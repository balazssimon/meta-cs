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

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IBodyBinder
    {

    }

    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    public class BodyBinder : Binder, IBodyBinder
    {
        private IMetaSymbol _container;
        private readonly Func<ConsList<IMetaSymbol>, Imports> _computeImports;
        private Imports _lazyImports;

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        public BodyBinder(Binder next, RedNode node, IMetaSymbol container, Imports imports = null)
            : base(next, node)
        {
            //Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        public BodyBinder(Binder next, RedNode node, Func<ConsList<IMetaSymbol>, Imports> computeImports)
            : base(next, node)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
        }

        public override IMetaSymbol ContainingSymbol
        {
            get
            {
                /*if (_container == null)
                {
                    var symbolBinder = this.GetAncestorBinder<ISymbolDefBinder>();
                    if (symbolBinder != null)
                    {
                        Interlocked.CompareExchange(ref _container, symbolBinder.DefinedSymbols, null);
                    }
                }*/
                return _container;
            }
        }

        public virtual bool IsSubmissionClass
        {
            get { return false; }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<IMetaSymbol> result, BindingOptions options, Binder originalBinder)
        {
            if (this.ContainingSymbol != null)
            {
                this.AddMemberLookupSymbolsInfo(result, this.ContainingSymbol, options, originalBinder);
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
            Debug.Assert(result.IsClear);

            if (IsSubmissionClass)
            {
                this.LookupMembersCore(result, null, name, basesBeingResolved, options, originalBinder, diagnose, ref useSiteDiagnostics);
                return;
            }

            var imports = GetImports(basesBeingResolved);

            // first lookup members of the namespace
            if (this.ContainingSymbol != null)
            {
                this.LookupMembersCore(result, null, name, basesBeingResolved, options, originalBinder, diagnose, ref useSiteDiagnostics);

                if (result.IsMultiViable)
                {
                    return;
                }
            }

            // next try using aliases or symbols in imported namespaces
            imports.LookupSymbol(originalBinder, result, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        protected override void LookupMembersCore(LookupResult result, IMetaSymbol qualifierOpt, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (qualifierOpt == null)
            {
                if (this.ContainingSymbol == null) return;
                foreach (var child in this.ContainingSymbol.MChildren)
                {
                    if (child.MName != null && child.MName == name)
                    {
                        result.MergeEqual(this.CheckViability(child, options, null, diagnose, ref useSiteDiagnostics));
                    }
                }
            }
            else
            {
                foreach (var child in qualifierOpt.MChildren)
                {
                    if (child.MName != null && child.MName == name)
                    {
                        result.MergeEqual(this.CheckViability(child, options, null, diagnose, ref useSiteDiagnostics));
                    }
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
