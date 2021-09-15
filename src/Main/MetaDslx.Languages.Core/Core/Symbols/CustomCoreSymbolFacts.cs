using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Core.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class CustomCoreSymbolFacts : CoreSymbolFacts
    {
        private ImmutableArray<object> _specialModelObjects;

        public override ImmutableArray<object> SpecialSymbols
        {
            get
            {
                if (_specialModelObjects.IsDefault)
                {
                    var objects = ArrayBuilder<object>.GetInstance();
                    objects.Add(SpecialSymbol.System_Object);
                    objects.Add(SpecialSymbol.System_Void);
                    objects.Add(SpecialSymbol.System_Boolean);
                    objects.Add(SpecialSymbol.System_Char);
                    objects.Add(SpecialSymbol.System_SByte);
                    objects.Add(SpecialSymbol.System_Byte);
                    objects.Add(SpecialSymbol.System_Int16);
                    objects.Add(SpecialSymbol.System_UInt16);
                    objects.Add(SpecialSymbol.System_Int32);
                    objects.Add(SpecialSymbol.System_UInt32);
                    objects.Add(SpecialSymbol.System_Int64);
                    objects.Add(SpecialSymbol.System_UInt64);
                    objects.Add(SpecialSymbol.System_Decimal);
                    objects.Add(SpecialSymbol.System_Single);
                    objects.Add(SpecialSymbol.System_Double);
                    objects.Add(SpecialSymbol.System_String);
                    objects.Add(SpecialSymbol.System_Enum);
                    objects.Add(SpecialSymbol.System_Type);
                    objects.Add(SpecialSymbol.System_Index);
                    objects.Add(SpecialSymbol.System_Range);
                    ImmutableInterlocked.InterlockedInitialize(ref _specialModelObjects, objects.ToImmutableAndFree());
                }
                return _specialModelObjects;
            }
        }

        public override string? GetMetadataNameOfSpecialSymbol(object specialSymbol)
        {
            if (specialSymbol is SpecialSymbol ss) return ss.GetMetadataName();
            if (ReferenceEquals(specialSymbol, CoreInstance.SystemType)) return "System.Type";
            return null;
        }

        public override object? GetModelObjectOfSpecialSymbol(object specialSymbol)
        {
            if (specialSymbol is SpecialSymbol ss)
            {
                switch (ss)
                {
                    case SpecialSymbol.None:
                        break;
                    case SpecialSymbol.System_Object:
                        return CoreInstance.Object;
                    case SpecialSymbol.System_Enum:
                        return CoreInstance.SystemEnum;
                    case SpecialSymbol.System_MulticastDelegate:
                        break;
                    case SpecialSymbol.System_Delegate:
                        break;
                    case SpecialSymbol.System_ValueType:
                        break;
                    case SpecialSymbol.System_Void:
                        return CoreInstance.Void;
                    case SpecialSymbol.System_Boolean:
                        return CoreInstance.Boolean;
                    case SpecialSymbol.System_Char:
                        return CoreInstance.Char;
                    case SpecialSymbol.System_SByte:
                        return CoreInstance.SByte;
                    case SpecialSymbol.System_Byte:
                        return CoreInstance.Byte;
                    case SpecialSymbol.System_Int16:
                        return CoreInstance.Int16;
                    case SpecialSymbol.System_UInt16:
                        return CoreInstance.UInt16;
                    case SpecialSymbol.System_Int32:
                        return CoreInstance.Int32;
                    case SpecialSymbol.System_UInt32:
                        return CoreInstance.UInt32;
                    case SpecialSymbol.System_Int64:
                        return CoreInstance.Int64;
                    case SpecialSymbol.System_UInt64:
                        return CoreInstance.UInt64;
                    case SpecialSymbol.System_Decimal:
                        return CoreInstance.Decimal;
                    case SpecialSymbol.System_Single:
                        return CoreInstance.Single;
                    case SpecialSymbol.System_Double:
                        return CoreInstance.Double;
                    case SpecialSymbol.System_String:
                        return CoreInstance.String;
                    case SpecialSymbol.System_Type:
                        return CoreInstance.SystemType;
                    case SpecialSymbol.System_Range:
                        return CoreInstance.SystemRange;
                    case SpecialSymbol.System_Index:
                        return CoreInstance.SystemIndex;
                    case SpecialSymbol.System_IntPtr:
                        break;
                    case SpecialSymbol.System_UIntPtr:
                        break;
                    case SpecialSymbol.System_Array:
                        break;
                    case SpecialSymbol.System_Collections_IEnumerable:
                        break;
                    case SpecialSymbol.System_Collections_Generic_IEnumerable_T:
                        break;
                    case SpecialSymbol.System_Collections_Generic_IList_T:
                        break;
                    case SpecialSymbol.System_Collections_Generic_ICollection_T:
                        break;
                    case SpecialSymbol.System_Collections_IEnumerator:
                        break;
                    case SpecialSymbol.System_Collections_Generic_IEnumerator_T:
                        break;
                    case SpecialSymbol.System_Collections_Generic_IReadOnlyList_T:
                        break;
                    case SpecialSymbol.System_Collections_Generic_IReadOnlyCollection_T:
                        break;
                    case SpecialSymbol.System_Nullable_T:
                        break;
                    case SpecialSymbol.System_DateTime:
                        break;
                    case SpecialSymbol.System_Runtime_CompilerServices_IsVolatile:
                        break;
                    case SpecialSymbol.System_IDisposable:
                        break;
                    case SpecialSymbol.System_TypedReference:
                        break;
                    case SpecialSymbol.System_ArgIterator:
                        break;
                    case SpecialSymbol.System_RuntimeArgumentHandle:
                        break;
                    case SpecialSymbol.System_RuntimeFieldHandle:
                        break;
                    case SpecialSymbol.System_RuntimeMethodHandle:
                        break;
                    case SpecialSymbol.System_RuntimeTypeHandle:
                        break;
                    case SpecialSymbol.System_IAsyncResult:
                        break;
                    case SpecialSymbol.System_AsyncCallback:
                        break;
                    case SpecialSymbol.System_Runtime_CompilerServices_RuntimeFeature:
                        break;
                    case SpecialSymbol.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute:
                        break;
                    default:
                        break;
                }
            }
            if (ReferenceEquals(specialSymbol, CoreInstance.SystemType)) return specialSymbol;
            return null;
        }

    }
}
