using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
	public partial class SourceTypeParameterSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionTypeParameterSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

		public SourceTypeParameterSymbol(Symbol containingSymbol, MergedDeclaration declaration, object? modelObject, bool isError = false)
            : base(containingSymbol, modelObject, isError)
        {
            if (declaration is null) throw new ArgumentNullException(nameof(declaration));
            _declaration = declaration;
		}

        public MergedDeclaration MergedDeclaration => _declaration;

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public BinderPosition<SymbolBinder> GetBinder(SyntaxReference reference)
        {
            Debug.Assert(this.DeclaringSyntaxReferences.Contains(reference));
            return FindBinders.FindSymbolBinder(this, reference);
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            foreach (var child in this.ChildSymbols)
            {
                if (child.DeclaringSyntaxReferences.Any(sr => sr.GetLocation() == syntax.GetLocation()))
                {
                    return child;
                }
            }
            return null;
        }
        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(this.MergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        protected override void CompleteInitializingSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
        }

        protected override ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.MakeChildSymbols(this, nameof(ChildSymbols), diagnostics, cancellationToken);
        }

        protected override void CompleteImports(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SourceSymbolImplementation.CompleteImports(this, locationOpt, diagnostics, cancellationToken);
        }

        protected override string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<string>(this, nameof(Name), diagnostics, cancellationToken);
        }

        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.Symbol> CompleteSymbolProperty_Attributes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.Symbol>(this, nameof(Attributes), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol> CompleteSymbolProperty_TypeParameters(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.TypeParameterSymbol>(this, nameof(TypeParameters), diagnostics, cancellationToken);
        }
        protected override global::Microsoft.CodeAnalysis.Accessibility CompleteSymbolProperty_DeclaredAccessibility(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<global::Microsoft.CodeAnalysis.Accessibility>(this, nameof(DeclaredAccessibility), diagnostics, cancellationToken);
        }
        protected override bool CompleteSymbolProperty_IsExtern(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<bool>(this, nameof(IsExtern), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol> CompleteSymbolProperty_Members(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Members), diagnostics, cancellationToken);
        }
        protected override global::System.Collections.Immutable.ImmutableArray<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol> CompleteSymbolProperty_BaseTypes(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValues<global::MetaDslx.CodeAnalysis.Symbols.NamedTypeSymbol>(this, nameof(BaseTypes), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);
        }

        public partial class Error : SourceTypeParameterSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;
            private readonly MetaDslx.CodeAnalysis.Symbols.ErrorKind _kind;
            private readonly bool _unreported;
            private ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong.

            public Error(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, object? modelObject)
                : base(container, declaration, modelObject, true)
            {
                _name = declaration.Name;
                _metadataName = declaration.MetadataName;
                _kind = kind;
                _errorInfo = errorInfo;
                _candidateSymbols = candidateSymbols;
                _unreported = unreported;
            }

            public Error AsUnreported()
            {
                return this.IsUnreported ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, ErrorInfo, CandidateSymbols, true, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind)
            {
                return _kind == kind ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, CandidateSymbols, _unreported, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, ImmutableArray<DeclaredSymbol> candidateSymbols)
            {
                return _kind == kind && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, ErrorInfo, candidateSymbols, _unreported, this.ModelObject);
            }

            public Error AsKind(MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols)
            {
                return _kind == kind && ErrorInfo == errorInfo && CandidateSymbols == candidateSymbols ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, kind, errorInfo, candidateSymbols, _unreported, this.ModelObject);
            }

            public Error WithErrorInfo(DiagnosticInfo errorInfo)
            {
                return ErrorInfo == errorInfo ? this :
                    Update(this.ContainingSymbol, this.MergedDeclaration, _kind, errorInfo, CandidateSymbols, _unreported, this.ModelObject);
            }

            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<DeclaredSymbol> candidateSymbols, bool unreported, object? modelObject)
            {
                return new Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
            }

            public override string Name => _name;

            public override string MetadataName => _metadataName;

            public sealed override bool IsError => true;

            public bool IsUnreported => _unreported;

            public MetaDslx.CodeAnalysis.Symbols.ErrorKind ErrorKind => _kind;

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

            public DiagnosticInfo? UseSiteDiagnosticInfo => _unreported ? ErrorInfo : null;

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
