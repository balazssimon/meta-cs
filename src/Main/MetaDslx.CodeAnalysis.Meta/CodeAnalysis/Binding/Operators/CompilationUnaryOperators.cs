using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class CompilationUnaryOperators : UnaryOperators
    {
        private UnaryOperators _standardUnaryOperators;
        private UnaryOperators _userDefinedUnaryOperators;

        public CompilationUnaryOperators(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        public UnaryOperators StandardUnaryOperators
        {
            get
            {
                if (_standardUnaryOperators is null)
                {
                    Interlocked.CompareExchange(ref _standardUnaryOperators, Compilation.Language.CompilationFactory.CreateStandardUnaryOperators(Compilation), null);
                }
                return _standardUnaryOperators;
            }
        }

        public UnaryOperators UserDefinedUnaryOperators
        {
            get
            {
                // TODO:MetaDslx see UnaryOperatorOverloadResolution.cs in the Roslyn implementation to load user defined unary operators
                if (_userDefinedUnaryOperators is null)
                {
                    Interlocked.CompareExchange(ref _userDefinedUnaryOperators, Compilation.Language.CompilationFactory.CreateUserDefinedUnaryOperators(Compilation), null);
                }
                return _userDefinedUnaryOperators;
            }
        }

        public override UnaryOperatorSignature ClassifyOperatorByType(UnaryOperatorKind kind, TypeSymbol operand)
        {
            var result = StandardUnaryOperators.ClassifyOperatorByType(kind, operand);
            if (!result.IsError) return result;
            return UserDefinedUnaryOperators.ClassifyOperatorByType(kind, operand);
        }
    }
}
