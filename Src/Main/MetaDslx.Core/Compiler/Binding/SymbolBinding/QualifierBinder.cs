using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public struct Qualifier
    {
        public Qualifier(string identifier)
        {
            this.Identifiers = ImmutableArray.Create(identifier); 
        }

        public Qualifier(ImmutableArray<string> identifiers)
        {
            this.Identifiers = identifiers;
        }

        public ImmutableArray<string> Identifiers { get; }
    }

    public class QualifierBinder : SymbolBinder
    {
        public QualifierBinder(Binder next) : base(next)
        {
        }

        public override bool GetQualifier(LookupResult<Qualifier> result)
        {
            LookupResult<string> identifiers = LookupResult<string>.GetInstance();
            try
            {
                this.ExecuteCurrentOrSynthesized(binder => binder.GetIdentifier(identifiers));
                if (identifiers.IsMultiViable)
                {
                    Qualifier qualifier = new Qualifier(identifiers.GetResults());
                    result.MergeEqual(LookupResult<Qualifier>.Good(qualifier));
                }
                return true;
            }
            finally
            {
                identifiers.Free();
            }
        }
    }
}
