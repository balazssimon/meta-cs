using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public class ModelGlobalNamespaceSymbol : ModelNamespaceSymbol
    {
        private ModelModuleSymbol _module;
        private ImmutableArray<string> _lazyTypeNames;
        private ImmutableArray<string> _lazyNamespaceNames;

        public ModelGlobalNamespaceSymbol(ModelModuleSymbol module)
            : base(module, null)
        {
            _module = module;
        }

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
                            if (symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(ms)) == DeclarationKind.Namespace)
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
                            if (symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(ms)) == DeclarationKind.Type)
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

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return Members;
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return GetMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return TypeMembers.OfType<NamedTypeSymbol>().ToImmutableArray();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.MakeGlobalSymbols(this, null, diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteSymbolProperty_Attributes(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        protected override ImmutableArray<DeclaredSymbol> CompleteSymbolProperty_Members(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return this.ChildSymbols.OfType<DeclaredSymbol>().ToImmutableArray();
        }

        protected override string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return string.Empty;
        }

        protected override ImmutableArray<TypeSymbol> CompleteSymbolProperty_TypeMembers(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return this.ChildSymbols.OfType<TypeSymbol>().ToImmutableArray();
        }
    }
}
