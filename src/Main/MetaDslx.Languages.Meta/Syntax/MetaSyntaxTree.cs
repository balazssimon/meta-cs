// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
namespace MetaDslx.Languages.Meta
{
    /// <summary>
    /// The parsed representation of a C# source document.
    /// </summary>
    public abstract partial class MetaSyntaxTree : LanguageSyntaxTree
    {
        internal static readonly MetaSyntaxTree Dummy = new DummySyntaxTree();
        /// <summary>
        /// The options used by the parser to produce the syntax tree.
        /// </summary>
        public new abstract MetaParseOptions Options { get; }
        // REVIEW: I would prefer to not expose CloneAsRoot and make the functionality
        // internal to CaaS layer, to ensure that for a given SyntaxTree there can not
        // be multiple trees claiming to be its children.
        // 
        // However, as long as we provide GetRoot extensibility point on SyntaxTree
        // the guarantee above cannot be implemented and we have to provide some way for
        // creating root nodes.
        //
        // Therefore I place CloneAsRoot API on SyntaxTree and make it protected to
        // at least limit its visibility to SyntaxTree extenders.
        /// <summary>
        /// Produces a clone of a <see cref="MetaSyntaxNode"/> which will have current syntax tree as its parent.
        /// 
        /// Caller must guarantee that if the same instance of <see cref="MetaSyntaxNode"/> makes multiple calls
        /// to this function, only one result is observable.
        /// </summary>
        /// <typeparam name="T">Type of the syntax node.</typeparam>
        /// <param name="node">The original syntax node.</param>
        /// <returns>A clone of the original syntax node that has current <see cref="CSharpSyntaxTree"/> as its parent.</returns>
        protected T CloneNodeAsRoot<T>(T node) where T : MetaSyntaxNode
        {
            return MetaSyntaxNode.CloneNodeAsRoot(node, this);
        }
        /// <summary>
        /// Gets the root node of the syntax tree.
        /// </summary>
        public new abstract MetaSyntaxNode GetRoot(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Gets the root node of the syntax tree if it is already available.
        /// </summary>
        public abstract bool TryGetRoot(out MetaSyntaxNode root);
        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        /// <remarks>
        /// By default, the work associated with this method will be executed immediately on the current thread.
        /// Implementations that wish to schedule this work differently should override <see cref="GetRootAsync(CancellationToken)"/>.
        /// </remarks>
        public new virtual Task<MetaSyntaxNode> GetRootAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            MetaSyntaxNode node;
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
        public static MetaSyntaxTree Create(MetaSyntaxNode root, MetaParseOptions options = null, string path = "", SourceText text = null, Encoding encoding = null, SourceHashAlgorithm checksumAlgorithm = SourceHashAlgorithm.Sha1)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            var directives = root.Kind == MetaSyntaxKind.Main && root is ICompilationUnitRootSyntax compilationUnitRoot ?
                compilationUnitRoot.GetConditionalDirectivesStack() :
                DirectiveStack.Empty;
            return new ParsedSyntaxTree(
                textOpt: text,
                encodingOpt: encoding,
                checksumAlgorithm: checksumAlgorithm,
                path: path,
                options: options ?? MetaParseOptions.Default,
                root: root,
                directives: directives);
        }
        /// <summary>
        /// Creates a new syntax tree from a syntax node with text that should correspond to the syntax node.
        /// </summary>
        /// <remarks>This is used by the ExpressionEvaluator.</remarks>
        internal static MetaSyntaxTree CreateForDebugger(MetaSyntaxNode root, SourceText text, MetaParseOptions options)
        {
            Debug.Assert(root != null);
            return new DebuggerSyntaxTree(root, text, options);
        }
        /// <summary>
        /// <para>
        /// Internal helper for <see cref="MetaSyntaxNode"/> class to create a new syntax tree rooted at the given root node.
        /// This method does not create a clone of the given root, but instead preserves it's reference identity.
        /// </para>
        /// <para>NOTE: This method is only intended to be used from <see cref="MetaSyntaxNode.SyntaxTree"/> property.</para>
        /// <para>NOTE: Do not use this method elsewhere, instead use <see cref="Create(MetaSyntaxNode, CSharpParseOptions, string, Encoding)"/> method for creating a syntax tree.</para>
        /// </summary>
        internal static MetaSyntaxTree CreateWithoutClone(MetaSyntaxNode root)
        {
            Debug.Assert(root != null);
            return new ParsedSyntaxTree(
                textOpt: null,
                encodingOpt: null,
                checksumAlgorithm: SourceHashAlgorithm.Sha1,
                path: "",
                options: MetaParseOptions.Default,
                root: root,
                directives: DirectiveStack.Empty,
                cloneRoot: false);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static MetaSyntaxTree ParseText(
            string text,
            MetaParseOptions options = null,
            string path = "",
            Encoding encoding = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ParseText(SourceText.From(text, encoding), options, path, cancellationToken);
        }
        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public static MetaSyntaxTree ParseText(
            SourceText text,
            MetaParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            options = options ?? MetaParseOptions.Default;
            using (var parser = new MetaSyntaxParser(text, options, oldTree: null, changes: null, cancellationToken: cancellationToken))
            {
                return Create(parser, path, cancellationToken);
            }
        }
        /// <summary>
        /// Produces a syntax tree by calling a parser.
        /// </summary>
        public static MetaSyntaxTree Create(
            MetaSyntaxParser parser,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }
            var root = (MainSyntax)parser.ParseMain().CreateRed();
            var tree = MetaSyntaxTree.Create(root, (MetaParseOptions)parser.Options, path, parser.SourceText, parser.SourceText.Encoding, parser.SourceText.ChecksumAlgorithm);
            tree.VerifySource();
            return tree;
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
            using (var parser = new MetaSyntaxParser(newText, this.Options, oldTree?.GetRoot(), changes))
            {
                var compilationUnit = (MainSyntax)parser.ParseMain().CreateRed();
                var tree = new ParsedSyntaxTree(newText, newText.Encoding, newText.ChecksumAlgorithm, this.FilePath, this.Options, compilationUnit, parser.Directives);
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
            MetaSyntaxNode node;
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
        internal sealed class DummySyntaxTree : MetaSyntaxTree
        {
            private readonly MetaSyntaxNode _node;
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
            public override MetaParseOptions Options
            {
                get { return MetaParseOptions.Default; }
            }
            public override string FilePath
            {
                get { return string.Empty; }
            }
            public override SyntaxReference GetReference(SyntaxNode node)
            {
                return new SimpleSyntaxReference(node);
            }
            public override MetaSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _node;
            }
            public override bool TryGetRoot(out MetaSyntaxNode root)
            {
                root = _node;
                return true;
            }
            public override bool HasCompilationUnitRoot
            {
                get { return true; }
            }
            public override FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
            {
                return default(FileLinePositionSpan);
            }
            public override SyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
            {
                return MetaLanguage.Instance.SyntaxFactory.SyntaxTree((LanguageSyntaxNode)root, options: (MetaParseOptions)options, path: FilePath, encoding: null);
            }
            public override SyntaxTree WithFilePath(string path)
            {
                return MetaLanguage.Instance.SyntaxFactory.SyntaxTree(_node, options: this.Options, path: path, encoding: null);
            }
        }
        private class ParsedSyntaxTree : MetaSyntaxTree
        {
            private readonly MetaParseOptions _options;
            private readonly string _path;
            private readonly MetaSyntaxNode _root;
            private readonly bool _hasCompilationUnitRoot;
            private readonly Encoding _encodingOpt;
            private readonly SourceHashAlgorithm _checksumAlgorithm;
            private SourceText _lazyText;
            internal ParsedSyntaxTree(SourceText textOpt, Encoding encodingOpt, SourceHashAlgorithm checksumAlgorithm, string path, MetaParseOptions options, MetaSyntaxNode root, DirectiveStack directives, bool cloneRoot = true)
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
                _hasCompilationUnitRoot = root.Kind == MetaSyntaxKind.Main;
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
            public override MetaSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _root;
            }
            public override bool TryGetRoot(out MetaSyntaxNode root)
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
            public override MetaParseOptions Options
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
                    (MetaParseOptions)options,
                    (MetaSyntaxNode)root,
                    this.GetDirectives());
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
                    this.GetDirectives());
            }
        }
        private class DebuggerSyntaxTree : ParsedSyntaxTree
        {
            public DebuggerSyntaxTree(MetaSyntaxNode root, SourceText text, MetaParseOptions options)
                : base(
                    text,
                    text.Encoding,
                    text.ChecksumAlgorithm,
                    path: "",
                    options: options,
                    root: root,
                    directives: DirectiveStack.Empty)
            {
            }
            public override bool SupportsLocations
            {
                get { return true; }
            }
        }
    }
}

