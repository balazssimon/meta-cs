using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
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
    public class SymbolBuilder
    {
        private readonly CompilationBase _compilation;
        private ModelFactory _lazyFactory;

        public SymbolBuilder(CompilationBase compilation)
        {
            _compilation = compilation;
        }

        public CompilationBase Compilation
        {
            get { return _compilation; }
        }

        private MutableModel ModelBuilder
        {
            get { return _compilation._lazyModelBuilder; }
        }

        public ModelFactory Factory
        {
            get
            {
                if (_lazyFactory == null)
                {
                    Interlocked.CompareExchange(ref _lazyFactory, _compilation.Language.CompilationFactory.CreateModelFactory(_compilation._lazyModelBuilder, false), null);
                }
                return _lazyFactory;
            }
        }

        public Binder GetBinder(RedNode node)
        {
            return this.Compilation.GetBinder(node);
        }

        public Binder GetBinder(SyntaxNode syntax, int position)
        {
            return this.Compilation.GetBinder(syntax, position);
        }

        public IMetaSymbol BuildSymbol(IMetaSymbol container, SyntaxNode node, string parentPropertyToAddTo, Type symbolType)
        {
            MutableSymbol symbol = this.Factory.Create(symbolType);
            MutableSymbol parent = container as MutableSymbol;
            if (parent != null)
            {
                ModelProperty parentProperty = symbol.MGetProperty(parentPropertyToAddTo);
                if (parentProperty != null)
                {
                    parent.MAdd(parentProperty, symbol);
                }
            }
            else if (_compilation != null)
            {
                symbol.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                symbol.MSet(CompilerAttachedProperties.ContainingCompilationProperty, _compilation);
            }
            symbol.MAttachProperty(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
            symbol.MSet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty, node.GetReference());
            this.BuildSymbolProperties(symbol, node, null);
            return symbol;
        }

        public IMetaSymbol BuildRootDeclarationSymbol(IMetaSymbol container, MergedDeclaration declaration)
        {
            return this.BuildDeclarationSymbol(container, declaration, true);
        }

        public IMetaSymbol BuildDeclarationSymbol(IMetaSymbol container, MergedDeclaration declaration, bool isRoot = false)
        {
            MutableSymbol symbol = null;
            if (isRoot)
            {
                symbol = (MutableSymbol)this.Compilation.Language.CompilationFactory.CreateGlobalNamespace(this.Compilation, this.ModelBuilder, ImmutableArray<IMetaSymbol>.Empty);
            }
            else
            {
                symbol = this.Factory.Create(declaration.Kind.ImmutableType);
            }
            ModelProperty nameProperty = symbol.MId.SymbolInfo.NameProperty;
            if (nameProperty != null)
            {
                symbol.MSet(symbol.MId.SymbolInfo.NameProperty, declaration.Name);
            }
            MutableSymbol parent = container as MutableSymbol;
            if (parent != null)
            {
                ModelProperty parentProperty = symbol.MGetProperty(declaration.ParentPropertyToAddTo);
                if (parentProperty != null)
                {
                    parent.MAdd(parentProperty, symbol);
                }
            }
            else if (_compilation != null)
            {
                symbol.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                symbol.MSet(CompilerAttachedProperties.ContainingCompilationProperty, _compilation);
            }
            symbol.MAttachProperty(CompilerAttachedProperties.MergedDeclarationProperty);
            symbol.MSet(CompilerAttachedProperties.MergedDeclarationProperty, declaration);
            symbol.MAttachProperty(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
            symbol.MSet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty, declaration.SyntaxReferences);
            if (declaration.Children.Length > 0)
            {
                symbol.MAttachProperty(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                symbol.MSetLazy(CompilerAttachedProperties.PropertiesToMembersMapProperty, () => BuildDeclarationParentPropertyToMemberMap(symbol, container, declaration));
                this.BuildDeclarationSymbolProperties(symbol, declaration);
            }
            if (!isRoot)
            {
                this.BuildSymbolProperties(symbol, declaration);
            }
            return symbol;
        }

        private Dictionary<string, ImmutableArray<IMetaSymbol>> BuildDeclarationParentPropertyToMemberMap(MutableSymbol symbol, IMetaSymbol container, MergedDeclaration declaration)
        {
            var map = new Dictionary<string, ImmutableArray<IMetaSymbol>>();
            var cbp = declaration.ChildrenByParentProperties;
            foreach (var kvp in cbp)
            {
                ArrayBuilder<IMetaSymbol> membersBuilder = ArrayBuilder<IMetaSymbol>.GetInstance();
                try
                {
                    foreach (var item in kvp.Value)
                    {
                        var member = BuildDeclarationSymbol(symbol, item);
                        membersBuilder.Add(member);
                    }
                }
                finally
                {
                    var members = membersBuilder.ToImmutableAndFree();
                    map.Add(kvp.Key, members);
                }
            };
            return map;
        }

        private void BuildDeclarationSymbolProperties(MutableSymbol symbol, MergedDeclaration declaration)
        {
            foreach (var kvp in declaration.ChildrenByParentProperties)
            {
                string propertyName = kvp.Key;
                ModelProperty parentProperty = symbol.MGetProperty(propertyName);
                if (parentProperty != null)
                {
                    if (parentProperty.IsCollection)
                    {
                        symbol.MAddRangeLazy(parentProperty,
                            () =>
                            {
                                var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)symbol.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                return map[propertyName];
                            });
                    }
                    else
                    {
                        symbol.MSetLazy(parentProperty,
                            () =>
                            {
                                var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)symbol.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                return map[propertyName].FirstOrDefault();
                            });
                    }
                }
            }
        }

        protected virtual void BuildSymbolProperties(MutableSymbol symbol, MergedDeclaration declaration)
        {
            Debug.Assert(symbol != null);

            foreach (var reference in declaration.SyntaxReferences)
            {
                var node = reference.GetSyntax();
                this.BuildSymbolProperties(symbol, node, declaration);
            }
        }

        private void BuildSymbolProperties(MutableSymbol symbol, SyntaxNode node, MergedDeclaration declaration)
        {
            Debug.Assert(symbol != null);
            var properties = new HashSet<string>(symbol.MProperties.Select(p => p.Name));
            //properties.RemoveAll(declaration.ChildrenByParentProperties.Keys);
            foreach (var propertyName in properties)
            {
                string currentName = propertyName;
                ModelProperty currentProperty = symbol.MGetProperty(currentName);
                if (currentProperty.IsCollection)
                {
                    symbol.MAddRangeLazy(currentProperty, () =>
                    {
                        var binder = this.Compilation.GetBinder(node);
                        if (binder == null) return null;
                        var propertyBinders = binder.GetDescendantBinders<IPropertyBinder>(pb => pb.PropertyName == currentName, b => b is IPropertyBinder);
                        if (propertyBinders.Length == 0 && binder is IPropertyBinder)
                        {
                            propertyBinders = ImmutableArray.Create((IPropertyBinder)binder);
                        }
                        var valueBinders = propertyBinders.SelectMany(pb => ((Binder)pb).GetDescendantBinders<IValueBinder>()).ToImmutableArray();
                        var values = valueBinders.SelectMany(vb => vb.GetValues()).Where(v => v != null).ToImmutableArray();
                        return values;
                    });
                }
                else if (!symbol.MIsSet(currentProperty))
                {
                    symbol.MSetLazy(currentProperty, () =>
                    {
                        var binder = this.Compilation.GetBinder(node);
                        if (binder == null) return null;
                        var propertyBinders = binder.GetDescendantBinders<IPropertyBinder>(pb => pb.PropertyName == currentName, b => b is IPropertyBinder);
                        if (propertyBinders.Length == 0 && binder is IPropertyBinder)
                        {
                            propertyBinders = ImmutableArray.Create((IPropertyBinder)binder);
                        }
                        var valueBinders = propertyBinders.SelectMany(pb => ((Binder)pb).GetDescendantBinders<IValueBinder>()).ToImmutableArray();
                        var values = valueBinders.SelectMany(vb => vb.GetValues()).Where(v => v != null).ToImmutableArray();
                        return values.FirstOrDefault();
                    });
                }
            }
        }
    }
}
