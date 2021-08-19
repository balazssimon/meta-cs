using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardUnaryOperators : UnaryOperators
    {
        private TypeSymbol[] _specialTypes;
        private UnaryOperatorSignature[] _plus;
        private UnaryOperatorSignature[] _minus;
        private UnaryOperatorSignature[] _logicalNegation;
        private UnaryOperatorSignature[] _bitwiseComplement;
        private UnaryOperatorSignature[] _prefixIncrement;
        private UnaryOperatorSignature[] _postfixIncrement;
        private UnaryOperatorSignature[] _prefixDecrement;
        private UnaryOperatorSignature[] _postfixDecrement;
        private UnaryOperatorSignature[][] _table;
        private UnaryOperatorSignature[][] _liftedTable;

        public StandardUnaryOperators(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        protected virtual void ComputeTable()
        {
            Interlocked.CompareExchange(ref _specialTypes, CreateSpecialTypes(), null);

            Interlocked.CompareExchange(ref _plus, CreatePlusSignatures(UnaryOperatorKind.UnaryPlus), null);
            Interlocked.CompareExchange(ref _minus, CreateMinusSignatures(UnaryOperatorKind.UnaryMinus), null);
            Interlocked.CompareExchange(ref _logicalNegation, CreateLogicalNegationSignatures(UnaryOperatorKind.LogicalNegation), null);
            Interlocked.CompareExchange(ref _bitwiseComplement, CreateBitwiseComplementSignatures(UnaryOperatorKind.BitwiseComplement), null);
            Interlocked.CompareExchange(ref _prefixIncrement, CreateIncrementSignatures(UnaryOperatorKind.PrefixIncrement), null);
            Interlocked.CompareExchange(ref _postfixIncrement, CreateIncrementSignatures(UnaryOperatorKind.PostfixIncrement), null);
            Interlocked.CompareExchange(ref _prefixDecrement, CreateIncrementSignatures(UnaryOperatorKind.PrefixDecrement), null);
            Interlocked.CompareExchange(ref _postfixDecrement, CreateIncrementSignatures(UnaryOperatorKind.PostfixDecrement), null);

            Interlocked.CompareExchange(ref _table, CreateTable(), null);
            Interlocked.CompareExchange(ref _liftedTable, CreateLiftedTable(), null);
        }

        private TypeSymbol[] CreateSpecialTypes()
        {
            return new TypeSymbol[]
            {
                Compilation.GetSpecialType(SpecialType.System_Object),
                Compilation.GetSpecialType(SpecialType.System_String),
                Compilation.GetSpecialType(SpecialType.System_Boolean),
                Compilation.GetSpecialType(SpecialType.System_Char),
                Compilation.GetSpecialType(SpecialType.System_SByte),
                Compilation.GetSpecialType(SpecialType.System_Int16),
                Compilation.GetSpecialType(SpecialType.System_Int32),
                Compilation.GetSpecialType(SpecialType.System_Int64),
                Compilation.GetSpecialType(SpecialType.System_Byte),
                Compilation.GetSpecialType(SpecialType.System_UInt16),
                Compilation.GetSpecialType(SpecialType.System_UInt32),
                Compilation.GetSpecialType(SpecialType.System_UInt64),
                Compilation.Options.Platform.Requires64Bit() ? Compilation.GetSpecialType(SpecialType.System_Int64) : Compilation.GetSpecialType(SpecialType.System_Int32),
                Compilation.Options.Platform.Requires64Bit() ? Compilation.GetSpecialType(SpecialType.System_UInt64) : Compilation.GetSpecialType(SpecialType.System_UInt32),
                Compilation.GetSpecialType(SpecialType.System_Single),
                Compilation.GetSpecialType(SpecialType.System_Double),
                Compilation.GetSpecialType(SpecialType.System_Decimal),
            };
        }

        private UnaryOperatorSignature[] CreateIncrementSignatures(UnaryOperatorKind kind)
        {
            return new UnaryOperatorSignature[]
            {
                UnaryOperatorSignature.Error, // obj
                UnaryOperatorSignature.Error, // str
                UnaryOperatorSignature.Error, // bool
                new UnaryOperatorSignature(kind, _specialTypes[ 3], _specialTypes[ 3]), // chr
                new UnaryOperatorSignature(kind, _specialTypes[ 4], _specialTypes[ 4]), // i08
                new UnaryOperatorSignature(kind, _specialTypes[ 5], _specialTypes[ 5]), // i16
                new UnaryOperatorSignature(kind, _specialTypes[ 6], _specialTypes[ 6]), // i32
                new UnaryOperatorSignature(kind, _specialTypes[ 7], _specialTypes[ 7]), // i64
                new UnaryOperatorSignature(kind, _specialTypes[ 8], _specialTypes[ 8]), // u08
                new UnaryOperatorSignature(kind, _specialTypes[ 9], _specialTypes[ 9]), // u16
                new UnaryOperatorSignature(kind, _specialTypes[10], _specialTypes[10]), // u32
                new UnaryOperatorSignature(kind, _specialTypes[11], _specialTypes[11]), // u64
                new UnaryOperatorSignature(kind, _specialTypes[12], _specialTypes[12]), // nint
                new UnaryOperatorSignature(kind, _specialTypes[13], _specialTypes[13]), // nuint
                new UnaryOperatorSignature(kind, _specialTypes[14], _specialTypes[14]), // r32
                new UnaryOperatorSignature(kind, _specialTypes[15], _specialTypes[15]), // r64
                new UnaryOperatorSignature(kind, _specialTypes[16], _specialTypes[16]), // dec
            };
        }

        private UnaryOperatorSignature[] CreatePlusSignatures(UnaryOperatorKind kind)
        {
            return new UnaryOperatorSignature[]
            {
                UnaryOperatorSignature.Error, // obj
                UnaryOperatorSignature.Error, // str
                UnaryOperatorSignature.Error, // bool
                new UnaryOperatorSignature(kind, _specialTypes[ 3], _specialTypes[ 6]), // chr
                new UnaryOperatorSignature(kind, _specialTypes[ 4], _specialTypes[ 6]), // i08
                new UnaryOperatorSignature(kind, _specialTypes[ 5], _specialTypes[ 6]), // i16
                new UnaryOperatorSignature(kind, _specialTypes[ 6], _specialTypes[ 6]), // i32
                new UnaryOperatorSignature(kind, _specialTypes[ 7], _specialTypes[ 7]), // i64
                new UnaryOperatorSignature(kind, _specialTypes[ 8], _specialTypes[ 6]), // u08
                new UnaryOperatorSignature(kind, _specialTypes[ 9], _specialTypes[ 6]), // u16
                new UnaryOperatorSignature(kind, _specialTypes[10], _specialTypes[10]), // u32
                new UnaryOperatorSignature(kind, _specialTypes[11], _specialTypes[11]), // u64
                new UnaryOperatorSignature(kind, _specialTypes[12], _specialTypes[12]), // nint
                new UnaryOperatorSignature(kind, _specialTypes[13], _specialTypes[13]), // nuint
                new UnaryOperatorSignature(kind, _specialTypes[14], _specialTypes[14]), // r32
                new UnaryOperatorSignature(kind, _specialTypes[15], _specialTypes[15]), // r64
                new UnaryOperatorSignature(kind, _specialTypes[16], _specialTypes[16]), // dec
            };
        }

        private UnaryOperatorSignature[] CreateMinusSignatures(UnaryOperatorKind kind)
        {
            return new UnaryOperatorSignature[]
            {
                UnaryOperatorSignature.Error, // obj
                UnaryOperatorSignature.Error, // str
                UnaryOperatorSignature.Error, // bool
                new UnaryOperatorSignature(kind, _specialTypes[ 3], _specialTypes[ 6]), // chr
                new UnaryOperatorSignature(kind, _specialTypes[ 4], _specialTypes[ 6]), // i08
                new UnaryOperatorSignature(kind, _specialTypes[ 5], _specialTypes[ 6]), // i16
                new UnaryOperatorSignature(kind, _specialTypes[ 6], _specialTypes[ 6]), // i32
                new UnaryOperatorSignature(kind, _specialTypes[ 7], _specialTypes[ 7]), // i64
                new UnaryOperatorSignature(kind, _specialTypes[ 8], _specialTypes[ 6]), // u08
                new UnaryOperatorSignature(kind, _specialTypes[ 9], _specialTypes[ 6]), // u16
                new UnaryOperatorSignature(kind, _specialTypes[10], _specialTypes[11]), // u32
                UnaryOperatorSignature.Error, // u64
                new UnaryOperatorSignature(kind, _specialTypes[12], _specialTypes[12]), // nint
                UnaryOperatorSignature.Error, // nuint
                new UnaryOperatorSignature(kind, _specialTypes[14], _specialTypes[14]), // r32
                new UnaryOperatorSignature(kind, _specialTypes[15], _specialTypes[15]), // r64
                new UnaryOperatorSignature(kind, _specialTypes[16], _specialTypes[16]), // dec
            };
        }

        private UnaryOperatorSignature[] CreateLogicalNegationSignatures(UnaryOperatorKind kind)
        {
            return new UnaryOperatorSignature[]
            {
                UnaryOperatorSignature.Error, // obj
                UnaryOperatorSignature.Error, // str
                new UnaryOperatorSignature(kind, _specialTypes[ 2], _specialTypes[ 2]), // bool
                UnaryOperatorSignature.Error, // chr
                UnaryOperatorSignature.Error, // i08
                UnaryOperatorSignature.Error, // i16
                UnaryOperatorSignature.Error, // i32
                UnaryOperatorSignature.Error, // i64
                UnaryOperatorSignature.Error, // u08
                UnaryOperatorSignature.Error, // u16
                UnaryOperatorSignature.Error, // u32
                UnaryOperatorSignature.Error, // u64
                UnaryOperatorSignature.Error, // nint
                UnaryOperatorSignature.Error, // nuint
                UnaryOperatorSignature.Error, // r32
                UnaryOperatorSignature.Error, // r64
                UnaryOperatorSignature.Error, // dec
            };
        }

        private UnaryOperatorSignature[] CreateBitwiseComplementSignatures(UnaryOperatorKind kind)
        {
            return new UnaryOperatorSignature[]
            {
                UnaryOperatorSignature.Error, // obj
                UnaryOperatorSignature.Error, // str
                UnaryOperatorSignature.Error, // bool
                new UnaryOperatorSignature(kind, _specialTypes[ 3], _specialTypes[ 6]), // chr
                new UnaryOperatorSignature(kind, _specialTypes[ 4], _specialTypes[ 6]), // i08
                new UnaryOperatorSignature(kind, _specialTypes[ 5], _specialTypes[ 6]), // i16
                new UnaryOperatorSignature(kind, _specialTypes[ 6], _specialTypes[ 6]), // i32
                new UnaryOperatorSignature(kind, _specialTypes[ 7], _specialTypes[ 7]), // i64
                new UnaryOperatorSignature(kind, _specialTypes[ 8], _specialTypes[ 6]), // u08
                new UnaryOperatorSignature(kind, _specialTypes[ 9], _specialTypes[ 6]), // u16
                new UnaryOperatorSignature(kind, _specialTypes[10], _specialTypes[10]), // u32
                new UnaryOperatorSignature(kind, _specialTypes[11], _specialTypes[11]), // u64
                new UnaryOperatorSignature(kind, _specialTypes[12], _specialTypes[12]), // nint
                new UnaryOperatorSignature(kind, _specialTypes[13], _specialTypes[13]), // nuint
                UnaryOperatorSignature.Error, // r32
                UnaryOperatorSignature.Error, // r64
                UnaryOperatorSignature.Error, // dec
            };
        }

        private UnaryOperatorSignature[][] CreateTable()
        {
            return new UnaryOperatorSignature[][]
            {
                _plus,
                _minus,
                _logicalNegation,
                _bitwiseComplement,
                _prefixIncrement,
                _postfixIncrement,
                _prefixDecrement,
                _postfixDecrement
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
            var opSpecialSymbol = operand.GetSpecialSymbol(CSharpLanguage.Instance);
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
