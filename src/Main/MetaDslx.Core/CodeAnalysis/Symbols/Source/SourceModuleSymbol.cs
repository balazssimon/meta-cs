using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SourceModuleSymbol : ModuleSymbol
    {
        /// <summary>
        /// Owning assembly.
        /// </summary>
        private readonly SourceAssemblySymbol _assemblySymbol;

        /// <summary>
        /// The underlying C# module
        /// </summary>
        private readonly Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol _csharpModuleSymbol;

        /// <summary>
        /// The declarations corresponding to the source files of this module.
        /// </summary>
        private readonly DeclarationTable _sources;

        private SymbolCompletionState _state;
        private ImmutableArray<Location> _locations;
        private NamespaceSymbol _globalNamespace;
        private int _ordinal;

        internal SourceModuleSymbol(
            SourceAssemblySymbol assemblySymbol,
            DeclarationTable declarations,
            Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol csharpModuleSymbol,
            int ordinal)
        {
            Debug.Assert((object)assemblySymbol != null);

            _assemblySymbol = assemblySymbol;
            _sources = declarations;
            _csharpModuleSymbol = csharpModuleSymbol;
            _ordinal = ordinal;
        }

        public override int Ordinal => _ordinal;

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => _csharpModuleSymbol.ReferencedAssemblies;

        public override ImmutableArray<IAssemblySymbol> ReferencedAssemblySymbols => StaticCast<IAssemblySymbol>.From(_csharpModuleSymbol.ReferencedAssemblySymbols);

        public override INamespaceSymbol GlobalNamespace
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
            /* TODO:MetaDslx
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                switch (incompletePart)
                {
                    case CompletionPart.Attributes:
                        GetAttributes();
                        break;

                    case CompletionPart.StartValidatingReferencedAssemblies:
                        {
                            DiagnosticBag diagnostics = null;

                            if (AnyReferencedAssembliesAreLinked)
                            {
                                diagnostics = DiagnosticBag.GetInstance();
                                ValidateLinkedAssemblies(diagnostics, cancellationToken);
                            }

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
                        break;

                    case CompletionPart.FinishValidatingReferencedAssemblies:
                        // some other thread has started validating references (otherwise we would be in the case above) so
                        // we just wait for it to both finish and report the diagnostics.
                        Debug.Assert(_state.HasComplete(CompletionPart.StartValidatingReferencedAssemblies));
                        _state.SpinWaitComplete(CompletionPart.FinishValidatingReferencedAssemblies, cancellationToken);
                        break;

                    case CompletionPart.MembersCompleted:
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

                        break;

                    case CompletionPart.None:
                        return;

                    default:
                        // any other values are completion parts intended for other kinds of symbols
                        _state.NotePartComplete(incompletePart);
                        break;
                }

                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }*/
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

        public override string Name
        {
            get
            {
                return _csharpModuleSymbol.Name;
            }
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return _assemblySymbol;
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

        public ICollection<string> TypeNames
        {
            get
            {
                return _sources.TypeNames;
            }
        }

        public ICollection<string> NamespaceNames
        {
            get
            {
                return _sources.NamespaceNames;
            }
        }

        public override ModuleMetadata GetMetadata() => null;

    }
}
