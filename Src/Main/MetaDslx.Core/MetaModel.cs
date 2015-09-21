using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public static class MetaDescriptor
    {
        static MetaDescriptor()
        {
            MetaAnnotatedElement.StaticInit();
            MetaNamedElement.StaticInit();
            MetaTypedElement.StaticInit();
            MetaType.StaticInit();
            MetaAnnotation.StaticInit();
            MetaAnnotationProperty.StaticInit();
            MetaNamespace.StaticInit();
            MetaDeclaration.StaticInit();
            MetaModel.StaticInit();
            MetaCollectionType.StaticInit();
            MetaNullableType.StaticInit();
            MetaPrimitiveType.StaticInit();
            MetaEnum.StaticInit();
            MetaEnumLiteral.StaticInit();
            MetaClass.StaticInit();
            MetaFunctionType.StaticInit();
            MetaFunction.StaticInit();
            MetaOperation.StaticInit();
            MetaConstant.StaticInit();
            MetaConstructor.StaticInit();
            MetaParameter.StaticInit();
            MetaProperty.StaticInit();
            MetaPropertyInitializer.StaticInit();
            MetaSynthetizedPropertyInitializer.StaticInit();
            MetaInheritedPropertyInitializer.StaticInit();
            MetaExpression.StaticInit();
            MetaBracketExpression.StaticInit();
            MetaBoundExpression.StaticInit();
            MetaThisExpression.StaticInit();
            MetaNullExpression.StaticInit();
            MetaTypeConversionExpression.StaticInit();
            MetaTypeAsExpression.StaticInit();
            MetaTypeCastExpression.StaticInit();
            MetaTypeCheckExpression.StaticInit();
            MetaTypeOfExpression.StaticInit();
            MetaConditionalExpression.StaticInit();
            MetaConstantExpression.StaticInit();
            MetaIdentifierExpression.StaticInit();
            MetaMemberAccessExpression.StaticInit();
            MetaFunctionCallExpression.StaticInit();
            MetaIndexerExpression.StaticInit();
            MetaNewExpression.StaticInit();
            MetaNewPropertyInitializer.StaticInit();
            MetaNewCollectionExpression.StaticInit();
            MetaOperatorExpression.StaticInit();
            MetaUnaryExpression.StaticInit();
            MetaUnaryPlusExpression.StaticInit();
            MetaNegateExpression.StaticInit();
            MetaOnesComplementExpression.StaticInit();
            MetaNotExpression.StaticInit();
            MetaUnaryAssignExpression.StaticInit();
            MetaPostIncrementAssignExpression.StaticInit();
            MetaPostDecrementAssignExpression.StaticInit();
            MetaPreIncrementAssignExpression.StaticInit();
            MetaPreDecrementAssignExpression.StaticInit();
            MetaBinaryExpression.StaticInit();
            MetaBinaryArithmeticExpression.StaticInit();
            MetaMultiplyExpression.StaticInit();
            MetaDivideExpression.StaticInit();
            MetaModuloExpression.StaticInit();
            MetaAddExpression.StaticInit();
            MetaSubtractExpression.StaticInit();
            MetaLeftShiftExpression.StaticInit();
            MetaRightShiftExpression.StaticInit();
            MetaBinaryComparisonExpression.StaticInit();
            MetaLessThanExpression.StaticInit();
            MetaLessThanOrEqualExpression.StaticInit();
            MetaGreaterThanExpression.StaticInit();
            MetaGreaterThanOrEqualExpression.StaticInit();
            MetaEqualExpression.StaticInit();
            MetaNotEqualExpression.StaticInit();
            MetaBinaryLogicalExpression.StaticInit();
            MetaAndExpression.StaticInit();
            MetaOrExpression.StaticInit();
            MetaExclusiveOrExpression.StaticInit();
            MetaAndAlsoExpression.StaticInit();
            MetaOrElseExpression.StaticInit();
            MetaNullCoalescingExpression.StaticInit();
            MetaAssignmentExpression.StaticInit();
            MetaAssignExpression.StaticInit();
            MetaArithmeticAssignmentExpression.StaticInit();
            MetaMultiplyAssignExpression.StaticInit();
            MetaDivideAssignExpression.StaticInit();
            MetaModuloAssignExpression.StaticInit();
            MetaAddAssignExpression.StaticInit();
            MetaSubtractAssignExpression.StaticInit();
            MetaLeftShiftAssignExpression.StaticInit();
            MetaRightShiftAssignExpression.StaticInit();
            MetaLogicalAssignmentExpression.StaticInit();
            MetaAndAssignExpression.StaticInit();
            MetaExclusiveOrAssignExpression.StaticInit();
            MetaOrAssignExpression.StaticInit();
        }
    
        internal static void StaticInit()
        {
        }
    
    	public const string Uri = "http://metadslx.core/1.0";
    
        public static class Constants
        {
            static Constants()
            {
                Object = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "object"))});
                String = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "string"))});
                Int = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "int"))});
                Long = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "long"))});
                Float = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "float"))});
                Double = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "double"))});
                Byte = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "byte"))});
                Bool = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "bool"))});
                Void = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "void"))});
                None = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "*none*"))});
                Any = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "*any*"))});
                Error = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "*error*"))});
                ModelObject = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaPrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ModelObject"))});
                ModelObjectList = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject))});
    
                TypeOf = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                TypeOf.Name = "typeof";
                ((ModelObject)TypeOf).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                global::MetaDslx.Core.MetaParameter tmp1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp1.Name = "type";
                ((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Object));
                TypeOf.Parameters.Add(tmp1);
                GetValueType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                GetValueType.Name = "get_type";
                ((ModelObject)GetValueType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                global::MetaDslx.Core.MetaParameter tmp2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp2.Name = "value";
                ((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Object));
                GetValueType.Parameters.Add(tmp2);
                GetReturnType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                GetReturnType.Name = "get_return_type";
                ((ModelObject)GetReturnType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                global::MetaDslx.Core.MetaParameter tmp3 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp3.Name = "value";
                ((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Object));
                GetReturnType.Parameters.Add(tmp3);
                CurrentType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                CurrentType.Name = "current_type";
                ((ModelObject)CurrentType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                global::MetaDslx.Core.MetaParameter tmp4 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp4.Name = "symbol";
                ((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                CurrentType.Parameters.Add(tmp4);
                TypeCheck = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                TypeCheck.Name = "type_check";
                ((ModelObject)TypeCheck).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Bool));
                global::MetaDslx.Core.MetaParameter tmp5 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp5.Name = "symbol";
                ((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                TypeCheck.Parameters.Add(tmp5);
                Balance = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Balance.Name = "balance";
                ((ModelObject)Balance).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                global::MetaDslx.Core.MetaParameter tmp6 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp6.Name = "left";
                ((ModelObject)tmp6).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                Balance.Parameters.Add(tmp6);
                global::MetaDslx.Core.MetaParameter tmp7 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp7.Name = "right";
                ((ModelObject)tmp7).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                Balance.Parameters.Add(tmp7);
                Resolve1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Resolve1.Name = "resolve";
                global::MetaDslx.Core.MetaCollectionType tmp8 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp8.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp8).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)Resolve1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp8));
                global::MetaDslx.Core.MetaParameter tmp9 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp9.Name = "name";
                ((ModelObject)tmp9).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                Resolve1.Parameters.Add(tmp9);
                Resolve2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Resolve2.Name = "resolve";
                global::MetaDslx.Core.MetaCollectionType tmp10 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp10.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp10).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)Resolve2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp10));
                global::MetaDslx.Core.MetaParameter tmp11 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp11.Name = "context";
                ((ModelObject)tmp11).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                Resolve2.Parameters.Add(tmp11);
                global::MetaDslx.Core.MetaParameter tmp12 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp12.Name = "name";
                ((ModelObject)tmp12).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                Resolve2.Parameters.Add(tmp12);
                ResolveType1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                ResolveType1.Name = "resolve_type";
                global::MetaDslx.Core.MetaCollectionType tmp13 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp13.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp13).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)ResolveType1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp13));
                global::MetaDslx.Core.MetaParameter tmp14 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp14.Name = "name";
                ((ModelObject)tmp14).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                ResolveType1.Parameters.Add(tmp14);
                ResolveType2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                ResolveType2.Name = "resolve_type";
                global::MetaDslx.Core.MetaCollectionType tmp15 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp15.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp15).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)ResolveType2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp15));
                global::MetaDslx.Core.MetaParameter tmp16 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp16.Name = "context";
                ((ModelObject)tmp16).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ResolveType2.Parameters.Add(tmp16);
                global::MetaDslx.Core.MetaParameter tmp17 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp17.Name = "name";
                ((ModelObject)tmp17).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                ResolveType2.Parameters.Add(tmp17);
                ResolveName1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                ResolveName1.Name = "resolve_name";
                global::MetaDslx.Core.MetaCollectionType tmp18 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp18.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp18).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)ResolveName1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp18));
                global::MetaDslx.Core.MetaParameter tmp19 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp19.Name = "name";
                ((ModelObject)tmp19).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                ResolveName1.Parameters.Add(tmp19);
                ResolveName2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                ResolveName2.Name = "resolve_name";
                global::MetaDslx.Core.MetaCollectionType tmp20 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp20.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp20).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)ResolveName2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp20));
                global::MetaDslx.Core.MetaParameter tmp21 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp21.Name = "context";
                ((ModelObject)tmp21).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ResolveName2.Parameters.Add(tmp21);
                global::MetaDslx.Core.MetaParameter tmp22 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp22.Name = "name";
                ((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                ResolveName2.Parameters.Add(tmp22);
                Bind1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Bind1.Name = "bind";
                ((ModelObject)Bind1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                global::MetaDslx.Core.MetaParameter tmp23 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp23.Name = "symbol";
                ((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                Bind1.Parameters.Add(tmp23);
                Bind2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Bind2.Name = "bind";
                ((ModelObject)Bind2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                global::MetaDslx.Core.MetaParameter tmp24 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp24.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp25 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp25.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp25));
                Bind2.Parameters.Add(tmp24);
                Bind3 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Bind3.Name = "bind";
                ((ModelObject)Bind3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                global::MetaDslx.Core.MetaParameter tmp26 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp26.Name = "context";
                ((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                Bind3.Parameters.Add(tmp26);
                global::MetaDslx.Core.MetaParameter tmp27 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp27.Name = "symbol";
                ((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                Bind3.Parameters.Add(tmp27);
                Bind4 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                Bind4.Name = "bind";
                ((ModelObject)Bind4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                global::MetaDslx.Core.MetaParameter tmp28 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp28.Name = "context";
                ((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                Bind4.Parameters.Add(tmp28);
                global::MetaDslx.Core.MetaParameter tmp29 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp29.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp30 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp30.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp30).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp30));
                Bind4.Parameters.Add(tmp29);
                SelectOfType1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                SelectOfType1.Name = "select_of_type";
                global::MetaDslx.Core.MetaCollectionType tmp31 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp31.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp31).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)SelectOfType1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp31));
                global::MetaDslx.Core.MetaParameter tmp32 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp32.Name = "symbol";
                ((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                SelectOfType1.Parameters.Add(tmp32);
                global::MetaDslx.Core.MetaParameter tmp33 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp33.Name = "type";
                ((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                SelectOfType1.Parameters.Add(tmp33);
                SelectOfType2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                SelectOfType2.Name = "select_of_type";
                global::MetaDslx.Core.MetaCollectionType tmp34 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp34.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)SelectOfType2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp34));
                global::MetaDslx.Core.MetaParameter tmp35 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp35.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp36 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp36.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp36));
                SelectOfType2.Parameters.Add(tmp35);
                global::MetaDslx.Core.MetaParameter tmp37 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp37.Name = "type";
                ((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
                SelectOfType2.Parameters.Add(tmp37);
                SelectOfName1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                SelectOfName1.Name = "select_of_name";
                global::MetaDslx.Core.MetaCollectionType tmp38 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp38.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)SelectOfName1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp38));
                global::MetaDslx.Core.MetaParameter tmp39 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp39.Name = "symbol";
                ((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                SelectOfName1.Parameters.Add(tmp39);
                global::MetaDslx.Core.MetaParameter tmp40 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp40.Name = "name";
                ((ModelObject)tmp40).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                SelectOfName1.Parameters.Add(tmp40);
                SelectOfName2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaFunction();
                SelectOfName2.Name = "select_of_name";
                global::MetaDslx.Core.MetaCollectionType tmp41 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp41.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp41).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)SelectOfName2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, new Lazy<object>(() => tmp41));
                global::MetaDslx.Core.MetaParameter tmp42 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp42.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp43 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
                tmp43.Kind = MetaCollectionKind.List;
                ((ModelObject)tmp43).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.ModelObject));
                ((ModelObject)tmp42).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp43));
                SelectOfName2.Parameters.Add(tmp42);
                global::MetaDslx.Core.MetaParameter tmp44 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaParameter();
                tmp44.Name = "name";
                ((ModelObject)tmp44).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.String));
                SelectOfName2.Parameters.Add(tmp44);
            }
    
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Object;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType String;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Int;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Long;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Float;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Double;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Byte;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Bool;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Void;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType None;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Any;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType Error;
            public static readonly global::MetaDslx.Core.MetaPrimitiveType ModelObject;
            public static readonly global::MetaDslx.Core.MetaCollectionType ModelObjectList;
    
            public static readonly global::MetaDslx.Core.MetaFunction TypeOf;
            public static readonly global::MetaDslx.Core.MetaFunction GetValueType;
            public static readonly global::MetaDslx.Core.MetaFunction GetReturnType;
            public static readonly global::MetaDslx.Core.MetaFunction CurrentType;
            public static readonly global::MetaDslx.Core.MetaFunction TypeCheck;
            public static readonly global::MetaDslx.Core.MetaFunction Balance;
            public static readonly global::MetaDslx.Core.MetaFunction Resolve1;
            public static readonly global::MetaDslx.Core.MetaFunction Resolve2;
            public static readonly global::MetaDslx.Core.MetaFunction ResolveType1;
            public static readonly global::MetaDslx.Core.MetaFunction ResolveType2;
            public static readonly global::MetaDslx.Core.MetaFunction ResolveName1;
            public static readonly global::MetaDslx.Core.MetaFunction ResolveName2;
            public static readonly global::MetaDslx.Core.MetaFunction Bind1;
            public static readonly global::MetaDslx.Core.MetaFunction Bind2;
            public static readonly global::MetaDslx.Core.MetaFunction Bind3;
            public static readonly global::MetaDslx.Core.MetaFunction Bind4;
            public static readonly global::MetaDslx.Core.MetaFunction SelectOfType1;
            public static readonly global::MetaDslx.Core.MetaFunction SelectOfType2;
            public static readonly global::MetaDslx.Core.MetaFunction SelectOfName1;
            public static readonly global::MetaDslx.Core.MetaFunction SelectOfName2;
        }
    
        
        public static class MetaAnnotatedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotatedElement()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAnnotatedElement; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty AnnotationsProperty =
                ModelProperty.Register("Annotations", typeof(IList<global::MetaDslx.Core.MetaAnnotation>), typeof(global::MetaDslx.Core.MetaAnnotatedElement), typeof(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaAnnotatedElement_AnnotationsProperty));
            
        }
        
        public static class MetaNamedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNamedElement()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNamedElement; }
            }
        
            [Name]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaNamedElement), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamedElement_NameProperty));
            
        }
        
        public static class MetaTypedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypedElement()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypedElement; }
            }
        
            [Type]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypedElement), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypedElement_TypeProperty));
            
        }
        
        public static class MetaType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaType()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaType; }
            }
        
        }
        
        public static class MetaAnnotation
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotation()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAnnotation; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaAnnotationProperty>), typeof(global::MetaDslx.Core.MetaAnnotation), typeof(global::MetaDslx.Core.MetaDescriptor.MetaAnnotation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaAnnotation_PropertiesProperty));
            
        }
        
        public static class MetaAnnotationProperty
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotationProperty()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAnnotationProperty; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaAnnotationProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaAnnotationProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaAnnotationProperty_ValueProperty));
            
        }
        
        public static class MetaNamespace
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNamespace()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNamespace; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), "Namespaces")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamespace_ParentProperty));
            
            [ImportedScope]
            public static readonly ModelProperty UsingsProperty =
                ModelProperty.Register("Usings", typeof(IList<global::MetaDslx.Core.MetaNamespace>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamespace_UsingsProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaModel), "Namespace")]
            public static readonly ModelProperty MetaModelProperty =
                ModelProperty.Register("MetaModel", typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamespace_MetaModelProperty));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), "Parent")]
            public static readonly ModelProperty NamespacesProperty =
                ModelProperty.Register("Namespaces", typeof(IList<global::MetaDslx.Core.MetaNamespace>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamespace_NamespacesProperty));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration), "Namespace")]
            public static readonly ModelProperty DeclarationsProperty =
                ModelProperty.Register("Declarations", typeof(IList<global::MetaDslx.Core.MetaDeclaration>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNamespace_DeclarationsProperty));
            
        }
        
        public static class MetaDeclaration
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDeclaration()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaDeclaration; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), "Declarations")]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDeclaration), typeof(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaDeclaration_NamespaceProperty));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty ModelProperty =
                ModelProperty.Register("Model", typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.MetaDeclaration), typeof(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaDeclaration_ModelProperty));
            
        }
        
        public static class MetaModel
        {
            internal static void StaticInit()
            {
            }
        
            static MetaModel()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaModel; }
            }
        
            
            public static readonly ModelProperty UriProperty =
                ModelProperty.Register("Uri", typeof(string), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.MetaDescriptor.MetaModel), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaModel_UriProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNamespace), "MetaModel")]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.MetaDescriptor.MetaModel), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaModel_NamespaceProperty));
            
        }
        
        public static class MetaCollectionType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaCollectionType()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaCollectionType; }
            }
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaCollectionKind), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaCollectionType_KindProperty));
            
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaCollectionType_InnerTypeProperty));
            
        }
        
        public static class MetaNullableType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullableType()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNullableType; }
            }
        
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaNullableType), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNullableType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNullableType_InnerTypeProperty));
            
        }
        
        public static class MetaPrimitiveType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPrimitiveType()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPrimitiveType; }
            }
        
        }
        
        public static class MetaEnum
        {
            internal static void StaticInit()
            {
            }
        
            static MetaEnum()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaEnum; }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral), "Enum")]
            public static readonly ModelProperty EnumLiteralsProperty =
                ModelProperty.Register("EnumLiterals", typeof(IList<global::MetaDslx.Core.MetaEnumLiteral>), typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnum), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaEnum_EnumLiteralsProperty));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaOperation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnum), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaEnum_OperationsProperty));
            
        }
        
        public static class MetaEnumLiteral
        {
            internal static void StaticInit()
            {
            }
        
            static MetaEnumLiteral()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaEnumLiteral; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnum), "EnumLiterals")]
            public static readonly ModelProperty EnumProperty =
                ModelProperty.Register("Enum", typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.MetaEnumLiteral), typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaEnumLiteral_EnumProperty));
            
        }
        
        public static class MetaClass
        {
            internal static void StaticInit()
            {
            }
        
            static MetaClass()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaClass; }
            }
        
            
            public static readonly ModelProperty IsAbstractProperty =
                ModelProperty.Register("IsAbstract", typeof(bool), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaClass_IsAbstractProperty));
            
            [InheritedScope]
            public static readonly ModelProperty SuperClassesProperty =
                ModelProperty.Register("SuperClasses", typeof(IList<global::MetaDslx.Core.MetaClass>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaClass_SuperClassesProperty));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "Class")]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaClass_PropertiesProperty));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaOperation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaClass_OperationsProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstructor), "Parent")]
            public static readonly ModelProperty ConstructorProperty =
                ModelProperty.Register("Constructor", typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaClass_ConstructorProperty));
            
        }
        
        public static class MetaFunctionType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionType()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaFunctionType; }
            }
        
            
            public static readonly ModelProperty ParameterTypesProperty =
                ModelProperty.Register("ParameterTypes", typeof(IList<global::MetaDslx.Core.MetaType>), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunctionType_ParameterTypesProperty));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunctionType_ReturnTypeProperty));
            
        }
        
        public static class MetaFunction
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunction()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaFunction; }
            }
        
            [Type]
            [ReadonlyAttribute]
            [RedefinesAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement), "Type")]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunction), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunction_TypeProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaParameter), "Function")]
            public static readonly ModelProperty ParametersProperty =
                ModelProperty.Register("Parameters", typeof(IList<global::MetaDslx.Core.MetaParameter>), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunction), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunction_ParametersProperty));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunction), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunction_ReturnTypeProperty));
            
        }
        
        public static class MetaOperation
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOperation()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOperation; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), "Operations")]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaEnum), "Operations")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.MetaDescriptor.MetaOperation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaOperation_ParentProperty));
            
        }
        
        public static class MetaConstant
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConstant()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaConstant; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConstant), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstant), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConstant_ValueProperty));
            
        }
        
        public static class MetaConstructor
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConstructor()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaConstructor; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), "Constructor")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstructor), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConstructor_ParentProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), "Constructor")]
            public static readonly ModelProperty InitializersProperty =
                ModelProperty.Register("Initializers", typeof(IList<global::MetaDslx.Core.MetaPropertyInitializer>), typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstructor), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConstructor_InitializersProperty));
            
        }
        
        public static class MetaParameter
        {
            internal static void StaticInit()
            {
            }
        
            static MetaParameter()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaParameter; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunction), "Parameters")]
            public static readonly ModelProperty FunctionProperty =
                ModelProperty.Register("Function", typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.MetaParameter), typeof(global::MetaDslx.Core.MetaDescriptor.MetaParameter), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaParameter_FunctionProperty));
            
        }
        
        public static class MetaProperty
        {
            internal static void StaticInit()
            {
            }
        
            static MetaProperty()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaProperty; }
            }
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaPropertyKind), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_KindProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaClass), "Properties")]
            public static readonly ModelProperty ClassProperty =
                ModelProperty.Register("Class", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_ClassProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "OppositeProperties")]
            public static readonly ModelProperty OppositePropertiesProperty =
                ModelProperty.Register("OppositeProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_OppositePropertiesProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "SubsettingProperties")]
            public static readonly ModelProperty SubsettedPropertiesProperty =
                ModelProperty.Register("SubsettedProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_SubsettedPropertiesProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "SubsettedProperties")]
            public static readonly ModelProperty SubsettingPropertiesProperty =
                ModelProperty.Register("SubsettingProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_SubsettingPropertiesProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "RedefiningProperties")]
            public static readonly ModelProperty RedefinedPropertiesProperty =
                ModelProperty.Register("RedefinedProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_RedefinedPropertiesProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), "RedefinedProperties")]
            public static readonly ModelProperty RedefiningPropertiesProperty =
                ModelProperty.Register("RedefiningProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaDescriptor.MetaProperty), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaProperty_RedefiningPropertiesProperty));
            
        }
        
        public static class MetaPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPropertyInitializer()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstructor), "Initializers")]
            public static readonly ModelProperty ConstructorProperty =
                ModelProperty.Register("Constructor", typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer_ConstructorProperty));
            
            
            public static readonly ModelProperty PropertyNameProperty =
                ModelProperty.Register("PropertyName", typeof(string), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer_PropertyNameProperty));
            
            
            public static readonly ModelProperty PropertyContextProperty =
                ModelProperty.Register("PropertyContext", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer_PropertyContextProperty));
            
            
            public static readonly ModelProperty PropertyProperty =
                ModelProperty.Register("Property", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer_PropertyProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaPropertyInitializer_ValueProperty));
            
        }
        
        public static class MetaSynthetizedPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSynthetizedPropertyInitializer()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaSynthetizedPropertyInitializer; }
            }
        
        }
        
        public static class MetaInheritedPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaInheritedPropertyInitializer()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaInheritedPropertyInitializer; }
            }
        
            
            public static readonly ModelProperty ObjectNameProperty =
                ModelProperty.Register("ObjectName", typeof(string), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaInheritedPropertyInitializer_ObjectNameProperty));
            
            
            public static readonly ModelProperty ObjectProperty =
                ModelProperty.Register("Object", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaInheritedPropertyInitializer_ObjectProperty));
            
        }
        
        public static class MetaExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaExpression; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NoTypeErrorProperty =
                ModelProperty.Register("NoTypeError", typeof(bool), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaExpression_NoTypeErrorProperty));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty ExpectedTypeProperty =
                ModelProperty.Register("ExpectedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaExpression_ExpectedTypeProperty));
            
        }
        
        public static class MetaBracketExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBracketExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBracketExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBracketExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBracketExpression_ExpressionProperty));
            
        }
        
        public static class MetaBoundExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBoundExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBoundExpression; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty UniqueDefinitionProperty =
                ModelProperty.Register("UniqueDefinition", typeof(bool), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBoundExpression_UniqueDefinitionProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ArgumentsProperty =
                ModelProperty.Register("Arguments", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBoundExpression_ArgumentsProperty));
            
            
            public static readonly ModelProperty DefinitionsProperty =
                ModelProperty.Register("Definitions", typeof(IList<ModelObject>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBoundExpression_DefinitionsProperty));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty DefinitionProperty =
                ModelProperty.Register("Definition", typeof(ModelObject), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBoundExpression_DefinitionProperty));
            
        }
        
        public static class MetaThisExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaThisExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaThisExpression; }
            }
        
        }
        
        public static class MetaNullExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNullExpression; }
            }
        
        }
        
        public static class MetaTypeConversionExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeConversionExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypeConversionExpression; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypeConversionExpression_TypeReferenceProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypeConversionExpression_ExpressionProperty));
            
        }
        
        public static class MetaTypeAsExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeAsExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypeAsExpression; }
            }
        
        }
        
        public static class MetaTypeCastExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCastExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypeCastExpression; }
            }
        
        }
        
        public static class MetaTypeCheckExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCheckExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypeCheckExpression; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypeCheckExpression_TypeReferenceProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypeCheckExpression_ExpressionProperty));
            
        }
        
        public static class MetaTypeOfExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeOfExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaTypeOfExpression; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeOfExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaTypeOfExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaTypeOfExpression_TypeReferenceProperty));
            
        }
        
        public static class MetaConditionalExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConditionalExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaConditionalExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ConditionProperty =
                ModelProperty.Register("Condition", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConditionalExpression_ConditionProperty));
            
            
            public static readonly ModelProperty BalancedTypeProperty =
                ModelProperty.Register("BalancedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConditionalExpression_BalancedTypeProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ThenProperty =
                ModelProperty.Register("Then", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConditionalExpression_ThenProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ElseProperty =
                ModelProperty.Register("Else", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConditionalExpression_ElseProperty));
            
        }
        
        public static class MetaConstantExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConstantExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaConstantExpression; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(object), typeof(global::MetaDslx.Core.MetaConstantExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaConstantExpression_ValueProperty));
            
        }
        
        public static class MetaIdentifierExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaIdentifierExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaIdentifierExpression; }
            }
        
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaIdentifierExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaIdentifierExpression_NameProperty));
            
        }
        
        public static class MetaMemberAccessExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMemberAccessExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaMemberAccessExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaMemberAccessExpression_ExpressionProperty));
            
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaMemberAccessExpression_NameProperty));
            
        }
        
        public static class MetaFunctionCallExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionCallExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaFunctionCallExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaFunctionCallExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaFunctionCallExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaFunctionCallExpression_ExpressionProperty));
            
        }
        
        public static class MetaIndexerExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaIndexerExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaIndexerExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaIndexerExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaIndexerExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaIndexerExpression_ExpressionProperty));
            
        }
        
        public static class MetaNewExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNewExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNewExpression; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewExpression_TypeReferenceProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer), "Parent")]
            public static readonly ModelProperty PropertyInitializersProperty =
                ModelProperty.Register("PropertyInitializers", typeof(IList<global::MetaDslx.Core.MetaNewPropertyInitializer>), typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewExpression_PropertyInitializersProperty));
            
        }
        
        public static class MetaNewPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNewPropertyInitializer()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNewPropertyInitializer; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression), "PropertyInitializers")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewPropertyInitializer_ParentProperty));
            
            
            public static readonly ModelProperty PropertyNameProperty =
                ModelProperty.Register("PropertyName", typeof(string), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewPropertyInitializer_PropertyNameProperty));
            
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewPropertyInitializer_ValueProperty));
            
            
            public static readonly ModelProperty PropertyProperty =
                ModelProperty.Register("Property", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewPropertyInitializer_PropertyProperty));
            
        }
        
        public static class MetaNewCollectionExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNewCollectionExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNewCollectionExpression; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.MetaNewCollectionExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewCollectionExpression_TypeReferenceProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ValuesProperty =
                ModelProperty.Register("Values", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaNewCollectionExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaNewCollectionExpression_ValuesProperty));
            
        }
        
        public static class MetaOperatorExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOperatorExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOperatorExpression; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaOperatorExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaOperatorExpression_NameProperty));
            
        }
        
        public static class MetaUnaryExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaUnaryExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaUnaryExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaUnaryExpression_ExpressionProperty));
            
        }
        
        public static class MetaUnaryPlusExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryPlusExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaUnaryPlusExpression; }
            }
        
        }
        
        public static class MetaNegateExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNegateExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNegateExpression; }
            }
        
        }
        
        public static class MetaOnesComplementExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOnesComplementExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOnesComplementExpression; }
            }
        
        }
        
        public static class MetaNotExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNotExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNotExpression; }
            }
        
        }
        
        public static class MetaUnaryAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaUnaryAssignExpression; }
            }
        
        }
        
        public static class MetaPostIncrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPostIncrementAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPostIncrementAssignExpression; }
            }
        
        }
        
        public static class MetaPostDecrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPostDecrementAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPostDecrementAssignExpression; }
            }
        
        }
        
        public static class MetaPreIncrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPreIncrementAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPreIncrementAssignExpression; }
            }
        
        }
        
        public static class MetaPreDecrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPreDecrementAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaPreDecrementAssignExpression; }
            }
        
        }
        
        public static class MetaBinaryExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBinaryExpression; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty LeftProperty =
                ModelProperty.Register("Left", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBinaryExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBinaryExpression_LeftProperty));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty RightProperty =
                ModelProperty.Register("Right", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBinaryExpression), typeof(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Core.MetaInstance.MetaBinaryExpression_RightProperty));
            
        }
        
        public static class MetaBinaryArithmeticExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryArithmeticExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBinaryArithmeticExpression; }
            }
        
        }
        
        public static class MetaMultiplyExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaMultiplyExpression; }
            }
        
        }
        
        public static class MetaDivideExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDivideExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaDivideExpression; }
            }
        
        }
        
        public static class MetaModuloExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaModuloExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaModuloExpression; }
            }
        
        }
        
        public static class MetaAddExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAddExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAddExpression; }
            }
        
        }
        
        public static class MetaSubtractExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaSubtractExpression; }
            }
        
        }
        
        public static class MetaLeftShiftExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaLeftShiftExpression; }
            }
        
        }
        
        public static class MetaRightShiftExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaRightShiftExpression; }
            }
        
        }
        
        public static class MetaBinaryComparisonExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryComparisonExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBinaryComparisonExpression; }
            }
        
        }
        
        public static class MetaLessThanExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaLessThanExpression; }
            }
        
        }
        
        public static class MetaLessThanOrEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanOrEqualExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaLessThanOrEqualExpression; }
            }
        
        }
        
        public static class MetaGreaterThanExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaGreaterThanExpression; }
            }
        
        }
        
        public static class MetaGreaterThanOrEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanOrEqualExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaGreaterThanOrEqualExpression; }
            }
        
        }
        
        public static class MetaEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaEqualExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaEqualExpression; }
            }
        
        }
        
        public static class MetaNotEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNotEqualExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNotEqualExpression; }
            }
        
        }
        
        public static class MetaBinaryLogicalExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryLogicalExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaBinaryLogicalExpression; }
            }
        
        }
        
        public static class MetaAndExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAndExpression; }
            }
        
        }
        
        public static class MetaOrExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOrExpression; }
            }
        
        }
        
        public static class MetaExclusiveOrExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaExclusiveOrExpression; }
            }
        
        }
        
        public static class MetaAndAlsoExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndAlsoExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAndAlsoExpression; }
            }
        
        }
        
        public static class MetaOrElseExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrElseExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOrElseExpression; }
            }
        
        }
        
        public static class MetaNullCoalescingExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullCoalescingExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaNullCoalescingExpression; }
            }
        
        }
        
        public static class MetaAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAssignmentExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAssignmentExpression; }
            }
        
        }
        
        public static class MetaAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAssignExpression; }
            }
        
        }
        
        public static class MetaArithmeticAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaArithmeticAssignmentExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaArithmeticAssignmentExpression; }
            }
        
        }
        
        public static class MetaMultiplyAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaMultiplyAssignExpression; }
            }
        
        }
        
        public static class MetaDivideAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDivideAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaDivideAssignExpression; }
            }
        
        }
        
        public static class MetaModuloAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaModuloAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaModuloAssignExpression; }
            }
        
        }
        
        public static class MetaAddAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAddAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAddAssignExpression; }
            }
        
        }
        
        public static class MetaSubtractAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaSubtractAssignExpression; }
            }
        
        }
        
        public static class MetaLeftShiftAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaLeftShiftAssignExpression; }
            }
        
        }
        
        public static class MetaRightShiftAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaRightShiftAssignExpression; }
            }
        
        }
        
        public static class MetaLogicalAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLogicalAssignmentExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaLogicalAssignmentExpression; }
            }
        
        }
        
        public static class MetaAndAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaAndAssignExpression; }
            }
        
        }
        
        public static class MetaExclusiveOrAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaExclusiveOrAssignExpression; }
            }
        
        }
        
        public static class MetaOrAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrAssignExpression()
            {
                global::MetaDslx.Core.MetaDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass Meta
            {
                get { return global::MetaDslx.Core.MetaInstance.MetaOrAssignExpression; }
            }
        
        }
    }
    
	internal static class MetaInstance
	{
	    internal static global::MetaDslx.Core.Model model;
	
	    static MetaInstance()
	    {
			MetaDescriptor.StaticInit();
			MetaInstance.model = new global::MetaDslx.Core.Model();
	   		using (new ModelContextScope(MetaInstance.model))
			{
				MetaAnnotatedElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNamedElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypedElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAnnotation = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAnnotationProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNamespace = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaDeclaration = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaModel = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaCollectionType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNullableType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPrimitiveType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaEnum = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaEnumLiteral = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaClass = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaFunctionType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaFunction = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOperation = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaConstant = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaConstructor = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaParameter = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPropertyInitializer = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaSynthetizedPropertyInitializer = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaInheritedPropertyInitializer = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBracketExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBoundExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaThisExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNullExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypeConversionExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypeAsExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypeCastExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypeCheckExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaTypeOfExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaConditionalExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaConstantExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaIdentifierExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaMemberAccessExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaFunctionCallExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaIndexerExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNewExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNewPropertyInitializer = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNewCollectionExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOperatorExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaUnaryExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaUnaryPlusExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNegateExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOnesComplementExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNotExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaUnaryAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPostIncrementAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPostDecrementAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPreIncrementAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaPreDecrementAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBinaryExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBinaryArithmeticExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaMultiplyExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaDivideExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaModuloExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAddExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaSubtractExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaLeftShiftExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaRightShiftExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBinaryComparisonExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaLessThanExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaLessThanOrEqualExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaGreaterThanExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaGreaterThanOrEqualExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaEqualExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNotEqualExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaBinaryLogicalExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAndExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOrExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaExclusiveOrExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAndAlsoExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOrElseExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaNullCoalescingExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAssignmentExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaArithmeticAssignmentExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaMultiplyAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaDivideAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaModuloAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAddAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaSubtractAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaLeftShiftAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaRightShiftAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaLogicalAssignmentExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaAndAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaExclusiveOrAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				MetaOrAssignExpression = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
	
				MetaAnnotatedElement.Name = "MetaAnnotatedElement";
				MetaAnnotatedElement.IsAbstract = true;
				MetaNamedElement.Name = "MetaNamedElement";
				MetaNamedElement.IsAbstract = true;
				MetaTypedElement.Name = "MetaTypedElement";
				MetaTypedElement.IsAbstract = true;
				MetaType.Name = "MetaType";
				MetaType.IsAbstract = true;
				MetaAnnotation.Name = "MetaAnnotation";
				MetaAnnotation.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaAnnotationProperty.Name = "MetaAnnotationProperty";
				MetaAnnotationProperty.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaNamespace.Name = "MetaNamespace";
				MetaNamespace.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaNamespace.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaDeclaration.Name = "MetaDeclaration";
				MetaDeclaration.IsAbstract = true;
				MetaDeclaration.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaDeclaration.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaModel.Name = "MetaModel";
				MetaModel.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaModel.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaCollectionType.Name = "MetaCollectionType";
				MetaCollectionType.SuperClasses.Add(MetaInstance.MetaType);
				MetaNullableType.Name = "MetaNullableType";
				MetaNullableType.SuperClasses.Add(MetaInstance.MetaType);
				MetaPrimitiveType.Name = "MetaPrimitiveType";
				MetaPrimitiveType.SuperClasses.Add(MetaInstance.MetaType);
				MetaPrimitiveType.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaEnum.Name = "MetaEnum";
				MetaEnum.SuperClasses.Add(MetaInstance.MetaType);
				MetaEnum.SuperClasses.Add(MetaInstance.MetaDeclaration);
				MetaEnumLiteral.Name = "MetaEnumLiteral";
				MetaEnumLiteral.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaEnumLiteral.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaClass.Name = "MetaClass";
				MetaClass.SuperClasses.Add(MetaInstance.MetaType);
				MetaClass.SuperClasses.Add(MetaInstance.MetaDeclaration);
				MetaFunctionType.Name = "MetaFunctionType";
				MetaFunctionType.SuperClasses.Add(MetaInstance.MetaType);
				MetaFunction.Name = "MetaFunction";
				MetaFunction.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaFunction.SuperClasses.Add(MetaInstance.MetaDeclaration);
				MetaOperation.Name = "MetaOperation";
				MetaOperation.SuperClasses.Add(MetaInstance.MetaFunction);
				MetaConstant.Name = "MetaConstant";
				MetaConstant.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaConstant.SuperClasses.Add(MetaInstance.MetaDeclaration);
				MetaConstructor.Name = "MetaConstructor";
				MetaConstructor.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaConstructor.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaParameter.Name = "MetaParameter";
				MetaParameter.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaParameter.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaParameter.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaProperty.Name = "MetaProperty";
				MetaProperty.SuperClasses.Add(MetaInstance.MetaNamedElement);
				MetaProperty.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaProperty.SuperClasses.Add(MetaInstance.MetaAnnotatedElement);
				MetaPropertyInitializer.Name = "MetaPropertyInitializer";
				MetaPropertyInitializer.IsAbstract = true;
				MetaSynthetizedPropertyInitializer.Name = "MetaSynthetizedPropertyInitializer";
				MetaSynthetizedPropertyInitializer.SuperClasses.Add(MetaInstance.MetaPropertyInitializer);
				MetaInheritedPropertyInitializer.Name = "MetaInheritedPropertyInitializer";
				MetaInheritedPropertyInitializer.SuperClasses.Add(MetaInstance.MetaPropertyInitializer);
				MetaExpression.Name = "MetaExpression";
				MetaExpression.IsAbstract = true;
				MetaExpression.SuperClasses.Add(MetaInstance.MetaTypedElement);
				MetaBracketExpression.Name = "MetaBracketExpression";
				MetaBracketExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaBoundExpression.Name = "MetaBoundExpression";
				MetaBoundExpression.IsAbstract = true;
				MetaBoundExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaThisExpression.Name = "MetaThisExpression";
				MetaThisExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaNullExpression.Name = "MetaNullExpression";
				MetaNullExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaTypeConversionExpression.Name = "MetaTypeConversionExpression";
				MetaTypeConversionExpression.IsAbstract = true;
				MetaTypeConversionExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaTypeAsExpression.Name = "MetaTypeAsExpression";
				MetaTypeAsExpression.SuperClasses.Add(MetaInstance.MetaTypeConversionExpression);
				MetaTypeCastExpression.Name = "MetaTypeCastExpression";
				MetaTypeCastExpression.SuperClasses.Add(MetaInstance.MetaTypeConversionExpression);
				MetaTypeCheckExpression.Name = "MetaTypeCheckExpression";
				MetaTypeCheckExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaTypeOfExpression.Name = "MetaTypeOfExpression";
				MetaTypeOfExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaConditionalExpression.Name = "MetaConditionalExpression";
				MetaConditionalExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaConstantExpression.Name = "MetaConstantExpression";
				MetaConstantExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaIdentifierExpression.Name = "MetaIdentifierExpression";
				MetaIdentifierExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaMemberAccessExpression.Name = "MetaMemberAccessExpression";
				MetaMemberAccessExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaFunctionCallExpression.Name = "MetaFunctionCallExpression";
				MetaFunctionCallExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaIndexerExpression.Name = "MetaIndexerExpression";
				MetaIndexerExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaNewExpression.Name = "MetaNewExpression";
				MetaNewExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaNewPropertyInitializer.Name = "MetaNewPropertyInitializer";
				MetaNewCollectionExpression.Name = "MetaNewCollectionExpression";
				MetaNewCollectionExpression.SuperClasses.Add(MetaInstance.MetaExpression);
				MetaOperatorExpression.Name = "MetaOperatorExpression";
				MetaOperatorExpression.IsAbstract = true;
				MetaOperatorExpression.SuperClasses.Add(MetaInstance.MetaBoundExpression);
				MetaUnaryExpression.Name = "MetaUnaryExpression";
				MetaUnaryExpression.IsAbstract = true;
				MetaUnaryExpression.SuperClasses.Add(MetaInstance.MetaOperatorExpression);
				MetaUnaryPlusExpression.Name = "MetaUnaryPlusExpression";
				MetaUnaryPlusExpression.SuperClasses.Add(MetaInstance.MetaUnaryExpression);
				MetaNegateExpression.Name = "MetaNegateExpression";
				MetaNegateExpression.SuperClasses.Add(MetaInstance.MetaUnaryExpression);
				MetaOnesComplementExpression.Name = "MetaOnesComplementExpression";
				MetaOnesComplementExpression.SuperClasses.Add(MetaInstance.MetaUnaryExpression);
				MetaNotExpression.Name = "MetaNotExpression";
				MetaNotExpression.SuperClasses.Add(MetaInstance.MetaUnaryExpression);
				MetaUnaryAssignExpression.Name = "MetaUnaryAssignExpression";
				MetaUnaryAssignExpression.IsAbstract = true;
				MetaUnaryAssignExpression.SuperClasses.Add(MetaInstance.MetaUnaryExpression);
				MetaPostIncrementAssignExpression.Name = "MetaPostIncrementAssignExpression";
				MetaPostIncrementAssignExpression.SuperClasses.Add(MetaInstance.MetaUnaryAssignExpression);
				MetaPostDecrementAssignExpression.Name = "MetaPostDecrementAssignExpression";
				MetaPostDecrementAssignExpression.SuperClasses.Add(MetaInstance.MetaUnaryAssignExpression);
				MetaPreIncrementAssignExpression.Name = "MetaPreIncrementAssignExpression";
				MetaPreIncrementAssignExpression.SuperClasses.Add(MetaInstance.MetaUnaryAssignExpression);
				MetaPreDecrementAssignExpression.Name = "MetaPreDecrementAssignExpression";
				MetaPreDecrementAssignExpression.SuperClasses.Add(MetaInstance.MetaUnaryAssignExpression);
				MetaBinaryExpression.Name = "MetaBinaryExpression";
				MetaBinaryExpression.IsAbstract = true;
				MetaBinaryExpression.SuperClasses.Add(MetaInstance.MetaOperatorExpression);
				MetaBinaryArithmeticExpression.Name = "MetaBinaryArithmeticExpression";
				MetaBinaryArithmeticExpression.IsAbstract = true;
				MetaBinaryArithmeticExpression.SuperClasses.Add(MetaInstance.MetaBinaryExpression);
				MetaMultiplyExpression.Name = "MetaMultiplyExpression";
				MetaMultiplyExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaDivideExpression.Name = "MetaDivideExpression";
				MetaDivideExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaModuloExpression.Name = "MetaModuloExpression";
				MetaModuloExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaAddExpression.Name = "MetaAddExpression";
				MetaAddExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaSubtractExpression.Name = "MetaSubtractExpression";
				MetaSubtractExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaLeftShiftExpression.Name = "MetaLeftShiftExpression";
				MetaLeftShiftExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaRightShiftExpression.Name = "MetaRightShiftExpression";
				MetaRightShiftExpression.SuperClasses.Add(MetaInstance.MetaBinaryArithmeticExpression);
				MetaBinaryComparisonExpression.Name = "MetaBinaryComparisonExpression";
				MetaBinaryComparisonExpression.IsAbstract = true;
				MetaBinaryComparisonExpression.SuperClasses.Add(MetaInstance.MetaBinaryExpression);
				MetaLessThanExpression.Name = "MetaLessThanExpression";
				MetaLessThanExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaLessThanOrEqualExpression.Name = "MetaLessThanOrEqualExpression";
				MetaLessThanOrEqualExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaGreaterThanExpression.Name = "MetaGreaterThanExpression";
				MetaGreaterThanExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaGreaterThanOrEqualExpression.Name = "MetaGreaterThanOrEqualExpression";
				MetaGreaterThanOrEqualExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaEqualExpression.Name = "MetaEqualExpression";
				MetaEqualExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaNotEqualExpression.Name = "MetaNotEqualExpression";
				MetaNotEqualExpression.SuperClasses.Add(MetaInstance.MetaBinaryComparisonExpression);
				MetaBinaryLogicalExpression.Name = "MetaBinaryLogicalExpression";
				MetaBinaryLogicalExpression.IsAbstract = true;
				MetaBinaryLogicalExpression.SuperClasses.Add(MetaInstance.MetaBinaryExpression);
				MetaAndExpression.Name = "MetaAndExpression";
				MetaAndExpression.SuperClasses.Add(MetaInstance.MetaBinaryLogicalExpression);
				MetaOrExpression.Name = "MetaOrExpression";
				MetaOrExpression.SuperClasses.Add(MetaInstance.MetaBinaryLogicalExpression);
				MetaExclusiveOrExpression.Name = "MetaExclusiveOrExpression";
				MetaExclusiveOrExpression.SuperClasses.Add(MetaInstance.MetaBinaryLogicalExpression);
				MetaAndAlsoExpression.Name = "MetaAndAlsoExpression";
				MetaAndAlsoExpression.SuperClasses.Add(MetaInstance.MetaBinaryLogicalExpression);
				MetaOrElseExpression.Name = "MetaOrElseExpression";
				MetaOrElseExpression.SuperClasses.Add(MetaInstance.MetaBinaryLogicalExpression);
				MetaNullCoalescingExpression.Name = "MetaNullCoalescingExpression";
				MetaNullCoalescingExpression.SuperClasses.Add(MetaInstance.MetaBinaryExpression);
				MetaAssignmentExpression.Name = "MetaAssignmentExpression";
				MetaAssignmentExpression.IsAbstract = true;
				MetaAssignmentExpression.SuperClasses.Add(MetaInstance.MetaBinaryExpression);
				MetaAssignExpression.Name = "MetaAssignExpression";
				MetaAssignExpression.SuperClasses.Add(MetaInstance.MetaAssignmentExpression);
				MetaArithmeticAssignmentExpression.Name = "MetaArithmeticAssignmentExpression";
				MetaArithmeticAssignmentExpression.IsAbstract = true;
				MetaArithmeticAssignmentExpression.SuperClasses.Add(MetaInstance.MetaAssignmentExpression);
				MetaMultiplyAssignExpression.Name = "MetaMultiplyAssignExpression";
				MetaMultiplyAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaDivideAssignExpression.Name = "MetaDivideAssignExpression";
				MetaDivideAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaModuloAssignExpression.Name = "MetaModuloAssignExpression";
				MetaModuloAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaAddAssignExpression.Name = "MetaAddAssignExpression";
				MetaAddAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaSubtractAssignExpression.Name = "MetaSubtractAssignExpression";
				MetaSubtractAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaLeftShiftAssignExpression.Name = "MetaLeftShiftAssignExpression";
				MetaLeftShiftAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaRightShiftAssignExpression.Name = "MetaRightShiftAssignExpression";
				MetaRightShiftAssignExpression.SuperClasses.Add(MetaInstance.MetaArithmeticAssignmentExpression);
				MetaLogicalAssignmentExpression.Name = "MetaLogicalAssignmentExpression";
				MetaLogicalAssignmentExpression.IsAbstract = true;
				MetaLogicalAssignmentExpression.SuperClasses.Add(MetaInstance.MetaAssignmentExpression);
				MetaAndAssignExpression.Name = "MetaAndAssignExpression";
				MetaAndAssignExpression.SuperClasses.Add(MetaInstance.MetaLogicalAssignmentExpression);
				MetaExclusiveOrAssignExpression.Name = "MetaExclusiveOrAssignExpression";
				MetaExclusiveOrAssignExpression.SuperClasses.Add(MetaInstance.MetaLogicalAssignmentExpression);
				MetaOrAssignExpression.Name = "MetaOrAssignExpression";
				MetaOrAssignExpression.SuperClasses.Add(MetaInstance.MetaLogicalAssignmentExpression);
	
				MetaAnnotatedElement_AnnotationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamedElement_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypedElement_TypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaAnnotation_PropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaAnnotationProperty_ValueProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamespace_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamespace_UsingsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamespace_MetaModelProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamespace_NamespacesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNamespace_DeclarationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaDeclaration_NamespaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaDeclaration_ModelProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaModel_UriProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaModel_NamespaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaCollectionType_KindProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaCollectionType_InnerTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNullableType_InnerTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaEnum_EnumLiteralsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaEnum_OperationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaEnumLiteral_EnumProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaClass_IsAbstractProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaClass_SuperClassesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaClass_PropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaClass_OperationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaClass_ConstructorProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunctionType_ParameterTypesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunctionType_ReturnTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunction_TypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunction_ParametersProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunction_ReturnTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaOperation_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConstant_ValueProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConstructor_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConstructor_InitializersProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaParameter_FunctionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_KindProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_ClassProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_OppositePropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_SubsettedPropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_SubsettingPropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_RedefinedPropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaProperty_RedefiningPropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaPropertyInitializer_ConstructorProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaPropertyInitializer_PropertyNameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaPropertyInitializer_PropertyContextProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaPropertyInitializer_PropertyProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaPropertyInitializer_ValueProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaInheritedPropertyInitializer_ObjectNameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaInheritedPropertyInitializer_ObjectProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaExpression_NoTypeErrorProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaExpression_ExpectedTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBracketExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBoundExpression_UniqueDefinitionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBoundExpression_ArgumentsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBoundExpression_DefinitionsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBoundExpression_DefinitionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypeConversionExpression_TypeReferenceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypeConversionExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypeCheckExpression_TypeReferenceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypeCheckExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaTypeOfExpression_TypeReferenceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConditionalExpression_ConditionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConditionalExpression_BalancedTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConditionalExpression_ThenProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConditionalExpression_ElseProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaConstantExpression_ValueProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaIdentifierExpression_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaMemberAccessExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaMemberAccessExpression_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaFunctionCallExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaIndexerExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewExpression_TypeReferenceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewExpression_PropertyInitializersProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewPropertyInitializer_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewPropertyInitializer_PropertyNameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewPropertyInitializer_ValueProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewPropertyInitializer_PropertyProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewCollectionExpression_TypeReferenceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaNewCollectionExpression_ValuesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaOperatorExpression_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaUnaryExpression_ExpressionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBinaryExpression_LeftProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				MetaBinaryExpression_RightProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
	
				MetaAnnotatedElement_AnnotationsProperty.Name = "Annotations";
				MetaNamedElement_NameProperty.Name = "Name";
				MetaTypedElement_TypeProperty.Name = "Type";
				MetaAnnotation_PropertiesProperty.Name = "Properties";
				MetaAnnotationProperty_ValueProperty.Name = "Value";
				MetaNamespace_ParentProperty.Name = "Parent";
				MetaNamespace_UsingsProperty.Name = "Usings";
				MetaNamespace_MetaModelProperty.Name = "MetaModel";
				MetaNamespace_NamespacesProperty.Name = "Namespaces";
				MetaNamespace_DeclarationsProperty.Name = "Declarations";
				MetaDeclaration_NamespaceProperty.Name = "Namespace";
				MetaDeclaration_ModelProperty.Name = "Model";
				MetaModel_UriProperty.Name = "Uri";
				MetaModel_NamespaceProperty.Name = "Namespace";
				MetaCollectionType_KindProperty.Name = "Kind";
				MetaCollectionType_InnerTypeProperty.Name = "InnerType";
				MetaNullableType_InnerTypeProperty.Name = "InnerType";
				MetaEnum_EnumLiteralsProperty.Name = "EnumLiterals";
				MetaEnum_OperationsProperty.Name = "Operations";
				MetaEnumLiteral_EnumProperty.Name = "Enum";
				MetaClass_IsAbstractProperty.Name = "IsAbstract";
				MetaClass_SuperClassesProperty.Name = "SuperClasses";
				MetaClass_PropertiesProperty.Name = "Properties";
				MetaClass_OperationsProperty.Name = "Operations";
				MetaClass_ConstructorProperty.Name = "Constructor";
				MetaFunctionType_ParameterTypesProperty.Name = "ParameterTypes";
				MetaFunctionType_ReturnTypeProperty.Name = "ReturnType";
				MetaFunction_TypeProperty.Name = "Type";
				MetaFunction_ParametersProperty.Name = "Parameters";
				MetaFunction_ReturnTypeProperty.Name = "ReturnType";
				MetaOperation_ParentProperty.Name = "Parent";
				MetaConstant_ValueProperty.Name = "Value";
				MetaConstructor_ParentProperty.Name = "Parent";
				MetaConstructor_InitializersProperty.Name = "Initializers";
				MetaParameter_FunctionProperty.Name = "Function";
				MetaProperty_KindProperty.Name = "Kind";
				MetaProperty_ClassProperty.Name = "Class";
				MetaProperty_OppositePropertiesProperty.Name = "OppositeProperties";
				MetaProperty_SubsettedPropertiesProperty.Name = "SubsettedProperties";
				MetaProperty_SubsettingPropertiesProperty.Name = "SubsettingProperties";
				MetaProperty_RedefinedPropertiesProperty.Name = "RedefinedProperties";
				MetaProperty_RedefiningPropertiesProperty.Name = "RedefiningProperties";
				MetaPropertyInitializer_ConstructorProperty.Name = "Constructor";
				MetaPropertyInitializer_PropertyNameProperty.Name = "PropertyName";
				MetaPropertyInitializer_PropertyContextProperty.Name = "PropertyContext";
				MetaPropertyInitializer_PropertyProperty.Name = "Property";
				MetaPropertyInitializer_ValueProperty.Name = "Value";
				MetaInheritedPropertyInitializer_ObjectNameProperty.Name = "ObjectName";
				MetaInheritedPropertyInitializer_ObjectProperty.Name = "Object";
				MetaExpression_NoTypeErrorProperty.Name = "NoTypeError";
				MetaExpression_ExpectedTypeProperty.Name = "ExpectedType";
				MetaBracketExpression_ExpressionProperty.Name = "Expression";
				MetaBoundExpression_UniqueDefinitionProperty.Name = "UniqueDefinition";
				MetaBoundExpression_ArgumentsProperty.Name = "Arguments";
				MetaBoundExpression_DefinitionsProperty.Name = "Definitions";
				MetaBoundExpression_DefinitionProperty.Name = "Definition";
				MetaTypeConversionExpression_TypeReferenceProperty.Name = "TypeReference";
				MetaTypeConversionExpression_ExpressionProperty.Name = "Expression";
				MetaTypeCheckExpression_TypeReferenceProperty.Name = "TypeReference";
				MetaTypeCheckExpression_ExpressionProperty.Name = "Expression";
				MetaTypeOfExpression_TypeReferenceProperty.Name = "TypeReference";
				MetaConditionalExpression_ConditionProperty.Name = "Condition";
				MetaConditionalExpression_BalancedTypeProperty.Name = "BalancedType";
				MetaConditionalExpression_ThenProperty.Name = "Then";
				MetaConditionalExpression_ElseProperty.Name = "Else";
				MetaConstantExpression_ValueProperty.Name = "Value";
				MetaIdentifierExpression_NameProperty.Name = "Name";
				MetaMemberAccessExpression_ExpressionProperty.Name = "Expression";
				MetaMemberAccessExpression_NameProperty.Name = "Name";
				MetaFunctionCallExpression_ExpressionProperty.Name = "Expression";
				MetaIndexerExpression_ExpressionProperty.Name = "Expression";
				MetaNewExpression_TypeReferenceProperty.Name = "TypeReference";
				MetaNewExpression_PropertyInitializersProperty.Name = "PropertyInitializers";
				MetaNewPropertyInitializer_ParentProperty.Name = "Parent";
				MetaNewPropertyInitializer_PropertyNameProperty.Name = "PropertyName";
				MetaNewPropertyInitializer_ValueProperty.Name = "Value";
				MetaNewPropertyInitializer_PropertyProperty.Name = "Property";
				MetaNewCollectionExpression_TypeReferenceProperty.Name = "TypeReference";
				MetaNewCollectionExpression_ValuesProperty.Name = "Values";
				MetaOperatorExpression_NameProperty.Name = "Name";
				MetaUnaryExpression_ExpressionProperty.Name = "Expression";
				MetaBinaryExpression_LeftProperty.Name = "Left";
				MetaBinaryExpression_RightProperty.Name = "Right";
			}
	    }
	
	    public static global::MetaDslx.Core.Model Model
	    {
	        get 
			{ 
				return MetaInstance.model; 
			}
	    }
	
		public static readonly global::MetaDslx.Core.MetaClass MetaAnnotatedElement;
		public static readonly global::MetaDslx.Core.MetaClass MetaNamedElement;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypedElement;
		public static readonly global::MetaDslx.Core.MetaClass MetaType;
		public static readonly global::MetaDslx.Core.MetaClass MetaAnnotation;
		public static readonly global::MetaDslx.Core.MetaClass MetaAnnotationProperty;
		public static readonly global::MetaDslx.Core.MetaClass MetaNamespace;
		public static readonly global::MetaDslx.Core.MetaClass MetaDeclaration;
		public static readonly global::MetaDslx.Core.MetaClass MetaModel;
		public static readonly global::MetaDslx.Core.MetaClass MetaCollectionType;
		public static readonly global::MetaDslx.Core.MetaClass MetaNullableType;
		public static readonly global::MetaDslx.Core.MetaClass MetaPrimitiveType;
		public static readonly global::MetaDslx.Core.MetaClass MetaEnum;
		public static readonly global::MetaDslx.Core.MetaClass MetaEnumLiteral;
		public static readonly global::MetaDslx.Core.MetaClass MetaClass;
		public static readonly global::MetaDslx.Core.MetaClass MetaFunctionType;
		public static readonly global::MetaDslx.Core.MetaClass MetaFunction;
		public static readonly global::MetaDslx.Core.MetaClass MetaOperation;
		public static readonly global::MetaDslx.Core.MetaClass MetaConstant;
		public static readonly global::MetaDslx.Core.MetaClass MetaConstructor;
		public static readonly global::MetaDslx.Core.MetaClass MetaParameter;
		public static readonly global::MetaDslx.Core.MetaClass MetaProperty;
		public static readonly global::MetaDslx.Core.MetaClass MetaPropertyInitializer;
		public static readonly global::MetaDslx.Core.MetaClass MetaSynthetizedPropertyInitializer;
		public static readonly global::MetaDslx.Core.MetaClass MetaInheritedPropertyInitializer;
		public static readonly global::MetaDslx.Core.MetaClass MetaExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBracketExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBoundExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaThisExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNullExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypeConversionExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypeAsExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypeCastExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypeCheckExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaTypeOfExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaConditionalExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaConstantExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaIdentifierExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaMemberAccessExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaFunctionCallExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaIndexerExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNewExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNewPropertyInitializer;
		public static readonly global::MetaDslx.Core.MetaClass MetaNewCollectionExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaOperatorExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaUnaryExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaUnaryPlusExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNegateExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaOnesComplementExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNotExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaUnaryAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaPostIncrementAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaPostDecrementAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaPreIncrementAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaPreDecrementAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBinaryExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBinaryArithmeticExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaMultiplyExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaDivideExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaModuloExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAddExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaSubtractExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaLeftShiftExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaRightShiftExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBinaryComparisonExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaLessThanExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaLessThanOrEqualExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaGreaterThanExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaGreaterThanOrEqualExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaEqualExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNotEqualExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaBinaryLogicalExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAndExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaOrExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaExclusiveOrExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAndAlsoExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaOrElseExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaNullCoalescingExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAssignmentExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaArithmeticAssignmentExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaMultiplyAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaDivideAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaModuloAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAddAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaSubtractAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaLeftShiftAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaRightShiftAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaLogicalAssignmentExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaAndAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaExclusiveOrAssignExpression;
		public static readonly global::MetaDslx.Core.MetaClass MetaOrAssignExpression;
	
		public static readonly global::MetaDslx.Core.MetaProperty MetaAnnotatedElement_AnnotationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamedElement_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypedElement_TypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaAnnotation_PropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaAnnotationProperty_ValueProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamespace_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamespace_UsingsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamespace_MetaModelProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamespace_NamespacesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNamespace_DeclarationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaDeclaration_NamespaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaDeclaration_ModelProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaModel_UriProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaModel_NamespaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaCollectionType_KindProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaCollectionType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNullableType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaEnum_EnumLiteralsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaEnum_OperationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaEnumLiteral_EnumProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaClass_IsAbstractProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaClass_SuperClassesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaClass_PropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaClass_OperationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaClass_ConstructorProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunctionType_ParameterTypesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunctionType_ReturnTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunction_TypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunction_ParametersProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunction_ReturnTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaOperation_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConstant_ValueProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConstructor_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConstructor_InitializersProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaParameter_FunctionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_KindProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_ClassProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_OppositePropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_SubsettedPropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_SubsettingPropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_RedefinedPropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaProperty_RedefiningPropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaPropertyInitializer_ConstructorProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaPropertyInitializer_PropertyNameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaPropertyInitializer_PropertyContextProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaPropertyInitializer_PropertyProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaPropertyInitializer_ValueProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaInheritedPropertyInitializer_ObjectNameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaInheritedPropertyInitializer_ObjectProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaExpression_NoTypeErrorProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaExpression_ExpectedTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBracketExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBoundExpression_UniqueDefinitionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBoundExpression_ArgumentsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBoundExpression_DefinitionsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBoundExpression_DefinitionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypeConversionExpression_TypeReferenceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypeConversionExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypeCheckExpression_TypeReferenceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypeCheckExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaTypeOfExpression_TypeReferenceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConditionalExpression_ConditionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConditionalExpression_BalancedTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConditionalExpression_ThenProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConditionalExpression_ElseProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaConstantExpression_ValueProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaIdentifierExpression_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaMemberAccessExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaMemberAccessExpression_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaFunctionCallExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaIndexerExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewExpression_TypeReferenceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewExpression_PropertyInitializersProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewPropertyInitializer_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewPropertyInitializer_PropertyNameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewPropertyInitializer_ValueProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewPropertyInitializer_PropertyProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewCollectionExpression_TypeReferenceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaNewCollectionExpression_ValuesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaOperatorExpression_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaUnaryExpression_ExpressionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBinaryExpression_LeftProperty;
		public static readonly global::MetaDslx.Core.MetaProperty MetaBinaryExpression_RightProperty;
	}
    
    public enum MetaCollectionKind
    {
        List,
        Set,
        MultiList,
        MultiSet,
    }
    
    
    public enum MetaPropertyKind
    {
        Normal,
        Readonly,
        Lazy,
        Derived,
        Containment,
        Synthetized,
        Inherited,
    }
    
    
    public interface MetaAnnotatedElement
    {
        IList<MetaAnnotation> Annotations { get; }
    
    }
    
    internal class MetaAnnotatedElementImpl : ModelObject, MetaDslx.Core.MetaAnnotatedElement
    {
        static MetaAnnotatedElementImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAnnotatedElementImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaAnnotatedElement_MetaAnnotatedElement(this);
            this.MMakeDefault();
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
    }
    
    
    public interface MetaNamedElement
    {
        string Name { get; set; }
    
    }
    
    internal class MetaNamedElementImpl : ModelObject, MetaDslx.Core.MetaNamedElement
    {
        static MetaNamedElementImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNamedElementImpl() 
        {
            MetaImplementationProvider.Implementation.MetaNamedElement_MetaNamedElement(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    }
    
    
    public interface MetaTypedElement
    {
        MetaType Type { get; set; }
    
    }
    
    internal class MetaTypedElementImpl : ModelObject, MetaDslx.Core.MetaTypedElement
    {
        static MetaTypedElementImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypedElementImpl() 
        {
            MetaImplementationProvider.Implementation.MetaTypedElement_MetaTypedElement(this);
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    }
    
    [Type]
    public interface MetaType
    {
    
    }
    
    internal class MetaTypeImpl : ModelObject, MetaDslx.Core.MetaType
    {
        static MetaTypeImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeImpl() 
        {
            MetaImplementationProvider.Implementation.MetaType_MetaType(this);
            this.MMakeDefault();
        }
    }
    
    
    public interface MetaAnnotation : MetaDslx.Core.MetaNamedElement
    {
        IList<MetaAnnotationProperty> Properties { get; }
    
    }
    
    internal class MetaAnnotationImpl : ModelObject, MetaDslx.Core.MetaAnnotation
    {
        static MetaAnnotationImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAnnotationImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotation.PropertiesProperty, new ModelList<MetaAnnotationProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotation.PropertiesProperty));
            MetaImplementationProvider.Implementation.MetaAnnotation_MetaAnnotation(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotationProperty> MetaAnnotation.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotation.PropertiesProperty); 
                if (result != null) return (IList<MetaAnnotationProperty>)result;
                else return default(IList<MetaAnnotationProperty>);
            }
        }
    }
    
    
    public interface MetaAnnotationProperty : MetaDslx.Core.MetaNamedElement
    {
        MetaExpression Value { get; set; }
    
    }
    
    internal class MetaAnnotationPropertyImpl : ModelObject, MetaDslx.Core.MetaAnnotationProperty
    {
        static MetaAnnotationPropertyImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAnnotationPropertyImpl() 
        {
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaAnnotationProperty.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            MetaImplementationProvider.Implementation.MetaAnnotationProperty_MetaAnnotationProperty(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        MetaExpression MetaAnnotationProperty.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotationProperty.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotationProperty.ValueProperty, value); }
        }
    }
    
    [Scope]
    public interface MetaNamespace : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaNamespace Parent { get; set; }
        IList<MetaNamespace> Usings { get; }
        MetaModel MetaModel { get; set; }
        IList<MetaNamespace> Namespaces { get; }
        IList<MetaDeclaration> Declarations { get; }
    
    }
    
    internal class MetaNamespaceImpl : ModelObject, MetaDslx.Core.MetaNamespace
    {
        static MetaNamespaceImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNamespaceImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.UsingsProperty, new ModelList<MetaNamespace>(this, global::MetaDslx.Core.MetaDescriptor.MetaNamespace.UsingsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty, new ModelList<MetaNamespace>(this, global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new ModelList<MetaDeclaration>(this, global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty));
            MetaImplementationProvider.Implementation.MetaNamespace_MetaNamespace(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaNamespace.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, value); }
        }
        
        IList<MetaNamespace> MetaNamespace.Usings
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.UsingsProperty); 
                if (result != null) return (IList<MetaNamespace>)result;
                else return default(IList<MetaNamespace>);
            }
        }
        
        MetaModel MetaNamespace.MetaModel
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty); 
                if (result != null) return (MetaModel)result;
                else return default(MetaModel);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
        }
        
        IList<MetaNamespace> MetaNamespace.Namespaces
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty); 
                if (result != null) return (IList<MetaNamespace>)result;
                else return default(IList<MetaNamespace>);
            }
        }
        
        IList<MetaDeclaration> MetaNamespace.Declarations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty); 
                if (result != null) return (IList<MetaDeclaration>)result;
                else return default(IList<MetaDeclaration>);
            }
        }
    }
    
    
    public interface MetaDeclaration : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaNamespace Namespace { get; set; }
        MetaModel Model { get; }
    
    }
    
    internal class MetaDeclarationImpl : ModelObject, MetaDslx.Core.MetaDeclaration
    {
        static MetaDeclarationImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaDeclarationImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaDeclaration_MetaDeclaration(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
    }
    
    
    public interface MetaModel : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        string Uri { get; set; }
        MetaNamespace Namespace { get; set; }
    
    }
    
    internal class MetaModelImpl : ModelObject, MetaDslx.Core.MetaModel
    {
        static MetaModelImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaModelImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaModel_MetaModel(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        string MetaModel.Uri
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty, value); }
        }
        
        MetaNamespace MetaModel.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty, value); }
        }
    }
    
    
    public interface MetaCollectionType : MetaDslx.Core.MetaType
    {
        MetaCollectionKind Kind { get; set; }
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaCollectionTypeImpl : ModelObject, MetaDslx.Core.MetaCollectionType
    {
        static MetaCollectionTypeImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaCollectionTypeImpl() 
        {
            MetaImplementationProvider.Implementation.MetaCollectionType_MetaCollectionType(this);
            this.MMakeDefault();
        }
        
        MetaCollectionKind MetaCollectionType.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty); 
                if (result != null) return (MetaCollectionKind)result;
                else return default(MetaCollectionKind);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, value); }
        }
        
        MetaType MetaCollectionType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
        }
    }
    
    
    public interface MetaNullableType : MetaDslx.Core.MetaType
    {
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaNullableTypeImpl : ModelObject, MetaDslx.Core.MetaNullableType
    {
        static MetaNullableTypeImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNullableTypeImpl() 
        {
            MetaImplementationProvider.Implementation.MetaNullableType_MetaNullableType(this);
            this.MMakeDefault();
        }
        
        MetaType MetaNullableType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNullableType.InnerTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
        }
    }
    
    
    public interface MetaPrimitiveType : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement
    {
    
    }
    
    internal class MetaPrimitiveTypeImpl : ModelObject, MetaDslx.Core.MetaPrimitiveType
    {
        static MetaPrimitiveTypeImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPrimitiveTypeImpl() 
        {
            MetaImplementationProvider.Implementation.MetaPrimitiveType_MetaPrimitiveType(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    }
    
    [Scope]
    public interface MetaEnum : MetaDslx.Core.MetaType, MetaDslx.Core.MetaDeclaration
    {
        IList<MetaEnumLiteral> EnumLiterals { get; }
        IList<MetaOperation> Operations { get; }
    
    }
    
    internal class MetaEnumImpl : ModelObject, MetaDslx.Core.MetaEnum
    {
        static MetaEnumImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaEnumImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaEnum.EnumLiteralsProperty, new ModelList<MetaEnumLiteral>(this, global::MetaDslx.Core.MetaDescriptor.MetaEnum.EnumLiteralsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaEnum.OperationsProperty, new ModelList<MetaOperation>(this, global::MetaDslx.Core.MetaDescriptor.MetaEnum.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaEnum_MetaEnum(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
        
        IList<MetaEnumLiteral> MetaEnum.EnumLiterals
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaEnum.EnumLiteralsProperty); 
                if (result != null) return (IList<MetaEnumLiteral>)result;
                else return default(IList<MetaEnumLiteral>);
            }
        }
        
        IList<MetaOperation> MetaEnum.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaEnum.OperationsProperty); 
                if (result != null) return (IList<MetaOperation>)result;
                else return default(IList<MetaOperation>);
            }
        }
    }
    
    
    public interface MetaEnumLiteral : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement
    {
        MetaEnum Enum { get; set; }
    
    }
    
    internal class MetaEnumLiteralImpl : ModelObject, MetaDslx.Core.MetaEnumLiteral
    {
        static MetaEnumLiteralImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaEnumLiteralImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaEnumLiteral)this).Enum));
            MetaImplementationProvider.Implementation.MetaEnumLiteral_MetaEnumLiteral(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        MetaEnum MetaEnumLiteral.Enum
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty); 
                if (result != null) return (MetaEnum)result;
                else return default(MetaEnum);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
        }
    }
    
    [Scope]
    public interface MetaClass : MetaDslx.Core.MetaType, MetaDslx.Core.MetaDeclaration
    {
        bool IsAbstract { get; set; }
        IList<MetaClass> SuperClasses { get; }
        IList<MetaProperty> Properties { get; }
        IList<MetaOperation> Operations { get; }
        MetaConstructor Constructor { get; set; }
    
        IList<MetaClass> GetAllSuperClasses();
        IList<MetaProperty> GetAllProperties();
        IList<MetaOperation> GetAllOperations();
    }
    
    internal class MetaClassImpl : ModelObject, MetaDslx.Core.MetaClass
    {
        static MetaClassImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaClassImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new ModelList<MetaClass>(this, global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.OperationsProperty, new ModelList<MetaOperation>(this, global::MetaDslx.Core.MetaDescriptor.MetaClass.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaClass_MetaClass(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
        
        bool MetaClass.IsAbstract
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
        }
        
        IList<MetaClass> MetaClass.SuperClasses
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty); 
                if (result != null) return (IList<MetaClass>)result;
                else return default(IList<MetaClass>);
            }
        }
        
        IList<MetaProperty> MetaClass.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaOperation> MetaClass.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaClass.OperationsProperty); 
                if (result != null) return (IList<MetaOperation>)result;
                else return default(IList<MetaOperation>);
            }
        }
        
        MetaConstructor MetaClass.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, value); }
        }
        
        IList<MetaClass> MetaClass.GetAllSuperClasses()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this);
        }
        
        IList<MetaProperty> MetaClass.GetAllProperties()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
        }
        
        IList<MetaOperation> MetaClass.GetAllOperations()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
        }
    }
    
    
    public interface MetaFunctionType : MetaDslx.Core.MetaType
    {
        IList<MetaType> ParameterTypes { get; }
        MetaType ReturnType { get; set; }
    
    }
    
    internal class MetaFunctionTypeImpl : ModelObject, MetaDslx.Core.MetaFunctionType
    {
        static MetaFunctionTypeImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaFunctionTypeImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, new ModelMultiList<MetaType>(this, global::MetaDslx.Core.MetaDescriptor.MetaFunctionType.ParameterTypesProperty));
            MetaImplementationProvider.Implementation.MetaFunctionType_MetaFunctionType(this);
            this.MMakeDefault();
        }
        
        IList<MetaType> MetaFunctionType.ParameterTypes
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType.ParameterTypesProperty); 
                if (result != null) return (IList<MetaType>)result;
                else return default(IList<MetaType>);
            }
        }
        
        MetaType MetaFunctionType.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
        }
    }
    
    
    public interface MetaFunction : MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaDeclaration
    {
        new MetaFunctionType Type { get; }
        IList<MetaParameter> Parameters { get; }
        MetaType ReturnType { get; set; }
    
    }
    
    internal class MetaFunctionImpl : ModelObject, MetaDslx.Core.MetaFunction
    {
        static MetaFunctionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaFunctionImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty in MetaImplementation.MetaFunction_MetaFunction
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty, new ModelList<MetaParameter>(this, global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaFunction_MetaFunction(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaFunction.TypeProperty was not set in MetaFunction_MetaFunction().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
        
        MetaFunctionType MetaFunction.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty); 
                if (result != null) return (MetaFunctionType)result;
                else return default(MetaFunctionType);
            }
        }
        
        IList<MetaParameter> MetaFunction.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty); 
                if (result != null) return (IList<MetaParameter>)result;
                else return default(IList<MetaParameter>);
            }
        }
        
        MetaType MetaFunction.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
    }
    
    
    public interface MetaOperation : MetaDslx.Core.MetaFunction
    {
        MetaType Parent { get; set; }
    
    }
    
    internal class MetaOperationImpl : ModelObject, MetaDslx.Core.MetaOperation
    {
        static MetaOperationImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOperationImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty in MetaImplementation.MetaOperation_MetaOperation
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty, new ModelList<MetaParameter>(this, global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaOperation_MetaOperation(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaFunction.TypeProperty was not set in MetaOperation_MetaOperation().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
        
        MetaFunctionType MetaFunction.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.TypeProperty); 
                if (result != null) return (MetaFunctionType)result;
                else return default(MetaFunctionType);
            }
        }
        
        IList<MetaParameter> MetaFunction.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ParametersProperty); 
                if (result != null) return (IList<MetaParameter>)result;
                else return default(IList<MetaParameter>);
            }
        }
        
        MetaType MetaFunction.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
        
        MetaType MetaOperation.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperation.ParentProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaOperation.ParentProperty, value); }
        }
    }
    
    
    public interface MetaConstant : MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaDeclaration
    {
        MetaExpression Value { get; set; }
    
    }
    
    internal class MetaConstantImpl : ModelObject, MetaDslx.Core.MetaConstant
    {
        static MetaConstantImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaConstantImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConstant)this).Type));
            MetaImplementationProvider.Implementation.MetaConstant_MetaConstant(this);
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return ((MetaDeclaration)this).Namespace.MetaModel; }
        }
        
        MetaExpression MetaConstant.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, value); }
        }
    }
    
    
    public interface MetaConstructor : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaClass Parent { get; set; }
        IList<MetaPropertyInitializer> Initializers { get; }
    
    }
    
    internal class MetaConstructorImpl : ModelObject, MetaDslx.Core.MetaConstructor
    {
        static MetaConstructorImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaConstructorImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty, new ModelList<MetaPropertyInitializer>(this, global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty));
            MetaImplementationProvider.Implementation.MetaConstructor_MetaConstructor(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaClass MetaConstructor.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty, value); }
        }
        
        IList<MetaPropertyInitializer> MetaConstructor.Initializers
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty); 
                if (result != null) return (IList<MetaPropertyInitializer>)result;
                else return default(IList<MetaPropertyInitializer>);
            }
        }
    }
    
    
    public interface MetaParameter : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaFunction Function { get; set; }
    
    }
    
    internal class MetaParameterImpl : ModelObject, MetaDslx.Core.MetaParameter
    {
        static MetaParameterImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaParameterImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaParameter_MetaParameter(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaFunction MetaParameter.Function
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaParameter.FunctionProperty); 
                if (result != null) return (MetaFunction)result;
                else return default(MetaFunction);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaParameter.FunctionProperty, value); }
        }
    }
    
    
    public interface MetaProperty : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaPropertyKind Kind { get; set; }
        MetaClass Class { get; set; }
        IList<MetaProperty> OppositeProperties { get; }
        IList<MetaProperty> SubsettedProperties { get; }
        IList<MetaProperty> SubsettingProperties { get; }
        IList<MetaProperty> RedefinedProperties { get; }
        IList<MetaProperty> RedefiningProperties { get; }
    
    }
    
    internal class MetaPropertyImpl : ModelObject, MetaDslx.Core.MetaProperty
    {
        static MetaPropertyImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPropertyImpl() 
        {
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty));
            MetaImplementationProvider.Implementation.MetaProperty_MetaProperty(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaPropertyKind MetaProperty.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty); 
                if (result != null) return (MetaPropertyKind)result;
                else return default(MetaPropertyKind);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, value); }
        }
        
        MetaClass MetaProperty.Class
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, value); }
        }
        
        IList<MetaProperty> MetaProperty.OppositeProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.SubsettedProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.SubsettingProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.RedefinedProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.RedefiningProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
    }
    
    
    public interface MetaPropertyInitializer
    {
        MetaConstructor Constructor { get; set; }
        string PropertyName { get; set; }
        MetaClass PropertyContext { get; set; }
        MetaProperty Property { get; set; }
        MetaExpression Value { get; set; }
    
    }
    
    internal class MetaPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaPropertyInitializer
    {
        static MetaPropertyInitializerImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPropertyInitializerImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaPropertyInitializer)this)) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaPropertyInitializer_MetaPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, value); }
        }
    }
    
    
    public interface MetaSynthetizedPropertyInitializer : MetaDslx.Core.MetaPropertyInitializer
    {
    
    }
    
    internal class MetaSynthetizedPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaSynthetizedPropertyInitializer
    {
        static MetaSynthetizedPropertyInitializerImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaSynthetizedPropertyInitializerImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaPropertyInitializer)this)) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, value); }
        }
    }
    
    
    public interface MetaInheritedPropertyInitializer : MetaDslx.Core.MetaPropertyInitializer
    {
        string ObjectName { get; set; }
        MetaProperty Object { get; set; }
    
    }
    
    internal class MetaInheritedPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaInheritedPropertyInitializer
    {
        static MetaInheritedPropertyInitializerImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaInheritedPropertyInitializerImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaInheritedPropertyInitializer)this).Object) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaInheritedPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaInheritedPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer.ObjectProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaInheritedPropertyInitializer)this).ObjectName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, value); }
        }
        
        string MetaInheritedPropertyInitializer.ObjectName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer.ObjectNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer.ObjectNameProperty, value); }
        }
        
        MetaProperty MetaInheritedPropertyInitializer.Object
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer.ObjectProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaInheritedPropertyInitializer.ObjectProperty, value); }
        }
    }
    
    
    public interface MetaExpression : MetaDslx.Core.MetaTypedElement
    {
        bool NoTypeError { get; }
        MetaType ExpectedType { get; }
    
    }
    
    internal class MetaExpressionImpl : ModelObject, MetaDslx.Core.MetaExpression
    {
        static MetaExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaExpression_MetaExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaExpression_MetaExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
    }
    
    
    public interface MetaBracketExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaBracketExpressionImpl : ModelObject, MetaDslx.Core.MetaBracketExpression
    {
        static MetaBracketExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBracketExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaBracketExpression)this).Expression.Type));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaBracketExpression)this).ExpectedType));
            MetaImplementationProvider.Implementation.MetaBracketExpression_MetaBracketExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBracketExpression_MetaBracketExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaExpression MetaBracketExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaBoundExpression : MetaDslx.Core.MetaExpression
    {
        bool UniqueDefinition { get; }
        IList<MetaExpression> Arguments { get; }
        IList<ModelObject> Definitions { get; }
        ModelObject Definition { get; }
    
    }
    
    internal class MetaBoundExpressionImpl : ModelObject, MetaDslx.Core.MetaBoundExpression
    {
        static MetaBoundExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBoundExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            MetaImplementationProvider.Implementation.MetaBoundExpression_MetaBoundExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBoundExpression_MetaBoundExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
    }
    
    
    public interface MetaThisExpression : MetaDslx.Core.MetaBoundExpression
    {
    
    }
    
    internal class MetaThisExpressionImpl : ModelObject, MetaDslx.Core.MetaThisExpression
    {
        static MetaThisExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaThisExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)this))));
            MetaImplementationProvider.Implementation.MetaThisExpression_MetaThisExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaThisExpression_MetaThisExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
    }
    
    
    public interface MetaNullExpression : MetaDslx.Core.MetaExpression
    {
    
    }
    
    internal class MetaNullExpressionImpl : ModelObject, MetaDslx.Core.MetaNullExpression
    {
        static MetaNullExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNullExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaNullExpression_MetaNullExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNullExpression_MetaNullExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
    }
    
    
    public interface MetaTypeConversionExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaTypeConversionExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeConversionExpression
    {
        static MetaTypeConversionExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeConversionExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeConversionExpression_MetaTypeConversionExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaTypeConversionExpression_MetaTypeConversionExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeAsExpression : MetaDslx.Core.MetaTypeConversionExpression
    {
    
    }
    
    internal class MetaTypeAsExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeAsExpression
    {
        static MetaTypeAsExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeAsExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeAsExpression_MetaTypeAsExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaTypeAsExpression_MetaTypeAsExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeCastExpression : MetaDslx.Core.MetaTypeConversionExpression
    {
    
    }
    
    internal class MetaTypeCastExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeCastExpression
    {
        static MetaTypeCastExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeCastExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeCastExpression_MetaTypeCastExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaTypeCastExpression_MetaTypeCastExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeCheckExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaTypeCheckExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeCheckExpression
    {
        static MetaTypeCheckExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeCheckExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Bool));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeCheckExpression_MetaTypeCheckExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaTypeCheckExpression_MetaTypeCheckExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeCheckExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeCheckExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeOfExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
    
    }
    
    internal class MetaTypeOfExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeOfExpression
    {
        static MetaTypeOfExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaTypeOfExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaDescriptor.MetaType.Meta));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaTypeOfExpression_MetaTypeOfExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaTypeOfExpression_MetaTypeOfExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeOfExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypeOfExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeOfExpression.TypeReferenceProperty, value); }
        }
    }
    
    
    public interface MetaConditionalExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Condition { get; set; }
        MetaType BalancedType { get; set; }
        MetaExpression Then { get; set; }
        MetaExpression Else { get; set; }
    
    }
    
    internal class MetaConditionalExpressionImpl : ModelObject, MetaDslx.Core.MetaConditionalExpression
    {
        static MetaConditionalExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaConditionalExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.Balance((ModelObject)((MetaConditionalExpression)this).Then.Type, (ModelObject)((MetaConditionalExpression)this).Else.Type)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.Bool));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConditionalExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConditionalExpression)this).ExpectedType));
            MetaImplementationProvider.Implementation.MetaConditionalExpression_MetaConditionalExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaConditionalExpression_MetaConditionalExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaExpression MetaConditionalExpression.Condition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty, value); }
        }
        
        MetaType MetaConditionalExpression.BalancedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty, value); }
        }
        
        MetaExpression MetaConditionalExpression.Then
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty, value); }
        }
        
        MetaExpression MetaConditionalExpression.Else
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty, value); }
        }
    }
    
    
    public interface MetaConstantExpression : MetaDslx.Core.MetaExpression
    {
        object Value { get; set; }
    
    }
    
    internal class MetaConstantExpressionImpl : ModelObject, MetaDslx.Core.MetaConstantExpression
    {
        static MetaConstantExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaConstantExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaConstantExpression)this).Value)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaConstantExpression_MetaConstantExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaConstantExpression_MetaConstantExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        object MetaConstantExpression.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, value); }
        }
    }
    
    
    public interface MetaIdentifierExpression : MetaDslx.Core.MetaBoundExpression
    {
        string Name { get; set; }
    
    }
    
    internal class MetaIdentifierExpressionImpl : ModelObject, MetaDslx.Core.MetaIdentifierExpression
    {
        static MetaIdentifierExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaIdentifierExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaIdentifierExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            MetaImplementationProvider.Implementation.MetaIdentifierExpression_MetaIdentifierExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaIdentifierExpression_MetaIdentifierExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaIdentifierExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, value); }
        }
    }
    
    
    public interface MetaMemberAccessExpression : MetaDslx.Core.MetaBoundExpression
    {
        MetaExpression Expression { get; set; }
        string Name { get; set; }
    
    }
    
    internal class MetaMemberAccessExpressionImpl : ModelObject, MetaDslx.Core.MetaMemberAccessExpression
    {
        static MetaMemberAccessExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaMemberAccessExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaMemberAccessExpression)this).Expression.Type }, ResolveKind.Name, ((MetaMemberAccessExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.None));
            MetaImplementationProvider.Implementation.MetaMemberAccessExpression_MetaMemberAccessExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaMemberAccessExpression_MetaMemberAccessExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaMemberAccessExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty, value); }
        }
        
        string MetaMemberAccessExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty, value); }
        }
    }
    
    
    public interface MetaFunctionCallExpression : MetaDslx.Core.MetaBoundExpression
    {
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaFunctionCallExpressionImpl : ModelObject, MetaDslx.Core.MetaFunctionCallExpression
    {
        static MetaFunctionCallExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaFunctionCallExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf((ModelObject)((MetaFunctionCallExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaFunctionCallExpression)this).Expression is MetaBoundExpression ? (((MetaBoundExpression)((MetaFunctionCallExpression)this).Expression).Definitions).Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is MetaFunctionType).OfType<ModelObject>().ToList() : null));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaFunctionCallExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaFunctionCallExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.None));
            MetaImplementationProvider.Implementation.MetaFunctionCallExpression_MetaFunctionCallExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaFunctionCallExpression_MetaFunctionCallExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaFunctionCallExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionCallExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaFunctionCallExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaIndexerExpression : MetaDslx.Core.MetaBoundExpression
    {
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaIndexerExpressionImpl : ModelObject, MetaDslx.Core.MetaIndexerExpression
    {
        static MetaIndexerExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaIndexerExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaIndexerExpression)this).Expression is MetaBoundExpression ? ((((MetaBoundExpression)((MetaIndexerExpression)this).Expression).Definitions).Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is MetaFunctionType).OfType<ModelObject>().ToList()).Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "operator[]").OfType<ModelObject>().ToList() : null));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaIndexerExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaIndexerExpression.ExpressionProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaDescriptor.Constants.None));
            MetaImplementationProvider.Implementation.MetaIndexerExpression_MetaIndexerExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaIndexerExpression_MetaIndexerExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaIndexerExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaIndexerExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaIndexerExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaNewExpression : MetaDslx.Core.MetaExpression
    {
        MetaClass TypeReference { get; set; }
        IList<MetaNewPropertyInitializer> PropertyInitializers { get; }
    
    }
    
    internal class MetaNewExpressionImpl : ModelObject, MetaDslx.Core.MetaNewExpression
    {
        static MetaNewExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNewExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaNewExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new ModelList<MetaNewPropertyInitializer>(this, global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty));
            MetaImplementationProvider.Implementation.MetaNewExpression_MetaNewExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNewExpression_MetaNewExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaClass MetaNewExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, value); }
        }
        
        IList<MetaNewPropertyInitializer> MetaNewExpression.PropertyInitializers
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty); 
                if (result != null) return (IList<MetaNewPropertyInitializer>)result;
                else return default(IList<MetaNewPropertyInitializer>);
            }
        }
    }
    
    
    public interface MetaNewPropertyInitializer
    {
        MetaNewExpression Parent { get; set; }
        string PropertyName { get; set; }
        MetaExpression Value { get; set; }
        MetaProperty Property { get; set; }
    
    }
    
    internal class MetaNewPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaNewPropertyInitializer
    {
        static MetaNewPropertyInitializerImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNewPropertyInitializerImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaNewPropertyInitializer)this).Parent.Type }, ResolveKind.Name, ((MetaNewPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaNewPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaNewPropertyInitializer_MetaNewPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaNewExpression MetaNewPropertyInitializer.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty); 
                if (result != null) return (MetaNewExpression)result;
                else return default(MetaNewExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, value); }
        }
        
        string MetaNewPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaExpression MetaNewPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, value); }
        }
        
        MetaProperty MetaNewPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, value); }
        }
    }
    
    
    public interface MetaNewCollectionExpression : MetaDslx.Core.MetaExpression
    {
        MetaCollectionType TypeReference { get; set; }
        IList<MetaExpression> Values { get; }
    
    }
    
    internal class MetaNewCollectionExpressionImpl : ModelObject, MetaDslx.Core.MetaNewCollectionExpression
    {
        static MetaNewCollectionExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNewCollectionExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaNewCollectionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression.ValuesProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression.ValuesProperty));
            MetaImplementationProvider.Implementation.MetaNewCollectionExpression_MetaNewCollectionExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNewCollectionExpression_MetaNewCollectionExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaCollectionType MetaNewCollectionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaCollectionType)result;
                else return default(MetaCollectionType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression.TypeReferenceProperty, value); }
        }
        
        IList<MetaExpression> MetaNewCollectionExpression.Values
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaNewCollectionExpression.ValuesProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
    }
    
    
    public interface MetaOperatorExpression : MetaDslx.Core.MetaBoundExpression
    {
        string Name { get; }
    
    }
    
    internal class MetaOperatorExpressionImpl : ModelObject, MetaDslx.Core.MetaOperatorExpression
    {
        static MetaOperatorExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOperatorExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaOperatorExpression_MetaOperatorExpression
            MetaImplementationProvider.Implementation.MetaOperatorExpression_MetaOperatorExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaOperatorExpression_MetaOperatorExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaOperatorExpression_MetaOperatorExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
    }
    
    
    public interface MetaUnaryExpression : MetaDslx.Core.MetaOperatorExpression
    {
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaUnaryExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryExpression
    {
        static MetaUnaryExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaUnaryExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryExpression_MetaUnaryExpression
            MetaImplementationProvider.Implementation.MetaUnaryExpression_MetaUnaryExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryExpression_MetaUnaryExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaUnaryExpression_MetaUnaryExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaUnaryPlusExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaUnaryPlusExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryPlusExpression
    {
        static MetaUnaryPlusExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaUnaryPlusExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator+()"));
            MetaImplementationProvider.Implementation.MetaUnaryPlusExpression_MetaUnaryPlusExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryPlusExpression_MetaUnaryPlusExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaUnaryPlusExpression_MetaUnaryPlusExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaNegateExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaNegateExpressionImpl : ModelObject, MetaDslx.Core.MetaNegateExpression
    {
        static MetaNegateExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNegateExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator-()"));
            MetaImplementationProvider.Implementation.MetaNegateExpression_MetaNegateExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNegateExpression_MetaNegateExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaNegateExpression_MetaNegateExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaOnesComplementExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaOnesComplementExpressionImpl : ModelObject, MetaDslx.Core.MetaOnesComplementExpression
    {
        static MetaOnesComplementExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOnesComplementExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator~()"));
            MetaImplementationProvider.Implementation.MetaOnesComplementExpression_MetaOnesComplementExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaOnesComplementExpression_MetaOnesComplementExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaOnesComplementExpression_MetaOnesComplementExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaNotExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaNotExpressionImpl : ModelObject, MetaDslx.Core.MetaNotExpression
    {
        static MetaNotExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNotExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator!()"));
            MetaImplementationProvider.Implementation.MetaNotExpression_MetaNotExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNotExpression_MetaNotExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaNotExpression_MetaNotExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaUnaryAssignExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaUnaryAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryAssignExpression
    {
        static MetaUnaryAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaUnaryAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression
            MetaImplementationProvider.Implementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryAssignExpression_MetaUnaryAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaUnaryAssignExpression_MetaUnaryAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPostIncrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPostIncrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPostIncrementAssignExpression
    {
        static MetaPostIncrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPostIncrementAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()++"));
            MetaImplementationProvider.Implementation.MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPostDecrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPostDecrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPostDecrementAssignExpression
    {
        static MetaPostDecrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPostDecrementAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()--"));
            MetaImplementationProvider.Implementation.MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPreIncrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPreIncrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPreIncrementAssignExpression
    {
        static MetaPreIncrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPreIncrementAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator++()"));
            MetaImplementationProvider.Implementation.MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPreDecrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPreDecrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPreDecrementAssignExpression
    {
        static MetaPreDecrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaPreDecrementAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator--()"));
            MetaImplementationProvider.Implementation.MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaBinaryExpression : MetaDslx.Core.MetaOperatorExpression
    {
        MetaExpression Left { get; set; }
        MetaExpression Right { get; set; }
    
    }
    
    internal class MetaBinaryExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryExpression
    {
        static MetaBinaryExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBinaryExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryExpression_MetaBinaryExpression
            MetaImplementationProvider.Implementation.MetaBinaryExpression_MetaBinaryExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryExpression_MetaBinaryExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaBinaryExpression_MetaBinaryExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryArithmeticExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryArithmeticExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryArithmeticExpression
    {
        static MetaBinaryArithmeticExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBinaryArithmeticExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression
            MetaImplementationProvider.Implementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaMultiplyExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaMultiplyExpressionImpl : ModelObject, MetaDslx.Core.MetaMultiplyExpression
    {
        static MetaMultiplyExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaMultiplyExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()*()"));
            MetaImplementationProvider.Implementation.MetaMultiplyExpression_MetaMultiplyExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaMultiplyExpression_MetaMultiplyExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaMultiplyExpression_MetaMultiplyExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaDivideExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaDivideExpressionImpl : ModelObject, MetaDslx.Core.MetaDivideExpression
    {
        static MetaDivideExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaDivideExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()/()"));
            MetaImplementationProvider.Implementation.MetaDivideExpression_MetaDivideExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaDivideExpression_MetaDivideExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaDivideExpression_MetaDivideExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaModuloExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaModuloExpressionImpl : ModelObject, MetaDslx.Core.MetaModuloExpression
    {
        static MetaModuloExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaModuloExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()%()"));
            MetaImplementationProvider.Implementation.MetaModuloExpression_MetaModuloExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaModuloExpression_MetaModuloExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaModuloExpression_MetaModuloExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAddExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaAddExpressionImpl : ModelObject, MetaDslx.Core.MetaAddExpression
    {
        static MetaAddExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAddExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()+()"));
            MetaImplementationProvider.Implementation.MetaAddExpression_MetaAddExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAddExpression_MetaAddExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAddExpression_MetaAddExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaSubtractExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaSubtractExpressionImpl : ModelObject, MetaDslx.Core.MetaSubtractExpression
    {
        static MetaSubtractExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaSubtractExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()-()"));
            MetaImplementationProvider.Implementation.MetaSubtractExpression_MetaSubtractExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaSubtractExpression_MetaSubtractExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaSubtractExpression_MetaSubtractExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLeftShiftExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaLeftShiftExpressionImpl : ModelObject, MetaDslx.Core.MetaLeftShiftExpression
    {
        static MetaLeftShiftExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaLeftShiftExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<<()"));
            MetaImplementationProvider.Implementation.MetaLeftShiftExpression_MetaLeftShiftExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaLeftShiftExpression_MetaLeftShiftExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaLeftShiftExpression_MetaLeftShiftExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaRightShiftExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaRightShiftExpressionImpl : ModelObject, MetaDslx.Core.MetaRightShiftExpression
    {
        static MetaRightShiftExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaRightShiftExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>>()"));
            MetaImplementationProvider.Implementation.MetaRightShiftExpression_MetaRightShiftExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaRightShiftExpression_MetaRightShiftExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaRightShiftExpression_MetaRightShiftExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryComparisonExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryComparisonExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryComparisonExpression
    {
        static MetaBinaryComparisonExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBinaryComparisonExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression
            MetaImplementationProvider.Implementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryComparisonExpression_MetaBinaryComparisonExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaBinaryComparisonExpression_MetaBinaryComparisonExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLessThanExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaLessThanExpressionImpl : ModelObject, MetaDslx.Core.MetaLessThanExpression
    {
        static MetaLessThanExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaLessThanExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<()"));
            MetaImplementationProvider.Implementation.MetaLessThanExpression_MetaLessThanExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaLessThanExpression_MetaLessThanExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaLessThanExpression_MetaLessThanExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLessThanOrEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaLessThanOrEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaLessThanOrEqualExpression
    {
        static MetaLessThanOrEqualExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaLessThanOrEqualExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<=()"));
            MetaImplementationProvider.Implementation.MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaGreaterThanExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaGreaterThanExpressionImpl : ModelObject, MetaDslx.Core.MetaGreaterThanExpression
    {
        static MetaGreaterThanExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaGreaterThanExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>()"));
            MetaImplementationProvider.Implementation.MetaGreaterThanExpression_MetaGreaterThanExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaGreaterThanExpression_MetaGreaterThanExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaGreaterThanExpression_MetaGreaterThanExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaGreaterThanOrEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaGreaterThanOrEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaGreaterThanOrEqualExpression
    {
        static MetaGreaterThanOrEqualExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaGreaterThanOrEqualExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>=()"));
            MetaImplementationProvider.Implementation.MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaEqualExpression
    {
        static MetaEqualExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaEqualExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()==()"));
            MetaImplementationProvider.Implementation.MetaEqualExpression_MetaEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaEqualExpression_MetaEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaEqualExpression_MetaEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaNotEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaNotEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaNotEqualExpression
    {
        static MetaNotEqualExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNotEqualExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()!=()"));
            MetaImplementationProvider.Implementation.MetaNotEqualExpression_MetaNotEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNotEqualExpression_MetaNotEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaNotEqualExpression_MetaNotEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryLogicalExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryLogicalExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryLogicalExpression
    {
        static MetaBinaryLogicalExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaBinaryLogicalExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression
            MetaImplementationProvider.Implementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryLogicalExpression_MetaBinaryLogicalExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaBinaryLogicalExpression_MetaBinaryLogicalExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaAndExpressionImpl : ModelObject, MetaDslx.Core.MetaAndExpression
    {
        static MetaAndExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAndExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&()"));
            MetaImplementationProvider.Implementation.MetaAndExpression_MetaAndExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAndExpression_MetaAndExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAndExpression_MetaAndExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaOrExpressionImpl : ModelObject, MetaDslx.Core.MetaOrExpression
    {
        static MetaOrExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOrExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()|()"));
            MetaImplementationProvider.Implementation.MetaOrExpression_MetaOrExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaOrExpression_MetaOrExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaOrExpression_MetaOrExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaExclusiveOrExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaExclusiveOrExpressionImpl : ModelObject, MetaDslx.Core.MetaExclusiveOrExpression
    {
        static MetaExclusiveOrExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaExclusiveOrExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()^()"));
            MetaImplementationProvider.Implementation.MetaExclusiveOrExpression_MetaExclusiveOrExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaExclusiveOrExpression_MetaExclusiveOrExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaExclusiveOrExpression_MetaExclusiveOrExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndAlsoExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaAndAlsoExpressionImpl : ModelObject, MetaDslx.Core.MetaAndAlsoExpression
    {
        static MetaAndAlsoExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAndAlsoExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&&()"));
            MetaImplementationProvider.Implementation.MetaAndAlsoExpression_MetaAndAlsoExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAndAlsoExpression_MetaAndAlsoExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAndAlsoExpression_MetaAndAlsoExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrElseExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaOrElseExpressionImpl : ModelObject, MetaDslx.Core.MetaOrElseExpression
    {
        static MetaOrElseExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOrElseExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()||()"));
            MetaImplementationProvider.Implementation.MetaOrElseExpression_MetaOrElseExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaOrElseExpression_MetaOrElseExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaOrElseExpression_MetaOrElseExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaNullCoalescingExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaNullCoalescingExpressionImpl : ModelObject, MetaDslx.Core.MetaNullCoalescingExpression
    {
        static MetaNullCoalescingExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaNullCoalescingExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()??()"));
            MetaImplementationProvider.Implementation.MetaNullCoalescingExpression_MetaNullCoalescingExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaNullCoalescingExpression_MetaNullCoalescingExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaNullCoalescingExpression_MetaNullCoalescingExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAssignmentExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaAssignmentExpression
    {
        static MetaAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAssignmentExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaAssignmentExpression_MetaAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAssignmentExpression_MetaAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAssignmentExpression_MetaAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAssignmentExpression_MetaAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAssignExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAssignExpression
    {
        static MetaAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAssignExpression_MetaAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAssignExpression_MetaAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAssignExpression_MetaAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaArithmeticAssignmentExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaArithmeticAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
        static MetaArithmeticAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaArithmeticAssignmentExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaMultiplyAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaMultiplyAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaMultiplyAssignExpression
    {
        static MetaMultiplyAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaMultiplyAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()*=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaMultiplyAssignExpression_MetaMultiplyAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaMultiplyAssignExpression_MetaMultiplyAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaDivideAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaDivideAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaDivideAssignExpression
    {
        static MetaDivideAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaDivideAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()/=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaDivideAssignExpression_MetaDivideAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaDivideAssignExpression_MetaDivideAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaDivideAssignExpression_MetaDivideAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaModuloAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaModuloAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaModuloAssignExpression
    {
        static MetaModuloAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaModuloAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()%=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaModuloAssignExpression_MetaModuloAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaModuloAssignExpression_MetaModuloAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaModuloAssignExpression_MetaModuloAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAddAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaAddAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAddAssignExpression
    {
        static MetaAddAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAddAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()+=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAddAssignExpression_MetaAddAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAddAssignExpression_MetaAddAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAddAssignExpression_MetaAddAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaSubtractAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaSubtractAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaSubtractAssignExpression
    {
        static MetaSubtractAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaSubtractAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()-=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaSubtractAssignExpression_MetaSubtractAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaSubtractAssignExpression_MetaSubtractAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaSubtractAssignExpression_MetaSubtractAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLeftShiftAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaLeftShiftAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaLeftShiftAssignExpression
    {
        static MetaLeftShiftAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaLeftShiftAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<<=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaRightShiftAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaRightShiftAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaRightShiftAssignExpression
    {
        static MetaRightShiftAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaRightShiftAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>>=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaRightShiftAssignExpression_MetaRightShiftAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaRightShiftAssignExpression_MetaRightShiftAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLogicalAssignmentExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaLogicalAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaLogicalAssignmentExpression
    {
        static MetaLogicalAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaLogicalAssignmentExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty in MetaImplementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaAndAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAndAssignExpression
    {
        static MetaAndAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaAndAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAndAssignExpression_MetaAndAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaAndAssignExpression_MetaAndAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaAndAssignExpression_MetaAndAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaExclusiveOrAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaExclusiveOrAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaExclusiveOrAssignExpression
    {
        static MetaExclusiveOrAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaExclusiveOrAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()^=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaOrAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaOrAssignExpression
    {
        static MetaOrAssignExpressionImpl()
        {
            global::MetaDslx.Core.MetaDescriptor.StaticInit();
        }
    
        public MetaOrAssignExpressionImpl() 
        {
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()|=()"));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaOrAssignExpression_MetaOrAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaExpression.NoTypeErrorProperty was not set in MetaOrAssignExpression_MetaOrAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property MetaDescriptor.MetaOperatorExpression.NameProperty was not set in MetaOrAssignExpression_MetaOrAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.MetaDescriptor.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class MetaFactory : ModelFactory
    {
        private static MetaFactory instance = new MetaFactory();
    
    	private MetaFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static MetaFactory Instance
        {
            get { return MetaFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of MetaAnnotation.
        /// </summary>
        public MetaAnnotation CreateMetaAnnotation(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAnnotation result = new global::MetaDslx.Core.MetaAnnotationImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAnnotationProperty.
        /// </summary>
        public MetaAnnotationProperty CreateMetaAnnotationProperty(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAnnotationProperty result = new global::MetaDslx.Core.MetaAnnotationPropertyImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNamespace.
        /// </summary>
        public MetaNamespace CreateMetaNamespace(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNamespace result = new global::MetaDslx.Core.MetaNamespaceImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModel.
        /// </summary>
        public MetaModel CreateMetaModel(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaModel result = new global::MetaDslx.Core.MetaModelImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaCollectionType.
        /// </summary>
        public MetaCollectionType CreateMetaCollectionType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaCollectionType result = new global::MetaDslx.Core.MetaCollectionTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullableType.
        /// </summary>
        public MetaNullableType CreateMetaNullableType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNullableType result = new global::MetaDslx.Core.MetaNullableTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPrimitiveType.
        /// </summary>
        public MetaPrimitiveType CreateMetaPrimitiveType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaPrimitiveType result = new global::MetaDslx.Core.MetaPrimitiveTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnum.
        /// </summary>
        public MetaEnum CreateMetaEnum(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaEnum result = new global::MetaDslx.Core.MetaEnumImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnumLiteral.
        /// </summary>
        public MetaEnumLiteral CreateMetaEnumLiteral(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaEnumLiteral result = new global::MetaDslx.Core.MetaEnumLiteralImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaClass.
        /// </summary>
        public MetaClass CreateMetaClass(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaClass result = new global::MetaDslx.Core.MetaClassImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunctionType.
        /// </summary>
        public MetaFunctionType CreateMetaFunctionType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaFunctionType result = new global::MetaDslx.Core.MetaFunctionTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunction.
        /// </summary>
        public MetaFunction CreateMetaFunction(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaFunction result = new global::MetaDslx.Core.MetaFunctionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOperation.
        /// </summary>
        public MetaOperation CreateMetaOperation(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaOperation result = new global::MetaDslx.Core.MetaOperationImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstant.
        /// </summary>
        public MetaConstant CreateMetaConstant(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaConstant result = new global::MetaDslx.Core.MetaConstantImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstructor.
        /// </summary>
        public MetaConstructor CreateMetaConstructor(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaConstructor result = new global::MetaDslx.Core.MetaConstructorImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaParameter.
        /// </summary>
        public MetaParameter CreateMetaParameter(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaParameter result = new global::MetaDslx.Core.MetaParameterImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaProperty.
        /// </summary>
        public MetaProperty CreateMetaProperty(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaProperty result = new global::MetaDslx.Core.MetaPropertyImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSynthetizedPropertyInitializer.
        /// </summary>
        public MetaSynthetizedPropertyInitializer CreateMetaSynthetizedPropertyInitializer(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaSynthetizedPropertyInitializer result = new global::MetaDslx.Core.MetaSynthetizedPropertyInitializerImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaInheritedPropertyInitializer.
        /// </summary>
        public MetaInheritedPropertyInitializer CreateMetaInheritedPropertyInitializer(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaInheritedPropertyInitializer result = new global::MetaDslx.Core.MetaInheritedPropertyInitializerImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaBracketExpression.
        /// </summary>
        public MetaBracketExpression CreateMetaBracketExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaBracketExpression result = new global::MetaDslx.Core.MetaBracketExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaThisExpression.
        /// </summary>
        public MetaThisExpression CreateMetaThisExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaThisExpression result = new global::MetaDslx.Core.MetaThisExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullExpression.
        /// </summary>
        public MetaNullExpression CreateMetaNullExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNullExpression result = new global::MetaDslx.Core.MetaNullExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeAsExpression.
        /// </summary>
        public MetaTypeAsExpression CreateMetaTypeAsExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaTypeAsExpression result = new global::MetaDslx.Core.MetaTypeAsExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeCastExpression.
        /// </summary>
        public MetaTypeCastExpression CreateMetaTypeCastExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaTypeCastExpression result = new global::MetaDslx.Core.MetaTypeCastExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeCheckExpression.
        /// </summary>
        public MetaTypeCheckExpression CreateMetaTypeCheckExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaTypeCheckExpression result = new global::MetaDslx.Core.MetaTypeCheckExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeOfExpression.
        /// </summary>
        public MetaTypeOfExpression CreateMetaTypeOfExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaTypeOfExpression result = new global::MetaDslx.Core.MetaTypeOfExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConditionalExpression.
        /// </summary>
        public MetaConditionalExpression CreateMetaConditionalExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaConditionalExpression result = new global::MetaDslx.Core.MetaConditionalExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstantExpression.
        /// </summary>
        public MetaConstantExpression CreateMetaConstantExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaConstantExpression result = new global::MetaDslx.Core.MetaConstantExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaIdentifierExpression.
        /// </summary>
        public MetaIdentifierExpression CreateMetaIdentifierExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaIdentifierExpression result = new global::MetaDslx.Core.MetaIdentifierExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMemberAccessExpression.
        /// </summary>
        public MetaMemberAccessExpression CreateMetaMemberAccessExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaMemberAccessExpression result = new global::MetaDslx.Core.MetaMemberAccessExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunctionCallExpression.
        /// </summary>
        public MetaFunctionCallExpression CreateMetaFunctionCallExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaFunctionCallExpression result = new global::MetaDslx.Core.MetaFunctionCallExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaIndexerExpression.
        /// </summary>
        public MetaIndexerExpression CreateMetaIndexerExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaIndexerExpression result = new global::MetaDslx.Core.MetaIndexerExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewExpression.
        /// </summary>
        public MetaNewExpression CreateMetaNewExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNewExpression result = new global::MetaDslx.Core.MetaNewExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewPropertyInitializer.
        /// </summary>
        public MetaNewPropertyInitializer CreateMetaNewPropertyInitializer(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNewPropertyInitializer result = new global::MetaDslx.Core.MetaNewPropertyInitializerImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewCollectionExpression.
        /// </summary>
        public MetaNewCollectionExpression CreateMetaNewCollectionExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNewCollectionExpression result = new global::MetaDslx.Core.MetaNewCollectionExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaUnaryPlusExpression.
        /// </summary>
        public MetaUnaryPlusExpression CreateMetaUnaryPlusExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaUnaryPlusExpression result = new global::MetaDslx.Core.MetaUnaryPlusExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNegateExpression.
        /// </summary>
        public MetaNegateExpression CreateMetaNegateExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNegateExpression result = new global::MetaDslx.Core.MetaNegateExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOnesComplementExpression.
        /// </summary>
        public MetaOnesComplementExpression CreateMetaOnesComplementExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaOnesComplementExpression result = new global::MetaDslx.Core.MetaOnesComplementExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNotExpression.
        /// </summary>
        public MetaNotExpression CreateMetaNotExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNotExpression result = new global::MetaDslx.Core.MetaNotExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPostIncrementAssignExpression.
        /// </summary>
        public MetaPostIncrementAssignExpression CreateMetaPostIncrementAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaPostIncrementAssignExpression result = new global::MetaDslx.Core.MetaPostIncrementAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPostDecrementAssignExpression.
        /// </summary>
        public MetaPostDecrementAssignExpression CreateMetaPostDecrementAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaPostDecrementAssignExpression result = new global::MetaDslx.Core.MetaPostDecrementAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPreIncrementAssignExpression.
        /// </summary>
        public MetaPreIncrementAssignExpression CreateMetaPreIncrementAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaPreIncrementAssignExpression result = new global::MetaDslx.Core.MetaPreIncrementAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPreDecrementAssignExpression.
        /// </summary>
        public MetaPreDecrementAssignExpression CreateMetaPreDecrementAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaPreDecrementAssignExpression result = new global::MetaDslx.Core.MetaPreDecrementAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyExpression.
        /// </summary>
        public MetaMultiplyExpression CreateMetaMultiplyExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaMultiplyExpression result = new global::MetaDslx.Core.MetaMultiplyExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaDivideExpression.
        /// </summary>
        public MetaDivideExpression CreateMetaDivideExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaDivideExpression result = new global::MetaDslx.Core.MetaDivideExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModuloExpression.
        /// </summary>
        public MetaModuloExpression CreateMetaModuloExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaModuloExpression result = new global::MetaDslx.Core.MetaModuloExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAddExpression.
        /// </summary>
        public MetaAddExpression CreateMetaAddExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAddExpression result = new global::MetaDslx.Core.MetaAddExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSubtractExpression.
        /// </summary>
        public MetaSubtractExpression CreateMetaSubtractExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaSubtractExpression result = new global::MetaDslx.Core.MetaSubtractExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftExpression.
        /// </summary>
        public MetaLeftShiftExpression CreateMetaLeftShiftExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaLeftShiftExpression result = new global::MetaDslx.Core.MetaLeftShiftExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftExpression.
        /// </summary>
        public MetaRightShiftExpression CreateMetaRightShiftExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaRightShiftExpression result = new global::MetaDslx.Core.MetaRightShiftExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLessThanExpression.
        /// </summary>
        public MetaLessThanExpression CreateMetaLessThanExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaLessThanExpression result = new global::MetaDslx.Core.MetaLessThanExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLessThanOrEqualExpression.
        /// </summary>
        public MetaLessThanOrEqualExpression CreateMetaLessThanOrEqualExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaLessThanOrEqualExpression result = new global::MetaDslx.Core.MetaLessThanOrEqualExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanExpression.
        /// </summary>
        public MetaGreaterThanExpression CreateMetaGreaterThanExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaGreaterThanExpression result = new global::MetaDslx.Core.MetaGreaterThanExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanOrEqualExpression.
        /// </summary>
        public MetaGreaterThanOrEqualExpression CreateMetaGreaterThanOrEqualExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaGreaterThanOrEqualExpression result = new global::MetaDslx.Core.MetaGreaterThanOrEqualExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEqualExpression.
        /// </summary>
        public MetaEqualExpression CreateMetaEqualExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaEqualExpression result = new global::MetaDslx.Core.MetaEqualExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNotEqualExpression.
        /// </summary>
        public MetaNotEqualExpression CreateMetaNotEqualExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNotEqualExpression result = new global::MetaDslx.Core.MetaNotEqualExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndExpression.
        /// </summary>
        public MetaAndExpression CreateMetaAndExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAndExpression result = new global::MetaDslx.Core.MetaAndExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrExpression.
        /// </summary>
        public MetaOrExpression CreateMetaOrExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaOrExpression result = new global::MetaDslx.Core.MetaOrExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrExpression.
        /// </summary>
        public MetaExclusiveOrExpression CreateMetaExclusiveOrExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaExclusiveOrExpression result = new global::MetaDslx.Core.MetaExclusiveOrExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndAlsoExpression.
        /// </summary>
        public MetaAndAlsoExpression CreateMetaAndAlsoExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAndAlsoExpression result = new global::MetaDslx.Core.MetaAndAlsoExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrElseExpression.
        /// </summary>
        public MetaOrElseExpression CreateMetaOrElseExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaOrElseExpression result = new global::MetaDslx.Core.MetaOrElseExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullCoalescingExpression.
        /// </summary>
        public MetaNullCoalescingExpression CreateMetaNullCoalescingExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaNullCoalescingExpression result = new global::MetaDslx.Core.MetaNullCoalescingExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAssignExpression.
        /// </summary>
        public MetaAssignExpression CreateMetaAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAssignExpression result = new global::MetaDslx.Core.MetaAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyAssignExpression.
        /// </summary>
        public MetaMultiplyAssignExpression CreateMetaMultiplyAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaMultiplyAssignExpression result = new global::MetaDslx.Core.MetaMultiplyAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaDivideAssignExpression.
        /// </summary>
        public MetaDivideAssignExpression CreateMetaDivideAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaDivideAssignExpression result = new global::MetaDslx.Core.MetaDivideAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModuloAssignExpression.
        /// </summary>
        public MetaModuloAssignExpression CreateMetaModuloAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaModuloAssignExpression result = new global::MetaDslx.Core.MetaModuloAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAddAssignExpression.
        /// </summary>
        public MetaAddAssignExpression CreateMetaAddAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAddAssignExpression result = new global::MetaDslx.Core.MetaAddAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSubtractAssignExpression.
        /// </summary>
        public MetaSubtractAssignExpression CreateMetaSubtractAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaSubtractAssignExpression result = new global::MetaDslx.Core.MetaSubtractAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftAssignExpression.
        /// </summary>
        public MetaLeftShiftAssignExpression CreateMetaLeftShiftAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaLeftShiftAssignExpression result = new global::MetaDslx.Core.MetaLeftShiftAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftAssignExpression.
        /// </summary>
        public MetaRightShiftAssignExpression CreateMetaRightShiftAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaRightShiftAssignExpression result = new global::MetaDslx.Core.MetaRightShiftAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndAssignExpression.
        /// </summary>
        public MetaAndAssignExpression CreateMetaAndAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaAndAssignExpression result = new global::MetaDslx.Core.MetaAndAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrAssignExpression.
        /// </summary>
        public MetaExclusiveOrAssignExpression CreateMetaExclusiveOrAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaExclusiveOrAssignExpression result = new global::MetaDslx.Core.MetaExclusiveOrAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrAssignExpression.
        /// </summary>
        public MetaOrAssignExpression CreateMetaOrAssignExpression(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		MetaOrAssignExpression result = new global::MetaDslx.Core.MetaOrAssignExpressionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    }
    
    internal static class MetaImplementationProvider
    {
        // If there is a compile error at this line, create a new class called MetaImplementation
    	// which is a subclass of MetaImplementationBase:
        private static MetaImplementation implementation = new MetaImplementation();
    
        public static MetaImplementation Implementation
        {
            get { return MetaImplementationProvider.implementation; }
        }
    }
    
    public static class MetaCollectionKindExtensions
    {
    }
    
    public static class MetaPropertyKindExtensions
    {
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in MetaImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class MetaImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: MetaAnnotatedElement()
        /// </summary>
        public virtual void MetaAnnotatedElement_MetaAnnotatedElement(MetaAnnotatedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamedElement()
        /// </summary>
        public virtual void MetaNamedElement_MetaNamedElement(MetaNamedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypedElement()
        /// </summary>
        public virtual void MetaTypedElement_MetaTypedElement(MetaTypedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaType()
        /// </summary>
        public virtual void MetaType_MetaType(MetaType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAnnotation()
    	/// Direct superclasses: MetaNamedElement
    	/// All superclasses: MetaNamedElement
        /// </summary>
        public virtual void MetaAnnotation_MetaAnnotation(MetaAnnotation @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAnnotationProperty()
    	/// Direct superclasses: MetaNamedElement
    	/// All superclasses: MetaNamedElement
        /// </summary>
        public virtual void MetaAnnotationProperty_MetaAnnotationProperty(MetaAnnotationProperty @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamespace()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaNamespace_MetaNamespace(MetaNamespace @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDeclaration()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaDeclaration_MetaDeclaration(MetaDeclaration @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModel()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaModel_MetaModel(MetaModel @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaCollectionType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaCollectionType_MetaCollectionType(MetaCollectionType @this)
        {
            this.MetaType_MetaType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullableType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaNullableType_MetaNullableType(MetaNullableType @this)
        {
            this.MetaType_MetaType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPrimitiveType()
    	/// Direct superclasses: MetaType, MetaNamedElement
    	/// All superclasses: MetaType, MetaNamedElement
        /// </summary>
        public virtual void MetaPrimitiveType_MetaPrimitiveType(MetaPrimitiveType @this)
        {
            this.MetaType_MetaType(@this);
            this.MetaNamedElement_MetaNamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnum()
    	/// Direct superclasses: MetaType, MetaDeclaration
    	/// All superclasses: MetaType, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// </summary>
        public virtual void MetaEnum_MetaEnum(MetaEnum @this)
        {
            this.MetaType_MetaType(@this);
            this.MetaDeclaration_MetaDeclaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnumLiteral()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement
        /// </summary>
        public virtual void MetaEnumLiteral_MetaEnumLiteral(MetaEnumLiteral @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaTypedElement_MetaTypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaClass()
    	/// Direct superclasses: MetaType, MetaDeclaration
    	/// All superclasses: MetaType, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// </summary>
        public virtual void MetaClass_MetaClass(MetaClass @this)
        {
            this.MetaType_MetaType(@this);
            this.MetaDeclaration_MetaDeclaration(@this);
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllSuperClasses()
        /// </summary>
        public virtual IList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllProperties()
        /// </summary>
        public virtual IList<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllOperations()
        /// </summary>
        public virtual IList<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaFunctionType_MetaFunctionType(MetaFunctionType @this)
        {
            this.MetaType_MetaType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunction()
    	/// Direct superclasses: MetaTypedElement, MetaDeclaration
    	/// All superclasses: MetaTypedElement, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// Initializes the following readonly properties:
        ///    MetaFunction.Type
        /// </summary>
        public virtual void MetaFunction_MetaFunction(MetaFunction @this)
        {
            this.MetaTypedElement_MetaTypedElement(@this);
            this.MetaDeclaration_MetaDeclaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperation()
    	/// Direct superclasses: MetaFunction
    	/// All superclasses: MetaTypedElement, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration, MetaFunction
        /// Initializes the following readonly properties:
        ///    MetaFunction.Type
        /// </summary>
        public virtual void MetaOperation_MetaOperation(MetaOperation @this)
        {
            this.MetaFunction_MetaFunction(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstant()
    	/// Direct superclasses: MetaTypedElement, MetaDeclaration
    	/// All superclasses: MetaTypedElement, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// </summary>
        public virtual void MetaConstant_MetaConstant(MetaConstant @this)
        {
            this.MetaTypedElement_MetaTypedElement(@this);
            this.MetaDeclaration_MetaDeclaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstructor()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaConstructor_MetaConstructor(MetaConstructor @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaParameter()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaParameter_MetaParameter(MetaParameter @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaTypedElement_MetaTypedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaProperty()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaProperty_MetaProperty(MetaProperty @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaTypedElement_MetaTypedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPropertyInitializer()
        /// </summary>
        public virtual void MetaPropertyInitializer_MetaPropertyInitializer(MetaPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSynthetizedPropertyInitializer()
    	/// Direct superclasses: MetaPropertyInitializer
    	/// All superclasses: MetaPropertyInitializer
        /// </summary>
        public virtual void MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(MetaSynthetizedPropertyInitializer @this)
        {
            this.MetaPropertyInitializer_MetaPropertyInitializer(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaInheritedPropertyInitializer()
    	/// Direct superclasses: MetaPropertyInitializer
    	/// All superclasses: MetaPropertyInitializer
        /// </summary>
        public virtual void MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(MetaInheritedPropertyInitializer @this)
        {
            this.MetaPropertyInitializer_MetaPropertyInitializer(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExpression()
    	/// Direct superclasses: MetaTypedElement
    	/// All superclasses: MetaTypedElement
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaExpression_MetaExpression(MetaExpression @this)
        {
            this.MetaTypedElement_MetaTypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBracketExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaBracketExpression_MetaBracketExpression(MetaBracketExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBoundExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaBoundExpression_MetaBoundExpression(MetaBoundExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaThisExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaThisExpression_MetaThisExpression(MetaThisExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaNullExpression_MetaNullExpression(MetaNullExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeConversionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeAsExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaTypeAsExpression_MetaTypeAsExpression(MetaTypeAsExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCastExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaTypeCastExpression_MetaTypeCastExpression(MetaTypeCastExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCheckExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeOfExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConditionalExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstantExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIdentifierExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMemberAccessExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionCallExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIndexerExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNewExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaNewExpression_MetaNewExpression(MetaNewExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNewPropertyInitializer()
        /// </summary>
        public virtual void MetaNewPropertyInitializer_MetaNewPropertyInitializer(MetaNewPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNewCollectionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        /// </summary>
        public virtual void MetaNewCollectionExpression_MetaNewCollectionExpression(MetaNewCollectionExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperatorExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaOperatorExpression_MetaOperatorExpression(MetaOperatorExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryExpression()
    	/// Direct superclasses: MetaOperatorExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
            this.MetaOperatorExpression_MetaOperatorExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryPlusExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryPlusExpression_MetaUnaryPlusExpression(MetaUnaryPlusExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNegateExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaNegateExpression_MetaNegateExpression(MetaNegateExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOnesComplementExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaOnesComplementExpression_MetaOnesComplementExpression(MetaOnesComplementExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNotExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaNotExpression_MetaNotExpression(MetaNotExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryAssignExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryAssignExpression_MetaUnaryAssignExpression(MetaUnaryAssignExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPostIncrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(MetaPostIncrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPostDecrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(MetaPostDecrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPreIncrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(MetaPreIncrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPreDecrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(MetaPreDecrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryExpression()
    	/// Direct superclasses: MetaOperatorExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
            this.MetaOperatorExpression_MetaOperatorExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryArithmeticExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(MetaBinaryArithmeticExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMultiplyExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaMultiplyExpression_MetaMultiplyExpression(MetaMultiplyExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDivideExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaDivideExpression_MetaDivideExpression(MetaDivideExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModuloExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaModuloExpression_MetaModuloExpression(MetaModuloExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAddExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAddExpression_MetaAddExpression(MetaAddExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSubtractExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaSubtractExpression_MetaSubtractExpression(MetaSubtractExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLeftShiftExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaLeftShiftExpression_MetaLeftShiftExpression(MetaLeftShiftExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaRightShiftExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaRightShiftExpression_MetaRightShiftExpression(MetaRightShiftExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryComparisonExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(MetaBinaryComparisonExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLessThanExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaLessThanExpression_MetaLessThanExpression(MetaLessThanExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLessThanOrEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(MetaLessThanOrEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaGreaterThanExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaGreaterThanExpression_MetaGreaterThanExpression(MetaGreaterThanExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaGreaterThanOrEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(MetaGreaterThanOrEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaEqualExpression_MetaEqualExpression(MetaEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNotEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaNotEqualExpression_MetaNotEqualExpression(MetaNotEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryLogicalExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(MetaBinaryLogicalExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAndExpression_MetaAndExpression(MetaAndExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaOrExpression_MetaOrExpression(MetaOrExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExclusiveOrExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaExclusiveOrExpression_MetaExclusiveOrExpression(MetaExclusiveOrExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndAlsoExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAndAlsoExpression_MetaAndAlsoExpression(MetaAndAlsoExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrElseExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaOrElseExpression_MetaOrElseExpression(MetaOrElseExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullCoalescingExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaNullCoalescingExpression_MetaNullCoalescingExpression(MetaNullCoalescingExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignmentExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAssignmentExpression_MetaAssignmentExpression(MetaAssignmentExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAssignExpression_MetaAssignExpression(MetaAssignExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaArithmeticAssignmentExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(MetaArithmeticAssignmentExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMultiplyAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(MetaMultiplyAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDivideAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaDivideAssignExpression_MetaDivideAssignExpression(MetaDivideAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModuloAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaModuloAssignExpression_MetaModuloAssignExpression(MetaModuloAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAddAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAddAssignExpression_MetaAddAssignExpression(MetaAddAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSubtractAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaSubtractAssignExpression_MetaSubtractAssignExpression(MetaSubtractAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLeftShiftAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(MetaLeftShiftAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaRightShiftAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(MetaRightShiftAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLogicalAssignmentExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(MetaLogicalAssignmentExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaAndAssignExpression_MetaAndAssignExpression(MetaAndAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExclusiveOrAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(MetaExclusiveOrAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        /// Initializes the following readonly properties:
        ///    MetaExpression.NoTypeError
        ///    MetaOperatorExpression.Name
        /// </summary>
        public virtual void MetaOrAssignExpression_MetaOrAssignExpression(MetaOrAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
    
    
    }
    
}

