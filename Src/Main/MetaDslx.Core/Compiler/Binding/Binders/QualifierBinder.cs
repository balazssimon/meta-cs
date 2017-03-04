using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Core;
using MetaDslx.Compiler.Diagnostics;
using System.Threading;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IQualifierBinder : IValueBinder
    {
        ImmutableArray<RedNode> IdentifierNodes { get; }
        bool IsLastIdentifier(RedNode node);
        ISymbol GetChildContextSymbol(RedNode node);
    }

    public class QualifierBinder : Binder, IQualifierBinder
    {
        private ImmutableArray<RedNode> _lazyIdentifierNodes;
        private ISymbol[] _lazySymbols;
        private ISymbol _lazySymbol;
        private IQualifierBinder _lazyParentQualifierBinder;

        public QualifierBinder(Binder next, RedNode node) 
            : base(next, node)
        {
        }

        private void CollectChildNodes()
        {
            if (_lazyIdentifierNodes.IsDefault)
            {
                Interlocked.CompareExchange(ref _lazyParentQualifierBinder, this.FindAncestorBinder<IQualifierBinder>(), null);
                var qualifierBinders = this.FindDescendantBinders<IQualifierBinder>();
                ImmutableInterlocked.InterlockedExchange(ref _lazyIdentifierNodes, qualifierBinders.Select(qb => ((Binder)qb).Node).ToImmutableArray());
                Interlocked.CompareExchange(ref _lazySymbols, new ISymbol[_lazyIdentifierNodes.Length], null);
                if (_lazySymbols.Length > 0 && _lazyParentQualifierBinder != null)
                {
                    Interlocked.CompareExchange(ref _lazySymbols[0], _lazyParentQualifierBinder.GetChildContextSymbol(this.Node), null);
                }
            }
        }

        public ImmutableArray<RedNode> IdentifierNodes
        {
            get
            {
                this.CollectChildNodes();
                return _lazyIdentifierNodes;
            }
        }

        public bool IsLastIdentifier(RedNode node)
        {
            int index = this.IdentifierNodes.IndexOf(node);
            return index >= 0 && index == _lazySymbols.Length-1 && (_lazyParentQualifierBinder == null || _lazyParentQualifierBinder.IsLastIdentifier(this.Node));
        }

        public ISymbol GetChildContextSymbol(RedNode node)
        {
            int index = this.IdentifierNodes.IndexOf(node);
            if (index > 0)
            {
                var symbol = this._lazySymbols[index];
                if (symbol == null)
                {
                    var prevNode = this.IdentifierNodes[index - 1];
                    var prevNodeBinder = this.GetBinder(prevNode) as IValueBinder;
                    var prevSymbol = prevNodeBinder.Symbol;
                    if (prevSymbol == null) prevSymbol = this.Compilation.ErrorSymbol;
                    Interlocked.CompareExchange(ref this._lazySymbols[index], prevSymbol, null);
                    symbol = this._lazySymbols[index];
                }
                return symbol;
            }
            return null;
        }

        public object Value
        {
            get { return this.Symbol; }
        }

        public virtual ISymbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    if (this.IdentifierNodes.Length == 0)
                    {
                        Interlocked.CompareExchange(ref _lazySymbol, this.Compilation.ErrorSymbol, null);
                    }
                    else
                    {
                        var lastNode = _lazyIdentifierNodes[_lazyIdentifierNodes.Length - 1];
                        var lastNodeBinder = this.GetBinder(lastNode) as IValueBinder;
                        var lastSymbol = lastNodeBinder?.Symbol;
                        if (lastSymbol != null)
                        {
                            Interlocked.CompareExchange(ref _lazySymbol, lastSymbol, null);
                        }
                        else
                        {
                            Interlocked.CompareExchange(ref _lazySymbol, this.Compilation.ErrorSymbol, null);
                        }
                    }
                }
                return _lazySymbol;
            }
        }
        
        public virtual ImmutableArray<Diagnostic> GetErrors()
        {
            var nodes = this.IdentifierNodes;
            for (int i = 0; i < nodes.Length; i++)
            {
                var identifierBinder = this.GetBinder(nodes[i]) as IValueBinder;
                var errors = identifierBinder.GetErrors();
                if (errors.Length > 0) return errors;
            }
            return ImmutableArray<Diagnostic>.Empty;
        }

        public ImmutableArray<object> GetValues()
        {
            var symbol = this.Symbol;
            if (symbol != null) return ImmutableArray.Create((object)this.Symbol);
            else return ImmutableArray<object>.Empty;
        }

        public ImmutableArray<ISymbol> GetSymbols()
        {
            var symbol = this.Symbol;
            if (symbol != null) return ImmutableArray.Create(this.Symbol);
            else return ImmutableArray<ISymbol>.Empty;
        }

    }
}
