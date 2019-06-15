using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BoundNodeFactoryVisitor : SyntaxVisitor<ArrayBuilder<BoundNode>, BoundNode>
    {
        private readonly BoundTree _boundTree;

        public BoundNodeFactoryVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public void Initialize()
        {
        }

        protected Language Language => _boundTree.Language;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected BoundTree BoundTree => _boundTree;

        protected bool InScript => _boundTree.InScript;

        protected DiagnosticBag DiagnosticBag => _boundTree.DiagnosticBag;

        protected virtual BoundNode CreateBoundRoot(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundRootCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundRootCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundRoot(BoundKind.Root, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundScope(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundScopeCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundScopeCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundScope(BoundKind.Scope, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolDef(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundSymbolDefCore(boundTree, childBoundNodes, symbolType, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolDefCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundSymbolDef(BoundKind.SymbolDef, boundTree, childBoundNodes, symbolType, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolCtr(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundSymbolCtrCore(boundTree, childBoundNodes, symbolType, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolCtrCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundSymbolCtr(BoundKind.SymbolCtr, boundTree, childBoundNodes, symbolType, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolUse(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundSymbolUseCore(boundTree, childBoundNodes, symbolTypes, ImmutableArray<Type>.Empty, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundSymbolUseCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundSymbolUse(BoundKind.SymbolUse, boundTree, childBoundNodes, symbolTypes, nestingSymbolTypes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundProperty(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundPropertyCore(boundTree, childBoundNodes, name, default, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundProperty(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, object value, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundPropertyCore(boundTree, childBoundNodes, name, new Optional<object>(value), syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundPropertyCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, string name, Optional<object> valueOpt, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundProperty(BoundKind.Property, boundTree, childBoundNodes, name, valueOpt, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundIdentifier(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundIdentifierCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundIdentifierCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundIdentifier(BoundKind.Identifier, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundQualifier(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundQualifierCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundQualifierCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundQualifier(BoundKind.Qualifier, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundName(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundNameCore(boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundNameCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundName(BoundKind.Name, boundTree, childBoundNodes, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundValue(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundValueCore(boundTree, childBoundNodes, Language.SyntaxFacts.ExtractValue(syntax), syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundValue(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, object value, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundValueCore(boundTree, childBoundNodes, value, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundValueCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, object value, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundValue(BoundKind.Value, boundTree, childBoundNodes, value, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundEnumValue(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type enumType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return this.CreateBoundEnumValueCore(boundTree, childBoundNodes, enumType, syntax, hasErrors);
        }

        protected virtual BoundNode CreateBoundEnumValueCore(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type enumType, LanguageSyntaxNode syntax, bool hasErrors)
        {
            return new BoundEnumValue(BoundKind.EnumValue, boundTree, childBoundNodes, Language.SyntaxFacts.ExtractName(syntax), enumType, syntax, hasErrors);
        }
    }
}
