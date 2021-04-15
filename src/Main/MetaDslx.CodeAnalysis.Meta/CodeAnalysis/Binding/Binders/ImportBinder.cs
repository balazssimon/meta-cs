using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ImportBinder : Binder, ISymbolBoundary
    {
        private bool _isExtern;
        private bool _isStatic;

        public ImportBinder(Binder next, SyntaxNodeOrToken syntax, bool isExtern, bool isStatic) 
            : base(next, syntax)
        {
            _isExtern = isExtern;
            _isStatic = isStatic;
        }

        public bool IsExtern => _isExtern;
        public bool IsStatic => _isStatic;

    }
}
