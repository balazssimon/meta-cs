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

        internal int DefaultWhitespaceSyntaxKind
        {
            get { return this.DefaultEndOfLineSyntaxKindCore; }
        }

        protected abstract int DefaultWhitespaceSyntaxKindCore
        {
            get;
        }

        internal int DefaultEndOfLineSyntaxKind
        {
            get { return this.DefaultEndOfLineSyntaxKindCore; }
        }

        protected abstract int DefaultEndOfLineSyntaxKindCore
        {
            get;
        }

        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract bool IsToken(int rawKind);
        public abstract bool IsFixedToken(int rawKind);
        public abstract bool IsTriviaWithEndOfLine(int rawKind);

        public virtual bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            return false;
        }
    }

    internal class DefaultSyntaxFacts : SyntaxFacts
    {
        protected override int DefaultWhitespaceSyntaxKindCore
        {
            get
            {
                throw ExceptionUtilities.Unreachable;
            }
        }

        protected override int DefaultEndOfLineSyntaxKindCore
        {
            get
            {
                throw ExceptionUtilities.Unreachable;
            }
        }

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
