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

        public override ImmutableArray<object> SpecialTypes
        {
            get
            {
                if (_specialModelObjects.IsDefault)
                {
                    var objects = ArrayBuilder<object>.GetInstance();
                    objects.Add(SpecialType.System_Object);
                    objects.Add(SpecialType.System_String);
                    objects.Add(SpecialType.System_Int32);
                    objects.Add(SpecialType.System_Int64);
                    objects.Add(SpecialType.System_Single);
                    objects.Add(SpecialType.System_Double);
                    objects.Add(SpecialType.System_Byte);
                    objects.Add(SpecialType.System_Boolean);
                    objects.Add(SpecialType.System_Void);
                    objects.Add(MetaInstance.ModelObject);
                    ImmutableInterlocked.InterlockedInitialize(ref _specialModelObjects, objects.ToImmutableAndFree());
                }
                return _specialModelObjects;
            }
        }

        public override string? GetSpecialSymbolMetadataName(object specialSymbol)
        {
            if (specialSymbol is SpecialType st) return st.GetMetadataName();
            if (ReferenceEquals(specialSymbol, MetaInstance.ModelObject)) return "MetaDslx.Modeling.IModelObject";
            return null;
        }

        public override object? GetSpecialModelObject(object specialSymbol)
        {
            if (specialSymbol is SpecialType st)
            {
                switch (st)
                {
                    case SpecialType.None:
                        break;
                    case SpecialType.System_Object:
                        return MetaInstance.Object;
                    case SpecialType.System_Enum:
                        break;
                    case SpecialType.System_MulticastDelegate:
                        break;
                    case SpecialType.System_Delegate:
                        break;
                    case SpecialType.System_ValueType:
                        break;
                    case SpecialType.System_Void:
                        return MetaInstance.Void;
                    case SpecialType.System_Boolean:
                        return MetaInstance.Bool;
                    case SpecialType.System_Char:
                        break;
                    case SpecialType.System_SByte:
                        break;
                    case SpecialType.System_Byte:
                        return MetaInstance.Byte;
                    case SpecialType.System_Int16:
                        break;
                    case SpecialType.System_UInt16:
                        break;
                    case SpecialType.System_Int32:
                        return MetaInstance.Int;
                    case SpecialType.System_UInt32:
                        break;
                    case SpecialType.System_Int64:
                        return MetaInstance.Long;
                    case SpecialType.System_UInt64:
                        break;
                    case SpecialType.System_Decimal:
                        break;
                    case SpecialType.System_Single:
                        return MetaInstance.Float;
                    case SpecialType.System_Double:
                        return MetaInstance.Double;
                    case SpecialType.System_String:
                        return MetaInstance.String;
                    case SpecialType.System_IntPtr:
                        break;
                    case SpecialType.System_UIntPtr:
                        break;
                    case SpecialType.System_Array:
                        break;
                    case SpecialType.System_Collections_IEnumerable:
                        break;
                    case SpecialType.System_Collections_Generic_IEnumerable_T:
                        break;
                    case SpecialType.System_Collections_Generic_IList_T:
                        break;
                    case SpecialType.System_Collections_Generic_ICollection_T:
                        break;
                    case SpecialType.System_Collections_IEnumerator:
                        break;
                    case SpecialType.System_Collections_Generic_IEnumerator_T:
                        break;
                    case SpecialType.System_Collections_Generic_IReadOnlyList_T:
                        break;
                    case SpecialType.System_Collections_Generic_IReadOnlyCollection_T:
                        break;
                    case SpecialType.System_Nullable_T:
                        break;
                    case SpecialType.System_DateTime:
                        break;
                    case SpecialType.System_Runtime_CompilerServices_IsVolatile:
                        break;
                    case SpecialType.System_IDisposable:
                        break;
                    case SpecialType.System_TypedReference:
                        break;
                    case SpecialType.System_ArgIterator:
                        break;
                    case SpecialType.System_RuntimeArgumentHandle:
                        break;
                    case SpecialType.System_RuntimeFieldHandle:
                        break;
                    case SpecialType.System_RuntimeMethodHandle:
                        break;
                    case SpecialType.System_RuntimeTypeHandle:
                        break;
                    case SpecialType.System_IAsyncResult:
                        break;
                    case SpecialType.System_AsyncCallback:
                        break;
                    case SpecialType.System_Runtime_CompilerServices_RuntimeFeature:
                        break;
                    case SpecialType.System_Runtime_CompilerServices_PreserveBaseOverridesAttribute:
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
