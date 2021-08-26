using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaCompletionBinderFactoryVisitor : CompletionBinderFactoryVisitor
    {
        public MetaCompletionBinderFactoryVisitor(BinderFactory binderFactory) 
            : base(binderFactory)
        {
        }
    }
}
