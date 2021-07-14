using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class SymbolCompletionPartAttribute : Attribute
    {
        public SymbolCompletionPartAttribute()
        {
            this.IsLocked = true;
        }

        public bool IsLocked { get; set; }
    }
}
