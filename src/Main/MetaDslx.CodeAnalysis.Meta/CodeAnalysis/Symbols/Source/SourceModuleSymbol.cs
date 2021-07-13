using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public partial class SourceModuleSymbol 
    {
        /// <summary>
        /// Owning assembly.
        /// </summary>
        private readonly SourceAssemblySymbol _assemblySymbol;

        private ImmutableArray<AssemblySymbol> _lazyAssembliesToEmbedTypesFrom;

        private ThreeState _lazyContainsExplicitDefinitionOfNoPiaLocalTypes = ThreeState.Unknown;

        /// <summary>
        /// The declarations corresponding to the source files of this module.
        /// </summary>
        private readonly DeclarationTable _sources;

        private CustomAttributesBag<AttributeData> _lazyCustomAttributesBag;
        private ImmutableArray<Location> _locations;
        private NamespaceSymbol _globalNamespace;

        private bool _hasBadAttributes;
        private object _model;

        internal SourceModuleSymbol(
            SourceAssemblySymbol assemblySymbol,
            DeclarationTable declarations,
            string moduleName)
            : base(assemblySymbol, null, 0)
        {
            Debug.Assert((object)assemblySymbol != null);

            _assemblySymbol = assemblySymbol;
            _sources = declarations;
            _name = moduleName;
        }

        public override object Model
        {
            get
            {
                if (_model == null)
                {
                    Interlocked.CompareExchange(ref _model, DeclaringCompilation.ObjectFactory.Model, null);
                }
                return _model;
            }
        }

        public override Language Language => _assemblySymbol.Language;

        internal void RecordPresenceOfBadAttributes()
        {
            _hasBadAttributes = true;
        }

        internal bool HasBadAttributes
        {
            get
            {
                return _hasBadAttributes;
            }
        }

        public override int Ordinal
        {
            get
            {
                return 0;
            }
        }

        public override Machine Machine
        {
            get
            {
                switch (DeclaringCompilation.Options.Platform)
                {
                    case Platform.Arm:
                        return Machine.ArmThumb2;
                    case Platform.X64:
                        return Machine.Amd64;
                    case Platform.Arm64:
                        return (Machine)0xAA64;//Machine.Arm64; https://github.com/dotnet/roslyn/issues/25185
                    case Platform.Itanium:
                        return Machine.IA64;
                    default:
                        return Machine.I386;
                }
            }
        }

        public override bool Bit32Required
        {
            get
            {
                return DeclaringCompilation.Options.Platform == Platform.X86;
            }
        }

        internal bool AnyReferencedAssembliesAreLinked
        {
            get
            {
                return GetAssembliesToEmbedTypesFrom().Length > 0;
            }
        }

        internal ImmutableArray<AssemblySymbol> GetAssembliesToEmbedTypesFrom()
        {
            if (_lazyAssembliesToEmbedTypesFrom.IsDefault)
            {
                AssertReferencesInitialized();
                var buffer = ArrayBuilder<AssemblySymbol>.GetInstance();

                foreach (AssemblySymbol asm in this.ReferencedAssemblySymbols)
                {
                    if (asm.IsLinked)
                    {
                        buffer.Add(asm);
                    }
                }

                ImmutableInterlocked.InterlockedCompareExchange(ref _lazyAssembliesToEmbedTypesFrom,
                                                    buffer.ToImmutableAndFree(),
                                                    default(ImmutableArray<AssemblySymbol>));
            }

            Debug.Assert(!_lazyAssembliesToEmbedTypesFrom.IsDefault);
            return _lazyAssembliesToEmbedTypesFrom;
        }

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if ((object)_globalNamespace == null)
                {
                    Debug.Assert(!DeclaringCompilation.MergedRootDeclaration.HasDiagnostics);
                    var globalNS = new SourceNamespaceSymbol(this, this, null, DeclaringCompilation.MergedRootDeclaration);
                    Interlocked.CompareExchange(ref _globalNamespace, globalNS, null);
                }

                return _globalNamespace;
            }
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
                    GetAttributes();
                }
                else if (incompletePart == CompletionGraph.StartValidatingReferencedAssemblies)
                {
                    DiagnosticBag diagnostics = null;

                    if (AnyReferencedAssembliesAreLinked)
                    {
                        diagnostics = DiagnosticBag.GetInstance();
                        ValidateLinkedAssemblies(diagnostics, cancellationToken);
                    }

                    if (_state.NotePartComplete(CompletionGraph.StartValidatingReferencedAssemblies))
                    {
                        if (diagnostics != null)
                        {
                            _assemblySymbol.DeclaringCompilation.DeclarationDiagnostics.AddRange(diagnostics);
                        }

                        _state.NotePartComplete(CompletionGraph.FinishValidatingReferencedAssemblies);
                    }

                    if (diagnostics != null)
                    {
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionGraph.FinishValidatingReferencedAssemblies)
                {
                    // some other thread has started validating references (otherwise we would be in the case above) so
                    // we just wait for it to both finish and report the diagnostics.
                    Debug.Assert(_state.HasComplete(CompletionGraph.StartValidatingReferencedAssemblies));
                    _state.SpinWaitComplete(CompletionGraph.FinishValidatingReferencedAssemblies, cancellationToken);
                }
                else if (incompletePart == CompletionGraph.ChildrenCompleted)
                {
                    this.GlobalNamespace.ForceComplete(null, locationOpt, cancellationToken);

                    if (this.GlobalNamespace.HasComplete(CompletionGraph.ChildrenCompleted))
                    {
                        _state.NotePartComplete(CompletionGraph.ChildrenCompleted);
                    }
                    else
                    {
                        Debug.Assert(locationOpt != null, "If no location was specified, then the namespace members should be completed");
                        return;
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
        }*/

        private void ValidateLinkedAssemblies(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            // TODO:MetaDslx
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                if (_locations.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(
                        ref _locations,
                        DeclaringCompilation.MergedRootDeclaration.Declarations.SelectAsArray(d => (Location)d.Location));
                }

                return _locations;
            }
        }

        /// <summary>
        /// The name (contains extension)
        /// </summary>
        private readonly string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return _assemblySymbol;
            }
        }

        internal SourceAssemblySymbol ContainingSourceAssembly
        {
            get
            {
                return _assemblySymbol;
            }
        }

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        public override LanguageCompilation DeclaringCompilation
        {
            get
            {
                return _assemblySymbol.DeclaringCompilation;
            }
        }

        public override ICollection<string> TypeNames
        {
            get
            {
                return _sources.TypeNames;
            }
        }

        public override ICollection<string> NamespaceNames
        {
            get
            {
                return _sources.NamespaceNames;
            }
        }

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes. Returns null if there are no attributes applied on the symbol.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CustomAttributesBag<AttributeData> GetAttributesBag()
        {
            /* TODO:MetaDslx
            if (_lazyCustomAttributesBag == null || !_lazyCustomAttributesBag.IsSealed)
            {
                var mergedAttributes = ((SourceAssemblySymbol)this.ContainingAssembly).GetAttributeDeclarations();
                if (LoadAndValidateAttributes(OneOrMany.Create(mergedAttributes), ref _lazyCustomAttributesBag))
                {
                    var completed = _state.NotePartComplete(CompletionGraph.Attributes);
                    Debug.Assert(completed);
                }
            }*/
            if (_lazyCustomAttributesBag == null)
            {
                Interlocked.CompareExchange(ref _lazyCustomAttributesBag, CustomAttributesBag<AttributeData>.Empty, null);
                /*var completed = _state.NotePartComplete(CompletionParts.FinishComputingProperty_Attributes);
                Debug.Assert(completed);*/
            }
            return _lazyCustomAttributesBag;
        }

        /// <summary>
        /// Gets the attributes applied on this symbol.
        /// Returns an empty array if there are no attributes.
        /// </summary>
        /// <remarks>
        /// NOTE: This method should always be kept as a sealed override.
        /// If you want to override attribute binding logic for a sub-class, then override <see cref="GetAttributesBag"/> method.
        /// </remarks>
        public sealed override ImmutableArray<AttributeData> GetAttributes()
        {
            return this.GetAttributesBag().Attributes;
        }

        /// <summary>
        /// Returns data decoded from well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CommonModuleWellKnownAttributeData GetDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (CommonModuleWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        internal override bool HasAssemblyCompilationRelaxationsAttribute
        {
            get
            {
                return false;
            }
        }

        internal override bool HasAssemblyRuntimeCompatibilityAttribute
        {
            get
            {
                return false;
            }
        }

        internal override CharSet? DefaultMarshallingCharSet
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasDefaultCharSetAttribute ? data.DefaultCharacterSet : (CharSet?)null;
            }
        }

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

    }
}
