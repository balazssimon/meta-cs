using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Compiler.Diagnostics;
using System.Threading;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IIdentifierBinder : IQualifierBinder
    {
    }

    public class IdentifierBinder : QualifierBinder, IIdentifierBinder
    {
        private readonly string _name;
        private IMetaSymbol _lazySymbol;

        public IdentifierBinder(Binder next, RedNode node, string name) 
            : base(next, node)
        {
            _name = name;
        }

        public override IMetaSymbol Symbol
        {
            get
            {
                IMetaSymbol context = null;
                var qualifierBinder = this.GetAncestorBinder<IQualifierBinder>();
                if (qualifierBinder != null)
                {
                    context = qualifierBinder.GetChildContextSymbol(this.Node);
                }
                LookupResult result = LookupResult.GetInstance();
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                try
                {
                    if (context != null)
                    { 
                        this.LookupMembersWithFallback(result, context, _name, null, BindingOptions.Default, ref useSiteDiagnostics);
                        Interlocked.CompareExchange(ref _lazySymbol, result.SingleSymbolOrDefault, null);
                    }
                    else
                    {
                        this.LookupSymbolsWithFallback(result, _name, null, BindingOptions.Default, ref useSiteDiagnostics);
                        Interlocked.CompareExchange(ref _lazySymbol, result.SingleSymbolOrDefault, null);
                    }
                }
                finally
                {
                    result.Free();
                }
                return _lazySymbol;
            }
        }
    }
}
