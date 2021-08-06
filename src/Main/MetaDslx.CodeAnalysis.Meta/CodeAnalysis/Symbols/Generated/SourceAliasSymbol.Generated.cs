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
	public partial class SourceAliasSymbol : MetaDslx.CodeAnalysis.Symbols.Completion.CompletionAliasSymbol, MetaDslx.CodeAnalysis.Symbols.Source.ISourceSymbol
	{
        private readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

		public SourceAliasSymbol(Symbol containingSymbol, MergedDeclaration declaration, bool isError = false)
            : base(containingSymbol, isError)
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
        protected override global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol CompleteSymbolProperty_Target(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return SourceSymbolImplementation.AssignSymbolPropertyValue<global::MetaDslx.CodeAnalysis.Symbols.DeclaredSymbol>(this, nameof(Target), diagnostics, cancellationToken);
        }

        protected override void CompleteNonSymbolProperties(SourceLocation locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            SourceSymbolImplementation.AssignNonSymbolProperties(this, diagnostics, cancellationToken);
        }

        public partial class Error : SourceAliasSymbol, MetaDslx.CodeAnalysis.Symbols.IErrorSymbol
        {
            private readonly string _name;
            private readonly string _metadataName;
            private DiagnosticInfo _errorInfo;

            public Error(Symbol container, MergedDeclaration declaration, DiagnosticInfo? errorInfo)
                : base(container, declaration, true)
            {
                _name = declaration.Name;
                _metadataName = declaration.MetadataName;
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
