using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes in a Compilation. Typically,
    /// an instance is obtained by a call to GetBinding on a Compilation or Compilation.
    /// </summary>
    /// <remarks>
    /// <para>An instance of SemanticModel caches local symbols and semantic information. Thus, it
    /// is much more efficient to use a single instance of SemanticModel when asking multiple
    /// questions about a syntax tree, because information from the first question may be reused.
    /// This also means that holding onto an instance of SemanticModel for a long time may keep a
    /// significant amount of memory from being garbage collected.
    /// </para>
    /// <para>
    /// When an answer is a named symbol that is reachable by traversing from the root of the symbol
    /// table, (that is, from an AssemblySymbol of the Compilation), that symbol will be returned
    /// (i.e. the returned value will be reference-equal to one reachable from the root of the
    /// symbol table). Symbols representing entities without names (e.g. array-of-int) may or may
    /// not exhibit reference equality. However, some named symbols (such as local variables) are
    /// not reachable from the root. These symbols are visible as answers to semantic questions.
    /// When the same SemanticModel object is used, the answers exhibit reference-equality.
    /// </para>
    /// </remarks>
    public abstract class SemanticModel
    {
        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public virtual Language Language
        {
            get { return this.Compilation.Language; }
        }

        /// <summary>
        /// The root node of the syntax tree that this binding is based on.
        /// </summary>
        public SyntaxNode Root
        {
            get { return this.RootCore; }
        }

        protected abstract SyntaxNode RootCore { get; }

        /// <summary>
        /// The compilation this model was obtained from.
        /// </summary>
        public CompilationBase Compilation
        {
            get { return CompilationCore; }
        }

        /// <summary>
        /// The compilation this model was obtained from.
        /// </summary>
        protected abstract CompilationBase CompilationCore { get; }

        /// <summary>
        /// The syntax tree this model was obtained from.
        /// </summary>
        public SyntaxTree SyntaxTree
        {
            get { return SyntaxTreeCore; }
        }

        /// <summary>
        /// The syntax tree this model was obtained from.
        /// </summary>
        protected abstract SyntaxTree SyntaxTreeCore { get; }

        /// <summary>
        /// Returns true if this is a SemanticModel that ignores accessibility rules when answering semantic questions.
        /// </summary>
        public virtual bool IgnoresAccessibility
        {
            get { return false; }
        }

        protected virtual void CheckSyntaxNode(SyntaxNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (!IsInTree(node))
            {
                throw new ArgumentException("Syntax node is not within syntax tree");
            }
        }

        internal bool IsInTree(SyntaxNode node)
        {
            return node.SyntaxTree == this.SyntaxTree;
        }

        /// <summary>
        /// Gets symbol information about a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the semantic info.</param>
        public SymbolInfo GetSymbolInfo(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetSymbolInfoCore(node, cancellationToken);
        }

        /// <summary>
        /// Gets symbol information about a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the semantic info.</param>
        protected abstract SymbolInfo GetSymbolInfoCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Binds the node in the context of the specified location and get semantic information
        /// such as type, symbols and diagnostics. This method is used to get semantic information
        /// about an expression that did not actually appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="expression">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to  SemanticModel
        /// instance.</param>
        /// <returns>The semantic information for the topmost node of the expression.</returns>
        /// <remarks>The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        public SymbolInfo GetSpeculativeSymbolInfo(int position, SyntaxNode expression)
        {
            return GetSpeculativeSymbolInfoCore(position, expression);
        }

        /// <summary>
        /// Binds the node in the context of the specified location and get semantic information
        /// such as type, symbols and diagnostics. This method is used to get semantic information
        /// about an expression that did not actually appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="expression">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to  SemanticModel
        /// instance.</param>
        /// <returns>The semantic information for the topmost node of the expression.</returns>
        /// <remarks>The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        protected abstract SymbolInfo GetSpeculativeSymbolInfoCore(int position, SyntaxNode expression);

        /// <summary>
        /// Gets type information about a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the semantic info.</param>
        public TypeInfo GetTypeInfo(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetTypeInfoCore(node, cancellationToken);
        }

        /// <summary>
        /// Gets type information about a syntax node.
        /// </summary>
        /// <param name="node">The syntax node to get semantic information for.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the semantic info.</param>
        protected abstract TypeInfo GetTypeInfoCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Binds the node in the context of the specified location and get semantic information
        /// such as type, symbols and diagnostics. This method is used to get semantic information
        /// about an expression that did not actually appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="expression">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to  SemanticModel
        /// instance.</param>
        /// <returns>The semantic information for the topmost node of the expression.</returns>
        /// <remarks>The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        public TypeInfo GetSpeculativeTypeInfo(int position, SyntaxNode expression)
        {
            return GetSpeculativeTypeInfoCore(position, expression);
        }

        /// <summary>
        /// Binds the node in the context of the specified location and get semantic information
        /// such as type, symbols and diagnostics. This method is used to get semantic information
        /// about an expression that did not actually appear in the source code.
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="expression">A syntax node that represents a parsed expression. This syntax
        /// node need not and typically does not appear in the source code referred to  SemanticModel
        /// instance.</param>
        /// <returns>The semantic information for the topmost node of the expression.</returns>
        /// <remarks>The passed in expression is interpreted as a stand-alone expression, as if it
        /// appeared by itself somewhere within the scope that encloses "position".</remarks>
        protected abstract TypeInfo GetSpeculativeTypeInfoCore(int position, SyntaxNode expression);

        /// <summary>
        /// Returns true if this is a speculative semantic model created with any of the TryGetSpeculativeSemanticModel methods.
        /// </summary>
        public abstract bool IsSpeculativeSemanticModel
        {
            get;
        }

        /// <summary>
        /// If this is a speculative semantic model, returns the original position at which the speculative model was created.
        /// Otherwise, returns 0.
        /// </summary>
        public abstract int OriginalPositionForSpeculation
        {
            get;
        }

        /// <summary>
        /// If this is a speculative semantic model, then returns its parent semantic model.
        /// Otherwise, returns null.
        /// </summary>
        public SemanticModel ParentModel
        {
            get { return this.ParentModelCore; }
        }

        /// <summary>
        /// If this is a speculative semantic model, then returns its parent semantic model.
        /// Otherwise, returns null.
        /// </summary>
        protected abstract SemanticModel ParentModelCore
        {
            get;
        }

        /// <summary>
        /// Get all of the syntax errors within the syntax tree associated with this
        /// object. Does not get errors involving declarations or compiling method bodies or initializers.
        /// </summary>
        /// <param name="span">Optional span within the syntax tree for which to get diagnostics.
        /// If no argument is specified, then diagnostics for the entire tree are returned.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the diagnostics.</param>
        public abstract ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get all of the declaration errors within the syntax tree associated with this
        /// object. Does not get errors involving incorrect syntax, compiling method bodies or initializers.
        /// </summary>
        /// <param name="span">Optional span within the syntax tree for which to get diagnostics.
        /// If no argument is specified, then diagnostics for the entire tree are returned.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the diagnostics.</param>
        /// <remarks>The declaration errors for a syntax tree are cached. The first time this method
        /// is called, all declarations are analyzed for diagnostics. Calling this a second time
        /// will return the cached diagnostics.
        /// </remarks>
        public abstract ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get all of the semantic errors within the syntax tree associated with this
        /// object. Does not get errors involving incorrect syntax or declarations.
        /// </summary>
        /// <param name="span">Optional span within the syntax tree for which to get diagnostics.
        /// If no argument is specified, then diagnostics for the entire tree are returned.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the diagnostics.</param>
        /// <remarks>The method body errors for a syntax tree are not cached. The first time this method
        /// is called, all method bodies are analyzed for diagnostics. Calling this a second time
        /// will repeat this work.
        /// </remarks>
        public abstract ImmutableArray<Diagnostic> GetSemanticDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get all the errors within the syntax tree associated with this object. Includes errors
        /// involving compiling method bodies or initializers, in addition to the errors returned by
        /// GetDeclarationDiagnostics.
        /// </summary>
        /// <param name="span">Optional span within the syntax tree for which to get diagnostics.
        /// If no argument is specified, then diagnostics for the entire tree are returned.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the
        /// process of obtaining the diagnostics.</param>
        /// <remarks>
        /// Because this method must semantically bind all method bodies and initializers to check
        /// for diagnostics, it may take a significant amount of time. Unlike
        /// GetDeclarationDiagnostics, diagnostics for method bodies and initializers are not
        /// cached, any semantic information used to obtain the diagnostics is discarded.
        /// </remarks>
        public abstract ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the symbol associated with a declaration syntax node.
        /// </summary>
        /// <param name="declaration">A syntax node that is a declaration. This can be any type
        /// derived from MemberDeclarationSyntax, TypeDeclarationSyntax, EnumDeclarationSyntax,
        /// NamespaceDeclarationSyntax, ParameterSyntax, TypeParameterSyntax, or the alias part of a
        /// UsingDirectiveSyntax</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbol declared by the node or null if the node is not a declaration.</returns>
        public IMetaSymbol GetDeclaredSymbolForNode(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDeclaredSymbolCore(declaration, cancellationToken);
        }

        /// <summary>
        /// Gets the symbol associated with a declaration syntax node.
        /// </summary>
        /// <param name="declaration">A syntax node that is a declaration. This can be any type
        /// derived from MemberDeclarationSyntax, TypeDeclarationSyntax, EnumDeclarationSyntax,
        /// NamespaceDeclarationSyntax, ParameterSyntax, TypeParameterSyntax, or the alias part of a
        /// UsingDirectiveSyntax</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbol declared by the node or null if the node is not a declaration.</returns>
        protected abstract IMetaSymbol GetDeclaredSymbolCore(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the symbol associated with a declaration syntax node. Unlike <see cref="GetDeclaredSymbolForNode(SyntaxNode, CancellationToken)"/>,
        /// this method returns all symbols declared by a given declaration syntax node. Specifically, in the case of field declaration syntax nodes,
        /// which can declare multiple symbols, this method returns all declared symbols.
        /// </summary>
        /// <param name="declaration">A syntax node that is a declaration. This can be any type
        /// derived from MemberDeclarationSyntax, TypeDeclarationSyntax, EnumDeclarationSyntax,
        /// NamespaceDeclarationSyntax, ParameterSyntax, TypeParameterSyntax, or the alias part of a
        /// UsingDirectiveSyntax</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbols declared by the node.</returns>
        public ImmutableArray<IMetaSymbol> GetDeclaredSymbolsForNode(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDeclaredSymbolsCore(declaration, cancellationToken);
        }

        /// <summary>
        /// Gets the symbol associated with a declaration syntax node. Unlike <see cref="GetDeclaredSymbolForNode(SyntaxNode, CancellationToken)"/>,
        /// this method returns all symbols declared by a given declaration syntax node. Specifically, in the case of field declaration syntax nodes,
        /// which can declare multiple symbols, this method returns all declared symbols.
        /// </summary>
        /// <param name="declaration">A syntax node that is a declaration. This can be any type
        /// derived from MemberDeclarationSyntax, TypeDeclarationSyntax, EnumDeclarationSyntax,
        /// NamespaceDeclarationSyntax, ParameterSyntax, TypeParameterSyntax, or the alias part of a
        /// UsingDirectiveSyntax</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbols declared by the node.</returns>
        protected abstract ImmutableArray<IMetaSymbol> GetDeclaredSymbolsCore(SyntaxNode declaration, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the available named symbols in the context of the specified location and optional container. Only
        /// symbols that are accessible and visible from the given location are returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// </remarks>
        public ImmutableArray<IMetaSymbol> LookupSymbols(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupSymbolsCore(position, container, name);
        }

        /// <summary>
        /// Backing implementation of <see cref="LookupSymbols"/>.
        /// </summary>
        protected abstract ImmutableArray<IMetaSymbol> LookupSymbolsCore(
            int position,
            IMetaSymbol container,
            string name);

        /// <summary>
        /// Gets the available base type members in the context of the specified location.  Akin to
        /// calling <see cref="LookupSymbols"/> with the container set to the immediate base type of
        /// the type in which <paramref name="position"/> occurs.  However, the accessibility rules
        /// are different: protected members of the base type will be visible.
        /// 
        /// Consider the following example:
        /// 
        ///   public class Base
        ///   {
        ///       protected void M() { }
        ///   }
        ///   
        ///   public class Derived : Base
        ///   {
        ///       void Test(Base b)
        ///       {
        ///           b.M(); // Error - cannot access protected member.
        ///           base.M();
        ///       }
        ///   }
        /// 
        /// Protected members of an instance of another type are only accessible if the instance is known
        /// to be "this" instance (as indicated by the "base" keyword).
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible.
        /// 
        /// Non-reduced extension methods are considered, but reduced extension methods are not.
        /// </remarks>
        public ImmutableArray<IMetaSymbol> LookupBaseMembers(
            int position,
            string name = null)
        {
            return LookupBaseMembersCore(position, name);
        }

        /// <summary>
        /// Backing implementation of <see cref="LookupBaseMembers"/>.
        /// </summary>
        protected abstract ImmutableArray<IMetaSymbol> LookupBaseMembersCore(
            int position,
            string name);

        /// <summary>
        /// Gets the available named static member symbols in the context of the specified location and optional container.
        /// Only members that are accessible and visible from the given location are returned.
        /// 
        /// Non-reduced extension methods are considered, since they are static methods.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// 
        /// Essentially the same as filtering instance members out of the results of an analogous <see cref="LookupSymbols"/> call.
        /// </remarks>
        public ImmutableArray<IMetaSymbol> LookupStaticMembers(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupStaticMembersCore(position, container, name);
        }

        /// <summary>
        /// Backing implementation of <see cref="LookupStaticMembers"/>.
        /// </summary>
        protected abstract ImmutableArray<IMetaSymbol> LookupStaticMembersCore(
            int position,
            IMetaSymbol container,
            string name);

        /// <summary>
        /// Gets the available named namespace and type symbols in the context of the specified location and optional container.
        /// Only members that are accessible and visible from the given location are returned.
        /// </summary>
        /// <param name="position">The character position for determining the enclosing declaration scope and
        /// accessibility.</param>
        /// <param name="container">The container to search for symbols within. If null then the enclosing declaration
        /// scope around position is used.</param>
        /// <param name="name">The name of the symbol to find. If null is specified then symbols
        /// with any names are returned.</param>
        /// <returns>A list of symbols that were found. If no symbols were found, an empty list is returned.</returns>
        /// <remarks>
        /// The "position" is used to determine what variables are visible and accessible. Even if "container" is
        /// specified, the "position" location is significant for determining which members of "containing" are
        /// accessible. 
        /// 
        /// Does not return INamespaceOrTypeSymbol, because there could be aliases.
        /// </remarks>
        public ImmutableArray<IMetaSymbol> LookupNamespacesAndTypes(
            int position,
            IMetaSymbol container = null,
            string name = null)
        {
            return LookupNamespacesAndTypesCore(position, container, name);
        }

        /// <summary>
        /// Backing implementation of <see cref="LookupNamespacesAndTypes"/>.
        /// </summary>
        protected abstract ImmutableArray<IMetaSymbol> LookupNamespacesAndTypesCore(
            int position,
            IMetaSymbol container,
            string name);

        /// <summary>
        /// If the node provided has a constant value an Optional value will be returned with
        /// HasValue set to true and with Value set to the constant.  If the node does not have an
        /// constant value, an Optional will be returned with HasValue set to false.
        /// </summary>
        public Optional<object> GetConstantValue(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetConstantValueCore(node, cancellationToken);
        }

        /// <summary>
        /// If the node provided has a constant value an Optional value will be returned with
        /// HasValue set to true and with Value set to the constant.  If the node does not have an
        /// constant value, an Optional will be returned with HasValue set to false.
        /// </summary>
        protected abstract Optional<object> GetConstantValueCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// When getting information for a symbol that resolves to a method group or property group,
        /// from which a method is then chosen; the chosen method or property is present in Symbol;
        /// all methods in the group that was consulted are placed in this property.
        /// </summary>
        public ImmutableArray<IMetaSymbol> GetMembers(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetMembersCore(node, cancellationToken);
        }

        /// <summary>
        /// When getting information for a symbol that resolves to a method group or property group,
        /// from which a method is then chosen; the chosen method or property is present in Symbol;
        /// all methods in the group that was consulted are placed in this property.
        /// </summary>
        protected abstract ImmutableArray<IMetaSymbol> GetMembersCore(SyntaxNode node, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Given a position in the SyntaxTree for this SemanticModel returns the innermost Symbol
        /// that the position is considered inside of.
        /// </summary>
        public IMetaSymbol GetEnclosingSymbol(int position, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEnclosingSymbolCore(position, cancellationToken);
        }

        /// <summary>
        /// Given a position in the SyntaxTree for this SemanticModel returns the innermost Symbol
        /// that the position is considered inside of.
        /// </summary>
        protected abstract IMetaSymbol GetEnclosingSymbolCore(int position, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Determines if the symbol is accessible from the specified location. 
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="symbol">The symbol that we are checking to see if it accessible.</param>
        /// <returns>
        /// True if "symbol is accessible, false otherwise.</returns>
        /// <remarks>
        /// This method only checks accessibility from the point of view of the accessibility
        /// modifiers on symbol and its containing types. Even if true is returned, the given symbol
        /// may not be able to be referenced for other reasons, such as name hiding.
        /// </remarks>
        public bool IsAccessible(int position, IMetaSymbol symbol)
        {
            return IsAccessibleCore(position, symbol);
        }

        /// <summary>
        /// Determines if the symbol is accessible from the specified location. 
        /// </summary>
        /// <param name="position">A character position used to identify a declaration scope and
        /// accessibility. This character position must be within the FullSpan of the Root syntax
        /// node in this SemanticModel.
        /// </param>
        /// <param name="symbol">The symbol that we are checking to see if it accessible.</param>
        /// <returns>
        /// True if "symbol is accessible, false otherwise.</returns>
        /// <remarks>
        /// This method only checks accessibility from the point of view of the accessibility
        /// modifiers on symbol and its containing types. Even if true is returned, the given symbol
        /// may not be able to be referenced for other reasons, such as name hiding.
        /// </remarks>
        protected abstract bool IsAccessibleCore(int position, IMetaSymbol symbol);

        /// <summary>
        /// Takes a Symbol and syntax for one of its declaring syntax reference and returns the topmost syntax node to be used by syntax analyzer.
        /// </summary>
        protected internal virtual SyntaxNode GetTopmostNodeForDiagnosticAnalysis(IMetaSymbol symbol, SyntaxNode declaringSyntax)
        {
            return declaringSyntax;
        }
    }
}
