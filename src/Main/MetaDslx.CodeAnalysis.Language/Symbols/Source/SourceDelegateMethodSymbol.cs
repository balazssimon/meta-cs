// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Collections.Generic;
using System;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal abstract class SourceDelegateMethodSymbol : SourceMemberMethodSymbol
    {
        private ImmutableArray<ParameterSymbol> _parameters;
        private readonly TypeWithAnnotations _returnType;

        protected SourceDelegateMethodSymbol(
            SourceMemberContainerTypeSymbol delegateType,
            TypeWithAnnotations returnType,
            CSharpSyntaxNode syntax,
            MethodKind methodKind,
            DeclarationModifiers declarationModifiers)
            : base(delegateType, syntax.GetReference(), location: syntax.GetLocation())
        {
            _returnType = returnType;
            this.MakeFlags(methodKind, declarationModifiers, _returnType.SpecialType == SpecialType.System_Void, isExtensionMethod: false);
        }

        protected void InitializeParameters(ImmutableArray<ParameterSymbol> parameters)
        {
            Debug.Assert(_parameters.IsDefault);
            _parameters = parameters;
        }

        internal static void AddDelegateMembers(
            SourceMemberContainerTypeSymbol delegateType,
            ArrayBuilder<Symbol> symbols,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected override void MethodChecks(DiagnosticBag diagnostics)
        {
            // TODO: move more functionality into here, making these symbols more lazy
        }

        public sealed override bool IsVararg
        {
            get
            {
                return false;
            }
        }

        public sealed override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get
            {
                return ImmutableArray<TypeParameterSymbol>.Empty;
            }
        }

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
            => ImmutableArray<TypeParameterConstraintClause>.Empty;

        public sealed override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                return _returnType;
            }
        }

        public sealed override bool IsImplicitlyDeclared
        {
            get
            {
                return true;
            }
        }

        internal override bool IsExpressionBodied
        {
            get { return false; }
        }

        internal override bool GenerateDebugInfo
        {
            get { return false; }
        }

        protected sealed override IAttributeTargetSymbol AttributeOwner
        {
            get
            {
                return (SourceNamedTypeSymbol)ContainingSymbol;
            }
        }

        internal sealed override System.Reflection.MethodImplAttributes ImplementationAttributes
        {
            get { return System.Reflection.MethodImplAttributes.Runtime; }
        }

        internal sealed override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            // TODO: This implementation looks strange. It might make sense for the Invoke method, but
            //       not for constructor and other methods.
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override System.AttributeTargets GetAttributeTarget()
        {
            return System.AttributeTargets.Delegate;
        }

        private sealed class Constructor : SourceDelegateMethodSymbol
        {
            internal Constructor(
                SourceMemberContainerTypeSymbol delegateType,
                TypeWithAnnotations voidType,
                TypeWithAnnotations objectType,
                TypeWithAnnotations intPtrType,
                CSharpSyntaxNode syntax)
                : base(delegateType, voidType, syntax, MethodKind.Constructor, DeclarationModifiers.Public)
            {
                InitializeParameters(ImmutableArray.Create<ParameterSymbol>(
                    SynthesizedParameterSymbol.Create(this, objectType, 0, RefKind.None, "object"),
                    SynthesizedParameterSymbol.Create(this, intPtrType, 1, RefKind.None, "method")));
            }

            public override string Name
            {
                get { return WellKnownMemberNames.InstanceConstructorName; }
            }

            public override RefKind RefKind
            {
                get { return RefKind.None; }
            }

            internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetReturnTypeAttributeDeclarations()
            {
                // Constructors don't have return type attributes
                return OneOrMany.Create(default(SyntaxList<CSharpSyntaxNode>));
            }

            internal override LexicalSortKey GetLexicalSortKey()
            {
                // associate "Invoke and .ctor" with whole delegate declaration for the sorting purposes
                // other methods will be associated with delegate's identifier
                // we want this just to keep the order of synthesized methods the same as in Dev12
                // Dev12 order is not strictly alphabetical - .ctor and Invoke go before other members.
                // there are no real reasons for emitting the members in one order or another, 
                // so we will keep them the same.
                return new LexicalSortKey(this.syntaxReferenceOpt.GetLocation(), this.DeclaringCompilation);
            }
        }

        private sealed class InvokeMethod : SourceDelegateMethodSymbol
        {
            private readonly RefKind _refKind;
            private readonly ImmutableArray<CustomModifier> _refCustomModifiers;

            internal InvokeMethod(
                SourceMemberContainerTypeSymbol delegateType,
                RefKind refKind,
                TypeWithAnnotations returnType,
                CSharpSyntaxNode syntax,
                Binder binder,
                DiagnosticBag diagnostics)
                : base(delegateType, returnType, syntax, MethodKind.DelegateInvoke, DeclarationModifiers.Virtual | DeclarationModifiers.Public)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }

            public override string Name
            {
                get { return WellKnownMemberNames.DelegateInvokeName; }
            }

            public override RefKind RefKind
            {
                get { return _refKind; }
            }

            internal override LexicalSortKey GetLexicalSortKey()
            {
                // associate "Invoke and .ctor" with whole delegate declaration for the sorting purposes
                // other methods will be associated with delegate's identifier
                // we want this just to keep the order of synthesized methods the same as in Dev12
                // Dev12 order is not strictly alphabetical - .ctor and Invoke go before other members.
                // there are no real reasons for emitting the members in one order or another, 
                // so we will keep them the same.
                return new LexicalSortKey(this.syntaxReferenceOpt.GetLocation(), this.DeclaringCompilation);
            }

            internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }

            public override ImmutableArray<CustomModifier> RefCustomModifiers => _refCustomModifiers;
        }

        private sealed class BeginInvokeMethod : SourceDelegateMethodSymbol
        {
            internal BeginInvokeMethod(
                InvokeMethod invoke,
                TypeWithAnnotations iAsyncResultType,
                TypeWithAnnotations objectType,
                TypeWithAnnotations asyncCallbackType,
                CSharpSyntaxNode syntax)
                : base((SourceNamedTypeSymbol)invoke.ContainingType, iAsyncResultType, syntax, MethodKind.Ordinary, DeclarationModifiers.Virtual | DeclarationModifiers.Public)
            {
                var parameters = ArrayBuilder<ParameterSymbol>.GetInstance();
                foreach (SourceParameterSymbol p in invoke.Parameters)
                {
                    var synthesizedParam = new SourceClonedParameterSymbol(originalParam: p, newOwner: this, newOrdinal: p.Ordinal, suppressOptional: true);
                    parameters.Add(synthesizedParam);
                }

                int paramCount = invoke.ParameterCount;
                parameters.Add(SynthesizedParameterSymbol.Create(this, asyncCallbackType, paramCount, RefKind.None, GetUniqueParameterName(parameters, "callback")));
                parameters.Add(SynthesizedParameterSymbol.Create(this, objectType, paramCount + 1, RefKind.None, GetUniqueParameterName(parameters, "object")));

                InitializeParameters(parameters.ToImmutableAndFree());
            }

            public override string Name
            {
                get { return WellKnownMemberNames.DelegateBeginInvokeName; }
            }

            public override RefKind RefKind
            {
                get { return RefKind.None; }
            }

            internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetReturnTypeAttributeDeclarations()
            {
                // BeginInvoke method doesn't have return type attributes
                // because it doesn't inherit Delegate declaration's return type.
                // It has a special return type: SpecialType.System.IAsyncResult.
                return OneOrMany.Create(default(SyntaxList<CSharpSyntaxNode>));
            }
        }

        private sealed class EndInvokeMethod : SourceDelegateMethodSymbol
        {
            private readonly InvokeMethod _invoke;

            internal EndInvokeMethod(
                InvokeMethod invoke,
                TypeWithAnnotations iAsyncResultType,
                CSharpSyntaxNode syntax)
                : base((SourceNamedTypeSymbol)invoke.ContainingType, invoke.ReturnTypeWithAnnotations, syntax, MethodKind.Ordinary, DeclarationModifiers.Virtual | DeclarationModifiers.Public)
            {
                _invoke = invoke;

                var parameters = ArrayBuilder<ParameterSymbol>.GetInstance();
                int ordinal = 0;

                foreach (SourceParameterSymbol p in invoke.Parameters)
                {
                    if (p.RefKind != RefKind.None)
                    {
                        var synthesizedParam = new SourceClonedParameterSymbol(originalParam: p, newOwner: this, newOrdinal: ordinal++, suppressOptional: true);
                        parameters.Add(synthesizedParam);
                    }
                }

                parameters.Add(SynthesizedParameterSymbol.Create(this, iAsyncResultType, ordinal++, RefKind.None, GetUniqueParameterName(parameters, "result")));
                InitializeParameters(parameters.ToImmutableAndFree());
            }

            protected override SourceMemberMethodSymbol BoundAttributesSource => _invoke;

            public override string Name => WellKnownMemberNames.DelegateEndInvokeName;

            public override RefKind RefKind => _invoke.RefKind;

            public override ImmutableArray<CustomModifier> RefCustomModifiers => _invoke.RefCustomModifiers;
        }

        private static string GetUniqueParameterName(ArrayBuilder<ParameterSymbol> currentParameters, string name)
        {
            while (!IsUnique(currentParameters, name))
            {
                name = "__" + name;
            }

            return name;
        }

        private static bool IsUnique(ArrayBuilder<ParameterSymbol> currentParameters, string name)
        {
            foreach (var p in currentParameters)
            {
                if (string.CompareOrdinal(p.Name, name) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
