using MetaDslx.Compiler;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Languages.Soal.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Languages.Soal
{
    public abstract class SoalSemanticModel : SemanticModelBase
    {
        public override Language Language
        {
            get { return SoalLanguage.Instance; }
        }
    }

    internal class SoalSyntaxTreeSemanticModel : SoalSemanticModel
    {
        private readonly SoalCompilation _compilation;
        private readonly SoalSyntaxTree _syntaxTree;

        private readonly BinderFactory _binderFactory;
        private readonly bool _ignoresAccessibility;

        internal SoalSyntaxTreeSemanticModel(SoalCompilation compilation, SoalSyntaxTree syntaxTree, bool ignoreAccessibility = false)
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

        internal SoalSyntaxTreeSemanticModel(SoalCompilation parentCompilation, SoalSyntaxTree parentSyntaxTree, SoalSyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            _syntaxTree = speculatedSyntaxTree;
            _binderFactory = _compilation.GetBinderFactory(parentSyntaxTree);
        }

        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        public new SoalCompilation Compilation
        {
            get
            {
                return _compilation;
            }
        }

        protected override CompilationBase CompilationCore
        {
            get
            {
                return this.Compilation;
            }
        }

        /// <summary>
        /// The root node of the syntax tree that this object is associated with.
        /// </summary>
        public new SoalSyntaxNode Root
        {
            get
            {
                return (SoalSyntaxNode)_syntaxTree.GetRoot();
            }
        }

        protected override SyntaxNode RootCore
        {
            get
            {
                return this.Root;
            }
        }

        /// <summary>
        /// The SyntaxTree that this object is associated with.
        /// </summary>
        public new SoalSyntaxTree SyntaxTree
        {
            get
            {
                return _syntaxTree;
            }
        }

        protected override SyntaxTree SyntaxTreeCore
        {
            get
            {
                return this.SyntaxTree;
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

        protected override SymbolInfo GetSymbolInfoWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override TypeInfo GetTypeInfoWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<IMetaSymbol> GetMembersWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override Optional<object> GetConstantValueWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override IMetaSymbol GetDeclaredSymbolWorker(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<IMetaSymbol> GetDeclaredSymbolsWorker(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
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

            return _binderFactory.GetBinder((SoalSyntaxNode)token.Parent, position); // SB-TODO: .WithAdditionalFlags(GetSemanticModelBinderFlags());
        }
    }

    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes that did not appear in the original source code.
    /// Typically, an instance is obtained by a call to SemanticModel.TryGetSpeculativeSemanticModel. 
    /// </summary>
    internal class SoalSpeculativeSyntaxTreeSemanticModel : SoalSyntaxTreeSemanticModel
    {
        private readonly SoalSemanticModel _parentSemanticModel;
        private readonly SoalSyntaxNode _root;
        private readonly Binder _rootBinder;
        private readonly int _position;
        private readonly SpeculativeBindingOption _bindingOption;

        private static SoalSpeculativeSyntaxTreeSemanticModel CreateCore(SoalSemanticModel parentSemanticModel, SoalSyntaxNode root, Binder rootBinder, int position, SpeculativeBindingOption bindingOption)
        {
            Debug.Assert(parentSemanticModel is SoalSyntaxTreeSemanticModel);
            Debug.Assert(root != null);
            Debug.Assert(rootBinder != null);
            Debug.Assert(rootBinder.IsSemanticModelBinder);

            var speculativeModel = new SoalSpeculativeSyntaxTreeSemanticModel(parentSemanticModel, root, rootBinder, position, bindingOption);
            return speculativeModel;
        }

        private SoalSpeculativeSyntaxTreeSemanticModel(SoalSemanticModel parentSemanticModel, SoalSyntaxNode root, Binder rootBinder, int position, SpeculativeBindingOption bindingOption)
            : base((SoalCompilation)parentSemanticModel.Compilation, (SoalSyntaxTree)parentSemanticModel.SyntaxTree, (SoalSyntaxTree)root.SyntaxTree)
        {
            _parentSemanticModel = parentSemanticModel;
            _root = root;
            _rootBinder = rootBinder;
            _position = position;
            _bindingOption = bindingOption;
        }

        public override bool IsSpeculativeSemanticModel
        {
            get
            {
                return true;
            }
        }

        public override int OriginalPositionForSpeculation
        {
            get
            {
                return _position;
            }
        }

        public new SoalSemanticModel ParentModel
        {
            get
            {
                return (SoalSemanticModel)base.ParentModel;
            }
        }

        protected override SemanticModel ParentModelCore
        {
            get
            {
                return _parentSemanticModel;
            }
        }

        public new SoalSyntaxNode Root
        {
            get { return (SoalSyntaxNode)base.Root; }
        }

        protected override SyntaxNode RootCore
        {
            get
            {
                return _root;
            }
        }

        protected override Binder GetEnclosingBinderCore(int position)
        {
            return _rootBinder;
        }

        protected override SymbolInfo GetSymbolInfoWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _parentSemanticModel.GetSpeculativeSymbolInfo(_position, node);
        }

        protected override TypeInfo GetTypeInfoWorker(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _parentSemanticModel.GetSpeculativeTypeInfo(_position, node);
        }
    }

}
