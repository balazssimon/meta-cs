using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PhaseAttribute : Attribute
    {
        public PhaseAttribute()
        {
        }

        public bool Locked { get; set; }
        public CompletionPart Before { get; set; }
        public CompletionPart After { get; set; }
    }
}
