// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// An ErrorSymbol is used when the compiler cannot determine a symbol object to return because
    /// of an error. For example, if a field is declared "Goo x;", and the type "Goo" cannot be
    /// found, an ErrorSymbol is returned when asking the field "x" what it's type is.
    /// </summary>
    [Symbol]
    public abstract partial class ErrorTypeSymbol : NamedTypeSymbol
    {
        internal static readonly ErrorTypeSymbol UnknownResultType = new UnsupportedMetadataTypeSymbol();

        /// <summary>
        /// The underlying error.
        /// </summary>
        public abstract DiagnosticInfo ErrorInfo { get; }

        /// <summary>
        /// Summary of the reason why the type is bad.
        /// </summary>
        internal virtual LookupResultKind ResultKind { get { return LookupResultKind.Empty; } }

        /// <summary>
        /// When constructing this ErrorTypeSymbol, there may have been symbols that seemed to
        /// be what the user intended, but were unsuitable. For example, a type might have been
        /// inaccessible, or ambiguous. This property returns the possible symbols that the user
        /// might have intended. It will return no symbols if no possible symbols were found.
        /// See the CandidateReason property to understand why the symbols were unsuitable.
        /// </summary>
        public virtual ImmutableArray<DeclaredSymbol> CandidateSymbols => ImmutableArray<DeclaredSymbol>.Empty;

        ///<summary>
        /// If CandidateSymbols returns one or more symbols, returns the reason that those
        /// symbols were not chosen. Otherwise, returns None.
        /// </summary>
        public CandidateReason CandidateReason
        {
            get
            {
                if (!CandidateSymbols.IsEmpty)
                {
                    Debug.Assert(ResultKind != LookupResultKind.Viable, "Shouldn't have viable result kind on error symbol");
                    return ResultKind.ToCandidateReason();
                }
                else
                {
                    return CandidateReason.None;
                }
            }
        }

        public override DiagnosticInfo GetUseSiteDiagnostic()
        {
            return this.ErrorInfo;
        }

        /// <summary>
        /// Collection of names of members declared within this type.
        /// </summary>
        public override IEnumerable<string> MemberNames => SpecializedCollections.EmptyEnumerable<string>();

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns Null.</returns>
        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns Null.</returns>
        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns Null.</returns>
        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        /// <summary>
        /// Get all the members of this symbol that are types.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name, of any arity.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name.
        /// If this symbol has no type members with this name,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        /// <summary>
        /// Gets the kind of this symbol.
        /// </summary>
        public sealed override SymbolKind Kind => SymbolKind.ErrorType;

        /// <summary>
        /// Gets the kind of this type.
        /// </summary>
        public sealed override TypeKind TypeKind => TypeKind.Error;

        /// <summary>
        /// Get the symbol that logically contains this symbol. 
        /// </summary>
        public override Symbol ContainingSymbol => null;

        /// <summary>
        /// Gets the locations where this symbol was originally defined, either in source or
        /// metadata. Some symbols (for example, partial classes) may be defined in more than one
        /// location.
        /// </summary>
        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        /// <summary>
        /// Gets the name of this symbol. Symbols without a name return the empty string; null is
        /// never returned.
        /// </summary>
        public override string Name => string.Empty;

        // Only the compiler should create error symbols.
        internal ErrorTypeSymbol()
        {
        }

        /// <summary>
        /// Get this accessibility that was declared on this symbol. For symbols that do not have
        /// accessibility declared on them, returns NotApplicable.
        /// </summary>
        public sealed override Accessibility DeclaredAccessibility => Accessibility.NotApplicable;

        public override ImmutableArray<NamedTypeSymbol> BaseTypesNoUseSiteDiagnostics => ImmutableArray<NamedTypeSymbol>.Empty;

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public virtual bool Unreported
        {
            get { return false; }
        }

        protected sealed override ISymbol CreateISymbol()
        {
            return new PublicModel.ErrorTypeSymbol(this, DefaultNullableAnnotation);
        }

        protected sealed override ITypeSymbol CreateITypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            Debug.Assert(nullableAnnotation != DefaultNullableAnnotation);
            return new PublicModel.ErrorTypeSymbol(this, nullableAnnotation);
        }
    }

}
