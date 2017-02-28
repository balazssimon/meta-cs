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
		public static readonly global::MetaDslx.Core.ImmutableModel Model;
	
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
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Annotation_AnnotatedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Annotation_Properties;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass AnnotationProperty;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty AnnotationProperty_Value;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass NamedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty NamedElement_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass TypedElement;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty TypedElement_Type;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass SoalType;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Namespace;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Uri;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Prefix;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_FullName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Namespace_Declarations;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Declaration;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Declaration_Namespace;
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
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Name;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_OptionalName;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Interface;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaProperty Port_Binding;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Service;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Reference;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Implementation;
		public static readonly global::MetaDslx.Languages.Meta.Symbols.MetaClass Language;
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
			Annotation_AnnotatedElement = SoalBuilderInstance.instance.Annotation_AnnotatedElement.ToImmutable(Model);
			Annotation_Properties = SoalBuilderInstance.instance.Annotation_Properties.ToImmutable(Model);
			AnnotationProperty = SoalBuilderInstance.instance.AnnotationProperty.ToImmutable(Model);
			AnnotationProperty_Value = SoalBuilderInstance.instance.AnnotationProperty_Value.ToImmutable(Model);
			NamedElement = SoalBuilderInstance.instance.NamedElement.ToImmutable(Model);
			NamedElement_Name = SoalBuilderInstance.instance.NamedElement_Name.ToImmutable(Model);
			TypedElement = SoalBuilderInstance.instance.TypedElement.ToImmutable(Model);
			TypedElement_Type = SoalBuilderInstance.instance.TypedElement_Type.ToImmutable(Model);
			SoalType = SoalBuilderInstance.instance.SoalType.ToImmutable(Model);
			Namespace = SoalBuilderInstance.instance.Namespace.ToImmutable(Model);
			Namespace_Uri = SoalBuilderInstance.instance.Namespace_Uri.ToImmutable(Model);
			Namespace_Prefix = SoalBuilderInstance.instance.Namespace_Prefix.ToImmutable(Model);
			Namespace_FullName = SoalBuilderInstance.instance.Namespace_FullName.ToImmutable(Model);
			Namespace_Declarations = SoalBuilderInstance.instance.Namespace_Declarations.ToImmutable(Model);
			Declaration = SoalBuilderInstance.instance.Declaration.ToImmutable(Model);
			Declaration_Namespace = SoalBuilderInstance.instance.Declaration_Namespace.ToImmutable(Model);
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
			Port_Name = SoalBuilderInstance.instance.Port_Name.ToImmutable(Model);
			Port_OptionalName = SoalBuilderInstance.instance.Port_OptionalName.ToImmutable(Model);
			Port_Interface = SoalBuilderInstance.instance.Port_Interface.ToImmutable(Model);
			Port_Binding = SoalBuilderInstance.instance.Port_Binding.ToImmutable(Model);
			Service = SoalBuilderInstance.instance.Service.ToImmutable(Model);
			Reference = SoalBuilderInstance.instance.Reference.ToImmutable(Model);
			Implementation = SoalBuilderInstance.instance.Implementation.ToImmutable(Model);
			Language = SoalBuilderInstance.instance.Language.ToImmutable(Model);
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
	public class SoalFactory : global::MetaDslx.Core.ModelFactory
	{
		public SoalFactory(global::MetaDslx.Core.MutableModel model, global::MetaDslx.Core.ModelFactoryFlags flags = global::MetaDslx.Core.ModelFactoryFlags.None)
			: base(model, flags)
		{
			SoalDescriptor.Initialize();
		}
	
		public override global::MetaDslx.Core.MutableSymbol Create(string type)
		{
			switch (type)
			{
				case "Annotation": return this.Annotation();
				case "AnnotationProperty": return this.AnnotationProperty();
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
				case "Language": return this.Language();
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
					throw new global::MetaDslx.Core.ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo(global::MetaDslx.Core.ModelErrorCode.ERR_UnknownTypeName, type));
			}
		}
	
		/// <summary>
		/// Creates a new instance of Annotation.
		/// </summary>
		public AnnotationBuilder Annotation()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new AnnotationId());
			return (AnnotationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of AnnotationProperty.
		/// </summary>
		public AnnotationPropertyBuilder AnnotationProperty()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new AnnotationPropertyId());
			return (AnnotationPropertyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Namespace.
		/// </summary>
		public NamespaceBuilder Namespace()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new NamespaceId());
			return (NamespaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of ArrayType.
		/// </summary>
		public ArrayTypeBuilder ArrayType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ArrayTypeId());
			return (ArrayTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of NullableType.
		/// </summary>
		public NullableTypeBuilder NullableType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new NullableTypeId());
			return (NullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of NonNullableType.
		/// </summary>
		public NonNullableTypeBuilder NonNullableType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new NonNullableTypeId());
			return (NonNullableTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of PrimitiveType.
		/// </summary>
		public PrimitiveTypeBuilder PrimitiveType()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PrimitiveTypeId());
			return (PrimitiveTypeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Enum.
		/// </summary>
		public EnumBuilder Enum()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new EnumId());
			return (EnumBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of EnumLiteral.
		/// </summary>
		public EnumLiteralBuilder EnumLiteral()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new EnumLiteralId());
			return (EnumLiteralBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Property.
		/// </summary>
		public PropertyBuilder Property()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PropertyId());
			return (PropertyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Struct.
		/// </summary>
		public StructBuilder Struct()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new StructId());
			return (StructBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Interface.
		/// </summary>
		public InterfaceBuilder Interface()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new InterfaceId());
			return (InterfaceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Database.
		/// </summary>
		public DatabaseBuilder Database()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new DatabaseId());
			return (DatabaseBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Operation.
		/// </summary>
		public OperationBuilder Operation()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new OperationId());
			return (OperationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of InputParameter.
		/// </summary>
		public InputParameterBuilder InputParameter()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new InputParameterId());
			return (InputParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of OutputParameter.
		/// </summary>
		public OutputParameterBuilder OutputParameter()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new OutputParameterId());
			return (OutputParameterBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Component.
		/// </summary>
		public ComponentBuilder Component()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ComponentId());
			return (ComponentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Composite.
		/// </summary>
		public CompositeBuilder Composite()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new CompositeId());
			return (CompositeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Assembly.
		/// </summary>
		public AssemblyBuilder Assembly()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new AssemblyId());
			return (AssemblyBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Wire.
		/// </summary>
		public WireBuilder Wire()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new WireId());
			return (WireBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Port.
		/// </summary>
		public PortBuilder Port()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new PortId());
			return (PortBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Service.
		/// </summary>
		public ServiceBuilder Service()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ServiceId());
			return (ServiceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Reference.
		/// </summary>
		public ReferenceBuilder Reference()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ReferenceId());
			return (ReferenceBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Implementation.
		/// </summary>
		public ImplementationBuilder Implementation()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ImplementationId());
			return (ImplementationBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Language.
		/// </summary>
		public LanguageBuilder Language()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new LanguageId());
			return (LanguageBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Deployment.
		/// </summary>
		public DeploymentBuilder Deployment()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new DeploymentId());
			return (DeploymentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Environment.
		/// </summary>
		public EnvironmentBuilder Environment()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new EnvironmentId());
			return (EnvironmentBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Runtime.
		/// </summary>
		public RuntimeBuilder Runtime()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new RuntimeId());
			return (RuntimeBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Binding.
		/// </summary>
		public BindingBuilder Binding()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new BindingId());
			return (BindingBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Endpoint.
		/// </summary>
		public EndpointBuilder Endpoint()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new EndpointId());
			return (EndpointBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of HttpTransportBindingElement.
		/// </summary>
		public HttpTransportBindingElementBuilder HttpTransportBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new HttpTransportBindingElementId());
			return (HttpTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of RestTransportBindingElement.
		/// </summary>
		public RestTransportBindingElementBuilder RestTransportBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new RestTransportBindingElementId());
			return (RestTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of WebSocketTransportBindingElement.
		/// </summary>
		public WebSocketTransportBindingElementBuilder WebSocketTransportBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new WebSocketTransportBindingElementId());
			return (WebSocketTransportBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of SoapEncodingBindingElement.
		/// </summary>
		public SoapEncodingBindingElementBuilder SoapEncodingBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new SoapEncodingBindingElementId());
			return (SoapEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of XmlEncodingBindingElement.
		/// </summary>
		public XmlEncodingBindingElementBuilder XmlEncodingBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new XmlEncodingBindingElementId());
			return (XmlEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of JsonEncodingBindingElement.
		/// </summary>
		public JsonEncodingBindingElementBuilder JsonEncodingBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new JsonEncodingBindingElementId());
			return (JsonEncodingBindingElementBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of WsAddressingBindingElement.
		/// </summary>
		public WsAddressingBindingElementBuilder WsAddressingBindingElement()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new WsAddressingBindingElementId());
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
	
	public interface AnnotatedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations { get; }
	
		bool HasAnnotation(string name);
		Annotation GetAnnotation(string name);
		global::MetaDslx.Core.ImmutableModelList<Annotation> GetAnnotations(string name);
		bool HasAnnotationProperty(string annotationName, string propertyName);
		object GetAnnotationPropertyValue(string annotationName, string propertyName);
	
		new AnnotatedElementBuilder ToMutable();
		new AnnotatedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface AnnotatedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations { get; }
	
		new AnnotatedElement ToImmutable();
		new AnnotatedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Annotation : NamedElement
	{
		AnnotatedElement AnnotatedElement { get; }
		global::MetaDslx.Core.ImmutableModelList<AnnotationProperty> Properties { get; }
	
		bool HasProperty(string name);
		AnnotationProperty GetProperty(string name);
		object GetPropertyValue(string name);
	
		new AnnotationBuilder ToMutable();
		new AnnotationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface AnnotationBuilder : NamedElementBuilder
	{
		AnnotatedElementBuilder AnnotatedElement { get; set; }
		Func<AnnotatedElementBuilder> AnnotatedElementLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<AnnotationPropertyBuilder> Properties { get; }
	
		new Annotation ToImmutable();
		new Annotation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface AnnotationProperty : NamedElement
	{
		object Value { get; }
	
	
		new AnnotationPropertyBuilder ToMutable();
		new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface AnnotationPropertyBuilder : NamedElementBuilder
	{
		object Value { get; set; }
		Func<object> ValueLazy { get; set; }
	
		new AnnotationProperty ToImmutable();
		new AnnotationProperty ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface NamedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		string Name { get; }
	
	
		new NamedElementBuilder ToMutable();
		new NamedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NamedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Name { get; set; }
		Func<string> NameLazy { get; set; }
	
		new NamedElement ToImmutable();
		new NamedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface TypedElement : global::MetaDslx.Core.ImmutableSymbol
	{
		SoalType Type { get; }
	
	
		new TypedElementBuilder ToMutable();
		new TypedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TypedElementBuilder : global::MetaDslx.Core.MutableSymbol
	{
		SoalTypeBuilder Type { get; set; }
		Func<SoalTypeBuilder> TypeLazy { get; set; }
	
		new TypedElement ToImmutable();
		new TypedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface SoalType : global::MetaDslx.Core.ImmutableSymbol
	{
	
	
		new SoalTypeBuilder ToMutable();
		new SoalTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface SoalTypeBuilder : global::MetaDslx.Core.MutableSymbol
	{
	
		new SoalType ToImmutable();
		new SoalType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Namespace : Declaration
	{
		string Uri { get; }
		string Prefix { get; }
		string FullName { get; }
		global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new NamespaceBuilder ToMutable();
		new NamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NamespaceBuilder : DeclarationBuilder
	{
		string Uri { get; set; }
		Func<string> UriLazy { get; set; }
		string Prefix { get; set; }
		Func<string> PrefixLazy { get; set; }
		string FullName { get; }
		Func<string> FullNameLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Namespace ToImmutable();
		new Namespace ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Declaration : NamedElement, AnnotatedElement
	{
		Namespace Namespace { get; }
	
	
		new DeclarationBuilder ToMutable();
		new DeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DeclarationBuilder : NamedElementBuilder, AnnotatedElementBuilder
	{
		NamespaceBuilder Namespace { get; set; }
		Func<NamespaceBuilder> NamespaceLazy { get; set; }
	
		new Declaration ToImmutable();
		new Declaration ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ArrayType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new ArrayTypeBuilder ToMutable();
		new ArrayTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ArrayTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new ArrayType ToImmutable();
		new ArrayType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface NullableType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new NullableTypeBuilder ToMutable();
		new NullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NullableTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new NullableType ToImmutable();
		new NullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface NonNullableType : SoalType
	{
		SoalType InnerType { get; }
	
	
		new NonNullableTypeBuilder ToMutable();
		new NonNullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NonNullableTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
	
		new NonNullableType ToImmutable();
		new NonNullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface PrimitiveType : SoalType, Declaration
	{
		bool Nullable { get; }
	
	
		new PrimitiveTypeBuilder ToMutable();
		new PrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PrimitiveTypeBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		bool Nullable { get; set; }
		Func<bool> NullableLazy { get; set; }
	
		new PrimitiveType ToImmutable();
		new PrimitiveType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Enum : SoalType, Declaration
	{
		Enum BaseType { get; }
		global::MetaDslx.Core.ImmutableModelList<EnumLiteral> EnumLiterals { get; }
	
	
		new EnumBuilder ToMutable();
		new EnumBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EnumBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		EnumBuilder BaseType { get; set; }
		Func<EnumBuilder> BaseTypeLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> EnumLiterals { get; }
	
		new Enum ToImmutable();
		new Enum ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface EnumLiteral : NamedElement, TypedElement, AnnotatedElement
	{
		Enum Enum { get; }
	
	
		new EnumLiteralBuilder ToMutable();
		new EnumLiteralBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EnumLiteralBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
		EnumBuilder Enum { get; set; }
		Func<EnumBuilder> EnumLazy { get; set; }
	
		new EnumLiteral ToImmutable();
		new EnumLiteral ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Property : NamedElement, TypedElement, AnnotatedElement
	{
	
	
		new PropertyBuilder ToMutable();
		new PropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PropertyBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
	
		new Property ToImmutable();
		new Property ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Struct : SoalType, Declaration
	{
		Struct BaseType { get; }
		global::MetaDslx.Core.ImmutableModelList<Property> Properties { get; }
	
	
		new StructBuilder ToMutable();
		new StructBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface StructBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		StructBuilder BaseType { get; set; }
		Func<StructBuilder> BaseTypeLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties { get; }
	
		new Struct ToImmutable();
		new Struct ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Interface : SoalType, Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Operation> Operations { get; }
	
	
		new InterfaceBuilder ToMutable();
		new InterfaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface InterfaceBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations { get; }
	
		new Interface ToImmutable();
		new Interface ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Database : Interface
	{
		global::MetaDslx.Core.ImmutableModelList<Struct> Entities { get; }
	
	
		new DatabaseBuilder ToMutable();
		new DatabaseBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DatabaseBuilder : InterfaceBuilder
	{
		global::MetaDslx.Core.MutableModelList<StructBuilder> Entities { get; }
	
		new Database ToImmutable();
		new Database ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Operation : NamedElement, AnnotatedElement
	{
		string Action { get; }
		global::MetaDslx.Core.ImmutableModelList<InputParameter> Parameters { get; }
		OutputParameter Result { get; }
		global::MetaDslx.Core.ImmutableModelList<Struct> Exceptions { get; }
	
	
		new OperationBuilder ToMutable();
		new OperationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface OperationBuilder : NamedElementBuilder, AnnotatedElementBuilder
	{
		string Action { get; set; }
		Func<string> ActionLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<InputParameterBuilder> Parameters { get; }
		OutputParameterBuilder Result { get; }
		Func<OutputParameterBuilder> ResultLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<StructBuilder> Exceptions { get; }
	
		new Operation ToImmutable();
		new Operation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface InputParameter : NamedElement, TypedElement, AnnotatedElement
	{
	
	
		new InputParameterBuilder ToMutable();
		new InputParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface InputParameterBuilder : NamedElementBuilder, TypedElementBuilder, AnnotatedElementBuilder
	{
	
		new InputParameter ToImmutable();
		new InputParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface OutputParameter : TypedElement, AnnotatedElement
	{
		bool IsOneway { get; }
	
	
		new OutputParameterBuilder ToMutable();
		new OutputParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface OutputParameterBuilder : TypedElementBuilder, AnnotatedElementBuilder
	{
		bool IsOneway { get; set; }
		Func<bool> IsOnewayLazy { get; set; }
	
		new OutputParameter ToImmutable();
		new OutputParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Component : Declaration
	{
		Component BaseComponent { get; }
		bool IsAbstract { get; }
		global::MetaDslx.Core.ImmutableModelList<Port> Ports { get; }
		global::MetaDslx.Core.ImmutableModelList<Service> Services { get; }
		global::MetaDslx.Core.ImmutableModelList<Reference> References { get; }
		global::MetaDslx.Core.ImmutableModelList<Property> Properties { get; }
		Implementation Implementation { get; }
		Language Language { get; }
	
	
		new ComponentBuilder ToMutable();
		new ComponentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ComponentBuilder : DeclarationBuilder
	{
		ComponentBuilder BaseComponent { get; set; }
		Func<ComponentBuilder> BaseComponentLazy { get; set; }
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<PortBuilder> Ports { get; }
		global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services { get; }
		global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References { get; }
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties { get; }
		ImplementationBuilder Implementation { get; set; }
		Func<ImplementationBuilder> ImplementationLazy { get; set; }
		LanguageBuilder Language { get; set; }
		Func<LanguageBuilder> LanguageLazy { get; set; }
	
		new Component ToImmutable();
		new Component ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Composite : Component
	{
		global::MetaDslx.Core.ImmutableModelList<Component> Components { get; }
		global::MetaDslx.Core.ImmutableModelList<Wire> Wires { get; }
	
	
		new CompositeBuilder ToMutable();
		new CompositeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface CompositeBuilder : ComponentBuilder
	{
		global::MetaDslx.Core.MutableModelList<ComponentBuilder> Components { get; }
		global::MetaDslx.Core.MutableModelList<WireBuilder> Wires { get; }
	
		new Composite ToImmutable();
		new Composite ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Assembly : Composite
	{
	
	
		new AssemblyBuilder ToMutable();
		new AssemblyBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface AssemblyBuilder : CompositeBuilder
	{
	
		new Assembly ToImmutable();
		new Assembly ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Wire : global::MetaDslx.Core.ImmutableSymbol
	{
		Port Source { get; }
		Port Target { get; }
	
	
		new WireBuilder ToMutable();
		new WireBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface WireBuilder : global::MetaDslx.Core.MutableSymbol
	{
		PortBuilder Source { get; set; }
		Func<PortBuilder> SourceLazy { get; set; }
		PortBuilder Target { get; set; }
		Func<PortBuilder> TargetLazy { get; set; }
	
		new Wire ToImmutable();
		new Wire ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Port : global::MetaDslx.Core.ImmutableSymbol
	{
		Component Component { get; }
		string Name { get; }
		string OptionalName { get; }
		Interface Interface { get; }
		Binding Binding { get; }
	
	
		new PortBuilder ToMutable();
		new PortBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PortBuilder : global::MetaDslx.Core.MutableSymbol
	{
		ComponentBuilder Component { get; set; }
		Func<ComponentBuilder> ComponentLazy { get; set; }
		string Name { get; }
		Func<string> NameLazy { get; set; }
		string OptionalName { get; set; }
		Func<string> OptionalNameLazy { get; set; }
		InterfaceBuilder Interface { get; set; }
		Func<InterfaceBuilder> InterfaceLazy { get; set; }
		BindingBuilder Binding { get; set; }
		Func<BindingBuilder> BindingLazy { get; set; }
	
		new Port ToImmutable();
		new Port ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Service : Port
	{
	
	
		new ServiceBuilder ToMutable();
		new ServiceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ServiceBuilder : PortBuilder
	{
	
		new Service ToImmutable();
		new Service ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Reference : Port
	{
	
	
		new ReferenceBuilder ToMutable();
		new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ReferenceBuilder : PortBuilder
	{
	
		new Reference ToImmutable();
		new Reference ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Implementation : NamedElement
	{
	
	
		new ImplementationBuilder ToMutable();
		new ImplementationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ImplementationBuilder : NamedElementBuilder
	{
	
		new Implementation ToImmutable();
		new Implementation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Language : NamedElement
	{
	
	
		new LanguageBuilder ToMutable();
		new LanguageBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface LanguageBuilder : NamedElementBuilder
	{
	
		new Language ToImmutable();
		new Language ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Deployment : Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Environment> Environments { get; }
		global::MetaDslx.Core.ImmutableModelList<Wire> Wires { get; }
	
	
		new DeploymentBuilder ToMutable();
		new DeploymentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DeploymentBuilder : DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<EnvironmentBuilder> Environments { get; }
		global::MetaDslx.Core.MutableModelList<WireBuilder> Wires { get; }
	
		new Deployment ToImmutable();
		new Deployment ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Environment : NamedElement
	{
		Runtime Runtime { get; }
		global::MetaDslx.Core.ImmutableModelList<Database> Databases { get; }
		global::MetaDslx.Core.ImmutableModelList<Assembly> Assemblies { get; }
	
	
		new EnvironmentBuilder ToMutable();
		new EnvironmentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EnvironmentBuilder : NamedElementBuilder
	{
		RuntimeBuilder Runtime { get; set; }
		Func<RuntimeBuilder> RuntimeLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<DatabaseBuilder> Databases { get; }
		global::MetaDslx.Core.MutableModelList<AssemblyBuilder> Assemblies { get; }
	
		new Environment ToImmutable();
		new Environment ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Runtime : NamedElement
	{
	
	
		new RuntimeBuilder ToMutable();
		new RuntimeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface RuntimeBuilder : NamedElementBuilder
	{
	
		new Runtime ToImmutable();
		new Runtime ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Binding : Declaration
	{
		TransportBindingElement Transport { get; }
		global::MetaDslx.Core.ImmutableModelList<EncodingBindingElement> Encodings { get; }
		global::MetaDslx.Core.ImmutableModelList<ProtocolBindingElement> Protocols { get; }
	
	
		new BindingBuilder ToMutable();
		new BindingBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface BindingBuilder : DeclarationBuilder
	{
		TransportBindingElementBuilder Transport { get; set; }
		Func<TransportBindingElementBuilder> TransportLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<EncodingBindingElementBuilder> Encodings { get; }
		global::MetaDslx.Core.MutableModelList<ProtocolBindingElementBuilder> Protocols { get; }
	
		new Binding ToImmutable();
		new Binding ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Endpoint : Declaration
	{
		Interface Interface { get; }
		Binding Binding { get; }
		string Address { get; }
	
	
		new EndpointBuilder ToMutable();
		new EndpointBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
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
		new Endpoint ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface BindingElement : NamedElement
	{
	
	
		new BindingElementBuilder ToMutable();
		new BindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface BindingElementBuilder : NamedElementBuilder
	{
	
		new BindingElement ToImmutable();
		new BindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface TransportBindingElement : BindingElement
	{
	
	
		new TransportBindingElementBuilder ToMutable();
		new TransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface TransportBindingElementBuilder : BindingElementBuilder
	{
	
		new TransportBindingElement ToImmutable();
		new TransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface EncodingBindingElement : BindingElement
	{
	
	
		new EncodingBindingElementBuilder ToMutable();
		new EncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EncodingBindingElementBuilder : BindingElementBuilder
	{
	
		new EncodingBindingElement ToImmutable();
		new EncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ProtocolBindingElement : BindingElement
	{
	
	
		new ProtocolBindingElementBuilder ToMutable();
		new ProtocolBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ProtocolBindingElementBuilder : BindingElementBuilder
	{
	
		new ProtocolBindingElement ToImmutable();
		new ProtocolBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface HttpTransportBindingElement : TransportBindingElement
	{
		bool Ssl { get; }
		bool ClientAuthentication { get; }
	
	
		new HttpTransportBindingElementBuilder ToMutable();
		new HttpTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface HttpTransportBindingElementBuilder : TransportBindingElementBuilder
	{
		bool Ssl { get; set; }
		Func<bool> SslLazy { get; set; }
		bool ClientAuthentication { get; set; }
		Func<bool> ClientAuthenticationLazy { get; set; }
	
		new HttpTransportBindingElement ToImmutable();
		new HttpTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface RestTransportBindingElement : TransportBindingElement
	{
	
	
		new RestTransportBindingElementBuilder ToMutable();
		new RestTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface RestTransportBindingElementBuilder : TransportBindingElementBuilder
	{
	
		new RestTransportBindingElement ToImmutable();
		new RestTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface WebSocketTransportBindingElement : TransportBindingElement
	{
	
	
		new WebSocketTransportBindingElementBuilder ToMutable();
		new WebSocketTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface WebSocketTransportBindingElementBuilder : TransportBindingElementBuilder
	{
	
		new WebSocketTransportBindingElement ToImmutable();
		new WebSocketTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface SoapEncodingBindingElement : EncodingBindingElement
	{
		SoapEncodingStyle Style { get; }
		SoapVersion Version { get; }
		bool Mtom { get; }
	
	
		new SoapEncodingBindingElementBuilder ToMutable();
		new SoapEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
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
		new SoapEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface XmlEncodingBindingElement : EncodingBindingElement
	{
	
	
		new XmlEncodingBindingElementBuilder ToMutable();
		new XmlEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface XmlEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
	
		new XmlEncodingBindingElement ToImmutable();
		new XmlEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface JsonEncodingBindingElement : EncodingBindingElement
	{
	
	
		new JsonEncodingBindingElementBuilder ToMutable();
		new JsonEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface JsonEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
	
		new JsonEncodingBindingElement ToImmutable();
		new JsonEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface WsProtocolBindingElement : ProtocolBindingElement
	{
	
	
		new WsProtocolBindingElementBuilder ToMutable();
		new WsProtocolBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface WsProtocolBindingElementBuilder : ProtocolBindingElementBuilder
	{
	
		new WsProtocolBindingElement ToImmutable();
		new WsProtocolBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface WsAddressingBindingElement : WsProtocolBindingElement
	{
	
	
		new WsAddressingBindingElementBuilder ToMutable();
		new WsAddressingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface WsAddressingBindingElementBuilder : WsProtocolBindingElementBuilder
	{
	
		new WsAddressingBindingElement ToImmutable();
		new WsAddressingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}

	public static class SoalDescriptor
	{
		private static global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty> properties;
	
		static SoalDescriptor()
		{
			properties = new global::System.Collections.Generic.List<global::MetaDslx.Core.ModelProperty>();
			AnnotatedElement.Initialize();
			Annotation.Initialize();
			AnnotationProperty.Initialize();
			NamedElement.Initialize();
			TypedElement.Initialize();
			SoalType.Initialize();
			Namespace.Initialize();
			Declaration.Initialize();
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
			Language.Initialize();
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
			properties.Add(SoalDescriptor.Annotation.AnnotatedElementProperty);
			properties.Add(SoalDescriptor.Annotation.PropertiesProperty);
			properties.Add(SoalDescriptor.AnnotationProperty.ValueProperty);
			properties.Add(SoalDescriptor.NamedElement.NameProperty);
			properties.Add(SoalDescriptor.TypedElement.TypeProperty);
			properties.Add(SoalDescriptor.Namespace.UriProperty);
			properties.Add(SoalDescriptor.Namespace.PrefixProperty);
			properties.Add(SoalDescriptor.Namespace.FullNameProperty);
			properties.Add(SoalDescriptor.Namespace.DeclarationsProperty);
			properties.Add(SoalDescriptor.Declaration.NamespaceProperty);
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
			properties.Add(SoalDescriptor.Port.NameProperty);
			properties.Add(SoalDescriptor.Port.OptionalNameProperty);
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
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElementBuilder))]
		public static class AnnotatedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static AnnotatedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(AnnotatedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotatedElement; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Annotation), "AnnotatedElement")]
			public static readonly global::MetaDslx.Core.ModelProperty AnnotationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(AnnotatedElement), "Annotations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Annotation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Annotation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotatedElement_Annotations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Annotation), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Annotation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Annotation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Annotation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Annotation; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.AnnotatedElement), "Annotations")]
			public static readonly global::MetaDslx.Core.ModelProperty AnnotatedElementProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Annotation), "AnnotatedElement",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElement), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotatedElementBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Annotation_AnnotatedElement);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Annotation), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Annotation_Properties);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationProperty), typeof(global::MetaDslx.Languages.Soal.Symbols.AnnotationPropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class AnnotationProperty
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static AnnotationProperty()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(AnnotationProperty));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotationProperty; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty ValueProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(AnnotationProperty), "Value",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(object), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(object), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.AnnotationProperty_Value);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.NamedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.NamedElementBuilder))]
		public static class NamedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static NamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NamedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NamedElement; }
			}
			
			[global::MetaDslx.Core.Name]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NamedElement), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NamedElement_Name);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.TypedElement), typeof(global::MetaDslx.Languages.Soal.Symbols.TypedElementBuilder))]
		public static class TypedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TypedElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TypedElement; }
			}
			
			[global::MetaDslx.Core.Type]
			public static readonly global::MetaDslx.Core.ModelProperty TypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(TypedElement), "Type",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TypedElement_Type);
		}
	
		[global::MetaDslx.Core.Type]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder))]
		public static class SoalType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static SoalType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(SoalType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoalType; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Namespace), typeof(global::MetaDslx.Languages.Soal.Symbols.NamespaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Namespace
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Namespace()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Namespace));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty UriProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "Uri",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Uri);
			
			public static readonly global::MetaDslx.Core.ModelProperty PrefixProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "Prefix",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Prefix);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty FullNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "FullName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_FullName);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Declaration), "Namespace")]
			public static readonly global::MetaDslx.Core.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "Declarations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Declaration), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Declaration>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Namespace_Declarations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Declaration), typeof(global::MetaDslx.Languages.Soal.Symbols.DeclarationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Declaration
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Declaration()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Declaration));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Declaration; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Namespace), "Declarations")]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Declaration), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Namespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.NamespaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Declaration_Namespace);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.ArrayType), typeof(global::MetaDslx.Languages.Soal.Symbols.ArrayTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class ArrayType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ArrayType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ArrayType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ArrayType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ArrayType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ArrayType_InnerType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.NullableType), typeof(global::MetaDslx.Languages.Soal.Symbols.NullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class NullableType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static NullableType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NullableType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NullableType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NullableType_InnerType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.NonNullableType), typeof(global::MetaDslx.Languages.Soal.Symbols.NonNullableTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType) })]
		public static class NonNullableType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static NonNullableType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(NonNullableType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NonNullableType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NonNullableType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoalTypeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.NonNullableType_InnerType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.PrimitiveType), typeof(global::MetaDslx.Languages.Soal.Symbols.PrimitiveTypeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class PrimitiveType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static PrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(PrimitiveType));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.PrimitiveType; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty NullableProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(PrimitiveType), "Nullable",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.PrimitiveType_Nullable);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Enum
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Enum()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Enum));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Enum), "BaseType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum_BaseType);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.EnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Enum), "EnumLiterals",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteral), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnumLiteral>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Enum_EnumLiterals);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteral), typeof(global::MetaDslx.Languages.Soal.Symbols.EnumLiteralBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class EnumLiteral
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static EnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(EnumLiteral));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EnumLiteral; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Enum), "EnumLiterals")]
			[global::MetaDslx.Core.RedefinesAttribute(typeof(SoalDescriptor.TypedElement), "Type")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(EnumLiteral), "Enum",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Enum), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnumBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EnumLiteral_Enum);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Property
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Property()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Property));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Property; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Struct
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Struct()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Struct));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Struct), "BaseType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct_BaseType);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Struct), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Property>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Struct_Properties);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration) })]
		public static class Interface
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Interface()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Interface));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Interface; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Interface), "Operations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Operation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Operation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OperationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.OperationBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Interface_Operations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Database), typeof(global::MetaDslx.Languages.Soal.Symbols.DatabaseBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Interface) })]
		public static class Database
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Database()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Database));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Database; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			public static readonly global::MetaDslx.Core.ModelProperty EntitiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Database), "Entities",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Struct>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.StructBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Database_Entities);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Operation), typeof(global::MetaDslx.Languages.Soal.Symbols.OperationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class Operation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Operation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Operation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty ActionProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Action",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Action);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ParametersProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Parameters",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameter), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.InputParameter>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Parameters);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ResultProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Result",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameter), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameterBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Result);
			
			public static readonly global::MetaDslx.Core.ModelProperty ExceptionsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Exceptions",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Struct), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Struct>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.StructBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.StructBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Operation_Exceptions);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameter), typeof(global::MetaDslx.Languages.Soal.Symbols.InputParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class InputParameter
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static InputParameter()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(InputParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.InputParameter; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameter), typeof(global::MetaDslx.Languages.Soal.Symbols.OutputParameterBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TypedElement), typeof(SoalDescriptor.AnnotatedElement) })]
		public static class OutputParameter
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static OutputParameter()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(OutputParameter));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.OutputParameter; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty IsOnewayProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(OutputParameter), "IsOneway",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.OutputParameter_IsOneway);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Component
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Component()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Component));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseComponentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "BaseComponent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_BaseComponent);
			
			public static readonly global::MetaDslx.Core.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "IsAbstract",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_IsAbstract);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Port), "Component")]
			public static readonly global::MetaDslx.Core.ModelProperty PortsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Ports",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Port>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PortBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Ports);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.SubsetsAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Core.ModelProperty ServicesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Services",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Service), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Service>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Services);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.SubsetsAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Core.ModelProperty ReferencesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "References",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Reference), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Reference>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_References);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Property), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Property>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.PropertyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Properties);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ImplementationProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Implementation",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Implementation), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ImplementationBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Implementation);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty LanguageProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Language",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Language), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.LanguageBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Component_Language);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Composite), typeof(global::MetaDslx.Languages.Soal.Symbols.CompositeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Component) })]
		public static class Composite
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Composite()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Composite));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			public static readonly global::MetaDslx.Core.ModelProperty ComponentsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Composite), "Components",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Component>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite_Components);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty WiresProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Composite), "Wires",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Wire>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.WireBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Composite_Wires);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Assembly), typeof(global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Composite) })]
		public static class Assembly
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Assembly()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Assembly));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Assembly; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder))]
		public static class Wire
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Wire()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Wire));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty SourceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Wire), "Source",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire_Source);
			
			public static readonly global::MetaDslx.Core.ModelProperty TargetProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Wire), "Target",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Wire_Target);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Port), typeof(global::MetaDslx.Languages.Soal.Symbols.PortBuilder))]
		public static class Port
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Port()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Port));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Component), "Ports")]
			public static readonly global::MetaDslx.Core.ModelProperty ComponentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Port), "Component",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Component), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ComponentBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Component);
			
			[global::MetaDslx.Core.Name]
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Port), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Name);
			
			public static readonly global::MetaDslx.Core.ModelProperty OptionalNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Port), "OptionalName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_OptionalName);
			
			public static readonly global::MetaDslx.Core.ModelProperty InterfaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Port), "Interface",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Interface);
			
			public static readonly global::MetaDslx.Core.ModelProperty BindingProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Port), "Binding",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Port_Binding);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Service), typeof(global::MetaDslx.Languages.Soal.Symbols.ServiceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Port) })]
		public static class Service
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Service()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Service));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Service; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Reference), typeof(global::MetaDslx.Languages.Soal.Symbols.ReferenceBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Port) })]
		public static class Reference
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Reference()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Reference));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Reference; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Implementation), typeof(global::MetaDslx.Languages.Soal.Symbols.ImplementationBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Implementation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Implementation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Implementation));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Implementation; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Language), typeof(global::MetaDslx.Languages.Soal.Symbols.LanguageBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Language
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Language()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Language));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Language; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Deployment), typeof(global::MetaDslx.Languages.Soal.Symbols.DeploymentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Deployment
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Deployment()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Deployment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty EnvironmentsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Deployment), "Environments",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Environment), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Environment>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment_Environments);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty WiresProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Deployment), "Wires",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Wire), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Wire>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.WireBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.WireBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Deployment_Wires);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Environment), typeof(global::MetaDslx.Languages.Soal.Symbols.EnvironmentBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Environment
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Environment()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Environment));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty RuntimeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Runtime",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Runtime), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.RuntimeBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Runtime);
			
			public static readonly global::MetaDslx.Core.ModelProperty DatabasesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Databases",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Database), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Database>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.DatabaseBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.DatabaseBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Databases);
			
			public static readonly global::MetaDslx.Core.ModelProperty AssembliesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Assemblies",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Assembly), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.Assembly>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.AssemblyBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Environment_Assemblies);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Runtime), typeof(global::MetaDslx.Languages.Soal.Symbols.RuntimeBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class Runtime
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Runtime()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Runtime));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Runtime; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Binding
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Binding()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Binding));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TransportProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Transport",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElement), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElementBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Transport);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty EncodingsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Encodings",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Encodings);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ProtocolsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Protocols",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder>)),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Binding_Protocols);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.Endpoint), typeof(global::MetaDslx.Languages.Soal.Symbols.EndpointBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.Declaration) })]
		public static class Endpoint
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Endpoint()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(Endpoint));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InterfaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Interface",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Interface), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.InterfaceBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Interface);
			
			public static readonly global::MetaDslx.Core.ModelProperty BindingProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Binding",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.Binding), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.BindingBuilder), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Binding);
			
			public static readonly global::MetaDslx.Core.ModelProperty AddressProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Address",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.Endpoint_Address);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.BindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.BindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.NamedElement) })]
		public static class BindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static BindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(BindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.BindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.TransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class TransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(TransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.TransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.EncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class EncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static EncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(EncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.EncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.ProtocolBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.BindingElement) })]
		public static class ProtocolBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(ProtocolBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.ProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.HttpTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.HttpTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class HttpTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static HttpTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(HttpTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty SslProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(HttpTransportBindingElement), "Ssl",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement_Ssl);
			
			public static readonly global::MetaDslx.Core.ModelProperty ClientAuthenticationProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(HttpTransportBindingElement), "ClientAuthentication",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.HttpTransportBindingElement_ClientAuthentication);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.RestTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.RestTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class RestTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static RestTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(RestTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.RestTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.WebSocketTransportBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WebSocketTransportBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.TransportBindingElement) })]
		public static class WebSocketTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WebSocketTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WebSocketTransportBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.WebSocketTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class SoapEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static SoapEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(SoapEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty StyleProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Style",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingStyle), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapEncodingStyle), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Style);
			
			public static readonly global::MetaDslx.Core.ModelProperty VersionProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Version",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapVersion), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Languages.Soal.Symbols.SoapVersion), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Version);
			
			public static readonly global::MetaDslx.Core.ModelProperty MtomProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Mtom",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Languages.Soal.Symbols.SoalInstance.SoapEncodingBindingElement_Mtom);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.XmlEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.XmlEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class XmlEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static XmlEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(XmlEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.XmlEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.JsonEncodingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.JsonEncodingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.EncodingBindingElement) })]
		public static class JsonEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static JsonEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(JsonEncodingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.JsonEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.WsProtocolBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WsProtocolBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.ProtocolBindingElement) })]
		public static class WsProtocolBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WsProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WsProtocolBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Languages.Meta.Symbols.MetaClass MetaClass
			{
				get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.WsProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(global::MetaDslx.Languages.Soal.Symbols.WsAddressingBindingElement), typeof(global::MetaDslx.Languages.Soal.Symbols.WsAddressingBindingElementBuilder), BaseSymbolDescriptors = new global::System.Type[] { typeof(SoalDescriptor.WsProtocolBindingElement) })]
		public static class WsAddressingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WsAddressingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetDescriptorSymbolInfo(typeof(WsAddressingBindingElement));
			}
		
			internal static void Initialize()
			{
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo SymbolInfo
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
	
	internal class AnnotatedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new AnnotatedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new AnnotatedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotatedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, AnnotatedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
	
		internal AnnotatedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new AnnotatedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (AnnotatedElementBuilder)base.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
		{
		    get { return this.GetList<Annotation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class AnnotatedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, AnnotatedElementBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal AnnotatedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new AnnotatedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (AnnotatedElement)base.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
		{
			get { return this.GetList<AnnotationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotatedElement.AnnotationsProperty, ref annotations0); }
		}
	}
	
	internal class AnnotationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new AnnotationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new AnnotationBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationImpl : global::MetaDslx.Core.ImmutableSymbolBase, Annotation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private AnnotatedElement annotatedElement0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<AnnotationProperty> properties0;
	
		internal AnnotationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new AnnotationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (AnnotationBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public AnnotatedElement AnnotatedElement
		{
		    get { return this.GetReference<AnnotatedElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.AnnotatedElementProperty, ref annotatedElement0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<AnnotationProperty> Properties
		{
		    get { return this.GetList<AnnotationProperty>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	
		
		bool Annotation.HasProperty(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.Annotation_HasProperty(this, name);
		}
	
		
		AnnotationProperty Annotation.GetProperty(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.Annotation_GetProperty(this, name);
		}
	
		
		object Annotation.GetPropertyValue(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.Annotation_GetPropertyValue(this, name);
		}
	}
	
	internal class AnnotationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, AnnotationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationPropertyBuilder> properties0;
	
		internal AnnotationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Annotation ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Annotation)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public AnnotatedElementBuilder AnnotatedElement
		{
			get { return this.GetReference<AnnotatedElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.AnnotatedElementProperty); }
			set { this.SetReference<AnnotatedElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.AnnotatedElementProperty, value); }
		}
		
		public Func<AnnotatedElementBuilder> AnnotatedElementLazy
		{
			get { return this.GetLazyReference<AnnotatedElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.AnnotatedElementProperty); }
			set { this.SetLazyReference(SoalDescriptor.Annotation.AnnotatedElementProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationPropertyBuilder> Properties
		{
			get { return this.GetList<AnnotationPropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Annotation.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class AnnotationPropertyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new AnnotationPropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new AnnotationPropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class AnnotationPropertyImpl : global::MetaDslx.Core.ImmutableSymbolBase, AnnotationProperty
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object value0;
	
		internal AnnotationPropertyImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new AnnotationPropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (AnnotationPropertyBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public object Value
		{
		    get { return this.GetReference<object>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.AnnotationProperty.ValueProperty, ref value0); }
		}
	}
	
	internal class AnnotationPropertyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, AnnotationPropertyBuilder
	{
	
		internal AnnotationPropertyBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new AnnotationProperty ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (AnnotationProperty)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class NamedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new NamedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new NamedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, NamedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal NamedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new NamedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (NamedElementBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class NamedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NamedElementBuilder
	{
	
		internal NamedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new NamedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (NamedElement)base.ToImmutable(model);
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
	
	internal class TypedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TypedElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TypedElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class TypedElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, TypedElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
	
		internal TypedElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new TypedElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TypedElementBuilder)base.ToMutable(model);
		}
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	}
	
	internal class TypedElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TypedElementBuilder
	{
	
		internal TypedElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new TypedElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class SoalTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoalType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new SoalTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new SoalTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class SoalTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, SoalType
	{
	
		internal SoalTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new SoalTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (SoalTypeBuilder)base.ToMutable(model);
		}
	}
	
	internal class SoalTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, SoalTypeBuilder
	{
	
		internal SoalTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new SoalType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (SoalType)base.ToImmutable(model);
		}
	}
	
	internal class NamespaceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new NamespaceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new NamespaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class NamespaceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Namespace
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string uri0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string prefix0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string fullName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Declaration> declarations0;
	
		internal NamespaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new NamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (NamespaceBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public string Uri
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.UriProperty, ref uri0); }
		}
	
		
		public string Prefix
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.PrefixProperty, ref prefix0); }
		}
	
		
		public string FullName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.FullNameProperty, ref fullName0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class NamespaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NamespaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<DeclarationBuilder> declarations0;
	
		internal NamespaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Namespace ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Namespace)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public string FullName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.FullNameProperty); }
		}
		
		public Func<string> FullNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.FullNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Namespace.FullNameProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class DeclarationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Declaration.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new DeclarationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new DeclarationBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeclarationImpl : global::MetaDslx.Core.ImmutableSymbolBase, Declaration
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
	
		internal DeclarationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new DeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (DeclarationBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DeclarationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal DeclarationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Declaration ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Declaration)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	}
	
	internal class ArrayTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ArrayTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ArrayTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class ArrayTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, ArrayType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal ArrayTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ArrayTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ArrayTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ArrayType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class ArrayTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ArrayTypeBuilder
	{
	
		internal ArrayTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new ArrayType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (ArrayType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class NullableTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new NullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new NullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class NullableTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, NullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal NullableTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new NullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (NullableTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class NullableTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NullableTypeBuilder
	{
	
		internal NullableTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new NullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (NullableType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class NonNullableTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new NonNullableTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new NonNullableTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class NonNullableTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, NonNullableType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType innerType0;
	
		internal NonNullableTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new NonNullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (NonNullableTypeBuilder)base.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public SoalType InnerType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NonNullableType.InnerTypeProperty, ref innerType0); }
		}
	}
	
	internal class NonNullableTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NonNullableTypeBuilder
	{
	
		internal NonNullableTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new NonNullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (NonNullableType)base.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class PrimitiveTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new PrimitiveTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new PrimitiveTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class PrimitiveTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, PrimitiveType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool nullable0;
	
		internal PrimitiveTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new PrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (PrimitiveTypeBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public bool Nullable
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.PrimitiveType.NullableProperty, ref nullable0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class PrimitiveTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PrimitiveTypeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal PrimitiveTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new PrimitiveType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (PrimitiveType)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class EnumId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EnumImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EnumBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnumImpl : global::MetaDslx.Core.ImmutableSymbolBase, Enum
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Enum baseType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<EnumLiteral> enumLiterals0;
	
		internal EnumImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new EnumBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EnumBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public Enum BaseType
		{
		    get { return this.GetReference<Enum>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.BaseTypeProperty, ref baseType0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<EnumLiteral> EnumLiterals
		{
		    get { return this.GetList<EnumLiteral>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class EnumBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EnumBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> enumLiterals0;
	
		internal EnumBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Enum ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Enum)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<EnumLiteralBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	}
	
	internal class EnumLiteralId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EnumLiteral.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EnumLiteralImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EnumLiteralBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnumLiteralImpl : global::MetaDslx.Core.ImmutableSymbolBase, EnumLiteral
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Enum enum0;
	
		internal EnumLiteralImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new EnumLiteralBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EnumLiteralBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class EnumLiteralBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EnumLiteralBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal EnumLiteralBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new EnumLiteral ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (EnumLiteral)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class PropertyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Property.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new PropertyImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new PropertyBuilderImpl(this, model, creating);
		}
	}
	
	internal class PropertyImpl : global::MetaDslx.Core.ImmutableSymbolBase, Property
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal PropertyImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new PropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (PropertyBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class PropertyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PropertyBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal PropertyBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Property ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Property)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class StructId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new StructImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new StructBuilderImpl(this, model, creating);
		}
	}
	
	internal class StructImpl : global::MetaDslx.Core.ImmutableSymbolBase, Struct
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Struct baseType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
	
		internal StructImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new StructBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (StructBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public Struct BaseType
		{
		    get { return this.GetReference<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.BaseTypeProperty, ref baseType0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.PropertiesProperty, ref properties0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class StructBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, StructBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal StructBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Struct ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Struct)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Struct.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class InterfaceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new InterfaceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new InterfaceBuilderImpl(this, model, creating);
		}
	}
	
	internal class InterfaceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Interface
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Operation> operations0;
	
		internal InterfaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new InterfaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (InterfaceBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class InterfaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, InterfaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<OperationBuilder> operations0;
	
		internal InterfaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Interface ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Interface)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	}
	
	internal class DatabaseId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new DatabaseImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new DatabaseBuilderImpl(this, model, creating);
		}
	}
	
	internal class DatabaseImpl : global::MetaDslx.Core.ImmutableSymbolBase, Database
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Operation> operations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Struct> entities0;
	
		internal DatabaseImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new DatabaseBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (DatabaseBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		InterfaceBuilder Interface.ToMutable()
		{
			return this.ToMutable();
		}
	
		InterfaceBuilder Interface.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Struct> Entities
		{
		    get { return this.GetList<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class DatabaseBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DatabaseBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<OperationBuilder> operations0;
		private global::MetaDslx.Core.MutableModelList<StructBuilder> entities0;
	
		internal DatabaseBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Database ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Database)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Interface InterfaceBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Interface InterfaceBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<StructBuilder> Entities
		{
			get { return this.GetList<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	}
	
	internal class OperationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new OperationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new OperationBuilderImpl(this, model, creating);
		}
	}
	
	internal class OperationImpl : global::MetaDslx.Core.ImmutableSymbolBase, Operation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string action0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<InputParameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private OutputParameter result0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Struct> exceptions0;
	
		internal OperationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new OperationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (OperationBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<InputParameter> Parameters
		{
		    get { return this.GetList<InputParameter>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public OutputParameter Result
		{
		    get { return this.GetReference<OutputParameter>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty, ref result0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Struct> Exceptions
		{
		    get { return this.GetList<Struct>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class OperationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, OperationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<InputParameterBuilder> parameters0;
		private global::MetaDslx.Core.MutableModelList<StructBuilder> exceptions0;
	
		internal OperationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Operation ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Operation)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<InputParameterBuilder> Parameters
		{
			get { return this.GetList<InputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public OutputParameterBuilder Result
		{
			get { return this.GetReference<OutputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty); }
		}
		
		public Func<OutputParameterBuilder> ResultLazy
		{
			get { return this.GetLazyReference<OutputParameterBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ResultProperty); }
			set { this.SetLazyReference(SoalDescriptor.Operation.ResultProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<StructBuilder> Exceptions
		{
			get { return this.GetList<StructBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	}
	
	internal class InputParameterId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.InputParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new InputParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new InputParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class InputParameterImpl : global::MetaDslx.Core.ImmutableSymbolBase, InputParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal InputParameterImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new InputParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (InputParameterBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class InputParameterBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, InputParameterBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal InputParameterBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new InputParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (InputParameter)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class OutputParameterId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.OutputParameter.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new OutputParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new OutputParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class OutputParameterImpl : global::MetaDslx.Core.ImmutableSymbolBase, OutputParameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isOneway0;
	
		internal OutputParameterImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new OutputParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (OutputParameterBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TypedElementBuilder TypedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TypedElementBuilder TypedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class OutputParameterBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, OutputParameterBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal OutputParameterBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new OutputParameter ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (OutputParameter)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TypedElement TypedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TypedElement TypedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class ComponentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ComponentImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ComponentBuilderImpl(this, model, creating);
		}
	}
	
	internal class ComponentImpl : global::MetaDslx.Core.ImmutableSymbolBase, Component
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Language language0;
	
		internal ComponentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ComponentBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ComponentBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class ComponentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ComponentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal ComponentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Component ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Component)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
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
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	}
	
	internal class CompositeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new CompositeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new CompositeBuilderImpl(this, model, creating);
		}
	}
	
	internal class CompositeImpl : global::MetaDslx.Core.ImmutableSymbolBase, Composite
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Language language0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Component> components0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Wire> wires0;
	
		internal CompositeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new CompositeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (CompositeBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ComponentBuilder Component.ToMutable()
		{
			return this.ToMutable();
		}
	
		ComponentBuilder Component.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class CompositeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, CompositeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<ComponentBuilder> components0;
		private global::MetaDslx.Core.MutableModelList<WireBuilder> wires0;
	
		internal CompositeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Composite ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Composite)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Component ComponentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Component ComponentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
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
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class AssemblyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Assembly.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new AssemblyImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new AssemblyBuilderImpl(this, model, creating);
		}
	}
	
	internal class AssemblyImpl : global::MetaDslx.Core.ImmutableSymbolBase, Assembly
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Port> ports0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Language language0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Component> components0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Wire> wires0;
	
		internal AssemblyImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new AssemblyBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (AssemblyBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ComponentBuilder Component.ToMutable()
		{
			return this.ToMutable();
		}
	
		ComponentBuilder Component.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		CompositeBuilder Composite.ToMutable()
		{
			return this.ToMutable();
		}
	
		CompositeBuilder Composite.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Port> Ports
		{
		    get { return this.GetList<Port>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PropertiesProperty, ref properties0); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class AssemblyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, AssemblyBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<PortBuilder> ports0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<ComponentBuilder> components0;
		private global::MetaDslx.Core.MutableModelList<WireBuilder> wires0;
	
		internal AssemblyBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Assembly ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Assembly)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Component ComponentBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Component ComponentBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Composite CompositeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Composite CompositeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<PortBuilder> Ports
		{
			get { return this.GetList<PortBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.PortsProperty, ref ports0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
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
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class WireId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Wire.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new WireImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new WireBuilderImpl(this, model, creating);
		}
	}
	
	internal class WireImpl : global::MetaDslx.Core.ImmutableSymbolBase, Wire
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Port source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Port target0;
	
		internal WireImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new WireBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
	internal class WireBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, WireBuilder
	{
	
		internal WireBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Wire ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
	internal class PortId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new PortImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new PortBuilderImpl(this, model, creating);
		}
	}
	
	internal class PortImpl : global::MetaDslx.Core.ImmutableSymbolBase, Port
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string optionalName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal PortImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new PortBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (PortBuilder)base.ToMutable(model);
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	}
	
	internal class PortBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PortBuilder
	{
	
		internal PortBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Port ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Port)base.ToImmutable(model);
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.OptionalNameProperty, value); }
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
	
	internal class ServiceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Service.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ServiceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ServiceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ServiceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Service
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string optionalName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal ServiceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ServiceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ServiceBuilder)base.ToMutable(model);
		}
	
		PortBuilder Port.ToMutable()
		{
			return this.ToMutable();
		}
	
		PortBuilder Port.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	}
	
	internal class ServiceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ServiceBuilder
	{
	
		internal ServiceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Service ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Service)base.ToImmutable(model);
		}
	
		Port PortBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Port PortBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.OptionalNameProperty, value); }
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
	
	internal class ReferenceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Reference.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class ReferenceImpl : global::MetaDslx.Core.ImmutableSymbolBase, Reference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component component0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string optionalName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal ReferenceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ReferenceBuilder)base.ToMutable(model);
		}
	
		PortBuilder Port.ToMutable()
		{
			return this.ToMutable();
		}
	
		PortBuilder Port.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public Component Component
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.ComponentProperty, ref component0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.BindingProperty, ref binding0); }
		}
	}
	
	internal class ReferenceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ReferenceBuilder
	{
	
		internal ReferenceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Reference ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Reference)base.ToImmutable(model);
		}
	
		Port PortBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Port PortBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Port.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.Port.OptionalNameProperty, value); }
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
	
	internal class ImplementationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Implementation.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ImplementationImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ImplementationBuilderImpl(this, model, creating);
		}
	}
	
	internal class ImplementationImpl : global::MetaDslx.Core.ImmutableSymbolBase, Implementation
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ImplementationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ImplementationBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ImplementationBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class ImplementationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ImplementationBuilder
	{
	
		internal ImplementationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Implementation ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Implementation)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class LanguageId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Language.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new LanguageImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new LanguageBuilderImpl(this, model, creating);
		}
	}
	
	internal class LanguageImpl : global::MetaDslx.Core.ImmutableSymbolBase, Language
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal LanguageImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Language; }
		}
	
		public new LanguageBuilder ToMutable()
		{
			return (LanguageBuilder)base.ToMutable();
		}
	
		public new LanguageBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (LanguageBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class LanguageBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, LanguageBuilder
	{
	
		internal LanguageBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Language(this);
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Languages.Soal.Symbols.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Languages.Meta.Symbols.MetaClass MMetaClass
		{
			get { return SoalInstance.Language; }
		}
	
		public new Language ToImmutable()
		{
			return (Language)base.ToImmutable();
		}
	
		public new Language ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Language)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class DeploymentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new DeploymentImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new DeploymentBuilderImpl(this, model, creating);
		}
	}
	
	internal class DeploymentImpl : global::MetaDslx.Core.ImmutableSymbolBase, Deployment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Environment> environments0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Wire> wires0;
	
		internal DeploymentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new DeploymentBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (DeploymentBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public global::MetaDslx.Core.ImmutableModelList<Environment> Environments
		{
		    get { return this.GetList<Environment>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class DeploymentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DeploymentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<EnvironmentBuilder> environments0;
		private global::MetaDslx.Core.MutableModelList<WireBuilder> wires0;
	
		internal DeploymentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Deployment ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Deployment)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<EnvironmentBuilder> Environments
		{
			get { return this.GetList<EnvironmentBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	}
	
	internal class EnvironmentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EnvironmentImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EnvironmentBuilderImpl(this, model, creating);
		}
	}
	
	internal class EnvironmentImpl : global::MetaDslx.Core.ImmutableSymbolBase, Environment
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Runtime runtime0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Database> databases0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Assembly> assemblies0;
	
		internal EnvironmentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new EnvironmentBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EnvironmentBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Runtime Runtime
		{
		    get { return this.GetReference<Runtime>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.RuntimeProperty, ref runtime0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Database> Databases
		{
		    get { return this.GetList<Database>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Assembly> Assemblies
		{
		    get { return this.GetList<Assembly>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
		}
	}
	
	internal class EnvironmentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EnvironmentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<DatabaseBuilder> databases0;
		private global::MetaDslx.Core.MutableModelList<AssemblyBuilder> assemblies0;
	
		internal EnvironmentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Environment ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Environment)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
		
		public global::MetaDslx.Core.MutableModelList<DatabaseBuilder> Databases
		{
			get { return this.GetList<DatabaseBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AssemblyBuilder> Assemblies
		{
			get { return this.GetList<AssemblyBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
		}
	}
	
	internal class RuntimeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Runtime.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new RuntimeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new RuntimeBuilderImpl(this, model, creating);
		}
	}
	
	internal class RuntimeImpl : global::MetaDslx.Core.ImmutableSymbolBase, Runtime
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal RuntimeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new RuntimeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (RuntimeBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class RuntimeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, RuntimeBuilder
	{
	
		internal RuntimeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Runtime ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Runtime)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class BindingId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new BindingImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new BindingBuilderImpl(this, model, creating);
		}
	}
	
	internal class BindingImpl : global::MetaDslx.Core.ImmutableSymbolBase, Binding
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TransportBindingElement transport0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<EncodingBindingElement> encodings0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<ProtocolBindingElement> protocols0;
	
		internal BindingImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new BindingBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (BindingBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		public TransportBindingElement Transport
		{
		    get { return this.GetReference<TransportBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.TransportProperty, ref transport0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<EncodingBindingElement> Encodings
		{
		    get { return this.GetList<EncodingBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<ProtocolBindingElement> Protocols
		{
		    get { return this.GetList<ProtocolBindingElement>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class BindingBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, BindingBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
		private global::MetaDslx.Core.MutableModelList<EncodingBindingElementBuilder> encodings0;
		private global::MetaDslx.Core.MutableModelList<ProtocolBindingElementBuilder> protocols0;
	
		internal BindingBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Binding ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Binding)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
		
		public global::MetaDslx.Core.MutableModelList<EncodingBindingElementBuilder> Encodings
		{
			get { return this.GetList<EncodingBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ProtocolBindingElementBuilder> Protocols
		{
			get { return this.GetList<ProtocolBindingElementBuilder>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	}
	
	internal class EndpointId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.Endpoint.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EndpointImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EndpointBuilderImpl(this, model, creating);
		}
	}
	
	internal class EndpointImpl : global::MetaDslx.Core.ImmutableSymbolBase, Endpoint
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Annotation> annotations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string address0;
	
		internal EndpointImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new EndpointBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EndpointBuilder)base.ToMutable(model);
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		AnnotatedElementBuilder AnnotatedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		DeclarationBuilder Declaration.ToMutable()
		{
			return this.ToMutable();
		}
	
		DeclarationBuilder Declaration.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Annotation> Annotations
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
	
		
		bool AnnotatedElement.HasAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotation(this, name);
		}
	
		
		Annotation AnnotatedElement.GetAnnotation(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotation(this, name);
		}
	
		
		global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement.GetAnnotations(string name)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotations(this, name);
		}
	
		
		bool AnnotatedElement.HasAnnotationProperty(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_HasAnnotationProperty(this, annotationName, propertyName);
		}
	
		
		object AnnotatedElement.GetAnnotationPropertyValue(string annotationName, string propertyName)
		{
		    return global::MetaDslx.Languages.Soal.Symbols.Internal.SoalImplementationProvider.Implementation.AnnotatedElement_GetAnnotationPropertyValue(this, annotationName, propertyName);
		}
	}
	
	internal class EndpointBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EndpointBuilder
	{
		private global::MetaDslx.Core.MutableModelList<AnnotationBuilder> annotations0;
	
		internal EndpointBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new Endpoint ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Endpoint)base.ToImmutable(model);
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		AnnotatedElement AnnotatedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		Declaration DeclarationBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		Declaration DeclarationBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AnnotationBuilder> Annotations
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
	
	internal class BindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.BindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new BindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new BindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class BindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, BindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal BindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new BindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (BindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class BindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, BindingElementBuilder
	{
	
		internal BindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new BindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (BindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class TransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.TransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new TransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new TransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class TransportBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, TransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal TransportBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new TransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (TransportBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class TransportBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, TransportBindingElementBuilder
	{
	
		internal TransportBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new TransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (TransportBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class EncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.EncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class EncodingBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, EncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal EncodingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new EncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class EncodingBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EncodingBindingElementBuilder
	{
	
		internal EncodingBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new EncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (EncodingBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class ProtocolBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.ProtocolBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ProtocolBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ProtocolBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class ProtocolBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, ProtocolBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal ProtocolBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new ProtocolBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ProtocolBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class ProtocolBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ProtocolBindingElementBuilder
	{
	
		internal ProtocolBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new ProtocolBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (ProtocolBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class HttpTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.HttpTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new HttpTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new HttpTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class HttpTransportBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, HttpTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool ssl0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool clientAuthentication0;
	
		internal HttpTransportBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new HttpTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (HttpTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
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
	}
	
	internal class HttpTransportBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, HttpTransportBindingElementBuilder
	{
	
		internal HttpTransportBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new HttpTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (HttpTransportBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class RestTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.RestTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new RestTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new RestTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class RestTransportBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, RestTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal RestTransportBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new RestTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (RestTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class RestTransportBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, RestTransportBindingElementBuilder
	{
	
		internal RestTransportBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new RestTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (RestTransportBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class WebSocketTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WebSocketTransportBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new WebSocketTransportBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new WebSocketTransportBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WebSocketTransportBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, WebSocketTransportBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WebSocketTransportBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new WebSocketTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (WebSocketTransportBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		TransportBindingElementBuilder TransportBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class WebSocketTransportBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, WebSocketTransportBindingElementBuilder
	{
	
		internal WebSocketTransportBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new WebSocketTransportBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (WebSocketTransportBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		TransportBindingElement TransportBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class SoapEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.SoapEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new SoapEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new SoapEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class SoapEncodingBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, SoapEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoapEncodingStyle style0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoapVersion version0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool mtom0;
	
		internal SoapEncodingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new SoapEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (SoapEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
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
	}
	
	internal class SoapEncodingBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, SoapEncodingBindingElementBuilder
	{
	
		internal SoapEncodingBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new SoapEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (SoapEncodingBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class XmlEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.XmlEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new XmlEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new XmlEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class XmlEncodingBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, XmlEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal XmlEncodingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new XmlEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (XmlEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class XmlEncodingBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, XmlEncodingBindingElementBuilder
	{
	
		internal XmlEncodingBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new XmlEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (XmlEncodingBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class JsonEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.JsonEncodingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new JsonEncodingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new JsonEncodingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class JsonEncodingBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, JsonEncodingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal JsonEncodingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new JsonEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (JsonEncodingBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		EncodingBindingElementBuilder EncodingBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class JsonEncodingBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, JsonEncodingBindingElementBuilder
	{
	
		internal JsonEncodingBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new JsonEncodingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (JsonEncodingBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		EncodingBindingElement EncodingBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class WsProtocolBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WsProtocolBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new WsProtocolBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new WsProtocolBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WsProtocolBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, WsProtocolBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WsProtocolBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new WsProtocolBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (WsProtocolBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class WsProtocolBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, WsProtocolBindingElementBuilder
	{
	
		internal WsProtocolBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new WsProtocolBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (WsProtocolBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
	
	internal class WsAddressingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo SymbolInfo { get { return global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.WsAddressingBindingElement.SymbolInfo; } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new WsAddressingBindingElementImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new WsAddressingBindingElementBuilderImpl(this, model, creating);
		}
	}
	
	internal class WsAddressingBindingElementImpl : global::MetaDslx.Core.ImmutableSymbolBase, WsAddressingBindingElement
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
	
		internal WsAddressingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
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
	
		public new WsAddressingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (WsAddressingBindingElementBuilder)base.ToMutable(model);
		}
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		BindingElementBuilder BindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		BindingElementBuilder BindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		ProtocolBindingElementBuilder ProtocolBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		WsProtocolBindingElementBuilder WsProtocolBindingElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		WsProtocolBindingElementBuilder WsProtocolBindingElement.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Languages.Soal.Symbols.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class WsAddressingBindingElementBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, WsAddressingBindingElementBuilder
	{
	
		internal WsAddressingBindingElementBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
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
	
		public new WsAddressingBindingElement ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (WsAddressingBindingElement)base.ToImmutable(model);
		}
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		BindingElement BindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		BindingElement BindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		ProtocolBindingElement ProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		WsProtocolBindingElement WsProtocolBindingElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		WsProtocolBindingElement WsProtocolBindingElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
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
		internal global::MetaDslx.Core.MutableModel Model;
		internal global::MetaDslx.Core.MutableModelGroup ModelGroup;
	
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
		private global::MetaDslx.Languages.Meta.Symbols.MetaNamespaceBuilder __tmp5;
		private global::MetaDslx.Languages.Meta.Symbols.MetaModelBuilder __tmp6;
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
		private global::MetaDslx.Languages.Meta.Symbols.MetaConstantBuilder __tmp19;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder AnnotatedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Annotation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder AnnotationProperty;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NamedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TypedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder SoalType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Namespace;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Declaration;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ArrayType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NullableType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder NonNullableType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder PrimitiveType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Enum;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder EnumLiteral;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Property;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Struct;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Database;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Operation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder InputParameter;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder OutputParameter;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Component;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Composite;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Assembly;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Wire;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Port;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Service;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Reference;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Implementation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Language;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Deployment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Environment;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Runtime;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Binding;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder Endpoint;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder BindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder TransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder EncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder ProtocolBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder HttpTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder RestTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WebSocketTransportBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder SoapVersion;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaEnumBuilder SoapEncodingStyle;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder SoapEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder XmlEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder JsonEncodingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WsProtocolBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaClassBuilder WsAddressingBindingElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Annotation_AnnotatedElement;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Annotation_Properties;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp20;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp21;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp22;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder AnnotatedElement_Annotations;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp23;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp24;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp25;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp26;
		private global::MetaDslx.Languages.Meta.Symbols.MetaOperationBuilder __tmp27;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp28;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Uri;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Prefix;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_FullName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Namespace_Declarations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Declaration_Namespace;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder EnumLiteral_Enum;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp29;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Enum_BaseType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Enum_EnumLiterals;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Component;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Name;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_OptionalName;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Port_Binding;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp30;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_BaseComponent;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_IsAbstract;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Ports;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Services;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_References;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Properties;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Implementation;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Component_Language;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp31;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp32;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp33;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp34;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder HttpTransportBindingElement_Ssl;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder HttpTransportBindingElement_ClientAuthentication;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Deployment_Environments;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Deployment_Wires;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp35;
		private global::MetaDslx.Languages.Meta.Symbols.MetaEnumLiteralBuilder __tmp36;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Runtime;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Databases;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Environment_Assemblies;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder ArrayType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Style;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Version;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder SoapEncodingBindingElement_Mtom;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp37;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Struct_BaseType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Struct_Properties;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder PrimitiveType_Nullable;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder OutputParameter_IsOneway;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Database_Entities;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Interface;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Binding;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Endpoint_Address;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Composite_Components;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Composite_Wires;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NonNullableType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Wire_Source;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Wire_Target;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NullableType_InnerType;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder NamedElement_Name;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp38;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp39;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Interface_Operations;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder TypedElement_Type;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Action;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Parameters;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Result;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Operation_Exceptions;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Transport;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Encodings;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder Binding_Protocols;
		internal global::MetaDslx.Languages.Meta.Symbols.MetaPropertyBuilder AnnotationProperty_Value;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp40;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp41;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp42;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp43;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp44;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp45;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp46;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp47;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp48;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp49;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp50;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp51;
		private global::MetaDslx.Languages.Meta.Symbols.MetaParameterBuilder __tmp52;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp53;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp54;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp55;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp56;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp57;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp58;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp59;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp60;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp61;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp62;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp63;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp64;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp65;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp66;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp67;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp68;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp69;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp70;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp71;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp72;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp73;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp74;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp75;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp76;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp77;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp78;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp79;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp80;
		private global::MetaDslx.Languages.Meta.Symbols.MetaAnnotationBuilder __tmp81;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp82;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp83;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp84;
		private global::MetaDslx.Languages.Meta.Symbols.MetaCollectionTypeBuilder __tmp85;
	
		internal SoalBuilderInstance()
		{
			this.ModelGroup = new global::MetaDslx.Core.MutableModelGroup();
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
			global::MetaDslx.Languages.Meta.Symbols.MetaFactory factory = new global::MetaDslx.Languages.Meta.Symbols.MetaFactory(this.Model, global::MetaDslx.Core.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaNamespace();
			__tmp4 = factory.MetaNamespace();
			__tmp5 = factory.MetaNamespace();
			__tmp6 = factory.MetaModel();
			MetaModel = __tmp6;
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
			__tmp19 = factory.MetaConstant();
			AnnotatedElement = factory.MetaClass();
			Annotation = factory.MetaClass();
			AnnotationProperty = factory.MetaClass();
			NamedElement = factory.MetaClass();
			TypedElement = factory.MetaClass();
			SoalType = factory.MetaClass();
			Namespace = factory.MetaClass();
			Declaration = factory.MetaClass();
			ArrayType = factory.MetaClass();
			NullableType = factory.MetaClass();
			NonNullableType = factory.MetaClass();
			PrimitiveType = factory.MetaClass();
			Enum = factory.MetaClass();
			EnumLiteral = factory.MetaClass();
			Property = factory.MetaClass();
			Struct = factory.MetaClass();
			Interface = factory.MetaClass();
			Database = factory.MetaClass();
			Operation = factory.MetaClass();
			InputParameter = factory.MetaClass();
			OutputParameter = factory.MetaClass();
			Component = factory.MetaClass();
			Composite = factory.MetaClass();
			Assembly = factory.MetaClass();
			Wire = factory.MetaClass();
			Port = factory.MetaClass();
			Service = factory.MetaClass();
			Reference = factory.MetaClass();
			Implementation = factory.MetaClass();
			Language = factory.MetaClass();
			Deployment = factory.MetaClass();
			Environment = factory.MetaClass();
			Runtime = factory.MetaClass();
			Binding = factory.MetaClass();
			Endpoint = factory.MetaClass();
			BindingElement = factory.MetaClass();
			TransportBindingElement = factory.MetaClass();
			EncodingBindingElement = factory.MetaClass();
			ProtocolBindingElement = factory.MetaClass();
			HttpTransportBindingElement = factory.MetaClass();
			RestTransportBindingElement = factory.MetaClass();
			WebSocketTransportBindingElement = factory.MetaClass();
			SoapVersion = factory.MetaEnum();
			SoapEncodingStyle = factory.MetaEnum();
			SoapEncodingBindingElement = factory.MetaClass();
			XmlEncodingBindingElement = factory.MetaClass();
			JsonEncodingBindingElement = factory.MetaClass();
			WsProtocolBindingElement = factory.MetaClass();
			WsAddressingBindingElement = factory.MetaClass();
			Annotation_AnnotatedElement = factory.MetaProperty();
			Annotation_Properties = factory.MetaProperty();
			__tmp20 = factory.MetaOperation();
			__tmp21 = factory.MetaOperation();
			__tmp22 = factory.MetaOperation();
			AnnotatedElement_Annotations = factory.MetaProperty();
			__tmp23 = factory.MetaOperation();
			__tmp24 = factory.MetaOperation();
			__tmp25 = factory.MetaOperation();
			__tmp26 = factory.MetaOperation();
			__tmp27 = factory.MetaOperation();
			__tmp28 = factory.MetaAnnotation();
			Namespace_Uri = factory.MetaProperty();
			Namespace_Prefix = factory.MetaProperty();
			Namespace_FullName = factory.MetaProperty();
			Namespace_Declarations = factory.MetaProperty();
			Declaration_Namespace = factory.MetaProperty();
			EnumLiteral_Enum = factory.MetaProperty();
			__tmp29 = factory.MetaAnnotation();
			Enum_BaseType = factory.MetaProperty();
			Enum_EnumLiterals = factory.MetaProperty();
			Port_Component = factory.MetaProperty();
			Port_Name = factory.MetaProperty();
			Port_OptionalName = factory.MetaProperty();
			Port_Interface = factory.MetaProperty();
			Port_Binding = factory.MetaProperty();
			__tmp30 = factory.MetaAnnotation();
			Component_BaseComponent = factory.MetaProperty();
			Component_IsAbstract = factory.MetaProperty();
			Component_Ports = factory.MetaProperty();
			Component_Services = factory.MetaProperty();
			Component_References = factory.MetaProperty();
			Component_Properties = factory.MetaProperty();
			Component_Implementation = factory.MetaProperty();
			Component_Language = factory.MetaProperty();
			__tmp31 = factory.MetaEnumLiteral();
			__tmp32 = factory.MetaEnumLiteral();
			__tmp33 = factory.MetaEnumLiteral();
			__tmp34 = factory.MetaEnumLiteral();
			HttpTransportBindingElement_Ssl = factory.MetaProperty();
			HttpTransportBindingElement_ClientAuthentication = factory.MetaProperty();
			Deployment_Environments = factory.MetaProperty();
			Deployment_Wires = factory.MetaProperty();
			__tmp35 = factory.MetaEnumLiteral();
			__tmp36 = factory.MetaEnumLiteral();
			Environment_Runtime = factory.MetaProperty();
			Environment_Databases = factory.MetaProperty();
			Environment_Assemblies = factory.MetaProperty();
			ArrayType_InnerType = factory.MetaProperty();
			SoapEncodingBindingElement_Style = factory.MetaProperty();
			SoapEncodingBindingElement_Version = factory.MetaProperty();
			SoapEncodingBindingElement_Mtom = factory.MetaProperty();
			__tmp37 = factory.MetaAnnotation();
			Struct_BaseType = factory.MetaProperty();
			Struct_Properties = factory.MetaProperty();
			PrimitiveType_Nullable = factory.MetaProperty();
			OutputParameter_IsOneway = factory.MetaProperty();
			Database_Entities = factory.MetaProperty();
			Endpoint_Interface = factory.MetaProperty();
			Endpoint_Binding = factory.MetaProperty();
			Endpoint_Address = factory.MetaProperty();
			Composite_Components = factory.MetaProperty();
			Composite_Wires = factory.MetaProperty();
			NonNullableType_InnerType = factory.MetaProperty();
			Wire_Source = factory.MetaProperty();
			Wire_Target = factory.MetaProperty();
			NullableType_InnerType = factory.MetaProperty();
			NamedElement_Name = factory.MetaProperty();
			__tmp38 = factory.MetaAnnotation();
			__tmp39 = factory.MetaAnnotation();
			Interface_Operations = factory.MetaProperty();
			TypedElement_Type = factory.MetaProperty();
			Operation_Action = factory.MetaProperty();
			Operation_Parameters = factory.MetaProperty();
			Operation_Result = factory.MetaProperty();
			Operation_Exceptions = factory.MetaProperty();
			Binding_Transport = factory.MetaProperty();
			Binding_Encodings = factory.MetaProperty();
			Binding_Protocols = factory.MetaProperty();
			AnnotationProperty_Value = factory.MetaProperty();
			__tmp40 = factory.MetaCollectionType();
			__tmp41 = factory.MetaParameter();
			__tmp42 = factory.MetaParameter();
			__tmp43 = factory.MetaParameter();
			__tmp44 = factory.MetaCollectionType();
			__tmp45 = factory.MetaParameter();
			__tmp46 = factory.MetaParameter();
			__tmp47 = factory.MetaCollectionType();
			__tmp48 = factory.MetaParameter();
			__tmp49 = factory.MetaParameter();
			__tmp50 = factory.MetaParameter();
			__tmp51 = factory.MetaParameter();
			__tmp52 = factory.MetaParameter();
			__tmp53 = factory.MetaAnnotation();
			__tmp54 = factory.MetaCollectionType();
			__tmp55 = factory.MetaAnnotation();
			__tmp56 = factory.MetaAnnotation();
			__tmp57 = factory.MetaCollectionType();
			__tmp58 = factory.MetaAnnotation();
			__tmp59 = factory.MetaAnnotation();
			__tmp60 = factory.MetaAnnotation();
			__tmp61 = factory.MetaCollectionType();
			__tmp62 = factory.MetaCollectionType();
			__tmp63 = factory.MetaCollectionType();
			__tmp64 = factory.MetaAnnotation();
			__tmp65 = factory.MetaCollectionType();
			__tmp66 = factory.MetaCollectionType();
			__tmp67 = factory.MetaCollectionType();
			__tmp68 = factory.MetaCollectionType();
			__tmp69 = factory.MetaCollectionType();
			__tmp70 = factory.MetaAnnotation();
			__tmp71 = factory.MetaAnnotation();
			__tmp72 = factory.MetaCollectionType();
			__tmp73 = factory.MetaAnnotation();
			__tmp74 = factory.MetaCollectionType();
			__tmp75 = factory.MetaAnnotation();
			__tmp76 = factory.MetaCollectionType();
			__tmp77 = factory.MetaCollectionType();
			__tmp78 = factory.MetaAnnotation();
			__tmp79 = factory.MetaAnnotation();
			__tmp80 = factory.MetaCollectionType();
			__tmp81 = factory.MetaAnnotation();
			__tmp82 = factory.MetaCollectionType();
			__tmp83 = factory.MetaCollectionType();
			__tmp84 = factory.MetaCollectionType();
			__tmp85 = factory.MetaCollectionType();
	
			__tmp1.Name = "";
			__tmp1.Documentation = null;
			// __tmp1.Parent = null;
			// __tmp1.MetaModel = null;
			__tmp1.Namespaces.AddLazy(() => __tmp2);
			__tmp2.Name = "MetaDslx";
			__tmp2.Documentation = null;
			__tmp2.ParentLazy = () => __tmp1;
			// __tmp2.MetaModel = null;
			__tmp2.Namespaces.AddLazy(() => __tmp3);
			__tmp3.Name = "Languages";
			__tmp3.Documentation = null;
			__tmp3.ParentLazy = () => __tmp2;
			// __tmp3.MetaModel = null;
			__tmp3.Namespaces.AddLazy(() => __tmp4);
			__tmp4.Name = "Soal";
			__tmp4.Documentation = null;
			__tmp4.ParentLazy = () => __tmp3;
			// __tmp4.MetaModel = null;
			__tmp4.Namespaces.AddLazy(() => __tmp5);
			__tmp5.Name = "Symbols";
			__tmp5.Documentation = null;
			__tmp5.ParentLazy = () => __tmp4;
			__tmp5.MetaModelLazy = () => __tmp6;
			__tmp5.Declarations.AddLazy(() => __tmp7);
			__tmp5.Declarations.AddLazy(() => __tmp8);
			__tmp5.Declarations.AddLazy(() => __tmp9);
			__tmp5.Declarations.AddLazy(() => __tmp10);
			__tmp5.Declarations.AddLazy(() => __tmp11);
			__tmp5.Declarations.AddLazy(() => __tmp12);
			__tmp5.Declarations.AddLazy(() => __tmp13);
			__tmp5.Declarations.AddLazy(() => __tmp14);
			__tmp5.Declarations.AddLazy(() => __tmp15);
			__tmp5.Declarations.AddLazy(() => __tmp16);
			__tmp5.Declarations.AddLazy(() => __tmp17);
			__tmp5.Declarations.AddLazy(() => __tmp18);
			__tmp5.Declarations.AddLazy(() => __tmp19);
			__tmp5.Declarations.AddLazy(() => AnnotatedElement);
			__tmp5.Declarations.AddLazy(() => Annotation);
			__tmp5.Declarations.AddLazy(() => AnnotationProperty);
			__tmp5.Declarations.AddLazy(() => NamedElement);
			__tmp5.Declarations.AddLazy(() => TypedElement);
			__tmp5.Declarations.AddLazy(() => SoalType);
			__tmp5.Declarations.AddLazy(() => Namespace);
			__tmp5.Declarations.AddLazy(() => Declaration);
			__tmp5.Declarations.AddLazy(() => ArrayType);
			__tmp5.Declarations.AddLazy(() => NullableType);
			__tmp5.Declarations.AddLazy(() => NonNullableType);
			__tmp5.Declarations.AddLazy(() => PrimitiveType);
			__tmp5.Declarations.AddLazy(() => Enum);
			__tmp5.Declarations.AddLazy(() => EnumLiteral);
			__tmp5.Declarations.AddLazy(() => Property);
			__tmp5.Declarations.AddLazy(() => Struct);
			__tmp5.Declarations.AddLazy(() => Interface);
			__tmp5.Declarations.AddLazy(() => Database);
			__tmp5.Declarations.AddLazy(() => Operation);
			__tmp5.Declarations.AddLazy(() => InputParameter);
			__tmp5.Declarations.AddLazy(() => OutputParameter);
			__tmp5.Declarations.AddLazy(() => Component);
			__tmp5.Declarations.AddLazy(() => Composite);
			__tmp5.Declarations.AddLazy(() => Assembly);
			__tmp5.Declarations.AddLazy(() => Wire);
			__tmp5.Declarations.AddLazy(() => Port);
			__tmp5.Declarations.AddLazy(() => Service);
			__tmp5.Declarations.AddLazy(() => Reference);
			__tmp5.Declarations.AddLazy(() => Implementation);
			__tmp5.Declarations.AddLazy(() => Language);
			__tmp5.Declarations.AddLazy(() => Deployment);
			__tmp5.Declarations.AddLazy(() => Environment);
			__tmp5.Declarations.AddLazy(() => Runtime);
			__tmp5.Declarations.AddLazy(() => Binding);
			__tmp5.Declarations.AddLazy(() => Endpoint);
			__tmp5.Declarations.AddLazy(() => BindingElement);
			__tmp5.Declarations.AddLazy(() => TransportBindingElement);
			__tmp5.Declarations.AddLazy(() => EncodingBindingElement);
			__tmp5.Declarations.AddLazy(() => ProtocolBindingElement);
			__tmp5.Declarations.AddLazy(() => HttpTransportBindingElement);
			__tmp5.Declarations.AddLazy(() => RestTransportBindingElement);
			__tmp5.Declarations.AddLazy(() => WebSocketTransportBindingElement);
			__tmp5.Declarations.AddLazy(() => SoapVersion);
			__tmp5.Declarations.AddLazy(() => SoapEncodingStyle);
			__tmp5.Declarations.AddLazy(() => SoapEncodingBindingElement);
			__tmp5.Declarations.AddLazy(() => XmlEncodingBindingElement);
			__tmp5.Declarations.AddLazy(() => JsonEncodingBindingElement);
			__tmp5.Declarations.AddLazy(() => WsProtocolBindingElement);
			__tmp5.Declarations.AddLazy(() => WsAddressingBindingElement);
			__tmp6.Name = "Soal";
			__tmp6.Documentation = null;
			__tmp6.Uri = "http://MetaDslx.Languages.Soal/1.0";
			__tmp6.NamespaceLazy = () => __tmp5;
			__tmp7.MetaModelLazy = () => __tmp6;
			__tmp7.NamespaceLazy = () => __tmp5;
			__tmp7.Documentation = null;
			__tmp7.Name = "Object";
			__tmp7.TypeLazy = () => PrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp6;
			__tmp8.NamespaceLazy = () => __tmp5;
			__tmp8.Documentation = null;
			__tmp8.Name = "String";
			__tmp8.TypeLazy = () => PrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp6;
			__tmp9.NamespaceLazy = () => __tmp5;
			__tmp9.Documentation = null;
			__tmp9.Name = "Int";
			__tmp9.TypeLazy = () => PrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp6;
			__tmp10.NamespaceLazy = () => __tmp5;
			__tmp10.Documentation = null;
			__tmp10.Name = "Long";
			__tmp10.TypeLazy = () => PrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp6;
			__tmp11.NamespaceLazy = () => __tmp5;
			__tmp11.Documentation = null;
			__tmp11.Name = "Float";
			__tmp11.TypeLazy = () => PrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp6;
			__tmp12.NamespaceLazy = () => __tmp5;
			__tmp12.Documentation = null;
			__tmp12.Name = "Double";
			__tmp12.TypeLazy = () => PrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp6;
			__tmp13.NamespaceLazy = () => __tmp5;
			__tmp13.Documentation = null;
			__tmp13.Name = "Byte";
			__tmp13.TypeLazy = () => PrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp6;
			__tmp14.NamespaceLazy = () => __tmp5;
			__tmp14.Documentation = null;
			__tmp14.Name = "Bool";
			__tmp14.TypeLazy = () => PrimitiveType;
			__tmp15.MetaModelLazy = () => __tmp6;
			__tmp15.NamespaceLazy = () => __tmp5;
			__tmp15.Documentation = null;
			__tmp15.Name = "Void";
			__tmp15.TypeLazy = () => PrimitiveType;
			__tmp16.MetaModelLazy = () => __tmp6;
			__tmp16.NamespaceLazy = () => __tmp5;
			__tmp16.Documentation = null;
			__tmp16.Name = "Date";
			__tmp16.TypeLazy = () => PrimitiveType;
			__tmp17.MetaModelLazy = () => __tmp6;
			__tmp17.NamespaceLazy = () => __tmp5;
			__tmp17.Documentation = null;
			__tmp17.Name = "Time";
			__tmp17.TypeLazy = () => PrimitiveType;
			__tmp18.MetaModelLazy = () => __tmp6;
			__tmp18.NamespaceLazy = () => __tmp5;
			__tmp18.Documentation = null;
			__tmp18.Name = "DateTime";
			__tmp18.TypeLazy = () => PrimitiveType;
			__tmp19.MetaModelLazy = () => __tmp6;
			__tmp19.NamespaceLazy = () => __tmp5;
			__tmp19.Documentation = null;
			__tmp19.Name = "TimeSpan";
			__tmp19.TypeLazy = () => PrimitiveType;
			AnnotatedElement.MetaModelLazy = () => __tmp6;
			AnnotatedElement.NamespaceLazy = () => __tmp5;
			AnnotatedElement.Documentation = null;
			AnnotatedElement.Name = "AnnotatedElement";
			AnnotatedElement.IsAbstract = true;
			AnnotatedElement.Properties.AddLazy(() => AnnotatedElement_Annotations);
			AnnotatedElement.Operations.AddLazy(() => __tmp23);
			AnnotatedElement.Operations.AddLazy(() => __tmp24);
			AnnotatedElement.Operations.AddLazy(() => __tmp25);
			AnnotatedElement.Operations.AddLazy(() => __tmp26);
			AnnotatedElement.Operations.AddLazy(() => __tmp27);
			// AnnotatedElement.Constructor = null;
			Annotation.MetaModelLazy = () => __tmp6;
			Annotation.NamespaceLazy = () => __tmp5;
			Annotation.Documentation = null;
			Annotation.Name = "Annotation";
			// Annotation.IsAbstract = null;
			Annotation.SuperClasses.AddLazy(() => NamedElement);
			Annotation.Properties.AddLazy(() => Annotation_AnnotatedElement);
			Annotation.Properties.AddLazy(() => Annotation_Properties);
			Annotation.Operations.AddLazy(() => __tmp20);
			Annotation.Operations.AddLazy(() => __tmp21);
			Annotation.Operations.AddLazy(() => __tmp22);
			// Annotation.Constructor = null;
			AnnotationProperty.MetaModelLazy = () => __tmp6;
			AnnotationProperty.NamespaceLazy = () => __tmp5;
			AnnotationProperty.Documentation = null;
			AnnotationProperty.Name = "AnnotationProperty";
			// AnnotationProperty.IsAbstract = null;
			AnnotationProperty.SuperClasses.AddLazy(() => NamedElement);
			AnnotationProperty.Properties.AddLazy(() => AnnotationProperty_Value);
			// AnnotationProperty.Constructor = null;
			NamedElement.MetaModelLazy = () => __tmp6;
			NamedElement.NamespaceLazy = () => __tmp5;
			NamedElement.Documentation = null;
			NamedElement.Name = "NamedElement";
			NamedElement.IsAbstract = true;
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			// NamedElement.Constructor = null;
			TypedElement.MetaModelLazy = () => __tmp6;
			TypedElement.NamespaceLazy = () => __tmp5;
			TypedElement.Documentation = null;
			TypedElement.Name = "TypedElement";
			TypedElement.IsAbstract = true;
			TypedElement.Properties.AddLazy(() => TypedElement_Type);
			// TypedElement.Constructor = null;
			SoalType.MetaModelLazy = () => __tmp6;
			SoalType.NamespaceLazy = () => __tmp5;
			SoalType.Documentation = null;
			SoalType.Name = "SoalType";
			SoalType.Annotations.AddLazy(() => __tmp38);
			SoalType.IsAbstract = true;
			// SoalType.Constructor = null;
			Namespace.MetaModelLazy = () => __tmp6;
			Namespace.NamespaceLazy = () => __tmp5;
			Namespace.Documentation = null;
			Namespace.Name = "Namespace";
			Namespace.Annotations.AddLazy(() => __tmp28);
			// Namespace.IsAbstract = null;
			Namespace.SuperClasses.AddLazy(() => Declaration);
			Namespace.Properties.AddLazy(() => Namespace_Uri);
			Namespace.Properties.AddLazy(() => Namespace_Prefix);
			Namespace.Properties.AddLazy(() => Namespace_FullName);
			Namespace.Properties.AddLazy(() => Namespace_Declarations);
			// Namespace.Constructor = null;
			Declaration.MetaModelLazy = () => __tmp6;
			Declaration.NamespaceLazy = () => __tmp5;
			Declaration.Documentation = null;
			Declaration.Name = "Declaration";
			Declaration.IsAbstract = true;
			Declaration.SuperClasses.AddLazy(() => NamedElement);
			Declaration.SuperClasses.AddLazy(() => AnnotatedElement);
			Declaration.Properties.AddLazy(() => Declaration_Namespace);
			// Declaration.Constructor = null;
			ArrayType.MetaModelLazy = () => __tmp6;
			ArrayType.NamespaceLazy = () => __tmp5;
			ArrayType.Documentation = null;
			ArrayType.Name = "ArrayType";
			// ArrayType.IsAbstract = null;
			ArrayType.SuperClasses.AddLazy(() => SoalType);
			ArrayType.Properties.AddLazy(() => ArrayType_InnerType);
			// ArrayType.Constructor = null;
			NullableType.MetaModelLazy = () => __tmp6;
			NullableType.NamespaceLazy = () => __tmp5;
			NullableType.Documentation = null;
			NullableType.Name = "NullableType";
			// NullableType.IsAbstract = null;
			NullableType.SuperClasses.AddLazy(() => SoalType);
			NullableType.Properties.AddLazy(() => NullableType_InnerType);
			// NullableType.Constructor = null;
			NonNullableType.MetaModelLazy = () => __tmp6;
			NonNullableType.NamespaceLazy = () => __tmp5;
			NonNullableType.Documentation = null;
			NonNullableType.Name = "NonNullableType";
			// NonNullableType.IsAbstract = null;
			NonNullableType.SuperClasses.AddLazy(() => SoalType);
			NonNullableType.Properties.AddLazy(() => NonNullableType_InnerType);
			// NonNullableType.Constructor = null;
			PrimitiveType.MetaModelLazy = () => __tmp6;
			PrimitiveType.NamespaceLazy = () => __tmp5;
			PrimitiveType.Documentation = null;
			PrimitiveType.Name = "PrimitiveType";
			// PrimitiveType.IsAbstract = null;
			PrimitiveType.SuperClasses.AddLazy(() => SoalType);
			PrimitiveType.SuperClasses.AddLazy(() => Declaration);
			PrimitiveType.Properties.AddLazy(() => PrimitiveType_Nullable);
			// PrimitiveType.Constructor = null;
			Enum.MetaModelLazy = () => __tmp6;
			Enum.NamespaceLazy = () => __tmp5;
			Enum.Documentation = null;
			Enum.Name = "Enum";
			Enum.Annotations.AddLazy(() => __tmp29);
			// Enum.IsAbstract = null;
			Enum.SuperClasses.AddLazy(() => SoalType);
			Enum.SuperClasses.AddLazy(() => Declaration);
			Enum.Properties.AddLazy(() => Enum_BaseType);
			Enum.Properties.AddLazy(() => Enum_EnumLiterals);
			// Enum.Constructor = null;
			EnumLiteral.MetaModelLazy = () => __tmp6;
			EnumLiteral.NamespaceLazy = () => __tmp5;
			EnumLiteral.Documentation = null;
			EnumLiteral.Name = "EnumLiteral";
			// EnumLiteral.IsAbstract = null;
			EnumLiteral.SuperClasses.AddLazy(() => NamedElement);
			EnumLiteral.SuperClasses.AddLazy(() => TypedElement);
			EnumLiteral.SuperClasses.AddLazy(() => AnnotatedElement);
			EnumLiteral.Properties.AddLazy(() => EnumLiteral_Enum);
			// EnumLiteral.Constructor = null;
			Property.MetaModelLazy = () => __tmp6;
			Property.NamespaceLazy = () => __tmp5;
			Property.Documentation = null;
			Property.Name = "Property";
			// Property.IsAbstract = null;
			Property.SuperClasses.AddLazy(() => NamedElement);
			Property.SuperClasses.AddLazy(() => TypedElement);
			Property.SuperClasses.AddLazy(() => AnnotatedElement);
			// Property.Constructor = null;
			Struct.MetaModelLazy = () => __tmp6;
			Struct.NamespaceLazy = () => __tmp5;
			Struct.Documentation = null;
			Struct.Name = "Struct";
			Struct.Annotations.AddLazy(() => __tmp37);
			// Struct.IsAbstract = null;
			Struct.SuperClasses.AddLazy(() => SoalType);
			Struct.SuperClasses.AddLazy(() => Declaration);
			Struct.Properties.AddLazy(() => Struct_BaseType);
			Struct.Properties.AddLazy(() => Struct_Properties);
			// Struct.Constructor = null;
			Interface.MetaModelLazy = () => __tmp6;
			Interface.NamespaceLazy = () => __tmp5;
			Interface.Documentation = null;
			Interface.Name = "Interface";
			Interface.Annotations.AddLazy(() => __tmp39);
			// Interface.IsAbstract = null;
			Interface.SuperClasses.AddLazy(() => SoalType);
			Interface.SuperClasses.AddLazy(() => Declaration);
			Interface.Properties.AddLazy(() => Interface_Operations);
			// Interface.Constructor = null;
			Database.MetaModelLazy = () => __tmp6;
			Database.NamespaceLazy = () => __tmp5;
			Database.Documentation = null;
			Database.Name = "Database";
			// Database.IsAbstract = null;
			Database.SuperClasses.AddLazy(() => Interface);
			Database.Properties.AddLazy(() => Database_Entities);
			// Database.Constructor = null;
			Operation.MetaModelLazy = () => __tmp6;
			Operation.NamespaceLazy = () => __tmp5;
			Operation.Documentation = null;
			Operation.Name = "Operation";
			// Operation.IsAbstract = null;
			Operation.SuperClasses.AddLazy(() => NamedElement);
			Operation.SuperClasses.AddLazy(() => AnnotatedElement);
			Operation.Properties.AddLazy(() => Operation_Action);
			Operation.Properties.AddLazy(() => Operation_Parameters);
			Operation.Properties.AddLazy(() => Operation_Result);
			Operation.Properties.AddLazy(() => Operation_Exceptions);
			// Operation.Constructor = null;
			InputParameter.MetaModelLazy = () => __tmp6;
			InputParameter.NamespaceLazy = () => __tmp5;
			InputParameter.Documentation = null;
			InputParameter.Name = "InputParameter";
			// InputParameter.IsAbstract = null;
			InputParameter.SuperClasses.AddLazy(() => NamedElement);
			InputParameter.SuperClasses.AddLazy(() => TypedElement);
			InputParameter.SuperClasses.AddLazy(() => AnnotatedElement);
			// InputParameter.Constructor = null;
			OutputParameter.MetaModelLazy = () => __tmp6;
			OutputParameter.NamespaceLazy = () => __tmp5;
			OutputParameter.Documentation = null;
			OutputParameter.Name = "OutputParameter";
			// OutputParameter.IsAbstract = null;
			OutputParameter.SuperClasses.AddLazy(() => TypedElement);
			OutputParameter.SuperClasses.AddLazy(() => AnnotatedElement);
			OutputParameter.Properties.AddLazy(() => OutputParameter_IsOneway);
			// OutputParameter.Constructor = null;
			Component.MetaModelLazy = () => __tmp6;
			Component.NamespaceLazy = () => __tmp5;
			Component.Documentation = null;
			Component.Name = "Component";
			Component.Annotations.AddLazy(() => __tmp30);
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
			// Component.Constructor = null;
			Composite.MetaModelLazy = () => __tmp6;
			Composite.NamespaceLazy = () => __tmp5;
			Composite.Documentation = null;
			Composite.Name = "Composite";
			// Composite.IsAbstract = null;
			Composite.SuperClasses.AddLazy(() => Component);
			Composite.Properties.AddLazy(() => Composite_Components);
			Composite.Properties.AddLazy(() => Composite_Wires);
			// Composite.Constructor = null;
			Assembly.MetaModelLazy = () => __tmp6;
			Assembly.NamespaceLazy = () => __tmp5;
			Assembly.Documentation = null;
			Assembly.Name = "Assembly";
			// Assembly.IsAbstract = null;
			Assembly.SuperClasses.AddLazy(() => Composite);
			// Assembly.Constructor = null;
			Wire.MetaModelLazy = () => __tmp6;
			Wire.NamespaceLazy = () => __tmp5;
			Wire.Documentation = null;
			Wire.Name = "Wire";
			// Wire.IsAbstract = null;
			Wire.Properties.AddLazy(() => Wire_Source);
			Wire.Properties.AddLazy(() => Wire_Target);
			// Wire.Constructor = null;
			Port.MetaModelLazy = () => __tmp6;
			Port.NamespaceLazy = () => __tmp5;
			Port.Documentation = null;
			Port.Name = "Port";
			// Port.IsAbstract = null;
			Port.Properties.AddLazy(() => Port_Component);
			Port.Properties.AddLazy(() => Port_Name);
			Port.Properties.AddLazy(() => Port_OptionalName);
			Port.Properties.AddLazy(() => Port_Interface);
			Port.Properties.AddLazy(() => Port_Binding);
			// Port.Constructor = null;
			Service.MetaModelLazy = () => __tmp6;
			Service.NamespaceLazy = () => __tmp5;
			Service.Documentation = null;
			Service.Name = "Service";
			// Service.IsAbstract = null;
			Service.SuperClasses.AddLazy(() => Port);
			// Service.Constructor = null;
			Reference.MetaModelLazy = () => __tmp6;
			Reference.NamespaceLazy = () => __tmp5;
			Reference.Documentation = null;
			Reference.Name = "Reference";
			// Reference.IsAbstract = null;
			Reference.SuperClasses.AddLazy(() => Port);
			// Reference.Constructor = null;
			Implementation.MetaModelLazy = () => __tmp6;
			Implementation.NamespaceLazy = () => __tmp5;
			Implementation.Documentation = null;
			Implementation.Name = "Implementation";
			// Implementation.IsAbstract = null;
			Implementation.SuperClasses.AddLazy(() => NamedElement);
			// Implementation.Constructor = null;
			Language.MetaModelLazy = () => __tmp6;
			Language.NamespaceLazy = () => __tmp5;
			Language.Documentation = null;
			Language.Name = "Language";
			// Language.IsAbstract = null;
			Language.SuperClasses.AddLazy(() => NamedElement);
			// Language.Constructor = null;
			Deployment.MetaModelLazy = () => __tmp6;
			Deployment.NamespaceLazy = () => __tmp5;
			Deployment.Documentation = null;
			Deployment.Name = "Deployment";
			// Deployment.IsAbstract = null;
			Deployment.SuperClasses.AddLazy(() => Declaration);
			Deployment.Properties.AddLazy(() => Deployment_Environments);
			Deployment.Properties.AddLazy(() => Deployment_Wires);
			// Deployment.Constructor = null;
			Environment.MetaModelLazy = () => __tmp6;
			Environment.NamespaceLazy = () => __tmp5;
			Environment.Documentation = null;
			Environment.Name = "Environment";
			// Environment.IsAbstract = null;
			Environment.SuperClasses.AddLazy(() => NamedElement);
			Environment.Properties.AddLazy(() => Environment_Runtime);
			Environment.Properties.AddLazy(() => Environment_Databases);
			Environment.Properties.AddLazy(() => Environment_Assemblies);
			// Environment.Constructor = null;
			Runtime.MetaModelLazy = () => __tmp6;
			Runtime.NamespaceLazy = () => __tmp5;
			Runtime.Documentation = null;
			Runtime.Name = "Runtime";
			// Runtime.IsAbstract = null;
			Runtime.SuperClasses.AddLazy(() => NamedElement);
			// Runtime.Constructor = null;
			Binding.MetaModelLazy = () => __tmp6;
			Binding.NamespaceLazy = () => __tmp5;
			Binding.Documentation = null;
			Binding.Name = "Binding";
			// Binding.IsAbstract = null;
			Binding.SuperClasses.AddLazy(() => Declaration);
			Binding.Properties.AddLazy(() => Binding_Transport);
			Binding.Properties.AddLazy(() => Binding_Encodings);
			Binding.Properties.AddLazy(() => Binding_Protocols);
			// Binding.Constructor = null;
			Endpoint.MetaModelLazy = () => __tmp6;
			Endpoint.NamespaceLazy = () => __tmp5;
			Endpoint.Documentation = null;
			Endpoint.Name = "Endpoint";
			// Endpoint.IsAbstract = null;
			Endpoint.SuperClasses.AddLazy(() => Declaration);
			Endpoint.Properties.AddLazy(() => Endpoint_Interface);
			Endpoint.Properties.AddLazy(() => Endpoint_Binding);
			Endpoint.Properties.AddLazy(() => Endpoint_Address);
			// Endpoint.Constructor = null;
			BindingElement.MetaModelLazy = () => __tmp6;
			BindingElement.NamespaceLazy = () => __tmp5;
			BindingElement.Documentation = null;
			BindingElement.Name = "BindingElement";
			BindingElement.IsAbstract = true;
			BindingElement.SuperClasses.AddLazy(() => NamedElement);
			// BindingElement.Constructor = null;
			TransportBindingElement.MetaModelLazy = () => __tmp6;
			TransportBindingElement.NamespaceLazy = () => __tmp5;
			TransportBindingElement.Documentation = null;
			TransportBindingElement.Name = "TransportBindingElement";
			TransportBindingElement.IsAbstract = true;
			TransportBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// TransportBindingElement.Constructor = null;
			EncodingBindingElement.MetaModelLazy = () => __tmp6;
			EncodingBindingElement.NamespaceLazy = () => __tmp5;
			EncodingBindingElement.Documentation = null;
			EncodingBindingElement.Name = "EncodingBindingElement";
			EncodingBindingElement.IsAbstract = true;
			EncodingBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// EncodingBindingElement.Constructor = null;
			ProtocolBindingElement.MetaModelLazy = () => __tmp6;
			ProtocolBindingElement.NamespaceLazy = () => __tmp5;
			ProtocolBindingElement.Documentation = null;
			ProtocolBindingElement.Name = "ProtocolBindingElement";
			ProtocolBindingElement.IsAbstract = true;
			ProtocolBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// ProtocolBindingElement.Constructor = null;
			HttpTransportBindingElement.MetaModelLazy = () => __tmp6;
			HttpTransportBindingElement.NamespaceLazy = () => __tmp5;
			HttpTransportBindingElement.Documentation = null;
			HttpTransportBindingElement.Name = "HttpTransportBindingElement";
			// HttpTransportBindingElement.IsAbstract = null;
			HttpTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			HttpTransportBindingElement.Properties.AddLazy(() => HttpTransportBindingElement_Ssl);
			HttpTransportBindingElement.Properties.AddLazy(() => HttpTransportBindingElement_ClientAuthentication);
			// HttpTransportBindingElement.Constructor = null;
			RestTransportBindingElement.MetaModelLazy = () => __tmp6;
			RestTransportBindingElement.NamespaceLazy = () => __tmp5;
			RestTransportBindingElement.Documentation = null;
			RestTransportBindingElement.Name = "RestTransportBindingElement";
			// RestTransportBindingElement.IsAbstract = null;
			RestTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			// RestTransportBindingElement.Constructor = null;
			WebSocketTransportBindingElement.MetaModelLazy = () => __tmp6;
			WebSocketTransportBindingElement.NamespaceLazy = () => __tmp5;
			WebSocketTransportBindingElement.Documentation = null;
			WebSocketTransportBindingElement.Name = "WebSocketTransportBindingElement";
			// WebSocketTransportBindingElement.IsAbstract = null;
			WebSocketTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			// WebSocketTransportBindingElement.Constructor = null;
			SoapVersion.MetaModelLazy = () => __tmp6;
			SoapVersion.NamespaceLazy = () => __tmp5;
			SoapVersion.Documentation = null;
			SoapVersion.Name = "SoapVersion";
			SoapVersion.EnumLiterals.AddLazy(() => __tmp35);
			SoapVersion.EnumLiterals.AddLazy(() => __tmp36);
			SoapEncodingStyle.MetaModelLazy = () => __tmp6;
			SoapEncodingStyle.NamespaceLazy = () => __tmp5;
			SoapEncodingStyle.Documentation = null;
			SoapEncodingStyle.Name = "SoapEncodingStyle";
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp31);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp32);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp33);
			SoapEncodingStyle.EnumLiterals.AddLazy(() => __tmp34);
			SoapEncodingBindingElement.MetaModelLazy = () => __tmp6;
			SoapEncodingBindingElement.NamespaceLazy = () => __tmp5;
			SoapEncodingBindingElement.Documentation = null;
			SoapEncodingBindingElement.Name = "SoapEncodingBindingElement";
			// SoapEncodingBindingElement.IsAbstract = null;
			SoapEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Style);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Version);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Mtom);
			// SoapEncodingBindingElement.Constructor = null;
			XmlEncodingBindingElement.MetaModelLazy = () => __tmp6;
			XmlEncodingBindingElement.NamespaceLazy = () => __tmp5;
			XmlEncodingBindingElement.Documentation = null;
			XmlEncodingBindingElement.Name = "XmlEncodingBindingElement";
			// XmlEncodingBindingElement.IsAbstract = null;
			XmlEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			// XmlEncodingBindingElement.Constructor = null;
			JsonEncodingBindingElement.MetaModelLazy = () => __tmp6;
			JsonEncodingBindingElement.NamespaceLazy = () => __tmp5;
			JsonEncodingBindingElement.Documentation = null;
			JsonEncodingBindingElement.Name = "JsonEncodingBindingElement";
			// JsonEncodingBindingElement.IsAbstract = null;
			JsonEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			// JsonEncodingBindingElement.Constructor = null;
			WsProtocolBindingElement.MetaModelLazy = () => __tmp6;
			WsProtocolBindingElement.NamespaceLazy = () => __tmp5;
			WsProtocolBindingElement.Documentation = null;
			WsProtocolBindingElement.Name = "WsProtocolBindingElement";
			WsProtocolBindingElement.IsAbstract = true;
			WsProtocolBindingElement.SuperClasses.AddLazy(() => ProtocolBindingElement);
			// WsProtocolBindingElement.Constructor = null;
			WsAddressingBindingElement.MetaModelLazy = () => __tmp6;
			WsAddressingBindingElement.NamespaceLazy = () => __tmp5;
			WsAddressingBindingElement.Documentation = null;
			WsAddressingBindingElement.Name = "WsAddressingBindingElement";
			// WsAddressingBindingElement.IsAbstract = null;
			WsAddressingBindingElement.SuperClasses.AddLazy(() => WsProtocolBindingElement);
			// WsAddressingBindingElement.Constructor = null;
			Annotation_AnnotatedElement.TypeLazy = () => AnnotatedElement;
			Annotation_AnnotatedElement.Name = "AnnotatedElement";
			Annotation_AnnotatedElement.Documentation = null;
			// Annotation_AnnotatedElement.Kind = null;
			Annotation_AnnotatedElement.ClassLazy = () => Annotation;
			Annotation_AnnotatedElement.OppositeProperties.AddLazy(() => AnnotatedElement_Annotations);
			Annotation_Properties.TypeLazy = () => __tmp40;
			Annotation_Properties.Name = "Properties";
			Annotation_Properties.Documentation = null;
			Annotation_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Annotation_Properties.ClassLazy = () => Annotation;
			__tmp20.ReturnTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			__tmp20.Parameters.AddLazy(() => __tmp41);
			// TODO: __tmp20.Type
			// TODO: __tmp20.Type
			__tmp20.Documentation = null;
			__tmp20.Name = "HasProperty";
			__tmp20.ParentLazy = () => Annotation;
			__tmp21.ReturnTypeLazy = () => AnnotationProperty;
			__tmp21.Parameters.AddLazy(() => __tmp42);
			// TODO: __tmp21.Type
			// TODO: __tmp21.Type
			__tmp21.Documentation = null;
			__tmp21.Name = "GetProperty";
			__tmp21.ParentLazy = () => Annotation;
			__tmp22.ReturnTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Object.ToMutable();
			__tmp22.Parameters.AddLazy(() => __tmp43);
			// TODO: __tmp22.Type
			// TODO: __tmp22.Type
			__tmp22.Documentation = null;
			__tmp22.Name = "GetPropertyValue";
			__tmp22.ParentLazy = () => Annotation;
			AnnotatedElement_Annotations.TypeLazy = () => __tmp44;
			AnnotatedElement_Annotations.Name = "Annotations";
			AnnotatedElement_Annotations.Documentation = null;
			AnnotatedElement_Annotations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			AnnotatedElement_Annotations.ClassLazy = () => AnnotatedElement;
			AnnotatedElement_Annotations.OppositeProperties.AddLazy(() => Annotation_AnnotatedElement);
			__tmp23.ReturnTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			__tmp23.Parameters.AddLazy(() => __tmp45);
			// TODO: __tmp23.Type
			// TODO: __tmp23.Type
			__tmp23.Documentation = null;
			__tmp23.Name = "HasAnnotation";
			__tmp23.ParentLazy = () => AnnotatedElement;
			__tmp24.ReturnTypeLazy = () => Annotation;
			__tmp24.Parameters.AddLazy(() => __tmp46);
			// TODO: __tmp24.Type
			// TODO: __tmp24.Type
			__tmp24.Documentation = null;
			__tmp24.Name = "GetAnnotation";
			__tmp24.ParentLazy = () => AnnotatedElement;
			__tmp25.ReturnTypeLazy = () => __tmp47;
			__tmp25.Parameters.AddLazy(() => __tmp48);
			// TODO: __tmp25.Type
			// TODO: __tmp25.Type
			__tmp25.Documentation = null;
			__tmp25.Name = "GetAnnotations";
			__tmp25.ParentLazy = () => AnnotatedElement;
			__tmp26.ReturnTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			__tmp26.Parameters.AddLazy(() => __tmp49);
			__tmp26.Parameters.AddLazy(() => __tmp50);
			// TODO: __tmp26.Type
			// TODO: __tmp26.Type
			__tmp26.Documentation = null;
			__tmp26.Name = "HasAnnotationProperty";
			__tmp26.ParentLazy = () => AnnotatedElement;
			__tmp27.ReturnTypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Object.ToMutable();
			__tmp27.Parameters.AddLazy(() => __tmp51);
			__tmp27.Parameters.AddLazy(() => __tmp52);
			// TODO: __tmp27.Type
			// TODO: __tmp27.Type
			__tmp27.Documentation = null;
			__tmp27.Name = "GetAnnotationPropertyValue";
			__tmp27.ParentLazy = () => AnnotatedElement;
			__tmp28.Name = "Scope";
			__tmp28.Documentation = null;
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
			Namespace_FullName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Namespace_FullName.Name = "FullName";
			Namespace_FullName.Documentation = null;
			Namespace_FullName.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			Namespace_FullName.ClassLazy = () => Namespace;
			Namespace_Declarations.Annotations.AddLazy(() => __tmp53);
			Namespace_Declarations.TypeLazy = () => __tmp54;
			Namespace_Declarations.Name = "Declarations";
			Namespace_Declarations.Documentation = null;
			Namespace_Declarations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Namespace_Declarations.ClassLazy = () => Namespace;
			Namespace_Declarations.OppositeProperties.AddLazy(() => Declaration_Namespace);
			Declaration_Namespace.TypeLazy = () => Namespace;
			Declaration_Namespace.Name = "Namespace";
			Declaration_Namespace.Documentation = null;
			// Declaration_Namespace.Kind = null;
			Declaration_Namespace.ClassLazy = () => Declaration;
			Declaration_Namespace.OppositeProperties.AddLazy(() => Namespace_Declarations);
			EnumLiteral_Enum.TypeLazy = () => Enum;
			EnumLiteral_Enum.Name = "Enum";
			EnumLiteral_Enum.Documentation = null;
			// EnumLiteral_Enum.Kind = null;
			EnumLiteral_Enum.ClassLazy = () => EnumLiteral;
			EnumLiteral_Enum.OppositeProperties.AddLazy(() => Enum_EnumLiterals);
			EnumLiteral_Enum.RedefinedProperties.AddLazy(() => TypedElement_Type);
			__tmp29.Name = "Scope";
			__tmp29.Documentation = null;
			Enum_BaseType.Annotations.AddLazy(() => __tmp55);
			Enum_BaseType.TypeLazy = () => Enum;
			Enum_BaseType.Name = "BaseType";
			Enum_BaseType.Documentation = null;
			// Enum_BaseType.Kind = null;
			Enum_BaseType.ClassLazy = () => Enum;
			Enum_EnumLiterals.Annotations.AddLazy(() => __tmp56);
			Enum_EnumLiterals.TypeLazy = () => __tmp57;
			Enum_EnumLiterals.Name = "EnumLiterals";
			Enum_EnumLiterals.Documentation = null;
			Enum_EnumLiterals.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Enum_EnumLiterals.ClassLazy = () => Enum;
			Enum_EnumLiterals.OppositeProperties.AddLazy(() => EnumLiteral_Enum);
			Port_Component.TypeLazy = () => Component;
			Port_Component.Name = "Component";
			Port_Component.Documentation = null;
			// Port_Component.Kind = null;
			Port_Component.ClassLazy = () => Port;
			Port_Component.OppositeProperties.AddLazy(() => Component_Ports);
			Port_Name.Annotations.AddLazy(() => __tmp58);
			Port_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Port_Name.Name = "Name";
			Port_Name.Documentation = null;
			Port_Name.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Derived;
			Port_Name.ClassLazy = () => Port;
			Port_OptionalName.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Port_OptionalName.Name = "OptionalName";
			Port_OptionalName.Documentation = null;
			// Port_OptionalName.Kind = null;
			Port_OptionalName.ClassLazy = () => Port;
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
			__tmp30.Name = "Scope";
			__tmp30.Documentation = null;
			Component_BaseComponent.Annotations.AddLazy(() => __tmp59);
			Component_BaseComponent.TypeLazy = () => Component;
			Component_BaseComponent.Name = "BaseComponent";
			Component_BaseComponent.Documentation = null;
			// Component_BaseComponent.Kind = null;
			Component_BaseComponent.ClassLazy = () => Component;
			Component_IsAbstract.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			Component_IsAbstract.Name = "IsAbstract";
			Component_IsAbstract.Documentation = null;
			// Component_IsAbstract.Kind = null;
			Component_IsAbstract.ClassLazy = () => Component;
			Component_Ports.Annotations.AddLazy(() => __tmp60);
			Component_Ports.TypeLazy = () => __tmp61;
			Component_Ports.Name = "Ports";
			Component_Ports.Documentation = null;
			Component_Ports.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Ports.ClassLazy = () => Component;
			Component_Ports.OppositeProperties.AddLazy(() => Port_Component);
			Component_Ports.SubsettingProperties.AddLazy(() => Component_Services);
			Component_Ports.SubsettingProperties.AddLazy(() => Component_References);
			Component_Services.TypeLazy = () => __tmp62;
			Component_Services.Name = "Services";
			Component_Services.Documentation = null;
			Component_Services.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Services.ClassLazy = () => Component;
			Component_Services.SubsettedProperties.AddLazy(() => Component_Ports);
			Component_References.TypeLazy = () => __tmp63;
			Component_References.Name = "References";
			Component_References.Documentation = null;
			Component_References.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_References.ClassLazy = () => Component;
			Component_References.SubsettedProperties.AddLazy(() => Component_Ports);
			Component_Properties.Annotations.AddLazy(() => __tmp64);
			Component_Properties.TypeLazy = () => __tmp65;
			Component_Properties.Name = "Properties";
			Component_Properties.Documentation = null;
			Component_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Properties.ClassLazy = () => Component;
			Component_Implementation.TypeLazy = () => Implementation;
			Component_Implementation.Name = "Implementation";
			Component_Implementation.Documentation = null;
			Component_Implementation.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Implementation.ClassLazy = () => Component;
			Component_Language.TypeLazy = () => Language;
			Component_Language.Name = "Language";
			Component_Language.Documentation = null;
			Component_Language.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Component_Language.ClassLazy = () => Component;
			__tmp31.TypeLazy = () => SoapEncodingStyle;
			__tmp31.Name = "DocumentWrapped";
			__tmp31.Documentation = null;
			__tmp31.EnumLazy = () => SoapEncodingStyle;
			__tmp32.TypeLazy = () => SoapEncodingStyle;
			__tmp32.Name = "DocumentLiteral";
			__tmp32.Documentation = null;
			__tmp32.EnumLazy = () => SoapEncodingStyle;
			__tmp33.TypeLazy = () => SoapEncodingStyle;
			__tmp33.Name = "RpcLiteral";
			__tmp33.Documentation = null;
			__tmp33.EnumLazy = () => SoapEncodingStyle;
			__tmp34.TypeLazy = () => SoapEncodingStyle;
			__tmp34.Name = "RpcEncoded";
			__tmp34.Documentation = null;
			__tmp34.EnumLazy = () => SoapEncodingStyle;
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
			Deployment_Environments.TypeLazy = () => __tmp66;
			Deployment_Environments.Name = "Environments";
			Deployment_Environments.Documentation = null;
			Deployment_Environments.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Deployment_Environments.ClassLazy = () => Deployment;
			Deployment_Wires.TypeLazy = () => __tmp67;
			Deployment_Wires.Name = "Wires";
			Deployment_Wires.Documentation = null;
			Deployment_Wires.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Deployment_Wires.ClassLazy = () => Deployment;
			__tmp35.TypeLazy = () => SoapVersion;
			__tmp35.Name = "Soap11";
			__tmp35.Documentation = null;
			__tmp35.EnumLazy = () => SoapVersion;
			__tmp36.TypeLazy = () => SoapVersion;
			__tmp36.Name = "Soap12";
			__tmp36.Documentation = null;
			__tmp36.EnumLazy = () => SoapVersion;
			Environment_Runtime.TypeLazy = () => Runtime;
			Environment_Runtime.Name = "Runtime";
			Environment_Runtime.Documentation = null;
			Environment_Runtime.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Environment_Runtime.ClassLazy = () => Environment;
			Environment_Databases.TypeLazy = () => __tmp68;
			Environment_Databases.Name = "Databases";
			Environment_Databases.Documentation = null;
			// Environment_Databases.Kind = null;
			Environment_Databases.ClassLazy = () => Environment;
			Environment_Assemblies.TypeLazy = () => __tmp69;
			Environment_Assemblies.Name = "Assemblies";
			Environment_Assemblies.Documentation = null;
			// Environment_Assemblies.Kind = null;
			Environment_Assemblies.ClassLazy = () => Environment;
			ArrayType_InnerType.TypeLazy = () => SoalType;
			ArrayType_InnerType.Name = "InnerType";
			ArrayType_InnerType.Documentation = null;
			// ArrayType_InnerType.Kind = null;
			ArrayType_InnerType.ClassLazy = () => ArrayType;
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
			__tmp37.Name = "Scope";
			__tmp37.Documentation = null;
			Struct_BaseType.Annotations.AddLazy(() => __tmp70);
			Struct_BaseType.TypeLazy = () => Struct;
			Struct_BaseType.Name = "BaseType";
			Struct_BaseType.Documentation = null;
			// Struct_BaseType.Kind = null;
			Struct_BaseType.ClassLazy = () => Struct;
			Struct_Properties.Annotations.AddLazy(() => __tmp71);
			Struct_Properties.TypeLazy = () => __tmp72;
			Struct_Properties.Name = "Properties";
			Struct_Properties.Documentation = null;
			Struct_Properties.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Struct_Properties.ClassLazy = () => Struct;
			PrimitiveType_Nullable.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			PrimitiveType_Nullable.Name = "Nullable";
			PrimitiveType_Nullable.Documentation = null;
			// PrimitiveType_Nullable.Kind = null;
			PrimitiveType_Nullable.ClassLazy = () => PrimitiveType;
			OutputParameter_IsOneway.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Bool.ToMutable();
			OutputParameter_IsOneway.Name = "IsOneway";
			OutputParameter_IsOneway.Documentation = null;
			// OutputParameter_IsOneway.Kind = null;
			OutputParameter_IsOneway.ClassLazy = () => OutputParameter;
			Database_Entities.Annotations.AddLazy(() => __tmp73);
			Database_Entities.TypeLazy = () => __tmp74;
			Database_Entities.Name = "Entities";
			Database_Entities.Documentation = null;
			// Database_Entities.Kind = null;
			Database_Entities.ClassLazy = () => Database;
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
			Composite_Components.Annotations.AddLazy(() => __tmp75);
			Composite_Components.TypeLazy = () => __tmp76;
			Composite_Components.Name = "Components";
			Composite_Components.Documentation = null;
			// Composite_Components.Kind = null;
			Composite_Components.ClassLazy = () => Composite;
			Composite_Wires.TypeLazy = () => __tmp77;
			Composite_Wires.Name = "Wires";
			Composite_Wires.Documentation = null;
			Composite_Wires.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Composite_Wires.ClassLazy = () => Composite;
			NonNullableType_InnerType.TypeLazy = () => SoalType;
			NonNullableType_InnerType.Name = "InnerType";
			NonNullableType_InnerType.Documentation = null;
			// NonNullableType_InnerType.Kind = null;
			NonNullableType_InnerType.ClassLazy = () => NonNullableType;
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
			NullableType_InnerType.TypeLazy = () => SoalType;
			NullableType_InnerType.Name = "InnerType";
			NullableType_InnerType.Documentation = null;
			// NullableType_InnerType.Kind = null;
			NullableType_InnerType.ClassLazy = () => NullableType;
			NamedElement_Name.Annotations.AddLazy(() => __tmp78);
			NamedElement_Name.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			NamedElement_Name.Name = "Name";
			NamedElement_Name.Documentation = null;
			// NamedElement_Name.Kind = null;
			NamedElement_Name.ClassLazy = () => NamedElement;
			__tmp38.Name = "Type";
			__tmp38.Documentation = null;
			__tmp39.Name = "Scope";
			__tmp39.Documentation = null;
			Interface_Operations.Annotations.AddLazy(() => __tmp79);
			Interface_Operations.TypeLazy = () => __tmp80;
			Interface_Operations.Name = "Operations";
			Interface_Operations.Documentation = null;
			Interface_Operations.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Interface_Operations.ClassLazy = () => Interface;
			TypedElement_Type.Annotations.AddLazy(() => __tmp81);
			TypedElement_Type.TypeLazy = () => SoalType;
			TypedElement_Type.Name = "Type";
			TypedElement_Type.Documentation = null;
			// TypedElement_Type.Kind = null;
			TypedElement_Type.ClassLazy = () => TypedElement;
			TypedElement_Type.RedefiningProperties.AddLazy(() => EnumLiteral_Enum);
			Operation_Action.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			Operation_Action.Name = "Action";
			Operation_Action.Documentation = null;
			// Operation_Action.Kind = null;
			Operation_Action.ClassLazy = () => Operation;
			Operation_Parameters.TypeLazy = () => __tmp82;
			Operation_Parameters.Name = "Parameters";
			Operation_Parameters.Documentation = null;
			Operation_Parameters.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Operation_Parameters.ClassLazy = () => Operation;
			Operation_Result.TypeLazy = () => OutputParameter;
			Operation_Result.Name = "Result";
			Operation_Result.Documentation = null;
			Operation_Result.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Readonly;
			Operation_Result.ClassLazy = () => Operation;
			Operation_Exceptions.TypeLazy = () => __tmp83;
			Operation_Exceptions.Name = "Exceptions";
			Operation_Exceptions.Documentation = null;
			// Operation_Exceptions.Kind = null;
			Operation_Exceptions.ClassLazy = () => Operation;
			Binding_Transport.TypeLazy = () => TransportBindingElement;
			Binding_Transport.Name = "Transport";
			Binding_Transport.Documentation = null;
			Binding_Transport.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Transport.ClassLazy = () => Binding;
			Binding_Encodings.TypeLazy = () => __tmp84;
			Binding_Encodings.Name = "Encodings";
			Binding_Encodings.Documentation = null;
			Binding_Encodings.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Encodings.ClassLazy = () => Binding;
			Binding_Protocols.TypeLazy = () => __tmp85;
			Binding_Protocols.Name = "Protocols";
			Binding_Protocols.Documentation = null;
			Binding_Protocols.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaPropertyKind.Containment;
			Binding_Protocols.ClassLazy = () => Binding;
			AnnotationProperty_Value.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.Object.ToMutable();
			AnnotationProperty_Value.Name = "Value";
			AnnotationProperty_Value.Documentation = null;
			// AnnotationProperty_Value.Kind = null;
			AnnotationProperty_Value.ClassLazy = () => AnnotationProperty;
			__tmp40.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp40.InnerTypeLazy = () => AnnotationProperty;
			__tmp41.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp41.Name = "name";
			__tmp41.Documentation = null;
			__tmp41.FunctionLazy = () => __tmp20;
			__tmp42.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp42.Name = "name";
			__tmp42.Documentation = null;
			__tmp42.FunctionLazy = () => __tmp21;
			__tmp43.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp43.Name = "name";
			__tmp43.Documentation = null;
			__tmp43.FunctionLazy = () => __tmp22;
			__tmp44.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp44.InnerTypeLazy = () => Annotation;
			__tmp45.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp45.Name = "name";
			__tmp45.Documentation = null;
			__tmp45.FunctionLazy = () => __tmp23;
			__tmp46.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp46.Name = "name";
			__tmp46.Documentation = null;
			__tmp46.FunctionLazy = () => __tmp24;
			__tmp47.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp47.InnerTypeLazy = () => Annotation;
			__tmp48.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp48.Name = "name";
			__tmp48.Documentation = null;
			__tmp48.FunctionLazy = () => __tmp25;
			__tmp49.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp49.Name = "annotationName";
			__tmp49.Documentation = null;
			__tmp49.FunctionLazy = () => __tmp26;
			__tmp50.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp50.Name = "propertyName";
			__tmp50.Documentation = null;
			__tmp50.FunctionLazy = () => __tmp26;
			__tmp51.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp51.Name = "annotationName";
			__tmp51.Documentation = null;
			__tmp51.FunctionLazy = () => __tmp27;
			__tmp52.TypeLazy = () => global::MetaDslx.Languages.Meta.Symbols.MetaInstance.String.ToMutable();
			__tmp52.Name = "propertyName";
			__tmp52.Documentation = null;
			__tmp52.FunctionLazy = () => __tmp27;
			__tmp53.Name = "ScopeEntry";
			__tmp53.Documentation = null;
			__tmp54.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp54.InnerTypeLazy = () => Declaration;
			__tmp55.Name = "InheritedScope";
			__tmp55.Documentation = null;
			__tmp56.Name = "ScopeEntry";
			__tmp56.Documentation = null;
			__tmp57.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp57.InnerTypeLazy = () => EnumLiteral;
			__tmp58.Name = "Name";
			__tmp58.Documentation = null;
			__tmp59.Name = "InheritedScope";
			__tmp59.Documentation = null;
			__tmp60.Name = "ScopeEntry";
			__tmp60.Documentation = null;
			__tmp61.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp61.InnerTypeLazy = () => Port;
			__tmp62.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp62.InnerTypeLazy = () => Service;
			__tmp63.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp63.InnerTypeLazy = () => Reference;
			__tmp64.Name = "ScopeEntry";
			__tmp64.Documentation = null;
			__tmp65.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp65.InnerTypeLazy = () => Property;
			__tmp66.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp66.InnerTypeLazy = () => Environment;
			__tmp67.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp67.InnerTypeLazy = () => Wire;
			__tmp68.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp68.InnerTypeLazy = () => Database;
			__tmp69.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp69.InnerTypeLazy = () => Assembly;
			__tmp70.Name = "InheritedScope";
			__tmp70.Documentation = null;
			__tmp71.Name = "ScopeEntry";
			__tmp71.Documentation = null;
			__tmp72.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp72.InnerTypeLazy = () => Property;
			__tmp73.Name = "ScopeEntry";
			__tmp73.Documentation = null;
			__tmp74.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp74.InnerTypeLazy = () => Struct;
			__tmp75.Name = "ScopeEntry";
			__tmp75.Documentation = null;
			__tmp76.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp76.InnerTypeLazy = () => Component;
			__tmp77.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp77.InnerTypeLazy = () => Wire;
			__tmp78.Name = "Name";
			__tmp78.Documentation = null;
			__tmp79.Name = "ScopeEntry";
			__tmp79.Documentation = null;
			__tmp80.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp80.InnerTypeLazy = () => Operation;
			__tmp81.Name = "Type";
			__tmp81.Documentation = null;
			__tmp82.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp82.InnerTypeLazy = () => InputParameter;
			__tmp83.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp83.InnerTypeLazy = () => Struct;
			__tmp84.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp84.InnerTypeLazy = () => EncodingBindingElement;
			__tmp85.Kind = global::MetaDslx.Languages.Meta.Symbols.MetaCollectionKind.List;
			__tmp85.InnerTypeLazy = () => ProtocolBindingElement;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
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
		/// Implements the operation: AnnotatedElement.HasAnnotation()
		/// </summary>
		public virtual bool AnnotatedElement_HasAnnotation(AnnotatedElement _this, string name)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: AnnotatedElement.GetAnnotation()
		/// </summary>
		public virtual Annotation AnnotatedElement_GetAnnotation(AnnotatedElement _this, string name)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: AnnotatedElement.GetAnnotations()
		/// </summary>
		public virtual global::MetaDslx.Core.ImmutableModelList<Annotation> AnnotatedElement_GetAnnotations(AnnotatedElement _this, string name)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: AnnotatedElement.HasAnnotationProperty()
		/// </summary>
		public virtual bool AnnotatedElement_HasAnnotationProperty(AnnotatedElement _this, string annotationName, string propertyName)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: AnnotatedElement.GetAnnotationPropertyValue()
		/// </summary>
		public virtual object AnnotatedElement_GetAnnotationPropertyValue(AnnotatedElement _this, string annotationName, string propertyName)
		{
			throw new NotImplementedException();
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
			this.NamedElement(_this);
		}
	
		/// <summary>
		/// Implements the operation: Annotation.HasProperty()
		/// </summary>
		public virtual bool Annotation_HasProperty(Annotation _this, string name)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: Annotation.GetProperty()
		/// </summary>
		public virtual AnnotationProperty Annotation_GetProperty(Annotation _this, string name)
		{
			throw new NotImplementedException();
		}
	
		/// <summary>
		/// Implements the operation: Annotation.GetPropertyValue()
		/// </summary>
		public virtual object Annotation_GetPropertyValue(Annotation _this, string name)
		{
			throw new NotImplementedException();
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
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: NamedElement()
		/// </summary>
		public virtual void NamedElement(NamedElementBuilder _this)
		{
			this.CallNamedElementSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of NamedElement
		/// </summary>
		protected virtual void CallNamedElementSuperConstructors(NamedElementBuilder _this)
		{
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
		/// Implements the constructor: Namespace()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		/// </ul>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>FullName</li>
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
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
			this.Declaration(_this);
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
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
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
			this.AnnotatedElement(_this);
			this.NamedElement(_this);
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
		///     <li>AnnotatedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		/// Initializes the following readonly properties:
		/// <ul>
		///     <li>Result</li>
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
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Name</li>
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
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Language()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Language(LanguageBuilder _this)
		{
			this.CallLanguageSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Language
		/// </summary>
		protected virtual void CallLanguageSuperConstructors(LanguageBuilder _this)
		{
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

