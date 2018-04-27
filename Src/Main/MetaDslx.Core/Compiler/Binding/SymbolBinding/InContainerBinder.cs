using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    internal sealed class InContainerBinder : SymbolBinder
    {
        private readonly ISymbol _container;
        private readonly Func<ConsList<ISymbol>, Imports> _computeImports;
        private Imports _lazyImports;

        /// <summary>
        /// Creates a binder for a container with imports (usings and extern aliases) that can be
        /// retrieved from <paramref name="syntaxNode"/>.
        /// </summary>
        internal InContainerBinder(Binder next, RedNode syntaxNode, ISymbol container, bool inUsing)
            : base(next)
        {
            Debug.Assert((object)container != null);
            Debug.Assert(syntaxNode != null);

            _container = container;
            _computeImports = basesBeingResolved => Imports.FromSyntax(syntaxNode, this, basesBeingResolved, inUsing);
        }

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        internal InContainerBinder(Binder next, ISymbol container, Imports imports = null)
            : base(next)
        {
            Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        internal InContainerBinder(Binder next, Func<ConsList<ISymbol>, Imports> computeImports)
            : base(next)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
        }

        public override ISymbol ContainingSymbol
        {
            get
            {
                return _container;
            }
        }

        public override void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<ISymbol> result, SymbolBindingOptions options, ISymbolBinder originalBinder)
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

        public override void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, SymbolBindingOptions options, ISymbolBinder originalBinder)
        {
            this.AddMemberLookupSymbolsInfoInType(result, container, options, originalBinder, null);
        }

        private void AddMemberLookupSymbolsInfoInType(ArrayBuilder<ISymbol> result, ISymbol type, SymbolBindingOptions options, ISymbolBinder originalBinder, ISymbol accessThroughType)
        {
            AddMemberLookupSymbolsInfoWithoutInheritance(result, type, options, originalBinder, accessThroughType);

            foreach (var baseType in type.MGetAllBases())
            {
                AddMemberLookupSymbolsInfoWithoutInheritance(result, baseType, options, originalBinder, accessThroughType);
            }

            // SB-TODO: add Object type here, if needed:
            //this.AddMemberLookupSymbolsInfoInClass(result, Compilation.GetSpecialType(SpecialType.System_Object), options, originalBinder, accessThroughType);
        }

        private static void AddMemberLookupSymbolsInfoWithoutInheritance(ArrayBuilder<ISymbol> result, ISymbol symbol, SymbolBindingOptions options, ISymbolBinder originalBinder, ISymbol accessThroughType)
        {
            HashSet<DiagnosticInfo> discardedDiagnostics = null;
            foreach (var member in symbol.MGetMembers())
            {
                SingleLookupResult lookupResult = originalBinder.CheckViability(member, options, accessThroughType, false, ref discardedDiagnostics);
                if (lookupResult.Kind == LookupResultKind.Viable)
                {
                    result.Add(member);
                }
            }
        }

        public override void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
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

        public override void LookupMembersCore(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (qualifierOpt == null)
            {
                if (this.ContainingSymbol == null) return;
                foreach (var child in this.ContainingSymbol.MGetMembers())
                {
                    if (child.MName != null && child.MName == name)
                    {
                        result.MergeEqual(this.CheckViability(child, options, null, diagnose, ref useSiteDiagnostics));
                    }
                }
            }
            else
            {
                foreach (var child in qualifierOpt.MGetMembers())
                {
                    if (child.MName != null && child.MName == name)
                    {
                        result.MergeEqual(this.CheckViability(child, options, null, diagnose, ref useSiteDiagnostics));
                    }
                }
            }
        }

        public override Imports GetImports(ConsList<ISymbol> basesBeingResolved)
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
