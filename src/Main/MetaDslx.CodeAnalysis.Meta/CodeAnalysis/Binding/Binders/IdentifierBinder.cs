using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.PooledObjects;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class IdentifierBinder : ValueBinder, IIdentifierBoundary
    {
        private string _name;
        private string _metadataName;

        public IdentifierBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion)
            : base(next, syntax, forCompletion)
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

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var qualifierBinder = this.GetQualifierBinder();
            if (qualifierBinder != null)
            {
                var boundQualifier = (BoundQualifier)qualifierBinder.Bind(null, cancellationToken);
                var index = boundQualifier.Identifiers.IndexOf(this.Syntax);
                Debug.Assert(index >= 0);
                return new BoundIdentifier(boundQualifier.IdentifierSymbols[index]);
            }
            else
            {
                var symbol = this.BindDeclaredSymbol(this.Syntax, diagnostics);
                return new BoundIdentifier(symbol);
            }
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            var baseConstraints = base.AdjustConstraints(constraints);
            if (this.IsCompletionBinder) return baseConstraints;
            else return baseConstraints.WithName(this.Name);
        }

    }
}
