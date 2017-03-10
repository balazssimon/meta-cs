using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Symbols
{
    public static class SoalSymbolFacts
    {
        private static ImmutableArray<ImmutableSymbol> _wellKnownTypes = default(ImmutableArray<ImmutableSymbol>);

        public static ImmutableArray<ImmutableSymbol> WellKnownTypes
        {
            get
            {
                if (_wellKnownTypes.IsDefault)
                {
                    ArrayBuilder<ImmutableSymbol> builder = ArrayBuilder<ImmutableSymbol>.GetInstance();
                    try
                    {
                        builder.Add(SoalInstance.Object);
                        builder.Add(SoalInstance.String);
                        builder.Add(SoalInstance.Int);
                        builder.Add(SoalInstance.Long);
                        builder.Add(SoalInstance.Float);
                        builder.Add(SoalInstance.Double);
                        builder.Add(SoalInstance.Byte);
                        builder.Add(SoalInstance.Bool);
                        builder.Add(SoalInstance.Void);
                        builder.Add(SoalInstance.Date);
                        builder.Add(SoalInstance.Time);
                        builder.Add(SoalInstance.DateTime);
                        builder.Add(SoalInstance.TimeSpan);
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedExchange(ref _wellKnownTypes, builder.ToImmutableAndFree());
                    }
                }
                return _wellKnownTypes;
            }
        }
    }
}
