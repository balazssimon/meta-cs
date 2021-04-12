using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolBinder : ValueBinder, ISymbolBoundary
    {
        private readonly Type _symbolType;
        private readonly Type _modelObjectType;
        private Imports _lazyImports;
        private ImportChain _lazyImportChain;

        public SymbolBinder(Binder next, SyntaxNodeOrToken syntax, Type symbolType, Type modelObjectType)
            : base(next, syntax)
        {
            _symbolType = symbolType;
            _modelObjectType = modelObjectType;
        }

        public Type SymbolType => _symbolType;
        public Type ModelObjectType => _modelObjectType;

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var symbols = SourceSymbol.GetInnermostNestedDeclaredSymbols(this.Syntax.GetReference(), this.ContainingDeclaration).Cast<DeclaredSymbol, Symbol>();
            Debug.Assert(symbols.Length == 1 && symbols[0] != null);
            return new BoundSymbols(symbols);
        }

        public ImmutableArray<Symbol> DefinedSymbols => ((BoundSymbol)this.Bind()).Symbols;

        public Symbol DefinedSymbol => DefinedSymbols.FirstOrDefault();

        public override ImmutableArray<object> Values => DefinedSymbols.Cast<Symbol, object>();

        public override Symbol GetDefinedSymbol()
        {
            return this.DefinedSymbol;
        }

        public override Imports GetImports(LookupConstraints recursionConstraints = null)
        {
            if (_lazyImports == null && (recursionConstraints == null || !recursionConstraints.InUsing))
            {
                if (recursionConstraints == null) recursionConstraints = new LookupConstraints(this);
                var imports = Imports.FromSyntax(this.Syntax, this.DefinedSymbol as DeclaredSymbol, this, recursionConstraints);
                Interlocked.CompareExchange(ref _lazyImports, imports, null);
            }

            return _lazyImports;
        }

        public override ImportChain ImportChain
        {
            get
            {
                if (_lazyImportChain == null)
                {
                    ImportChain importChain = this.Next.ImportChain;
                    if ((object)DefinedSymbol == null || DefinedSymbol.Kind == LanguageSymbolKind.Namespace)
                    {
                        importChain = new ImportChain(GetImports(), importChain);
                    }

                    Interlocked.CompareExchange(ref _lazyImportChain, importChain, null);
                }

                Debug.Assert(_lazyImportChain != null);

                return _lazyImportChain;
            }
        }


        public override string ToString()
        {
            return $"SymbolBinder: {_symbolType.Name}";
        }
    }
}
