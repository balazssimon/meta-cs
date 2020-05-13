using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Binding
{ 
    public class DocumentationBinder : CustomBinder
    {
        public DocumentationBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next, syntax)
        {
        }
    }
}
