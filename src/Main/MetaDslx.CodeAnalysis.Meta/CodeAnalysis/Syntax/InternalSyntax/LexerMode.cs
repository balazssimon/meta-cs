using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class LexerMode : IEquatable<LexerMode>
    {
        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == this.GetType();
        }

        public bool Equals(LexerMode other)
        {
            return this.Equals((object)other);
        }

        public static bool SameMode(LexerMode first, LexerMode second)
        {
            if (first == null && second == null) return true;
            if (first != null) return first.Equals(second);
            else return second.Equals(first);
        }
    }
}
