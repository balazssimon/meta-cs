using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using Roslyn.Utilities;
using System.Collections.Concurrent;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Model;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpCompilation = Microsoft.CodeAnalysis.CSharp.CSharpCompilation;
    using MessageProvider = Microsoft.CodeAnalysis.CSharp.MessageProvider;
    using CommonAssemblyWellKnownAttributeData = Microsoft.CodeAnalysis.CommonAssemblyWellKnownAttributeData<MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol>;

    public partial class SourceAssemblySymbol 
    {
        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly LanguageCompilation _compilation;
        
        /// <summary>
        /// The source language of this assembly.
        /// </summary>
        private readonly Language _language;

        private CompletionState _state;

        /// <summary>
        /// Assembly's identity.
        /// </summary>
        internal AssemblyIdentity lazyAssemblyIdentity;
        private readonly string _assemblySimpleName;

        // Computing the identity requires computing the public key. Computing the public key 
        // can require binding attributes that contain version or strong name information. 
        // Attribute binding will check type visibility which will possibly 
        // check IVT relationships. To correctly determine the IVT relationship requires the public key. 
        // To avoid infinite recursion, this type notes, per thread, the assembly for which the thread 
        // is actively computing the public key (assemblyForWhichCurrentThreadIsComputingKeys). Should a request to determine IVT
        // relationship occur on the thread that is computing the public key, access is optimistically
        // granted provided the simple assembly names match. When such access is granted
        // the assembly to which we have been granted access is noted (optimisticallyGrantedInternalsAccess).
        // After the public key has been computed, the set of optimistic grants is reexamined 
        // to ensure that full identities match. This may produce diagnostics.
        private StrongNameKeys _lazyStrongNameKeys;

        /// <summary>
        /// A list of modules the assembly consists of. 
        /// The first (index=0) module is a SourceModuleSymbol, which is a primary module, the rest are net-modules.
        /// </summary>
        private readonly ImmutableArray<ModuleSymbol> _modules;

        private readonly ImmutableArray<ModuleSymbol> _peModules;

        /// <summary>
        /// Bag of assembly's custom attributes and decoded well-known attribute data from source.
        /// </summary>
        private CustomAttributesBag<AttributeData> _lazySourceAttributesBag;

        /// <summary>
        /// Bag of assembly's custom attributes and decoded well-known attribute data from added netmodules.
        /// </summary>
        private CustomAttributesBag<AttributeData> _lazyNetModuleAttributesBag;

        private IDictionary<string, NamedTypeSymbol> _lazyForwardedTypesFromSource;

        /// <summary>
        /// Indices of attributes that will not be emitted for one of two reasons:
        /// - They are duplicates of another attribute (i.e. attributes that bind to the same constructor and have identical arguments)
        /// - They are InternalsVisibleToAttributes with invalid assembly identities
        /// </summary>
        /// <remarks>
        /// These indices correspond to the merged assembly attributes from source and added net modules, i.e. attributes returned by <see cref="GetAttributes"/> method.
        /// </remarks>
        private ConcurrentSet<int> _lazyOmittedAttributeIndices;

        private ThreeState _lazyContainsExtensionMethods;

        /// <summary>
        /// Map for storing effectively private or effectively internal fields declared in this assembly but never initialized nor assigned.
        /// Each {symbol, bool} key-value pair in this map indicates the following:
        ///  (a) Key: Unassigned field symbol.
        ///  (b) Value: True if the unassigned field is effectively internal, false otherwise.
        /// </summary>
        private readonly ConcurrentDictionary<DeclaredSymbol, bool> _unassignedFieldsMap = new ConcurrentDictionary<DeclaredSymbol, bool>();

        /// <summary>
        /// private fields declared in this assembly but never read
        /// </summary>
        private readonly ConcurrentSet<DeclaredSymbol> _unreadFields = new ConcurrentSet<DeclaredSymbol>();

        /// <summary>
        /// We imitate the native compiler's policy of not warning about unused fields
        /// when the enclosing type is used by an extern method for a ref argument.
        /// Here we keep track of those types.
        /// </summary>
        internal ConcurrentSet<TypeSymbol> TypesReferencedInExternalMethods = new ConcurrentSet<TypeSymbol>();

        /// <summary>
        /// The warnings for unused fields.
        /// </summary>
        private ImmutableArray<Diagnostic> _unusedFieldWarnings;

        private ImmutableArray<object> _models;

        internal SourceAssemblySymbol(
            LanguageCompilation compilation,
            string assemblySimpleName,
            string moduleName,
            CSharpSymbolMap csharpSymbolMap,
            ImmutableArray<PEModule> netModules,
            ImmutableArray<CustomReference> customReferences)
        {
            Debug.Assert(compilation != null);
            Debug.Assert(assemblySimpleName != null);
            Debug.Assert(!String.IsNullOrWhiteSpace(moduleName));
            Debug.Assert(!netModules.IsDefault);

            _compilation = compilation;
            _language = _compilation.Language;
            _assemblySimpleName = assemblySimpleName;

            ArrayBuilder<object> modelBuilder0 = new ArrayBuilder<object>(1 + netModules.Length);
            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(1 + netModules.Length);

            var sourceModule = new SourceModuleSymbol(this, compilation.Declarations, moduleName);
            moduleBuilder.Add(sourceModule);

            var importOptions = (compilation.Options.MetadataImportOptions == MetadataImportOptions.All) ?
                MetadataImportOptions.All : MetadataImportOptions.Internal;

            if (netModules.Length > 0)
            {
                foreach (PEModule netModule in netModules)
                {
                    var moduleSymbol = new CSharpModuleSymbol(this, new CSharpSymbols.Metadata.PE.PEModuleSymbol(compilation.CSharpCompilationForReferenceManager.SourceAssembly, netModule, importOptions, moduleBuilder.Count), moduleBuilder.Count);
                    moduleBuilder.Add(csharpSymbolMap.RegisterModuleSymbol(moduleSymbol));
                    // SetReferences will be called later by the ReferenceManager (in CreateSourceAssemblyFullBind for 
                    // a fresh manager, in CreateSourceAssemblyReuseData for a reused one).
                }
            }
            _peModules = moduleBuilder.ToImmutable();

            if (customReferences.Length > 0)
            {
                foreach (var reference in customReferences.OfType<ModelReference>())
                {
                    var metadata = reference.GetMetadata();
                    if (metadata is ModelMetadata modelMetadata)
                    {
                        var model = modelMetadata.Model;
                        moduleBuilder.Add(new MetaModuleSymbol(this, model, moduleBuilder.Count));
                    }
                    if (metadata is ModelGroupMetadata modelGroupMetadata)
                    {
                        var modelGroup = modelGroupMetadata.ModelGroup;
                        moduleBuilder.Add(new MetaModuleSymbol(this, modelGroup, moduleBuilder.Count));
                    }
                }
            }
            _modules = moduleBuilder.ToImmutableAndFree();

            if (!compilation.Options.CryptoPublicKey.IsEmpty)
            {
                // Private key is not necessary for assembly identity, only when emitting.  For this reason, the private key can remain null.
                _lazyStrongNameKeys = StrongNameKeys.Create(compilation.Options.CryptoPublicKey, privateKey: null, hasCounterSignature: false, MessageProvider.Instance);
            }

            _state = CompletionState.Create(_language);
        }

        public override string Name
        {
            get
            {
                return _assemblySimpleName;
            }
        }

        public override Language Language => _language;

        public object Model => SourceModule.Model;

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        public sealed override LanguageCompilation DeclaringCompilation
        {
            get
            {
                return _compilation;
            }
        }

        public override bool IsInteractive
        {
            get
            {
                return _compilation.IsSubmission;
            }
        }

        internal bool MightContainNoPiaLocalTypes()
        {
            for (int i = 1; i < _peModules.Length; i++)
            {
                var csharpModuleSymbol = (CSharpModuleSymbol)_peModules[i];
                var peModuleSymbol = (CSharpSymbols.Metadata.PE.PEModuleSymbol)csharpModuleSymbol.UnderlyingModule;
                if (peModuleSymbol.Module.ContainsNoPiaLocalTypes())
                {
                    return true;
                }
            }

            return SourceModule.MightContainNoPiaLocalTypes();
        }

        public override AssemblyIdentity Identity
        {
            get
            {
                if (lazyAssemblyIdentity == null)
                    Interlocked.CompareExchange(ref lazyAssemblyIdentity, ComputeIdentity(), null);

                return lazyAssemblyIdentity;
            }
        }

        internal override DeclaredSymbol GetSpecialTypeMember(SpecialMember member)
        {
            return _compilation.IsMemberMissing(member) ? null : base.GetSpecialTypeMember(member);
        }

        private string GetWellKnownAttributeDataStringField(Func<CommonAssemblyWellKnownAttributeData, string> fieldGetter, string missingValue = null)
        {
            string fieldValue = missingValue;

            var data = GetSourceDecodedWellKnownAttributeData();
            if (data != null)
            {
                fieldValue = fieldGetter(data);
            }

            if ((object)fieldValue == (object)missingValue)
            {
                data = GetNetModuleDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue = fieldGetter(data);
                }
            }

            return fieldValue;
        }

        internal bool RuntimeCompatibilityWrapNonExceptionThrows
        {
            get
            {
                var data = GetSourceDecodedWellKnownAttributeData() ?? GetNetModuleDecodedWellKnownAttributeData();

                // By default WrapNonExceptionThrows is considered to be true.
                return (data != null) ? data.RuntimeCompatibilityWrapNonExceptionThrows : CommonAssemblyWellKnownAttributeData.WrapNonExceptionThrowsDefault;
            }
        }

        internal string FileVersion
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyFileVersionAttributeSetting);
            }
        }

        internal string Title
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyTitleAttributeSetting);
            }
        }

        internal string Description
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyDescriptionAttributeSetting);
            }
        }

        internal string Company
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyCompanyAttributeSetting);
            }
        }

        internal string Product
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyProductAttributeSetting);
            }
        }

        internal string InformationalVersion
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyInformationalVersionAttributeSetting);
            }
        }

        internal string Copyright
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyCopyrightAttributeSetting);
            }
        }

        internal string Trademark
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyTrademarkAttributeSetting);
            }
        }

        private ThreeState AssemblyDelaySignAttributeSetting
        {
            get
            {
                var defaultValue = ThreeState.Unknown;
                var fieldValue = defaultValue;

                var data = GetSourceDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue = data.AssemblyDelaySignAttributeSetting;
                }

                if (fieldValue == defaultValue)
                {
                    data = GetNetModuleDecodedWellKnownAttributeData();
                    if (data != null)
                    {
                        fieldValue = data.AssemblyDelaySignAttributeSetting;
                    }
                }

                return fieldValue;
            }
        }

        private string AssemblyKeyContainerAttributeSetting
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyKeyContainerAttributeSetting, WellKnownAttributeData.StringMissingValue);
            }
        }

        private string AssemblyKeyFileAttributeSetting
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyKeyFileAttributeSetting, WellKnownAttributeData.StringMissingValue);
            }
        }

        private string AssemblyCultureAttributeSetting
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblyCultureAttributeSetting);
            }
        }

        public string SignatureKey
        {
            get
            {
                return GetWellKnownAttributeDataStringField(data => data.AssemblySignatureKeyAttributeSetting);
            }
        }

        private Version AssemblyVersionAttributeSetting
        {
            get
            {
                var defaultValue = default(Version);
                var fieldValue = defaultValue;

                var data = GetSourceDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue = data.AssemblyVersionAttributeSetting;
                }

                if (fieldValue == defaultValue)
                {
                    data = GetNetModuleDecodedWellKnownAttributeData();
                    if (data != null)
                    {
                        fieldValue = data.AssemblyVersionAttributeSetting;
                    }
                }

                return fieldValue;
            }
        }

        public override Version AssemblyVersionPattern
        {
            get
            {
                var attributeValue = AssemblyVersionAttributeSetting;
                return (object)attributeValue == null || (attributeValue.Build != ushort.MaxValue && attributeValue.Revision != ushort.MaxValue) ? null : attributeValue;
            }
        }

        public AssemblyHashAlgorithm HashAlgorithm
        {
            get
            {
                return AssemblyAlgorithmIdAttributeSetting ?? AssemblyHashAlgorithm.Sha1;
            }
        }

        internal AssemblyHashAlgorithm? AssemblyAlgorithmIdAttributeSetting
        {
            get
            {
                var fieldValue = default(AssemblyHashAlgorithm?);

                var data = GetSourceDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue = data.AssemblyAlgorithmIdAttributeSetting;
                }

                if (!fieldValue.HasValue)
                {
                    data = GetNetModuleDecodedWellKnownAttributeData();
                    if (data != null)
                    {
                        fieldValue = data.AssemblyAlgorithmIdAttributeSetting;
                    }
                }

                return fieldValue;
            }
        }

        /// <summary>
        /// This represents what the user claimed in source through the AssemblyFlagsAttribute.
        /// It may be modified as emitted due to presence or absence of the public key.
        /// </summary>
        public AssemblyFlags AssemblyFlags
        {
            get
            {
                var defaultValue = default(AssemblyFlags);
                var fieldValue = defaultValue;

                var data = GetSourceDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue = data.AssemblyFlagsAttributeSetting;
                }

                data = GetNetModuleDecodedWellKnownAttributeData();
                if (data != null)
                {
                    fieldValue |= data.AssemblyFlagsAttributeSetting;
                }

                return fieldValue;
            }
        }

        private StrongNameKeys ComputeStrongNameKeys()
        {
            // TODO:
            // In order to allow users to escape problems that we create with our provisional granting of IVT access,
            // consider not binding the attributes if the command line options were specified, then later bind them
            // and report warnings if both were used.
            EnsureAttributesAreBound();

            // when both attributes and command-line options specified, cmd line wins.
            string keyFile = _compilation.Options.CryptoKeyFile;

            // Public sign requires a keyfile
            if (DeclaringCompilation.Options.PublicSign)
            {
                // TODO(https://github.com/dotnet/roslyn/issues/9150):
                // Provide better error message if keys are provided by
                // the attributes. Right now we'll just fall through to the
                // "no key available" error.

                if (!string.IsNullOrEmpty(keyFile) && !PathUtilities.IsAbsolute(keyFile))
                {
                    // If keyFile has a relative path then there should be a diagnostic
                    // about it
                    Debug.Assert(!DeclaringCompilation.Options.Errors.IsEmpty);
                    return StrongNameKeys.None;
                }

                // If we're public signing, we don't need a strong name provider
                return StrongNameKeys.Create(keyFile, MessageProvider.Instance);
            }

            if (string.IsNullOrEmpty(keyFile))
            {
                keyFile = this.AssemblyKeyFileAttributeSetting;

                if ((object)keyFile == (object)WellKnownAttributeData.StringMissingValue)
                {
                    keyFile = null;
                }
            }

            string keyContainer = _compilation.Options.CryptoKeyContainer;

            if (string.IsNullOrEmpty(keyContainer))
            {
                keyContainer = this.AssemblyKeyContainerAttributeSetting;

                if ((object)keyContainer == (object)WellKnownAttributeData.StringMissingValue)
                {
                    keyContainer = null;
                }
            }

            var hasCounterSignature = !string.IsNullOrEmpty(this.SignatureKey);
            return StrongNameKeys.Create(DeclaringCompilation.Options.StrongNameProvider, keyFile, keyContainer, hasCounterSignature, MessageProvider.Instance);
        }

        // A collection of assemblies to which we were granted internals access by only checking matches for assembly name
        // and ignoring public key. This just acts as a set. The bool is ignored.
        private ConcurrentDictionary<AssemblySymbol, bool> _optimisticallyGrantedInternalsAccess;

        //EDMAURER please don't use thread local storage widely. This is hoped to be a one-off usage.
        [ThreadStatic]
        private static AssemblySymbol t_assemblyForWhichCurrentThreadIsComputingKeys;

        internal StrongNameKeys StrongNameKeys
        {
            get
            {
                if (_lazyStrongNameKeys == null)
                {
                    try
                    {
                        t_assemblyForWhichCurrentThreadIsComputingKeys = this;
                        Interlocked.CompareExchange(ref _lazyStrongNameKeys, ComputeStrongNameKeys(), null);
                    }
                    finally
                    {
                        t_assemblyForWhichCurrentThreadIsComputingKeys = null;
                    }
                }

                return _lazyStrongNameKeys;
            }
        }

        internal override ImmutableArray<byte> PublicKey
        {
            get { return StrongNameKeys.PublicKey; }
        }

        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                return _modules;
            }
        }

        internal ImmutableArray<ModuleSymbol> PEModules => _peModules;

        //TODO: cache
        public override ImmutableArray<Location> Locations
        {
            get
            {
                return this.Modules.SelectMany(m => m.Locations).AsImmutable();
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        private void ValidateAttributeSemantics(DiagnosticBag diagnostics)
        {
            //diagnostics that come from computing the public key.
            //If building a netmodule, strong name keys need not be validated. Dev11 didn't.
            if (StrongNameKeys.DiagnosticOpt != null && !_compilation.Options.OutputKind.IsNetModule())
            {
                diagnostics.Add(StrongNameKeys.DiagnosticOpt);
            }

            ValidateIVTPublicKeys(diagnostics);
            //diagnostics that result from IVT checks performed while in the process of computing the public key.
            CheckOptimisticIVTAccessGrants(diagnostics);

            DetectAttributeAndOptionConflicts(diagnostics);

            if (IsDelaySigned && !Identity.HasPublicKey)
            {
                diagnostics.Add(InternalErrorCode.WRN_DelaySignButNoKey, NoLocation.Singleton);
            }

            if (DeclaringCompilation.Options.PublicSign)
            {
                if (_compilation.Options.OutputKind.IsNetModule())
                {
                    diagnostics.Add(InternalErrorCode.ERR_PublicSignNetModule, NoLocation.Singleton);
                }
                else if (!Identity.HasPublicKey)
                {
                    diagnostics.Add(InternalErrorCode.ERR_PublicSignButNoKey, NoLocation.Singleton);
                }
            }

            // If the options and attributes applied on the compilation imply real signing,
            // but we have no private key to sign it with report an error.
            // Note that if public key is set and delay sign is off we do OSS signing, which doesn't require private key.
            // Consider: should we allow to OSS sign if the key file only contains public key?

            if (DeclaringCompilation.Options.OutputKind != OutputKind.NetModule &&
                DeclaringCompilation.Options.CryptoPublicKey.IsEmpty &&
                Identity.HasPublicKey &&
                !IsDelaySigned &&
                !DeclaringCompilation.Options.PublicSign &&
                !StrongNameKeys.CanSign &&
                StrongNameKeys.DiagnosticOpt == null)
            {
                // Since the container always contains both keys, the problem is that the key file didn't contain private key.
                diagnostics.Add(InternalErrorCode.ERR_SignButNoPrivateKey, NoLocation.Singleton, StrongNameKeys.KeyFilePath);
            }

            ReportDiagnosticsForSynthesizedAttributes(_compilation, diagnostics);
        }

        /// <summary>
        /// We're going to synthesize some well-known attributes for this assembly symbol.  However, at synthesis time, it is
        /// too late to report diagnostics or cancel the emit.  Instead, we check for use site errors on the types and members
        /// we know we'll need at synthesis time.
        /// </summary>
        /// <remarks>
        /// As in Dev10, we won't report anything if the attribute TYPES are missing (note: missing, not erroneous) because we won't
        /// synthesize anything in that case.  We'll only report diagnostics if the attribute TYPES are present and either they or 
        /// the attribute CONSTRUCTORS have errors.
        /// </remarks>
        private static void ReportDiagnosticsForSynthesizedAttributes(LanguageCompilation compilation, DiagnosticBag diagnostics)
        {
            // TODO:MetaDslx
        }

        private void ValidateIVTPublicKeys(DiagnosticBag diagnostics)
        {
            EnsureAttributesAreBound();

            if (!this.Identity.IsStrongName)
                return;

            if (_lazyInternalsVisibleToMap != null)
            {
                foreach (var keys in _lazyInternalsVisibleToMap.Values)
                {
                    foreach (var oneKey in keys)
                    {
                        if (oneKey.Key.IsDefaultOrEmpty)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_FriendAssemblySNReq, oneKey.Value.Item1, oneKey.Value.Item2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// True if internals are exposed at all.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// This property shouldn't be accessed during binding as it can lead to attribute binding cycle.
        /// </remarks>
        public bool InternalsAreVisible
        {
            get
            {
                EnsureAttributesAreBound();
                return _lazyInternalsVisibleToMap != null;
            }
        }

        private void DetectAttributeAndOptionConflicts(DiagnosticBag diagnostics)
        {
            EnsureAttributesAreBound();
            // TODO:MetaDslx
        }

        internal bool IsDelaySigned
        {
            get
            {
                //commandline setting trumps attribute value. Warning assumed to be given elsewhere
                if (_compilation.Options.DelaySign.HasValue)
                {
                    return _compilation.Options.DelaySign.Value;
                }

                // The public sign argument should also override the attribute
                if (_compilation.Options.PublicSign)
                {
                    return false;
                }

                return (this.AssemblyDelaySignAttributeSetting == ThreeState.True);
            }
        }

        internal SourceModuleSymbol SourceModule
        {
            get { return (SourceModuleSymbol)this.Modules[0]; }
        }

        /*public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if (completionPart != null && _state.HasComplete(completionPart)) return;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionGraph.Attributes)
                {
                    EnsureAttributesAreBound();
                }
                else if (incompletePart == CompletionGraph.StartAttributeChecks || incompletePart == CompletionGraph.FinishAttributeChecks)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartAttributeChecks))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        ValidateAttributeSemantics(diagnostics);
                        AddDeclarationDiagnostics(diagnostics);
                        var thisThreadCompleted = _state.NotePartComplete(CompletionGraph.FinishAttributeChecks);
                        Debug.Assert(thisThreadCompleted);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.Module)
                {
                    SourceModule.ForceComplete(null, locationOpt, cancellationToken);
                    if (SourceModule.HasComplete(CompletionGraph.ChildrenCompleted))
                    {
                        _state.NotePartComplete(CompletionGraph.Module);
                    }
                    else
                    {
                        Debug.Assert(locationOpt != null, "If no location was specified, then the module members should be completed");
                        // this is the last completion part we can handle if there is a location.
                        return;
                    }
                }
                else if (incompletePart == CompletionGraph.StartValidatingAddedModules || incompletePart == CompletionGraph.FinishValidatingAddedModules)
                {
                    if (_state.NotePartComplete(CompletionGraph.StartValidatingAddedModules))
                    {
                        ReportDiagnosticsForAddedModules();
                        var thisThreadCompleted = _state.NotePartComplete(CompletionGraph.FinishValidatingAddedModules);
                        Debug.Assert(thisThreadCompleted);
                    }
                }
                else if (incompletePart == null || incompletePart == CompletionGraph.None)
                {
                    return;
                }
                else
                {
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }

                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }
        */
        private void ReportDiagnosticsForAddedModules()
        {
            var diagnostics = DiagnosticBag.GetInstance();

            foreach (var pair in _compilation.GetBoundReferenceManager().ReferencedModuleIndexMap)
            {
                var fileRef = pair.Key as PortableExecutableReference;

                if ((object)fileRef != null && (object)fileRef.FilePath != null)
                {
                    string fileName = FileNameUtilities.GetFileName(fileRef.FilePath);
                    string moduleName = _peModules[pair.Value].Name;

                    if (!string.Equals(fileName, moduleName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Used to be ERR_ALinkFailed
                        diagnostics.Add(InternalErrorCode.ERR_NetModuleNameMismatch, NoLocation.Singleton, moduleName, fileName);
                    }
                }
            }

            // Alink performed these checks only when emitting an assembly.
            if (_peModules.Length > 1 && !_compilation.Options.OutputKind.IsNetModule())
            {
                var assemblyMachine = this.Machine;
                bool isPlatformAgnostic = (assemblyMachine == System.Reflection.PortableExecutable.Machine.I386 && !this.Bit32Required);
                var knownModuleNames = new HashSet<String>(StringComparer.OrdinalIgnoreCase);

                for (int i = 1; i < _peModules.Length; i++)
                {
                    var m = (CSharpModuleSymbol)_peModules[i];
                    var pem = ((CSharpSymbols.Metadata.PE.PEModuleSymbol)m.UnderlyingModule);
                    if (!knownModuleNames.Add(m.Name))
                    {
                        diagnostics.Add(InternalErrorCode.ERR_NetModuleNameMustBeUnique, NoLocation.Singleton, m.Name);
                    }

                    if (!pem.Module.IsCOFFOnly)
                    {
                        var moduleMachine = m.Machine;

                        if (moduleMachine == System.Reflection.PortableExecutable.Machine.I386 && !m.Bit32Required)
                        {
                            // Other module is agnostic, this is always safe
                            ;
                        }
                        else if (isPlatformAgnostic)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_AgnosticToMachineModule, NoLocation.Singleton, m);
                        }
                        else if (assemblyMachine != moduleMachine)
                        {
                            // Different machine types, and neither is agnostic
                            // So it is a conflict
                            diagnostics.Add(InternalErrorCode.ERR_ConflictingMachineModule, NoLocation.Singleton, m);
                        }
                    }
                }

                // Assembly main module must explicitly reference all the modules referenced by other assembly 
                // modules, i.e. all modules from transitive closure must be referenced explicitly here
                for (int i = 1; i < _peModules.Length; i++)
                {
                    var m = (CSharpModuleSymbol)_peModules[i];
                    var pem = ((CSharpSymbols.Metadata.PE.PEModuleSymbol)m.UnderlyingModule);
                    try
                    {
                        foreach (var referencedModuleName in pem.Module.GetReferencedManagedModulesOrThrow())
                        {
                            // Do not report error for this module twice
                            if (knownModuleNames.Add(referencedModuleName))
                            {
                                diagnostics.Add(InternalErrorCode.ERR_MissingNetModuleReference, NoLocation.Singleton, referencedModuleName);
                            }
                        }
                    }
                    catch (BadImageFormatException)
                    {
                        diagnostics.Add(new LanguageDiagnosticInfo(InternalErrorCode.ERR_BindToBogus, m), NoLocation.Singleton);
                    }
                }
            }

            ReportNameCollisionDiagnosticsForAddedModules(this.GlobalNamespace, diagnostics);

            _compilation.DeclarationDiagnostics.AddRange(diagnostics);
            diagnostics.Free();
        }

        private void ReportNameCollisionDiagnosticsForAddedModules(NamespaceSymbol ns, DiagnosticBag diagnostics)
        {
            var mergedNs = ns as MergedNamespaceSymbol;

            if ((object)mergedNs == null)
            {
                return;
            }

            ImmutableArray<NamespaceSymbol> constituent = mergedNs.ConstituentNamespaces;

            if (constituent.Length > 2 || (constituent.Length == 2 && constituent[0].ContainingModule.Ordinal != 0 && constituent[1].ContainingModule.Ordinal != 0))
            {
                var topLevelTypesFromModules = ArrayBuilder<NamedTypeSymbol>.GetInstance();

                foreach (var moduleNs in constituent)
                {
                    Debug.Assert(moduleNs.Extent.Kind == NamespaceKind.Module);

                    if (moduleNs.ContainingModule.Ordinal != 0)
                    {
                        topLevelTypesFromModules.AddRange(moduleNs.GetTypeMembers());
                    }
                }

                topLevelTypesFromModules.Sort(NameCollisionForAddedModulesTypeComparer.Singleton);

                bool reportedAnError = false;

                for (int i = 0; i < topLevelTypesFromModules.Count - 1; i++)
                {
                    NamedTypeSymbol x = topLevelTypesFromModules[i];
                    NamedTypeSymbol y = topLevelTypesFromModules[i + 1];

                    if (x.Arity == y.Arity && x.Name == y.Name)
                    {
                        if (!reportedAnError)
                        {
                            // Skip synthetic <Module> type which every .NET module has.
                            if (x.Arity != 0 || !x.ContainingNamespace.IsGlobalNamespace || x.Name != "<Module>")
                            {
                                diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInNS, y.Locations[0],
                                                y.ToDisplayString(SymbolDisplayFormat.ShortFormat),
                                                y.ContainingNamespace);
                            }

                            reportedAnError = true;
                        }
                    }
                    else
                    {
                        reportedAnError = false;
                    }
                }

                topLevelTypesFromModules.Free();

                // Descent into child namespaces.
                foreach (Symbol member in mergedNs.GetMembers())
                {
                    if (member.Kind == SymbolKind.Namespace)
                    {
                        ReportNameCollisionDiagnosticsForAddedModules((NamespaceSymbol)member, diagnostics);
                    }
                }
            }
        }

        private class NameCollisionForAddedModulesTypeComparer : IComparer<NamedTypeSymbol>
        {
            public static readonly NameCollisionForAddedModulesTypeComparer Singleton = new NameCollisionForAddedModulesTypeComparer();

            private NameCollisionForAddedModulesTypeComparer() { }

            public int Compare(NamedTypeSymbol x, NamedTypeSymbol y)
            {
                int result = String.CompareOrdinal(x.Name, y.Name);

                if (result == 0)
                {
                    result = x.Arity - y.Arity;

                    if (result == 0)
                    {
                        result = x.ContainingModule.Ordinal - y.ContainingModule.Ordinal;
                    }
                }

                return result;
            }
        }

        private bool IsKnownAssemblyAttribute(AttributeData attribute)
        {
            // TODO: This list used to include AssemblyOperatingSystemAttribute and AssemblyProcessorAttribute,
            //       but it doesn't look like they are defined, cannot find them on MSDN.
            /* TODO:MetaDslx
            if (attribute.IsTargetAttribute(this, AttributeDescription.AssemblyTitleAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyDescriptionAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyConfigurationAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyCultureAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyVersionAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyCompanyAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyProductAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyInformationalVersionAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyCopyrightAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyTrademarkAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyKeyFileAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyKeyNameAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyAlgorithmIdAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyFlagsAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyDelaySignAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblyFileVersionAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.SatelliteContractVersionAttribute) ||
                attribute.IsTargetAttribute(this, AttributeDescription.AssemblySignatureKeyAttribute))
            {
                return true;
            }
            */
            return false;
        }

        private void AddOmittedAttributeIndex(int index)
        {
            if (_lazyOmittedAttributeIndices == null)
            {
                Interlocked.CompareExchange(ref _lazyOmittedAttributeIndices, new ConcurrentSet<int>(), null);
            }

            _lazyOmittedAttributeIndices.Add(index);
        }

        /// <summary>
        /// Gets unique source assembly attributes that should be emitted,
        /// i.e. filters out attributes with errors and duplicate attributes.
        /// </summary>
        private HashSet<AttributeData> GetUniqueSourceAssemblyAttributes()
        {
            ImmutableArray<AttributeData> appliedSourceAttributes = this.GetSourceAttributesBag().Attributes;

            HashSet<AttributeData> uniqueAttributes = null;

            for (int i = 0; i < appliedSourceAttributes.Length; i++)
            {
                AttributeData attribute = appliedSourceAttributes[i];
                if (!attribute.HasErrors)
                {
                    if (!AddUniqueAssemblyAttribute(attribute, ref uniqueAttributes))
                    {
                        AddOmittedAttributeIndex(i);
                    }
                }
            }

            return uniqueAttributes;
        }

        private static bool AddUniqueAssemblyAttribute(AttributeData attribute, ref HashSet<AttributeData> uniqueAttributes)
        {
            Debug.Assert(!attribute.HasErrors);

            if (uniqueAttributes == null)
            {
                uniqueAttributes = new HashSet<AttributeData>(comparer: CommonAttributeDataComparer.Instance);
            }

            return uniqueAttributes.Add(attribute);
        }

        private ImmutableArray<AttributeData> GetNetModuleAttributes(out ImmutableArray<string> netModuleNames)
        {
            ArrayBuilder<AttributeData> moduleAssemblyAttributesBuilder = null;
            ArrayBuilder<string> netModuleNameBuilder = null;

            for (int i = 1; i < _peModules.Length; i++)
            {
                var m = (CSharpModuleSymbol)_peModules[i];
                var peModuleSymbol = ((CSharpSymbols.Metadata.PE.PEModuleSymbol)m.UnderlyingModule);
                string netModuleName = peModuleSymbol.Name;
                foreach (var attributeData in peModuleSymbol.GetAssemblyAttributes())
                {
                    if (netModuleNameBuilder == null)
                    {
                        netModuleNameBuilder = ArrayBuilder<string>.GetInstance();
                        moduleAssemblyAttributesBuilder = ArrayBuilder<AttributeData>.GetInstance();
                    }

                    netModuleNameBuilder.Add(netModuleName);
                    moduleAssemblyAttributesBuilder.Add(attributeData);
                }
            }
            // TODO:MetaDslx - non-CSharp modules

            if (netModuleNameBuilder == null)
            {
                netModuleNames = ImmutableArray<string>.Empty;
                return ImmutableArray<AttributeData>.Empty;
            }

            netModuleNames = netModuleNameBuilder.ToImmutableAndFree();
            return moduleAssemblyAttributesBuilder.ToImmutableAndFree();
        }

        private WellKnownAttributeData ValidateAttributeUsageAndDecodeWellKnownAttributes(
            ImmutableArray<AttributeData> attributesFromNetModules,
            ImmutableArray<string> netModuleNames,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(attributesFromNetModules.Any());
            Debug.Assert(netModuleNames.Any());
            Debug.Assert(attributesFromNetModules.Length == netModuleNames.Length);
            // TODO:MetaDslx
            return null;
        }

        private void LoadAndValidateNetModuleAttributes(ref CustomAttributesBag<AttributeData> lazyNetModuleAttributesBag)
        {
            if (_compilation.Options.OutputKind.IsNetModule())
            {
                Interlocked.CompareExchange(ref lazyNetModuleAttributesBag, CustomAttributesBag<AttributeData>.Empty, null);
            }
            else
            {
                var diagnostics = DiagnosticBag.GetInstance();

                ImmutableArray<string> netModuleNames;
                ImmutableArray<AttributeData> attributesFromNetModules = GetNetModuleAttributes(out netModuleNames);

                WellKnownAttributeData wellKnownData = null;

                if (attributesFromNetModules.Any())
                {
                    wellKnownData = ValidateAttributeUsageAndDecodeWellKnownAttributes(attributesFromNetModules, netModuleNames, diagnostics);
                }
                else
                {
                    // Compute duplicate source assembly attributes, i.e. attributes with same constructor and arguments, that must not be emitted.
                    var unused = GetUniqueSourceAssemblyAttributes();
                }

                // Load type forwarders from modules
                HashSet<NamedTypeSymbol> forwardedTypes = null;

                // Similar to attributes, type forwarders from the second added module should override type forwarders from the first added module, etc. 
                // This affects only diagnostics.
                for (int i = _peModules.Length - 1; i > 0; i--)
                {
                    var csharpModuleSymbol = (CSharpModuleSymbol)_peModules[i];

                    foreach (NamedTypeSymbol forwarded in csharpModuleSymbol.GetForwardedTypes())
                    {
                        if (forwardedTypes == null)
                        {
                            if (wellKnownData == null)
                            {
                                wellKnownData = new CommonAssemblyWellKnownAttributeData();
                            }

                            forwardedTypes = ((CommonAssemblyWellKnownAttributeData)wellKnownData).ForwardedTypes;
                            if (forwardedTypes == null)
                            {
                                forwardedTypes = new HashSet<NamedTypeSymbol>();
                                ((CommonAssemblyWellKnownAttributeData)wellKnownData).ForwardedTypes = forwardedTypes;
                            }
                        }

                        if (forwardedTypes.Add(forwarded))
                        {
                            if (forwarded.IsErrorType())
                            {
                                DiagnosticInfo info = forwarded.GetUseSiteDiagnostic() ?? ((ErrorTypeSymbol)forwarded).ErrorInfo;

                                if ((object)info != null)
                                {
                                    diagnostics.Add(info, NoLocation.Singleton);
                                }
                            }
                        }
                    }
                }
                // TODO:MetaDslx - non-CSharp modules

                CustomAttributesBag<AttributeData> netModuleAttributesBag;

                if (wellKnownData != null || attributesFromNetModules.Any())
                {
                    netModuleAttributesBag = new CustomAttributesBag<AttributeData>();

                    netModuleAttributesBag.SetEarlyDecodedWellKnownAttributeData(null);
                    netModuleAttributesBag.SetDecodedWellKnownAttributeData(wellKnownData);
                    netModuleAttributesBag.SetAttributes(attributesFromNetModules);
                    if (netModuleAttributesBag.IsEmpty) netModuleAttributesBag = CustomAttributesBag<AttributeData>.Empty;
                }
                else
                {
                    netModuleAttributesBag = CustomAttributesBag<AttributeData>.Empty;
                }

                if (Interlocked.CompareExchange(ref lazyNetModuleAttributesBag, netModuleAttributesBag, null) == null)
                {
                    this.AddDeclarationDiagnostics(diagnostics);
                }

                diagnostics.Free();
            }

            Debug.Assert(lazyNetModuleAttributesBag.IsSealed);
        }

        private void EnsureNetModuleAttributesAreBound()
        {
            if (_lazyNetModuleAttributesBag == null)
            {
                LoadAndValidateNetModuleAttributes(ref _lazyNetModuleAttributesBag);
            }
        }

        private CustomAttributesBag<AttributeData> GetNetModuleAttributesBag()
        {
            EnsureNetModuleAttributesAreBound();
            return _lazyNetModuleAttributesBag;
        }

        internal CommonAssemblyWellKnownAttributeData GetNetModuleDecodedWellKnownAttributeData()
        {
            var attributesBag = this.GetNetModuleAttributesBag();
            Debug.Assert(attributesBag.IsSealed);
            return (CommonAssemblyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        private void EnsureAttributesAreBound()
        {
            /* TODO:MetaDslx
            if ((_lazySourceAttributesBag == null || !_lazySourceAttributesBag.IsSealed) &&
                LoadAndValidateAttributes(OneOrMany.Create(GetAttributeDeclarations()), ref _lazySourceAttributesBag))
            {
                _state.NotePartComplete(CompletionGraph.Attributes);
            }*/
            if (_lazySourceAttributesBag == null)
            {
                Interlocked.CompareExchange(ref _lazySourceAttributesBag, CustomAttributesBag<AttributeData>.Empty, null);
                _state.NotePartComplete(CompletionGraph.Attributes);
            }
        }

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes. Returns null if there are no attributes applied on the symbol.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CustomAttributesBag<AttributeData> GetSourceAttributesBag()
        {
            EnsureAttributesAreBound();
            return _lazySourceAttributesBag;
        }

        /// <summary>
        /// Gets the attributes applied on this symbol.
        /// Returns an empty array if there are no attributes.
        /// </summary>
        /// <remarks>
        /// NOTE: This method should always be kept as a sealed override.
        /// If you want to override attribute binding logic for a sub-class, then override <see cref="GetSourceAttributesBag"/> method.
        /// </remarks>
        public sealed override ImmutableArray<AttributeData> GetAttributes()
        {
            var attributes = this.GetSourceAttributesBag().Attributes;
            var netmoduleAttributes = this.GetNetModuleAttributesBag().Attributes;
            Debug.Assert(!attributes.IsDefault);
            Debug.Assert(!netmoduleAttributes.IsDefault);

            if (attributes.Length > 0)
            {
                if (netmoduleAttributes.Length > 0)
                {
                    attributes = attributes.Concat(netmoduleAttributes);
                }
            }
            else
            {
                attributes = netmoduleAttributes;
            }

            Debug.Assert(!attributes.IsDefault);
            return attributes;
        }

        /// <summary>
        /// Returns data decoded from source assembly attributes or null if there are none.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// TODO: We should replace methods GetSourceDecodedWellKnownAttributeData and GetNetModuleDecodedWellKnownAttributeData with
        /// a single method GetDecodedWellKnownAttributeData, which merges DecodedWellKnownAttributeData from source and netmodule attributes.
        /// </remarks>
        internal CommonAssemblyWellKnownAttributeData GetSourceDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazySourceAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetSourceAttributesBag();
            }

            return (CommonAssemblyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        /// <summary>
        /// This only forces binding of attributes that look like they may be forwarded types attributes (syntactically).
        /// </summary>
        internal HashSet<NamedTypeSymbol> GetForwardedTypes()
        {
            CustomAttributesBag<AttributeData> attributesBag = _lazySourceAttributesBag;
            if (attributesBag?.IsDecodedWellKnownAttributeDataComputed == true)
            {
                // Use already decoded attributes
                return ((CommonAssemblyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData)?.ForwardedTypes;
            }

            /* TODO:MetaDslx
            attributesBag = null;
            LoadAndValidateAttributes(OneOrMany.Create(GetAttributeDeclarations()), ref attributesBag, attributeMatchesOpt: this.IsPossibleForwardedTypesAttribute);
            */
            attributesBag = new CustomAttributesBag<AttributeData>();

            var wellKnownAttributeData = (CommonAssemblyWellKnownAttributeData)attributesBag?.DecodedWellKnownAttributeData;
            return wellKnownAttributeData?.ForwardedTypes;
        }

        internal override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            return _modules[0].ReferencedAssemblySymbols;
        }

        internal override void SetNoPiaResolutionAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override ImmutableArray<AssemblySymbol> GetLinkedReferencedAssemblies()
        {
            // SourceAssemblySymbol is never used directly as a reference
            // when it is or any of its references is linked.
            return default(ImmutableArray<AssemblySymbol>);
        }

        internal override void SetLinkedReferencedAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            // SourceAssemblySymbol is never used directly as a reference
            // when it is or any of its references is linked.
            throw ExceptionUtilities.Unreachable;
        }

        public override bool IsLinked
        {
            get
            {
                return false;
            }
        }

        internal bool DeclaresTheObjectClass
        {
            get
            {
                if ((object)this.CorLibrary != (object)this)
                {
                    return false;
                }

                var obj = (NamedTypeSymbol)GetSpecialSymbol(SpecialType.System_Object);

                return !obj.IsErrorType() && obj.DeclaredAccessibility == Accessibility.Public;
            }
        }

        public override bool MightContainExtensionMethods
        {
            get
            {
                // Note this method returns true until all ContainsExtensionMethods is
                // called, after which the correct value will be returned. In other words,
                // the return value may change from true to false on subsequent calls.
                if (_lazyContainsExtensionMethods.HasValue())
                {
                    return _lazyContainsExtensionMethods.Value();
                }
                return true;
            }
        }

        private bool HasDebuggableAttribute
        {
            get
            {
                CommonAssemblyWellKnownAttributeData assemblyData = this.GetSourceDecodedWellKnownAttributeData();
                return assemblyData != null && assemblyData.HasDebuggableAttribute;
            }
        }

        private bool HasReferenceAssemblyAttribute
        {
            get
            {
                CommonAssemblyWellKnownAttributeData assemblyData = this.GetSourceDecodedWellKnownAttributeData();
                return assemblyData != null && assemblyData.HasReferenceAssemblyAttribute;
            }
        }

        /// <summary>
        /// Returns true if and only if at least one type within the assembly contains
        /// extension methods. Note, this method is expensive since it potentially
        /// inspects all types within the assembly. The expectation is that this method is
        /// only called at emit time, when all types have been or will be traversed anyway.
        /// </summary>
        private bool ContainsExtensionMethods()
        {
            if (!_lazyContainsExtensionMethods.HasValue())
            {
                _lazyContainsExtensionMethods = ContainsExtensionMethods(_modules).ToThreeState();
            }

            return _lazyContainsExtensionMethods.Value();
        }

        private static bool ContainsExtensionMethods(ImmutableArray<ModuleSymbol> modules)
        {
            foreach (var module in modules)
            {
                if (ContainsExtensionMethods(module.GlobalNamespace))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ContainsExtensionMethods(NamespaceSymbol ns)
        {
            foreach (var member in ns.GetMembersUnordered())
            {
                switch (member.Kind.Switch())
                {
                    case SymbolKind.Namespace:
                        if (ContainsExtensionMethods((NamespaceSymbol)member))
                        {
                            return true;
                        }
                        break;
                    case SymbolKind.NamedType:
                        if (((NamedTypeSymbol)member).MightContainExtensionMethods)
                        {
                            return true;
                        }
                        break;
                    default:
                        throw ExceptionUtilities.UnexpectedValue(member.Kind);
                }
            }
            return false;
        }

        //Once the computation of the AssemblyIdentity is complete, check whether
        //any of the IVT access grants that were optimistically made during AssemblyIdentity computation
        //are in fact invalid now that the full identity is known.
        private void CheckOptimisticIVTAccessGrants(DiagnosticBag bag)
        {
            ConcurrentDictionary<AssemblySymbol, bool> haveGrantedAssemblies = _optimisticallyGrantedInternalsAccess;

            if (haveGrantedAssemblies != null)
            {
                foreach (var otherAssembly in haveGrantedAssemblies.Keys)
                {
                    IVTConclusion conclusion = MakeFinalIVTDetermination(otherAssembly);

                    Debug.Assert(conclusion != IVTConclusion.NoRelationshipClaimed);

                    if (conclusion == IVTConclusion.PublicKeyDoesntMatch)
                        bag.Add(InternalErrorCode.ERR_FriendRefNotEqualToThis, NoLocation.Singleton,
                                                                      otherAssembly.Identity, this.Identity);
                    else if (conclusion == IVTConclusion.OneSignedOneNot)
                        bag.Add(InternalErrorCode.ERR_FriendRefSigningMismatch, NoLocation.Singleton,
                                                                      otherAssembly.Identity);
                }
            }
        }

        internal override IEnumerable<ImmutableArray<byte>> GetInternalsVisibleToPublicKeys(string simpleName)
        {
            //EDMAURER assume that if EnsureAttributesAreBound() returns, then the internals visible to map has been populated.
            //Do not optimize by checking if m_lazyInternalsVisibleToMap is Nothing. It may be non-null yet still
            //incomplete because another thread is in the process of building it.

            EnsureAttributesAreBound();

            if (_lazyInternalsVisibleToMap == null)
                return SpecializedCollections.EmptyEnumerable<ImmutableArray<byte>>();

            ConcurrentDictionary<ImmutableArray<byte>, Tuple<Location, string>> result = null;

            _lazyInternalsVisibleToMap.TryGetValue(simpleName, out result);

            return (result != null) ? result.Keys : SpecializedCollections.EmptyEnumerable<ImmutableArray<byte>>();
        }

        internal override bool AreInternalsVisibleToThisAssembly(AssemblySymbol potentialGiverOfAccess)
        {
            // Ensure that optimistic IVT access is only granted to requests that originated on the thread
            //that is trying to compute the assembly identity. This gives us deterministic behavior when
            //two threads are checking IVT access but only one of them is in the process of computing identity.

            //as an optimization confirm that the identity has not yet been computed to avoid testing TLS
            if (_lazyStrongNameKeys == null)
            {
                var assemblyWhoseKeysAreBeingComputed = t_assemblyForWhichCurrentThreadIsComputingKeys;
                if ((object)assemblyWhoseKeysAreBeingComputed != null)
                {
                    //ThrowIfFalse(assemblyWhoseKeysAreBeingComputed Is Me);
                    if (!potentialGiverOfAccess.GetInternalsVisibleToPublicKeys(this.Name).IsEmpty())
                    {
                        if (_optimisticallyGrantedInternalsAccess == null)
                            Interlocked.CompareExchange(ref _optimisticallyGrantedInternalsAccess, new ConcurrentDictionary<AssemblySymbol, bool>(), null);

                        _optimisticallyGrantedInternalsAccess.TryAdd(potentialGiverOfAccess, true);
                        return true;
                    }
                    else
                        return false;
                }
            }

            IVTConclusion conclusion = MakeFinalIVTDetermination(potentialGiverOfAccess);

            return conclusion == IVTConclusion.Match || conclusion == IVTConclusion.OneSignedOneNot;
        }

        private AssemblyIdentity ComputeIdentity()
        {
            return new AssemblyIdentity(
                _assemblySimpleName,
                VersionHelper.GenerateVersionFromPatternAndCurrentTime(_compilation.Options.CurrentLocalTime, AssemblyVersionAttributeSetting),
                this.AssemblyCultureAttributeSetting,
                StrongNameKeys.PublicKey,
                hasPublicKey: !StrongNameKeys.PublicKey.IsDefault);
        }

        //This maps from assembly name to a set of public keys. It uses concurrent dictionaries because it is built,
        //one attribute at a time, in the callback that validates an attribute's application to a symbol. It is assumed
        //to be complete after a call to GetAttributes(). The second dictionary is acting like a set. The value element is
        //only used when the key is empty in which case it stores the location and value of the attribute string which
        //may be used to construct a diagnostic if the assembly being compiled is found to be strong named.
        private ConcurrentDictionary<string, ConcurrentDictionary<ImmutableArray<byte>, Tuple<Location, string>>> _lazyInternalsVisibleToMap;

        private static Location GetAssemblyAttributeLocationForDiagnostic(SyntaxNode attributeSyntaxOpt)
        {
            return (object)attributeSyntaxOpt != null ? attributeSyntaxOpt.Location : NoLocation.Singleton;
        }

        internal void NoteSymbolAccess(DeclaredSymbol symbol, bool read, bool write)
        {
            var container = symbol.ContainingSymbol as SourceNamedTypeSymbol;
            if ((object)container == null)
            {
                // field is not in source.
                return;
            }

            container.EnsureSymbolDefinitionsNoted();

            if (_unusedFieldWarnings.IsDefault)
            {
                if (read)
                {
                    _unreadFields.Remove(symbol);
                }

                if (write)
                {
                    bool _;
                    _unassignedFieldsMap.TryRemove(symbol, out _);
                }
            }
            else
            {
                // It's acceptable to run flow analysis again after the diagnostics have been computed - just
                // make sure that the nothing is different than the first time.

                Debug.Assert(
                     !(read && _unreadFields.Remove(symbol)),
                     "we are already reporting unused field warnings, there could be no more changes");

                Debug.Assert(
                    !(write && _unassignedFieldsMap.ContainsKey(symbol)),
                    "we are already reporting unused field warnings, there could be no more changes");
            }
        }

        internal void NoteSymbolDefinition(DeclaredSymbol symbol, bool isInternal, bool isUnread)
        {
            Debug.Assert(_unusedFieldWarnings.IsDefault, "We shouldn't have computed the diagnostics if we're still noting definitions.");

            _unassignedFieldsMap.TryAdd(symbol, isInternal);
            if (isUnread)
            {
                _unreadFields.Add(symbol);
            }
        }

        /// <summary>
        /// Get the warnings for unused symbols.  This should only be fetched when all method bodies have been compiled.
        /// </summary>
        internal ImmutableArray<Diagnostic> GetUnusedSymbolWarnings(CancellationToken cancellationToken)
        {
            if (_unusedFieldWarnings.IsDefault)
            {
                //Our maps of unread and unassigned fields won't be done until the assembly is complete.
                this.ForceComplete(completionPart: null, locationOpt: null, cancellationToken: cancellationToken);

                Debug.Assert(this.HasComplete(CompletionGraph.Module),
                    "Don't consume unused field information if there are still types to be processed.");

                // Build this up in a local before we assign it to this.unusedFieldWarnings (so other threads
                // can see that it's not done).
                DiagnosticBag diagnostics = DiagnosticBag.GetInstance();

                // NOTE: two threads can come in here at the same time.  If they do, then they will
                // share the diagnostic bag.  That's alright, as long as each one processes only
                // the fields that it successfully removes from the shared map/set.  Furthermore,
                // there should be no problem with re-calling this method on the same assembly,
                // since there will be nothing left in the map/set the second time.
                bool internalsAreVisible =
                    this.InternalsAreVisible ||
                    this.IsNetModule();

                HashSet<Symbol> handledUnreadSymbols = null;

                foreach (DeclaredSymbol symbol in _unassignedFieldsMap.Keys) // Not mutating, so no snapshot required.
                {
                    bool isInternalAccessibility;
                    bool success = _unassignedFieldsMap.TryGetValue(symbol, out isInternalAccessibility);
                    Debug.Assert(success, "Once CompletionGraph.Module is set, no-one should be modifying the map.");

                    if (isInternalAccessibility && internalsAreVisible)
                    {
                        continue;
                    }

                    if (!symbol.CanBeReferencedByName)
                    {
                        continue;
                    }

                    var containingType = symbol.ContainingType as SourceNamedTypeSymbol;
                    if ((object)containingType == null)
                    {
                        continue;
                    }

                    bool unread = _unreadFields.Contains(symbol);
                    if (unread)
                    {
                        if (handledUnreadSymbols == null)
                        {
                            handledUnreadSymbols = new HashSet<Symbol>();
                        }
                        handledUnreadSymbols.Add(symbol);
                    }
                }
                ImmutableInterlocked.InterlockedInitialize(ref _unusedFieldWarnings, diagnostics.ToReadOnlyAndFree());
            }

            Debug.Assert(!_unusedFieldWarnings.IsDefault);
            return _unusedFieldWarnings;
        }

        private static string DefaultValue(TypeSymbol type)
        {
            // TODO: localize these strings
            if (type.IsReferenceType) return "null";
            switch (type.SpecialType)
            {
                case SpecialType.System_Boolean:
                    return "false";
                case SpecialType.System_Byte:
                case SpecialType.System_Decimal:
                case SpecialType.System_Double:
                case SpecialType.System_Int16:
                case SpecialType.System_Int32:
                case SpecialType.System_Int64:
                case SpecialType.System_SByte:
                case SpecialType.System_Single:
                case SpecialType.System_UInt16:
                case SpecialType.System_UInt32:
                case SpecialType.System_UInt64:
                    return "0";
                default:
                    return "";
            }
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            int forcedArity = emittedName.ForcedArity;

            if (emittedName.UseCLSCompliantNameArityEncoding)
            {
                if (forcedArity == -1)
                {
                    forcedArity = emittedName.InferredArity;
                }
                else if (forcedArity != emittedName.InferredArity)
                {
                    return null;
                }

                Debug.Assert(forcedArity == emittedName.InferredArity);
            }

            if (_lazyForwardedTypesFromSource == null)
            {
                IDictionary<string, NamedTypeSymbol> forwardedTypesFromSource;
                // Get the TypeForwardedTo attributes with minimal binding to avoid cycle problems
                HashSet<NamedTypeSymbol> forwardedTypes = GetForwardedTypes();

                if (forwardedTypes != null)
                {
                    forwardedTypesFromSource = new Dictionary<string, NamedTypeSymbol>(StringOrdinalComparer.Instance);

                    foreach (NamedTypeSymbol forwardedType in forwardedTypes)
                    {
                        NamedTypeSymbol originalDefinition = forwardedType.OriginalDefinition;
                        Debug.Assert((object)originalDefinition.ContainingType == null, "How did a nested type get forwarded?");

                        string fullEmittedName = MetadataHelpers.BuildQualifiedName(originalDefinition.ContainingSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat),
                                                                                    originalDefinition.MetadataName);
                        // Since we need to allow multiple constructions of the same generic type at the source
                        // level, we need to de-dup the original definitions.
                        forwardedTypesFromSource[fullEmittedName] = originalDefinition;
                    }
                }
                else
                {
                    forwardedTypesFromSource = SpecializedCollections.EmptyDictionary<string, NamedTypeSymbol>();
                }

                _lazyForwardedTypesFromSource = forwardedTypesFromSource;
            }

            NamedTypeSymbol result;

            if (_lazyForwardedTypesFromSource.TryGetValue(emittedName.FullName, out result))
            {
                if ((forcedArity == -1 || result.Arity == forcedArity) &&
                    (!emittedName.UseCLSCompliantNameArityEncoding || result.Arity == 0 || result.MangleName))
                {
                    return result;
                }
            }
            else if (!_compilation.Options.OutputKind.IsNetModule())
            {
                // See if any of added modules forward the type.

                // Similar to attributes, type forwarders from the second added module should override type forwarders from the first added module, etc. 
                for (int i = _peModules.Length - 1; i > 0; i--)
                {
                    var cSharpModuleSymbol = (CSharpModuleSymbol)_peModules[i];

                    (AssemblySymbol firstSymbol, AssemblySymbol secondSymbol) = cSharpModuleSymbol.GetAssembliesForForwardedType(ref emittedName);

                    if ((object)firstSymbol != null)
                    {
                        if ((object)secondSymbol != null)
                        {
                            return CreateMultipleForwardingErrorTypeSymbol(ref emittedName, cSharpModuleSymbol, firstSymbol, secondSymbol);
                        }

                        // Don't bother to check the forwarded-to assembly if we've already seen it.
                        if (visitedAssemblies != null && visitedAssemblies.Contains(firstSymbol))
                        {
                            return CreateCycleInTypeForwarderErrorTypeSymbol(ref emittedName);
                        }
                        else
                        {
                            visitedAssemblies = new ConsList<AssemblySymbol>(this, visitedAssemblies ?? ConsList<AssemblySymbol>.Empty);
                            return firstSymbol.LookupTopLevelMetadataTypeWithCycleDetection(ref emittedName, visitedAssemblies, digThroughForwardedTypes: true);
                        }
                    }
                    // TODO:MetaDslx - non-CSharp modules
                }
            }

            return null;
        }

        public override AssemblyMetadata GetMetadata() => null;

        internal override bool IsNetModule()
        {
            return _compilation.Options.OutputKind.IsNetModule();
        }
    }
}
