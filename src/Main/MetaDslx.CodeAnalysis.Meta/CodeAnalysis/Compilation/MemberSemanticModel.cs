// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Operations;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Binding info for expressions and statements that are part of a member declaration.
    /// </summary>
    internal abstract partial class MemberSemanticModel : LanguageSemanticModel
    {
        private readonly Symbol _memberSymbol;
        private readonly BoundTree _boundTree;
        private readonly DiagnosticBag _ignoredDiagnostics = new DiagnosticBag();

        internal readonly Binder RootBinder;

        /// <summary>
        /// Field specific to a non-speculative MemberSemanticModel that must have a containing semantic model.
        /// </summary>
        private readonly SyntaxTreeSemanticModel _containingSemanticModelOpt;

        // Fields specific to a speculative MemberSemanticModel.
        private readonly SyntaxTreeSemanticModel _parentSemanticModelOpt;
        private readonly int _speculatedPosition;

        private readonly Lazy<LanguageOperationFactory> _operationFactory;

        protected MemberSemanticModel(
            LanguageSyntaxNode root,
            Symbol memberSymbol,
            Binder rootBinder,
            SyntaxTreeSemanticModel containingSemanticModelOpt,
            SyntaxTreeSemanticModel parentSemanticModelOpt,
            int speculatedPosition)
        {
            Debug.Assert(root != null);
            Debug.Assert((object)memberSymbol != null);
            Debug.Assert(parentSemanticModelOpt == null ^ containingSemanticModelOpt == null);
            Debug.Assert(containingSemanticModelOpt == null || !containingSemanticModelOpt.IsSpeculativeSemanticModel);
            Debug.Assert(parentSemanticModelOpt == null || !parentSemanticModelOpt.IsSpeculativeSemanticModel, CSharpResources.ChainingSpeculativeModelIsNotSupported);

            _memberSymbol = memberSymbol;

            this.RootBinder = rootBinder.WithAdditionalFlags(GetSemanticModelBinderFlags());
            _containingSemanticModelOpt = containingSemanticModelOpt;
            _parentSemanticModelOpt = parentSemanticModelOpt;
            _speculatedPosition = speculatedPosition;

            _boundTree = new BoundTree(this.Compilation, root, rootBinder);

            _operationFactory = new Lazy<LanguageOperationFactory>(() => new LanguageOperationFactory(this));
        }

        public override LanguageCompilation Compilation
        {
            get
            {
                return (_containingSemanticModelOpt ?? _parentSemanticModelOpt).Compilation;
            }
        }

        public override SyntaxNodeOrToken Root
        {
            get
            {
                return (LanguageSyntaxNode)_boundTree.RootSyntax;
            }
        }

        public override BoundTree BoundTree => _boundTree;

        /// <summary>
        /// The member symbol 
        /// </summary>
        public Symbol MemberSymbol
        {
            get
            {
                return _memberSymbol;
            }
        }

        public sealed override bool IsSpeculativeSemanticModel
        {
            get
            {
                return _parentSemanticModelOpt != null;
            }
        }

        public sealed override int OriginalPositionForSpeculation
        {
            get
            {
                return _speculatedPosition;
            }
        }

        public sealed override LanguageSemanticModel ParentModel
        {
            get
            {
                return _parentSemanticModelOpt;
            }
        }

        internal sealed override SemanticModel ContainingModelOrSelf
        {
            get
            {
                return _containingSemanticModelOpt ?? (SemanticModel)this;
            }
        }

        internal override MemberSemanticModel GetMemberModel(SyntaxNode node)
        {
            // We do have to override this method, but should never call it because it might not do the right thing. 
            Debug.Assert(false);
            return IsInTree(node) ? this : null;
        }

        internal sealed override bool TryGetSpeculativeSemanticModelCore(SyntaxTreeSemanticModel parentModel, int position, LanguageSyntaxNode type, SpeculativeBindingOption bindingOption, out SemanticModel speculativeModel)
        {
            var expression = SyntaxFactory.GetStandaloneNode(type);

            var binder = this.GetSpeculativeBinder(position, expression, bindingOption);
            if (binder != null)
            {
                speculativeModel = new SpeculativeMemberSemanticModel(parentModel, _memberSymbol, type, binder, position);
                return true;
            }

            speculativeModel = null;
            return false;
        }

        /// <summary>
        /// Get the bound node corresponding to the root.
        /// </summary> 
        internal virtual BoundNode GetBoundRoot()
        {
            return _boundTree.GetBoundRoot();
        }

        /// <summary>
        /// Get the highest bound node in the tree associated with a particular syntax node.
        /// </summary>
        internal BoundNode GetUpperBoundNode(LanguageSyntaxNode node, bool promoteToBindable = false)
        {
            var boundNodes = _boundTree.GetBoundNodes(node);
            return boundNodes[0];
        }

        /// <summary>
        /// Get the lowest bound node in the tree associated with a particular syntax node. Lowest is defined as last
        /// in a pre-order traversal of the bound tree.
        /// </summary>
        internal BoundNode GetLowerBoundNode(LanguageSyntaxNode node)
        {
            var boundNodes = _boundTree.GetBoundNodes(node);
            return boundNodes[boundNodes.Length-1];
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetSymbolDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override DeclaredSymbol GetDeclaredSymbol(SyntaxNodeOrToken declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't define namespace inside a member.
            return null;
        }

        public override ImmutableArray<DeclaredSymbol> GetDeclaredSymbols(SyntaxNodeOrToken declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't define field inside member.
            return ImmutableArray.Create<DeclaredSymbol>();
        }

        public override TypeInfo GetTypeInfo(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override SymbolInfo GetSymbolInfo(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _boundTree.SyntaxTree;
            }
        }

    }
}
