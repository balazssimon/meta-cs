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
    public abstract partial class ErrorTypeSymbol : NamedTypeSymbol
    {
        internal static readonly ErrorTypeSymbol UnknownResultType = new UnsupportedMetadataTypeSymbol();

        public override bool IsError => true;
        public override bool IsStatic => false;

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

        public override ImmutableArray<DeclaredSymbol> Members => ImmutableArray<DeclaredSymbol>.Empty;

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

        public override ImmutableArray<NamedTypeSymbol> BaseTypes => ImmutableArray<NamedTypeSymbol>.Empty;

        public virtual bool Unreported
        {
            get { return false; }
        }

    }

}
