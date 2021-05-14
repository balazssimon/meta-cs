using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class State
    {
        private int _hashCode;

        public State(int hashCode)
        {
            _hashCode = hashCode;
        }

        public sealed override int GetHashCode()
        {
            return _hashCode;
        }
    }
}
