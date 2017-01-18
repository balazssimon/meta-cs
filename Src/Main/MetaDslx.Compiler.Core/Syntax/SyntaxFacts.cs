using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxFacts
    {
        internal static readonly SyntaxFacts Default = new DefaultSyntaxFacts();

        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract bool IsToken(int rawKind);
        public abstract bool IsFixedToken(int rawKind);
        public abstract bool IsTriviaWithEndOfLine(int rawKind);
    }

    internal class DefaultSyntaxFacts : SyntaxFacts
    {
        public override string GetKindText(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override string GetText(int tokenKind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override bool IsToken(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override bool IsFixedToken(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override bool IsTriviaWithEndOfLine(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
