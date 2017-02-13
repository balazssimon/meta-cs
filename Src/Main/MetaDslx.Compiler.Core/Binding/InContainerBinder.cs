using MetaDslx.Compiler.Diagnostics;
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
    public class InContainerBinder : Binder
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

        public virtual bool IsSubmissionClass
        {
            get { return false; }
        }

        public virtual bool IsScriptClass
        {
            get { return false; }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<IMetaSymbol> result, BindingOptions options, Binder originalBinder)
        {
            if (_container != null)
            {
                this.AddMemberLookupSymbolsInfo(result, _container, options, originalBinder);
            }

            // Submission imports are handled by AddMemberLookupSymbolsInfo (above).
            if (!IsSubmissionClass)
            {
                var imports = GetImports(basesBeingResolved: null);
                imports.AddLookupSymbolsInfo(result, options, originalBinder);
            }
        }

        public override void AddMemberLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, IMetaSymbol container, BindingOptions options, Binder originalBinder)
        {
            this.AddMemberLookupSymbolsInfoInType(result, container, options, originalBinder, null);
        }

        private void AddMemberLookupSymbolsInfoInType(ArrayBuilder<IMetaSymbol> result, IMetaSymbol type, BindingOptions options, Binder originalBinder, IMetaSymbol accessThroughType)
        {
            AddMemberLookupSymbolsInfoWithoutInheritance(result, type, options, originalBinder, accessThroughType);

            foreach (var baseType in type.MGetAllBaseTypes())
            {
                AddMemberLookupSymbolsInfoWithoutInheritance(result, baseType, options, originalBinder, accessThroughType);
            }

            // SB-TODO: add Object type here, if needed:
            //this.AddMemberLookupSymbolsInfoInClass(result, Compilation.GetSpecialType(SpecialType.System_Object), options, originalBinder, accessThroughType);
        }

        private static void AddMemberLookupSymbolsInfoWithoutInheritance(ArrayBuilder<IMetaSymbol> result, IMetaSymbol symbol, BindingOptions options, Binder originalBinder, IMetaSymbol accessThroughType)
        {
            HashSet<DiagnosticInfo> discardedDiagnostics = null;
            foreach (var member in symbol.MChildren)
            {
                SingleLookupResult lookupResult = originalBinder.CheckViability(member, options, accessThroughType, false, ref discardedDiagnostics);
                if (lookupResult.Kind == LookupResultKind.Viable)
                {
                    result.Add(member);
                }
            }
        }

        protected override void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            foreach (var child in _container.MChildren)
            {
                if (child.MName != null && child.MName == name)
                {
                    result.MergeEqual(this.CheckViability(child, options, null, diagnose, ref useSiteDiagnostics));
                }
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
