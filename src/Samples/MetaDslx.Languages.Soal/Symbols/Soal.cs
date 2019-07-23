using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Languages.Soal.Symbols
{
	using global::MetaDslx.Languages.Soal.Symbols.Internal;

	public class SoalInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return SoalInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaModel MetaModel;
		public static readonly global::MetaDslx.Modeling.ImmutableModel Model;
	
		public static readonly PrimitiveType Object;
		public static readonly PrimitiveType String;
		public static readonly PrimitiveType Int;
		public static readonly PrimitiveType Long;
		public static readonly PrimitiveType Float;
		public static readonly PrimitiveType Double;
		public static readonly PrimitiveType Byte;
		public static readonly PrimitiveType Bool;
		public static readonly PrimitiveType Void;
		public static readonly PrimitiveType Date;
		public static readonly PrimitiveType Time;
		public static readonly PrimitiveType DateTime;
		public static readonly PrimitiveType TimeSpan;
	
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass AnnotatedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty AnnotatedElement_Annotations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Annotation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Annotation_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass AnnotationProperty;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty AnnotationProperty_Value;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass DocumentedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty DocumentedElement_Documentation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass NamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty NamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass TypedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty TypedElement_Type;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass SoalType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass NamedType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Declaration;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Declaration_Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Declaration_FullName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Uri;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Prefix;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ArrayType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty ArrayType_InnerType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass NullableType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty NullableType_InnerType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass NonNullableType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty NonNullableType_InnerType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass PrimitiveType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty PrimitiveType_Nullable;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Enum;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Enum_BaseType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Enum_EnumLiterals;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass EnumLiteral;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty EnumLiteral_Enum;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Property;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Struct;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Struct_BaseType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Struct_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Interface;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Interface_Operations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Database;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Database_Entities;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Operation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Operation_Action;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Operation_Parameters;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Operation_Result;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Operation_Exceptions;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass InputParameter;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass OutputParameter;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty OutputParameter_IsOneway;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Component;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_BaseComponent;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_IsAbstract;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_Ports;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_Services;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_References;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_Implementation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Component_Language;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Composite;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Composite_Components;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Composite_Wires;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Assembly;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Wire;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Wire_Source;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Wire_Target;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Port;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Component;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Interface;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Binding;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Service;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Reference;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Implementation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ProgrammingLanguage;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Deployment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Deployment_Environments;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Deployment_Wires;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Environment;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Environment_Runtime;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Environment_Databases;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Environment_Assemblies;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Runtime;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Binding;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Binding_Transport;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Binding_Encodings;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Binding_Protocols;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Endpoint;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Endpoint_Interface;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Endpoint_Binding;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Endpoint_Address;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass BindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass TransportBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass EncodingBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass ProtocolBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass HttpTransportBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty HttpTransportBindingElement_Ssl;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty HttpTransportBindingElement_ClientAuthentication;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass RestTransportBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass WebSocketTransportBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass SoapEncodingBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SoapEncodingBindingElement_Style;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SoapEncodingBindingElement_Version;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty SoapEncodingBindingElement_Mtom;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass XmlEncodingBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass JsonEncodingBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass WsProtocolBindingElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass WsAddressingBindingElement;
	
		static SoalInstance()
		{
			SoalBuilderInstance.instance.Create();
			SoalBuilderInstance.instance.EvaluateLazyValues();
			MetaModel = SoalBuilderInstance.instance.MetaModel.ToImmutable();
			Model = SoalBuilderInstance.instance.Model.ToImmutable();
	
			Object = SoalBuilderInstance.instance.Object.ToImmutable(Model);
			String = SoalBuilderInstance.instance.String.ToImmutable(Model);
			Int = SoalBuilderInstance.instance.Int.ToImmutable(Model);
			Long = SoalBuilderInstance.instance.Long.ToImmutable(Model);
			Float = SoalBuilderInstance.instance.Float.ToImmutable(Model);
			Double = SoalBuilderInstance.instance.Double.ToImmutable(Model);
			Byte = SoalBuilderInstance.instance.Byte.ToImmutable(Model);
			Bool = SoalBuilderInstance.instance.Bool.ToImmutable(Model);
			Void = SoalBuilderInstance.instance.Void.ToImmutable(Model);
			Date = SoalBuilderInstance.instance.Date.ToImmutable(Model);
			Time = SoalBuilderInstance.instance.Time.ToImmutable(Model);
			DateTime = SoalBuilderInstance.instance.DateTime.ToImmutable(Model);
			TimeSpan = SoalBuilderInstance.instance.TimeSpan.ToImmutable(Model);
	
			AnnotatedElement = SoalBuilderInstance.instance.AnnotatedElement.ToImmutable(Model);
			AnnotatedElement_Annotations = SoalBuilderInstance.instance.AnnotatedElement_Annotations.ToImmutable(Model);
			Annotation = SoalBuilderInstance.instance.Annotation.ToImmutable(Model);
			Annotation_Properties = SoalBuilderInstance.instance.Annotation_Properties.ToImmutable(Model);
			AnnotationProperty = SoalBuilderInstance.instance.AnnotationProperty.ToImmutable(Model);
			AnnotationProperty_Value = SoalBuilderInstance.instance.AnnotationProperty_Value.ToImmutable(Model);
			DocumentedElement = SoalBuilderInstance.instance.DocumentedElement.ToImmutable(Model);
			DocumentedElement_Documentation = SoalBuilderInstance.instance.DocumentedElement_Documentation.ToImmutable(Model);
			NamedElement = SoalBuilderInstance.instance.NamedElement.ToImmutable(Model);
			NamedElement_Name = SoalBuilderInstance.instance.NamedElement_Name.ToImmutable(Model);
			TypedElement = SoalBuilderInstance.instance.TypedElement.ToImmutable(Model);
			TypedElement_Type = SoalBuilderInstance.instance.TypedElement_Type.ToImmutable(Model);
			SoalType = SoalBuilderInstance.instance.SoalType.ToImmutable(Model);
			NamedType = SoalBuilderInstance.instance.NamedType.ToImmutable(Model);
			Declaration = SoalBuilderInstance.instance.Declaration.ToImmutable(Model);
			Declaration_Namespace = SoalBuilderInstance.instance.Declaration_Namespace.ToImmutable(Model);
			Declaration_FullName = SoalBuilderInstance.instance.Declaration_FullName.ToImmutable(Model);
			Namespace = SoalBuilderInstance.instance.Namespace.ToImmutable(Model);
			Namespace_Uri = SoalBuilderInstance.instance.Namespace_Uri.ToImmutable(Model);
			Namespace_Prefix = SoalBuilderInstance.instance.Namespace_Prefix.ToImmutable(Model);
			Namespace_Declarations = SoalBuilderInstance.instance.Namespace_Declarations.ToImmutable(Model);
			ArrayType = SoalBuilderInstance.instance.ArrayType.ToImmutable(Model);
			ArrayType_InnerType = SoalBuilderInstance.instance.ArrayType_InnerType.ToImmutable(Model);
			NullableType = SoalBuilderInstance.instance.NullableType.ToImmutable(Model);
			NullableType_InnerType = SoalBuilderInstance.instance.NullableType_InnerType.ToImmutable(Model);
			NonNullableType = SoalBuilderInstance.instance.NonNullableType.ToImmutable(Model);
			NonNullableType_InnerType = SoalBuilderInstance.instance.NonNullableType_InnerType.ToImmutable(Model);
			PrimitiveType = SoalBuilderInstance.instance.PrimitiveType.ToImmutable(Model);
			PrimitiveType_Nullable = SoalBuilderInstance.instance.PrimitiveType_Nullable.ToImmutable(Model);
			Enum = SoalBuilderInstance.instance.Enum.ToImmutable(Model);
			Enum_BaseType = SoalBuilderInstance.instance.Enum_BaseType.ToImmutable(Model);
			Enum_EnumLiterals = SoalBuilderInstance.instance.Enum_EnumLiterals.ToImmutable(Model);
			EnumLiteral = SoalBuilderInstance.instance.EnumLiteral.ToImmutable(Model);
			EnumLiteral_Enum = SoalBuilderInstance.instance.EnumLiteral_Enum.ToImmutable(Model);
			Property = SoalBuilderInstance.instance.Property.ToImmutable(Model);
			Struct = SoalBuilderInstance.instance.Struct.ToImmutable(Model);
			Struct_BaseType = SoalBuilderInstance.instance.Struct_BaseType.ToImmutable(Model);
			Struct_Properties = SoalBuilderInstance.instance.Struct_Properties.ToImmutable(Model);
			Interface = SoalBuilderInstance.instance.Interface.ToImmutable(Model);
			Interface_Operations = SoalBuilderInstance.instance.Interface_Operations.ToImmutable(Model);
			Database = SoalBuilderInstance.instance.Database.ToImmutable(Model);
			Database_Entities = SoalBuilderInstance.instance.Database_Entities.ToImmutable(Model);
			Operation = SoalBuilderInstance.instance.Operation.ToImmutable(Model);
			Operation_Action = SoalBuilderInstance.instance.Operation_Action.ToImmutable(Model);
			Operation_Parameters = SoalBuilderInstance.instance.Operation_Parameters.ToImmutable(Model);
			Operation_Result = SoalBuilderInstance.instance.Operation_Result.ToImmutable(Model);
			Operation_Exceptions = SoalBuilderInstance.instance.Operation_Exceptions.ToImmutable(Model);
			InputParameter = SoalBuilderInstance.instance.InputParameter.ToImmutable(Model);
			OutputParameter = SoalBuilderInstance.instance.OutputParameter.ToImmutable(Model);
			OutputParameter_IsOneway = SoalBuilderInstance.instance.OutputParameter_IsOneway.ToImmutable(Model);
			Component = SoalBuilderInstance.instance.Component.ToImmutable(Model);
			Component_BaseComponent = SoalBuilderInstance.instance.Component_BaseComponent.ToImmutable(Model);
			Component_IsAbstract = SoalBuilderInstance.instance.Component_IsAbstract.ToImmutable(Model);
			Component_Ports = SoalBuilderInstance.instance.Component_Ports.ToImmutable(Model);
			Component_Services = SoalBuilderInstance.instance.Component_Services.ToImmutable(Model);
			Component_References = SoalBuilderInstance.instance.Component_References.ToImmutable(Model);
			Component_Properties = SoalBuilderInstance.instance.Component_Properties.ToImmutable(Model);
			Component_Implementation = SoalBuilderInstance.instance.Component_Implementation.ToImmutable(Model);
			Component_Language = SoalBuilderInstance.instance.Component_Language.ToImmutable(Model);
			Composite = SoalBuilderInstance.instance.Composite.ToImmutable(Model);
			Composite_Components = SoalBuilderInstance.instance.Composite_Components.ToImmutable(Model);
			Composite_Wires = SoalBuilderInstance.instance.Composite_Wires.ToImmutable(Model);
			Assembly = SoalBuilderInstance.instance.Assembly.ToImmutable(Model);
			Wire = SoalBuilderInstance.instance.Wire.ToImmutable(Model);
			Wire_Source = SoalBuilderInstance.instance.Wire_Source.ToImmutable(Model);
			Wire_Target = SoalBuilderInstance.instance.Wire_Target.ToImmutable(Model);
			Port = SoalBuilderInstance.instance.Port.ToImmutable(Model);
			Port_Component = SoalBuilderInstance.instance.Port_Component.ToImmutable(Model);
			Port_Interface = SoalBuilderInstance.instance.Port_Interface.ToImmutable(Model);
			Port_Binding = SoalBuilderInstance.instance.Port_Binding.ToImmutable(Model);
			Service = SoalBuilderInstance.instance.Service.ToImmutable(Model);
			Reference = SoalBuilderInstance.instance.Reference.ToImmutable(Model);
			Implementation = SoalBuilderInstance.instance.Implementation.ToImmutable(Model);
			ProgrammingLanguage = SoalBuilderInstance.instance.ProgrammingLanguage.ToImmutable(Model);
			Deployment = SoalBuilderInstance.instance.Deployment.ToImmutable(Model);
			Deployment_Environments = SoalBuilderInstance.instance.Deployment_Environments.ToImmutable(Model);
			Deployment_Wires = SoalBuilderInstance.instance.Deployment_Wires.ToImmutable(Model);
			Environment = SoalBuilderInstance.instance.Environment.ToImmutable(Model);
			Environment_Runtime = SoalBuilderInstance.instance.Environment_Runtime.ToImmutable(Model);
			Environment_Databases = SoalBuilderInstance.instance.Environment_Databases.ToImmutable(Model);
			Environment_Assemblies = SoalBuilderInstance.instance.Environment_Assemblies.ToImmutable(Model);
			Runtime = SoalBuilderInstance.instance.Runtime.ToImmutable(Model);
			Binding = SoalBuilderInstance.instance.Binding.ToImmutable(Model);
			Binding_Transport = SoalBuilderInstance.instance.Binding_Transport.ToImmutable(Model);
			Binding_Encodings = SoalBuilderInstance.instance.Binding_Encodings.ToImmutable(Model);
			Binding_Protocols = SoalBuilderInstance.instance.Binding_Protocols.ToImmutable(Model);
			Endpoint = SoalBuilderInstance.instance.Endpoint.ToImmutable(Model);
			Endpoint_Interface = SoalBuilderInstance.instance.Endpoint_Interface.ToImmutable(Model);
			Endpoint_Binding = SoalBuilderInstance.instance.Endpoint_Binding.ToImmutable(Model);
			Endpoint_Address = SoalBuilderInstance.instance.Endpoint_Address.ToImmutable(Model);
			BindingElement = SoalBuilderInstance.instance.BindingElement.ToImmutable(Model);
			TransportBindingElement = SoalBuilderInstance.instance.TransportBindingElement.ToImmutable(Model);
			EncodingBindingElement = SoalBuilderInstance.instance.EncodingBindingElement.ToImmutable(Model);
			ProtocolBindingElement = SoalBuilderInstance.instance.ProtocolBindingElement.ToImmutable(Model);
			HttpTransportBindingElement = SoalBuilderInstance.instance.HttpTransportBindingElement.ToImmutable(Model);
			HttpTransportBindingElement_Ssl = SoalBuilderInstance.instance.HttpTransportBindingElement_Ssl.ToImmutable(Model);
			HttpTransportBindingElement_ClientAuthentication = SoalBuilderInstance.instance.HttpTransportBindingElement_ClientAuthentication.ToImmutable(Model);
			RestTransportBindingElement = SoalBuilderInstance.instance.RestTransportBindingElement.ToImmutable(Model);
			WebSocketTransportBindingElement = SoalBuilderInstance.instance.WebSocketTransportBindingElement.ToImmutable(Model);
			SoapEncodingBindingElement = SoalBuilderInstance.instance.SoapEncodingBindingElement.ToImmutable(Model);
			SoapEncodingBindingElement_Style = SoalBuilderInstance.instance.SoapEncodingBindingElement_Style.ToImmutable(Model);
			SoapEncodingBindingElement_Version = SoalBuilderInstance.instance.SoapEncodingBindingElement_Version.ToImmutable(Model);
			SoapEncodingBindingElement_Mtom = SoalBuilderInstance.instance.SoapEncodingBindingElement_Mtom.ToImmutable(Model);
			XmlEncodingBindingElement = SoalBuilderInstance.instance.XmlEncodingBindingElement.ToImmutable(Model);
			JsonEncodingBindingElement = SoalBuilderInstance.instance.JsonEncodingBindingElement.ToImmutable(Model);
			WsProtocolBindingElement = SoalBuilderInstance.instance.WsProtocolBindingElement.ToImmutable(Model);
			WsAddressingBindingElement = SoalBuilderInstance.instance.WsAddressingBindingElement.ToImmutable(Model);
	
			SoalInstance.initialized = true;
		}
	}

	/// <summary>
	/// Factory class for creating instances of model elements.
	/// </summary>
	public class SoalFactory : global::MetaDslx.Modeling.ModelFactory
	{
		public SoalFactory(global::MetaDslx.Modeling.MutableModel model, global::MetaDslx.Modeling.ModelFactoryFlags flags = global::MetaDslx.Modeling.ModelFactoryFlags.None)
			: base(model, flags)
		{
			SoalDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Modeling.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "Annotation": return this.Annotation();
				case "AnnotationProperty": return this.AnnotationProperty();
				case "NamedType": return this.NamedType();
				case "Namespace": return this.Namespace();
				case "ArrayType": return this.ArrayType();
				case "NullableType": return this.NullableType();
				case "NonNullableType": return this.NonNullableType();
				case "PrimitiveType": return this.PrimitiveType();
				case "Enum": return this.Enum();
				case "EnumLiteral": return this.EnumLiteral();
				case "Property": return this.Property();
				case "Struct": return this.Struct();
				case "Interface": return this.Interface();
				case "Database": return this.Database();
				case "Operation": return this.Operation();
				case "InputParameter": return this.InputParameter();
				case "OutputParameter": return this.OutputParameter();
				case "Component": return this.Component();
				case "Composite": return this.Composite();
				case "Assembly": return this.Assembly();
				case "Wire": return this.Wire();
				case "Port": return this.Port();
				case "Service": return this.Service();
				case "Reference": return this.Reference();
				case "Implementation": return this.Implementation();
				case "ProgrammingLanguage": return this.ProgrammingLanguage();
				case "Deployment": return this.Deployment();
				case "Environment": return this.Environment();
				case "Runtime": return this.Runtime();
				case "Binding": return this.Binding();
				case "Endpoint": return this.Endpoint();
				case "HttpTransportBindingElement": return this.HttpTransportBindingElement();
				case "RestTransportBindingElement": return this.RestTransportBindingElement();
				case "WebSocketTransportBindingElement": return this.WebSocketTransportBindingElement();
				case "SoapEncodingBindingElement": return this.SoapEncodingBindingElement();
				case "XmlEncodingBindingElement": return this.XmlEncodingBindingElement();
				case "JsonEncodingBindingElement": return this.JsonEncodingBindingElement();
				case "WsAddressingBindingElement": return this.WsAddressingBindingElement();
				default:
					throw new global::MetaDslx.Modeling.ModelException(global::Microsoft.CodeAnalysis.Location.None, new global::MetaDslx.CodeAnalysis.LanguageDiagnosticInfo(global::MetaDslx.Modeling.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Annotation.
		/// </summary>
		public AnnotationBuilder Annotation()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new AnnotationId());
			return (AnnotationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of AnnotationProperty.
		/// </summary>
		public AnnotationPropertyBuilder AnnotationProperty()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new AnnotationPropertyId());
			return (AnnotationPropertyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of NamedType.
		/// </summary>
		public NamedTypeBuilder NamedType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new NamedTypeId());
			return (NamedTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Namespace.
		/// </summary>
		public NamespaceBuilder Namespace()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new NamespaceId());
			return (NamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of ArrayType.
		/// </summary>
		public ArrayTypeBuilder ArrayType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ArrayTypeId());
			return (ArrayTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of NullableType.
		/// </summary>
		public NullableTypeBuilder NullableType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new NullableTypeId());
			return (NullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of NonNullableType.
		/// </summary>
		public NonNullableTypeBuilder NonNullableType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new NonNullableTypeId());
			return (NonNullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of PrimitiveType.
		/// </summary>
		public PrimitiveTypeBuilder PrimitiveType()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new PrimitiveTypeId());
			return (PrimitiveTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Enum.
		/// </summary>
		public EnumBuilder Enum()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new EnumId());
			return (EnumBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of EnumLiteral.
		/// </summary>
		public EnumLiteralBuilder EnumLiteral()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new EnumLiteralId());
			return (EnumLiteralBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Property.
		/// </summary>
		public PropertyBuilder Property()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new PropertyId());
			return (PropertyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Struct.
		/// </summary>
		public StructBuilder Struct()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new StructId());
			return (StructBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Interface.
		/// </summary>
		public InterfaceBuilder Interface()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new InterfaceId());
			return (InterfaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Database.
		/// </summary>
		public DatabaseBuilder Database()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new DatabaseId());
			return (DatabaseBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Operation.
		/// </summary>
		public OperationBuilder Operation()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new OperationId());
			return (OperationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of InputParameter.
		/// </summary>
		public InputParameterBuilder InputParameter()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new InputParameterId());
			return (InputParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of OutputParameter.
		/// </summary>
		public OutputParameterBuilder OutputParameter()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new OutputParameterId());
			return (OutputParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Component.
		/// </summary>
		public ComponentBuilder Component()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ComponentId());
			return (ComponentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Composite.
		/// </summary>
		public CompositeBuilder Composite()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new CompositeId());
			return (CompositeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Assembly.
		/// </summary>
		public AssemblyBuilder Assembly()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new AssemblyId());
			return (AssemblyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Wire.
		/// </summary>
		public WireBuilder Wire()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new WireId());
			return (WireBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Port.
		/// </summary>
		public PortBuilder Port()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new PortId());
			return (PortBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Service.
		/// </summary>
		public ServiceBuilder Service()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ServiceId());
			return (ServiceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Reference.
		/// </summary>
		public ReferenceBuilder Reference()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ReferenceId());
			return (ReferenceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Implementation.
		/// </summary>
		public ImplementationBuilder Implementation()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ImplementationId());
			return (ImplementationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of ProgrammingLanguage.
		/// </summary>
		public ProgrammingLanguageBuilder ProgrammingLanguage()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new ProgrammingLanguageId());
			return (ProgrammingLanguageBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Deployment.
		/// </summary>
		public DeploymentBuilder Deployment()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new DeploymentId());
			return (DeploymentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Environment.
		/// </summary>
		public EnvironmentBuilder Environment()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new EnvironmentId());
			return (EnvironmentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Runtime.
		/// </summary>
		public RuntimeBuilder Runtime()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new RuntimeId());
			return (RuntimeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Binding.
		/// </summary>
		public BindingBuilder Binding()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new BindingId());
			return (BindingBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Endpoint.
		/// </summary>
		public EndpointBuilder Endpoint()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new EndpointId());
			return (EndpointBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of HttpTransportBindingElement.
		/// </summary>
		public HttpTransportBindingElementBuilder HttpTransportBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new HttpTransportBindingElementId());
			return (HttpTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of RestTransportBindingElement.
		/// </summary>
		public RestTransportBindingElementBuilder RestTransportBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new RestTransportBindingElementId());
			return (RestTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of WebSocketTransportBindingElement.
		/// </summary>
		public WebSocketTransportBindingElementBuilder WebSocketTransportBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new WebSocketTransportBindingElementId());
			return (WebSocketTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of SoapEncodingBindingElement.
		/// </summary>
		public SoapEncodingBindingElementBuilder SoapEncodingBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new SoapEncodingBindingElementId());
			return (SoapEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of XmlEncodingBindingElement.
		/// </summary>
		public XmlEncodingBindingElementBuilder XmlEncodingBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new XmlEncodingBindingElementId());
			return (XmlEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of JsonEncodingBindingElement.
		/// </summary>
		public JsonEncodingBindingElementBuilder JsonEncodingBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new JsonEncodingBindingElementId());
			return (JsonEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of WsAddressingBindingElement.
		/// </summary>
		public WsAddressingBindingElementBuilder WsAddressingBindingElement()
		{
			global::MetaDslx.Modeling.MutableSymbol symbol = this.CreateSymbol(new WsAddressingBindingElementId());
			return (WsAddressingBindingElementBuilder)symbol;
		}
	}
	

	
	public enum SoapVersion
	{
		Soap11,
		Soap12
	}
	
	public static class SoapVersionExtensions
	{
	}
	
	public enum SoapEncodingStyle
	{
		DocumentWrapped,
		DocumentLiteral,
		RpcLiteral,
		RpcEncoded
	}
	
	public static class SoapEncodingStyleExtensions
	{
	}
	
	public interface AnnotatedElement : global::MetaDslx.Modeling.ImmutableSymbol
	{
		global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations { get; }
	
	
		new AnnotatedElementBuilder ToMutable();
		new AnnotatedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotatedElementBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations { get; }
	
		new AnnotatedElement ToImmutable();
		new AnnotatedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Annotation : NamedElement
	{
		global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> Properties { get; }
	
	
		new AnnotationBuilder ToMutable();
		new AnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotationBuilder : NamedElementBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> Properties { get; }
	
		new Annotation ToImmutable();
		new Annotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface AnnotationProperty : NamedElement
	{
		object Value { get; }
	
	
		new AnnotationPropertyBuilder ToMutable();
		new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AnnotationPropertyBuilder : NamedElementBuilder
	{
		object Value { get; set; }
		Func<object> ValueLazy { get; set; }
	
		new AnnotationProperty ToImmutable();
		new AnnotationProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface DocumentedElement : global::MetaDslx.Modeling.ImmutableSymbol
	{
		string Documentation { get; }
	
		global::MetaDslx.Modeling.ImmutableModelList<string> GetDocumentationLines();
	
		new DocumentedElementBuilder ToMutable();
		new DocumentedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DocumentedElementBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		string Documentation { get; set; }
		Func<string> DocumentationLazy { get; set; }
	
		new DocumentedElement ToImmutable();
		new DocumentedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NamedElement : DocumentedElement
	{
		string Name { get; }
	
	
		new NamedElementBuilder ToMutable();
		new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamedElementBuilder : DocumentedElementBuilder
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new NamedElement ToImmutable();
		new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TypedElement : global::MetaDslx.Modeling.ImmutableSymbol
	{
		SoalType Type { get; }
	
	
		new TypedElementBuilder ToMutable();
		new TypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TypedElementBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		SoalTypeBuilder Type { get; set; }
		Func<SoalTypeBuilder> TypeLazy { get; set; }
	
		new TypedElement ToImmutable();
		new TypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface SoalType : global::MetaDslx.Modeling.ImmutableSymbol
	{
	
	
		new SoalTypeBuilder ToMutable();
		new SoalTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SoalTypeBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
	
		new SoalType ToImmutable();
		new SoalType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NamedType : SoalType, NamedElement
	{
	
	
		new NamedTypeBuilder ToMutable();
		new NamedTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamedTypeBuilder : SoalTypeBuilder, NamedElementBuilder
	{
	
		new NamedType ToImmutable();
		new NamedType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Declaration : NamedElement, AnnotatedElement
	{
		Namespace Namespace { get; }
		string FullName { get; }
	
	
		new DeclarationBuilder ToMutable();
		new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DeclarationBuilder : NamedElementBuilder, AnnotatedElementBuilder
	{
		NamespaceBuilder Namespace { get; set; }
		Func<NamespaceBuilder> NamespaceLazy { get; set; }
		string FullName { get; }
		Func<string> FullNameLazy { get; set; }
	
		new Declaration ToImmutable();
		new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Namespace : Declaration
	{
		string Uri { get; }
		string Prefix { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new NamespaceBuilder ToMutable();
		new NamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NamespaceBuilder : DeclarationBuilder
	{
		string Uri { get; set; }
		Func<string> UriLazy { get; set; }
		string Prefix { get; set; }
		Func<string> PrefixLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Namespace ToImmutable();
		new Namespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ArrayType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new ArrayTypeBuilder ToMutable();
		new ArrayTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ArrayTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new ArrayType ToImmutable();
		new ArrayType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NullableType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new NullableTypeBuilder ToMutable();
		new NullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NullableTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new NullableType ToImmutable();
		new NullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface NonNullableType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new NonNullableTypeBuilder ToMutable();
		new NonNullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface NonNullableTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new NonNullableType ToImmutable();
		new NonNullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface PrimitiveType : SoalType, Declaration
	{
		bool Nullable { get; }
	
	
		new PrimitiveTypeBuilder ToMutable();
		new PrimitiveTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface PrimitiveTypeBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		bool Nullable { get; set; }
		Func<bool> NullableLazy { get; set; }
	
		new PrimitiveType ToImmutable();
		new PrimitiveType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Enum : SoalType, Declaration
	{
		Enum BaseType { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EnumLiteral> EnumLiterals { get; }
	
	
		new EnumBuilder ToMutable();
		new EnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EnumBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		EnumBuilder BaseType { get; set; }
		Func<EnumBuilder> BaseTypeLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<EnumLiteralBuilder> EnumLiterals { get; }
	
		new Enum ToImmutable();
		new Enum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EnumLiteral : NamedElement, TypedElement, AnnotatedElement
	{
		Enum Enum { get; }
	
	
		new EnumLiteralBuilder ToMutable();
		new EnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EnumLiteralBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
		EnumBuilder Enum { get; set; }
		Func<EnumBuilder> EnumLazy { get; set; }
	
		new EnumLiteral ToImmutable();
		new EnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Property : NamedElement, TypedElement, AnnotatedElement
	{
	
	
		new PropertyBuilder ToMutable();
		new PropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface PropertyBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
	
		new Property ToImmutable();
		new Property ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Struct : SoalType, Declaration
	{
		Struct BaseType { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Property> Properties { get; }
	
	
		new StructBuilder ToMutable();
		new StructBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface StructBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		StructBuilder BaseType { get; set; }
		Func<StructBuilder> BaseTypeLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties { get; }
	
		new Struct ToImmutable();
		new Struct ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Interface : SoalType, Declaration
	{
		global::MetaDslx.Modeling.ImmutableModelList<Operation> Operations { get; }
	
	
		new InterfaceBuilder ToMutable();
		new InterfaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface InterfaceBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<OperationBuilder> Operations { get; }
	
		new Interface ToImmutable();
		new Interface ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Database : Interface
	{
		global::MetaDslx.Modeling.ImmutableModelList<Struct> Entities { get; }
	
	
		new DatabaseBuilder ToMutable();
		new DatabaseBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DatabaseBuilder : InterfaceBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<StructBuilder> Entities { get; }
	
		new Database ToImmutable();
		new Database ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Operation : NamedElement, AnnotatedElement
	{
		string Action { get; }
		global::MetaDslx.Modeling.ImmutableModelList<InputParameter> Parameters { get; }
		OutputParameter Result { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Struct> Exceptions { get; }
	
	
		new OperationBuilder ToMutable();
		new OperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface OperationBuilder : NamedElementBuilder, AnnotatedElementBuilder
	{
		string Action { get; set; }
		Func<string> ActionLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<InputParameterBuilder> Parameters { get; }
		OutputParameterBuilder Result { get; set; }
		Func<OutputParameterBuilder> ResultLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<StructBuilder> Exceptions { get; }
	
		new Operation ToImmutable();
		new Operation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface InputParameter : NamedElement, TypedElement, AnnotatedElement
	{
	
	
		new InputParameterBuilder ToMutable();
		new InputParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface InputParameterBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
	
		new InputParameter ToImmutable();
		new InputParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface OutputParameter : TypedElement, AnnotatedElement
	{
		bool IsOneway { get; }
	
	
		new OutputParameterBuilder ToMutable();
		new OutputParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface OutputParameterBuilder : TypedElementBuilder, AnnotatedElementBuilder
	{
		bool IsOneway { get; set; }
		Func<bool> IsOnewayLazy { get; set; }
	
		new OutputParameter ToImmutable();
		new OutputParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Component : Declaration
	{
		Component BaseComponent { get; }
		bool IsAbstract { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Port> Ports { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Service> Services { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Reference> References { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Property> Properties { get; }
		Implementation Implementation { get; }
		ProgrammingLanguage Language { get; }
	
	
		new ComponentBuilder ToMutable();
		new ComponentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ComponentBuilder : DeclarationBuilder
	{
		ComponentBuilder BaseComponent { get; set; }
		Func<ComponentBuilder> BaseComponentLazy { get; set; }
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<PortBuilder> Ports { get; }
		global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> Services { get; }
		global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> References { get; }
		global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties { get; }
		ImplementationBuilder Implementation { get; set; }
		Func<ImplementationBuilder> ImplementationLazy { get; set; }
		ProgrammingLanguageBuilder Language { get; set; }
		Func<ProgrammingLanguageBuilder> LanguageLazy { get; set; }
	
		new Component ToImmutable();
		new Component ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Composite : Component
	{
		global::MetaDslx.Modeling.ImmutableModelList<Component> Components { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Wire> Wires { get; }
	
	
		new CompositeBuilder ToMutable();
		new CompositeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface CompositeBuilder : ComponentBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<ComponentBuilder> Components { get; }
		global::MetaDslx.Modeling.MutableModelList<WireBuilder> Wires { get; }
	
		new Composite ToImmutable();
		new Composite ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Assembly : Composite
	{
	
	
		new AssemblyBuilder ToMutable();
		new AssemblyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface AssemblyBuilder : CompositeBuilder
	{
	
		new Assembly ToImmutable();
		new Assembly ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Wire : global::MetaDslx.Modeling.ImmutableSymbol
	{
		Port Source { get; }
		Port Target { get; }
	
	
		new WireBuilder ToMutable();
		new WireBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface WireBuilder : global::MetaDslx.Modeling.MutableSymbol
	{
		PortBuilder Source { get; set; }
		Func<PortBuilder> SourceLazy { get; set; }
		PortBuilder Target { get; set; }
		Func<PortBuilder> TargetLazy { get; set; }
	
		new Wire ToImmutable();
		new Wire ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Port : NamedElement
	{
		Component Component { get; }
		Interface Interface { get; }
		Binding Binding { get; }
	
	
		new PortBuilder ToMutable();
		new PortBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface PortBuilder : NamedElementBuilder
	{
		ComponentBuilder Component { get; set; }
		Func<ComponentBuilder> ComponentLazy { get; set; }
		InterfaceBuilder Interface { get; set; }
		Func<InterfaceBuilder> InterfaceLazy { get; set; }
		BindingBuilder Binding { get; set; }
		Func<BindingBuilder> BindingLazy { get; set; }
	
		new Port ToImmutable();
		new Port ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Service : Port
	{
	
	
		new ServiceBuilder ToMutable();
		new ServiceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ServiceBuilder : PortBuilder
	{
	
		new Service ToImmutable();
		new Service ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Reference : Port
	{
	
	
		new ReferenceBuilder ToMutable();
		new ReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ReferenceBuilder : PortBuilder
	{
	
		new Reference ToImmutable();
		new Reference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Implementation : NamedElement
	{
	
	
		new ImplementationBuilder ToMutable();
		new ImplementationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ImplementationBuilder : NamedElementBuilder
	{
	
		new Implementation ToImmutable();
		new Implementation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ProgrammingLanguage : NamedElement
	{
	
	
		new ProgrammingLanguageBuilder ToMutable();
		new ProgrammingLanguageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ProgrammingLanguageBuilder : NamedElementBuilder
	{
	
		new ProgrammingLanguage ToImmutable();
		new ProgrammingLanguage ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Deployment : Declaration
	{
		global::MetaDslx.Modeling.ImmutableModelList<Environment> Environments { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Wire> Wires { get; }
	
	
		new DeploymentBuilder ToMutable();
		new DeploymentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface DeploymentBuilder : DeclarationBuilder
	{
		global::MetaDslx.Modeling.MutableModelList<EnvironmentBuilder> Environments { get; }
		global::MetaDslx.Modeling.MutableModelList<WireBuilder> Wires { get; }
	
		new Deployment ToImmutable();
		new Deployment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Environment : NamedElement
	{
		Runtime Runtime { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Interface> Databases { get; }
		global::MetaDslx.Modeling.ImmutableModelList<Assembly> Assemblies { get; }
	
	
		new EnvironmentBuilder ToMutable();
		new EnvironmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EnvironmentBuilder : NamedElementBuilder
	{
		RuntimeBuilder Runtime { get; set; }
		Func<RuntimeBuilder> RuntimeLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<InterfaceBuilder> Databases { get; }
		global::MetaDslx.Modeling.MutableModelList<AssemblyBuilder> Assemblies { get; }
	
		new Environment ToImmutable();
		new Environment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Runtime : NamedElement
	{
	
	
		new RuntimeBuilder ToMutable();
		new RuntimeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RuntimeBuilder : NamedElementBuilder
	{
	
		new Runtime ToImmutable();
		new Runtime ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Binding : Declaration
	{
		TransportBindingElement Transport { get; }
		global::MetaDslx.Modeling.ImmutableModelList<EncodingBindingElement> Encodings { get; }
		global::MetaDslx.Modeling.ImmutableModelList<ProtocolBindingElement> Protocols { get; }
	
	
		new BindingBuilder ToMutable();
		new BindingBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface BindingBuilder : DeclarationBuilder
	{
		TransportBindingElementBuilder Transport { get; set; }
		Func<TransportBindingElementBuilder> TransportLazy { get; set; }
		global::MetaDslx.Modeling.MutableModelList<EncodingBindingElementBuilder> Encodings { get; }
		global::MetaDslx.Modeling.MutableModelList<ProtocolBindingElementBuilder> Protocols { get; }
	
		new Binding ToImmutable();
		new Binding ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface Endpoint : Declaration
	{
		Interface Interface { get; }
		Binding Binding { get; }
		string Address { get; }
	
	
		new EndpointBuilder ToMutable();
		new EndpointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EndpointBuilder : DeclarationBuilder
	{
		InterfaceBuilder Interface { get; set; }
		Func<InterfaceBuilder> InterfaceLazy { get; set; }
		BindingBuilder Binding { get; set; }
		Func<BindingBuilder> BindingLazy { get; set; }
		string Address { get; set; }
		Func<string> AddressLazy { get; set; }
	
		new Endpoint ToImmutable();
		new Endpoint ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface BindingElement : NamedElement
	{
	
	
		new BindingElementBuilder ToMutable();
		new BindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface BindingElementBuilder : NamedElementBuilder
	{
	
		new BindingElement ToImmutable();
		new BindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface TransportBindingElement : BindingElement
	{
	
	
		new TransportBindingElementBuilder ToMutable();
		new TransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface TransportBindingElementBuilder : BindingElementBuilder
	{
	
		new TransportBindingElement ToImmutable();
		new TransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface EncodingBindingElement : BindingElement
	{
	
	
		new EncodingBindingElementBuilder ToMutable();
		new EncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface EncodingBindingElementBuilder : BindingElementBuilder
	{
	
		new EncodingBindingElement ToImmutable();
		new EncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface ProtocolBindingElement : BindingElement
	{
	
	
		new ProtocolBindingElementBuilder ToMutable();
		new ProtocolBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface ProtocolBindingElementBuilder : BindingElementBuilder
	{
	
		new ProtocolBindingElement ToImmutable();
		new ProtocolBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface HttpTransportBindingElement : TransportBindingElement
	{
		bool Ssl { get; }
		bool ClientAuthentication { get; }
	
	
		new HttpTransportBindingElementBuilder ToMutable();
		new HttpTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface HttpTransportBindingElementBuilder : TransportBindingElementBuilder
	{
		bool Ssl { get; set; }
		Func<bool> SslLazy { get; set; }
		bool ClientAuthentication { get; set; }
		Func<bool> ClientAuthenticationLazy { get; set; }
	
		new HttpTransportBindingElement ToImmutable();
		new HttpTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface RestTransportBindingElement : TransportBindingElement
	{
	
	
		new RestTransportBindingElementBuilder ToMutable();
		new RestTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface RestTransportBindingElementBuilder : TransportBindingElementBuilder
	{
	
		new RestTransportBindingElement ToImmutable();
		new RestTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface WebSocketTransportBindingElement : TransportBindingElement
	{
	
	
		new WebSocketTransportBindingElementBuilder ToMutable();
		new WebSocketTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface WebSocketTransportBindingElementBuilder : TransportBindingElementBuilder
	{
	
		new WebSocketTransportBindingElement ToImmutable();
		new WebSocketTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface SoapEncodingBindingElement : EncodingBindingElement
	{
		SoapEncodingStyle Style { get; }
		SoapVersion Version { get; }
		bool Mtom { get; }
	
	
		new SoapEncodingBindingElementBuilder ToMutable();
		new SoapEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface SoapEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
		SoapEncodingStyle Style { get; set; }
		Func<SoapEncodingStyle> StyleLazy { get; set; }
		SoapVersion Version { get; set; }
		Func<SoapVersion> VersionLazy { get; set; }
		bool Mtom { get; set; }
		Func<bool> MtomLazy { get; set; }
	
		new SoapEncodingBindingElement ToImmutable();
		new SoapEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface XmlEncodingBindingElement : EncodingBindingElement
	{
	
	
		new XmlEncodingBindingElementBuilder ToMutable();
		new XmlEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface XmlEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
	
		new XmlEncodingBindingElement ToImmutable();
		new XmlEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface JsonEncodingBindingElement : EncodingBindingElement
	{
	
	
		new JsonEncodingBindingElementBuilder ToMutable();
		new JsonEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface JsonEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
	
		new JsonEncodingBindingElement ToImmutable();
		new JsonEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface WsProtocolBindingElement : ProtocolBindingElement
	{
	
	
		new WsProtocolBindingElementBuilder ToMutable();
		new WsProtocolBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface WsProtocolBindingElementBuilder : ProtocolBindingElementBuilder
	{
	
		new WsProtocolBindingElement ToImmutable();
		new WsProtocolBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}
	
	public interface WsAddressingBindingElement : WsProtocolBindingElement
	{
	
	
		new WsAddressingBindingElementBuilder ToMutable();
		new WsAddressingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model);
	}
	
	public interface WsAddressingBindingElementBuilder : WsProtocolBindingElementBuilder
	{
	
		new WsAddressingBindingElement ToImmutable();
		new WsAddressingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model);
	}

	public static class SoalDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty> properties;
	
		static SoalDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Modeling.ModelProperty>();
			AnnotatedElement.Initialize();
			Annotation.Initialize();
			AnnotationProperty.Initialize();
			DocumentedElement.Initialize();
			NamedElement.Initialize();
			TypedElement.Initialize();
			SoalType.Initialize();
			NamedType.Initialize();
			Declaration.Initialize();
			Namespace.Initialize();
			ArrayType.Initialize();
			NullableType.Initialize();
			NonNullableType.Initialize();
			PrimitiveType.Initialize();
			Enum.Initialize();
			EnumLiteral.Initialize();
			Property.Initialize();
			Struct.Initialize();
			Interface.Initialize();
			Database.Initialize();
			Operation.Initialize();
			InputParameter.Initialize();
			OutputParameter.Initialize();
			Component.Initialize();
			Composite.Initialize();
			Assembly.Initialize();
			Wire.Initialize();
			Port.Initialize();
			Service.Initialize();
			Reference.Initialize();
			Implementation.Initialize();
			ProgrammingLanguage.Initialize();
			Deployment.Initialize();
			Environment.Initialize();
			Runtime.Initialize();
			Binding.Initialize();
			Endpoint.Initialize();
			BindingElement.Initialize();
			TransportBindingElement.Initialize();
			EncodingBindingElement.Initialize();
			ProtocolBindingElement.Initialize();
			HttpTransportBindingElement.Initialize();
			RestTransportBindingElement.Initialize();
			WebSocketTransportBindingElement.Initialize();
			SoapEncodingBindingElement.Initialize();
			XmlEncodingBindingElement.Initialize();
			JsonEncodingBindingElement.Initialize();
			WsProtocolBindingElement.Initialize();
			WsAddressingBindingElement.Initialize();
			properties.Add(SoalDescriptor.AnnotatedElement.AnnotationsProperty);
			properties.Add(SoalDescriptor.Annotation.PropertiesProperty);
			properties.Add(SoalDescriptor.AnnotationProperty.ValueProperty);
			properties.Add(SoalDescriptor.DocumentedElement.DocumentationProperty);
			properties.Add(SoalDescriptor.NamedElement.NameProperty);
			properties.Add(SoalDescriptor.TypedElement.TypeProperty);
			properties.Add(SoalDescriptor.Declaration.NamespaceProperty);
			properties.Add(SoalDescriptor.Declaration.FullNameProperty);
			properties.Add(SoalDescriptor.Namespace.UriProperty);
			properties.Add(SoalDescriptor.Namespace.PrefixProperty);
			properties.Add(SoalDescriptor.Namespace.DeclarationsProperty);
			properties.Add(SoalDescriptor.ArrayType.InnerTypeProperty);
			properties.Add(SoalDescriptor.NullableType.InnerTypeProperty);
			properties.Add(SoalDescriptor.NonNullableType.InnerTypeProperty);
			properties.Add(SoalDescriptor.PrimitiveType.NullableProperty);
			properties.Add(SoalDescriptor.Enum.BaseTypeProperty);
			properties.Add(SoalDescriptor.Enum.EnumLiteralsProperty);
			properties.Add(SoalDescriptor.EnumLiteral.EnumProperty);
			properties.Add(SoalDescriptor.Struct.BaseTypeProperty);
			properties.Add(SoalDescriptor.Struct.PropertiesProperty);
			properties.Add(SoalDescriptor.Interface.OperationsProperty);
			properties.Add(SoalDescriptor.Database.EntitiesProperty);
			properties.Add(SoalDescriptor.Operation.ActionProperty);
			properties.Add(SoalDescriptor.Operation.ParametersProperty);
			properties.Add(SoalDescriptor.Operation.ResultProperty);
			properties.Add(SoalDescriptor.Operation.ExceptionsProperty);
			properties.Add(SoalDescriptor.OutputParameter.IsOnewayProperty);
			properties.Add(SoalDescriptor.Component.BaseComponentProperty);
			properties.Add(SoalDescriptor.Component.IsAbstractProperty);
			properties.Add(SoalDescriptor.Component.PortsProperty);
			properties.Add(SoalDescriptor.Component.ServicesProperty);
			properties.Add(SoalDescriptor.Component.ReferencesProperty);
			properties.Add(SoalDescriptor.Component.PropertiesProperty);
			properties.Add(SoalDescriptor.Component.ImplementationProperty);
			properties.Add(SoalDescriptor.Component.LanguageProperty);
			properties.Add(SoalDescriptor.Composite.ComponentsProperty);
			properties.Add(SoalDescriptor.Composite.WiresProperty);
			properties.Add(SoalDescriptor.Wire.SourceProperty);
			properties.Add(SoalDescriptor.Wire.TargetProperty);
			properties.Add(SoalDescriptor.Port.ComponentProperty);
			properties.Add(SoalDescriptor.Port.InterfaceProperty);
			properties.Add(SoalDescriptor.Port.BindingProperty);
			properties.Add(SoalDescriptor.Deployment.EnvironmentsProperty);
			properties.Add(SoalDescriptor.Deployment.WiresProperty);
			properties.Add(SoalDescriptor.Environment.RuntimeProperty);
			properties.Add(SoalDescriptor.Environment.DatabasesProperty);
			properties.Add(SoalDescriptor.Environment.AssembliesProperty);
			properties.Add(SoalDescriptor.Binding.TransportProperty);
			properties.Add(SoalDescriptor.Binding.EncodingsProperty);
			properties.Add(SoalDescriptor.Binding.ProtocolsProperty);
			properties.Add(SoalDescriptor.Endpoint.InterfaceProperty);
			properties.Add(SoalDescriptor.Endpoint.BindingProperty);
			properties.Add(SoalDescriptor.Endpoint.AddressProperty);
			properties.Add(SoalDescriptor.HttpTransportBindingElement.SslProperty);
			properties.Add(SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty);
			properties.Add(SoalDescriptor.SoapEncodingBindingElement.StyleProperty);
			properties.Add(SoalDescriptor.SoapEncodingBindingElement.VersionProperty);
			properties.Add(SoalDescriptor.SoapEncodingBindingElement.MtomProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://MetaDslx.Languages.Soal/1.0";
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.AnnotatedElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElementBuilder))]
		public static class AnnotatedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static AnnotatedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(AnnotatedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotatedElement; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty AnnotationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(AnnotatedElement), "Annotations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Annotation), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Annotation>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotatedElement_Annotations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.AnnotationId), typeof(global::MetaDslx.Languages.Soal.Symbols.Annotation), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Annotation
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Annotation()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Annotation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Annotation; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Annotation), "Properties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Annotation_Properties);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.AnnotationPropertyId), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class AnnotationProperty
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static AnnotationProperty()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(AnnotationProperty));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotationProperty; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ValueProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(AnnotationProperty), "Value",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(object), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(object), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotationProperty_Value);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.DocumentedElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.DocumentedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.DocumentedElementBuilder))]
		public static class DocumentedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static DocumentedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(DocumentedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.DocumentedElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DocumentationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(DocumentedElement), "Documentation",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.DocumentedElement_Documentation);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.NamedElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.NamedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.NamedElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.DocumentedElement) })]
		public static class NamedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static NamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NamedElement; }
			}
			
			[global::MetaDslx.Modeling.NameAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty NameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(NamedElement), "Name",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NamedElement_Name);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.TypedElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.TypedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.TypedElementBuilder))]
		public static class TypedElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static TypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TypedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TypedElement; }
			}
			
			[global::MetaDslx.Modeling.TypeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty TypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(TypedElement), "Type",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TypedElement_Type);
		}
	
		[global::MetaDslx.Modeling.TypeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.SoalTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder))]
		public static class SoalType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static SoalType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(SoalType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoalType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.NamedTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.NamedType), typeof(global::MetaDslx.Languages.Soal.Symbols.NamedTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.NamedElement) })]
		public static class NamedType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static NamedType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NamedType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NamedType; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.DeclarationId), typeof(global::MetaDslx.Languages.Soal.Symbols.Declaration), typeof(global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Declaration
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Declaration()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Declaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Declaration; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.Namespace), "Declarations")]
			public static readonly global::MetaDslx.Modeling.ModelProperty NamespaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Declaration), "Namespace",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Namespace), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.NamespaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Declaration_Namespace);
			
			[global::MetaDslx.Modeling.ReadonlyAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty FullNameProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Declaration), "FullName",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Declaration_FullName);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.NamespaceId), typeof(global::MetaDslx.Languages.Soal.Symbols.Namespace), typeof(global::MetaDslx.Languages.Soal.Symbols.NamespaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Namespace
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Namespace()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Namespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty UriProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Namespace), "Uri",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Uri);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty PrefixProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Namespace), "Prefix",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Prefix);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.Declaration), "Namespace")]
			public static readonly global::MetaDslx.Modeling.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Namespace), "Declarations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Declaration), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Declaration>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Declarations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ArrayTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.ArrayType), typeof(global::MetaDslx.Languages.Soal.Symbols.ArrayTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class ArrayType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static ArrayType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ArrayType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ArrayType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(ArrayType), "InnerType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ArrayType_InnerType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.NullableTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.NullableType), typeof(global::MetaDslx.Languages.Soal.Symbols.NullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class NullableType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static NullableType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NullableType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(NullableType), "InnerType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NullableType_InnerType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.NonNullableTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.NonNullableType), typeof(global::MetaDslx.Languages.Soal.Symbols.NonNullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class NonNullableType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static NonNullableType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NonNullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NonNullableType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(NonNullableType), "InnerType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NonNullableType_InnerType);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.PrimitiveTypeId), typeof(global::MetaDslx.Languages.Soal.Symbols.PrimitiveType), typeof(global::MetaDslx.Languages.Soal.Symbols.PrimitiveTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class PrimitiveType
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static PrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(PrimitiveType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.PrimitiveType; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty NullableProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(PrimitiveType), "Nullable",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.PrimitiveType_Nullable);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.EnumId), typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Enum
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Enum()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Enum));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum; }
			}
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Enum), "BaseType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum_BaseType);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.EnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Enum), "EnumLiterals",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteral), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnumLiteral>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum_EnumLiterals);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.EnumLiteralId), typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteral), typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class EnumLiteral
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static EnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(EnumLiteral));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EnumLiteral; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.Enum), "EnumLiterals")]
			[global::MetaDslx.Modeling.RedefinesAttribute(typeof(SoalDescriptor.TypedElement), "Type")]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnumProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(EnumLiteral), "Enum",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EnumLiteral_Enum);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.PropertyId), typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Property
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Property()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Property));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Property; }
			}
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.StructId), typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Struct
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Struct()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Struct));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct; }
			}
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Struct), "BaseType",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct_BaseType);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Struct), "Properties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Property>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct_Properties);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.InterfaceId), typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Interface
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Interface()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Interface));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Interface; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty OperationsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Interface), "Operations",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Operation), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Operation>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OperationBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.OperationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Interface_Operations);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.DatabaseId), typeof(global::MetaDslx.Languages.Soal.Symbols.Database), typeof(global::MetaDslx.Languages.Soal.Symbols.DatabaseBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Interface) })]
		public static class Database
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Database()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Database));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Database; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty EntitiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Database), "Entities",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Struct>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.StructBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Database_Entities);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.OperationId), typeof(global::MetaDslx.Languages.Soal.Symbols.Operation), typeof(global::MetaDslx.Languages.Soal.Symbols.OperationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Operation
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Operation()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Operation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ActionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Operation), "Action",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Action);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ParametersProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Operation), "Parameters",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameter), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.InputParameter>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Parameters);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ResultProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Operation), "Result",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameter), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameterBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Result);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ExceptionsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Operation), "Exceptions",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Struct>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.StructBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Exceptions);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.InputParameterId), typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameter), typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class InputParameter
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static InputParameter()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(InputParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.InputParameter; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.OutputParameterId), typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameter), typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class OutputParameter
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static OutputParameter()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(OutputParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.OutputParameter; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsOnewayProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(OutputParameter), "IsOneway",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.OutputParameter_IsOneway);
		}
	
		[global::MetaDslx.Modeling.ScopeAttribute]
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ComponentId), typeof(global::MetaDslx.Languages.Soal.Symbols.Component), typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Component
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Component()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Component));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component; }
			}
			
			[global::MetaDslx.Modeling.BaseScopeAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty BaseComponentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "BaseComponent",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_BaseComponent);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "IsAbstract",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_IsAbstract);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.Port), "Component")]
			public static readonly global::MetaDslx.Modeling.ModelProperty PortsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "Ports",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Port>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PortBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Ports);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.SubsetsAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ServicesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "Services",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Service), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Service>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Services);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			[global::MetaDslx.Modeling.SubsetsAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ReferencesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "References",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Reference), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Reference>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_References);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty PropertiesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "Properties",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Property>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Properties);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ImplementationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "Implementation",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Implementation), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ImplementationBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Implementation);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty LanguageProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Component), "Language",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProgrammingLanguage), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProgrammingLanguageBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Language);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.CompositeId), typeof(global::MetaDslx.Languages.Soal.Symbols.Composite), typeof(global::MetaDslx.Languages.Soal.Symbols.CompositeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Component) })]
		public static class Composite
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Composite()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Composite));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ComponentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Composite), "Components",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Component>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite_Components);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty WiresProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Composite), "Wires",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Wire>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.WireBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite_Wires);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.AssemblyId), typeof(global::MetaDslx.Languages.Soal.Symbols.Assembly), typeof(global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Composite) })]
		public static class Assembly
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Assembly()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Assembly));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Assembly; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.WireId), typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder))]
		public static class Wire
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Wire()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Wire));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SourceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Wire), "Source",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire_Source);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty TargetProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Wire), "Target",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire_Target);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.PortId), typeof(global::MetaDslx.Languages.Soal.Symbols.Port), typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Port
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Port()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Port));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port; }
			}
			
			[global::MetaDslx.Modeling.OppositeAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Modeling.ModelProperty ComponentProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Port), "Component",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Component);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InterfaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Port), "Interface",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Interface);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty BindingProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Port), "Binding",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Binding);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ServiceId), typeof(global::MetaDslx.Languages.Soal.Symbols.Service), typeof(global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Port) })]
		public static class Service
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Service()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Service));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Service; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ReferenceId), typeof(global::MetaDslx.Languages.Soal.Symbols.Reference), typeof(global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Port) })]
		public static class Reference
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Reference()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Reference));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Reference; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ImplementationId), typeof(global::MetaDslx.Languages.Soal.Symbols.Implementation), typeof(global::MetaDslx.Languages.Soal.Symbols.ImplementationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Implementation
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Implementation()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Implementation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Implementation; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ProgrammingLanguageId), typeof(global::MetaDslx.Languages.Soal.Symbols.ProgrammingLanguage), typeof(global::MetaDslx.Languages.Soal.Symbols.ProgrammingLanguageBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class ProgrammingLanguage
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static ProgrammingLanguage()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ProgrammingLanguage));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ProgrammingLanguage; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.DeploymentId), typeof(global::MetaDslx.Languages.Soal.Symbols.Deployment), typeof(global::MetaDslx.Languages.Soal.Symbols.DeploymentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Deployment
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Deployment()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Deployment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EnvironmentsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Deployment), "Environments",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Environment), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Environment>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment_Environments);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty WiresProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Deployment), "Wires",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Wire>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.WireBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment_Wires);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.EnvironmentId), typeof(global::MetaDslx.Languages.Soal.Symbols.Environment), typeof(global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Environment
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Environment()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Environment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty RuntimeProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Environment), "Runtime",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Runtime), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.RuntimeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Runtime);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty DatabasesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Environment), "Databases",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Interface>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Databases);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AssembliesProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Environment), "Assemblies",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Assembly), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Assembly>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Assemblies);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.RuntimeId), typeof(global::MetaDslx.Languages.Soal.Symbols.Runtime), typeof(global::MetaDslx.Languages.Soal.Symbols.RuntimeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Runtime
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Runtime()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Runtime));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Runtime; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.BindingId), typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Binding
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Binding()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Binding));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding; }
			}
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty TransportProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Binding), "Transport",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElement), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElementBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Transport);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty EncodingsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Binding), "Encodings",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Encodings);
			
			[global::MetaDslx.Modeling.ContainmentAttribute]
			public static readonly global::MetaDslx.Modeling.ModelProperty ProtocolsProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Binding), "Protocols",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement), typeof(global::MetaDslx.Modeling.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement>)),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder), typeof(global::MetaDslx.Modeling.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Protocols);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.EndpointId), typeof(global::MetaDslx.Languages.Soal.Symbols.Endpoint), typeof(global::MetaDslx.Languages.Soal.Symbols.EndpointBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Endpoint
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static Endpoint()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Endpoint));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty InterfaceProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Endpoint), "Interface",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Interface);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty BindingProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Endpoint), "Binding",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Binding);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty AddressProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(Endpoint), "Address",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Address);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.BindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.BindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.BindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class BindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static BindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(BindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.BindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.TransportBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class TransportBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static TransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.EncodingBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class EncodingBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static EncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(EncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.ProtocolBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class ProtocolBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static ProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ProtocolBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.HttpTransportBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.HttpTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.HttpTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class HttpTransportBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static HttpTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(HttpTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty SslProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(HttpTransportBindingElement), "Ssl",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement_Ssl);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty ClientAuthenticationProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(HttpTransportBindingElement), "ClientAuthentication",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement_ClientAuthentication);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.RestTransportBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.RestTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.RestTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class RestTransportBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static RestTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(RestTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.RestTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.WebSocketTransportBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.WebSocketTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WebSocketTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class WebSocketTransportBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static WebSocketTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WebSocketTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.WebSocketTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.SoapEncodingBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class SoapEncodingBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static SoapEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(SoapEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement; }
			}
			
			public static readonly global::MetaDslx.Modeling.ModelProperty StyleProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Style",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingStyle), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingStyle), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Style);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty VersionProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Version",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapVersion), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapVersion), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Version);
			
			public static readonly global::MetaDslx.Modeling.ModelProperty MtomProperty =
			    global::MetaDslx.Modeling.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Mtom",
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Modeling.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Mtom);
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.XmlEncodingBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.XmlEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.XmlEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class XmlEncodingBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static XmlEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(XmlEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.XmlEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.JsonEncodingBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.JsonEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.JsonEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class JsonEncodingBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static JsonEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(JsonEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.JsonEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.WsProtocolBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.WsProtocolBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WsProtocolBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.ProtocolBindingElement) })]
		public static class WsProtocolBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static WsProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WsProtocolBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.WsProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Modeling.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Internal.WsAddressingBindingElementId), typeof(global::MetaDslx.Languages.Soal.Symbols.WsAddressingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WsAddressingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.WsProtocolBindingElement) })]
		public static class WsAddressingBindingElement
		{
			private static global::MetaDslx.Modeling.ModelSymbolInfo modelSymbolInfo;
		
			static WsAddressingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Modeling.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WsAddressingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.WsAddressingBindingElement; }
			}
		}
	}
}

namespace MetaDslx.Languages.Soal.Symbols.Internal
{
	
	internal class AnnotatedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotatedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotatedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotatedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, AnnotatedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
	
		internal AnnotatedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.AnnotatedElement; }
		}
	
		public new AnnotatedElementBuilder ToMutable()
		{
			return (AnnotatedElementBuilder)base.ToMutable();
		}
	
		public new AnnotatedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotatedElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class AnnotatedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, AnnotatedElementBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal AnnotatedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.AnnotatedElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.AnnotatedElement; }
		}
	
		public new AnnotatedElement ToImmutable()
		{
			return (AnnotatedElement)base.ToImmutable();
		}
	
		public new AnnotatedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (AnnotatedElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class AnnotationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Annotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> properties0;
	
		internal AnnotationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Annotation; }
		}
	
		public new AnnotationBuilder ToMutable()
		{
			return (AnnotationBuilder)base.ToMutable();
		}
	
		public new AnnotationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotationBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<AnnotationProperty> Properties
		{
		    get { return this.GetList<AnnotationProperty>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class AnnotationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, AnnotationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> properties0;
	
		internal AnnotationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Annotation(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Annotation; }
		}
	
		public new Annotation ToImmutable()
		{
			return (Annotation)base.ToImmutable();
		}
	
		public new Annotation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Annotation)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationPropertyBuilder> Properties
		{
			get { return this.GetList<AnnotationPropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class AnnotationPropertyId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AnnotationPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AnnotationPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationPropertyImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, AnnotationProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object value0;
	
		internal AnnotationPropertyImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.AnnotationProperty; }
		}
	
		public new AnnotationPropertyBuilder ToMutable()
		{
			return (AnnotationPropertyBuilder)base.ToMutable();
		}
	
		public new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AnnotationPropertyBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public object Value
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.ValueProperty, ref value0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class AnnotationPropertyBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, AnnotationPropertyBuilder
	{
	
		internal AnnotationPropertyBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.AnnotationProperty(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.AnnotationProperty; }
		}
	
		public new AnnotationProperty ToImmutable()
		{
			return (AnnotationProperty)base.ToImmutable();
		}
	
		public new AnnotationProperty ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (AnnotationProperty)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public object Value
		{
			get { return this.GetReference<object>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.ValueProperty); }
			set { this.SetReference<object>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.ValueProperty, value); }
		}
		
		public Func<object> ValueLazy
		{
			get { return this.GetLazyReference<object>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.ValueProperty); }
			set { this.SetLazyReference(SoalDescriptor.AnnotationProperty.ValueProperty, value); }
		}
	}
	
	internal class DocumentedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DocumentedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DocumentedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class DocumentedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, DocumentedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
	
		internal DocumentedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.DocumentedElement; }
		}
	
		public new DocumentedElementBuilder ToMutable()
		{
			return (DocumentedElementBuilder)base.ToMutable();
		}
	
		public new DocumentedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DocumentedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class DocumentedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DocumentedElementBuilder
	{
	
		internal DocumentedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.DocumentedElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.DocumentedElement; }
		}
	
		public new DocumentedElement ToImmutable()
		{
			return (DocumentedElement)base.ToImmutable();
		}
	
		public new DocumentedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (DocumentedElement)base.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	}
	
	internal class NamedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, NamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NamedElement; }
		}
	
		public new NamedElementBuilder ToMutable()
		{
			return (NamedElementBuilder)base.ToMutable();
		}
	
		public new NamedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamedElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class NamedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, NamedElementBuilder
	{
	
		internal NamedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.NamedElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NamedElement; }
		}
	
		public new NamedElement ToImmutable()
		{
			return (NamedElement)base.ToImmutable();
		}
	
		public new NamedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NamedElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class TypedElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class TypedElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, TypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
	
		internal TypedElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.TypedElement; }
		}
	
		public new TypedElementBuilder ToMutable()
		{
			return (TypedElementBuilder)base.ToMutable();
		}
	
		public new TypedElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TypedElementBuilder)base.ToMutable(model);
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class TypedElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, TypedElementBuilder
	{
	
		internal TypedElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.TypedElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.TypedElement; }
		}
	
		public new TypedElement ToImmutable()
		{
			return (TypedElement)base.ToImmutable();
		}
	
		public new TypedElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TypedElement)base.ToImmutable(model);
		}
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	}
	
	internal class SoalTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoalType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SoalTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SoalTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class SoalTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, SoalType
	{
	
		internal SoalTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.SoalType; }
		}
	
		public new SoalTypeBuilder ToMutable()
		{
			return (SoalTypeBuilder)base.ToMutable();
		}
	
		public new SoalTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SoalTypeBuilder)base.ToMutable(model);
		}
	}
	
	internal class SoalTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, SoalTypeBuilder
	{
	
		internal SoalTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.SoalType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.SoalType; }
		}
	
		public new SoalType ToImmutable()
		{
			return (SoalType)base.ToImmutable();
		}
	
		public new SoalType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (SoalType)base.ToImmutable(model);
		}
	}
	
	internal class NamedTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamedTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamedTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamedTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, NamedType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamedTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NamedType; }
		}
	
		public new NamedTypeBuilder ToMutable()
		{
			return (NamedTypeBuilder)base.ToMutable();
		}
	
		public new NamedTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamedTypeBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class NamedTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, NamedTypeBuilder
	{
	
		internal NamedTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.NamedType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NamedType; }
		}
	
		public new NamedType ToImmutable()
		{
			return (NamedType)base.ToImmutable();
		}
	
		public new NamedType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NamedType)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class DeclarationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeclarationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Declaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
	
		internal DeclarationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Declaration; }
		}
	
		public new DeclarationBuilder ToMutable()
		{
			return (DeclarationBuilder)base.ToMutable();
		}
	
		public new DeclarationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DeclarationBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DeclarationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal DeclarationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Declaration(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Declaration; }
		}
	
		public new Declaration ToImmutable()
		{
			return (Declaration)base.ToImmutable();
		}
	
		public new Declaration ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Declaration)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	}
	
	internal class NamespaceId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamespaceImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Namespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string prefix0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Declaration> declarations0;
	
		internal NamespaceImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Namespace; }
		}
	
		public new NamespaceBuilder ToMutable()
		{
			return (NamespaceBuilder)base.ToMutable();
		}
	
		public new NamespaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NamespaceBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.UriProperty, ref uri0); }
		}
	
		
		public string Prefix
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.PrefixProperty, ref prefix0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class NamespaceBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, NamespaceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> declarations0;
	
		internal NamespaceBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Namespace(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Namespace; }
		}
	
		public new Namespace ToImmutable()
		{
			return (Namespace)base.ToImmutable();
		}
	
		public new Namespace ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Namespace)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public string Uri
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.UriProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.UriProperty, value); }
		}
		
		public Func<string> UriLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.UriProperty); }
			set { this.SetLazyReference(SoalDescriptor.Namespace.UriProperty, value); }
		}
	
		
		public string Prefix
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.PrefixProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.PrefixProperty, value); }
		}
		
		public Func<string> PrefixLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.PrefixProperty); }
			set { this.SetLazyReference(SoalDescriptor.Namespace.PrefixProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class ArrayTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ArrayTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ArrayTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class ArrayTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, ArrayType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal ArrayTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ArrayType; }
		}
	
		public new ArrayTypeBuilder ToMutable()
		{
			return (ArrayTypeBuilder)base.ToMutable();
		}
	
		public new ArrayTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ArrayTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class ArrayTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ArrayTypeBuilder
	{
	
		internal ArrayTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.ArrayType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ArrayType; }
		}
	
		public new ArrayType ToImmutable()
		{
			return (ArrayType)base.ToImmutable();
		}
	
		public new ArrayType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ArrayType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SoalTypeBuilder InnerType
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.InnerTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.InnerTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.InnerTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.ArrayType.InnerTypeProperty, value); }
		}
	}
	
	internal class NullableTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class NullableTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, NullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal NullableTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NullableType; }
		}
	
		public new NullableTypeBuilder ToMutable()
		{
			return (NullableTypeBuilder)base.ToMutable();
		}
	
		public new NullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NullableTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class NullableTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, NullableTypeBuilder
	{
	
		internal NullableTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.NullableType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NullableType; }
		}
	
		public new NullableType ToImmutable()
		{
			return (NullableType)base.ToImmutable();
		}
	
		public new NullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NullableType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SoalTypeBuilder InnerType
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.InnerTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.InnerTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.InnerTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.NullableType.InnerTypeProperty, value); }
		}
	}
	
	internal class NonNullableTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new NonNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new NonNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class NonNullableTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, NonNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal NonNullableTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NonNullableType; }
		}
	
		public new NonNullableTypeBuilder ToMutable()
		{
			return (NonNullableTypeBuilder)base.ToMutable();
		}
	
		public new NonNullableTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (NonNullableTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class NonNullableTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, NonNullableTypeBuilder
	{
	
		internal NonNullableTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.NonNullableType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.NonNullableType; }
		}
	
		public new NonNullableType ToImmutable()
		{
			return (NonNullableType)base.ToImmutable();
		}
	
		public new NonNullableType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (NonNullableType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public SoalTypeBuilder InnerType
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.InnerTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.InnerTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.InnerTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.NonNullableType.InnerTypeProperty, value); }
		}
	}
	
	internal class PrimitiveTypeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new PrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new PrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class PrimitiveTypeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, PrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool nullable0;
	
		internal PrimitiveTypeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.PrimitiveType; }
		}
	
		public new PrimitiveTypeBuilder ToMutable()
		{
			return (PrimitiveTypeBuilder)base.ToMutable();
		}
	
		public new PrimitiveTypeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (PrimitiveTypeBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public bool Nullable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.NullableProperty, ref nullable0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class PrimitiveTypeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, PrimitiveTypeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal PrimitiveTypeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.PrimitiveType(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.PrimitiveType; }
		}
	
		public new PrimitiveType ToImmutable()
		{
			return (PrimitiveType)base.ToImmutable();
		}
	
		public new PrimitiveType ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (PrimitiveType)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public bool Nullable
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.NullableProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.NullableProperty, value); }
		}
		
		public Func<bool> NullableLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.NullableProperty); }
			set { this.SetLazyValue(SoalDescriptor.PrimitiveType.NullableProperty, value); }
		}
	}
	
	internal class EnumId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EnumImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnumImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Enum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Enum baseType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EnumLiteral> enumLiterals0;
	
		internal EnumImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Enum; }
		}
	
		public new EnumBuilder ToMutable()
		{
			return (EnumBuilder)base.ToMutable();
		}
	
		public new EnumBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EnumBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Enum BaseType
		{
		    get { return this.GetReference<Enum>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.BaseTypeProperty, ref baseType0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EnumLiteral> EnumLiterals
		{
		    get { return this.GetList<EnumLiteral>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class EnumBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, EnumBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<EnumLiteralBuilder> enumLiterals0;
	
		internal EnumBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Enum(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Enum; }
		}
	
		public new Enum ToImmutable()
		{
			return (Enum)base.ToImmutable();
		}
	
		public new Enum ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Enum)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public EnumBuilder BaseType
		{
			get { return this.GetReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.BaseTypeProperty); }
			set { this.SetReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.BaseTypeProperty, value); }
		}
		
		public Func<EnumBuilder> BaseTypeLazy
		{
			get { return this.GetLazyReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.BaseTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Enum.BaseTypeProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<EnumLiteralBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	}
	
	internal class EnumLiteralId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnumLiteralImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, EnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Enum enum0;
	
		internal EnumLiteralImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.EnumLiteral; }
		}
	
		public new EnumLiteralBuilder ToMutable()
		{
			return (EnumLiteralBuilder)base.ToMutable();
		}
	
		public new EnumLiteralBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EnumLiteralBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Enum Enum
		{
		    get { return this.GetReference<Enum>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.EnumProperty, ref enum0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class EnumLiteralBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, EnumLiteralBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal EnumLiteralBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.EnumLiteral(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.EnumLiteral; }
		}
	
		public new EnumLiteral ToImmutable()
		{
			return (EnumLiteral)base.ToImmutable();
		}
	
		public new EnumLiteral ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EnumLiteral)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public EnumBuilder Enum
		{
			get { return this.GetReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.EnumProperty); }
			set { this.SetReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.EnumProperty, value); }
		}
		
		public Func<EnumBuilder> EnumLazy
		{
			get { return this.GetLazyReference<EnumBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.EnumProperty); }
			set { this.SetLazyReference(SoalDescriptor.EnumLiteral.EnumProperty, value); }
		}
	}
	
	internal class PropertyId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Property.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new PropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new PropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class PropertyImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Property
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal PropertyImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Property; }
		}
	
		public new PropertyBuilder ToMutable()
		{
			return (PropertyBuilder)base.ToMutable();
		}
	
		public new PropertyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (PropertyBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class PropertyBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, PropertyBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal PropertyBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Property(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Property; }
		}
	
		public new Property ToImmutable()
		{
			return (Property)base.ToImmutable();
		}
	
		public new Property ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Property)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class StructId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new StructImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new StructBuilderImpl(this, model, creating);
		}
	}
	
	internal class StructImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Struct
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Struct baseType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Property> properties0;
	
		internal StructImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Struct; }
		}
	
		public new StructBuilder ToMutable()
		{
			return (StructBuilder)base.ToMutable();
		}
	
		public new StructBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (StructBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Struct BaseType
		{
		    get { return this.GetReference<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.BaseTypeProperty, ref baseType0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.PropertiesProperty, ref properties0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class StructBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, StructBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> properties0;
	
		internal StructBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Struct(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Struct; }
		}
	
		public new Struct ToImmutable()
		{
			return (Struct)base.ToImmutable();
		}
	
		public new Struct ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Struct)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public StructBuilder BaseType
		{
			get { return this.GetReference<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.BaseTypeProperty); }
			set { this.SetReference<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.BaseTypeProperty, value); }
		}
		
		public Func<StructBuilder> BaseTypeLazy
		{
			get { return this.GetLazyReference<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.BaseTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Struct.BaseTypeProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class InterfaceId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new InterfaceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new InterfaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class InterfaceImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Interface
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Operation> operations0;
	
		internal InterfaceImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Interface; }
		}
	
		public new InterfaceBuilder ToMutable()
		{
			return (InterfaceBuilder)base.ToMutable();
		}
	
		public new InterfaceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (InterfaceBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class InterfaceBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, InterfaceBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<OperationBuilder> operations0;
	
		internal InterfaceBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Interface(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Interface; }
		}
	
		public new Interface ToImmutable()
		{
			return (Interface)base.ToImmutable();
		}
	
		public new Interface ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Interface)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	}
	
	internal class DatabaseId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DatabaseImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DatabaseBuilderImpl(this, model, creating);
		}
	}
	
	internal class DatabaseImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Database
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Operation> operations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Struct> entities0;
	
		internal DatabaseImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Database; }
		}
	
		public new DatabaseBuilder ToMutable()
		{
			return (DatabaseBuilder)base.ToMutable();
		}
	
		public new DatabaseBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DatabaseBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		InterfaceBuilder Interface.ToMutable()
		{
			return this.ToMutable();
		}
	
		InterfaceBuilder Interface.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Struct> Entities
		{
		    get { return this.GetList<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class DatabaseBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DatabaseBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<OperationBuilder> operations0;
		private global::MetaDslx.Modeling.MutableModelList<StructBuilder> entities0;
	
		internal DatabaseBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Database(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Database; }
		}
	
		public new Database ToImmutable()
		{
			return (Database)base.ToImmutable();
		}
	
		public new Database ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Database)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Interface InterfaceBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Interface InterfaceBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<StructBuilder> Entities
		{
			get { return this.GetList<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	}
	
	internal class OperationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new OperationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new OperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class OperationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Operation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string action0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<InputParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OutputParameter result0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Struct> exceptions0;
	
		internal OperationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Operation; }
		}
	
		public new OperationBuilder ToMutable()
		{
			return (OperationBuilder)base.ToMutable();
		}
	
		public new OperationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (OperationBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public string Action
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ActionProperty, ref action0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<InputParameter> Parameters
		{
		    get { return this.GetList<InputParameter>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public OutputParameter Result
		{
		    get { return this.GetReference<OutputParameter>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty, ref result0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Struct> Exceptions
		{
		    get { return this.GetList<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class OperationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, OperationBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<InputParameterBuilder> parameters0;
		private global::MetaDslx.Modeling.MutableModelList<StructBuilder> exceptions0;
	
		internal OperationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Operation(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Operation; }
		}
	
		public new Operation ToImmutable()
		{
			return (Operation)base.ToImmutable();
		}
	
		public new Operation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Operation)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public string Action
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ActionProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ActionProperty, value); }
		}
		
		public Func<string> ActionLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ActionProperty); }
			set { this.SetLazyReference(SoalDescriptor.Operation.ActionProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<InputParameterBuilder> Parameters
		{
			get { return this.GetList<InputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public OutputParameterBuilder Result
		{
			get { return this.GetReference<OutputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty); }
			set { this.SetReference<OutputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty, value); }
		}
		
		public Func<OutputParameterBuilder> ResultLazy
		{
			get { return this.GetLazyReference<OutputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty); }
			set { this.SetLazyReference(SoalDescriptor.Operation.ResultProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<StructBuilder> Exceptions
		{
			get { return this.GetList<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	}
	
	internal class InputParameterId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.InputParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new InputParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new InputParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class InputParameterImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, InputParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal InputParameterImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.InputParameter; }
		}
	
		public new InputParameterBuilder ToMutable()
		{
			return (InputParameterBuilder)base.ToMutable();
		}
	
		public new InputParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (InputParameterBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class InputParameterBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, InputParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal InputParameterBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.InputParameter(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.InputParameter; }
		}
	
		public new InputParameter ToImmutable()
		{
			return (InputParameter)base.ToImmutable();
		}
	
		public new InputParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (InputParameter)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class OutputParameterId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new OutputParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new OutputParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class OutputParameterImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, OutputParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isOneway0;
	
		internal OutputParameterImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.OutputParameter; }
		}
	
		public new OutputParameterBuilder ToMutable()
		{
			return (OutputParameterBuilder)base.ToMutable();
		}
	
		public new OutputParameterBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (OutputParameterBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public bool IsOneway
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.IsOnewayProperty, ref isOneway0); }
		}
	}
	
	internal class OutputParameterBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, OutputParameterBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal OutputParameterBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.OutputParameter(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.OutputParameter; }
		}
	
		public new OutputParameter ToImmutable()
		{
			return (OutputParameter)base.ToImmutable();
		}
	
		public new OutputParameter ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (OutputParameter)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public bool IsOneway
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.IsOnewayProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.IsOnewayProperty, value); }
		}
		
		public Func<bool> IsOnewayLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.IsOnewayProperty); }
			set { this.SetLazyValue(SoalDescriptor.OutputParameter.IsOnewayProperty, value); }
		}
	}
	
	internal class ComponentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ComponentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ComponentBuilderImpl(this, model, creating);
		}
	}
	
	internal class ComponentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Component
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ProgrammingLanguage language0;
	
		internal ComponentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Component; }
		}
	
		public new ComponentBuilder ToMutable()
		{
			return (ComponentBuilder)base.ToMutable();
		}
	
		public new ComponentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ComponentBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public ProgrammingLanguage Language
		{
		    get { return this.GetReference<ProgrammingLanguage>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ComponentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ComponentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> properties0;
	
		internal ComponentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Component(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Component; }
		}
	
		public new Component ToImmutable()
		{
			return (Component)base.ToImmutable();
		}
	
		public new Component ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Component)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public ProgrammingLanguageBuilder Language
		{
			get { return this.GetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<ProgrammingLanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	}
	
	internal class CompositeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new CompositeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new CompositeBuilderImpl(this, model, creating);
		}
	}
	
	internal class CompositeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Composite
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ProgrammingLanguage language0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Component> components0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Wire> wires0;
	
		internal CompositeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Composite; }
		}
	
		public new CompositeBuilder ToMutable()
		{
			return (CompositeBuilder)base.ToMutable();
		}
	
		public new CompositeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (CompositeBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ComponentBuilder Component.ToMutable()
		{
			return this.ToMutable();
		}
	
		ComponentBuilder Component.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public ProgrammingLanguage Language
		{
		    get { return this.GetReference<ProgrammingLanguage>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class CompositeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, CompositeBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Modeling.MutableModelList<ComponentBuilder> components0;
		private global::MetaDslx.Modeling.MutableModelList<WireBuilder> wires0;
	
		internal CompositeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Composite(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Composite; }
		}
	
		public new Composite ToImmutable()
		{
			return (Composite)base.ToImmutable();
		}
	
		public new Composite ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Composite)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Component ComponentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Component ComponentBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public ProgrammingLanguageBuilder Language
		{
			get { return this.GetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<ProgrammingLanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class AssemblyId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Assembly.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new AssemblyImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new AssemblyBuilderImpl(this, model, creating);
		}
	}
	
	internal class AssemblyImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Assembly
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ProgrammingLanguage language0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Component> components0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Wire> wires0;
	
		internal AssemblyImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Assembly; }
		}
	
		public new AssemblyBuilder ToMutable()
		{
			return (AssemblyBuilder)base.ToMutable();
		}
	
		public new AssemblyBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (AssemblyBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ComponentBuilder Component.ToMutable()
		{
			return this.ToMutable();
		}
	
		ComponentBuilder Component.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		CompositeBuilder Composite.ToMutable()
		{
			return this.ToMutable();
		}
	
		CompositeBuilder Composite.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public ProgrammingLanguage Language
		{
		    get { return this.GetReference<ProgrammingLanguage>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class AssemblyBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, AssemblyBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Modeling.MutableModelList<ComponentBuilder> components0;
		private global::MetaDslx.Modeling.MutableModelList<WireBuilder> wires0;
	
		internal AssemblyBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Assembly(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Assembly; }
		}
	
		public new Assembly ToImmutable()
		{
			return (Assembly)base.ToImmutable();
		}
	
		public new Assembly ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Assembly)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Component ComponentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Component ComponentBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Composite CompositeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Composite CompositeBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public ProgrammingLanguageBuilder Language
		{
			get { return this.GetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<ProgrammingLanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<ProgrammingLanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class WireId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new WireImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new WireBuilderImpl(this, model, creating);
		}
	}
	
	internal class WireImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Wire
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Port source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Port target0;
	
		internal WireImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Wire; }
		}
	
		public new WireBuilder ToMutable()
		{
			return (WireBuilder)base.ToMutable();
		}
	
		public new WireBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (WireBuilder)base.ToMutable(model);
		}
	
		
		public Port Source
		{
		    get { return this.GetReference<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SourceProperty, ref source0); }
		}
	
		
		public Port Target
		{
		    get { return this.GetReference<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.TargetProperty, ref target0); }
		}
	}
	
	internal class WireBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, WireBuilder
	{
	
		internal WireBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Wire(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Wire; }
		}
	
		public new Wire ToImmutable()
		{
			return (Wire)base.ToImmutable();
		}
	
		public new Wire ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Wire)base.ToImmutable(model);
		}
	
		
		public PortBuilder Source
		{
			get { return this.GetReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SourceProperty); }
			set { this.SetReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SourceProperty, value); }
		}
		
		public Func<PortBuilder> SourceLazy
		{
			get { return this.GetLazyReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SourceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Wire.SourceProperty, value); }
		}
	
		
		public PortBuilder Target
		{
			get { return this.GetReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.TargetProperty); }
			set { this.SetReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.TargetProperty, value); }
		}
		
		public Func<PortBuilder> TargetLazy
		{
			get { return this.GetLazyReference<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.TargetProperty); }
			set { this.SetLazyReference(SoalDescriptor.Wire.TargetProperty, value); }
		}
	}
	
	internal class PortId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new PortImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new PortBuilderImpl(this, model, creating);
		}
	}
	
	internal class PortImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Port
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal PortImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Port; }
		}
	
		public new PortBuilder ToMutable()
		{
			return (PortBuilder)base.ToMutable();
		}
	
		public new PortBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (PortBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class PortBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, PortBuilder
	{
	
		internal PortBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Port(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Port; }
		}
	
		public new Port ToImmutable()
		{
			return (Port)base.ToImmutable();
		}
	
		public new Port ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Port)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public ComponentBuilder Component
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> ComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.ComponentProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.BindingProperty, value); }
		}
	}
	
	internal class ServiceId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Service.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ServiceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ServiceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ServiceImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Service
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal ServiceImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Service; }
		}
	
		public new ServiceBuilder ToMutable()
		{
			return (ServiceBuilder)base.ToMutable();
		}
	
		public new ServiceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ServiceBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		PortBuilder Port.ToMutable()
		{
			return this.ToMutable();
		}
	
		PortBuilder Port.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ServiceBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ServiceBuilder
	{
	
		internal ServiceBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Service(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Service; }
		}
	
		public new Service ToImmutable()
		{
			return (Service)base.ToImmutable();
		}
	
		public new Service ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Service)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Port PortBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Port PortBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public ComponentBuilder Component
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> ComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.ComponentProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.BindingProperty, value); }
		}
	}
	
	internal class ReferenceId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Reference.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ReferenceImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Reference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal ReferenceImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Reference; }
		}
	
		public new ReferenceBuilder ToMutable()
		{
			return (ReferenceBuilder)base.ToMutable();
		}
	
		public new ReferenceBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ReferenceBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		PortBuilder Port.ToMutable()
		{
			return this.ToMutable();
		}
	
		PortBuilder Port.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ReferenceBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ReferenceBuilder
	{
	
		internal ReferenceBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Reference(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Reference; }
		}
	
		public new Reference ToImmutable()
		{
			return (Reference)base.ToImmutable();
		}
	
		public new Reference ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Reference)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Port PortBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Port PortBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public ComponentBuilder Component
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> ComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.ComponentProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.BindingProperty, value); }
		}
	}
	
	internal class ImplementationId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Implementation.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ImplementationImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ImplementationBuilderImpl(this, model, creating);
		}
	}
	
	internal class ImplementationImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Implementation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ImplementationImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Implementation; }
		}
	
		public new ImplementationBuilder ToMutable()
		{
			return (ImplementationBuilder)base.ToMutable();
		}
	
		public new ImplementationBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ImplementationBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ImplementationBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ImplementationBuilder
	{
	
		internal ImplementationBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Implementation(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Implementation; }
		}
	
		public new Implementation ToImmutable()
		{
			return (Implementation)base.ToImmutable();
		}
	
		public new Implementation ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Implementation)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class ProgrammingLanguageId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ProgrammingLanguage.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ProgrammingLanguageImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ProgrammingLanguageBuilderImpl(this, model, creating);
		}
	}
	
	internal class ProgrammingLanguageImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, ProgrammingLanguage
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ProgrammingLanguageImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ProgrammingLanguage; }
		}
	
		public new ProgrammingLanguageBuilder ToMutable()
		{
			return (ProgrammingLanguageBuilder)base.ToMutable();
		}
	
		public new ProgrammingLanguageBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ProgrammingLanguageBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ProgrammingLanguageBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ProgrammingLanguageBuilder
	{
	
		internal ProgrammingLanguageBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.ProgrammingLanguage(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ProgrammingLanguage; }
		}
	
		public new ProgrammingLanguage ToImmutable()
		{
			return (ProgrammingLanguage)base.ToImmutable();
		}
	
		public new ProgrammingLanguage ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ProgrammingLanguage)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class DeploymentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new DeploymentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new DeploymentBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeploymentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Deployment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Environment> environments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Wire> wires0;
	
		internal DeploymentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Deployment; }
		}
	
		public new DeploymentBuilder ToMutable()
		{
			return (DeploymentBuilder)base.ToMutable();
		}
	
		public new DeploymentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (DeploymentBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Environment> Environments
		{
		    get { return this.GetList<Environment>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class DeploymentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, DeploymentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<EnvironmentBuilder> environments0;
		private global::MetaDslx.Modeling.MutableModelList<WireBuilder> wires0;
	
		internal DeploymentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Deployment(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Deployment; }
		}
	
		public new Deployment ToImmutable()
		{
			return (Deployment)base.ToImmutable();
		}
	
		public new Deployment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Deployment)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EnvironmentBuilder> Environments
		{
			get { return this.GetList<EnvironmentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	}
	
	internal class EnvironmentId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EnvironmentImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EnvironmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnvironmentImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Environment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Runtime runtime0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Interface> databases0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Assembly> assemblies0;
	
		internal EnvironmentImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Environment; }
		}
	
		public new EnvironmentBuilder ToMutable()
		{
			return (EnvironmentBuilder)base.ToMutable();
		}
	
		public new EnvironmentBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EnvironmentBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Runtime Runtime
		{
		    get { return this.GetReference<Runtime>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.RuntimeProperty, ref runtime0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Interface> Databases
		{
		    get { return this.GetList<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Assembly> Assemblies
		{
		    get { return this.GetList<Assembly>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class EnvironmentBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, EnvironmentBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<InterfaceBuilder> databases0;
		private global::MetaDslx.Modeling.MutableModelList<AssemblyBuilder> assemblies0;
	
		internal EnvironmentBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Environment(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Environment; }
		}
	
		public new Environment ToImmutable()
		{
			return (Environment)base.ToImmutable();
		}
	
		public new Environment ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Environment)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public RuntimeBuilder Runtime
		{
			get { return this.GetReference<RuntimeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.RuntimeProperty); }
			set { this.SetReference<RuntimeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.RuntimeProperty, value); }
		}
		
		public Func<RuntimeBuilder> RuntimeLazy
		{
			get { return this.GetLazyReference<RuntimeBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.RuntimeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Environment.RuntimeProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<InterfaceBuilder> Databases
		{
			get { return this.GetList<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AssemblyBuilder> Assemblies
		{
			get { return this.GetList<AssemblyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
		}
	}
	
	internal class RuntimeId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Runtime.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RuntimeImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RuntimeBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuntimeImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Runtime
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal RuntimeImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Runtime; }
		}
	
		public new RuntimeBuilder ToMutable()
		{
			return (RuntimeBuilder)base.ToMutable();
		}
	
		public new RuntimeBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RuntimeBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class RuntimeBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, RuntimeBuilder
	{
	
		internal RuntimeBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Runtime(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Runtime; }
		}
	
		public new Runtime ToImmutable()
		{
			return (Runtime)base.ToImmutable();
		}
	
		public new Runtime ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Runtime)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class BindingId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new BindingImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new BindingBuilderImpl(this, model, creating);
		}
	}
	
	internal class BindingImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Binding
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TransportBindingElement transport0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<EncodingBindingElement> encodings0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<ProtocolBindingElement> protocols0;
	
		internal BindingImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Binding; }
		}
	
		public new BindingBuilder ToMutable()
		{
			return (BindingBuilder)base.ToMutable();
		}
	
		public new BindingBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (BindingBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public TransportBindingElement Transport
		{
		    get { return this.GetReference<TransportBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.TransportProperty, ref transport0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<EncodingBindingElement> Encodings
		{
		    get { return this.GetList<EncodingBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<ProtocolBindingElement> Protocols
		{
		    get { return this.GetList<ProtocolBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class BindingBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, BindingBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Modeling.MutableModelList<EncodingBindingElementBuilder> encodings0;
		private global::MetaDslx.Modeling.MutableModelList<ProtocolBindingElementBuilder> protocols0;
	
		internal BindingBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Binding(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Binding; }
		}
	
		public new Binding ToImmutable()
		{
			return (Binding)base.ToImmutable();
		}
	
		public new Binding ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Binding)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public TransportBindingElementBuilder Transport
		{
			get { return this.GetReference<TransportBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.TransportProperty); }
			set { this.SetReference<TransportBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.TransportProperty, value); }
		}
		
		public Func<TransportBindingElementBuilder> TransportLazy
		{
			get { return this.GetLazyReference<TransportBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.TransportProperty); }
			set { this.SetLazyReference(SoalDescriptor.Binding.TransportProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<EncodingBindingElementBuilder> Encodings
		{
			get { return this.GetList<EncodingBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<ProtocolBindingElementBuilder> Protocols
		{
			get { return this.GetList<ProtocolBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	}
	
	internal class EndpointId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EndpointImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EndpointBuilderImpl(this, model, creating);
		}
	}
	
	internal class EndpointImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, Endpoint
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Modeling.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string address0;
	
		internal EndpointImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Endpoint; }
		}
	
		public new EndpointBuilder ToMutable()
		{
			return (EndpointBuilder)base.ToMutable();
		}
	
		public new EndpointBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EndpointBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public global::MetaDslx.Modeling.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty, ref fullName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.BindingProperty, ref binding0); }
		}
	
		
		public string Address
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.AddressProperty, ref address0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class EndpointBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, EndpointBuilder
	{
		private global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> annotations0;
	
		internal EndpointBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Endpoint(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Endpoint; }
		}
	
		public new Endpoint ToImmutable()
		{
			return (Endpoint)base.ToImmutable();
		}
	
		public new Endpoint ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (Endpoint)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public global::MetaDslx.Modeling.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.FullNameProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.BindingProperty, value); }
		}
	
		
		public string Address
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.AddressProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.AddressProperty, value); }
		}
		
		public Func<string> AddressLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.AddressProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.AddressProperty, value); }
		}
	}
	
	internal class BindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.BindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new BindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new BindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class BindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, BindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal BindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.BindingElement; }
		}
	
		public new BindingElementBuilder ToMutable()
		{
			return (BindingElementBuilder)base.ToMutable();
		}
	
		public new BindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (BindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class BindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, BindingElementBuilder
	{
	
		internal BindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.BindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.BindingElement; }
		}
	
		public new BindingElement ToImmutable()
		{
			return (BindingElement)base.ToImmutable();
		}
	
		public new BindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (BindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class TransportBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new TransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new TransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class TransportBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, TransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal TransportBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.TransportBindingElement; }
		}
	
		public new TransportBindingElementBuilder ToMutable()
		{
			return (TransportBindingElementBuilder)base.ToMutable();
		}
	
		public new TransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (TransportBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class TransportBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, TransportBindingElementBuilder
	{
	
		internal TransportBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.TransportBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.TransportBindingElement; }
		}
	
		public new TransportBindingElement ToImmutable()
		{
			return (TransportBindingElement)base.ToImmutable();
		}
	
		public new TransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (TransportBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class EncodingBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new EncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new EncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class EncodingBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, EncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal EncodingBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.EncodingBindingElement; }
		}
	
		public new EncodingBindingElementBuilder ToMutable()
		{
			return (EncodingBindingElementBuilder)base.ToMutable();
		}
	
		public new EncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (EncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class EncodingBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, EncodingBindingElementBuilder
	{
	
		internal EncodingBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.EncodingBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.EncodingBindingElement; }
		}
	
		public new EncodingBindingElement ToImmutable()
		{
			return (EncodingBindingElement)base.ToImmutable();
		}
	
		public new EncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (EncodingBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class ProtocolBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ProtocolBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new ProtocolBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new ProtocolBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ProtocolBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, ProtocolBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ProtocolBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ProtocolBindingElement; }
		}
	
		public new ProtocolBindingElementBuilder ToMutable()
		{
			return (ProtocolBindingElementBuilder)base.ToMutable();
		}
	
		public new ProtocolBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (ProtocolBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class ProtocolBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, ProtocolBindingElementBuilder
	{
	
		internal ProtocolBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.ProtocolBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.ProtocolBindingElement; }
		}
	
		public new ProtocolBindingElement ToImmutable()
		{
			return (ProtocolBindingElement)base.ToImmutable();
		}
	
		public new ProtocolBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (ProtocolBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class HttpTransportBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new HttpTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new HttpTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class HttpTransportBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, HttpTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ssl0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool clientAuthentication0;
	
		internal HttpTransportBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.HttpTransportBindingElement; }
		}
	
		public new HttpTransportBindingElementBuilder ToMutable()
		{
			return (HttpTransportBindingElementBuilder)base.ToMutable();
		}
	
		public new HttpTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (HttpTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public bool Ssl
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SslProperty, ref ssl0); }
		}
	
		
		public bool ClientAuthentication
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty, ref clientAuthentication0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class HttpTransportBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, HttpTransportBindingElementBuilder
	{
	
		internal HttpTransportBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.HttpTransportBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.HttpTransportBindingElement; }
		}
	
		public new HttpTransportBindingElement ToImmutable()
		{
			return (HttpTransportBindingElement)base.ToImmutable();
		}
	
		public new HttpTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (HttpTransportBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public bool Ssl
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SslProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SslProperty, value); }
		}
		
		public Func<bool> SslLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SslProperty); }
			set { this.SetLazyValue(SoalDescriptor.HttpTransportBindingElement.SslProperty, value); }
		}
	
		
		public bool ClientAuthentication
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty, value); }
		}
		
		public Func<bool> ClientAuthenticationLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty); }
			set { this.SetLazyValue(SoalDescriptor.HttpTransportBindingElement.ClientAuthenticationProperty, value); }
		}
	}
	
	internal class RestTransportBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.RestTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new RestTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new RestTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class RestTransportBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, RestTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal RestTransportBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.RestTransportBindingElement; }
		}
	
		public new RestTransportBindingElementBuilder ToMutable()
		{
			return (RestTransportBindingElementBuilder)base.ToMutable();
		}
	
		public new RestTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (RestTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class RestTransportBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, RestTransportBindingElementBuilder
	{
	
		internal RestTransportBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.RestTransportBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.RestTransportBindingElement; }
		}
	
		public new RestTransportBindingElement ToImmutable()
		{
			return (RestTransportBindingElement)base.ToImmutable();
		}
	
		public new RestTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (RestTransportBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WebSocketTransportBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WebSocketTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new WebSocketTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new WebSocketTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WebSocketTransportBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, WebSocketTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WebSocketTransportBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WebSocketTransportBindingElement; }
		}
	
		public new WebSocketTransportBindingElementBuilder ToMutable()
		{
			return (WebSocketTransportBindingElementBuilder)base.ToMutable();
		}
	
		public new WebSocketTransportBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (WebSocketTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class WebSocketTransportBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, WebSocketTransportBindingElementBuilder
	{
	
		internal WebSocketTransportBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.WebSocketTransportBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WebSocketTransportBindingElement; }
		}
	
		public new WebSocketTransportBindingElement ToImmutable()
		{
			return (WebSocketTransportBindingElement)base.ToImmutable();
		}
	
		public new WebSocketTransportBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (WebSocketTransportBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class SoapEncodingBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new SoapEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new SoapEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class SoapEncodingBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, SoapEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoapEncodingStyle style0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoapVersion version0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool mtom0;
	
		internal SoapEncodingBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.SoapEncodingBindingElement; }
		}
	
		public new SoapEncodingBindingElementBuilder ToMutable()
		{
			return (SoapEncodingBindingElementBuilder)base.ToMutable();
		}
	
		public new SoapEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (SoapEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SoapEncodingStyle Style
		{
		    get { return this.GetValue<SoapEncodingStyle>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.StyleProperty, ref style0); }
		}
	
		
		public SoapVersion Version
		{
		    get { return this.GetValue<SoapVersion>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.VersionProperty, ref version0); }
		}
	
		
		public bool Mtom
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.MtomProperty, ref mtom0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class SoapEncodingBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, SoapEncodingBindingElementBuilder
	{
	
		internal SoapEncodingBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.SoapEncodingBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.SoapEncodingBindingElement; }
		}
	
		public new SoapEncodingBindingElement ToImmutable()
		{
			return (SoapEncodingBindingElement)base.ToImmutable();
		}
	
		public new SoapEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (SoapEncodingBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public SoapEncodingStyle Style
		{
			get { return this.GetValue<SoapEncodingStyle>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.StyleProperty); }
			set { this.SetValue<SoapEncodingStyle>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.StyleProperty, value); }
		}
		
		public Func<SoapEncodingStyle> StyleLazy
		{
			get { return this.GetLazyValue<SoapEncodingStyle>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.StyleProperty); }
			set { this.SetLazyValue(SoalDescriptor.SoapEncodingBindingElement.StyleProperty, value); }
		}
	
		
		public SoapVersion Version
		{
			get { return this.GetValue<SoapVersion>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.VersionProperty); }
			set { this.SetValue<SoapVersion>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.VersionProperty, value); }
		}
		
		public Func<SoapVersion> VersionLazy
		{
			get { return this.GetLazyValue<SoapVersion>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.VersionProperty); }
			set { this.SetLazyValue(SoalDescriptor.SoapEncodingBindingElement.VersionProperty, value); }
		}
	
		
		public bool Mtom
		{
			get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.MtomProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.MtomProperty, value); }
		}
		
		public Func<bool> MtomLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.MtomProperty); }
			set { this.SetLazyValue(SoalDescriptor.SoapEncodingBindingElement.MtomProperty, value); }
		}
	}
	
	internal class XmlEncodingBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.XmlEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new XmlEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new XmlEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class XmlEncodingBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, XmlEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal XmlEncodingBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.XmlEncodingBindingElement; }
		}
	
		public new XmlEncodingBindingElementBuilder ToMutable()
		{
			return (XmlEncodingBindingElementBuilder)base.ToMutable();
		}
	
		public new XmlEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (XmlEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class XmlEncodingBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, XmlEncodingBindingElementBuilder
	{
	
		internal XmlEncodingBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.XmlEncodingBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.XmlEncodingBindingElement; }
		}
	
		public new XmlEncodingBindingElement ToImmutable()
		{
			return (XmlEncodingBindingElement)base.ToImmutable();
		}
	
		public new XmlEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (XmlEncodingBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class JsonEncodingBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.JsonEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new JsonEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new JsonEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class JsonEncodingBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, JsonEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal JsonEncodingBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.JsonEncodingBindingElement; }
		}
	
		public new JsonEncodingBindingElementBuilder ToMutable()
		{
			return (JsonEncodingBindingElementBuilder)base.ToMutable();
		}
	
		public new JsonEncodingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (JsonEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class JsonEncodingBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, JsonEncodingBindingElementBuilder
	{
	
		internal JsonEncodingBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.JsonEncodingBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.JsonEncodingBindingElement; }
		}
	
		public new JsonEncodingBindingElement ToImmutable()
		{
			return (JsonEncodingBindingElement)base.ToImmutable();
		}
	
		public new JsonEncodingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (JsonEncodingBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WsProtocolBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WsProtocolBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new WsProtocolBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new WsProtocolBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WsProtocolBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, WsProtocolBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WsProtocolBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WsProtocolBindingElement; }
		}
	
		public new WsProtocolBindingElementBuilder ToMutable()
		{
			return (WsProtocolBindingElementBuilder)base.ToMutable();
		}
	
		public new WsProtocolBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (WsProtocolBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class WsProtocolBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, WsProtocolBindingElementBuilder
	{
	
		internal WsProtocolBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.WsProtocolBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WsProtocolBindingElement; }
		}
	
		public new WsProtocolBindingElement ToImmutable()
		{
			return (WsProtocolBindingElement)base.ToImmutable();
		}
	
		public new WsProtocolBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (WsProtocolBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WsAddressingBindingElementId : global::MetaDslx.Modeling.SymbolId
	{
		public override global::MetaDslx.Modeling.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WsAddressingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Modeling.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return new WsAddressingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Modeling.MutableSymbolBase CreateMutable(global::MetaDslx.Modeling.MutableModel model, bool creating)
		{
			return new WsAddressingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WsAddressingBindingElementImpl : global::MetaDslx.Modeling.ImmutableSymbolBase, WsAddressingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string documentation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WsAddressingBindingElementImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WsAddressingBindingElement; }
		}
	
		public new WsAddressingBindingElementBuilder ToMutable()
		{
			return (WsAddressingBindingElementBuilder)base.ToMutable();
		}
	
		public new WsAddressingBindingElementBuilder ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return (WsAddressingBindingElementBuilder)base.ToMutable(model);
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		DocumentedElementBuilder DocumentedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		WsProtocolBindingElementBuilder WsProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		WsProtocolBindingElementBuilder WsProtocolBindingElement.ToMutable(global::MetaDslx.Modeling.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Documentation
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, ref documentation0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement.GetDocumentationLines()
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.DocumentedElement_GetDocumentationLines(this);
		}
	}
	
	internal class WsAddressingBindingElementBuilderImpl : global::MetaDslx.Modeling.MutableSymbolBase, WsAddressingBindingElementBuilder
	{
	
		internal WsAddressingBindingElementBuilderImpl(global::MetaDslx.Modeling.SymbolId id, global::MetaDslx.Modeling.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.WsAddressingBindingElement(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.WsAddressingBindingElement; }
		}
	
		public new WsAddressingBindingElement ToImmutable()
		{
			return (WsAddressingBindingElement)base.ToImmutable();
		}
	
		public new WsAddressingBindingElement ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return (WsAddressingBindingElement)base.ToImmutable(model);
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		DocumentedElement DocumentedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		WsProtocolBindingElement WsProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		WsProtocolBindingElement WsProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Modeling.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Documentation
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
		
		public Func<string> DocumentationLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.DocumentedElement.DocumentationProperty); }
			set { this.SetLazyReference(SoalDescriptor.DocumentedElement.DocumentationProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}

	internal class SoalBuilderInstance
	{
		internal static SoalBuilderInstance instance = new SoalBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Modeling.MutableModel Model;
		internal global::MetaDslx.Modeling.MutableModelGroup ModelGroup;
	
		internal PrimitiveTypeBuilder Object = null;
		internal PrimitiveTypeBuilder String = null;
		internal PrimitiveTypeBuilder Int = null;
		internal PrimitiveTypeBuilder Long = null;
		internal PrimitiveTypeBuilder Float = null;
		internal PrimitiveTypeBuilder Double = null;
		internal PrimitiveTypeBuilder Byte = null;
		internal PrimitiveTypeBuilder Bool = null;
		internal PrimitiveTypeBuilder Void = null;
		internal PrimitiveTypeBuilder Date = null;
		internal PrimitiveTypeBuilder Time = null;
		internal PrimitiveTypeBuilder DateTime = null;
		internal PrimitiveTypeBuilder TimeSpan = null;
	
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp3;
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp4;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp6;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp7;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp8;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp9;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp10;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp11;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp12;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp13;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp14;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp15;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp16;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp17;
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp18;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder AnnotatedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder AnnotatedElement_Annotations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Annotation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Annotation_Properties;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder AnnotationProperty;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder AnnotationProperty_Value;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder DocumentedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder DocumentedElement_Documentation;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp21;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NamedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NamedElement_Name;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TypedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder TypedElement_Type;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder SoalType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NamedType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Declaration;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Declaration_Namespace;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Declaration_FullName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Namespace;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Uri;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Prefix;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Declarations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ArrayType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ArrayType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NullableType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NullableType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NonNullableType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NonNullableType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder PrimitiveType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder PrimitiveType_Nullable;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Enum;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Enum_BaseType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Enum_EnumLiterals;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder EnumLiteral;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder EnumLiteral_Enum;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Property;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Struct;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Struct_BaseType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Struct_Properties;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Interface_Operations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Database;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Database_Entities;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Operation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Action;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Parameters;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Result;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Exceptions;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder InputParameter;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder OutputParameter;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder OutputParameter_IsOneway;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Component;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_BaseComponent;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_IsAbstract;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Ports;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Services;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_References;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Properties;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Implementation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Language;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Composite;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Composite_Components;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Composite_Wires;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Assembly;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Wire;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Wire_Source;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Wire_Target;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Port;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Component;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Binding;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Service;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Reference;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Implementation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ProgrammingLanguage;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Deployment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Deployment_Environments;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Deployment_Wires;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Environment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Runtime;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Databases;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Assemblies;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Runtime;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Binding;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Transport;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Encodings;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Protocols;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Endpoint;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Binding;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Address;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder BindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder EncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ProtocolBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder HttpTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder HttpTransportBindingElement_Ssl;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder HttpTransportBindingElement_ClientAuthentication;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder RestTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WebSocketTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder SoapVersion;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp42;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp43;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder SoapEncodingStyle;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp44;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp45;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp46;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp47;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder SoapEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Style;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Version;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Mtom;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder XmlEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder JsonEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WsProtocolBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WsAddressingBindingElement;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp19;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp22;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp28;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp29;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp30;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp31;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp32;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp33;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp34;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp35;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp36;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp37;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp38;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp39;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp40;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp41;
	
		internal SoalBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Modeling.MutableModelGroup();
			this.ModelGroup.AddReference(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Model.ToMutable(true));
			this.Model = this.ModelGroup.CreateModel("Soal");
		}
	
		internal void Create()
		{
			lock (this)
			{
				if (this.creating || this.created) return;
				this.creating = true;
			}
			SoalImplementationProvider.Implementation.SoalBuilderInstance(this);
			this.CreateSymbols();
			lock (this)
			{
				this.created = true;
			}
		}
	
		internal void EvaluateLazyValues()
		{
			if (!this.created) return;
			this.Model.EvaluateLazyValues();
		}
	
		private void CreateSymbols()
		{
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaModel();
			MetaModel = __tmp5;
			__tmp6 = factory.MetaConstant();
			__tmp7 = factory.MetaConstant();
			__tmp8 = factory.MetaConstant();
			__tmp9 = factory.MetaConstant();
			__tmp10 = factory.MetaConstant();
			__tmp11 = factory.MetaConstant();
			__tmp12 = factory.MetaConstant();
			__tmp13 = factory.MetaConstant();
			__tmp14 = factory.MetaConstant();
			__tmp15 = factory.MetaConstant();
			__tmp16 = factory.MetaConstant();
			__tmp17 = factory.MetaConstant();
			__tmp18 = factory.MetaConstant();
			AnnotatedElement = factory.MetaClass();
			AnnotatedElement_Annotations = factory.MetaProperty();
			Annotation = factory.MetaClass();
			Annotation_Properties = factory.MetaProperty();
			AnnotationProperty = factory.MetaClass();
			AnnotationProperty_Value = factory.MetaProperty();
			DocumentedElement = factory.MetaClass();
			DocumentedElement_Documentation = factory.MetaProperty();
			__tmp21 = factory.MetaOperation();
			NamedElement = factory.MetaClass();
			NamedElement_Name = factory.MetaProperty();
			TypedElement = factory.MetaClass();
			TypedElement_Type = factory.MetaProperty();
			SoalType = factory.MetaClass();
			NamedType = factory.MetaClass();
			Declaration = factory.MetaClass();
			Declaration_Namespace = factory.MetaProperty();
			Declaration_FullName = factory.MetaProperty();
			Namespace = factory.MetaClass();
			Namespace_Uri = factory.MetaProperty();
			Namespace_Prefix = factory.MetaProperty();
			Namespace_Declarations = factory.MetaProperty();
			ArrayType = factory.MetaClass();
			ArrayType_InnerType = factory.MetaProperty();
			NullableType = factory.MetaClass();
			NullableType_InnerType = factory.MetaProperty();
			NonNullableType = factory.MetaClass();
			NonNullableType_InnerType = factory.MetaProperty();
			PrimitiveType = factory.MetaClass();
			PrimitiveType_Nullable = factory.MetaProperty();
			Enum = factory.MetaClass();
			Enum_BaseType = factory.MetaProperty();
			Enum_EnumLiterals = factory.MetaProperty();
			EnumLiteral = factory.MetaClass();
			EnumLiteral_Enum = factory.MetaProperty();
			Property = factory.MetaClass();
			Struct = factory.MetaClass();
			Struct_BaseType = factory.MetaProperty();
			Struct_Properties = factory.MetaProperty();
			Interface = factory.MetaClass();
			Interface_Operations = factory.MetaProperty();
			Database = factory.MetaClass();
			Database_Entities = factory.MetaProperty();
			Operation = factory.MetaClass();
			Operation_Action = factory.MetaProperty();
			Operation_Parameters = factory.MetaProperty();
			Operation_Result = factory.MetaProperty();
			Operation_Exceptions = factory.MetaProperty();
			InputParameter = factory.MetaClass();
			OutputParameter = factory.MetaClass();
			OutputParameter_IsOneway = factory.MetaProperty();
			Component = factory.MetaClass();
			Component_BaseComponent = factory.MetaProperty();
			Component_IsAbstract = factory.MetaProperty();
			Component_Ports = factory.MetaProperty();
			Component_Services = factory.MetaProperty();
			Component_References = factory.MetaProperty();
			Component_Properties = factory.MetaProperty();
			Component_Implementation = factory.MetaProperty();
			Component_Language = factory.MetaProperty();
			Composite = factory.MetaClass();
			Composite_Components = factory.MetaProperty();
			Composite_Wires = factory.MetaProperty();
			Assembly = factory.MetaClass();
			Wire = factory.MetaClass();
			Wire_Source = factory.MetaProperty();
			Wire_Target = factory.MetaProperty();
			Port = factory.MetaClass();
			Port_Component = factory.MetaProperty();
			Port_Interface = factory.MetaProperty();
			Port_Binding = factory.MetaProperty();
			Service = factory.MetaClass();
			Reference = factory.MetaClass();
			Implementation = factory.MetaClass();
			ProgrammingLanguage = factory.MetaClass();
			Deployment = factory.MetaClass();
			Deployment_Environments = factory.MetaProperty();
			Deployment_Wires = factory.MetaProperty();
			Environment = factory.MetaClass();
			Environment_Runtime = factory.MetaProperty();
			Environment_Databases = factory.MetaProperty();
			Environment_Assemblies = factory.MetaProperty();
			Runtime = factory.MetaClass();
			Binding = factory.MetaClass();
			Binding_Transport = factory.MetaProperty();
			Binding_Encodings = factory.MetaProperty();
			Binding_Protocols = factory.MetaProperty();
			Endpoint = factory.MetaClass();
			Endpoint_Interface = factory.MetaProperty();
			Endpoint_Binding = factory.MetaProperty();
			Endpoint_Address = factory.MetaProperty();
			BindingElement = factory.MetaClass();
			TransportBindingElement = factory.MetaClass();
			EncodingBindingElement = factory.MetaClass();
			ProtocolBindingElement = factory.MetaClass();
			HttpTransportBindingElement = factory.MetaClass();
			HttpTransportBindingElement_Ssl = factory.MetaProperty();
			HttpTransportBindingElement_ClientAuthentication = factory.MetaProperty();
			RestTransportBindingElement = factory.MetaClass();
			WebSocketTransportBindingElement = factory.MetaClass();
			SoapVersion = factory.MetaEnum();
			__tmp42 = factory.MetaEnumLiteral();
			__tmp43 = factory.MetaEnumLiteral();
			SoapEncodingStyle = factory.MetaEnum();
			__tmp44 = factory.MetaEnumLiteral();
			__tmp45 = factory.MetaEnumLiteral();
			__tmp46 = factory.MetaEnumLiteral();
			__tmp47 = factory.MetaEnumLiteral();
			SoapEncodingBindingElement = factory.MetaClass();
			SoapEncodingBindingElement_Style = factory.MetaProperty();
			SoapEncodingBindingElement_Version = factory.MetaProperty();
			SoapEncodingBindingElement_Mtom = factory.MetaProperty();
			XmlEncodingBindingElement = factory.MetaClass();
			JsonEncodingBindingElement = factory.MetaClass();
			WsProtocolBindingElement = factory.MetaClass();
			WsAddressingBindingElement = factory.MetaClass();
			__tmp19 = factory.MetaCollectionType();
			__tmp20 = factory.MetaCollectionType();
			__tmp22 = factory.MetaCollectionType();
			__tmp23 = factory.MetaCollectionType();
			__tmp24 = factory.MetaCollectionType();
			__tmp25 = factory.MetaCollectionType();
			__tmp26 = factory.MetaCollectionType();
			__tmp27 = factory.MetaCollectionType();
			__tmp28 = factory.MetaCollectionType();
			__tmp29 = factory.MetaCollectionType();
			__tmp30 = factory.MetaCollectionType();
			__tmp31 = factory.MetaCollectionType();
			__tmp32 = factory.MetaCollectionType();
			__tmp33 = factory.MetaCollectionType();
			__tmp34 = factory.MetaCollectionType();
			__tmp35 = factory.MetaCollectionType();
			__tmp36 = factory.MetaCollectionType();
			__tmp37 = factory.MetaCollectionType();
			__tmp38 = factory.MetaCollectionType();
			__tmp39 = factory.MetaCollectionType();
			__tmp40 = factory.MetaCollectionType();
			__tmp41 = factory.MetaCollectionType();
	
			// __tmp1.MetaModel = null;
			// __tmp1.Namespace = null;
			__tmp1.Documentation = null;
			__tmp1.Name = "MetaDslx";
			// __tmp1.DefinedMetaModel = null;
			__tmp1.Declarations.AddLazy(() => __tmp2);
			// __tmp2.MetaModel = null;
			__tmp2.NamespaceLazy = () => __tmp1;
			__tmp2.Documentation = null;
			__tmp2.Name = "Languages";
			// __tmp2.DefinedMetaModel = null;
			__tmp2.Declarations.AddLazy(() => __tmp3);
			// __tmp3.MetaModel = null;
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp3.Documentation = null;
			__tmp3.Name = "Soal";
			// __tmp3.DefinedMetaModel = null;
			__tmp3.Declarations.AddLazy(() => __tmp4);
			// __tmp4.MetaModel = null;
			__tmp4.NamespaceLazy = () => __tmp3;
			__tmp4.Documentation = null;
			__tmp4.Name = "Symbols";
			__tmp4.DefinedMetaModelLazy = () => __tmp5;
			__tmp4.Declarations.AddLazy(() => __tmp6);
			__tmp4.Declarations.AddLazy(() => __tmp7);
			__tmp4.Declarations.AddLazy(() => __tmp8);
			__tmp4.Declarations.AddLazy(() => __tmp9);
			__tmp4.Declarations.AddLazy(() => __tmp10);
			__tmp4.Declarations.AddLazy(() => __tmp11);
			__tmp4.Declarations.AddLazy(() => __tmp12);
			__tmp4.Declarations.AddLazy(() => __tmp13);
			__tmp4.Declarations.AddLazy(() => __tmp14);
			__tmp4.Declarations.AddLazy(() => __tmp15);
			__tmp4.Declarations.AddLazy(() => __tmp16);
			__tmp4.Declarations.AddLazy(() => __tmp17);
			__tmp4.Declarations.AddLazy(() => __tmp18);
			__tmp4.Declarations.AddLazy(() => AnnotatedElement);
			__tmp4.Declarations.AddLazy(() => Annotation);
			__tmp4.Declarations.AddLazy(() => AnnotationProperty);
			__tmp4.Declarations.AddLazy(() => DocumentedElement);
			__tmp4.Declarations.AddLazy(() => NamedElement);
			__tmp4.Declarations.AddLazy(() => TypedElement);
			__tmp4.Declarations.AddLazy(() => SoalType);
			__tmp4.Declarations.AddLazy(() => NamedType);
			__tmp4.Declarations.AddLazy(() => Declaration);
			__tmp4.Declarations.AddLazy(() => Namespace);
			__tmp4.Declarations.AddLazy(() => ArrayType);
			__tmp4.Declarations.AddLazy(() => NullableType);
			__tmp4.Declarations.AddLazy(() => NonNullableType);
			__tmp4.Declarations.AddLazy(() => PrimitiveType);
			__tmp4.Declarations.AddLazy(() => Enum);
			__tmp4.Declarations.AddLazy(() => EnumLiteral);
			__tmp4.Declarations.AddLazy(() => Property);
			__tmp4.Declarations.AddLazy(() => Struct);
			__tmp4.Declarations.AddLazy(() => Interface);
			__tmp4.Declarations.AddLazy(() => Database);
			__tmp4.Declarations.AddLazy(() => Operation);
			__tmp4.Declarations.AddLazy(() => InputParameter);
			__tmp4.Declarations.AddLazy(() => OutputParameter);
			__tmp4.Declarations.AddLazy(() => Component);
			__tmp4.Declarations.AddLazy(() => Composite);
			__tmp4.Declarations.AddLazy(() => Assembly);
			__tmp4.Declarations.AddLazy(() => Wire);
			__tmp4.Declarations.AddLazy(() => Port);
			__tmp4.Declarations.AddLazy(() => Service);
			__tmp4.Declarations.AddLazy(() => Reference);
			__tmp4.Declarations.AddLazy(() => Implementation);
			__tmp4.Declarations.AddLazy(() => ProgrammingLanguage);
			__tmp4.Declarations.AddLazy(() => Deployment);
			__tmp4.Declarations.AddLazy(() => Environment);
			__tmp4.Declarations.AddLazy(() => Runtime);
			__tmp4.Declarations.AddLazy(() => Binding);
			__tmp4.Declarations.AddLazy(() => Endpoint);
			__tmp4.Declarations.AddLazy(() => BindingElement);
			__tmp4.Declarations.AddLazy(() => TransportBindingElement);
			__tmp4.Declarations.AddLazy(() => EncodingBindingElement);
			__tmp4.Declarations.AddLazy(() => ProtocolBindingElement);
			__tmp4.Declarations.AddLazy(() => HttpTransportBindingElement);
			__tmp4.Declarations.AddLazy(() => RestTransportBindingElement);
			__tmp4.Declarations.AddLazy(() => WebSocketTransportBindingElement);
			__tmp4.Declarations.AddLazy(() => SoapVersion);
			__tmp4.Declarations.AddLazy(() => SoapEncodingStyle);
			__tmp4.Declarations.AddLazy(() => SoapEncodingBindingElement);
			__tmp4.Declarations.AddLazy(() => XmlEncodingBindingElement);
			__tmp4.Declarations.AddLazy(() => JsonEncodingBindingElement);
			__tmp4.Declarations.AddLazy(() => WsProtocolBindingElement);
			__tmp4.Declarations.AddLazy(() => WsAddressingBindingElement);
			__tmp5.Name = "Soal";
			__tmp5.Documentation = null;
			__tmp5.Uri = "http://MetaDslx.Languages.Soal/1.0";
			__tmp5.NamespaceLazy = () => __tmp4;
			__tmp6.TypeLazy = () => PrimitiveType;
			__tmp6.MetaModelLazy = () => __tmp5;
			__tmp6.NamespaceLazy = () => __tmp4;
			__tmp6.Documentation = null;
			__tmp6.Name = "Object";
			__tmp7.TypeLazy = () => PrimitiveType;
			__tmp7.MetaModelLazy = () => __tmp5;
			__tmp7.NamespaceLazy = () => __tmp4;
			__tmp7.Documentation = null;
			__tmp7.Name = "String";
			__tmp8.TypeLazy = () => PrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp5;
			__tmp8.NamespaceLazy = () => __tmp4;
			__tmp8.Documentation = null;
			__tmp8.Name = "Int";
			__tmp9.TypeLazy = () => PrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp5;
			__tmp9.NamespaceLazy = () => __tmp4;
			__tmp9.Documentation = null;
			__tmp9.Name = "Long";
			__tmp10.TypeLazy = () => PrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp5;
			__tmp10.NamespaceLazy = () => __tmp4;
			__tmp10.Documentation = null;
			__tmp10.Name = "Float";
			__tmp11.TypeLazy = () => PrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp5;
			__tmp11.NamespaceLazy = () => __tmp4;
			__tmp11.Documentation = null;
			__tmp11.Name = "Double";
			__tmp12.TypeLazy = () => PrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp5;
			__tmp12.NamespaceLazy = () => __tmp4;
			__tmp12.Documentation = null;
			__tmp12.Name = "Byte";
			__tmp13.TypeLazy = () => PrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp5;
			__tmp13.NamespaceLazy = () => __tmp4;
			__tmp13.Documentation = null;
			__tmp13.Name = "Bool";
			__tmp14.TypeLazy = () => PrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp5;
			__tmp14.NamespaceLazy = () => __tmp4;
			__tmp14.Documentation = null;
			__tmp14.Name = "Void";
			__tmp15.TypeLazy = () => PrimitiveType;
			__tmp15.MetaModelLazy = () => __tmp5;
			__tmp15.NamespaceLazy = () => __tmp4;
			__tmp15.Documentation = null;
			__tmp15.Name = "Date";
			__tmp16.TypeLazy = () => PrimitiveType;
			__tmp16.MetaModelLazy = () => __tmp5;
			__tmp16.NamespaceLazy = () => __tmp4;
			__tmp16.Documentation = null;
			__tmp16.Name = "Time";
			__tmp17.TypeLazy = () => PrimitiveType;
			__tmp17.MetaModelLazy = () => __tmp5;
			__tmp17.NamespaceLazy = () => __tmp4;
			__tmp17.Documentation = null;
			__tmp17.Name = "DateTime";
			__tmp18.TypeLazy = () => PrimitiveType;
			__tmp18.MetaModelLazy = () => __tmp5;
			__tmp18.NamespaceLazy = () => __tmp4;
			__tmp18.Documentation = null;
			__tmp18.Name = "TimeSpan";
			AnnotatedElement.MetaModelLazy = () => __tmp5;
			AnnotatedElement.NamespaceLazy = () => __tmp4;
			AnnotatedElement.Documentation = null;
			AnnotatedElement.Name = "AnnotatedElement";
			AnnotatedElement.IsAbstract = true;
			AnnotatedElement.Properties.AddLazy(() => AnnotatedElement_Annotations);
			AnnotatedElement_Annotations.TypeLazy = () => __tmp19;
			AnnotatedElement_Annotations.Name = "Annotations";
			AnnotatedElement_Annotations.Documentation = null;
			AnnotatedElement_Annotations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			AnnotatedElement_Annotations.ClassLazy = () => AnnotatedElement;
			Annotation.MetaModelLazy = () => __tmp5;
			Annotation.NamespaceLazy = () => __tmp4;
			Annotation.Documentation = null;
			Annotation.Name = "Annotation";
			// Annotation.IsAbstract = null;
			Annotation.SuperClasses.AddLazy(() => NamedElement);
			Annotation.Properties.AddLazy(() => Annotation_Properties);
			Annotation_Properties.TypeLazy = () => __tmp20;
			Annotation_Properties.Name = "Properties";
			Annotation_Properties.Documentation = null;
			Annotation_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Annotation_Properties.ClassLazy = () => Annotation;
			AnnotationProperty.MetaModelLazy = () => __tmp5;
			AnnotationProperty.NamespaceLazy = () => __tmp4;
			AnnotationProperty.Documentation = null;
			AnnotationProperty.Name = "AnnotationProperty";
			// AnnotationProperty.IsAbstract = null;
			AnnotationProperty.SuperClasses.AddLazy(() => NamedElement);
			AnnotationProperty.Properties.AddLazy(() => AnnotationProperty_Value);
			AnnotationProperty_Value.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Object.ToMutable();
			AnnotationProperty_Value.Name = "Value";
			AnnotationProperty_Value.Documentation = null;
			// AnnotationProperty_Value.Kind = null;
			AnnotationProperty_Value.ClassLazy = () => AnnotationProperty;
			DocumentedElement.MetaModelLazy = () => __tmp5;
			DocumentedElement.NamespaceLazy = () => __tmp4;
			DocumentedElement.Documentation = null;
			DocumentedElement.Name = "DocumentedElement";
			DocumentedElement.IsAbstract = true;
			DocumentedElement.Properties.AddLazy(() => DocumentedElement_Documentation);
			DocumentedElement.Operations.AddLazy(() => __tmp21);
			DocumentedElement_Documentation.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			DocumentedElement_Documentation.Name = "Documentation";
			DocumentedElement_Documentation.Documentation = null;
			// DocumentedElement_Documentation.Kind = null;
			DocumentedElement_Documentation.ClassLazy = () => DocumentedElement;
			__tmp21.Name = "GetDocumentationLines";
			__tmp21.Documentation = null;
			__tmp21.ParentLazy = () => DocumentedElement;
			__tmp21.ReturnTypeLazy = () => __tmp22;
			NamedElement.MetaModelLazy = () => __tmp5;
			NamedElement.NamespaceLazy = () => __tmp4;
			NamedElement.Documentation = null;
			NamedElement.Name = "NamedElement";
			NamedElement.IsAbstract = true;
			NamedElement.SuperClasses.AddLazy(() => DocumentedElement);
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			NamedElement_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			NamedElement_Name.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.NameAttribute.ToMutable());
			NamedElement_Name.Name = "Name";
			NamedElement_Name.Documentation = null;
			// NamedElement_Name.Kind = null;
			NamedElement_Name.ClassLazy = () => NamedElement;
			TypedElement.MetaModelLazy = () => __tmp5;
			TypedElement.NamespaceLazy = () => __tmp4;
			TypedElement.Documentation = null;
			TypedElement.Name = "TypedElement";
			TypedElement.IsAbstract = true;
			TypedElement.Properties.AddLazy(() => TypedElement_Type);
			TypedElement_Type.TypeLazy = () => SoalType;
			TypedElement_Type.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.TypeAttribute.ToMutable());
			TypedElement_Type.Name = "Type";
			TypedElement_Type.Documentation = null;
			// TypedElement_Type.Kind = null;
			TypedElement_Type.ClassLazy = () => TypedElement;
			TypedElement_Type.RedefiningProperties.AddLazy(() => EnumLiteral_Enum);
			SoalType.MetaModelLazy = () => __tmp5;
			SoalType.NamespaceLazy = () => __tmp4;
			SoalType.Documentation = null;
			SoalType.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.TypeAttribute.ToMutable());
			SoalType.Name = "SoalType";
			SoalType.IsAbstract = true;
			NamedType.MetaModelLazy = () => __tmp5;
			NamedType.NamespaceLazy = () => __tmp4;
			NamedType.Documentation = null;
			NamedType.Name = "NamedType";
			// NamedType.IsAbstract = null;
			NamedType.SuperClasses.AddLazy(() => SoalType);
			NamedType.SuperClasses.AddLazy(() => NamedElement);
			Declaration.MetaModelLazy = () => __tmp5;
			Declaration.NamespaceLazy = () => __tmp4;
			Declaration.Documentation = null;
			Declaration.Name = "Declaration";
			Declaration.IsAbstract = true;
			Declaration.SuperClasses.AddLazy(() => NamedElement);
			Declaration.SuperClasses.AddLazy(() => AnnotatedElement);
			Declaration.Properties.AddLazy(() => Declaration_Namespace);
			Declaration.Properties.AddLazy(() => Declaration_FullName);
			Declaration_Namespace.TypeLazy = () => Namespace;
			Declaration_Namespace.Name = "Namespace";
			Declaration_Namespace.Documentation = null;
			// Declaration_Namespace.Kind = null;
			Declaration_Namespace.ClassLazy = () => Declaration;
			Declaration_Namespace.OppositeProperties.AddLazy(() => Namespace_Declarations);
			Declaration_FullName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Declaration_FullName.Name = "FullName";
			Declaration_FullName.Documentation = null;
			Declaration_FullName.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			Declaration_FullName.ClassLazy = () => Declaration;
			Namespace.MetaModelLazy = () => __tmp5;
			Namespace.NamespaceLazy = () => __tmp4;
			Namespace.Documentation = null;
			Namespace.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Namespace.Name = "Namespace";
			// Namespace.IsAbstract = null;
			Namespace.SuperClasses.AddLazy(() => Declaration);
			Namespace.Properties.AddLazy(() => Namespace_Uri);
			Namespace.Properties.AddLazy(() => Namespace_Prefix);
			Namespace.Properties.AddLazy(() => Namespace_Declarations);
			Namespace_Uri.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Namespace_Uri.Name = "Uri";
			Namespace_Uri.Documentation = null;
			// Namespace_Uri.Kind = null;
			Namespace_Uri.ClassLazy = () => Namespace;
			Namespace_Prefix.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Namespace_Prefix.Name = "Prefix";
			Namespace_Prefix.Documentation = null;
			// Namespace_Prefix.Kind = null;
			Namespace_Prefix.ClassLazy = () => Namespace;
			Namespace_Declarations.TypeLazy = () => __tmp23;
			Namespace_Declarations.Name = "Declarations";
			Namespace_Declarations.Documentation = null;
			Namespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Namespace_Declarations.ClassLazy = () => Namespace;
			Namespace_Declarations.OppositeProperties.AddLazy(() => Declaration_Namespace);
			ArrayType.MetaModelLazy = () => __tmp5;
			ArrayType.NamespaceLazy = () => __tmp4;
			ArrayType.Documentation = null;
			ArrayType.Name = "ArrayType";
			// ArrayType.IsAbstract = null;
			ArrayType.SuperClasses.AddLazy(() => SoalType);
			ArrayType.Properties.AddLazy(() => ArrayType_InnerType);
			ArrayType_InnerType.TypeLazy = () => SoalType;
			ArrayType_InnerType.Name = "InnerType";
			ArrayType_InnerType.Documentation = null;
			// ArrayType_InnerType.Kind = null;
			ArrayType_InnerType.ClassLazy = () => ArrayType;
			NullableType.MetaModelLazy = () => __tmp5;
			NullableType.NamespaceLazy = () => __tmp4;
			NullableType.Documentation = null;
			NullableType.Name = "NullableType";
			// NullableType.IsAbstract = null;
			NullableType.SuperClasses.AddLazy(() => SoalType);
			NullableType.Properties.AddLazy(() => NullableType_InnerType);
			NullableType_InnerType.TypeLazy = () => SoalType;
			NullableType_InnerType.Name = "InnerType";
			NullableType_InnerType.Documentation = null;
			// NullableType_InnerType.Kind = null;
			NullableType_InnerType.ClassLazy = () => NullableType;
			NonNullableType.MetaModelLazy = () => __tmp5;
			NonNullableType.NamespaceLazy = () => __tmp4;
			NonNullableType.Documentation = null;
			NonNullableType.Name = "NonNullableType";
			// NonNullableType.IsAbstract = null;
			NonNullableType.SuperClasses.AddLazy(() => SoalType);
			NonNullableType.Properties.AddLazy(() => NonNullableType_InnerType);
			NonNullableType_InnerType.TypeLazy = () => SoalType;
			NonNullableType_InnerType.Name = "InnerType";
			NonNullableType_InnerType.Documentation = null;
			// NonNullableType_InnerType.Kind = null;
			NonNullableType_InnerType.ClassLazy = () => NonNullableType;
			PrimitiveType.MetaModelLazy = () => __tmp5;
			PrimitiveType.NamespaceLazy = () => __tmp4;
			PrimitiveType.Documentation = null;
			PrimitiveType.Name = "PrimitiveType";
			// PrimitiveType.IsAbstract = null;
			PrimitiveType.SuperClasses.AddLazy(() => SoalType);
			PrimitiveType.SuperClasses.AddLazy(() => Declaration);
			PrimitiveType.Properties.AddLazy(() => PrimitiveType_Nullable);
			PrimitiveType_Nullable.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			PrimitiveType_Nullable.Name = "Nullable";
			PrimitiveType_Nullable.Documentation = null;
			// PrimitiveType_Nullable.Kind = null;
			PrimitiveType_Nullable.ClassLazy = () => PrimitiveType;
			Enum.MetaModelLazy = () => __tmp5;
			Enum.NamespaceLazy = () => __tmp4;
			Enum.Documentation = null;
			Enum.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Enum.Name = "Enum";
			// Enum.IsAbstract = null;
			Enum.SuperClasses.AddLazy(() => SoalType);
			Enum.SuperClasses.AddLazy(() => Declaration);
			Enum.Properties.AddLazy(() => Enum_BaseType);
			Enum.Properties.AddLazy(() => Enum_EnumLiterals);
			Enum_BaseType.TypeLazy = () => Enum;
			Enum_BaseType.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.BaseScopeAttribute.ToMutable());
			Enum_BaseType.Name = "BaseType";
			Enum_BaseType.Documentation = null;
			// Enum_BaseType.Kind = null;
			Enum_BaseType.ClassLazy = () => Enum;
			Enum_EnumLiterals.TypeLazy = () => __tmp24;
			Enum_EnumLiterals.Name = "EnumLiterals";
			Enum_EnumLiterals.Documentation = null;
			Enum_EnumLiterals.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Enum_EnumLiterals.ClassLazy = () => Enum;
			Enum_EnumLiterals.OppositeProperties.AddLazy(() => EnumLiteral_Enum);
			EnumLiteral.MetaModelLazy = () => __tmp5;
			EnumLiteral.NamespaceLazy = () => __tmp4;
			EnumLiteral.Documentation = null;
			EnumLiteral.Name = "EnumLiteral";
			// EnumLiteral.IsAbstract = null;
			EnumLiteral.SuperClasses.AddLazy(() => NamedElement);
			EnumLiteral.SuperClasses.AddLazy(() => TypedElement);
			EnumLiteral.SuperClasses.AddLazy(() => AnnotatedElement);
			EnumLiteral.Properties.AddLazy(() => EnumLiteral_Enum);
			EnumLiteral_Enum.TypeLazy = () => Enum;
			EnumLiteral_Enum.Name = "Enum";
			EnumLiteral_Enum.Documentation = null;
			// EnumLiteral_Enum.Kind = null;
			EnumLiteral_Enum.ClassLazy = () => EnumLiteral;
			EnumLiteral_Enum.OppositeProperties.AddLazy(() => Enum_EnumLiterals);
			EnumLiteral_Enum.RedefinedProperties.AddLazy(() => TypedElement_Type);
			Property.MetaModelLazy = () => __tmp5;
			Property.NamespaceLazy = () => __tmp4;
			Property.Documentation = null;
			Property.Name = "Property";
			// Property.IsAbstract = null;
			Property.SuperClasses.AddLazy(() => NamedElement);
			Property.SuperClasses.AddLazy(() => TypedElement);
			Property.SuperClasses.AddLazy(() => AnnotatedElement);
			Struct.MetaModelLazy = () => __tmp5;
			Struct.NamespaceLazy = () => __tmp4;
			Struct.Documentation = null;
			Struct.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Struct.Name = "Struct";
			// Struct.IsAbstract = null;
			Struct.SuperClasses.AddLazy(() => SoalType);
			Struct.SuperClasses.AddLazy(() => Declaration);
			Struct.Properties.AddLazy(() => Struct_BaseType);
			Struct.Properties.AddLazy(() => Struct_Properties);
			Struct_BaseType.TypeLazy = () => Struct;
			Struct_BaseType.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.BaseScopeAttribute.ToMutable());
			Struct_BaseType.Name = "BaseType";
			Struct_BaseType.Documentation = null;
			// Struct_BaseType.Kind = null;
			Struct_BaseType.ClassLazy = () => Struct;
			Struct_Properties.TypeLazy = () => __tmp25;
			Struct_Properties.Name = "Properties";
			Struct_Properties.Documentation = null;
			Struct_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Struct_Properties.ClassLazy = () => Struct;
			Interface.MetaModelLazy = () => __tmp5;
			Interface.NamespaceLazy = () => __tmp4;
			Interface.Documentation = null;
			Interface.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Interface.Name = "Interface";
			// Interface.IsAbstract = null;
			Interface.SuperClasses.AddLazy(() => SoalType);
			Interface.SuperClasses.AddLazy(() => Declaration);
			Interface.Properties.AddLazy(() => Interface_Operations);
			Interface_Operations.TypeLazy = () => __tmp26;
			Interface_Operations.Name = "Operations";
			Interface_Operations.Documentation = null;
			Interface_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Interface_Operations.ClassLazy = () => Interface;
			Database.MetaModelLazy = () => __tmp5;
			Database.NamespaceLazy = () => __tmp4;
			Database.Documentation = null;
			Database.Name = "Database";
			// Database.IsAbstract = null;
			Database.SuperClasses.AddLazy(() => Interface);
			Database.Properties.AddLazy(() => Database_Entities);
			Database_Entities.TypeLazy = () => __tmp27;
			Database_Entities.Name = "Entities";
			Database_Entities.Documentation = null;
			// Database_Entities.Kind = null;
			Database_Entities.ClassLazy = () => Database;
			Operation.MetaModelLazy = () => __tmp5;
			Operation.NamespaceLazy = () => __tmp4;
			Operation.Documentation = null;
			Operation.Name = "Operation";
			// Operation.IsAbstract = null;
			Operation.SuperClasses.AddLazy(() => NamedElement);
			Operation.SuperClasses.AddLazy(() => AnnotatedElement);
			Operation.Properties.AddLazy(() => Operation_Action);
			Operation.Properties.AddLazy(() => Operation_Parameters);
			Operation.Properties.AddLazy(() => Operation_Result);
			Operation.Properties.AddLazy(() => Operation_Exceptions);
			Operation_Action.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Operation_Action.Name = "Action";
			Operation_Action.Documentation = null;
			// Operation_Action.Kind = null;
			Operation_Action.ClassLazy = () => Operation;
			Operation_Parameters.TypeLazy = () => __tmp28;
			Operation_Parameters.Name = "Parameters";
			Operation_Parameters.Documentation = null;
			Operation_Parameters.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Operation_Parameters.ClassLazy = () => Operation;
			Operation_Result.TypeLazy = () => OutputParameter;
			Operation_Result.Name = "Result";
			Operation_Result.Documentation = null;
			Operation_Result.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Operation_Result.ClassLazy = () => Operation;
			Operation_Exceptions.TypeLazy = () => __tmp29;
			Operation_Exceptions.Name = "Exceptions";
			Operation_Exceptions.Documentation = null;
			// Operation_Exceptions.Kind = null;
			Operation_Exceptions.ClassLazy = () => Operation;
			InputParameter.MetaModelLazy = () => __tmp5;
			InputParameter.NamespaceLazy = () => __tmp4;
			InputParameter.Documentation = null;
			InputParameter.Name = "InputParameter";
			// InputParameter.IsAbstract = null;
			InputParameter.SuperClasses.AddLazy(() => NamedElement);
			InputParameter.SuperClasses.AddLazy(() => TypedElement);
			InputParameter.SuperClasses.AddLazy(() => AnnotatedElement);
			OutputParameter.MetaModelLazy = () => __tmp5;
			OutputParameter.NamespaceLazy = () => __tmp4;
			OutputParameter.Documentation = null;
			OutputParameter.Name = "OutputParameter";
			// OutputParameter.IsAbstract = null;
			OutputParameter.SuperClasses.AddLazy(() => TypedElement);
			OutputParameter.SuperClasses.AddLazy(() => AnnotatedElement);
			OutputParameter.Properties.AddLazy(() => OutputParameter_IsOneway);
			OutputParameter_IsOneway.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			OutputParameter_IsOneway.Name = "IsOneway";
			OutputParameter_IsOneway.Documentation = null;
			// OutputParameter_IsOneway.Kind = null;
			OutputParameter_IsOneway.ClassLazy = () => OutputParameter;
			Component.MetaModelLazy = () => __tmp5;
			Component.NamespaceLazy = () => __tmp4;
			Component.Documentation = null;
			Component.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.ScopeAttribute.ToMutable());
			Component.Name = "Component";
			// Component.IsAbstract = null;
			Component.SuperClasses.AddLazy(() => Declaration);
			Component.Properties.AddLazy(() => Component_BaseComponent);
			Component.Properties.AddLazy(() => Component_IsAbstract);
			Component.Properties.AddLazy(() => Component_Ports);
			Component.Properties.AddLazy(() => Component_Services);
			Component.Properties.AddLazy(() => Component_References);
			Component.Properties.AddLazy(() => Component_Properties);
			Component.Properties.AddLazy(() => Component_Implementation);
			Component.Properties.AddLazy(() => Component_Language);
			Component_BaseComponent.TypeLazy = () => Component;
			Component_BaseComponent.Attributes.Add(global::MetaDslx.Languages.Meta.Symbols.MetaInstance.BaseScopeAttribute.ToMutable());
			Component_BaseComponent.Name = "BaseComponent";
			Component_BaseComponent.Documentation = null;
			// Component_BaseComponent.Kind = null;
			Component_BaseComponent.ClassLazy = () => Component;
			Component_IsAbstract.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			Component_IsAbstract.Name = "IsAbstract";
			Component_IsAbstract.Documentation = null;
			// Component_IsAbstract.Kind = null;
			Component_IsAbstract.ClassLazy = () => Component;
			Component_Ports.TypeLazy = () => __tmp30;
			Component_Ports.Name = "Ports";
			Component_Ports.Documentation = null;
			Component_Ports.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Ports.ClassLazy = () => Component;
			Component_Ports.OppositeProperties.AddLazy(() => Port_Component);
			Component_Ports.SubsettingProperties.AddLazy(() => Component_Services);
			Component_Ports.SubsettingProperties.AddLazy(() => Component_References);
			Component_Services.TypeLazy = () => __tmp31;
			Component_Services.Name = "Services";
			Component_Services.Documentation = null;
			Component_Services.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Services.ClassLazy = () => Component;
			Component_Services.SubsettedProperties.AddLazy(() => Component_Ports);
			Component_References.TypeLazy = () => __tmp32;
			Component_References.Name = "References";
			Component_References.Documentation = null;
			Component_References.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_References.ClassLazy = () => Component;
			Component_References.SubsettedProperties.AddLazy(() => Component_Ports);
			Component_Properties.TypeLazy = () => __tmp33;
			Component_Properties.Name = "Properties";
			Component_Properties.Documentation = null;
			Component_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Properties.ClassLazy = () => Component;
			Component_Implementation.TypeLazy = () => Implementation;
			Component_Implementation.Name = "Implementation";
			Component_Implementation.Documentation = null;
			Component_Implementation.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Implementation.ClassLazy = () => Component;
			Component_Language.TypeLazy = () => ProgrammingLanguage;
			Component_Language.Name = "Language";
			Component_Language.Documentation = null;
			Component_Language.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Language.ClassLazy = () => Component;
			Composite.MetaModelLazy = () => __tmp5;
			Composite.NamespaceLazy = () => __tmp4;
			Composite.Documentation = null;
			Composite.Name = "Composite";
			// Composite.IsAbstract = null;
			Composite.SuperClasses.AddLazy(() => Component);
			Composite.Properties.AddLazy(() => Composite_Components);
			Composite.Properties.AddLazy(() => Composite_Wires);
			Composite_Components.TypeLazy = () => __tmp34;
			Composite_Components.Name = "Components";
			Composite_Components.Documentation = null;
			// Composite_Components.Kind = null;
			Composite_Components.ClassLazy = () => Composite;
			Composite_Wires.TypeLazy = () => __tmp35;
			Composite_Wires.Name = "Wires";
			Composite_Wires.Documentation = null;
			Composite_Wires.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Composite_Wires.ClassLazy = () => Composite;
			Assembly.MetaModelLazy = () => __tmp5;
			Assembly.NamespaceLazy = () => __tmp4;
			Assembly.Documentation = null;
			Assembly.Name = "Assembly";
			// Assembly.IsAbstract = null;
			Assembly.SuperClasses.AddLazy(() => Composite);
			Wire.MetaModelLazy = () => __tmp5;
			Wire.NamespaceLazy = () => __tmp4;
			Wire.Documentation = null;
			Wire.Name = "Wire";
			// Wire.IsAbstract = null;
			Wire.Properties.AddLazy(() => Wire_Source);
			Wire.Properties.AddLazy(() => Wire_Target);
			Wire_Source.TypeLazy = () => Port;
			Wire_Source.Name = "Source";
			Wire_Source.Documentation = null;
			// Wire_Source.Kind = null;
			Wire_Source.ClassLazy = () => Wire;
			Wire_Target.TypeLazy = () => Port;
			Wire_Target.Name = "Target";
			Wire_Target.Documentation = null;
			// Wire_Target.Kind = null;
			Wire_Target.ClassLazy = () => Wire;
			Port.MetaModelLazy = () => __tmp5;
			Port.NamespaceLazy = () => __tmp4;
			Port.Documentation = null;
			Port.Name = "Port";
			// Port.IsAbstract = null;
			Port.SuperClasses.AddLazy(() => NamedElement);
			Port.Properties.AddLazy(() => Port_Component);
			Port.Properties.AddLazy(() => Port_Interface);
			Port.Properties.AddLazy(() => Port_Binding);
			Port_Component.TypeLazy = () => Component;
			Port_Component.Name = "Component";
			Port_Component.Documentation = null;
			// Port_Component.Kind = null;
			Port_Component.ClassLazy = () => Port;
			Port_Component.OppositeProperties.AddLazy(() => Component_Ports);
			Port_Interface.TypeLazy = () => Interface;
			Port_Interface.Name = "Interface";
			Port_Interface.Documentation = null;
			// Port_Interface.Kind = null;
			Port_Interface.ClassLazy = () => Port;
			Port_Binding.TypeLazy = () => Binding;
			Port_Binding.Name = "Binding";
			Port_Binding.Documentation = null;
			// Port_Binding.Kind = null;
			Port_Binding.ClassLazy = () => Port;
			Service.MetaModelLazy = () => __tmp5;
			Service.NamespaceLazy = () => __tmp4;
			Service.Documentation = null;
			Service.Name = "Service";
			// Service.IsAbstract = null;
			Service.SuperClasses.AddLazy(() => Port);
			Reference.MetaModelLazy = () => __tmp5;
			Reference.NamespaceLazy = () => __tmp4;
			Reference.Documentation = null;
			Reference.Name = "Reference";
			// Reference.IsAbstract = null;
			Reference.SuperClasses.AddLazy(() => Port);
			Implementation.MetaModelLazy = () => __tmp5;
			Implementation.NamespaceLazy = () => __tmp4;
			Implementation.Documentation = null;
			Implementation.Name = "Implementation";
			// Implementation.IsAbstract = null;
			Implementation.SuperClasses.AddLazy(() => NamedElement);
			ProgrammingLanguage.MetaModelLazy = () => __tmp5;
			ProgrammingLanguage.NamespaceLazy = () => __tmp4;
			ProgrammingLanguage.Documentation = null;
			ProgrammingLanguage.Name = "ProgrammingLanguage";
			// ProgrammingLanguage.IsAbstract = null;
			ProgrammingLanguage.SuperClasses.AddLazy(() => NamedElement);
			Deployment.MetaModelLazy = () => __tmp5;
			Deployment.NamespaceLazy = () => __tmp4;
			Deployment.Documentation = null;
			Deployment.Name = "Deployment";
			// Deployment.IsAbstract = null;
			Deployment.SuperClasses.AddLazy(() => Declaration);
			Deployment.Properties.AddLazy(() => Deployment_Environments);
			Deployment.Properties.AddLazy(() => Deployment_Wires);
			Deployment_Environments.TypeLazy = () => __tmp36;
			Deployment_Environments.Name = "Environments";
			Deployment_Environments.Documentation = null;
			Deployment_Environments.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Deployment_Environments.ClassLazy = () => Deployment;
			Deployment_Wires.TypeLazy = () => __tmp37;
			Deployment_Wires.Name = "Wires";
			Deployment_Wires.Documentation = null;
			Deployment_Wires.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Deployment_Wires.ClassLazy = () => Deployment;
			Environment.MetaModelLazy = () => __tmp5;
			Environment.NamespaceLazy = () => __tmp4;
			Environment.Documentation = null;
			Environment.Name = "Environment";
			// Environment.IsAbstract = null;
			Environment.SuperClasses.AddLazy(() => NamedElement);
			Environment.Properties.AddLazy(() => Environment_Runtime);
			Environment.Properties.AddLazy(() => Environment_Databases);
			Environment.Properties.AddLazy(() => Environment_Assemblies);
			Environment_Runtime.TypeLazy = () => Runtime;
			Environment_Runtime.Name = "Runtime";
			Environment_Runtime.Documentation = null;
			Environment_Runtime.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Environment_Runtime.ClassLazy = () => Environment;
			Environment_Databases.TypeLazy = () => __tmp38;
			Environment_Databases.Name = "Databases";
			Environment_Databases.Documentation = null;
			// Environment_Databases.Kind = null;
			Environment_Databases.ClassLazy = () => Environment;
			Environment_Assemblies.TypeLazy = () => __tmp39;
			Environment_Assemblies.Name = "Assemblies";
			Environment_Assemblies.Documentation = null;
			// Environment_Assemblies.Kind = null;
			Environment_Assemblies.ClassLazy = () => Environment;
			Runtime.MetaModelLazy = () => __tmp5;
			Runtime.NamespaceLazy = () => __tmp4;
			Runtime.Documentation = null;
			Runtime.Name = "Runtime";
			// Runtime.IsAbstract = null;
			Runtime.SuperClasses.AddLazy(() => NamedElement);
			Binding.MetaModelLazy = () => __tmp5;
			Binding.NamespaceLazy = () => __tmp4;
			Binding.Documentation = null;
			Binding.Name = "Binding";
			// Binding.IsAbstract = null;
			Binding.SuperClasses.AddLazy(() => Declaration);
			Binding.Properties.AddLazy(() => Binding_Transport);
			Binding.Properties.AddLazy(() => Binding_Encodings);
			Binding.Properties.AddLazy(() => Binding_Protocols);
			Binding_Transport.TypeLazy = () => TransportBindingElement;
			Binding_Transport.Name = "Transport";
			Binding_Transport.Documentation = null;
			Binding_Transport.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Transport.ClassLazy = () => Binding;
			Binding_Encodings.TypeLazy = () => __tmp40;
			Binding_Encodings.Name = "Encodings";
			Binding_Encodings.Documentation = null;
			Binding_Encodings.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Encodings.ClassLazy = () => Binding;
			Binding_Protocols.TypeLazy = () => __tmp41;
			Binding_Protocols.Name = "Protocols";
			Binding_Protocols.Documentation = null;
			Binding_Protocols.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Protocols.ClassLazy = () => Binding;
			Endpoint.MetaModelLazy = () => __tmp5;
			Endpoint.NamespaceLazy = () => __tmp4;
			Endpoint.Documentation = null;
			Endpoint.Name = "Endpoint";
			// Endpoint.IsAbstract = null;
			Endpoint.SuperClasses.AddLazy(() => Declaration);
			Endpoint.Properties.AddLazy(() => Endpoint_Interface);
			Endpoint.Properties.AddLazy(() => Endpoint_Binding);
			Endpoint.Properties.AddLazy(() => Endpoint_Address);
			Endpoint_Interface.TypeLazy = () => Interface;
			Endpoint_Interface.Name = "Interface";
			Endpoint_Interface.Documentation = null;
			// Endpoint_Interface.Kind = null;
			Endpoint_Interface.ClassLazy = () => Endpoint;
			Endpoint_Binding.TypeLazy = () => Binding;
			Endpoint_Binding.Name = "Binding";
			Endpoint_Binding.Documentation = null;
			// Endpoint_Binding.Kind = null;
			Endpoint_Binding.ClassLazy = () => Endpoint;
			Endpoint_Address.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Endpoint_Address.Name = "Address";
			Endpoint_Address.Documentation = null;
			// Endpoint_Address.Kind = null;
			Endpoint_Address.ClassLazy = () => Endpoint;
			BindingElement.MetaModelLazy = () => __tmp5;
			BindingElement.NamespaceLazy = () => __tmp4;
			BindingElement.Documentation = null;
			BindingElement.Name = "BindingElement";
			BindingElement.IsAbstract = true;
			BindingElement.SuperClasses.AddLazy(() => NamedElement);
			TransportBindingElement.MetaModelLazy = () => __tmp5;
			TransportBindingElement.NamespaceLazy = () => __tmp4;
			TransportBindingElement.Documentation = null;
			TransportBindingElement.Name = "TransportBindingElement";
			TransportBindingElement.IsAbstract = true;
			TransportBindingElement.SuperClasses.AddLazy(() => BindingElement);
			EncodingBindingElement.MetaModelLazy = () => __tmp5;
			EncodingBindingElement.NamespaceLazy = () => __tmp4;
			EncodingBindingElement.Documentation = null;
			EncodingBindingElement.Name = "EncodingBindingElement";
			EncodingBindingElement.IsAbstract = true;
			EncodingBindingElement.SuperClasses.AddLazy(() => BindingElement);
			ProtocolBindingElement.MetaModelLazy = () => __tmp5;
			ProtocolBindingElement.NamespaceLazy = () => __tmp4;
			ProtocolBindingElement.Documentation = null;
			ProtocolBindingElement.Name = "ProtocolBindingElement";
			ProtocolBindingElement.IsAbstract = true;
			ProtocolBindingElement.SuperClasses.AddLazy(() => BindingElement);
			HttpTransportBindingElement.MetaModelLazy = () => __tmp5;
			HttpTransportBindingElement.NamespaceLazy = () => __tmp4;
			HttpTransportBindingElement.Documentation = null;
			HttpTransportBindingElement.Name = "HttpTransportBindingElement";
			// HttpTransportBindingElement.IsAbstract = null;
			HttpTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			HttpTransportBindingElement.Properties.AddLazy(() => HttpTransportBindingElement_Ssl);
			HttpTransportBindingElement.Properties.AddLazy(() => HttpTransportBindingElement_ClientAuthentication);
			HttpTransportBindingElement_Ssl.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			HttpTransportBindingElement_Ssl.Name = "Ssl";
			HttpTransportBindingElement_Ssl.Documentation = null;
			// HttpTransportBindingElement_Ssl.Kind = null;
			HttpTransportBindingElement_Ssl.ClassLazy = () => HttpTransportBindingElement;
			HttpTransportBindingElement_ClientAuthentication.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			HttpTransportBindingElement_ClientAuthentication.Name = "ClientAuthentication";
			HttpTransportBindingElement_ClientAuthentication.Documentation = null;
			// HttpTransportBindingElement_ClientAuthentication.Kind = null;
			HttpTransportBindingElement_ClientAuthentication.ClassLazy = () => HttpTransportBindingElement;
			RestTransportBindingElement.MetaModelLazy = () => __tmp5;
			RestTransportBindingElement.NamespaceLazy = () => __tmp4;
			RestTransportBindingElement.Documentation = null;
			RestTransportBindingElement.Name = "RestTransportBindingElement";
			// RestTransportBindingElement.IsAbstract = null;
			RestTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			WebSocketTransportBindingElement.MetaModelLazy = () => __tmp5;
			WebSocketTransportBindingElement.NamespaceLazy = () => __tmp4;
			WebSocketTransportBindingElement.Documentation = null;
			WebSocketTransportBindingElement.Name = "WebSocketTransportBindingElement";
			// WebSocketTransportBindingElement.IsAbstract = null;
			WebSocketTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			SoapVersion.MetaModelLazy = () => __tmp5;
			SoapVersion.NamespaceLazy = () => __tmp4;
			SoapVersion.Documentation = null;
			SoapVersion.Name = "SoapVersion";
			SoapVersion.EnumLiterals.AddLazy(() => __tmp42);
			SoapVersion.EnumLiterals.AddLazy(() => __tmp43);
			__tmp42.TypeLazy = () => SoapVersion;
			__tmp42.Name = "Soap11";
			__tmp42.Documentation = null;
			__tmp42.EnumLazy = () => SoapVersion;
			__tmp43.TypeLazy = () => SoapVersion;
			__tmp43.Name = "Soap12";
			__tmp43.Documentation = null;
			__tmp43.EnumLazy = () => SoapVersion;
			SoapEncodingStyle.MetaModelLazy = () => __tmp5;
			SoapEncodingStyle.NamespaceLazy = () => __tmp4;
			SoapEncodingStyle.Documentation = null;
			SoapEncodingStyle.Name = "SoapEncodingStyle";
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp44);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp45);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp46);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp47);
			__tmp44.TypeLazy = () => SoapEncodingStyle;
			__tmp44.Name = "DocumentWrapped";
			__tmp44.Documentation = null;
			__tmp44.EnumLazy = () => SoapEncodingStyle;
			__tmp45.TypeLazy = () => SoapEncodingStyle;
			__tmp45.Name = "DocumentLiteral";
			__tmp45.Documentation = null;
			__tmp45.EnumLazy = () => SoapEncodingStyle;
			__tmp46.TypeLazy = () => SoapEncodingStyle;
			__tmp46.Name = "RpcLiteral";
			__tmp46.Documentation = null;
			__tmp46.EnumLazy = () => SoapEncodingStyle;
			__tmp47.TypeLazy = () => SoapEncodingStyle;
			__tmp47.Name = "RpcEncoded";
			__tmp47.Documentation = null;
			__tmp47.EnumLazy = () => SoapEncodingStyle;
			SoapEncodingBindingElement.MetaModelLazy = () => __tmp5;
			SoapEncodingBindingElement.NamespaceLazy = () => __tmp4;
			SoapEncodingBindingElement.Documentation = null;
			SoapEncodingBindingElement.Name = "SoapEncodingBindingElement";
			// SoapEncodingBindingElement.IsAbstract = null;
			SoapEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Style);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Version);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Mtom);
			SoapEncodingBindingElement_Style.TypeLazy = () => SoapEncodingStyle;
			SoapEncodingBindingElement_Style.Name = "Style";
			SoapEncodingBindingElement_Style.Documentation = null;
			// SoapEncodingBindingElement_Style.Kind = null;
			SoapEncodingBindingElement_Style.ClassLazy = () => SoapEncodingBindingElement;
			SoapEncodingBindingElement_Version.TypeLazy = () => SoapVersion;
			SoapEncodingBindingElement_Version.Name = "Version";
			SoapEncodingBindingElement_Version.Documentation = null;
			// SoapEncodingBindingElement_Version.Kind = null;
			SoapEncodingBindingElement_Version.ClassLazy = () => SoapEncodingBindingElement;
			SoapEncodingBindingElement_Mtom.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			SoapEncodingBindingElement_Mtom.Name = "Mtom";
			SoapEncodingBindingElement_Mtom.Documentation = null;
			// SoapEncodingBindingElement_Mtom.Kind = null;
			SoapEncodingBindingElement_Mtom.ClassLazy = () => SoapEncodingBindingElement;
			XmlEncodingBindingElement.MetaModelLazy = () => __tmp5;
			XmlEncodingBindingElement.NamespaceLazy = () => __tmp4;
			XmlEncodingBindingElement.Documentation = null;
			XmlEncodingBindingElement.Name = "XmlEncodingBindingElement";
			// XmlEncodingBindingElement.IsAbstract = null;
			XmlEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			JsonEncodingBindingElement.MetaModelLazy = () => __tmp5;
			JsonEncodingBindingElement.NamespaceLazy = () => __tmp4;
			JsonEncodingBindingElement.Documentation = null;
			JsonEncodingBindingElement.Name = "JsonEncodingBindingElement";
			// JsonEncodingBindingElement.IsAbstract = null;
			JsonEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			WsProtocolBindingElement.MetaModelLazy = () => __tmp5;
			WsProtocolBindingElement.NamespaceLazy = () => __tmp4;
			WsProtocolBindingElement.Documentation = null;
			WsProtocolBindingElement.Name = "WsProtocolBindingElement";
			WsProtocolBindingElement.IsAbstract = true;
			WsProtocolBindingElement.SuperClasses.AddLazy(() => ProtocolBindingElement);
			WsAddressingBindingElement.MetaModelLazy = () => __tmp5;
			WsAddressingBindingElement.NamespaceLazy = () => __tmp4;
			WsAddressingBindingElement.Documentation = null;
			WsAddressingBindingElement.Name = "WsAddressingBindingElement";
			// WsAddressingBindingElement.IsAbstract = null;
			WsAddressingBindingElement.SuperClasses.AddLazy(() => WsProtocolBindingElement);
			__tmp19.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp19.InnerTypeLazy = () => Annotation;
			__tmp20.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp20.InnerTypeLazy = () => AnnotationProperty;
			__tmp22.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp22.InnerTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp23.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp23.InnerTypeLazy = () => Declaration;
			__tmp24.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp24.InnerTypeLazy = () => EnumLiteral;
			__tmp25.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp25.InnerTypeLazy = () => Property;
			__tmp26.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp26.InnerTypeLazy = () => Operation;
			__tmp27.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp27.InnerTypeLazy = () => Struct;
			__tmp28.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp28.InnerTypeLazy = () => InputParameter;
			__tmp29.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp29.InnerTypeLazy = () => Struct;
			__tmp30.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp30.InnerTypeLazy = () => Port;
			__tmp31.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp31.InnerTypeLazy = () => Service;
			__tmp32.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp32.InnerTypeLazy = () => Reference;
			__tmp33.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp33.InnerTypeLazy = () => Property;
			__tmp34.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp34.InnerTypeLazy = () => Component;
			__tmp35.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp35.InnerTypeLazy = () => Wire;
			__tmp36.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp36.InnerTypeLazy = () => Environment;
			__tmp37.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp37.InnerTypeLazy = () => Wire;
			__tmp38.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp38.InnerTypeLazy = () => Interface;
			__tmp39.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp39.InnerTypeLazy = () => Assembly;
			__tmp40.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp40.InnerTypeLazy = () => EncodingBindingElement;
			__tmp41.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp41.InnerTypeLazy = () => ProtocolBindingElement;
	
			foreach (global::MetaDslx.Modeling.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementation to provide custom
	/// implementation for the constructors, operations and property values.
	/// </summary>
	internal abstract class SoalImplementationBase
	{
		/// <summary>
		/// Implements the constructor: SoalBuilderInstance()
		/// </summary>
		internal virtual void SoalBuilderInstance(SoalBuilderInstance _this)
		{
		}
	
		/// <summary>
		/// Implements the constructor: AnnotatedElement()
		/// </summary>
		public virtual void AnnotatedElement(AnnotatedElementBuilder _this)
		{
			this.CallAnnotatedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of AnnotatedElement
		/// </summary>
		protected virtual void CallAnnotatedElementSuperConstructors(AnnotatedElementBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Annotation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Annotation(AnnotationBuilder _this)
		{
			this.CallAnnotationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Annotation
		/// </summary>
		protected virtual void CallAnnotationSuperConstructors(AnnotationBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: AnnotationProperty()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void AnnotationProperty(AnnotationPropertyBuilder _this)
		{
			this.CallAnnotationPropertySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of AnnotationProperty
		/// </summary>
		protected virtual void CallAnnotationPropertySuperConstructors(AnnotationPropertyBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: DocumentedElement()
		/// </summary>
		public virtual void DocumentedElement(DocumentedElementBuilder _this)
		{
			this.CallDocumentedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of DocumentedElement
		/// </summary>
		protected virtual void CallDocumentedElementSuperConstructors(DocumentedElementBuilder _this)
		{
		}
	
		/// <summary>
		/// Implements the operation: DocumentedElement.GetDocumentationLines()
		/// </summary>
		public virtual global::MetaDslx.Modeling.ImmutableModelList<string> DocumentedElement_GetDocumentationLines(DocumentedElement _this)
		{
			throw new NotImplementedException();
		}
	
	
		/// <summary>
		/// Implements the constructor: NamedElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>DocumentedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		/// </ul>
		public virtual void NamedElement(NamedElementBuilder _this)
		{
			this.CallNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedElement
		/// </summary>
		protected virtual void CallNamedElementSuperConstructors(NamedElementBuilder _this)
		{
			this.DocumentedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: TypedElement()
		/// </summary>
		public virtual void TypedElement(TypedElementBuilder _this)
		{
			this.CallTypedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TypedElement
		/// </summary>
		protected virtual void CallTypedElementSuperConstructors(TypedElementBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: SoalType()
		/// </summary>
		public virtual void SoalType(SoalTypeBuilder _this)
		{
			this.CallSoalTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of SoalType
		/// </summary>
		protected virtual void CallSoalTypeSuperConstructors(SoalTypeBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: NamedType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void NamedType(NamedTypeBuilder _this)
		{
			this.CallNamedTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedType
		/// </summary>
		protected virtual void CallNamedTypeSuperConstructors(NamedTypeBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Declaration()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>FullName</li>
		/// </ul>
		public virtual void Declaration(DeclarationBuilder _this)
		{
			this.CallDeclarationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Declaration
		/// </summary>
		protected virtual void CallDeclarationSuperConstructors(DeclarationBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Namespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Namespace(NamespaceBuilder _this)
		{
			this.CallNamespaceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Namespace
		/// </summary>
		protected virtual void CallNamespaceSuperConstructors(NamespaceBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: ArrayType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void ArrayType(ArrayTypeBuilder _this)
		{
			this.CallArrayTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ArrayType
		/// </summary>
		protected virtual void CallArrayTypeSuperConstructors(ArrayTypeBuilder _this)
		{
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: NullableType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void NullableType(NullableTypeBuilder _this)
		{
			this.CallNullableTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NullableType
		/// </summary>
		protected virtual void CallNullableTypeSuperConstructors(NullableTypeBuilder _this)
		{
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: NonNullableType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void NonNullableType(NonNullableTypeBuilder _this)
		{
			this.CallNonNullableTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NonNullableType
		/// </summary>
		protected virtual void CallNonNullableTypeSuperConstructors(NonNullableTypeBuilder _this)
		{
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: PrimitiveType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void PrimitiveType(PrimitiveTypeBuilder _this)
		{
			this.CallPrimitiveTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of PrimitiveType
		/// </summary>
		protected virtual void CallPrimitiveTypeSuperConstructors(PrimitiveTypeBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Enum()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void Enum(EnumBuilder _this)
		{
			this.CallEnumSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Enum
		/// </summary>
		protected virtual void CallEnumSuperConstructors(EnumBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: EnumLiteral()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>TypedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>TypedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void EnumLiteral(EnumLiteralBuilder _this)
		{
			this.CallEnumLiteralSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EnumLiteral
		/// </summary>
		protected virtual void CallEnumLiteralSuperConstructors(EnumLiteralBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Property()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>TypedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>TypedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Property(PropertyBuilder _this)
		{
			this.CallPropertySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Property
		/// </summary>
		protected virtual void CallPropertySuperConstructors(PropertyBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Struct()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void Struct(StructBuilder _this)
		{
			this.CallStructSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Struct
		/// </summary>
		protected virtual void CallStructSuperConstructors(StructBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Interface()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void Interface(InterfaceBuilder _this)
		{
			this.CallInterfaceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Interface
		/// </summary>
		protected virtual void CallInterfaceSuperConstructors(InterfaceBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Database()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Interface</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		///     <li>Interface</li>
		/// </ul>
		public virtual void Database(DatabaseBuilder _this)
		{
			this.CallDatabaseSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Database
		/// </summary>
		protected virtual void CallDatabaseSuperConstructors(DatabaseBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
			this.Interface(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Operation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Operation(OperationBuilder _this)
		{
			this.CallOperationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Operation
		/// </summary>
		protected virtual void CallOperationSuperConstructors(OperationBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: InputParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>TypedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>TypedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void InputParameter(InputParameterBuilder _this)
		{
			this.CallInputParameterSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of InputParameter
		/// </summary>
		protected virtual void CallInputParameterSuperConstructors(InputParameterBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: OutputParameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TypedElement</li>
		///     <li>AnnotatedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>TypedElement</li>
		/// </ul>
		public virtual void OutputParameter(OutputParameterBuilder _this)
		{
			this.CallOutputParameterSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of OutputParameter
		/// </summary>
		protected virtual void CallOutputParameterSuperConstructors(OutputParameterBuilder _this)
		{
			this.AnnotatedElement(_this);
			this.TypedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Component()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Component(ComponentBuilder _this)
		{
			this.CallComponentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Component
		/// </summary>
		protected virtual void CallComponentSuperConstructors(ComponentBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Composite()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Component</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>Component</li>
		/// </ul>
		public virtual void Composite(CompositeBuilder _this)
		{
			this.CallCompositeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Composite
		/// </summary>
		protected virtual void CallCompositeSuperConstructors(CompositeBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.Component(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Assembly()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Composite</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>Component</li>
		///     <li>Composite</li>
		/// </ul>
		public virtual void Assembly(AssemblyBuilder _this)
		{
			this.CallAssemblySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Assembly
		/// </summary>
		protected virtual void CallAssemblySuperConstructors(AssemblyBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
			this.Component(_this);
			this.Composite(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Wire()
		/// </summary>
		public virtual void Wire(WireBuilder _this)
		{
			this.CallWireSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Wire
		/// </summary>
		protected virtual void CallWireSuperConstructors(WireBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Port()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Port(PortBuilder _this)
		{
			this.CallPortSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Port
		/// </summary>
		protected virtual void CallPortSuperConstructors(PortBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Service()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Port</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>Port</li>
		/// </ul>
		public virtual void Service(ServiceBuilder _this)
		{
			this.CallServiceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Service
		/// </summary>
		protected virtual void CallServiceSuperConstructors(ServiceBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.Port(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Reference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Port</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>Port</li>
		/// </ul>
		public virtual void Reference(ReferenceBuilder _this)
		{
			this.CallReferenceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Reference
		/// </summary>
		protected virtual void CallReferenceSuperConstructors(ReferenceBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.Port(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Implementation()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Implementation(ImplementationBuilder _this)
		{
			this.CallImplementationSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Implementation
		/// </summary>
		protected virtual void CallImplementationSuperConstructors(ImplementationBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: ProgrammingLanguage()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void ProgrammingLanguage(ProgrammingLanguageBuilder _this)
		{
			this.CallProgrammingLanguageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ProgrammingLanguage
		/// </summary>
		protected virtual void CallProgrammingLanguageSuperConstructors(ProgrammingLanguageBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Deployment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Deployment(DeploymentBuilder _this)
		{
			this.CallDeploymentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Deployment
		/// </summary>
		protected virtual void CallDeploymentSuperConstructors(DeploymentBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Environment()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Environment(EnvironmentBuilder _this)
		{
			this.CallEnvironmentSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Environment
		/// </summary>
		protected virtual void CallEnvironmentSuperConstructors(EnvironmentBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Runtime()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Runtime(RuntimeBuilder _this)
		{
			this.CallRuntimeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Runtime
		/// </summary>
		protected virtual void CallRuntimeSuperConstructors(RuntimeBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Binding()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Binding(BindingBuilder _this)
		{
			this.CallBindingSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Binding
		/// </summary>
		protected virtual void CallBindingSuperConstructors(BindingBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Endpoint()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		public virtual void Endpoint(EndpointBuilder _this)
		{
			this.CallEndpointSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Endpoint
		/// </summary>
		protected virtual void CallEndpointSuperConstructors(EndpointBuilder _this)
		{
			this.DocumentedElement(_this);
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: BindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void BindingElement(BindingElementBuilder _this)
		{
			this.CallBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of BindingElement
		/// </summary>
		protected virtual void CallBindingElementSuperConstructors(BindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: TransportBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>BindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		/// </ul>
		public virtual void TransportBindingElement(TransportBindingElementBuilder _this)
		{
			this.CallTransportBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of TransportBindingElement
		/// </summary>
		protected virtual void CallTransportBindingElementSuperConstructors(TransportBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: EncodingBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>BindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		/// </ul>
		public virtual void EncodingBindingElement(EncodingBindingElementBuilder _this)
		{
			this.CallEncodingBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of EncodingBindingElement
		/// </summary>
		protected virtual void CallEncodingBindingElementSuperConstructors(EncodingBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: ProtocolBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>BindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		/// </ul>
		public virtual void ProtocolBindingElement(ProtocolBindingElementBuilder _this)
		{
			this.CallProtocolBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of ProtocolBindingElement
		/// </summary>
		protected virtual void CallProtocolBindingElementSuperConstructors(ProtocolBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: HttpTransportBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TransportBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>TransportBindingElement</li>
		/// </ul>
		public virtual void HttpTransportBindingElement(HttpTransportBindingElementBuilder _this)
		{
			this.CallHttpTransportBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of HttpTransportBindingElement
		/// </summary>
		protected virtual void CallHttpTransportBindingElementSuperConstructors(HttpTransportBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.TransportBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: RestTransportBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TransportBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>TransportBindingElement</li>
		/// </ul>
		public virtual void RestTransportBindingElement(RestTransportBindingElementBuilder _this)
		{
			this.CallRestTransportBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of RestTransportBindingElement
		/// </summary>
		protected virtual void CallRestTransportBindingElementSuperConstructors(RestTransportBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.TransportBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: WebSocketTransportBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>TransportBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>TransportBindingElement</li>
		/// </ul>
		public virtual void WebSocketTransportBindingElement(WebSocketTransportBindingElementBuilder _this)
		{
			this.CallWebSocketTransportBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of WebSocketTransportBindingElement
		/// </summary>
		protected virtual void CallWebSocketTransportBindingElementSuperConstructors(WebSocketTransportBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.TransportBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: SoapEncodingBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		public virtual void SoapEncodingBindingElement(SoapEncodingBindingElementBuilder _this)
		{
			this.CallSoapEncodingBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of SoapEncodingBindingElement
		/// </summary>
		protected virtual void CallSoapEncodingBindingElementSuperConstructors(SoapEncodingBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.EncodingBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: XmlEncodingBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		public virtual void XmlEncodingBindingElement(XmlEncodingBindingElementBuilder _this)
		{
			this.CallXmlEncodingBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of XmlEncodingBindingElement
		/// </summary>
		protected virtual void CallXmlEncodingBindingElementSuperConstructors(XmlEncodingBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.EncodingBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: JsonEncodingBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>EncodingBindingElement</li>
		/// </ul>
		public virtual void JsonEncodingBindingElement(JsonEncodingBindingElementBuilder _this)
		{
			this.CallJsonEncodingBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of JsonEncodingBindingElement
		/// </summary>
		protected virtual void CallJsonEncodingBindingElementSuperConstructors(JsonEncodingBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.EncodingBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: WsProtocolBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>ProtocolBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>ProtocolBindingElement</li>
		/// </ul>
		public virtual void WsProtocolBindingElement(WsProtocolBindingElementBuilder _this)
		{
			this.CallWsProtocolBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of WsProtocolBindingElement
		/// </summary>
		protected virtual void CallWsProtocolBindingElementSuperConstructors(WsProtocolBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.ProtocolBindingElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: WsAddressingBindingElement()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>WsProtocolBindingElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>DocumentedElement</li>
		///     <li>NamedElement</li>
		///     <li>BindingElement</li>
		///     <li>ProtocolBindingElement</li>
		///     <li>WsProtocolBindingElement</li>
		/// </ul>
		public virtual void WsAddressingBindingElement(WsAddressingBindingElementBuilder _this)
		{
			this.CallWsAddressingBindingElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of WsAddressingBindingElement
		/// </summary>
		protected virtual void CallWsAddressingBindingElementSuperConstructors(WsAddressingBindingElementBuilder _this)
		{
			this.DocumentedElement(_this);
			this.NamedElement(_this);
			this.BindingElement(_this);
			this.ProtocolBindingElement(_this);
			this.WsProtocolBindingElement(_this);
		}
	
	
	
	}

	internal class SoalImplementationProvider
	{
		// If there is a compile error at this line, create a new class called SoalImplementation
		// which is a subclass of global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationBase:
		private static SoalImplementation implementation = new SoalImplementation();
	
		public static SoalImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
