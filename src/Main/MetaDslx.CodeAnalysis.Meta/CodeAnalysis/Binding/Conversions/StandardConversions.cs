using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardConversions : Conversions
    {
        public StandardConversions(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var srcNullable = false;
            if (source is NullableTypeSymbol srcNts)
            {
                source = srcNts.InnerType;
                srcNullable = true;
            }
            var srcSpecialSymbol = source.GetSpecialSymbol(CSharpLanguage.Instance);
            var srcIndex = -1;
            if (srcSpecialSymbol is SpecialType srcSpecialType)
            {
                srcIndex = SpecialTypeToIndex(srcSpecialType);
            }
            if (srcIndex < 0) return NoConversion;
            var trgNullable = false;
            if (target is NullableTypeSymbol trgNts)
            {
                target = trgNts.InnerType;
                trgNullable = true;
            }
            var trgSpecialSymbol = target.GetSpecialSymbol(CSharpLanguage.Instance);
            var trgIndex = -1;
            if (trgSpecialSymbol is SpecialType trgSpecialType)
            {
                trgIndex = SpecialTypeToIndex(trgSpecialType);
            }
            if (trgIndex < 0) return NoConversion;
            var kind = s_convkind[srcIndex, trgIndex];
            if (!srcNullable && !trgNullable)
            {
                return kind; 
            }
            else if (!srcNullable && trgNullable)
            {
                if (kind == NoConversion) return kind;
                else return kind.IsImplicit ? ImplicitNullable : ExplicitNullable;
            }
            else if (srcNullable && !trgNullable)
            {
                if (kind == NoConversion) return kind;
                else return ExplicitNullable;
            }
            else
            {
                if (kind == NoConversion || kind == Identity) return kind;
                else return kind.IsImplicit ? ImplicitNullable : ExplicitNullable;
            }
        }

        private int SpecialTypeToIndex(SpecialType specialType)
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

        // There are situations in which we know that there is no unusual conversion going on
        // (such as a conversion involving constants, enumerated types, and so on.) In those
        // situations we can classify conversions via a simple table lookup:

        // PERF: Use byte instead of ConversionKind so the compiler can use array literal initialization.
        //       The most natural type choice, Enum arrays, are not blittable due to a CLR limitation.
        private static readonly Conversion[,] s_convkind;
        private const int s_convCount = 17;

        static StandardConversions()
        {
            var NOC = NoConversion;
            var IDN = Identity;
            var IRF = ImplicitReference;
            var XRF = ExplicitReference;
            var XNM = ExplicitNumeric;
            var BOX = Boxing;
            var UNB = Unboxing;
            var NUM = ImplicitNumeric;

            s_convkind = new Conversion[,] {
                    // Converting Y to X:
                    //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                    /*  obj */{ IDN, XRF, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB, UNB },
                    /*  str */{ IRF, IDN, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC },
                    /* bool */{ BOX, NOC, IDN, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC, NOC },
                    /*  chr */{ BOX, NOC, NOC, IDN, XNM, XNM, NUM, NUM, XNM, NUM, NUM, NUM, NUM, NUM, NUM, NUM, NUM },
                    /*  i08 */{ BOX, NOC, NOC, XNM, IDN, NUM, NUM, NUM, XNM, XNM, XNM, XNM, NUM, XNM, NUM, NUM, NUM },
                    /*  i16 */{ BOX, NOC, NOC, XNM, XNM, IDN, NUM, NUM, XNM, XNM, XNM, XNM, NUM, XNM, NUM, NUM, NUM },
                    /*  i32 */{ BOX, NOC, NOC, XNM, XNM, XNM, IDN, NUM, XNM, XNM, XNM, XNM, NUM, XNM, NUM, NUM, NUM },
                    /*  i64 */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, IDN, XNM, XNM, XNM, XNM, XNM, XNM, NUM, NUM, NUM },
                    /*  u08 */{ BOX, NOC, NOC, XNM, XNM, NUM, NUM, NUM, IDN, NUM, NUM, NUM, NUM, NUM, NUM, NUM, NUM },
                    /*  u16 */{ BOX, NOC, NOC, XNM, XNM, XNM, NUM, NUM, XNM, IDN, NUM, NUM, NUM, NUM, NUM, NUM, NUM },
                    /*  u32 */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, NUM, XNM, XNM, IDN, NUM, XNM, NUM, NUM, NUM, NUM },
                    /*  u64 */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, IDN, XNM, XNM, NUM, NUM, NUM },
                    /* nint */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, NUM, XNM, XNM, XNM, XNM, IDN, XNM, NUM, NUM, NUM },
                    /*nuint */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, NUM, XNM, IDN, NUM, NUM, NUM },
                    /*  r32 */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, IDN, NUM, XNM },
                    /*  r64 */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, IDN, XNM },
                    /*  dec */{ BOX, NOC, NOC, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, XNM, IDN },
               };
        }
    }
}
