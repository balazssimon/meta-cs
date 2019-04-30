// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static partial class TypeSymbolExtensions
    {
        static public NamedTypeSymbol AsUnboundGenericType(this NamedTypeSymbol type)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public static bool ImplementsInterface(this TypeSymbol subType, TypeSymbol superInterface, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            foreach (NamedTypeSymbol @interface in subType.AllInterfacesWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics))
            {
                if (@interface.IsInterface && TypeSymbol.Equals(@interface, superInterface, TypeCompareKind.ConsiderEverything2))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanBeAssignedNull(this TypeSymbol type)
        {
            return type.IsReferenceType || type.IsNullableType();
        }

        public static bool CanContainNull(this TypeSymbol type)
        {
            // unbound type parameters might contain null, even though they cannot be *assigned* null.
            return !type.IsValueType || type.IsNullableType();
        }

        public static bool CanBeConst(this TypeSymbol typeSymbol)
        {
            Debug.Assert((object)typeSymbol != null);

            return typeSymbol.IsReferenceType || typeSymbol.IsEnumType() || typeSymbol.SpecialType.CanBeConst();
        }

        public static bool IsNonNullableValueType(this TypeSymbol type)
        {
            return type.IsValueType && !type.IsNullableType();
        }

        public static bool IsNullableType(this TypeSymbol type)
        {
            return type.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T;
        }

        public static TypeSymbol GetNullableUnderlyingType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            Debug.Assert(IsNullableType(type));
            Debug.Assert(type is NamedTypeSymbol);  //not testing Kind because it may be an ErrorType
            // TODO:MetaDslx
            //return ((NamedTypeSymbol)type).TypeArgumentsWithAnnotationsNoUseSiteDiagnostics[0];
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public static TypeSymbol StrippedType(this TypeSymbol type)
        {
            return type.IsNullableType() ? type.GetNullableUnderlyingType() : type;
        }

        public static TypeSymbol TupleUnderlyingTypeOrSelf(this TypeSymbol type)
        {
            return type.TupleUnderlyingType ?? type;
        }

        public static TypeSymbol EnumUnderlyingType(this TypeSymbol type)
        {
            return type.IsEnumType() ? type.GetEnumUnderlyingType() : type;
        }

        public static bool IsObjectType(this TypeSymbol type)
        {
            return type.SpecialType == SpecialType.System_Object;
        }

        public static bool IsStringType(this TypeSymbol type)
        {
            return type.SpecialType == SpecialType.System_String;
        }

        public static bool IsCharType(this TypeSymbol type)
        {
            return type.SpecialType == SpecialType.System_Char;
        }

        public static bool IsIntegralType(this TypeSymbol type)
        {
            return type.SpecialType.IsIntegralType();
        }

        public static NamedTypeSymbol GetEnumUnderlyingType(this TypeSymbol type)
        {
            var namedType = type as NamedTypeSymbol;
            return ((object)namedType != null) ? namedType.EnumUnderlyingType : null;
        }

        public static bool IsEnumType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Enum;
        }

        public static bool IsValidEnumType(this TypeSymbol type)
        {
            var underlyingType = type.GetEnumUnderlyingType();
            // SpecialType will be None if the underlying type is invalid.
            return ((object)underlyingType != null) && (underlyingType.SpecialType != SpecialType.None);
        }

        public static bool IsValidExtensionParameterType(this TypeSymbol type)
        {
            switch (type.TypeKind)
            {
                case TypeKind.Pointer:
                case TypeKind.Dynamic:
                    return false;
                default:
                    return true;
            }
        }

        public static bool IsInterfaceType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.Kind == SymbolKind.NamedType && ((NamedTypeSymbol)type).IsInterface;
        }

        public static bool IsClassType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Class;
        }

        public static bool IsStructType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Struct;
        }

        public static bool IsErrorType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.Kind == SymbolKind.ErrorType;
        }

        public static bool IsDynamic(this TypeSymbol type)
        {
            return type.TypeKind == TypeKind.Dynamic;
        }

        public static bool IsTypeParameter(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.TypeParameter;
        }

        public static bool IsArray(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Array;
        }

        // If the type is a delegate type, it returns it. If the type is an
        // expression tree type associated with a delegate type, it returns
        // the delegate type. Otherwise, null.
        public static NamedTypeSymbol GetDelegateType(this TypeSymbol type)
        {
            if ((object)type == null) return null;
            if (type.IsExpressionTree())
            {
                type = ((NamedTypeSymbol)type).TypeArgumentsWithAnnotationsNoUseSiteDiagnostics[0].Type;
            }

            return type.IsDelegateType() ? (NamedTypeSymbol)type : null;
        }

        /// <summary>
        /// return true if the type is constructed from System.Linq.Expressions.Expression`1
        /// </summary>
        public static bool IsExpressionTree(this TypeSymbol _type)
        {
            return _type.OriginalDefinition is NamedTypeSymbol type &&
                type.Arity == 1 &&
                type.MangleName &&
                type.Name == "Expression" &&
                CheckFullName(type.ContainingSymbol, s_expressionsNamespaceName);
        }


        /// <summary>
        /// return true if the type is constructed from a generic interface that 
        /// might be implemented by an array.
        /// </summary>
        public static bool IsPossibleArrayGenericInterface(this TypeSymbol _type)
        {
            NamedTypeSymbol t = _type as NamedTypeSymbol;
            if ((object)t == null)
            {
                return false;
            }

            t = t.OriginalDefinition;

            SpecialType st = t.SpecialType;

            if (st == SpecialType.System_Collections_Generic_IList_T ||
                st == SpecialType.System_Collections_Generic_ICollection_T ||
                st == SpecialType.System_Collections_Generic_IEnumerable_T ||
                st == SpecialType.System_Collections_Generic_IReadOnlyList_T ||
                st == SpecialType.System_Collections_Generic_IReadOnlyCollection_T)
            {
                return true;
            }

            return false;
        }

        private static readonly string[] s_expressionsNamespaceName = { "Expressions", "Linq", MetadataHelpers.SystemString, "" };

        private static bool CheckFullName(Symbol symbol, string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if ((object)symbol == null || symbol.Name != names[i]) return false;
                symbol = symbol.ContainingSymbol;
            }

            return true;
        }

        public static bool IsDelegateType(this TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            return type.TypeKind == TypeKind.Delegate;
        }

        /// <summary>
        /// Return the default value constant for the given type,
        /// or null if the default value is not a constant.
        /// </summary>
        public static ConstantValue GetDefaultValue(this TypeSymbol type)
        {
            // SPEC:    A default-value-expression is a constant expression (§7.19) if the type
            // SPEC:    is a reference type or a type parameter that is known to be a reference type (§10.1.5). 
            // SPEC:    In addition, a default-value-expression is a constant expression if the type is
            // SPEC:    one of the following value types:
            // SPEC:    sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, bool, or any enumeration type.

            Debug.Assert((object)type != null);

            if (type.IsErrorType())
            {
                return null;
            }

            if (type.IsReferenceType)
            {
                return ConstantValue.Null;
            }

            if (type.IsValueType)
            {
                if (type.IsEnumType())
                {
                    type = type.GetEnumUnderlyingType();
                }

                switch (type.SpecialType)
                {
                    case SpecialType.System_SByte:
                    case SpecialType.System_Byte:
                    case SpecialType.System_Int16:
                    case SpecialType.System_UInt16:
                    case SpecialType.System_Int32:
                    case SpecialType.System_UInt32:
                    case SpecialType.System_Int64:
                    case SpecialType.System_UInt64:
                    case SpecialType.System_Char:
                    case SpecialType.System_Boolean:
                    case SpecialType.System_Single:
                    case SpecialType.System_Double:
                    case SpecialType.System_Decimal:
                        return ConstantValue.Default(type.SpecialType);
                }
            }

            return null;
        }

        public static SpecialType GetSpecialTypeSafe(this TypeSymbol type)
        {
            return (object)type != null ? type.SpecialType : SpecialType.None;
        }

        public static bool IsUnboundGenericType(this TypeSymbol type)
        {
            var namedType = type as NamedTypeSymbol;
            return (object)namedType != null && namedType.IsUnboundGenericType;
        }

        public static bool IsTopLevelType(this NamedTypeSymbol type)
        {
            return (object)type.ContainingType == null;
        }

        /// <summary>
        /// Guess the non-error type that the given type was intended to represent.
        /// If the type itself is not an error type, then it will be returned.
        /// Otherwise, the underlying type (if any) of the error type will be
        /// returned.
        /// </summary>
        /// <remarks>
        /// Any non-null type symbol returned is guaranteed not to be an error type.
        /// 
        /// It is possible to pass in a constructed type and received back an 
        /// unconstructed type.  This can occur when the type passed in was
        /// constructed from an error type - the underlying definition will be
        /// available, but there won't be a good way to "re-substitute" back up
        /// to the level of the specified type.
        /// </remarks>
        internal static TypeSymbol GetNonErrorGuess(this TypeSymbol type)
        {
            var result = ExtendedErrorTypeSymbol.ExtractNonErrorType(type);
            Debug.Assert((object)result == null || !result.IsErrorType());
            return result;
        }

        /// <summary>
        /// Guess the non-error type kind that the given type was intended to represent,
        /// if possible. If not, return TypeKind.Error.
        /// </summary>
        internal static TypeKind GetNonErrorTypeKindGuess(this TypeSymbol type)
        {
            return ExtendedErrorTypeSymbol.ExtractNonErrorTypeKind(type);
        }

        /// <summary>
        /// Returns true if the type was a valid switch expression type in C# 6. We use this test to determine
        /// whether or not we should attempt a user-defined conversion from the type to a C# 6 switch governing
        /// type, which we support for compatibility with C# 6 and earlier.
        /// </summary>
        internal static bool IsValidV6SwitchGoverningType(this TypeSymbol type, bool isTargetTypeOfUserDefinedOp = false)
        {
            // SPEC:    The governing type of a switch statement is established by the switch expression.
            // SPEC:    1) If the type of the switch expression is sbyte, byte, short, ushort, int, uint,
            // SPEC:       long, ulong, bool, char, string, or an enum-type, or if it is the nullable type
            // SPEC:       corresponding to one of these types, then that is the governing type of the switch statement. 
            // SPEC:    2) Otherwise, exactly one user-defined implicit conversion must exist from the
            // SPEC:       type of the switch expression to one of the following possible governing types:
            // SPEC:       sbyte, byte, short, ushort, int, uint, long, ulong, char, string, or, a nullable type
            // SPEC:       corresponding to one of those types

            Debug.Assert((object)type != null);
            if (type.IsNullableType())
            {
                type = type.GetNullableUnderlyingType();
            }

            // User-defined implicit conversion with target type as Enum type is not valid.
            if (!isTargetTypeOfUserDefinedOp && type.IsEnumType())
            {
                type = type.GetEnumUnderlyingType();
            }

            switch (type.SpecialType)
            {
                case SpecialType.System_SByte:
                case SpecialType.System_Byte:
                case SpecialType.System_Int16:
                case SpecialType.System_UInt16:
                case SpecialType.System_Int32:
                case SpecialType.System_UInt32:
                case SpecialType.System_Int64:
                case SpecialType.System_UInt64:
                case SpecialType.System_Char:
                case SpecialType.System_String:
                    return true;

                case SpecialType.System_Boolean:
                    // User-defined implicit conversion with target type as bool type is not valid.
                    return !isTargetTypeOfUserDefinedOp;
            }

            return false;
        }

#pragma warning disable CA1200 // Avoid using cref tags with a prefix
        /// <summary>
        /// Returns true if the type is one of the restricted types, namely: <see cref="T:System.TypedReference"/>, 
        /// <see cref="T:System.ArgIterator"/>, or <see cref="T:System.RuntimeArgumentHandle"/>.
        /// or a ref-like type.
        /// </summary>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
        internal static bool IsRestrictedType(this TypeSymbol type,
                                                bool ignoreSpanLikeTypes = false)
        {
            // See Dev10 C# compiler, "type.cpp", bool Type::isSpecialByRefType() const
            Debug.Assert((object)type != null);
            switch (type.SpecialType)
            {
                case SpecialType.System_TypedReference:
                case SpecialType.System_ArgIterator:
                case SpecialType.System_RuntimeArgumentHandle:
                    return true;
            }

            return ignoreSpanLikeTypes ?
                        false :
                        type.IsRefLikeType;
        }

        public static bool IsIntrinsicType(this TypeSymbol type)
        {
            return type.SpecialType.IsIntrinsicType();
        }

        public static bool IsPartial(this TypeSymbol type)
        {
            var nt = type as SourceNamedTypeSymbol;
            return (object)nt != null && nt.IsPartial;
        }

        internal static int FixedBufferElementSizeInBytes(this TypeSymbol type)
        {
            return type.SpecialType.FixedBufferElementSizeInBytes();
        }

        // check that its type is allowed for Volatile
        internal static bool IsValidVolatileFieldType(this TypeSymbol type)
        {
            switch (type.TypeKind)
            {
                case TypeKind.Struct:
                    return type.SpecialType.IsValidVolatileFieldType();

                case TypeKind.Array:
                case TypeKind.Class:
                case TypeKind.Delegate:
                case TypeKind.Dynamic:
                case TypeKind.Error:
                case TypeKind.Interface:
                case TypeKind.Pointer:
                    return true;

                case TypeKind.Enum:
                    return ((NamedTypeSymbol)type).EnumUnderlyingType.SpecialType.IsValidVolatileFieldType();

                case TypeKind.TypeParameter:
                    return type.IsReferenceType;

                case TypeKind.Submission:
                    throw ExceptionUtilities.UnexpectedValue(type.TypeKind);
            }

            return false;
        }

        /// <summary>
        /// Add this instance to the set of checked types. Returns true
        /// if this was added, false if the type was already in the set.
        /// </summary>
        public static bool MarkCheckedIfNecessary(this TypeSymbol type, ref HashSet<TypeSymbol> checkedTypes)
        {
            if (checkedTypes == null)
            {
                checkedTypes = new HashSet<TypeSymbol>();
            }

            return checkedTypes.Add(type);
        }

        /// <summary>
        /// These special types are structs that contain fields of the same type
        /// (e.g. <see cref="System.Int32"/> contains an instance field of type <see cref="System.Int32"/>).
        /// </summary>
        internal static bool IsPrimitiveRecursiveStruct(this TypeSymbol t)
        {
            return t.SpecialType.IsPrimitiveRecursiveStruct();
        }

        /// <summary>
        /// Compute a hash code for the constructed type. The return value will be
        /// non-zero so callers can used zero to represent an uninitialized value.
        /// </summary>
        internal static int ComputeHashCode(this NamedTypeSymbol type)
        {
            int code = type.OriginalDefinition.GetHashCode();
            code = Hash.Combine(type.ContainingType, code);

            // Unconstructed type may contain alpha-renamed type parameters while
            // may still be considered equal, we do not want to give different hashcode to such types.
            //
            // Example:
            //   Having original type A<U>.B<V> we create two _unconstructed_ types
            //    A<int>.B<V'>
            //    A<int>.B<V">     
            //  Note that V' and V" are type parameters substituted via alpha-renaming of original V
            //  These are different objects, but represent the same "type parameter at index 1"
            //
            //  In short - we are not interested in the type parameters of unconstructed types.
            if ((object)type.ConstructedFrom != (object)type)
            {
                foreach (var arg in type.TypeArgumentsWithAnnotationsNoUseSiteDiagnostics)
                {
                    code = Hash.Combine(arg.Type, code);
                }
            }

            // 0 may be used by the caller to indicate the hashcode is not
            // initialized. If we computed 0 for the hashcode, tweak it.
            if (code == 0)
            {
                code++;
            }
            return code;
        }

        /// <summary>
        /// If we are in a COM PIA with embedInteropTypes enabled we should turn properties and methods 
        /// that have the type and return type of object, respectively, into type dynamic. If the requisite conditions 
        /// are fulfilled, this method returns a dynamic type. If not, it returns the original type.
        /// </summary>
        /// <param name="type">A property type or method return type to be checked for dynamification.</param>
        /// <param name="containingType">Containing type.</param>
        /// <returns></returns>
        public static TypeSymbol AsDynamicIfNoPia(this TypeSymbol type, NamedTypeSymbol containingType)
        {
            return type.TryAsDynamicIfNoPia(containingType, out TypeSymbol result) ? result : type;
        }

        public static bool TryAsDynamicIfNoPia(this TypeSymbol type, NamedTypeSymbol containingType, out TypeSymbol result)
        {
            if (type.SpecialType == SpecialType.System_Object)
            {
                AssemblySymbol assembly = containingType.ContainingAssembly;
                if ((object)assembly != null &&
                    assembly.IsLinked &&
                    containingType.IsComImport)
                {
                    result = DynamicTypeSymbol.Instance;
                    return true;
                }
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Type variables are never considered reference types by the verifier.
        /// </summary>
        internal static bool IsVerifierReference(this TypeSymbol type)
        {
            return type.IsReferenceType && type.TypeKind != TypeKind.TypeParameter;
        }

        /// <summary>
        /// Type variables are never considered value types by the verifier.
        /// </summary>
        internal static bool IsVerifierValue(this TypeSymbol type)
        {
            return type.IsValueType && type.TypeKind != TypeKind.TypeParameter;
        }

        internal static void AddUseSiteDiagnostics(
            this TypeSymbol type,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            DiagnosticInfo errorInfo = type.GetUseSiteDiagnostic();

            if ((object)errorInfo != null)
            {
                if (useSiteDiagnostics == null)
                {
                    useSiteDiagnostics = new HashSet<DiagnosticInfo>();
                }

                useSiteDiagnostics.Add(errorInfo);
            }
        }

        /// <summary>
        /// Return true if the fully qualified name of the type's containing symbol
        /// matches the given name. This method avoids string concatenations
        /// in the common case where the type is a top-level type.
        /// </summary>
        internal static bool HasNameQualifier(this NamedTypeSymbol type, string qualifiedName)
        {
            const StringComparison comparison = StringComparison.Ordinal;

            var container = type.ContainingSymbol;
            if (container.Kind != SymbolKind.Namespace)
            {
                // Nested type. For simplicity, compare qualified name to SymbolDisplay result.
                return string.Equals(container.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat), qualifiedName, comparison);
            }

            var @namespace = (NamespaceSymbol)container;
            if (@namespace.IsGlobalNamespace)
            {
                return qualifiedName.Length == 0;
            }

            return HasNamespaceName(@namespace, qualifiedName, comparison, length: qualifiedName.Length);
        }

        private static bool HasNamespaceName(NamespaceSymbol @namespace, string namespaceName, StringComparison comparison, int length)
        {
            if (length == 0)
            {
                return false;
            }

            var container = @namespace.ContainingNamespace;
            int separator = namespaceName.LastIndexOf('.', length - 1, length);
            int offset = 0;
            if (separator >= 0)
            {
                if (container.IsGlobalNamespace)
                {
                    return false;
                }

                if (!HasNamespaceName(container, namespaceName, comparison, length: separator))
                {
                    return false;
                }

                int n = separator + 1;
                offset = n;
                length -= n;
            }
            else if (!container.IsGlobalNamespace)
            {
                return false;
            }

            var name = @namespace.Name;
            return (name.Length == length) && (string.Compare(name, 0, namespaceName, offset, length, comparison) == 0);
        }

    }
}
