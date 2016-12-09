using MetaDslx.Compiler.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Syntax
{
    public abstract class SyntaxFacts
    {
        internal static readonly SyntaxFacts Default = new DefaultSyntaxFacts();

        public abstract string GetKindText(int kind);
        public abstract string GetText(int tokenKind);
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
    }
}
