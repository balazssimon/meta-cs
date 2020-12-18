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
    internal sealed class RetargetingNamedTypeSymbol : WrappedNamedTypeSymbol
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

        private RetargetingModuleSymbol.RetargetingSymbolTranslator RetargetingTranslator
        {
            get
            {
                return _retargetingModule.RetargetingTranslator;
            }
        }

        public override NamedTypeSymbol EnumUnderlyingType
        {
            get
            {
                var underlying = _underlyingType.EnumUnderlyingType;
                return (object)underlying == null ? null : this.RetargetingTranslator.Retarget(underlying, RetargetOptions.RetargetPrimitiveTypesByTypeCode); // comes from field's signature.
            }
        }

        public override IEnumerable<string> MemberNames
        {
            get
            {
                return _underlyingType.MemberNames;
            }
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetMembers());
        }

        internal override ImmutableArray<DeclaredSymbol> GetMembersUnordered()
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetMembersUnordered());
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetMembers(name));
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetMembers(name, metadataName));
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetTypeMembersUnordered());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetTypeMembers());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetTypeMembers(name));
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return this.RetargetingTranslator.Retarget(_underlyingType.GetTypeMembers(name, metadataName));
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                var container = _underlyingType.ContainingSymbol as DeclaredSymbol;
                if (container == null) return null;
                else return this.RetargetingTranslator.Retarget(container);
            }
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            return this.RetargetingTranslator.GetRetargetedAttributes(_underlyingType.GetAttributes(), ref _lazyCustomAttributes);
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
            return this.RetargetingTranslator.Retarget(_underlyingType.LookupMetadataType(ref typeName), RetargetOptions.RetargetPrimitiveTypesByName);
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
                var declaredInterfaces = GetDeclaredBaseTypes(basesBeingResolved);

                ImmutableArray<NamedTypeSymbol> result = declaredInterfaces
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
                var result = this.RetargetingTranslator.Retarget(underlyingBaseTypes);
                ImmutableInterlocked.InterlockedCompareExchange(ref _lazyDeclaredBaseTypes, result, default(ImmutableArray<NamedTypeSymbol>));
            }

            return _lazyDeclaredBaseTypes;
        }

        public override DiagnosticInfo GetUseSiteDiagnostic()
        {
            if (ReferenceEquals(_lazyUseSiteDiagnostic, LanguageDiagnosticInfo.EmptyErrorInfo))
            {
                _lazyUseSiteDiagnostic = CalculateUseSiteDiagnostic();
            }

            return _lazyUseSiteDiagnostic;
        }

        internal sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }
    }
}
