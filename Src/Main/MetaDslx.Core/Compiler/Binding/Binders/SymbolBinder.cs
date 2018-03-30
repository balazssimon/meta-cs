using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ISymbolBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        TBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        TBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);

        void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, BindingOptions options);
    }

    public class SymbolBinderPart<TBinder> : BinderPart<TBinder>, ISymbolBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        public SymbolBinderPart(TBinder binder) 
            : base(binder)
        {
        }

        public virtual void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, BindingOptions options)
        {
            throw new NotImplementedException();
        }

        public virtual TBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual TBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual string ToDisplayString(ISymbol symbol)
        {
            string result = string.Empty;
            ISymbol current = symbol;
            while (current != null)
            {
                if (result.Length > 0) result = "." + result;
                result = current.MName + result;
                current = current.MParent;
            }
            return result;
        }

    }
}
