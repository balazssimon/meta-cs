using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceModuleSymbol : NonMissingModuleSymbol
    {
        /// <summary>
        /// Owning assembly.
        /// </summary>
        private readonly SourceAssemblySymbol _assemblySymbol;
        
        /// <summary>
        /// An array of <see cref="AssemblySymbol"/> objects corresponding to assemblies directly referenced by this module.
        /// </summary>
        /// <remarks>
        /// The contents are provided by ReferenceManager and may not be modified.
        /// </remarks>
        private ModuleReferences<AssemblySymbol> _moduleReferences;

        /// <summary>
        /// The name of the module (contains extension)
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// The declarations corresponding to the source files of this module.
        /// </summary>
        private readonly DeclarationTable _sources;

        private ImmutableArray<Location> _locations;
        private NamespaceSymbol _globalNamespace;
        private ImmutableArray<string> _lazyTypeNames;
        private ImmutableArray<string> _lazyNamespaceNames;

        private MutableModel _model;

        private SymbolCompletionState _state;

        internal SourceModuleSymbol(
            SourceAssemblySymbol assemblySymbol,
            DeclarationTable declarations,
            string moduleName)
        {
            Debug.Assert((object)assemblySymbol != null);

            _assemblySymbol = assemblySymbol;
            _sources = declarations;
            _name = moduleName;
            _model = new MutableModel(moduleName);

            _state = assemblySymbol.Language.CompilationFactory.CreateSymbolCompletionState();
        }

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if ((object)_globalNamespace == null)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    var globalNS = new SourceNamespaceSymbol(this, this, DeclaringCompilation.MergedRootDeclaration, diagnostics);
                    Debug.Assert(diagnostics.IsEmptyWithoutResolution);
                    diagnostics.Free();
                    Interlocked.CompareExchange(ref _globalNamespace, globalNS, null);
                }
                return _globalNamespace;
            }
        }

        public override int Ordinal => 0;

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

        public override string Name => _name;

        internal MutableModel Model => _model;

        public override Symbol ContainingSymbol => _assemblySymbol;

        public override AssemblySymbol ContainingAssembly => _assemblySymbol;

        internal SourceAssemblySymbol ContainingSourceAssembly => _assemblySymbol;

        /// <remarks>
        /// This override is essential - it's a base case of the recursive definition.
        /// </remarks>
        internal override LanguageCompilation DeclaringCompilation => _assemblySymbol.DeclaringCompilation;

        public override ImmutableArray<string> TypeNames
        {
            get
            {
                if (_lazyTypeNames.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeNames, _sources.TypeNames.ToImmutableArray());
                }
                return _lazyTypeNames;
            }
        }

        public override ImmutableArray<string> NamespaceNames
        {
            get
            {
                if (_lazyNamespaceNames.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyNamespaceNames, _sources.NamespaceNames.ToImmutableArray());
                }
                return _lazyNamespaceNames;
            }
        }
        
        public override bool HasUnifiedReferences
        {
            get { return GetUnifiedAssemblies().Length > 0; }
        }

        public override bool GetUnificationUseSiteDiagnostic(ref DiagnosticInfo result, Symbol dependentType)
        {
            AssertReferencesInitialized();

            var ownerModule = this;
            var ownerAssembly = ownerModule.ContainingAssembly;
            var dependentAssembly = dependentType.ContainingAssembly;
            if (ownerAssembly == dependentAssembly)
            {
                return false;
            }

            // TODO (tomat): we should report an error/warning for all unified references, not just the first one.

            foreach (var unifiedAssembly in GetUnifiedAssemblies())
            {
                if (!ReferenceEquals(unifiedAssembly.TargetAssembly, dependentAssembly))
                {
                    continue;
                }

                var referenceId = unifiedAssembly.OriginalReference;
                var definitionId = dependentAssembly.Identity;
                var involvedAssemblies = ImmutableArray.Create<Symbol>(ownerAssembly, dependentAssembly);

                DiagnosticInfo info;
                if (definitionId.Version > referenceId.Version)
                {
                    // unified with a definition whose version is higher than the reference                    
                    ErrorCode warning = (definitionId.Version.Major == referenceId.Version.Major && definitionId.Version.Minor == referenceId.Version.Minor) ?
                                        InternalErrorCode.WRN_UnifyReferenceBldRev : InternalErrorCode.WRN_UnifyReferenceMajMin;

                    // warning: Assuming assembly reference '{0}' used by '{1}' matches identity '{2}' of '{3}', you may need to supply runtime policy.
                    info = new LanguageDiagnosticInfo(
                        warning,
                        new object[]
                        {
                            referenceId.GetDisplayName(),
                            ownerAssembly.Name, // TODO (tomat): should rather be MetadataReference.Display for the corresponding reference
                            definitionId.GetDisplayName(),
                            dependentAssembly.Name
                        },
                        involvedAssemblies,
                        ImmutableArray<Location>.Empty);
                }
                else
                {
                    // unified with a definition whose version is lower than the reference

                    // error: Assembly '{0}' with identity '{1}' uses '{2}' which has a higher version than referenced assembly '{3}' with identity '{4}'
                    info = new LanguageDiagnosticInfo(
                        InternalErrorCode.ERR_AssemblyMatchBadVersion,
                        new object[]
                        {
                            ownerAssembly.Name, // TODO (tomat): should rather be MetadataReference.Display for the corresponding reference
                            ownerAssembly.Identity.GetDisplayName(),
                            referenceId.GetDisplayName(),
                            dependentAssembly.Name, // TODO (tomat): should rather be MetadataReference.Display for the corresponding reference
                            definitionId.GetDisplayName()
                        },
                        involvedAssemblies,
                        ImmutableArray<Location>.Empty);
                }

                if (MergeUseSiteDiagnostics(ref result, info))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A helper method for ReferenceManager to set assembly identities for assemblies 
        /// referenced by this module and corresponding AssemblySymbols.
        /// </summary>
        internal override void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly = null)
        {
            Debug.Assert(moduleReferences != null);

            AssertReferencesUninitialized();

            _moduleReferences = moduleReferences;
        }

        public override ModuleMetadata GetMetadata() => null;

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.StartValidatingReferencedAssemblies)
                {
                    DiagnosticBag diagnostics = null;
                    if (_state.NotePartComplete(CompletionPart.StartValidatingReferencedAssemblies))
                    {
                        if (diagnostics != null)
                        {
                            _assemblySymbol.DeclaringCompilation.DeclarationDiagnostics.AddRange(diagnostics);
                        }

                        _state.NotePartComplete(CompletionPart.FinishValidatingReferencedAssemblies);
                    }

                    if (diagnostics != null)
                    {
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.FinishValidatingReferencedAssemblies)
                {
                    // some other thread has started validating references (otherwise we would be in the case above) so
                    // we just wait for it to both finish and report the diagnostics.
                    Debug.Assert(_state.HasComplete(CompletionPart.StartValidatingReferencedAssemblies));
                    _state.SpinWaitComplete(CompletionPart.FinishValidatingReferencedAssemblies, cancellationToken);
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    this.GlobalNamespace.ForceComplete(locationOpt, cancellationToken);

                    if (this.GlobalNamespace.HasComplete(CompletionPart.MembersCompleted))
                    {
                        _state.NotePartComplete(CompletionPart.MembersCompleted);
                    }
                    else
                    {
                        Debug.Assert(locationOpt != null, "If no location was specified, then the namespace members should be completed");
                        return;
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    _state.NotePartComplete(incompletePart);
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }
        }


    }
}
