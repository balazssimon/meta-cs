using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class CompilationConversions : Conversions
    {
        private Conversions _standardConversions;
        private Conversions _userDefinedConversions;

        public CompilationConversions(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public Conversions StandardConversions
        {
            get
            {
                if (_standardConversions is null)
                {
                    Interlocked.CompareExchange(ref _standardConversions, Compilation.Language.CompilationFactory.CreateStandardConversions(Compilation), null);
                }
                return _standardConversions;
            }
        }

        public Conversions UserDefinedConversions
        {
            get
            {
                if (_userDefinedConversions is null)
                {
                    Interlocked.CompareExchange(ref _userDefinedConversions, Compilation.Language.CompilationFactory.CreateUserDefinedConversions(Compilation), null);
                }
                return _userDefinedConversions;
            }
        }

        public override Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var kind = StandardConversions.ClassifyConversionFromType(source, target, ref useSiteDiagnostics);
            if (kind != UnsetConversion) return kind;
            kind = UserDefinedConversions.ClassifyConversionFromType(source, target, ref useSiteDiagnostics);
            if (kind != UnsetConversion) return kind;
            else return NoConversion;
        }

        public override Conversion ClassifyConversionFromExpression(ExpressionSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var kind = StandardConversions.ClassifyConversionFromExpression(source, target, ref useSiteDiagnostics);
            if (kind != UnsetConversion) return kind;
            kind = UserDefinedConversions.ClassifyConversionFromExpression(source, target, ref useSiteDiagnostics);
            if (kind != UnsetConversion) return kind;
            if (source.Type is null) return NoConversion;
            kind = ClassifyConversionFromType(source.Type, target, ref useSiteDiagnostics);
            if (kind != UnsetConversion) return kind;
            else return NoConversion;
        }
    }
}
