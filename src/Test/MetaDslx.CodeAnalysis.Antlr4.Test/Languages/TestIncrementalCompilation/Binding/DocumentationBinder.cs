using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Binding
{
    public class DocumentationBinder : Binder
    {
        public DocumentationBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

    }
}
