// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes that did not appear in the original source code.
    /// Typically, an instance is obtained by a call to SemanticModel.TryGetSpeculativeSemanticModel. 
    /// </summary>
    internal class SpeculativeSyntaxTreeSemanticModel : SyntaxTreeSemanticModel
    {
        private readonly SyntaxTreeSemanticModel _parentSemanticModel;
        private readonly LanguageSyntaxNode _root;
        private readonly Binder _rootBinder;
        private readonly int _position;
        private readonly SpeculativeBindingOption _bindingOption;

        public static SpeculativeSyntaxTreeSemanticModel Create(SyntaxTreeSemanticModel parentSemanticModel, LanguageSyntaxNode root, Binder rootBinder, int position, SpeculativeBindingOption bindingOption)
        {
            return CreateCore(parentSemanticModel, root, rootBinder, position, bindingOption);
        }

        private static SpeculativeSyntaxTreeSemanticModel CreateCore(SyntaxTreeSemanticModel parentSemanticModel, LanguageSyntaxNode root, Binder rootBinder, int position, SpeculativeBindingOption bindingOption)
        {
            Debug.Assert(parentSemanticModel is SyntaxTreeSemanticModel);
            Debug.Assert(root != null);
            Debug.Assert(rootBinder != null);
            Debug.Assert(rootBinder.IsSemanticModelBinder);

            var speculativeModel = new SpeculativeSyntaxTreeSemanticModel(parentSemanticModel, root, rootBinder, position, bindingOption);
            return speculativeModel;
        }

        private SpeculativeSyntaxTreeSemanticModel(SyntaxTreeSemanticModel parentSemanticModel, LanguageSyntaxNode root, Binder rootBinder, int position, SpeculativeBindingOption bindingOption)
            : base(parentSemanticModel.Compilation, (LanguageSyntaxTree)parentSemanticModel.SyntaxTree, (LanguageSyntaxTree)root.SyntaxTree)
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

        public override LanguageSemanticModel ParentModel
        {
            get
            {
                return _parentSemanticModel;
            }
        }

        public override LanguageSyntaxNode Root
        {
            get
            {
                return _root;
            }
        }

        internal override BoundNode Bind(Binder binder, LanguageSyntaxNode node, DiagnosticBag diagnostics)
        {
            return _parentSemanticModel.Bind(binder, node, diagnostics);
        }

        internal override Binder GetEnclosingBinderInternal(int position)
        {
            return _rootBinder;
        }

        protected virtual SpeculativeBindingOption GetSpeculativeBindingOption(LanguageSyntaxNode node)
        {
            if (SyntaxFacts.IsInNamespaceOrTypeContext(node))
            {
                return SpeculativeBindingOption.BindAsTypeOrNamespace;
            }

            return _bindingOption;
        }

        internal override SymbolInfo GetSymbolInfoWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if ((options & SymbolInfoOptions.PreserveAliases) != 0)
            {
                var aliasSymbol = (AliasSymbol)_parentSemanticModel.GetSpeculativeAliasInfo(_position, node, this.GetSpeculativeBindingOption(node));
                return new SymbolInfo(aliasSymbol, ImmutableArray<ISymbol>.Empty, CandidateReason.None);
            }

            return _parentSemanticModel.GetSpeculativeSymbolInfo(_position, node, this.GetSpeculativeBindingOption(node));
        }

        internal override LanguageTypeInfo GetTypeInfoWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _parentSemanticModel.GetSpeculativeTypeInfoWorker(_position, node, this.GetSpeculativeBindingOption(node));
        }
    }
}
