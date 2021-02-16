// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// An error type, used to represent the type of a type binding
    /// operation when binding fails.
    /// </summary>
    internal sealed class ExtendedErrorTypeSymbol : ErrorTypeSymbol
    {
        private readonly string _name;
        private readonly string _metadataName;
        private readonly DiagnosticInfo _errorInfo;
        private readonly DeclaredSymbol _containingSymbol;
        private readonly bool _unreported;
        public readonly bool VariableUsedBeforeDeclaration;
        private readonly ImmutableArray<DeclaredSymbol> _candidateSymbols;  // Best guess at what user meant, but was wrong.
        private readonly LookupResultKind _resultKind; // why the guessSymbols were wrong.

        internal ExtendedErrorTypeSymbol(LanguageCompilation compilation, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported = false, bool variableUsedBeforeDeclaration = false)
            : this(compilation.Assembly.GlobalNamespace, name, metadataName, errorInfo, unreported, variableUsedBeforeDeclaration)
        {
        }

        internal ExtendedErrorTypeSymbol(DeclaredSymbol containingSymbol, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported = false, bool variableUsedBeforeDeclaration = false)
        {
            Debug.Assert(((object)containingSymbol == null) ||
                (containingSymbol.Kind == LanguageSymbolKind.Namespace) ||
                (containingSymbol.Kind == LanguageSymbolKind.NamedType) ||
                (containingSymbol.Kind == LanguageSymbolKind.ErrorType));

            Debug.Assert(name != null);
            Debug.Assert(unreported == false || errorInfo != null);

            _name = name;
            _errorInfo = errorInfo;
            _containingSymbol = containingSymbol;
            _metadataName = metadataName;
            _unreported = unreported;
            this.VariableUsedBeforeDeclaration = variableUsedBeforeDeclaration;
            _resultKind = LookupResultKind.Empty;
        }

        private ExtendedErrorTypeSymbol(DeclaredSymbol containingSymbol, string name, string metadataName, DiagnosticInfo errorInfo, bool unreported, bool variableUsedBeforeDeclaration, ImmutableArray<DeclaredSymbol> candidateSymbols, LookupResultKind resultKind)
        {
            _name = name;
            _errorInfo = errorInfo;
            _containingSymbol = containingSymbol;
            _metadataName = metadataName;
            _unreported = unreported;
            this.VariableUsedBeforeDeclaration = variableUsedBeforeDeclaration;
            _candidateSymbols = candidateSymbols;
            _resultKind = resultKind;
        }

        internal ExtendedErrorTypeSymbol(DeclaredSymbol guessSymbol, LookupResultKind resultKind, DiagnosticInfo errorInfo, bool unreported = false)
            : this(guessSymbol.ContainingNamespaceOrType(), guessSymbol, resultKind, errorInfo, unreported)
        {
        }

        internal ExtendedErrorTypeSymbol(DeclaredSymbol containingSymbol, DeclaredSymbol guessSymbol, LookupResultKind resultKind, DiagnosticInfo errorInfo, bool unreported = false)
            : this(containingSymbol, ImmutableArray.Create<DeclaredSymbol>(guessSymbol), resultKind, errorInfo, guessSymbol.MetadataName, unreported)
        {
        }

        internal ExtendedErrorTypeSymbol(DeclaredSymbol containingSymbol, ImmutableArray<DeclaredSymbol> candidateSymbols, LookupResultKind resultKind, DiagnosticInfo errorInfo, string metadataName, bool unreported = false)
            : this(containingSymbol, candidateSymbols[0].Name, metadataName, errorInfo, unreported)
        {
            _candidateSymbols = UnwrapErrorCandidates(candidateSymbols);
            _resultKind = resultKind;
            Debug.Assert(candidateSymbols.IsEmpty || resultKind != LookupResultKind.Viable, "Shouldn't use LookupResultKind.Viable with candidate symbols");
        }

        internal ExtendedErrorTypeSymbol AsUnreported()
        {
            return this.Unreported ? this :
                new ExtendedErrorTypeSymbol(_containingSymbol, _name, _metadataName, _errorInfo, true, VariableUsedBeforeDeclaration, _candidateSymbols, _resultKind);
        }

        private static ImmutableArray<DeclaredSymbol> UnwrapErrorCandidates(ImmutableArray<DeclaredSymbol> candidateSymbols)
        {
            var candidate = candidateSymbols.IsEmpty ? null : candidateSymbols[0] as ErrorTypeSymbol;
            return ((object)candidate != null && !candidate.CandidateSymbols.IsEmpty) ? candidate.CandidateSymbols : candidateSymbols;
        }

        public override DiagnosticInfo ErrorInfo
        {
            get
            {
                return _errorInfo;
            }
        }

        internal override LookupResultKind ResultKind
        {
            get
            {
                return _resultKind;
            }
        }

        public override ImmutableArray<DeclaredSymbol> CandidateSymbols => _candidateSymbols.NullToEmpty();

        public override bool Unreported
        {
            get { return _unreported; }
        }

        public override DiagnosticInfo GetUseSiteDiagnostic()
        {
            if (_unreported)
            {
                return this.ErrorInfo;
            }

            return null;
        }

        public override string MetadataName => _metadataName;

        public override bool MangleName => _name != _metadataName;

        public override Symbol ContainingSymbol => _containingSymbol;

        public override string Name => _name;

        public override NamedTypeSymbol OriginalDefinition => this;
        
        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        /// <summary>
        /// If (we believe) we know which symbol the user intended, then we should retain that information
        /// in the corresponding error symbol - it can be useful for deciding how to handle the error.
        /// For example, we might want to know whether (we believe) the error type was supposed to be an
        /// interface, so that we can put it in a derived type's interface list, rather than in the base
        /// type slot.
        /// 
        /// Sometimes we will return the original definition of the intended symbol.  For example, if we see 
        /// <![CDATA[IGoo<int>]]> and we have an IGoo with a different arity or accessibility 
        /// (e.g. <![CDATA[IGoo<int>]]> was constructed from an error symbol based on <![CDATA[IGoo<T>]]>), 
        /// then we'll return <![CDATA[IGoo<T>]]>, rather than trying to construct a corresponding closed
        /// type (which may not be difficult/possible in the case of nested types or mismatched arities).
        /// 
        /// NOTE: Any non-null type symbol returned is guaranteed not to be an error type.
        /// </summary>
        /// <remarks>
        /// TypeSymbolExtensions.GetNonErrorGuess is a more discoverable version of this functionality.
        /// However, the real definition is in this class so that it can access the private field 
        /// nonErrorGuessType.
        /// </remarks>
        internal static TypeSymbol ExtractNonErrorType(TypeSymbol oldSymbol)
        {
            if ((object)oldSymbol == null || oldSymbol.TypeKind != LanguageTypeKind.Error)
            {
                return oldSymbol;
            }

            // At this point, we know that oldSymbol is a non-null type symbol with kind error.
            // Hence, it is either an ErrorTypeSymbol or it has an ErrorTypeSymbol as its
            // original definition.  In the former case, it is its own original definition.
            // Thus, if there's a CSErrorTypeSymbol in there somewhere, it's returned by
            // OriginalDefinition.
            ExtendedErrorTypeSymbol oldError = oldSymbol.OriginalDefinition as ExtendedErrorTypeSymbol;

            // If the original definition isn't a CSErrorTypeSymbol, then we don't know how to
            // pull out a non-error type.  If it is, then if there is a unambiguous type inside it,
            // use that.
            if ((object)oldError != null && !oldError._candidateSymbols.IsDefault && oldError._candidateSymbols.Length == 1)
            {
                TypeSymbol type = oldError._candidateSymbols[0] as TypeSymbol;
                if ((object)type != null)
                    return type.GetNonErrorGuess();
            }

            return null;
        }

        // Get the type kind of a symbol, going to candidates if possible.
        internal static LanguageTypeKind ExtractNonErrorTypeKind(TypeSymbol oldSymbol)
        {
            if (oldSymbol.TypeKind != LanguageTypeKind.Error)
            {
                return oldSymbol.TypeKind;
            }

            // At this point, we know that oldSymbol is a non-null type symbol with kind error.
            // Hence, it is either an ErrorTypeSymbol or it has an ErrorTypeSymbol as its
            // original definition.  In the former case, it is its own original definition.
            // Thus, if there's a CSErrorTypeSymbol in there somewhere, it's returned by
            // OriginalDefinition.
            ExtendedErrorTypeSymbol oldError = oldSymbol.OriginalDefinition as ExtendedErrorTypeSymbol;

            // If the original definition isn't a CSErrorTypeSymbol, then we don't know how to
            // pull out a non-error type.  If it is, then if there is a unambiguous type inside it,
            // use that.
            LanguageTypeKind commonTypeKind = LanguageTypeKind.Error;
            if ((object)oldError != null && !oldError._candidateSymbols.IsDefault && oldError._candidateSymbols.Length > 0)
            {
                foreach (Symbol sym in oldError._candidateSymbols)
                {
                    TypeSymbol type = sym as TypeSymbol;
                    if ((object)type != null && type.TypeKind != LanguageTypeKind.Error)
                    {
                        if (commonTypeKind == LanguageTypeKind.Error)
                            commonTypeKind = type.TypeKind;
                        else if (commonTypeKind != type.TypeKind)
                            return LanguageTypeKind.Error;  // no common kind.
                    }
                }
            }

            return commonTypeKind;
        }

        public override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
        {
            if (ReferenceEquals(this, t2))
            {
                return true;
            }

            var other = t2 as ExtendedErrorTypeSymbol;
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
