using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class BindVisitor : DetailedSyntaxVisitor
    {
        private enum BindState
        {
            VisitParent,
            VisitChild,
            Binding
        }

        private Binder _binder;
        private DiagnosticBag _diagnostics;
        private bool _canEnterDeclaration;
        private BindState _bindState;
        private RedNode _node;
        private BindingOptions _options;
        private int _qualifierStack;
        private ArrayBuilder<RedNode> _qualifier;
        private ArrayBuilder<Type> _symbolTypes;
        private ArrayBuilder<object> _results;

        protected BindVisitor(Binder binder) 
            : base(false, false)
        {
            _binder = binder;
            this.Reset(null, null);
        }

        public virtual void Reset(DiagnosticBag diagnostics, RedNode node)
        {
            _diagnostics = diagnostics;
            _bindState = BindState.VisitParent;
            _canEnterDeclaration = false;
            _node = node;
            _qualifierStack = 0;
            _qualifier = ArrayBuilder<RedNode>.GetInstance();
            _symbolTypes = ArrayBuilder<Type>.GetInstance();
            _results = ArrayBuilder<object>.GetInstance();
            _options = null;
        }

        public virtual void Free()
        {
            _diagnostics = null;
            _qualifier.Free();
            _symbolTypes.Free();
            _results.Free();
        }

        public ImmutableArray<object> Bind()
        {
            this.VisitRed(_node);
            return _results.ToImmutable();
        }

        public bool IsBinding
        {
            get { return this._bindState == BindState.Binding; }
        }

        protected void StartBinding()
        {
            this._bindState = BindState.Binding;
        }

        protected bool CanEnterDeclaration()
        {
            bool result = _canEnterDeclaration;
            _canEnterDeclaration = false;
            return result;
        }

        protected bool CanVisitParent(SyntaxNode parent)
        {
            if (this._bindState == BindState.VisitParent)
            {
                if (parent == null)
                {
                    this._bindState = BindState.Binding;
                    return false;
                }
                else
                {
                    this._bindState = BindState.VisitChild;
                    return true;
                }
            }
            return false;
        }

        protected bool CanVisitChild(RedNode child)
        {
            if (child == null) return false;
            if (this._bindState == BindState.VisitChild && child.FullSpan.Contains(this._node.Position))
            {
                this._bindState = BindState.Binding;
                return true;
            }
            return false;
        }

        protected ImmutableArray<RedNode> Qualifier
        {
            get { return _qualifier.ToImmutable(); }
        }

        protected ImmutableArray<Type> SymbolTypes
        {
            get { return _symbolTypes.ToImmutable(); }
        }

        protected BindingOptions Options
        {
            get { return _options; }
        }

        protected DiagnosticBag Diagnostics
        {
            get { return _diagnostics; }
        }

        protected RedNode RootNode
        {
            get { return _node; }
        }

        protected void BeginQualifier()
        {
            if (_qualifierStack <= 0) _qualifier.Clear();
            ++_qualifierStack;
        }

        protected void EndQualifier()
        {
            --_qualifierStack;
            if (_qualifierStack == 0)
            {
                LookupResult result = LookupResult.GetInstance();
                HashSet<DiagnosticInfo> discardedDiagnostics = null;
                try
                {
                    Binder binder = this._binder;
                    IMetaSymbol symbol = binder.ContainingSymbol;
                    int index = 0;
                    while (symbol != null && index < _qualifier.Count)
                    {
                        string name = _qualifier[index].ToString();
                        binder = binder.LookupSymbols(result, name, null, BindingOptions.Default, false, ref discardedDiagnostics);
                        if (result.IsSingleViable)
                        {
                            symbol = result.SingleSymbolOrDefault;
                        }
                        else
                        {
                            symbol = null;
                            break;
                        }
                        ++index;
                    }
                    if (symbol != null)
                    {
                        _results.Add(symbol);
                    }
                }
                finally
                {
                    result.Free();
                }
            }
            if (_qualifierStack <= 0) _qualifier.Clear();
        }

        protected void RegisterIdentifier(RedNode name)
        {
            if (_qualifierStack == 0)
            {
                this.BeginQualifier();
                try
                {
                    _qualifier.Add(name);
                }
                finally
                {
                    this.EndQualifier();
                }
            }
            else
            {
                _qualifier.Add(name);
            }
        }

        protected void RegisterValue(RedNode node)
        {
            if (node == null) return;
            string valueStr = node.ToString();
            object value = this.GetValue(valueStr);
            _results.Add(value);
        }

        protected object GetValue(string value)
        {
            if (value == "null") return null;
            if (value.Length >= 3 && value.StartsWith("@\'") && value.EndsWith("\'"))
            {
                return value.Substring(2, value.Length - 3).Replace("\'\'", "\'");
            }
            else if (value.Length >= 2 && value.StartsWith("\'") && value.EndsWith("\'"))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
            else if (value.Length >= 3 && value.StartsWith("@\"") && value.EndsWith("\""))
            {
                return value.Substring(2, value.Length - 3).Replace("\"\"", "\"");
            }
            else if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            long longValue;
            if (long.TryParse(value, out longValue))
            {
                return longValue;
            }
            float floatValue;
            if (float.TryParse(value, out floatValue))
            {
                return floatValue;
            }
            double doubleValue;
            if (double.TryParse(value, out doubleValue))
            {
                return doubleValue;
            }
            return value;
        }

        protected void RegisterSymbolType(Type type)
        {
            _symbolTypes.Add(type);
        }

        protected void RegisterOptions(BindingOptions options)
        {
            _options = options;
        }


    }
}
