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
        IMetaSymbol GetChildContextSymbol(RedNode node);
    }

    public class QualifierBinder : Binder, IQualifierBinder
    {
        private ImmutableArray<RedNode> _lazyIdentifierNodes;
        private IMetaSymbol[] _lazySymbols;
        private IMetaSymbol _lazySymbol;

        public QualifierBinder(Binder next, RedNode node) 
            : base(next, node)
        {
        }

        public ImmutableArray<RedNode> IdentifierNodes
        {
            get
            {
                if (_lazyIdentifierNodes.IsDefault)
                {
                    var parentQualifierBinder = this.GetAncestorBinder<IQualifierBinder>();
                    var qualifierBinders = this.GetDescendantBinders<IQualifierBinder>();
                    ImmutableInterlocked.InterlockedExchange(ref _lazyIdentifierNodes, qualifierBinders.Select(qb => ((Binder)qb).Node).ToImmutableArray());
                    Interlocked.CompareExchange(ref _lazySymbols, new IMetaSymbol[_lazyIdentifierNodes.Length], null);
                    if (_lazySymbols.Length > 0 && parentQualifierBinder != null)
                    {
                        Interlocked.CompareExchange(ref _lazySymbols[0], parentQualifierBinder.GetChildContextSymbol(this.Node), null);
                    }
                }
                return _lazyIdentifierNodes;
            }
        }

        public IMetaSymbol GetChildContextSymbol(RedNode node)
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

        public virtual IMetaSymbol Symbol
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

        public ImmutableArray<object> GetValues()
        {
            var symbol = this.Symbol;
            if (symbol != null) return ImmutableArray.Create((object)this.Symbol);
            else return ImmutableArray<object>.Empty;
        }

        public ImmutableArray<IMetaSymbol> GetSymbols()
        {
            var symbol = this.Symbol;
            if (symbol != null) return ImmutableArray.Create(this.Symbol);
            else return ImmutableArray<IMetaSymbol>.Empty;
        }

    }
}
