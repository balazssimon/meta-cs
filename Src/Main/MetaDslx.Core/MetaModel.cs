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
            MetaOperation.StaticInit();
            MetaConstructor.StaticInit();
            MetaParameter.StaticInit();
            MetaProperty.StaticInit();
            MetaPropertyInitializer.StaticInit();
            MetaSynthetizedPropertyInitializer.StaticInit();
            MetaInheritedPropertyInitializer.StaticInit();
            MetaExpression.StaticInit();
            MetaThisExpression.StaticInit();
            MetaUnaryExpression.StaticInit();
            MetaBinaryExpression.StaticInit();
            MetaBinaryArithmeticExpression.StaticInit();
            MetaBinaryComparisonExpression.StaticInit();
            MetaBinaryLogicalExpression.StaticInit();
            MetaNullCoalescingExpression.StaticInit();
            MetaAssignmentExpression.StaticInit();
            MetaTypeConversionExpression.StaticInit();
            MetaTypeCheckExpression.StaticInit();
            MetaTypeOfExpression.StaticInit();
            MetaConstantExpression.StaticInit();
            MetaIdentifierExpression.StaticInit();
            MetaMemberAccessExpression.StaticInit();
            MetaFunctionCallExpression.StaticInit();
            MetaIndexerExpression.StaticInit();
            MetaConditionalExpression.StaticInit();
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
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaParameter), "Operation")]
            public static readonly ModelProperty ParametersProperty =
                ModelProperty.Register("Parameters", typeof(IList<global::MetaDslx.Core.MetaParameter>), typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.Meta.MetaOperation));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaOperation), typeof(global::MetaDslx.Core.Meta.MetaOperation));
            
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
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Meta.MetaOperation), "Parameters")]
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
        
            
            public static readonly ModelProperty KindProperty =
                ModelProperty.Register("Kind", typeof(global::MetaDslx.Core.MetaExpressionKind), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty ExpectedTypeProperty =
                ModelProperty.Register("ExpectedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
            
            public static readonly ModelProperty DefinitionsProperty =
                ModelProperty.Register("Definitions", typeof(IList<object>), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty DefinitionProperty =
                ModelProperty.Register("Definition", typeof(object), typeof(global::MetaDslx.Core.MetaExpression), typeof(global::MetaDslx.Core.Meta.MetaExpression));
            
        }
        
        public static class MetaThisExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaThisExpression()
            {
            }
        
            
            public static readonly ModelProperty ObjectProperty =
                ModelProperty.Register("Object", typeof(object), typeof(global::MetaDslx.Core.MetaThisExpression), typeof(global::MetaDslx.Core.Meta.MetaThisExpression));
            
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
        
        public static class MetaBinaryComparisonExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaBinaryComparisonExpression()
            {
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty BalancedTypeProperty =
                ModelProperty.Register("BalancedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaBinaryComparisonExpression), typeof(global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression));
            
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
        
        public static class MetaNullCoalescingExpression
        {
            internal static void StaticInit()
            {
            }
        
            static MetaNullCoalescingExpression()
            {
            }
        
            
            [ReadonlyAttribute]
            public static readonly ModelProperty BalancedTypeProperty =
                ModelProperty.Register("BalancedType", typeof(global::MetaDslx.Core.MetaType), typeof(global::MetaDslx.Core.MetaNullCoalescingExpression), typeof(global::MetaDslx.Core.Meta.MetaNullCoalescingExpression));
            
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
            
            
            public static readonly ModelProperty ObjectProperty =
                ModelProperty.Register("Object", typeof(object), typeof(global::MetaDslx.Core.MetaIdentifierExpression), typeof(global::MetaDslx.Core.Meta.MetaIdentifierExpression));
            
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
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ArgumentsProperty =
                ModelProperty.Register("Arguments", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaFunctionCallExpression), typeof(global::MetaDslx.Core.Meta.MetaFunctionCallExpression));
            
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
            
            
            [ContainmentAttribute]
            public static readonly ModelProperty ArgumentsProperty =
                ModelProperty.Register("Arguments", typeof(IList<global::MetaDslx.Core.MetaExpression>), typeof(global::MetaDslx.Core.MetaIndexerExpression), typeof(global::MetaDslx.Core.Meta.MetaIndexerExpression));
            
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
    
    
    public enum MetaExpressionKind
    {
        None,
        Identifier,
        Literal,
        Bracket,
        TypeOf,
        TypeCast,
        MemberAccess,
        FunctionCall,
        Indexer,
        TypeIs,
        TypeAs,
        And,
        Or,
        ExclusiveOr,
        AndAlso,
        OrElse,
        Coalesce,
        Conditional,
        PostIncrementAssign,
        PostDecrementAssign,
        PreIncrementAssign,
        PreDecrementAssign,
        UnaryPlus,
        Negate,
        OnesComplement,
        Not,
        Multiply,
        Divide,
        Modulo,
        Add,
        Subtract,
        LeftShift,
        RightShift,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual,
        Equal,
        NotEqual,
        Assign,
        MultiplyAssign,
        DivideAssign,
        ModuloAssign,
        AddAssign,
        SubtractAssign,
        LeftShiftAssign,
        RightShiftAssign,
        AndAssign,
        ExclusiveOrAssign,
        OrAssign,
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
    
    
    public interface MetaEnumLiteral : MetaDslx.Core.MetaNamedElement
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
    
    
    public interface MetaOperation : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaAnnotatedElement
    {
        MetaType Parent { get; set; }
        IList<MetaParameter> Parameters { get; }
        MetaType ReturnType { get; set; }
    
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
            this.MSet(global::MetaDslx.Core.Meta.MetaOperation.ParametersProperty, new ModelList<MetaParameter>(this, global::MetaDslx.Core.Meta.MetaOperation.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaOperation_MetaOperation(this);
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
        
        IList<MetaParameter> MetaOperation.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperation.ParametersProperty); 
                if (result != null) return (IList<MetaParameter>)result;
                else return default(IList<MetaParameter>);
            }
        }
        
        MetaType MetaOperation.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaOperation.ReturnTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaOperation.ReturnTypeProperty, value); }
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
            MetaImplementationProvider.Implementation.MetaPropertyInitializer_MetaPropertyInitializer(this);
            this.MMakeDefault();
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
            MetaImplementationProvider.Implementation.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(this);
            this.MMakeDefault();
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
    
    
    public interface MetaExpression
    {
        MetaExpressionKind Kind { get; set; }
        MetaType Type { get; }
        MetaType ExpectedType { get; }
        IList<object> Definitions { get; }
        object Definition { get; }
    
    }
    
    internal class MetaExpressionImpl : ModelObject, MetaDslx.Core.MetaExpression
    {
        static MetaExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaExpressionImpl()
        {
            MetaImplementationProvider.Implementation.MetaExpression_MetaExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
        }
    }
    
    
    public interface MetaThisExpression : MetaDslx.Core.MetaExpression
    {
        object Object { get; set; }
    
    }
    
    internal class MetaThisExpressionImpl : ModelObject, MetaDslx.Core.MetaThisExpression
    {
        static MetaThisExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaThisExpressionImpl()
        {
            MetaImplementationProvider.Implementation.MetaThisExpression_MetaThisExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
        }
        
        object MetaThisExpression.Object
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaThisExpression.ObjectProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaThisExpression.ObjectProperty, value); }
        }
    }
    
    
    public interface MetaUnaryExpression : MetaDslx.Core.MetaExpression
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
            MetaImplementationProvider.Implementation.MetaUnaryExpression_MetaUnaryExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
    
    
    public interface MetaBinaryExpression : MetaDslx.Core.MetaExpression
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
            MetaImplementationProvider.Implementation.MetaBinaryExpression_MetaBinaryExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
            MetaImplementationProvider.Implementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        MetaType BalancedType { get; }
    
    }
    
    internal class MetaBinaryComparisonExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryComparisonExpression
    {
        static MetaBinaryComparisonExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaBinaryComparisonExpressionImpl()
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.BalancedTypeProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaBinaryComparisonExpression_BalancedType(this)));
            MetaImplementationProvider.Implementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        
        MetaType MetaBinaryComparisonExpression.BalancedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaBinaryComparisonExpression.BalancedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
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
            MetaImplementationProvider.Implementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        MetaType BalancedType { get; }
    
    }
    
    internal class MetaNullCoalescingExpressionImpl : ModelObject, MetaDslx.Core.MetaNullCoalescingExpression
    {
        static MetaNullCoalescingExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaNullCoalescingExpressionImpl()
        {
            this.MLazySet(global::MetaDslx.Core.Meta.MetaNullCoalescingExpression.BalancedTypeProperty, new Lazy<object>(() => MetaImplementationProvider.Implementation.MetaNullCoalescingExpression_BalancedType(this)));
            MetaImplementationProvider.Implementation.MetaNullCoalescingExpression_MetaNullCoalescingExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        
        MetaType MetaNullCoalescingExpression.BalancedType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaNullCoalescingExpression.BalancedTypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
            }
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
            MetaImplementationProvider.Implementation.MetaAssignmentExpression_MetaAssignmentExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
            MetaImplementationProvider.Implementation.MetaTypeConversionExpression_MetaTypeConversionExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
            MetaImplementationProvider.Implementation.MetaTypeCheckExpression_MetaTypeCheckExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
            MetaImplementationProvider.Implementation.MetaTypeOfExpression_MetaTypeOfExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
            MetaImplementationProvider.Implementation.MetaConstantExpression_MetaConstantExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
    
    
    public interface MetaIdentifierExpression : MetaDslx.Core.MetaExpression
    {
        string Name { get; set; }
        object Object { get; set; }
    
    }
    
    internal class MetaIdentifierExpressionImpl : ModelObject, MetaDslx.Core.MetaIdentifierExpression
    {
        static MetaIdentifierExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaIdentifierExpressionImpl()
        {
            MetaImplementationProvider.Implementation.MetaIdentifierExpression_MetaIdentifierExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
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
        
        object MetaIdentifierExpression.Object
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaIdentifierExpression.ObjectProperty); 
                if (result != null) return (object)result;
                else return default(object);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaIdentifierExpression.ObjectProperty, value); }
        }
    }
    
    
    public interface MetaMemberAccessExpression : MetaDslx.Core.MetaExpression
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
            MetaImplementationProvider.Implementation.MetaMemberAccessExpression_MetaMemberAccessExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
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
    
    
    public interface MetaFunctionCallExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
        IList<MetaExpression> Arguments { get; }
    
    }
    
    internal class MetaFunctionCallExpressionImpl : ModelObject, MetaDslx.Core.MetaFunctionCallExpression
    {
        static MetaFunctionCallExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaFunctionCallExpressionImpl()
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ArgumentsProperty));
            MetaImplementationProvider.Implementation.MetaFunctionCallExpression_MetaFunctionCallExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
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
        
        IList<MetaExpression> MetaFunctionCallExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaFunctionCallExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
        }
    }
    
    
    public interface MetaIndexerExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
        IList<MetaExpression> Arguments { get; }
    
    }
    
    internal class MetaIndexerExpressionImpl : ModelObject, MetaDslx.Core.MetaIndexerExpression
    {
        static MetaIndexerExpressionImpl()
        {
            global::MetaDslx.Core.Meta.StaticInit();
        }
    
        public MetaIndexerExpressionImpl()
        {
            this.MSet(global::MetaDslx.Core.Meta.MetaIndexerExpression.ArgumentsProperty, new ModelList<MetaExpression>(this, global::MetaDslx.Core.Meta.MetaIndexerExpression.ArgumentsProperty));
            MetaImplementationProvider.Implementation.MetaIndexerExpression_MetaIndexerExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
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
        
        IList<MetaExpression> MetaIndexerExpression.Arguments
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaIndexerExpression.ArgumentsProperty); 
                if (result != null) return (IList<MetaExpression>)result;
                else return default(IList<MetaExpression>);
            }
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
            MetaImplementationProvider.Implementation.MetaConditionalExpression_MetaConditionalExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty); 
                if (result != null) return (MetaExpressionKind)result;
                else return default(MetaExpressionKind);
            }
            set { this.MSet(global::MetaDslx.Core.Meta.MetaExpression.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.TypeProperty); 
                if (result != null) return (MetaType)result;
                else return default(MetaType);
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
        
        IList<object> MetaExpression.Definitions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionsProperty); 
                if (result != null) return (IList<object>)result;
                else return default(IList<object>);
            }
        }
        
        object MetaExpression.Definition
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Core.Meta.MetaExpression.DefinitionProperty); 
                if (result != null) return (object)result;
                else return default(object);
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
        /// Creates a new instance of MetaThisExpression.
        /// </summary>
        public MetaThisExpression CreateMetaThisExpression()
    	{
    		MetaThisExpression result = new MetaThisExpressionImpl();
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
        /// Creates a new instance of MetaBinaryComparisonExpression.
        /// </summary>
        public MetaBinaryComparisonExpression CreateMetaBinaryComparisonExpression()
    	{
    		MetaBinaryComparisonExpression result = new MetaBinaryComparisonExpressionImpl();
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
        /// Creates a new instance of MetaTypeConversionExpression.
        /// </summary>
        public MetaTypeConversionExpression CreateMetaTypeConversionExpression()
    	{
    		MetaTypeConversionExpression result = new MetaTypeConversionExpressionImpl();
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
        /// Creates a new instance of MetaConditionalExpression.
        /// </summary>
        public MetaConditionalExpression CreateMetaConditionalExpression()
    	{
    		MetaConditionalExpression result = new MetaConditionalExpressionImpl();
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
    
    public static class MetaExpressionKindExtensions
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
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamespace()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaNamespace_MetaNamespace(MetaNamespace @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModel()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaModel_MetaModel(MetaModel @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDeclaration()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaDeclaration_MetaDeclaration(MetaDeclaration @this)
        {
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
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullableType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaNullableType_MetaNullableType(MetaNullableType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPrimitiveType()
    	/// Direct superclasses: MetaType, MetaNamedElement
    	/// All superclasses: MetaType, MetaNamedElement
        /// </summary>
        public virtual void MetaPrimitiveType_MetaPrimitiveType(MetaPrimitiveType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnum()
    	/// Direct superclasses: MetaType, MetaDeclaration
    	/// All superclasses: MetaType, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// </summary>
        public virtual void MetaEnum_MetaEnum(MetaEnum @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnumLiteral()
    	/// Direct superclasses: MetaNamedElement
    	/// All superclasses: MetaNamedElement
        /// </summary>
        public virtual void MetaEnumLiteral_MetaEnumLiteral(MetaEnumLiteral @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaClass()
    	/// Direct superclasses: MetaType, MetaDeclaration
    	/// All superclasses: MetaType, MetaNamedElement, MetaAnnotatedElement, MetaDeclaration
        /// </summary>
        public virtual void MetaClass_MetaClass(MetaClass @this)
        {
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
    	/// Implements the constructor: MetaOperation()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaOperation_MetaOperation(MetaOperation @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstructor()
    	/// Direct superclasses: MetaNamedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaConstructor_MetaConstructor(MetaConstructor @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaParameter()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaParameter_MetaParameter(MetaParameter @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaProperty()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
    	/// All superclasses: MetaNamedElement, MetaTypedElement, MetaAnnotatedElement
        /// </summary>
        public virtual void MetaProperty_MetaProperty(MetaProperty @this)
        {
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
        }
    
        /// <summary>
    	/// Implements the constructor: MetaInheritedPropertyInitializer()
    	/// Direct superclasses: MetaPropertyInitializer
    	/// All superclasses: MetaPropertyInitializer
        /// </summary>
        public virtual void MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(MetaInheritedPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExpression()
        /// </summary>
        public virtual void MetaExpression_MetaExpression(MetaExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaThisExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaThisExpression_MetaThisExpression(MetaThisExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryArithmeticExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(MetaBinaryArithmeticExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryComparisonExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(MetaBinaryComparisonExpression @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaBinaryComparisonExpression.BalancedType
        /// </summary>
        public virtual MetaType MetaBinaryComparisonExpression_BalancedType(MetaBinaryComparisonExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryLogicalExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(MetaBinaryLogicalExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullCoalescingExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaNullCoalescingExpression_MetaNullCoalescingExpression(MetaNullCoalescingExpression @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaNullCoalescingExpression.BalancedType
        /// </summary>
        public virtual MetaType MetaNullCoalescingExpression_BalancedType(MetaNullCoalescingExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignmentExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaAssignmentExpression_MetaAssignmentExpression(MetaAssignmentExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeConversionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCheckExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeOfExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstantExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIdentifierExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMemberAccessExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionCallExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIndexerExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConditionalExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
        }
    
    
    
    
    }
    
}

