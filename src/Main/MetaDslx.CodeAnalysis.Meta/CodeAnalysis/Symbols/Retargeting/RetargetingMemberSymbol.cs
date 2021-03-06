﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols.Wrapped;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.Cci;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    /// <summary>
    /// Represents a member in a RetargetingModuleSymbol. Essentially this is a wrapper around 
    /// another MemberSymbol that is responsible for retargeting symbols from one assembly to another. 
    /// It can retarget symbols for multiple assemblies at the same time.
    /// </summary>
    internal sealed class RetargetingMemberSymbol : WrappedMemberSymbol
    {
        /// <summary>
        /// Owning RetargetingModuleSymbol.
        /// </summary>
        private readonly RetargetingModuleSymbol _retargetingModule;

        /// <summary>
        /// Retargeted custom attributes
        /// </summary>
        private ImmutableArray<AttributeData> _lazyCustomAttributes;

        private DiagnosticInfo _lazyUseSiteDiagnostic = LanguageDiagnosticInfo.EmptyErrorInfo; // Indicates unknown state. 

        public RetargetingMemberSymbol(RetargetingModuleSymbol retargetingModule, MemberSymbol underlyingMember)
            : base(underlyingMember)
        {
            Debug.Assert((object)retargetingModule != null);
            Debug.Assert(!(underlyingMember is RetargetingMemberSymbol));

            _retargetingModule = retargetingModule;
        }

        private RetargetingModuleSymbol.RetargetingSymbolTranslator RetargetingTranslator
        {
            get
            {
                return _retargetingModule.RetargetingTranslator;
            }
        }

        public RetargetingModuleSymbol RetargetingModule
        {
            get
            {
                return _retargetingModule;
            }
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return this.RetargetingTranslator.Retarget(_underlyingMember.ContainingSymbol);
            }
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            return this.RetargetingTranslator.GetRetargetedAttributes(_underlyingMember.GetAttributes(), ref _lazyCustomAttributes);
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

        public override DiagnosticInfo GetUseSiteDiagnostic()
        {
            if (ReferenceEquals(_lazyUseSiteDiagnostic, LanguageDiagnosticInfo.EmptyErrorInfo))
            {
                _lazyUseSiteDiagnostic = CalculateUseSiteDiagnostic();
            }

            return _lazyUseSiteDiagnostic;
        }

        internal override ImmutableArray<Symbol> GetMembersUnordered()
        {
            return RetargetMembers(_underlyingMember.GetMembersUnordered());
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            return RetargetMembers(_underlyingMember.GetMembers());
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return RetargetMembers(_underlyingMember.GetMembers(name));
        }

        public override ImmutableArray<Symbol> GetMembers(string name, string metadataName)
        {
            return RetargetMembers(_underlyingMember.GetMembers(name, metadataName));
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return RetargetTypeMembers(_underlyingMember.GetTypeMembersUnordered());
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return RetargetTypeMembers(_underlyingMember.GetTypeMembers());
        }

        private ImmutableArray<NamedTypeSymbol> RetargetTypeMembers(ImmutableArray<NamedTypeSymbol> underlyingMembers)
        {
            var builder = ArrayBuilder<NamedTypeSymbol>.GetInstance(underlyingMembers.Length);

            foreach (NamedTypeSymbol t in underlyingMembers)
            {
                // Skip explicitly declared local types.
                if (t.IsExplicitDefinitionOfNoPiaLocalType)
                {
                    continue;
                }

                Debug.Assert(t.PrimitiveTypeCode == PrimitiveTypeCode.NotPrimitive);
                builder.Add(this.RetargetingTranslator.Retarget(t, RetargetOptions.RetargetPrimitiveTypesByName));
            }

            return builder.ToImmutableAndFree();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return RetargetTypeMembers(_underlyingMember.GetTypeMembers(name));
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return RetargetTypeMembers(_underlyingMember.GetTypeMembers(name, metadataName));
        }

        private ImmutableArray<Symbol> RetargetMembers(ImmutableArray<Symbol> underlyingMembers)
        {
            var builder = ArrayBuilder<Symbol>.GetInstance(underlyingMembers.Length);

            foreach (Symbol s in underlyingMembers)
            {
                // Skip explicitly declared local types.
                if (s.Kind == LanguageSymbolKind.NamedType && ((NamedTypeSymbol)s).IsExplicitDefinitionOfNoPiaLocalType)
                {
                    continue;
                }

                builder.Add(this.RetargetingTranslator.Retarget(s));
            }

            return builder.ToImmutableAndFree();
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitMember(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMember(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitMember(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            throw new NotSupportedException();
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            throw new NotSupportedException();
        }

        internal sealed override LanguageCompilation DeclaringCompilation // perf, not correctness
        {
            get { return null; }
        }
    }
}
