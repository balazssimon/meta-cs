using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public partial class MetadataNamedTypeSymbol
    {
        public class Missing : Error
        {
            public Missing(Symbol container, string name, string metadataName, DiagnosticInfo? errorInfo, object? modelObject) 
                : base(container, name, metadataName, errorInfo, modelObject)
            {
            }
        }

        public class Unsupported : Error
        {
            public Unsupported(Symbol container, string name, string metadataName, DiagnosticInfo? errorInfo, object? modelObject)
                : base(container, name, metadataName, errorInfo, modelObject)
            {
            }
        }

        /// <summary>
        /// An error type, used to represent the type of a type binding
        /// operation when binding fails.
        /// </summary>
        public class ExtendedError : Error
        {
            private readonly bool _unreported;
            public readonly bool VariableUsedBeforeDeclaration;
            private readonly ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong.
            private readonly LookupResultKind _resultKind; // why the guessSymbols were wrong.

            internal ExtendedError(LanguageCompilation compilation, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported = false, bool variableUsedBeforeDeclaration = false)
                : this(compilation.Assembly.GlobalNamespace, name, metadataName, errorInfo, unreported, variableUsedBeforeDeclaration)
            {
            }

            internal ExtendedError(DeclaredSymbol containingSymbol, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported = false, bool variableUsedBeforeDeclaration = false)
                : base(containingSymbol, name, metadataName, errorInfo, null)
            {
                Debug.Assert(((object)containingSymbol == null) || containingSymbol.IsError || containingSymbol is NamespaceOrTypeSymbol);

                Debug.Assert(name != null);
                Debug.Assert(unreported == false || errorInfo != null);

                _unreported = unreported;
                this.VariableUsedBeforeDeclaration = variableUsedBeforeDeclaration;
                _resultKind = LookupResultKind.Empty;
            }

            private ExtendedError(DeclaredSymbol containingSymbol, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported, bool variableUsedBeforeDeclaration, ImmutableArray<DeclaredSymbol> candidateSymbols, LookupResultKind resultKind)
                : base(containingSymbol, name, metadataName, errorInfo, null)
            {
                _unreported = unreported;
                this.VariableUsedBeforeDeclaration = variableUsedBeforeDeclaration;
                _candidateSymbols = candidateSymbols;
                _resultKind = resultKind;
            }

            internal ExtendedError(DeclaredSymbol guessSymbol, LookupResultKind resultKind, DiagnosticInfo errorInfo, bool unreported = false)
                : this(guessSymbol.ContainingDeclaration, guessSymbol, resultKind, errorInfo, unreported)
            {
            }

            internal ExtendedError(DeclaredSymbol containingSymbol, DeclaredSymbol guessSymbol, LookupResultKind resultKind, DiagnosticInfo errorInfo, bool unreported = false)
                : this(containingSymbol, ImmutableArray.Create<DeclaredSymbol>(guessSymbol), resultKind, errorInfo, guessSymbol.MetadataName, unreported)
            {
            }

            internal ExtendedError(DeclaredSymbol containingSymbol, ImmutableArray<DeclaredSymbol> candidateSymbols, LookupResultKind resultKind, DiagnosticInfo errorInfo, string metadataName, bool unreported = false)
                : this(containingSymbol, candidateSymbols[0].Name, metadataName, errorInfo, unreported)
            {
                _candidateSymbols = UnwrapErrorCandidates(candidateSymbols);
                _resultKind = resultKind;
                Debug.Assert(candidateSymbols.IsEmpty || resultKind != LookupResultKind.Viable, "Shouldn't use LookupResultKind.Viable with candidate symbols");
            }

            internal ExtendedError AsUnreported()
            {
                return this.Unreported ? this :
                    new ExtendedError(this.ContainingDeclaration, this.Name, this.MetadataName, this.ErrorInfo, true, VariableUsedBeforeDeclaration, _candidateSymbols, _resultKind);
            }

            private static ImmutableArray<DeclaredSymbol> UnwrapErrorCandidates(ImmutableArray<DeclaredSymbol> candidateSymbols)
            {
                var candidate = candidateSymbols.IsEmpty ? null : candidateSymbols[0] as ExtendedError;
                return ((object)candidate != null && !candidate.CandidateSymbols.IsEmpty) ? candidate.CandidateSymbols : candidateSymbols;
            }

            public LookupResultKind ResultKind => _resultKind;

            public ImmutableArray<DeclaredSymbol> CandidateSymbols => _candidateSymbols.NullToEmpty();

            public bool Unreported => _unreported;

            public override DiagnosticInfo GetUseSiteDiagnostic()
            {
                if (_unreported)
                {
                    return this.ErrorInfo;
                }

                return null;
            }

            public override NamedTypeSymbol OriginalDefinition => this;

            public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

            public override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
            {
                if (ReferenceEquals(this, t2))
                {
                    return true;
                }

                var other = t2 as ExtendedError;
                if ((object)other == null || _unreported || other._unreported)
                {
                    return false;
                }

                return
                    ((object)this.ContainingType != null ? this.ContainingType.Equals(other.ContainingType, comparison) :
                     (object)this.ContainingSymbol == null ? (object)other.ContainingSymbol == null : this.ContainingSymbol.Equals(other.ContainingSymbol)) &&
                    this.Name == other.Name && this.Arity == other.Arity;
            }

            public override int GetHashCode()
            {
                return Hash.Combine(this.Arity,
                            Hash.Combine((object)this.ContainingSymbol != null ? this.ContainingSymbol.GetHashCode() : 0,
                                         this.Name != null ? this.Name.GetHashCode() : 0));
            }

        }

    }
}
