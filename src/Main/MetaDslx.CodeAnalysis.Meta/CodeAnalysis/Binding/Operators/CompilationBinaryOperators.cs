using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class CompilationBinaryOperators : BinaryOperators
    {
        private BinaryOperators _standardBinaryOperators;
        private BinaryOperators _userDefinedBinaryOperators;

        public CompilationBinaryOperators(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        public BinaryOperators StandardBinaryOperators
        {
            get
            {
                if (_standardBinaryOperators is null)
                {
                    Interlocked.CompareExchange(ref _standardBinaryOperators, Compilation.Language.CompilationFactory.CreateStandardBinaryOperators(Compilation), null);
                }
                return _standardBinaryOperators;
            }
        }

        public BinaryOperators UserDefinedBinaryOperators
        {
            get
            {
                if (_userDefinedBinaryOperators is null)
                {
                    Interlocked.CompareExchange(ref _userDefinedBinaryOperators, Compilation.Language.CompilationFactory.CreateUserDefinedBinaryOperators(Compilation), null);
                }
                return _userDefinedBinaryOperators;
            }
        }

        public override BinaryOperatorSignature ClassifyOperatorByType(BinaryOperatorKind kind, TypeSymbol left, TypeSymbol right)
        {
            var result = StandardBinaryOperators.ClassifyOperatorByType(kind, left, right);
            if (!result.IsError) return result;
            return UserDefinedBinaryOperators.ClassifyOperatorByType(kind, left, right);
        }
    }
}
