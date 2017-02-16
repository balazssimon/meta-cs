using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class SymbolTreeBuilderVisitor : DetailedSyntaxVisitor
    {
        private SymbolTreeBuilder _symbolTreeBuilder;
        private MutableSymbol _symbol;
        private bool _canEnterDeclaration;
        private MergedDeclaration _declaration;
        private DiagnosticBag _diagnostics;
        private List<string> _propertyStack;
        private string _currentPropertyName;
        private ModelProperty _currentProperty;

        public SymbolTreeBuilderVisitor(SymbolTreeBuilder symbolTreeBuilder)
            : base(false, false)
        {
            _symbolTreeBuilder = symbolTreeBuilder;
            _propertyStack = new List<string>();
            _currentProperty = null;
            _currentPropertyName = null;
        }

        public virtual void Reset(MutableSymbol symbol, MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            _canEnterDeclaration = true;
            _symbol = symbol;
            _declaration = declaration;
            _diagnostics = diagnostics;
            _propertyStack.Clear();
            _currentProperty = null;
            _currentPropertyName = null;
        }

        public MergedDeclaration Declaration
        {
            get { return _declaration; }
        }

        public MutableSymbol Symbol
        {
            get { return _symbol; }
        }

        public SymbolTreeBuilder SymbolTreeBuilder
        {
            get { return _symbolTreeBuilder; }
        }

        public CompilationBase Compilation
        {
            get { return _symbolTreeBuilder.Compilation; }
        }

        public string CurrentPropertyName
        {
            get { return _currentPropertyName; }
        }

        public ModelProperty CurrentProperty
        {
            get { return _currentProperty; }
        }

        protected void BeginProperty(string name)
        {
            this._propertyStack.Add(name);
            this._currentPropertyName = name;
            this._currentProperty = this._symbol.MGetProperty(this._currentPropertyName);
        }

        protected void EndProperty()
        {
            int index = this._propertyStack.Count - 1;
            this._propertyStack.RemoveAt(index);
            --index;
            if (index >= 0)
            {
                this._currentPropertyName = this._propertyStack[index];
                this._currentProperty = this._symbol.MGetProperty(this._currentPropertyName);
            }
            else
            {
                this._currentPropertyName = null;
                this._currentProperty = null;
            }
        }

        protected virtual ImmutableArray<object> Bind(RedNode node)
        {
            var currentDiagnostics = _diagnostics;
            return this.SymbolTreeBuilder.GetBinder(node).Bind(node, currentDiagnostics);
        }

        protected virtual bool CanEnterDeclaration()
        {
            bool result = _canEnterDeclaration;
            _canEnterDeclaration = false;
            return result;
        }

        protected virtual void RegisterValue(RedNode node)
        {
            if (this._symbol != null && this._currentProperty != null)
            {
                if (this._currentProperty.IsCollection)
                {
                    this._symbol.MAddLazy(this._currentProperty, () => this.Bind(node).FirstOrDefault());
                }
                else if (!this._symbol.MIsSet(this._currentProperty))
                {
                    this._symbol.MSetLazy(this._currentProperty, () => this.Bind(node).FirstOrDefault());
                }
            }
        }

        protected virtual void RegisterProperty(string name, object value)
        {
            if (this._symbol != null)
            {
                ModelProperty property = this._symbol.MGetProperty(name);
                if (property != null)
                {
                    if (property.IsCollection)
                    {
                        this._symbol.MAdd(property, value);
                    }
                    else if (!this._symbol.MIsSet(property))
                    {
                        this._symbol.MSet(property, value);
                    }
                }
            }
        }
    }
}
