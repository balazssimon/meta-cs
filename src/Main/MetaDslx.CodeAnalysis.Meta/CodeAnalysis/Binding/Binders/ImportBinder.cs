using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class ImportBinder : Binder, ISymbolBoundary
    {
        private bool _isExtern;
        private bool _isStatic;

        public ImportBinder(Binder next, SyntaxNodeOrToken syntax, bool isExtern, bool isStatic, bool forCompletion) 
            : base(next, syntax, forCompletion)
        {
            _isExtern = isExtern;
            _isStatic = isStatic;
        }

        public bool IsExtern => _isExtern;
        public bool IsStatic => _isStatic;

        protected override bool ContinueLookup => false;

        public override bool IsValidCompletionBinder
        {
            get
            {
                var binder = this.Next;
                while (binder != null)
                {
                    if ((binder is ISymbolBoundary) && binder.IsCompletionBinder) return false;
                    binder = binder.Next;
                }
                return true;
            }
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var imports = GetImports();
            var usingDirective = imports.Usings.FirstOrDefault(ud => ud.UsingDirective.Syntax == this.Syntax);
            return new BoundImport(usingDirective.DeclaredSymbol);
        }

        public virtual DeclaredSymbol BindImportedSymbol(Binder usingsBinder, UsingDirective usingDirective, LookupConstraints constraints, DiagnosticBag diagnostics)
        {
            var declarationBinder = usingsBinder.WithAdditionalFlags(BinderFlags.SuppressConstraintChecks);
            var target = declarationBinder.BindQualifiedName(usingDirective.TargetQualifiedName, diagnostics, constraints.WithInUsing(true));
            var imported = target.Length > 0 ? target[target.Length - 1] : null;
            if (imported == null) return null;
            if (imported is NamespaceSymbol)
            {
                if (usingDirective.IsStatic)
                {
                    diagnostics.Add(InternalErrorCode.ERR_BadUsingType, usingDirective.TargetName.GetLocation(), imported);
                }
            }
            else if (imported is NamedTypeSymbol)
            {
                if (usingDirective.IsStatic)
                {
                    diagnostics.Add(InternalErrorCode.ERR_BadUsingNamespace, usingDirective.TargetName.GetLocation(), imported);
                }
            }
            else 
            {
                // error: '<symbol>' is a '<symbol kind>' but is used as 'type or namespace'
                diagnostics.Add(InternalErrorCode.ERR_BadSKknown, usingDirective.TargetName.GetLocation(), usingDirective.TargetName, imported.GetKindText(), "type or namespace");
            }
            return imported;
        }

        protected override bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            // lookup via "using static" ignores non-static members
            return symbol is NamespaceSymbol || symbol is TypeSymbol || (this.IsStatic && symbol is MemberSymbol memberSymbol && memberSymbol.IsStatic);
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return base.AdjustConstraints(constraints).WithAdditionalValidators(this);
        }

        protected sealed override void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            var imports = GetImports();
            var importedSymbol = imports.GetImportedSymbol(this.Syntax);
            if (importedSymbol == null) return;
            var importedCandidates = LookupCandidates.GetInstance();
            this.AddLookupCandidateSymbolsForImport(importedSymbol, importedCandidates, constraints);
            foreach (var symbol in importedCandidates.Symbols)
            {
                if (constraints.IsViable(symbol))
                {
                    result.Add(symbol);
                    if (constraints.IsLookup)
                    {
                        this.Compilation.MarkImportDirectiveAsUsed(this.Syntax);
                    }
                }
            }
        }

        protected virtual void AddLookupCandidateSymbolsForImport(DeclaredSymbol importedSymbol, LookupCandidates result, LookupConstraints constraints)
        {
            result.AddRange(importedSymbol.GetMembersUnordered());
        }
    }
}
