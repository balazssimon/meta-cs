using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardBinaryOperators : BinaryOperators
    {
        private TypeSymbol ERR = null;
        private TypeSymbol OBJ;
        private TypeSymbol STR;
        private TypeSymbol BOL;
        private TypeSymbol CHR;
        private TypeSymbol I08;
        private TypeSymbol U08;
        private TypeSymbol I16;
        private TypeSymbol U16;
        private TypeSymbol I32;
        private TypeSymbol U32;
        private TypeSymbol I64;
        private TypeSymbol U64;
        private TypeSymbol NIN;
        private TypeSymbol NUI;
        private TypeSymbol R32;
        private TypeSymbol R64;
        private TypeSymbol DEC;

        private TypeSymbol INT;
        private TypeSymbol LNG;
        private TypeSymbol UIN;
        private TypeSymbol ULG;
        private TypeSymbol FLT;
        private TypeSymbol DBL;

        private TypeSymbol SOC = null;
        private TypeSymbol OSC = null;

        private TypeSymbol[] _types;
        private BinaryOperatorSignature[][,] _table;
        private BinaryOperatorSignature[][,] _liftedTable;

        public StandardBinaryOperators(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        protected virtual void ComputeTable()
        {
            Interlocked.CompareExchange(ref _table, CreateTable(), null);
            Interlocked.CompareExchange(ref _liftedTable, CreateLiftedTable(), null);
        }

        private void CreateSpecialTypes()
        {
            Interlocked.CompareExchange(ref OBJ, Compilation.GetSpecialType(SpecialType.System_Object), null);
            Interlocked.CompareExchange(ref STR, Compilation.GetSpecialType(SpecialType.System_String), null);
            Interlocked.CompareExchange(ref BOL, Compilation.GetSpecialType(SpecialType.System_Boolean), null);
            Interlocked.CompareExchange(ref CHR, Compilation.GetSpecialType(SpecialType.System_Char), null);
            Interlocked.CompareExchange(ref I08, Compilation.GetSpecialType(SpecialType.System_SByte), null);
            Interlocked.CompareExchange(ref I16, Compilation.GetSpecialType(SpecialType.System_Int16), null);
            Interlocked.CompareExchange(ref I32, Compilation.GetSpecialType(SpecialType.System_Int32), null);
            Interlocked.CompareExchange(ref I64, Compilation.GetSpecialType(SpecialType.System_Int64), null);
            Interlocked.CompareExchange(ref U08, Compilation.GetSpecialType(SpecialType.System_Byte), null);
            Interlocked.CompareExchange(ref U16, Compilation.GetSpecialType(SpecialType.System_UInt16), null);
            Interlocked.CompareExchange(ref U32, Compilation.GetSpecialType(SpecialType.System_UInt32), null);
            Interlocked.CompareExchange(ref U64, Compilation.GetSpecialType(SpecialType.System_UInt64), null);
            Interlocked.CompareExchange(ref NIN, Compilation.Options.Platform.Requires64Bit() ? Compilation.GetSpecialType(SpecialType.System_Int64) : Compilation.GetSpecialType(SpecialType.System_Int32), null);
            Interlocked.CompareExchange(ref NUI, Compilation.Options.Platform.Requires64Bit() ? Compilation.GetSpecialType(SpecialType.System_UInt64) : Compilation.GetSpecialType(SpecialType.System_UInt32), null);
            Interlocked.CompareExchange(ref R32, Compilation.GetSpecialType(SpecialType.System_Single), null);
            Interlocked.CompareExchange(ref R64, Compilation.GetSpecialType(SpecialType.System_Double), null);
            Interlocked.CompareExchange(ref DEC, Compilation.GetSpecialType(SpecialType.System_Decimal), null);

            Interlocked.CompareExchange(ref INT, I32, null);
            Interlocked.CompareExchange(ref LNG, I64, null);
            Interlocked.CompareExchange(ref UIN, U32, null);
            Interlocked.CompareExchange(ref ULG, U64, null);
            Interlocked.CompareExchange(ref FLT, R32, null);
            Interlocked.CompareExchange(ref DBL, R64, null);

            var types = new TypeSymbol[] { OBJ, STR, BOL, CHR, I08, I16, I32, I64, U08, U16, U32, U64, NIN, NUI, R32, R64, DEC };
            Interlocked.CompareExchange(ref _types, types, null);
        }

        // Overload resolution for Y * / - % < > <= >= X
        private TypeSymbol[,] GetArithmetic()
        {
            return new TypeSymbol[,] {
                //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                /*  obj */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  str */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /* bool */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  chr */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  i08 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i16 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i32 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i64 */{ ERR, ERR, ERR, LNG, LNG, LNG, LNG, LNG, LNG, LNG, LNG, ERR, LNG, ERR, FLT, DBL, DEC },
                /*  u08 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u16 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u32 */{ ERR, ERR, ERR, UIN, LNG, LNG, LNG, LNG, UIN, UIN, UIN, ULG, LNG, NUI, FLT, DBL, DEC },
                /*  u64 */{ ERR, ERR, ERR, ULG, ERR, ERR, ERR, ERR, ULG, ULG, ULG, ULG, ERR, ULG, FLT, DBL, DEC },
                /* nint */{ ERR, ERR, ERR, NIN, NIN, NIN, NIN, LNG, NIN, NIN, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*nuint */{ ERR, ERR, ERR, NUI, ERR, ERR, ERR, ERR, NUI, NUI, NUI, ULG, ERR, NUI, FLT, DBL, DEC },
                /*  r32 */{ ERR, ERR, ERR, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, DBL, ERR },
                /*  r64 */{ ERR, ERR, ERR, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, ERR },
                /*  dec */{ ERR, ERR, ERR, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, ERR, ERR, DEC },
            };
        }

        // Overload resolution for Y + X
        private TypeSymbol[,] GetAddition()
        {
            return new TypeSymbol[,] {
                //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                /*  obj */{ ERR, OSC, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  str */{ SOC, STR, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC, SOC },
                /* bool */{ ERR, OSC, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  chr */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  i08 */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i16 */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i32 */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i64 */{ ERR, OSC, ERR, LNG, LNG, LNG, LNG, LNG, LNG, LNG, LNG, ERR, LNG, ERR, FLT, DBL, DEC },
                /*  u08 */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u16 */{ ERR, OSC, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u32 */{ ERR, OSC, ERR, UIN, LNG, LNG, LNG, LNG, UIN, UIN, UIN, ULG, LNG, NUI, FLT, DBL, DEC },
                /*  u64 */{ ERR, OSC, ERR, ULG, ERR, ERR, ERR, ERR, ULG, ULG, ULG, ULG, ERR, ULG, FLT, DBL, DEC },
                /* nint */{ ERR, OSC, ERR, NIN, NIN, NIN, NIN, LNG, NIN, NIN, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*nuint */{ ERR, OSC, ERR, NUI, ERR, ERR, ERR, ERR, NUI, NUI, NUI, ULG, ERR, NUI, FLT, DBL, DEC },
                /*  r32 */{ ERR, OSC, ERR, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, DBL, ERR },
                /*  r64 */{ ERR, OSC, ERR, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, ERR },
                /*  dec */{ ERR, OSC, ERR, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, ERR, ERR, DEC },
            };
        }

        // Overload resolution for Y << >> X
        private TypeSymbol[,] GetShift()
        {
            return new TypeSymbol[,] {
                //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                /*  obj */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  str */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /* bool */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  chr */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  i08 */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  i16 */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  i32 */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  i64 */{ ERR, ERR, ERR, LNG, LNG, LNG, LNG, ERR, LNG, LNG, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  u08 */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  u16 */{ ERR, ERR, ERR, INT, INT, INT, INT, ERR, INT, INT, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  u32 */{ ERR, ERR, ERR, UIN, UIN, UIN, UIN, ERR, UIN, UIN, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  u64 */{ ERR, ERR, ERR, ULG, ULG, ULG, ULG, ERR, ULG, ULG, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /* nint */{ ERR, ERR, ERR, NIN, NIN, NIN, NIN, ERR, NIN, NIN, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*nuint */{ ERR, ERR, ERR, NUI, NUI, NUI, NUI, ERR, NUI, NUI, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  r32 */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  r64 */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  dec */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
            };
        }

        // Overload resolution for Y == != X
        // Note that these are the overload resolution rules; overload resolution might pick an invalid operator.
        // For example, overload resolution on object == decimal chooses the object/object overload, which then
        // is not legal because decimal must be a reference type. But we don't know to give that error *until*
        // overload resolution has chosen the reference equality operator.
        private TypeSymbol[,] GetEquality()
        {
            return new TypeSymbol[,] {
                //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                /*  obj */{ OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ },
                /*  str */{ OBJ, STR, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ },
                /* bool */{ OBJ, OBJ, BOL, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ, OBJ },
                /*  chr */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  i08 */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i16 */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i32 */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*  i64 */{ OBJ, OBJ, OBJ, LNG, LNG, LNG, LNG, LNG, LNG, LNG, LNG, ERR, LNG, ERR, FLT, DBL, DEC },
                /*  u08 */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u16 */{ OBJ, OBJ, OBJ, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, FLT, DBL, DEC },
                /*  u32 */{ OBJ, OBJ, OBJ, UIN, LNG, LNG, LNG, LNG, UIN, UIN, UIN, ULG, LNG, NUI, FLT, DBL, DEC },
                /*  u64 */{ OBJ, OBJ, OBJ, ULG, ERR, ERR, ERR, ERR, ULG, ULG, ULG, ULG, ERR, ULG, FLT, DBL, DEC },
                /* nint */{ OBJ, OBJ, OBJ, NIN, NIN, NIN, NIN, LNG, NIN, NIN, LNG, ERR, NIN, ERR, FLT, DBL, DEC },
                /*nuint */{ OBJ, OBJ, OBJ, NUI, ERR, ERR, ERR, ERR, NUI, NUI, NUI, ULG, ERR, NUI, FLT, DBL, DEC },
                /*  r32 */{ OBJ, OBJ, OBJ, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, FLT, DBL, OBJ },
                /*  r64 */{ OBJ, OBJ, OBJ, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, DBL, OBJ },
                /*  dec */{ OBJ, OBJ, OBJ, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, DEC, OBJ, OBJ, DEC },
            };
        }

        // Overload resolution for Y | & ^ || && X
        private TypeSymbol[,] GetLogical()
        {
            return new TypeSymbol[,] {
                //          obj  str  bool chr  i08  i16  i32  i64  u08  u16  u32  u64 nint nuint r32  r64  dec  
                /*  obj */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  str */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /* bool */{ ERR, ERR, BOL, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  chr */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, ERR, ERR, ERR },
                /*  i08 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, ERR, ERR, ERR },
                /*  i16 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, ERR, ERR, ERR },
                /*  i32 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, LNG, ERR, NIN, ERR, ERR, ERR, ERR },
                /*  i64 */{ ERR, ERR, ERR, LNG, LNG, LNG, LNG, LNG, LNG, LNG, LNG, ERR, LNG, ERR, ERR, ERR, ERR },
                /*  u08 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, ERR, ERR, ERR },
                /*  u16 */{ ERR, ERR, ERR, INT, INT, INT, INT, LNG, INT, INT, UIN, ULG, NIN, NUI, ERR, ERR, ERR },
                /*  u32 */{ ERR, ERR, ERR, UIN, LNG, LNG, LNG, LNG, UIN, UIN, UIN, ULG, LNG, NUI, ERR, ERR, ERR },
                /*  u64 */{ ERR, ERR, ERR, ULG, ERR, ERR, ERR, ERR, ULG, ULG, ULG, ULG, ERR, ULG, ERR, ERR, ERR },
                /* nint */{ ERR, ERR, ERR, NIN, NIN, NIN, NIN, LNG, NIN, NIN, LNG, ERR, NIN, ERR, ERR, ERR, ERR },
                /*nuint */{ ERR, ERR, ERR, NUI, ERR, ERR, ERR, ERR, NUI, NUI, NUI, ULG, ERR, NUI, ERR, ERR, ERR },
                /*  r32 */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  r64 */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
                /*  dec */{ ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR, ERR },
            };
        }

        private BinaryOperatorSignature[,] CreateSignatures(BinaryOperatorKind kind, TypeSymbol[,] operandTypes)
        {
            var rows = operandTypes.GetLength(0);
            var cols = operandTypes.GetLength(1);
            var result = new BinaryOperatorSignature[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var opType = operandTypes[i, j];
                    var originalLeftType = _types[i];
                    var originalRightType = _types[j];
                    var leftType = opType;
                    var rightType = opType;
                    var returnType = opType;
                    if (kind == BinaryOperatorKind.Addition && (originalLeftType == STR && originalRightType == OBJ || originalLeftType == OBJ && originalRightType == STR))
                    {
                        leftType = originalLeftType;
                        rightType = originalRightType;
                        returnType = STR;
                    }
                    if (kind == BinaryOperatorKind.LeftShift || kind == BinaryOperatorKind.RightShift)
                    {
                        rightType = INT;
                    }
                    if (kind == BinaryOperatorKind.Equal || kind == BinaryOperatorKind.NotEqual ||
                        kind == BinaryOperatorKind.LessThan || kind == BinaryOperatorKind.GreaterThan ||
                        kind == BinaryOperatorKind.LessThanOrEqual || kind == BinaryOperatorKind.GreaterThanOrEqual)
                    {
                        returnType = BOL;
                    }
                    if (kind == BinaryOperatorKind.LogicalAnd || kind == BinaryOperatorKind.LogicalOr || kind == BinaryOperatorKind.LogicalXor)
                    {
                        if (leftType != BOL || rightType != BOL)
                        {
                            leftType = ERR;
                            rightType = ERR;
                        }
                    }
                    result[i, j] = (leftType == ERR || rightType == ERR || returnType == ERR) ? BinaryOperatorSignature.Error : new BinaryOperatorSignature(kind, leftType, rightType, returnType);
                }
            }
            return result;
        }

        private BinaryOperatorSignature[][,] CreateTable()
        {
            CreateSpecialTypes();
            return new BinaryOperatorSignature[][,]
            {
                CreateSignatures(BinaryOperatorKind.Multiplication, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.Addition, GetAddition()),
                CreateSignatures(BinaryOperatorKind.Subtraction, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.Division, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.Remainder, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.LeftShift, GetShift()),
                CreateSignatures(BinaryOperatorKind.RightShift, GetShift()),
                CreateSignatures(BinaryOperatorKind.Equal, GetEquality()),
                CreateSignatures(BinaryOperatorKind.NotEqual, GetEquality()),
                CreateSignatures(BinaryOperatorKind.GreaterThan, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.LessThan, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.GreaterThanOrEqual, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.LessThanOrEqual, GetArithmetic()),
                CreateSignatures(BinaryOperatorKind.LogicalAnd, GetLogical()),
                CreateSignatures(BinaryOperatorKind.LogicalXor, GetLogical()),
                CreateSignatures(BinaryOperatorKind.LogicalOr, GetLogical()),
                CreateSignatures(BinaryOperatorKind.BitwiseAnd, GetLogical()),
                CreateSignatures(BinaryOperatorKind.BitwiseXor, GetLogical()),
                CreateSignatures(BinaryOperatorKind.BitwiseOr, GetLogical()),
                CreateSignatures(BinaryOperatorKind.Range, GetLogical()),
            };
        }

        private BinaryOperatorSignature[][,] CreateLiftedTable()
        {
            var result = new BinaryOperatorSignature[_table.Length][,];
            for (int k = 0; k < _table.Length; k++)
            {
                var entry = _table[k];
                var rows = entry.GetLength(0);
                var cols = entry.GetLength(1);
                var lifted = new BinaryOperatorSignature[rows, cols];
                result[k] = lifted;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        var signature = entry[i, j];
                        lifted[i, j] = signature.AsLifted();
                    }
                }
            }
            return result;
        }

        public override BinaryOperatorSignature ClassifyOperatorByType(BinaryOperatorKind kind, TypeSymbol left, TypeSymbol right)
        {
            if (_table is null) ComputeTable();
            var leftNullable = false;
            if (left is NullableTypeSymbol leftNts)
            {
                left = leftNts.InnerType;
                leftNullable = true;
            }
            var leftSpecialSymbol = left.GetSpecialSymbol(Compilation.Language);
            var leftIndex = -1;
            if (leftSpecialSymbol is SpecialSymbol leftSpecialType)
            {
                leftIndex = leftSpecialType.ToSpecialType().TypeToIndex();
            }
            if (leftIndex < 0)
            {
                return BinaryOperatorSignature.Error;
            }
            var rightNullable = false;
            if (right is NullableTypeSymbol rightNts)
            {
                right = rightNts.InnerType;
                rightNullable = true;
            }
            var rightSpecialSymbol = right.GetSpecialSymbol(Compilation.Language);
            var rightIndex = -1;
            if (rightSpecialSymbol is SpecialSymbol rightSpecialType)
            {
                rightIndex = rightSpecialType.ToSpecialType().TypeToIndex();
            }
            if (rightIndex < 0)
            {
                return BinaryOperatorSignature.Error;
            }
            int kindIndex = kind.StandardIndex;
            if (kindIndex < 0 || kindIndex >= _table.Length) return BinaryOperatorSignature.Error;
            else return leftNullable || rightNullable ? _liftedTable[kindIndex][leftIndex, rightIndex] : _table[kindIndex][leftIndex, rightIndex];
        }
    }
}
