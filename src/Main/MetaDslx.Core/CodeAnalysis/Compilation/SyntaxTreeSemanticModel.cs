// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.FlowAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.BoundTree;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Allows asking semantic questions about any node in a SyntaxTree within a Compilation.
    /// </summary>
    internal partial class SyntaxTreeSemanticModel : LanguageSemanticModel
    {
        private readonly LanguageCompilation _compilation;
        private readonly SyntaxTree _syntaxTree;

        /// <summary>
        /// Note, the name of this field could be somewhat confusing because it is also 
        /// used to store models for attributes and default parameter values, which are
        /// not members.
        /// </summary>
        private ImmutableDictionary<LanguageSyntaxNode, MemberSemanticModel> _memberModels = ImmutableDictionary<LanguageSyntaxNode, MemberSemanticModel>.Empty;

        private readonly BinderFactory _binderFactory;
        private Func<LanguageSyntaxNode, MemberSemanticModel> _createMemberModelFunction;
        private readonly bool _ignoresAccessibility;

        internal SyntaxTreeSemanticModel(LanguageCompilation compilation, SyntaxTree syntaxTree, bool ignoreAccessibility = false)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;
            _ignoresAccessibility = ignoreAccessibility;

            if (!this.Compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), CSharpResources.TreeNotPartOfCompilation);
            }

            _binderFactory = compilation.GetBinderFactory(SyntaxTree);
        }

        internal SyntaxTreeSemanticModel(LanguageCompilation parentCompilation, SyntaxTree parentSyntaxTree, SyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            _syntaxTree = speculatedSyntaxTree;
            _binderFactory = _compilation.GetBinderFactory(parentSyntaxTree);
        }

        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        public override LanguageCompilation Compilation
        {
            get
            {
                return _compilation;
            }
        }

        /// <summary>
        /// The root node of the syntax tree that this object is associated with.
        /// </summary>
        public override LanguageSyntaxNode Root
        {
            get
            {
                return (LanguageSyntaxNode)_syntaxTree.GetRoot();
            }
        }

        /// <summary>
        /// The SyntaxTree that this object is associated with.
        /// </summary>
        public override SyntaxTree SyntaxTree
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

        private void VerifySpanForGetDiagnostics(TextSpan? span)
        {
            if (span.HasValue && !this.Root.FullSpan.Contains(span.Value))
            {
                throw new ArgumentException("span");
            }
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Parse, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Declare, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public virtual ImmutableArray<Diagnostic> GetSymbolDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: true, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the enclosing binder associated with the node
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal override Binder GetEnclosingBinderInternal(int position)
        {
            AssertPositionAdjusted(position);
            SyntaxToken token = this.Root.FindToken(position);

            // If we're before the start of the first token, just return
            // the binder for the compilation unit.
            if (position == 0 && position != token.SpanStart)
            {
                return _binderFactory.GetBinder(this.Root, position).WithAdditionalFlags(GetSemanticModelBinderFlags());
            }

            MemberSemanticModel memberModel = GetMemberModel(position);
            if (memberModel != null)
            {
                return memberModel.GetEnclosingBinder(position);
            }

            return _binderFactory.GetBinder((LanguageSyntaxNode)token.Parent, position).WithAdditionalFlags(GetSemanticModelBinderFlags());
        }

        internal override IOperation GetOperationWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            MemberSemanticModel model;

            switch (node)
            {
                /* TODO:MetaDslx
                case ConstructorDeclarationSyntax constructor:
                    model = (constructor.HasAnyBody() || constructor.Initializer != null) ? GetOrAddModel(node) : null;
                    break;
                case BaseMethodDeclarationSyntax method:
                    model = method.HasAnyBody() ? GetOrAddModel(node) : null;
                    break;
                case AccessorDeclarationSyntax accessor:
                    model = (accessor.Body != null || accessor.ExpressionBody != null) ? GetOrAddModel(node) : null;
                    break;*/
                default:
                    model = this.GetMemberModel(node);
                    break;
            }

            if (model != null)
            {
                return model.GetOperationWorker(node, cancellationToken);
            }
            else
            {
                return null;
            }
        }

        internal override SymbolInfo GetSymbolInfoWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateSymbolInfoOptions(options);

            // in case this is right side of a qualified name or member access (or part of a cref)
            node = SyntaxFactory.GetStandaloneNode(node);

            var model = this.GetMemberModel(node);
            SymbolInfo result;

            if (model != null)
            {
                // Expression occurs in an executable code (method body or initializer) context. Use that
                // model to get the information.
                result = model.GetSymbolInfoWorker(node, options, cancellationToken);

                // If we didn't get anything and were in Type/Namespace only context, let's bind normally and see
                // if any symbol comes out.
                if ((object)result.Symbol == null && result.CandidateReason == CandidateReason.None && this.Language.SyntaxFacts.IsInNamespaceOrTypeContext(node))
                {
                    var binder = this.GetEnclosingBinder(GetAdjustedNodePosition(node));

                    if (binder != null)
                    {
                        // Wrap the binder in a LocalScopeBinder because Binder.BindExpression assumes there
                        // will be one in the binder chain and one isn't necessarily required for the batch case.
                        binder = new LocalScopeBinder(binder);

                        var diagnostics = DiagnosticBag.GetInstance();
                        BoundExpression bound = binder.BindExpression(node, diagnostics);
                        diagnostics.Free();

                        SymbolInfo info = GetSymbolInfoForNode(options, bound, bound, boundNodeForSyntacticParent: null, binderOpt: null);
                        if ((object)info.Symbol != null)
                        {
                            result = new SymbolInfo(null, ImmutableArray.Create<ISymbol>(info.Symbol), CandidateReason.NotATypeOrNamespace);
                        }
                        else if (!info.CandidateSymbols.IsEmpty)
                        {
                            result = new SymbolInfo(null, info.CandidateSymbols, CandidateReason.NotATypeOrNamespace);
                        }
                    }
                }
            }
            else
            {
                // if expression is not part of a member context then caller may really just have a
                // reference to a type or namespace name
                var symbol = GetSemanticInfoSymbolInNonMemberContext(node, bindVarAsAliasFirst: (options & SymbolInfoOptions.PreserveAliases) != 0);
                result = (object)symbol != null ? GetSymbolInfoForSymbol(symbol, options) : SymbolInfo.None;
            }

            return result;
        }

        internal override LanguageTypeInfo GetTypeInfoWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            // in case this is right side of a qualified name or member access (or part of a cref)
            node = SyntaxFactory.GetStandaloneNode(node);

            var model = this.GetMemberModel(node);

            if (model != null)
            {
                // Expression occurs in an executable code (method body or initializer) context. Use that
                // model to get the information.
                return model.GetTypeInfoWorker(node, cancellationToken);
            }
            else
            {
                // if expression is not part of a member context then caller may really just have a
                // reference to a type or namespace name
                var symbol = GetSemanticInfoSymbolInNonMemberContext(node, bindVarAsAliasFirst: false); // Don't care about aliases here.
                return (object)symbol != null ? GetTypeInfoForSymbol(symbol) : LanguageTypeInfo.None;
            }
        }

        // Common helper method for GetSymbolInfoWorker and GetTypeInfoWorker, which is called when there is no member model for the given syntax node.
        // Even if the  expression is not part of a member context, the caller may really just have a reference to a type or namespace name.
        // If so, the methods binds the syntax as a namespace or type or alias symbol. Otherwise, it returns null.
        protected virtual Symbol GetSemanticInfoSymbolInNonMemberContext(LanguageSyntaxNode node, bool bindVarAsAliasFirst)
        {
            Debug.Assert(this.GetMemberModel(node) == null);

            var binder = this.GetEnclosingBinder(GetAdjustedNodePosition(node));
            if (binder != null)
            {
                // if expression is not part of a member context then caller may really just have a
                // reference to a type or namespace name
                if ((object)node != null)
                {
                    // determine if this type is part of a base declaration being resolved
                    var basesBeingResolved = GetBasesBeingResolved(node);

                    var diagnostics = DiagnosticBag.GetInstance();
                    try
                    {
                        return binder.BindNamespaceOrTypeOrAliasSymbol(node, diagnostics, basesBeingResolved, basesBeingResolved != null, null);
                    }
                    finally
                    {
                        diagnostics.Free();
                    }
                }
            }

            return null;
        }

        internal override ImmutableArray<Symbol> GetMemberGroupWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            // in case this is right side of a qualified name or member access (or part of a cref)
            node = SyntaxFactory.GetStandaloneNode(node);

            var model = this.GetMemberModel(node);
            return model == null ? ImmutableArray<Symbol>.Empty : model.GetMemberGroupWorker(node, options, cancellationToken);
        }

        internal override Optional<object> GetConstantValueWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            // in case this is right side of a qualified name or member access
            node = SyntaxFactory.GetStandaloneNode(node);

            var model = this.GetMemberModel(node);
            return model == null ? default(Optional<object>) : model.GetConstantValueWorker(node, cancellationToken);
        }

        protected virtual ConsList<TypeSymbol> GetBasesBeingResolved(LanguageSyntaxNode expression)
        {
            return null;
        }

        public override Conversion ClassifyConversion(LanguageSyntaxNode expression, ITypeSymbol destination, bool isExplicitInSource = false)
        {
            var csdestination = destination.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(destination));

            if (isExplicitInSource)
            {
                return ClassifyConversionForCast(expression, csdestination);
            }

            CheckSyntaxNode(expression);

            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            // TODO(cyrusn): Check arguments. This is a public entrypoint, so we must do appropriate
            // checks here. However, no other methods in this type do any checking currently. So I'm
            // going to hold off on this until we do a full sweep of the API.

            var model = this.GetMemberModel(expression);
            if (model == null)
            {
                // 'expression' must just be reference to a type or namespace name outside of an
                // expression context.  Currently we bail in that case.  However, is this a question
                // that a client would be asking and would expect sensible results for?
                return Conversion.NoConversion;
            }

            return model.ClassifyConversion(expression, destination);
        }

        internal override Conversion ClassifyConversionForCast(LanguageSyntaxNode expression, TypeSymbol destination)
        {
            CheckSyntaxNode(expression);

            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var model = this.GetMemberModel(expression);
            if (model == null)
            {
                // 'expression' must just be reference to a type or namespace name outside of an
                // expression context.  Currently we bail in that case.  However, is this a question
                // that a client would be asking and would expect sensible results for?
                return Conversion.NoConversion;
            }

            return model.ClassifyConversionForCast(expression, destination);
        }

        public override bool IsSpeculativeSemanticModel
        {
            get { return false; }
        }

        public override int OriginalPositionForSpeculation
        {
            get { return 0; }
        }

        public override LanguageSemanticModel ParentModel
        {
            get { return null; }
        }

        internal override SemanticModel ContainingModelOrSelf
        {
            get { return this; }
        }

        internal sealed override bool TryGetSpeculativeSemanticModelCore(SyntaxTreeSemanticModel parentModel, int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption, out SemanticModel speculativeModel)
        {
            position = CheckAndAdjustPosition(position);

            var model = this.GetMemberModel(position);
            if (model != null)
            {
                return model.TryGetSpeculativeSemanticModelCore(parentModel, position, node, bindingOption, out speculativeModel);
            }

            Binder binder = GetSpeculativeBinder(position, node, bindingOption);
            if (binder != null)
            {
                speculativeModel = SpeculativeSyntaxTreeSemanticModel.Create(parentModel, node, binder, position, bindingOption);
                return true;
            }

            speculativeModel = null;
            return false;
        }

        private MemberSemanticModel GetMemberModel(int position)
        {
            AssertPositionAdjusted(position);
            LanguageSyntaxNode node = (LanguageSyntaxNode)Root.FindToken(position).Parent;
            LanguageSyntaxNode memberDecl = GetMemberDeclaration(node);

            bool outsideMemberDecl = false;
            /* TODO:MetaDslx
            if (memberDecl != null)
            {
                switch (memberDecl.Kind())
                {
                    case SyntaxKind.AddAccessorDeclaration:
                    case SyntaxKind.RemoveAccessorDeclaration:
                    case SyntaxKind.GetAccessorDeclaration:
                    case SyntaxKind.SetAccessorDeclaration:
                        // NOTE: not UnknownAccessorDeclaration since there's no corresponding method symbol from which to build a member model.
                        outsideMemberDecl = !LookupPosition.IsInBody(position, (AccessorDeclarationSyntax)memberDecl);
                        break;
                    case SyntaxKind.ConstructorDeclaration:
                        var constructorDecl = (ConstructorDeclarationSyntax)memberDecl;
                        outsideMemberDecl =
                            !LookupPosition.IsInConstructorParameterScope(position, constructorDecl) &&
                            !LookupPosition.IsInParameterList(position, constructorDecl);
                        break;
                    case SyntaxKind.ConversionOperatorDeclaration:
                    case SyntaxKind.DestructorDeclaration:
                    case SyntaxKind.MethodDeclaration:
                    case SyntaxKind.OperatorDeclaration:
                        var methodDecl = (BaseMethodDeclarationSyntax)memberDecl;
                        outsideMemberDecl =
                            !LookupPosition.IsInBody(position, methodDecl) &&
                            !LookupPosition.IsInParameterList(position, methodDecl);
                        break;
                }
            }*/

            return outsideMemberDecl ? null : GetMemberModel(node);
        }

        // Try to get a member semantic model that encloses "node". If there is not an enclosing
        // member semantic model, return null.
        internal override MemberSemanticModel GetMemberModel(SyntaxNode node)
        {
            var memberDecl = GetMemberDeclaration(node);
            /* TODO:MetaDslx
            if (memberDecl != null)
            {
                var span = node.Span;

                switch (memberDecl.Kind())
                {
                    case SyntaxKind.MethodDeclaration:
                    case SyntaxKind.ConversionOperatorDeclaration:
                    case SyntaxKind.OperatorDeclaration:
                        {
                            var methodDecl = (BaseMethodDeclarationSyntax)memberDecl;
                            var expressionBody = methodDecl.GetExpressionBodySyntax();
                            return (expressionBody?.FullSpan.Contains(span) == true || methodDecl.Body?.FullSpan.Contains(span) == true) ?
                                   GetOrAddModel(methodDecl) : null;
                        }

                    case SyntaxKind.ConstructorDeclaration:
                        {
                            ConstructorDeclarationSyntax constructorDecl = (ConstructorDeclarationSyntax)memberDecl;
                            var expressionBody = constructorDecl.GetExpressionBodySyntax();
                            return (constructorDecl.Initializer?.FullSpan.Contains(span) == true ||
                                    expressionBody?.FullSpan.Contains(span) == true ||
                                    constructorDecl.Body?.FullSpan.Contains(span) == true) ?
                                   GetOrAddModel(constructorDecl) : null;
                        }

                    case SyntaxKind.DestructorDeclaration:
                        {
                            DestructorDeclarationSyntax destructorDecl = (DestructorDeclarationSyntax)memberDecl;
                            var expressionBody = destructorDecl.GetExpressionBodySyntax();
                            return (expressionBody?.FullSpan.Contains(span) == true || destructorDecl.Body?.FullSpan.Contains(span) == true) ?
                                   GetOrAddModel(destructorDecl) : null;
                        }

                    case SyntaxKind.GetAccessorDeclaration:
                    case SyntaxKind.SetAccessorDeclaration:
                    case SyntaxKind.AddAccessorDeclaration:
                    case SyntaxKind.RemoveAccessorDeclaration:
                        // NOTE: not UnknownAccessorDeclaration since there's no corresponding method symbol from which to build a member model.
                        {
                            var accessorDecl = (AccessorDeclarationSyntax)memberDecl;
                            return (accessorDecl.ExpressionBody?.FullSpan.Contains(span) == true || accessorDecl.Body?.FullSpan.Contains(span) == true) ?
                                   GetOrAddModel(accessorDecl) : null;
                        }

                    case SyntaxKind.IndexerDeclaration:
                        {
                            var indexerDecl = (IndexerDeclarationSyntax)memberDecl;
                            return GetOrAddModelIfContains(indexerDecl.ExpressionBody, span);
                        }

                    case SyntaxKind.FieldDeclaration:
                    case SyntaxKind.EventFieldDeclaration:
                        {
                            var fieldDecl = (BaseFieldDeclarationSyntax)memberDecl;
                            foreach (var variableDecl in fieldDecl.Declaration.Variables)
                            {
                                var binding = GetOrAddModelIfContains(variableDecl.Initializer, span);
                                if (binding != null)
                                {
                                    return binding;
                                }
                            }
                        }
                        break;

                    case SyntaxKind.EnumMemberDeclaration:
                        {
                            var enumDecl = (EnumMemberDeclarationSyntax)memberDecl;
                            return (enumDecl.EqualsValue != null) ?
                                GetOrAddModelIfContains(enumDecl.EqualsValue, span) :
                                null;
                        }

                    case SyntaxKind.PropertyDeclaration:
                        {
                            var propertyDecl = (PropertyDeclarationSyntax)memberDecl;
                            return GetOrAddModelIfContains(propertyDecl.Initializer, span) ??
                                GetOrAddModelIfContains(propertyDecl.ExpressionBody, span);
                        }

                    case SyntaxKind.GlobalStatement:
                        return GetOrAddModel(memberDecl);

                    case SyntaxKind.Attribute:
                        return GetOrAddModelForAttribute((AttributeSyntax)memberDecl);

                    case SyntaxKind.Parameter:
                        return GetOrAddModelForParameter((ParameterSyntax)memberDecl, span);
                }
            }*/

            return null;
        }

        /// <summary>
        /// Internal for test purposes only
        /// </summary>
        internal ImmutableDictionary<LanguageSyntaxNode, MemberSemanticModel> TestOnlyMemberModels => _memberModels;

        protected LanguageSyntaxNode GetMemberDeclaration(SyntaxNode node)
        {
            return node.FirstAncestorOrSelf<LanguageSyntaxNode>(IsMemberDeclaration);
        }

        private MemberSemanticModel GetOrAddModelIfContains(LanguageSyntaxNode node, TextSpan span)
        {
            if (node != null && node.FullSpan.Contains(span))
            {
                return GetOrAddModel(node);
            }
            return null;
        }

        private MemberSemanticModel GetOrAddModel(LanguageSyntaxNode node)
        {
            var createMemberModelFunction = _createMemberModelFunction ??
                                            (_createMemberModelFunction = this.CreateMemberModel);

            return GetOrAddModel(node, createMemberModelFunction);
        }

        internal MemberSemanticModel GetOrAddModel(LanguageSyntaxNode node, Func<LanguageSyntaxNode, MemberSemanticModel> createMemberModelFunction)
        {
            return ImmutableInterlocked.GetOrAdd(ref _memberModels, node, createMemberModelFunction);
        }

        // Create a member model for the given declaration syntax. In certain very malformed
        // syntax trees, there may not be a symbol that can have a member model associated with it
        // (although we try to minimize such cases). In such cases, null is returned.
        protected virtual MemberSemanticModel CreateMemberModel(LanguageSyntaxNode node)
        {
            /* TODO:MetaDslx - implement in descendants
            BinderFlags additionalFlags = BinderFlags.None;
            if (this.IgnoresAccessibility)
            {
                additionalFlags = BinderFlags.IgnoreAccessibility;
            }*/
            return null;
        }


        protected virtual bool IsMemberDeclaration(LanguageSyntaxNode node)
        {
            return false;
        }

        private bool IsRegularCode
        {
            get
            {
                return this.SyntaxTree.Options.Kind == SourceCodeKind.Regular;
            }
        }

        #region "GetDeclaredSymbol overloads for MemberDeclarationSyntax and its subtypes"

        /// <summary>
        /// Given a member declaration syntax, get the corresponding symbol.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares a member.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbol that was declared.</returns>
        /// <remarks>
        /// NOTE:   We have no GetDeclaredSymbol overloads for following subtypes of MemberDeclarationSyntax:
        /// NOTE:   (1) GlobalStatementSyntax as they don't declare any symbols.
        /// NOTE:   (2) IncompleteMemberSyntax as there are no symbols for incomplete members.
        /// NOTE:   (3) BaseFieldDeclarationSyntax or its subtypes as these declarations can contain multiple variable declarators.
        /// NOTE:       GetDeclaredSymbol should be called on the variable declarators directly.
        /// </remarks>
        public override ISymbol GetDeclaredSymbol(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(declarationSyntax);

            return GetDeclaredNamespace(declarationSyntax);
        }

        private NamespaceSymbol GetDeclaredNamespace(LanguageSyntaxNode declarationSyntax)
        {
            Debug.Assert(declarationSyntax != null);
            throw new NotImplementedException("TODO:MetaDslx");
            /*NamespaceOrTypeSymbol container;
            if (declarationSyntax.Parent.RawKind == SyntaxKind.CompilationUnit)
            {
                container = _compilation.Assembly.GlobalNamespace;
            }
            else
            {
                container = GetDeclaredNamespaceOrType(declarationSyntax.Parent);
            }

            Debug.Assert((object)container != null);

            // We should get a namespace symbol since we match the symbol location with a namespace declaration syntax location.
            var symbol = (NamespaceSymbol)GetDeclaredMember(container, declarationSyntax.Span, declarationSyntax.Name);
            Debug.Assert((object)symbol != null);

            // Map to compilation-scoped namespace (Roslyn bug 9538)
            symbol = _compilation.GetCompilationNamespace(symbol);
            Debug.Assert((object)symbol != null);

            return symbol;*/
        }

        #endregion

        /// <summary>
        /// Given a base field declaration syntax, get the corresponding symbols.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares one or more fields or events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The field symbols that were declared.</returns>
        public override ImmutableArray<ISymbol> GetDeclaredSymbols(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(declarationSyntax);

            /* 
            var builder = new ArrayBuilder<ISymbol>();

            foreach (var declarator in declarationSyntax.Declaration.Variables)
            {
                var field = this.GetDeclaredSymbol(declarator, cancellationToken) as ISymbol;
                if (field != null)
                {
                    builder.Add(field);
                }
            }

            return builder.ToImmutableAndFree();*/
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public override ControlFlowAnalysis AnalyzeControlFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            ValidateStatementRange(firstStatement, lastStatement);
            var context = RegionAnalysisContext(firstStatement, lastStatement);
            var result = new LanguageControlFlowAnalysis(context);
            return result;
        }

        private void ValidateStatementRange(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            if (firstStatement == null)
            {
                throw new ArgumentNullException(nameof(firstStatement));
            }

            if (lastStatement == null)
            {
                throw new ArgumentNullException(nameof(lastStatement));
            }

            if (!IsInTree(firstStatement))
            {
                throw new ArgumentException("statements not within tree");
            }

            if (firstStatement.Parent == null || firstStatement.Parent != lastStatement.Parent)
            {
                throw new ArgumentException("statements not within the same statement list");
            }

            if (firstStatement.SpanStart > lastStatement.SpanStart)
            {
                throw new ArgumentException("first statement does not precede last statement");
            }
        }

        public override DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (!IsInTree(expression))
            {
                throw new ArgumentException("expression not within tree");
            }

            var context = RegionAnalysisContext(expression);
            var result = new LanguageDataFlowAnalysis(context);
            return result;
        }

        public override DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            ValidateStatementRange(firstStatement, lastStatement);
            var context = RegionAnalysisContext(firstStatement, lastStatement);
            var result = new LanguageDataFlowAnalysis(context);
            return result;
        }

        private static BoundNode GetBoundRoot(MemberSemanticModel memberModel, out Symbol member)
        {
            member = memberModel.MemberSymbol;
            return memberModel.GetBoundRoot();
        }

        private RegionAnalysisContext RegionAnalysisContext(LanguageSyntaxNode expression)
        {
            var memberModel = GetMemberModel(expression);
            if (memberModel == null)
            {
                // Recover from error cases
                var node = new BoundBadStatement(expression, ImmutableArray<BoundNode>.Empty, hasErrors: true);
                return new RegionAnalysisContext(Compilation, null, node, node, node);
            }

            Symbol member;
            BoundNode boundNode = GetBoundRoot(memberModel, out member);
            var first = memberModel.GetUpperBoundNode(expression, promoteToBindable: true);
            var last = first;
            return new RegionAnalysisContext(this.Compilation, member, boundNode, first, last);
        }

        private RegionAnalysisContext RegionAnalysisContext(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            var memberModel = GetMemberModel(firstStatement);
            if (memberModel == null)
            {
                // Recover from error cases
                var node = new BoundBadStatement(firstStatement, ImmutableArray<BoundNode>.Empty, hasErrors: true);
                return new RegionAnalysisContext(Compilation, null, node, node, node);
            }

            Symbol member;
            BoundNode boundNode = GetBoundRoot(memberModel, out member);
            var first = memberModel.GetUpperBoundNode(firstStatement, promoteToBindable: true);
            var last = memberModel.GetUpperBoundNode(lastStatement, promoteToBindable: true);
            return new RegionAnalysisContext(Compilation, member, boundNode, first, last);
        }
    }
}
