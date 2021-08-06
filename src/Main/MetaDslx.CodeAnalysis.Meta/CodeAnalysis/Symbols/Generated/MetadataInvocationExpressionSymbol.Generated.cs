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
	public partial class MetadataInvocationExpressionSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionInvocationExpressionSymbol
	{
        public MetadataInvocationExpressionSymbol(Symbol container, object? modelObject, bool isError = false)
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

        protected override global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol CompleteSymbolProperty_Operation(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.ExpressionSymbol>(this, nameof(Operation), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.ArgumentSymbol> CompleteSymbolProperty_Arguments(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return ModelSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.ArgumentSymbol>(this, nameof(Arguments), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        public partial class Error : MetadataInvocationExpressionSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;
            private readonly bool _unreported;
            private ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong.

            public Error(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, object? modelObject)
                : base(container, modelObject, true)
            {
                _name = name;
                _metadataName = metadataName;
                _kind = kind;
                _errorInfo = errorInfo;
                _candidateSymbols = candidateSymbols;
                _unreported = unreported;
            }

            public Error AsUnreported()
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, _kind, ErrorInfo, CandidateSymbols, true, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)
            {
                return _kind == kind ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, CandidateSymbols, _unreported, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<DeclaredSymbol> candidateSymbols)
            {
                return _kind == kind && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, ErrorInfo, candidateSymbols, _unreported, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols)
            {
                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, kind, errorInfo, candidateSymbols, _unreported, this.ModelObject);
            }

            public Error WithErrorInfo(DiagnosticInfo errorInfo)
            {
                return ErrorInfo == errorInfo ? this :
                    Update(this.ContainingSymbol, _name, _metadataName, _kind, errorInfo, CandidateSymbols, _unreported, this.ModelObject);
            }

            protected virtual Error Update(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, object? modelObject)
            {
                return new Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }

            public override string Name => _name;

            public override string MetadataName => _metadataName;

            public sealed override bool IsError => true;

            public bool IsUnreported => _unreported;

            public MetaDslx.CodeAnalysis.Symbols.ErrorKind Kind => _kind;

            public ImmutableArray<DeclaredSymbol> CandidateSymbols
            {
                get
                {
                    if (_candidateSymbols.IsDefault)
                    {
                        System.Collections.Immutable.ImmutableInterlocked.InterlockedInitialize(ref _candidateSymbols, MakeCandidateSymbols());
                    }
                    return _candidateSymbols;
                }
            }

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

            protected virtual ImmutableArray<DeclaredSymbol> MakeCandidateSymbols()
            {
                return ImmutableArray<DeclaredSymbol>.Empty;
            }

            protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                return _name;
            }
        }
    }
}
