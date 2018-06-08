using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Binding.SymbolBinding;
using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    internal class SpeculativeSyntaxTreeSemanticModel : SyntaxTreeSemanticModel
    {
        private readonly SemanticModel _parentSemanticModel;
        private readonly SyntaxNode _root;
        private readonly Binder _rootBinder;
        private readonly int _position;
        private readonly SymbolBindingOptions _bindingOption;

        private static SpeculativeSyntaxTreeSemanticModel CreateCore(SemanticModel parentSemanticModel, SyntaxNode root, Binder rootBinder, int position, SymbolBindingOptions bindingOption)
        {
            Debug.Assert(parentSemanticModel is SyntaxTreeSemanticModel);
            Debug.Assert(root != null);
            Debug.Assert(rootBinder != null);
            Debug.Assert(rootBinder.IsSemanticModelBinder);

            var speculativeModel = new SpeculativeSyntaxTreeSemanticModel(parentSemanticModel, root, rootBinder, position, bindingOption);
            return speculativeModel;
        }

        private SpeculativeSyntaxTreeSemanticModel(SemanticModel parentSemanticModel, SyntaxNode root, Binder rootBinder, int position, SymbolBindingOptions bindingOption)
            : base(parentSemanticModel.Compilation, parentSemanticModel.SyntaxTree, root.SyntaxTree)
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

        protected override SemanticModel ParentModelCore
        {
            get
            {
                return _parentSemanticModel;
            }
        }

        protected override SyntaxNode RootCore
        {
            get
            {
                return _root;
            }
        }

        protected override ISymbolBinder GetEnclosingBinderCore(int position)
        {
            return _rootBinder.GetBinder<ISymbolBinder>();
        }

        protected override SymbolInfo GetSymbolInfoWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _parentSemanticModel.GetSpeculativeSymbolInfo(_position, node);
        }

        protected override TypeInfo GetTypeInfoWorker(SyntaxNode node, SymbolBindingOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _parentSemanticModel.GetSpeculativeTypeInfo(_position, node);
        }
    }

}
