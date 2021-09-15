using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public static class SpecialSymbolExtensions
    {
        public static SpecialSymbol ToSpecialSymbol(this SpecialType specialType)
        {
            switch (specialType)
            {
                case SpecialType.None:
                    return SpecialSymbol.None;
                case SpecialType.System_Object:
                    return SpecialSymbol.System_Object;
                case SpecialType.System_Enum:
                    return SpecialSymbol.System_Enum;
                case SpecialType.System_MulticastDelegate:
                    return SpecialSymbol.System_MulticastDelegate;
                case SpecialType.System_Delegate:
                    return SpecialSymbol.System_Delegate;
                case SpecialType.System_ValueType:
                    return SpecialSymbol.System_ValueType;
                case SpecialType.System_Void:
                    return SpecialSymbol.System_Void;
                case SpecialType.System_Boolean:
                    return SpecialSymbol.System_Boolean;
                case SpecialType.System_Char:
                    return SpecialSymbol.System_Char;
                case SpecialType.System_SByte:
                    return SpecialSymbol.System_SByte;
                case SpecialType.System_Byte:
                    return SpecialSymbol.System_Byte;
                case SpecialType.System_Int16:
                    return SpecialSymbol.System_Int16;
                case SpecialType.System_UInt16:
                    return SpecialSymbol.System_UInt16;
                case SpecialType.System_Int32:
                    return SpecialSymbol.System_Int32;
                case SpecialType.System_UInt32:
                    return SpecialSymbol.System_UInt32;
                case SpecialType.System_Int64:
                    return SpecialSymbol.System_Int64;
                case SpecialType.System_UInt64:
                    return SpecialSymbol.System_UInt64;
                case SpecialType.System_Decimal:
                    return SpecialSymbol.System_Decimal;
                case SpecialType.System_Single:
                    return SpecialSymbol.System_Single;
                case SpecialType.System_Double:
                    return SpecialSymbol.System_Double;
                case SpecialType.System_String:
                    return SpecialSymbol.System_String;
                case SpecialType.System_IntPtr:
                    return SpecialSymbol.System_IntPtr;
                case SpecialType.System_UIntPtr:
                    return SpecialSymbol.System_UIntPtr;
                case SpecialType.System_Array:
                    return SpecialSymbol.System_Array;
                case SpecialType.System_Collections_IEnumerable:
                    return SpecialSymbol.System_Collections_IEnumerable;
                case SpecialType.System_Collections_Generic_IEnumerable_T:
                    return SpecialSymbol.System_Collections_Generic_IEnumerable_T;
                case SpecialType.System_Collections_Generic_IList_T:
                    return SpecialSymbol.System_Collections_Generic_IList_T;
                case SpecialType.System_Collections_Generic_ICollection_T:
                    return SpecialSymbol.System_Collections_Generic_ICollection_T;
                case SpecialType.System_Collections_IEnumerator:
                    return SpecialSymbol.System_Collections_IEnumerator;
                case SpecialType.System_Collections_Generic_IEnumerator_T:
                    return SpecialSymbol.System_Collections_Generic_IEnumerator_T;
                case SpecialType.System_Collections_Generic_IReadOnlyList_T:
                    return SpecialSymbol.System_Collections_Generic_IReadOnlyList_T;
                case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                    return SpecialSymbol.System_Collections_Generic_IReadOnlyCollection_T;
                case SpecialType.System_Nullable_T:
                    return SpecialSymbol.System_Nullable_T;
                case SpecialType.System_DateTime:
                    return SpecialSymbol.System_DateTime;
                case SpecialType.System_Runtime_CompilerServices_IsVolatile:
                    return SpecialSymbol.System_Runtime_CompilerServices_IsVolatile;
                case SpecialType.System_IDisposable:
                    return SpecialSymbol.System_IDisposable;
                case SpecialType.System_TypedReference:
                    return SpecialSymbol.System_TypedReference;
                case SpecialType.System_ArgIterator:
                    return SpecialSymbol.System_ArgIterator;
                case SpecialType.System_RuntimeArgumentHandle:
                    return SpecialSymbol.System_RuntimeArgumentHandle;
                case SpecialType.System_RuntimeFieldHandle:
                    return SpecialSymbol.System_RuntimeFieldHandle;
                case SpecialType.System_RuntimeMethodHandle:
                    return SpecialSymbol.System_RuntimeMethodHandle;
                case SpecialType.System_RuntimeTypeHandle:
                    return SpecialSymbol.System_RuntimeTypeHandle;
                case SpecialType.System_IAsyncResult:
                    return SpecialSymbol.System_IAsyncResult;
                case SpecialType.System_AsyncCallback:
                    return SpecialSymbol.System_AsyncCallback;
                case SpecialType.System_Runtime_CompilerServices_RuntimeFeature:
                    return SpecialSymbol.System_Runtime_CompilerServices_RuntimeFeature;
                case SpecialType.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute:
                    return SpecialSymbol.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute;
                default:
                    return SpecialSymbol.None;
            }
        }

        public static SpecialType ToSpecialType(this SpecialSymbol specialSymbol)
        {
            switch (specialSymbol)
            {
                case SpecialSymbol.None:
                    return SpecialType.None;
                case SpecialSymbol.System_Object:
                    return SpecialType.System_Object;
                case SpecialSymbol.System_Enum:
                    return SpecialType.System_Enum;
                case SpecialSymbol.System_MulticastDelegate:
                    return SpecialType.System_MulticastDelegate;
                case SpecialSymbol.System_Delegate:
                    return SpecialType.System_Delegate;
                case SpecialSymbol.System_ValueType:
                    return SpecialType.System_ValueType;
                case SpecialSymbol.System_Void:
                    return SpecialType.System_Void;
                case SpecialSymbol.System_Boolean:
                    return SpecialType.System_Boolean;
                case SpecialSymbol.System_Char:
                    return SpecialType.System_Char;
                case SpecialSymbol.System_SByte:
                    return SpecialType.System_SByte;
                case SpecialSymbol.System_Byte:
                    return SpecialType.System_Byte;
                case SpecialSymbol.System_Int16:
                    return SpecialType.System_Int16;
                case SpecialSymbol.System_UInt16:
                    return SpecialType.System_UInt16;
                case SpecialSymbol.System_Int32:
                    return SpecialType.System_Int32;
                case SpecialSymbol.System_UInt32:
                    return SpecialType.System_UInt32;
                case SpecialSymbol.System_Int64:
                    return SpecialType.System_Int64;
                case SpecialSymbol.System_UInt64:
                    return SpecialType.System_Int64;
                case SpecialSymbol.System_Decimal:
                    return SpecialType.System_Decimal;
                case SpecialSymbol.System_Single:
                    return SpecialType.System_Single;
                case SpecialSymbol.System_Double:
                    return SpecialType.System_Double;
                case SpecialSymbol.System_String:
                    return SpecialType.System_String;
                case SpecialSymbol.System_IntPtr:
                    return SpecialType.System_IntPtr;
                case SpecialSymbol.System_UIntPtr:
                    return SpecialType.System_UIntPtr;
                case SpecialSymbol.System_Array:
                    return SpecialType.System_Array;
                case SpecialSymbol.System_Collections_IEnumerable:
                    return SpecialType.System_Collections_IEnumerable;
                case SpecialSymbol.System_Collections_Generic_IEnumerable_T:
                    return SpecialType.System_Collections_Generic_IEnumerable_T;
                case SpecialSymbol.System_Collections_Generic_IList_T:
                    return SpecialType.System_Collections_Generic_IList_T;
                case SpecialSymbol.System_Collections_Generic_ICollection_T:
                    return SpecialType.System_Collections_Generic_ICollection_T;
                case SpecialSymbol.System_Collections_IEnumerator:
                    return SpecialType.System_Collections_IEnumerator;
                case SpecialSymbol.System_Collections_Generic_IEnumerator_T:
                    return SpecialType.System_Collections_Generic_IEnumerator_T;
                case SpecialSymbol.System_Collections_Generic_IReadOnlyList_T:
                    return SpecialType.System_Collections_Generic_IReadOnlyList_T;
                case SpecialSymbol.System_Collections_Generic_IReadOnlyCollection_T:
                    return SpecialType.System_Collections_Generic_IReadOnlyCollection_T;
                case SpecialSymbol.System_Nullable_T:
                    return SpecialType.System_Nullable_T;
                case SpecialSymbol.System_DateTime:
                    return SpecialType.System_DateTime;
                case SpecialSymbol.System_Runtime_CompilerServices_IsVolatile:
                    return SpecialType.System_Runtime_CompilerServices_IsVolatile;
                case SpecialSymbol.System_IDisposable:
                    return SpecialType.System_IDisposable;
                case SpecialSymbol.System_TypedReference:
                    return SpecialType.System_TypedReference;
                case SpecialSymbol.System_ArgIterator:
                    return SpecialType.System_ArgIterator;
                case SpecialSymbol.System_RuntimeArgumentHandle:
                    return SpecialType.System_RuntimeArgumentHandle;
                case SpecialSymbol.System_RuntimeFieldHandle:
                    return SpecialType.System_RuntimeFieldHandle;
                case SpecialSymbol.System_RuntimeMethodHandle:
                    return SpecialType.System_RuntimeMethodHandle;
                case SpecialSymbol.System_RuntimeTypeHandle:
                    return SpecialType.System_RuntimeTypeHandle;
                case SpecialSymbol.System_IAsyncResult:
                    return SpecialType.System_IAsyncResult;
                case SpecialSymbol.System_AsyncCallback:
                    return SpecialType.System_AsyncCallback;
                case SpecialSymbol.System_Runtime_CompilerServices_RuntimeFeature:
                    return SpecialType.System_Runtime_CompilerServices_RuntimeFeature;
                case SpecialSymbol.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute:
                    return SpecialType.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute;
                default:
                    return SpecialType.None;
            }
        }

        public static string? GetMetadataName(this SpecialSymbol specialSymbol)
        {
            switch (specialSymbol)
            {
                case SpecialSymbol.None:
                    break;
                case SpecialSymbol.System_Object:
                    return "System.Object";
                case SpecialSymbol.System_Enum:
                    return "System.Enum";
                case SpecialSymbol.System_MulticastDelegate:
                    return "System.MulticastDelegate";
                case SpecialSymbol.System_Delegate:
                    return "System.Delegate";
                case SpecialSymbol.System_ValueType:
                    return "System.ValueType";
                case SpecialSymbol.System_Void:
                    return "System.Void";
                case SpecialSymbol.System_Boolean:
                    return "System.Boolean";
                case SpecialSymbol.System_Char:
                    return "System.Char";
                case SpecialSymbol.System_SByte:
                    return "System.SByte";
                case SpecialSymbol.System_Byte:
                    return "System.Byte";
                case SpecialSymbol.System_Int16:
                    return "System.Int16";
                case SpecialSymbol.System_UInt16:
                    return "System.UInt16";
                case SpecialSymbol.System_Int32:
                    return "System.Int32";
                case SpecialSymbol.System_UInt32:
                    return "System.UInt32";
                case SpecialSymbol.System_Int64:
                    return "System.Int64";
                case SpecialSymbol.System_UInt64:
                    return "System.UInt64";
                case SpecialSymbol.System_Decimal:
                    return "System.Decimal";
                case SpecialSymbol.System_Single:
                    return "System.Single";
                case SpecialSymbol.System_Double:
                    return "System.Double";
                case SpecialSymbol.System_String:
                    return "System.String";
                case SpecialSymbol.System_IntPtr:
                    return "System.IntPtr";
                case SpecialSymbol.System_UIntPtr:
                    return "System.UIntPtr";
                case SpecialSymbol.System_Array:
                    return "System.Array";
                case SpecialSymbol.System_Type:
                    return "System.Type";
                case SpecialSymbol.System_Index:
                    return "System.Index";
                case SpecialSymbol.System_Range:
                    return "System.Range";
                case SpecialSymbol.System_Collections_IEnumerable:
                    return "System.Collections.IEnumerable";
                case SpecialSymbol.System_Collections_Generic_IEnumerable_T:
                    return "System.Collections.Generic.IEnumerable.T";
                case SpecialSymbol.System_Collections_Generic_IList_T:
                    return "System.Collections.Generic.IList.T";
                case SpecialSymbol.System_Collections_Generic_ICollection_T:
                    return "System.Collections.Generic.ICollection.T";
                case SpecialSymbol.System_Collections_IEnumerator:
                    return "System.Collections.IEnumerator";
                case SpecialSymbol.System_Collections_Generic_IEnumerator_T:
                    return "System.Collections.Generic.IEnumerator.T";
                case SpecialSymbol.System_Collections_Generic_IReadOnlyList_T:
                    return "System.Collections.Generic.IReadOnlyList.T";
                case SpecialSymbol.System_Collections_Generic_IReadOnlyCollection_T:
                    return "System.Collections.Generic.IReadOnlyCollection.T";
                case SpecialSymbol.System_Nullable_T:
                    return "System.Nullable.T";
                case SpecialSymbol.System_DateTime:
                    return "System.DateTime";
                case SpecialSymbol.System_Runtime_CompilerServices_IsVolatile:
                    return "System.Runtime.CompilerServices.IsVolatile";
                case SpecialSymbol.System_IDisposable:
                    return "System.IDisposable";
                case SpecialSymbol.System_TypedReference:
                    return "System.TypedReference";
                case SpecialSymbol.System_ArgIterator:
                    return "System.ArgIterator";
                case SpecialSymbol.System_RuntimeArgumentHandle:
                    return "System.RuntimeArgumentHandle";
                case SpecialSymbol.System_RuntimeFieldHandle:
                    return "System.RuntimeFieldHandle";
                case SpecialSymbol.System_RuntimeMethodHandle:
                    return "System.RuntimeMethodHandle";
                case SpecialSymbol.System_RuntimeTypeHandle:
                    return "System.RuntimeTypeHandle";
                case SpecialSymbol.System_IAsyncResult:
                    return "System.IAsyncResult";
                case SpecialSymbol.System_AsyncCallback:
                    return "System.AsyncCallback";
                case SpecialSymbol.System_Runtime_CompilerServices_RuntimeFeature:
                    return "System.Runtime.CompilerServices.RuntimeFeature";
                case SpecialSymbol.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute:
                    return "System.Runtime.CompilerServices.PreserveBaseOverridesAttribute";
                default:
                    break;
            }
            return null;
        }

        // IMPORTANT: make sure to keep the index values in sync with StandardUnaryOperators and StandardBinaryOperators
        public static int TypeToIndex(this SpecialType specialType)
        {
            switch (specialType)
            {
                case SpecialType.None:
                    break;
                case SpecialType.System_Object:
                    return 0;
                case SpecialType.System_Enum:
                    break;
                case SpecialType.System_MulticastDelegate:
                    break;
                case SpecialType.System_Delegate:
                    break;
                case SpecialType.System_ValueType:
                    break;
                case SpecialType.System_Void:
                    break;
                case SpecialType.System_Boolean:
                    return 2;
                case SpecialType.System_Char:
                    return 3;
                case SpecialType.System_SByte:
                    return 4;
                case SpecialType.System_Byte:
                    return 8;
                case SpecialType.System_Int16:
                    return 5;
                case SpecialType.System_UInt16:
                    return 9;
                case SpecialType.System_Int32:
                    return 6;
                case SpecialType.System_UInt32:
                    return 10;
                case SpecialType.System_Int64:
                    return 7;
                case SpecialType.System_UInt64:
                    return 11;
                case SpecialType.System_Decimal:
                    return 16;
                case SpecialType.System_Single:
                    return 14;
                case SpecialType.System_Double:
                    return 15;
                case SpecialType.System_String:
                    return 1;
                case SpecialType.System_IntPtr:
                    break;
                case SpecialType.System_UIntPtr:
                    break;
                default:
                    break;
            }
            return -1;
        }

    }
}
