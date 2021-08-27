using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class ImportBinder : Binder, ISymbolBoundary
    {
        private bool _isExtern;
        private bool _isStatic;

        public ImportBinder(Binder next, SyntaxNodeOrToken syntax, bool isExtern, bool isStatic, bool forCompletion) 
            : base(next, syntax, forCompletion)
        {
            _isExtern = isExtern;
            _isStatic = isStatic;
        }

        public bool IsExtern => _isExtern;
        public bool IsStatic => _isStatic;

    }
}
