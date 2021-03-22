// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.Emit;

namespace MetaDslx.CodeAnalysis.CSharp.Emit
{
    /// <summary>
    /// Represents a generic method of a generic type instantiation, closed over type parameters.
    /// e.g. 
    /// A{T}.M{S}()
    /// A.B{T}.C.M{S}()
    /// </summary>
    internal sealed class SpecializedGenericMethodInstanceReference : SpecializedMethodReference, Cci.IGenericMethodInstanceReference
    {
        private readonly SpecializedMethodReference _genericMethod;

        public SpecializedGenericMethodInstanceReference(MethodSymbol underlyingMethod)
            : base(underlyingMethod)
        {
            Debug.Assert(PEModuleBuilder.IsGenericType(underlyingMethod.ContainingType) && underlyingMethod.ContainingType.IsDefinition);
            _genericMethod = new SpecializedMethodReference(underlyingMethod);
        }

        IEnumerable<Cci.ITypeReference> Cci.IGenericMethodInstanceReference.GetGenericArguments(EmitContext context)
        {
            PEModuleBuilder moduleBeingBuilt = (PEModuleBuilder)context.Module;

            foreach (var arg in UnderlyingMethod.TypeArgumentsWithAnnotations)
            {
                Debug.Assert(arg.CustomModifiers.IsEmpty);
                yield return moduleBeingBuilt.Translate(arg.Type, syntaxNodeOpt: (CSharpSyntaxNode)context.SyntaxNodeOpt, diagnostics: context.Diagnostics);
            }
        }

        Cci.IMethodReference Cci.IGenericMethodInstanceReference.GetGenericMethod(EmitContext context)
        {
            return _genericMethod;
        }

        public override Cci.IGenericMethodInstanceReference AsGenericMethodInstanceReference
        {
            get
            {
                return this;
            }
        }

        public override void Dispatch(Cci.MetadataVisitor visitor)
        {
            visitor.Visit((Cci.IGenericMethodInstanceReference)this);
        }
    }
}
