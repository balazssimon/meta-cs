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
        internal readonly int _index;
        private BoundNode _boundNode;
        private Conversions _lazyConversions;
        private OverloadResolution _lazyOverloadResolution;

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
        }

        public Binder(Binder next, SyntaxNodeOrToken syntax)
        {
            Debug.Assert(next != null);
            if (syntax.IsNull) _syntax = next.Syntax;
            else _syntax = syntax;
            _index = next._index + 1;
            _next = next;
            this.Flags = next.Flags;
            _compilation = next._compilation;
        }

        private Binder(Binder next, BinderFlags flags)
        {
            Debug.Assert(next != null);
            _index = next._index + 1;
            _next = next;
            _syntax = next.Syntax;
            this.Flags = flags;
            _compilation = next._compilation;
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

        /// <summary>
        /// Get the next binder in which to look up a name, if not found by this binder.
        /// </summary>
        public Binder Next => _next;

        public BinderPosition GetBinderPosition()
        {
            return new BinderPosition(this, GetBinder(this.Syntax), this.Syntax);
        }

        /// <summary>
        /// Some nodes have special binders for their contents (like Blocks)
        /// </summary>
        public virtual Binder GetBinder(SyntaxNodeOrToken node)
        {
            return this.Next.GetBinder(node);
        }

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

        /// <summary>
        /// The type containing the binding context
        /// </summary>
        public TypeSymbol ContainingType
        {
            get
            {
                if (_next == null) return null;
                var symbol = Next.GetDefinedSymbol() as TypeSymbol;
                if (symbol != null) return symbol;
                else return Next.ContainingType;
            }
        }

        /// <summary>
        /// The imports for all containing namespace declarations (innermost-to-outermost, including global),
        /// or null if there are none.
        /// </summary>
        public virtual ImportChain ImportChain => _next.ImportChain;

        public virtual Imports GetImports(LookupConstraints? recursionConstraints = null)
        {
            return _next.GetImports(recursionConstraints);
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
                    case Symbols.SymbolKind.Member:
                        var memberSymbol = (MemberSymbol)containingMember;
                        if (memberSymbol.MemberKind == MemberKind.Method)
                        {
                            // global statements
                            return ((MethodSymbol)containingMember).IsScriptInitializer;
                        }
                        else
                        {
                            return false;
                        }

                    case Symbols.SymbolKind.NamedType:
                        // script variable initializers
                        return ((NamedTypeSymbol)containingMember).IsScript;

                    default:
                        return false;
                }
            }
        }

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

        public BoundNode Bind(DiagnosticBag diagnostics = null, CancellationToken cancellationToken = default)
        {
            if (this.Syntax.IsNull) return null;
            if (_boundNode == null)
            {
                var boundNodeDiagnostics = DiagnosticBag.GetInstance();
                var boundNode = BindNode(boundNodeDiagnostics, cancellationToken);
                if (boundNode != null)
                {
                    var parentNode = Next?.Bind(null, cancellationToken);
                    if (parentNode == null) parentNode = _compilation.GetBoundTree(Syntax)?.RootNode;
                    boundNode = parentNode.TryAddChild(this.Syntax, boundNode);
                    Interlocked.CompareExchange(ref boundNode._index, _index, 0);
                    ImmutableInterlocked.InterlockedInitialize(ref boundNode._diagnostics, boundNodeDiagnostics.ToReadOnly());
                    Interlocked.CompareExchange(ref _boundNode, boundNode, null);
                }
                if (diagnostics != null) diagnostics.AddRange(boundNodeDiagnostics);
                boundNodeDiagnostics.Free();
            }
            else
            {
                if (diagnostics != null) diagnostics.AddRange(_boundNode.Diagnostics);
            }
            if (_boundNode != null) return _boundNode;
            if (Next?.Syntax == this.Syntax) return Next?.Bind(diagnostics, cancellationToken);
            else return null;
        }

        protected virtual BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return null;
        }

        public TBinder FindAncestorBinder<TBinder>()
            where TBinder: Binder
        {
            var binder = this;
            var result = binder as TBinder;
            while (binder != null && result == null)
            {
                binder = binder.Next;
                result = binder as TBinder;
            }
            return result;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
