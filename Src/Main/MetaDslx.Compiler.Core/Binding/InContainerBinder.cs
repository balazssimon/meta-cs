using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    public sealed class InContainerBinder : Binder
    {
        private readonly IMetaSymbol _container;
        private readonly Func<ConsList<IMetaSymbol>, Imports> _computeImports;
        private Imports _lazyImports;

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        public InContainerBinder(IMetaSymbol container, Binder next, Imports imports = null)
            : base(next)
        {
            Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        public InContainerBinder(Binder next, Func<ConsList<IMetaSymbol>, Imports> computeImports)
            : base(next)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
        }


        public override IMetaSymbol ContainingSymbol
        {
            get
            {
                return _container;
            }
        }

        internal override void LookupSymbolsInSingleBinder(LookupResult result, string name, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            foreach (var child in _container.MChildren)
            {
                if (child.MName != null && child.MName == name)
                {
                    result.MergeEqual(this.CheckViability(child, options, diagnose, ref useSiteDiagnostics));
                }
            }
        }

        private SingleLookupResult CheckViability(IMetaSymbol symbol, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            bool isType = symbol.MIsType;
            bool isMember = !symbol.MIsScope && !symbol.MIsType;
            bool isNamespace = symbol.MIsScope && !symbol.MIsType;
            bool isViableKind = (isNamespace && options.LookupNamespaces) || (isType && options.LookupTypes) || (isMember && (options.LookupInstanceMembers || options.LookupStaticMembers));
            bool isViableType = true;
            if (options is SimpleSymbolBindingOptions)
            {
                var soptions = (SimpleSymbolBindingOptions)options;
                if (soptions.SymbolTypes != null)
                {
                    isViableType = false;
                    foreach (var symbolType in soptions.SymbolTypes)
                    {
                        if (symbolType.IsAssignableFrom(symbol.MId.SymbolInfo.ImmutableType))
                        {
                            isViableType = true;
                            break;
                        }
                    }
                }
            }
            if (isViableKind && isViableType)
            {
                return LookupResult.Good(symbol);
            }
            else
            {
                return LookupResult.Wrong(symbol, new DefaultDiagnosticInfo(this.Compilation.MessageProvider, ErrorCode.ERR_WrongSymbol));
            }
        }

        public override Imports GetImports(ConsList<IMetaSymbol> basesBeingResolved)
        {
            Debug.Assert(_lazyImports != null || _computeImports != null, "Have neither imports nor a way to compute them.");

            if (_lazyImports == null)
            {
                Interlocked.CompareExchange(ref _lazyImports, _computeImports(basesBeingResolved), null);
            }

            return _lazyImports;
        }


    }
}
