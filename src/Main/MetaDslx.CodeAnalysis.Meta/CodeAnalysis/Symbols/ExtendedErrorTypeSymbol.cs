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
            Debug.Assert(((object)containingSymbol == null) || containingSymbol.IsError || containingSymbol is NamespaceOrTypeSymbol);

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
            : this(guessSymbol.ContainingDeclaration, guessSymbol, resultKind, errorInfo, unreported)
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
