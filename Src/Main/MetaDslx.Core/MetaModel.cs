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
        static Meta()
        {
            MetaAnnotatedElement.StaticInit();
            MetaNamedElement.StaticInit();
            MetaTypedElement.StaticInit();
            MetaType.StaticInit();
            MetaAnnotation.StaticInit();
            MetaNamespace.StaticInit();
            MetaModel.StaticInit();
            MetaDeclaration.StaticInit();
            MetaCollectionType.StaticInit();
            MetaNullableType.StaticInit();
            MetaPrimitiveType.StaticInit();
            MetaEnum.StaticInit();
            MetaEnumLiteral.StaticInit();
            MetaClass.StaticInit();
            MetaFunctionType.StaticInit();
            MetaFunction.StaticInit();
            MetaOperation.StaticInit();
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
    
        
        public static class MetaAnnotatedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotatedElement()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty AnnotationsProperty =
                ModelProperty.Register("Annotations", typeof(IList<global::MetaDslx.Core.MetaAnnotation>), typeof(global::MetaDslx.Core.MetaAnnotatedElement), typeof(global::MetaDslx.Core.Meta.MetaAnnotatedElement));
            
        }
        
        public static class MetaNamedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNamedElement()
            {
            }
        
            [Name]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaNamedElement), typeof(global::MetaDslx.Core.Meta.MetaNamedElement));
            
        }
        
        public static class MetaTypedElement
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypedElement()
            {
            }
        
            [Type]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypedElement), typeof(global::MetaDslx.Core.Meta.MetaTypedElement));
            
        }
        
        public static class MetaType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaType()
            {
            }
        
        }
        
        public static class MetaAnnotation
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAnnotation()
            {
            }
        
        }
        
        public static class MetaNamespace
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNamespace()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaModel()
            {
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
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
            [ScopeEntry]
            [ContainmentAttribute]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaModel), typeof(global::MetaDslx.Core.Meta.MetaModel));
            
        }
        
        public static class MetaDeclaration
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDeclaration()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaCollectionType()
            {
            }
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaCollectionKind), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.Meta.MetaCollectionType));
            
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaCollectionType), typeof(global::MetaDslx.Core.Meta.MetaCollectionType));
            
        }
        
        public static class MetaNullableType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullableType()
            {
            }
        
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaNullableType), typeof(global::MetaDslx.Core.Meta.MetaNullableType));
            
        }
        
        public static class MetaPrimitiveType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPrimitiveType()
            {
            }
        
        }
        
        public static class MetaEnum
        {
            internal static void StaticInit()
            {
            }
        
            static MetaEnum()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaEnumLiteral()
            {
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaEnum), "EnumLiterals")]
            public static readonly ModelProperty EnumProperty =
                ModelProperty.Register("Enum", typeof(global::MetaDslx.Core.MetaEnum), typeof(global::MetaDslx.Core.MetaEnumLiteral), typeof(global::MetaDslx.Core.Meta.MetaEnumLiteral));
            
        }
        
        public static class MetaClass
        {
            internal static void StaticInit()
            {
            }
        
            static MetaClass()
            {
            }
        
            
            public static readonly ModelProperty IsAbstractProperty =
                ModelProperty.Register("IsAbstract", typeof(bool), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [InheritedScope]
            public static readonly ModelProperty SuperClassesProperty =
                ModelProperty.Register("SuperClasses", typeof(IList<global::MetaDslx.Core.MetaClass>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "Class")]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaProperty), "Parent")]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(IList<global::MetaDslx.Core.MetaProperty>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaOperation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(IList<global::MetaDslx.Core.MetaOperation>), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ConstructorProperty =
                ModelProperty.Register("Constructor", typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.MetaClass), typeof(global::MetaDslx.Core.Meta.MetaClass));
            
        }
        
        public static class MetaFunctionType
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionType()
            {
            }
        
            
            public static readonly ModelProperty ParameterTypesProperty =
                ModelProperty.Register("ParameterTypes", typeof(IList<global::MetaDslx.Core.MetaType>), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.Meta.MetaFunctionType));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.Meta.MetaFunctionType));
            
        }
        
        public static class MetaFunction
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunction()
            {
            }
        
            [Type]
            [ReadonlyAttribute]
            [RedefinesAttribute(typeof(global::MetaDslx.Core.Meta.MetaTypedElement), "Type")]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaFunctionType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaParameter), "Operation")]
            public static readonly ModelProperty ParametersProperty =
                ModelProperty.Register("Parameters", typeof(IList<global::MetaDslx.Core.MetaParameter>), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaFunction), typeof(global::MetaDslx.Core.Meta.MetaFunction));
            
        }
        
        public static class MetaOperation
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOperation()
            {
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaClass), "Operations")]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaEnum), "Operations")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.Meta.MetaOperation));
            
        }
        
        public static class MetaConstructor
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConstructor()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty InitializersProperty =
                ModelProperty.Register("Initializers", typeof(IList<global::MetaDslx.Core.MetaPropertyInitializer>), typeof(global::MetaDslx.Core.MetaConstructor), typeof(global::MetaDslx.Core.Meta.MetaConstructor));
            
        }
        
        public static class MetaParameter
        {
            internal static void StaticInit()
            {
            }
        
            static MetaParameter()
            {
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaFunction), "Parameters")]
            public static readonly ModelProperty OperationProperty =
                ModelProperty.Register("Operation", typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.MetaParameter), typeof(global::MetaDslx.Core.Meta.MetaParameter));
            
        }
        
        public static class MetaProperty
        {
            internal static void StaticInit()
            {
            }
        
            static MetaProperty()
            {
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaClass), "Properties")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.Meta.MetaProperty));
            
            
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
            internal static void StaticInit()
            {
            }
        
            static MetaPropertyInitializer()
            {
            }
        
            
            public static readonly ModelProperty PropertyNameProperty =
                ModelProperty.Register("PropertyName", typeof(string), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            public static readonly ModelProperty PropertyProperty =
                ModelProperty.Register("Property", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaPropertyInitializer));
            
        }
        
        public static class MetaSynthetizedPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSynthetizedPropertyInitializer()
            {
            }
        
        }
        
        public static class MetaInheritedPropertyInitializer
        {
            internal static void StaticInit()
            {
            }
        
            static MetaInheritedPropertyInitializer()
            {
            }
        
            
            public static readonly ModelProperty ObjectNameProperty =
                ModelProperty.Register("ObjectName", typeof(string), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer));
            
            
            public static readonly ModelProperty ObjectProperty =
                ModelProperty.Register("Object", typeof(global::MetaDslx.Core.MetaProperty), typeof(global::MetaDslx.Core.MetaInheritedPropertyInitializer), typeof(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer));
            
        }
        
        public static class MetaExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExpression()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaBracketExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaBracketExpression), typeof(global::MetaDslx.Core.Meta.MetaBracketExpression));
            
        }
        
        public static class MetaBoundExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBoundExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ArgumentsProperty =
                ModelProperty.Register("Arguments", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
            
            public static readonly ModelProperty DefinitionsProperty =
                ModelProperty.Register("Definitions", typeof(IList<object>), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty DefinitionProperty =
                ModelProperty.Register("Definition", typeof(object), typeof(global::MetaDslx.Core.MetaBoundExpression), typeof(global::MetaDslx.Core.Meta.MetaBoundExpression));
            
        }
        
        public static class MetaThisExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaThisExpression()
            {
            }
        
        }
        
        public static class MetaNullExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullExpression()
            {
            }
        
        }
        
        public static class MetaTypeConversionExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeConversionExpression()
            {
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeConversionExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeConversionExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeConversionExpression));
            
        }
        
        public static class MetaTypeAsExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeAsExpression()
            {
            }
        
        }
        
        public static class MetaTypeCastExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCastExpression()
            {
            }
        
        }
        
        public static class MetaTypeCheckExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeCheckExpression()
            {
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeCheckExpression));
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaTypeCheckExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeCheckExpression));
            
        }
        
        public static class MetaTypeOfExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaTypeOfExpression()
            {
            }
        
            
            public static readonly ModelProperty TypeReferenceProperty =
                ModelProperty.Register("TypeReference", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaTypeOfExpression), typeof(global::MetaDslx.Core.Meta.MetaTypeOfExpression));
            
        }
        
        public static class MetaConditionalExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaConditionalExpression()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaConstantExpression()
            {
            }
        
            
            public static readonly ModelProperty ValueProperty =
                ModelProperty.Register("Value", typeof(object), typeof(global::MetaDslx.Core.MetaConstantExpression), typeof(global::MetaDslx.Core.Meta.MetaConstantExpression));
            
        }
        
        public static class MetaIdentifierExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaIdentifierExpression()
            {
            }
        
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaIdentifierExpression), typeof(global::MetaDslx.Core.Meta.MetaIdentifierExpression));
            
        }
        
        public static class MetaMemberAccessExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMemberAccessExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.Meta.MetaMemberAccessExpression));
            
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaMemberAccessExpression), typeof(global::MetaDslx.Core.Meta.MetaMemberAccessExpression));
            
        }
        
        public static class MetaFunctionCallExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaFunctionCallExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaFunctionCallExpression), typeof(global::MetaDslx.Core.Meta.MetaFunctionCallExpression));
            
        }
        
        public static class MetaIndexerExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaIndexerExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaIndexerExpression), typeof(global::MetaDslx.Core.Meta.MetaIndexerExpression));
            
        }
        
        public static class MetaOperatorExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOperatorExpression()
            {
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Core.MetaOperatorExpression), typeof(global::MetaDslx.Core.Meta.MetaOperatorExpression));
            
        }
        
        public static class MetaUnaryExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryExpression()
            {
            }
        
            
            [ContainmentAttribute]
            public static readonly ModelProperty ExpressionProperty =
                ModelProperty.Register("Expression", typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.MetaUnaryExpression), typeof(global::MetaDslx.Core.Meta.MetaUnaryExpression));
            
        }
        
        public static class MetaUnaryPlusExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryPlusExpression()
            {
            }
        
        }
        
        public static class MetaNegateExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNegateExpression()
            {
            }
        
        }
        
        public static class MetaOnesComplementExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOnesComplementExpression()
            {
            }
        
        }
        
        public static class MetaNotExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNotExpression()
            {
            }
        
        }
        
        public static class MetaUnaryAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaUnaryAssignExpression()
            {
            }
        
        }
        
        public static class MetaPostIncrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPostIncrementAssignExpression()
            {
            }
        
        }
        
        public static class MetaPostDecrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPostDecrementAssignExpression()
            {
            }
        
        }
        
        public static class MetaPreIncrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPreIncrementAssignExpression()
            {
            }
        
        }
        
        public static class MetaPreDecrementAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaPreDecrementAssignExpression()
            {
            }
        
        }
        
        public static class MetaBinaryExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryExpression()
            {
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
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryArithmeticExpression()
            {
            }
        
        }
        
        public static class MetaMultiplyExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyExpression()
            {
            }
        
        }
        
        public static class MetaDivideExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDivideExpression()
            {
            }
        
        }
        
        public static class MetaModuloExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaModuloExpression()
            {
            }
        
        }
        
        public static class MetaAddExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAddExpression()
            {
            }
        
        }
        
        public static class MetaSubtractExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractExpression()
            {
            }
        
        }
        
        public static class MetaLeftShiftExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftExpression()
            {
            }
        
        }
        
        public static class MetaRightShiftExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftExpression()
            {
            }
        
        }
        
        public static class MetaBinaryComparisonExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryComparisonExpression()
            {
            }
        
        }
        
        public static class MetaLessThanExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanExpression()
            {
            }
        
        }
        
        public static class MetaLessThanOrEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLessThanOrEqualExpression()
            {
            }
        
        }
        
        public static class MetaGreaterThanExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanExpression()
            {
            }
        
        }
        
        public static class MetaGreaterThanOrEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaGreaterThanOrEqualExpression()
            {
            }
        
        }
        
        public static class MetaEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaEqualExpression()
            {
            }
        
        }
        
        public static class MetaNotEqualExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNotEqualExpression()
            {
            }
        
        }
        
        public static class MetaBinaryLogicalExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryLogicalExpression()
            {
            }
        
        }
        
        public static class MetaAndExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndExpression()
            {
            }
        
        }
        
        public static class MetaOrExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrExpression()
            {
            }
        
        }
        
        public static class MetaExclusiveOrExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrExpression()
            {
            }
        
        }
        
        public static class MetaAndAlsoExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndAlsoExpression()
            {
            }
        
        }
        
        public static class MetaOrElseExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrElseExpression()
            {
            }
        
        }
        
        public static class MetaNullCoalescingExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullCoalescingExpression()
            {
            }
        
        }
        
        public static class MetaAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAssignmentExpression()
            {
            }
        
        }
        
        public static class MetaAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAssignExpression()
            {
            }
        
        }
        
        public static class MetaArithmeticAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaArithmeticAssignmentExpression()
            {
            }
        
        }
        
        public static class MetaMultiplyAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaMultiplyAssignExpression()
            {
            }
        
        }
        
        public static class MetaDivideAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaDivideAssignExpression()
            {
            }
        
        }
        
        public static class MetaModuloAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaModuloAssignExpression()
            {
            }
        
        }
        
        public static class MetaAddAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAddAssignExpression()
            {
            }
        
        }
        
        public static class MetaSubtractAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaSubtractAssignExpression()
            {
            }
        
        }
        
        public static class MetaLeftShiftAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLeftShiftAssignExpression()
            {
            }
        
        }
        
        public static class MetaRightShiftAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaRightShiftAssignExpression()
            {
            }
        
        }
        
        public static class MetaLogicalAssignmentExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaLogicalAssignmentExpression()
            {
            }
        
        }
        
        public static class MetaAndAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaAndAssignExpression()
            {
            }
        
        }
        
        public static class MetaExclusiveOrAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaExclusiveOrAssignExpression()
            {
            }
        
        }
        
        public static class MetaOrAssignExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaOrAssignExpression()
            {
            }
        
        }
    }
    
    
    public enum MetaCollectionKind
    {
        Set,
        List,
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
        {
            MetaImplementationProvider.Implementation.MetaType_MetaType(this);
            this.MMakeDefault();
        }
    }
    
    
    public interface MetaAnnotation : MetaDslx.Core.MetaNamedElement
    {
    
    }
    
    internal class MetaAnnotationImpl : ModelObject, MetaDslx.Core.MetaAnnotation
    {
        static MetaAnnotationImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaAnnotationImpl()
        {
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
        IList<MetaProperty> Properties { get; }
        IList<MetaOperation> Operations { get; }
    
    }
    
    internal class MetaModelImpl : ModelObject, MetaDslx.Core.MetaModel
    {
        static MetaModelImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaModelImpl()
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty, new ModelList<MetaAnnotation>(this, global::MetaDslx.Core.Meta.MetaAnnotatedElement.AnnotationsProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.TypesProperty, new ModelList<MetaType>(this, global::MetaDslx.Core.Meta.MetaModel.TypesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.PropertiesProperty, new ModelList<MetaProperty>(this, global::MetaDslx.Core.Meta.MetaModel.PropertiesProperty));
            this.MSet(global::MetaDslx.Core.Meta.MetaModel.OperationsProperty, new ModelList<MetaOperation>(this, global::MetaDslx.Core.Meta.MetaModel.OperationsProperty));
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
        
        IList<MetaProperty> MetaModel.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.PropertiesProperty); 
                if (result != null) return (IList<MetaProperty>)result;
                else return default(IList<MetaProperty>);
            }
        }
        
        IList<MetaOperation> MetaModel.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaModel.OperationsProperty); 
                if (result != null) return (IList<MetaOperation>)result;
                else return default(IList<MetaOperation>);
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
            get { return MetaImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
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
            get { return MetaImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
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
            get { return MetaImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
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
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaFunctionType.ParameterTypesProperty, new ModelList<MetaType>(this, global::MetaDslx.Core.Meta.MetaFunctionType.ParameterTypesProperty));
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
    
    
    public interface MetaConstructor : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        IList<MetaPropertyInitializer> Initializers { get; }
    
    }
    
    internal class MetaConstructorImpl : ModelObject, MetaDslx.Core.MetaConstructor
    {
        static MetaConstructorImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaConstructorImpl()
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
        MetaOperation Operation { get; set; }
    
    }
    
    internal class MetaParameterImpl : ModelObject, MetaDslx.Core.MetaParameter
    {
        static MetaParameterImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaParameterImpl()
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
        
        MetaOperation MetaParameter.Operation
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaParameter.OperationProperty); 
                if (result != null) return (MetaOperation)result;
                else return default(MetaOperation);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaParameter.OperationProperty, value); }
        }
    }
    
    
    public interface MetaProperty : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaType Parent { get; set; }
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
        
        MetaType MetaProperty.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaProperty.ParentProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaProperty.ParentProperty, value); }
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
        string PropertyName { get; set; }
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaPropertyInitializer.ValueProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaPropertyInitializer_MetaPropertyInitializer(this);
            this.MMakeDefault();
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
        {
            MetaImplementationProvider.Implementation.MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(this);
            this.MMakeDefault();
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaInheritedPropertyInitializer.ObjectProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(this);
            this.MMakeDefault();
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaExpression_MetaExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBracketExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaBracketExpression_MetaBracketExpression(this);
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
        IList<MetaExpression> Arguments { get; }
        IList<object> Definitions { get; }
        object Definition { get; }
    
    }
    
    internal class MetaBoundExpressionImpl : ModelObject, MetaDslx.Core.MetaBoundExpression
    {
        static MetaBoundExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBoundExpressionImpl()
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaBoundExpression_MetaBoundExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaThisExpression_MetaThisExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            MetaImplementationProvider.Implementation.MetaNullExpression_MetaNullExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeConversionExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaTypeConversionExpression_MetaTypeConversionExpression(this);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            MetaImplementationProvider.Implementation.MetaTypeAsExpression_MetaTypeAsExpression(this);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            MetaImplementationProvider.Implementation.MetaTypeCastExpression_MetaTypeCastExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaTypeCheckExpression.ExpressionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaTypeCheckExpression_MetaTypeCheckExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            MetaImplementationProvider.Implementation.MetaTypeOfExpression_MetaTypeOfExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ConditionProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ThenProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaConditionalExpression.ElseProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaConditionalExpression_MetaConditionalExpression(this);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            MetaImplementationProvider.Implementation.MetaConstantExpression_MetaConstantExpression(this);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaIdentifierExpression_MetaIdentifierExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaMemberAccessExpression_MetaMemberAccessExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaFunctionCallExpression_MetaFunctionCallExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaIndexerExpression_MetaIndexerExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaOperatorExpression_MetaOperatorExpression
            MetaImplementationProvider.Implementation.MetaOperatorExpression_MetaOperatorExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => ));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryExpression_MetaUnaryExpression
            MetaImplementationProvider.Implementation.MetaUnaryExpression_MetaUnaryExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaUnaryPlusExpression_MetaUnaryPlusExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaNegateExpression_MetaNegateExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaOnesComplementExpression_MetaOnesComplementExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaNotExpression_MetaNotExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression
            MetaImplementationProvider.Implementation.MetaUnaryAssignExpression_MetaUnaryAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => ));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryExpression_MetaBinaryExpression
            MetaImplementationProvider.Implementation.MetaBinaryExpression_MetaBinaryExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression
            MetaImplementationProvider.Implementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaMultiplyExpression_MetaMultiplyExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaDivideExpression_MetaDivideExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaModuloExpression_MetaModuloExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAddExpression_MetaAddExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaSubtractExpression_MetaSubtractExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaLeftShiftExpression_MetaLeftShiftExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaRightShiftExpression_MetaRightShiftExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression
            MetaImplementationProvider.Implementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaLessThanExpression_MetaLessThanExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaGreaterThanExpression_MetaGreaterThanExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaEqualExpression_MetaEqualExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaNotEqualExpression_MetaNotEqualExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression
            MetaImplementationProvider.Implementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAndExpression_MetaAndExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaOrExpression_MetaOrExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaExclusiveOrExpression_MetaExclusiveOrExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAndAlsoExpression_MetaAndAlsoExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaOrElseExpression_MetaOrElseExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaNullCoalescingExpression_MetaNullCoalescingExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => ));
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaAssignmentExpression_MetaAssignmentExpression
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.LeftProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            //this.MLazySetChild(global::MetaDslx.Core.Meta.MetaBinaryExpression.RightProperty, global::MetaDslx.Core.Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAssignmentExpression_MetaAssignmentExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAssignExpression_MetaAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression
            MetaImplementationProvider.Implementation.MetaArithmeticAssignmentExpression_MetaArithmeticAssignmentExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaDivideAssignExpression_MetaDivideAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaModuloAssignExpression_MetaModuloAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAddAssignExpression_MetaAddAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaSubtractAssignExpression_MetaSubtractAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            // Init global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty in MetaImplementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression
            MetaImplementationProvider.Implementation.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaAndAssignExpression_MetaAndAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaExpression_NoTypeError(this)));
            this.MSet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty));
            //this.MLazySet(global::MetaDslx.Core.Meta.MetaOperatorExpression.NameProperty, new Lazy<object>(() => ));
            MetaImplementationProvider.Implementation.MetaOrAssignExpression_MetaOrAssignExpression(this);
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
        
        IList<MetaExpression> MetaBoundExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
        
        IList<object> MetaBoundExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaBoundExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBoundExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        /// Creates a new instance of MetaAnnotatedElement.
        /// </summary>
        public MetaAnnotatedElement CreateMetaAnnotatedElement()
    	{
    		MetaAnnotatedElement result = new MetaAnnotatedElementImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNamedElement.
        /// </summary>
        public MetaNamedElement CreateMetaNamedElement()
    	{
    		MetaNamedElement result = new MetaNamedElementImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypedElement.
        /// </summary>
        public MetaTypedElement CreateMetaTypedElement()
    	{
    		MetaTypedElement result = new MetaTypedElementImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaType.
        /// </summary>
        public MetaType CreateMetaType()
    	{
    		MetaType result = new MetaTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAnnotation.
        /// </summary>
        public MetaAnnotation CreateMetaAnnotation()
    	{
    		MetaAnnotation result = new MetaAnnotationImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNamespace.
        /// </summary>
        public MetaNamespace CreateMetaNamespace()
    	{
    		MetaNamespace result = new MetaNamespaceImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaModel.
        /// </summary>
        public MetaModel CreateMetaModel()
    	{
    		MetaModel result = new MetaModelImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaDeclaration.
        /// </summary>
        public MetaDeclaration CreateMetaDeclaration()
    	{
    		MetaDeclaration result = new MetaDeclarationImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaCollectionType.
        /// </summary>
        public MetaCollectionType CreateMetaCollectionType()
    	{
    		MetaCollectionType result = new MetaCollectionTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNullableType.
        /// </summary>
        public MetaNullableType CreateMetaNullableType()
    	{
    		MetaNullableType result = new MetaNullableTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPrimitiveType.
        /// </summary>
        public MetaPrimitiveType CreateMetaPrimitiveType()
    	{
    		MetaPrimitiveType result = new MetaPrimitiveTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaEnum.
        /// </summary>
        public MetaEnum CreateMetaEnum()
    	{
    		MetaEnum result = new MetaEnumImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaEnumLiteral.
        /// </summary>
        public MetaEnumLiteral CreateMetaEnumLiteral()
    	{
    		MetaEnumLiteral result = new MetaEnumLiteralImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaClass.
        /// </summary>
        public MetaClass CreateMetaClass()
    	{
    		MetaClass result = new MetaClassImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaFunctionType.
        /// </summary>
        public MetaFunctionType CreateMetaFunctionType()
    	{
    		MetaFunctionType result = new MetaFunctionTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaFunction.
        /// </summary>
        public MetaFunction CreateMetaFunction()
    	{
    		MetaFunction result = new MetaFunctionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOperation.
        /// </summary>
        public MetaOperation CreateMetaOperation()
    	{
    		MetaOperation result = new MetaOperationImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaConstructor.
        /// </summary>
        public MetaConstructor CreateMetaConstructor()
    	{
    		MetaConstructor result = new MetaConstructorImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaParameter.
        /// </summary>
        public MetaParameter CreateMetaParameter()
    	{
    		MetaParameter result = new MetaParameterImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaProperty.
        /// </summary>
        public MetaProperty CreateMetaProperty()
    	{
    		MetaProperty result = new MetaPropertyImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPropertyInitializer.
        /// </summary>
        public MetaPropertyInitializer CreateMetaPropertyInitializer()
    	{
    		MetaPropertyInitializer result = new MetaPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaSynthetizedPropertyInitializer.
        /// </summary>
        public MetaSynthetizedPropertyInitializer CreateMetaSynthetizedPropertyInitializer()
    	{
    		MetaSynthetizedPropertyInitializer result = new MetaSynthetizedPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaInheritedPropertyInitializer.
        /// </summary>
        public MetaInheritedPropertyInitializer CreateMetaInheritedPropertyInitializer()
    	{
    		MetaInheritedPropertyInitializer result = new MetaInheritedPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaExpression.
        /// </summary>
        public MetaExpression CreateMetaExpression()
    	{
    		MetaExpression result = new MetaExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBracketExpression.
        /// </summary>
        public MetaBracketExpression CreateMetaBracketExpression()
    	{
    		MetaBracketExpression result = new MetaBracketExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBoundExpression.
        /// </summary>
        public MetaBoundExpression CreateMetaBoundExpression()
    	{
    		MetaBoundExpression result = new MetaBoundExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaThisExpression.
        /// </summary>
        public MetaThisExpression CreateMetaThisExpression()
    	{
    		MetaThisExpression result = new MetaThisExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNullExpression.
        /// </summary>
        public MetaNullExpression CreateMetaNullExpression()
    	{
    		MetaNullExpression result = new MetaNullExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeConversionExpression.
        /// </summary>
        public MetaTypeConversionExpression CreateMetaTypeConversionExpression()
    	{
    		MetaTypeConversionExpression result = new MetaTypeConversionExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeAsExpression.
        /// </summary>
        public MetaTypeAsExpression CreateMetaTypeAsExpression()
    	{
    		MetaTypeAsExpression result = new MetaTypeAsExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeCastExpression.
        /// </summary>
        public MetaTypeCastExpression CreateMetaTypeCastExpression()
    	{
    		MetaTypeCastExpression result = new MetaTypeCastExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeCheckExpression.
        /// </summary>
        public MetaTypeCheckExpression CreateMetaTypeCheckExpression()
    	{
    		MetaTypeCheckExpression result = new MetaTypeCheckExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeOfExpression.
        /// </summary>
        public MetaTypeOfExpression CreateMetaTypeOfExpression()
    	{
    		MetaTypeOfExpression result = new MetaTypeOfExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaConditionalExpression.
        /// </summary>
        public MetaConditionalExpression CreateMetaConditionalExpression()
    	{
    		MetaConditionalExpression result = new MetaConditionalExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaConstantExpression.
        /// </summary>
        public MetaConstantExpression CreateMetaConstantExpression()
    	{
    		MetaConstantExpression result = new MetaConstantExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaIdentifierExpression.
        /// </summary>
        public MetaIdentifierExpression CreateMetaIdentifierExpression()
    	{
    		MetaIdentifierExpression result = new MetaIdentifierExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaMemberAccessExpression.
        /// </summary>
        public MetaMemberAccessExpression CreateMetaMemberAccessExpression()
    	{
    		MetaMemberAccessExpression result = new MetaMemberAccessExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaFunctionCallExpression.
        /// </summary>
        public MetaFunctionCallExpression CreateMetaFunctionCallExpression()
    	{
    		MetaFunctionCallExpression result = new MetaFunctionCallExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaIndexerExpression.
        /// </summary>
        public MetaIndexerExpression CreateMetaIndexerExpression()
    	{
    		MetaIndexerExpression result = new MetaIndexerExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOperatorExpression.
        /// </summary>
        public MetaOperatorExpression CreateMetaOperatorExpression()
    	{
    		MetaOperatorExpression result = new MetaOperatorExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaUnaryExpression.
        /// </summary>
        public MetaUnaryExpression CreateMetaUnaryExpression()
    	{
    		MetaUnaryExpression result = new MetaUnaryExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaUnaryPlusExpression.
        /// </summary>
        public MetaUnaryPlusExpression CreateMetaUnaryPlusExpression()
    	{
    		MetaUnaryPlusExpression result = new MetaUnaryPlusExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNegateExpression.
        /// </summary>
        public MetaNegateExpression CreateMetaNegateExpression()
    	{
    		MetaNegateExpression result = new MetaNegateExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOnesComplementExpression.
        /// </summary>
        public MetaOnesComplementExpression CreateMetaOnesComplementExpression()
    	{
    		MetaOnesComplementExpression result = new MetaOnesComplementExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNotExpression.
        /// </summary>
        public MetaNotExpression CreateMetaNotExpression()
    	{
    		MetaNotExpression result = new MetaNotExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaUnaryAssignExpression.
        /// </summary>
        public MetaUnaryAssignExpression CreateMetaUnaryAssignExpression()
    	{
    		MetaUnaryAssignExpression result = new MetaUnaryAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPostIncrementAssignExpression.
        /// </summary>
        public MetaPostIncrementAssignExpression CreateMetaPostIncrementAssignExpression()
    	{
    		MetaPostIncrementAssignExpression result = new MetaPostIncrementAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPostDecrementAssignExpression.
        /// </summary>
        public MetaPostDecrementAssignExpression CreateMetaPostDecrementAssignExpression()
    	{
    		MetaPostDecrementAssignExpression result = new MetaPostDecrementAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPreIncrementAssignExpression.
        /// </summary>
        public MetaPreIncrementAssignExpression CreateMetaPreIncrementAssignExpression()
    	{
    		MetaPreIncrementAssignExpression result = new MetaPreIncrementAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPreDecrementAssignExpression.
        /// </summary>
        public MetaPreDecrementAssignExpression CreateMetaPreDecrementAssignExpression()
    	{
    		MetaPreDecrementAssignExpression result = new MetaPreDecrementAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryExpression.
        /// </summary>
        public MetaBinaryExpression CreateMetaBinaryExpression()
    	{
    		MetaBinaryExpression result = new MetaBinaryExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryArithmeticExpression.
        /// </summary>
        public MetaBinaryArithmeticExpression CreateMetaBinaryArithmeticExpression()
    	{
    		MetaBinaryArithmeticExpression result = new MetaBinaryArithmeticExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyExpression.
        /// </summary>
        public MetaMultiplyExpression CreateMetaMultiplyExpression()
    	{
    		MetaMultiplyExpression result = new MetaMultiplyExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaDivideExpression.
        /// </summary>
        public MetaDivideExpression CreateMetaDivideExpression()
    	{
    		MetaDivideExpression result = new MetaDivideExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaModuloExpression.
        /// </summary>
        public MetaModuloExpression CreateMetaModuloExpression()
    	{
    		MetaModuloExpression result = new MetaModuloExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAddExpression.
        /// </summary>
        public MetaAddExpression CreateMetaAddExpression()
    	{
    		MetaAddExpression result = new MetaAddExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaSubtractExpression.
        /// </summary>
        public MetaSubtractExpression CreateMetaSubtractExpression()
    	{
    		MetaSubtractExpression result = new MetaSubtractExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftExpression.
        /// </summary>
        public MetaLeftShiftExpression CreateMetaLeftShiftExpression()
    	{
    		MetaLeftShiftExpression result = new MetaLeftShiftExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftExpression.
        /// </summary>
        public MetaRightShiftExpression CreateMetaRightShiftExpression()
    	{
    		MetaRightShiftExpression result = new MetaRightShiftExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryComparisonExpression.
        /// </summary>
        public MetaBinaryComparisonExpression CreateMetaBinaryComparisonExpression()
    	{
    		MetaBinaryComparisonExpression result = new MetaBinaryComparisonExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaLessThanExpression.
        /// </summary>
        public MetaLessThanExpression CreateMetaLessThanExpression()
    	{
    		MetaLessThanExpression result = new MetaLessThanExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaLessThanOrEqualExpression.
        /// </summary>
        public MetaLessThanOrEqualExpression CreateMetaLessThanOrEqualExpression()
    	{
    		MetaLessThanOrEqualExpression result = new MetaLessThanOrEqualExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanExpression.
        /// </summary>
        public MetaGreaterThanExpression CreateMetaGreaterThanExpression()
    	{
    		MetaGreaterThanExpression result = new MetaGreaterThanExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaGreaterThanOrEqualExpression.
        /// </summary>
        public MetaGreaterThanOrEqualExpression CreateMetaGreaterThanOrEqualExpression()
    	{
    		MetaGreaterThanOrEqualExpression result = new MetaGreaterThanOrEqualExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaEqualExpression.
        /// </summary>
        public MetaEqualExpression CreateMetaEqualExpression()
    	{
    		MetaEqualExpression result = new MetaEqualExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNotEqualExpression.
        /// </summary>
        public MetaNotEqualExpression CreateMetaNotEqualExpression()
    	{
    		MetaNotEqualExpression result = new MetaNotEqualExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryLogicalExpression.
        /// </summary>
        public MetaBinaryLogicalExpression CreateMetaBinaryLogicalExpression()
    	{
    		MetaBinaryLogicalExpression result = new MetaBinaryLogicalExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAndExpression.
        /// </summary>
        public MetaAndExpression CreateMetaAndExpression()
    	{
    		MetaAndExpression result = new MetaAndExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOrExpression.
        /// </summary>
        public MetaOrExpression CreateMetaOrExpression()
    	{
    		MetaOrExpression result = new MetaOrExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrExpression.
        /// </summary>
        public MetaExclusiveOrExpression CreateMetaExclusiveOrExpression()
    	{
    		MetaExclusiveOrExpression result = new MetaExclusiveOrExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAndAlsoExpression.
        /// </summary>
        public MetaAndAlsoExpression CreateMetaAndAlsoExpression()
    	{
    		MetaAndAlsoExpression result = new MetaAndAlsoExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOrElseExpression.
        /// </summary>
        public MetaOrElseExpression CreateMetaOrElseExpression()
    	{
    		MetaOrElseExpression result = new MetaOrElseExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNullCoalescingExpression.
        /// </summary>
        public MetaNullCoalescingExpression CreateMetaNullCoalescingExpression()
    	{
    		MetaNullCoalescingExpression result = new MetaNullCoalescingExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAssignmentExpression.
        /// </summary>
        public MetaAssignmentExpression CreateMetaAssignmentExpression()
    	{
    		MetaAssignmentExpression result = new MetaAssignmentExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAssignExpression.
        /// </summary>
        public MetaAssignExpression CreateMetaAssignExpression()
    	{
    		MetaAssignExpression result = new MetaAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaArithmeticAssignmentExpression.
        /// </summary>
        public MetaArithmeticAssignmentExpression CreateMetaArithmeticAssignmentExpression()
    	{
    		MetaArithmeticAssignmentExpression result = new MetaArithmeticAssignmentExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaMultiplyAssignExpression.
        /// </summary>
        public MetaMultiplyAssignExpression CreateMetaMultiplyAssignExpression()
    	{
    		MetaMultiplyAssignExpression result = new MetaMultiplyAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaDivideAssignExpression.
        /// </summary>
        public MetaDivideAssignExpression CreateMetaDivideAssignExpression()
    	{
    		MetaDivideAssignExpression result = new MetaDivideAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaModuloAssignExpression.
        /// </summary>
        public MetaModuloAssignExpression CreateMetaModuloAssignExpression()
    	{
    		MetaModuloAssignExpression result = new MetaModuloAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAddAssignExpression.
        /// </summary>
        public MetaAddAssignExpression CreateMetaAddAssignExpression()
    	{
    		MetaAddAssignExpression result = new MetaAddAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaSubtractAssignExpression.
        /// </summary>
        public MetaSubtractAssignExpression CreateMetaSubtractAssignExpression()
    	{
    		MetaSubtractAssignExpression result = new MetaSubtractAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaLeftShiftAssignExpression.
        /// </summary>
        public MetaLeftShiftAssignExpression CreateMetaLeftShiftAssignExpression()
    	{
    		MetaLeftShiftAssignExpression result = new MetaLeftShiftAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaRightShiftAssignExpression.
        /// </summary>
        public MetaRightShiftAssignExpression CreateMetaRightShiftAssignExpression()
    	{
    		MetaRightShiftAssignExpression result = new MetaRightShiftAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaLogicalAssignmentExpression.
        /// </summary>
        public MetaLogicalAssignmentExpression CreateMetaLogicalAssignmentExpression()
    	{
    		MetaLogicalAssignmentExpression result = new MetaLogicalAssignmentExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAndAssignExpression.
        /// </summary>
        public MetaAndAssignExpression CreateMetaAndAssignExpression()
    	{
    		MetaAndAssignExpression result = new MetaAndAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaExclusiveOrAssignExpression.
        /// </summary>
        public MetaExclusiveOrAssignExpression CreateMetaExclusiveOrAssignExpression()
    	{
    		MetaExclusiveOrAssignExpression result = new MetaExclusiveOrAssignExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOrAssignExpression.
        /// </summary>
        public MetaOrAssignExpression CreateMetaOrAssignExpression()
    	{
    		MetaOrAssignExpression result = new MetaOrAssignExpressionImpl();
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
        /// Returns the value of the derived property: MetaDeclaration.Namespace
        /// </summary>
        public virtual MetaNamespace MetaDeclaration_Namespace(MetaDeclaration @this)
        {
            throw new NotImplementedException();
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
        /// </summary>
        public virtual void MetaExpression_MetaExpression(MetaExpression @this)
        {
            this.MetaTypedElement_MetaTypedElement(@this);
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaExpression.NoTypeError
        /// </summary>
        public virtual bool MetaExpression_NoTypeError(MetaExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBracketExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaBracketExpression_MetaBracketExpression(MetaBracketExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBoundExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaBoundExpression_MetaBoundExpression(MetaBoundExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaThisExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// </summary>
        public virtual void MetaThisExpression_MetaThisExpression(MetaThisExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaNullExpression_MetaNullExpression(MetaNullExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeConversionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeAsExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        /// </summary>
        public virtual void MetaTypeAsExpression_MetaTypeAsExpression(MetaTypeAsExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCastExpression()
    	/// Direct superclasses: MetaTypeConversionExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaTypeConversionExpression
        /// </summary>
        public virtual void MetaTypeCastExpression_MetaTypeCastExpression(MetaTypeCastExpression @this)
        {
            this.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCheckExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeOfExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConditionalExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstantExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaTypedElement, MetaExpression
        /// </summary>
        public virtual void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
            this.MetaExpression_MetaExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIdentifierExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// </summary>
        public virtual void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMemberAccessExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// </summary>
        public virtual void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionCallExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// </summary>
        public virtual void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIndexerExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        /// </summary>
        public virtual void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
            this.MetaBoundExpression_MetaBoundExpression(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperatorExpression()
    	/// Direct superclasses: MetaBoundExpression
    	/// All superclasses: MetaTypedElement, MetaExpression, MetaBoundExpression
        // Initializes the following readonly properties:
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
        ///    OperatorExpression.Name
        /// </summary>
        public virtual void MetaOrAssignExpression_MetaOrAssignExpression(MetaOrAssignExpression @this)
        {
            this.MetaLogicalAssignmentExpression_MetaLogicalAssignmentExpression(@this);
        }
    
    
    
    }
    
}

