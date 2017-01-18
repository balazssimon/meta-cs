using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// The parsed representation of a source document.
    /// </summary>
    public abstract class SyntaxTree
    {
        private ImmutableArray<byte> _lazyChecksum;
        private SourceHashAlgorithm _lazyHashAlgorithm;

        /// <summary>
        /// Returns true if this syntax tree has a root with SyntaxKind "CompilationUnit".
        /// </summary>
        public abstract Language Language { get; }

        /// <summary>
        /// The path of the source document file.
        /// </summary>
        /// <remarks>
        /// If this syntax tree is not associated with a file, this value can be empty.
        /// The path shall not be null.
        /// 
        /// The file doesn't need to exist on disk. The path is opaque to the compiler.
        /// The only requirement on the path format is that the implementations of 
        /// <see cref="SourceReferenceResolver"/>, <see cref="XmlReferenceResolver"/> and <see cref="MetadataReferenceResolver"/> 
        /// passed to the compilation that contains the tree understand it.
        /// 
        /// Clients must also not assume that the values of this property are unique
        /// within a Compilation.
        /// 
        /// The path is used as follows:
        ///    - When debug information is emitted, this path is embedded in the debug information.
        ///    - When resolving and normalizing relative paths in #r, #load, #line/#ExternalSource, 
        ///      #pragma checksum, #ExternalChecksum directives, XML doc comment include elements, etc.
        /// </remarks>
        public abstract string FilePath { get; }

        /// <summary>
        /// Returns true if this syntax tree has a root with SyntaxKind "CompilationUnit".
        /// </summary>
        public abstract bool HasCompilationUnitRoot { get; }

        public virtual bool SupportsLocations
        {
            get { return this.HasCompilationUnitRoot; }
        }

        /// <summary>
        /// The options used by the parser to produce the syntax tree.
        /// </summary>
        public ParseOptions Options
        {
            get
            {
                return this.OptionsCore;
            }
        }

        /// <summary>
        /// The options used by the parser to produce the syntax tree.
        /// </summary>
        protected abstract ParseOptions OptionsCore { get; }

        /// <summary>
        /// The length of the text of the syntax tree.
        /// </summary>
        public abstract int Length { get; }

        /// <summary>
        /// Gets the syntax tree's text if it is available.
        /// </summary>
        public abstract bool TryGetText(out SourceText text);

        /// <summary>
        /// Gets the text of the source document.
        /// </summary>
        public abstract SourceText GetText(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// The text encoding of the source document.
        /// </summary>
        public abstract Encoding Encoding { get; }

        /// <summary>
        /// Gets the text of the source document asynchronously.
        /// </summary>
        /// <remarks>
        /// By default, the work associated with this method will be executed immediately on the current thread.
        /// Implementations that wish to schedule this work differently should override <see cref="GetTextAsync(CancellationToken)"/>.
        /// </remarks>
        public virtual Task<SourceText> GetTextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SourceText text;
            return Task.FromResult(this.TryGetText(out text) ? text : this.GetText(cancellationToken));
        }

        /// <summary>
        /// Gets the root of the syntax tree if it is available.
        /// </summary>
        public bool TryGetRoot(out SyntaxNode root)
        {
            return TryGetRootCore(out root);
        }

        /// <summary>
        /// Gets the root of the syntax tree if it is available.
        /// </summary>
        protected abstract bool TryGetRootCore(out SyntaxNode root);

        /// <summary>
        /// Gets the root node of the syntax tree, causing computation if necessary.
        /// </summary>
        public SyntaxNode GetRoot(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetRootCore(cancellationToken);
        }

        /// <summary>
        /// Gets the root node of the syntax tree, causing computation if necessary.
        /// </summary>
        protected abstract SyntaxNode GetRootCore(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        public Task<SyntaxNode> GetRootAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetRootAsyncCore(cancellationToken);
        }

        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        protected abstract Task<SyntaxNode> GetRootAsyncCore(CancellationToken cancellationToken);

        /// <summary>
        /// Create a new syntax tree based off this tree using a new source text.
        /// 
        /// If the new source text is a minor change from the current source text an incremental
        /// parse will occur reusing most of the current syntax tree internal data.  Otherwise, a
        /// full parse will occur using the new source text.
        /// </summary>
        public abstract SyntaxTree WithChangedText(SourceText newText);

        /// <summary>
        /// Gets a list of all the diagnostics in the sub tree that has the specified node as its root.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public IEnumerable<Diagnostic> GetDiagnostics(SyntaxNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return GetDiagnostics(node.Green, node.Position);
        }

        private IEnumerable<Diagnostic> GetDiagnostics(GreenNode greenNode, int position)
        {
            if (greenNode == null)
            {
                throw new InvalidOperationException();
            }

            if (greenNode.ContainsDiagnostics)
            {
                return EnumerateDiagnostics(greenNode, position);
            }

            return EmptyCollections.Enumerable<Diagnostic>();
        }

        private IEnumerable<Diagnostic> EnumerateDiagnostics(GreenNode node, int position)
        {
            var enumerator = new SyntaxTreeDiagnosticEnumerator(this, node, position);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the token and any related trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public IEnumerable<Diagnostic> GetDiagnostics(SyntaxToken token)
        {
            return GetDiagnostics(token.Green, token.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public IEnumerable<Diagnostic> GetDiagnostics(SyntaxTrivia trivia)
        {
            return GetDiagnostics(trivia.Green, trivia.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in either the sub tree that has the specified node as its root or
        /// associated with the token and its related trivia. 
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public IEnumerable<Diagnostic> GetDiagnostics(RedNode nodeOrToken)
        {
            return GetDiagnostics(nodeOrToken.Green, nodeOrToken.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in the syntax tree.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public IEnumerable<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetDiagnostics((SyntaxNode)this.GetRoot(cancellationToken));
        }

        /// <summary>
        /// Gets the location in terms of path, line and column for a given span.
        /// </summary>
        /// <param name="span">Span within the tree.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// <see cref="FileLinePositionSpan"/> that contains path, line and column information.
        /// </returns>
        /// <remarks>The values are not affected by line mapping directives (<c>#line</c>).</remarks>
        public FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FileLinePositionSpan(this.FilePath, GetLinePosition(span.Start), GetLinePosition(span.End));
        }

        private LinePosition GetLinePosition(int position)
        {
            return this.GetText().Lines.GetLinePosition(position);
        }

        /// <summary>
        /// Gets the location in terms of path, line and column after applying source line mapping directives (<c>#line</c>). 
        /// </summary>
        /// <param name="span">Span within the tree.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// <para>A valid <see cref="FileLinePositionSpan"/> that contains path, line and column information.</para>
        /// <para>
        /// If the location path is mapped the resulting path is the path specified in the corresponding <c>#line</c>,
        /// otherwise it's <see cref="SyntaxTree.FilePath"/>.
        /// </para>
        /// <para>
        /// A location path is considered mapped if the first <c>#line</c> directive that precedes it and that
        /// either specifies an explicit file path or is <c>#line default</c> exists and specifies an explicit path.
        /// </para>
        /// </returns>
        public virtual FileLinePositionSpan GetMappedLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetLineSpan(span, cancellationToken);
        }

        /// <summary>
        /// Returns the visibility for the line at the given position.
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <param name="cancellationToken">The cancellation token.</param> 
        public virtual LineVisibility GetLineVisibility(int position, CancellationToken cancellationToken = default(CancellationToken))
        {
            return LineVisibility.Visible;
        }

        /// <summary>
        /// Gets a FileLinePositionSpan for a TextSpan and the information whether this span is considered to be hidden or not. 
        /// FileLinePositionSpans are used primarily for diagnostics and source locations.
        /// This method combines a call to GetLineSpan and IsHiddenPosition.
        /// </summary>
        /// <param name="span"></param>
        /// <param name="isHiddenPosition">Returns a boolean indicating whether this span is considered hidden or not.</param>
        /// <remarks>This function is being called only in the context of sequence point creation and therefore interprets the 
        /// LineVisibility accordingly (BeforeFirstRemappingDirective -> Visible).</remarks>
        internal virtual FileLinePositionSpan GetMappedLineSpanAndVisibility(TextSpan span, out bool isHiddenPosition)
        {
            isHiddenPosition = GetLineVisibility(span.Start) == LineVisibility.Hidden;
            return GetMappedLineSpan(span);
        }

        /// <summary>
        /// Returns a path for particular location in source that is presented to the user. 
        /// </summary>
        /// <remarks>
        /// Used for implementation of <see cref="System.Runtime.CompilerServices.CallerFilePathAttribute"/> 
        /// or for embedding source paths in error messages.
        /// 
        /// Unlike Dev12 we do account for #line and #ExternalSource directives when determining value for 
        /// <see cref="System.Runtime.CompilerServices.CallerFilePathAttribute"/>.
        /// </remarks>
        internal string GetDisplayPath(TextSpan span, SourceReferenceResolver resolver)
        {
            var mappedSpan = GetMappedLineSpan(span);
            if (resolver == null || string.IsNullOrEmpty(mappedSpan.Path))
            {
                return mappedSpan.Path;
            }

            return resolver.NormalizePath(mappedSpan.Path, baseFilePath: mappedSpan.HasMappedPath ? FilePath : null) ?? mappedSpan.Path;
        }

        /// <summary>
        /// Returns a line number for particular location in source that is presented to the user. 
        /// </summary>
        /// <remarks>
        /// Used for implementation of <see cref="System.Runtime.CompilerServices.CallerLineNumberAttribute"/> 
        /// or for embedding source line numbers in error messages.
        /// 
        /// Unlike Dev12 we do account for #line and #ExternalSource directives when determining value for 
        /// <see cref="System.Runtime.CompilerServices.CallerLineNumberAttribute"/>.
        /// </remarks>
        internal int GetDisplayLineNumber(TextSpan span)
        {
            // display line numbers are 1-based
            return GetMappedLineSpan(span).StartLinePosition.Line + 1;
        }

        /// <summary>
        /// Are there any hidden regions in the tree?
        /// </summary>
        /// <returns>True if there is at least one hidden region.</returns>
        public virtual bool HasHiddenRegions()
        {
            return false;
        }

        /// <summary>
        /// Produces a pessimistic list of spans that denote the regions of text in this tree that
        /// are changed from the text of the old tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list is pessimistic because it may claim more or larger regions than actually changed.</remarks>
        public IList<TextSpan> GetChangedSpans(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetPossiblyDifferentTextSpans(oldTree, this);
        }

        /// <summary>
        /// Gets a list of text changes that when applied to the old tree produce this tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list of changes may be different than the original changes that produced this tree.</remarks>
        public IList<TextChange> GetChanges(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetTextChanges(oldTree, this);
        }

        /// <summary>
        /// Gets a location for the specified text span.
        /// </summary>
        public Location GetLocation(TextSpan span)
        {
            return new SourceLocation(this, span);
        }

        private bool _hasDirectives;
        private DirectiveStack _directives;

        protected void SetDirectiveStack(DirectiveStack directives)
        {
            _directives = directives;
            _hasDirectives = true;
        }

        protected DirectiveStack GetDirectives()
        {
            if (!_hasDirectives)
            {
                var stack = DirectiveStack.Empty;//this.GetRoot().Green.ApplyDirectives(default(InternalSyntax.DirectiveStack));
                SetDirectiveStack(stack);
            }

            return _directives;
        }


        /// <summary>
        /// Determines if two trees are the same.
        /// </summary>
        /// <param name="tree">The tree to compare against.</param>
        public virtual bool IsEquivalentTo(SyntaxTree tree)
        {
            return this.GetRoot().Green.IsEquivalentTo(tree.GetRoot().Green);
        }

        /// <summary>
        /// Gets a SyntaxReference for a specified syntax node. SyntaxReferences can be used to
        /// regain access to a syntax node without keeping the entire tree and source text in
        /// memory.
        /// </summary>
        public SyntaxReference GetReference(SyntaxNode node)
        {
            return new SimpleSyntaxReference(node);
        }

        internal Tuple<ImmutableArray<byte>, SourceHashAlgorithm> GetChecksumAndAlgorithm()
        {
            if (_lazyChecksum.IsDefault)
            {
                var text = this.GetText();
                _lazyChecksum = text.GetChecksum();
                _lazyHashAlgorithm = text.ChecksumAlgorithm;
            }

            Debug.Assert(!_lazyChecksum.IsDefault);
            return Tuple.Create(_lazyChecksum, _lazyHashAlgorithm);
        }

        /// <summary>
        /// Returns a <see cref="String" /> that represents the entire source text of this <see cref="SyntaxTree"/>.
        /// </summary>
        public override string ToString()
        {
            return this.GetText(CancellationToken.None).ToString();
        }

        /// <summary>
        /// Verify nodes match source.
        /// </summary>
        [Conditional("DEBUG")]
        protected void VerifySource(IEnumerable<TextChangeRange> changes = null)
        {
            var root = this.GetRoot();
            var text = this.GetText();
            var fullSpan = new TextSpan(0, text.Length);
            SyntaxNode node = null;

            // If only a subset of the document has changed,
            // just check that subset to reduce verification cost.
            if (changes != null)
            {
                var change = TextChangeRange.Collapse(changes).Span;
                if (!change.Equals(fullSpan))
                {
                    // Find the lowest node in the tree that contains the changed region.
                    node = root.DescendantNodes(n => n.FullSpan.Contains(change)).LastOrDefault();
                }
            }

            if (node == null)
            {
                node = root;
            }

            var span = node.FullSpan;
            var textSpanOpt = span.Intersection(fullSpan);
            int index;

            if (textSpanOpt == null)
            {
                index = 0;
            }
            else
            {
                var fromText = text.ToString(textSpanOpt.Value);
                var fromNode = node.ToFullString();
                index = FindFirstDifference(fromText, fromNode);
            }

            if (index >= 0)
            {
                index += span.Start;
                string message;
                if (index < text.Length)
                {
                    var position = text.Lines.GetLinePosition(index);
                    var line = text.Lines[position.Line];
                    var allText = text.ToString(); // Entire document as string to allow inspecting the text in the debugger.
                    message = string.Format("Unexpected difference at offset {0}: Line {1}, Column {2} \"{3}\"",
                        index,
                        position.Line + 1,
                        position.Character + 1,
                        line.ToString());
                }
                else
                {
                    message = "Unexpected difference past end of the file";
                }
                Debug.Assert(false, message);
            }
        }

        /// <summary>
        /// Return the index of the first difference between
        /// the two strings, or -1 if the strings are the same.
        /// </summary>
        private static int FindFirstDifference(string s1, string s2)
        {
            var n1 = s1.Length;
            var n2 = s2.Length;
            var n = Math.Min(n1, n2);
            for (int i = 0; i < n; i++)
            {
                if (s1[i] != s2[i])
                {
                    return i;
                }
            }
            return (n1 == n2) ? -1 : n + 1;
        }
    }
}
