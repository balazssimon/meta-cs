// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents a symbol (namespace, class, method, parameter, etc.)
    /// exposed by the compiler.
    /// </summary>
    /// <remarks>
    /// This interface is reserved for implementation by its associated APIs. We reserve the right to
    /// change it in the future.
    /// </remarks>
    //[InternalImplementationOnly]
    public interface ISymbol : IEquatable<ISymbol>
    {
        /// <summary>
        /// Gets the <see cref="SymbolKind"/> indicating what kind of symbol it is.
        /// </summary>
        SymbolKind Kind { get; }

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        string Language { get; }

        /// <summary>
        /// Gets the symbol name. Returns the empty string if unnamed.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the name of a symbol as it appears in metadata. Most of the time, this
        /// is the same as the Name property, with the following exceptions:
        /// <list type="number">
        /// <item>
        /// <description>The metadata name of generic types includes the "`1", "`2" etc. suffix that
        /// indicates the number of type parameters (it does not include, however, names of
        /// containing types or namespaces). </description>
        /// </item>
        /// <item>
        /// <description>The metadata name of explicit interface names have spaces removed, compared to
        /// the name property.</description>
        /// </item>
        /// <item>
        /// <description>The length of names is limited to not exceed metadata restrictions.</description>
        /// </item>
        /// </list>
        /// </summary>
        string MetadataName { get; }

        /// <summary>
        /// Gets the <see cref="ISymbol"/> for the immediately containing symbol.
        /// </summary>
        ISymbol ContainingSymbol { get; }

        /// <summary>
        /// Gets the <see cref="IAssemblySymbol"/> for the containing assembly. Returns null if the
        /// symbol is shared across multiple assemblies.
        /// </summary>
        IAssemblySymbol ContainingAssembly { get; }

        /// <summary>
        /// Gets the <see cref="IModuleSymbol"/> for the containing module. Returns null if the
        /// symbol is shared across multiple modules.
        /// </summary>
        IModuleSymbol ContainingModule { get; }

        /// <summary>
        /// Gets the locations where the symbol was originally defined, either in source or
        /// metadata. Some symbols (for example, partial classes) may be defined in more than one
        /// location.
        /// </summary>
        ImmutableArray<Location> Locations { get; }

        /// <summary>
        /// Gets the attributes for the symbol. Returns an empty <see cref="IEnumerable{ISymbolAttribute}"/>
        /// if there are no attributes.
        /// </summary>
        ImmutableArray<AttributeData> GetAttributes();

        void Accept(SymbolVisitor visitor);
        TResult Accept<TResult>(SymbolVisitor<TResult> visitor);

        /// <summary>
        /// Converts the symbol to a string representation.
        /// </summary>
        /// <param name="format">Format or null for the default.</param>
        /// <returns>A formatted string representation of the symbol.</returns>
        string ToDisplayString(SymbolDisplayFormat format = null);

        /// <summary>
        /// Convert a symbol to an array of string parts, each of which has a kind. Useful for
        /// colorizing the display string.
        /// </summary>
        /// <param name="format">Formatting rules - null implies
        /// SymbolDisplayFormat.ErrorMessageFormat.</param>
        /// <returns>A read-only array of string parts.</returns>
        ImmutableArray<SymbolDisplayPart> ToDisplayParts(SymbolDisplayFormat format = null);

        /// <summary>
        /// Convert a symbol to a string that can be displayed to the user. May be tailored to a
        /// specific location in the source code.
        /// </summary>
        /// <param name="semanticModel">Binding information (for determining names appropriate to
        /// the context).</param>
        /// <param name="position">A position in the source code (context).</param>
        /// <param name="format">Formatting rules - null implies
        /// SymbolDisplayFormat.MinimallyQualifiedFormat.</param>
        /// <returns>A formatted string that can be displayed to the user.</returns>
        string ToMinimalDisplayString(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format = null);

        /// <summary>
        /// Convert a symbol to an array of string parts, each of which has a kind. May be tailored
        /// to a specific location in the source code. Useful for colorizing the display string.
        /// </summary>
        /// <param name="semanticModel">Binding information (for determining names appropriate to
        /// the context).</param>
        /// <param name="position">A position in the source code (context).</param>
        /// <param name="format">Formatting rules - null implies
        /// SymbolDisplayFormat.MinimallyQualifiedFormat.</param>
        /// <returns>A read-only array of string parts.</returns>
        ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format = null);

        /// <summary>
        /// Indicates that this symbol uses metadata that cannot be supported by the language.
        /// 
        /// <para>
        /// Examples include:
        /// <list type="bullet">
        /// <item> Pointer types in VB </item>
        /// <item> ByRef return type </item>
        /// <item> Required custom modifiers </item>
        /// </list>
        /// </para>
        /// 
        /// <para>
        /// This is distinguished from, for example, references to metadata symbols defined in assemblies that weren't referenced.
        /// Symbols where this returns true can never be used successfully, and thus should never appear in any IDE feature.
        /// </para>
        /// 
        /// <para>
        /// This is set for metadata symbols, as follows:
        /// <list type="bullet">
        /// <item> Type - if a type is unsupported (e.g., a pointer type, etc.) </item>
        /// <item> Method - parameter or return type is unsupported </item>
        /// <item> Field - type is unsupported </item>
        /// <item> Event - type is unsupported </item>
        /// <item> Property - type is unsupported </item>
        /// <item> Parameter - type is unsupported </item>
        /// </list>
        /// </para>
        /// </summary>
        bool HasUnsupportedMetadata { get; }
    }

}
