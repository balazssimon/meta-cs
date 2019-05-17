using MetaDslx.CodeAnalysis.BoundTree;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Binding
{
    using CSharp = Microsoft.CodeAnalysis.CSharp;
    /// <summary>
    /// A Binder converts names in to symbols and syntax nodes into bound trees. It is context
    /// dependent, relative to a location in source code.
    /// </summary>
    public class Binder
    {
        internal LanguageCompilation Compilation { get; }
        private readonly Binder _next;

        internal readonly BinderFlags Flags;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        internal Binder(LanguageCompilation compilation)
        {
            Debug.Assert(compilation != null);
            this.Flags = compilation.Options.TopLevelBinderFlags;
            this.Compilation = compilation;
        }

        protected Binder(Binder next)
        {
            Debug.Assert(next != null);
            _next = next;
            this.Flags = next.Flags;
            this.Compilation = next.Compilation;
        }

        protected Binder(Binder next, BinderFlags flags)
        {
            Debug.Assert(next != null);
            _next = next;
            this.Flags = flags;
            this.Compilation = next.Compilation;
        }

        public Language Language => this.Compilation.Language;

        internal Binder WithFlags(BinderFlags flags)
        {
            return this.Flags == flags
                ? this
                : new Binder(this, flags);
        }

        internal Binder WithAdditionalFlags(BinderFlags flags)
        {
            return this.Flags.Includes(flags)
                ? this
                : new Binder(this, this.Flags | flags);
        }

        internal bool IsSemanticModelBinder
        {
            get
            {
                return this.Flags.Includes(BinderFlags.SemanticModel);
            }
        }

        // IsEarlyAttributeBinder is called relatively frequently so we want fast code here.
        internal bool IsEarlyAttributeBinder
        {
            get
            {
                return this.Flags.Includes(BinderFlags.EarlyAttributeBinding);
            }
        }

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        internal protected Binder Next
        {
            get
            {
                return _next;
            }
        }

        /// <summary>
        /// Some nodes have special binders for their contents (like Blocks)
        /// </summary>
        internal virtual Binder GetBinder(SyntaxNode node)
        {
            return this.Next.GetBinder(node);
        }

        /// <summary>
        /// Get symbols declared immediately in scope designated by the node.
        /// </summary>
        internal virtual ImmutableArray<ISymbol> GetDeclaredSymbolsInScope(SyntaxNode scopeDesignator)
        {
            return this.Next.GetDeclaredSymbolsInScope(scopeDesignator);
        }

        public virtual ImmutableArray<ISymbol> ChildSymbols
        {
            get { return ImmutableArray<ISymbol>.Empty; }
        }

        /// <summary>
        /// If this binder owns a scope for locals, return syntax node that is used
        /// as the scope designator. Otherwise, null.
        /// </summary>
        internal virtual SyntaxNode ScopeDesignator
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// The member containing the binding context.  Note that for the purposes of the compiler,
        /// a lambda expression is considered a "member" of its enclosing method, field, or lambda.
        /// </summary>
        internal virtual Symbol ContainingSymbol
        {
            get
            {
                return Next.ContainingSymbol;
            }
        }

        /// <summary>
        /// The imports for all containing namespace declarations (innermost-to-outermost, including global),
        /// or null if there are none.
        /// </summary>
        internal virtual ImportChain ImportChain
        {
            get
            {
                return _next.ImportChain;
            }
        }

        internal virtual Imports GetImports(ConsList<ITypeSymbol> basesBeingResolved)
        {
            return _next.GetImports(basesBeingResolved);
        }

        private Conversions _lazyConversions;
        internal Conversions Conversions
        {
            get
            {
                if (_lazyConversions == null)
                {
                    Interlocked.CompareExchange(ref _lazyConversions, new Conversions(this), null);
                }

                return _lazyConversions;
            }
        }

        /// <summary>
        /// The type containing the binding context
        /// </summary>
        internal NamedTypeSymbol ContainingType
        {
            get
            {
                var member = this.ContainingSymbol;
                Debug.Assert((object)member == null || member.Kind != SymbolKind.ErrorType);
                return (object)member == null
                    ? null
                    : member.Kind == SymbolKind.NamedType
                        ? (NamedTypeSymbol)member
                        : member.ContainingType;
            }
        }


        /// <summary>
        /// Returns true if the binder is binding top-level script code.
        /// </summary>
        internal bool BindingTopLevelScriptCode
        {
            get
            {
                var containingMember = this.ContainingSymbol;
                switch (containingMember?.Kind)
                {
                    case SymbolKind.Method:
                        // global statements
                        return ((MetaDslx.CodeAnalysis.Symbols.MethodSymbol)containingMember).IsScriptInitializer;

                    case SymbolKind.NamedType:
                        // script variable initializers
                        return ((INamedTypeSymbol)containingMember).IsScriptClass;

                    default:
                        return false;
                }
            }
        }

        internal static void Error(DiagnosticBag diagnostics, DiagnosticInfo info, SyntaxNode syntax)
        {
            diagnostics.Add(info.ToDiagnostic(syntax.Location));
        }

        internal static void Error(DiagnosticBag diagnostics, DiagnosticInfo info, Location location)
        {
            diagnostics.Add(info.ToDiagnostic(location));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNode syntax)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), syntax.Location));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNode syntax, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), syntax.Location));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxToken token)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), token.GetLocation()));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxToken token, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), token.GetLocation()));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNodeOrToken syntax)
        {
            Error(diagnostics, code, syntax.GetLocation());
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNodeOrToken syntax, params object[] args)
        {
            Error(diagnostics, code, syntax.GetLocation(), args);
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, Location location)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), location));
        }

        internal static void Error(DiagnosticBag diagnostics, ErrorCode code, Location location, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), location));
        }

        internal virtual bool IsAccessibleHelper(ISymbol symbol, ITypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ITypeSymbol> basesBeingResolved)
        {
            return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        internal bool IsSymbolAccessibleConditional(
            ISymbol symbol,
            INamedTypeSymbol within,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics,
            ITypeSymbol throughTypeOpt = null)
        {
            return this.Flags.Includes(BinderFlags.IgnoreAccessibility) || CSharp.AccessCheck.IsSymbolAccessible((CSharp.Symbol)symbol, (CSharp.Symbols.NamedTypeSymbol)within, ref useSiteDiagnostics, (CSharp.Symbols.TypeSymbol)throughTypeOpt);
        }

        internal bool IsSymbolAccessibleConditional(
            ISymbol symbol,
            INamedTypeSymbol within,
            ITypeSymbol throughTypeOpt,
            out bool failedThroughTypeCheck,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics,
            ConsList<CSharp.Symbols.TypeSymbol> basesBeingResolved = null)
        {
            if (this.Flags.Includes(BinderFlags.IgnoreAccessibility))
            {
                failedThroughTypeCheck = false;
                return true;
            }

            return Microsoft.CodeAnalysis.CSharp.AccessCheck.IsSymbolAccessible((CSharp.Symbol)symbol, (CSharp.Symbols.NamedTypeSymbol)within, (CSharp.Symbols.TypeSymbol)throughTypeOpt, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

#if DEBUG
        // Helper to allow displaying the binder hierarchy in the debugger.
        internal Binder[] GetAllBinders()
        {
            var binders = ArrayBuilder<Binder>.GetInstance();
            for (var binder = this; binder != null; binder = binder.Next)
            {
                binders.Add(binder);
            }
            return binders.ToArrayAndFree();
        }
#endif

        internal string Dump()
        {
            return TreeDumper.DumpCompact(DumpAncestors());

            TreeDumperNode DumpAncestors()
            {
                TreeDumperNode current = null;

                for (Binder scope = this; scope != null; scope = scope.Next)
                {
                    var (description, snippet, locals) = Print(scope);
                    var sub = new List<TreeDumperNode>();
                    if (!locals.IsEmpty())
                    {
                        sub.Add(new TreeDumperNode("locals", locals, null));
                    }
                    var currentContainer = scope.ContainingSymbol;
                    if (currentContainer != null && currentContainer != scope.Next?.ContainingSymbol)
                    {
                        sub.Add(new TreeDumperNode("containing symbol", currentContainer.ToDisplayString(), null));
                    }
                    if (snippet != null)
                    {
                        LanguageSyntaxNode node = scope.ScopeDesignator as LanguageSyntaxNode;
                        string kindText = (string)(node != null ? node.Kind : scope.ScopeDesignator.GetKind());
                        sub.Add(new TreeDumperNode($"scope", $"{snippet} ({kindText})", null));
                    }
                    if (current != null)
                    {
                        sub.Add(current);
                    }
                    current = new TreeDumperNode(description, null, sub);
                }

                return current;
            }

            (string description, string snippet, string locals) Print(Binder scope)
            {
                var locals = string.Join(", ", scope.ChildSymbols.SelectAsArray(s => s.Name));
                string snippet = null;
                if (scope.ScopeDesignator != null)
                {
                    var lines = scope.ScopeDesignator.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    if (lines.Length == 1)
                    {
                        snippet = lines[0];
                    }
                    else
                    {
                        var first = lines[0];
                        var last = lines[lines.Length - 1].Trim();
                        var lastSize = Math.Min(last.Length, 12);
                        snippet = first.Substring(0, Math.Min(first.Length, 12)) + " ... " + last.Substring(last.Length - lastSize, lastSize);
                    }
                    snippet = snippet.IsEmpty() ? null : snippet;
                }

                var description = scope.GetType().Name;
                return (description, snippet, locals);
            }
        }

        internal BoundNode BindNamespaceOrTypeSymbol(SyntaxNodeOrToken syntax, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new NotImplementedException();
        }

        internal void AddLookupSymbolsInfo(LookupSymbolsInfo info, LookupOptions options)
        {
            throw new NotImplementedException();
        }

        internal void AddMemberLookupSymbolsInfo(LookupSymbolsInfo info, NamespaceOrTypeSymbol container, LookupOptions options, Binder binder)
        {
            throw new NotImplementedException();
        }

        internal BoundNode BindNamespaceOrTypeOrAliasSymbol(LanguageSyntaxNode node, DiagnosticBag diagnostics, ConsList<TypeSymbol> basesBeingResolved, bool v)
        {
            throw new NotImplementedException();
        }

        internal void LookupSymbolsSimpleName(LookupResult lookupResult, NamespaceOrTypeSymbol container, string name, int arity, object basesBeingResolved, LookupOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        internal Symbol ResultSymbol(LookupResult lookupResult, string name, int arity, LanguageSyntaxNode root, DiagnosticBag diagnostics, bool v, out bool wasError, NamespaceOrTypeSymbol container, LookupOptions options)
        {
            throw new NotImplementedException();
        }

        internal bool IsAccessible(Symbol cssymbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, object p)
        {
            throw new NotImplementedException();
        }

        public virtual BoundNode Bind(LanguageSyntaxNode node, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual BoundExpression BindExpression(LanguageSyntaxNode expression, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

        public virtual BoundStatement BindStatement(LanguageSyntaxNode node, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

    }
}
