using Microsoft.Cci;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class NamespaceSymbol : NamespaceOrTypeSymbol, IMetaNamespaceSymbol, Microsoft.Cci.INamespace
    {
        // PERF: initialization of the following fields will allocate, so we make them lazy
        private string _lazyQualifiedName;

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        // Only the compiler can create namespace symbols.
        protected NamespaceSymbol()
        {
        }

        /// <summary>
        /// Returns whether this namespace is the unnamed, global namespace that is 
        /// at the root of all namespaces.
        /// </summary>
        public virtual bool IsGlobalNamespace => (object)ContainingNamespace == null;

        public abstract NamespaceExtent Extent { get; }

        /// <summary>
        /// The kind of namespace: Module, Assembly or Compilation.
        /// Module namespaces contain only members from the containing module that share the same namespace name.
        /// Assembly namespaces contain members for all modules in the containing assembly that share the same namespace name.
        /// Compilation namespaces contain all members, from source or referenced metadata (assemblies and modules) that share the same namespace name.
        /// </summary>
        public NamespaceKind NamespaceKind => this.Extent.Kind;

        /// <summary>
        /// The containing compilation for compilation namespaces.
        /// </summary>
        public LanguageCompilation ContainingCompilation
        {
            get { return this.NamespaceKind == NamespaceKind.Compilation ? this.Extent.Compilation : null; }
        }

        /// <summary>
        /// If a namespace has Assembly or Compilation extent, it may be composed of multiple
        /// namespaces that are merged together. If so, ConstituentNamespaces returns
        /// all the namespaces that were merged. If this namespace was not merged, returns
        /// an array containing only this namespace.
        /// </summary>
        public virtual ImmutableArray<NamespaceSymbol> ConstituentNamespaces => ImmutableArray.Create(this);

        public override ModuleSymbol ContainingModule
        {
            get
            {
                var extent = this.Extent;
                if (extent.Kind == NamespaceKind.Module)
                {
                    return extent.Module;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the kind of this symbol.
        /// </summary>
        public sealed override SymbolKind Kind => SymbolKind.Namespace;

        public override bool IsImplicitlyDeclared => this.IsGlobalNamespace;

        /// <summary>
        /// Get this accessibility that was declared on this symbol. For symbols that do not have
        /// accessibility declared on them, returns NotApplicable.
        /// </summary>
        public override Accessibility DeclaredAccessibility => Accessibility.Public;

        /// <summary>
        /// Returns true if this symbol is "static"; i.e., declared with the "static" modifier or
        /// implicitly static.
        /// </summary>
        public override bool IsStatic => true;

        /// <summary>
        /// Returns an implicit type symbol for this namespace or null if there is none. This type
        /// wraps misplaced global code.
        /// </summary>
        internal NamedTypeSymbol ImplicitType
        {
            get
            {
                var types = this.GetTypeMembers(TypeSymbol.ImplicitTypeName);
                if (types.Length == 0)
                {
                    return null;
                }
                Debug.Assert(types.Length == 1);
                return types[0];
            }
        }

        /// <summary>
        /// Lookup a nested namespace.
        /// </summary>
        /// <param name="names">
        /// Sequence of names for nested child namespaces.
        /// </param>
        /// <returns>
        /// Symbol for the most nested namespace, if found. Nothing 
        /// if namespace or any part of it can not be found.
        /// </returns>
        public NamespaceSymbol LookupNestedNamespace(ImmutableArray<string> names)
        {
            NamespaceSymbol scope = this;

            foreach (string name in names)
            {
                NamespaceSymbol nextScope = null;

                foreach (NamespaceOrTypeSymbol symbol in scope.GetMembers(name))
                {
                    var ns = symbol as NamespaceSymbol;

                    if ((object)ns != null)
                    {
                        if ((object)nextScope != null)
                        {
                            Debug.Assert((object)nextScope == null, "Why did we run into an unmerged namespace?");
                            nextScope = null;
                            break;
                        }

                        nextScope = ns;
                    }
                }

                scope = nextScope;

                if ((object)scope == null)
                {
                    break;
                }
            }

            return scope;
        }

        public NamespaceSymbol GetNestedNamespace(string name)
        {
            foreach (var sym in this.GetMembers(name))
            {
                if (sym.Kind == SymbolKind.Namespace)
                {
                    return (NamespaceSymbol)sym;
                }
            }

            return null;
        }

        public virtual NamespaceSymbol GetNestedNamespace(LanguageSyntaxNode name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the members of this symbol that are namespaces.
        /// </summary>
        /// <returns>An IEnumerable containing all the namespaces that are members of this symbol.
        /// If this symbol has no namespace members, returns an empty IEnumerable. Never returns
        /// null.</returns>
        public IEnumerable<NamespaceSymbol> GetNamespaceMembers()
        {
            return this.GetMembers().OfType<NamespaceSymbol>();
        }

        #region IMetaNamespaceSymbol Members

        INamespaceSymbol IMetaNamespaceSymbol.LookupNestedNamespace(ImmutableArray<string> names)
        {
            return this.LookupNestedNamespace(names);
        }

        INamespaceSymbol IMetaNamespaceSymbol.GetNestedNamespace(string name)
        {
            return this.GetNestedNamespace(name);
        }

        #endregion

        #region INamespaceSymbol Members

        IEnumerable<INamespaceOrTypeSymbol> INamespaceSymbol.GetMembers()
        {
            return this.GetMembers().OfType<INamespaceOrTypeSymbol>();
        }

        IEnumerable<INamespaceOrTypeSymbol> INamespaceSymbol.GetMembers(string name)
        {
            return this.GetMembers(name).OfType<INamespaceOrTypeSymbol>();
        }

        IEnumerable<INamespaceSymbol> INamespaceSymbol.GetNamespaceMembers()
        {
            return this.GetNamespaceMembers();
        }

        NamespaceKind INamespaceSymbol.NamespaceKind
        {
            get { return this.NamespaceKind; }
        }

        Compilation INamespaceSymbol.ContainingCompilation
        {
            get
            {
                return this.ContainingCompilation;
            }
        }

        ImmutableArray<INamespaceSymbol> INamespaceSymbol.ConstituentNamespaces
        {
            get
            {
                return StaticCast<INamespaceSymbol>.From(this.ConstituentNamespaces);
            }
        }

        public string QualifiedName
        {
            get
            {
                return _lazyQualifiedName ??
                    (_lazyQualifiedName = this.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat));
            }
        }

        INamespace INamespace.ContainingNamespace => this.ContainingNamespace;

        #endregion

        #region ISymbol Members

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitNamespace(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitNamespace(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitNamespace(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            visitor.VisitNamespace(this);
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitNamespace(this);
        }
        #endregion
    }
}
