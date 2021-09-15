using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Specifies the Ids of special runtime symbols.
    /// </summary>
    public enum SpecialSymbol
    {
        /// <summary>
        /// Indicates a non-special type (default value).
        /// </summary>
        None,

        /// <summary>
        /// Indicates that the type is <see cref="object"/>.
        /// </summary>
        System_Object,

        /// <summary>
        /// Indicates that the type is <see cref="Enum"/>.
        /// </summary>
        System_Enum,

        /// <summary>
        /// Indicates that the type is <see cref="MulticastDelegate"/>.
        /// </summary>
        System_MulticastDelegate,

        /// <summary>
        /// Indicates that the type is <see cref="Delegate"/>.
        /// </summary>
        System_Delegate,

        /// <summary>
        /// Indicates that the type is <see cref="ValueType"/>.
        /// </summary>
        System_ValueType,

        /// <summary>
        /// Indicates that the type is <see cref="void"/>.
        /// </summary>
        System_Void,

        /// <summary>
        /// Indicates that the type is <see cref="bool"/>.
        /// </summary>
        System_Boolean,

        /// <summary>
        /// Indicates that the type is <see cref="char"/>.
        /// </summary>
        System_Char,

        /// <summary>
        /// Indicates that the type is <see cref="sbyte"/>.
        /// </summary>
        System_SByte,

        /// <summary>
        /// Indicates that the type is <see cref="byte"/>.
        /// </summary>
        System_Byte,

        /// <summary>
        /// Indicates that the type is <see cref="short"/>.
        /// </summary>
        System_Int16,

        /// <summary>
        /// Indicates that the type is <see cref="ushort"/>.
        /// </summary>
        System_UInt16,

        /// <summary>
        /// Indicates that the type is <see cref="int"/>.
        /// </summary>
        System_Int32,

        /// <summary>
        /// Indicates that the type is <see cref="uint"/>.
        /// </summary>
        System_UInt32,

        /// <summary>
        /// Indicates that the type is <see cref="long"/>.
        /// </summary>
        System_Int64,

        /// <summary>
        /// Indicates that the type is <see cref="ulong"/>.
        /// </summary>
        System_UInt64,

        /// <summary>
        /// Indicates that the type is <see cref="decimal"/>.
        /// </summary>
        System_Decimal,

        /// <summary>
        /// Indicates that the type is <see cref="float"/>.
        /// </summary>
        System_Single,

        /// <summary>
        /// Indicates that the type is <see cref="double"/>.
        /// </summary>
        System_Double,

        /// <summary>
        /// Indicates that the type is <see cref="string"/>.
        /// </summary>
        System_String,

        /// <summary>
        /// Indicates that the type is <see cref="IntPtr" />.
        /// </summary>
        System_IntPtr,

        /// <summary>
        /// Indicates that the type is <see cref="UIntPtr"/>.
        /// </summary>
        System_UIntPtr,

        /// <summary>
        /// Indicates that the type is <see cref="Array"/>.
        /// </summary>
        System_Array,

        /// <summary>
        /// Indicates that the type is <see cref="Type"/>.
        /// </summary>
        System_Type,

        /// <summary>
        /// Indicates that the type is <see cref="Index"/>.
        /// </summary>
        System_Index,

        /// <summary>
        /// Indicates that the type is <see cref="Range"/>.
        /// </summary>
        System_Range,

        /// <summary>
        /// Indicates that the type is <see cref="IEnumerable"/>.
        /// </summary>
        System_Collections_IEnumerable,

        /// <summary>
        /// Indicates that the type is <see cref="IEnumerable{T}"/>.
        /// </summary>
        System_Collections_Generic_IEnumerable_T, // Note: IEnumerable<int> (i.e. constructed type) has no special type

        /// <summary>
        /// Indicates that the type is <see cref="IList{T}"/>.
        /// </summary>
        System_Collections_Generic_IList_T,

        /// <summary>
        /// Indicates that the type is <see cref="ICollection{T}"/>.
        /// </summary>
        System_Collections_Generic_ICollection_T,

        /// <summary>
        /// Indicates that the type is <see cref="IEnumerator"/>.
        /// </summary>
        System_Collections_IEnumerator,

        /// <summary>
        /// Indicates that the type is <see cref="IEnumerator{T}"/>.
        /// </summary>
        System_Collections_Generic_IEnumerator_T,

        /// <summary>
        /// Indicates that the type is <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        System_Collections_Generic_IReadOnlyList_T,

        /// <summary>
        /// Indicates that the type is <see cref="IReadOnlyCollection{T}"/>.
        /// </summary>
        System_Collections_Generic_IReadOnlyCollection_T,

        /// <summary>
        /// Indicates that the type is <see cref="Nullable{T}"/>.
        /// </summary>
        System_Nullable_T,

        /// <summary>
        /// Indicates that the type is <see cref="DateTime"/>.
        /// </summary>
        System_DateTime,

        /// <summary>
        /// Indicates that the type is <see cref="IsVolatile"/>.
        /// </summary>
        System_Runtime_CompilerServices_IsVolatile,

        /// <summary>
        /// Indicates that the type is <see cref="IDisposable"/>.
        /// </summary>
        System_IDisposable,

#pragma warning disable CA1200 // Avoid using cref tags with a prefix
        /// <summary>
        /// Indicates that the type is <see cref="T:System.TypedReference"/>.
        /// </summary>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
        System_TypedReference,

#pragma warning disable CA1200 // Avoid using cref tags with a prefix
        /// <summary>
        /// Indicates that the type is <see cref="T:System.ArgIterator"/>.
        /// </summary>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
        System_ArgIterator,

#pragma warning disable CA1200 // Avoid using cref tags with a prefix
        /// <summary>
        /// Indicates that the type is <see cref="T:System.RuntimeArgumentHandle"/>.
        /// </summary>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
        System_RuntimeArgumentHandle,

        /// <summary>
        /// Indicates that the type is <see cref="RuntimeFieldHandle"/>.
        /// </summary>
        System_RuntimeFieldHandle,

        /// <summary>
        /// Indicates that the type is <see cref="RuntimeMethodHandle"/>.
        /// </summary>
        System_RuntimeMethodHandle,

        /// <summary>
        /// Indicates that the type is <see cref="RuntimeTypeHandle"/>.
        /// </summary>
        System_RuntimeTypeHandle,

        /// <summary>
        /// Indicates that the type is <see cref="IAsyncResult"/>.
        /// </summary>
        System_IAsyncResult,

        /// <summary>
        /// Indicates that the type is <see cref="AsyncCallback"/>.
        /// </summary>
        System_AsyncCallback,

        /// <summary>
        /// Indicates that the type is System.Runtime.CompilerServices.RuntimeFeature.
        /// </summary>
        System_Runtime_CompilerServices_RuntimeFeature,

        /// <summary>
        /// An attribute that is placed on each method with a 'methodimpl" aka ".override" in metadata.
        /// </summary>
        System_Runtime_CompilerServices_PreserveBaseOverridesAttribute,

    }
}
