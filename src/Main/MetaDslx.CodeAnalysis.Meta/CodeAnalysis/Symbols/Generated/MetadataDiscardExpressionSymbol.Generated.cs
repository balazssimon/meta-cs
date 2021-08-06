using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
	public partial class MetadataDiscardExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionDiscardExpressionSymbol
	{
        public MetadataDiscardExpressionSymbol(Symbol container, bool isError = false)
            : base(container, isError)
        {
        }

        public override ImmutableArray<Location> Locations => this.ContainingModule.Locations;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        public partial class Error : MetadataDiscardExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;

            public Error(Symbol container, string name, string metadataName, DiagnosticInfo? errorInfo)
                : base(container, true)
            {
                _name = name;
                _metadataName = metadataName;
                _errorInfo = errorInfo;
            }

            public sealed override bool IsError => true;

            public override string Name => _name;

            public override string MetadataName => _metadataName;

            public DiagnosticInfo? ErrorInfo
            {
                get
                {
                    if (_errorInfo is null)
                    {
                        System.Threading.Interlocked.CompareExchange(ref _errorInfo, MakeErrorInfo(), null);
                    }
                    return _errorInfo;
                }
            }

            protected virtual DiagnosticInfo? MakeErrorInfo()
            {
                return null;
            }

            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _name;
            }
        }
    }
}
