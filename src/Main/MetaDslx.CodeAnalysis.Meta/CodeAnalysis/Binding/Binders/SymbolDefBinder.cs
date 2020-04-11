using MetaDslx.CodeAnalysis.Binding.BoundNodes;
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

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _type;
        private readonly Type _nestingType;
        private ImmutableArray<DeclaredSymbol> _declaredSymbols;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolDefBinder(Binder next, LanguageSyntaxNode syntax, Type type, Type nestingType) 
            : base(next)
        {
            _type = type;
            _nestingType = nestingType;
            _syntax = syntax;
            _declaredSymbols = default;
        }

        public ImmutableArray<DeclaredSymbol> DeclaredSymbols
        {
            get
            {
                if (_declaredSymbols.IsDefault)
                {
                    var boundNode = this.Compilation.GetBoundNode<BoundSymbolDef>(_syntax);
                    ImmutableInterlocked.InterlockedInitialize(ref _declaredSymbols, boundNode.Symbols.Cast<DeclaredSymbol>().ToImmutableArray());
                }
                return _declaredSymbols;
            }
        }

        public DeclaredSymbol LastDeclaredSymbol
        {
            get
            {
                var symbols = this.DeclaredSymbols;
                if (symbols.Length == 0) return null;
                else return symbols[symbols.Length - 1];
            }
        }

        public override DeclaredSymbol GetDeclarationSymbol()
        {
            return this.LastDeclaredSymbol;
        }

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var boundNode = this.Compilation.GetBoundNode<BoundSymbolDef>(qualifier.Syntax);
            var boundNames = boundNode.GetChildNames();
            foreach (var boundName in boundNames)
            {
                foreach (var child in boundName.GetChildQualifiers())
                {
                    if (child.Syntax.Span.Contains(qualifier.Syntax.Span))
                    {
                        this.InitializeFullQualifierSymbol(child);
                    }
                }
            }
        }

        private void InitializeFullQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var containerSymbol = this.GetParentDeclarationSymbol();
            var result = ArrayBuilder<object>.GetInstance();
            var identifiers = qualifier.Identifiers;
            foreach (var identifier in identifiers)
            {
                var symbol = containerSymbol?.GetSourceMember(identifier.Syntax);
                // Debug.Assert(symbol != null); // TODO:MetaDslx
                if (symbol != null) result.Add(symbol);
                else result.Add(Compilation.CreateErrorTypeSymbol(containerSymbol as INamespaceOrTypeSymbol, Language.SyntaxFacts.ExtractName(identifier.Syntax), 0));
                containerSymbol = symbol;
            }
            qualifier.InitializeValues(identifiers, result.ToImmutableAndFree());
        }
    }
}
