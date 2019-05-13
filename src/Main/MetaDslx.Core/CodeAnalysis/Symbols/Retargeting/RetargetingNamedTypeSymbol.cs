// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Wrapped;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    /// <summary>
    /// Represents a type of a RetargetingModuleSymbol. Essentially this is a wrapper around 
    /// another NamedTypeSymbol that is responsible for retargeting referenced symbols from one assembly to another. 
    /// It can retarget symbols for multiple assemblies at the same time.
    /// </summary>
    public sealed class RetargetingNamedTypeSymbol : WrappedNamedTypeSymbol
    {
        /// <summary>
        /// Owning RetargetingModuleSymbol.
        /// </summary>
        private readonly RetargetingModuleSymbol _retargetingModule;

        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes = default(ImmutableArray<NamedTypeSymbol>);
        private ImmutableArray<NamedTypeSymbol> _lazyDeclaredBaseTypes;

        private ImmutableArray<AttributeData> _lazyCustomAttributes;

        private DiagnosticInfo _lazyUseSiteDiagnostic = LanguageDiagnosticInfo.EmptyErrorInfo; // Indicates unknown state. 

        public RetargetingNamedTypeSymbol(RetargetingModuleSymbol retargetingModule, NamedTypeSymbol underlyingType)
            : base(underlyingType)
        {
            Debug.Assert((object)retargetingModule != null);
            Debug.Assert(!(underlyingType is RetargetingNamedTypeSymbol));

            _retargetingModule = retargetingModule;
        }

        private RetargetingSymbolMap RetargetingSymbolMap
        {
            get
            {
                return _retargetingModule.RetargetingSymbolMap;
            }
        }

        public override NamedTypeSymbol EnumUnderlyingType
        {
            get
            {
                var underlying = _underlyingType.EnumUnderlyingType;
                return (object)underlying == null ? null : this.RetargetingSymbolMap.GetNamedTypeSymbol(underlying);
            }
        }

        public override IEnumerable<string> MemberNames
        {
            get
            {
                return _underlyingType.MemberNames;
            }
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            return this.RetargetingSymbolMap.GetSymbols(_underlyingType.GetMembers());
        }

        internal override ImmutableArray<Symbol> GetMembersUnordered()
        {
            return this.RetargetingSymbolMap.GetSymbols(_underlyingType.GetMembersUnordered());
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return this.RetargetingSymbolMap.GetSymbols(_underlyingType.GetMembers(name));
        }

        public override ImmutableArray<Symbol> GetMembers(string name, string metadataName)
        {
            return this.RetargetingSymbolMap.GetSymbols(_underlyingType.GetMembers(name, metadataName));
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return this.RetargetingSymbolMap.GetNamedTypeSymbols(_underlyingType.GetTypeMembersUnordered());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.RetargetingSymbolMap.GetNamedTypeSymbols(_underlyingType.GetTypeMembers());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return this.RetargetingSymbolMap.GetNamedTypeSymbols(_underlyingType.GetTypeMembers(name));
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return this.RetargetingSymbolMap.GetNamedTypeSymbols(_underlyingType.GetTypeMembers(name, metadataName));
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return this.RetargetingSymbolMap.GetSymbol(_underlyingType.ContainingSymbol);
            }
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return _retargetingModule.ContainingAssembly;
            }
        }

        public override ModuleSymbol ContainingModule
        {
            get
            {
                return _retargetingModule;
            }
        }

        internal override NamedTypeSymbol LookupMetadataType(ref MetadataTypeName typeName)
        {
            return this.RetargetingSymbolMap.GetNamedTypeSymbol(_underlyingType.LookupMetadataType(ref typeName));
        }

        private static ExtendedErrorTypeSymbol CyclicInheritanceError(RetargetingNamedTypeSymbol type, TypeSymbol declaredBase)
        {
            var info = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ImportedCircularBase, declaredBase, type);
            return new ExtendedErrorTypeSymbol(declaredBase, LookupResultKind.NotReferencable, info, true);
        }

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyBaseTypes.IsDefault)
            {
                var declaredBaseTypes = GetDeclaredBaseTypes(basesBeingResolved);

                ImmutableArray<NamedTypeSymbol> result = declaredBaseTypes
                    .SelectAsArray(t => BaseTypeAnalysis.TypeDependsOn(t, this) ? CyclicInheritanceError(this, t) : t);

                ImmutableInterlocked.InterlockedCompareExchange(ref _lazyBaseTypes, result, default(ImmutableArray<NamedTypeSymbol>));
            }

            return _lazyBaseTypes;
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyDeclaredBaseTypes.IsDefault)
            {
                var underlyingBaseTypes = _underlyingType.GetDeclaredBaseTypes(basesBeingResolved);
                var result = this.RetargetingSymbolMap.GetNamedTypeSymbols(underlyingBaseTypes);
                ImmutableInterlocked.InterlockedCompareExchange(ref _lazyDeclaredBaseTypes, result, default(ImmutableArray<NamedTypeSymbol>));
            }

            return _lazyDeclaredBaseTypes;
        }

        public override DiagnosticInfo GetUseSiteDiagnostic()
        {
            if (ReferenceEquals(_lazyUseSiteDiagnostic, LanguageDiagnosticInfo.EmptyErrorInfo))
            {
                _lazyUseSiteDiagnostic = base.GetUseSiteDiagnostic();
            }

            return _lazyUseSiteDiagnostic;
        }

        internal sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }
    }
}
