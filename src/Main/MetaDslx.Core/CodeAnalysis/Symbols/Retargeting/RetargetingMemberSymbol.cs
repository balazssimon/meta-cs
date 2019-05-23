// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols.Wrapped;

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
