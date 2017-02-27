﻿using MetaDslx.Compiler.Binding.Binders;
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
    public abstract class SymbolBuilder
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

        protected MutableModel ModelBuilder
        {
            get { return _compilation._lazyModelBuilder; }
        }

        public IMetaSymbol BuildSymbol(IMetaSymbol container, SyntaxNode node, string parentPropertyToAddTo, Type symbolType)
        {
            MutableSymbol symbol = this.CreateSymbol(symbolType);
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
                symbol = this.CreateGlobalNamespace(ImmutableArray<IMetaSymbol>.Empty);
            }
            else
            {
                symbol = this.CreateSymbol(declaration.Kind.ImmutableType);
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
            symbol.MAttachProperty(CompilerAttachedProperties.DiagnosticBagProperty);
            symbol.MSet(CompilerAttachedProperties.DiagnosticBagProperty, new DiagnosticBag());
            if (declaration.Children.Length > 0)
            {
                //symbol.MAttachProperty(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                //symbol.MSetLazy(CompilerAttachedProperties.PropertiesToMembersMapProperty, LazyValue.CreateSingle(() => BuildDeclarationParentPropertyToMemberMap(symbol, container, declaration)));
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
                    foreach (var item in kvp.Value)
                    {
                        var currentItem = item;
                        symbol.MSetOrAddLazy(parentProperty, LazyValue.CreateSingle(() => BuildDeclarationSymbol(symbol, currentItem)));
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
            Location location = node.GetLocation();
            DiagnosticBag diagnostics = (DiagnosticBag)symbol.MGet(CompilerAttachedProperties.DiagnosticBagProperty);
            var properties = new HashSet<string>(symbol.MProperties.Select(p => p.Name));
            //properties.RemoveAll(declaration.ChildrenByParentProperties.Keys);
            foreach (var propertyName in properties)
            {
                string currentName = propertyName;
                ModelProperty currentProperty = symbol.MGetProperty(currentName);
                if (currentProperty.IsCollection)
                {
                    symbol.MAddRangeLazy(currentProperty, LazyValue.CreateMultiple(() => BindMultipleValues(symbol, node, currentName), true));
                }
                else if (!symbol.MIsSet(currentProperty))
                {
                    symbol.MSetLazy(currentProperty, LazyValue.CreateSingle(() => BindSingleValue(symbol, node, currentName), true));
                }
            }
        }

        private object BindSingleValue(MutableSymbol symbol, SyntaxNode node, string propertyName)
        {
            var binder = this.Compilation.GetBinder(node);
            if (binder == null) return null;
            var propertyBinders = binder.FindDescendantBinders<IPropertyBinder>(pb => pb.PropertyName == propertyName, b => b is IPropertyBinder && ((IPropertyBinder)b).PropertyName != propertyName);
            var values = propertyBinders.SelectMany(pb => pb.GetValues()).ToImmutableArray();
            var errors = propertyBinders.SelectMany(pb => pb.GetErrors()).ToImmutableArray();
            if (errors.Length > 0)
            {
                DiagnosticBag diagnostics = (DiagnosticBag)symbol.MGet(CompilerAttachedProperties.DiagnosticBagProperty);
                diagnostics.AddRange(errors);
            }
            return values.FirstOrDefault();
        }


        private IEnumerable<object> BindMultipleValues(MutableSymbol symbol, SyntaxNode node, string propertyName)
        {
            var binder = this.Compilation.GetBinder(node);
            if (binder == null) return null;
            var propertyBinders = binder.FindDescendantBinders<IPropertyBinder>(pb => pb.PropertyName == propertyName, b => b is IPropertyBinder && ((IPropertyBinder)b).PropertyName != propertyName);
            var values = propertyBinders.SelectMany(pb => pb.GetValues()).ToImmutableArray();
            var errors = propertyBinders.SelectMany(pb => pb.GetErrors()).ToImmutableArray();
            if (errors.Length > 0)
            {
                DiagnosticBag diagnostics = (DiagnosticBag)symbol.MGet(CompilerAttachedProperties.DiagnosticBagProperty);
                diagnostics.AddRange(errors);
            }
            return values;
        }

        public MutableSymbol CreateSymbol(Type symbolType)
        {
            return this.CreateSymbolCore(symbolType);
        }

        protected abstract MutableSymbol CreateSymbolCore(Type symbolType);

        public MutableSymbol CreateErrorSymbol()
        {
            var errorSymbol = this.CreateErrorSymbolCore();
            errorSymbol.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
            errorSymbol.MSet(CompilerAttachedProperties.ContainingCompilationProperty, this.Compilation);
            return errorSymbol;
        }

        protected abstract MutableSymbol CreateErrorSymbolCore();

        public MutableSymbol CreateGlobalNamespace(IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var result = this.CreateGlobalNamespaceCore(namespacesToMerge);
            result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
            result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, this.Compilation);
            return result;
        }

        protected abstract MutableSymbol CreateGlobalNamespaceCore(IEnumerable<IMetaSymbol> namespacesToMerge);

        public IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, RootBinder rootBinder)
        {
            var result = this.CreateGlobalNamespaceAliasCore(globalNamespace);
            result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
            result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, this.Compilation);
            return result;
        }

        protected abstract MutableSymbol CreateGlobalNamespaceAliasCore(IMetaSymbol globalNamespace);
    }
}
