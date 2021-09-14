using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

#nullable disable

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardUnaryOperators : UnaryOperators
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

        private TypeSymbol[] _types;
        private UnaryOperatorSignature[][] _table;
        private UnaryOperatorSignature[][] _liftedTable;

        public StandardUnaryOperators(LanguageCompilation compilation)
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

            var types = new TypeSymbol[] { OBJ, STR, BOL, CHR, I08, I16, I32, I64, U08, U16, U32, U64, NIN, NUI, R32, R64, DEC };
            Interlocked.CompareExchange(ref _types, types, null);
        }

        private TypeSymbol[] GetIncrementTypes()
        {
                                    //obj   str  bool   chr   i08   i16   i32   i64   u08   u16   u32   u64  nint nuint   r32   r64   dec  
            return new TypeSymbol[] { ERR,  ERR,  ERR,  CHR,  I08,  I16,  I32,  I64,  U08,  U16,  U32,  U64,  NIN,  NUI,  R32,  R64,  DEC };
        }

        private TypeSymbol[] GetPlusTypes()
        {
                                    //obj   str  bool   chr   i08   i16   i32   i64   u08   u16   u32   u64  nint nuint   r32   r64   dec  
            return new TypeSymbol[] { ERR,  ERR,  ERR,  I32,  I32,  I32,  I32,  I64,  I32,  I32,  U32,  U64,  NIN,  NUI,  R32,  R64,  DEC };
        }

        private TypeSymbol[] GetMinusTypes()
        {
                                    //obj   str  bool   chr   i08   i16   i32   i64   u08   u16   u32   u64  nint nuint   r32   r64   dec  
            return new TypeSymbol[] { ERR,  ERR,  ERR,  I32,  I32,  I32,  I32,  I64,  I32,  I32,  I64,  ERR,  NIN,  ERR,  R32,  R64,  DEC };
        }

        private TypeSymbol[] GetLogicalNegationTypes()
        {
                                    //obj   str  bool   chr   i08   i16   i32   i64   u08   u16   u32   u64  nint nuint   r32   r64   dec  
            return new TypeSymbol[] { ERR,  ERR,  BOL,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR,  ERR };
        }

        private TypeSymbol[] GetBitwiseComplementTypes()
        {
                                    //obj   str  bool   chr   i08   i16   i32   i64   u08   u16   u32   u64  nint nuint   r32   r64   dec  
            return new TypeSymbol[] { ERR,  ERR,  ERR,  I32,  I32,  I32,  I32,  I64,  I32,  I32,  U32,  U64,  NIN,  NUI,  ERR,  ERR,  ERR };
        }


        private UnaryOperatorSignature[] CreateSignatures(UnaryOperatorKind kind, TypeSymbol[] returnTypes)
        {
            var result = new UnaryOperatorSignature[returnTypes.Length];
            for (int i = 0; i < returnTypes.Length; i++)
            {
                var returnType = returnTypes[i];
                result[i] = (returnType == ERR) ? UnaryOperatorSignature.Error : new UnaryOperatorSignature(kind, _types[i], returnType);
            }
            return result;
        }

        private UnaryOperatorSignature[][] CreateTable()
        {
            CreateSpecialTypes();
            return new UnaryOperatorSignature[][]
            {
                CreateSignatures(UnaryOperatorKind.UnaryPlus, GetPlusTypes()),
                CreateSignatures(UnaryOperatorKind.UnaryMinus, GetMinusTypes()),
                CreateSignatures(UnaryOperatorKind.LogicalNegation, GetLogicalNegationTypes()),
                CreateSignatures(UnaryOperatorKind.BitwiseComplement, GetBitwiseComplementTypes()),
                CreateSignatures(UnaryOperatorKind.PrefixIncrement, GetIncrementTypes()),
                CreateSignatures(UnaryOperatorKind.PostfixIncrement, GetIncrementTypes()),
                CreateSignatures(UnaryOperatorKind.PrefixDecrement, GetIncrementTypes()),
                CreateSignatures(UnaryOperatorKind.PostfixDecrement, GetIncrementTypes()),
            };
        }

        private UnaryOperatorSignature[][] CreateLiftedTable()
        {
            var result = new UnaryOperatorSignature[_table.Length][];
            for (int i = 0; i < _table.Length; i++)
            {
                result[i] = new UnaryOperatorSignature[_table[i].Length];
                for (int j = 0; j < _table[i].Length; j++)
                {
                    result[i][j] = _table[i][j].AsLifted();
                }
            }
            return result;
        }

        public override UnaryOperatorSignature ClassifyOperatorByType(UnaryOperatorKind kind, TypeSymbol operand)
        {
            if (_table is null) ComputeTable();
            var opNullable = false;
            if (operand is NullableTypeSymbol opNts)
            {
                operand = opNts.InnerType;
                opNullable = true;
            }
            var opSpecialSymbol = operand.GetSpecialSymbol(Compilation.Language);
            var opIndex = -1;
            if (opSpecialSymbol is SpecialType opSpecialType)
            {
                opIndex = opSpecialType.TypeToIndex();
            }
            if (opIndex < 0)
            {
                return UnaryOperatorSignature.Error;
            }
            int kindIndex = kind.StandardIndex;
            if (kindIndex < 0 || kindIndex >= _table.Length) return UnaryOperatorSignature.Error;
            else return opNullable ? _liftedTable[kindIndex][opIndex] : _table[kindIndex][opIndex];
        }

    }
}
