using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class TypeConversion : Conversion
    {
        private TypeSymbol _source;
        private TypeSymbol _target;
        private bool _isImplicit;
        private ConversionOperatorSymbol? _conversionOperator;

        public TypeConversion(TypeSymbol source, TypeSymbol target, bool isImplicit, ConversionOperatorSymbol? conversionOperator)
        {
            _source = source;
            _target = target;
            _isImplicit = isImplicit;
            _conversionOperator = conversionOperator;
        }

        public TypeSymbol Source => _source;
        public TypeSymbol Target => _target;
        public override bool IsImplicit => _isImplicit;
        public override ConversionOperatorSymbol? ConversionOperator => _conversionOperator;
    }
}
