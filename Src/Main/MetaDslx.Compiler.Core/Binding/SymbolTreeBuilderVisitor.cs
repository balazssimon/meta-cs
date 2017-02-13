using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class SymbolTreeBuilderVisitor : DetailedSyntaxVisitor
    {
        private SymbolTreeBuilder _symbolBuilder;
        private MutableSymbol _symbol;
        private MergedDeclaration _declaration;
        private List<string> _propertyStack;
        private string _currentProperty;

        public SymbolTreeBuilderVisitor(SymbolTreeBuilder symbolBuilder)
            : base(false, false)
        {
            _symbolBuilder = symbolBuilder;
            _propertyStack = new List<string>();
            _currentProperty = null;
        }

        public virtual void Reset(MutableSymbol symbol, MergedDeclaration declaration)
        {
            _symbol = symbol;
            _declaration = declaration;
            _propertyStack.Clear();
            _currentProperty = null;
        }

        public MergedDeclaration Declaration
        {
            get { return _declaration; }
        }

        public MutableSymbol Symbol
        {
            get { return _symbol; }
        }

        public SymbolTreeBuilder SymbolBuilder
        {
            get { return _symbolBuilder; }
        }

        public CompilationBase Compilation
        {
            get { return _symbolBuilder.Compilation; }
        }

        protected void BeginProperty(string name)
        {
            this._propertyStack.Add(name);
            this._currentProperty = name;
        }

        protected void EndProperty()
        {
            int index = this._propertyStack.Count - 1;
            this._propertyStack.RemoveAt(index);
            --index;
            if (index >= 0)
            {
                this._currentProperty = this._propertyStack[index];
            }
            else
            {
                this._currentProperty = null;
            }
        }

        protected virtual Binder GetBinder(RedNode node)
        {
            return this.SymbolBuilder.GetBinder(node);
        }

    }
}
