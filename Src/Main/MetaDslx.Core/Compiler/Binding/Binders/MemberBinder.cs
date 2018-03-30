using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IMemberBinder<TBinder>
        where TBinder: Binder<TBinder>, ITypeBinder<TBinder>
    {
        bool IgnoreAccessibility { get; }
        ISymbol ContainingSymbol { get; }
        OverloadResolution<TBinder> OverloadResolution { get; }

        bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null);
        bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null);

        void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);

        void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, BindingOptions options, TBinder originalBinder);
    }

    public class MemberBinderPart<TBinder> : BinderPart<TBinder>, IMemberBinder<TBinder>
        where TBinder : Binder<TBinder>, ITypeBinder<TBinder>
    {
        public MemberBinderPart(TBinder binder) 
            : base(binder)
        {
        }

        private OverloadResolution<TBinder> _lazyOverloadResolution;
        public OverloadResolution<TBinder> OverloadResolution
        {
            get
            {
                if (_lazyOverloadResolution == null)
                {
                    Interlocked.CompareExchange(ref _lazyOverloadResolution, new OverloadResolution<TBinder>(this.Binder), null);
                }
                return _lazyOverloadResolution;
            }
        }

        public bool IgnoreAccessibility => throw new NotImplementedException();

        public ISymbol ContainingSymbol => throw new NotImplementedException();

        public virtual bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        public virtual void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, BindingOptions options, TBinder originalBinder)
        {
            throw new NotImplementedException();
        }
    }
}
