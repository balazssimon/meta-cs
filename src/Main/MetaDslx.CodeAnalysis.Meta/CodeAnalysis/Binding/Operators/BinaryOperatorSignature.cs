// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct BinaryOperatorSignature : IEquatable<BinaryOperatorSignature>
    {
        public static BinaryOperatorSignature Error = default(BinaryOperatorSignature);

        public readonly TypeSymbol LeftType;
        public readonly TypeSymbol RightType;
        public readonly TypeSymbol ReturnType;
        public readonly MethodLikeSymbol Method;
        public readonly BinaryOperatorKind Kind;
        public readonly bool IsLifted;

        public BinaryOperatorSignature(BinaryOperatorKind kind, TypeSymbol leftType, TypeSymbol rightType, TypeSymbol returnType, bool isLifted = false, MethodLikeSymbol method = null)
        {
            this.Kind = kind;
            this.LeftType = leftType;
            this.RightType = rightType;
            this.ReturnType = returnType;
            this.Method = method;
            this.IsLifted = isLifted;
        }

        public bool IsError => this.Kind is null;

        public BinaryOperatorSignature AsLifted()
        {
            if (this.IsError) return Error;
            else return new BinaryOperatorSignature(Kind, LeftType, RightType, ReturnType, IsLifted, Method);
        }

        public override string ToString()
        {
            return $"kind: {this.Kind} lifted: {this.IsLifted} leftType: {this.LeftType} leftRefKind: {this.LeftRefKind} rightType: {this.RightType} rightRefKind: {this.RightRefKind} return: {this.ReturnType}";
        }

        public bool Equals(BinaryOperatorSignature other)
        {
            return
                this.Kind == other.Kind &&
                TypeSymbol.Equals(this.LeftType, other.LeftType, TypeCompareKind.ConsiderEverything2) &&
                TypeSymbol.Equals(this.RightType, other.RightType, TypeCompareKind.ConsiderEverything2) &&
                TypeSymbol.Equals(this.ReturnType, other.ReturnType, TypeCompareKind.ConsiderEverything2) &&
                this.Method == other.Method;
        }

        public static bool operator ==(BinaryOperatorSignature x, BinaryOperatorSignature y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(BinaryOperatorSignature x, BinaryOperatorSignature y)
        {
            return !x.Equals(y);
        }

        public override bool Equals(object obj)
        {
            return obj is BinaryOperatorSignature && Equals((BinaryOperatorSignature)obj);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(ReturnType,
                   Hash.Combine(LeftType,
                   Hash.Combine(RightType,
                   Hash.Combine(Method,
                   Hash.Combine(Kind, IsLifted.GetHashCode())))));
        }

        public RefKind LeftRefKind
        {
            get
            {
                if ((object)Method != null)
                {
                    Debug.Assert(Method.Parameters.Length == 2);
                    if (Method.Parameters.Length == 2)
                    {
                        return Method.Parameters[0].RefKind;
                    }
                }
                return RefKind.None;
            }
        }

        public RefKind RightRefKind
        {
            get
            {
                if ((object)Method != null)
                {
                    Debug.Assert(Method.Parameters.Length == 2);
                    if (Method.Parameters.Length == 2)
                    {
                        return Method.Parameters[1].RefKind;
                    }
                }
                return RefKind.None;
            }
        }
    }
}
