using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Completion;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class GlobalNamespaceSymbol : CompletionNamespaceSymbol
    {
        private CompletionModuleSymbol _module;
        private ImmutableArray<string> _lazyTypeNames;
        private ImmutableArray<string> _lazyNamespaceNames;

        public GlobalNamespaceSymbol(CompletionModuleSymbol module)
            : base(module)
        {
            _module = module;
        }

        protected override ISymbolImplementation SymbolImplementation => MetadataSymbolImplementation.Instance;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override ImmutableArray<Location> Locations => _module.Locations;

        public ImmutableArray<string> NamespaceNames
        {
            get
            {
                if (_lazyNamespaceNames.IsDefault)
                {
                    HashSet<string> names = new HashSet<string>();
                    try
                    {
                        var symbolFacts = Language.SymbolFacts;
                        foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                        {
                            if (typeof(NamespaceSymbol).IsAssignableFrom(symbolFacts.GetSymbolType(ms)))
                            {
                                names.Add(symbolFacts.GetName(ms));
                            }
                        }
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedInitialize(ref _lazyNamespaceNames, names.ToImmutableArray());
                    }
                }
                return _lazyNamespaceNames;
            }
        }

        public ImmutableArray<string> TypeNames
        {
            get
            {
                if (_lazyTypeNames.IsDefault)
                {
                    HashSet<string> names = new HashSet<string>();
                    try
                    {
                        var symbolFacts = Language.SymbolFacts;
                        foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                        {
                            if (typeof(NamedTypeSymbol).IsAssignableFrom(symbolFacts.GetSymbolType(ms)))
                            {
                                var name = symbolFacts.GetName(ms);
                                if (!string.IsNullOrEmpty(name)) names.Add(symbolFacts.GetName(ms));
                            }
                        }
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeNames, names.ToImmutableArray());
                    }
                }
                return _lazyTypeNames;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SymbolImplementation.MakeGlobalSymbols(this, null, diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<AttributeSymbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<AttributeSymbol>.Empty;
        }

        protected override ImmutableArray<DeclaredSymbol> CompleteSymbolProperty_Members(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return this.ChildSymbols.OfType<DeclaredSymbol>().ToImmutableArray();
        }

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return string.Empty;
        }

        protected override string CompleteSymbolProperty_MetadataName(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return string.Empty;
        }

        protected override bool CompleteSymbolProperty_IsExtern(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return false;
        }

        protected override Accessibility CompleteSymbolProperty_DeclaredAccessibility(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return Accessibility.NotApplicable;
        }

        protected override ImmutableArray<TypeParameterSymbol> CompleteSymbolProperty_TypeParameters(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<TypeParameterSymbol>.Empty;
        }
    }
}
