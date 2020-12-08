using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Microsoft.CodeAnalysis
{
    /// <summary>
    /// Represents a declaration symbol (namespace, class, method, parameter, etc.)
    /// exposed by the compiler.
    /// </summary>
    /// <remarks>
    /// This interface is reserved for implementation by its associated APIs. We reserve the right to
    /// change it in the future.
    /// </remarks>
    public interface IDeclaredSymbol : ISymbol
    {
        /// <summary>
        /// Gets the <see cref="INamedTypeSymbol"/> for the containing type. Returns null if the
        /// symbol is not contained within a type.
        /// </summary>
        INamedTypeSymbol ContainingType { get; }

        /// <summary>
        /// Gets the <see cref="INamespaceSymbol"/> for the nearest enclosing namespace. Returns null if the
        /// symbol isn't contained in a namespace.
        /// </summary>
        INamespaceSymbol ContainingNamespace { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is the original definition. Returns false
        /// if the symbol is derived from another symbol, by type substitution for instance.
        /// </summary>
        bool IsDefinition { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is static.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is virtual.
        /// </summary>
        bool IsVirtual { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is an override of a base class symbol.
        /// </summary>
        bool IsOverride { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is abstract.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is sealed.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        /// Gets a value indicating whether the symbol is defined externally.
        /// </summary>
        bool IsExtern { get; }

        /// <summary>
        /// Returns true if this symbol was automatically created by the compiler, and does not have
        /// an explicit corresponding source code declaration. 
        /// </summary> 
        /// <remarks>
        /// This is intended for symbols that are ordinary symbols in the language sense, and may be
        /// used by code, but that are simply declared implicitly rather than with explicit language
        /// syntax.
        /// 
        /// <para>
        /// Examples include (this list is not exhaustive):
        /// <list type="bullet">
        /// <item> the default constructor for a class or struct that is created if one is not provided, </item>
        /// <item> the BeginInvoke/Invoke/EndInvoke methods for a delegate, </item>
        /// <item> the generated backing field for an auto property or a field-like event, </item>
        /// <item> the "this" parameter for non-static methods, </item>
        /// <item> the "value" parameter for a property setter, </item>
        /// <item> the parameters on indexer accessor methods (not on the indexer itself), </item>
        /// <item> methods in anonymous types </item>
        /// </list>
        /// </para>
        /// </remarks>
        bool IsImplicitlyDeclared { get; }

        /// <summary>
        /// Returns true if this symbol can be referenced by its name in code.
        /// </summary>
        bool CanBeReferencedByName { get; }

        /// <summary>
        /// Get the syntax node(s) where this symbol was declared in source. Some symbols (for example,
        /// partial classes) may be defined in more than one location. This property should return
        /// one or more syntax nodes only if the symbol was declared in source code and also was
        /// not implicitly declared (see the IsImplicitlyDeclared property). 
        /// 
        /// <para>
        /// Note that for namespace symbol, the declaring syntax might be declaring a nested namespace.
        /// For example, the declaring syntax node for N1 in "namespace N1.N2 {...}" is the entire
        /// NamespaceDeclarationSyntax for N1.N2. For the global namespace, the declaring syntax will
        /// be the CompilationUnitSyntax.
        /// </para>
        /// </summary>
        /// <returns>
        /// The syntax node(s) that declared the symbol. If the symbol was declared in metadata
        /// or was implicitly declared, returns an empty read-only array.
        /// </returns>
        ImmutableArray<SyntaxReference> DeclaringSyntaxReferences { get; }

        /// <summary>
        /// Gets a <see cref="Accessibility"/> indicating the declared accessibility for the symbol.
        /// Returns NotApplicable if no accessibility is declared.
        /// </summary>
        Accessibility DeclaredAccessibility { get; }

        /// <summary>
        /// Gets the <see cref="IDeclaredSymbol"/> for the original definition of the symbol.
        /// If this symbol is derived from another symbol, by type substitution for instance,
        /// this gets the original symbol, as it was defined in source or metadata.
        /// </summary>
        IDeclaredSymbol OriginalDefinition { get; }

        /// <summary>
        /// Returns the Documentation Comment ID for the symbol, or null if the symbol doesn't
        /// support documentation comments.
        /// </summary>
        string GetDocumentationCommentId();

        /// <summary>
        /// Gets the XML (as text) for the comment associated with the symbol.
        /// </summary>
        /// <param name="preferredCulture">Preferred culture or null for the default.</param>
        /// <param name="expandIncludes">Optionally, expand &lt;include&gt; elements.  No impact on non-source documentation comments.</param>
        /// <param name="cancellationToken">Token allowing cancellation of request.</param>
        /// <returns>The XML that would be written to the documentation file for the symbol.</returns>
        string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken));

    }

}
