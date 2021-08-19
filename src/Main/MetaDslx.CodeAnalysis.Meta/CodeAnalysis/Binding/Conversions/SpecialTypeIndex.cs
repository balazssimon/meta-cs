using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal static class SpecialTypeIndex
    {
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
