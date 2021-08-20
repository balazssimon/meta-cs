using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public partial class SourceAliasSymbol
    {
        private DiagnosticBag _aliasTargetDiagnostics;

        protected override DeclaredSymbol CompleteSymbolProperty_Target(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            // the target is not yet bound. If it is an ordinary alias, bind the target
            // symbol. If it is an extern alias then find the target in the list of metadata references.
            var newDiagnostics = DiagnosticBag.GetInstance();

            DeclaredSymbol symbol = this.IsExtern ?
                ResolveExternAliasTarget(newDiagnostics) :
                ResolveAliasTarget(newDiagnostics, cancellationToken);

            // Note: It's important that we don't call newDiagnosticsToReadOnlyAndFree here. That call
            // can force the prompt evaluation of lazy initialized diagnostics.  That in turn can 
            // call back into GetAliasTarget on the same thread resulting in a dead lock scenario.
            bool won = Interlocked.Exchange(ref _aliasTargetDiagnostics, newDiagnostics) == null;
            Debug.Assert(won, "Only one thread can win the alias target CompareExchange");

            return symbol;

            //return SourceSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Target), diagnostics, cancellationToken);
        }

        public override AliasSymbol ToNewSubmission(LanguageCompilation compilation)
        {
            Debug.Assert(this.DeclaringCompilation.IsSubmission);

            // We can pass basesBeingResolved: null because base type cycles can't cross
            // submission boundaries - there's no way to depend on a subsequent submission.
            var previousTarget = GetAliasTarget(null);
            if (previousTarget is not NamespaceSymbol previousNamespace)
            {
                return this;
            }

            var expandedGlobalNamespace = compilation.GlobalNamespace;
            var expandedNamespace = Imports.ExpandPreviousSubmissionNamespace(previousNamespace, expandedGlobalNamespace);
            return new SourceAliasSymbol(expandedNamespace, this.MergedDeclaration);
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

        private DeclaredSymbol ResolveExternAliasTarget(DiagnosticBag diagnostics)
        {
            NamespaceSymbol target;
            if (!this.DeclaringCompilation.GetExternAliasTarget(this.Name, out target))
            {
                diagnostics.Add(InternalErrorCode.ERR_BadExternAlias, this.Locations.FirstOrDefault(), this.Name);
            }

            Debug.Assert((object)target != null);

            return target;
        }

        private DeclaredSymbol ResolveAliasTarget(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Target), diagnostics, cancellationToken, out var result);
            return result;
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
    }
}
