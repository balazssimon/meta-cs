using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols.Model;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaAliasSymbol : ModelAliasSymbol
    {
        private readonly string _aliasName;
        private readonly Binder _binder;

        private DeclaredSymbol _aliasTarget;
        private readonly ImmutableArray<Location> _locations;  // NOTE: can be empty for the "global" alias.

        // lazy binding
        private readonly SyntaxNodeOrToken _aliasTargetName;
        private readonly bool _isExtern;
        private DiagnosticBag _aliasTargetDiagnostics;

        public MetaAliasSymbol(Binder binder, DeclaredSymbol target, string aliasName, ImmutableArray<Location> locations)
            : base(binder.ContainingSymbol)
        {
            _aliasName = aliasName;
            _locations = locations;
            _aliasTarget = target;
            _binder = binder;
        }

        public MetaAliasSymbol(Binder binder, string aliasName, SyntaxNodeOrToken aliasTargetName, Location location, bool isExtern = false)
            : base(binder.ContainingSymbol)
        {
            _aliasName = aliasName;
            _locations = ImmutableArray.Create(location);
            _aliasTargetName = aliasTargetName;
            _binder = binder;
            _isExtern = isExtern;
        }

        public override ImmutableArray<Location> Locations => _locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => GetDeclaringSyntaxReferenceHelper<LanguageSyntaxNode>(_locations);

        protected override string CompleteSymbolProperty_Name(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return _aliasName;
        }

        protected override DeclaredSymbol CompleteSymbolProperty_Target(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            // the target is not yet bound. If it is an ordinary alias, bind the target
            // symbol. If it is an extern alias then find the target in the list of metadata references.
            var newDiagnostics = DiagnosticBag.GetInstance();

            DeclaredSymbol symbol = this.IsExtern ?
                ResolveExternAliasTarget(newDiagnostics) :
                ResolveAliasTarget(_binder, _aliasTargetName, newDiagnostics, null);

            // Note: It's important that we don't call newDiagnosticsToReadOnlyAndFree here. That call
            // can force the prompt evaluation of lazy initialized diagnostics.  That in turn can 
            // call back into GetAliasTarget on the same thread resulting in a dead lock scenario.
            bool won = Interlocked.Exchange(ref _aliasTargetDiagnostics, newDiagnostics) == null;
            Debug.Assert(won, "Only one thread can win the alias target CompareExchange");

            return symbol;
        }

        protected override bool CompleteSymbolProperty_IsExtern(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return _isExtern;
        }

        public override AliasSymbol ToNewSubmission(LanguageCompilation compilation)
        {
            Debug.Assert(_binder.Compilation.IsSubmission);

            // We can pass basesBeingResolved: null because base type cycles can't cross
            // submission boundaries - there's no way to depend on a subsequent submission.
            var previousTarget = GetAliasTarget(null);
            if (previousTarget.Kind != SymbolKind.Namespace)
            {
                return this;
            }

            var expandedGlobalNamespace = compilation.GlobalNamespace;
            var expandedNamespace = (NamespaceOrTypeSymbol)Imports.ExpandPreviousSubmissionNamespace((NamespaceSymbol)previousTarget, expandedGlobalNamespace);
            var binder = new InContainerBinder(expandedGlobalNamespace, new BuckStopsHereBinder(compilation));
            return new MetaAliasSymbol(binder, expandedNamespace, _aliasName, _locations);
        }

        // basesBeingResolved is only used to break circular references.
        public DeclaredSymbol GetAliasTarget(LookupConstraints recursionConstraints)
        {
            return this.Target;
        }

        public override DiagnosticBag AliasTargetDiagnostics
        {
            get
            {
                GetAliasTarget(null);
                Debug.Assert(_aliasTargetDiagnostics != null);
                return _aliasTargetDiagnostics;
            }
        }

        private NamespaceSymbol ResolveExternAliasTarget(DiagnosticBag diagnostics)
        {
            NamespaceSymbol target;
            if (!_binder.Compilation.GetExternAliasTarget(_aliasName, out target))
            {
                diagnostics.Add(InternalErrorCode.ERR_BadExternAlias, _locations.FirstOrDefault(), _aliasName);
            }

            Debug.Assert((object)target != null);

            return target;
        }

        private static DeclaredSymbol ResolveAliasTarget(Binder binder, SyntaxNodeOrToken syntax, DiagnosticBag diagnostics, LookupConstraints recursionConstraints)
        {
            return binder.BindDeclaredSymbol(syntax, diagnostics, recursionConstraints);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            AliasSymbol other = obj as AliasSymbol;

            return (object)other != null &&
                Equals(this.Locations.FirstOrDefault(), other.Locations.FirstOrDefault()) &&
                this.ContainingAssembly == other.ContainingAssembly;
        }

        public override int GetHashCode()
        {
            if (this.Locations.Length > 0)
                return this.Locations.First().GetHashCode();
            else
                return Name.GetHashCode();
        }

        protected override void CompleteInitializingSymbol(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteSymbolProperty_Attributes(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        protected override ImmutableArray<DeclaredSymbol> CompleteSymbolProperty_Members(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        protected override ImmutableArray<TypeSymbol> CompleteSymbolProperty_TypeMembers(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ImmutableArray<TypeSymbol>.Empty;
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }
    }
}
