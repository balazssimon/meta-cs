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
        private ISymbol _lazySymbol;
        private ImmutableArray<Diagnostic> _lazyErrors;

        public IdentifierBinder(Binder next, RedNode node, string name) 
            : base(next, node)
        {
            _name = name;
        }

        public override ISymbol Symbol
        {
            get
            {
                return this.BindSymbol();
            }
        }

        private ISymbol BindSymbol()
        {
            if (_lazySymbol == null)
            {
                ISymbol context = null;
                bool last = true;
                var qualifierBinder = this.FindAncestorBinder<IQualifierBinder>();
                if (qualifierBinder != null)
                {
                    context = qualifierBinder.GetChildContextSymbol(this.Node);
                    last = qualifierBinder.IsLastChild(this.Node);
                }
                LookupResult result = LookupResult.GetInstance();
                DiagnosticBag diagnostics = DiagnosticBag.GetInstance();
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                try
                {
                    bool wasError = false;
                    var options = last ? this.BindingOptions : BindingOptions.Default;
                    if (context != null)
                    {
                        this.LookupMembersWithFallback(result, context, _name, null, options, ref useSiteDiagnostics);
                        Interlocked.CompareExchange(ref _lazySymbol, ResultSymbol(result, this.Node, context, _name, options, diagnostics, false, out wasError), null);
                    }
                    else
                    {
                        this.LookupSymbolsWithFallback(result, _name, null, options, ref useSiteDiagnostics);
                        Interlocked.CompareExchange(ref _lazySymbol, ResultSymbol(result, this.Node, null, _name, options, diagnostics, false, out wasError), null);
                    }
                }
                finally
                {
                    ImmutableInterlocked.InterlockedExchange(ref _lazyErrors, diagnostics.ToReadOnlyAndFree());
                    result.Free();
                }
            }
            return _lazySymbol;
        }

        public override ImmutableArray<Diagnostic> GetErrors()
        {
            this.BindSymbol();
            return _lazyErrors;
        }
    }
}
