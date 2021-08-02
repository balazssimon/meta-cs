using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Reflection.Metadata;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or function.
    /// </summary>
    [Symbol]
    public abstract partial class MethodSymbol : BehavioralMemberSymbol
    {
        public virtual bool IsScriptInitializer => false;

        public bool IsEntryPointCandidate { get; internal set; }
        public bool IsGenericMethod { get; internal set; }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitMethod(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMethod(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitMethod(this, argument);
        }

        internal bool IsNullableAnalysisEnabled()
        {
            throw new NotImplementedException();
        }

        internal TypeSymbol GetTypeInferredDuringReduction(TypeParameterSymbol typeParameterSymbol)
        {
            throw new NotImplementedException();
        }

        internal MethodSymbol ReduceExtensionMethod(TypeSymbol typeSymbol, object compilation)
        {
            throw new NotImplementedException();
        }

    }
}
