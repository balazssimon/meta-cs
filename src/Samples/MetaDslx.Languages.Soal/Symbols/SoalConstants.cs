using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Soal.Symbols
{
    public static class SoalConstants
    {
        private static ImmutableArray<IMetaSymbol> _wellKnownTypes = default;

        public static ImmutableArray<IMetaSymbol> Types
        {
            get
            {
                if (_wellKnownTypes.IsDefault)
                {
                    ArrayBuilder<IMetaSymbol> builder = ArrayBuilder<IMetaSymbol>.GetInstance();
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
