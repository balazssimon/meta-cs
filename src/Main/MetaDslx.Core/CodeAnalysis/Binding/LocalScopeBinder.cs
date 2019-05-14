using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LocalScopeBinder : Binder
    {
        public LocalScopeBinder(Binder next)
            : base(next)
        {

        }
    }
}
