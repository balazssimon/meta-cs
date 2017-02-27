// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MetaDslx.Languages.Soal.Syntax
{
    /// <summary>
    /// The parsed representation of a Soal source document.
    /// </summary>
    public abstract class SoalSyntaxTree : SyntaxTree
    {
        internal static readonly SyntaxTree Dummy = new DummySyntaxTree();
        public override Language Language => SoalLanguage.Instance;
        /// <summary>
        /// The options used by the parser to produce the syntax tree.
        /// </summary>
        public new abstract SoalParseOptions Options { get; }
        /// <summary>
        /// Gets the root node of the syntax tree.
        /// </summary>
        public new abstract SoalSyntaxNode GetRoot(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the root node of the syntax tree if it is already available.
        /// </summary>
        public abstract bool TryGetRoot(out SoalSyntaxNode root);
        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        /// <remarks>
        /// By default, the work associated with this method will be executed immediately on the current thread.
        /// Implementations that wish to schedule this work differently should override <see cref="GetRootAsync(CancellationToken)"/>.
        /// </remarks>
        public new virtual Task<SoalSyntaxNode> GetRootAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SoalSyntaxNode node;
            return Task.FromResult(this.TryGetRoot(out node) ? node : this.GetRoot(cancellationToken));
        }
        /// <summary>
        /// Gets the root of the syntax tree statically typed as <see cref="CompilationUnitSyntax"/>.
        /// </summary>
        /// <remarks>
        /// Ensure that <see cref="SyntaxTree.HasCompilationUnitRoot"/> is true for this tree prior to invoking this method.
        /// </remarks>
        /// <exception cref="InvalidCastException">Throws this exception if <see cref="SyntaxTree.HasCompilationUnitRoot"/> is false.</exception>
        public MainSyntax GetCompilationUnitRoot(CancellationToken cancellationToken = default(CancellationToken))
        {
            return (MainSyntax)this.GetRoot(cancellationToken);
        }
        /// <summary>
        /// Creates a new syntax based off this tree using a new source text.
        /// </summary>
        /// <remarks>
        /// If the new source text is a minor change from the current source text an incremental parse will occur
        /// reusing most of the current syntax tree internal data.  Otherwise, a full parse will occur using the new
        /// source text.
        /// </remarks>
        public override SyntaxTree WithChangedText(SourceText newText)
        {
            // try to find the changes between the old text and the new text.
            SourceText oldText;
            if (this.TryGetText(out oldText))
            {
                var changes = newText.GetChangeRanges(oldText);
                if (changes.Count == 0 && newText == oldText)
                {
                    return this;
                }
                return this.WithChanges(newText, changes);
            }
            // if we do not easily know the old text, then specify entire text as changed so we do a full reparse.
            return this.WithChanges(newText, new[] { new TextChangeRange(new TextSpan(0, this.Length), newText.Length) });
        }
        private SyntaxTree WithChanges(SourceText newText, IReadOnlyList<TextChangeRange> changes)
        {
            if (changes == null)
            {
                throw new ArgumentNullException(nameof(changes));
            }
            var oldTree = this;
            // if changes is entire text do a full reparse
            if (changes.Count == 1 && new TextSpan(0, this.Length).Equals(changes[0].Span) && changes[0].NewLength == newText.Length)
            {
                // parser will do a full parse if we give it no changes
                changes = null;
                oldTree = null;
            }
            using (var parser = SoalLanguage.Instance.SyntaxFactory.MakeParser(newText, this.Options, oldTree?.GetRoot(), changes))
            {
                var compilationUnit = (MainSyntax)parser.Parse().CreateRed();
                var tree = new ParsedSyntaxTree(newText, newText.Encoding, newText.ChecksumAlgorithm, this.FilePath, this.Options, compilationUnit, parser.Directives);
                tree.VerifySource(changes);
                return tree;
            }
        }
        public abstract SoalSyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options);
        public abstract SoalSyntaxTree WithFilePath(string path);
        #region Factories
        /// <summary>
        /// Creates a new syntax tree from a syntax node.
        /// </summary>
        public static SoalSyntaxTree Create(SoalSyntaxNode root, SoalParseOptions options = null, string path = "", Encoding encoding = null)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            var directives = DirectiveStack.Empty;
            return new ParsedSyntaxTree(
                textOpt: null,
                encodingOpt: encoding,
                checksumAlgorithm: SourceHashAlgorithm.Sha1,
                path: path,
                options: options ?? SoalParseOptions.Default,
                root: root,
                directives: directives);
        }
        /// <summary>
        /// Creates a new syntax tree from a syntax node with text that should correspond to the syntax node.
        /// </summary>
        /// <remarks>This is used by the ExpressionEvaluator.</remarks>
        internal static SoalSyntaxTree CreateForDebugger(SoalSyntaxNode root, SourceText text)
        {
            Debug.Assert(root != null);
            return new DebuggerSyntaxTree(root, text);
        }
        /// <summary>
        /// <para>
        /// Internal helper for <see cref="SoalSyntaxNode"/> class to create a new syntax tree rooted at the given root node.
        /// This method does not create a clone of the given root, but instead preserves it's reference identity.
        /// </para>
        /// <para>NOTE: This method is only intended to be used from <see cref="SoalSyntaxNode.SyntaxTree"/> property.</para>
        /// <para>NOTE: Do not use this method elsewhere, instead use <see cref="Create(SoalSyntaxNode, SoalParseOptions, string, Encoding)"/> method for creating a syntax tree.</para>
        /// </summary>
        internal static SoalSyntaxTree CreateWithoutClone(SoalSyntaxNode root)
        {
            Debug.Assert(root != null);
            return new ParsedSyntaxTree(
                textOpt: null,
                encodingOpt: null,
                checksumAlgorithm: SourceHashAlgorithm.Sha1,
                path: "",
                options: SoalParseOptions.Default,
                root: root,
                directives: DirectiveStack.Empty,
                cloneRoot: false);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static SoalSyntaxTree ParseText(
            string text,
            SoalParseOptions options = null,
            string path = "",
            Encoding encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ParseText(SourceText.From(text, encoding), options, path, cancellationToken);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static SoalSyntaxTree ParseText(
            SourceText text,
            SoalParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            options = options ?? SoalParseOptions.Default;
            using (var parser = SoalLanguage.Instance.SyntaxFactory.MakeParser(text, options, oldTree: null, changes: null))
            {
                var compilationUnit = (MainSyntax)parser.Parse().CreateRed();
                var tree = new ParsedSyntaxTree(text, text.Encoding, text.ChecksumAlgorithm, path, options, compilationUnit, parser.Directives);
                tree.VerifySource();
                return tree;
            }
        }
        #endregion
        #region SyntaxTree
        protected override SyntaxNode GetRootCore(CancellationToken cancellationToken)
        {
            return this.GetRoot(cancellationToken);
        }
        protected override async Task<SyntaxNode> GetRootAsyncCore(CancellationToken cancellationToken)
        {
            return await this.GetRootAsync(cancellationToken).ConfigureAwait(false);
        }
        protected override bool TryGetRootCore(out SyntaxNode root)
        {
            SoalSyntaxNode node;
            if (this.TryGetRoot(out node))
            {
                root = node;
                return true;
            }
            else
            {
                root = null;
                return false;
            }
        }
        protected override ParseOptions OptionsCore
        {
            get
            {
                return this.Options;
            }
        }
        #endregion
        private class DebuggerSyntaxTree : ParsedSyntaxTree
        {
            public DebuggerSyntaxTree(SoalSyntaxNode root, SourceText text)
                : base(
                    text,
                    text.Encoding,
                    text.ChecksumAlgorithm,
                    path: "",
                    options: SoalParseOptions.Default,
                    root: root,
                    directives: DirectiveStack.Empty)
            {
            }
            public override bool SupportsLocations
            {
                get { return true; }
            }
        }
        private sealed class DummySyntaxTree : SoalSyntaxTree
        {
            private readonly MainSyntax _node;
            public DummySyntaxTree()
            {
                _node = new MainSyntax(SoalLanguage.Instance.InternalSyntaxFactory.Main(null, null, true), this, 0);
            }
            public override string ToString()
            {
                return string.Empty;
            }
            public override SourceText GetText(CancellationToken cancellationToken)
            {
                return SourceText.From(string.Empty, Encoding.UTF8);
            }
            public override bool TryGetText(out SourceText text)
            {
                text = SourceText.From(string.Empty, Encoding.UTF8);
                return true;
            }
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
            public override int Length
            {
                get { return 0; }
            }
            public override SoalParseOptions Options
            {
                get { return SoalParseOptions.Default; }
            }
            public override string FilePath
            {
                get { return string.Empty; }
            }
            public override SoalSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _node;
            }
            public override bool TryGetRoot(out SoalSyntaxNode root)
            {
                root = _node;
                return true;
            }
            public override bool HasCompilationUnitRoot
            {
                get { return true; }
            }
            public override SoalSyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
            {
                return SoalLanguage.Instance.SyntaxFactory.SyntaxTree(root, options: (SoalParseOptions)options, path: FilePath, encoding: null);
            }
            public override SoalSyntaxTree WithFilePath(string path)
            {
                return SoalLanguage.Instance.SyntaxFactory.SyntaxTree(_node, options: this.Options, path: path, encoding: null);
            }
        }
        private class ParsedSyntaxTree : SoalSyntaxTree
        {
            private readonly SoalParseOptions _options;
            private readonly string _path;
            private readonly SoalSyntaxNode _root;
            private readonly bool _hasCompilationUnitRoot;
            private readonly Encoding _encodingOpt;
            private readonly SourceHashAlgorithm _checksumAlgorithm;
            private SourceText _lazyText;
            internal ParsedSyntaxTree(SourceText textOpt, Encoding encodingOpt, SourceHashAlgorithm checksumAlgorithm, string path, SoalParseOptions options, SoalSyntaxNode root, DirectiveStack directives, bool cloneRoot = true)
            {
                Debug.Assert(root != null);
                Debug.Assert(options != null);
                Debug.Assert(path != null);
                Debug.Assert(textOpt == null || textOpt.Encoding == encodingOpt && textOpt.ChecksumAlgorithm == checksumAlgorithm);
                _lazyText = textOpt;
                _encodingOpt = encodingOpt ?? textOpt?.Encoding;
                _checksumAlgorithm = checksumAlgorithm;
                _options = options;
                _path = path;
                _root = cloneRoot ? new MainSyntax((InternalSyntaxNode)root.Green, this, 0) : root;
                _hasCompilationUnitRoot = root.Kind == SoalSyntaxKind.Main;
                this.SetDirectiveStack(directives);
            }
            public override string FilePath
            {
                get { return _path; }
            }
            public override SourceText GetText(CancellationToken cancellationToken)
            {
                if (_lazyText == null)
                {
                    Interlocked.CompareExchange(ref _lazyText, this.GetRoot(cancellationToken).GetText(_encodingOpt, _checksumAlgorithm), null);
                }
                return _lazyText;
            }
            public override bool TryGetText(out SourceText text)
            {
                text = _lazyText;
                return text != null;
            }
            public override Encoding Encoding
            {
                get { return _encodingOpt; }
            }
            public override int Length
            {
                get { return _root.FullSpan.Length; }
            }
            public override SoalSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _root;
            }
            public override bool TryGetRoot(out SoalSyntaxNode root)
            {
                root = _root;
                return true;
            }
            public override bool HasCompilationUnitRoot
            {
                get
                {
                    return _hasCompilationUnitRoot;
                }
            }
            public override SoalParseOptions Options
            {
                get
                {
                    return _options;
                }
            }
            public override SoalSyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
            {
                if (ReferenceEquals(_root, root) && ReferenceEquals(_options, options))
                {
                    return this;
                }
                return new ParsedSyntaxTree(
                    null,
                    _encodingOpt,
                    _checksumAlgorithm,
                    _path,
                    (SoalParseOptions)options,
                    (SoalSyntaxNode)root,
                    this.GetDirectives());
            }
            public override SoalSyntaxTree WithFilePath(string path)
            {
                if (_path == path)
                {
                    return this;
                }
                return new ParsedSyntaxTree(
                    _lazyText,
                    _encodingOpt,
                    _checksumAlgorithm,
                    path,
                    _options,
                    _root,
                    this.GetDirectives());
            }
        }
    }
}

