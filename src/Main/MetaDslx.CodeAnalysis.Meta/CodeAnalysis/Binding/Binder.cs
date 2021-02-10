using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
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
    [DebuggerDisplay("{ToString(), nq}")]
    public partial class Binder
    {
        private readonly LanguageCompilation _compilation;
        private readonly SyntaxNodeOrToken _syntax;
        private readonly Binder _next;
        private readonly int _index;
        private Lazy<BoundNode> _boundNode;

        public readonly BinderFlags Flags;

        /// <summary>
        /// Used to create a root binder.
        /// </summary>
        public Binder(LanguageCompilation compilation)
        {
            Debug.Assert(compilation != null);
            this.Flags = compilation.Options.TopLevelBinderFlags;
            _compilation = compilation;
            _index = 0;
            _boundNode = new Lazy<BoundNode>(GetOrCreateBoundNode, true);
        }

        public Binder(Binder next, SyntaxNodeOrToken syntax, Conversions conversions = null)
        {
            Debug.Assert(next != null);
            if (syntax.IsNull) _syntax = next.Syntax;
            else _syntax = syntax;
            if (_syntax == next.Syntax) _index = next._index + 1;
            else _index = 0;
            _next = next;
            this.Flags = next.Flags;
            _compilation = next._compilation;
            _lazyConversions = conversions;
            _boundNode = new Lazy<BoundNode>(GetOrCreateBoundNode, true);
        }

        private Binder(Binder next, BinderFlags flags)
        {
            Debug.Assert(next != null);
            _index = next._index + 1;
            _next = next;
            _syntax = next.Syntax;
            this.Flags = flags;
            _compilation = next._compilation;
            _boundNode = new Lazy<BoundNode>(GetOrCreateBoundNode, true);
        }

        public LanguageCompilation Compilation => _compilation;

        public Language Language => _compilation.Language;

        public SyntaxNodeOrToken Syntax => !_syntax.IsNull ? _syntax : (_next?.Syntax ?? null);

        public Binder WithFlags(params BinderFlags[] flags)
        {
            BinderFlags union = FlagsObject.Union<BinderFlags>(flags);
            return this.Flags == union
                ? this
                : new Binder(this, union);
        }

        public Binder WithAdditionalFlags(params BinderFlags[] flags)
        {
            return this.Flags.IncludesAll(flags)
                ? this
                : new Binder(this, this.Flags.UnionWith(flags));
        }

        public override bool Equals(object obj)
        {
            if (obj is Binder other)
            {
                return Syntax == other.Syntax && _index == other._index;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var syntaxHash = 0;
            if (Syntax != null) syntaxHash = Syntax.GetHashCode();
            return Hash.Combine(syntaxHash, _index.GetHashCode());
        }

        public bool IsSemanticModelBinder => this.Flags.Includes(BinderFlags.SemanticModel);

        // IsEarlyAttributeBinder is called relatively frequently so we want fast code here.
        public bool IsEarlyAttributeBinder => this.Flags.Includes(BinderFlags.EarlyAttributeBinding);

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        public Binder Next => _next;

        public BinderPosition GetBinderPosition()
        {
            return new BinderPosition(this, GetBinder(this.Syntax), this.Syntax);
        }

        protected BoundNode ParentBoundNode => Next?.BoundNode ?? _compilation.GetBoundTree(Syntax)?.RootNode;

        internal protected BoundNode BoundNode => _boundNode.Value;

        /// <summary>
        /// Some nodes have special binders for their contents (like Blocks)
        /// </summary>
        public virtual Binder GetBinder(SyntaxNodeOrToken node)
        {
            return this.Next.GetBinder(node);
        }

        private BoundNode GetOrCreateBoundNode()
        {
            if (this.Syntax.IsNull) return null;
            var parent = this.ParentBoundNode;
            var result = parent?.GetChild(this.Syntax);
            if (result == null)
            {
                result = CreateBoundNode();
                if (parent != null && result != null) result = parent.TryAddChild(this.Syntax, result);
            }
            return result;
        }

        protected virtual BoundNode CreateBoundNode()
        {
            return null;
        }

        public virtual BoundQualifier GetBoundQualifier()
        {
            return Next?.GetBoundQualifier();
        }

        /// <summary>
        /// Get locals declared immediately in scope designated by the node.
        /// </summary>
        public virtual ImmutableArray<Symbol> GetDeclaredLocalsForScope(SyntaxNode scopeDesignator)
        {
            return this.Next.GetDeclaredLocalsForScope(scopeDesignator);
        }

        /// <summary>
        /// If this binder owns a scope for locals, return syntax node that is used
        /// as the scope designator. Otherwise, null.
        /// </summary>
        public virtual SyntaxNode ScopeDesignator => null;

        /// <summary>
        /// The member containing the binding context.  Note that for the purposes of the compiler,
        /// a lambda expression is considered a "member" of its enclosing method, field, or lambda.
        /// </summary>
        public virtual Symbol ContainingSymbol
        {
            get
            {
                if (_next == null) return null;
                var symbol = Next.GetDefinedSymbol();
                if (symbol != null) return symbol;
                else return Next.ContainingSymbol;
            }
        }

        /// <summary>
        /// The member containing the binding context.  Note that for the purposes of the compiler,
        /// a lambda expression is considered a "member" of its enclosing method, field, or lambda.
        /// </summary>
        public virtual DeclaredSymbol ContainingDeclaration
        {
            get
            {
                if (_next == null) return null;
                var symbol = Next.GetDefinedSymbol() as DeclaredSymbol;
                if (symbol != null) return symbol;
                else return Next.ContainingDeclaration;
            }
        }

        public virtual ImmutableArray<Symbol> ChildSymbols => Next.ChildSymbols;

        /// <summary>
        /// The imports for all containing namespace declarations (innermost-to-outermost, including global),
        /// or null if there are none.
        /// </summary>
        public virtual ImportChain ImportChain => _next.ImportChain;

        public virtual Imports GetImports(ConsList<TypeSymbol> basesBeingResolved)
        {
            return _next.GetImports(basesBeingResolved);
        }

        protected virtual bool InExecutableBinder => _next.InExecutableBinder;

        /// <summary>
        /// The type containing the binding context
        /// </summary>
        public NamedTypeSymbol ContainingType
        {
            get
            {
                var member = this.ContainingDeclaration;
                Debug.Assert((object)member == null || member.Kind != LanguageSymbolKind.ErrorType);
                return (object)member == null
                    ? null
                    : member.Kind == LanguageSymbolKind.NamedType
                        ? (NamedTypeSymbol)member
                        : member.ContainingType;
            }
        }

        /// <summary>
        /// Returns true if the binder is binding top-level script code.
        /// </summary>
        public bool BindingTopLevelScriptCode
        {
            get
            {
                var containingMember = this.ContainingDeclaration;
                switch (containingMember?.Kind.Switch())
                {
                    case LanguageSymbolKind.Operation:
                        // global statements
                        return ((MethodSymbol)containingMember).IsScriptInitializer;

                    case LanguageSymbolKind.NamedType:
                        // script variable initializers
                        return ((NamedTypeSymbol)containingMember).IsScript;

                    default:
                        return false;
                }
            }
        }

        private Conversions _lazyConversions;
        public Conversions Conversions
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

        private OverloadResolution _lazyOverloadResolution;
        public OverloadResolution OverloadResolution
        {
            get
            {
                if (_lazyOverloadResolution == null)
                {
                    Interlocked.CompareExchange(ref _lazyOverloadResolution, new OverloadResolution(this), null);
                }

                return _lazyOverloadResolution;
            }
        }

        public static void Error(DiagnosticBag diagnostics, DiagnosticInfo info, SyntaxNode syntax)
        {
            diagnostics.Add(info.ToDiagnostic(syntax.Location));
        }

        public static void Error(DiagnosticBag diagnostics, DiagnosticInfo info, Location location)
        {
            diagnostics.Add(info.ToDiagnostic(location));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNode syntax)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), syntax.Location));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNode syntax, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), syntax.Location));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxToken token)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), token.GetLocation()));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxToken token, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), token.GetLocation()));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNodeOrToken syntax)
        {
            Error(diagnostics, code, syntax.GetLocation());
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, SyntaxNodeOrToken syntax, params object[] args)
        {
            Error(diagnostics, code, syntax.GetLocation(), args);
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, Location location)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code), location));
        }

        public static void Error(DiagnosticBag diagnostics, ErrorCode code, Location location, params object[] args)
        {
            diagnostics.Add(new LanguageDiagnostic(new LanguageDiagnosticInfo(code, args), location));
        }

        /// <summary>
        /// Issue an error or warning for a symbol if it is Obsolete. If there is not enough
        /// information to report diagnostics, then store the symbols so that diagnostics
        /// can be reported at a later stage.
        /// </summary>
        public void ReportDiagnosticsIfObsolete(DiagnosticBag diagnostics, DeclaredSymbol symbol, SyntaxNodeOrToken node, bool hasBaseReceiver)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.NamedType:
                case LanguageSymbolKind.Name:
                case LanguageSymbolKind.Operation:
                case LanguageSymbolKind.Property:
                    ReportDiagnosticsIfObsolete(diagnostics, symbol, node, hasBaseReceiver, this.ContainingDeclaration, this.ContainingType, this.Flags);
                    break;
            }
        }

        public void ReportDiagnosticsIfObsolete(DiagnosticBag diagnostics, Conversion conversion, SyntaxNodeOrToken node, bool hasBaseReceiver)
        {
            if (conversion.IsValid && (object)conversion.Method != null)
            {
                ReportDiagnosticsIfObsolete(diagnostics, conversion.Method, node, hasBaseReceiver);
            }
        }

        public static void ReportDiagnosticsIfObsolete(
            DiagnosticBag diagnostics,
            DeclaredSymbol symbol,
            SyntaxNodeOrToken node,
            bool hasBaseReceiver,
            DeclaredSymbol containingMember,
            NamedTypeSymbol containingType,
            BinderFlags location)
        {
            Debug.Assert((object)symbol != null);

            // Dev11 also reports on the unconstructed method.  It would be nice to report on 
            // the constructed method, but then we wouldn't be able to walk the override chain.
            if (symbol is MemberSymbol memberSymbol)
            {
                symbol = symbol.ConstructedFrom;
            }

            // There are two reasons to walk up to the least-overridden member:
            //   1) That's the method to which we will actually emit a call.
            //   2) We don't know what virtual dispatch will do at runtime so an
            //      overriding member is basically a shot in the dark.  Better to
            //      just be consistent and always use the least-overridden member.
            Symbol leastOverriddenSymbol = symbol.GetConstructedLeastOverriddenMember(containingType);

            bool checkOverridingSymbol = hasBaseReceiver && !ReferenceEquals(symbol, leastOverriddenSymbol);
            if (checkOverridingSymbol)
            {
                // If we have a base receiver, we must be done with declaration binding, so it should
                // be safe to decode diagnostics.  We want to do this since reporting for the overriding
                // member is conditional on reporting for the overridden member (i.e. we need a definite
                // answer so we don't double-report).  You might think that double reporting just results
                // in cascading diagnostics, but it's possible that the second diagnostic is an error
                // while the first is merely a warning.
                leastOverriddenSymbol.GetAttributes();
            }

            var diagnosticKind = ReportDiagnosticsIfObsoleteInternal(diagnostics, leastOverriddenSymbol, node, containingMember, location);

            // CONSIDER: In place of hasBaseReceiver, dev11 also accepts cases where symbol.ContainingType is a "simple type" (e.g. int)
            // or a special by-ref type (e.g. ArgumentHandle).  These cases are probably more important for other checks performed by
            // ExpressionBinder::PostBindMethod, but they do appear to ObsoleteAttribute as well.  We're skipping them because they
            // don't make much sense for ObsoleteAttribute (e.g. this would seem to address the case where int.ToString has been made
            // obsolete but object.ToString has not).

            // If the overridden member was not definitely obsolete and this is a (non-virtual) base member
            // access, then check the overriding symbol as well.
            switch (diagnosticKind)
            {
                case ObsoleteDiagnosticKind.NotObsolete:
                case ObsoleteDiagnosticKind.Lazy:
                    if (checkOverridingSymbol)
                    {
                        Debug.Assert(diagnosticKind != ObsoleteDiagnosticKind.Lazy, "We forced attribute binding above.");
                        ReportDiagnosticsIfObsoleteInternal(diagnostics, symbol, node, containingMember, location);
                    }
                    break;
            }
        }

        internal static ObsoleteDiagnosticKind ReportDiagnosticsIfObsoleteInternal(DiagnosticBag diagnostics, Symbol symbol, SyntaxNodeOrToken node, Symbol containingMember, BinderFlags location)
        {
            Debug.Assert(diagnostics != null);

            var kind = ObsoleteAttributeHelpers.GetObsoleteDiagnosticKind(symbol, containingMember);

            DiagnosticInfo info = null;
            switch (kind)
            {
                case ObsoleteDiagnosticKind.Diagnostic:
                    info = ObsoleteAttributeHelpers.CreateObsoleteDiagnostic(symbol, location);
                    break;
                case ObsoleteDiagnosticKind.Lazy:
                case ObsoleteDiagnosticKind.LazyPotentiallySuppressed:
                    info = new LazyObsoleteDiagnosticInfo(symbol, containingMember, location);
                    break;
            }

            if (info != null)
            {
                diagnostics.Add(info, node.GetLocation());
            }

            return kind;
        }

        public static bool IsSymbolAccessibleConditional(
            Symbol symbol,
            AssemblySymbol within,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return AccessCheck.IsSymbolAccessible(symbol, within, ref useSiteDiagnostics);
        }

        public bool IsSymbolAccessibleConditional(
            Symbol symbol,
            NamedTypeSymbol within,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics,
            TypeSymbol throughTypeOpt = null)
        {
            return this.Flags.Includes(BinderFlags.IgnoreAccessibility) || AccessCheck.IsSymbolAccessible(symbol, within, ref useSiteDiagnostics, throughTypeOpt);
        }

        public bool IsSymbolAccessibleConditional(
            Symbol symbol,
            NamedTypeSymbol within,
            TypeSymbol throughTypeOpt,
            out bool failedThroughTypeCheck,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics,
            ConsList<TypeSymbol> basesBeingResolved = null)
        {
            if (this.Flags.Includes(BinderFlags.IgnoreAccessibility))
            {
                failedThroughTypeCheck = false;
                return true;
            }

            return AccessCheck.IsSymbolAccessible(symbol, within, throughTypeOpt, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
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

        public virtual BoundNode Bind(SyntaxNodeOrToken node, CancellationToken cancellationToken)
        {
            if (node == this.Syntax) return this.BoundNode;
            else return null;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
