using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class NamespaceOrTypeSymbol : DeclaredSymbol
    {
        public override ImmutableArray<Symbol> ChildSymbols => GetMembers().Cast<DeclaredSymbol, Symbol>();

        /// <summary>
        /// Lookup an immediately nested type referenced from metadata, names should be
        /// compared case-sensitively.
        /// </summary>
        /// <param name="emittedTypeName">
        /// Simple type name, possibly with generic name mangling.
        /// </param>
        /// <returns>
        /// Symbol for the type, or MissingMetadataSymbol if the type isn't found.
        /// </returns>
        internal virtual NamedTypeSymbol LookupMetadataType(ref MetadataTypeName emittedTypeName)
        {
            Debug.Assert(!emittedTypeName.IsNull);

            NamespaceOrTypeSymbol scope = this;

            if (scope.IsError)
            {
                return this.ContainingModule.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>((NamedTypeSymbol)scope, emittedTypeName.FullName, emittedTypeName.FullName, ErrorKind.Missing);
            }

            NamedTypeSymbol namedType = null;

            ImmutableArray<NamedTypeSymbol> namespaceOrTypeMembers;
            bool isTopLevel = scope is NamespaceSymbol;

            Debug.Assert(!isTopLevel || scope.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat) == emittedTypeName.NamespaceName);

            if (emittedTypeName.IsMangled)
            {
                Debug.Assert(!emittedTypeName.UnmangledTypeName.Equals(emittedTypeName.TypeName) && emittedTypeName.InferredArity > 0);

                if (emittedTypeName.ForcedArity == -1 || emittedTypeName.ForcedArity == emittedTypeName.InferredArity)
                {
                    // Let's handle mangling case first.
                    namespaceOrTypeMembers = scope.GetTypeMembers(emittedTypeName.UnmangledTypeName);

                    foreach (var named in namespaceOrTypeMembers)
                    {
                        if (emittedTypeName.InferredArity == named.Arity && named.MangleName)
                        {
                            if ((object)namedType != null)
                            {
                                namedType = null;
                                break;
                            }

                            namedType = named;
                        }
                    }
                }
            }
            else
            {
                Debug.Assert(ReferenceEquals(emittedTypeName.UnmangledTypeName, emittedTypeName.TypeName) && emittedTypeName.InferredArity == 0);
            }

            // Now try lookup without removing generic arity mangling.
            int forcedArity = emittedTypeName.ForcedArity;

            if (emittedTypeName.UseCLSCompliantNameArityEncoding)
            {
                // Only types with arity 0 are acceptable, we already examined types with mangled names.
                if (emittedTypeName.InferredArity > 0)
                {
                    goto Done;
                }
                else if (forcedArity == -1)
                {
                    forcedArity = 0;
                }
                else if (forcedArity != 0)
                {
                    goto Done;
                }
                else
                {
                    Debug.Assert(forcedArity == emittedTypeName.InferredArity);
                }
            }

            namespaceOrTypeMembers = scope.GetTypeMembers(emittedTypeName.TypeName);

            foreach (var named in namespaceOrTypeMembers)
            {
                if (!named.MangleName && (forcedArity == -1 || forcedArity == named.Arity))
                {
                    if ((object)namedType != null)
                    {
                        namedType = null;
                        break;
                    }

                    namedType = named;
                }
            }

        Done:
            if ((object)namedType == null)
            {
                if (isTopLevel)
                {
                    return this.ContainingModule.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(scope.ContainingModule, emittedTypeName.FullName, emittedTypeName.FullName, ErrorKind.Missing);
                }
                else
                {
                    return this.ContainingModule.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>((NamedTypeSymbol)scope, emittedTypeName.FullName, emittedTypeName.FullName, ErrorKind.Missing);
                }
            }

            return namedType;
        }


        /// <summary>
        /// Finds types or namespaces described by a qualified name.
        /// </summary>
        /// <param name="qualifiedName">Sequence of simple plain names.</param>
        /// <returns>
        /// A set of namespace or type symbols with given qualified name (might comprise of types with multiple generic arities), 
        /// or an empty set if the member can't be found (the qualified name is ambiguous or the symbol doesn't exist).
        /// </returns>
        /// <remarks>
        /// "C.D" matches C.D, C{T}.D, C{S,T}.D{U}, etc.
        /// </remarks>
        internal IEnumerable<NamespaceOrTypeSymbol>? GetNamespaceOrTypeByQualifiedName(IEnumerable<string> qualifiedName)
        {
            NamespaceOrTypeSymbol namespaceOrType = this;
            IEnumerable<NamespaceOrTypeSymbol>? symbols = null;
            foreach (string name in qualifiedName)
            {
                if (symbols != null)
                {
                    // there might be multiple types of different arity, prefer a non-generic type:
                    namespaceOrType = symbols.OfMinimalArity();
                    if ((object)namespaceOrType == null)
                    {
                        return SpecializedCollections.EmptyEnumerable<NamespaceOrTypeSymbol>();
                    }
                }

                symbols = namespaceOrType.GetMembers(name).OfType<NamespaceOrTypeSymbol>();
            }

            return symbols;
        }
    }
}
