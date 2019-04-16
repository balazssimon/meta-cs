// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Binding;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents an interactive code entry point that is inserted into the compilation if there is not an existing one. 
    /// </summary>
    internal abstract class SynthesizedEntryPointSymbol : MethodSymbol
    {
        internal const string MainName = "<Main>";
        internal const string FactoryName = "<Factory>";

        private readonly NamedTypeSymbol _containingType;

        internal static SynthesizedEntryPointSymbol Create(SynthesizedInteractiveInitializerMethod initializerMethod, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private SynthesizedEntryPointSymbol(NamedTypeSymbol containingType)
        {
            Debug.Assert((object)containingType != null);

            _containingType = containingType;
        }

        internal override bool GenerateDebugInfo
        {
            get { return false; }
        }

        internal abstract BoundBlock CreateBody(DiagnosticBag diagnostics);

        public override Symbol ContainingSymbol
        {
            get { return _containingType; }
        }

        public abstract override string Name
        {
            get;
        }

        internal override bool HasSpecialName
        {
            get { return true; }
        }

        internal override System.Reflection.MethodImplAttributes ImplementationAttributes
        {
            get { return default(System.Reflection.MethodImplAttributes); }
        }

        internal override bool RequiresSecurityObject
        {
            get { return false; }
        }

        public override bool IsVararg
        {
            get { return false; }
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return ImmutableArray<TypeParameterSymbol>.Empty; }
        }

        public override Accessibility DeclaredAccessibility
        {
            get { return Accessibility.Private; }
        }

        public override ImmutableArray<Location> Locations
        {
            get { return ImmutableArray<Location>.Empty; }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return ImmutableArray<SyntaxReference>.Empty;
            }
        }

        public override RefKind RefKind
        {
            get { return RefKind.None; }
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers
        {
            get { return ImmutableArray<CustomModifier>.Empty; }
        }

        public override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotations
        {
            get { return ImmutableArray<TypeWithAnnotations>.Empty; }
        }

        public override Symbol AssociatedSymbol
        {
            get { return null; }
        }

        public override int Arity
        {
            get { return 0; }
        }

        public override bool ReturnsVoid
        {
            get { return ReturnType.SpecialType == SpecialType.System_Void; }
        }

        public override MethodKind MethodKind
        {
            get { return MethodKind.Ordinary; }
        }

        public override bool IsExtern
        {
            get { return false; }
        }

        public override bool IsSealed
        {
            get { return false; }
        }

        public override bool IsAbstract
        {
            get { return false; }
        }

        public override bool IsOverride
        {
            get { return false; }
        }

        public override bool IsVirtual
        {
            get { return false; }
        }

        public override bool IsStatic
        {
            get { return true; }
        }

        public override bool IsAsync
        {
            get { return false; }
        }

        public override bool HidesBaseMethodsByName
        {
            get { return false; }
        }

        public override bool IsExtensionMethod
        {
            get { return false; }
        }

        internal sealed override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return null; }
        }

        internal override Cci.CallingConvention CallingConvention
        {
            get { return 0; }
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get { return false; }
        }

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations
        {
            get { return ImmutableArray<MethodSymbol>.Empty; }
        }

        internal sealed override bool IsDeclaredReadOnly => false;

        internal sealed override bool IsMetadataNewSlot(bool ignoreInterfaceImplementationChanges = false)
        {
            return false;
        }

        internal sealed override bool IsMetadataVirtual(bool ignoreInterfaceImplementationChanges = false)
        {
            return false;
        }

        internal override bool IsMetadataFinal
        {
            get
            {
                return false;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get { return true; }
        }

        public override DllImportData GetDllImportData()
        {
            return null;
        }

        internal override MarshalPseudoCustomAttributeData ReturnValueMarshallingInformation
        {
            get { return null; }
        }

        internal override bool HasDeclarativeSecurity
        {
            get { return false; }
        }

        internal override IEnumerable<Cci.SecurityAttribute> GetSecurityInformation()
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal sealed override ImmutableArray<string> GetAppliedConditionalSymbols()
        {
            return ImmutableArray<string>.Empty;
        }

        internal override int CalculateLocalSyntaxOffset(int localPosition, SyntaxTree localTree)
        {
            throw ExceptionUtilities.Unreachable;
        }

        private static CSharpSyntaxNode DummySyntax()
        {
            return CSharpSyntaxNode.Dummy;
        }

        private static void ReportUseSiteDiagnostics(Symbol symbol, DiagnosticBag diagnostics)
        {
            var useSiteDiagnostic = symbol.GetUseSiteDiagnostic();
            if (useSiteDiagnostic != null)
            {
                ReportUseSiteDiagnostic(useSiteDiagnostic, diagnostics, NoLocation.Singleton);
            }
        }

        /// <summary> A synthesized entrypoint that forwards all calls to an async Main Method </summary>
        internal sealed class AsyncForwardEntryPoint : SynthesizedEntryPointSymbol
        {
            /// <summary> The user-defined asynchronous main method. </summary>
            private readonly CSharpSyntaxNode _userMainReturnTypeSyntax;

            private readonly BoundExpression _getAwaiterGetResultCall;

            private readonly ImmutableArray<ParameterSymbol> _parameters;

            internal AsyncForwardEntryPoint(CSharpCompilation compilation, NamedTypeSymbol containingType, MethodSymbol userMain) :
                base(containingType)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }

            internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
            {
                base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

                AddSynthesizedAttribute(ref attributes, this.DeclaringCompilation.SynthesizeDebuggerStepThroughAttribute());
            }

            public override string Name => MainName;

            public override ImmutableArray<ParameterSymbol> Parameters => _parameters;

            public override TypeWithAnnotations ReturnTypeWithAnnotations => throw new System.NotImplementedException("TODO:MetaDslx");

            internal override BoundBlock CreateBody(DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        private sealed class ScriptEntryPoint : SynthesizedEntryPointSymbol
        {
            private readonly TypeWithAnnotations _returnType;

            internal ScriptEntryPoint(NamedTypeSymbol containingType, TypeWithAnnotations returnType) :
                base(containingType)
            {
                Debug.Assert(containingType.IsScriptClass);
                Debug.Assert(returnType.SpecialType == SpecialType.System_Void);
                _returnType = returnType;
            }

            public override string Name => MainName;

            public override ImmutableArray<ParameterSymbol> Parameters => ImmutableArray<ParameterSymbol>.Empty;

            public override TypeWithAnnotations ReturnTypeWithAnnotations => _returnType;

            // private static void <Main>()
            // {
            //     var script = new Script();
            //     script.<Initialize>().GetAwaiter().GetResult();
            // }
            internal override BoundBlock CreateBody(DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        private sealed class SubmissionEntryPoint : SynthesizedEntryPointSymbol
        {
            private readonly ImmutableArray<ParameterSymbol> _parameters;
            private readonly TypeWithAnnotations _returnType;

            internal SubmissionEntryPoint(NamedTypeSymbol containingType, TypeWithAnnotations returnType, TypeSymbol submissionArrayType) :
                base(containingType)
            {
                Debug.Assert(containingType.IsSubmissionClass);
                Debug.Assert(returnType.SpecialType != SpecialType.System_Void);
                _parameters = ImmutableArray.Create(SynthesizedParameterSymbol.Create(this,
                    TypeWithAnnotations.Create(submissionArrayType), 0, RefKind.None, "submissionArray"));

                _returnType = returnType;
            }

            public override string Name
            {
                get { return FactoryName; }
            }

            public override ImmutableArray<ParameterSymbol> Parameters
            {
                get { return _parameters; }
            }

            public override TypeWithAnnotations ReturnTypeWithAnnotations => _returnType;

            // private static T <Factory>(object[] submissionArray) 
            // {
            //     var submission = new Submission#N(submissionArray);
            //     return submission.<Initialize>();
            // }
            internal override BoundBlock CreateBody(DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }
    }
}
