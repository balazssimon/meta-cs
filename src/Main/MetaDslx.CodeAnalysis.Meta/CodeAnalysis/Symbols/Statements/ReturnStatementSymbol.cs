using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a return from the method with an optional return value.
    /// </summary>
    [Symbol]
    public abstract partial class ReturnStatementSymbol : StatementSymbol
    {
        private MethodLikeSymbol? _method;

        /// <summary>
        /// Value to be returned.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? ReturnedValue { get; }

        public MethodLikeSymbol Method
        {
            get
            {
                if (_method is null)
                {
                    var method = this.ContainingMember;
                    Interlocked.CompareExchange(ref _method, method, null);
                }
                return _method;
            }
        }

        public TypeSymbol? ReturnType => this.Method?.Result?.Type;

        protected override void CompleteValidatingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            base.CompleteValidatingSymbol(diagnostics, cancellationToken);
            if (this.ReturnType is null)
            {
                if (this.ReturnedValue is not null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_UnexpectedReturnValue.ToDiagnostic(this.GetLocation()));
                }
            }
            else
            {
                if (this.ReturnedValue is null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_ReturnValueExpected.ToDiagnostic(this.GetLocation(), this.ReturnType));
                }
                else
                {
                    ReturnedValue?.CheckExpressionType(this.ReturnType, diagnostics);
                }
            }
        }
    }
}
