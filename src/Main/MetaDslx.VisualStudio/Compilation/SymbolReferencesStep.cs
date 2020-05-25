using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public sealed class SymbolReferencesStep : IBackgroundCompilationStep
    {
        private BackgroundCompilation _backgroundCompilation;

        public SymbolReferencesStep(BackgroundCompilation backgroundCompilation)
        {
            _backgroundCompilation = backgroundCompilation;
        }

        public object ResultKey => typeof(SymbolReferencesResult);

        public object Execute(ICompilation compilation, CancellationToken cancellationToken)
        {
            var result = new SymbolReferencesResult();
            var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
            var collectedSymbols = compilationSnapshot.GetCompilationStepResult<CollectSymbolsResult>();
            if (collectedSymbols == null) return result;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            foreach (var token in collectedSymbols.TokensWithSymbols)
            {
                var tokenSpan = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                var symbol = collectedSymbols.GetSymbol(token);
                if (symbol.Locations.Any(loc => loc.SourceSpan == token.Span))
                {
                    var nameDefinitions = ArrayBuilder<SnapshotSpan>.GetInstance();
                    var definitions = ArrayBuilder<SnapshotSpan>.GetInstance();
                    int index = 0;
                    foreach (var location in symbol.Locations)
                    {
                        var syntaxDecl = symbol.DeclaringSyntaxReferences[index];
                        nameDefinitions.Add(new SnapshotSpan(textSnapshot, new Span(location.SourceSpan.Start, location.SourceSpan.Length)));
                        var syntax = syntaxDecl.GetSyntax();
                        definitions.Add(new SnapshotSpan(textSnapshot, new Span(syntax.Span.Start, syntax.Span.Length)));
                        ++index;
                    }
                    result.TryAdd(symbol, nameDefinitions.ToImmutableAndFree(), definitions.ToImmutableAndFree(), GetReferences(symbol, collectedSymbols, textSnapshot));
                }
            }
            return result;
        }

        private ImmutableArray<SnapshotSpan> GetReferences(ISymbol symbol, CollectSymbolsResult symbols, ITextSnapshot textSnapshot)
        {
            var result = ArrayBuilder<SnapshotSpan>.GetInstance();
            foreach (var token in symbols.TokensWithSymbols)
            {
                var refSymbol = symbols.GetSymbol(token);
                if (object.ReferenceEquals(refSymbol, symbol) && !symbol.Locations.Any(loc => loc.SourceSpan == token.Span))
                {
                    result.Add(new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length)));
                }
            }
            return result.ToImmutableAndFree();
        }
    }

    public class SymbolReferencesResult
    {
        private Dictionary<ISymbol, ImmutableArray<SnapshotSpan>> _symbolNameDefinitions;
        private Dictionary<ISymbol, ImmutableArray<SnapshotSpan>> _symbolDefinitions;
        private Dictionary<ISymbol, ImmutableArray<SnapshotSpan>> _symbolReferences;

        public SymbolReferencesResult()
        {
            _symbolNameDefinitions = new Dictionary<ISymbol, ImmutableArray<SnapshotSpan>>();
            _symbolDefinitions = new Dictionary<ISymbol, ImmutableArray<SnapshotSpan>>();
            _symbolReferences = new Dictionary<ISymbol, ImmutableArray<SnapshotSpan>>();
        }

        internal bool TryAdd(ISymbol symbol, ImmutableArray<SnapshotSpan> nameDefinitions, ImmutableArray<SnapshotSpan> definitions, ImmutableArray<SnapshotSpan> references)
        {
            if (_symbolNameDefinitions.ContainsKey(symbol)) return false;
            _symbolNameDefinitions.Add(symbol, nameDefinitions);
            _symbolDefinitions.Add(symbol, definitions);
            _symbolReferences.Add(symbol, references);
            return true;
        }

        public IEnumerable<ISymbol> Symbols => _symbolDefinitions.Keys;

        public ImmutableArray<SnapshotSpan> GetNameDefinitions(ISymbol symbol)
        {
            if (_symbolNameDefinitions.TryGetValue(symbol, out var result)) return result;
            else return ImmutableArray<SnapshotSpan>.Empty;
        }

        public ImmutableArray<SnapshotSpan> GetDefinitions(ISymbol symbol)
        {
            if (_symbolDefinitions.TryGetValue(symbol, out var result)) return result;
            else return ImmutableArray<SnapshotSpan>.Empty;
        }

        public ImmutableArray<SnapshotSpan> GetReferences(ISymbol symbol)
        {
            if (_symbolReferences.TryGetValue(symbol, out var result)) return result;
            else return ImmutableArray<SnapshotSpan>.Empty;
        }
    }
}
