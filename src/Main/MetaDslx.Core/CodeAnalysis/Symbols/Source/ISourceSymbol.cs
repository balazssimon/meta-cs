using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface ISourceSymbol
    {
        LanguageCompilation DeclaringCompilation { get; }
        ImmutableArray<Location> Locations { get; }
        LexicalSortKey GetLexicalSortKey();
        bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default);
        void ForceComplete(SourceLocation location, CancellationToken cancellationToken = default);
    }
}