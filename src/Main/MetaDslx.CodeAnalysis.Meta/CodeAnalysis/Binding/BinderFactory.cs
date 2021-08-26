using MetaDslx.CodeAnalysis.Binding.Binders;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinderFactory
    {
        private readonly BinderCache _cache;

        // In a typing scenario, GetBinder is regularly called with a non-zero position.
        // This results in a lot of allocations of BinderFactoryVisitors. Pooling them
        // reduces this churn to almost nothing.
        private readonly ObjectPool<BinderFactoryVisitor> _pool;
        private readonly ObjectPool<CompletionBinderFactoryVisitor> _completionPool;

        public BinderFactory(BinderCache cache)
        {
            _cache = cache;
            _pool = new ObjectPool<BinderFactoryVisitor>(() => Language.CompilationFactory.CreateBinderFactoryVisitor(this), 64);
            _completionPool = new ObjectPool<CompletionBinderFactoryVisitor>(() => Language.CompilationFactory.CreateCompletionBinderFactoryVisitor(this), 64);
        }

        public Language Language => _cache.Language;

        public LanguageCompilation Compilation => _cache.Compilation;

        public LanguageSyntaxTree SyntaxTree => _cache.SyntaxTree;

        public bool InScript => _cache.InScript;

        public BuckStopsHereBinder BuckStopsHereBinder => _cache.BuckStopsHereBinder;


        /// <summary>
        /// Return binder for binding at node.
        /// <paramref name="memberDeclarationOpt"/> and <paramref name="memberOpt"/>
        /// are optional syntax and symbol for the member containing <paramref name="node"/>.
        /// If provided, the <see cref="BinderFactoryVisitor"/> will use the member symbol rather
        /// than looking up the member in the containing type, allowing this method to be called
        /// while calculating the member list.
        /// </summary>
        /// <remarks>
        /// Note, there is no guarantee that the factory always gives back the same binder instance for the same node.
        /// </remarks>
        public Binder GetBinder(SyntaxNodeOrToken node)
        {
            int position = node.SpanStart;

            if (node.IsToken) return GetBinder(node.Parent, position, node.IsToken);
            else return GetBinder(node.AsNode(), position, node.IsToken);
        }

        public Binder GetBinder(SyntaxNode node, int position, bool forChild)
        {
            Debug.Assert(node != null);

            BinderFactoryVisitor visitor = _pool.Allocate();
            visitor.Initialize(position, forChild);
            Binder result = visitor.Visit(node);
            _pool.Free(visitor);

            return result;
        }

        public ImmutableArray<(object BinderOrTokenKind, TextSpan TextSpan)> GetCompletionBinders(int position)
        {
            CompletionBinderFactoryVisitor visitor = _completionPool.Allocate();
            visitor.Initialize(position);
            var result = visitor.CollectBinders();
            _completionPool.Free(visitor);
            return result;
        }

        public bool TryGetBinder(LanguageSyntaxNode node, object usage, out Binder binder)
        {
            return _cache.TryGetBinder(node, usage, out binder);
        }

        public bool TryAddBinder(LanguageSyntaxNode node, object usage, ref Binder binder)
        {
            return _cache.TryAddBinder(node, usage, ref binder);
        }

        public virtual Binder CreateScopeBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateScopeBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateScopeBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new ScopeBinder(parentBinder, syntax);
        }

        public virtual Binder CreateDefineBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            return this.CreateDefineBinderCore(parentBinder, syntax, type);
        }

        public virtual Binder CreateDefineBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, Type type)
        {
            return new DefineBinder(parentBinder, syntax, type);
        }

        public virtual Binder CreateSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            return this.CreateSymbolBinderCore(parentBinder, syntax, type);
        }

        public virtual Binder CreateSymbolBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, Type type)
        {
            return new SymbolBinder(parentBinder, syntax, type, null);
        }

        public virtual Binder CreateImportBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool isExtern = false, bool isStatic = false)
        {
            return this.CreateImportBinderCore(parentBinder, syntax, isExtern, isStatic);
        }

        public virtual Binder CreateImportBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, bool isExtern, bool isStatic)
        {
            return new ImportBinder(parentBinder, syntax, isExtern, isStatic);
        }

        public virtual Binder CreateUseBinder(Binder parentBinder, SyntaxNodeOrToken syntax, ImmutableArray<Type> types, string autoPrefix = null, string autoSuffix = null)
        {
            return this.CreateUseBinderCore(parentBinder, syntax, types, autoPrefix, autoSuffix);
        }

        public virtual Binder CreateUseBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, ImmutableArray<Type> types, string autoPrefix, string autoSuffix)
        {
            return new UseBinder(parentBinder, syntax, types, autoPrefix, autoSuffix);
        }

        public virtual Binder CreatePropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax, string name, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            return this.CreatePropertyBinderCore(parentBinder, syntax, name, default, owner, ownerType);
        }

        public virtual Binder CreatePropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax, string name, object value, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            return this.CreatePropertyBinderCore(parentBinder, syntax, name, new Optional<object>(value), owner, ownerType);
        }

        public virtual Binder CreatePropertyBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, string name, Optional<object> valueOpt, SymbolPropertyOwner owner, Type ownerType)
        {
            return new PropertyBinder(parentBinder, syntax, name, valueOpt, owner, ownerType);
        }

        public virtual Binder CreateIdentifierBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateIdentifierBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateIdentifierBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new IdentifierBinder(parentBinder, syntax);
        }

        public virtual Binder CreateQualifierBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateQualifierBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateQualifierBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new QualifierBinder(parentBinder, syntax);
        }

        public virtual Binder CreateNameBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateNameBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateNameBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return new NameBinder(parentBinder, syntax);
        }

        public virtual Binder CreateValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax)
        {
            return this.CreateValueBinderCore(parentBinder, syntax, Language.SyntaxFacts.ExtractValue(syntax));
        }

        public virtual Binder CreateValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax, object value)
        {
            return this.CreateValueBinderCore(parentBinder, syntax, value);
        }

        public virtual Binder CreateValueBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, object value)
        {
            return new ValueBinder(parentBinder, syntax, value);
        }

        public virtual Binder CreateEnumValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type enumType)
        {
            return this.CreateEnumValueBinderCore(parentBinder, syntax, enumType);
        }

        public virtual Binder CreateEnumValueBinderCore(Binder parentBinder, SyntaxNodeOrToken syntax, Type enumType)
        {
            return new EnumValueBinder(parentBinder, syntax, Language.SyntaxFacts.ExtractName(syntax), enumType);
        }

        public virtual Binder CreateDocumentationBinder(Binder parentBinder, LanguageSyntaxNode syntax)
        {
            return this.CreateDocumentationBinderCore(parentBinder, syntax);
        }

        public virtual Binder CreateDocumentationBinderCore(Binder parentBinder, LanguageSyntaxNode syntax)
        {
            return new DocumentationBinder(parentBinder, syntax);
        }

    }
}
