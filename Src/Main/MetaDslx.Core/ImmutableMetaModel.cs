using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Core;
using System.Diagnostics;

namespace MetaDslx.Core.Immutable
{
    public static class MetaDescriptor
    {
        private static global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties;
    
        static MetaDescriptor()
        {
            MetaDescriptor.properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();
    		global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty> properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.Immutable.ModelProperty>();
            properties.Add(MetaAnnotatedElement.AnnotationsProperty);
            properties.Add(MetaDocumentedElement.DocumentationProperty);
            properties.Add(MetaNamedElement.NameProperty);
            properties.Add(MetaTypedElement.TypeProperty);
            properties.Add(MetaNamespace.ParentProperty);
            properties.Add(MetaNamespace.UsingsProperty);
            properties.Add(MetaNamespace.MetaModelProperty);
            properties.Add(MetaNamespace.NamespacesProperty);
            properties.Add(MetaNamespace.DeclarationsProperty);
            properties.Add(MetaDeclaration.NamespaceProperty);
            properties.Add(MetaDeclaration.ModelProperty);
            properties.Add(MetaModel.UriProperty);
            properties.Add(MetaModel.NamespaceProperty);
            properties.Add(MetaCollectionType.KindProperty);
            properties.Add(MetaCollectionType.InnerTypeProperty);
            properties.Add(MetaNullableType.InnerTypeProperty);
            properties.Add(MetaEnum.EnumLiteralsProperty);
            properties.Add(MetaEnum.OperationsProperty);
            properties.Add(MetaEnumLiteral.EnumProperty);
            properties.Add(MetaClass.IsAbstractProperty);
            properties.Add(MetaClass.SuperClassesProperty);
            properties.Add(MetaClass.PropertiesProperty);
            properties.Add(MetaClass.OperationsProperty);
            properties.Add(MetaClass.ConstructorProperty);
            properties.Add(MetaFunctionType.ParameterTypesProperty);
            properties.Add(MetaFunctionType.ReturnTypeProperty);
            properties.Add(MetaFunction.TypeProperty);
            properties.Add(MetaFunction.ParametersProperty);
            properties.Add(MetaFunction.ReturnTypeProperty);
            properties.Add(MetaOperation.ParentProperty);
            properties.Add(MetaConstructor.ParentProperty);
            properties.Add(MetaParameter.FunctionProperty);
            properties.Add(MetaProperty.KindProperty);
            properties.Add(MetaProperty.ClassProperty);
            properties.Add(MetaProperty.OppositePropertiesProperty);
            properties.Add(MetaProperty.SubsettedPropertiesProperty);
            properties.Add(MetaProperty.SubsettingPropertiesProperty);
            properties.Add(MetaProperty.RedefinedPropertiesProperty);
            properties.Add(MetaProperty.RedefiningPropertiesProperty);
        }
    
        public static void Initialize()
        {
        }
    
    	public const string Uri = "http://metadslx.core/1.0";
    
        
        [ModelSymbolDecriptor]
        public static class MetaAnnotatedElement
        {
            static MetaAnnotatedElement()
            {
                MetaAnnotatedElement.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaAnnotatedElement));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaAnnotatedElement;*/ }
            }
        
            [ContainmentAttribute]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty AnnotationsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaAnnotatedElement), "Annotations",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaAnnotation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaAnnotationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>)));
            
        }
        
        [ModelSymbolDecriptor]
        public static class MetaDocumentedElement
        {
            static MetaDocumentedElement()
            {
                MetaDocumentedElement.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaDocumentedElement));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaDocumentedElement;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty DocumentationProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaDocumentedElement), "Documentation",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement))]
        public static class MetaNamedElement
        {
            static MetaNamedElement()
            {
                MetaNamedElement.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNamedElement));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNamedElement;*/ }
            }
        
            [Name]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty NameProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamedElement), "Name",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null));
            
        }
        
        [ModelSymbolDecriptor]
        public static class MetaTypedElement
        {
            static MetaTypedElement()
            {
                MetaTypedElement.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaTypedElement));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaTypedElement;*/ }
            }
        
            [Type]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty TypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaTypedElement), "Type",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor]
        public static class MetaType
        {
            static MetaType()
            {
                MetaType.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaType));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaType;*/ }
            }
        
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement))]
        public static class MetaAnnotation
        {
            static MetaAnnotation()
            {
                MetaAnnotation.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaAnnotation));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaAnnotation;*/ }
            }
        
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaNamespace
        {
            static MetaNamespace()
            {
                MetaNamespace.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNamespace));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNamespace;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace), "Namespaces")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamespace), "Parent",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null));
            
            [ImportedScope]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty UsingsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamespace), "Usings",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>)));
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel), "Namespace")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty MetaModelProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamespace), "MetaModel",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModel), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModelBuilder), null));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace), "Parent")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespacesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamespace), "Namespaces",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>)));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration), "Namespace")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty DeclarationsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNamespace), "Declarations",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaDeclaration), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaDeclaration>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaDeclarationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder>)));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaDeclaration
        {
            static MetaDeclaration()
            {
                MetaDeclaration.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaDeclaration));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaDeclaration;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace), "Declarations")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespaceProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaDeclaration), "Namespace",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null));
            
            [ReadonlyAttribute]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ModelProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaDeclaration), "Model",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModel), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaModelBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaModel
        {
            static MetaModel()
            {
                MetaModel.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaModel));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaModel;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty UriProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaModel), "Uri",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(string), null));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace), "MetaModel")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty NamespaceProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaModel), "Namespace",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespace), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaNamespaceBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType))]
        public static class MetaCollectionType
        {
            static MetaCollectionType()
            {
                MetaCollectionType.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaCollectionType));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaCollectionType;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty KindProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaCollectionType), "Kind",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaCollectionKind), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaCollectionKind), null));
            
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty InnerTypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaCollectionType), "InnerType",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType))]
        public static class MetaNullableType
        {
            static MetaNullableType()
            {
                MetaNullableType.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaNullableType));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNullableType;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty InnerTypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaNullableType), "InnerType",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement))]
        public static class MetaPrimitiveType
        {
            static MetaPrimitiveType()
            {
                MetaPrimitiveType.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaPrimitiveType));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaPrimitiveType;*/ }
            }
        
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration))]
        public static class MetaEnum
        {
            static MetaEnum()
            {
                MetaEnum.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaEnum));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaEnum;*/ }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral), "Enum")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty EnumLiteralsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaEnum), "EnumLiterals",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumLiteral), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteral>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder>)));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation), "Parent")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty OperationsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaEnum), "Operations",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>)));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement))]
        public static class MetaEnumLiteral
        {
            static MetaEnumLiteral()
            {
                MetaEnumLiteral.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaEnumLiteral));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaEnumLiteral;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum), "EnumLiterals")]
            [RedefinesAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), "Type")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty EnumProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaEnumLiteral), "Enum",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnum), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaEnumBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration))]
        public static class MetaConstant
        {
            static MetaConstant()
            {
                MetaConstant.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaConstant));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaConstant;*/ }
            }
        
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration))]
        public static class MetaClass
        {
            static MetaClass()
            {
                MetaClass.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaClass));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass _MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaClass;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty IsAbstractProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaClass), "IsAbstract",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(bool), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(bool), null));
            
            [InheritedScope]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty SuperClassesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaClass), "SuperClasses",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaClassBuilder>)));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "Class")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty PropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaClass), "Properties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation), "Parent")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty OperationsProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaClass), "Operations",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperation), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaOperationBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>)));
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor), "Parent")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ConstructorProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaClass), "Constructor",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaConstructor), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaConstructorBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaType))]
        public static class MetaFunctionType
        {
            static MetaFunctionType()
            {
                MetaFunctionType.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaFunctionType));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaFunctionType;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParameterTypesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaFunctionType), "ParameterTypes",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaType>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaTypeBuilder>)));
            
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ReturnTypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaFunctionType), "ReturnType",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaFunction
        {
            static MetaFunction()
            {
                MetaFunction.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaFunction));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaFunction;*/ }
            }
        
            [Type]
            [ReadonlyAttribute]
            [RedefinesAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), "Type")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty TypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaFunction), "Type",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder), null));
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter), "Function")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParametersProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaFunction), "Parameters",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaParameter), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaParameterBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder>)));
            
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ReturnTypeProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaFunction), "ReturnType",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction))]
        public static class MetaOperation
        {
            static MetaOperation()
            {
                MetaOperation.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaOperation));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaOperation;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass), "Operations")]
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum), "Operations")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaOperation), "Parent",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaType), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaTypeBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaConstructor
        {
            static MetaConstructor()
            {
                MetaConstructor.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaConstructor));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaConstructor;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass), "Constructor")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ParentProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaConstructor), "Parent",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaParameter
        {
            static MetaParameter()
            {
                MetaParameter.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaParameter));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaParameter;*/ }
            }
        
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction), "Parameters")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty FunctionProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaParameter), "Function",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunction), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaFunctionBuilder), null));
            
        }
        
        [ModelSymbolDecriptor(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement), typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement))]
        public static class MetaProperty
        {
            static MetaProperty()
            {
                MetaProperty.ModelSymbolInfo = global::MetaDslx.Core.Immutable.ModelSymbolInfo.GetSymbolInfo(typeof(MetaProperty));
            }
        
            public static global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get; }
        
            public static global::MetaDslx.Core.Immutable.MetaClass MetaClass
            {
                get { return null;/*global::MetaDslx.Core.MetaInstance.MetaProperty;*/ }
            }
        
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty KindProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "Kind",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyKind), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyKind), null));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass), "Properties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty ClassProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "Class",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClass), null),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaClassBuilder), null));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "OppositeProperties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty OppositePropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "OppositeProperties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "SubsettingProperties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty SubsettedPropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "SubsettedProperties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "SubsettedProperties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty SubsettingPropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "SubsettingProperties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "RedefiningProperties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty RedefinedPropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "RedefinedProperties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
            [OppositeAttribute(typeof(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty), "RedefinedProperties")]
            public static readonly global::MetaDslx.Core.Immutable.ModelProperty RedefiningPropertiesProperty =
                global::MetaDslx.Core.Immutable.ModelProperty.Register(typeof(MetaDescriptor.MetaProperty), "RedefiningProperties",
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaProperty), typeof(global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty>)),
                    new global::MetaDslx.Core.Immutable.ModelPropertyTypeInfo(typeof(global::MetaDslx.Core.Immutable.MetaPropertyBuilder), typeof(global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>)));
            
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
        DerivedUnion,
        Containment,
    }
    
    internal class MetaAnnotatedElementId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaAnnotatedElement.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaAnnotatedElement); } }
        public override global::System.Type MutableType { get { return typeof(MetaAnnotatedElementBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaAnnotatedElementImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaAnnotatedElementBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaAnnotatedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
    {
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations { get; }
    
    
    	new MetaAnnotatedElementBuilder ToMutable();
    	new MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaDocumentedElementId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaDocumentedElement.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaDocumentedElement); } }
        public override global::System.Type MutableType { get { return typeof(MetaDocumentedElementBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaDocumentedElementImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaDocumentedElementBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaDocumentedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
    {
        string Documentation { get; }
    
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> GetDocumentationLines();
    
    	new MetaDocumentedElementBuilder ToMutable();
    	new MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaNamedElementId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaNamedElement.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaNamedElement); } }
        public override global::System.Type MutableType { get { return typeof(MetaNamedElementBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaNamedElementImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaNamedElementBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaNamedElement : global::MetaDslx.Core.Immutable.MetaDocumentedElement
    {
        string Name { get; }
    
    
    	new MetaNamedElementBuilder ToMutable();
    	new MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaTypedElementId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaTypedElement.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaTypedElement); } }
        public override global::System.Type MutableType { get { return typeof(MetaTypedElementBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaTypedElementImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaTypedElementBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaTypedElement : global::MetaDslx.Core.Immutable.ImmutableSymbol
    {
        global::MetaDslx.Core.Immutable.MetaType Type { get; }
    
    
    	new MetaTypedElementBuilder ToMutable();
    	new MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaTypeId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaType.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaType); } }
        public override global::System.Type MutableType { get { return typeof(MetaTypeBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaTypeImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaTypeBuilderImpl(this, model, creating);
        }
    }
    
    [Type]
    public interface MetaType : global::MetaDslx.Core.Immutable.ImmutableSymbol
    {
    
    
    	new MetaTypeBuilder ToMutable();
    	new MetaTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaAnnotationId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaAnnotation.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaAnnotation); } }
        public override global::System.Type MutableType { get { return typeof(MetaAnnotationBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaAnnotationImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaAnnotationBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaAnnotation : global::MetaDslx.Core.Immutable.MetaNamedElement
    {
    
    
    	new MetaAnnotationBuilder ToMutable();
    	new MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaNamespaceId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaNamespace.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaNamespace); } }
        public override global::System.Type MutableType { get { return typeof(MetaNamespaceBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaNamespaceImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaNamespaceBuilderImpl(this, model, creating);
        }
    }
    
    [Scope]
    public interface MetaNamespace : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        global::MetaDslx.Core.Immutable.MetaNamespace Parent { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> Usings { get; }
        global::MetaDslx.Core.Immutable.MetaModel MetaModel { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> Namespaces { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaDeclaration> Declarations { get; }
    
    
    	new MetaNamespaceBuilder ToMutable();
    	new MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaDeclarationId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaDeclaration.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaDeclaration); } }
        public override global::System.Type MutableType { get { return typeof(MetaDeclarationBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaDeclarationImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaDeclarationBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaDeclaration : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        global::MetaDslx.Core.Immutable.MetaNamespace Namespace { get; }
        global::MetaDslx.Core.Immutable.MetaModel Model { get; }
    
    
    	new MetaDeclarationBuilder ToMutable();
    	new MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaModelId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaModel.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaModel); } }
        public override global::System.Type MutableType { get { return typeof(MetaModelBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaModelImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaModelBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaModel : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        string Uri { get; }
        global::MetaDslx.Core.Immutable.MetaNamespace Namespace { get; }
    
    
    	new MetaModelBuilder ToMutable();
    	new MetaModelBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaCollectionTypeId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaCollectionType.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaCollectionType); } }
        public override global::System.Type MutableType { get { return typeof(MetaCollectionTypeBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaCollectionTypeImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaCollectionTypeBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaCollectionType : global::MetaDslx.Core.Immutable.MetaType
    {
        global::MetaDslx.Core.Immutable.MetaCollectionKind Kind { get; }
        global::MetaDslx.Core.Immutable.MetaType InnerType { get; }
    
    
    	new MetaCollectionTypeBuilder ToMutable();
    	new MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaNullableTypeId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaNullableType.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaNullableType); } }
        public override global::System.Type MutableType { get { return typeof(MetaNullableTypeBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaNullableTypeImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaNullableTypeBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaNullableType : global::MetaDslx.Core.Immutable.MetaType
    {
        global::MetaDslx.Core.Immutable.MetaType InnerType { get; }
    
    
    	new MetaNullableTypeBuilder ToMutable();
    	new MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaPrimitiveTypeId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaPrimitiveType.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaPrimitiveType); } }
        public override global::System.Type MutableType { get { return typeof(MetaPrimitiveTypeBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaPrimitiveTypeImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaPrimitiveTypeBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaPrimitiveType : global::MetaDslx.Core.Immutable.MetaType, global::MetaDslx.Core.Immutable.MetaNamedElement
    {
    
    
    	new MetaPrimitiveTypeBuilder ToMutable();
    	new MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaEnumId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaEnum.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaEnum); } }
        public override global::System.Type MutableType { get { return typeof(MetaEnumBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaEnumImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaEnumBuilderImpl(this, model, creating);
        }
    }
    
    [Scope]
    public interface MetaEnum : global::MetaDslx.Core.Immutable.MetaType, global::MetaDslx.Core.Immutable.MetaDeclaration
    {
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteral> EnumLiterals { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> Operations { get; }
    
    
    	new MetaEnumBuilder ToMutable();
    	new MetaEnumBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaEnumLiteralId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaEnumLiteral.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaEnumLiteral); } }
        public override global::System.Type MutableType { get { return typeof(MetaEnumLiteralBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaEnumLiteralImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaEnumLiteralBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaEnumLiteral : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaTypedElement
    {
        global::MetaDslx.Core.Immutable.MetaEnum Enum { get; }
    
    
    	new MetaEnumLiteralBuilder ToMutable();
    	new MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaConstantId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaConstant.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaConstant); } }
        public override global::System.Type MutableType { get { return typeof(MetaConstantBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaConstantImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaConstantBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaConstant : global::MetaDslx.Core.Immutable.MetaTypedElement, global::MetaDslx.Core.Immutable.MetaDeclaration
    {
    
    
    	new MetaConstantBuilder ToMutable();
    	new MetaConstantBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaClassId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaClass.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaClass); } }
        public override global::System.Type MutableType { get { return typeof(MetaClassBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaClassImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaClassBuilderImpl(this, model, creating);
        }
    }
    
    [Scope]
    public interface MetaClass : global::MetaDslx.Core.Immutable.MetaType, global::MetaDslx.Core.Immutable.MetaDeclaration
    {
        bool IsAbstract { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> SuperClasses { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> Properties { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> Operations { get; }
        global::MetaDslx.Core.Immutable.MetaConstructor Constructor { get; }
    
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> GetAllSuperClasses();
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> GetAllProperties();
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> GetAllOperations();
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> GetAllImplementedProperties();
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> GetAllImplementedOperations();
    
    	new MetaClassBuilder ToMutable();
    	new MetaClassBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaFunctionTypeId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaFunctionType.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaFunctionType); } }
        public override global::System.Type MutableType { get { return typeof(MetaFunctionTypeBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaFunctionTypeImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaFunctionTypeBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaFunctionType : global::MetaDslx.Core.Immutable.MetaType
    {
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaType> ParameterTypes { get; }
        global::MetaDslx.Core.Immutable.MetaType ReturnType { get; }
    
    
    	new MetaFunctionTypeBuilder ToMutable();
    	new MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaFunctionId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaFunction.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaFunction); } }
        public override global::System.Type MutableType { get { return typeof(MetaFunctionBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaFunctionImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaFunctionBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaFunction : global::MetaDslx.Core.Immutable.MetaTypedElement, global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        new global::MetaDslx.Core.Immutable.MetaFunctionType Type { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter> Parameters { get; }
        global::MetaDslx.Core.Immutable.MetaType ReturnType { get; }
    
    
    	new MetaFunctionBuilder ToMutable();
    	new MetaFunctionBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaOperationId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaOperation.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaOperation); } }
        public override global::System.Type MutableType { get { return typeof(MetaOperationBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaOperationImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaOperationBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaOperation : global::MetaDslx.Core.Immutable.MetaFunction
    {
        global::MetaDslx.Core.Immutable.MetaType Parent { get; }
    
    
    	new MetaOperationBuilder ToMutable();
    	new MetaOperationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaConstructorId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaConstructor.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaConstructor); } }
        public override global::System.Type MutableType { get { return typeof(MetaConstructorBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaConstructorImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaConstructorBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaConstructor : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        global::MetaDslx.Core.Immutable.MetaClass Parent { get; }
    
    
    	new MetaConstructorBuilder ToMutable();
    	new MetaConstructorBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaParameterId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaParameter.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaParameter); } }
        public override global::System.Type MutableType { get { return typeof(MetaParameterBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaParameterImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaParameterBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaParameter : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaTypedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        global::MetaDslx.Core.Immutable.MetaFunction Function { get; }
    
    
    	new MetaParameterBuilder ToMutable();
    	new MetaParameterBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    internal class MetaPropertyId : global::MetaDslx.Core.Immutable.SymbolId
    {
    	public override global::MetaDslx.Core.Immutable.ModelSymbolInfo ModelSymbolInfo { get { return MetaDescriptor.MetaProperty.ModelSymbolInfo; } }
        public override global::System.Type ImmutableType { get { return typeof(MetaProperty); } }
        public override global::System.Type MutableType { get { return typeof(MetaPropertyBuilder); } }
    
        public override global::MetaDslx.Core.Immutable.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
        {
            return new MetaPropertyImpl(this, model);
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase CreateMutable(global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
        {
            return new MetaPropertyBuilderImpl(this, model, creating);
        }
    }
    
    public interface MetaProperty : global::MetaDslx.Core.Immutable.MetaNamedElement, global::MetaDslx.Core.Immutable.MetaTypedElement, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        global::MetaDslx.Core.Immutable.MetaPropertyKind Kind { get; }
        global::MetaDslx.Core.Immutable.MetaClass Class { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> OppositeProperties { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> SubsettedProperties { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> SubsettingProperties { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> RedefinedProperties { get; }
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> RedefiningProperties { get; }
    
    
    	new MetaPropertyBuilder ToMutable();
    	new MetaPropertyBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model);
    }
    
    public interface MetaAnnotatedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
    {
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations { get; }
    
    	new MetaAnnotatedElement ToImmutable();
    	new MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaDocumentedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
    {
        string Documentation { get; set; }
        Func<string> DocumentationLazy { get; set; }
    
    	new MetaDocumentedElement ToImmutable();
    	new MetaDocumentedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaNamedElementBuilder : global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder
    {
        string Name { get; set; }
        Func<string> NameLazy { get; set; }
    
    	new MetaNamedElement ToImmutable();
    	new MetaNamedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaTypedElementBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
    {
        global::MetaDslx.Core.Immutable.MetaTypeBuilder Type { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy { get; set; }
    
    	new MetaTypedElement ToImmutable();
    	new MetaTypedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaTypeBuilder : global::MetaDslx.Core.Immutable.MutableSymbol
    {
    
    	new MetaType ToImmutable();
    	new MetaType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaAnnotationBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder
    {
    
    	new MetaAnnotation ToImmutable();
    	new MetaAnnotation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaNamespaceBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Parent { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> ParentLazy { get; set; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> Usings { get; }
        global::MetaDslx.Core.Immutable.MetaModelBuilder MetaModel { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> MetaModelLazy { get; set; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> Namespaces { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder> Declarations { get; }
    
    	new MetaNamespace ToImmutable();
    	new MetaNamespace ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaDeclarationBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy { get; set; }
        global::MetaDslx.Core.Immutable.MetaModelBuilder Model { get; }
        Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> ModelLazy { get; set; }
    
    	new MetaDeclaration ToImmutable();
    	new MetaDeclaration ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaModelBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        string Uri { get; set; }
        Func<string> UriLazy { get; set; }
        global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy { get; set; }
    
    	new MetaModel ToImmutable();
    	new MetaModel ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaCollectionTypeBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder
    {
        global::MetaDslx.Core.Immutable.MetaCollectionKind Kind { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaCollectionKind> KindLazy { get; set; }
        global::MetaDslx.Core.Immutable.MetaTypeBuilder InnerType { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> InnerTypeLazy { get; set; }
    
    	new MetaCollectionType ToImmutable();
    	new MetaCollectionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaNullableTypeBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder
    {
        global::MetaDslx.Core.Immutable.MetaTypeBuilder InnerType { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> InnerTypeLazy { get; set; }
    
    	new MetaNullableType ToImmutable();
    	new MetaNullableType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaPrimitiveTypeBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder, global::MetaDslx.Core.Immutable.MetaNamedElementBuilder
    {
    
    	new MetaPrimitiveType ToImmutable();
    	new MetaPrimitiveType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaEnumBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder, global::MetaDslx.Core.Immutable.MetaDeclarationBuilder
    {
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder> EnumLiterals { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> Operations { get; }
    
    	new MetaEnum ToImmutable();
    	new MetaEnum ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaEnumLiteralBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaTypedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaEnumBuilder Enum { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaEnumBuilder> EnumLazy { get; set; }
    
    	new MetaEnumLiteral ToImmutable();
    	new MetaEnumLiteral ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaConstantBuilder : global::MetaDslx.Core.Immutable.MetaTypedElementBuilder, global::MetaDslx.Core.Immutable.MetaDeclarationBuilder
    {
    
    	new MetaConstant ToImmutable();
    	new MetaConstant ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaClassBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder, global::MetaDslx.Core.Immutable.MetaDeclarationBuilder
    {
        bool IsAbstract { get; set; }
        Func<bool> IsAbstractLazy { get; set; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaClassBuilder> SuperClasses { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> Properties { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> Operations { get; }
        global::MetaDslx.Core.Immutable.MetaConstructorBuilder Constructor { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaConstructorBuilder> ConstructorLazy { get; set; }
    
    	new MetaClass ToImmutable();
    	new MetaClass ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaFunctionTypeBuilder : global::MetaDslx.Core.Immutable.MetaTypeBuilder
    {
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ParameterTypes { get; }
        global::MetaDslx.Core.Immutable.MetaTypeBuilder ReturnType { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ReturnTypeLazy { get; set; }
    
    	new MetaFunctionType ToImmutable();
    	new MetaFunctionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaFunctionBuilder : global::MetaDslx.Core.Immutable.MetaTypedElementBuilder, global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        new global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder Type { get; }
        new Func<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder> TypeLazy { get; set; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder> Parameters { get; }
        global::MetaDslx.Core.Immutable.MetaTypeBuilder ReturnType { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ReturnTypeLazy { get; set; }
    
    	new MetaFunction ToImmutable();
    	new MetaFunction ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaOperationBuilder : global::MetaDslx.Core.Immutable.MetaFunctionBuilder
    {
        global::MetaDslx.Core.Immutable.MetaTypeBuilder Parent { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ParentLazy { get; set; }
    
    	new MetaOperation ToImmutable();
    	new MetaOperation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaConstructorBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaClassBuilder Parent { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaClassBuilder> ParentLazy { get; set; }
    
    	new MetaConstructor ToImmutable();
    	new MetaConstructor ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaParameterBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaTypedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaFunctionBuilder Function { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaFunctionBuilder> FunctionLazy { get; set; }
    
    	new MetaParameter ToImmutable();
    	new MetaParameter ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    public interface MetaPropertyBuilder : global::MetaDslx.Core.Immutable.MetaNamedElementBuilder, global::MetaDslx.Core.Immutable.MetaTypedElementBuilder, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        global::MetaDslx.Core.Immutable.MetaPropertyKind Kind { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaPropertyKind> KindLazy { get; set; }
        global::MetaDslx.Core.Immutable.MetaClassBuilder Class { get; set; }
        Func<global::MetaDslx.Core.Immutable.MetaClassBuilder> ClassLazy { get; set; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> OppositeProperties { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> SubsettedProperties { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> SubsettingProperties { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> RedefinedProperties { get; }
        global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> RedefiningProperties { get; }
    
    	new MetaProperty ToImmutable();
    	new MetaProperty ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model);
    }
    
    internal class MetaAnnotatedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaAnnotatedElement
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaAnnotatedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaAnnotatedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder)base.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaDocumentedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaDocumentedElement
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
    
        internal MetaDocumentedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaDocumentedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder)base.ToMutable(model);
    	}
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaNamedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNamedElement
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
    
        internal MetaNamedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaNamedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNamedElementBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamedElementBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNamedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamedElementBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaTypedElementImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaTypedElement
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type0;
    
        internal MetaTypedElementImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaTypedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaTypedElementBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypedElementBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaTypedElementBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypedElementBuilder)base.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
        }
    }
    
    internal class MetaTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaType
    {
    
        internal MetaTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaTypeBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypeBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypeBuilder)base.ToMutable(model);
    	}
    }
    
    internal class MetaAnnotationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaAnnotation
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
    
        internal MetaAnnotationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaAnnotation;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotationBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotationBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotationBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaNamespaceImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNamespace
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace parent0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> usings0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaModel metaModel0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> namespaces0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaDeclaration> declarations0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaNamespaceImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaNamespace;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNamespaceBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamespaceBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNamespaceBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamespaceBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty, ref parent0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> Usings
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModel MetaModel
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty, ref metaModel0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaNamespace> Namespaces
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaDeclaration> Declarations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaDeclaration>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaDeclarationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaDeclaration
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace namespace0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaModel model0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaDeclarationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaDeclaration;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaDeclarationBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDeclarationBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaDeclarationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDeclarationBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModel Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, ref model0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaModelImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaModel
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string uri0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace namespace0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaModelImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaModel;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaModelBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaModelBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaModelBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaModelBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public string Uri
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty, ref uri0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty, ref namespace0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaCollectionTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaCollectionType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaCollectionKind kind0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType innerType0;
    
        internal MetaCollectionTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaCollectionType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaCollectionKind Kind
        {
            get { return this.GetValue<global::MetaDslx.Core.Immutable.MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty, ref kind0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType InnerType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty, ref innerType0); }
        }
    }
    
    internal class MetaNullableTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNullableType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType innerType0;
    
        internal MetaNullableTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaNullableType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNullableTypeBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNullableTypeBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNullableTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNullableTypeBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaType InnerType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty, ref innerType0); }
        }
    }
    
    internal class MetaPrimitiveTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaPrimitiveType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
    
        internal MetaPrimitiveTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaPrimitiveType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaEnumImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaEnum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteral> enumLiterals0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> operations0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace namespace0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaModel model0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaEnumImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaEnum;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaEnumBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaEnumBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteral> EnumLiterals
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaEnumLiteral>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> Operations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaOperation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModel Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, ref model0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaEnumLiteralImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaEnumLiteral
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaEnum enum0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type0;
    
        internal MetaEnumLiteralImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaEnumLiteral;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaEnum Enum
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaEnum>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty, ref enum0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaConstantImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaConstant
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace namespace0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaModel model0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaConstantImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaConstant;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaConstantBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstantBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaConstantBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstantBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModel Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, ref model0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaClassImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaClass
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool isAbstract0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> superClasses0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> properties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> operations0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaConstructor constructor0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaNamespace namespace0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaModel model0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaClassImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaClass;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaClassBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaClassBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaClassBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaClassBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclarationBuilder global::MetaDslx.Core.Immutable.MetaDeclaration.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public bool IsAbstract
        {
            get { return this.GetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty, ref isAbstract0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> SuperClasses
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> Properties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> Operations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaOperation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaConstructor Constructor
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaConstructor>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty, ref constructor0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespace Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespace>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, ref namespace0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModel Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModel>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, ref model0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> global::MetaDslx.Core.Immutable.MetaClass.GetAllSuperClasses()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this);
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> global::MetaDslx.Core.Immutable.MetaClass.GetAllProperties()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> global::MetaDslx.Core.Immutable.MetaClass.GetAllOperations()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> global::MetaDslx.Core.Immutable.MetaClass.GetAllImplementedProperties()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaClass_GetAllImplementedProperties(this);
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> global::MetaDslx.Core.Immutable.MetaClass.GetAllImplementedOperations()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaClass_GetAllImplementedOperations(this);
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaFunctionTypeImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaFunctionType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaType> parameterTypes0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType returnType0;
    
        internal MetaFunctionTypeImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaFunctionType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaType.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaType> ParameterTypes
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, ref returnType0); }
        }
    }
    
    internal class MetaFunctionImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaFunction
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaFunctionType type0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter> parameters0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType returnType0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaFunctionImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaFunction;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaFunctionType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunctionType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, ref type0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter> Parameters
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaParameter>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
        }
    
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypedElement.Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type1); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaOperationImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaOperation
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType parent0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaFunctionType type0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter> parameters0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType returnType0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type1;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaOperationImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaOperation;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaOperationBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaOperationBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaOperationBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaOperationBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaFunctionBuilder global::MetaDslx.Core.Immutable.MetaFunction.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaFunctionBuilder global::MetaDslx.Core.Immutable.MetaFunction.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaType Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty, ref parent0); }
        }
    
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        global::MetaDslx.Core.Immutable.MetaFunctionType global::MetaDslx.Core.Immutable.MetaFunction.Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunctionType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, ref type0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaParameter> Parameters
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaParameter>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, ref returnType0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type1); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaConstructorImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaConstructor
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaClass parent0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaConstructorImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaConstructor;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaConstructorBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstructorBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaConstructorBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstructorBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaClass Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty, ref parent0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaParameterImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaParameter
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaFunction function0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaParameterImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaParameter;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaParameterBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaParameterBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaParameterBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaParameterBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaFunction Function
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunction>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty, ref function0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaPropertyImpl : global::MetaDslx.Core.Immutable.ImmutableSymbolBase, global::MetaDslx.Core.Immutable.MetaProperty
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaPropertyKind kind0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaClass class0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> oppositeProperties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> subsettedProperties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> subsettingProperties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> redefinedProperties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> redefiningProperties0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string name0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string documentation0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.MetaType type0;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> annotations0;
    
        internal MetaPropertyImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.ImmutableModel model)
    		: base(id, model)
        {
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null; /*global::MetaDslx.Core.MetaInstance.MetaProperty;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaPropertyBuilder ToMutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPropertyBuilder)base.ToMutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaPropertyBuilder ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPropertyBuilder)base.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElementBuilder global::MetaDslx.Core.Immutable.MetaNamedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder global::MetaDslx.Core.Immutable.MetaDocumentedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElementBuilder global::MetaDslx.Core.Immutable.MetaTypedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable()
    	{
    		return this.ToMutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder global::MetaDslx.Core.Immutable.MetaAnnotatedElement.ToMutable(global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    		return this.ToMutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaPropertyKind Kind
        {
            get { return this.GetValue<global::MetaDslx.Core.Immutable.MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty, ref kind0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaClass Class
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaClass>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty, ref class0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> OppositeProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> SubsettedProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> SubsettingProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> RedefinedProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> RedefiningProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaProperty>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, ref name0); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, ref documentation0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaType Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaType>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, ref type0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotation> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotation>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    
        
        global::MetaDslx.Core.Immutable.ImmutableModelList<string> global::MetaDslx.Core.Immutable.MetaDocumentedElement.GetDocumentationLines()
        {
            return global::MetaDslx.Core.Immutable.MetaImplementationProvider.Implementation.MetaDocumentedElement_GetDocumentationLines(this);
        }
    }
    
    internal class MetaAnnotatedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaAnnotatedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaAnnotatedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotatedElement ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotatedElement)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotatedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotatedElement)base.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaDocumentedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder
    {
    
        internal MetaDocumentedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaDocumentedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaDocumentedElement ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDocumentedElement)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaDocumentedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDocumentedElement)base.ToImmutable(model);
    	}
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    }
    
    internal class MetaNamedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNamedElementBuilder
    {
    
        internal MetaNamedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNamedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNamedElement ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamedElement)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNamedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamedElement)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    }
    
    internal class MetaTypedElementBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaTypedElementBuilder
    {
    
        internal MetaTypedElementBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaTypedElement;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaTypedElement ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypedElement)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaTypedElement ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaTypedElement)base.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    }
    
    internal class MetaTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaTypeBuilder
    {
    
        internal MetaTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaType ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaType)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaType)base.ToImmutable(model);
    	}
    }
    
    internal class MetaAnnotationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaAnnotationBuilder
    {
    
        internal MetaAnnotationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotation(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaAnnotation;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotation ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotation)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaAnnotation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaAnnotation)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    }
    
    internal class MetaNamespaceBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNamespaceBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> usings0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> namespaces0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder> declarations0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaNamespaceBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaNamespace(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNamespace;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNamespace ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamespace)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNamespace ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNamespace)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> ParentLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.ParentProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> Usings
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.UsingsProperty, ref usings0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModelBuilder MetaModel
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> MetaModelLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.MetaModelProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> Namespaces
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.NamespacesProperty, ref namespaces0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder> Declarations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaDeclarationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamespace.DeclarationsProperty, ref declarations0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaDeclarationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaDeclarationBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaDeclarationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaDeclaration(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaDeclaration;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaDeclaration ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDeclaration)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaDeclaration ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaDeclaration)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModelBuilder Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> ModelLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaModelBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaModelBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaModelBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaModel(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaModel;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaModel ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaModel)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaModel ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaModel)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public string Uri
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty, value); }
        }
        
        public Func<string> UriLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.UriProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaModel.NamespaceProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaCollectionTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder
    {
    
        internal MetaCollectionTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaCollectionType(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaCollectionType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaCollectionType ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaCollectionType)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaCollectionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaCollectionType)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaCollectionKind Kind
        {
            get { return this.GetValue<global::MetaDslx.Core.Immutable.MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty); }
            set { this.SetValue<global::MetaDslx.Core.Immutable.MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaCollectionKind> KindLazy
        {
            get { return this.GetLazyValue<global::MetaDslx.Core.Immutable.MetaCollectionKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty); }
            set { this.SetLazyValue(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.KindProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder InnerType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> InnerTypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaCollectionType.InnerTypeProperty, value); }
        }
    }
    
    internal class MetaNullableTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaNullableTypeBuilder
    {
    
        internal MetaNullableTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaNullableType(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaNullableType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaNullableType ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNullableType)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaNullableType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaNullableType)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder InnerType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> InnerTypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNullableType.InnerTypeProperty, value); }
        }
    }
    
    internal class MetaPrimitiveTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder
    {
    
        internal MetaPrimitiveTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaPrimitiveType(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaPrimitiveType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaPrimitiveType ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPrimitiveType)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaPrimitiveType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaPrimitiveType)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    }
    
    internal class MetaEnumBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaEnumBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder> enumLiterals0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> operations0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaEnumBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaDeclaration(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaEnum(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaEnum;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaEnum ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnum)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaEnum ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnum)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder> EnumLiterals
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.EnumLiteralsProperty, ref enumLiterals0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> Operations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnum.OperationsProperty, ref operations0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModelBuilder Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> ModelLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaEnumLiteralBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder
    {
    
        internal MetaEnumLiteralBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaEnumLiteral(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaEnumLiteral;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaEnumLiteral ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumLiteral)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaEnumLiteral ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaEnumLiteral)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaEnumBuilder Enum
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaEnumBuilder> EnumLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaEnumBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaEnumLiteral.EnumProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    }
    
    internal class MetaConstantBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaConstantBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaConstantBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaDeclaration(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaConstant(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaConstant;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaConstant ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstant)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaConstant ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstant)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModelBuilder Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> ModelLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaClassBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaClassBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaClassBuilder> superClasses0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> properties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> operations0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaClassBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaDeclaration(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaClass(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaClass;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaClass ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaClass)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaClass ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaClass)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDeclaration global::MetaDslx.Core.Immutable.MetaDeclarationBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public bool IsAbstract
        {
            get { return this.GetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty); }
            set { this.SetValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
        }
        
        public Func<bool> IsAbstractLazy
        {
            get { return this.GetLazyValue<bool>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty); }
            set { this.SetLazyValue(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.IsAbstractProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaClassBuilder> SuperClasses
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.SuperClassesProperty, ref superClasses0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> Properties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.PropertiesProperty, ref properties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaOperationBuilder> Operations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaOperationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.OperationsProperty, ref operations0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaConstructorBuilder Constructor
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaConstructorBuilder> ConstructorLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaConstructorBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaClass.ConstructorProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaNamespaceBuilder Namespace
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder> NamespaceLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaNamespaceBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.NamespaceProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaModelBuilder Model
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaModelBuilder> ModelLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaModelBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDeclaration.ModelProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaFunctionTypeBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaTypeBuilder> parameterTypes0;
    
        internal MetaFunctionTypeBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaType(this);
    		MetaImplementationProvider.Implementation.MetaFunctionType(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaFunctionType;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionType ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionType)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaFunctionType ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunctionType)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaType global::MetaDslx.Core.Immutable.MetaTypeBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ParameterTypes
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ParameterTypesProperty, ref parameterTypes0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ReturnTypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunctionType.ReturnTypeProperty, value); }
        }
    }
    
    internal class MetaFunctionBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaFunctionBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder> parameters0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaFunctionBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaFunction(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaFunction;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaFunction ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunction)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaFunction ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaFunction)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder> Parameters
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaParameterBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ReturnTypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
    
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        global::MetaDslx.Core.Immutable.MetaTypeBuilder global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaOperationBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaOperationBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder> parameters0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaOperationBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaFunction(this);
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaOperation(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaOperation;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaOperation ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaOperation)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaOperation ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaOperation)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaFunction global::MetaDslx.Core.Immutable.MetaFunctionBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaFunction global::MetaDslx.Core.Immutable.MetaFunctionBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ParentLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaOperation.ParentProperty, value); }
        }
    
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder global::MetaDslx.Core.Immutable.MetaFunctionBuilder.Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
        }
        
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        Func<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder> global::MetaDslx.Core.Immutable.MetaFunctionBuilder.TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.TypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaParameterBuilder> Parameters
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaParameterBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ParametersProperty, ref parameters0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder ReturnType
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> ReturnTypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaFunction.ReturnTypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaConstructorBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaConstructorBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaConstructorBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaConstructor(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaConstructor;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaConstructor ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstructor)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaConstructor ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaConstructor)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaClassBuilder Parent
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaClassBuilder> ParentLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaConstructor.ParentProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaParameterBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaParameterBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaParameterBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaParameter(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaParameter;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaParameter ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaParameter)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaParameter ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaParameter)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaFunctionBuilder Function
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaFunctionBuilder> FunctionLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaFunctionBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaParameter.FunctionProperty, value); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
    internal class MetaPropertyBuilderImpl : global::MetaDslx.Core.Immutable.MutableSymbolBase, global::MetaDslx.Core.Immutable.MetaPropertyBuilder
    {
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> oppositeProperties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> subsettedProperties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> subsettingProperties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> redefinedProperties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> redefiningProperties0;
        private global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> annotations0;
    
        internal MetaPropertyBuilderImpl(global::MetaDslx.Core.Immutable.SymbolId id, global::MetaDslx.Core.Immutable.MutableModel model, bool creating)
    		: base(id, model, creating)
        {
        }
    
        internal protected override void MInit()
        {
    		MetaImplementationProvider.Implementation.MetaNamedElement(this);
    		MetaImplementationProvider.Implementation.MetaDocumentedElement(this);
    		MetaImplementationProvider.Implementation.MetaTypedElement(this);
    		MetaImplementationProvider.Implementation.MetaAnnotatedElement(this);
    		MetaImplementationProvider.Implementation.MetaProperty(this);
        }
    
        public override object MMetaModel
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.Meta;*/ }
        }
    
        public override object MMetaClass
        {
            get { return null;/*global::MetaDslx.Core.MetaInstance.MetaProperty;*/ }
        }
    
        public new global::MetaDslx.Core.Immutable.MetaProperty ToImmutable()
    	{
    		return (global::MetaDslx.Core.Immutable.MetaProperty)base.ToImmutable();
    	}
    
        public new global::MetaDslx.Core.Immutable.MetaProperty ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return (global::MetaDslx.Core.Immutable.MetaProperty)base.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaNamedElement global::MetaDslx.Core.Immutable.MetaNamedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaDocumentedElement global::MetaDslx.Core.Immutable.MetaDocumentedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaTypedElement global::MetaDslx.Core.Immutable.MetaTypedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable()
    	{
    		return this.ToImmutable();
    	}
    
        global::MetaDslx.Core.Immutable.MetaAnnotatedElement global::MetaDslx.Core.Immutable.MetaAnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.Immutable.ImmutableModel model)
    	{
    		return this.ToImmutable(model);
    	}
    
        
        public global::MetaDslx.Core.Immutable.MetaPropertyKind Kind
        {
            get { return this.GetValue<global::MetaDslx.Core.Immutable.MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty); }
            set { this.SetValue<global::MetaDslx.Core.Immutable.MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaPropertyKind> KindLazy
        {
            get { return this.GetLazyValue<global::MetaDslx.Core.Immutable.MetaPropertyKind>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty); }
            set { this.SetLazyValue(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.KindProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaClassBuilder Class
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaClassBuilder> ClassLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaClassBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.ClassProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> OppositeProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.OppositePropertiesProperty, ref oppositeProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> SubsettedProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettedPropertiesProperty, ref subsettedProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> SubsettingProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.SubsettingPropertiesProperty, ref subsettingProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> RedefinedProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefinedPropertiesProperty, ref redefinedProperties0); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder> RedefiningProperties
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaPropertyBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaProperty.RedefiningPropertiesProperty, ref redefiningProperties0); }
        }
    
        
        public string Name
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
        
        public Func<string> NameLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaNamedElement.NameProperty, value); }
        }
    
        
        public string Documentation
        {
            get { return this.GetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
        
        public Func<string> DocumentationLazy
        {
            get { return this.GetLazyReference<string>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaDocumentedElement.DocumentationProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MetaTypeBuilder Type
        {
            get { return this.GetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
        
        public Func<global::MetaDslx.Core.Immutable.MetaTypeBuilder> TypeLazy
        {
            get { return this.GetLazyReference<global::MetaDslx.Core.Immutable.MetaTypeBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty); }
            set { this.SetLazyReference(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaTypedElement.TypeProperty, value); }
        }
    
        
        public global::MetaDslx.Core.Immutable.MutableModelList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder> Annotations
        {
            get { return this.GetList<global::MetaDslx.Core.Immutable.MetaAnnotationBuilder>(global::MetaDslx.Core.Immutable.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, ref annotations0); }
        }
    }
    
	internal class MetaBuilderInstance
	{
		internal static MetaBuilderInstance instance = new MetaBuilderInstance();
	
		internal readonly global::MetaDslx.Core.Immutable.MetaModelBuilder _MetaModel;
	
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Object = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder String = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Int = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Long = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Float = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Double = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Byte = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Bool = null;
	    internal global::MetaDslx.Core.Immutable.MetaPrimitiveTypeBuilder Void = null;
	
		private readonly global::MetaDslx.Core.Immutable.MetaNamespaceBuilder __tmp1;
		private readonly global::MetaDslx.Core.Immutable.MetaNamespaceBuilder __tmp2;
		private readonly global::MetaDslx.Core.Immutable.MetaModelBuilder __tmp3;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp4;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp5;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp6;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp7;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp8;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp9;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp10;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp11;
		private readonly global::MetaDslx.Core.Immutable.MetaConstantBuilder __tmp12;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaAnnotatedElement;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp13;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaAnnotatedElement_AnnotationsProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaDocumentedElement;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaDocumentedElement_DocumentationProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp14;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp15;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp16;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaNamedElement;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp17;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamedElement_NameProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaTypedElement;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp18;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaTypedElement_TypeProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp19;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaType;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaAnnotation;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp20;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaNamespace;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamespace_ParentProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp21;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp22;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamespace_UsingsProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamespace_MetaModelProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp23;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp24;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamespace_NamespacesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp25;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp26;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNamespace_DeclarationsProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaDeclaration;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaDeclaration_NamespaceProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaDeclaration_ModelProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaModel;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaModel_UriProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaModel_NamespaceProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaEnumBuilder MetaCollectionKind;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp27;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp28;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp29;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp30;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaCollectionType;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaCollectionType_KindProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaCollectionType_InnerTypeProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaNullableType;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaNullableType_InnerTypeProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaPrimitiveType;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp31;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaEnum;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp32;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp33;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaEnum_EnumLiteralsProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp34;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp35;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaEnum_OperationsProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaEnumLiteral;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaEnumLiteral_EnumProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaConstant;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp36;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaClass;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaClass_IsAbstractProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp37;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp38;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaClass_SuperClassesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp39;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp40;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaClass_PropertiesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp41;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp42;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaClass_OperationsProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaClass_ConstructorProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp43;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp44;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp45;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp46;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp47;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp48;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp49;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp50;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp51;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp52;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp53;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp54;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp55;
		private readonly global::MetaDslx.Core.Immutable.MetaOperationBuilder __tmp56;
		private readonly global::MetaDslx.Core.Immutable.MetaFunctionTypeBuilder __tmp57;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaFunctionType;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp58;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaFunctionType_ParameterTypesProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaFunctionType_ReturnTypeProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaFunction;
		private readonly global::MetaDslx.Core.Immutable.MetaAnnotationBuilder __tmp59;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaFunction_TypeProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp60;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaFunction_ParametersProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaFunction_ReturnTypeProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaOperation;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaOperation_ParentProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaConstructor;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaConstructor_ParentProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaParameter;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaParameter_FunctionProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaEnumBuilder MetaPropertyKind;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp61;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp62;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp63;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp64;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp65;
		private readonly global::MetaDslx.Core.Immutable.MetaEnumLiteralBuilder __tmp66;
		internal readonly global::MetaDslx.Core.Immutable.MetaClassBuilder MetaProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_KindProperty;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_ClassProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp67;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_OppositePropertiesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp68;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_SubsettedPropertiesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp69;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_SubsettingPropertiesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp70;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_RedefinedPropertiesProperty;
		private readonly global::MetaDslx.Core.Immutable.MetaCollectionTypeBuilder __tmp71;
		internal readonly global::MetaDslx.Core.Immutable.MetaPropertyBuilder MetaProperty_RedefiningPropertiesProperty;
	
	    private MetaBuilderInstance()
	    {
			global::MetaDslx.Core.Immutable.MutableModel model = new global::MetaDslx.Core.Immutable.MutableModel();
			global::MetaDslx.Core.Immutable.MetaFactory factory = new global::MetaDslx.Core.Immutable.MetaFactory(model, global::MetaDslx.Core.Immutable.ModelFactoryFlags.None);
			MetaImplementationProvider.Implementation.MetaBuilderInstance(this, model);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaModel();
			_MetaModel = __tmp3;
			__tmp4 = factory.MetaConstant();
			__tmp5 = factory.MetaConstant();
			__tmp6 = factory.MetaConstant();
			__tmp7 = factory.MetaConstant();
			__tmp8 = factory.MetaConstant();
			__tmp9 = factory.MetaConstant();
			__tmp10 = factory.MetaConstant();
			__tmp11 = factory.MetaConstant();
			__tmp12 = factory.MetaConstant();
			MetaAnnotatedElement = factory.MetaClass();
			__tmp13 = factory.MetaCollectionType();
			MetaAnnotatedElement_AnnotationsProperty = factory.MetaProperty();
			MetaDocumentedElement = factory.MetaClass();
			MetaDocumentedElement_DocumentationProperty = factory.MetaProperty();
			__tmp14 = factory.MetaCollectionType();
			__tmp15 = factory.MetaOperation();
			__tmp16 = factory.MetaFunctionType();
			MetaNamedElement = factory.MetaClass();
			__tmp17 = factory.MetaAnnotation();
			MetaNamedElement_NameProperty = factory.MetaProperty();
			MetaTypedElement = factory.MetaClass();
			__tmp18 = factory.MetaAnnotation();
			MetaTypedElement_TypeProperty = factory.MetaProperty();
			__tmp19 = factory.MetaAnnotation();
			MetaType = factory.MetaClass();
			MetaAnnotation = factory.MetaClass();
			__tmp20 = factory.MetaAnnotation();
			MetaNamespace = factory.MetaClass();
			MetaNamespace_ParentProperty = factory.MetaProperty();
			__tmp21 = factory.MetaAnnotation();
			__tmp22 = factory.MetaCollectionType();
			MetaNamespace_UsingsProperty = factory.MetaProperty();
			MetaNamespace_MetaModelProperty = factory.MetaProperty();
			__tmp23 = factory.MetaAnnotation();
			__tmp24 = factory.MetaCollectionType();
			MetaNamespace_NamespacesProperty = factory.MetaProperty();
			__tmp25 = factory.MetaAnnotation();
			__tmp26 = factory.MetaCollectionType();
			MetaNamespace_DeclarationsProperty = factory.MetaProperty();
			MetaDeclaration = factory.MetaClass();
			MetaDeclaration_NamespaceProperty = factory.MetaProperty();
			MetaDeclaration_ModelProperty = factory.MetaProperty();
			MetaModel = factory.MetaClass();
			MetaModel_UriProperty = factory.MetaProperty();
			MetaModel_NamespaceProperty = factory.MetaProperty();
			MetaCollectionKind = factory.MetaEnum();
			__tmp27 = factory.MetaEnumLiteral();
			__tmp28 = factory.MetaEnumLiteral();
			__tmp29 = factory.MetaEnumLiteral();
			__tmp30 = factory.MetaEnumLiteral();
			MetaCollectionType = factory.MetaClass();
			MetaCollectionType_KindProperty = factory.MetaProperty();
			MetaCollectionType_InnerTypeProperty = factory.MetaProperty();
			MetaNullableType = factory.MetaClass();
			MetaNullableType_InnerTypeProperty = factory.MetaProperty();
			MetaPrimitiveType = factory.MetaClass();
			__tmp31 = factory.MetaAnnotation();
			MetaEnum = factory.MetaClass();
			__tmp32 = factory.MetaAnnotation();
			__tmp33 = factory.MetaCollectionType();
			MetaEnum_EnumLiteralsProperty = factory.MetaProperty();
			__tmp34 = factory.MetaAnnotation();
			__tmp35 = factory.MetaCollectionType();
			MetaEnum_OperationsProperty = factory.MetaProperty();
			MetaEnumLiteral = factory.MetaClass();
			MetaEnumLiteral_EnumProperty = factory.MetaProperty();
			MetaConstant = factory.MetaClass();
			__tmp36 = factory.MetaAnnotation();
			MetaClass = factory.MetaClass();
			MetaClass_IsAbstractProperty = factory.MetaProperty();
			__tmp37 = factory.MetaAnnotation();
			__tmp38 = factory.MetaCollectionType();
			MetaClass_SuperClassesProperty = factory.MetaProperty();
			__tmp39 = factory.MetaAnnotation();
			__tmp40 = factory.MetaCollectionType();
			MetaClass_PropertiesProperty = factory.MetaProperty();
			__tmp41 = factory.MetaAnnotation();
			__tmp42 = factory.MetaCollectionType();
			MetaClass_OperationsProperty = factory.MetaProperty();
			MetaClass_ConstructorProperty = factory.MetaProperty();
			__tmp43 = factory.MetaCollectionType();
			__tmp44 = factory.MetaOperation();
			__tmp45 = factory.MetaFunctionType();
			__tmp46 = factory.MetaCollectionType();
			__tmp47 = factory.MetaOperation();
			__tmp48 = factory.MetaFunctionType();
			__tmp49 = factory.MetaCollectionType();
			__tmp50 = factory.MetaOperation();
			__tmp51 = factory.MetaFunctionType();
			__tmp52 = factory.MetaCollectionType();
			__tmp53 = factory.MetaOperation();
			__tmp54 = factory.MetaFunctionType();
			__tmp55 = factory.MetaCollectionType();
			__tmp56 = factory.MetaOperation();
			__tmp57 = factory.MetaFunctionType();
			MetaFunctionType = factory.MetaClass();
			__tmp58 = factory.MetaCollectionType();
			MetaFunctionType_ParameterTypesProperty = factory.MetaProperty();
			MetaFunctionType_ReturnTypeProperty = factory.MetaProperty();
			MetaFunction = factory.MetaClass();
			__tmp59 = factory.MetaAnnotation();
			MetaFunction_TypeProperty = factory.MetaProperty();
			__tmp60 = factory.MetaCollectionType();
			MetaFunction_ParametersProperty = factory.MetaProperty();
			MetaFunction_ReturnTypeProperty = factory.MetaProperty();
			MetaOperation = factory.MetaClass();
			MetaOperation_ParentProperty = factory.MetaProperty();
			MetaConstructor = factory.MetaClass();
			MetaConstructor_ParentProperty = factory.MetaProperty();
			MetaParameter = factory.MetaClass();
			MetaParameter_FunctionProperty = factory.MetaProperty();
			MetaPropertyKind = factory.MetaEnum();
			__tmp61 = factory.MetaEnumLiteral();
			__tmp62 = factory.MetaEnumLiteral();
			__tmp63 = factory.MetaEnumLiteral();
			__tmp64 = factory.MetaEnumLiteral();
			__tmp65 = factory.MetaEnumLiteral();
			__tmp66 = factory.MetaEnumLiteral();
			MetaProperty = factory.MetaClass();
			MetaProperty_KindProperty = factory.MetaProperty();
			MetaProperty_ClassProperty = factory.MetaProperty();
			__tmp67 = factory.MetaCollectionType();
			MetaProperty_OppositePropertiesProperty = factory.MetaProperty();
			__tmp68 = factory.MetaCollectionType();
			MetaProperty_SubsettedPropertiesProperty = factory.MetaProperty();
			__tmp69 = factory.MetaCollectionType();
			MetaProperty_SubsettingPropertiesProperty = factory.MetaProperty();
			__tmp70 = factory.MetaCollectionType();
			MetaProperty_RedefinedPropertiesProperty = factory.MetaProperty();
			__tmp71 = factory.MetaCollectionType();
			MetaProperty_RedefiningPropertiesProperty = factory.MetaProperty();
	
			// __tmp1.Parent = null;
			// __tmp1.MetaModel = null;
			__tmp1.Namespaces.AddLazy(() => __tmp2);
			__tmp1.Name = "MetaDslx";
			__tmp1.Documentation = null;
			__tmp2.ParentLazy = () => __tmp1;
			__tmp2.MetaModelLazy = () => __tmp3;
			__tmp2.Declarations.AddLazy(() => __tmp4);
			__tmp2.Declarations.AddLazy(() => __tmp5);
			__tmp2.Declarations.AddLazy(() => __tmp6);
			__tmp2.Declarations.AddLazy(() => __tmp7);
			__tmp2.Declarations.AddLazy(() => __tmp8);
			__tmp2.Declarations.AddLazy(() => __tmp9);
			__tmp2.Declarations.AddLazy(() => __tmp10);
			__tmp2.Declarations.AddLazy(() => __tmp11);
			__tmp2.Declarations.AddLazy(() => __tmp12);
			__tmp2.Declarations.AddLazy(() => MetaAnnotatedElement);
			__tmp2.Declarations.AddLazy(() => MetaDocumentedElement);
			__tmp2.Declarations.AddLazy(() => MetaNamedElement);
			__tmp2.Declarations.AddLazy(() => MetaTypedElement);
			__tmp2.Declarations.AddLazy(() => MetaType);
			__tmp2.Declarations.AddLazy(() => MetaAnnotation);
			__tmp2.Declarations.AddLazy(() => MetaNamespace);
			__tmp2.Declarations.AddLazy(() => MetaDeclaration);
			__tmp2.Declarations.AddLazy(() => MetaModel);
			__tmp2.Declarations.AddLazy(() => MetaCollectionKind);
			__tmp2.Declarations.AddLazy(() => MetaCollectionType);
			__tmp2.Declarations.AddLazy(() => MetaNullableType);
			__tmp2.Declarations.AddLazy(() => MetaPrimitiveType);
			__tmp2.Declarations.AddLazy(() => MetaEnum);
			__tmp2.Declarations.AddLazy(() => MetaEnumLiteral);
			__tmp2.Declarations.AddLazy(() => MetaConstant);
			__tmp2.Declarations.AddLazy(() => MetaClass);
			__tmp2.Declarations.AddLazy(() => MetaFunctionType);
			__tmp2.Declarations.AddLazy(() => MetaFunction);
			__tmp2.Declarations.AddLazy(() => MetaOperation);
			__tmp2.Declarations.AddLazy(() => MetaConstructor);
			__tmp2.Declarations.AddLazy(() => MetaParameter);
			__tmp2.Declarations.AddLazy(() => MetaPropertyKind);
			__tmp2.Declarations.AddLazy(() => MetaProperty);
			__tmp2.Name = "Core";
			__tmp2.Documentation = null;
			__tmp3.Uri = "http://metadslx.core/1.0";
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp3.Name = "Meta";
			__tmp3.Documentation = null;
			// __tmp4.Value = null;
			__tmp4.TypeLazy = () => MetaPrimitiveType;
			__tmp4.NamespaceLazy = () => __tmp2;
			__tmp4.Name = "Object";
			__tmp4.Documentation = null;
			// __tmp5.Value = null;
			__tmp5.TypeLazy = () => MetaPrimitiveType;
			__tmp5.NamespaceLazy = () => __tmp2;
			__tmp5.Name = "String";
			__tmp5.Documentation = null;
			// __tmp6.Value = null;
			__tmp6.TypeLazy = () => MetaPrimitiveType;
			__tmp6.NamespaceLazy = () => __tmp2;
			__tmp6.Name = "Int";
			__tmp6.Documentation = null;
			// __tmp7.Value = null;
			__tmp7.TypeLazy = () => MetaPrimitiveType;
			__tmp7.NamespaceLazy = () => __tmp2;
			__tmp7.Name = "Long";
			__tmp7.Documentation = null;
			// __tmp8.Value = null;
			__tmp8.TypeLazy = () => MetaPrimitiveType;
			__tmp8.NamespaceLazy = () => __tmp2;
			__tmp8.Name = "Float";
			__tmp8.Documentation = null;
			// __tmp9.Value = null;
			__tmp9.TypeLazy = () => MetaPrimitiveType;
			__tmp9.NamespaceLazy = () => __tmp2;
			__tmp9.Name = "Double";
			__tmp9.Documentation = null;
			// __tmp10.Value = null;
			__tmp10.TypeLazy = () => MetaPrimitiveType;
			__tmp10.NamespaceLazy = () => __tmp2;
			__tmp10.Name = "Byte";
			__tmp10.Documentation = null;
			// __tmp11.Value = null;
			__tmp11.TypeLazy = () => MetaPrimitiveType;
			__tmp11.NamespaceLazy = () => __tmp2;
			__tmp11.Name = "Bool";
			__tmp11.Documentation = null;
			// __tmp12.Value = null;
			__tmp12.TypeLazy = () => MetaPrimitiveType;
			__tmp12.NamespaceLazy = () => __tmp2;
			__tmp12.Name = "Void";
			__tmp12.Documentation = null;
			MetaAnnotatedElement.IsAbstract = true;
			MetaAnnotatedElement.Properties.AddLazy(() => MetaAnnotatedElement_AnnotationsProperty);
			// MetaAnnotatedElement.Constructor = null;
			MetaAnnotatedElement.NamespaceLazy = () => __tmp2;
			MetaAnnotatedElement.Name = "MetaAnnotatedElement";
			MetaAnnotatedElement.Documentation = "Represents an annotated element.";
			__tmp13.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp13.InnerTypeLazy = () => MetaAnnotation;
			MetaAnnotatedElement_AnnotationsProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaAnnotatedElement_AnnotationsProperty.ClassLazy = () => MetaAnnotatedElement;
			MetaAnnotatedElement_AnnotationsProperty.Name = "Annotations";
			MetaAnnotatedElement_AnnotationsProperty.Documentation = "List of annotations";
			MetaAnnotatedElement_AnnotationsProperty.TypeLazy = () => __tmp13;
			MetaDocumentedElement.IsAbstract = true;
			MetaDocumentedElement.Properties.AddLazy(() => MetaDocumentedElement_DocumentationProperty);
			MetaDocumentedElement.Operations.AddLazy(() => __tmp15);
			// MetaDocumentedElement.Constructor = null;
			MetaDocumentedElement.NamespaceLazy = () => __tmp2;
			MetaDocumentedElement.Name = "MetaDocumentedElement";
			MetaDocumentedElement.Documentation = null;
			// MetaDocumentedElement_DocumentationProperty.Kind = null;
			MetaDocumentedElement_DocumentationProperty.ClassLazy = () => MetaDocumentedElement;
			MetaDocumentedElement_DocumentationProperty.Name = "Documentation";
			MetaDocumentedElement_DocumentationProperty.Documentation = null;
			MetaDocumentedElement_DocumentationProperty.TypeLazy = () => this.String;
			__tmp14.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp14.InnerTypeLazy = () => this.String;
			__tmp15.ParentLazy = () => MetaDocumentedElement;
			__tmp15.ReturnTypeLazy = () => __tmp14;
			__tmp15.Name = "GetDocumentationLines";
			__tmp15.Documentation = null;
			__tmp16.ReturnTypeLazy = () => __tmp14;
			MetaNamedElement.IsAbstract = true;
			MetaNamedElement.SuperClasses.AddLazy(() => MetaDocumentedElement);
			MetaNamedElement.Properties.AddLazy(() => MetaNamedElement_NameProperty);
			// MetaNamedElement.Constructor = null;
			MetaNamedElement.NamespaceLazy = () => __tmp2;
			MetaNamedElement.Name = "MetaNamedElement";
			MetaNamedElement.Documentation = null;
			__tmp17.Name = "Name";
			__tmp17.Documentation = null;
			// MetaNamedElement_NameProperty.Kind = null;
			MetaNamedElement_NameProperty.ClassLazy = () => MetaNamedElement;
			MetaNamedElement_NameProperty.Name = "Name";
			MetaNamedElement_NameProperty.Documentation = null;
			MetaNamedElement_NameProperty.TypeLazy = () => this.String;
			MetaNamedElement_NameProperty.Annotations.AddLazy(() => __tmp17);
			MetaTypedElement.IsAbstract = true;
			MetaTypedElement.Properties.AddLazy(() => MetaTypedElement_TypeProperty);
			// MetaTypedElement.Constructor = null;
			MetaTypedElement.NamespaceLazy = () => __tmp2;
			MetaTypedElement.Name = "MetaTypedElement";
			MetaTypedElement.Documentation = null;
			__tmp18.Name = "Type";
			__tmp18.Documentation = null;
			// MetaTypedElement_TypeProperty.Kind = null;
			MetaTypedElement_TypeProperty.ClassLazy = () => MetaTypedElement;
			MetaTypedElement_TypeProperty.RedefiningProperties.AddLazy(() => MetaEnumLiteral_EnumProperty);
			MetaTypedElement_TypeProperty.RedefiningProperties.AddLazy(() => MetaFunction_TypeProperty);
			MetaTypedElement_TypeProperty.Name = "Type";
			MetaTypedElement_TypeProperty.Documentation = null;
			MetaTypedElement_TypeProperty.TypeLazy = () => MetaType;
			MetaTypedElement_TypeProperty.Annotations.AddLazy(() => __tmp18);
			__tmp19.Name = "Type";
			__tmp19.Documentation = null;
			MetaType.IsAbstract = true;
			// MetaType.Constructor = null;
			MetaType.NamespaceLazy = () => __tmp2;
			MetaType.Name = "MetaType";
			MetaType.Documentation = null;
			MetaType.Annotations.AddLazy(() => __tmp19);
			// MetaAnnotation.IsAbstract = null;
			MetaAnnotation.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaAnnotation.Constructor = null;
			MetaAnnotation.NamespaceLazy = () => __tmp2;
			MetaAnnotation.Name = "MetaAnnotation";
			MetaAnnotation.Documentation = null;
			__tmp20.Name = "Scope";
			__tmp20.Documentation = null;
			// MetaNamespace.IsAbstract = null;
			MetaNamespace.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaNamespace.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_ParentProperty);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_UsingsProperty);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_MetaModelProperty);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_NamespacesProperty);
			MetaNamespace.Properties.AddLazy(() => MetaNamespace_DeclarationsProperty);
			// MetaNamespace.Constructor = null;
			MetaNamespace.NamespaceLazy = () => __tmp2;
			MetaNamespace.Name = "MetaNamespace";
			MetaNamespace.Documentation = null;
			MetaNamespace.Annotations.AddLazy(() => __tmp20);
			// MetaNamespace_ParentProperty.Kind = null;
			MetaNamespace_ParentProperty.ClassLazy = () => MetaNamespace;
			MetaNamespace_ParentProperty.OppositeProperties.AddLazy(() => MetaNamespace_NamespacesProperty);
			MetaNamespace_ParentProperty.Name = "Parent";
			MetaNamespace_ParentProperty.Documentation = null;
			MetaNamespace_ParentProperty.TypeLazy = () => MetaNamespace;
			__tmp21.Name = "ImportedScope";
			__tmp21.Documentation = null;
			__tmp22.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp22.InnerTypeLazy = () => MetaNamespace;
			// MetaNamespace_UsingsProperty.Kind = null;
			MetaNamespace_UsingsProperty.ClassLazy = () => MetaNamespace;
			MetaNamespace_UsingsProperty.Name = "Usings";
			MetaNamespace_UsingsProperty.Documentation = null;
			MetaNamespace_UsingsProperty.TypeLazy = () => __tmp22;
			MetaNamespace_UsingsProperty.Annotations.AddLazy(() => __tmp21);
			MetaNamespace_MetaModelProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_MetaModelProperty.ClassLazy = () => MetaNamespace;
			MetaNamespace_MetaModelProperty.OppositeProperties.AddLazy(() => MetaModel_NamespaceProperty);
			MetaNamespace_MetaModelProperty.Name = "MetaModel";
			MetaNamespace_MetaModelProperty.Documentation = null;
			MetaNamespace_MetaModelProperty.TypeLazy = () => MetaModel;
			__tmp23.Name = "ScopeEntry";
			__tmp23.Documentation = null;
			__tmp24.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp24.InnerTypeLazy = () => MetaNamespace;
			MetaNamespace_NamespacesProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_NamespacesProperty.ClassLazy = () => MetaNamespace;
			MetaNamespace_NamespacesProperty.OppositeProperties.AddLazy(() => MetaNamespace_ParentProperty);
			MetaNamespace_NamespacesProperty.Name = "Namespaces";
			MetaNamespace_NamespacesProperty.Documentation = null;
			MetaNamespace_NamespacesProperty.TypeLazy = () => __tmp24;
			MetaNamespace_NamespacesProperty.Annotations.AddLazy(() => __tmp23);
			__tmp25.Name = "ScopeEntry";
			__tmp25.Documentation = null;
			__tmp26.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp26.InnerTypeLazy = () => MetaDeclaration;
			MetaNamespace_DeclarationsProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaNamespace_DeclarationsProperty.ClassLazy = () => MetaNamespace;
			MetaNamespace_DeclarationsProperty.OppositeProperties.AddLazy(() => MetaDeclaration_NamespaceProperty);
			MetaNamespace_DeclarationsProperty.Name = "Declarations";
			MetaNamespace_DeclarationsProperty.Documentation = null;
			MetaNamespace_DeclarationsProperty.TypeLazy = () => __tmp26;
			MetaNamespace_DeclarationsProperty.Annotations.AddLazy(() => __tmp25);
			MetaDeclaration.IsAbstract = true;
			MetaDeclaration.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaDeclaration.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_NamespaceProperty);
			MetaDeclaration.Properties.AddLazy(() => MetaDeclaration_ModelProperty);
			// MetaDeclaration.Constructor = null;
			MetaDeclaration.NamespaceLazy = () => __tmp2;
			MetaDeclaration.Name = "MetaDeclaration";
			MetaDeclaration.Documentation = null;
			// MetaDeclaration_NamespaceProperty.Kind = null;
			MetaDeclaration_NamespaceProperty.ClassLazy = () => MetaDeclaration;
			MetaDeclaration_NamespaceProperty.OppositeProperties.AddLazy(() => MetaNamespace_DeclarationsProperty);
			MetaDeclaration_NamespaceProperty.Name = "Namespace";
			MetaDeclaration_NamespaceProperty.Documentation = null;
			MetaDeclaration_NamespaceProperty.TypeLazy = () => MetaNamespace;
			MetaDeclaration_ModelProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Derived;
			MetaDeclaration_ModelProperty.ClassLazy = () => MetaDeclaration;
			MetaDeclaration_ModelProperty.Name = "Model";
			MetaDeclaration_ModelProperty.Documentation = null;
			MetaDeclaration_ModelProperty.TypeLazy = () => MetaModel;
			// MetaModel.IsAbstract = null;
			MetaModel.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaModel.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaModel.Properties.AddLazy(() => MetaModel_UriProperty);
			MetaModel.Properties.AddLazy(() => MetaModel_NamespaceProperty);
			// MetaModel.Constructor = null;
			MetaModel.NamespaceLazy = () => __tmp2;
			MetaModel.Name = "MetaModel";
			MetaModel.Documentation = null;
			// MetaModel_UriProperty.Kind = null;
			MetaModel_UriProperty.ClassLazy = () => MetaModel;
			MetaModel_UriProperty.Name = "Uri";
			MetaModel_UriProperty.Documentation = null;
			MetaModel_UriProperty.TypeLazy = () => this.String;
			// MetaModel_NamespaceProperty.Kind = null;
			MetaModel_NamespaceProperty.ClassLazy = () => MetaModel;
			MetaModel_NamespaceProperty.OppositeProperties.AddLazy(() => MetaNamespace_MetaModelProperty);
			MetaModel_NamespaceProperty.Name = "Namespace";
			MetaModel_NamespaceProperty.Documentation = null;
			MetaModel_NamespaceProperty.TypeLazy = () => MetaNamespace;
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp27);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp28);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp29);
			MetaCollectionKind.EnumLiterals.AddLazy(() => __tmp30);
			MetaCollectionKind.NamespaceLazy = () => __tmp2;
			MetaCollectionKind.Name = "MetaCollectionKind";
			MetaCollectionKind.Documentation = null;
			__tmp27.EnumLazy = () => MetaCollectionKind;
			__tmp27.Name = "List";
			__tmp27.Documentation = null;
			__tmp27.TypeLazy = () => MetaCollectionKind;
			__tmp28.EnumLazy = () => MetaCollectionKind;
			__tmp28.Name = "Set";
			__tmp28.Documentation = null;
			__tmp28.TypeLazy = () => MetaCollectionKind;
			__tmp29.EnumLazy = () => MetaCollectionKind;
			__tmp29.Name = "MultiList";
			__tmp29.Documentation = null;
			__tmp29.TypeLazy = () => MetaCollectionKind;
			__tmp30.EnumLazy = () => MetaCollectionKind;
			__tmp30.Name = "MultiSet";
			__tmp30.Documentation = null;
			__tmp30.TypeLazy = () => MetaCollectionKind;
			// MetaCollectionType.IsAbstract = null;
			MetaCollectionType.SuperClasses.AddLazy(() => MetaType);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_KindProperty);
			MetaCollectionType.Properties.AddLazy(() => MetaCollectionType_InnerTypeProperty);
			// MetaCollectionType.Constructor = null;
			MetaCollectionType.NamespaceLazy = () => __tmp2;
			MetaCollectionType.Name = "MetaCollectionType";
			MetaCollectionType.Documentation = null;
			// MetaCollectionType_KindProperty.Kind = null;
			MetaCollectionType_KindProperty.ClassLazy = () => MetaCollectionType;
			MetaCollectionType_KindProperty.Name = "Kind";
			MetaCollectionType_KindProperty.Documentation = null;
			MetaCollectionType_KindProperty.TypeLazy = () => MetaCollectionKind;
			// MetaCollectionType_InnerTypeProperty.Kind = null;
			MetaCollectionType_InnerTypeProperty.ClassLazy = () => MetaCollectionType;
			MetaCollectionType_InnerTypeProperty.Name = "InnerType";
			MetaCollectionType_InnerTypeProperty.Documentation = null;
			MetaCollectionType_InnerTypeProperty.TypeLazy = () => MetaType;
			// MetaNullableType.IsAbstract = null;
			MetaNullableType.SuperClasses.AddLazy(() => MetaType);
			MetaNullableType.Properties.AddLazy(() => MetaNullableType_InnerTypeProperty);
			// MetaNullableType.Constructor = null;
			MetaNullableType.NamespaceLazy = () => __tmp2;
			MetaNullableType.Name = "MetaNullableType";
			MetaNullableType.Documentation = null;
			// MetaNullableType_InnerTypeProperty.Kind = null;
			MetaNullableType_InnerTypeProperty.ClassLazy = () => MetaNullableType;
			MetaNullableType_InnerTypeProperty.Name = "InnerType";
			MetaNullableType_InnerTypeProperty.Documentation = null;
			MetaNullableType_InnerTypeProperty.TypeLazy = () => MetaType;
			// MetaPrimitiveType.IsAbstract = null;
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaType);
			MetaPrimitiveType.SuperClasses.AddLazy(() => MetaNamedElement);
			// MetaPrimitiveType.Constructor = null;
			MetaPrimitiveType.NamespaceLazy = () => __tmp2;
			MetaPrimitiveType.Name = "MetaPrimitiveType";
			MetaPrimitiveType.Documentation = null;
			__tmp31.Name = "Scope";
			__tmp31.Documentation = null;
			// MetaEnum.IsAbstract = null;
			MetaEnum.SuperClasses.AddLazy(() => MetaType);
			MetaEnum.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaEnum.Properties.AddLazy(() => MetaEnum_EnumLiteralsProperty);
			MetaEnum.Properties.AddLazy(() => MetaEnum_OperationsProperty);
			// MetaEnum.Constructor = null;
			MetaEnum.NamespaceLazy = () => __tmp2;
			MetaEnum.Name = "MetaEnum";
			MetaEnum.Documentation = null;
			MetaEnum.Annotations.AddLazy(() => __tmp31);
			__tmp32.Name = "ScopeEntry";
			__tmp32.Documentation = null;
			__tmp33.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp33.InnerTypeLazy = () => MetaEnumLiteral;
			MetaEnum_EnumLiteralsProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaEnum_EnumLiteralsProperty.ClassLazy = () => MetaEnum;
			MetaEnum_EnumLiteralsProperty.OppositeProperties.AddLazy(() => MetaEnumLiteral_EnumProperty);
			MetaEnum_EnumLiteralsProperty.Name = "EnumLiterals";
			MetaEnum_EnumLiteralsProperty.Documentation = null;
			MetaEnum_EnumLiteralsProperty.TypeLazy = () => __tmp33;
			MetaEnum_EnumLiteralsProperty.Annotations.AddLazy(() => __tmp32);
			__tmp34.Name = "ScopeEntry";
			__tmp34.Documentation = null;
			__tmp35.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp35.InnerTypeLazy = () => MetaOperation;
			MetaEnum_OperationsProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaEnum_OperationsProperty.ClassLazy = () => MetaEnum;
			MetaEnum_OperationsProperty.OppositeProperties.AddLazy(() => MetaOperation_ParentProperty);
			MetaEnum_OperationsProperty.Name = "Operations";
			MetaEnum_OperationsProperty.Documentation = null;
			MetaEnum_OperationsProperty.TypeLazy = () => __tmp35;
			MetaEnum_OperationsProperty.Annotations.AddLazy(() => __tmp34);
			// MetaEnumLiteral.IsAbstract = null;
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaEnumLiteral.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaEnumLiteral.Properties.AddLazy(() => MetaEnumLiteral_EnumProperty);
			// MetaEnumLiteral.Constructor = null;
			MetaEnumLiteral.NamespaceLazy = () => __tmp2;
			MetaEnumLiteral.Name = "MetaEnumLiteral";
			MetaEnumLiteral.Documentation = null;
			// MetaEnumLiteral_EnumProperty.Kind = null;
			MetaEnumLiteral_EnumProperty.ClassLazy = () => MetaEnumLiteral;
			MetaEnumLiteral_EnumProperty.OppositeProperties.AddLazy(() => MetaEnum_EnumLiteralsProperty);
			MetaEnumLiteral_EnumProperty.RedefinedProperties.AddLazy(() => MetaTypedElement_TypeProperty);
			MetaEnumLiteral_EnumProperty.Name = "Enum";
			MetaEnumLiteral_EnumProperty.Documentation = null;
			MetaEnumLiteral_EnumProperty.TypeLazy = () => MetaEnum;
			// MetaConstant.IsAbstract = null;
			MetaConstant.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaConstant.SuperClasses.AddLazy(() => MetaDeclaration);
			// MetaConstant.Constructor = null;
			MetaConstant.NamespaceLazy = () => __tmp2;
			MetaConstant.Name = "MetaConstant";
			MetaConstant.Documentation = null;
			__tmp36.Name = "Scope";
			__tmp36.Documentation = null;
			// MetaClass.IsAbstract = null;
			MetaClass.SuperClasses.AddLazy(() => MetaType);
			MetaClass.SuperClasses.AddLazy(() => MetaDeclaration);
			MetaClass.Properties.AddLazy(() => MetaClass_IsAbstractProperty);
			MetaClass.Properties.AddLazy(() => MetaClass_SuperClassesProperty);
			MetaClass.Properties.AddLazy(() => MetaClass_PropertiesProperty);
			MetaClass.Properties.AddLazy(() => MetaClass_OperationsProperty);
			MetaClass.Properties.AddLazy(() => MetaClass_ConstructorProperty);
			MetaClass.Operations.AddLazy(() => __tmp44);
			MetaClass.Operations.AddLazy(() => __tmp47);
			MetaClass.Operations.AddLazy(() => __tmp50);
			MetaClass.Operations.AddLazy(() => __tmp53);
			MetaClass.Operations.AddLazy(() => __tmp56);
			// MetaClass.Constructor = null;
			MetaClass.NamespaceLazy = () => __tmp2;
			MetaClass.Name = "MetaClass";
			MetaClass.Documentation = null;
			MetaClass.Annotations.AddLazy(() => __tmp36);
			// MetaClass_IsAbstractProperty.Kind = null;
			MetaClass_IsAbstractProperty.ClassLazy = () => MetaClass;
			MetaClass_IsAbstractProperty.Name = "IsAbstract";
			MetaClass_IsAbstractProperty.Documentation = null;
			MetaClass_IsAbstractProperty.TypeLazy = () => this.Bool;
			__tmp37.Name = "InheritedScope";
			__tmp37.Documentation = null;
			__tmp38.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp38.InnerTypeLazy = () => MetaClass;
			// MetaClass_SuperClassesProperty.Kind = null;
			MetaClass_SuperClassesProperty.ClassLazy = () => MetaClass;
			MetaClass_SuperClassesProperty.Name = "SuperClasses";
			MetaClass_SuperClassesProperty.Documentation = null;
			MetaClass_SuperClassesProperty.TypeLazy = () => __tmp38;
			MetaClass_SuperClassesProperty.Annotations.AddLazy(() => __tmp37);
			__tmp39.Name = "ScopeEntry";
			__tmp39.Documentation = null;
			__tmp40.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp40.InnerTypeLazy = () => MetaProperty;
			MetaClass_PropertiesProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_PropertiesProperty.ClassLazy = () => MetaClass;
			MetaClass_PropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_ClassProperty);
			MetaClass_PropertiesProperty.Name = "Properties";
			MetaClass_PropertiesProperty.Documentation = null;
			MetaClass_PropertiesProperty.TypeLazy = () => __tmp40;
			MetaClass_PropertiesProperty.Annotations.AddLazy(() => __tmp39);
			__tmp41.Name = "ScopeEntry";
			__tmp41.Documentation = null;
			__tmp42.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp42.InnerTypeLazy = () => MetaOperation;
			MetaClass_OperationsProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_OperationsProperty.ClassLazy = () => MetaClass;
			MetaClass_OperationsProperty.OppositeProperties.AddLazy(() => MetaOperation_ParentProperty);
			MetaClass_OperationsProperty.Name = "Operations";
			MetaClass_OperationsProperty.Documentation = null;
			MetaClass_OperationsProperty.TypeLazy = () => __tmp42;
			MetaClass_OperationsProperty.Annotations.AddLazy(() => __tmp41);
			MetaClass_ConstructorProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaClass_ConstructorProperty.ClassLazy = () => MetaClass;
			MetaClass_ConstructorProperty.OppositeProperties.AddLazy(() => MetaConstructor_ParentProperty);
			MetaClass_ConstructorProperty.Name = "Constructor";
			MetaClass_ConstructorProperty.Documentation = null;
			MetaClass_ConstructorProperty.TypeLazy = () => MetaConstructor;
			__tmp43.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp43.InnerTypeLazy = () => MetaClass;
			__tmp44.ParentLazy = () => MetaClass;
			__tmp44.ReturnTypeLazy = () => __tmp43;
			__tmp44.Name = "GetAllSuperClasses";
			__tmp44.Documentation = null;
			__tmp45.ReturnTypeLazy = () => __tmp43;
			__tmp46.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp46.InnerTypeLazy = () => MetaProperty;
			__tmp47.ParentLazy = () => MetaClass;
			__tmp47.ReturnTypeLazy = () => __tmp46;
			__tmp47.Name = "GetAllProperties";
			__tmp47.Documentation = null;
			__tmp48.ReturnTypeLazy = () => __tmp46;
			__tmp49.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp49.InnerTypeLazy = () => MetaOperation;
			__tmp50.ParentLazy = () => MetaClass;
			__tmp50.ReturnTypeLazy = () => __tmp49;
			__tmp50.Name = "GetAllOperations";
			__tmp50.Documentation = null;
			__tmp51.ReturnTypeLazy = () => __tmp49;
			__tmp52.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp52.InnerTypeLazy = () => MetaProperty;
			__tmp53.ParentLazy = () => MetaClass;
			__tmp53.ReturnTypeLazy = () => __tmp52;
			__tmp53.Name = "GetAllImplementedProperties";
			__tmp53.Documentation = null;
			__tmp54.ReturnTypeLazy = () => __tmp52;
			__tmp55.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp55.InnerTypeLazy = () => MetaOperation;
			__tmp56.ParentLazy = () => MetaClass;
			__tmp56.ReturnTypeLazy = () => __tmp55;
			__tmp56.Name = "GetAllImplementedOperations";
			__tmp56.Documentation = null;
			__tmp57.ReturnTypeLazy = () => __tmp55;
			// MetaFunctionType.IsAbstract = null;
			MetaFunctionType.SuperClasses.AddLazy(() => MetaType);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ParameterTypesProperty);
			MetaFunctionType.Properties.AddLazy(() => MetaFunctionType_ReturnTypeProperty);
			// MetaFunctionType.Constructor = null;
			MetaFunctionType.NamespaceLazy = () => __tmp2;
			MetaFunctionType.Name = "MetaFunctionType";
			MetaFunctionType.Documentation = null;
			__tmp58.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.MultiList;
			__tmp58.InnerTypeLazy = () => MetaType;
			// MetaFunctionType_ParameterTypesProperty.Kind = null;
			MetaFunctionType_ParameterTypesProperty.ClassLazy = () => MetaFunctionType;
			MetaFunctionType_ParameterTypesProperty.Name = "ParameterTypes";
			MetaFunctionType_ParameterTypesProperty.Documentation = null;
			MetaFunctionType_ParameterTypesProperty.TypeLazy = () => __tmp58;
			// MetaFunctionType_ReturnTypeProperty.Kind = null;
			MetaFunctionType_ReturnTypeProperty.ClassLazy = () => MetaFunctionType;
			MetaFunctionType_ReturnTypeProperty.Name = "ReturnType";
			MetaFunctionType_ReturnTypeProperty.Documentation = null;
			MetaFunctionType_ReturnTypeProperty.TypeLazy = () => MetaType;
			MetaFunction.IsAbstract = true;
			MetaFunction.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaFunction.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaFunction.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaFunction.Properties.AddLazy(() => MetaFunction_TypeProperty);
			MetaFunction.Properties.AddLazy(() => MetaFunction_ParametersProperty);
			MetaFunction.Properties.AddLazy(() => MetaFunction_ReturnTypeProperty);
			// MetaFunction.Constructor = null;
			MetaFunction.NamespaceLazy = () => __tmp2;
			MetaFunction.Name = "MetaFunction";
			MetaFunction.Documentation = null;
			__tmp59.Name = "Type";
			__tmp59.Documentation = null;
			MetaFunction_TypeProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Readonly;
			MetaFunction_TypeProperty.ClassLazy = () => MetaFunction;
			MetaFunction_TypeProperty.RedefinedProperties.AddLazy(() => MetaTypedElement_TypeProperty);
			MetaFunction_TypeProperty.Name = "Type";
			MetaFunction_TypeProperty.Documentation = null;
			MetaFunction_TypeProperty.TypeLazy = () => MetaFunctionType;
			MetaFunction_TypeProperty.Annotations.AddLazy(() => __tmp59);
			__tmp60.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp60.InnerTypeLazy = () => MetaParameter;
			MetaFunction_ParametersProperty.Kind = global::MetaDslx.Core.Immutable.MetaPropertyKind.Containment;
			MetaFunction_ParametersProperty.ClassLazy = () => MetaFunction;
			MetaFunction_ParametersProperty.OppositeProperties.AddLazy(() => MetaParameter_FunctionProperty);
			MetaFunction_ParametersProperty.Name = "Parameters";
			MetaFunction_ParametersProperty.Documentation = null;
			MetaFunction_ParametersProperty.TypeLazy = () => __tmp60;
			// MetaFunction_ReturnTypeProperty.Kind = null;
			MetaFunction_ReturnTypeProperty.ClassLazy = () => MetaFunction;
			MetaFunction_ReturnTypeProperty.Name = "ReturnType";
			MetaFunction_ReturnTypeProperty.Documentation = null;
			MetaFunction_ReturnTypeProperty.TypeLazy = () => MetaType;
			// MetaOperation.IsAbstract = null;
			MetaOperation.SuperClasses.AddLazy(() => MetaFunction);
			MetaOperation.Properties.AddLazy(() => MetaOperation_ParentProperty);
			// MetaOperation.Constructor = null;
			MetaOperation.NamespaceLazy = () => __tmp2;
			MetaOperation.Name = "MetaOperation";
			MetaOperation.Documentation = null;
			// MetaOperation_ParentProperty.Kind = null;
			MetaOperation_ParentProperty.ClassLazy = () => MetaOperation;
			MetaOperation_ParentProperty.OppositeProperties.AddLazy(() => MetaClass_OperationsProperty);
			MetaOperation_ParentProperty.OppositeProperties.AddLazy(() => MetaEnum_OperationsProperty);
			MetaOperation_ParentProperty.Name = "Parent";
			MetaOperation_ParentProperty.Documentation = null;
			MetaOperation_ParentProperty.TypeLazy = () => MetaType;
			// MetaConstructor.IsAbstract = null;
			MetaConstructor.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaConstructor.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaConstructor.Properties.AddLazy(() => MetaConstructor_ParentProperty);
			// MetaConstructor.Constructor = null;
			MetaConstructor.NamespaceLazy = () => __tmp2;
			MetaConstructor.Name = "MetaConstructor";
			MetaConstructor.Documentation = null;
			// MetaConstructor_ParentProperty.Kind = null;
			MetaConstructor_ParentProperty.ClassLazy = () => MetaConstructor;
			MetaConstructor_ParentProperty.OppositeProperties.AddLazy(() => MetaClass_ConstructorProperty);
			MetaConstructor_ParentProperty.Name = "Parent";
			MetaConstructor_ParentProperty.Documentation = null;
			MetaConstructor_ParentProperty.TypeLazy = () => MetaClass;
			// MetaParameter.IsAbstract = null;
			MetaParameter.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaParameter.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaParameter.Properties.AddLazy(() => MetaParameter_FunctionProperty);
			// MetaParameter.Constructor = null;
			MetaParameter.NamespaceLazy = () => __tmp2;
			MetaParameter.Name = "MetaParameter";
			MetaParameter.Documentation = null;
			// MetaParameter_FunctionProperty.Kind = null;
			MetaParameter_FunctionProperty.ClassLazy = () => MetaParameter;
			MetaParameter_FunctionProperty.OppositeProperties.AddLazy(() => MetaFunction_ParametersProperty);
			MetaParameter_FunctionProperty.Name = "Function";
			MetaParameter_FunctionProperty.Documentation = null;
			MetaParameter_FunctionProperty.TypeLazy = () => MetaFunction;
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp61);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp62);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp63);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp64);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp65);
			MetaPropertyKind.EnumLiterals.AddLazy(() => __tmp66);
			MetaPropertyKind.NamespaceLazy = () => __tmp2;
			MetaPropertyKind.Name = "MetaPropertyKind";
			MetaPropertyKind.Documentation = null;
			__tmp61.EnumLazy = () => MetaPropertyKind;
			__tmp61.Name = "Normal";
			__tmp61.Documentation = null;
			__tmp61.TypeLazy = () => MetaPropertyKind;
			__tmp62.EnumLazy = () => MetaPropertyKind;
			__tmp62.Name = "Readonly";
			__tmp62.Documentation = null;
			__tmp62.TypeLazy = () => MetaPropertyKind;
			__tmp63.EnumLazy = () => MetaPropertyKind;
			__tmp63.Name = "Lazy";
			__tmp63.Documentation = null;
			__tmp63.TypeLazy = () => MetaPropertyKind;
			__tmp64.EnumLazy = () => MetaPropertyKind;
			__tmp64.Name = "Derived";
			__tmp64.Documentation = null;
			__tmp64.TypeLazy = () => MetaPropertyKind;
			__tmp65.EnumLazy = () => MetaPropertyKind;
			__tmp65.Name = "DerivedUnion";
			__tmp65.Documentation = null;
			__tmp65.TypeLazy = () => MetaPropertyKind;
			__tmp66.EnumLazy = () => MetaPropertyKind;
			__tmp66.Name = "Containment";
			__tmp66.Documentation = null;
			__tmp66.TypeLazy = () => MetaPropertyKind;
			// MetaProperty.IsAbstract = null;
			MetaProperty.SuperClasses.AddLazy(() => MetaNamedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaTypedElement);
			MetaProperty.SuperClasses.AddLazy(() => MetaAnnotatedElement);
			MetaProperty.Properties.AddLazy(() => MetaProperty_KindProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_ClassProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_OppositePropertiesProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettedPropertiesProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_SubsettingPropertiesProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefinedPropertiesProperty);
			MetaProperty.Properties.AddLazy(() => MetaProperty_RedefiningPropertiesProperty);
			// MetaProperty.Constructor = null;
			MetaProperty.NamespaceLazy = () => __tmp2;
			MetaProperty.Name = "MetaProperty";
			MetaProperty.Documentation = null;
			// MetaProperty_KindProperty.Kind = null;
			MetaProperty_KindProperty.ClassLazy = () => MetaProperty;
			MetaProperty_KindProperty.Name = "Kind";
			MetaProperty_KindProperty.Documentation = null;
			MetaProperty_KindProperty.TypeLazy = () => MetaPropertyKind;
			// MetaProperty_ClassProperty.Kind = null;
			MetaProperty_ClassProperty.ClassLazy = () => MetaProperty;
			MetaProperty_ClassProperty.OppositeProperties.AddLazy(() => MetaClass_PropertiesProperty);
			MetaProperty_ClassProperty.Name = "Class";
			MetaProperty_ClassProperty.Documentation = null;
			MetaProperty_ClassProperty.TypeLazy = () => MetaClass;
			__tmp67.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp67.InnerTypeLazy = () => MetaProperty;
			// MetaProperty_OppositePropertiesProperty.Kind = null;
			MetaProperty_OppositePropertiesProperty.ClassLazy = () => MetaProperty;
			MetaProperty_OppositePropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_OppositePropertiesProperty);
			MetaProperty_OppositePropertiesProperty.Name = "OppositeProperties";
			MetaProperty_OppositePropertiesProperty.Documentation = null;
			MetaProperty_OppositePropertiesProperty.TypeLazy = () => __tmp67;
			__tmp68.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp68.InnerTypeLazy = () => MetaProperty;
			// MetaProperty_SubsettedPropertiesProperty.Kind = null;
			MetaProperty_SubsettedPropertiesProperty.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettedPropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_SubsettingPropertiesProperty);
			MetaProperty_SubsettedPropertiesProperty.Name = "SubsettedProperties";
			MetaProperty_SubsettedPropertiesProperty.Documentation = null;
			MetaProperty_SubsettedPropertiesProperty.TypeLazy = () => __tmp68;
			__tmp69.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp69.InnerTypeLazy = () => MetaProperty;
			// MetaProperty_SubsettingPropertiesProperty.Kind = null;
			MetaProperty_SubsettingPropertiesProperty.ClassLazy = () => MetaProperty;
			MetaProperty_SubsettingPropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_SubsettedPropertiesProperty);
			MetaProperty_SubsettingPropertiesProperty.Name = "SubsettingProperties";
			MetaProperty_SubsettingPropertiesProperty.Documentation = null;
			MetaProperty_SubsettingPropertiesProperty.TypeLazy = () => __tmp69;
			__tmp70.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp70.InnerTypeLazy = () => MetaProperty;
			// MetaProperty_RedefinedPropertiesProperty.Kind = null;
			MetaProperty_RedefinedPropertiesProperty.ClassLazy = () => MetaProperty;
			MetaProperty_RedefinedPropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_RedefiningPropertiesProperty);
			MetaProperty_RedefinedPropertiesProperty.Name = "RedefinedProperties";
			MetaProperty_RedefinedPropertiesProperty.Documentation = null;
			MetaProperty_RedefinedPropertiesProperty.TypeLazy = () => __tmp70;
			__tmp71.Kind = global::MetaDslx.Core.Immutable.MetaCollectionKind.List;
			__tmp71.InnerTypeLazy = () => MetaProperty;
			// MetaProperty_RedefiningPropertiesProperty.Kind = null;
			MetaProperty_RedefiningPropertiesProperty.ClassLazy = () => MetaProperty;
			MetaProperty_RedefiningPropertiesProperty.OppositeProperties.AddLazy(() => MetaProperty_RedefinedPropertiesProperty);
			MetaProperty_RedefiningPropertiesProperty.Name = "RedefiningProperties";
			MetaProperty_RedefiningPropertiesProperty.Documentation = null;
			MetaProperty_RedefiningPropertiesProperty.TypeLazy = () => __tmp71;
	
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp1).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp2).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp3).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp4).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp5).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp6).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp7).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp8).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp9).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp10).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp11).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp12).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaAnnotatedElement).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp13).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaAnnotatedElement_AnnotationsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaDocumentedElement).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaDocumentedElement_DocumentationProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp14).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp15).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp16).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamedElement).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp17).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamedElement_NameProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaTypedElement).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp18).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaTypedElement_TypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp19).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaType).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaAnnotation).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp20).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace_ParentProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp21).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp22).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace_UsingsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace_MetaModelProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp23).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp24).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace_NamespacesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp25).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp26).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNamespace_DeclarationsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaDeclaration).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaDeclaration_NamespaceProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaDeclaration_ModelProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaModel).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaModel_UriProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaModel_NamespaceProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaCollectionKind).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp27).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp28).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp29).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp30).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaCollectionType).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaCollectionType_KindProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaCollectionType_InnerTypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNullableType).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaNullableType_InnerTypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaPrimitiveType).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp31).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaEnum).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp32).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp33).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaEnum_EnumLiteralsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp34).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp35).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaEnum_OperationsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaEnumLiteral).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaEnumLiteral_EnumProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaConstant).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp36).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass_IsAbstractProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp37).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp38).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass_SuperClassesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp39).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp40).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass_PropertiesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp41).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp42).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass_OperationsProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaClass_ConstructorProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp43).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp44).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp45).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp46).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp47).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp48).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp49).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp50).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp51).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp52).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp53).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp54).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp55).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp56).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp57).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunctionType).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp58).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunctionType_ParameterTypesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunctionType_ReturnTypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunction).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp59).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunction_TypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp60).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunction_ParametersProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaFunction_ReturnTypeProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaOperation).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaOperation_ParentProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaConstructor).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaConstructor_ParentProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaParameter).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaParameter_FunctionProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaPropertyKind).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp61).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp62).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp63).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp64).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp65).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp66).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_KindProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_ClassProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp67).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_OppositePropertiesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp68).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_SubsettedPropertiesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp69).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_SubsettingPropertiesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp70).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_RedefinedPropertiesProperty).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)__tmp71).MMakeCreated();
			((global::MetaDslx.Core.Immutable.MutableSymbolBase)MetaProperty_RedefiningPropertiesProperty).MMakeCreated();
	
	        model.EvaluateLazyValues();
	    }
	}
	
	public class MetaInstance
	{
	
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return MetaInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Core.Immutable.MetaModel _MetaModel;
	
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Object = MetaBuilderInstance.instance.Object.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType String = MetaBuilderInstance.instance.String.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Int = MetaBuilderInstance.instance.Int.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Long = MetaBuilderInstance.instance.Long.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Float = MetaBuilderInstance.instance.Float.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Double = MetaBuilderInstance.instance.Double.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Byte = MetaBuilderInstance.instance.Byte.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Bool = MetaBuilderInstance.instance.Bool.ToImmutable();
	    public static readonly global::MetaDslx.Core.Immutable.MetaPrimitiveType Void = MetaBuilderInstance.instance.Void.ToImmutable();
	
		/**
		 * <summary>
		 * Represents an annotated element.
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaAnnotatedElement;
		/**
		 * <summary>
		 * List of annotations
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaAnnotatedElement_AnnotationsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaDocumentedElement;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaDocumentedElement_DocumentationProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaNamedElement;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamedElement_NameProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaTypedElement;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaTypedElement_TypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaType;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaAnnotation;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaNamespace;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamespace_ParentProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamespace_UsingsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamespace_MetaModelProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamespace_NamespacesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNamespace_DeclarationsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaDeclaration;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaDeclaration_NamespaceProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaDeclaration_ModelProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaModel;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaModel_UriProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaModel_NamespaceProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaEnum MetaCollectionKind;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaCollectionType;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaCollectionType_KindProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaCollectionType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaNullableType;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaNullableType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaPrimitiveType;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaEnum;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaEnum_EnumLiteralsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaEnum_OperationsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaEnumLiteral;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaEnumLiteral_EnumProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaConstant;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaClass;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaClass_IsAbstractProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaClass_SuperClassesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaClass_PropertiesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaClass_OperationsProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaClass_ConstructorProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaFunctionType;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaFunctionType_ParameterTypesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaFunctionType_ReturnTypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaFunction;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaFunction_TypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaFunction_ParametersProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaFunction_ReturnTypeProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaOperation;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaOperation_ParentProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaConstructor;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaConstructor_ParentProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaParameter;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaParameter_FunctionProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaEnum MetaPropertyKind;
		public static readonly global::MetaDslx.Core.Immutable.MetaClass MetaProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_KindProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_ClassProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_OppositePropertiesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_SubsettedPropertiesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_SubsettingPropertiesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_RedefinedPropertiesProperty;
		public static readonly global::MetaDslx.Core.Immutable.MetaProperty MetaProperty_RedefiningPropertiesProperty;
	
		static MetaInstance()
		{
			MetaInstance._MetaModel = MetaBuilderInstance.instance._MetaModel.ToImmutable();
	
			MetaInstance.MetaAnnotatedElement = MetaBuilderInstance.instance.MetaAnnotatedElement.ToImmutable();
			MetaInstance.MetaAnnotatedElement_AnnotationsProperty = MetaBuilderInstance.instance.MetaAnnotatedElement_AnnotationsProperty.ToImmutable();
			MetaInstance.MetaDocumentedElement = MetaBuilderInstance.instance.MetaDocumentedElement.ToImmutable();
			MetaInstance.MetaDocumentedElement_DocumentationProperty = MetaBuilderInstance.instance.MetaDocumentedElement_DocumentationProperty.ToImmutable();
			MetaInstance.MetaNamedElement = MetaBuilderInstance.instance.MetaNamedElement.ToImmutable();
			MetaInstance.MetaNamedElement_NameProperty = MetaBuilderInstance.instance.MetaNamedElement_NameProperty.ToImmutable();
			MetaInstance.MetaTypedElement = MetaBuilderInstance.instance.MetaTypedElement.ToImmutable();
			MetaInstance.MetaTypedElement_TypeProperty = MetaBuilderInstance.instance.MetaTypedElement_TypeProperty.ToImmutable();
			MetaInstance.MetaType = MetaBuilderInstance.instance.MetaType.ToImmutable();
			MetaInstance.MetaAnnotation = MetaBuilderInstance.instance.MetaAnnotation.ToImmutable();
			MetaInstance.MetaNamespace = MetaBuilderInstance.instance.MetaNamespace.ToImmutable();
			MetaInstance.MetaNamespace_ParentProperty = MetaBuilderInstance.instance.MetaNamespace_ParentProperty.ToImmutable();
			MetaInstance.MetaNamespace_UsingsProperty = MetaBuilderInstance.instance.MetaNamespace_UsingsProperty.ToImmutable();
			MetaInstance.MetaNamespace_MetaModelProperty = MetaBuilderInstance.instance.MetaNamespace_MetaModelProperty.ToImmutable();
			MetaInstance.MetaNamespace_NamespacesProperty = MetaBuilderInstance.instance.MetaNamespace_NamespacesProperty.ToImmutable();
			MetaInstance.MetaNamespace_DeclarationsProperty = MetaBuilderInstance.instance.MetaNamespace_DeclarationsProperty.ToImmutable();
			MetaInstance.MetaDeclaration = MetaBuilderInstance.instance.MetaDeclaration.ToImmutable();
			MetaInstance.MetaDeclaration_NamespaceProperty = MetaBuilderInstance.instance.MetaDeclaration_NamespaceProperty.ToImmutable();
			MetaInstance.MetaDeclaration_ModelProperty = MetaBuilderInstance.instance.MetaDeclaration_ModelProperty.ToImmutable();
			MetaInstance.MetaModel = MetaBuilderInstance.instance.MetaModel.ToImmutable();
			MetaInstance.MetaModel_UriProperty = MetaBuilderInstance.instance.MetaModel_UriProperty.ToImmutable();
			MetaInstance.MetaModel_NamespaceProperty = MetaBuilderInstance.instance.MetaModel_NamespaceProperty.ToImmutable();
			MetaInstance.MetaCollectionKind = MetaBuilderInstance.instance.MetaCollectionKind.ToImmutable();
			MetaInstance.MetaCollectionType = MetaBuilderInstance.instance.MetaCollectionType.ToImmutable();
			MetaInstance.MetaCollectionType_KindProperty = MetaBuilderInstance.instance.MetaCollectionType_KindProperty.ToImmutable();
			MetaInstance.MetaCollectionType_InnerTypeProperty = MetaBuilderInstance.instance.MetaCollectionType_InnerTypeProperty.ToImmutable();
			MetaInstance.MetaNullableType = MetaBuilderInstance.instance.MetaNullableType.ToImmutable();
			MetaInstance.MetaNullableType_InnerTypeProperty = MetaBuilderInstance.instance.MetaNullableType_InnerTypeProperty.ToImmutable();
			MetaInstance.MetaPrimitiveType = MetaBuilderInstance.instance.MetaPrimitiveType.ToImmutable();
			MetaInstance.MetaEnum = MetaBuilderInstance.instance.MetaEnum.ToImmutable();
			MetaInstance.MetaEnum_EnumLiteralsProperty = MetaBuilderInstance.instance.MetaEnum_EnumLiteralsProperty.ToImmutable();
			MetaInstance.MetaEnum_OperationsProperty = MetaBuilderInstance.instance.MetaEnum_OperationsProperty.ToImmutable();
			MetaInstance.MetaEnumLiteral = MetaBuilderInstance.instance.MetaEnumLiteral.ToImmutable();
			MetaInstance.MetaEnumLiteral_EnumProperty = MetaBuilderInstance.instance.MetaEnumLiteral_EnumProperty.ToImmutable();
			MetaInstance.MetaConstant = MetaBuilderInstance.instance.MetaConstant.ToImmutable();
			MetaInstance.MetaClass = MetaBuilderInstance.instance.MetaClass.ToImmutable();
			MetaInstance.MetaClass_IsAbstractProperty = MetaBuilderInstance.instance.MetaClass_IsAbstractProperty.ToImmutable();
			MetaInstance.MetaClass_SuperClassesProperty = MetaBuilderInstance.instance.MetaClass_SuperClassesProperty.ToImmutable();
			MetaInstance.MetaClass_PropertiesProperty = MetaBuilderInstance.instance.MetaClass_PropertiesProperty.ToImmutable();
			MetaInstance.MetaClass_OperationsProperty = MetaBuilderInstance.instance.MetaClass_OperationsProperty.ToImmutable();
			MetaInstance.MetaClass_ConstructorProperty = MetaBuilderInstance.instance.MetaClass_ConstructorProperty.ToImmutable();
			MetaInstance.MetaFunctionType = MetaBuilderInstance.instance.MetaFunctionType.ToImmutable();
			MetaInstance.MetaFunctionType_ParameterTypesProperty = MetaBuilderInstance.instance.MetaFunctionType_ParameterTypesProperty.ToImmutable();
			MetaInstance.MetaFunctionType_ReturnTypeProperty = MetaBuilderInstance.instance.MetaFunctionType_ReturnTypeProperty.ToImmutable();
			MetaInstance.MetaFunction = MetaBuilderInstance.instance.MetaFunction.ToImmutable();
			MetaInstance.MetaFunction_TypeProperty = MetaBuilderInstance.instance.MetaFunction_TypeProperty.ToImmutable();
			MetaInstance.MetaFunction_ParametersProperty = MetaBuilderInstance.instance.MetaFunction_ParametersProperty.ToImmutable();
			MetaInstance.MetaFunction_ReturnTypeProperty = MetaBuilderInstance.instance.MetaFunction_ReturnTypeProperty.ToImmutable();
			MetaInstance.MetaOperation = MetaBuilderInstance.instance.MetaOperation.ToImmutable();
			MetaInstance.MetaOperation_ParentProperty = MetaBuilderInstance.instance.MetaOperation_ParentProperty.ToImmutable();
			MetaInstance.MetaConstructor = MetaBuilderInstance.instance.MetaConstructor.ToImmutable();
			MetaInstance.MetaConstructor_ParentProperty = MetaBuilderInstance.instance.MetaConstructor_ParentProperty.ToImmutable();
			MetaInstance.MetaParameter = MetaBuilderInstance.instance.MetaParameter.ToImmutable();
			MetaInstance.MetaParameter_FunctionProperty = MetaBuilderInstance.instance.MetaParameter_FunctionProperty.ToImmutable();
			MetaInstance.MetaPropertyKind = MetaBuilderInstance.instance.MetaPropertyKind.ToImmutable();
			MetaInstance.MetaProperty = MetaBuilderInstance.instance.MetaProperty.ToImmutable();
			MetaInstance.MetaProperty_KindProperty = MetaBuilderInstance.instance.MetaProperty_KindProperty.ToImmutable();
			MetaInstance.MetaProperty_ClassProperty = MetaBuilderInstance.instance.MetaProperty_ClassProperty.ToImmutable();
			MetaInstance.MetaProperty_OppositePropertiesProperty = MetaBuilderInstance.instance.MetaProperty_OppositePropertiesProperty.ToImmutable();
			MetaInstance.MetaProperty_SubsettedPropertiesProperty = MetaBuilderInstance.instance.MetaProperty_SubsettedPropertiesProperty.ToImmutable();
			MetaInstance.MetaProperty_SubsettingPropertiesProperty = MetaBuilderInstance.instance.MetaProperty_SubsettingPropertiesProperty.ToImmutable();
			MetaInstance.MetaProperty_RedefinedPropertiesProperty = MetaBuilderInstance.instance.MetaProperty_RedefinedPropertiesProperty.ToImmutable();
			MetaInstance.MetaProperty_RedefiningPropertiesProperty = MetaBuilderInstance.instance.MetaProperty_RedefiningPropertiesProperty.ToImmutable();
	
			MetaInstance.initialized = true;
		}
	}
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class MetaFactory : global::MetaDslx.Core.Immutable.ModelFactory
    {
        public MetaFactory(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.MakeSymbolsCreated)
            : base(model, flags)
        {
    		global::MetaDslx.Core.Immutable.MetaDescriptor.Initialize();
        }
    
        public override global::MetaDslx.Core.Immutable.MutableSymbolBase Create(string type)
        {
            switch (type)
            {
                case "MetaAnnotation": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaAnnotation();
                case "MetaNamespace": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaNamespace();
                case "MetaModel": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaModel();
                case "MetaCollectionType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaCollectionType();
                case "MetaNullableType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaNullableType();
                case "MetaPrimitiveType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaPrimitiveType();
                case "MetaEnum": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaEnum();
                case "MetaEnumLiteral": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaEnumLiteral();
                case "MetaConstant": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaConstant();
                case "MetaClass": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaClass();
                case "MetaFunctionType": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaFunctionType();
                case "MetaOperation": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaOperation();
                case "MetaConstructor": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaConstructor();
                case "MetaParameter": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaParameter();
                case "MetaProperty": return (global::MetaDslx.Core.Immutable.MutableSymbolBase)this.MetaProperty();
                default:
                    throw new ModelException("Unknown type name: " + type);
            }
        }
    
        /// <summary>
        /// Creates a new instance of MetaAnnotation.
        /// </summary>
        public MetaAnnotationBuilder MetaAnnotation()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaAnnotationId());
    		return (MetaAnnotationBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNamespace.
        /// </summary>
        public MetaNamespaceBuilder MetaNamespace()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaNamespaceId());
    		return (MetaNamespaceBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaModel.
        /// </summary>
        public MetaModelBuilder MetaModel()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaModelId());
    		return (MetaModelBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaCollectionType.
        /// </summary>
        public MetaCollectionTypeBuilder MetaCollectionType()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaCollectionTypeId());
    		return (MetaCollectionTypeBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaNullableType.
        /// </summary>
        public MetaNullableTypeBuilder MetaNullableType()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaNullableTypeId());
    		return (MetaNullableTypeBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaPrimitiveType.
        /// </summary>
        public MetaPrimitiveTypeBuilder MetaPrimitiveType()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaPrimitiveTypeId());
    		return (MetaPrimitiveTypeBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnum.
        /// </summary>
        public MetaEnumBuilder MetaEnum()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaEnumId());
    		return (MetaEnumBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaEnumLiteral.
        /// </summary>
        public MetaEnumLiteralBuilder MetaEnumLiteral()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaEnumLiteralId());
    		return (MetaEnumLiteralBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstant.
        /// </summary>
        public MetaConstantBuilder MetaConstant()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaConstantId());
    		return (MetaConstantBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaClass.
        /// </summary>
        public MetaClassBuilder MetaClass()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaClassId());
    		return (MetaClassBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaFunctionType.
        /// </summary>
        public MetaFunctionTypeBuilder MetaFunctionType()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaFunctionTypeId());
    		return (MetaFunctionTypeBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaOperation.
        /// </summary>
        public MetaOperationBuilder MetaOperation()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaOperationId());
    		return (MetaOperationBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaConstructor.
        /// </summary>
        public MetaConstructorBuilder MetaConstructor()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaConstructorId());
    		return (MetaConstructorBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaParameter.
        /// </summary>
        public MetaParameterBuilder MetaParameter()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaParameterId());
    		return (MetaParameterBuilder)symbol;
    	}
    
        /// <summary>
        /// Creates a new instance of MetaProperty.
        /// </summary>
        public MetaPropertyBuilder MetaProperty()
    	{
    		global::MetaDslx.Core.Immutable.MutableSymbolBase symbol = this.CreateSymbol(new MetaPropertyId());
    		return (MetaPropertyBuilder)symbol;
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
    	public virtual void MetaBuilderInstance(MetaBuilderInstance _this, global::MetaDslx.Core.Immutable.MutableModel model)
    	{
    	}
        /// <summary>
    	/// Implements the constructor: MetaAnnotatedElement()
        /// </summary>
        public virtual void MetaAnnotatedElement(MetaAnnotatedElementBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDocumentedElement()
        /// </summary>
        public virtual void MetaDocumentedElement(MetaDocumentedElementBuilder _this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaDocumentedElement.GetDocumentationLines()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<string> MetaDocumentedElement_GetDocumentationLines(global::MetaDslx.Core.Immutable.MetaDocumentedElement _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamedElement()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaDocumentedElement
    	/// All superclasses: global::MetaDslx.Core.MetaDocumentedElement
        public virtual void MetaNamedElement(MetaNamedElementBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypedElement()
        /// </summary>
        public virtual void MetaTypedElement(MetaTypedElementBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaType()
        /// </summary>
        public virtual void MetaType(MetaTypeBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAnnotation()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement
        public virtual void MetaAnnotation(MetaAnnotationBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamespace()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaNamespace(MetaNamespaceBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDeclaration()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        /// Initializes the following derived properties:
    	/// <ul>
        ///     <li>Model</li>
    	/// </ul>
        public virtual void MetaDeclaration(MetaDeclarationBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModel()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaModel(MetaModelBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaCollectionType()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType
    	/// All superclasses: global::MetaDslx.Core.MetaType
        public virtual void MetaCollectionType(MetaCollectionTypeBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullableType()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType
    	/// All superclasses: global::MetaDslx.Core.MetaType
        public virtual void MetaNullableType(MetaNullableTypeBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPrimitiveType()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaNamedElement
    	/// All superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement
        public virtual void MetaPrimitiveType(MetaPrimitiveTypeBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnum()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaDeclaration
    	/// All superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaDeclaration, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaEnum(MetaEnumBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnumLiteral()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaTypedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaTypedElement
        public virtual void MetaEnumLiteral(MetaEnumLiteralBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstant()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaDeclaration
    	/// All superclasses: global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaDeclaration, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaConstant(MetaConstantBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaClass()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaDeclaration
    	/// All superclasses: global::MetaDslx.Core.MetaType, global::MetaDslx.Core.MetaDeclaration, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaClass(MetaClassBuilder _this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllSuperClasses()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaClass> MetaClass_GetAllSuperClasses(global::MetaDslx.Core.Immutable.MetaClass _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllProperties()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> MetaClass_GetAllProperties(global::MetaDslx.Core.Immutable.MetaClass _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllOperations()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> MetaClass_GetAllOperations(global::MetaDslx.Core.Immutable.MetaClass _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllImplementedProperties()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaProperty> MetaClass_GetAllImplementedProperties(global::MetaDslx.Core.Immutable.MetaClass _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllImplementedOperations()
        /// </summary>
        public virtual global::MetaDslx.Core.Immutable.ImmutableModelList<global::MetaDslx.Core.Immutable.MetaOperation> MetaClass_GetAllImplementedOperations(global::MetaDslx.Core.Immutable.MetaClass _this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionType()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaType
    	/// All superclasses: global::MetaDslx.Core.MetaType
        public virtual void MetaFunctionType(MetaFunctionTypeBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunction()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        /// Initializes the following readonly properties:
    	/// <ul>
        ///     <li>Type</li>
    	/// </ul>
        public virtual void MetaFunction(MetaFunctionBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperation()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaFunction
    	/// All superclasses: global::MetaDslx.Core.MetaFunction, global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaOperation(MetaOperationBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstructor()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaConstructor(MetaConstructorBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaParameter()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaParameter(MetaParameterBuilder _this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaProperty()
        /// </summary>
    	/// Direct superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaAnnotatedElement
    	/// All superclasses: global::MetaDslx.Core.MetaNamedElement, global::MetaDslx.Core.MetaDocumentedElement, global::MetaDslx.Core.MetaTypedElement, global::MetaDslx.Core.MetaAnnotatedElement
        public virtual void MetaProperty(MetaPropertyBuilder _this)
        {
        }
    
    
    
    }
    
}

