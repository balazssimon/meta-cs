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
        public bool IsImplicit => _isImplicit;
        public ConversionOperatorSymbol? ConversionOperator => _conversionOperator;
    }
}
