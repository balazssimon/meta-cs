using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            return new BoundIdentifier(); 
        }

    }
}
