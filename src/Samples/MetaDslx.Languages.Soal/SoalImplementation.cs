using MetaDslx.Languages.Soal.Symbols.Internal;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Soal.Symbols
{
    internal class SoalImplementation : SoalImplementationBase
    {
        public SoalImplementation()
        {
        }
    }

    public static class SoalConstants
    {
        private static ImmutableList<IMetaSymbol> types = ImmutableList<IMetaSymbol>.Empty;

        public static ImmutableList<IMetaSymbol> Types
        {
            get
            {
                if (SoalConstants.types.Count == 0 && SoalInstance.IsInitialized)
                {
                    ImmutableList<IMetaSymbol>.Builder typesBuilder = ImmutableList.CreateBuilder<IMetaSymbol>();
                    typesBuilder.Add(SoalInstance.Object);
                    typesBuilder.Add(SoalInstance.String);
                    typesBuilder.Add(SoalInstance.Int);
                    typesBuilder.Add(SoalInstance.Long);
                    typesBuilder.Add(SoalInstance.Float);
                    typesBuilder.Add(SoalInstance.Double);
                    typesBuilder.Add(SoalInstance.Byte);
                    typesBuilder.Add(SoalInstance.Bool);
                    typesBuilder.Add(SoalInstance.Void);
                    typesBuilder.Add(SoalInstance.Date);
                    typesBuilder.Add(SoalInstance.Time);
                    typesBuilder.Add(SoalInstance.DateTime);
                    typesBuilder.Add(SoalInstance.TimeSpan);
                    Interlocked.Exchange(ref SoalConstants.types, typesBuilder.ToImmutable());
                }
                return SoalConstants.types;
            }
        }
    }
}
