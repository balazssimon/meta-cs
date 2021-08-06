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
	public partial class MetadataFieldSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionFieldSymbol
	{
        public MetadataFieldSymbol(Symbol container, object? modelObject, bool isError = false)
            : base(container, modelObject, isError)
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

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> CompleteSymbolProperty_TypeParameters(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol>(this, nameof(TypeParameters), diagnostics, cancellationToken);
        }

        protected override global::Microsoft.CodeAnalysis.Accessibility CompleteSymbolProperty_DeclaredAccessibility(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::Microsoft.CodeAnalysis.Accessibility>(this, nameof(DeclaredAccessibility), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsExtern(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsExtern), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> CompleteSymbolProperty_Members(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Members), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsStatic(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsStatic), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsVirtual(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsVirtual), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsOverride(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsOverride), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsAbstract(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsAbstract), diagnostics, cancellationToken);
        }

        protected override bool CompleteSymbolProperty_IsSealed(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsSealed), diagnostics, cancellationToken);
        }

        protected override global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol CompleteSymbolProperty_Type(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.TypeSymbol>(this, nameof(Type), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        public partial class Error : MetadataFieldSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;

            public Error(Symbol container, string name, string metadataName, DiagnosticInfo? errorInfo, object? modelObject)
                : base(container, modelObject, true)
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
