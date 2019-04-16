// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal class SourceFixedFieldSymbol : SourceMemberFieldSymbolFromDeclarator
    {
        private const int FixedSizeNotInitialized = -1;

        // In a fixed-size field declaration, stores the fixed size of the buffer
        private int _fixedSize = FixedSizeNotInitialized;

        internal SourceFixedFieldSymbol(
            SourceMemberContainerTypeSymbol containingType,
            CSharpSyntaxNode declarator,
            DeclarationModifiers modifiers,
            bool modifierErrors,
            DiagnosticBag diagnostics)
            : base(containingType, declarator, modifiers, modifierErrors, diagnostics)
        {
            // Checked in parser: a fixed field declaration requires a length in square brackets

            Debug.Assert(this.IsFixedSizeBuffer);
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            var compilation = this.DeclaringCompilation;
            var systemType = compilation.GetWellKnownType(WellKnownType.System_Type);
            var intType = compilation.GetSpecialType(SpecialType.System_Int32);
            var item1 = new TypedConstant(systemType, TypedConstantKind.Type, ((PointerTypeSymbol)this.Type).PointedAtType);
            var item2 = new TypedConstant(intType, TypedConstantKind.Primitive, this.FixedSize);
            AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(
                WellKnownMember.System_Runtime_CompilerServices_FixedBufferAttribute__ctor,
                ImmutableArray.Create<TypedConstant>(item1, item2)));
        }

        public sealed override int FixedSize
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal override NamedTypeSymbol FixedImplementationType(PEModuleBuilder emitModule)
        {
            return emitModule.SetFixedImplementationType(this);
        }
    }

    internal sealed class FixedFieldImplementationType : SynthesizedContainer
    {
        internal const string FixedElementFieldName = "FixedElementField";

        private readonly SourceMemberFieldSymbol _field;
        private readonly MethodSymbol _constructor;
        private readonly FieldSymbol _internalField;

        public FixedFieldImplementationType(SourceMemberFieldSymbol field)
            : base(GeneratedNames.MakeFixedFieldImplementationName(field.Name), typeParameters: ImmutableArray<TypeParameterSymbol>.Empty, typeMap: TypeMap.Empty)
        {
            _field = field;
            _constructor = new SynthesizedInstanceConstructor(this);
            _internalField = new SynthesizedFieldSymbol(this, ((PointerTypeSymbol)field.Type).PointedAtType, FixedElementFieldName, isPublic: true);
        }

        public override Symbol ContainingSymbol
        {
            get { return _field.ContainingType; }
        }

        public override TypeKind TypeKind
        {
            get { return TypeKind.Struct; }
        }

        internal override MethodSymbol Constructor
        {
            get { return _constructor; }
        }

        internal override TypeLayout Layout
        {
            get
            {
                int nElements = _field.FixedSize;
                var elementType = ((PointerTypeSymbol)_field.Type).PointedAtType;
                int elementSize = elementType.FixedBufferElementSizeInBytes();
                const int alignment = 0;
                int totalSize = nElements * elementSize;
                const LayoutKind layoutKind = LayoutKind.Sequential;
                return new TypeLayout(layoutKind, totalSize, alignment);
            }
        }

        internal override CharSet MarshallingCharSet
        {
            get
            {
                // We manually propagate the CharSet field of StructLayout attribute for fabricated structs implementing fixed buffers.
                // See void AttrBind::EmitStructLayoutAttributeCharSet(AttributeNode *attr) in native codebase.
                return _field.ContainingType.MarshallingCharSet;
            }
        }
        internal override FieldSymbol FixedElementField
        {
            get { return _internalField; }
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);
            var compilation = ContainingSymbol.DeclaringCompilation;
            AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(WellKnownMember.System_Runtime_CompilerServices_UnsafeValueTypeAttribute__ctor));
        }

        public override IEnumerable<string> MemberNames
        {
            get { return SpecializedCollections.SingletonEnumerable(FixedElementFieldName); }
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            return ImmutableArray.Create<Symbol>(_constructor, _internalField);
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return
                (name == _constructor.Name) ? ImmutableArray.Create<Symbol>(_constructor) :
                (name == FixedElementFieldName) ? ImmutableArray.Create<Symbol>(_internalField) :
                ImmutableArray<Symbol>.Empty;
        }

        public override Accessibility DeclaredAccessibility
        {
            get { return Accessibility.Public; }
        }

        internal override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics
            => ContainingAssembly.GetSpecialType(SpecialType.System_ValueType);
    }
}
