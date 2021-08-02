// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// AssemblySymbol to represent missing, for whatever reason, CorLibrary.
    /// The symbol is created by ReferenceManager on as needed basis and is shared by all compilations
    /// with missing CorLibraries.
    /// </summary>
    internal sealed class MissingCorLibrarySymbol : MissingAssemblySymbol
    {
        internal static readonly MissingCorLibrarySymbol Instance = new MissingCorLibrarySymbol();

        /// <summary>
        /// A dictionary of cached Cor types defined in this assembly.
        /// Lazily filled by GetSpecialSymbol method.
        /// </summary>
        /// <remarks></remarks>
        private ConcurrentDictionary<object, DeclaredSymbol> _lazySpecialSymbols;

        private MissingCorLibrarySymbol()
            : base(new AssemblyIdentity("<Missing Core Assembly>"))
        {
            this.SetCorLibrary(this);
        }

        /// <summary>
        /// Lookup declaration for predefined CorLib type in this Assembly. Only should be
        /// called if it is know that this is the Cor Library (mscorlib).
        /// </summary>
        /// <param name="type"></param>
        public override DeclaredSymbol GetDeclaredSpecialSymbol(object key)
        {
#if DEBUG
            foreach (var module in this.Modules)
            {
                Debug.Assert(module.ReferencedAssemblies.Length == 0);
            }
#endif

            DeclaredSymbol result;
            if (_lazySpecialSymbols == null || !_lazySpecialSymbols.ContainsKey(key))
            {
                ModuleSymbol module = this.Modules[0];
                if (key is SpecialType type)
                {
                    MetadataTypeName emittedName = MetadataTypeName.FromFullName(type.GetMetadataName(), useCLSCompliantNameArityEncoding: true);
                    result = module.LookupTopLevelMetadataType(ref emittedName);
                    if (!result.IsError && result.DeclaredAccessibility != Accessibility.Public)
                    {
                        result = new MissingMetadataTypeSymbol.TopLevel(module, ref emittedName, type);
                    }
                }
                else
                {
                    result = this.Language.CompilationFactory.CreateSpecialSymbol(module, key) as DeclaredSymbol;
                    if (result == null)
                    {
                        result = new MissingMetadataTypeSymbol.TopLevel(module, string.Empty, key.ToString(), 0, false);
                    }
                }
                RegisterDeclaredSpecialSymbol(key, ref result);
            }

            return _lazySpecialSymbols[key];
        }

        /// <summary>
        /// Register declaration of predefined symbol in this Assembly.
        /// </summary>
        /// <param name="corType"></param>
        private void RegisterDeclaredSpecialSymbol(object key, ref DeclaredSymbol symbol)
        {
            Debug.Assert(key != null);
            Debug.Assert(ReferenceEquals(symbol.ContainingAssembly, this));
            Debug.Assert(symbol.ContainingModule.Ordinal == 0);
            Debug.Assert(ReferenceEquals(this.CorLibrary, this));

            if (_lazySpecialSymbols == null)
            {
                Interlocked.CompareExchange(ref _lazySpecialSymbols, new ConcurrentDictionary<object, DeclaredSymbol>(), null);
            }
            _lazySpecialSymbols.TryAdd(key, symbol);
        }
    }
}
