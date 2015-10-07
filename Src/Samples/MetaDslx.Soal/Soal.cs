using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;

namespace MetaDslx.Soal
{
    public static class SoalDescriptor
    {
        static SoalDescriptor()
        {
            NamedElement.StaticInit();
            TypedElement.StaticInit();
            SoalType.StaticInit();
            Namespace.StaticInit();
            Declaration.StaticInit();
            ArrayType.StaticInit();
            NullableType.StaticInit();
            PrimitiveType.StaticInit();
            Enum.StaticInit();
            EnumLiteral.StaticInit();
            StructuredType.StaticInit();
            Property.StaticInit();
            Struct.StaticInit();
            Exception.StaticInit();
            Interface.StaticInit();
            Operation.StaticInit();
            Parameter.StaticInit();
            Binding.StaticInit();
            Endpoint.StaticInit();
            BindingElement.StaticInit();
            TransportBindingElement.StaticInit();
            EncodingBindingElement.StaticInit();
            ProtocolBindingElement.StaticInit();
            HttpTransportBindingElement.StaticInit();
            RestTransportBindingElement.StaticInit();
            WebSocketTransportBindingElement.StaticInit();
            SoapEncodingBindingElement.StaticInit();
            XmlEncodingBindingElement.StaticInit();
            JsonEncodingBindingElement.StaticInit();
            WsProtocolBindingElement.StaticInit();
            WsAddressingBindingElement.StaticInit();
        }
    
        internal static void StaticInit()
        {
        }
    
    	public const string Uri = "http://MetaDslx.Soal/1.0";
    
        
        public static class NamedElement
        {
            internal static void StaticInit()
            {
            }
        
            static NamedElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.NamedElement; }
            }
        
            [Name]
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Soal.NamedElement), typeof(global::MetaDslx.Soal.SoalDescriptor.NamedElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.NamedElement_NameProperty));
            
        }
        
        public static class TypedElement
        {
            internal static void StaticInit()
            {
            }
        
            static TypedElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.TypedElement; }
            }
        
            [Type]
            public static readonly ModelProperty TypeProperty =
                ModelProperty.Register("Type", typeof(global::MetaDslx.Soal.SoalType), typeof(global::MetaDslx.Soal.TypedElement), typeof(global::MetaDslx.Soal.SoalDescriptor.TypedElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.TypedElement_TypeProperty));
            
        }
        
        public static class SoalType
        {
            internal static void StaticInit()
            {
            }
        
            static SoalType()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.SoalType; }
            }
        
        }
        
        public static class Namespace
        {
            internal static void StaticInit()
            {
            }
        
            static Namespace()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Namespace; }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Declaration), "Namespace")]
            public static readonly ModelProperty DeclarationsProperty =
                ModelProperty.Register("Declarations", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Declaration>), typeof(global::MetaDslx.Soal.Namespace), typeof(global::MetaDslx.Soal.SoalDescriptor.Namespace), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Namespace_DeclarationsProperty));
            
        }
        
        public static class Declaration
        {
            internal static void StaticInit()
            {
            }
        
            static Declaration()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Declaration; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Namespace), "Declarations")]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Soal.Namespace), typeof(global::MetaDslx.Soal.Declaration), typeof(global::MetaDslx.Soal.SoalDescriptor.Declaration), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Declaration_NamespaceProperty));
            
        }
        
        public static class ArrayType
        {
            internal static void StaticInit()
            {
            }
        
            static ArrayType()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.ArrayType; }
            }
        
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Soal.SoalType), typeof(global::MetaDslx.Soal.ArrayType), typeof(global::MetaDslx.Soal.SoalDescriptor.ArrayType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.ArrayType_InnerTypeProperty));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Soal.Namespace), typeof(global::MetaDslx.Soal.ArrayType), typeof(global::MetaDslx.Soal.SoalDescriptor.ArrayType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.ArrayType_NamespaceProperty));
            
        }
        
        public static class NullableType
        {
            internal static void StaticInit()
            {
            }
        
            static NullableType()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.NullableType; }
            }
        
            
            public static readonly ModelProperty InnerTypeProperty =
                ModelProperty.Register("InnerType", typeof(global::MetaDslx.Soal.SoalType), typeof(global::MetaDslx.Soal.NullableType), typeof(global::MetaDslx.Soal.SoalDescriptor.NullableType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.NullableType_InnerTypeProperty));
            
            
            [ReadonlyAttribute]
            public static readonly ModelProperty NamespaceProperty =
                ModelProperty.Register("Namespace", typeof(global::MetaDslx.Soal.Namespace), typeof(global::MetaDslx.Soal.NullableType), typeof(global::MetaDslx.Soal.SoalDescriptor.NullableType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.NullableType_NamespaceProperty));
            
        }
        
        public static class PrimitiveType
        {
            internal static void StaticInit()
            {
            }
        
            static PrimitiveType()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.PrimitiveType; }
            }
        
        }
        
        public static class Enum
        {
            internal static void StaticInit()
            {
            }
        
            static Enum()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Enum; }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral), "Enum")]
            public static readonly ModelProperty EnumLiteralsProperty =
                ModelProperty.Register("EnumLiterals", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.EnumLiteral>), typeof(global::MetaDslx.Soal.Enum), typeof(global::MetaDslx.Soal.SoalDescriptor.Enum), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Enum_EnumLiteralsProperty));
            
        }
        
        public static class EnumLiteral
        {
            internal static void StaticInit()
            {
            }
        
            static EnumLiteral()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.EnumLiteral; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Enum), "EnumLiterals")]
            public static readonly ModelProperty EnumProperty =
                ModelProperty.Register("Enum", typeof(global::MetaDslx.Soal.Enum), typeof(global::MetaDslx.Soal.EnumLiteral), typeof(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.EnumLiteral_EnumProperty));
            
        }
        
        public static class StructuredType
        {
            internal static void StaticInit()
            {
            }
        
            static StructuredType()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.StructuredType; }
            }
        
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Property), "Parent")]
            public static readonly ModelProperty PropertiesProperty =
                ModelProperty.Register("Properties", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>), typeof(global::MetaDslx.Soal.StructuredType), typeof(global::MetaDslx.Soal.SoalDescriptor.StructuredType), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.StructuredType_PropertiesProperty));
            
        }
        
        public static class Property
        {
            internal static void StaticInit()
            {
            }
        
            static Property()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Property; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.StructuredType), "Properties")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Soal.StructuredType), typeof(global::MetaDslx.Soal.Property), typeof(global::MetaDslx.Soal.SoalDescriptor.Property), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Property_ParentProperty));
            
        }
        
        public static class Struct
        {
            internal static void StaticInit()
            {
            }
        
            static Struct()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Struct; }
            }
        
            
            public static readonly ModelProperty BaseTypeProperty =
                ModelProperty.Register("BaseType", typeof(global::MetaDslx.Soal.Struct), typeof(global::MetaDslx.Soal.Struct), typeof(global::MetaDslx.Soal.SoalDescriptor.Struct), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Struct_BaseTypeProperty));
            
        }
        
        public static class Exception
        {
            internal static void StaticInit()
            {
            }
        
            static Exception()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Exception; }
            }
        
            
            public static readonly ModelProperty BaseTypeProperty =
                ModelProperty.Register("BaseType", typeof(global::MetaDslx.Soal.Exception), typeof(global::MetaDslx.Soal.Exception), typeof(global::MetaDslx.Soal.SoalDescriptor.Exception), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Exception_BaseTypeProperty));
            
        }
        
        public static class Interface
        {
            internal static void StaticInit()
            {
            }
        
            static Interface()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Interface; }
            }
        
            [ScopeEntry]
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), "Parent")]
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Operation>), typeof(global::MetaDslx.Soal.Interface), typeof(global::MetaDslx.Soal.SoalDescriptor.Interface), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Interface_OperationsProperty));
            
        }
        
        public static class Operation
        {
            internal static void StaticInit()
            {
            }
        
            static Operation()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Operation; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Interface), "Operations")]
            public static readonly ModelProperty ParentProperty =
                ModelProperty.Register("Parent", typeof(global::MetaDslx.Soal.Interface), typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Operation_ParentProperty));
            
            
            public static readonly ModelProperty IsOnewayProperty =
                ModelProperty.Register("IsOneway", typeof(bool), typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Operation_IsOnewayProperty));
            
            
            public static readonly ModelProperty ReturnTypeProperty =
                ModelProperty.Register("ReturnType", typeof(global::MetaDslx.Soal.SoalType), typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Operation_ReturnTypeProperty));
            
            
            [ContainmentAttribute]
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Parameter), "Operation")]
            public static readonly ModelProperty ParametersProperty =
                ModelProperty.Register("Parameters", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Parameter>), typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Operation_ParametersProperty));
            
            
            public static readonly ModelProperty ExceptionsProperty =
                ModelProperty.Register("Exceptions", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Exception>), typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Operation_ExceptionsProperty));
            
        }
        
        public static class Parameter
        {
            internal static void StaticInit()
            {
            }
        
            static Parameter()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Parameter; }
            }
        
            
            [OppositeAttribute(typeof(global::MetaDslx.Soal.SoalDescriptor.Operation), "Parameters")]
            public static readonly ModelProperty OperationProperty =
                ModelProperty.Register("Operation", typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Soal.Parameter), typeof(global::MetaDslx.Soal.SoalDescriptor.Parameter), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Parameter_OperationProperty));
            
        }
        
        public static class Binding
        {
            internal static void StaticInit()
            {
            }
        
            static Binding()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Binding; }
            }
        
            
            public static readonly ModelProperty TransportProperty =
                ModelProperty.Register("Transport", typeof(global::MetaDslx.Soal.TransportBindingElement), typeof(global::MetaDslx.Soal.Binding), typeof(global::MetaDslx.Soal.SoalDescriptor.Binding), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Binding_TransportProperty));
            
            
            public static readonly ModelProperty EncodingsProperty =
                ModelProperty.Register("Encodings", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.EncodingBindingElement>), typeof(global::MetaDslx.Soal.Binding), typeof(global::MetaDslx.Soal.SoalDescriptor.Binding), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Binding_EncodingsProperty));
            
            
            public static readonly ModelProperty ProtocolsProperty =
                ModelProperty.Register("Protocols", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Soal.ProtocolBindingElement>), typeof(global::MetaDslx.Soal.Binding), typeof(global::MetaDslx.Soal.SoalDescriptor.Binding), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Binding_ProtocolsProperty));
            
        }
        
        public static class Endpoint
        {
            internal static void StaticInit()
            {
            }
        
            static Endpoint()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.Endpoint; }
            }
        
            
            public static readonly ModelProperty InterfaceProperty =
                ModelProperty.Register("Interface", typeof(global::MetaDslx.Soal.Interface), typeof(global::MetaDslx.Soal.Endpoint), typeof(global::MetaDslx.Soal.SoalDescriptor.Endpoint), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Endpoint_InterfaceProperty));
            
            
            public static readonly ModelProperty BindingProperty =
                ModelProperty.Register("Binding", typeof(global::MetaDslx.Soal.Binding), typeof(global::MetaDslx.Soal.Endpoint), typeof(global::MetaDslx.Soal.SoalDescriptor.Endpoint), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Endpoint_BindingProperty));
            
            
            public static readonly ModelProperty AddressProperty =
                ModelProperty.Register("Address", typeof(string), typeof(global::MetaDslx.Soal.Endpoint), typeof(global::MetaDslx.Soal.SoalDescriptor.Endpoint), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.Endpoint_AddressProperty));
            
        }
        
        public static class BindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static BindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.BindingElement; }
            }
        
        }
        
        public static class TransportBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static TransportBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.TransportBindingElement; }
            }
        
        }
        
        public static class EncodingBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static EncodingBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.EncodingBindingElement; }
            }
        
        }
        
        public static class ProtocolBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static ProtocolBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.ProtocolBindingElement; }
            }
        
        }
        
        public static class HttpTransportBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static HttpTransportBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.HttpTransportBindingElement; }
            }
        
        }
        
        public static class RestTransportBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static RestTransportBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.RestTransportBindingElement; }
            }
        
        }
        
        public static class WebSocketTransportBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static WebSocketTransportBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.WebSocketTransportBindingElement; }
            }
        
        }
        
        public static class SoapEncodingBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static SoapEncodingBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement; }
            }
        
            
            public static readonly ModelProperty VersionProperty =
                ModelProperty.Register("Version", typeof(global::MetaDslx.Soal.SoapVersion), typeof(global::MetaDslx.Soal.SoapEncodingBindingElement), typeof(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement_VersionProperty));
            
            
            public static readonly ModelProperty MtomEnabledProperty =
                ModelProperty.Register("MtomEnabled", typeof(bool), typeof(global::MetaDslx.Soal.SoapEncodingBindingElement), typeof(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement_MtomEnabledProperty));
            
        }
        
        public static class XmlEncodingBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static XmlEncodingBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.XmlEncodingBindingElement; }
            }
        
        }
        
        public static class JsonEncodingBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static JsonEncodingBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.JsonEncodingBindingElement; }
            }
        
        }
        
        public static class WsProtocolBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static WsProtocolBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.WsProtocolBindingElement; }
            }
        
        }
        
        public static class WsAddressingBindingElement
        {
            internal static void StaticInit()
            {
            }
        
            static WsAddressingBindingElement()
            {
                global::MetaDslx.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Soal.SoalInstance.WsAddressingBindingElement; }
            }
        
        }
    }
    
	public static class SoalInstance
	{
	    private static global::MetaDslx.Core.Model model;
	
	    public static global::MetaDslx.Core.Model Model
	    {
	        get { return SoalInstance.model; }
	    }
	
	    public static readonly global::MetaDslx.Core.MetaModel Meta;
	
	    public static readonly global::MetaDslx.Soal.PrimitiveType Object;
	    public static readonly global::MetaDslx.Soal.PrimitiveType String;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Int;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Long;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Float;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Double;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Byte;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Bool;
	    public static readonly global::MetaDslx.Soal.PrimitiveType Void;
	    public static readonly global::MetaDslx.Soal.PrimitiveType DateTime;
	    public static readonly global::MetaDslx.Soal.PrimitiveType TimeSpan;
	
		
		
		
		
		
		
		
		
		
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass NamedElement;
		
		public static readonly global::MetaDslx.Core.MetaClass TypedElement;
		
		public static readonly global::MetaDslx.Core.MetaClass SoalType;
		
		public static readonly global::MetaDslx.Core.MetaClass Namespace;
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass Declaration;
		
		public static readonly global::MetaDslx.Core.MetaClass ArrayType;
		
		
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass NullableType;
		
		
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass PrimitiveType;
		public static readonly global::MetaDslx.Core.MetaClass Enum;
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass EnumLiteral;
		
		
		public static readonly global::MetaDslx.Core.MetaClass StructuredType;
		
		public static readonly global::MetaDslx.Core.MetaClass Property;
		
		public static readonly global::MetaDslx.Core.MetaClass Struct;
		
		public static readonly global::MetaDslx.Core.MetaClass Exception;
		
		public static readonly global::MetaDslx.Core.MetaClass Interface;
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass Operation;
		
		
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass Parameter;
		
		public static readonly global::MetaDslx.Core.MetaClass Binding;
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass Endpoint;
		
		
		
		public static readonly global::MetaDslx.Core.MetaClass BindingElement;
		public static readonly global::MetaDslx.Core.MetaClass TransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass EncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass ProtocolBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass HttpTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass RestTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WebSocketTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaEnum SoapVersion;
		
		
		public static readonly global::MetaDslx.Core.MetaClass SoapEncodingBindingElement;
		
		
		public static readonly global::MetaDslx.Core.MetaClass XmlEncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass JsonEncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WsProtocolBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WsAddressingBindingElement;
	
		public static readonly global::MetaDslx.Core.MetaProperty NamedElement_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty TypedElement_TypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Namespace_DeclarationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Declaration_NamespaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty ArrayType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty ArrayType_NamespaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty NullableType_InnerTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty NullableType_NamespaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Enum_EnumLiteralsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty EnumLiteral_EnumProperty;
		public static readonly global::MetaDslx.Core.MetaProperty StructuredType_PropertiesProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Property_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Struct_BaseTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Exception_BaseTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Interface_OperationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_ParentProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_IsOnewayProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_ReturnTypeProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_ParametersProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_ExceptionsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Parameter_OperationProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_TransportProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_EncodingsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_ProtocolsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_InterfaceProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_BindingProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_AddressProperty;
		public static readonly global::MetaDslx.Core.MetaProperty SoapEncodingBindingElement_VersionProperty;
		public static readonly global::MetaDslx.Core.MetaProperty SoapEncodingBindingElement_MtomEnabledProperty;
	
	    static SoalInstance()
	    {
			SoalDescriptor.StaticInit();
			SoalInstance.model = new global::MetaDslx.Core.Model();
	   		using (new ModelContextScope(SoalInstance.model))
			{
	            Object = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "object"))});
	            String = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "string"))});
	            Int = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "int"))});
	            Long = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "long"))});
	            Float = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "float"))});
	            Double = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "double"))});
	            Byte = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "byte"))});
	            Bool = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "bool"))});
	            Void = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "void"))});
	            DateTime = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "DateTime"))});
	            TimeSpan = global::MetaDslx.Soal.SoalFactory.Instance.CreatePrimitiveType(new List<ModelPropertyInitializer>() {new ModelPropertyInitializer(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, new Lazy<object>(() => "TimeSpan"))});
	
				global::MetaDslx.Core.MetaNamespace tmp1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaNamespace tmp2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaModel tmp3 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaModel();
				Meta = tmp3;
				global::MetaDslx.Core.MetaConstant tmp4 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp5 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp6 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp7 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp8 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp9 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp10 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp11 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp12 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp13 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				global::MetaDslx.Core.MetaConstant tmp14 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstant();
				NamedElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				NamedElement_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaAnnotation tmp15 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				TypedElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				TypedElement_TypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaAnnotation tmp16 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				SoalType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				global::MetaDslx.Core.MetaAnnotation tmp17 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				Namespace = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Namespace_DeclarationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaAnnotation tmp18 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				global::MetaDslx.Core.MetaCollectionType tmp19 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				global::MetaDslx.Core.MetaAnnotation tmp20 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				Declaration = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Declaration_NamespaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				ArrayType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				global::MetaDslx.Core.MetaConstructor tmp21 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstructor();
				global::MetaDslx.Core.MetaSynthetizedPropertyInitializer tmp22 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaSynthetizedPropertyInitializer();
				global::MetaDslx.Core.MetaConditionalExpression tmp23 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConditionalExpression();
				global::MetaDslx.Core.MetaTypeCheckExpression tmp24 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaTypeCheckExpression();
				global::MetaDslx.Core.MetaIdentifierExpression tmp25 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaIdentifierExpression();
				global::MetaDslx.Core.MetaMemberAccessExpression tmp26 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaMemberAccessExpression();
				global::MetaDslx.Core.MetaBracketExpression tmp27 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaBracketExpression();
				global::MetaDslx.Core.MetaTypeCastExpression tmp28 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaTypeCastExpression();
				global::MetaDslx.Core.MetaIdentifierExpression tmp29 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaIdentifierExpression();
				global::MetaDslx.Core.MetaConstantExpression tmp30 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				ArrayType_InnerTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				ArrayType_NamespaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				NullableType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				global::MetaDslx.Core.MetaConstructor tmp31 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstructor();
				global::MetaDslx.Core.MetaSynthetizedPropertyInitializer tmp32 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaSynthetizedPropertyInitializer();
				global::MetaDslx.Core.MetaConditionalExpression tmp33 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConditionalExpression();
				global::MetaDslx.Core.MetaTypeCheckExpression tmp34 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaTypeCheckExpression();
				global::MetaDslx.Core.MetaIdentifierExpression tmp35 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaIdentifierExpression();
				global::MetaDslx.Core.MetaMemberAccessExpression tmp36 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaMemberAccessExpression();
				global::MetaDslx.Core.MetaBracketExpression tmp37 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaBracketExpression();
				global::MetaDslx.Core.MetaTypeCastExpression tmp38 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaTypeCastExpression();
				global::MetaDslx.Core.MetaIdentifierExpression tmp39 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaIdentifierExpression();
				global::MetaDslx.Core.MetaConstantExpression tmp40 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				NullableType_InnerTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				NullableType_NamespaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				PrimitiveType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Enum = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Enum_EnumLiteralsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaAnnotation tmp41 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				global::MetaDslx.Core.MetaCollectionType tmp42 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				global::MetaDslx.Core.MetaAnnotation tmp43 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				EnumLiteral = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				global::MetaDslx.Core.MetaConstructor tmp44 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstructor();
				global::MetaDslx.Core.MetaSynthetizedPropertyInitializer tmp45 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaSynthetizedPropertyInitializer();
				global::MetaDslx.Core.MetaIdentifierExpression tmp46 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaIdentifierExpression();
				EnumLiteral_EnumProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				StructuredType = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				StructuredType_PropertiesProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp47 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Property = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Property_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Struct = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Struct_BaseTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Exception = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Exception_BaseTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Interface = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Interface_OperationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaAnnotation tmp48 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				global::MetaDslx.Core.MetaCollectionType tmp49 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				global::MetaDslx.Core.MetaAnnotation tmp50 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaAnnotation();
				Operation = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Operation_ParentProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Operation_IsOnewayProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Operation_ReturnTypeProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Operation_ParametersProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp51 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Operation_ExceptionsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp52 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Parameter = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Parameter_OperationProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Binding = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Binding_TransportProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Binding_EncodingsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp53 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Binding_ProtocolsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp54 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Endpoint = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Endpoint_InterfaceProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Endpoint_BindingProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Endpoint_AddressProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				BindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				TransportBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				EncodingBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				ProtocolBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				HttpTransportBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				RestTransportBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				WebSocketTransportBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				SoapVersion = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaEnum();
				global::MetaDslx.Core.MetaEnumLiteral tmp55 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaEnumLiteral();
				global::MetaDslx.Core.MetaEnumLiteral tmp56 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaEnumLiteral();
				SoapEncodingBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				SoapEncodingBindingElement_VersionProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				SoapEncodingBindingElement_MtomEnabledProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				XmlEncodingBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				JsonEncodingBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				WsProtocolBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				WsAddressingBindingElement = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
	
				
				
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty, new Lazy<object>(() => tmp2));
				
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "MetaDslx"));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => null));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => null));
				
				
				
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp4));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp5));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp6));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp7));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp8));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp9));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp10));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp11));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp12));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp13));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => tmp14));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => TypedElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => ArrayType));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => NullableType));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Enum));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => EnumLiteral));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => StructuredType));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Property));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Struct));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Exception));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Interface));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Operation));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Parameter));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Binding));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Endpoint));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => BindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => TransportBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => EncodingBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => ProtocolBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => HttpTransportBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => RestTransportBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => WebSocketTransportBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => SoapVersion));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => SoapEncodingBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => XmlEncodingBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => JsonEncodingBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => WsProtocolBindingElement));
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => WsAddressingBindingElement));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => tmp1));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => tmp3));
				
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty, new Lazy<object>(() => "http://MetaDslx.Soal/1.0"));
				
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Object"));
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp57 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp58 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp57).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp58));
				((ModelObject)tmp57).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp57).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp57).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp57).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp57).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp57).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp57).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp57).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp58).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp58).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp57));
				((ModelObject)tmp58).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp58).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp58).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp59 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp59).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp59).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "object"));
				((ModelObject)tmp59).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp59).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp59).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp59).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp59).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp59).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp58).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp59));
				((ModelObject)tmp58).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp58).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp57));
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "String"));
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp60 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp61 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp60).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp61));
				((ModelObject)tmp60).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp60).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp60).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp60).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp60).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp60).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp60).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp60).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp61).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp61).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp60));
				((ModelObject)tmp61).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp61).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp61).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp62 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp62).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp62).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "string"));
				((ModelObject)tmp62).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp62).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp62).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp62).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp62).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp62).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp61).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp62));
				((ModelObject)tmp61).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp61).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp60));
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp6).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp6).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Int"));
				((ModelObject)tmp6).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp6).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp6).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp63 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp64 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp63).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp64));
				((ModelObject)tmp63).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp63).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp63).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp63).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp63).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp63).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp63).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp63).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp64).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp64).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp63));
				((ModelObject)tmp64).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp64).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp64).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp65 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp65).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp65).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "int"));
				((ModelObject)tmp65).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp65).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp65).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp65).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp65).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp65).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp64).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp65));
				((ModelObject)tmp64).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp64).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp6).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp63));
				((ModelObject)tmp6).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp6).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp7).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp7).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Long"));
				((ModelObject)tmp7).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp7).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp7).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp66 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp67 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp66).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp67));
				((ModelObject)tmp66).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp66).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp66).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp66).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp66).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp66).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp66).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp66).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp67).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp67).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp66));
				((ModelObject)tmp67).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp67).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp67).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp68 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp68).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp68).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "long"));
				((ModelObject)tmp68).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp68).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp68).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp68).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp68).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp68).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp67).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp68));
				((ModelObject)tmp67).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp67).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp7).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp66));
				((ModelObject)tmp7).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp7).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp8).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp8).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Float"));
				((ModelObject)tmp8).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp8).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp8).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp69 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp70 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp69).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp70));
				((ModelObject)tmp69).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp69).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp69).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp69).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp69).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp69).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp69).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp69).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp70).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp70).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp69));
				((ModelObject)tmp70).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp70).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp70).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp71 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp71).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp71).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "float"));
				((ModelObject)tmp71).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp71).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp71).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp71).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp71).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp71).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp70).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp71));
				((ModelObject)tmp70).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp70).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp8).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp69));
				((ModelObject)tmp8).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp8).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp9).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp9).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Double"));
				((ModelObject)tmp9).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp9).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp9).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp72 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp73 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp72).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp73));
				((ModelObject)tmp72).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp72).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp72).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp72).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp72).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp72).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp72).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp72).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp73).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp73).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp72));
				((ModelObject)tmp73).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp73).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp73).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp74 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp74).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp74).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "double"));
				((ModelObject)tmp74).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp74).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp74).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp74).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp74).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp74).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp73).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp74));
				((ModelObject)tmp73).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp73).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp9).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp72));
				((ModelObject)tmp9).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp9).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp10).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp10).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Byte"));
				((ModelObject)tmp10).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp10).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp10).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp75 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp76 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp75).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp76));
				((ModelObject)tmp75).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp75).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp75).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp75).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp75).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp75).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp75).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp75).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp76).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp76).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp75));
				((ModelObject)tmp76).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp76).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp76).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp77 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp77).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp77).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "byte"));
				((ModelObject)tmp77).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp77).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp77).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp77).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp77).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp77).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp76).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp77));
				((ModelObject)tmp76).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp76).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp10).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp75));
				((ModelObject)tmp10).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp10).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp11).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp11).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Bool"));
				((ModelObject)tmp11).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp11).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp11).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp78 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp79 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp78).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp79));
				((ModelObject)tmp78).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp78).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp78).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp78).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp78).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp78).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp78).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp78).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp79).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp79).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp78));
				((ModelObject)tmp79).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp79).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp79).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp80 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp80).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp80).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "bool"));
				((ModelObject)tmp80).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp80).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp80).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp80).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp80).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp80).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp79).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp80));
				((ModelObject)tmp79).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp79).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp11).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp78));
				((ModelObject)tmp11).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp11).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp12).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp12).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Void"));
				((ModelObject)tmp12).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp12).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp12).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp81 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp82 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp81).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp82));
				((ModelObject)tmp81).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp81).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp81).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp81).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp81).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp81).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp81).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp81).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp82).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp82).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp81));
				((ModelObject)tmp82).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp82).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp82).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp83 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp83).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp83).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "void"));
				((ModelObject)tmp83).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp83).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp83).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp83).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp83).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp83).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp82).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp83));
				((ModelObject)tmp82).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp82).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp12).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp81));
				((ModelObject)tmp12).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp12).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp13).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp13).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "DateTime"));
				((ModelObject)tmp13).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp13).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp13).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp84 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp85 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp84).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp85));
				((ModelObject)tmp84).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp84).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp84).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp84).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp84).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp84).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp84).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp84).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp85).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp85).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp84));
				((ModelObject)tmp85).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp85).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp85).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp86 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp86).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp86).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "DateTime"));
				((ModelObject)tmp86).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp86).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp86).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp86).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp86).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp86).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp85).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp86));
				((ModelObject)tmp85).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp85).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp13).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp84));
				((ModelObject)tmp13).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp13).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				((ModelObject)tmp14).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp14).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "TimeSpan"));
				((ModelObject)tmp14).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)tmp14).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp14).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty);
				global::MetaDslx.Core.MetaNewExpression tmp87 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewExpression();
				global::MetaDslx.Core.MetaNewPropertyInitializer tmp88 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNewPropertyInitializer();
				((ModelObject)tmp87).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.PropertyInitializersProperty, new Lazy<object>(() => tmp88));
				((ModelObject)tmp87).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty);
				((ModelObject)tmp87).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewExpression.TypeReferenceProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp87).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp87).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp87).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp87).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => PrimitiveType));
				((ModelObject)tmp87).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp87).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp88).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty);
				((ModelObject)tmp88).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ParentProperty, new Lazy<object>(() => tmp87));
				((ModelObject)tmp88).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp88).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)tmp88).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty);
				global::MetaDslx.Core.MetaConstantExpression tmp89 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaConstantExpression();
				((ModelObject)tmp89).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				((ModelObject)tmp89).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => "TimeSpan"));
				((ModelObject)tmp89).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp89).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp89).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp89).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)tmp89).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp89).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp88).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp89));
				((ModelObject)tmp88).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty);
				((ModelObject)tmp88).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNewPropertyInitializer.PropertyProperty, new Lazy<object>(() => NamedElement_NameProperty));
				((ModelObject)tmp14).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstant.ValueProperty, new Lazy<object>(() => tmp87));
				((ModelObject)tmp14).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp14).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => PrimitiveType));
				
				
				((ModelObject)NamedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => NamedElement_NameProperty));
				
				((ModelObject)NamedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)NamedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "NamedElement"));
				((ModelObject)NamedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)NamedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)NamedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)NamedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)NamedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)NamedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)NamedElement_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp15));
				
				
				
				
				
				((ModelObject)NamedElement_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)NamedElement_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)NamedElement_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)NamedElement_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)NamedElement_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)NamedElement_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)NamedElement_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)NamedElement_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp15).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp15).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Name"));
				
				
				((ModelObject)TypedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => TypedElement_TypeProperty));
				
				((ModelObject)TypedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)TypedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "TypedElement"));
				((ModelObject)TypedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)TypedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)TypedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)TypedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)TypedElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)TypedElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)TypedElement_TypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp16));
				
				
				
				
				
				((ModelObject)TypedElement_TypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)TypedElement_TypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Type"));
				((ModelObject)TypedElement_TypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)TypedElement_TypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => TypedElement));
				((ModelObject)TypedElement_TypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)TypedElement_TypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)TypedElement_TypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)TypedElement_TypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp16).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp16).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Type"));
				((ModelObject)SoalType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp17));
				
				
				
				((ModelObject)SoalType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)SoalType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "SoalType"));
				((ModelObject)SoalType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)SoalType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)SoalType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)SoalType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)SoalType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)SoalType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp17).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp17).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Type"));
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp20));
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Namespace_DeclarationsProperty));
				
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Namespace).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Namespace).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp18));
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Declaration_NamespaceProperty));
				
				
				
				
				((ModelObject)Namespace_DeclarationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Declarations"));
				((ModelObject)Namespace_DeclarationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Namespace));
				((ModelObject)Namespace_DeclarationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Containment));
				((ModelObject)Namespace_DeclarationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Namespace_DeclarationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp19));
				
				((ModelObject)tmp18).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp18).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ScopeEntry"));
				((ModelObject)tmp19).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp19).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp19).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp19).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Declaration));
				
				((ModelObject)tmp20).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp20).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Scope"));
				
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Declaration_NamespaceProperty));
				
				((ModelObject)Declaration).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Declaration"));
				((ModelObject)Declaration).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Declaration).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)Declaration).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Declaration).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)Declaration_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Namespace_DeclarationsProperty));
				
				
				
				
				((ModelObject)Declaration_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Declaration_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)Declaration_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Declaration_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Declaration_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Declaration_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)Declaration_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Declaration_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => ArrayType_InnerTypeProperty));
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => ArrayType_NamespaceProperty));
				
				((ModelObject)ArrayType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ArrayType"));
				((ModelObject)ArrayType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)ArrayType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => tmp21));
				((ModelObject)ArrayType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)ArrayType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp21).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty, new Lazy<object>(() => tmp22));
				((ModelObject)tmp21).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp21).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ArrayType"));
				((ModelObject)tmp21).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty);
				((ModelObject)tmp21).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty, new Lazy<object>(() => ArrayType));
				((ModelObject)tmp22).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty);
				((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, new Lazy<object>(() => tmp21));
				((ModelObject)tmp22).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)tmp22).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty);
				((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp23));
				((ModelObject)tmp22).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty);
				((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => ArrayType));
				((ModelObject)tmp22).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty);
				((ModelObject)tmp22).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => ArrayType_NamespaceProperty));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty, new Lazy<object>(() => tmp24));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty, new Lazy<object>(() => tmp26));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty, new Lazy<object>(() => tmp30));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp23).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty);
				((ModelObject)tmp23).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty, new Lazy<object>(() => null));
				((ModelObject)tmp24).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty);
				((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty, new Lazy<object>(() => tmp25));
				((ModelObject)tmp24).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)tmp24).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)tmp24).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp24).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty);
				((ModelObject)tmp24).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty, new Lazy<object>(() => Declaration));
				
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, new Lazy<object>(() => "InnerType"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ArrayType_InnerTypeProperty));
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp25).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp25).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty, new Lazy<object>(() => tmp27));
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty, new Lazy<object>(() => "Namespace"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => Declaration_NamespaceProperty));
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp26).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp26).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				((ModelObject)tmp27).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty);
				((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty, new Lazy<object>(() => tmp28));
				((ModelObject)tmp27).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp27).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.None	));
				((ModelObject)tmp27).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp27).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp27).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
				((ModelObject)tmp28).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty);
				((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, new Lazy<object>(() => tmp29));
				((ModelObject)tmp28).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty);
				((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp28).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp28).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.None	));
				((ModelObject)tmp28).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp28).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, new Lazy<object>(() => "InnerType"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => ArrayType_InnerTypeProperty));
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp29).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp29).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				((ModelObject)tmp30).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				global::MetaDslx.Core.MetaNullExpression tmp90 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNullExpression();
				((ModelObject)tmp90).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp90).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp90).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp90).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp90).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp90).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => null));
				((ModelObject)tmp30).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => tmp90));
				((ModelObject)tmp30).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp30).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp30).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp30).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp30).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp30).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				
				
				
				
				
				
				((ModelObject)ArrayType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)ArrayType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "InnerType"));
				((ModelObject)ArrayType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)ArrayType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => ArrayType));
				((ModelObject)ArrayType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)ArrayType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)ArrayType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)ArrayType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)ArrayType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)ArrayType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)ArrayType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)ArrayType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => ArrayType));
				((ModelObject)ArrayType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)ArrayType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Derived));
				((ModelObject)ArrayType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)ArrayType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => NullableType_InnerTypeProperty));
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => NullableType_NamespaceProperty));
				
				((ModelObject)NullableType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "NullableType"));
				((ModelObject)NullableType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)NullableType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => tmp31));
				((ModelObject)NullableType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)NullableType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp31).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty, new Lazy<object>(() => tmp32));
				((ModelObject)tmp31).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp31).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "NullableType"));
				((ModelObject)tmp31).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty);
				((ModelObject)tmp31).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty, new Lazy<object>(() => NullableType));
				((ModelObject)tmp32).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty);
				((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, new Lazy<object>(() => tmp31));
				((ModelObject)tmp32).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)tmp32).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty);
				((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp33));
				((ModelObject)tmp32).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty);
				((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => NullableType));
				((ModelObject)tmp32).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty);
				((ModelObject)tmp32).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => NullableType_NamespaceProperty));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ConditionProperty, new Lazy<object>(() => tmp34));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ThenProperty, new Lazy<object>(() => tmp36));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.ElseProperty, new Lazy<object>(() => tmp40));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp33).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty);
				((ModelObject)tmp33).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConditionalExpression.BalancedTypeProperty, new Lazy<object>(() => null));
				((ModelObject)tmp34).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty);
				((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.ExpressionProperty, new Lazy<object>(() => tmp35));
				((ModelObject)tmp34).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)tmp34).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)tmp34).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp34).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty);
				((ModelObject)tmp34).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeCheckExpression.TypeReferenceProperty, new Lazy<object>(() => Declaration));
				
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, new Lazy<object>(() => "InnerType"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => NullableType_InnerTypeProperty));
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp35).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp35).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.ExpressionProperty, new Lazy<object>(() => tmp37));
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaMemberAccessExpression.NameProperty, new Lazy<object>(() => "Namespace"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => Declaration_NamespaceProperty));
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp36).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp36).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				((ModelObject)tmp37).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty);
				((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBracketExpression.ExpressionProperty, new Lazy<object>(() => tmp38));
				((ModelObject)tmp37).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp37).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.None	));
				((ModelObject)tmp37).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp37).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp37).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
				((ModelObject)tmp38).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty);
				((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.ExpressionProperty, new Lazy<object>(() => tmp39));
				((ModelObject)tmp38).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty);
				((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypeConversionExpression.TypeReferenceProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp38).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Declaration));
				((ModelObject)tmp38).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.None	));
				((ModelObject)tmp38).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp38).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, new Lazy<object>(() => "InnerType"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => NullableType_InnerTypeProperty));
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp39).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp39).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				((ModelObject)tmp40).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty);
				global::MetaDslx.Core.MetaNullExpression tmp91 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNullExpression();
				((ModelObject)tmp91).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp91).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp91).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp91).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp91).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp91).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => null));
				((ModelObject)tmp40).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstantExpression.ValueProperty, new Lazy<object>(() => tmp91));
				((ModelObject)tmp40).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp40).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Any	));
				((ModelObject)tmp40).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp40).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => Namespace));
				((ModelObject)tmp40).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp40).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				
				
				
				
				
				
				((ModelObject)NullableType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)NullableType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "InnerType"));
				((ModelObject)NullableType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)NullableType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => NullableType));
				((ModelObject)NullableType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)NullableType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)NullableType_InnerTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)NullableType_InnerTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)NullableType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)NullableType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Namespace"));
				((ModelObject)NullableType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)NullableType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => NullableType));
				((ModelObject)NullableType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)NullableType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Derived));
				((ModelObject)NullableType_NamespaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)NullableType_NamespaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Namespace));
				
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				
				
				((ModelObject)PrimitiveType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "PrimitiveType"));
				((ModelObject)PrimitiveType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)PrimitiveType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)PrimitiveType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)PrimitiveType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp43));
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Enum_EnumLiteralsProperty));
				
				((ModelObject)Enum).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Enum"));
				((ModelObject)Enum).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Enum).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Enum).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Enum).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp41));
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => EnumLiteral_EnumProperty));
				
				
				
				
				((ModelObject)Enum_EnumLiteralsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "EnumLiterals"));
				((ModelObject)Enum_EnumLiteralsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Enum));
				((ModelObject)Enum_EnumLiteralsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Containment));
				((ModelObject)Enum_EnumLiteralsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Enum_EnumLiteralsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp42));
				
				((ModelObject)tmp41).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp41).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ScopeEntry"));
				((ModelObject)tmp42).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp42).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp42).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp42).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => EnumLiteral));
				
				((ModelObject)tmp43).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp43).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Scope"));
				
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TypedElement));
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => EnumLiteral_EnumProperty));
				
				((ModelObject)EnumLiteral).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "EnumLiteral"));
				((ModelObject)EnumLiteral).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)EnumLiteral).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => tmp44));
				((ModelObject)EnumLiteral).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)EnumLiteral).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				
				((ModelObject)tmp44).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.InitializersProperty, new Lazy<object>(() => tmp45));
				((ModelObject)tmp44).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp44).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "EnumLiteral"));
				((ModelObject)tmp44).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty);
				((ModelObject)tmp44).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaConstructor.ParentProperty, new Lazy<object>(() => EnumLiteral));
				((ModelObject)tmp45).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty);
				((ModelObject)tmp45).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ConstructorProperty, new Lazy<object>(() => tmp44));
				((ModelObject)tmp45).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty);
				((ModelObject)tmp45).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyNameProperty, new Lazy<object>(() => "Type"));
				((ModelObject)tmp45).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty);
				((ModelObject)tmp45).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.ValueProperty, new Lazy<object>(() => tmp46));
				((ModelObject)tmp45).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty);
				((ModelObject)tmp45).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyContextProperty, new Lazy<object>(() => EnumLiteral));
				((ModelObject)tmp45).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty);
				((ModelObject)tmp45).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaPropertyInitializer.PropertyProperty, new Lazy<object>(() => TypedElement_TypeProperty));
				
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaIdentifierExpression.NameProperty, new Lazy<object>(() => "Enum"));
				// global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionsProperty = System.Collections.Generic.List`1[MetaDslx.Core.ModelObject]
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => EnumLiteral_EnumProperty));
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Enum));
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => true));
				((ModelObject)tmp46).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty);
				((ModelObject)tmp46).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
				
				((ModelObject)EnumLiteral_EnumProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Enum_EnumLiteralsProperty));
				
				
				
				
				((ModelObject)EnumLiteral_EnumProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)EnumLiteral_EnumProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Enum"));
				((ModelObject)EnumLiteral_EnumProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)EnumLiteral_EnumProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => EnumLiteral));
				((ModelObject)EnumLiteral_EnumProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)EnumLiteral_EnumProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Enum));
				((ModelObject)EnumLiteral_EnumProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)EnumLiteral_EnumProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => StructuredType_PropertiesProperty));
				
				((ModelObject)StructuredType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "StructuredType"));
				((ModelObject)StructuredType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)StructuredType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)StructuredType).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)StructuredType).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)StructuredType_PropertiesProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Property_ParentProperty));
				
				
				
				
				((ModelObject)StructuredType_PropertiesProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)StructuredType_PropertiesProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Properties"));
				((ModelObject)StructuredType_PropertiesProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)StructuredType_PropertiesProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => StructuredType));
				((ModelObject)StructuredType_PropertiesProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)StructuredType_PropertiesProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Containment));
				((ModelObject)StructuredType_PropertiesProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)StructuredType_PropertiesProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp47));
				((ModelObject)tmp47).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp47).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp47).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp47).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Property));
				
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TypedElement));
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Property_ParentProperty));
				
				((ModelObject)Property).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Property"));
				((ModelObject)Property).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Property).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Property).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Property).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)Property_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => StructuredType_PropertiesProperty));
				
				
				
				
				((ModelObject)Property_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Property_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Parent"));
				((ModelObject)Property_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Property_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Property));
				((ModelObject)Property_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Property_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => StructuredType));
				((ModelObject)Property_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Property_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => StructuredType));
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Struct_BaseTypeProperty));
				
				((ModelObject)Struct).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Struct"));
				((ModelObject)Struct).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Struct).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Struct).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Struct).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Struct_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Struct_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "BaseType"));
				((ModelObject)Struct_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Struct_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Struct));
				((ModelObject)Struct_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Struct_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Struct));
				((ModelObject)Struct_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Struct_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => StructuredType));
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Exception_BaseTypeProperty));
				
				((ModelObject)Exception).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Exception"));
				((ModelObject)Exception).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Exception).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Exception).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Exception).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Exception_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Exception_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "BaseType"));
				((ModelObject)Exception_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Exception_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Exception));
				((ModelObject)Exception_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Exception_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Exception));
				((ModelObject)Exception_BaseTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Exception_BaseTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp50));
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => SoalType));
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Interface_OperationsProperty));
				
				((ModelObject)Interface).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Interface"));
				((ModelObject)Interface).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Interface).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Interface).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Interface).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaAnnotatedElement.AnnotationsProperty, new Lazy<object>(() => tmp48));
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Operation_ParentProperty));
				
				
				
				
				((ModelObject)Interface_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Operations"));
				((ModelObject)Interface_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Interface));
				((ModelObject)Interface_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Containment));
				((ModelObject)Interface_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Interface_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp49));
				
				((ModelObject)tmp48).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp48).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ScopeEntry"));
				((ModelObject)tmp49).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp49).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp49).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp49).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Operation));
				
				((ModelObject)tmp50).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp50).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Scope"));
				
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_ParentProperty));
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_IsOnewayProperty));
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_ReturnTypeProperty));
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_ParametersProperty));
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_ExceptionsProperty));
				
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Operation"));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)Operation_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Interface_OperationsProperty));
				
				
				
				
				((ModelObject)Operation_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Parent"));
				((ModelObject)Operation_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Interface));
				((ModelObject)Operation_ParentProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_ParentProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Operation_IsOnewayProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_IsOnewayProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "IsOneway"));
				((ModelObject)Operation_IsOnewayProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_IsOnewayProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_IsOnewayProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_IsOnewayProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)Operation_IsOnewayProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_IsOnewayProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Operation_ReturnTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_ReturnTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ReturnType"));
				((ModelObject)Operation_ReturnTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_ReturnTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_ReturnTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_ReturnTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoalType));
				((ModelObject)Operation_ReturnTypeProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_ReturnTypeProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)Operation_ParametersProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Parameter_OperationProperty));
				
				
				
				
				((ModelObject)Operation_ParametersProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_ParametersProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Parameters"));
				((ModelObject)Operation_ParametersProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_ParametersProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_ParametersProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_ParametersProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaPropertyKind.Containment));
				((ModelObject)Operation_ParametersProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_ParametersProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp51));
				((ModelObject)tmp51).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp51).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp51).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp51).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Parameter));
				
				
				
				
				
				
				((ModelObject)Operation_ExceptionsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_ExceptionsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Exceptions"));
				((ModelObject)Operation_ExceptionsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_ExceptionsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_ExceptionsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_ExceptionsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp52));
				((ModelObject)Operation_ExceptionsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_ExceptionsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				((ModelObject)tmp52).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp52).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp52).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp52).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Exception));
				
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TypedElement));
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Parameter_OperationProperty));
				
				((ModelObject)Parameter).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Parameter"));
				((ModelObject)Parameter).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Parameter).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Parameter).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Parameter).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)Parameter_OperationProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.OppositePropertiesProperty, new Lazy<object>(() => Operation_ParametersProperty));
				
				
				
				
				((ModelObject)Parameter_OperationProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Parameter_OperationProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Operation"));
				((ModelObject)Parameter_OperationProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Parameter_OperationProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Parameter));
				((ModelObject)Parameter_OperationProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Parameter_OperationProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Operation));
				((ModelObject)Parameter_OperationProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Parameter_OperationProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Binding_TransportProperty));
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Binding_EncodingsProperty));
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Binding_ProtocolsProperty));
				
				((ModelObject)Binding).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Binding"));
				((ModelObject)Binding).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Binding).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Binding).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Binding).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Binding_TransportProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Binding_TransportProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Transport"));
				((ModelObject)Binding_TransportProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Binding_TransportProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Binding));
				((ModelObject)Binding_TransportProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Binding_TransportProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => TransportBindingElement));
				((ModelObject)Binding_TransportProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Binding_TransportProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Binding_EncodingsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Binding_EncodingsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Encodings"));
				((ModelObject)Binding_EncodingsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Binding_EncodingsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Binding));
				((ModelObject)Binding_EncodingsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Binding_EncodingsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp53));
				((ModelObject)Binding_EncodingsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Binding_EncodingsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				((ModelObject)tmp53).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp53).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp53).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp53).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => EncodingBindingElement));
				
				
				
				
				
				
				((ModelObject)Binding_ProtocolsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Binding_ProtocolsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Protocols"));
				((ModelObject)Binding_ProtocolsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Binding_ProtocolsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Binding));
				((ModelObject)Binding_ProtocolsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Binding_ProtocolsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp54));
				((ModelObject)Binding_ProtocolsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Binding_ProtocolsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				((ModelObject)tmp54).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp54).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp54).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp54).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => ProtocolBindingElement));
				
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => Declaration));
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Endpoint_InterfaceProperty));
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Endpoint_BindingProperty));
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Endpoint_AddressProperty));
				
				((ModelObject)Endpoint).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Endpoint"));
				((ModelObject)Endpoint).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)Endpoint).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Endpoint).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Endpoint).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Endpoint_InterfaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Endpoint_InterfaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Interface"));
				((ModelObject)Endpoint_InterfaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Endpoint_InterfaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Endpoint));
				((ModelObject)Endpoint_InterfaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Endpoint_InterfaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Interface));
				((ModelObject)Endpoint_InterfaceProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Endpoint_InterfaceProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Endpoint_BindingProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Endpoint_BindingProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Binding"));
				((ModelObject)Endpoint_BindingProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Endpoint_BindingProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Endpoint));
				((ModelObject)Endpoint_BindingProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Endpoint_BindingProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => Binding));
				((ModelObject)Endpoint_BindingProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Endpoint_BindingProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Endpoint_AddressProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Endpoint_AddressProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Address"));
				((ModelObject)Endpoint_AddressProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Endpoint_AddressProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Endpoint));
				((ModelObject)Endpoint_AddressProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Endpoint_AddressProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)Endpoint_AddressProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Endpoint_AddressProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)BindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => NamedElement));
				
				
				((ModelObject)BindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)BindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "BindingElement"));
				((ModelObject)BindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)BindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)BindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)BindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)BindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)BindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)TransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => BindingElement));
				
				
				((ModelObject)TransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)TransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "TransportBindingElement"));
				((ModelObject)TransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)TransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)TransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)TransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)TransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)TransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)EncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => BindingElement));
				
				
				((ModelObject)EncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)EncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "EncodingBindingElement"));
				((ModelObject)EncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)EncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)EncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)EncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)EncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)EncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)ProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => BindingElement));
				
				
				((ModelObject)ProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)ProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "ProtocolBindingElement"));
				((ModelObject)ProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)ProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)ProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)ProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)ProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)ProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)HttpTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TransportBindingElement));
				
				
				((ModelObject)HttpTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)HttpTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "HttpTransportBindingElement"));
				((ModelObject)HttpTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)HttpTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)HttpTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)HttpTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)HttpTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)HttpTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)RestTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TransportBindingElement));
				
				
				((ModelObject)RestTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)RestTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "RestTransportBindingElement"));
				((ModelObject)RestTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)RestTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)RestTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)RestTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)RestTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)RestTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)WebSocketTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => TransportBindingElement));
				
				
				((ModelObject)WebSocketTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)WebSocketTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "WebSocketTransportBindingElement"));
				((ModelObject)WebSocketTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)WebSocketTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)WebSocketTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)WebSocketTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)WebSocketTransportBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)WebSocketTransportBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)SoapVersion).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaEnum.EnumLiteralsProperty, new Lazy<object>(() => tmp55));
				((ModelObject)SoapVersion).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaEnum.EnumLiteralsProperty, new Lazy<object>(() => tmp56));
				
				((ModelObject)SoapVersion).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)SoapVersion).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "SoapVersion"));
				((ModelObject)SoapVersion).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)SoapVersion).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp55).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp55).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soap11"));
				((ModelObject)tmp55).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty);
				((ModelObject)tmp55).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty, new Lazy<object>(() => SoapVersion));
				((ModelObject)tmp55).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp55).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoapVersion));
				((ModelObject)tmp56).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp56).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soap12"));
				((ModelObject)tmp56).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty);
				((ModelObject)tmp56).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaEnumLiteral.EnumProperty, new Lazy<object>(() => SoapVersion));
				((ModelObject)tmp56).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)tmp56).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoapVersion));
				
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => EncodingBindingElement));
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => SoapEncodingBindingElement_VersionProperty));
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => SoapEncodingBindingElement_MtomEnabledProperty));
				
				((ModelObject)SoapEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "SoapEncodingBindingElement"));
				((ModelObject)SoapEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)SoapEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)SoapEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)SoapEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Version"));
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => SoapEncodingBindingElement));
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => SoapVersion));
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)SoapEncodingBindingElement_VersionProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "MtomEnabled"));
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => SoapEncodingBindingElement));
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.Bool	));
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)SoapEncodingBindingElement_MtomEnabledProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				((ModelObject)XmlEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => EncodingBindingElement));
				
				
				((ModelObject)XmlEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)XmlEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "XmlEncodingBindingElement"));
				((ModelObject)XmlEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)XmlEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)XmlEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)XmlEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)XmlEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)XmlEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)JsonEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => EncodingBindingElement));
				
				
				((ModelObject)JsonEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)JsonEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "JsonEncodingBindingElement"));
				((ModelObject)JsonEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)JsonEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)JsonEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)JsonEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)JsonEncodingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)JsonEncodingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)WsProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => ProtocolBindingElement));
				
				
				((ModelObject)WsProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)WsProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "WsProtocolBindingElement"));
				((ModelObject)WsProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)WsProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)WsProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)WsProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => true));
				((ModelObject)WsProtocolBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)WsProtocolBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				((ModelObject)WsAddressingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.SuperClassesProperty, new Lazy<object>(() => WsProtocolBindingElement));
				
				
				((ModelObject)WsAddressingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)WsAddressingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "WsAddressingBindingElement"));
				((ModelObject)WsAddressingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)WsAddressingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp2));
				((ModelObject)WsAddressingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)WsAddressingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)WsAddressingBindingElement).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)WsAddressingBindingElement).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
	
	            foreach (var mo in ModelContext.Current.Model.Instances)
	            {
	                mo.MEvalLazyValues();
	            }
			}
	    }
	}
    
    public enum SoapVersion
    {
        Soap11,
        Soap12,
    }
    
    
    public interface NamedElement
    {
        string Name { get; set; }
    
    }
    
    internal class NamedElementImpl : ModelObject, global::MetaDslx.Soal.NamedElement
    {
        static NamedElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.NamedElement; }
        }
    
        public NamedElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.NamedElement_NamedElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface TypedElement
    {
        global::MetaDslx.Soal.SoalType Type { get; set; }
    
    }
    
    internal class TypedElementImpl : ModelObject, global::MetaDslx.Soal.TypedElement
    {
        static TypedElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.TypedElement; }
        }
    
        public TypedElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.TypedElement_TypedElement(this);
            this.MMakeDefault();
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.TypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
        }
    }
    
    [Type]
    public interface SoalType
    {
    
    }
    
    internal class SoalTypeImpl : ModelObject, global::MetaDslx.Soal.SoalType
    {
        static SoalTypeImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.SoalType; }
        }
    
        public SoalTypeImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.SoalType_SoalType(this);
            this.MMakeDefault();
        }
    }
    
    [Scope]
    public interface Namespace : global::MetaDslx.Soal.Declaration
    {
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Declaration> Declarations { get; }
    
    }
    
    internal class NamespaceImpl : ModelObject, global::MetaDslx.Soal.Namespace
    {
        static NamespaceImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Namespace; }
        }
    
        public NamespaceImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Namespace.DeclarationsProperty, new global::MetaDslx.Core.ModelList<Declaration>(this, global::MetaDslx.Soal.SoalDescriptor.Namespace.DeclarationsProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Namespace_Namespace(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Declaration> global::MetaDslx.Soal.Namespace.Declarations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Namespace.DeclarationsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Declaration>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Declaration>);
            }
        }
    }
    
    
    public interface Declaration : global::MetaDslx.Soal.NamedElement
    {
        global::MetaDslx.Soal.Namespace Namespace { get; set; }
    
    }
    
    internal class DeclarationImpl : ModelObject, global::MetaDslx.Soal.Declaration
    {
        static DeclarationImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Declaration; }
        }
    
        public DeclarationImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Declaration_Declaration(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
    }
    
    
    public interface ArrayType : global::MetaDslx.Soal.SoalType
    {
        global::MetaDslx.Soal.SoalType InnerType { get; set; }
        global::MetaDslx.Soal.Namespace Namespace { get; }
    
    }
    
    internal class ArrayTypeImpl : ModelObject, global::MetaDslx.Soal.ArrayType
    {
        static ArrayTypeImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.ArrayType; }
        }
    
        public ArrayTypeImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.ArrayType_ArrayType(this);
            this.MMakeDefault();
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.ArrayType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.ArrayType.Namespace
        {
            get { return ((ArrayType)this).InnerType is Declaration ? ((Declaration)((ArrayType)this).InnerType).Namespace : null; }
        }
    }
    
    
    public interface NullableType : global::MetaDslx.Soal.SoalType
    {
        global::MetaDslx.Soal.SoalType InnerType { get; set; }
        global::MetaDslx.Soal.Namespace Namespace { get; }
    
    }
    
    internal class NullableTypeImpl : ModelObject, global::MetaDslx.Soal.NullableType
    {
        static NullableTypeImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.NullableType; }
        }
    
        public NullableTypeImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.NullableType_NullableType(this);
            this.MMakeDefault();
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.NullableType.InnerType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.NullableType.Namespace
        {
            get { return ((NullableType)this).InnerType is Declaration ? ((Declaration)((NullableType)this).InnerType).Namespace : null; }
        }
    }
    
    
    public interface PrimitiveType : global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement
    {
    
    }
    
    internal class PrimitiveTypeImpl : ModelObject, global::MetaDslx.Soal.PrimitiveType
    {
        static PrimitiveTypeImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.PrimitiveType; }
        }
    
        public PrimitiveTypeImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.PrimitiveType_PrimitiveType(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    [Scope]
    public interface Enum : global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    {
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.EnumLiteral> EnumLiterals { get; }
    
    }
    
    internal class EnumImpl : ModelObject, global::MetaDslx.Soal.Enum
    {
        static EnumImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Enum; }
        }
    
        public EnumImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Enum.EnumLiteralsProperty, new global::MetaDslx.Core.ModelList<EnumLiteral>(this, global::MetaDslx.Soal.SoalDescriptor.Enum.EnumLiteralsProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Enum_Enum(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.EnumLiteral> global::MetaDslx.Soal.Enum.EnumLiterals
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Enum.EnumLiteralsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.EnumLiteral>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.EnumLiteral>);
            }
        }
    }
    
    
    public interface EnumLiteral : global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    {
        global::MetaDslx.Soal.Enum Enum { get; set; }
    
    }
    
    internal class EnumLiteralImpl : ModelObject, global::MetaDslx.Soal.EnumLiteral
    {
        static EnumLiteralImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.EnumLiteral; }
        }
    
        public EnumLiteralImpl() 
        {
            this.MLazySet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, new Lazy<object>(() => ((EnumLiteral)this).Enum));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.EnumLiteral_EnumLiteral(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.TypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
        }
        
        global::MetaDslx.Soal.Enum global::MetaDslx.Soal.EnumLiteral.Enum
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty); 
                if (result != null) return (global::MetaDslx.Soal.Enum)result;
                else return default(global::MetaDslx.Soal.Enum);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty, value); }
        }
    }
    
    
    public interface StructuredType : global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    {
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property> Properties { get; }
    
    }
    
    internal class StructuredTypeImpl : ModelObject, global::MetaDslx.Soal.StructuredType
    {
        static StructuredTypeImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.StructuredType; }
        }
    
        public StructuredTypeImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, new global::MetaDslx.Core.ModelList<Property>(this, global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.StructuredType_StructuredType(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property> global::MetaDslx.Soal.StructuredType.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>);
            }
        }
    }
    
    
    public interface Property : global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    {
        global::MetaDslx.Soal.StructuredType Parent { get; set; }
    
    }
    
    internal class PropertyImpl : ModelObject, global::MetaDslx.Soal.Property
    {
        static PropertyImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Property; }
        }
    
        public PropertyImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Property_Property(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.TypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
        }
        
        global::MetaDslx.Soal.StructuredType global::MetaDslx.Soal.Property.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty); 
                if (result != null) return (global::MetaDslx.Soal.StructuredType)result;
                else return default(global::MetaDslx.Soal.StructuredType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty, value); }
        }
    }
    
    
    public interface Struct : global::MetaDslx.Soal.StructuredType
    {
        global::MetaDslx.Soal.Struct BaseType { get; set; }
    
    }
    
    internal class StructImpl : ModelObject, global::MetaDslx.Soal.Struct
    {
        static StructImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Struct; }
        }
    
        public StructImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, new global::MetaDslx.Core.ModelList<Property>(this, global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Struct_Struct(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property> global::MetaDslx.Soal.StructuredType.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>);
            }
        }
        
        global::MetaDslx.Soal.Struct global::MetaDslx.Soal.Struct.BaseType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.Struct)result;
                else return default(global::MetaDslx.Soal.Struct);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty, value); }
        }
    }
    
    
    public interface Exception : global::MetaDslx.Soal.StructuredType
    {
        global::MetaDslx.Soal.Exception BaseType { get; set; }
    
    }
    
    internal class ExceptionImpl : ModelObject, global::MetaDslx.Soal.Exception
    {
        static ExceptionImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Exception; }
        }
    
        public ExceptionImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, new global::MetaDslx.Core.ModelList<Property>(this, global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Exception_Exception(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property> global::MetaDslx.Soal.StructuredType.Properties
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Property>);
            }
        }
        
        global::MetaDslx.Soal.Exception global::MetaDslx.Soal.Exception.BaseType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.Exception)result;
                else return default(global::MetaDslx.Soal.Exception);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty, value); }
        }
    }
    
    [Scope]
    public interface Interface : global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    {
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Operation> Operations { get; }
    
    }
    
    internal class InterfaceImpl : ModelObject, global::MetaDslx.Soal.Interface
    {
        static InterfaceImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Interface; }
        }
    
        public InterfaceImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty, new global::MetaDslx.Core.ModelList<Operation>(this, global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Interface_Interface(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Operation> global::MetaDslx.Soal.Interface.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Operation>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Operation>);
            }
        }
    }
    
    
    public interface Operation : global::MetaDslx.Soal.NamedElement
    {
        global::MetaDslx.Soal.Interface Parent { get; set; }
        bool IsOneway { get; set; }
        global::MetaDslx.Soal.SoalType ReturnType { get; set; }
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Parameter> Parameters { get; }
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Exception> Exceptions { get; }
    
    }
    
    internal class OperationImpl : ModelObject, global::MetaDslx.Soal.Operation
    {
        static OperationImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Operation; }
        }
    
        public OperationImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Operation.ParametersProperty, new global::MetaDslx.Core.ModelList<Parameter>(this, global::MetaDslx.Soal.SoalDescriptor.Operation.ParametersProperty));
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Operation.ExceptionsProperty, new global::MetaDslx.Core.ModelList<Exception>(this, global::MetaDslx.Soal.SoalDescriptor.Operation.ExceptionsProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Operation_Operation(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Interface global::MetaDslx.Soal.Operation.Parent
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty); 
                if (result != null) return (global::MetaDslx.Soal.Interface)result;
                else return default(global::MetaDslx.Soal.Interface);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty, value); }
        }
        
        bool global::MetaDslx.Soal.Operation.IsOneway
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty, value); }
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.Operation.ReturnType
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Parameter> global::MetaDslx.Soal.Operation.Parameters
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Operation.ParametersProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Parameter>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Parameter>);
            }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.Exception> global::MetaDslx.Soal.Operation.Exceptions
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Operation.ExceptionsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.Exception>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.Exception>);
            }
        }
    }
    
    
    public interface Parameter : global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    {
        global::MetaDslx.Soal.Operation Operation { get; set; }
    
    }
    
    internal class ParameterImpl : ModelObject, global::MetaDslx.Soal.Parameter
    {
        static ParameterImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Parameter; }
        }
    
        public ParameterImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Parameter_Parameter(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.SoalType global::MetaDslx.Soal.TypedElement.Type
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoalType)result;
                else return default(global::MetaDslx.Soal.SoalType);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
        }
        
        global::MetaDslx.Soal.Operation global::MetaDslx.Soal.Parameter.Operation
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty); 
                if (result != null) return (global::MetaDslx.Soal.Operation)result;
                else return default(global::MetaDslx.Soal.Operation);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty, value); }
        }
    }
    
    
    public interface Binding : global::MetaDslx.Soal.Declaration
    {
        global::MetaDslx.Soal.TransportBindingElement Transport { get; set; }
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.EncodingBindingElement> Encodings { get; }
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.ProtocolBindingElement> Protocols { get; }
    
    }
    
    internal class BindingImpl : ModelObject, global::MetaDslx.Soal.Binding
    {
        static BindingImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Binding; }
        }
    
        public BindingImpl() 
        {
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Binding.EncodingsProperty, new global::MetaDslx.Core.ModelList<EncodingBindingElement>(this, global::MetaDslx.Soal.SoalDescriptor.Binding.EncodingsProperty));
            this.MSet(global::MetaDslx.Soal.SoalDescriptor.Binding.ProtocolsProperty, new global::MetaDslx.Core.ModelList<ProtocolBindingElement>(this, global::MetaDslx.Soal.SoalDescriptor.Binding.ProtocolsProperty));
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Binding_Binding(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::MetaDslx.Soal.TransportBindingElement global::MetaDslx.Soal.Binding.Transport
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty); 
                if (result != null) return (global::MetaDslx.Soal.TransportBindingElement)result;
                else return default(global::MetaDslx.Soal.TransportBindingElement);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.EncodingBindingElement> global::MetaDslx.Soal.Binding.Encodings
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Binding.EncodingsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.EncodingBindingElement>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.EncodingBindingElement>);
            }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Soal.ProtocolBindingElement> global::MetaDslx.Soal.Binding.Protocols
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Binding.ProtocolsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Soal.ProtocolBindingElement>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Soal.ProtocolBindingElement>);
            }
        }
    }
    
    
    public interface Endpoint : global::MetaDslx.Soal.Declaration
    {
        global::MetaDslx.Soal.Interface Interface { get; set; }
        global::MetaDslx.Soal.Binding Binding { get; set; }
        string Address { get; set; }
    
    }
    
    internal class EndpointImpl : ModelObject, global::MetaDslx.Soal.Endpoint
    {
        static EndpointImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.Endpoint; }
        }
    
        public EndpointImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.Endpoint_Endpoint(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.Namespace global::MetaDslx.Soal.Declaration.Namespace
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Namespace)result;
                else return default(global::MetaDslx.Soal.Namespace);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
        }
        
        global::MetaDslx.Soal.Interface global::MetaDslx.Soal.Endpoint.Interface
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty); 
                if (result != null) return (global::MetaDslx.Soal.Interface)result;
                else return default(global::MetaDslx.Soal.Interface);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty, value); }
        }
        
        global::MetaDslx.Soal.Binding global::MetaDslx.Soal.Endpoint.Binding
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty); 
                if (result != null) return (global::MetaDslx.Soal.Binding)result;
                else return default(global::MetaDslx.Soal.Binding);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty, value); }
        }
        
        string global::MetaDslx.Soal.Endpoint.Address
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty, value); }
        }
    }
    
    
    public interface BindingElement : global::MetaDslx.Soal.NamedElement
    {
    
    }
    
    internal class BindingElementImpl : ModelObject, global::MetaDslx.Soal.BindingElement
    {
        static BindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.BindingElement; }
        }
    
        public BindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.BindingElement_BindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface TransportBindingElement : global::MetaDslx.Soal.BindingElement
    {
    
    }
    
    internal class TransportBindingElementImpl : ModelObject, global::MetaDslx.Soal.TransportBindingElement
    {
        static TransportBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.TransportBindingElement; }
        }
    
        public TransportBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.TransportBindingElement_TransportBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface EncodingBindingElement : global::MetaDslx.Soal.BindingElement
    {
    
    }
    
    internal class EncodingBindingElementImpl : ModelObject, global::MetaDslx.Soal.EncodingBindingElement
    {
        static EncodingBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.EncodingBindingElement; }
        }
    
        public EncodingBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.EncodingBindingElement_EncodingBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface ProtocolBindingElement : global::MetaDslx.Soal.BindingElement
    {
    
    }
    
    internal class ProtocolBindingElementImpl : ModelObject, global::MetaDslx.Soal.ProtocolBindingElement
    {
        static ProtocolBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.ProtocolBindingElement; }
        }
    
        public ProtocolBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.ProtocolBindingElement_ProtocolBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface HttpTransportBindingElement : global::MetaDslx.Soal.TransportBindingElement
    {
    
    }
    
    internal class HttpTransportBindingElementImpl : ModelObject, global::MetaDslx.Soal.HttpTransportBindingElement
    {
        static HttpTransportBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.HttpTransportBindingElement; }
        }
    
        public HttpTransportBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.HttpTransportBindingElement_HttpTransportBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface RestTransportBindingElement : global::MetaDslx.Soal.TransportBindingElement
    {
    
    }
    
    internal class RestTransportBindingElementImpl : ModelObject, global::MetaDslx.Soal.RestTransportBindingElement
    {
        static RestTransportBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.RestTransportBindingElement; }
        }
    
        public RestTransportBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.RestTransportBindingElement_RestTransportBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface WebSocketTransportBindingElement : global::MetaDslx.Soal.TransportBindingElement
    {
    
    }
    
    internal class WebSocketTransportBindingElementImpl : ModelObject, global::MetaDslx.Soal.WebSocketTransportBindingElement
    {
        static WebSocketTransportBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.WebSocketTransportBindingElement; }
        }
    
        public WebSocketTransportBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.WebSocketTransportBindingElement_WebSocketTransportBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface SoapEncodingBindingElement : global::MetaDslx.Soal.EncodingBindingElement
    {
        global::MetaDslx.Soal.SoapVersion Version { get; set; }
        bool MtomEnabled { get; set; }
    
    }
    
    internal class SoapEncodingBindingElementImpl : ModelObject, global::MetaDslx.Soal.SoapEncodingBindingElement
    {
        static SoapEncodingBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement; }
        }
    
        public SoapEncodingBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.SoapEncodingBindingElement_SoapEncodingBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
        
        global::MetaDslx.Soal.SoapVersion global::MetaDslx.Soal.SoapEncodingBindingElement.Version
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty); 
                if (result != null) return (global::MetaDslx.Soal.SoapVersion)result;
                else return default(global::MetaDslx.Soal.SoapVersion);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty, value); }
        }
        
        bool global::MetaDslx.Soal.SoapEncodingBindingElement.MtomEnabled
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty); 
                if (result != null) return (bool)result;
                else return default(bool);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty, value); }
        }
    }
    
    
    public interface XmlEncodingBindingElement : global::MetaDslx.Soal.EncodingBindingElement
    {
    
    }
    
    internal class XmlEncodingBindingElementImpl : ModelObject, global::MetaDslx.Soal.XmlEncodingBindingElement
    {
        static XmlEncodingBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.XmlEncodingBindingElement; }
        }
    
        public XmlEncodingBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.XmlEncodingBindingElement_XmlEncodingBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface JsonEncodingBindingElement : global::MetaDslx.Soal.EncodingBindingElement
    {
    
    }
    
    internal class JsonEncodingBindingElementImpl : ModelObject, global::MetaDslx.Soal.JsonEncodingBindingElement
    {
        static JsonEncodingBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.JsonEncodingBindingElement; }
        }
    
        public JsonEncodingBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.JsonEncodingBindingElement_JsonEncodingBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface WsProtocolBindingElement : global::MetaDslx.Soal.ProtocolBindingElement
    {
    
    }
    
    internal class WsProtocolBindingElementImpl : ModelObject, global::MetaDslx.Soal.WsProtocolBindingElement
    {
        static WsProtocolBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.WsProtocolBindingElement; }
        }
    
        public WsProtocolBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.WsProtocolBindingElement_WsProtocolBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    
    public interface WsAddressingBindingElement : global::MetaDslx.Soal.WsProtocolBindingElement
    {
    
    }
    
    internal class WsAddressingBindingElementImpl : ModelObject, global::MetaDslx.Soal.WsAddressingBindingElement
    {
        static WsAddressingBindingElementImpl()
        {
            global::MetaDslx.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Soal.SoalInstance.WsAddressingBindingElement; }
        }
    
        public WsAddressingBindingElementImpl() 
        {
            global::MetaDslx.Soal.SoalImplementationProvider.Implementation.WsAddressingBindingElement_WsAddressingBindingElement(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Soal.NamedElement.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class SoalFactory : ModelFactory
    {
        private static SoalFactory instance = new SoalFactory();
    
    	private SoalFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static SoalFactory Instance
        {
            get { return SoalFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of Namespace.
        /// </summary>
        public Namespace CreateNamespace(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Namespace result = new global::MetaDslx.Soal.NamespaceImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of ArrayType.
        /// </summary>
        public ArrayType CreateArrayType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		ArrayType result = new global::MetaDslx.Soal.ArrayTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of NullableType.
        /// </summary>
        public NullableType CreateNullableType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		NullableType result = new global::MetaDslx.Soal.NullableTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of PrimitiveType.
        /// </summary>
        public PrimitiveType CreatePrimitiveType(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		PrimitiveType result = new global::MetaDslx.Soal.PrimitiveTypeImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Enum.
        /// </summary>
        public Enum CreateEnum(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Enum result = new global::MetaDslx.Soal.EnumImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of EnumLiteral.
        /// </summary>
        public EnumLiteral CreateEnumLiteral(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		EnumLiteral result = new global::MetaDslx.Soal.EnumLiteralImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Property.
        /// </summary>
        public Property CreateProperty(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Property result = new global::MetaDslx.Soal.PropertyImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Struct.
        /// </summary>
        public Struct CreateStruct(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Struct result = new global::MetaDslx.Soal.StructImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Exception.
        /// </summary>
        public Exception CreateException(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Exception result = new global::MetaDslx.Soal.ExceptionImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Interface.
        /// </summary>
        public Interface CreateInterface(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Interface result = new global::MetaDslx.Soal.InterfaceImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Operation.
        /// </summary>
        public Operation CreateOperation(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Operation result = new global::MetaDslx.Soal.OperationImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Parameter.
        /// </summary>
        public Parameter CreateParameter(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Parameter result = new global::MetaDslx.Soal.ParameterImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Binding.
        /// </summary>
        public Binding CreateBinding(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Binding result = new global::MetaDslx.Soal.BindingImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Endpoint.
        /// </summary>
        public Endpoint CreateEndpoint(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Endpoint result = new global::MetaDslx.Soal.EndpointImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of HttpTransportBindingElement.
        /// </summary>
        public HttpTransportBindingElement CreateHttpTransportBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		HttpTransportBindingElement result = new global::MetaDslx.Soal.HttpTransportBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of RestTransportBindingElement.
        /// </summary>
        public RestTransportBindingElement CreateRestTransportBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		RestTransportBindingElement result = new global::MetaDslx.Soal.RestTransportBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of WebSocketTransportBindingElement.
        /// </summary>
        public WebSocketTransportBindingElement CreateWebSocketTransportBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		WebSocketTransportBindingElement result = new global::MetaDslx.Soal.WebSocketTransportBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of SoapEncodingBindingElement.
        /// </summary>
        public SoapEncodingBindingElement CreateSoapEncodingBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		SoapEncodingBindingElement result = new global::MetaDslx.Soal.SoapEncodingBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of XmlEncodingBindingElement.
        /// </summary>
        public XmlEncodingBindingElement CreateXmlEncodingBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		XmlEncodingBindingElement result = new global::MetaDslx.Soal.XmlEncodingBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of JsonEncodingBindingElement.
        /// </summary>
        public JsonEncodingBindingElement CreateJsonEncodingBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		JsonEncodingBindingElement result = new global::MetaDslx.Soal.JsonEncodingBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of WsAddressingBindingElement.
        /// </summary>
        public WsAddressingBindingElement CreateWsAddressingBindingElement(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		WsAddressingBindingElement result = new global::MetaDslx.Soal.WsAddressingBindingElementImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    }
    
    internal static class SoalImplementationProvider
    {
        // If there is a compile error at this line, create a new class called SoalImplementation
    	// which is a subclass of SoalImplementationBase:
        private static SoalImplementation implementation = new SoalImplementation();
    
        public static SoalImplementation Implementation
        {
            get { return SoalImplementationProvider.implementation; }
        }
    }
    
    public static class SoapVersionExtensions
    {
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in SoalImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class SoalImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: NamedElement()
        /// </summary>
        public virtual void NamedElement_NamedElement(NamedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: TypedElement()
        /// </summary>
        public virtual void TypedElement_TypedElement(TypedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: SoalType()
        /// </summary>
        public virtual void SoalType_SoalType(SoalType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: Namespace()
    	/// Direct superclasses: global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void Namespace_Namespace(Namespace @this)
        {
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Declaration()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement
        /// </summary>
        public virtual void Declaration_Declaration(Declaration @this)
        {
            this.NamedElement_NamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: ArrayType()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType
    	/// All superclasses: global::MetaDslx.Soal.SoalType
        /// </summary>
        public virtual void ArrayType_ArrayType(ArrayType @this)
        {
            this.SoalType_SoalType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: NullableType()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType
    	/// All superclasses: global::MetaDslx.Soal.SoalType
        /// </summary>
        public virtual void NullableType_NullableType(NullableType @this)
        {
            this.SoalType_SoalType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: PrimitiveType()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement
        /// </summary>
        public virtual void PrimitiveType_PrimitiveType(PrimitiveType @this)
        {
            this.SoalType_SoalType(@this);
            this.NamedElement_NamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Enum()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void Enum_Enum(Enum @this)
        {
            this.SoalType_SoalType(@this);
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: EnumLiteral()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
        /// </summary>
        public virtual void EnumLiteral_EnumLiteral(EnumLiteral @this)
        {
            this.NamedElement_NamedElement(@this);
            this.TypedElement_TypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: StructuredType()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void StructuredType_StructuredType(StructuredType @this)
        {
            this.SoalType_SoalType(@this);
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Property()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
        /// </summary>
        public virtual void Property_Property(Property @this)
        {
            this.NamedElement_NamedElement(@this);
            this.TypedElement_TypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Struct()
    	/// Direct superclasses: global::MetaDslx.Soal.StructuredType
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration, global::MetaDslx.Soal.StructuredType
        /// </summary>
        public virtual void Struct_Struct(Struct @this)
        {
            this.StructuredType_StructuredType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Exception()
    	/// Direct superclasses: global::MetaDslx.Soal.StructuredType
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration, global::MetaDslx.Soal.StructuredType
        /// </summary>
        public virtual void Exception_Exception(Exception @this)
        {
            this.StructuredType_StructuredType(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Interface()
    	/// Direct superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.SoalType, global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void Interface_Interface(Interface @this)
        {
            this.SoalType_SoalType(@this);
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Operation()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement
        /// </summary>
        public virtual void Operation_Operation(Operation @this)
        {
            this.NamedElement_NamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Parameter()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.TypedElement
        /// </summary>
        public virtual void Parameter_Parameter(Parameter @this)
        {
            this.NamedElement_NamedElement(@this);
            this.TypedElement_TypedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Binding()
    	/// Direct superclasses: global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void Binding_Binding(Binding @this)
        {
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: Endpoint()
    	/// Direct superclasses: global::MetaDslx.Soal.Declaration
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.Declaration
        /// </summary>
        public virtual void Endpoint_Endpoint(Endpoint @this)
        {
            this.Declaration_Declaration(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: BindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.NamedElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement
        /// </summary>
        public virtual void BindingElement_BindingElement(BindingElement @this)
        {
            this.NamedElement_NamedElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: TransportBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.BindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement
        /// </summary>
        public virtual void TransportBindingElement_TransportBindingElement(TransportBindingElement @this)
        {
            this.BindingElement_BindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: EncodingBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.BindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement
        /// </summary>
        public virtual void EncodingBindingElement_EncodingBindingElement(EncodingBindingElement @this)
        {
            this.BindingElement_BindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: ProtocolBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.BindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement
        /// </summary>
        public virtual void ProtocolBindingElement_ProtocolBindingElement(ProtocolBindingElement @this)
        {
            this.BindingElement_BindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: HttpTransportBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.TransportBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.TransportBindingElement
        /// </summary>
        public virtual void HttpTransportBindingElement_HttpTransportBindingElement(HttpTransportBindingElement @this)
        {
            this.TransportBindingElement_TransportBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: RestTransportBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.TransportBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.TransportBindingElement
        /// </summary>
        public virtual void RestTransportBindingElement_RestTransportBindingElement(RestTransportBindingElement @this)
        {
            this.TransportBindingElement_TransportBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: WebSocketTransportBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.TransportBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.TransportBindingElement
        /// </summary>
        public virtual void WebSocketTransportBindingElement_WebSocketTransportBindingElement(WebSocketTransportBindingElement @this)
        {
            this.TransportBindingElement_TransportBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: SoapEncodingBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.EncodingBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.EncodingBindingElement
        /// </summary>
        public virtual void SoapEncodingBindingElement_SoapEncodingBindingElement(SoapEncodingBindingElement @this)
        {
            this.EncodingBindingElement_EncodingBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: XmlEncodingBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.EncodingBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.EncodingBindingElement
        /// </summary>
        public virtual void XmlEncodingBindingElement_XmlEncodingBindingElement(XmlEncodingBindingElement @this)
        {
            this.EncodingBindingElement_EncodingBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: JsonEncodingBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.EncodingBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.EncodingBindingElement
        /// </summary>
        public virtual void JsonEncodingBindingElement_JsonEncodingBindingElement(JsonEncodingBindingElement @this)
        {
            this.EncodingBindingElement_EncodingBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: WsProtocolBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.ProtocolBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.ProtocolBindingElement
        /// </summary>
        public virtual void WsProtocolBindingElement_WsProtocolBindingElement(WsProtocolBindingElement @this)
        {
            this.ProtocolBindingElement_ProtocolBindingElement(@this);
        }
    
        /// <summary>
    	/// Implements the constructor: WsAddressingBindingElement()
    	/// Direct superclasses: global::MetaDslx.Soal.WsProtocolBindingElement
    	/// All superclasses: global::MetaDslx.Soal.NamedElement, global::MetaDslx.Soal.BindingElement, global::MetaDslx.Soal.ProtocolBindingElement, global::MetaDslx.Soal.WsProtocolBindingElement
        /// </summary>
        public virtual void WsAddressingBindingElement_WsAddressingBindingElement(WsAddressingBindingElement @this)
        {
            this.WsProtocolBindingElement_WsProtocolBindingElement(@this);
        }
    
    
    }
    
}
