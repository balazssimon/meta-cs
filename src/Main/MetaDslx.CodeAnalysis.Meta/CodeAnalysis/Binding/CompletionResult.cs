using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class CompletionResult
    {
        private readonly ImmutableArray<CompletionItem> _completionItems;
        private readonly ImmutableArray<CompletionRangeResult> _ranges;

        public CompletionResult(ImmutableArray<CompletionItem> completionItems, ImmutableArray<CompletionRangeResult> ranges)
        {
            _completionItems = completionItems;
            _ranges = ranges;
        }

        public ImmutableArray<CompletionItem> CompletionItems => _completionItems;

        public ImmutableArray<CompletionRangeResult> Ranges => _ranges;

        public static CompletionResult Create(LanguageCompilation compilation, LanguageSyntaxTree syntaxTree, int position)
        {
            var syntaxFacts = syntaxTree.Language.SyntaxFacts;
            var itemResults = PooledDictionary<TextSpan, PooledHashSet<CompletionItem>>.GetInstance();
            var completionBinders = compilation.GetCompletionBinders(syntaxTree, position);
            foreach (var completionBinder in completionBinders)
            {
                if (completionBinder.BinderOrTokenKind is SyntaxKind tokenKind)
                {
                    AddResult(itemResults, completionBinder.TextSpan, new CompletionItem(tokenKind, syntaxFacts.GetText(tokenKind)));
                }
                else if (completionBinder.BinderOrTokenKind is Binder binder)
                {
                    Debug.Assert(binder.IsValidCompletionBinder);
                    var symbols = LookupCandidates.GetInstance();
                    var location = (SourceLocation)syntaxTree.GetLocation(TextSpan.FromBounds(position, position));
                    binder.AddCompletionSymbols(symbols, new LookupConstraints(binder, location, diagnose: false));
                    foreach (var symbol in symbols.Symbols)
                    {
                        if (symbol.CanBeReferencedByName && !string.IsNullOrEmpty(symbol.Name))
                        {
                            AddResult(itemResults, completionBinder.TextSpan, new CompletionItem(symbol));
                        }
                    }
                    symbols.Free();
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            var results = ArrayBuilder<CompletionRangeResult>.GetInstance();
            var completionItems = PooledHashSet<CompletionItem>.GetInstance();
            var rangeResults = ArrayBuilder<CompletionItem>.GetInstance();
            foreach (var textSpan in itemResults.Keys)
            {
                var items = itemResults[textSpan];
                rangeResults.Clear();
                rangeResults.AddRange(items);
                completionItems.UnionWith(items);
                results.Add(new CompletionRangeResult(textSpan, rangeResults.ToImmutable()));
                items.Free();
            }
            rangeResults.Free();
            var completionItemsArray = completionItems.ToImmutableArray();
            completionItems.Free();
            return new CompletionResult(completionItemsArray, results.ToImmutableAndFree());
        }

        private static void AddResult(Dictionary<TextSpan, PooledHashSet<CompletionItem>> results, TextSpan textSpan, CompletionItem item)
        {
            if (!results.TryGetValue(textSpan, out var items))
            {
                items = PooledHashSet<CompletionItem>.GetInstance();
                results.Add(textSpan, items);
            }
            items.Add(item);
        }
    }
}
