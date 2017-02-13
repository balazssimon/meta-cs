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
        private readonly CompilationBase _compilation;
        private readonly SyntaxTree _syntaxTree;

        private readonly BinderFactory _binderFactory;
        private readonly bool _ignoresAccessibility;

        internal SyntaxTreeSemanticModel(CompilationBase compilation, SyntaxTree syntaxTree, bool ignoreAccessibility = false)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;
            _ignoresAccessibility = ignoreAccessibility;

            if (!this.Compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), "tree not part of compilation");
            }

            _binderFactory = compilation.GetBinderFactory(SyntaxTree);
        }

        internal SyntaxTreeSemanticModel(CompilationBase parentCompilation, SyntaxTree parentSyntaxTree, SyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            _syntaxTree = speculatedSyntaxTree;
            _binderFactory = _compilation.GetBinderFactory(parentSyntaxTree);
        }

        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        protected override CompilationBase CompilationCore
        {
            get
            {
                return _compilation;
            }
        }

        protected override SyntaxNode RootCore
        {
            get
            {
                return _syntaxTree.GetRoot();
            }
        }

        protected override SyntaxTree SyntaxTreeCore
        {
            get
            {
                return _syntaxTree;
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

        protected override SymbolInfo GetSymbolInfoWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            Binder binder = this.Compilation.GetBinder(node);
            return null;
            //throw new NotImplementedException();
        }

        protected override TypeInfo GetTypeInfoWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<IMetaSymbol> GetMembersWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Optional<object> GetConstantValueWorker(SyntaxNode node, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override IMetaSymbol GetDeclaredSymbolWorker(SyntaxNode declaration, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var container = GetDeclaredContainer(declaration);
            return GetDeclaredMember(container, declaration.Span, null);
        }

        private IMetaSymbol GetDeclaredContainer(SyntaxNode declaration)
        {
            if (declaration.Parent == null)
            {
                return this.Compilation.GlobalNamespace;
            }
            var container = GetDeclaredSymbolForNode(declaration.Parent);
            Debug.Assert((object)container != null);
            return container;
        }

        protected override ImmutableArray<IMetaSymbol> GetDeclaredSymbolsWorker(SyntaxNode declaration, BindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the member in the containing symbol which is inside the given declaration span.
        /// </summary>
        private IMetaSymbol GetDeclaredMember(IMetaSymbol container, TextSpan declarationSpan, string name = null)
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
        protected override Binder GetEnclosingBinderCore(int position)
        {
            AssertPositionAdjusted(position);
            SyntaxToken token = this.Root.FindToken(position);

            // If we're before the start of the first token, just return
            // the binder for the compilation unit.
            if (position == 0 && position != token.SpanStart)
            {
                return _binderFactory.GetBinder(this.Root, position); // SB-TODO: .WithAdditionalFlags(GetSemanticModelBinderFlags());
            }

            return _binderFactory.GetBinder(token.Parent, position); // SB-TODO: .WithAdditionalFlags(GetSemanticModelBinderFlags());
        }

    }
}
