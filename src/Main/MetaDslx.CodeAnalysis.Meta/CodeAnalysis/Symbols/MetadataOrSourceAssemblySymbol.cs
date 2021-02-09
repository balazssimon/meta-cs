// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents source or metadata assembly.
    /// </summary>
    /// <remarks></remarks>
    public abstract class MetadataOrSourceAssemblySymbol
        : NonMissingAssemblySymbol
    {
        /// <summary>
        /// A dictionary of cached Cor types defined in this assembly.
        /// Lazily filled by GetSpecialSymbol method.
        /// </summary>
        /// <remarks></remarks>
        private ConcurrentDictionary<object, DeclaredSymbol> _lazySpecialSymbols;

        /// <summary>
        /// Lookup declaration for predefined symbol in this Assembly.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override DeclaredSymbol GetDeclaredSpecialSymbol(object key)
        {
#if DEBUG
            foreach (var module in this.Modules)
            {
                Debug.Assert(module.ReferencedAssemblies.Length == 0);
            }
#endif

            MetadataTypeName emittedName = default;
            DeclaredSymbol result = null;
            if (_lazySpecialSymbols == null || !_lazySpecialSymbols.ContainsKey(key))
            {
                ModuleSymbol firstModule = this.Modules[0];
                if (key is SpecialType)
                {
                    emittedName = MetadataTypeName.FromFullName(((SpecialType)key).GetMetadataName(), useCLSCompliantNameArityEncoding: true);
                    result = firstModule.LookupTopLevelMetadataType(ref emittedName);
                    if (result.Kind == LanguageSymbolKind.ErrorType || result.DeclaredAccessibility != Accessibility.Public)
                    {
                        result = null;
                    }
                }
                if (result == null)
                {
                    foreach (var module in this.Modules)
                    {
                        var symbol = this.Language.CompilationFactory.CreateSpecialSymbol(module, key) as DeclaredSymbol;
                        if (symbol != null)
                        {
                            result = symbol;
                            break;
                        }
                    }
                }
                if (result == null || (result.Kind != LanguageSymbolKind.ErrorType && result.DeclaredAccessibility != Accessibility.Public))
                {
                    if (key is SpecialType)
                    {
                        result = new MissingMetadataTypeSymbol.TopLevel(firstModule, ref emittedName, (SpecialType)key);
                    }
                    else
                    {
                        result = new MissingMetadataTypeSymbol.TopLevel(firstModule, string.Empty, key.ToString(), 0, false);
                    }
                }
                RegisterDeclaredSpecialSymbol(key, ref result);
            }

            return _lazySpecialSymbols[key];
        }

        public override ImmutableArray<DeclaredSymbol> DeclaredSpecialSymbols => _lazySpecialSymbols == null ? ImmutableArray<DeclaredSymbol>.Empty : _lazySpecialSymbols.Values.ToImmutableArray();


        /// <summary>
        /// Register declaration of predefined symbol in this Assembly.
        /// </summary>
        /// <param name="corType"></param>
        private void RegisterDeclaredSpecialSymbol(object key, ref DeclaredSymbol symbol)
        {
            Debug.Assert(key != null);
            Debug.Assert(ReferenceEquals(symbol.ContainingAssembly, this));

            if (_lazySpecialSymbols == null)
            {
                Interlocked.CompareExchange(ref _lazySpecialSymbols, new ConcurrentDictionary<object, DeclaredSymbol>(), null);
            }
            _lazySpecialSymbols.TryAdd(key, symbol);
        }

        private ICollection<string> _lazyTypeNames;
        private ICollection<string> _lazyNamespaceNames;

        public override ICollection<string> TypeNames
        {
            get
            {
                if (_lazyTypeNames == null)
                {
                    Interlocked.CompareExchange(ref _lazyTypeNames, UnionCollection<string>.Create(this.Modules, m => m.TypeNames), null);
                }

                return _lazyTypeNames;
            }
        }

        public override ICollection<string> NamespaceNames
        {
            get
            {
                if (_lazyNamespaceNames == null)
                {
                    Interlocked.CompareExchange(ref _lazyNamespaceNames, UnionCollection<string>.Create(this.Modules, m => m.NamespaceNames), null);
                }

                return _lazyNamespaceNames;
            }
        }

        /// <summary>
        /// Not yet known value is represented by ErrorTypeSymbol.UnknownResultType
        /// </summary>
        private Symbol[] _lazySpecialTypeMembers;

        /// <summary>
        /// Lookup member declaration in predefined CorLib type in this Assembly. Only valid if this 
        /// assembly is the Cor Library
        /// </summary>
        internal override Symbol GetDeclaredSpecialTypeMember(SpecialMember member)
        {
#if DEBUG
            foreach (var module in this.Modules)
            {
                Debug.Assert(module.ReferencedAssemblies.Length == 0);
            }
#endif

            if (_lazySpecialTypeMembers == null || ReferenceEquals(_lazySpecialTypeMembers[(int)member], ErrorTypeSymbol.UnknownResultType))
            {
                if (_lazySpecialTypeMembers == null)
                {
                    var specialTypeMembers = new Symbol[(int)SpecialMember.Count];

                    for (int i = 0; i < specialTypeMembers.Length; i++)
                    {
                        specialTypeMembers[i] = ErrorTypeSymbol.UnknownResultType;
                    }

                    Interlocked.CompareExchange(ref _lazySpecialTypeMembers, specialTypeMembers, null);
                }

                var descriptor = SpecialMembers.GetDescriptor(member);
                NamedTypeSymbol type = (NamedTypeSymbol)GetDeclaredSpecialSymbol((SpecialType)descriptor.DeclaringTypeId);
                Symbol result = null;

                if (!type.IsErrorType())
                {
                    throw new NotImplementedException("TODO:MetaDslx");
                    // result = LanguageCompilation.GetRuntimeMember(type, ref descriptor, LanguageCompilation.SpecialMembersSignatureComparer.Instance, accessWithinOpt: null);
                }

                Interlocked.CompareExchange(ref _lazySpecialTypeMembers[(int)member], result, ErrorTypeSymbol.UnknownResultType);
            }

            return _lazySpecialTypeMembers[(int)member];
        }

        /// <summary>
        /// Determine whether this assembly has been granted access to <paramref name="potentialGiverOfAccess"></paramref>.
        /// Assumes that the public key has been determined. The result will be cached.
        /// </summary>
        /// <param name="potentialGiverOfAccess"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected IVTConclusion MakeFinalIVTDetermination(AssemblySymbol potentialGiverOfAccess)
        {
            IVTConclusion result;
            if (AssembliesToWhichInternalAccessHasBeenDetermined.TryGetValue(potentialGiverOfAccess, out result))
                return result;

            result = IVTConclusion.NoRelationshipClaimed;

            // returns an empty list if there was no IVT attribute at all for the given name
            // A name w/o a key is represented by a list with an entry that is empty
            IEnumerable<ImmutableArray<byte>> publicKeys = potentialGiverOfAccess.GetInternalsVisibleToPublicKeys(this.Name);

            // We have an easy out here. Suppose the assembly wanting access is 
            // being compiled as a module. You can only strong-name an assembly. So we are going to optimistically 
            // assume that it is going to be compiled into an assembly with a matching strong name, if necessary.
            if (publicKeys.Any() && this.IsNetModule())
            {
                return IVTConclusion.Match;
            }

            // look for one that works, if none work, then return the failure for the last one examined.
            foreach (var key in publicKeys)
            {
                // We pass the public key of this assembly explicitly so PerformIVTCheck does not need
                // to get it from this.Identity, which would trigger an infinite recursion.
                result = potentialGiverOfAccess.Identity.PerformIVTCheck(this.PublicKey, key);
                Debug.Assert(result != IVTConclusion.NoRelationshipClaimed);

                if (result == IVTConclusion.Match || result == IVTConclusion.OneSignedOneNot)
                {
                    break;
                }
            }

            AssembliesToWhichInternalAccessHasBeenDetermined.TryAdd(potentialGiverOfAccess, result);
            return result;
        }

        //EDMAURER This is a cache mapping from assemblies which we have analyzed whether or not they grant
        //internals access to us to the conclusion reached.
        private ConcurrentDictionary<AssemblySymbol, IVTConclusion> _assembliesToWhichInternalAccessHasBeenAnalyzed;

        private ConcurrentDictionary<AssemblySymbol, IVTConclusion> AssembliesToWhichInternalAccessHasBeenDetermined
        {
            get
            {
                if (_assembliesToWhichInternalAccessHasBeenAnalyzed == null)
                    Interlocked.CompareExchange(ref _assembliesToWhichInternalAccessHasBeenAnalyzed, new ConcurrentDictionary<AssemblySymbol, IVTConclusion>(), null);
                return _assembliesToWhichInternalAccessHasBeenAnalyzed;
            }
        }
    }
}
