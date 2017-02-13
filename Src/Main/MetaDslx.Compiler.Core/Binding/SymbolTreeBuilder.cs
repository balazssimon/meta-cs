using MetaDslx.Compiler.Declarations;
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
    public sealed class SymbolTreeBuilder
    {
        private readonly CompilationBase _compilation;
        private ModelFactory _lazyFactory;
        private readonly ObjectPool<SymbolTreeBuilderVisitor> _symbolBuilderVisitorPool;

        public SymbolTreeBuilder(CompilationBase compilation)
        {
            _compilation = compilation;
            _symbolBuilderVisitorPool = new ObjectPool<SymbolTreeBuilderVisitor>(() => compilation.Language.CompilationFactory.CreateSymbolTreeBuilderVisitor(this), 64);
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
                    Interlocked.CompareExchange(ref _lazyFactory, _compilation.Language.CompilationFactory.CreateModelFactory(_compilation._lazyModelBuilder), null);
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
            this.BuildSymbolProperties(symbol, node);
            return symbol;
        }

        public IMetaSymbol BuildDeclarationSymbol(IMetaSymbol container, MergedDeclaration declaration)
        {
            MutableSymbol symbol = this.Factory.Create(declaration.Kind.ImmutableType);
            symbol.MSet(symbol.MId.SymbolInfo.NameProperty, declaration.Name);
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
            this.BuildSymbolProperties(symbol, declaration);
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
                ModelProperty parentProperty = symbol.MGetProperty(kvp.Key);
                if (parentProperty != null)
                {
                    if (parentProperty.IsCollection)
                    {
                        for (int i = 0; i < kvp.Value.Length; i++)
                        {
                            int index = i;
                            symbol.MAddLazy(parentProperty,
                                () =>
                                {
                                    var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)symbol.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                    var members = map[kvp.Key];
                                    return members[index];
                                });
                        }
                    }
                    else
                    {
                        symbol.MSetLazy(parentProperty,
                            () =>
                            {
                                var map = (Dictionary<string, ImmutableArray<IMetaSymbol>>)symbol.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
                                return map[kvp.Key].FirstOrDefault();
                            });
                    }
                }
            }
        }

        private void BuildSymbolProperties(MutableSymbol symbol, MergedDeclaration declaration)
        {
            Debug.Assert(symbol != null);

            SymbolTreeBuilderVisitor visitor = _symbolBuilderVisitorPool.Allocate();
            try
            {
                visitor.Reset(symbol, declaration);
                foreach (var reference in declaration.SyntaxReferences)
                {
                    var node = reference.GetSyntax();
                    node.Accept(visitor);
                }
            }
            finally
            {
                _symbolBuilderVisitorPool.Free(visitor);
            }
        }

        private void BuildSymbolProperties(MutableSymbol symbol, SyntaxNode node)
        {
            Debug.Assert(symbol != null);

            Binder result = null;

            SymbolTreeBuilderVisitor visitor = _symbolBuilderVisitorPool.Allocate();
            try
            {
                visitor.Reset(symbol, null);
                result = node.Accept(((object)visitor) as SyntaxVisitor<Binder>);
            }
            finally
            {
                _symbolBuilderVisitorPool.Free(visitor);
            }
        }
    }
}
