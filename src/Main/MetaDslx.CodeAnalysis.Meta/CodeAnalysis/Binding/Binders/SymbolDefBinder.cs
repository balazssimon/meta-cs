using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : ValueBinder, ISymbolBoundary

    {
        private readonly Type _type;
        private Imports _lazyImports;
        private ImportChain _lazyImportChain;

        public SymbolDefBinder(Binder next, SyntaxNodeOrToken syntax, Type type) 
            : base(next, syntax)
        {
            _type = type;
        }

        public Type ModelObjectType => _type;

        protected override BoundNode CreateBoundNode()
        {
            var symbols = SourceSymbol.GetInnermostNestedDeclaredSymbols(this.Syntax.GetReference(), this.ContainingDeclaration).Cast<DeclaredSymbol, Symbol>();
            return new BoundSymbols(this.ParentBoundNode, this.Syntax, symbols);
        }

        public ImmutableArray<Symbol> DefinedSymbols => ((BoundSymbol)this.BoundNode).Symbols;

        public Symbol DefinedSymbol => DefinedSymbols.FirstOrDefault();

        public override ImmutableArray<object> Values => DefinedSymbols.Cast<Symbol, object>();

        public override Symbol GetDefinedSymbol()
        {
            return this.DefinedSymbol;
        }

        public override Imports GetImports(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyImports == null)
            {
                var imports = Imports.FromSyntax(this.Syntax, this.DefinedSymbol as DeclaredSymbol, this, basesBeingResolved, false);
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
                        importChain = new ImportChain(GetImports(basesBeingResolved: null), importChain);
                    }

                    Interlocked.CompareExchange(ref _lazyImportChain, importChain, null);
                }

                Debug.Assert(_lazyImportChain != null);

                return _lazyImportChain;
            }
        }


        public override string ToString()
        {
            return $"SymbolDefBinder: {_type.Name}";
        }

    }
}
