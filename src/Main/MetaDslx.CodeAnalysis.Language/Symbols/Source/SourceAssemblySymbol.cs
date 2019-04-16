// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Symbols.Metadata.PE;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using CommonAssemblyWellKnownAttributeData = Microsoft.CodeAnalysis.CommonAssemblyWellKnownAttributeData<Microsoft.CodeAnalysis.CSharp.Symbols.NamedTypeSymbol>;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents an assembly built by compiler.
    /// </summary>
    internal sealed partial class SourceAssemblySymbol : MetadataOrSourceAssemblySymbol, ISourceAssemblySymbolInternal, IAttributeTargetSymbol
    {
        /// <summary>
        /// A Compilation the assembly is created for.
        /// </summary>
        private readonly CSharpCompilation _compilation;

        private SymbolCompletionState _state;

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

        /// <summary>
        /// Bag of assembly's custom attributes and decoded well-known attribute data from source.
        /// </summary>
        private CustomAttributesBag<CSharpAttributeData> _lazySourceAttributesBag;

        /// <summary>
        /// Bag of assembly's custom attributes and decoded well-known attribute data from added netmodules.
        /// </summary>
        private CustomAttributesBag<CSharpAttributeData> _lazyNetModuleAttributesBag;

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
        private readonly ConcurrentDictionary<FieldSymbol, bool> _unassignedFieldsMap = new ConcurrentDictionary<FieldSymbol, bool>();

        /// <summary>
        /// private fields declared in this assembly but never read
        /// </summary>
        private readonly ConcurrentSet<FieldSymbol> _unreadFields = new ConcurrentSet<FieldSymbol>();

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

        internal SourceAssemblySymbol(
            CSharpCompilation compilation,
            string assemblySimpleName,
            string moduleName,
            ImmutableArray<PEModule> netModules)
        {
            Debug.Assert(compilation != null);
            Debug.Assert(assemblySimpleName != null);
            Debug.Assert(!String.IsNullOrWhiteSpace(moduleName));
            Debug.Assert(!netModules.IsDefault);

            _compilation = compilation;
            _assemblySimpleName = assemblySimpleName;

            ArrayBuilder<ModuleSymbol> moduleBuilder = new ArrayBuilder<ModuleSymbol>(1 + netModules.Length);

            moduleBuilder.Add(new SourceModuleSymbol(this, compilation.Declarations, moduleName));

            var importOptions = (compilation.Options.MetadataImportOptions == MetadataImportOptions.All) ?
                MetadataImportOptions.All : MetadataImportOptions.Internal;

            foreach (PEModule netModule in netModules)
            {
                moduleBuilder.Add(new PEModuleSymbol(this, netModule, importOptions, moduleBuilder.Count));
                // SetReferences will be called later by the ReferenceManager (in CreateSourceAssemblyFullBind for 
                // a fresh manager, in CreateSourceAssemblyReuseData for a reused one).
            }

            _modules = moduleBuilder.ToImmutableAndFree();

            if (!compilation.Options.CryptoPublicKey.IsEmpty)
            {
                // Private key is not necessary for assembly identity, only when emitting.  For this reason, the private key can remain null.
                _lazyStrongNameKeys = StrongNameKeys.Create(compilation.Options.CryptoPublicKey, privateKey: null, hasCounterSignature: false, MessageProvider.Instance);
            }
        }

        public override string Name
        {
            get
            {
                return _assemblySimpleName;
            }
        }

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        internal sealed override CSharpCompilation DeclaringCompilation
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
            for (int i = 1; i < _modules.Length; i++)
            {
                var peModuleSymbol = (Metadata.PE.PEModuleSymbol)_modules[i];
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

        internal override Symbol GetSpecialTypeMember(SpecialMember member)
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

        //TODO: cache
        public override ImmutableArray<Location> Locations
        {
            get
            {
                return this.Modules.SelectMany(m => m.Locations).AsImmutable();
            }
        }

        private void ValidateAttributeSemantics(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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
        private static void ReportDiagnosticsForSynthesizedAttributes(CSharpCompilation compilation, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void ValidateIVTPublicKeys(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        internal override bool RequiresCompletion
        {
            get { return true; }
        }

        internal override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                switch (incompletePart)
                {
                    case CompletionPart.Attributes:
                        EnsureAttributesAreBound();
                        break;
                    case CompletionPart.StartAttributeChecks:
                    case CompletionPart.FinishAttributeChecks:
                        if (_state.NotePartComplete(CompletionPart.StartAttributeChecks))
                        {
                            var diagnostics = DiagnosticBag.GetInstance();
                            ValidateAttributeSemantics(diagnostics);
                            AddDeclarationDiagnostics(diagnostics);
                            var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishAttributeChecks);
                            Debug.Assert(thisThreadCompleted);
                            diagnostics.Free();
                        }
                        break;
                    case CompletionPart.Module:
                        SourceModule.ForceComplete(locationOpt, cancellationToken);
                        if (SourceModule.HasComplete(CompletionPart.MembersCompleted))
                        {
                            _state.NotePartComplete(CompletionPart.Module);
                            break;
                        }
                        else
                        {
                            Debug.Assert(locationOpt != null, "If no location was specified, then the module members should be completed");
                            // this is the last completion part we can handle if there is a location.
                            return;
                        }

                    case CompletionPart.StartValidatingAddedModules:
                    case CompletionPart.FinishValidatingAddedModules:
                        if (_state.NotePartComplete(CompletionPart.StartValidatingAddedModules))
                        {
                            ReportDiagnosticsForAddedModules();
                            var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishValidatingAddedModules);
                            Debug.Assert(thisThreadCompleted);
                        }
                        break;

                    case CompletionPart.None:
                        return;

                    default:
                        // any other values are completion parts intended for other kinds of symbols
                        _state.NotePartComplete(CompletionPart.All & ~CompletionPart.AssemblySymbolAll);
                        break;
                }

                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }

        private void ReportDiagnosticsForAddedModules()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void ReportNameCollisionDiagnosticsForAddedModules(NamespaceSymbol ns, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        private bool IsKnownAssemblyAttribute(CSharpAttributeData attribute)
        {
            // TODO: This list used to include AssemblyOperatingSystemAttribute and AssemblyProcessorAttribute,
            //       but it doesn't look like they are defined, cannot find them on MSDN.
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
        private HashSet<CSharpAttributeData> GetUniqueSourceAssemblyAttributes()
        {
            ImmutableArray<CSharpAttributeData> appliedSourceAttributes = this.GetSourceAttributesBag().Attributes;

            HashSet<CSharpAttributeData> uniqueAttributes = null;

            for (int i = 0; i < appliedSourceAttributes.Length; i++)
            {
                CSharpAttributeData attribute = appliedSourceAttributes[i];
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

        private static bool AddUniqueAssemblyAttribute(CSharpAttributeData attribute, ref HashSet<CSharpAttributeData> uniqueAttributes)
        {
            Debug.Assert(!attribute.HasErrors);

            if (uniqueAttributes == null)
            {
                uniqueAttributes = new HashSet<CSharpAttributeData>(comparer: CommonAttributeDataComparer.Instance);
            }

            return uniqueAttributes.Add(attribute);
        }

        private bool ValidateAttributeUsageForNetModuleAttribute(CSharpAttributeData attribute, string netModuleName, DiagnosticBag diagnostics, ref HashSet<CSharpAttributeData> uniqueAttributes)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private ImmutableArray<CSharpAttributeData> GetNetModuleAttributes(out ImmutableArray<string> netModuleNames)
        {
            ArrayBuilder<CSharpAttributeData> moduleAssemblyAttributesBuilder = null;
            ArrayBuilder<string> netModuleNameBuilder = null;

            for (int i = 1; i < _modules.Length; i++)
            {
                var peModuleSymbol = (Metadata.PE.PEModuleSymbol)_modules[i];
                string netModuleName = peModuleSymbol.Name;
                foreach (var attributeData in peModuleSymbol.GetAssemblyAttributes())
                {
                    if (netModuleNameBuilder == null)
                    {
                        netModuleNameBuilder = ArrayBuilder<string>.GetInstance();
                        moduleAssemblyAttributesBuilder = ArrayBuilder<CSharpAttributeData>.GetInstance();
                    }

                    netModuleNameBuilder.Add(netModuleName);
                    moduleAssemblyAttributesBuilder.Add(attributeData);
                }
            }

            if (netModuleNameBuilder == null)
            {
                netModuleNames = ImmutableArray<string>.Empty;
                return ImmutableArray<CSharpAttributeData>.Empty;
            }

            netModuleNames = netModuleNameBuilder.ToImmutableAndFree();
            return moduleAssemblyAttributesBuilder.ToImmutableAndFree();
        }

        private WellKnownAttributeData ValidateAttributeUsageAndDecodeWellKnownAttributes(
            ImmutableArray<CSharpAttributeData> attributesFromNetModules,
            ImmutableArray<string> netModuleNames,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(attributesFromNetModules.Any());
            Debug.Assert(netModuleNames.Any());
            Debug.Assert(attributesFromNetModules.Length == netModuleNames.Length);

            int netModuleAttributesCount = attributesFromNetModules.Length;
            int sourceAttributesCount = this.GetSourceAttributesBag().Attributes.Length;

            // Get unique source assembly attributes.
            HashSet<CSharpAttributeData> uniqueAttributes = GetUniqueSourceAssemblyAttributes();

            var arguments = new DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation>();
            arguments.AttributesCount = netModuleAttributesCount;
            arguments.Diagnostics = diagnostics;
            arguments.SymbolPart = AttributeLocation.None;

            // Attributes from the second added module should override attributes from the first added module, etc. 
            // Attributes from source should override attributes from added modules.
            // That is why we are iterating attributes backwards.
            for (int i = netModuleAttributesCount - 1; i >= 0; i--)
            {
                var totalIndex = i + sourceAttributesCount;

                CSharpAttributeData attribute = attributesFromNetModules[i];
                if (!attribute.HasErrors && ValidateAttributeUsageForNetModuleAttribute(attribute, netModuleNames[i], diagnostics, ref uniqueAttributes))
                {
                    arguments.Attribute = attribute;
                    arguments.Index = i;

                    // CONSIDER: Provide usable AttributeSyntax node for diagnostics of malformed netmodule assembly attributes
                    arguments.AttributeSyntaxOpt = null;

                    this.DecodeWellKnownAttribute(ref arguments, totalIndex, isFromNetModule: true);
                }
                else
                {
                    AddOmittedAttributeIndex(totalIndex);
                }
            }

            return arguments.HasDecodedData ? arguments.DecodedData : null;
        }

        private void LoadAndValidateNetModuleAttributes(ref CustomAttributesBag<CSharpAttributeData> lazyNetModuleAttributesBag)
        {
            if (_compilation.Options.OutputKind.IsNetModule())
            {
                Interlocked.CompareExchange(ref lazyNetModuleAttributesBag, CustomAttributesBag<CSharpAttributeData>.Empty, null);
            }
            else
            {
                var diagnostics = DiagnosticBag.GetInstance();

                ImmutableArray<string> netModuleNames;
                ImmutableArray<CSharpAttributeData> attributesFromNetModules = GetNetModuleAttributes(out netModuleNames);

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
                for (int i = _modules.Length - 1; i > 0; i--)
                {
                    var peModuleSymbol = (Metadata.PE.PEModuleSymbol)_modules[i];

                    foreach (NamedTypeSymbol forwarded in peModuleSymbol.GetForwardedTypes())
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

                CustomAttributesBag<CSharpAttributeData> netModuleAttributesBag;

                if (wellKnownData != null || attributesFromNetModules.Any())
                {
                    netModuleAttributesBag = new CustomAttributesBag<CSharpAttributeData>();

                    netModuleAttributesBag.SetEarlyDecodedWellKnownAttributeData(null);
                    netModuleAttributesBag.SetDecodedWellKnownAttributeData(wellKnownData);
                    netModuleAttributesBag.SetAttributes(attributesFromNetModules);
                    if (netModuleAttributesBag.IsEmpty) netModuleAttributesBag = CustomAttributesBag<CSharpAttributeData>.Empty;
                }
                else
                {
                    netModuleAttributesBag = CustomAttributesBag<CSharpAttributeData>.Empty;
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

        private CustomAttributesBag<CSharpAttributeData> GetNetModuleAttributesBag()
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

        internal ImmutableArray<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void EnsureAttributesAreBound()
        {
            if ((_lazySourceAttributesBag == null || !_lazySourceAttributesBag.IsSealed) &&
                LoadAndValidateAttributes(OneOrMany.Create(GetAttributeDeclarations()), ref _lazySourceAttributesBag))
            {
                _state.NotePartComplete(CompletionPart.Attributes);
            }
        }

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes. Returns null if there are no attributes applied on the symbol.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CustomAttributesBag<CSharpAttributeData> GetSourceAttributesBag()
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
        public sealed override ImmutableArray<CSharpAttributeData> GetAttributes()
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
        /// Returns true if the assembly attribute at the given index is a duplicate assembly attribute that must not be emitted.
        /// Duplicate assembly attributes are attributes that bind to the same constructor and have identical arguments.
        /// </summary>
        /// <remarks>
        /// This method must be invoked only after all the assembly attributes have been bound.
        /// </remarks>
        internal bool IsIndexOfOmittedAssemblyAttribute(int index)
        {
            Debug.Assert(_lazyOmittedAttributeIndices == null || !_lazyOmittedAttributeIndices.Any(i => i < 0 || i >= this.GetAttributes().Length));
            Debug.Assert(_lazySourceAttributesBag.IsSealed);
            Debug.Assert(_lazyNetModuleAttributesBag.IsSealed);
            Debug.Assert(index >= 0);
            Debug.Assert(index < this.GetAttributes().Length);

            return _lazyOmittedAttributeIndices != null && _lazyOmittedAttributeIndices.Contains(index);
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
            CustomAttributesBag<CSharpAttributeData> attributesBag = _lazySourceAttributesBag;
            if (attributesBag?.IsDecodedWellKnownAttributeDataComputed == true)
            {
                // Use already decoded attributes
                return ((CommonAssemblyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData)?.ForwardedTypes;
            }

            attributesBag = null;
            LoadAndValidateAttributes(OneOrMany.Create(GetAttributeDeclarations()), ref attributesBag, attributeMatchesOpt: this.IsPossibleForwardedTypesAttribute);

            var wellKnownAttributeData = (CommonAssemblyWellKnownAttributeData)attributesBag?.DecodedWellKnownAttributeData;
            return wellKnownAttributeData?.ForwardedTypes;
        }

        private bool IsPossibleForwardedTypesAttribute(CSharpSyntaxNode node)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static IEnumerable<Cci.SecurityAttribute> GetSecurityAttributes(CustomAttributesBag<CSharpAttributeData> attributesBag)
        {
            Debug.Assert(attributesBag.IsSealed);

            var wellKnownAttributeData = (CommonAssemblyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
            if (wellKnownAttributeData != null)
            {
                SecurityWellKnownAttributeData securityData = wellKnownAttributeData.SecurityInformation;
                if (securityData != null)
                {
                    foreach (var securityAttribute in securityData.GetSecurityAttributes<CSharpAttributeData>(attributesBag.Attributes))
                    {
                        yield return securityAttribute;
                    }
                }
            }
        }

        internal IEnumerable<Cci.SecurityAttribute> GetSecurityAttributes()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            return _modules[0].GetReferencedAssemblySymbols();
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

        internal override bool IsLinked
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

                var obj = GetSpecialType(SpecialType.System_Object);

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

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        private static Location GetAssemblyAttributeLocationForDiagnostic(CSharpSyntaxNode attributeSyntaxOpt)
        {
            return (object)attributeSyntaxOpt != null ? attributeSyntaxOpt.Location : NoLocation.Singleton;
        }

        private void DecodeTypeForwardedToAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void DecodeOneInternalsVisibleToAttribute(
            CSharpSyntaxNode nodeOpt,
            CSharpAttributeData attrData,
            DiagnosticBag diagnostics,
            int index,
            ref ConcurrentDictionary<string, ConcurrentDictionary<ImmutableArray<byte>, Tuple<Location, string>>> lazyInternalsVisibleToMap)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        IAttributeTargetSymbol IAttributeTargetSymbol.AttributesOwner
        {
            get { return this; }
        }

        AttributeLocation IAttributeTargetSymbol.DefaultAttributeLocation
        {
            get { return AttributeLocation.Assembly; }
        }

        AttributeLocation IAttributeTargetSymbol.AllowedAttributeLocations
        {
            get
            {
                return IsInteractive ? AttributeLocation.None : AttributeLocation.Assembly | AttributeLocation.Module;
            }
        }

        internal override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            DecodeWellKnownAttribute(ref arguments, arguments.Index, isFromNetModule: false);
        }

        private void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments, int index, bool isFromNetModule)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal void NoteFieldDefinition(FieldSymbol field, bool isInternal, bool isUnread)
        {
            Debug.Assert(_unusedFieldWarnings.IsDefault, "We shouldn't have computed the diagnostics if we're still noting definitions.");

            _unassignedFieldsMap.TryAdd(field, isInternal);
            if (isUnread)
            {
                _unreadFields.Add(field);
            }
        }

        /// <summary>
        /// Get the warnings for unused fields.  This should only be fetched when all method bodies have been compiled.
        /// </summary>
        internal ImmutableArray<Diagnostic> GetUnusedFieldWarnings(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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
                for (int i = _modules.Length - 1; i > 0; i--)
                {
                    var peModuleSymbol = (Metadata.PE.PEModuleSymbol)_modules[i];

                    (AssemblySymbol firstSymbol, AssemblySymbol secondSymbol) = peModuleSymbol.GetAssembliesForForwardedType(ref emittedName);

                    if ((object)firstSymbol != null)
                    {
                        if ((object)secondSymbol != null)
                        {
                            return CreateMultipleForwardingErrorTypeSymbol(ref emittedName, peModuleSymbol, firstSymbol, secondSymbol);
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
                }
            }

            return null;
        }

        public override AssemblyMetadata GetMetadata() => null;

        Compilation ISourceAssemblySymbol.Compilation => _compilation;
    }
}
