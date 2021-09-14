// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Syntax.InternalSyntax;
namespace MetaDslx.Languages.Core
{
    /// <summary>
    /// The parsed representation of a C# source document.
    /// </summary>
    public abstract partial class CoreSyntaxTree : LanguageSyntaxTree
    {
        internal static readonly CoreSyntaxTree Dummy = new DummySyntaxTree();
        /// <summary>
        /// The options used by the parser to produce the syntax tree.
        /// </summary>
        public new abstract CoreParseOptions Options { get; }
        /// <summary>
        /// Gets the root node of the syntax tree.
        /// </summary>
        public new abstract CoreSyntaxNode GetRoot(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the root node of the syntax tree if it is already available.
        /// </summary>
        public abstract bool TryGetRoot(out CoreSyntaxNode root);
        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        /// <remarks>
        /// By default, the work associated with this method will be executed immediately on the current thread.
        /// Implementations that wish to schedule this work differently should override <see cref="GetRootAsync(CancellationToken)"/>.
        /// </remarks>
        public new virtual Task<CoreSyntaxNode> GetRootAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            CoreSyntaxNode node;
            return Task.FromResult(this.TryGetRoot(out node) ? node : this.GetRoot(cancellationToken));
        }
        /// <summary>
        /// Gets the root of the syntax tree statically typed as <see cref="MainSyntax"/>.
        /// </summary>
        /// <remarks>
        /// Ensure that <see cref="SyntaxTree.HasCompilationUnitRoot"/> is true for this tree prior to invoking this method.
        /// </remarks>
        /// <exception cref="InvalidCastException">Throws this exception if <see cref="SyntaxTree.HasCompilationUnitRoot"/> is false.</exception>
        public MainSyntax GetCompilationUnitRoot(CancellationToken cancellationToken = default(CancellationToken))
        {
            return (MainSyntax)this.GetRoot(cancellationToken);
        }
        #region Factories
        /// <summary>
        /// Creates a new syntax tree from a syntax node.
        /// </summary>
        public static CoreSyntaxTree Create(CoreSyntaxNode root, ParseData parseData, CoreParseOptions? options = null, string path = "", SourceText? text = null, Encoding? encoding = null, SourceHashAlgorithm checksumAlgorithm = SourceHashAlgorithm.Sha1)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            var directives = root.Kind == CoreSyntaxKind.Main && root is ICompilationUnitRootSyntax compilationUnitRoot ?
                ((ICompilationUnitRootSyntax)root).GetConditionalDirectivesStack() :
                DirectiveStack.Empty;
            return new ParsedSyntaxTree(
                textOpt: text,
                encodingOpt: encoding,
                checksumAlgorithm: checksumAlgorithm,
                path: path,
                options: options ?? CoreParseOptions.Default,
                root: root,
                parseData: parseData.WithDirectives(directives));
        }
        /// <summary>
        /// Creates a new syntax tree from a syntax node with text that should correspond to the syntax node.
        /// </summary>
        /// <remarks>This is used by the ExpressionEvaluator.</remarks>
        internal static CoreSyntaxTree CreateForDebugger(CoreSyntaxNode root, ParseData parseData, SourceText text, CoreParseOptions options)
        {
            Debug.Assert(root != null);
            return new DebuggerSyntaxTree(root, parseData, text, options);
        }
        /// <summary>
        /// <para>
        /// Internal helper for <see cref="CoreSyntaxNode"/> class to create a new syntax tree rooted at the given root node.
        /// This method does not create a clone of the given root, but instead preserves it's reference identity.
        /// </para>
        /// <para>NOTE: This method is only intended to be used from <see cref="CoreSyntaxNode.SyntaxTree"/> property.</para>
        /// <para>NOTE: Do not use this method elsewhere, instead use <see cref="Create(CoreSyntaxNode, CSharpParseOptions, string, Encoding)"/> method for creating a syntax tree.</para>
        /// </summary>
        internal static CoreSyntaxTree CreateWithoutClone(CoreSyntaxNode root, ParseData parseData)
        {
            Debug.Assert(root != null);
            return new ParsedSyntaxTree(
                textOpt: null,
                encodingOpt: null,
                checksumAlgorithm: SourceHashAlgorithm.Sha1,
                path: "",
                options: CoreParseOptions.Default,
                root: root,
                parseData: parseData.WithDirectives(DirectiveStack.Empty),
                cloneRoot: false);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static CoreSyntaxTree ParseText(
            string text,
            CoreParseOptions options = null,
            string path = "",
            Encoding encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ParseText(SourceText.From(text, encoding), options, path, cancellationToken);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static CoreSyntaxTree ParseText(
            SourceText text,
            CoreParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            options = options ?? CoreParseOptions.Default;
            using (var parser = new CoreSyntaxParser(text, options, oldTree: null, oldParseData: ParseData.Empty, changes: null, cancellationToken: cancellationToken))
            {
                var compilationUnit = (MainSyntax)parser.Parse();
                var tree = new ParsedSyntaxTree(text, text.Encoding, text.ChecksumAlgorithm, path, options, compilationUnit, parser.ParseData);
                tree.VerifySource();
                return tree;
            }
        }
        #endregion
        #region Completion
        protected override ImmutableArray<SyntaxKind> LookupTokensCore(int position, CancellationToken cancellationToken = default)
        {
            return new Antlr4CompletionSource(this.ParseData, this.GetRoot(cancellationToken), CoreParser._ATN).GetTokenSuggestions(position, cancellationToken);
        }
        public new ImmutableArray<CoreSyntaxKind> LookupTokens(int position, CancellationToken cancellationToken)
        {
            return this.LookupTokensCore(position, cancellationToken).Select(kind => (CoreSyntaxKind)kind).ToImmutableArray();
        }
        #endregion
        #region Changes
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
            if (changes.Count == 1 && changes[0].Span == new TextSpan(0, this.Length) && changes[0].NewLength == newText.Length)
            {
                // parser will do a full parse if we give it no changes
                changes = null;
                oldTree = null;
            }
            using (var parser = new CoreSyntaxParser(newText, this.Options, oldTree?.GetRoot(), oldTree?.ParseData ?? ParseData.Empty, changes))
            {
                var compilationUnit = (MainSyntax)parser.Parse();
                var tree = new ParsedSyntaxTree(newText, newText.Encoding, newText.ChecksumAlgorithm, this.FilePath, this.Options, compilationUnit, parser.ParseData);
                tree.VerifySource(changes);
                return tree;
            }
        }
        #endregion
        #region SyntaxTree
        protected override ParseOptions OptionsCore => this.Options;
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
            CoreSyntaxNode node;
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
        #endregion
        internal sealed class DummySyntaxTree : CoreSyntaxTree
        {
            private readonly CoreSyntaxNode _node;
            public DummySyntaxTree()
            {
                _node = this.CloneNodeAsRoot((MainSyntax)MainGreen.__Missing.CreateRed());
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
            public override CoreParseOptions Options
            {
                get { return CoreParseOptions.Default; }
            }
            public override string FilePath
            {
                get { return string.Empty; }
            }
            public override SyntaxReference GetReference(SyntaxNode node)
            {
                return new SimpleSyntaxReference(node);
            }
            public override CoreSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _node;
            }
            public override bool TryGetRoot(out CoreSyntaxNode root)
            {
                root = _node;
                return true;
            }
            public override bool HasCompilationUnitRoot
            {
                get { return true; }
            }
            protected override ParseData ParseData => ParseData.Empty;
            public override FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
            {
                return default(FileLinePositionSpan);
            }
            public override SyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
            {
                return CoreLanguage.Instance.SyntaxFactory.SyntaxTree((LanguageSyntaxNode)root, options: (CoreParseOptions)options, path: FilePath, encoding: null);
            }
            public override SyntaxTree WithFilePath(string path)
            {
                return CoreLanguage.Instance.SyntaxFactory.SyntaxTree(_node, options: this.Options, path: path, encoding: null);
            }
        }
        private class ParsedSyntaxTree : CoreSyntaxTree
        {
            private readonly CoreParseOptions _options;
            private readonly string _path;
            private readonly CoreSyntaxNode _root;
            private readonly ParseData _parseData;
            private readonly bool _hasCompilationUnitRoot;
            private readonly Encoding? _encodingOpt;
            private readonly SourceHashAlgorithm _checksumAlgorithm;
            private SourceText _lazyText;
            internal ParsedSyntaxTree(SourceText? textOpt, Encoding? encodingOpt, SourceHashAlgorithm checksumAlgorithm, string path, CoreParseOptions options, CoreSyntaxNode root, ParseData parseData, bool cloneRoot = true)
            {
                Debug.Assert(root != null);
                Debug.Assert(options != null);
                Debug.Assert(textOpt == null || textOpt.Encoding == encodingOpt && textOpt.ChecksumAlgorithm == checksumAlgorithm);
                _lazyText = textOpt;
                _encodingOpt = encodingOpt ?? textOpt?.Encoding;
                _checksumAlgorithm = checksumAlgorithm;
                _options = options;
                _path = path ?? string.Empty;
                _root = cloneRoot ? this.CloneNodeAsRoot(root) : root;
                _parseData = parseData;
                _hasCompilationUnitRoot = root.Kind == CoreSyntaxKind.Main;
            }
            protected override ParseData ParseData => _parseData;
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
            public override CoreSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _root;
            }
            public override bool TryGetRoot(out CoreSyntaxNode root)
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
            public override CoreParseOptions Options
            {
                get
                {
                    return _options;
                }
            }
            public override SyntaxReference GetReference(SyntaxNode node)
            {
                return new SimpleSyntaxReference(node);
            }
            public override SyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
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
                    (CoreParseOptions)options,
                    (CoreSyntaxNode)root,
                    this.ParseData);
            }
            public override SyntaxTree WithFilePath(string path)
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
                    this.ParseData);
            }
        }
        private class DebuggerSyntaxTree : ParsedSyntaxTree
        {
            public DebuggerSyntaxTree(CoreSyntaxNode root, ParseData parseData, SourceText text, CoreParseOptions options)
                : base(
                    text,
                    text.Encoding,
                    text.ChecksumAlgorithm,
                    path: "",
                    options: options,
                    root: root,
                    parseData: parseData.WithDirectives(DirectiveStack.Empty))
            {
            }
            protected override bool SupportsLocations
            {
                get { return true; }
            }
        }
    }
}

