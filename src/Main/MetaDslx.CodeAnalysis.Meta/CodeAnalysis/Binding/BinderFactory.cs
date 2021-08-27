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

        public virtual Binder CreateScopeBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new ScopeBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateDefineBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false, bool forCompletion = false)
        {
            return new DefineBinder(parentBinder, syntax, type, forCompletion);
        }

        public virtual Binder CreateSymbolBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false, bool forCompletion = false)
        {
            return new SymbolBinder(parentBinder, syntax, type, null, forCompletion);
        }

        public virtual Binder CreateImportBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool isExtern = false, bool isStatic = false, bool forCompletion = false)
        {
            return new ImportBinder(parentBinder, syntax, isExtern, isStatic, forCompletion);
        }

        public virtual Binder CreateUseBinder(Binder parentBinder, SyntaxNodeOrToken syntax, ImmutableArray<Type> types, string autoPrefix = null, string autoSuffix = null, bool forCompletion = false)
        {
            return new UseBinder(parentBinder, syntax, types, autoPrefix, autoSuffix, forCompletion);
        }

        public virtual Binder CreatePropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax, string name, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null, bool forCompletion = false)
        {
            return new PropertyBinder(parentBinder, syntax, name, default, owner, ownerType, forCompletion);
        }

        public virtual Binder CreatePropertyBinder(Binder parentBinder, SyntaxNodeOrToken syntax, string name, object value, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null, bool forCompletion = false)
        {
            return new PropertyBinder(parentBinder, syntax, name, new Optional<object>(value), owner, ownerType, forCompletion);
        }

        public virtual Binder CreateIdentifierBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new IdentifierBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateQualifierBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new QualifierBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateNameBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new NameBinder(parentBinder, syntax, forCompletion);
        }

        public virtual Binder CreateValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax, bool forCompletion = false)
        {
            return new ValueBinder(parentBinder, syntax, Language.SyntaxFacts.ExtractValue(syntax), forCompletion);
        }

        public virtual Binder CreateValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax, object value, bool forCompletion = false)
        {
            return new ValueBinder(parentBinder, syntax, value, forCompletion);
        }

        public virtual Binder CreateEnumValueBinder(Binder parentBinder, SyntaxNodeOrToken syntax, Type enumType, bool forCompletion = false)
        {
            return new EnumValueBinder(parentBinder, syntax, Language.SyntaxFacts.ExtractName(syntax), enumType, forCompletion);
        }

        public virtual Binder CreateDocumentationBinder(Binder parentBinder, LanguageSyntaxNode syntax, bool forCompletion = false)
        {
            return new DocumentationBinder(parentBinder, syntax, forCompletion);
        }

    }
}
