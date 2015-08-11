using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public static class Meta
    {
    	internal static global::MetaDslx.Core.Model model;
    
        static Meta()
        {
    	    Meta.model = new global::MetaDslx.Core.Model();
            MetaAnnotatedElement.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAnnotatedElement.Instance);
            MetaNamedElement.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNamedElement.Instance);
            MetaTypedElement.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypedElement.Instance);
            MetaType.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaType.Instance);
            MetaAnnotation.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAnnotation.Instance);
            MetaAnnotationProperty.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAnnotationProperty.Instance);
            MetaNamespace.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNamespace.Instance);
            MetaModel.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaModel.Instance);
            MetaDeclaration.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaDeclaration.Instance);
            MetaCollectionType.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaCollectionType.Instance);
            MetaNullableType.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNullableType.Instance);
            MetaPrimitiveType.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPrimitiveType.Instance);
            MetaEnum.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaEnum.Instance);
            MetaEnumLiteral.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaEnumLiteral.Instance);
            MetaClass.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaClass.Instance);
            MetaFunctionType.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaFunctionType.Instance);
            MetaFunction.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaFunction.Instance);
            MetaOperation.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOperation.Instance);
            MetaConstant.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaConstant.Instance);
            MetaConstructor.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaConstructor.Instance);
            MetaParameter.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaParameter.Instance);
            MetaProperty.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaProperty.Instance);
            MetaPropertyInitializer.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPropertyInitializer.Instance);
            MetaSynthetizedPropertyInitializer.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaSynthetizedPropertyInitializer.Instance);
            MetaInheritedPropertyInitializer.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaInheritedPropertyInitializer.Instance);
            MetaExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaExpression.Instance);
            MetaBracketExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBracketExpression.Instance);
            MetaBoundExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBoundExpression.Instance);
            MetaThisExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaThisExpression.Instance);
            MetaNullExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNullExpression.Instance);
            MetaTypeConversionExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypeConversionExpression.Instance);
            MetaTypeAsExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypeAsExpression.Instance);
            MetaTypeCastExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypeCastExpression.Instance);
            MetaTypeCheckExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypeCheckExpression.Instance);
            MetaTypeOfExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaTypeOfExpression.Instance);
            MetaConditionalExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaConditionalExpression.Instance);
            MetaConstantExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaConstantExpression.Instance);
            MetaIdentifierExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaIdentifierExpression.Instance);
            MetaMemberAccessExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaMemberAccessExpression.Instance);
            MetaFunctionCallExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaFunctionCallExpression.Instance);
            MetaIndexerExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaIndexerExpression.Instance);
            MetaNewExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNewExpression.Instance);
            MetaNewPropertyInitializer.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNewPropertyInitializer.Instance);
            MetaNewCollectionExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNewCollectionExpression.Instance);
            MetaOperatorExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOperatorExpression.Instance);
            MetaUnaryExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaUnaryExpression.Instance);
            MetaUnaryPlusExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaUnaryPlusExpression.Instance);
            MetaNegateExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNegateExpression.Instance);
            MetaOnesComplementExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOnesComplementExpression.Instance);
            MetaNotExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNotExpression.Instance);
            MetaUnaryAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaUnaryAssignExpression.Instance);
            MetaPostIncrementAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPostIncrementAssignExpression.Instance);
            MetaPostDecrementAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPostDecrementAssignExpression.Instance);
            MetaPreIncrementAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPreIncrementAssignExpression.Instance);
            MetaPreDecrementAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaPreDecrementAssignExpression.Instance);
            MetaBinaryExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBinaryExpression.Instance);
            MetaBinaryArithmeticExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBinaryArithmeticExpression.Instance);
            MetaMultiplyExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaMultiplyExpression.Instance);
            MetaDivideExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaDivideExpression.Instance);
            MetaModuloExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaModuloExpression.Instance);
            MetaAddExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAddExpression.Instance);
            MetaSubtractExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaSubtractExpression.Instance);
            MetaLeftShiftExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaLeftShiftExpression.Instance);
            MetaRightShiftExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaRightShiftExpression.Instance);
            MetaBinaryComparisonExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBinaryComparisonExpression.Instance);
            MetaLessThanExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaLessThanExpression.Instance);
            MetaLessThanOrEqualExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaLessThanOrEqualExpression.Instance);
            MetaGreaterThanExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaGreaterThanExpression.Instance);
            MetaGreaterThanOrEqualExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaGreaterThanOrEqualExpression.Instance);
            MetaEqualExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaEqualExpression.Instance);
            MetaNotEqualExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNotEqualExpression.Instance);
            MetaBinaryLogicalExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaBinaryLogicalExpression.Instance);
            MetaAndExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAndExpression.Instance);
            MetaOrExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOrExpression.Instance);
            MetaExclusiveOrExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaExclusiveOrExpression.Instance);
            MetaAndAlsoExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAndAlsoExpression.Instance);
            MetaOrElseExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOrElseExpression.Instance);
            MetaNullCoalescingExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaNullCoalescingExpression.Instance);
            MetaAssignmentExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAssignmentExpression.Instance);
            MetaAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAssignExpression.Instance);
            MetaArithmeticAssignmentExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaArithmeticAssignmentExpression.Instance);
            MetaMultiplyAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaMultiplyAssignExpression.Instance);
            MetaDivideAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaDivideAssignExpression.Instance);
            MetaModuloAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaModuloAssignExpression.Instance);
            MetaAddAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAddAssignExpression.Instance);
            MetaSubtractAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaSubtractAssignExpression.Instance);
            MetaLeftShiftAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaLeftShiftAssignExpression.Instance);
            MetaRightShiftAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaRightShiftAssignExpression.Instance);
            MetaLogicalAssignmentExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaLogicalAssignmentExpression.Instance);
            MetaAndAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaAndAssignExpression.Instance);
            MetaExclusiveOrAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaExclusiveOrAssignExpression.Instance);
            MetaOrAssignExpression.StaticInit();
            model.AddInstance((global::MetaDslx.Core.ModelObject)MetaOrAssignExpression.Instance);
        }
    
        internal static void StaticInit()
        {
        }
    
        public static MetaDslx.Core.Model Model
        {
            get { return Meta.model; }
        }
    
        public static class Constants
        {
            static Constants()
            {
                global::MetaDslx.Core.MetaPrimitiveType tmp1 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Object = tmp1;
                tmp1.Name = "object";
                global::MetaDslx.Core.MetaPrimitiveType tmp2 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                String = tmp2;
                tmp2.Name = "string";
                global::MetaDslx.Core.MetaPrimitiveType tmp3 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Int = tmp3;
                tmp3.Name = "int";
                global::MetaDslx.Core.MetaPrimitiveType tmp4 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Long = tmp4;
                tmp4.Name = "long";
                global::MetaDslx.Core.MetaPrimitiveType tmp5 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Float = tmp5;
                tmp5.Name = "float";
                global::MetaDslx.Core.MetaPrimitiveType tmp6 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Double = tmp6;
                tmp6.Name = "double";
                global::MetaDslx.Core.MetaPrimitiveType tmp7 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Byte = tmp7;
                tmp7.Name = "byte";
                global::MetaDslx.Core.MetaPrimitiveType tmp8 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Bool = tmp8;
                tmp8.Name = "bool";
                global::MetaDslx.Core.MetaPrimitiveType tmp9 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Void = tmp9;
                tmp9.Name = "void";
                global::MetaDslx.Core.MetaPrimitiveType tmp10 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                None = tmp10;
                tmp10.Name = "none";
                global::MetaDslx.Core.MetaPrimitiveType tmp11 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Any = tmp11;
                tmp11.Name = "any";
                global::MetaDslx.Core.MetaPrimitiveType tmp12 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                Error = tmp12;
                tmp12.Name = "error";
                global::MetaDslx.Core.MetaPrimitiveType tmp13 = MetaModelFactory.Instance.CreateMetaPrimitiveType();
                ModelObject = tmp13;
                tmp13.Name = "ModelObject";
                global::MetaDslx.Core.MetaCollectionType tmp14 = MetaModelFactory.Instance.CreateMetaCollectionType();
                ModelObjectList = tmp14;
                tmp14.InnerType = Meta.Constants.ModelObject;
    
                TypeOf = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                TypeOf.Name = "typeof";
                TypeOf.ReturnType = global::MetaDslx.Core.Meta.MetaType.Instance;
                global::MetaDslx.Core.MetaParameter tmp15 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp15.Name = "type";
                tmp15.Type = Meta.Constants.Object;
                TypeOf.Parameters.Add(tmp15);
                GetValueType = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                GetValueType.Name = "get_type";
                GetValueType.ReturnType = global::MetaDslx.Core.Meta.MetaType.Instance;
                global::MetaDslx.Core.MetaParameter tmp16 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp16.Name = "value";
                tmp16.Type = Meta.Constants.Object;
                GetValueType.Parameters.Add(tmp16);
                GetReturnType = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                GetReturnType.Name = "get_return_type";
                GetReturnType.ReturnType = global::MetaDslx.Core.Meta.MetaType.Instance;
                global::MetaDslx.Core.MetaParameter tmp17 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp17.Name = "value";
                tmp17.Type = Meta.Constants.Object;
                GetReturnType.Parameters.Add(tmp17);
                CurrentType = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                CurrentType.Name = "current_type";
                CurrentType.ReturnType = global::MetaDslx.Core.Meta.MetaType.Instance;
                global::MetaDslx.Core.MetaParameter tmp18 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp18.Name = "symbol";
                tmp18.Type = Meta.Constants.ModelObject;
                CurrentType.Parameters.Add(tmp18);
                TypeCheck = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                TypeCheck.Name = "type_check";
                TypeCheck.ReturnType = Meta.Constants.Bool;
                global::MetaDslx.Core.MetaParameter tmp19 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp19.Name = "symbol";
                tmp19.Type = Meta.Constants.ModelObject;
                TypeCheck.Parameters.Add(tmp19);
                Balance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Balance.Name = "balance";
                Balance.ReturnType = global::MetaDslx.Core.Meta.MetaType.Instance;
                global::MetaDslx.Core.MetaParameter tmp20 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp20.Name = "left";
                tmp20.Type = global::MetaDslx.Core.Meta.MetaType.Instance;
                Balance.Parameters.Add(tmp20);
                global::MetaDslx.Core.MetaParameter tmp21 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp21.Name = "right";
                tmp21.Type = global::MetaDslx.Core.Meta.MetaType.Instance;
                Balance.Parameters.Add(tmp21);
                Resolve1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Resolve1.Name = "resolve";
                global::MetaDslx.Core.MetaCollectionType tmp22 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                Resolve1.ReturnType = tmp22;
                tmp22.Kind = MetaCollectionKind.List;
                tmp22.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp23 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp23.Name = "name";
                tmp23.Type = Meta.Constants.String;
                Resolve1.Parameters.Add(tmp23);
                Resolve2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Resolve2.Name = "resolve";
                global::MetaDslx.Core.MetaCollectionType tmp24 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                Resolve2.ReturnType = tmp24;
                tmp24.Kind = MetaCollectionKind.List;
                tmp24.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp25 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp25.Name = "context";
                tmp25.Type = Meta.Constants.ModelObject;
                Resolve2.Parameters.Add(tmp25);
                global::MetaDslx.Core.MetaParameter tmp26 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp26.Name = "name";
                tmp26.Type = Meta.Constants.String;
                Resolve2.Parameters.Add(tmp26);
                ResolveType1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                ResolveType1.Name = "resolve_type";
                global::MetaDslx.Core.MetaCollectionType tmp27 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                ResolveType1.ReturnType = tmp27;
                tmp27.Kind = MetaCollectionKind.List;
                tmp27.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp28 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp28.Name = "name";
                tmp28.Type = Meta.Constants.String;
                ResolveType1.Parameters.Add(tmp28);
                ResolveType2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                ResolveType2.Name = "resolve_type";
                global::MetaDslx.Core.MetaCollectionType tmp29 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                ResolveType2.ReturnType = tmp29;
                tmp29.Kind = MetaCollectionKind.List;
                tmp29.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp30 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp30.Name = "context";
                tmp30.Type = Meta.Constants.ModelObject;
                ResolveType2.Parameters.Add(tmp30);
                global::MetaDslx.Core.MetaParameter tmp31 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp31.Name = "name";
                tmp31.Type = Meta.Constants.String;
                ResolveType2.Parameters.Add(tmp31);
                ResolveName1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                ResolveName1.Name = "resolve_name";
                global::MetaDslx.Core.MetaCollectionType tmp32 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                ResolveName1.ReturnType = tmp32;
                tmp32.Kind = MetaCollectionKind.List;
                tmp32.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp33 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp33.Name = "name";
                tmp33.Type = Meta.Constants.String;
                ResolveName1.Parameters.Add(tmp33);
                ResolveName2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                ResolveName2.Name = "resolve_name";
                global::MetaDslx.Core.MetaCollectionType tmp34 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                ResolveName2.ReturnType = tmp34;
                tmp34.Kind = MetaCollectionKind.List;
                tmp34.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp35 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp35.Name = "context";
                tmp35.Type = Meta.Constants.ModelObject;
                ResolveName2.Parameters.Add(tmp35);
                global::MetaDslx.Core.MetaParameter tmp36 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp36.Name = "name";
                tmp36.Type = Meta.Constants.String;
                ResolveName2.Parameters.Add(tmp36);
                Bind1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Bind1.Name = "bind";
                Bind1.ReturnType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp37 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp37.Name = "symbol";
                tmp37.Type = Meta.Constants.ModelObject;
                Bind1.Parameters.Add(tmp37);
                Bind2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Bind2.Name = "bind";
                Bind2.ReturnType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp38 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp38.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp39 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                tmp38.Type = tmp39;
                tmp39.Kind = MetaCollectionKind.List;
                tmp39.InnerType = Meta.Constants.ModelObject;
                Bind2.Parameters.Add(tmp38);
                Bind3 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Bind3.Name = "bind";
                Bind3.ReturnType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp40 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp40.Name = "context";
                tmp40.Type = Meta.Constants.ModelObject;
                Bind3.Parameters.Add(tmp40);
                global::MetaDslx.Core.MetaParameter tmp41 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp41.Name = "symbol";
                tmp41.Type = Meta.Constants.ModelObject;
                Bind3.Parameters.Add(tmp41);
                Bind4 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                Bind4.Name = "bind";
                Bind4.ReturnType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp42 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp42.Name = "context";
                tmp42.Type = Meta.Constants.ModelObject;
                Bind4.Parameters.Add(tmp42);
                global::MetaDslx.Core.MetaParameter tmp43 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp43.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp44 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                tmp43.Type = tmp44;
                tmp44.Kind = MetaCollectionKind.List;
                tmp44.InnerType = Meta.Constants.ModelObject;
                Bind4.Parameters.Add(tmp43);
                SelectOfType1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                SelectOfType1.Name = "select_of_type";
                global::MetaDslx.Core.MetaCollectionType tmp45 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                SelectOfType1.ReturnType = tmp45;
                tmp45.Kind = MetaCollectionKind.List;
                tmp45.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp46 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp46.Name = "symbol";
                tmp46.Type = Meta.Constants.ModelObject;
                SelectOfType1.Parameters.Add(tmp46);
                global::MetaDslx.Core.MetaParameter tmp47 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp47.Name = "type";
                tmp47.Type = global::MetaDslx.Core.Meta.MetaType.Instance;
                SelectOfType1.Parameters.Add(tmp47);
                SelectOfType2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                SelectOfType2.Name = "select_of_type";
                global::MetaDslx.Core.MetaCollectionType tmp48 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                SelectOfType2.ReturnType = tmp48;
                tmp48.Kind = MetaCollectionKind.List;
                tmp48.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp49 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp49.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp50 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                tmp49.Type = tmp50;
                tmp50.Kind = MetaCollectionKind.List;
                tmp50.InnerType = Meta.Constants.ModelObject;
                SelectOfType2.Parameters.Add(tmp49);
                global::MetaDslx.Core.MetaParameter tmp51 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp51.Name = "type";
                tmp51.Type = global::MetaDslx.Core.Meta.MetaType.Instance;
                SelectOfType2.Parameters.Add(tmp51);
                SelectOfName1 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                SelectOfName1.Name = "select_of_name";
                global::MetaDslx.Core.MetaCollectionType tmp52 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                SelectOfName1.ReturnType = tmp52;
                tmp52.Kind = MetaCollectionKind.List;
                tmp52.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp53 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp53.Name = "symbol";
                tmp53.Type = Meta.Constants.ModelObject;
                SelectOfName1.Parameters.Add(tmp53);
                global::MetaDslx.Core.MetaParameter tmp54 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp54.Name = "name";
                tmp54.Type = Meta.Constants.String;
                SelectOfName1.Parameters.Add(tmp54);
                SelectOfName2 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaFunction();
                SelectOfName2.Name = "select_of_name";
                global::MetaDslx.Core.MetaCollectionType tmp55 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                SelectOfName2.ReturnType = tmp55;
                tmp55.Kind = MetaCollectionKind.List;
                tmp55.InnerType = Meta.Constants.ModelObject;
                global::MetaDslx.Core.MetaParameter tmp56 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp56.Name = "symbols";
                global::MetaDslx.Core.MetaCollectionType tmp57 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaCollectionType();
                tmp56.Type = tmp57;
                tmp57.Kind = MetaCollectionKind.List;
                tmp57.InnerType = Meta.Constants.ModelObject;
                SelectOfName2.Parameters.Add(tmp56);
                global::MetaDslx.Core.MetaParameter tmp58 = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaParameter();
                tmp58.Name = "name";
                tmp58.Type = Meta.Constants.String;
                SelectOfName2.Parameters.Add(tmp58);
            }
    
            public static global::MetaDslx.Core.MetaPrimitiveType Object { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType String { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Int { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Long { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Float { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Double { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Byte { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Bool { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Void { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType None { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Any { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType Error { get; private set; }
            public static global::MetaDslx.Core.MetaPrimitiveType ModelObject { get; private set; }
            public static global::MetaDslx.Core.MetaCollectionType ModelObjectList { get; private set; }
    
            public static global::MetaDslx.Core.MetaFunction TypeOf { get; private set; }
            public static global::MetaDslx.Core.MetaFunction GetValueType { get; private set; }
            public static global::MetaDslx.Core.MetaFunction GetReturnType { get; private set; }
            public static global::MetaDslx.Core.MetaFunction CurrentType { get; private set; }
            public static global::MetaDslx.Core.MetaFunction TypeCheck { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Balance { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Resolve1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Resolve2 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction ResolveType1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction ResolveType2 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction ResolveName1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction ResolveName2 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Bind1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Bind2 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Bind3 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction Bind4 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction SelectOfType1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction SelectOfType2 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction SelectOfName1 { get; private set; }
            public static global::MetaDslx.Core.MetaFunction SelectOfName2 { get; private set; }
        }
    
        
        public static class MetaAnnotatedElement
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotatedElement()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAnnotatedElement.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaAnnotatedElement.instance.IsAbstract = true;
                MetaAnnotatedElement.instance.Name = "MetaAnnotatedElement";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAnnotatedElement.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty AnnotationsProperty =
                ModelProperty.Register("Annotations", typeof(IList<global::MetaDslx.Core.MetaAnnotation>), typeof(global::MetaDslx.Core.MetaAnnotatedElement), typeof(global::MetaDslx.Core.Meta.MetaAnnotatedElement));
            
        }
        
        public static class MetaNamedElement
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNamedElement()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNamedElement.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaNamedElement.instance.IsAbstract = true;
                MetaNamedElement.instance.Name = "MetaNamedElement";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNamedElement.instance; }
            }
        
            [Name]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaNamedElement), typeof(global::MetaDslx.Core.Meta.MetaNamedElement));
            
        }
        
        public static class MetaTypedElement
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypedElement()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypedElement.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaTypedElement.instance.IsAbstract = true;
                MetaTypedElement.instance.Name = "MetaTypedElement";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypedElement.instance; }
            }
        
            [Type]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypedElement), typeof(global::MetaDslx.Core.Meta.MetaTypedElement));
            
        }
        
        public static class MetaType
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaType()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaType.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaType.instance.IsAbstract = true;
                MetaType.instance.Name = "MetaType";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaType.instance; }
            }
        
        }
        
        public static class MetaAnnotation
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotation()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAnnotation.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAnnotation.instance.Name = "MetaAnnotation";
                ((ModelCollection)MetaAnnotation.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAnnotation.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaAnnotationProperty>), typeof(global::MetaDslx.Core.MetaAnnotation), typeof(global::MetaDslx.Core.Meta.MetaAnnotation));
            
        }
        
        public static class MetaAnnotationProperty
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotationProperty()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAnnotationProperty.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAnnotationProperty.instance.Name = "MetaAnnotationProperty";
                ((ModelCollection)MetaAnnotationProperty.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAnnotationProperty.instance; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaAnnotationProperty), typeof(global::MetaDslx.Core.Meta.MetaAnnotationProperty));
            
        }
        
        public static class MetaNamespace
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNamespace()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNamespace.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNamespace.instance.Name = "MetaNamespace";
                ((ModelCollection)MetaNamespace.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaNamespace.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNamespace.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaNamespace), "Namespaces")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.Meta.MetaNamespace));
            
            [ImportedScope]
            public static readonly ModelProperty UsingsProperty =
                ModelProperty.Register("Usings", typeof(IList<global::MetaDslx.Core.MetaNamespace>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.Meta.MetaNamespace));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaNamespace), "Parent")]
            public static readonly ModelProperty NamespacesProperty =
                ModelProperty.Register("Namespaces", typeof(IList<global::MetaDslx.Core.MetaNamespace>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.Meta.MetaNamespace));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaModel), "Namespace")]
            public static readonly ModelProperty ModelsProperty =
                ModelProperty.Register("Models", typeof(IList<global::MetaDslx.Core.MetaModel>), typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.Meta.MetaNamespace));
            
        }
        
        public static class MetaModel
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaModel()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaModel.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaModel.instance.Name = "MetaModel";
                ((ModelCollection)MetaModel.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaModel.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaModel.instance; }
            }
        
            
            public static readonly ModelProperty UriProperty =
                ModelProperty.Register("Uri", typeof(string), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            
            public static readonly ModelProperty PrefixProperty =
                ModelProperty.Register("Prefix", typeof(string), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaNamespace), "Models")]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaDeclaration), "Model")]
            public static readonly ModelProperty TypesProperty =
                ModelProperty.Register("Types", typeof(IList<global::MetaDslx.Core.MetaType>), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            [ScopeEntry]
            [ContainmentAttribute]
            public static readonly ModelProperty ConstantsProperty =
                ModelProperty.Register("Constants", typeof(IList<global::MetaDslx.Core.MetaConstant>), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            [ScopeEntry]
            [ContainmentAttribute]
            public static readonly ModelProperty FunctionsProperty =
                ModelProperty.Register("Functions", typeof(IList<global::MetaDslx.Core.MetaFunction>), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
        }
        
        public static class MetaDeclaration
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaDeclaration()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaDeclaration.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaDeclaration.instance.IsAbstract = true;
                MetaDeclaration.instance.Name = "MetaDeclaration";
                ((ModelCollection)MetaDeclaration.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaDeclaration.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaDeclaration.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaModel), "Types")]
            public static readonly ModelProperty ModelProperty =
                ModelProperty.Register("Model", typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.MetaDeclaration), typeof(global::MetaDslx.Core.Meta.MetaDeclaration));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Core.MetaNamespace), typeof(global::MetaDslx.Core.MetaDeclaration), typeof(global::MetaDslx.Core.Meta.MetaDeclaration));
            
        }
        
        public static class MetaCollectionType
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaCollectionType()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaCollectionType.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaCollectionType.instance.Name = "MetaCollectionType";
                ((ModelCollection)MetaCollectionType.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaCollectionType.instance; }
            }
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaCollectionKind), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.Meta.MetaCollectionType));
            
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.Meta.MetaCollectionType));
            
        }
        
        public static class MetaNullableType
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNullableType()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNullableType.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNullableType.instance.Name = "MetaNullableType";
                ((ModelCollection)MetaNullableType.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNullableType.instance; }
            }
        
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaNullableType), typeof(global::MetaDslx.Core.Meta.MetaNullableType));
            
        }
        
        public static class MetaPrimitiveType
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPrimitiveType()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPrimitiveType.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaPrimitiveType.instance.Name = "MetaPrimitiveType";
                ((ModelCollection)MetaPrimitiveType.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
                ((ModelCollection)MetaPrimitiveType.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPrimitiveType.instance; }
            }
        
        }
        
        public static class MetaEnum
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaEnum()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaEnum.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaEnum.instance.Name = "MetaEnum";
                ((ModelCollection)MetaEnum.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
                ((ModelCollection)MetaEnum.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaDeclaration.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaEnum.instance; }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaEnumLiteral), "Enum")]
            public static readonly ModelProperty EnumLiteralsProperty =
                ModelProperty.Register("EnumLiterals", typeof(IList<global::MetaDslx.Core.MetaEnumLiteral>), typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.Meta.MetaEnum));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaOperation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.Meta.MetaEnum));
            
        }
        
        public static class MetaEnumLiteral
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaEnumLiteral()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaEnumLiteral.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaEnumLiteral.instance.Name = "MetaEnumLiteral";
                ((ModelCollection)MetaEnumLiteral.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaEnumLiteral.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaEnumLiteral.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaEnum), "EnumLiterals")]
            public static readonly ModelProperty EnumProperty =
                ModelProperty.Register("Enum", typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.MetaEnumLiteral), typeof(global::MetaDslx.Core.Meta.MetaEnumLiteral));
            
        }
        
        public static class MetaClass
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaClass()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaClass.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaClass.instance.Name = "MetaClass";
                ((ModelCollection)MetaClass.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
                ((ModelCollection)MetaClass.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaDeclaration.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaClass.instance; }
            }
        
            
            public static readonly ModelProperty IsAbstractProperty =
                ModelProperty.Register("IsAbstract", typeof(bool), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [InheritedScope]
            public static readonly ModelProperty SuperClassesProperty =
                ModelProperty.Register("SuperClasses", typeof(IList<global::MetaDslx.Core.MetaClass>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "Class")]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaOperation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaConstructor), "Parent")]
            public static readonly ModelProperty ConstructorProperty =
                ModelProperty.Register("Constructor", typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
        }
        
        public static class MetaFunctionType
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionType()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaFunctionType.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaFunctionType.instance.Name = "MetaFunctionType";
                ((ModelCollection)MetaFunctionType.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaFunctionType.instance; }
            }
        
            
            public static readonly ModelProperty ParameterTypesProperty =
                ModelProperty.Register("ParameterTypes", typeof(IList<global::MetaDslx.Core.MetaType>), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.Meta.MetaFunctionType));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.Meta.MetaFunctionType));
            
        }
        
        public static class MetaFunction
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaFunction()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaFunction.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaFunction.instance.Name = "MetaFunction";
                ((ModelCollection)MetaFunction.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaFunction.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
                ((ModelCollection)MetaFunction.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaFunction.instance; }
            }
        
            [Type]
            [ReadonlyAttribute]
            [RedefinesAttribute(typeof(global::MetaDslx.Core.Meta.MetaTypedElement), "Type")]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaParameter), "Function")]
            public static readonly ModelProperty ParametersProperty =
                ModelProperty.Register("Parameters", typeof(IList<global::MetaDslx.Core.MetaParameter>), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
        }
        
        public static class MetaOperation
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOperation()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOperation.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaOperation.instance.Name = "MetaOperation";
                ((ModelCollection)MetaOperation.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaFunction.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOperation.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaClass), "Operations")]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaEnum), "Operations")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.Meta.MetaOperation));
            
        }
        
        public static class MetaConstant
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaConstant()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaConstant.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaConstant.instance.Name = "MetaConstant";
                ((ModelCollection)MetaConstant.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
                ((ModelCollection)MetaConstant.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaDeclaration.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaConstant.instance; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConstant), typeof(global::MetaDslx.Core.Meta.MetaConstant));
            
        }
        
        public static class MetaConstructor
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaConstructor()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaConstructor.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaConstructor.instance.Name = "MetaConstructor";
                ((ModelCollection)MetaConstructor.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaConstructor.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaConstructor.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaClass), "Constructor")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.Meta.MetaConstructor));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer), "Constructor")]
            public static readonly ModelProperty InitializersProperty =
                ModelProperty.Register("Initializers", typeof(IList<global::MetaDslx.Core.MetaPropertyInitializer>), typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.Meta.MetaConstructor));
            
        }
        
        public static class MetaParameter
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaParameter()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaParameter.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaParameter.instance.Name = "MetaParameter";
                ((ModelCollection)MetaParameter.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaParameter.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
                ((ModelCollection)MetaParameter.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaParameter.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaFunction), "Parameters")]
            public static readonly ModelProperty FunctionProperty =
                ModelProperty.Register("Function", typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.MetaParameter), typeof(global::MetaDslx.Core.Meta.MetaParameter));
            
        }
        
        public static class MetaProperty
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaProperty()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaProperty.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaProperty.instance.Name = "MetaProperty";
                ((ModelCollection)MetaProperty.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaNamedElement.Instance));
                ((ModelCollection)MetaProperty.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
                ((ModelCollection)MetaProperty.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAnnotatedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaProperty.instance; }
            }
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaPropertyKind), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaClass), "Properties")]
            public static readonly ModelProperty ClassProperty =
                ModelProperty.Register("Class", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "OppositeProperties")]
            public static readonly ModelProperty OppositePropertiesProperty =
                ModelProperty.Register("OppositeProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "SubsettingProperties")]
            public static readonly ModelProperty SubsettedPropertiesProperty =
                ModelProperty.Register("SubsettedProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "SubsettedProperties")]
            public static readonly ModelProperty SubsettingPropertiesProperty =
                ModelProperty.Register("SubsettingProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "RedefiningProperties")]
            public static readonly ModelProperty RedefinedPropertiesProperty =
                ModelProperty.Register("RedefinedProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "RedefinedProperties")]
            public static readonly ModelProperty RedefiningPropertiesProperty =
                ModelProperty.Register("RedefiningProperties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
        }
        
        public static class MetaPropertyInitializer
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPropertyInitializer()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPropertyInitializer.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaPropertyInitializer.instance.IsAbstract = true;
                MetaPropertyInitializer.instance.Name = "MetaPropertyInitializer";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPropertyInitializer.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaConstructor), "Initializers")]
            public static readonly ModelProperty ConstructorProperty =
                ModelProperty.Register("Constructor", typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyNameProperty =
                ModelProperty.Register("PropertyName", typeof(string), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyContextProperty =
                ModelProperty.Register("PropertyContext", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyProperty =
                ModelProperty.Register("Property", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
        }
        
        public static class MetaSynthetizedPropertyInitializer
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaSynthetizedPropertyInitializer()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaSynthetizedPropertyInitializer.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaSynthetizedPropertyInitializer.instance.Name = "MetaSynthetizedPropertyInitializer";
                ((ModelCollection)MetaSynthetizedPropertyInitializer.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaPropertyInitializer.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaSynthetizedPropertyInitializer.instance; }
            }
        
        }
        
        public static class MetaInheritedPropertyInitializer
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaInheritedPropertyInitializer()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaInheritedPropertyInitializer.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaInheritedPropertyInitializer.instance.Name = "MetaInheritedPropertyInitializer";
                ((ModelCollection)MetaInheritedPropertyInitializer.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaPropertyInitializer.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaInheritedPropertyInitializer.instance; }
            }
        
            
            public static readonly ModelProperty ObjectNameProperty =
                ModelProperty.Register("ObjectName", typeof(string), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer));
            
            
            public static readonly ModelProperty ObjectProperty =
                ModelProperty.Register("Object", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer));
            
        }
        
        public static class MetaExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaExpression.instance.IsAbstract = true;
                MetaExpression.instance.Name = "MetaExpression";
                ((ModelCollection)MetaExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypedElement.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaExpression.instance; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NoTypeErrorProperty =
                ModelProperty.Register("NoTypeError", typeof(bool), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty ExpectedTypeProperty =
                ModelProperty.Register("ExpectedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
        }
        
        public static class MetaBracketExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBracketExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBracketExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaBracketExpression.instance.Name = "MetaBracketExpression";
                ((ModelCollection)MetaBracketExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBracketExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBracketExpression), typeof(global::MetaDslx.Core.Meta.MetaBracketExpression));
            
        }
        
        public static class MetaBoundExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBoundExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBoundExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaBoundExpression.instance.IsAbstract = true;
                MetaBoundExpression.instance.Name = "MetaBoundExpression";
                ((ModelCollection)MetaBoundExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBoundExpression.instance; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty UniqueDefinitionProperty =
                ModelProperty.Register("UniqueDefinition", typeof(bool), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ArgumentsProperty =
                ModelProperty.Register("Arguments", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
            
            public static readonly ModelProperty DefinitionsProperty =
                ModelProperty.Register("Definitions", typeof(IList<ModelObject>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty DefinitionProperty =
                ModelProperty.Register("Definition", typeof(ModelObject), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
        }
        
        public static class MetaThisExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaThisExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaThisExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaThisExpression.instance.Name = "MetaThisExpression";
                ((ModelCollection)MetaThisExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaThisExpression.instance; }
            }
        
        }
        
        public static class MetaNullExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNullExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNullExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNullExpression.instance.Name = "MetaNullExpression";
                ((ModelCollection)MetaNullExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNullExpression.instance; }
            }
        
        }
        
        public static class MetaTypeConversionExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypeConversionExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypeConversionExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaTypeConversionExpression.instance.IsAbstract = true;
                MetaTypeConversionExpression.instance.Name = "MetaTypeConversionExpression";
                ((ModelCollection)MetaTypeConversionExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypeConversionExpression.instance; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeConversionExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeConversionExpression));
            
        }
        
        public static class MetaTypeAsExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypeAsExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypeAsExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaTypeAsExpression.instance.Name = "MetaTypeAsExpression";
                ((ModelCollection)MetaTypeAsExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypeConversionExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypeAsExpression.instance; }
            }
        
        }
        
        public static class MetaTypeCastExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCastExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypeCastExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaTypeCastExpression.instance.Name = "MetaTypeCastExpression";
                ((ModelCollection)MetaTypeCastExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaTypeConversionExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypeCastExpression.instance; }
            }
        
        }
        
        public static class MetaTypeCheckExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCheckExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypeCheckExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaTypeCheckExpression.instance.Name = "MetaTypeCheckExpression";
                ((ModelCollection)MetaTypeCheckExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypeCheckExpression.instance; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeCheckExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeCheckExpression));
            
        }
        
        public static class MetaTypeOfExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaTypeOfExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaTypeOfExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaTypeOfExpression.instance.Name = "MetaTypeOfExpression";
                ((ModelCollection)MetaTypeOfExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaTypeOfExpression.instance; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeOfExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeOfExpression));
            
        }
        
        public static class MetaConditionalExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaConditionalExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaConditionalExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaConditionalExpression.instance.Name = "MetaConditionalExpression";
                ((ModelCollection)MetaConditionalExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaConditionalExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ConditionProperty =
                ModelProperty.Register("Condition", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.Meta.MetaConditionalExpression));
            
            
            public static readonly ModelProperty BalancedTypeProperty =
                ModelProperty.Register("BalancedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.Meta.MetaConditionalExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ThenProperty =
                ModelProperty.Register("Then", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.Meta.MetaConditionalExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ElseProperty =
                ModelProperty.Register("Else", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaConditionalExpression), typeof(global::MetaDslx.Core.Meta.MetaConditionalExpression));
            
        }
        
        public static class MetaConstantExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaConstantExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaConstantExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaConstantExpression.instance.Name = "MetaConstantExpression";
                ((ModelCollection)MetaConstantExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaConstantExpression.instance; }
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(object), typeof(global::MetaDslx.Core.MetaConstantExpression), typeof(global::MetaDslx.Core.Meta.MetaConstantExpression));
            
        }
        
        public static class MetaIdentifierExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaIdentifierExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaIdentifierExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaIdentifierExpression.instance.Name = "MetaIdentifierExpression";
                ((ModelCollection)MetaIdentifierExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaIdentifierExpression.instance; }
            }
        
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaIdentifierExpression), typeof(global::MetaDslx.Core.Meta.MetaIdentifierExpression));
            
        }
        
        public static class MetaMemberAccessExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaMemberAccessExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaMemberAccessExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaMemberAccessExpression.instance.Name = "MetaMemberAccessExpression";
                ((ModelCollection)MetaMemberAccessExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaMemberAccessExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.Meta.MetaMemberAccessExpression));
            
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.Meta.MetaMemberAccessExpression));
            
        }
        
        public static class MetaFunctionCallExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionCallExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaFunctionCallExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaFunctionCallExpression.instance.Name = "MetaFunctionCallExpression";
                ((ModelCollection)MetaFunctionCallExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaFunctionCallExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaFunctionCallExpression), typeof(global::MetaDslx.Core.Meta.MetaFunctionCallExpression));
            
        }
        
        public static class MetaIndexerExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaIndexerExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaIndexerExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaIndexerExpression.instance.Name = "MetaIndexerExpression";
                ((ModelCollection)MetaIndexerExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaIndexerExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaIndexerExpression), typeof(global::MetaDslx.Core.Meta.MetaIndexerExpression));
            
        }
        
        public static class MetaNewExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNewExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNewExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNewExpression.instance.Name = "MetaNewExpression";
                ((ModelCollection)MetaNewExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNewExpression.instance; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.Meta.MetaNewExpression));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer), "Parent")]
            public static readonly ModelProperty PropertyInitializersProperty =
                ModelProperty.Register("PropertyInitializers", typeof(IList<global::MetaDslx.Core.MetaNewPropertyInitializer>), typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.Meta.MetaNewExpression));
            
        }
        
        public static class MetaNewPropertyInitializer
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNewPropertyInitializer()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNewPropertyInitializer.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNewPropertyInitializer.instance.Name = "MetaNewPropertyInitializer";
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNewPropertyInitializer.instance; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaNewExpression), "PropertyInitializers")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaNewExpression), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyNameProperty =
                ModelProperty.Register("PropertyName", typeof(string), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer));
            
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyProperty =
                ModelProperty.Register("Property", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaNewPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer));
            
        }
        
        public static class MetaNewCollectionExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNewCollectionExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNewCollectionExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNewCollectionExpression.instance.Name = "MetaNewCollectionExpression";
                ((ModelCollection)MetaNewCollectionExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNewCollectionExpression.instance; }
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.MetaNewCollectionExpression), typeof(global::MetaDslx.Core.Meta.MetaNewCollectionExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ValuesProperty =
                ModelProperty.Register("Values", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaNewCollectionExpression), typeof(global::MetaDslx.Core.Meta.MetaNewCollectionExpression));
            
        }
        
        public static class MetaOperatorExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOperatorExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOperatorExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaOperatorExpression.instance.IsAbstract = true;
                MetaOperatorExpression.instance.Name = "MetaOperatorExpression";
                ((ModelCollection)MetaOperatorExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBoundExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOperatorExpression.instance; }
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaOperatorExpression), typeof(global::MetaDslx.Core.Meta.MetaOperatorExpression));
            
        }
        
        public static class MetaUnaryExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaUnaryExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaUnaryExpression.instance.IsAbstract = true;
                MetaUnaryExpression.instance.Name = "MetaUnaryExpression";
                ((ModelCollection)MetaUnaryExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaOperatorExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaUnaryExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaUnaryExpression), typeof(global::MetaDslx.Core.Meta.MetaUnaryExpression));
            
        }
        
        public static class MetaUnaryPlusExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryPlusExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaUnaryPlusExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaUnaryPlusExpression.instance.Name = "MetaUnaryPlusExpression";
                ((ModelCollection)MetaUnaryPlusExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaUnaryPlusExpression.instance; }
            }
        
        }
        
        public static class MetaNegateExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNegateExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNegateExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNegateExpression.instance.Name = "MetaNegateExpression";
                ((ModelCollection)MetaNegateExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNegateExpression.instance; }
            }
        
        }
        
        public static class MetaOnesComplementExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOnesComplementExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOnesComplementExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaOnesComplementExpression.instance.Name = "MetaOnesComplementExpression";
                ((ModelCollection)MetaOnesComplementExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOnesComplementExpression.instance; }
            }
        
        }
        
        public static class MetaNotExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNotExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNotExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNotExpression.instance.Name = "MetaNotExpression";
                ((ModelCollection)MetaNotExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNotExpression.instance; }
            }
        
        }
        
        public static class MetaUnaryAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaUnaryAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaUnaryAssignExpression.instance.IsAbstract = true;
                MetaUnaryAssignExpression.instance.Name = "MetaUnaryAssignExpression";
                ((ModelCollection)MetaUnaryAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaUnaryAssignExpression.instance; }
            }
        
        }
        
        public static class MetaPostIncrementAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPostIncrementAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPostIncrementAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaPostIncrementAssignExpression.instance.Name = "MetaPostIncrementAssignExpression";
                ((ModelCollection)MetaPostIncrementAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryAssignExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPostIncrementAssignExpression.instance; }
            }
        
        }
        
        public static class MetaPostDecrementAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPostDecrementAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPostDecrementAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaPostDecrementAssignExpression.instance.Name = "MetaPostDecrementAssignExpression";
                ((ModelCollection)MetaPostDecrementAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryAssignExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPostDecrementAssignExpression.instance; }
            }
        
        }
        
        public static class MetaPreIncrementAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPreIncrementAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPreIncrementAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaPreIncrementAssignExpression.instance.Name = "MetaPreIncrementAssignExpression";
                ((ModelCollection)MetaPreIncrementAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryAssignExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPreIncrementAssignExpression.instance; }
            }
        
        }
        
        public static class MetaPreDecrementAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaPreDecrementAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaPreDecrementAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaPreDecrementAssignExpression.instance.Name = "MetaPreDecrementAssignExpression";
                ((ModelCollection)MetaPreDecrementAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaUnaryAssignExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaPreDecrementAssignExpression.instance; }
            }
        
        }
        
        public static class MetaBinaryExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBinaryExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaBinaryExpression.instance.IsAbstract = true;
                MetaBinaryExpression.instance.Name = "MetaBinaryExpression";
                ((ModelCollection)MetaBinaryExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaOperatorExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBinaryExpression.instance; }
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty LeftProperty =
                ModelProperty.Register("Left", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBinaryExpression), typeof(global::MetaDslx.Core.Meta.MetaBinaryExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty RightProperty =
                ModelProperty.Register("Right", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBinaryExpression), typeof(global::MetaDslx.Core.Meta.MetaBinaryExpression));
            
        }
        
        public static class MetaBinaryArithmeticExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryArithmeticExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBinaryArithmeticExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaBinaryArithmeticExpression.instance.IsAbstract = true;
                MetaBinaryArithmeticExpression.instance.Name = "MetaBinaryArithmeticExpression";
                ((ModelCollection)MetaBinaryArithmeticExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBinaryArithmeticExpression.instance; }
            }
        
        }
        
        public static class MetaMultiplyExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaMultiplyExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaMultiplyExpression.instance.Name = "MetaMultiplyExpression";
                ((ModelCollection)MetaMultiplyExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaMultiplyExpression.instance; }
            }
        
        }
        
        public static class MetaDivideExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaDivideExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaDivideExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaDivideExpression.instance.Name = "MetaDivideExpression";
                ((ModelCollection)MetaDivideExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaDivideExpression.instance; }
            }
        
        }
        
        public static class MetaModuloExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaModuloExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaModuloExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaModuloExpression.instance.Name = "MetaModuloExpression";
                ((ModelCollection)MetaModuloExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaModuloExpression.instance; }
            }
        
        }
        
        public static class MetaAddExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAddExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAddExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAddExpression.instance.Name = "MetaAddExpression";
                ((ModelCollection)MetaAddExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAddExpression.instance; }
            }
        
        }
        
        public static class MetaSubtractExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaSubtractExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaSubtractExpression.instance.Name = "MetaSubtractExpression";
                ((ModelCollection)MetaSubtractExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaSubtractExpression.instance; }
            }
        
        }
        
        public static class MetaLeftShiftExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaLeftShiftExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaLeftShiftExpression.instance.Name = "MetaLeftShiftExpression";
                ((ModelCollection)MetaLeftShiftExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaLeftShiftExpression.instance; }
            }
        
        }
        
        public static class MetaRightShiftExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaRightShiftExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaRightShiftExpression.instance.Name = "MetaRightShiftExpression";
                ((ModelCollection)MetaRightShiftExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryArithmeticExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaRightShiftExpression.instance; }
            }
        
        }
        
        public static class MetaBinaryComparisonExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryComparisonExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBinaryComparisonExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaBinaryComparisonExpression.instance.IsAbstract = true;
                MetaBinaryComparisonExpression.instance.Name = "MetaBinaryComparisonExpression";
                ((ModelCollection)MetaBinaryComparisonExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBinaryComparisonExpression.instance; }
            }
        
        }
        
        public static class MetaLessThanExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaLessThanExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaLessThanExpression.instance.Name = "MetaLessThanExpression";
                ((ModelCollection)MetaLessThanExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaLessThanExpression.instance; }
            }
        
        }
        
        public static class MetaLessThanOrEqualExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanOrEqualExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaLessThanOrEqualExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaLessThanOrEqualExpression.instance.Name = "MetaLessThanOrEqualExpression";
                ((ModelCollection)MetaLessThanOrEqualExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaLessThanOrEqualExpression.instance; }
            }
        
        }
        
        public static class MetaGreaterThanExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaGreaterThanExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaGreaterThanExpression.instance.Name = "MetaGreaterThanExpression";
                ((ModelCollection)MetaGreaterThanExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaGreaterThanExpression.instance; }
            }
        
        }
        
        public static class MetaGreaterThanOrEqualExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanOrEqualExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaGreaterThanOrEqualExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaGreaterThanOrEqualExpression.instance.Name = "MetaGreaterThanOrEqualExpression";
                ((ModelCollection)MetaGreaterThanOrEqualExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaGreaterThanOrEqualExpression.instance; }
            }
        
        }
        
        public static class MetaEqualExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaEqualExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaEqualExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaEqualExpression.instance.Name = "MetaEqualExpression";
                ((ModelCollection)MetaEqualExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaEqualExpression.instance; }
            }
        
        }
        
        public static class MetaNotEqualExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNotEqualExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNotEqualExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNotEqualExpression.instance.Name = "MetaNotEqualExpression";
                ((ModelCollection)MetaNotEqualExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNotEqualExpression.instance; }
            }
        
        }
        
        public static class MetaBinaryLogicalExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryLogicalExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaBinaryLogicalExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaBinaryLogicalExpression.instance.IsAbstract = true;
                MetaBinaryLogicalExpression.instance.Name = "MetaBinaryLogicalExpression";
                ((ModelCollection)MetaBinaryLogicalExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaBinaryLogicalExpression.instance; }
            }
        
        }
        
        public static class MetaAndExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAndExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAndExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAndExpression.instance.Name = "MetaAndExpression";
                ((ModelCollection)MetaAndExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryLogicalExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAndExpression.instance; }
            }
        
        }
        
        public static class MetaOrExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOrExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOrExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaOrExpression.instance.Name = "MetaOrExpression";
                ((ModelCollection)MetaOrExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryLogicalExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOrExpression.instance; }
            }
        
        }
        
        public static class MetaExclusiveOrExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaExclusiveOrExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaExclusiveOrExpression.instance.Name = "MetaExclusiveOrExpression";
                ((ModelCollection)MetaExclusiveOrExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryLogicalExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaExclusiveOrExpression.instance; }
            }
        
        }
        
        public static class MetaAndAlsoExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAndAlsoExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAndAlsoExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAndAlsoExpression.instance.Name = "MetaAndAlsoExpression";
                ((ModelCollection)MetaAndAlsoExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryLogicalExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAndAlsoExpression.instance; }
            }
        
        }
        
        public static class MetaOrElseExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOrElseExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOrElseExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaOrElseExpression.instance.Name = "MetaOrElseExpression";
                ((ModelCollection)MetaOrElseExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryLogicalExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOrElseExpression.instance; }
            }
        
        }
        
        public static class MetaNullCoalescingExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaNullCoalescingExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaNullCoalescingExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaNullCoalescingExpression.instance.Name = "MetaNullCoalescingExpression";
                ((ModelCollection)MetaNullCoalescingExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaNullCoalescingExpression.instance; }
            }
        
        }
        
        public static class MetaAssignmentExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAssignmentExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAssignmentExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaAssignmentExpression.instance.IsAbstract = true;
                MetaAssignmentExpression.instance.Name = "MetaAssignmentExpression";
                ((ModelCollection)MetaAssignmentExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaBinaryExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAssignmentExpression.instance; }
            }
        
        }
        
        public static class MetaAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAssignExpression.instance.Name = "MetaAssignExpression";
                ((ModelCollection)MetaAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAssignExpression.instance; }
            }
        
        }
        
        public static class MetaArithmeticAssignmentExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaArithmeticAssignmentExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaArithmeticAssignmentExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaArithmeticAssignmentExpression.instance.IsAbstract = true;
                MetaArithmeticAssignmentExpression.instance.Name = "MetaArithmeticAssignmentExpression";
                ((ModelCollection)MetaArithmeticAssignmentExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaArithmeticAssignmentExpression.instance; }
            }
        
        }
        
        public static class MetaMultiplyAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaMultiplyAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaMultiplyAssignExpression.instance.Name = "MetaMultiplyAssignExpression";
                ((ModelCollection)MetaMultiplyAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaMultiplyAssignExpression.instance; }
            }
        
        }
        
        public static class MetaDivideAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaDivideAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaDivideAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaDivideAssignExpression.instance.Name = "MetaDivideAssignExpression";
                ((ModelCollection)MetaDivideAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaDivideAssignExpression.instance; }
            }
        
        }
        
        public static class MetaModuloAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaModuloAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaModuloAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaModuloAssignExpression.instance.Name = "MetaModuloAssignExpression";
                ((ModelCollection)MetaModuloAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaModuloAssignExpression.instance; }
            }
        
        }
        
        public static class MetaAddAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAddAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAddAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAddAssignExpression.instance.Name = "MetaAddAssignExpression";
                ((ModelCollection)MetaAddAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAddAssignExpression.instance; }
            }
        
        }
        
        public static class MetaSubtractAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaSubtractAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaSubtractAssignExpression.instance.Name = "MetaSubtractAssignExpression";
                ((ModelCollection)MetaSubtractAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaSubtractAssignExpression.instance; }
            }
        
        }
        
        public static class MetaLeftShiftAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaLeftShiftAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaLeftShiftAssignExpression.instance.Name = "MetaLeftShiftAssignExpression";
                ((ModelCollection)MetaLeftShiftAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaLeftShiftAssignExpression.instance; }
            }
        
        }
        
        public static class MetaRightShiftAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaRightShiftAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaRightShiftAssignExpression.instance.Name = "MetaRightShiftAssignExpression";
                ((ModelCollection)MetaRightShiftAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaArithmeticAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaRightShiftAssignExpression.instance; }
            }
        
        }
        
        public static class MetaLogicalAssignmentExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaLogicalAssignmentExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaLogicalAssignmentExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
        		MetaLogicalAssignmentExpression.instance.IsAbstract = true;
                MetaLogicalAssignmentExpression.instance.Name = "MetaLogicalAssignmentExpression";
                ((ModelCollection)MetaLogicalAssignmentExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaLogicalAssignmentExpression.instance; }
            }
        
        }
        
        public static class MetaAndAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaAndAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaAndAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaAndAssignExpression.instance.Name = "MetaAndAssignExpression";
                ((ModelCollection)MetaAndAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaLogicalAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaAndAssignExpression.instance; }
            }
        
        }
        
        public static class MetaExclusiveOrAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaExclusiveOrAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaExclusiveOrAssignExpression.instance.Name = "MetaExclusiveOrAssignExpression";
                ((ModelCollection)MetaExclusiveOrAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaLogicalAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaExclusiveOrAssignExpression.instance; }
            }
        
        }
        
        public static class MetaOrAssignExpression
        {
        	internal static global::MetaDslx.Core.MetaClass instance;
            internal static void StaticInit()
            {
            }
        
            static MetaOrAssignExpression()
            {
                global::MetaDslx.Core.Meta.StaticInit();
                MetaOrAssignExpression.instance = global::MetaDslx.Core.MetaModelFactory.Instance.CreateMetaClass(false);
                MetaOrAssignExpression.instance.Name = "MetaOrAssignExpression";
                ((ModelCollection)MetaOrAssignExpression.instance.SuperClasses).MLazyAdd(new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaLogicalAssignmentExpression.Instance));
            }
        
            public static global::MetaDslx.Core.MetaClass Instance
            {
                get { return MetaOrAssignExpression.instance; }
            }
        
        }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAnnotatedElementImpl() 
            : this(true)
        {
        }
        public MetaAnnotatedElementImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaAnnotatedElement_MetaAnnotatedElement(this);
            this.MMakeDefault();
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNamedElementImpl() 
            : this(true)
        {
        }
        public MetaNamedElementImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            MetaImplementationProvider.Implementation.MetaNamedElement_MetaNamedElement(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypedElementImpl() 
            : this(true)
        {
        }
        public MetaTypedElementImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            MetaImplementationProvider.Implementation.MetaTypedElement_MetaTypedElement(this);
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeImpl() 
            : this(true)
        {
        }
        public MetaTypeImpl(bool addToModelContext) 
            : base(addToModelContext)
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAnnotationImpl() 
            : this(true)
        {
        }
        public MetaAnnotationImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotation.PropertiesProperty, new ModelList<MetaAnnotationProperty>(this, global::MetaDslx.Core.Meta.MetaAnnotation.PropertiesProperty));
            MetaImplementationProvider.Implementation.MetaAnnotation_MetaAnnotation(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotationProperty> MetaAnnotation.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotation.PropertiesProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAnnotationPropertyImpl() 
            : this(true)
        {
        }
        public MetaAnnotationPropertyImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaAnnotationProperty.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            MetaImplementationProvider.Implementation.MetaAnnotationProperty_MetaAnnotationProperty(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaExpression MetaAnnotationProperty.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotationProperty.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaAnnotationProperty.ValueProperty, value); }
        }
    }
    
    [Scope]
    public interface MetaNamespace : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaNamespace Parent { get; set; }
        IList<MetaNamespace> Usings { get; }
        IList<MetaNamespace> Namespaces { get; }
        IList<MetaModel> Models { get; }
    
    }
    
    internal class MetaNamespaceImpl : ModelObject, MetaDslx.Core.MetaNamespace
    {
        static MetaNamespaceImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNamespaceImpl() 
            : this(true)
        {
        }
        public MetaNamespaceImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaNamespace.UsingsProperty, new ModelList<MetaNamespace>(this, global::MetaDslx.Core.Meta.MetaNamespace.UsingsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaNamespace.NamespacesProperty, new ModelList<MetaNamespace>(this, global::MetaDslx.Core.Meta.MetaNamespace.NamespacesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaNamespace.ModelsProperty, new ModelList<MetaModel>(this, global::MetaDslx.Core.Meta.MetaNamespace.ModelsProperty));
            MetaImplementationProvider.Implementation.MetaNamespace_MetaNamespace(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaNamespace MetaNamespace.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamespace.ParentProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamespace.ParentProperty, value); }
        }
        
        IList<MetaNamespace> MetaNamespace.Usings
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamespace.UsingsProperty); 
                if (result != null) return (IList<MetaNamespace>)result;
                else return default(IList<MetaNamespace>);
            }
        }
        
        IList<MetaNamespace> MetaNamespace.Namespaces
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamespace.NamespacesProperty); 
                if (result != null) return (IList<MetaNamespace>)result;
                else return default(IList<MetaNamespace>);
            }
        }
        
        IList<MetaModel> MetaNamespace.Models
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamespace.ModelsProperty); 
                if (result != null) return (IList<MetaModel>)result;
                else return default(IList<MetaModel>);
            }
        }
    }
    
    [Scope]
    public interface MetaModel : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        string Uri { get; set; }
        string Prefix { get; set; }
        MetaNamespace Namespace { get; set; }
        IList<MetaType> Types { get; }
        IList<MetaConstant> Constants { get; }
        IList<MetaFunction> Functions { get; }
    
    }
    
    internal class MetaModelImpl : ModelObject, MetaDslx.Core.MetaModel
    {
        static MetaModelImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaModelImpl() 
            : this(true)
        {
        }
        public MetaModelImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.TypesProperty, new ModelList<MetaType>(this, global::MetaDslx.Core.Meta.MetaModel.TypesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.ConstantsProperty, new ModelList<MetaConstant>(this, global::MetaDslx.Core.Meta.MetaModel.ConstantsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.FunctionsProperty, new ModelList<MetaFunction>(this, global::MetaDslx.Core.Meta.MetaModel.FunctionsProperty));
            MetaImplementationProvider.Implementation.MetaModel_MetaModel(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        string MetaModel.Uri
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.UriProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaModel.UriProperty, value); }
        }
        
        string MetaModel.Prefix
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.PrefixProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaModel.PrefixProperty, value); }
        }
        
        MetaNamespace MetaModel.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.NamespaceProperty); 
                if (result != null) return (MetaNamespace)result;
                else return default(MetaNamespace);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaModel.NamespaceProperty, value); }
        }
        
        IList<MetaType> MetaModel.Types
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.TypesProperty); 
                if (result != null) return (IList<MetaType>)result;
                else return default(IList<MetaType>);
            }
        }
        
        IList<MetaConstant> MetaModel.Constants
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.ConstantsProperty); 
                if (result != null) return (IList<MetaConstant>)result;
                else return default(IList<MetaConstant>);
            }
        }
        
        IList<MetaFunction> MetaModel.Functions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.FunctionsProperty); 
                if (result != null) return (IList<MetaFunction>)result;
                else return default(IList<MetaFunction>);
            }
        }
    }
    
    
    public interface MetaDeclaration : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaModel Model { get; set; }
        MetaNamespace Namespace { get; }
    
    }
    
    internal class MetaDeclarationImpl : ModelObject, MetaDslx.Core.MetaDeclaration
    {
        static MetaDeclarationImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaDeclarationImpl() 
            : this(true)
        {
        }
        public MetaDeclarationImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaDeclaration_MetaDeclaration(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty); 
                if (result != null) return (MetaModel)result;
                else return default(MetaModel);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return ((MetaDeclaration)this).Model.Namespace; }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaCollectionTypeImpl() 
            : this(true)
        {
        }
        public MetaCollectionTypeImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            MetaImplementationProvider.Implementation.MetaCollectionType_MetaCollectionType(this);
            this.MMakeDefault();
        }
        
        MetaCollectionKind MetaCollectionType.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaCollectionType.KindProperty); 
                if (result != null) return (MetaCollectionKind)result;
                else return default(MetaCollectionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaCollectionType.KindProperty, value); }
        }
        
        MetaType MetaCollectionType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaCollectionType.InnerTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaCollectionType.InnerTypeProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNullableTypeImpl() 
            : this(true)
        {
        }
        public MetaNullableTypeImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            MetaImplementationProvider.Implementation.MetaNullableType_MetaNullableType(this);
            this.MMakeDefault();
        }
        
        MetaType MetaNullableType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNullableType.InnerTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNullableType.InnerTypeProperty, value); }
        }
    }
    
    
    public interface MetaPrimitiveType : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement
    {
    
    }
    
    internal class MetaPrimitiveTypeImpl : ModelObject, MetaDslx.Core.MetaPrimitiveType
    {
        static MetaPrimitiveTypeImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPrimitiveTypeImpl() 
            : this(true)
        {
        }
        public MetaPrimitiveTypeImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            MetaImplementationProvider.Implementation.MetaPrimitiveType_MetaPrimitiveType(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaEnumImpl() 
            : this(true)
        {
        }
        public MetaEnumImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaEnum.EnumLiteralsProperty, new ModelList<MetaEnumLiteral>(this, global::MetaDslx.Core.Meta.MetaEnum.EnumLiteralsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaEnum.OperationsProperty, new ModelList<MetaOperation>(this, global::MetaDslx.Core.Meta.MetaEnum.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaEnum_MetaEnum(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty); 
                if (result != null) return (MetaModel)result;
                else return default(MetaModel);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return ((MetaDeclaration)this).Model.Namespace; }
        }
        
        IList<MetaEnumLiteral> MetaEnum.EnumLiterals
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaEnum.EnumLiteralsProperty); 
                if (result != null) return (IList<MetaEnumLiteral>)result;
                else return default(IList<MetaEnumLiteral>);
            }
        }
        
        IList<MetaOperation> MetaEnum.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaEnum.OperationsProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaEnumLiteralImpl() 
            : this(true)
        {
        }
        public MetaEnumLiteralImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaEnumLiteral)this).Enum));
            MetaImplementationProvider.Implementation.MetaEnumLiteral_MetaEnumLiteral(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        MetaEnum MetaEnumLiteral.Enum
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaEnumLiteral.EnumProperty); 
                if (result != null) return (MetaEnum)result;
                else return default(MetaEnum);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaEnumLiteral.EnumProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaClassImpl() 
            : this(true)
        {
        }
        public MetaClassImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaClass.SuperClassesProperty, new ModelList<MetaClass>(this, global::MetaDslx.Core.Meta.MetaClass.SuperClassesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaClass.PropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaClass.PropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaClass.OperationsProperty, new ModelList<MetaOperation>(this, global::MetaDslx.Core.Meta.MetaClass.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaClass_MetaClass(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty); 
                if (result != null) return (MetaModel)result;
                else return default(MetaModel);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return ((MetaDeclaration)this).Model.Namespace; }
        }
        
        bool MetaClass.IsAbstract
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaClass.IsAbstractProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaClass.IsAbstractProperty, value); }
        }
        
        IList<MetaClass> MetaClass.SuperClasses
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaClass.SuperClassesProperty); 
                if (result != null) return (IList<MetaClass>)result;
                else return default(IList<MetaClass>);
            }
        }
        
        IList<MetaProperty> MetaClass.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaClass.PropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaOperation> MetaClass.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaClass.OperationsProperty); 
                if (result != null) return (IList<MetaOperation>)result;
                else return default(IList<MetaOperation>);
            }
        }
        
        MetaConstructor MetaClass.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaClass.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaClass.ConstructorProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaFunctionTypeImpl() 
            : this(true)
        {
        }
        public MetaFunctionTypeImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaFunctionType.ParameterTypesProperty, new ModelMultiList<MetaType>(this, global::MetaDslx.Core.Meta.MetaFunctionType.ParameterTypesProperty));
            MetaImplementationProvider.Implementation.MetaFunctionType_MetaFunctionType(this);
            this.MMakeDefault();
        }
        
        IList<MetaType> MetaFunctionType.ParameterTypes
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunctionType.ParameterTypesProperty); 
                if (result != null) return (IList<MetaType>)result;
                else return default(IList<MetaType>);
            }
        }
        
        MetaType MetaFunctionType.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunctionType.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaFunctionType.ReturnTypeProperty, value); }
        }
    }
    
    
    public interface MetaFunction : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        new MetaFunctionType Type { get; }
        IList<MetaParameter> Parameters { get; }
        MetaType ReturnType { get; set; }
    
    }
    
    internal class MetaFunctionImpl : ModelObject, MetaDslx.Core.MetaFunction
    {
        static MetaFunctionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaFunctionImpl() 
            : this(true)
        {
        }
        public MetaFunctionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            // Init global::MetaDslx.Core.Meta.MetaFunction.TypeProperty in MetaImplementation.MetaFunction_MetaFunction
            this.MSet(global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty, new ModelList<MetaParameter>(this, global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaFunction_MetaFunction(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaFunction.TypeProperty)) throw new ModelException("Readonly property Meta.MetaFunction.TypeProperty was not set in MetaFunction_MetaFunction().");
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaFunctionType MetaFunction.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.TypeProperty); 
                if (result != null) return (MetaFunctionType)result;
                else return default(MetaFunctionType);
            }
        }
        
        IList<MetaParameter> MetaFunction.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty); 
                if (result != null) return (IList<MetaParameter>)result;
                else return default(IList<MetaParameter>);
            }
        }
        
        MetaType MetaFunction.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaFunction.ReturnTypeProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOperationImpl() 
            : this(true)
        {
        }
        public MetaOperationImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            // Init global::MetaDslx.Core.Meta.MetaFunction.TypeProperty in MetaImplementation.MetaOperation_MetaOperation
            this.MSet(global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty, new ModelList<MetaParameter>(this, global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaOperation_MetaOperation(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaFunction.TypeProperty)) throw new ModelException("Readonly property Meta.MetaFunction.TypeProperty was not set in MetaOperation_MetaOperation().");
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaFunctionType MetaFunction.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.TypeProperty); 
                if (result != null) return (MetaFunctionType)result;
                else return default(MetaFunctionType);
            }
        }
        
        IList<MetaParameter> MetaFunction.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.ParametersProperty); 
                if (result != null) return (IList<MetaParameter>)result;
                else return default(IList<MetaParameter>);
            }
        }
        
        MetaType MetaFunction.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunction.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaFunction.ReturnTypeProperty, value); }
        }
        
        MetaType MetaOperation.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperation.ParentProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaOperation.ParentProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaConstantImpl() 
            : this(true)
        {
        }
        public MetaConstantImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConstant.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConstant)this).Type));
            MetaImplementationProvider.Implementation.MetaConstant_MetaConstant(this);
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty); 
                if (result != null) return (MetaModel)result;
                else return default(MetaModel);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaDeclaration.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return ((MetaDeclaration)this).Model.Namespace; }
        }
        
        MetaExpression MetaConstant.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConstant.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConstant.ValueProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaConstructorImpl() 
            : this(true)
        {
        }
        public MetaConstructorImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaConstructor.InitializersProperty, new ModelList<MetaPropertyInitializer>(this, global::MetaDslx.Core.Meta.MetaConstructor.InitializersProperty));
            MetaImplementationProvider.Implementation.MetaConstructor_MetaConstructor(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaClass MetaConstructor.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConstructor.ParentProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConstructor.ParentProperty, value); }
        }
        
        IList<MetaPropertyInitializer> MetaConstructor.Initializers
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConstructor.InitializersProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaParameterImpl() 
            : this(true)
        {
        }
        public MetaParameterImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            MetaImplementationProvider.Implementation.MetaParameter_MetaParameter(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaFunction MetaParameter.Function
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaParameter.FunctionProperty); 
                if (result != null) return (MetaFunction)result;
                else return default(MetaFunction);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaParameter.FunctionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPropertyImpl() 
            : this(true)
        {
        }
        public MetaPropertyImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaProperty.OppositePropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaProperty.OppositePropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaProperty.SubsettedPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaProperty.SubsettedPropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaProperty.SubsettingPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaProperty.SubsettingPropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaProperty.RedefinedPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaProperty.RedefinedPropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaProperty.RedefiningPropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaProperty.RedefiningPropertiesProperty));
            MetaImplementationProvider.Implementation.MetaProperty_MetaProperty(this);
            this.MMakeDefault();
        }
        
        string MetaNamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNamedElement.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        IList<MetaAnnotation> MetaAnnotatedElement.Annotations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty); 
                if (result != null) return (IList<MetaAnnotation>)result;
                else return default(IList<MetaAnnotation>);
            }
        }
        
        MetaPropertyKind MetaProperty.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.KindProperty); 
                if (result != null) return (MetaPropertyKind)result;
                else return default(MetaPropertyKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaProperty.KindProperty, value); }
        }
        
        MetaClass MetaProperty.Class
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.ClassProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaProperty.ClassProperty, value); }
        }
        
        IList<MetaProperty> MetaProperty.OppositeProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.OppositePropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.SubsettedProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.SubsettedPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.SubsettingProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.SubsettingPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.RedefinedProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.RedefinedPropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaProperty> MetaProperty.RedefiningProperties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.RedefiningPropertiesProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPropertyInitializerImpl() 
            : this(true)
        {
        }
        public MetaPropertyInitializerImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaPropertyInitializer)this)) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaPropertyInitializer_MetaPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, value); }
        }
    }
    
    
    public interface MetaSynthetizedPropertyInitializer : MetaDslx.Core.MetaPropertyInitializer
    {
    
    }
    
    internal class MetaSynthetizedPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaSynthetizedPropertyInitializer
    {
        static MetaSynthetizedPropertyInitializerImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaSynthetizedPropertyInitializerImpl() 
            : this(true)
        {
        }
        public MetaSynthetizedPropertyInitializerImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaPropertyInitializer)this)) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaInheritedPropertyInitializerImpl() 
            : this(true)
        {
        }
        public MetaInheritedPropertyInitializerImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaInheritedPropertyInitializer)this).Object) as MetaClass));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaInheritedPropertyInitializer)this).PropertyContext }, ResolveKind.Name, ((MetaInheritedPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaInheritedPropertyInitializer)this).ObjectName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaConstructor MetaPropertyInitializer.Constructor
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty); 
                if (result != null) return (MetaConstructor)result;
                else return default(MetaConstructor);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ConstructorProperty, value); }
        }
        
        string MetaPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaClass MetaPropertyInitializer.PropertyContext
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyContextProperty, value); }
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, value); }
        }
        
        string MetaInheritedPropertyInitializer.ObjectName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectNameProperty, value); }
        }
        
        MetaProperty MetaInheritedPropertyInitializer.Object
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaExpressionImpl() 
            : this(true)
        {
        }
        public MetaExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaExpression_MetaExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaExpression_MetaExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBracketExpressionImpl() 
            : this(true)
        {
        }
        public MetaBracketExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaBracketExpression)this).Expression.Type));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBracketExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaBracketExpression)this).ExpectedType));
            MetaImplementationProvider.Implementation.MetaBracketExpression_MetaBracketExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBracketExpression_MetaBracketExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaExpression MetaBracketExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBracketExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBracketExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBoundExpressionImpl() 
            : this(true)
        {
        }
        public MetaBoundExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            MetaImplementationProvider.Implementation.MetaBoundExpression_MetaBoundExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBoundExpression_MetaBoundExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaThisExpressionImpl() 
            : this(true)
        {
        }
        public MetaThisExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.GetCurrentTypeScopeOf((ModelObject)((MetaThisExpression)this))));
            MetaImplementationProvider.Implementation.MetaThisExpression_MetaThisExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaThisExpression_MetaThisExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNullExpressionImpl() 
            : this(true)
        {
        }
        public MetaNullExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaNullExpression_MetaNullExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNullExpression_MetaNullExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeConversionExpressionImpl() 
            : this(true)
        {
        }
        public MetaTypeConversionExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeConversionExpression_MetaTypeConversionExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaTypeConversionExpression_MetaTypeConversionExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeAsExpression : MetaDslx.Core.MetaTypeConversionExpression
    {
    
    }
    
    internal class MetaTypeAsExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeAsExpression
    {
        static MetaTypeAsExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeAsExpressionImpl() 
            : this(true)
        {
        }
        public MetaTypeAsExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeAsExpression_MetaTypeAsExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaTypeAsExpression_MetaTypeAsExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaTypeCastExpression : MetaDslx.Core.MetaTypeConversionExpression
    {
    
    }
    
    internal class MetaTypeCastExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeCastExpression
    {
        static MetaTypeCastExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeCastExpressionImpl() 
            : this(true)
        {
        }
        public MetaTypeCastExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaTypeConversionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeCastExpression_MetaTypeCastExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaTypeCastExpression_MetaTypeCastExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeCheckExpressionImpl() 
            : this(true)
        {
        }
        public MetaTypeCheckExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => Meta.Constants.Bool));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Any));
            MetaImplementationProvider.Implementation.MetaTypeCheckExpression_MetaTypeCheckExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaTypeCheckExpression_MetaTypeCheckExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeCheckExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.TypeReferenceProperty, value); }
        }
        
        MetaExpression MetaTypeCheckExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaTypeOfExpressionImpl() 
            : this(true)
        {
        }
        public MetaTypeOfExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => global::MetaDslx.Core.Meta.MetaType.Instance));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaTypeOfExpression_MetaTypeOfExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaTypeOfExpression_MetaTypeOfExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaType MetaTypeOfExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypeOfExpression.TypeReferenceProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypeOfExpression.TypeReferenceProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaConditionalExpressionImpl() 
            : this(true)
        {
        }
        public MetaConditionalExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.Balance((ModelObject)((MetaConditionalExpression)this).Then.Type, (ModelObject)((MetaConditionalExpression)this).Else.Type)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ConditionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.Bool));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ThenProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConditionalExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ElseProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaConditionalExpression)this).ExpectedType));
            MetaImplementationProvider.Implementation.MetaConditionalExpression_MetaConditionalExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaConditionalExpression_MetaConditionalExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaExpression MetaConditionalExpression.Condition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ConditionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ConditionProperty, value); }
        }
        
        MetaType MetaConditionalExpression.BalancedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConditionalExpression.BalancedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConditionalExpression.BalancedTypeProperty, value); }
        }
        
        MetaExpression MetaConditionalExpression.Then
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ThenProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ThenProperty, value); }
        }
        
        MetaExpression MetaConditionalExpression.Else
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ElseProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConditionalExpression.ElseProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaConstantExpressionImpl() 
            : this(true)
        {
        }
        public MetaConstantExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaConstantExpression)this).Value)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            MetaImplementationProvider.Implementation.MetaConstantExpression_MetaConstantExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaConstantExpression_MetaConstantExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        object MetaConstantExpression.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaConstantExpression.ValueProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaConstantExpression.ValueProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaIdentifierExpressionImpl() 
            : this(true)
        {
        }
        public MetaIdentifierExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaIdentifierExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            MetaImplementationProvider.Implementation.MetaIdentifierExpression_MetaIdentifierExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaIdentifierExpression_MetaIdentifierExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaIdentifierExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaIdentifierExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaIdentifierExpression.NameProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaMemberAccessExpressionImpl() 
            : this(true)
        {
        }
        public MetaMemberAccessExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaMemberAccessExpression)this).Expression.Type }, ResolveKind.Name, ((MetaMemberAccessExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.None));
            MetaImplementationProvider.Implementation.MetaMemberAccessExpression_MetaMemberAccessExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaMemberAccessExpression_MetaMemberAccessExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaMemberAccessExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.ExpressionProperty, value); }
        }
        
        string MetaMemberAccessExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaMemberAccessExpression.NameProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaFunctionCallExpressionImpl() 
            : this(true)
        {
        }
        public MetaFunctionCallExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetReturnTypeOf((ModelObject)((MetaFunctionCallExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaFunctionCallExpression)this).Expression is MetaBoundExpression ? (((MetaBoundExpression)((MetaFunctionCallExpression)this).Expression).Definitions).Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is MetaFunctionType).OfType<ModelObject>().ToList() : null));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.None));
            MetaImplementationProvider.Implementation.MetaFunctionCallExpression_MetaFunctionCallExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaFunctionCallExpression_MetaFunctionCallExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaFunctionCallExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaIndexerExpressionImpl() 
            : this(true)
        {
        }
        public MetaIndexerExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaIndexerExpression)this).Expression is MetaBoundExpression ? ((((MetaBoundExpression)((MetaIndexerExpression)this).Expression).Definitions).Where(e => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(e) is MetaFunctionType).OfType<ModelObject>().ToList()).Where(e => ModelContext.Current.Compiler.NameProvider.GetNameOf((ModelObject)e) == "operator[]").OfType<ModelObject>().ToList() : null));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaIndexerExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaIndexerExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Meta.Constants.None));
            MetaImplementationProvider.Implementation.MetaIndexerExpression_MetaIndexerExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaIndexerExpression_MetaIndexerExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        MetaExpression MetaIndexerExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaIndexerExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaIndexerExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNewExpressionImpl() 
            : this(true)
        {
        }
        public MetaNewExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaNewExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MSet(global::MetaDslx.Core.Meta.MetaNewExpression.PropertyInitializersProperty, new ModelList<MetaNewPropertyInitializer>(this, global::MetaDslx.Core.Meta.MetaNewExpression.PropertyInitializersProperty));
            MetaImplementationProvider.Implementation.MetaNewExpression_MetaNewExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNewExpression_MetaNewExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaClass MetaNewExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewExpression.TypeReferenceProperty); 
                if (result != null) return (MetaClass)result;
                else return default(MetaClass);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewExpression.TypeReferenceProperty, value); }
        }
        
        IList<MetaNewPropertyInitializer> MetaNewExpression.PropertyInitializers
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewExpression.PropertyInitializersProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNewPropertyInitializerImpl() 
            : this(true)
        {
        }
        public MetaNewPropertyInitializerImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)((MetaNewPropertyInitializer)this).Parent.Type }, ResolveKind.Name, ((MetaNewPropertyInitializer)this).PropertyName, new ResolutionInfo(), ResolveFlags.All), new BindingInfo())));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaNewPropertyInitializer)this).Property)));
            MetaImplementationProvider.Implementation.MetaNewPropertyInitializer_MetaNewPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaNewExpression MetaNewPropertyInitializer.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.ParentProperty); 
                if (result != null) return (MetaNewExpression)result;
                else return default(MetaNewExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.ParentProperty, value); }
        }
        
        string MetaNewPropertyInitializer.PropertyName
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.PropertyNameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.PropertyNameProperty, value); }
        }
        
        MetaExpression MetaNewPropertyInitializer.Value
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.ValueProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.ValueProperty, value); }
        }
        
        MetaProperty MetaNewPropertyInitializer.Property
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.PropertyProperty); 
                if (result != null) return (MetaProperty)result;
                else return default(MetaProperty);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewPropertyInitializer.PropertyProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNewCollectionExpressionImpl() 
            : this(true)
        {
        }
        public MetaNewCollectionExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ((MetaNewCollectionExpression)this).TypeReference));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MSet(global::MetaDslx.Core.Meta.MetaNewCollectionExpression.ValuesProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaNewCollectionExpression.ValuesProperty));
            MetaImplementationProvider.Implementation.MetaNewCollectionExpression_MetaNewCollectionExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNewCollectionExpression_MetaNewCollectionExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        MetaCollectionType MetaNewCollectionExpression.TypeReference
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewCollectionExpression.TypeReferenceProperty); 
                if (result != null) return (MetaCollectionType)result;
                else return default(MetaCollectionType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaNewCollectionExpression.TypeReferenceProperty, value); }
        }
        
        IList<MetaExpression> MetaNewCollectionExpression.Values
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNewCollectionExpression.ValuesProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOperatorExpressionImpl() 
            : this(true)
        {
        }
        public MetaOperatorExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaOperatorExpression_MetaOperatorExpression
            MetaImplementationProvider.Implementation.MetaOperatorExpression_MetaOperatorExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaOperatorExpression_MetaOperatorExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaOperatorExpression_MetaOperatorExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaUnaryExpressionImpl() 
            : this(true)
        {
        }
        public MetaUnaryExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryExpression_MetaUnaryExpression
            MetaImplementationProvider.Implementation.MetaUnaryExpression_MetaUnaryExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryExpression_MetaUnaryExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaUnaryExpression_MetaUnaryExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaUnaryPlusExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaUnaryPlusExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryPlusExpression
    {
        static MetaUnaryPlusExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaUnaryPlusExpressionImpl() 
            : this(true)
        {
        }
        public MetaUnaryPlusExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator+()"));
            MetaImplementationProvider.Implementation.MetaUnaryPlusExpression_MetaUnaryPlusExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryPlusExpression_MetaUnaryPlusExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaUnaryPlusExpression_MetaUnaryPlusExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaNegateExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaNegateExpressionImpl : ModelObject, MetaDslx.Core.MetaNegateExpression
    {
        static MetaNegateExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNegateExpressionImpl() 
            : this(true)
        {
        }
        public MetaNegateExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator-()"));
            MetaImplementationProvider.Implementation.MetaNegateExpression_MetaNegateExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNegateExpression_MetaNegateExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaNegateExpression_MetaNegateExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaOnesComplementExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaOnesComplementExpressionImpl : ModelObject, MetaDslx.Core.MetaOnesComplementExpression
    {
        static MetaOnesComplementExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOnesComplementExpressionImpl() 
            : this(true)
        {
        }
        public MetaOnesComplementExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator~()"));
            MetaImplementationProvider.Implementation.MetaOnesComplementExpression_MetaOnesComplementExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaOnesComplementExpression_MetaOnesComplementExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaOnesComplementExpression_MetaOnesComplementExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaNotExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaNotExpressionImpl : ModelObject, MetaDslx.Core.MetaNotExpression
    {
        static MetaNotExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNotExpressionImpl() 
            : this(true)
        {
        }
        public MetaNotExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator!()"));
            MetaImplementationProvider.Implementation.MetaNotExpression_MetaNotExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNotExpression_MetaNotExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaNotExpression_MetaNotExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaUnaryAssignExpression : MetaDslx.Core.MetaUnaryExpression
    {
    
    }
    
    internal class MetaUnaryAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryAssignExpression
    {
        static MetaUnaryAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaUnaryAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaUnaryAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression
            MetaImplementationProvider.Implementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaUnaryAssignExpression_MetaUnaryAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaUnaryAssignExpression_MetaUnaryAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPostIncrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPostIncrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPostIncrementAssignExpression
    {
        static MetaPostIncrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPostIncrementAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaPostIncrementAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()++"));
            MetaImplementationProvider.Implementation.MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPostDecrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPostDecrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPostDecrementAssignExpression
    {
        static MetaPostDecrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPostDecrementAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaPostDecrementAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()--"));
            MetaImplementationProvider.Implementation.MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPreIncrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPreIncrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPreIncrementAssignExpression
    {
        static MetaPreIncrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPreIncrementAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaPreIncrementAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator++()"));
            MetaImplementationProvider.Implementation.MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
        }
    }
    
    
    public interface MetaPreDecrementAssignExpression : MetaDslx.Core.MetaUnaryAssignExpression
    {
    
    }
    
    internal class MetaPreDecrementAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaPreDecrementAssignExpression
    {
        static MetaPreDecrementAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaPreDecrementAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaPreDecrementAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator--()"));
            MetaImplementationProvider.Implementation.MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaUnaryExpression.Expression
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaUnaryExpression.ExpressionProperty, value); }
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
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBinaryExpressionImpl() 
            : this(true)
        {
        }
        public MetaBinaryExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryExpression_MetaBinaryExpression
            MetaImplementationProvider.Implementation.MetaBinaryExpression_MetaBinaryExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryExpression_MetaBinaryExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaBinaryExpression_MetaBinaryExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryArithmeticExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryArithmeticExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryArithmeticExpression
    {
        static MetaBinaryArithmeticExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBinaryArithmeticExpressionImpl() 
            : this(true)
        {
        }
        public MetaBinaryArithmeticExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression
            MetaImplementationProvider.Implementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaMultiplyExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaMultiplyExpressionImpl : ModelObject, MetaDslx.Core.MetaMultiplyExpression
    {
        static MetaMultiplyExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaMultiplyExpressionImpl() 
            : this(true)
        {
        }
        public MetaMultiplyExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()*()"));
            MetaImplementationProvider.Implementation.MetaMultiplyExpression_MetaMultiplyExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaMultiplyExpression_MetaMultiplyExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaMultiplyExpression_MetaMultiplyExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaDivideExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaDivideExpressionImpl : ModelObject, MetaDslx.Core.MetaDivideExpression
    {
        static MetaDivideExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaDivideExpressionImpl() 
            : this(true)
        {
        }
        public MetaDivideExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()/()"));
            MetaImplementationProvider.Implementation.MetaDivideExpression_MetaDivideExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaDivideExpression_MetaDivideExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaDivideExpression_MetaDivideExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaModuloExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaModuloExpressionImpl : ModelObject, MetaDslx.Core.MetaModuloExpression
    {
        static MetaModuloExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaModuloExpressionImpl() 
            : this(true)
        {
        }
        public MetaModuloExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()%()"));
            MetaImplementationProvider.Implementation.MetaModuloExpression_MetaModuloExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaModuloExpression_MetaModuloExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaModuloExpression_MetaModuloExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAddExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaAddExpressionImpl : ModelObject, MetaDslx.Core.MetaAddExpression
    {
        static MetaAddExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAddExpressionImpl() 
            : this(true)
        {
        }
        public MetaAddExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()+()"));
            MetaImplementationProvider.Implementation.MetaAddExpression_MetaAddExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAddExpression_MetaAddExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAddExpression_MetaAddExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaSubtractExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaSubtractExpressionImpl : ModelObject, MetaDslx.Core.MetaSubtractExpression
    {
        static MetaSubtractExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaSubtractExpressionImpl() 
            : this(true)
        {
        }
        public MetaSubtractExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()-()"));
            MetaImplementationProvider.Implementation.MetaSubtractExpression_MetaSubtractExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaSubtractExpression_MetaSubtractExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaSubtractExpression_MetaSubtractExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLeftShiftExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaLeftShiftExpressionImpl : ModelObject, MetaDslx.Core.MetaLeftShiftExpression
    {
        static MetaLeftShiftExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaLeftShiftExpressionImpl() 
            : this(true)
        {
        }
        public MetaLeftShiftExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<<()"));
            MetaImplementationProvider.Implementation.MetaLeftShiftExpression_MetaLeftShiftExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaLeftShiftExpression_MetaLeftShiftExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaLeftShiftExpression_MetaLeftShiftExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaRightShiftExpression : MetaDslx.Core.MetaBinaryArithmeticExpression
    {
    
    }
    
    internal class MetaRightShiftExpressionImpl : ModelObject, MetaDslx.Core.MetaRightShiftExpression
    {
        static MetaRightShiftExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaRightShiftExpressionImpl() 
            : this(true)
        {
        }
        public MetaRightShiftExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>>()"));
            MetaImplementationProvider.Implementation.MetaRightShiftExpression_MetaRightShiftExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaRightShiftExpression_MetaRightShiftExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaRightShiftExpression_MetaRightShiftExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryComparisonExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryComparisonExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryComparisonExpression
    {
        static MetaBinaryComparisonExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBinaryComparisonExpressionImpl() 
            : this(true)
        {
        }
        public MetaBinaryComparisonExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression
            MetaImplementationProvider.Implementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryComparisonExpression_MetaBinaryComparisonExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaBinaryComparisonExpression_MetaBinaryComparisonExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLessThanExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaLessThanExpressionImpl : ModelObject, MetaDslx.Core.MetaLessThanExpression
    {
        static MetaLessThanExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaLessThanExpressionImpl() 
            : this(true)
        {
        }
        public MetaLessThanExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<()"));
            MetaImplementationProvider.Implementation.MetaLessThanExpression_MetaLessThanExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaLessThanExpression_MetaLessThanExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaLessThanExpression_MetaLessThanExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLessThanOrEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaLessThanOrEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaLessThanOrEqualExpression
    {
        static MetaLessThanOrEqualExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaLessThanOrEqualExpressionImpl() 
            : this(true)
        {
        }
        public MetaLessThanOrEqualExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<=()"));
            MetaImplementationProvider.Implementation.MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaGreaterThanExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaGreaterThanExpressionImpl : ModelObject, MetaDslx.Core.MetaGreaterThanExpression
    {
        static MetaGreaterThanExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaGreaterThanExpressionImpl() 
            : this(true)
        {
        }
        public MetaGreaterThanExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>()"));
            MetaImplementationProvider.Implementation.MetaGreaterThanExpression_MetaGreaterThanExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaGreaterThanExpression_MetaGreaterThanExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaGreaterThanExpression_MetaGreaterThanExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaGreaterThanOrEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaGreaterThanOrEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaGreaterThanOrEqualExpression
    {
        static MetaGreaterThanOrEqualExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaGreaterThanOrEqualExpressionImpl() 
            : this(true)
        {
        }
        public MetaGreaterThanOrEqualExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>=()"));
            MetaImplementationProvider.Implementation.MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaEqualExpression
    {
        static MetaEqualExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaEqualExpressionImpl() 
            : this(true)
        {
        }
        public MetaEqualExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()==()"));
            MetaImplementationProvider.Implementation.MetaEqualExpression_MetaEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaEqualExpression_MetaEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaEqualExpression_MetaEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaNotEqualExpression : MetaDslx.Core.MetaBinaryComparisonExpression
    {
    
    }
    
    internal class MetaNotEqualExpressionImpl : ModelObject, MetaDslx.Core.MetaNotEqualExpression
    {
        static MetaNotEqualExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNotEqualExpressionImpl() 
            : this(true)
        {
        }
        public MetaNotEqualExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()!=()"));
            MetaImplementationProvider.Implementation.MetaNotEqualExpression_MetaNotEqualExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNotEqualExpression_MetaNotEqualExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaNotEqualExpression_MetaNotEqualExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaBinaryLogicalExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryLogicalExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryLogicalExpression
    {
        static MetaBinaryLogicalExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBinaryLogicalExpressionImpl() 
            : this(true)
        {
        }
        public MetaBinaryLogicalExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression
            MetaImplementationProvider.Implementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaBinaryLogicalExpression_MetaBinaryLogicalExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaBinaryLogicalExpression_MetaBinaryLogicalExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaAndExpressionImpl : ModelObject, MetaDslx.Core.MetaAndExpression
    {
        static MetaAndExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAndExpressionImpl() 
            : this(true)
        {
        }
        public MetaAndExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&()"));
            MetaImplementationProvider.Implementation.MetaAndExpression_MetaAndExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAndExpression_MetaAndExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAndExpression_MetaAndExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaOrExpressionImpl : ModelObject, MetaDslx.Core.MetaOrExpression
    {
        static MetaOrExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOrExpressionImpl() 
            : this(true)
        {
        }
        public MetaOrExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()|()"));
            MetaImplementationProvider.Implementation.MetaOrExpression_MetaOrExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaOrExpression_MetaOrExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaOrExpression_MetaOrExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaExclusiveOrExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaExclusiveOrExpressionImpl : ModelObject, MetaDslx.Core.MetaExclusiveOrExpression
    {
        static MetaExclusiveOrExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaExclusiveOrExpressionImpl() 
            : this(true)
        {
        }
        public MetaExclusiveOrExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()^()"));
            MetaImplementationProvider.Implementation.MetaExclusiveOrExpression_MetaExclusiveOrExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaExclusiveOrExpression_MetaExclusiveOrExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaExclusiveOrExpression_MetaExclusiveOrExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndAlsoExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaAndAlsoExpressionImpl : ModelObject, MetaDslx.Core.MetaAndAlsoExpression
    {
        static MetaAndAlsoExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAndAlsoExpressionImpl() 
            : this(true)
        {
        }
        public MetaAndAlsoExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&&()"));
            MetaImplementationProvider.Implementation.MetaAndAlsoExpression_MetaAndAlsoExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAndAlsoExpression_MetaAndAlsoExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAndAlsoExpression_MetaAndAlsoExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrElseExpression : MetaDslx.Core.MetaBinaryLogicalExpression
    {
    
    }
    
    internal class MetaOrElseExpressionImpl : ModelObject, MetaDslx.Core.MetaOrElseExpression
    {
        static MetaOrElseExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOrElseExpressionImpl() 
            : this(true)
        {
        }
        public MetaOrElseExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()||()"));
            MetaImplementationProvider.Implementation.MetaOrElseExpression_MetaOrElseExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaOrElseExpression_MetaOrElseExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaOrElseExpression_MetaOrElseExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaNullCoalescingExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaNullCoalescingExpressionImpl : ModelObject, MetaDslx.Core.MetaNullCoalescingExpression
    {
        static MetaNullCoalescingExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNullCoalescingExpressionImpl() 
            : this(true)
        {
        }
        public MetaNullCoalescingExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaBoundExpression)this).Definition)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()??()"));
            MetaImplementationProvider.Implementation.MetaNullCoalescingExpression_MetaNullCoalescingExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaNullCoalescingExpression_MetaNullCoalescingExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaNullCoalescingExpression_MetaNullCoalescingExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAssignmentExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaAssignmentExpression
    {
        static MetaAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAssignmentExpressionImpl() 
            : this(true)
        {
        }
        public MetaAssignmentExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaAssignmentExpression_MetaAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAssignmentExpression_MetaAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAssignmentExpression_MetaAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAssignmentExpression_MetaAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAssignExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAssignExpression
    {
        static MetaAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAssignExpression_MetaAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAssignExpression_MetaAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAssignExpression_MetaAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaArithmeticAssignmentExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaArithmeticAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
        static MetaArithmeticAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaArithmeticAssignmentExpressionImpl() 
            : this(true)
        {
        }
        public MetaArithmeticAssignmentExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaMultiplyAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaMultiplyAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaMultiplyAssignExpression
    {
        static MetaMultiplyAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaMultiplyAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaMultiplyAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()*=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaMultiplyAssignExpression_MetaMultiplyAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaMultiplyAssignExpression_MetaMultiplyAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaDivideAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaDivideAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaDivideAssignExpression
    {
        static MetaDivideAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaDivideAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaDivideAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()/=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaDivideAssignExpression_MetaDivideAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaDivideAssignExpression_MetaDivideAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaDivideAssignExpression_MetaDivideAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaModuloAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaModuloAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaModuloAssignExpression
    {
        static MetaModuloAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaModuloAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaModuloAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()%=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaModuloAssignExpression_MetaModuloAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaModuloAssignExpression_MetaModuloAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaModuloAssignExpression_MetaModuloAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAddAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaAddAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAddAssignExpression
    {
        static MetaAddAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAddAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaAddAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()+=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAddAssignExpression_MetaAddAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAddAssignExpression_MetaAddAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAddAssignExpression_MetaAddAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaSubtractAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaSubtractAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaSubtractAssignExpression
    {
        static MetaSubtractAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaSubtractAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaSubtractAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()-=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaSubtractAssignExpression_MetaSubtractAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaSubtractAssignExpression_MetaSubtractAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaSubtractAssignExpression_MetaSubtractAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLeftShiftAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaLeftShiftAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaLeftShiftAssignExpression
    {
        static MetaLeftShiftAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaLeftShiftAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaLeftShiftAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()<<=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaRightShiftAssignExpression : MetaDslx.Core.MetaArithmeticAssignmentExpression
    {
    
    }
    
    internal class MetaRightShiftAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaRightShiftAssignExpression
    {
        static MetaRightShiftAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaRightShiftAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaRightShiftAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()>>=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaRightShiftAssignExpression_MetaRightShiftAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaRightShiftAssignExpression_MetaRightShiftAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaLogicalAssignmentExpression : MetaDslx.Core.MetaAssignmentExpression
    {
    
    }
    
    internal class MetaLogicalAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaLogicalAssignmentExpression
    {
        static MetaLogicalAssignmentExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaLogicalAssignmentExpressionImpl() 
            : this(true)
        {
        }
        public MetaLogicalAssignmentExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaAndAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaAndAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaAndAssignExpression
    {
        static MetaAndAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAndAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaAndAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()&=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaAndAssignExpression_MetaAndAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaAndAssignExpression_MetaAndAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaAndAssignExpression_MetaAndAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaExclusiveOrAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaExclusiveOrAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaExclusiveOrAssignExpression
    {
        static MetaExclusiveOrAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaExclusiveOrAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaExclusiveOrAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()^=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    
    public interface MetaOrAssignExpression : MetaDslx.Core.MetaLogicalAssignmentExpression
    {
    
    }
    
    internal class MetaOrAssignExpressionImpl : ModelObject, MetaDslx.Core.MetaOrAssignExpression
    {
        static MetaOrAssignExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaOrAssignExpressionImpl() 
            : this(true)
        {
        }
        public MetaOrAssignExpressionImpl(bool addToModelContext) 
            : base(addToModelContext)
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.GetTypeOf(((MetaAssignmentExpression)this).Left)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ModelContext.Current.Compiler.TypeProvider.TypeCheck((ModelObject)((MetaExpression)this))));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ModelContext.Current.Compiler.ResolutionProvider.Resolve(new ModelObject[] { ModelContext.Current.Compiler.ResolutionProvider.GetCurrentScope(this) }, ResolveKind.Name, ((MetaOperatorExpression)this).Name, new ResolutionInfo(), ResolveFlags.All)));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ModelContext.Current.Compiler.BindingProvider.Bind(this, ((MetaBoundExpression)this).Definitions, new BindingInfo())));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => "operator()|=()"));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).ExpectedType));
            this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ((MetaAssignmentExpression)this).Type));
            MetaImplementationProvider.Implementation.MetaOrAssignExpression_MetaOrAssignExpression(this);
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty)) throw new ModelException("Readonly property Meta.MetaExpression.NoTypeErrorProperty was not set in MetaOrAssignExpression_MetaOrAssignExpression().");
            if (!this.MIsSet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty)) throw new ModelException("Readonly property Meta.MetaOperatorExpression.NameProperty was not set in MetaOrAssignExpression_MetaOrAssignExpression().");
            this.MMakeDefault();
        }
        
        MetaType MetaTypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, value); }
        }
        
        bool MetaExpression.NoTypeError
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
        }
        
        bool MetaBoundExpression.UniqueDefinition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.UniqueDefinitionProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
        }
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<ModelObject> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<ModelObject>)result;
                else return default(IList<ModelObject>);
            }
        }
        
        ModelObject MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (ModelObject)result;
                else return default(ModelObject);
            }
        }
        
        string MetaOperatorExpression.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty); 
                if (result != null) return (MetaExpression)result;
                else return default(MetaExpression);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, value); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class MetaModelFactory : ModelFactory
    {
        private static MetaModelFactory instance = new MetaModelFactory();
    
    	private MetaModelFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static MetaModelFactory Instance
        {
            get { return MetaModelFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of MetaAnnotation.
        /// </summary>
        public MetaAnnotation CreateMetaAnnotation(bool addToModelContext = true)
    	{
    		MetaAnnotation result = new global::MetaDslx.Core.MetaAnnotationImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAnnotationProperty.
        /// </summary>
        public MetaAnnotationProperty CreateMetaAnnotationProperty(bool addToModelContext = true)
    	{
    		MetaAnnotationProperty result = new global::MetaDslx.Core.MetaAnnotationPropertyImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNamespace.
        /// </summary>
        public MetaNamespace CreateMetaNamespace(bool addToModelContext = true)
    	{
    		MetaNamespace result = new global::MetaDslx.Core.MetaNamespaceImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModel.
        /// </summary>
        public MetaModel CreateMetaModel(bool addToModelContext = true)
    	{
    		MetaModel result = new global::MetaDslx.Core.MetaModelImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaCollectionType.
        /// </summary>
        public MetaCollectionType CreateMetaCollectionType(bool addToModelContext = true)
    	{
    		MetaCollectionType result = new global::MetaDslx.Core.MetaCollectionTypeImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullableType.
        /// </summary>
        public MetaNullableType CreateMetaNullableType(bool addToModelContext = true)
    	{
    		MetaNullableType result = new global::MetaDslx.Core.MetaNullableTypeImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPrimitiveType.
        /// </summary>
        public MetaPrimitiveType CreateMetaPrimitiveType(bool addToModelContext = true)
    	{
    		MetaPrimitiveType result = new global::MetaDslx.Core.MetaPrimitiveTypeImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnum.
        /// </summary>
        public MetaEnum CreateMetaEnum(bool addToModelContext = true)
    	{
    		MetaEnum result = new global::MetaDslx.Core.MetaEnumImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnumLiteral.
        /// </summary>
        public MetaEnumLiteral CreateMetaEnumLiteral(bool addToModelContext = true)
    	{
    		MetaEnumLiteral result = new global::MetaDslx.Core.MetaEnumLiteralImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaClass.
        /// </summary>
        public MetaClass CreateMetaClass(bool addToModelContext = true)
    	{
    		MetaClass result = new global::MetaDslx.Core.MetaClassImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunctionType.
        /// </summary>
        public MetaFunctionType CreateMetaFunctionType(bool addToModelContext = true)
    	{
    		MetaFunctionType result = new global::MetaDslx.Core.MetaFunctionTypeImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunction.
        /// </summary>
        public MetaFunction CreateMetaFunction(bool addToModelContext = true)
    	{
    		MetaFunction result = new global::MetaDslx.Core.MetaFunctionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOperation.
        /// </summary>
        public MetaOperation CreateMetaOperation(bool addToModelContext = true)
    	{
    		MetaOperation result = new global::MetaDslx.Core.MetaOperationImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstant.
        /// </summary>
        public MetaConstant CreateMetaConstant(bool addToModelContext = true)
    	{
    		MetaConstant result = new global::MetaDslx.Core.MetaConstantImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstructor.
        /// </summary>
        public MetaConstructor CreateMetaConstructor(bool addToModelContext = true)
    	{
    		MetaConstructor result = new global::MetaDslx.Core.MetaConstructorImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaParameter.
        /// </summary>
        public MetaParameter CreateMetaParameter(bool addToModelContext = true)
    	{
    		MetaParameter result = new global::MetaDslx.Core.MetaParameterImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaProperty.
        /// </summary>
        public MetaProperty CreateMetaProperty(bool addToModelContext = true)
    	{
    		MetaProperty result = new global::MetaDslx.Core.MetaPropertyImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSynthetizedPropertyInitializer.
        /// </summary>
        public MetaSynthetizedPropertyInitializer CreateMetaSynthetizedPropertyInitializer(bool addToModelContext = true)
    	{
    		MetaSynthetizedPropertyInitializer result = new global::MetaDslx.Core.MetaSynthetizedPropertyInitializerImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaInheritedPropertyInitializer.
        /// </summary>
        public MetaInheritedPropertyInitializer CreateMetaInheritedPropertyInitializer(bool addToModelContext = true)
    	{
    		MetaInheritedPropertyInitializer result = new global::MetaDslx.Core.MetaInheritedPropertyInitializerImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaBracketExpression.
        /// </summary>
        public MetaBracketExpression CreateMetaBracketExpression(bool addToModelContext = true)
    	{
    		MetaBracketExpression result = new global::MetaDslx.Core.MetaBracketExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaThisExpression.
        /// </summary>
        public MetaThisExpression CreateMetaThisExpression(bool addToModelContext = true)
    	{
    		MetaThisExpression result = new global::MetaDslx.Core.MetaThisExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullExpression.
        /// </summary>
        public MetaNullExpression CreateMetaNullExpression(bool addToModelContext = true)
    	{
    		MetaNullExpression result = new global::MetaDslx.Core.MetaNullExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeAsExpression.
        /// </summary>
        public MetaTypeAsExpression CreateMetaTypeAsExpression(bool addToModelContext = true)
    	{
    		MetaTypeAsExpression result = new global::MetaDslx.Core.MetaTypeAsExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeCastExpression.
        /// </summary>
        public MetaTypeCastExpression CreateMetaTypeCastExpression(bool addToModelContext = true)
    	{
    		MetaTypeCastExpression result = new global::MetaDslx.Core.MetaTypeCastExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeCheckExpression.
        /// </summary>
        public MetaTypeCheckExpression CreateMetaTypeCheckExpression(bool addToModelContext = true)
    	{
    		MetaTypeCheckExpression result = new global::MetaDslx.Core.MetaTypeCheckExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaTypeOfExpression.
        /// </summary>
        public MetaTypeOfExpression CreateMetaTypeOfExpression(bool addToModelContext = true)
    	{
    		MetaTypeOfExpression result = new global::MetaDslx.Core.MetaTypeOfExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConditionalExpression.
        /// </summary>
        public MetaConditionalExpression CreateMetaConditionalExpression(bool addToModelContext = true)
    	{
    		MetaConditionalExpression result = new global::MetaDslx.Core.MetaConditionalExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstantExpression.
        /// </summary>
        public MetaConstantExpression CreateMetaConstantExpression(bool addToModelContext = true)
    	{
    		MetaConstantExpression result = new global::MetaDslx.Core.MetaConstantExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaIdentifierExpression.
        /// </summary>
        public MetaIdentifierExpression CreateMetaIdentifierExpression(bool addToModelContext = true)
    	{
    		MetaIdentifierExpression result = new global::MetaDslx.Core.MetaIdentifierExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMemberAccessExpression.
        /// </summary>
        public MetaMemberAccessExpression CreateMetaMemberAccessExpression(bool addToModelContext = true)
    	{
    		MetaMemberAccessExpression result = new global::MetaDslx.Core.MetaMemberAccessExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunctionCallExpression.
        /// </summary>
        public MetaFunctionCallExpression CreateMetaFunctionCallExpression(bool addToModelContext = true)
    	{
    		MetaFunctionCallExpression result = new global::MetaDslx.Core.MetaFunctionCallExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaIndexerExpression.
        /// </summary>
        public MetaIndexerExpression CreateMetaIndexerExpression(bool addToModelContext = true)
    	{
    		MetaIndexerExpression result = new global::MetaDslx.Core.MetaIndexerExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewExpression.
        /// </summary>
        public MetaNewExpression CreateMetaNewExpression(bool addToModelContext = true)
    	{
    		MetaNewExpression result = new global::MetaDslx.Core.MetaNewExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewPropertyInitializer.
        /// </summary>
        public MetaNewPropertyInitializer CreateMetaNewPropertyInitializer(bool addToModelContext = true)
    	{
    		MetaNewPropertyInitializer result = new global::MetaDslx.Core.MetaNewPropertyInitializerImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNewCollectionExpression.
        /// </summary>
        public MetaNewCollectionExpression CreateMetaNewCollectionExpression(bool addToModelContext = true)
    	{
    		MetaNewCollectionExpression result = new global::MetaDslx.Core.MetaNewCollectionExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaUnaryPlusExpression.
        /// </summary>
        public MetaUnaryPlusExpression CreateMetaUnaryPlusExpression(bool addToModelContext = true)
    	{
    		MetaUnaryPlusExpression result = new global::MetaDslx.Core.MetaUnaryPlusExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNegateExpression.
        /// </summary>
        public MetaNegateExpression CreateMetaNegateExpression(bool addToModelContext = true)
    	{
    		MetaNegateExpression result = new global::MetaDslx.Core.MetaNegateExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOnesComplementExpression.
        /// </summary>
        public MetaOnesComplementExpression CreateMetaOnesComplementExpression(bool addToModelContext = true)
    	{
    		MetaOnesComplementExpression result = new global::MetaDslx.Core.MetaOnesComplementExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNotExpression.
        /// </summary>
        public MetaNotExpression CreateMetaNotExpression(bool addToModelContext = true)
    	{
    		MetaNotExpression result = new global::MetaDslx.Core.MetaNotExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPostIncrementAssignExpression.
        /// </summary>
        public MetaPostIncrementAssignExpression CreateMetaPostIncrementAssignExpression(bool addToModelContext = true)
    	{
    		MetaPostIncrementAssignExpression result = new global::MetaDslx.Core.MetaPostIncrementAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPostDecrementAssignExpression.
        /// </summary>
        public MetaPostDecrementAssignExpression CreateMetaPostDecrementAssignExpression(bool addToModelContext = true)
    	{
    		MetaPostDecrementAssignExpression result = new global::MetaDslx.Core.MetaPostDecrementAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPreIncrementAssignExpression.
        /// </summary>
        public MetaPreIncrementAssignExpression CreateMetaPreIncrementAssignExpression(bool addToModelContext = true)
    	{
    		MetaPreIncrementAssignExpression result = new global::MetaDslx.Core.MetaPreIncrementAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPreDecrementAssignExpression.
        /// </summary>
        public MetaPreDecrementAssignExpression CreateMetaPreDecrementAssignExpression(bool addToModelContext = true)
    	{
    		MetaPreDecrementAssignExpression result = new global::MetaDslx.Core.MetaPreDecrementAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyExpression.
        /// </summary>
        public MetaMultiplyExpression CreateMetaMultiplyExpression(bool addToModelContext = true)
    	{
    		MetaMultiplyExpression result = new global::MetaDslx.Core.MetaMultiplyExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaDivideExpression.
        /// </summary>
        public MetaDivideExpression CreateMetaDivideExpression(bool addToModelContext = true)
    	{
    		MetaDivideExpression result = new global::MetaDslx.Core.MetaDivideExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModuloExpression.
        /// </summary>
        public MetaModuloExpression CreateMetaModuloExpression(bool addToModelContext = true)
    	{
    		MetaModuloExpression result = new global::MetaDslx.Core.MetaModuloExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAddExpression.
        /// </summary>
        public MetaAddExpression CreateMetaAddExpression(bool addToModelContext = true)
    	{
    		MetaAddExpression result = new global::MetaDslx.Core.MetaAddExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSubtractExpression.
        /// </summary>
        public MetaSubtractExpression CreateMetaSubtractExpression(bool addToModelContext = true)
    	{
    		MetaSubtractExpression result = new global::MetaDslx.Core.MetaSubtractExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftExpression.
        /// </summary>
        public MetaLeftShiftExpression CreateMetaLeftShiftExpression(bool addToModelContext = true)
    	{
    		MetaLeftShiftExpression result = new global::MetaDslx.Core.MetaLeftShiftExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftExpression.
        /// </summary>
        public MetaRightShiftExpression CreateMetaRightShiftExpression(bool addToModelContext = true)
    	{
    		MetaRightShiftExpression result = new global::MetaDslx.Core.MetaRightShiftExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLessThanExpression.
        /// </summary>
        public MetaLessThanExpression CreateMetaLessThanExpression(bool addToModelContext = true)
    	{
    		MetaLessThanExpression result = new global::MetaDslx.Core.MetaLessThanExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLessThanOrEqualExpression.
        /// </summary>
        public MetaLessThanOrEqualExpression CreateMetaLessThanOrEqualExpression(bool addToModelContext = true)
    	{
    		MetaLessThanOrEqualExpression result = new global::MetaDslx.Core.MetaLessThanOrEqualExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanExpression.
        /// </summary>
        public MetaGreaterThanExpression CreateMetaGreaterThanExpression(bool addToModelContext = true)
    	{
    		MetaGreaterThanExpression result = new global::MetaDslx.Core.MetaGreaterThanExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanOrEqualExpression.
        /// </summary>
        public MetaGreaterThanOrEqualExpression CreateMetaGreaterThanOrEqualExpression(bool addToModelContext = true)
    	{
    		MetaGreaterThanOrEqualExpression result = new global::MetaDslx.Core.MetaGreaterThanOrEqualExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEqualExpression.
        /// </summary>
        public MetaEqualExpression CreateMetaEqualExpression(bool addToModelContext = true)
    	{
    		MetaEqualExpression result = new global::MetaDslx.Core.MetaEqualExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNotEqualExpression.
        /// </summary>
        public MetaNotEqualExpression CreateMetaNotEqualExpression(bool addToModelContext = true)
    	{
    		MetaNotEqualExpression result = new global::MetaDslx.Core.MetaNotEqualExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndExpression.
        /// </summary>
        public MetaAndExpression CreateMetaAndExpression(bool addToModelContext = true)
    	{
    		MetaAndExpression result = new global::MetaDslx.Core.MetaAndExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrExpression.
        /// </summary>
        public MetaOrExpression CreateMetaOrExpression(bool addToModelContext = true)
    	{
    		MetaOrExpression result = new global::MetaDslx.Core.MetaOrExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrExpression.
        /// </summary>
        public MetaExclusiveOrExpression CreateMetaExclusiveOrExpression(bool addToModelContext = true)
    	{
    		MetaExclusiveOrExpression result = new global::MetaDslx.Core.MetaExclusiveOrExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndAlsoExpression.
        /// </summary>
        public MetaAndAlsoExpression CreateMetaAndAlsoExpression(bool addToModelContext = true)
    	{
    		MetaAndAlsoExpression result = new global::MetaDslx.Core.MetaAndAlsoExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrElseExpression.
        /// </summary>
        public MetaOrElseExpression CreateMetaOrElseExpression(bool addToModelContext = true)
    	{
    		MetaOrElseExpression result = new global::MetaDslx.Core.MetaOrElseExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullCoalescingExpression.
        /// </summary>
        public MetaNullCoalescingExpression CreateMetaNullCoalescingExpression(bool addToModelContext = true)
    	{
    		MetaNullCoalescingExpression result = new global::MetaDslx.Core.MetaNullCoalescingExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAssignExpression.
        /// </summary>
        public MetaAssignExpression CreateMetaAssignExpression(bool addToModelContext = true)
    	{
    		MetaAssignExpression result = new global::MetaDslx.Core.MetaAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyAssignExpression.
        /// </summary>
        public MetaMultiplyAssignExpression CreateMetaMultiplyAssignExpression(bool addToModelContext = true)
    	{
    		MetaMultiplyAssignExpression result = new global::MetaDslx.Core.MetaMultiplyAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaDivideAssignExpression.
        /// </summary>
        public MetaDivideAssignExpression CreateMetaDivideAssignExpression(bool addToModelContext = true)
    	{
    		MetaDivideAssignExpression result = new global::MetaDslx.Core.MetaDivideAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModuloAssignExpression.
        /// </summary>
        public MetaModuloAssignExpression CreateMetaModuloAssignExpression(bool addToModelContext = true)
    	{
    		MetaModuloAssignExpression result = new global::MetaDslx.Core.MetaModuloAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAddAssignExpression.
        /// </summary>
        public MetaAddAssignExpression CreateMetaAddAssignExpression(bool addToModelContext = true)
    	{
    		MetaAddAssignExpression result = new global::MetaDslx.Core.MetaAddAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaSubtractAssignExpression.
        /// </summary>
        public MetaSubtractAssignExpression CreateMetaSubtractAssignExpression(bool addToModelContext = true)
    	{
    		MetaSubtractAssignExpression result = new global::MetaDslx.Core.MetaSubtractAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftAssignExpression.
        /// </summary>
        public MetaLeftShiftAssignExpression CreateMetaLeftShiftAssignExpression(bool addToModelContext = true)
    	{
    		MetaLeftShiftAssignExpression result = new global::MetaDslx.Core.MetaLeftShiftAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftAssignExpression.
        /// </summary>
        public MetaRightShiftAssignExpression CreateMetaRightShiftAssignExpression(bool addToModelContext = true)
    	{
    		MetaRightShiftAssignExpression result = new global::MetaDslx.Core.MetaRightShiftAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaAndAssignExpression.
        /// </summary>
        public MetaAndAssignExpression CreateMetaAndAssignExpression(bool addToModelContext = true)
    	{
    		MetaAndAssignExpression result = new global::MetaDslx.Core.MetaAndAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrAssignExpression.
        /// </summary>
        public MetaExclusiveOrAssignExpression CreateMetaExclusiveOrAssignExpression(bool addToModelContext = true)
    	{
    		MetaExclusiveOrAssignExpression result = new global::MetaDslx.Core.MetaExclusiveOrAssignExpressionImpl(addToModelContext);
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOrAssignExpression.
        /// </summary>
        public MetaOrAssignExpression CreateMetaOrAssignExpression(bool addToModelContext = true)
    	{
    		MetaOrAssignExpression result = new global::MetaDslx.Core.MetaOrAssignExpressionImpl(addToModelContext);
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
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
        // Initializes the following readonly properties:
        ///    Function.Type
        /// </summary>
        public virtual void MetaFunction_MetaFunction(MetaFunction @this)
        {
            this.MetaNamedElement_MetaNamedElement(@this);
            this.MetaTypedElement_MetaTypedElement(@this);
            this.MetaAnnotatedElement_MetaAnnotatedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperation()
    	/// Direct superclasses: MetaFunction
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement, MetaFunction
        // Initializes the following readonly properties:
        ///    Function.Type
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
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaExpression_MetaExpression(MetaExpression @this)
        {
            this.MetaTypedElement_MetaTypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBracketExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaBracketExpression_MetaBracketExpression(MetaBracketExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBoundExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaBoundExpression_MetaBoundExpression(MetaBoundExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaThisExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaThisExpression_MetaThisExpression(MetaThisExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaNullExpression_MetaNullExpression(MetaNullExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeConversionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeAsExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaTypeAsExpression_MetaTypeAsExpression(MetaTypeAsExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCastExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaTypeCastExpression_MetaTypeCastExpression(MetaTypeCastExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCheckExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeOfExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConditionalExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstantExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIdentifierExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMemberAccessExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionCallExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIndexerExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNewExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
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
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        /// </summary>
        public virtual void MetaNewCollectionExpression_MetaNewCollectionExpression(MetaNewCollectionExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperatorExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOperatorExpression_MetaOperatorExpression(MetaOperatorExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryExpression()
    	/// Direct superclasses: MetaOperatorExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
            this.MetaOperatorExpression_MetaOperatorExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryPlusExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryPlusExpression_MetaUnaryPlusExpression(MetaUnaryPlusExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNegateExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaNegateExpression_MetaNegateExpression(MetaNegateExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOnesComplementExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOnesComplementExpression_MetaOnesComplementExpression(MetaOnesComplementExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNotExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaNotExpression_MetaNotExpression(MetaNotExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryAssignExpression()
    	/// Direct superclasses: MetaUnaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaUnaryAssignExpression_MetaUnaryAssignExpression(MetaUnaryAssignExpression @this)
        {
            this.MetaUnaryExpression_MetaUnaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPostIncrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(MetaPostIncrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPostDecrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(MetaPostDecrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPreIncrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(MetaPreIncrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPreDecrementAssignExpression()
    	/// Direct superclasses: MetaUnaryAssignExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaUnaryExpression, MetaUnaryAssignExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(MetaPreDecrementAssignExpression @this)
        {
            this.MetaUnaryAssignExpression_MetaUnaryAssignExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryExpression()
    	/// Direct superclasses: MetaOperatorExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
            this.MetaOperatorExpression_MetaOperatorExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryArithmeticExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(MetaBinaryArithmeticExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMultiplyExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaMultiplyExpression_MetaMultiplyExpression(MetaMultiplyExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDivideExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaDivideExpression_MetaDivideExpression(MetaDivideExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModuloExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaModuloExpression_MetaModuloExpression(MetaModuloExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAddExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAddExpression_MetaAddExpression(MetaAddExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSubtractExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaSubtractExpression_MetaSubtractExpression(MetaSubtractExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLeftShiftExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaLeftShiftExpression_MetaLeftShiftExpression(MetaLeftShiftExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaRightShiftExpression()
    	/// Direct superclasses: MetaBinaryArithmeticExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryArithmeticExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaRightShiftExpression_MetaRightShiftExpression(MetaRightShiftExpression @this)
        {
            this.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryComparisonExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(MetaBinaryComparisonExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLessThanExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaLessThanExpression_MetaLessThanExpression(MetaLessThanExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLessThanOrEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(MetaLessThanOrEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaGreaterThanExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaGreaterThanExpression_MetaGreaterThanExpression(MetaGreaterThanExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaGreaterThanOrEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(MetaGreaterThanOrEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaEqualExpression_MetaEqualExpression(MetaEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNotEqualExpression()
    	/// Direct superclasses: MetaBinaryComparisonExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryComparisonExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaNotEqualExpression_MetaNotEqualExpression(MetaNotEqualExpression @this)
        {
            this.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryLogicalExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(MetaBinaryLogicalExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAndExpression_MetaAndExpression(MetaAndExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOrExpression_MetaOrExpression(MetaOrExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExclusiveOrExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaExclusiveOrExpression_MetaExclusiveOrExpression(MetaExclusiveOrExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndAlsoExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAndAlsoExpression_MetaAndAlsoExpression(MetaAndAlsoExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrElseExpression()
    	/// Direct superclasses: MetaBinaryLogicalExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaBinaryLogicalExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOrElseExpression_MetaOrElseExpression(MetaOrElseExpression @this)
        {
            this.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullCoalescingExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaNullCoalescingExpression_MetaNullCoalescingExpression(MetaNullCoalescingExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignmentExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAssignmentExpression_MetaAssignmentExpression(MetaAssignmentExpression @this)
        {
            this.MetaBinaryExpression_MetaBinaryExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAssignExpression_MetaAssignExpression(MetaAssignExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaArithmeticAssignmentExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(MetaArithmeticAssignmentExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMultiplyAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(MetaMultiplyAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDivideAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaDivideAssignExpression_MetaDivideAssignExpression(MetaDivideAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModuloAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaModuloAssignExpression_MetaModuloAssignExpression(MetaModuloAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAddAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAddAssignExpression_MetaAddAssignExpression(MetaAddAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSubtractAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaSubtractAssignExpression_MetaSubtractAssignExpression(MetaSubtractAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLeftShiftAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(MetaLeftShiftAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaRightShiftAssignExpression()
    	/// Direct superclasses: MetaArithmeticAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaArithmeticAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(MetaRightShiftAssignExpression @this)
        {
            this.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaLogicalAssignmentExpression()
    	/// Direct superclasses: MetaAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(MetaLogicalAssignmentExpression @this)
        {
            this.MetaAssignmentExpression_MetaAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAndAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaAndAssignExpression_MetaAndAssignExpression(MetaAndAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExclusiveOrAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(MetaExclusiveOrAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOrAssignExpression()
    	/// Direct superclasses: MetaLogicalAssignmentExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression, MetaOperatorExpression, MetaBinaryExpression, MetaAssignmentExpression, MetaLogicalAssignmentExpression
        // Initializes the following readonly properties:
        ///    Expression.NoTypeError
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOrAssignExpression_MetaOrAssignExpression(MetaOrAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
    
    
    }
    
}

