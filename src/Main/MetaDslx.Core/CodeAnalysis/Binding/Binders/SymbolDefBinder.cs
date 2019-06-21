using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _symbolType;
        private readonly Type _nestingSymbolType;
        private Symbol _definedSymbol;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolDefBinder(Binder next, LanguageSyntaxNode syntax, Type symbolType, Type nestingSymbolType) 
            : base(next)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
            _syntax = syntax;
        }

        public Symbol DefinedSymbol
        {
            get
            {
                if (_definedSymbol == null)
                {
                    var containerSymbol = this.Next.GetEnclosingDeclarationSymbol(_syntax);
                    Symbol symbol = null;
                    while (containerSymbol != null)
                    {
                        var member = this.GetSourceMember(containerSymbol, _syntax);
                        if (member != null) symbol = member;
                        containerSymbol = member as ISourceDeclarationSymbol;
                    }
                    Interlocked.CompareExchange(ref _definedSymbol, symbol, null);
                }
                return _definedSymbol;
            }
        }

        public override ISourceDeclarationSymbol GetEnclosingDeclarationSymbol(SyntaxNodeOrToken syntax)
        {
            return this.DefinedSymbol as ISourceDeclarationSymbol;
        }

        /// <summary>
        /// Get a source symbol for the given declaration syntax.
        /// </summary>
        /// <returns>Null if there is no matching declaration.</returns>
        private Symbol GetSourceMember(ISourceDeclarationSymbol containerSymbol, SyntaxNodeOrToken syntax)
        {
            if (syntax == null) return null;
            if (containerSymbol == null) return null;
            foreach (var member in containerSymbol.GetDeclaredChildren())
            {
                var memberT = member as Symbol;
                if ((object)memberT != null)
                {
                    foreach (var syntaxRef in memberT.DeclaringSyntaxReferences)
                    {
                        if (syntaxRef.SyntaxTree == syntax.SyntaxTree && syntax.Span.Equals(syntaxRef.Span))
                        {
                            return memberT;
                        }
                    }
                }
            }
            // None found.
            return null;
        }

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var boundNode = this.Compilation.GetBoundNode<BoundSymbolDef>(_syntax);
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
            var containerSymbol = this.Next.GetEnclosingDeclarationSymbol(qualifier.Syntax);
            var result = ArrayBuilder<Symbol>.GetInstance();
            var identifiers = qualifier.Identifiers;
            for (int i = 0; i < identifiers.Length; i++)
            {
                bool last = i == identifiers.Length - 1;
                var identifier = identifiers[i];
                var symbol = containerSymbol.GetSourceMember(identifier.Syntax);
                result.Add(symbol);
                containerSymbol = symbol as ISourceDeclarationSymbol;
            }
            qualifier.InitializeSymbols(identifiers, result.ToImmutableAndFree());
        }
    }
}
