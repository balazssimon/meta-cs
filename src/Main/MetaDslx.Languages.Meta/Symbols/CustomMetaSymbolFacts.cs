using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class CustomMetaSymbolFacts : MetaSymbolFacts
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
                    objects.Add(SpecialSymbol.System_String);
                    objects.Add(SpecialSymbol.System_Int32);
                    objects.Add(SpecialSymbol.System_Int64);
                    objects.Add(SpecialSymbol.System_Single);
                    objects.Add(SpecialSymbol.System_Double);
                    objects.Add(SpecialSymbol.System_Byte);
                    objects.Add(SpecialSymbol.System_Boolean);
                    objects.Add(SpecialSymbol.System_Void);
                    objects.Add(MetaInstance.ModelObject);
                    ImmutableInterlocked.InterlockedInitialize(ref _specialModelObjects, objects.ToImmutableAndFree());
                }
                return _specialModelObjects;
            }
        }

        public override string? GetMetadataNameOfSpecialSymbol(object specialSymbol)
        {
            if (specialSymbol is SpecialSymbol st) return st.GetMetadataName();
            if (ReferenceEquals(specialSymbol, MetaInstance.ModelObject)) return "MetaDslx.Modeling.IModelObject";
            return null;
        }

        public override object? GetModelObjectOfSpecialSymbol(object specialSymbol)
        {
            if (specialSymbol is SpecialSymbol st)
            {
                switch (st)
                {
                    case SpecialSymbol.None:
                        break;
                    case SpecialSymbol.System_Object:
                        return MetaInstance.Object;
                    case SpecialSymbol.System_Enum:
                        break;
                    case SpecialSymbol.System_MulticastDelegate:
                        break;
                    case SpecialSymbol.System_Delegate:
                        break;
                    case SpecialSymbol.System_ValueType:
                        break;
                    case SpecialSymbol.System_Void:
                        return MetaInstance.Void;
                    case SpecialSymbol.System_Boolean:
                        return MetaInstance.Bool;
                    case SpecialSymbol.System_Char:
                        break;
                    case SpecialSymbol.System_SByte:
                        break;
                    case SpecialSymbol.System_Byte:
                        return MetaInstance.Byte;
                    case SpecialSymbol.System_Int16:
                        break;
                    case SpecialSymbol.System_UInt16:
                        break;
                    case SpecialSymbol.System_Int32:
                        return MetaInstance.Int;
                    case SpecialSymbol.System_UInt32:
                        break;
                    case SpecialSymbol.System_Int64:
                        return MetaInstance.Long;
                    case SpecialSymbol.System_UInt64:
                        break;
                    case SpecialSymbol.System_Decimal:
                        break;
                    case SpecialSymbol.System_Single:
                        return MetaInstance.Float;
                    case SpecialSymbol.System_Double:
                        return MetaInstance.Double;
                    case SpecialSymbol.System_String:
                        return MetaInstance.String;
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
            if (ReferenceEquals(specialSymbol, MetaInstance.ModelObject)) return specialSymbol;
            return null;
        }

    }
}
