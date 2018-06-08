using MetaDslx.Compiler.Binding.SymbolBinding;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public abstract class BinderFactoryVisitor : SyntaxVisitor 
    {
        private readonly BinderFactory _binderFactory;
        private int _position;
        private bool _bindChild;
        private ArrayBuilder<Binder> _binders;

        public BinderFactoryVisitor(BinderFactory binderFactory)
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

        public bool BindChild
        {
            get { return _bindChild; }
        }

        internal void Reset(int position, bool bindChild, ArrayBuilder<Binder> binders)
        {
            _position = position;
            _bindChild = bindChild;
            _binders = binders;
        }

        protected void AddBinder(Binder binder)
        {
            _binders.Add(binder);
        }
    }
}
