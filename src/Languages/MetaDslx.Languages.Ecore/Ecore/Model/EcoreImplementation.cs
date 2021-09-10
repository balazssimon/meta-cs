using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Modeling;

namespace MetaDslx.Languages.Ecore.Model.Internal
{
    internal class EcoreImplementation : EcoreImplementationBase
    {
        public override EDataTypeBuilder EAttribute_ComputeProperty_EAttributeType(EAttributeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override object EClassifier_ComputeProperty_DefaultValue(EClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override Type EClassifier_ComputeProperty_InstanceClass(EClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override int EClassifier_GetClassifierID(EClassifierBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool EClassifier_IsInstance(EClassifierBuilder _this, object @object)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAllAttributes(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllContainments(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EGenericTypeBuilder> EClass_ComputeProperty_EAllGenericSuperTypes(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EOperationBuilder> EClass_ComputeProperty_EAllOperations(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EAllReferences(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EStructuralFeatureBuilder> EClass_ComputeProperty_EAllStructuralFeatures(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EClassBuilder> EClass_ComputeProperty_EAllSuperTypes(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EAttributeBuilder> EClass_ComputeProperty_EAttributes(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EAttributeBuilder EClass_ComputeProperty_EIDAttribute(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EReferenceBuilder> EClass_ComputeProperty_EReferences(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EOperationBuilder EClass_GetEOperation(EClassBuilder _this, int operationID)
        {
            throw new NotImplementedException();
        }

        public override EStructuralFeatureBuilder EClass_GetEStructuralFeature(EClassBuilder _this, int featureID)
        {
            throw new NotImplementedException();
        }

        public override EStructuralFeatureBuilder EClass_GetEStructuralFeature(EClassBuilder _this, string featureName)
        {
            throw new NotImplementedException();
        }

        public override int EClass_GetFeatureCount(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override int EClass_GetFeatureID(EClassBuilder _this, EStructuralFeatureBuilder feature)
        {
            throw new NotImplementedException();
        }

        public override EGenericTypeBuilder EClass_GetFeatureType(EClassBuilder _this, EStructuralFeatureBuilder feature)
        {
            throw new NotImplementedException();
        }

        public override int EClass_GetOperationCount(EClassBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override int EClass_GetOperationID(EClassBuilder _this, EOperationBuilder operation)
        {
            throw new NotImplementedException();
        }

        public override EOperationBuilder EClass_GetOverride(EClassBuilder _this, EOperationBuilder operation)
        {
            throw new NotImplementedException();
        }

        public override bool EClass_IsSuperTypeOf(EClassBuilder _this, EClassBuilder someClass)
        {
            throw new NotImplementedException();
        }

        public override EEnumLiteralBuilder EEnum_GetEEnumLiteral(EEnumBuilder _this, string name)
        {
            throw new NotImplementedException();
        }

        public override EEnumLiteralBuilder EEnum_GetEEnumLiteral(EEnumBuilder _this, int value)
        {
            throw new NotImplementedException();
        }

        public override EEnumLiteralBuilder EEnum_GetEEnumLiteralByLiteral(EEnumBuilder _this, string literal)
        {
            throw new NotImplementedException();
        }

        public override string EFactory_ConvertToString(EFactoryBuilder _this, EDataTypeBuilder eDataType, object instanceValue)
        {
            throw new NotImplementedException();
        }

        public override EObjectBuilder EFactory_Create(EFactoryBuilder _this, EClassBuilder eClass)
        {
            throw new NotImplementedException();
        }

        public override object EFactory_CreateFromString(EFactoryBuilder _this, EDataTypeBuilder eDataType, string literalValue)
        {
            throw new NotImplementedException();
        }

        public override EClassifierBuilder EGenericType_ComputeProperty_ERawType(EGenericTypeBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool EGenericType_IsInstance(EGenericTypeBuilder _this, object @object)
        {
            throw new NotImplementedException();
        }

        public override EAnnotationBuilder EModelElement_GetEAnnotation(EModelElementBuilder _this, string source)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<EObjectBuilder> EObject_EAllContents(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EClassBuilder EObject_EClass(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EObjectBuilder EObject_EContainer(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EStructuralFeatureBuilder EObject_EContainingFeature(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EReferenceBuilder EObject_EContainmentFeature(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EObjectBuilder> EObject_EContents(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyList<EObjectBuilder> EObject_ECrossReferences(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override object EObject_EGet(EObjectBuilder _this, EStructuralFeatureBuilder feature)
        {
            throw new NotImplementedException();
        }

        public override object EObject_EGet(EObjectBuilder _this, EStructuralFeatureBuilder feature, bool resolve)
        {
            throw new NotImplementedException();
        }

        public override object EObject_EInvoke(EObjectBuilder _this, EOperationBuilder operation, IReadOnlyList<object> arguments)
        {
            throw new NotImplementedException();
        }

        public override bool EObject_EIsProxy(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool EObject_EIsSet(EObjectBuilder _this, EStructuralFeatureBuilder feature)
        {
            throw new NotImplementedException();
        }

        public override IModel EObject_EResource(EObjectBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override void EObject_ESet(EObjectBuilder _this, EStructuralFeatureBuilder feature, object newValue)
        {
            throw new NotImplementedException();
        }

        public override void EObject_EUnset(EObjectBuilder _this, EStructuralFeatureBuilder feature)
        {
            throw new NotImplementedException();
        }

        public override int EOperation_GetOperationID(EOperationBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool EOperation_IsOverrideOf(EOperationBuilder _this, EOperationBuilder someOperation)
        {
            throw new NotImplementedException();
        }

        public override EClassifierBuilder EPackage_GetEClassifier(EPackageBuilder _this, string name)
        {
            throw new NotImplementedException();
        }

        public override bool EReference_ComputeProperty_Container(EReferenceBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override EClassBuilder EReference_ComputeProperty_EReferenceType(EReferenceBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override object EStructuralFeature_ComputeProperty_DefaultValue(EStructuralFeatureBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override Type EStructuralFeature_GetContainerClass(EStructuralFeatureBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override int EStructuralFeature_GetFeatureID(EStructuralFeatureBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool ETypedElement_ComputeProperty_Many(ETypedElementBuilder _this)
        {
            throw new NotImplementedException();
        }

        public override bool ETypedElement_ComputeProperty_Required(ETypedElementBuilder _this)
        {
            throw new NotImplementedException();
        }
    }
}
