﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// Manages anonymous types created in owning compilation. All requests for 
    /// anonymous type symbols go via the instance of this class.
    /// </summary>
    public class AnonymousTypeManager
    {
        private CompilationBase _compilation;

        public AnonymousTypeManager(CompilationBase compilation)
        {
            _compilation = compilation;
        }

        public CompilationBase Compilation
        {
            get { return _compilation; }
        }
    }
}