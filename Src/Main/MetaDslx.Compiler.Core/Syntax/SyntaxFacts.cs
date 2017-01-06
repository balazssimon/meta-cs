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

        internal protected abstract string GetKindText(int rawKind);
        internal protected abstract string GetText(int rawKind);
        internal protected abstract bool IsToken(int rawKind);
        internal protected abstract bool IsFixedToken(int rawKind);
        internal protected abstract bool IsTriviaWithEndOfLine(int rawKind);
    }

    internal class DefaultSyntaxFacts : SyntaxFacts
    {
        internal protected override string GetKindText(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override string GetText(int tokenKind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override bool IsToken(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override bool IsFixedToken(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal protected override bool IsTriviaWithEndOfLine(int kind)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
