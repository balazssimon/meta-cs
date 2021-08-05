﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;


namespace MetaDslx.CodeAnalysis.Symbols.Completion
{
    public abstract partial class CompletionAssemblySymbol : NonMissingAssemblySymbol
    {
        /// <summary>
        /// A dictionary of cached Cor types defined in this assembly.
        /// Lazily filled by GetSpecialSymbol method.
        /// </summary>
        /// <remarks></remarks>
        private ConcurrentDictionary<string, DeclaredSymbol> _lazySpecialSymbols;

        /// <summary>
        /// Not yet known value is represented by ErrorTypeSymbol.UnknownResultType
        /// </summary>
        private DeclaredSymbol[] _lazySpecialTypeMembers;

        public CompletionAssemblySymbol()
        {
            _state = CompletionParts.CompletionGraph.CreateState();
        }

        protected virtual string CompleteSymbolProperty_Name(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return this.Identity.Name;
        }

        protected virtual ImmutableArray<Symbol> CompleteCreatingChildSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return this.Modules.Cast<ModuleSymbol, Symbol>();
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
        /// Lookup member declaration in predefined CorLib type in this Assembly. Only valid if this 
        /// assembly is the Cor Library
        /// </summary>
        internal override DeclaredSymbol GetDeclaredSpecialTypeMember(SpecialMember member)
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
                    var specialTypeMembers = new DeclaredSymbol[(int)SpecialMember.Count];

                    for (int i = 0; i < specialTypeMembers.Length; i++)
                    {
                        specialTypeMembers[i] = ErrorTypeSymbol.UnknownResultType;
                    }

                    Interlocked.CompareExchange(ref _lazySpecialTypeMembers, specialTypeMembers, null);
                }

                var descriptor = SpecialMembers.GetDescriptor(member);
                NamedTypeSymbol type = (NamedTypeSymbol)GetSpecialSymbol((SpecialType)descriptor.DeclaringTypeId);
                DeclaredSymbol result = null;

                if (!type.IsError)
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
        internal IVTConclusion MakeFinalIVTDetermination(AssemblySymbol potentialGiverOfAccess)
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
