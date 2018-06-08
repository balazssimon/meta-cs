using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Binding.SymbolBinding;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    internal class SyntaxTreeSemanticModel : SemanticModelBase
    {
        private readonly BoundTree _boundTree;
        private readonly bool _ignoresAccessibility;

        internal SyntaxTreeSemanticModel(CompilationBase compilation, SyntaxTree syntaxTree, bool ignoreAccessibility = false)
        {
            _ignoresAccessibility = ignoreAccessibility;

            if (!this.Compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), "tree not part of compilation");
            }

            _boundTree = new BoundTree(compilation, syntaxTree);
        }

        internal SyntaxTreeSemanticModel(CompilationBase parentCompilation, SyntaxTree parentSyntaxTree, SyntaxTree speculatedSyntaxTree)
        {
            _boundTree = new BoundTree(parentCompilation, parentSyntaxTree, speculatedSyntaxTree);
        }

        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        protected override CompilationBase CompilationCore
        {
            get
            {
                return _boundTree.Compilation;
            }
        }

        protected override SyntaxNode RootCore
        {
            get
            {
                return this.SyntaxTree.GetRoot();
            }
        }

        protected override SyntaxTree SyntaxTreeCore
        {
            get
            {
                return _boundTree.SyntaxTree;
            }
        }

        protected BoundTree BoundTree
        {
            get
            {
                return _boundTree;
            }
        }

        protected BinderFactory BinderFactory
        {
            get
            {
                return _boundTree.BinderFactory;
            }
        }

        /// <summary>
        /// Returns true if this is a SemanticModel that ignores accessibility rules when answering semantic questions.
        /// </summary>
        public override bool IgnoresAccessibility
        {
            get { return _ignoresAccessibility; }
        }

        public override bool IsSpeculativeSemanticModel
        {
            get { return false; }
        }

        public override int OriginalPositionForSpeculation
        {
            get { return 0; }
        }

        protected override SemanticModel ParentModelCore
        {
            get { return null; }
        }

        protected override SymbolInfo GetSymbolInfoWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var boundNode = this.Compilation.Bind(node) as ISymbolBoundNode;
            var symbol = boundNode.Symbol;
            return symbol != null ? GetSymbolInfoForSymbol(symbol, options) : SymbolInfo.None;
        }

        protected override TypeInfo GetTypeInfoWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var boundNode = this.Compilation.Bind(node) as ISymbolBoundNode;
            var symbol = boundNode.Symbol;
            return (object)symbol != null ? GetTypeInfoForSymbol(symbol, options) : TypeInfo.None;
        }

        protected override ImmutableArray<ISymbol> GetMembersWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Optional<object> GetConstantValueWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override ISymbol GetDeclaredSymbolWorker(SyntaxNode declaration, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var container = GetDeclaredContainer(declaration);
            return GetDeclaredMember(container, declaration.Span, null);
        }

        private ISymbol GetDeclaredContainer(SyntaxNode declaration)
        {
            if (declaration.Parent == null)
            {
                return this.Compilation.GlobalNamespace;
            }
            var container = GetDeclaredSymbolForNode(declaration.Parent);
            Debug.Assert((object)container != null);
            return container;
        }

        protected override ImmutableArray<ISymbol> GetDeclaredSymbolsWorker(SyntaxNode declaration, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the member in the containing symbol which is inside the given declaration span.
        /// </summary>
        private ISymbol GetDeclaredMember(ISymbol container, TextSpan declarationSpan, string name = null)
        {
            return null;
            /*
            if ((object)container == null)
            {
                return null;
            }

            // look for any member with same declaration location
            var collection = name != null ? container.GetMembers(name) : container.GetMembersUnordered();

            IMetaSymbol zeroWidthMatch = null;
            foreach (var symbol in collection)
            {
                foreach (var loc in symbol.Locations)
                {
                    if (loc.IsInSource && loc.SourceTree == this.SyntaxTree && declarationSpan.Contains(loc.SourceSpan))
                    {
                        if (loc.SourceSpan.IsEmpty && loc.SourceSpan.End == declarationSpan.Start)
                        {
                            // exclude decls created via syntax recovery
                            zeroWidthMatch = symbol;
                        }
                        else
                        {
                            return symbol;
                        }
                    }
                }
            }

            // If we didn't find anything better than the symbol that matched because of syntax error recovery, then return that.
            // Otherwise, if there's a name, try again without a name.
            // Otherwise, give up.
            return zeroWidthMatch ??
                (name != null ? GetDeclaredMember(container, declarationSpan) : null);*/
        }

        protected override Binder GetSpeculativeBinder(int position, SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the enclosing binder associated with the node
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected override ISymbolBinder GetEnclosingBinderCore(int position)
        {
            AssertPositionAdjusted(position);
            SyntaxToken token = this.Root.FindToken(position);

            // If we're before the start of the first token, just return
            // the binder for the compilation unit.
            if (position == 0 && position != token.SpanStart)
            {
                return this.Compilation.GetDefaultBinder<ISymbolBinder>(); // SB-TODO: .WithAdditionalFlags(GetSemanticModelBinderFlags());
            }

            return this.BinderFactory.GetBinder<ISymbolBinder>(token); // SB-TODO: .WithAdditionalFlags(GetSemanticModelBinderFlags());
        }

    }
}
