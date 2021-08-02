using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SymbolAttribute : Attribute
    {
        public SymbolAttribute()
        {
            this.SymbolParts = SymbolParts.All;
            this.ModelObjectOption = ParameterOption.Required;
        }

        public SymbolParts SymbolParts { get; set; }
        public ParameterOption ModelObjectOption { get; set; }
    }
}
