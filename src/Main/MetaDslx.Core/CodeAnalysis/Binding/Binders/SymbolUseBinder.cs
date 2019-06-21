using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolUseBinder : Binder
    {
        private readonly ImmutableArray<ModelSymbolInfo> _symbolTypes;
        private readonly ImmutableArray<ModelSymbolInfo> _nestingSymbolTypes;
        private readonly LanguageSyntaxNode _syntax;

        public SymbolUseBinder(Binder next, LanguageSyntaxNode syntax, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes)
            : base(next)
        {
            _syntax = syntax;
            _symbolTypes = symbolTypes.Select(type => ModelSymbolInfo.GetSymbolInfo(type)).ToImmutableArray();
            _nestingSymbolTypes = nestingSymbolTypes.Select(type => ModelSymbolInfo.GetSymbolInfo(type)).ToImmutableArray();
        }

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var boundNode = this.Compilation.GetBoundNode<BoundSymbolUse>(_syntax);
            var qualifiers = boundNode.GetChildQualifiers();
            foreach (var child in qualifiers)
            {
                if (child.Syntax.Span.Contains(qualifier.Syntax.Span))
                {
                    this.InitializeFullQualifierSymbol(qualifier);
                    return;
                }
            }
        }

        private void InitializeFullQualifierSymbol(BoundQualifier qualifier)
        {
            var result = ArrayBuilder<Symbol>.GetInstance();
            var identifiers = qualifier.Identifiers;
            NamespaceOrTypeSymbol qualifierOpt = null;
            for (int i = 0; i < identifiers.Length; i++)
            {
                bool last = i == identifiers.Length - 1;
                var identifier = identifiers[i];
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                LookupResult lookupResult = LookupResult.GetInstance();
                LookupResult viableResult = LookupResult.GetInstance();
                this.LookupSymbolsSimpleName(lookupResult, qualifierOpt, identifier.Name, identifier.MetadataName, null, LookupOptions.Default, false, ref useSiteDiagnostics);
                if (last)
                {
                    if (_symbolTypes.Length > 0)
                    {
                        foreach (var s in lookupResult.Symbols)
                        {
                            if (_symbolTypes.Any(st => st.ImmutableType.IsAssignableFrom(s.ModelSymbolInfo.ImmutableType)))
                            {
                                viableResult.MergeEqual(LookupResult.Good(s));
                            }
                        }
                    }
                }
                else
                {
                    if (_nestingSymbolTypes.Length > 0)
                    {
                        foreach (var s in lookupResult.Symbols)
                        {
                            if (_nestingSymbolTypes.Any(st => st.ImmutableType.IsAssignableFrom(s.ModelSymbolInfo.ImmutableType)))
                            {
                                viableResult.MergeEqual(LookupResult.Good(s));
                            }
                        }
                    }
                }
                viableResult.MergePrioritized(lookupResult);
                var symbol = this.ResultSymbol(lookupResult, identifier.Name, identifier.MetadataName, identifier.Syntax, identifier.BoundTree.DiagnosticBag, false, out bool wasError, qualifierOpt, LookupOptions.Default);
                result.Add(symbol);
                lookupResult.Free();
                qualifierOpt = symbol as NamespaceOrTypeSymbol;
            }
            qualifier.InitializeSymbols(identifiers, result.ToImmutableAndFree());
        }

    }
}
