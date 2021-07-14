using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SymbolPropertyAttribute : Attribute
    {
        public SymbolPropertyAttribute()
        {
            CompleteMethodParameters = CompleteMethodParameters.All;
        }

        public CompleteMethodParameters CompleteMethodParameters { get; set; }
    }
}
