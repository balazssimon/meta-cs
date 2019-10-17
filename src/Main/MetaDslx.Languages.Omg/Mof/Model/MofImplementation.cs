using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Modeling;

namespace MetaDslx.Languages.Mof.Model.Internal
{
    class MofImplementation : MofImplementationBase
    {
        internal override void MofBuilderInstance(MofBuilderInstance _this)
        {
            MofFactory f = new MofFactory(_this.MModel);
            _this.Boolean = f.PrimitiveType();
            _this.Boolean.Name = "Boolean";
            _this.String = f.PrimitiveType();
            _this.String.Name = "String";
            _this.Integer = f.PrimitiveType();
            _this.Integer.Name = "Integer";
            _this.Real = f.PrimitiveType();
            _this.Real.Name = "Real";
            _this.UnlimitedNatural = f.PrimitiveType();
            _this.UnlimitedNatural.Name = "UnlimitedNatural";
        }

        public override long MultiplicityElement_ComputeProperty_Lower(MultiplicityElementBuilder _this)
        {
            return ((LiteralInteger)_this.LowerValue)?.Value ?? 0;
        }

        public override long MultiplicityElement_ComputeProperty_Upper(MultiplicityElementBuilder _this)
        {
            return ((LiteralUnlimitedNaturalBuilder)_this.UpperValue)?.Value ?? 1;
        }

        public override string NamedElement_ComputeProperty_QualifiedName(NamedElementBuilder _this)
        {
            return null;
        }

        public override NamespaceBuilder NamedElement_ComputeProperty_MemberNamespace(NamedElementBuilder _this)
        {
            return null;
        }

        public override IReadOnlyList<NamedElementBuilder> Namespace_ComputeProperty_Member(NamespaceBuilder _this)
        {
            return new List<NamedElementBuilder>();
        }

        public override IReadOnlyList<ClassBuilder> Class_ComputeProperty_SuperClass(ClassBuilder _this)
        {
            return new List<ClassBuilder>();
        }

        public override PropertyBuilder Property_ComputeProperty_Opposite(PropertyBuilder _this)
        {
            return null;
        }

        public override string Property_ComputeProperty_Default(PropertyBuilder _this)
        {
            return null;
        }

        public override bool Property_ComputeProperty_IsComposite(PropertyBuilder _this)
        {
            return false;
        }

        public override IReadOnlyList<ElementBuilder> Relationship_ComputeProperty_RelatedElement(RelationshipBuilder _this)
        {
            return new List<ElementBuilder>();
        }

        public override bool Operation_ComputeProperty_IsOrdered(OperationBuilder _this)
        {
            return false;
        }

        public override bool Operation_ComputeProperty_IsUnique(OperationBuilder _this)
        {
            return false;
        }

        public override long Operation_ComputeProperty_Lower(OperationBuilder _this)
        {
            return 0;
        }

        public override long Operation_ComputeProperty_Upper(OperationBuilder _this)
        {
            return 1;
        }
    }
}
