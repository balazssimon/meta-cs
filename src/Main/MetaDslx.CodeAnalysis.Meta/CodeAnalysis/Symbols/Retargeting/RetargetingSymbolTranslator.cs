// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Cci;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    using CSharpSymbols = MetaDslx.CodeAnalysis.CSharp.Symbols;
    using PEModuleSymbol = MetaDslx.CodeAnalysis.CSharp.Symbols.Metadata.PE.PEModuleSymbol;

    internal enum RetargetOptions : byte
    {
        RetargetPrimitiveTypesByName = 0,
        RetargetPrimitiveTypesByTypeCode = 1,
    }

    public partial class RetargetingModuleSymbol
    {
        /// <summary>
        /// Retargeting map from underlying module to this one.
        /// </summary>
        private readonly ConcurrentDictionary<Symbol, Symbol> _symbolMap =
            new ConcurrentDictionary<Symbol, Symbol>(concurrencyLevel: 2, capacity: 4);

        private readonly Func<Symbol, RetargetingNamespaceSymbol> _createRetargetingNamespace;
        private readonly Func<Symbol, RetargetingNamedTypeSymbol> _createRetargetingNamedType;
        private readonly Func<Symbol, RetargetingMemberSymbol> _createRetargetingMember;

        private RetargetingNamespaceSymbol CreateRetargetingNamespace(Symbol symbol)
        {
            Debug.Assert(ReferenceEquals(symbol.ContainingModule, _underlyingModule));
            return new RetargetingNamespaceSymbol(this, (NamespaceSymbol)symbol);
        }

        private RetargetingNamedTypeSymbol CreateRetargetingNamedType(Symbol symbol)
        {
            Debug.Assert(ReferenceEquals(symbol.ContainingModule, _underlyingModule));
            return new RetargetingNamedTypeSymbol(this, (NamedTypeSymbol)symbol);
        }

        private RetargetingMemberSymbol CreateRetargetingMember(Symbol symbol)
        {
            Debug.Assert(ReferenceEquals(symbol.ContainingModule, _underlyingModule));
            return new RetargetingMemberSymbol(this, (MemberSymbol)symbol);
        }

        internal class RetargetingSymbolTranslator
            : SymbolVisitor<RetargetOptions, Symbol>
        {
            private readonly RetargetingModuleSymbol _retargetingModule;

            public RetargetingSymbolTranslator(RetargetingModuleSymbol retargetingModule)
            {
                Debug.Assert((object)retargetingModule != null);
                _retargetingModule = retargetingModule;
            }

            /// <summary>
            /// Retargeting map from underlying module to the retargeting module.
            /// </summary>
            private ConcurrentDictionary<Symbol, Symbol> SymbolMap
            {
                get
                {
                    return _retargetingModule._symbolMap;
                }
            }

            /// <summary>
            /// RetargetingAssemblySymbol owning retargetingModule.
            /// </summary>
            private RetargetingAssemblySymbol RetargetingAssembly
            {
                get
                {
                    return _retargetingModule._retargetingAssembly;
                }
            }

            /// <summary>
            /// The underlying ModuleSymbol for retargetingModule.
            /// </summary>
            private SourceModuleSymbol UnderlyingModule
            {
                get
                {
                    return _retargetingModule._underlyingModule;
                }
            }

            /// <summary>
            /// The map that captures information about what assembly should be retargeted 
            /// to what assembly. Key is the AssemblySymbol referenced by the underlying module,
            /// value is the corresponding AssemblySymbol referenced by the retargeting module, and 
            /// corresponding retargeting map for symbols.
            /// </summary>
            private Dictionary<AssemblySymbol, DestinationData> RetargetingAssemblyMap
            {
                get
                {
                    return _retargetingModule._retargetingAssemblyMap;
                }
            }

            public DeclaredSymbol Retarget(DeclaredSymbol symbol)
            {
                Debug.Assert(symbol.Kind != LanguageSymbolKind.NamedType || ((NamedTypeSymbol)symbol).PrimitiveTypeCode == PrimitiveTypeCode.NotPrimitive);
                return symbol.Accept(this, RetargetOptions.RetargetPrimitiveTypesByName) as DeclaredSymbol;
            }

            public MarshalPseudoCustomAttributeData Retarget(MarshalPseudoCustomAttributeData marshallingInfo)
            {
                // Retarget by type code - primitive types are encoded in short form in an attribute signature:
                return marshallingInfo?.WithTranslatedTypes<TypeSymbol, RetargetingSymbolTranslator>(
                    (type, translator) => translator.Retarget(type, RetargetOptions.RetargetPrimitiveTypesByTypeCode), this);
            }

            public TypeSymbol Retarget(TypeSymbol symbol, RetargetOptions options)
            {
                return (TypeSymbol)symbol.Accept(this, options);
            }

            public NamespaceSymbol Retarget(NamespaceSymbol ns)
            {
                return (NamespaceSymbol)this.SymbolMap.GetOrAdd(ns, _retargetingModule._createRetargetingNamespace);
            }

            private NamedTypeSymbol RetargetNamedTypeDefinition(NamedTypeSymbol type, RetargetOptions options)
            {
                Debug.Assert(type.IsDefinition);

                // Before we do anything else, check if we need to do special retargeting
                // for primitive type references encoded with enum values in metadata signatures.
                if (options == RetargetOptions.RetargetPrimitiveTypesByTypeCode)
                {
                    PrimitiveTypeCode typeCode = type.PrimitiveTypeCode;

                    if (typeCode != PrimitiveTypeCode.NotPrimitive)
                    {
                        return RetargetingAssembly.GetPrimitiveType(typeCode);
                    }
                }

                if (type.Kind == LanguageSymbolKind.ErrorType)
                {
                    return Retarget((ErrorTypeSymbol)type);
                }

                AssemblySymbol retargetFrom = type.ContainingAssembly;

                // Deal with "to be local" NoPia types leaking through source module.
                // These are the types that are coming from assemblies linked (/l-ed) 
                // by the compilation that created the source module.
                bool isLocalType;

                if (ReferenceEquals(retargetFrom, this.RetargetingAssembly.UnderlyingAssembly))
                {
                    Debug.Assert(!retargetFrom.IsLinked);
                    isLocalType = type.IsExplicitDefinitionOfNoPiaLocalType;
                }
                else
                {
                    isLocalType = retargetFrom.IsLinked;
                }

                if (isLocalType)
                {
                    return RetargetNoPiaLocalType(type);
                }

                // Perform general retargeting.

                if (ReferenceEquals(retargetFrom, this.RetargetingAssembly.UnderlyingAssembly))
                {
                    return RetargetNamedTypeDefinitionFromUnderlyingAssembly(type);
                }

                // Does this type come from one of the retargeted assemblies?
                DestinationData destination;

                if (!this.RetargetingAssemblyMap.TryGetValue(retargetFrom, out destination))
                {
                    // No need to retarget
                    return type;
                }

                // Retarget from one assembly to another
                type = PerformTypeRetargeting(ref destination, type);
                this.RetargetingAssemblyMap[retargetFrom] = destination;
                return type;
            }

            private NamedTypeSymbol RetargetNamedTypeDefinitionFromUnderlyingAssembly(NamedTypeSymbol type)
            {
                // The type is defined in the underlying assembly.
                var module = type.ContainingModule;

                if (ReferenceEquals(module, this.UnderlyingModule))
                {
                    Debug.Assert(module.Ordinal == 0);
                    Debug.Assert(!type.IsExplicitDefinitionOfNoPiaLocalType);
                    var container = type.ContainingType;

                    while ((object)container != null)
                    {
                        if (container.IsExplicitDefinitionOfNoPiaLocalType)
                        {
                            // Types nested into local types are not supported.
                            return (NamedTypeSymbol)this.SymbolMap.GetOrAdd(type, new UnsupportedMetadataTypeSymbol());
                        }

                        container = container.ContainingType;
                    }

                    return (NamedTypeSymbol)this.SymbolMap.GetOrAdd(type, _retargetingModule._createRetargetingNamedType);
                }
                else
                {
                    // The type is defined in one of the added modules
                    Debug.Assert(module.Ordinal > 0);
                    CSharpModuleSymbol addedModule = (CSharpModuleSymbol)this.RetargetingAssembly.Modules[module.Ordinal];
                    Debug.Assert(ReferenceEquals(((CSharpModuleSymbol)module).Module, addedModule.Module));
                    return RetargetNamedTypeDefinition((CSharpNamedTypeSymbol)type, addedModule);
                }
            }

            private NamedTypeSymbol RetargetNoPiaLocalType(NamedTypeSymbol type)
            {
                NamedTypeSymbol cached;

                var map = this.RetargetingAssembly.NoPiaUnificationMap;
                if (map.TryGetValue(type, out cached))
                {
                    return cached;
                }

                // TODO:MetaDslx - find and evaluate RetargetingAttribute
                NamedTypeSymbol result = new UnsupportedMetadataTypeSymbol();
                cached = map.GetOrAdd(type, result);
                return cached;
            }

            private static NamedTypeSymbol RetargetNamedTypeDefinition(CSharpNamedTypeSymbol type, CSharpModuleSymbol addedModule)
            {
                Debug.Assert(!type.ContainingModule.Equals(addedModule) &&
                             ReferenceEquals(((CSharpModuleSymbol)type.ContainingModule).Module, addedModule.Module));

                TypeSymbol cached;

                if (addedModule.CSharpSymbolMap.TryGetSymbol(type.CSharpSymbol, out cached))
                {
                    return (NamedTypeSymbol)cached;
                }

                NamedTypeSymbol result;

                NamedTypeSymbol containingType = type.ContainingType;
                MetadataTypeName mdName;

                if ((object)containingType != null)
                {
                    // Nested type.  We need to retarget 
                    // the enclosing type and then go back and get the type we are interested in.

                    NamedTypeSymbol scope = RetargetNamedTypeDefinition((CSharpNamedTypeSymbol)containingType, addedModule);

                    mdName = MetadataTypeName.FromTypeName(type.MetadataName, forcedArity: type.Arity);
                    result = scope.LookupMetadataType(ref mdName);
                    Debug.Assert((object)result != null && result.Arity == type.Arity);
                }
                else
                {
                    string namespaceName = type.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat);
                    mdName = MetadataTypeName.FromNamespaceAndTypeName(namespaceName, type.MetadataName, forcedArity: type.Arity);
                    result = addedModule.LookupTopLevelMetadataType(ref mdName);

                    Debug.Assert(result.Arity == type.Arity);
                }

                return result;
            }

            private static NamedTypeSymbol PerformTypeRetargeting(
                ref DestinationData destination,
                NamedTypeSymbol type)
            {
                NamedTypeSymbol result;

                if (!destination.SymbolMap.TryGetValue(type, out result))
                {
                    // Lookup by name as a TypeRef.
                    NamedTypeSymbol containingType = type.ContainingType;
                    NamedTypeSymbol result1;
                    MetadataTypeName mdName;

                    if ((object)containingType != null)
                    {
                        // This happens if type is a nested class.  We need to retarget 
                        // the enclosing class and then go back and get the type we are interested in.

                        NamedTypeSymbol scope = PerformTypeRetargeting(ref destination, containingType);
                        mdName = MetadataTypeName.FromTypeName(type.MetadataName, forcedArity: type.Arity);
                        result1 = scope.LookupMetadataType(ref mdName);
                        Debug.Assert((object)result1 != null && result1.Arity == type.Arity);
                    }
                    else
                    {
                        string namespaceName = type.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat);
                        mdName = MetadataTypeName.FromNamespaceAndTypeName(namespaceName, type.MetadataName, forcedArity: type.Arity);
                        result1 = destination.To.LookupTopLevelMetadataType(ref mdName, digThroughForwardedTypes: true);

                        Debug.Assert(result1.Arity == type.Arity);
                    }

                    result = destination.SymbolMap.GetOrAdd(type, result1);
                    Debug.Assert(TypeSymbol.Equals(result1, result, TypeCompareKind.ConsiderEverything2));
                }

                return result;
            }

            public NamedTypeSymbol Retarget(NamedTypeSymbol type, RetargetOptions options)
            {
                NamedTypeSymbol originalDefinition = type.OriginalDefinition;

                NamedTypeSymbol newDefinition = RetargetNamedTypeDefinition(originalDefinition, options);

                if (ReferenceEquals(type, originalDefinition))
                {
                    return newDefinition;
                }

                if (newDefinition.Kind == LanguageSymbolKind.ErrorType)
                {
                    return newDefinition;
                }

                // Nothing was retargeted, return original type symbol.
                return type;
            }

            public static ErrorTypeSymbol Retarget(ErrorTypeSymbol type)
            {
                // TODO: if it is a missing symbol error but no longer missing in the target assembly, then we can resolve it here.

                var useSiteDiagnostic = type.GetUseSiteDiagnostic();
                if (useSiteDiagnostic != null)
                {
                    return type;
                }

                // A retargeted error symbol must trigger an error on use so that a dependent compilation won't
                // improperly succeed. We therefore ensure we have a use-site diagnostic.
                return
                    (type as ExtendedErrorTypeSymbol)?.AsUnreported() ?? // preserve diagnostic information if possible
                    new ExtendedErrorTypeSymbol(type, type.ResultKind,
                        type.ErrorInfo ?? new LanguageDiagnosticInfo(InternalErrorCode.ERR_ErrorInReferencedAssembly, type.ContainingAssembly?.Identity.GetDisplayName() ?? string.Empty), true);
            }

            public ImmutableArray<DeclaredSymbol> Retarget(ImmutableArray<DeclaredSymbol> arr)
            {
                var symbols = ArrayBuilder<DeclaredSymbol>.GetInstance(arr.Length);

                foreach (var s in arr)
                {
                    symbols.Add(Retarget(s));
                }

                return symbols.ToImmutableAndFree();
            }

            public ImmutableArray<NamedTypeSymbol> Retarget(ImmutableArray<NamedTypeSymbol> sequence)
            {
                var result = ArrayBuilder<NamedTypeSymbol>.GetInstance(sequence.Length);

                foreach (var nts in sequence)
                {
                    // If there is an error type in the base type list, it will end up in the interface list (rather
                    // than as the base class), so it might end up passing through here.  If it is specified using
                    // a primitive type keyword, then it will have a primitive type code, even if corlib is missing.
                    Debug.Assert(nts.TypeKind == TypeKind.Error || nts.PrimitiveTypeCode == PrimitiveTypeCode.NotPrimitive);
                    result.Add(Retarget(nts, RetargetOptions.RetargetPrimitiveTypesByName));
                }

                return result.ToImmutableAndFree();
            }

            public ImmutableArray<TypeSymbol> Retarget(ImmutableArray<TypeSymbol> sequence)
            {
                var result = ArrayBuilder<TypeSymbol>.GetInstance(sequence.Length);

                foreach (var ts in sequence)
                {
                    // In incorrect code, a type parameter constraint list can contain primitive types.
                    Debug.Assert(ts.TypeKind == TypeKind.Error || ts.PrimitiveTypeCode == PrimitiveTypeCode.NotPrimitive);
                    result.Add(Retarget(ts, RetargetOptions.RetargetPrimitiveTypesByName));
                }

                return result.ToImmutableAndFree();
            }

            public MemberSymbol Retarget(MemberSymbol member)
            {
                return (MemberSymbol)this.SymbolMap.GetOrAdd(member, _retargetingModule._createRetargetingMember);
            }

            private ImmutableArray<AttributeData> RetargetAttributes(ImmutableArray<AttributeData> oldAttributes)
            {
                return oldAttributes.SelectAsArray((a, t) => t.RetargetAttributeData(a), this);
            }

            internal IEnumerable<AttributeData> RetargetAttributes(IEnumerable<AttributeData> attributes)
            {
                foreach (var attributeData in attributes)
                {
                    var newAttribute = this.RetargetAttributeData(attributeData); 
                    if ((object)newAttribute != null) yield return newAttribute;
                }
            }

            protected virtual AttributeData RetargetAttributeData(AttributeData oldAttributeData)
            {
                return null;
            }

            // Get the retargeted attributes
            internal ImmutableArray<AttributeData> GetRetargetedAttributes(
                ImmutableArray<AttributeData> underlyingAttributes,
                ref ImmutableArray<AttributeData> lazyCustomAttributes)
            {
                if (lazyCustomAttributes.IsDefault)
                {
                    // Retarget the attributes
                    ImmutableArray<AttributeData> retargetedAttributes = this.RetargetAttributes(underlyingAttributes);

                    ImmutableInterlocked.InterlockedCompareExchange(ref lazyCustomAttributes, retargetedAttributes, default(ImmutableArray<AttributeData>));
                }

                return lazyCustomAttributes;
            }

            public override Symbol VisitModule(ModuleSymbol symbol, RetargetOptions options)
            {
                // We shouldn't run into any other module, but the underlying module
                Debug.Assert(ReferenceEquals(symbol, _retargetingModule.UnderlyingModule));
                return _retargetingModule;
            }

            public override Symbol VisitNamespace(NamespaceSymbol symbol, RetargetOptions options)
            {
                return Retarget(symbol);
            }

            public override Symbol VisitNamedType(NamedTypeSymbol symbol, RetargetOptions options)
            {
                return Retarget(symbol, options);
            }

            public override Symbol VisitMethod(MethodSymbol symbol, RetargetOptions options)
            {
                return Retarget(symbol);
            }

            public override Symbol VisitMember(MemberSymbol symbol, RetargetOptions options)
            {
                return Retarget(symbol);
            }

            public override Symbol VisitErrorType(ErrorTypeSymbol symbol, RetargetOptions options)
            {
                return Retarget(symbol);
            }

            public override Symbol VisitDynamicType(DynamicTypeSymbol symbol, RetargetOptions argument)
            {
                // TODO(cyrusn): What's the right thing to do here?
                return symbol;
            }
        }
    }
}
