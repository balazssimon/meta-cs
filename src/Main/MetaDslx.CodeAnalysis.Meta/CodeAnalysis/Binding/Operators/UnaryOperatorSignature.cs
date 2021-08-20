// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct UnaryOperatorSignature
    {
        public static UnaryOperatorSignature Error = default(UnaryOperatorSignature);

        public readonly MethodLikeSymbol Method;
        public readonly TypeSymbol OperandType;
        public readonly TypeSymbol ReturnType;
        public readonly UnaryOperatorKind Kind;
        public readonly bool IsLifted;

        public UnaryOperatorSignature(UnaryOperatorKind kind, TypeSymbol operandType, TypeSymbol returnType, bool isLifted = false, MethodLikeSymbol method = null)
        {
            this.Kind = kind;
            this.OperandType = operandType;
            this.ReturnType = returnType;
            this.Method = method;
            this.IsLifted = isLifted;
        }

        public bool IsError => this.Kind is null;

        public UnaryOperatorSignature AsLifted()
        {
            if (this.IsError) return Error;
            else return new UnaryOperatorSignature(Kind, OperandType, ReturnType, true, Method);
        }

        public override string ToString()
        {
            return $"kind: {this.Kind} lifted: {this.IsLifted} operandType: {this.OperandType} operandRefKind: {this.RefKind} return: {this.ReturnType}";
        }

        public RefKind RefKind
        {
            get
            {
                if ((object)Method != null)
                {
                    Debug.Assert(Method.Parameters.Length == 1);
                    if (Method.Parameters.Length == 1)
                    {
                        return Method.Parameters[0].RefKind;
                    }
                }
                return RefKind.None;
            }
        }
    }
}
