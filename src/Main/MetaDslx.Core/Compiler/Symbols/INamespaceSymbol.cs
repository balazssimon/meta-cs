using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Compiler.Symbols
{
    public interface INamespaceSymbol : INamespaceOrTypeSymbol
    {
        /// <summary>
        /// The kind of namespace: Module, Assembly or Compilation.
        /// Module namespaces contain only members from the containing module that share the same namespace name.
        /// Assembly namespaces contain members for all modules in the containing assembly that share the same namespace name.
        /// Compilation namespaces contain all members, from source or referenced metadata (assemblies and modules) that share the same namespace name.
        /// </summary>
        int NamespaceKind { get; }

        /// <summary>
        /// If a namespace is an assembly or compilation namespace, it may be composed of multiple
        /// namespaces that are merged together. If so, ConstituentNamespaces returns
        /// all the namespaces that were merged. If this namespace was not merged, returns
        /// an array containing only this namespace.
        /// </summary>
        ImmutableArray<INamespaceSymbol> ConstituentNamespaces { get; }

    }
}
