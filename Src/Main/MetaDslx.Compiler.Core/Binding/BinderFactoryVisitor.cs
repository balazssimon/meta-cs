using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public abstract class BinderFactoryVisitor : DetailedSyntaxVisitor<Binder> 
    {
        private readonly BinderFactory _binderFactory;
        private int _position;

        public BinderFactoryVisitor(BinderFactory binderFactory)
            : base(false, false)
        {
            _binderFactory = binderFactory;
        }

        public BinderFactory BinderFactory
        {
            get { return _binderFactory; }
        }

        public CompilationBase Compilation
        {
            get { return _binderFactory.Compilation; }
        }

        public SyntaxTree SyntaxTree
        {
            get { return _binderFactory.SyntaxTree; }
        }

        public int Position
        {
            get { return _position; }
        }

        public virtual void Reset(int position)
        {
            _position = position;
        }

        protected virtual Binder CreateContainerBinder(IMetaSymbol symbol, Binder parentBinder)
        {
            return new InContainerBinder(symbol, parentBinder);
        }

        protected virtual Binder GetBinderForSymbol(SyntaxNode parent, string name = null, bool inBody = false, Type kind = null, object usage = null)
        {
            if (inBody) return this.GetBinderForSymbolBody(parent, name, kind, usage);
            else return this.GetBinderForSymbolOutsideOfBody(parent, name, kind, usage);
        }

        protected virtual Binder GetBinderForSymbolBody(SyntaxNode parent, string name = null, Type kind = null, object usage = null)
        {
            Binder resultBinder;
            if (!_binderFactory.TryGetBinder(parent, usage, out resultBinder))
            {
                Binder outerBinder = this.GetContainingBinder(parent); // a binder for the body of the symbol enclosing this symbol
                var parentSymbol = this.GetContainingSymbol(outerBinder, parent);
                var symbol = this.GetChildSymbol(name, parent.Span, parentSymbol, kind);
                var parentBinder = outerBinder;
                if (symbol.MParent != null && symbol.MParent != parentSymbol)
                {
                    List<IMetaSymbol> ancestors = new List<IMetaSymbol>();
                    ancestors.Add(symbol.MParent);
                    int index = 0;
                    while (index < ancestors.Count && ancestors[index] != parentSymbol)
                    {
                        var currentSymbol = ancestors[index];
                        if (currentSymbol.MParent != null)
                        {
                            ancestors.Add(currentSymbol.MParent);
                        }
                        ++index;
                    }
                    for (int i = 1; i < ancestors.Count; i++)
                    {
                        var currentSymbol = ancestors[i];
                        parentBinder = this.CreateContainerBinder(currentSymbol, parentBinder);
                    }
                }
                resultBinder = this.CreateContainerBinder(symbol, parentBinder);
                _binderFactory.TryAddBinder(parent, usage, resultBinder);
            }
            return resultBinder;
        }

        protected virtual Binder GetBinderForSymbolOutsideOfBody(SyntaxNode parent, string name = null, Type kind = null, object usage = null)
        {
            return this.GetContainingBinder(parent);
        }

        protected virtual Binder GetContainingBinder(SyntaxNode node)
        {
            Binder resultBinder;
            if (node.Parent == null)
            {
                if (!_binderFactory.TryGetBinder(node, null, out resultBinder))
                {
                    Binder outerBinder = this.BinderFactory.BuckStopsHereBinder;
                    var parentSymbol = this.GetContainingSymbol(outerBinder, node);
                    resultBinder = this.CreateContainerBinder(parentSymbol, outerBinder);
                    _binderFactory.TryAddBinder(node, null, resultBinder);
                }
            }
            else
            {
                resultBinder = node.Parent.Accept(this);
            }
            return resultBinder;
        }

        protected virtual IMetaSymbol GetContainingSymbol(Binder binder, SyntaxNode node)
        {
            var container = binder.ContainingSymbol;
            if ((object)container == null)
            {
                if (node.Parent == null)
                {
                    if (this.SyntaxTree.Options.Kind != SourceCodeKind.Regular)
                    {
                        container = this.Compilation.ScriptSymbol;
                    }
                    else
                    {
                        container = this.Compilation.GlobalNamespace;
                    }
                }
            }
            return container;
        }

        protected virtual IMetaSymbol GetChildSymbol(string childName, TextSpan childSpan, IMetaSymbol container, Type kind)
        {
            foreach (IMetaSymbol sym in container.GetChildren(childName))
            {
                if (kind != null && sym.IsOfKind(kind))
                {
                    continue;
                }

                var syntaxReferences = (ImmutableArray<SyntaxReference>)sym.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
                foreach (var reference in syntaxReferences)
                {
                    if (reference.SyntaxTree == this.SyntaxTree && reference.Span.OverlapsWith(childSpan))
                    {
                        return sym;
                    }
                }
            }
            return null;
        }
    }
}
