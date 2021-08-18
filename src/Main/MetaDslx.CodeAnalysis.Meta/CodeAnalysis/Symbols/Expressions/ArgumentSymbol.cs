using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an argument to a method invocation.
    /// </summary>
    [Symbol]
    public abstract partial class ArgumentSymbol : NonDeclaredSymbol
    {
        /// <summary>
        /// Value supplied for the argument.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Value { get; }

        /// <summary>
        /// Optional name of the parameter.
        /// </summary>
        [SymbolProperty]
        public virtual RefKind RefKind { get; }

        /// <summary>
        /// Parameter the argument matches. This can be null for __arglist parameters.
        /// </summary>
        public virtual ParameterSymbol? Parameter { get; }

        /// <summary>
        /// Information of the conversion applied to the argument value passing it into the target method. Applicable only to VB Reference arguments.
        /// </summary>
        public virtual Conversion InConversion { get; }

        /// <summary>
        /// Information of the conversion applied to the argument value after the invocation. Applicable only to VB Reference arguments.
        /// </summary>
        public virtual Conversion OutConversion { get; }

        public object Display
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Name)) return this.Name;
                if (this.Parameter is not null)
                {
                    if (!string.IsNullOrEmpty(this.Parameter.Name)) return this.Parameter.Name;
                    if (this.Parameter.Type is not null) return this.Parameter.Type;
                }
                return string.Empty;
            }
        }
    }
}
