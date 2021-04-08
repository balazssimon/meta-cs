using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.PooledObjects;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class IdentifierBinder : ValueBinder, IIdentifierBoundary
    {
        private string _name;
        private string _metadataName;

        public IdentifierBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

        public string Name
        {
            get
            {
                if (_name == null)
                {
                    var name = Language.SyntaxFacts.ExtractName(this.Syntax);
                    Interlocked.CompareExchange(ref _name, name, null);
                }
                return _name;
            }
        }

        public string MetadataName
        {
            get
            {
                if (_metadataName == null)
                {
                    var metadataName = Language.SyntaxFacts.ExtractMetadataName(this.Syntax);
                    Interlocked.CompareExchange(ref _metadataName, metadataName, null);
                }
                return _metadataName;
            }
        }

        protected QualifierBinder GetQualifierBinder()
        {
            return QualifierBinder.GetTopmostQualifierBinder(this);
        }

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            var qualifierBinder = this.GetQualifierBinder();
            if (qualifierBinder != null)
            {
                var boundQualifier = (BoundQualifier)qualifierBinder.Bind(cancellationToken);
                var index = boundQualifier.Identifiers.IndexOf(this.Syntax);
                Debug.Assert(index >= 0);
                return new BoundIdentifier(boundQualifier.IdentifierSymbols[index], ImmutableArray<Diagnostic>.Empty); // Diagnostics are reported by the qualifier
            }
            else
            {
                var diagnostics = DiagnosticBag.GetInstance();
                var symbol = this.BindDeclaredSymbol(this.Syntax, diagnostics);
                return new BoundIdentifier(symbol, diagnostics.ToReadOnlyAndFree());
            }
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return base.AdjustConstraints(constraints).WithName(this.Name, this.MetadataName);
        }

    }
}
