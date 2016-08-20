using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetaDslx.Soal
{
	using global::MetaDslx.Soal.Internal;

	public class SoalInstance
	{
		private static bool initialized;
	
		public static bool IsInitialized
		{
			get { return SoalInstance.initialized; }
		}
	
		public static readonly global::MetaDslx.Core.MetaModel MetaModel;
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
		public static readonly PrimitiveType DateTime;
		public static readonly PrimitiveType TimeSpan;
	
		public static readonly global::MetaDslx.Core.MetaClass NamedElement;
		public static readonly global::MetaDslx.Core.MetaProperty NamedElement_Name;
		public static readonly global::MetaDslx.Core.MetaClass TypedElement;
		public static readonly global::MetaDslx.Core.MetaProperty TypedElement_Type;
		public static readonly global::MetaDslx.Core.MetaClass SoalType;
		public static readonly global::MetaDslx.Core.MetaClass Namespace;
		public static readonly global::MetaDslx.Core.MetaProperty Namespace_Declarations;
		public static readonly global::MetaDslx.Core.MetaClass Declaration;
		public static readonly global::MetaDslx.Core.MetaProperty Declaration_Namespace;
		public static readonly global::MetaDslx.Core.MetaClass ArrayType;
		/**
		 * <summary>
		 * ArrayType()
		 * {
		 * Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
		 * }
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.MetaProperty ArrayType_InnerType;
		public static readonly global::MetaDslx.Core.MetaProperty ArrayType_Namespace;
		public static readonly global::MetaDslx.Core.MetaClass NullableType;
		/**
		 * <summary>
		 * NullableType()
		 * {
		 * Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
		 * }
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.MetaProperty NullableType_InnerType;
		public static readonly global::MetaDslx.Core.MetaProperty NullableType_Namespace;
		public static readonly global::MetaDslx.Core.MetaClass PrimitiveType;
		public static readonly global::MetaDslx.Core.MetaClass Enum;
		public static readonly global::MetaDslx.Core.MetaProperty Enum_EnumLiterals;
		public static readonly global::MetaDslx.Core.MetaClass EnumLiteral;
		/**
		 * <summary>
		 * EnumLiteral()
		 * {
		 * Type = Enum;
		 * }
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.MetaProperty EnumLiteral_Enum;
		public static readonly global::MetaDslx.Core.MetaClass StructuredType;
		public static readonly global::MetaDslx.Core.MetaProperty StructuredType_Properties;
		public static readonly global::MetaDslx.Core.MetaClass Property;
		public static readonly global::MetaDslx.Core.MetaProperty Property_Parent;
		public static readonly global::MetaDslx.Core.MetaClass Struct;
		public static readonly global::MetaDslx.Core.MetaProperty Struct_BaseType;
		public static readonly global::MetaDslx.Core.MetaClass Exception;
		public static readonly global::MetaDslx.Core.MetaProperty Exception_BaseType;
		public static readonly global::MetaDslx.Core.MetaClass Entity;
		public static readonly global::MetaDslx.Core.MetaProperty Entity_BaseType;
		public static readonly global::MetaDslx.Core.MetaClass Interface;
		public static readonly global::MetaDslx.Core.MetaProperty Interface_Operations;
		public static readonly global::MetaDslx.Core.MetaClass Database;
		public static readonly global::MetaDslx.Core.MetaProperty Database_Entities;
		public static readonly global::MetaDslx.Core.MetaClass Operation;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_Parent;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_IsOneway;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_ReturnType;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_Parameters;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_Exceptions;
		public static readonly global::MetaDslx.Core.MetaClass Parameter;
		public static readonly global::MetaDslx.Core.MetaProperty Parameter_Operation;
		public static readonly global::MetaDslx.Core.MetaClass Component;
		public static readonly global::MetaDslx.Core.MetaProperty Component_BaseComponent;
		public static readonly global::MetaDslx.Core.MetaProperty Component_IsAbstract;
		public static readonly global::MetaDslx.Core.MetaProperty Component_Services;
		public static readonly global::MetaDslx.Core.MetaProperty Component_References;
		public static readonly global::MetaDslx.Core.MetaProperty Component_Properties;
		public static readonly global::MetaDslx.Core.MetaProperty Component_Implementation;
		public static readonly global::MetaDslx.Core.MetaProperty Component_Language;
		public static readonly global::MetaDslx.Core.MetaClass Composite;
		public static readonly global::MetaDslx.Core.MetaProperty Composite_Components;
		public static readonly global::MetaDslx.Core.MetaProperty Composite_Wires;
		public static readonly global::MetaDslx.Core.MetaClass Assembly;
		public static readonly global::MetaDslx.Core.MetaClass Wire;
		public static readonly global::MetaDslx.Core.MetaProperty Wire_Source;
		public static readonly global::MetaDslx.Core.MetaProperty Wire_Target;
		public static readonly global::MetaDslx.Core.MetaClass InterfaceReference;
		/**
		 * <summary>
		 * InterfaceReference()
		 * {
		 * // this.Name = this.OptionalName != "" ? this.OptionalName : this.Interface.Name;
		 * }
		 * </summary>
		 */
		public static readonly global::MetaDslx.Core.MetaProperty InterfaceReference_Name;
		public static readonly global::MetaDslx.Core.MetaProperty InterfaceReference_OptionalName;
		public static readonly global::MetaDslx.Core.MetaProperty InterfaceReference_Interface;
		public static readonly global::MetaDslx.Core.MetaProperty InterfaceReference_Binding;
		public static readonly global::MetaDslx.Core.MetaClass Service;
		public static readonly global::MetaDslx.Core.MetaClass Reference;
		public static readonly global::MetaDslx.Core.MetaClass Implementation;
		public static readonly global::MetaDslx.Core.MetaClass Language;
		public static readonly global::MetaDslx.Core.MetaClass Deployment;
		public static readonly global::MetaDslx.Core.MetaProperty Deployment_Environments;
		public static readonly global::MetaDslx.Core.MetaProperty Deployment_Wires;
		public static readonly global::MetaDslx.Core.MetaClass Environment;
		public static readonly global::MetaDslx.Core.MetaProperty Environment_Runtime;
		public static readonly global::MetaDslx.Core.MetaProperty Environment_Databases;
		public static readonly global::MetaDslx.Core.MetaProperty Environment_Assemblies;
		public static readonly global::MetaDslx.Core.MetaClass Runtime;
		public static readonly global::MetaDslx.Core.MetaClass Binding;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_Transport;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_Encodings;
		public static readonly global::MetaDslx.Core.MetaProperty Binding_Protocols;
		public static readonly global::MetaDslx.Core.MetaClass Endpoint;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_Interface;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_Binding;
		public static readonly global::MetaDslx.Core.MetaProperty Endpoint_Address;
		public static readonly global::MetaDslx.Core.MetaClass BindingElement;
		public static readonly global::MetaDslx.Core.MetaClass TransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass EncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass ProtocolBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass HttpTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass RestTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WebSocketTransportBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass SoapEncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaProperty SoapEncodingBindingElement_Version;
		public static readonly global::MetaDslx.Core.MetaProperty SoapEncodingBindingElement_MtomEnabled;
		public static readonly global::MetaDslx.Core.MetaClass XmlEncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass JsonEncodingBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WsProtocolBindingElement;
		public static readonly global::MetaDslx.Core.MetaClass WsAddressingBindingElement;
	
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
			DateTime = SoalBuilderInstance.instance.DateTime.ToImmutable(Model);
			TimeSpan = SoalBuilderInstance.instance.TimeSpan.ToImmutable(Model);
	
			NamedElement = SoalBuilderInstance.instance.NamedElement.ToImmutable(Model);
			NamedElement_Name = SoalBuilderInstance.instance.NamedElement_Name.ToImmutable(Model);
			TypedElement = SoalBuilderInstance.instance.TypedElement.ToImmutable(Model);
			TypedElement_Type = SoalBuilderInstance.instance.TypedElement_Type.ToImmutable(Model);
			SoalType = SoalBuilderInstance.instance.SoalType.ToImmutable(Model);
			Namespace = SoalBuilderInstance.instance.Namespace.ToImmutable(Model);
			Namespace_Declarations = SoalBuilderInstance.instance.Namespace_Declarations.ToImmutable(Model);
			Declaration = SoalBuilderInstance.instance.Declaration.ToImmutable(Model);
			Declaration_Namespace = SoalBuilderInstance.instance.Declaration_Namespace.ToImmutable(Model);
			ArrayType = SoalBuilderInstance.instance.ArrayType.ToImmutable(Model);
			ArrayType_InnerType = SoalBuilderInstance.instance.ArrayType_InnerType.ToImmutable(Model);
			ArrayType_Namespace = SoalBuilderInstance.instance.ArrayType_Namespace.ToImmutable(Model);
			NullableType = SoalBuilderInstance.instance.NullableType.ToImmutable(Model);
			NullableType_InnerType = SoalBuilderInstance.instance.NullableType_InnerType.ToImmutable(Model);
			NullableType_Namespace = SoalBuilderInstance.instance.NullableType_Namespace.ToImmutable(Model);
			PrimitiveType = SoalBuilderInstance.instance.PrimitiveType.ToImmutable(Model);
			Enum = SoalBuilderInstance.instance.Enum.ToImmutable(Model);
			Enum_EnumLiterals = SoalBuilderInstance.instance.Enum_EnumLiterals.ToImmutable(Model);
			EnumLiteral = SoalBuilderInstance.instance.EnumLiteral.ToImmutable(Model);
			EnumLiteral_Enum = SoalBuilderInstance.instance.EnumLiteral_Enum.ToImmutable(Model);
			StructuredType = SoalBuilderInstance.instance.StructuredType.ToImmutable(Model);
			StructuredType_Properties = SoalBuilderInstance.instance.StructuredType_Properties.ToImmutable(Model);
			Property = SoalBuilderInstance.instance.Property.ToImmutable(Model);
			Property_Parent = SoalBuilderInstance.instance.Property_Parent.ToImmutable(Model);
			Struct = SoalBuilderInstance.instance.Struct.ToImmutable(Model);
			Struct_BaseType = SoalBuilderInstance.instance.Struct_BaseType.ToImmutable(Model);
			Exception = SoalBuilderInstance.instance.Exception.ToImmutable(Model);
			Exception_BaseType = SoalBuilderInstance.instance.Exception_BaseType.ToImmutable(Model);
			Entity = SoalBuilderInstance.instance.Entity.ToImmutable(Model);
			Entity_BaseType = SoalBuilderInstance.instance.Entity_BaseType.ToImmutable(Model);
			Interface = SoalBuilderInstance.instance.Interface.ToImmutable(Model);
			Interface_Operations = SoalBuilderInstance.instance.Interface_Operations.ToImmutable(Model);
			Database = SoalBuilderInstance.instance.Database.ToImmutable(Model);
			Database_Entities = SoalBuilderInstance.instance.Database_Entities.ToImmutable(Model);
			Operation = SoalBuilderInstance.instance.Operation.ToImmutable(Model);
			Operation_Parent = SoalBuilderInstance.instance.Operation_Parent.ToImmutable(Model);
			Operation_IsOneway = SoalBuilderInstance.instance.Operation_IsOneway.ToImmutable(Model);
			Operation_ReturnType = SoalBuilderInstance.instance.Operation_ReturnType.ToImmutable(Model);
			Operation_Parameters = SoalBuilderInstance.instance.Operation_Parameters.ToImmutable(Model);
			Operation_Exceptions = SoalBuilderInstance.instance.Operation_Exceptions.ToImmutable(Model);
			Parameter = SoalBuilderInstance.instance.Parameter.ToImmutable(Model);
			Parameter_Operation = SoalBuilderInstance.instance.Parameter_Operation.ToImmutable(Model);
			Component = SoalBuilderInstance.instance.Component.ToImmutable(Model);
			Component_BaseComponent = SoalBuilderInstance.instance.Component_BaseComponent.ToImmutable(Model);
			Component_IsAbstract = SoalBuilderInstance.instance.Component_IsAbstract.ToImmutable(Model);
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
			InterfaceReference = SoalBuilderInstance.instance.InterfaceReference.ToImmutable(Model);
			InterfaceReference_Name = SoalBuilderInstance.instance.InterfaceReference_Name.ToImmutable(Model);
			InterfaceReference_OptionalName = SoalBuilderInstance.instance.InterfaceReference_OptionalName.ToImmutable(Model);
			InterfaceReference_Interface = SoalBuilderInstance.instance.InterfaceReference_Interface.ToImmutable(Model);
			InterfaceReference_Binding = SoalBuilderInstance.instance.InterfaceReference_Binding.ToImmutable(Model);
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
			RestTransportBindingElement = SoalBuilderInstance.instance.RestTransportBindingElement.ToImmutable(Model);
			WebSocketTransportBindingElement = SoalBuilderInstance.instance.WebSocketTransportBindingElement.ToImmutable(Model);
			SoapEncodingBindingElement = SoalBuilderInstance.instance.SoapEncodingBindingElement.ToImmutable(Model);
			SoapEncodingBindingElement_Version = SoalBuilderInstance.instance.SoapEncodingBindingElement_Version.ToImmutable(Model);
			SoapEncodingBindingElement_MtomEnabled = SoalBuilderInstance.instance.SoapEncodingBindingElement_MtomEnabled.ToImmutable(Model);
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
				case "Namespace": return this.Namespace();
				case "ArrayType": return this.ArrayType();
				case "NullableType": return this.NullableType();
				case "PrimitiveType": return this.PrimitiveType();
				case "Enum": return this.Enum();
				case "EnumLiteral": return this.EnumLiteral();
				case "Property": return this.Property();
				case "Struct": return this.Struct();
				case "Exception": return this.Exception();
				case "Entity": return this.Entity();
				case "Interface": return this.Interface();
				case "Database": return this.Database();
				case "Operation": return this.Operation();
				case "Parameter": return this.Parameter();
				case "Component": return this.Component();
				case "Composite": return this.Composite();
				case "Assembly": return this.Assembly();
				case "Wire": return this.Wire();
				case "InterfaceReference": return this.InterfaceReference();
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
					throw new global::MetaDslx.Core.ModelException("Unknown type name: " + type);
			}
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
		/// Creates a new instance of Exception.
		/// </summary>
		public ExceptionBuilder Exception()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ExceptionId());
			return (ExceptionBuilder)symbol;
		}
	
		/// <summary>
		/// Creates a new instance of Entity.
		/// </summary>
		public EntityBuilder Entity()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new EntityId());
			return (EntityBuilder)symbol;
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
		/// Creates a new instance of Parameter.
		/// </summary>
		public ParameterBuilder Parameter()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new ParameterId());
			return (ParameterBuilder)symbol;
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
		/// Creates a new instance of InterfaceReference.
		/// </summary>
		public InterfaceReferenceBuilder InterfaceReference()
		{
			global::MetaDslx.Core.MutableSymbol symbol = this.CreateSymbol(new InterfaceReferenceId());
			return (InterfaceReferenceBuilder)symbol;
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
	
	[global::MetaDslx.Core.Type]
	public interface SoalType : global::MetaDslx.Core.ImmutableSymbol
	{
	
	
		new SoalTypeBuilder ToMutable();
		new SoalTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Type]
	public interface SoalTypeBuilder : global::MetaDslx.Core.MutableSymbol
	{
	
		new SoalType ToImmutable();
		new SoalType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface Namespace : Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations { get; }
	
	
		new NamespaceBuilder ToMutable();
		new NamespaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface NamespaceBuilder : DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations { get; }
	
		new Namespace ToImmutable();
		new Namespace ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Declaration : NamedElement
	{
		Namespace Namespace { get; }
	
	
		new DeclarationBuilder ToMutable();
		new DeclarationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DeclarationBuilder : NamedElementBuilder
	{
		NamespaceBuilder Namespace { get; set; }
		Func<NamespaceBuilder> NamespaceLazy { get; set; }
	
		new Declaration ToImmutable();
		new Declaration ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface ArrayType : SoalType
	{
		SoalType InnerType { get; }
		Namespace Namespace { get; }
	
	
		new ArrayTypeBuilder ToMutable();
		new ArrayTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ArrayTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
		NamespaceBuilder Namespace { get; }
		Func<NamespaceBuilder> NamespaceLazy { get; set; }
	
		new ArrayType ToImmutable();
		new ArrayType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface NullableType : SoalType
	{
		SoalType InnerType { get; }
		Namespace Namespace { get; }
	
	
		new NullableTypeBuilder ToMutable();
		new NullableTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface NullableTypeBuilder : SoalTypeBuilder
	{
		SoalTypeBuilder InnerType { get; set; }
		Func<SoalTypeBuilder> InnerTypeLazy { get; set; }
		NamespaceBuilder Namespace { get; }
		Func<NamespaceBuilder> NamespaceLazy { get; set; }
	
		new NullableType ToImmutable();
		new NullableType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface PrimitiveType : SoalType, NamedElement
	{
	
	
		new PrimitiveTypeBuilder ToMutable();
		new PrimitiveTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PrimitiveTypeBuilder : SoalTypeBuilder, NamedElementBuilder
	{
	
		new PrimitiveType ToImmutable();
		new PrimitiveType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface Enum : SoalType, Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<EnumLiteral> EnumLiterals { get; }
	
	
		new EnumBuilder ToMutable();
		new EnumBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface EnumBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> EnumLiterals { get; }
	
		new Enum ToImmutable();
		new Enum ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface EnumLiteral : NamedElement, TypedElement
	{
		Enum Enum { get; }
	
	
		new EnumLiteralBuilder ToMutable();
		new EnumLiteralBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EnumLiteralBuilder : NamedElementBuilder, TypedElementBuilder
	{
		EnumBuilder Enum { get; set; }
		Func<EnumBuilder> EnumLazy { get; set; }
	
		new EnumLiteral ToImmutable();
		new EnumLiteral ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface StructuredType : SoalType, Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Property> Properties { get; }
	
	
		new StructuredTypeBuilder ToMutable();
		new StructuredTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface StructuredTypeBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties { get; }
	
		new StructuredType ToImmutable();
		new StructuredType ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Property : NamedElement, TypedElement
	{
		StructuredType Parent { get; }
	
	
		new PropertyBuilder ToMutable();
		new PropertyBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface PropertyBuilder : NamedElementBuilder, TypedElementBuilder
	{
		StructuredTypeBuilder Parent { get; set; }
		Func<StructuredTypeBuilder> ParentLazy { get; set; }
	
		new Property ToImmutable();
		new Property ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Struct : StructuredType
	{
		Struct BaseType { get; }
	
	
		new StructBuilder ToMutable();
		new StructBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface StructBuilder : StructuredTypeBuilder
	{
		StructBuilder BaseType { get; set; }
		Func<StructBuilder> BaseTypeLazy { get; set; }
	
		new Struct ToImmutable();
		new Struct ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Exception : StructuredType
	{
		Exception BaseType { get; }
	
	
		new ExceptionBuilder ToMutable();
		new ExceptionBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ExceptionBuilder : StructuredTypeBuilder
	{
		ExceptionBuilder BaseType { get; set; }
		Func<ExceptionBuilder> BaseTypeLazy { get; set; }
	
		new Exception ToImmutable();
		new Exception ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Entity : StructuredType
	{
		Entity BaseType { get; }
	
	
		new EntityBuilder ToMutable();
		new EntityBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface EntityBuilder : StructuredTypeBuilder
	{
		EntityBuilder BaseType { get; set; }
		Func<EntityBuilder> BaseTypeLazy { get; set; }
	
		new Entity ToImmutable();
		new Entity ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface Interface : SoalType, Declaration
	{
		global::MetaDslx.Core.ImmutableModelList<Operation> Operations { get; }
	
	
		new InterfaceBuilder ToMutable();
		new InterfaceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface InterfaceBuilder : SoalTypeBuilder, DeclarationBuilder
	{
		global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations { get; }
	
		new Interface ToImmutable();
		new Interface ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Database : Interface
	{
		global::MetaDslx.Core.ImmutableModelList<Entity> Entities { get; }
	
	
		new DatabaseBuilder ToMutable();
		new DatabaseBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface DatabaseBuilder : InterfaceBuilder
	{
		global::MetaDslx.Core.MutableModelList<EntityBuilder> Entities { get; }
	
		new Database ToImmutable();
		new Database ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Operation : NamedElement
	{
		Interface Parent { get; }
		bool IsOneway { get; }
		SoalType ReturnType { get; }
		global::MetaDslx.Core.ImmutableModelList<Parameter> Parameters { get; }
		global::MetaDslx.Core.ImmutableModelList<Exception> Exceptions { get; }
	
	
		new OperationBuilder ToMutable();
		new OperationBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface OperationBuilder : NamedElementBuilder
	{
		InterfaceBuilder Parent { get; set; }
		Func<InterfaceBuilder> ParentLazy { get; set; }
		bool IsOneway { get; set; }
		Func<bool> IsOnewayLazy { get; set; }
		SoalTypeBuilder ReturnType { get; set; }
		Func<SoalTypeBuilder> ReturnTypeLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<ParameterBuilder> Parameters { get; }
		global::MetaDslx.Core.MutableModelList<ExceptionBuilder> Exceptions { get; }
	
		new Operation ToImmutable();
		new Operation ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Parameter : NamedElement, TypedElement
	{
		Operation Operation { get; }
	
	
		new ParameterBuilder ToMutable();
		new ParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ParameterBuilder : NamedElementBuilder, TypedElementBuilder
	{
		OperationBuilder Operation { get; set; }
		Func<OperationBuilder> OperationLazy { get; set; }
	
		new Parameter ToImmutable();
		new Parameter ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface Component : Declaration, StructuredType
	{
		Component BaseComponent { get; }
		bool IsAbstract { get; }
		global::MetaDslx.Core.ImmutableModelList<Service> Services { get; }
		global::MetaDslx.Core.ImmutableModelList<Reference> References { get; }
		new global::MetaDslx.Core.ImmutableModelList<Property> Properties { get; }
		Implementation Implementation { get; }
		Language Language { get; }
	
	
		new ComponentBuilder ToMutable();
		new ComponentBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	[global::MetaDslx.Core.Scope]
	public interface ComponentBuilder : DeclarationBuilder, StructuredTypeBuilder
	{
		ComponentBuilder BaseComponent { get; set; }
		Func<ComponentBuilder> BaseComponentLazy { get; set; }
		bool IsAbstract { get; set; }
		Func<bool> IsAbstractLazy { get; set; }
		global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services { get; }
		global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References { get; }
		new global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties { get; }
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
		InterfaceReference Source { get; }
		InterfaceReference Target { get; }
	
	
		new WireBuilder ToMutable();
		new WireBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface WireBuilder : global::MetaDslx.Core.MutableSymbol
	{
		InterfaceReferenceBuilder Source { get; set; }
		Func<InterfaceReferenceBuilder> SourceLazy { get; set; }
		InterfaceReferenceBuilder Target { get; set; }
		Func<InterfaceReferenceBuilder> TargetLazy { get; set; }
	
		new Wire ToImmutable();
		new Wire ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface InterfaceReference : global::MetaDslx.Core.ImmutableSymbol
	{
		string Name { get; }
		string OptionalName { get; }
		Interface Interface { get; }
		Binding Binding { get; }
	
	
		new InterfaceReferenceBuilder ToMutable();
		new InterfaceReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface InterfaceReferenceBuilder : global::MetaDslx.Core.MutableSymbol
	{
		string Name { get; }
		Func<string> NameLazy { get; set; }
		string OptionalName { get; set; }
		Func<string> OptionalNameLazy { get; set; }
		InterfaceBuilder Interface { get; set; }
		Func<InterfaceBuilder> InterfaceLazy { get; set; }
		BindingBuilder Binding { get; set; }
		Func<BindingBuilder> BindingLazy { get; set; }
	
		new InterfaceReference ToImmutable();
		new InterfaceReference ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Service : InterfaceReference
	{
	
	
		new ServiceBuilder ToMutable();
		new ServiceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ServiceBuilder : InterfaceReferenceBuilder
	{
	
		new Service ToImmutable();
		new Service ToImmutable(global::MetaDslx.Core.ImmutableModel model);
	}
	
	public interface Reference : InterfaceReference
	{
	
	
		new ReferenceBuilder ToMutable();
		new ReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface ReferenceBuilder : InterfaceReferenceBuilder
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
	
	
		new HttpTransportBindingElementBuilder ToMutable();
		new HttpTransportBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface HttpTransportBindingElementBuilder : TransportBindingElementBuilder
	{
	
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
		SoapVersion Version { get; }
		bool MtomEnabled { get; }
	
	
		new SoapEncodingBindingElementBuilder ToMutable();
		new SoapEncodingBindingElementBuilder ToMutable(global::MetaDslx.Core.MutableModel model);
	}
	
	public interface SoapEncodingBindingElementBuilder : EncodingBindingElementBuilder
	{
		SoapVersion Version { get; set; }
		Func<SoapVersion> VersionLazy { get; set; }
		bool MtomEnabled { get; set; }
		Func<bool> MtomEnabledLazy { get; set; }
	
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
			properties.Add(SoalDescriptor.NamedElement.NameProperty);
			properties.Add(SoalDescriptor.TypedElement.TypeProperty);
			properties.Add(SoalDescriptor.Namespace.DeclarationsProperty);
			properties.Add(SoalDescriptor.Declaration.NamespaceProperty);
			properties.Add(SoalDescriptor.ArrayType.InnerTypeProperty);
			properties.Add(SoalDescriptor.ArrayType.NamespaceProperty);
			properties.Add(SoalDescriptor.NullableType.InnerTypeProperty);
			properties.Add(SoalDescriptor.NullableType.NamespaceProperty);
			properties.Add(SoalDescriptor.Enum.EnumLiteralsProperty);
			properties.Add(SoalDescriptor.EnumLiteral.EnumProperty);
			properties.Add(SoalDescriptor.StructuredType.PropertiesProperty);
			properties.Add(SoalDescriptor.Property.ParentProperty);
			properties.Add(SoalDescriptor.Struct.BaseTypeProperty);
			properties.Add(SoalDescriptor.Exception.BaseTypeProperty);
			properties.Add(SoalDescriptor.Entity.BaseTypeProperty);
			properties.Add(SoalDescriptor.Interface.OperationsProperty);
			properties.Add(SoalDescriptor.Database.EntitiesProperty);
			properties.Add(SoalDescriptor.Operation.ParentProperty);
			properties.Add(SoalDescriptor.Operation.IsOnewayProperty);
			properties.Add(SoalDescriptor.Operation.ReturnTypeProperty);
			properties.Add(SoalDescriptor.Operation.ParametersProperty);
			properties.Add(SoalDescriptor.Operation.ExceptionsProperty);
			properties.Add(SoalDescriptor.Parameter.OperationProperty);
			properties.Add(SoalDescriptor.Component.BaseComponentProperty);
			properties.Add(SoalDescriptor.Component.IsAbstractProperty);
			properties.Add(SoalDescriptor.Component.ServicesProperty);
			properties.Add(SoalDescriptor.Component.ReferencesProperty);
			properties.Add(SoalDescriptor.Component.PropertiesProperty);
			properties.Add(SoalDescriptor.Component.ImplementationProperty);
			properties.Add(SoalDescriptor.Component.LanguageProperty);
			properties.Add(SoalDescriptor.Composite.ComponentsProperty);
			properties.Add(SoalDescriptor.Composite.WiresProperty);
			properties.Add(SoalDescriptor.Wire.SourceProperty);
			properties.Add(SoalDescriptor.Wire.TargetProperty);
			properties.Add(SoalDescriptor.InterfaceReference.NameProperty);
			properties.Add(SoalDescriptor.InterfaceReference.OptionalNameProperty);
			properties.Add(SoalDescriptor.InterfaceReference.InterfaceProperty);
			properties.Add(SoalDescriptor.InterfaceReference.BindingProperty);
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
			properties.Add(SoalDescriptor.SoapEncodingBindingElement.VersionProperty);
			properties.Add(SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty);
		}
	
		public static void Initialize()
		{
		}
	
		public const string Uri = "http://MetaDslx.Soal/1.0";
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute]
		public static class NamedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static NamedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(NamedElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.NamedElement; }
			}
			
			[global::MetaDslx.Core.Name]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NamedElement), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Soal.SoalInstance.NamedElement_Name);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute]
		public static class TypedElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TypedElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(TypedElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.TypedElement; }
			}
			
			[global::MetaDslx.Core.Type]
			public static readonly global::MetaDslx.Core.ModelProperty TypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(TypedElement), "Type",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalTypeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.TypedElement_Type);
		}
	
		[global::MetaDslx.Core.Type]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute]
		public static class SoalType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static SoalType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(SoalType));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.SoalType; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Declaration))]
		public static class Namespace
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Namespace()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Namespace));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Namespace; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Declaration), "Namespace")]
			public static readonly global::MetaDslx.Core.ModelProperty DeclarationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Namespace), "Declarations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Declaration), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Declaration>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.DeclarationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.DeclarationBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Namespace_Declarations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Declaration
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Declaration()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Declaration));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Declaration; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Namespace), "Declarations")]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Declaration), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Namespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.NamespaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Declaration_Namespace);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType))]
		public static class ArrayType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ArrayType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(ArrayType));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.ArrayType; }
			}
			
			/**
			 * <summary>
			 * ArrayType()
			 * {
			 * Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
			 * }
			 * </summary>
			 */
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ArrayType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalTypeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.ArrayType_InnerType);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(ArrayType), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Namespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.NamespaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.ArrayType_Namespace);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType))]
		public static class NullableType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static NullableType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(NullableType));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.NullableType; }
			}
			
			/**
			 * <summary>
			 * NullableType()
			 * {
			 * Namespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;
			 * }
			 * </summary>
			 */
			public static readonly global::MetaDslx.Core.ModelProperty InnerTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NullableType), "InnerType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalTypeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.NullableType_InnerType);
			
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NamespaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(NullableType), "Namespace",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Namespace), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.NamespaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.NullableType_Namespace);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.NamedElement))]
		public static class PrimitiveType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static PrimitiveType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(PrimitiveType));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.PrimitiveType; }
			}
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration))]
		public static class Enum
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Enum()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Enum));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Enum; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.EnumLiteral), "Enum")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumLiteralsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Enum), "EnumLiterals",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EnumLiteral), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.EnumLiteral>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EnumLiteralBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.EnumLiteralBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Enum_EnumLiterals);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement))]
		public static class EnumLiteral
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static EnumLiteral()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(EnumLiteral));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.EnumLiteral; }
			}
			
			/**
			 * <summary>
			 * EnumLiteral()
			 * {
			 * Type = Enum;
			 * }
			 * </summary>
			 */
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Enum), "EnumLiterals")]
			public static readonly global::MetaDslx.Core.ModelProperty EnumProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(EnumLiteral), "Enum",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Enum), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EnumBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.EnumLiteral_Enum);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration))]
		public static class StructuredType
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static StructuredType()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(StructuredType));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.StructuredType; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Property), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(StructuredType), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Property), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Property>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.PropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.PropertyBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.StructuredType_Properties);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement))]
		public static class Property
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Property()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Property));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Property; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.StructuredType), "Properties")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Property), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.StructuredType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.StructuredTypeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Property_Parent);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.StructuredType))]
		public static class Struct
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Struct()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Struct));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Struct; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Struct), "BaseType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Struct), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.StructBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Struct_BaseType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.StructuredType))]
		public static class Exception
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Exception()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Exception));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Exception; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Exception), "BaseType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Exception), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ExceptionBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Exception_BaseType);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.StructuredType))]
		public static class Entity
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Entity()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Entity));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Entity; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Entity), "BaseType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Entity), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EntityBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Entity_BaseType);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.SoalType), typeof(SoalDescriptor.Declaration))]
		public static class Interface
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Interface()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Interface));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Interface; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Operation), "Parent")]
			public static readonly global::MetaDslx.Core.ModelProperty OperationsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Interface), "Operations",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Operation), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Operation>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.OperationBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.OperationBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Interface_Operations);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Interface))]
		public static class Database
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Database()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Database));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Database; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			public static readonly global::MetaDslx.Core.ModelProperty EntitiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Database), "Entities",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Entity), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Entity>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EntityBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.EntityBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Database_Entities);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Operation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Operation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Operation));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Operation; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Interface), "Operations")]
			public static readonly global::MetaDslx.Core.ModelProperty ParentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Parent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Interface), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Operation_Parent);
			
			public static readonly global::MetaDslx.Core.ModelProperty IsOnewayProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "IsOneway",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Soal.SoalInstance.Operation_IsOneway);
			
			public static readonly global::MetaDslx.Core.ModelProperty ReturnTypeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "ReturnType",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalType), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoalTypeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Operation_ReturnType);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Parameter), "Operation")]
			public static readonly global::MetaDslx.Core.ModelProperty ParametersProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Parameters",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Parameter), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Parameter>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ParameterBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ParameterBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Operation_Parameters);
			
			public static readonly global::MetaDslx.Core.ModelProperty ExceptionsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Operation), "Exceptions",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Exception), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Exception>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ExceptionBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ExceptionBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Operation_Exceptions);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement), typeof(SoalDescriptor.TypedElement))]
		public static class Parameter
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Parameter()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Parameter));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Parameter; }
			}
			
			[global::MetaDslx.Core.OppositeAttribute(typeof(SoalDescriptor.Operation), "Parameters")]
			public static readonly global::MetaDslx.Core.ModelProperty OperationProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Parameter), "Operation",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Operation), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.OperationBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Parameter_Operation);
		}
	
		[global::MetaDslx.Core.Scope]
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Declaration), typeof(SoalDescriptor.StructuredType))]
		public static class Component
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Component()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Component));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Component; }
			}
			
			[global::MetaDslx.Core.InheritedScope]
			public static readonly global::MetaDslx.Core.ModelProperty BaseComponentProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "BaseComponent",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Component), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ComponentBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Component_BaseComponent);
			
			public static readonly global::MetaDslx.Core.ModelProperty IsAbstractProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "IsAbstract",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Soal.SoalInstance.Component_IsAbstract);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ServicesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Services",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Service), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Service>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ServiceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ServiceBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Component_Services);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ReferencesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "References",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Reference), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Reference>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ReferenceBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ReferenceBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Component_References);
			
			[global::MetaDslx.Core.ScopeEntry]
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty PropertiesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Properties",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Property), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Property>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.PropertyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.PropertyBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Component_Properties);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ImplementationProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Implementation",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Implementation), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ImplementationBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Component_Implementation);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty LanguageProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Component), "Language",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Language), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.LanguageBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Component_Language);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Component))]
		public static class Composite
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Composite()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Composite));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Composite; }
			}
			
			[global::MetaDslx.Core.ScopeEntry]
			public static readonly global::MetaDslx.Core.ModelProperty ComponentsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Composite), "Components",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Component), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Component>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ComponentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ComponentBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Composite_Components);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty WiresProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Composite), "Wires",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Wire), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Wire>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.WireBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.WireBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Composite_Wires);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Composite))]
		public static class Assembly
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Assembly()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Assembly));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Assembly; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute]
		public static class Wire
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Wire()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Wire));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Wire; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty SourceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Wire), "Source",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceReference), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceReferenceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Wire_Source);
			
			public static readonly global::MetaDslx.Core.ModelProperty TargetProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Wire), "Target",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceReference), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceReferenceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Wire_Target);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute]
		public static class InterfaceReference
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static InterfaceReference()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(InterfaceReference));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.InterfaceReference; }
			}
			
			/**
			 * <summary>
			 * InterfaceReference()
			 * {
			 * // this.Name = this.OptionalName != "" ? this.OptionalName : this.Interface.Name;
			 * }
			 * </summary>
			 */
			[global::MetaDslx.Core.Name]
			[global::MetaDslx.Core.ReadonlyAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty NameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(InterfaceReference), "Name",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Soal.SoalInstance.InterfaceReference_Name);
			
			public static readonly global::MetaDslx.Core.ModelProperty OptionalNameProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(InterfaceReference), "OptionalName",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Soal.SoalInstance.InterfaceReference_OptionalName);
			
			public static readonly global::MetaDslx.Core.ModelProperty InterfaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(InterfaceReference), "Interface",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Interface), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.InterfaceReference_Interface);
			
			public static readonly global::MetaDslx.Core.ModelProperty BindingProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(InterfaceReference), "Binding",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Binding), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.BindingBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.InterfaceReference_Binding);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.InterfaceReference))]
		public static class Service
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Service()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Service));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Service; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.InterfaceReference))]
		public static class Reference
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Reference()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Reference));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Reference; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Implementation
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Implementation()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Implementation));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Implementation; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Language
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Language()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Language));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Language; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Declaration))]
		public static class Deployment
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Deployment()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Deployment));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Deployment; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty EnvironmentsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Deployment), "Environments",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Environment), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Environment>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EnvironmentBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.EnvironmentBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Deployment_Environments);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty WiresProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Deployment), "Wires",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Wire), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Wire>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.WireBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.WireBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Deployment_Wires);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Environment
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Environment()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Environment));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Environment; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty RuntimeProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Runtime",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Runtime), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.RuntimeBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Environment_Runtime);
			
			public static readonly global::MetaDslx.Core.ModelProperty DatabasesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Databases",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Database), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Database>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.DatabaseBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.DatabaseBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Environment_Databases);
			
			public static readonly global::MetaDslx.Core.ModelProperty AssembliesProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Environment), "Assemblies",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Assembly), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.Assembly>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.AssemblyBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.AssemblyBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Environment_Assemblies);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class Runtime
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Runtime()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Runtime));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Runtime; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Declaration))]
		public static class Binding
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Binding()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Binding));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Binding; }
			}
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty TransportProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Transport",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.TransportBindingElement), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.TransportBindingElementBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Binding_Transport);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty EncodingsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Encodings",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EncodingBindingElement), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.EncodingBindingElement>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.EncodingBindingElementBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.EncodingBindingElementBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Binding_Encodings);
			
			[global::MetaDslx.Core.ContainmentAttribute]
			public static readonly global::MetaDslx.Core.ModelProperty ProtocolsProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Binding), "Protocols",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ProtocolBindingElement), typeof(global::MetaDslx.Core.ImmutableModelList<global::MetaDslx.Soal.ProtocolBindingElement>)),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.ProtocolBindingElementBuilder), typeof(global::MetaDslx.Core.MutableModelList<global::MetaDslx.Soal.ProtocolBindingElementBuilder>)),
					() => global::MetaDslx.Soal.SoalInstance.Binding_Protocols);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.Declaration))]
		public static class Endpoint
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static Endpoint()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(Endpoint));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.Endpoint; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty InterfaceProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Interface",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Interface), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.InterfaceBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Endpoint_Interface);
			
			public static readonly global::MetaDslx.Core.ModelProperty BindingProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Binding",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.Binding), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.BindingBuilder), null),
					() => global::MetaDslx.Soal.SoalInstance.Endpoint_Binding);
			
			public static readonly global::MetaDslx.Core.ModelProperty AddressProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(Endpoint), "Address",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(string), null),
					() => global::MetaDslx.Soal.SoalInstance.Endpoint_Address);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.NamedElement))]
		public static class BindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static BindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(BindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.BindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.BindingElement))]
		public static class TransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static TransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(TransportBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.TransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.BindingElement))]
		public static class EncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static EncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(EncodingBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.EncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.BindingElement))]
		public static class ProtocolBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static ProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(ProtocolBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.ProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.TransportBindingElement))]
		public static class HttpTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static HttpTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(HttpTransportBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.HttpTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.TransportBindingElement))]
		public static class RestTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static RestTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(RestTransportBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.RestTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.TransportBindingElement))]
		public static class WebSocketTransportBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WebSocketTransportBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(WebSocketTransportBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.WebSocketTransportBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.EncodingBindingElement))]
		public static class SoapEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static SoapEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(SoapEncodingBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement; }
			}
			
			public static readonly global::MetaDslx.Core.ModelProperty VersionProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SoapEncodingBindingElement), "Version",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoapVersion), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(global::MetaDslx.Soal.SoapVersion), null),
					() => global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement_Version);
			
			public static readonly global::MetaDslx.Core.ModelProperty MtomEnabledProperty =
			    global::MetaDslx.Core.ModelProperty.Register(typeof(SoapEncodingBindingElement), "MtomEnabled",
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
			        new global::MetaDslx.Core.ModelPropertyTypeInfo(typeof(bool), null),
					() => global::MetaDslx.Soal.SoalInstance.SoapEncodingBindingElement_MtomEnabled);
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.EncodingBindingElement))]
		public static class XmlEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static XmlEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(XmlEncodingBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.XmlEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.EncodingBindingElement))]
		public static class JsonEncodingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static JsonEncodingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(JsonEncodingBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.JsonEncodingBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.ProtocolBindingElement))]
		public static class WsProtocolBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WsProtocolBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(WsProtocolBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.WsProtocolBindingElement; }
			}
		}
	
		[global::MetaDslx.Core.ModelSymbolDescriptorAttribute(typeof(SoalDescriptor.WsProtocolBindingElement))]
		public static class WsAddressingBindingElement
		{
			private static global::MetaDslx.Core.ModelSymbolInfo modelSymbolInfo;
		
			static WsAddressingBindingElement()
			{
				modelSymbolInfo = global::MetaDslx.Core.ModelSymbolInfo.GetSymbolInfo(typeof(WsAddressingBindingElement));
			}
		
			public static global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo
			{
				get { return modelSymbolInfo; }
			}
		
			public static global::MetaDslx.Core.MetaClass MetaClass
			{
				get { return global::MetaDslx.Soal.SoalInstance.WsAddressingBindingElement; }
			}
		}
	}
}

namespace MetaDslx.Soal.Internal
{
	
	internal class NamedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.NamedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(NamedElement); } }
		public override global::System.Type MutableType { get { return typeof(NamedElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class TypedElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.TypedElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(TypedElement); } }
		public override global::System.Type MutableType { get { return typeof(TypedElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	}
	
	internal class SoalTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.SoalType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(SoalType); } }
		public override global::System.Type MutableType { get { return typeof(SoalTypeBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Namespace.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Namespace); } }
		public override global::System.Type MutableType { get { return typeof(NamespaceBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Declaration> declarations0;
	
		internal NamespaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Declaration> Declarations
		{
		    get { return this.GetList<Declaration>(global::MetaDslx.Soal.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class NamespaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, NamespaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<DeclarationBuilder> declarations0;
	
		internal NamespaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Namespace(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<DeclarationBuilder> Declarations
		{
			get { return this.GetList<DeclarationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Namespace.DeclarationsProperty, ref declarations0); }
		}
	}
	
	internal class DeclarationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Declaration.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Declaration); } }
		public override global::System.Type MutableType { get { return typeof(DeclarationBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
	
		internal DeclarationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	}
	
	internal class DeclarationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DeclarationBuilder
	{
	
		internal DeclarationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Declaration(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	}
	
	internal class ArrayTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.ArrayType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(ArrayType); } }
		public override global::System.Type MutableType { get { return typeof(ArrayTypeBuilder); } }
	
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
	
		internal ArrayTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty, ref innerType0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.NamespaceProperty, ref namespace0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.InnerTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.ArrayType.InnerTypeProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.NamespaceProperty); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.ArrayType.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.ArrayType.NamespaceProperty, value); }
		}
	}
	
	internal class NullableTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.NullableType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(NullableType); } }
		public override global::System.Type MutableType { get { return typeof(NullableTypeBuilder); } }
	
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
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
	
		internal NullableTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty, ref innerType0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.NullableType.NamespaceProperty, ref namespace0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> InnerTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.NullableType.InnerTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.NullableType.InnerTypeProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.NullableType.NamespaceProperty); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.NullableType.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.NullableType.NamespaceProperty, value); }
		}
	}
	
	internal class PrimitiveTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.PrimitiveType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(PrimitiveType); } }
		public override global::System.Type MutableType { get { return typeof(PrimitiveTypeBuilder); } }
	
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
		private string name0;
	
		internal PrimitiveTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		NamedElementBuilder NamedElement.ToMutable()
		{
			return this.ToMutable();
		}
	
		NamedElementBuilder NamedElement.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	}
	
	internal class PrimitiveTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PrimitiveTypeBuilder
	{
	
		internal PrimitiveTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.PrimitiveType(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		NamedElement NamedElementBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		NamedElement NamedElementBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class EnumId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Enum.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Enum); } }
		public override global::System.Type MutableType { get { return typeof(EnumBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<EnumLiteral> enumLiterals0;
	
		internal EnumImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<EnumLiteral> EnumLiterals
		{
		    get { return this.GetList<EnumLiteral>(global::MetaDslx.Soal.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	}
	
	internal class EnumBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EnumBuilder
	{
		private global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> enumLiterals0;
	
		internal EnumBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Enum(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<EnumLiteralBuilder> EnumLiterals
		{
			get { return this.GetList<EnumLiteralBuilder>(global::MetaDslx.Soal.SoalDescriptor.Enum.EnumLiteralsProperty, ref enumLiterals0); }
		}
	}
	
	internal class EnumLiteralId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(EnumLiteral); } }
		public override global::System.Type MutableType { get { return typeof(EnumLiteralBuilder); } }
	
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
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Enum enum0;
	
		internal EnumLiteralImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Enum Enum
		{
		    get { return this.GetReference<Enum>(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty, ref enum0); }
		}
	}
	
	internal class EnumLiteralBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EnumLiteralBuilder
	{
	
		internal EnumLiteralBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.EnumLiteral(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public EnumBuilder Enum
		{
			get { return this.GetReference<EnumBuilder>(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty); }
			set { this.SetReference<EnumBuilder>(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty, value); }
		}
		
		public Func<EnumBuilder> EnumLazy
		{
			get { return this.GetLazyReference<EnumBuilder>(global::MetaDslx.Soal.SoalDescriptor.EnumLiteral.EnumProperty); }
			set { this.SetLazyReference(SoalDescriptor.EnumLiteral.EnumProperty, value); }
		}
	}
	
	internal class StructuredTypeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.StructuredType.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(StructuredType); } }
		public override global::System.Type MutableType { get { return typeof(StructuredTypeBuilder); } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new StructuredTypeImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new StructuredTypeBuilderImpl(this, model, creating);
		}
	}
	
	internal class StructuredTypeImpl : global::MetaDslx.Core.ImmutableSymbolBase, StructuredType
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
	
		internal StructuredTypeImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.StructuredType; }
		}
	
		public new StructuredTypeBuilder ToMutable()
		{
			return (StructuredTypeBuilder)base.ToMutable();
		}
	
		public new StructuredTypeBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (StructuredTypeBuilder)base.ToMutable(model);
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class StructuredTypeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, StructuredTypeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal StructuredTypeBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.StructuredType(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.StructuredType; }
		}
	
		public new StructuredType ToImmutable()
		{
			return (StructuredType)base.ToImmutable();
		}
	
		public new StructuredType ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (StructuredType)base.ToImmutable(model);
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	}
	
	internal class PropertyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Property.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Property); } }
		public override global::System.Type MutableType { get { return typeof(PropertyBuilder); } }
	
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
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private StructuredType parent0;
	
		internal PropertyImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public StructuredType Parent
		{
		    get { return this.GetReference<StructuredType>(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty, ref parent0); }
		}
	}
	
	internal class PropertyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, PropertyBuilder
	{
	
		internal PropertyBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Property(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public StructuredTypeBuilder Parent
		{
			get { return this.GetReference<StructuredTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty); }
			set { this.SetReference<StructuredTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty, value); }
		}
		
		public Func<StructuredTypeBuilder> ParentLazy
		{
			get { return this.GetLazyReference<StructuredTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Property.ParentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Property.ParentProperty, value); }
		}
	}
	
	internal class StructId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Struct.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Struct); } }
		public override global::System.Type MutableType { get { return typeof(StructBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Struct baseType0;
	
		internal StructImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Struct BaseType
		{
		    get { return this.GetReference<Struct>(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty, ref baseType0); }
		}
	}
	
	internal class StructBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, StructBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal StructBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Struct(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public StructBuilder BaseType
		{
			get { return this.GetReference<StructBuilder>(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty); }
			set { this.SetReference<StructBuilder>(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty, value); }
		}
		
		public Func<StructBuilder> BaseTypeLazy
		{
			get { return this.GetLazyReference<StructBuilder>(global::MetaDslx.Soal.SoalDescriptor.Struct.BaseTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Struct.BaseTypeProperty, value); }
		}
	}
	
	internal class ExceptionId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Exception.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Exception); } }
		public override global::System.Type MutableType { get { return typeof(ExceptionBuilder); } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ExceptionImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ExceptionBuilderImpl(this, model, creating);
		}
	}
	
	internal class ExceptionImpl : global::MetaDslx.Core.ImmutableSymbolBase, Exception
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exception baseType0;
	
		internal ExceptionImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Exception; }
		}
	
		public new ExceptionBuilder ToMutable()
		{
			return (ExceptionBuilder)base.ToMutable();
		}
	
		public new ExceptionBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ExceptionBuilder)base.ToMutable(model);
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Exception BaseType
		{
		    get { return this.GetReference<Exception>(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty, ref baseType0); }
		}
	}
	
	internal class ExceptionBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ExceptionBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal ExceptionBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Exception(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Exception; }
		}
	
		public new Exception ToImmutable()
		{
			return (Exception)base.ToImmutable();
		}
	
		public new Exception ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Exception)base.ToImmutable(model);
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public ExceptionBuilder BaseType
		{
			get { return this.GetReference<ExceptionBuilder>(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty); }
			set { this.SetReference<ExceptionBuilder>(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty, value); }
		}
		
		public Func<ExceptionBuilder> BaseTypeLazy
		{
			get { return this.GetLazyReference<ExceptionBuilder>(global::MetaDslx.Soal.SoalDescriptor.Exception.BaseTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Exception.BaseTypeProperty, value); }
		}
	}
	
	internal class EntityId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Entity.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Entity); } }
		public override global::System.Type MutableType { get { return typeof(EntityBuilder); } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new EntityImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new EntityBuilderImpl(this, model, creating);
		}
	}
	
	internal class EntityImpl : global::MetaDslx.Core.ImmutableSymbolBase, Entity
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Entity baseType0;
	
		internal EntityImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Entity; }
		}
	
		public new EntityBuilder ToMutable()
		{
			return (EntityBuilder)base.ToMutable();
		}
	
		public new EntityBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (EntityBuilder)base.ToMutable(model);
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Entity BaseType
		{
		    get { return this.GetReference<Entity>(global::MetaDslx.Soal.SoalDescriptor.Entity.BaseTypeProperty, ref baseType0); }
		}
	}
	
	internal class EntityBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EntityBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
	
		internal EntityBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Entity(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Entity; }
		}
	
		public new Entity ToImmutable()
		{
			return (Entity)base.ToImmutable();
		}
	
		public new Entity ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Entity)base.ToImmutable(model);
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public EntityBuilder BaseType
		{
			get { return this.GetReference<EntityBuilder>(global::MetaDslx.Soal.SoalDescriptor.Entity.BaseTypeProperty); }
			set { this.SetReference<EntityBuilder>(global::MetaDslx.Soal.SoalDescriptor.Entity.BaseTypeProperty, value); }
		}
		
		public Func<EntityBuilder> BaseTypeLazy
		{
			get { return this.GetLazyReference<EntityBuilder>(global::MetaDslx.Soal.SoalDescriptor.Entity.BaseTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Entity.BaseTypeProperty, value); }
		}
	}
	
	internal class InterfaceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Interface.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Interface); } }
		public override global::System.Type MutableType { get { return typeof(InterfaceBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Operation> operations0;
	
		internal InterfaceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	}
	
	internal class InterfaceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, InterfaceBuilder
	{
		private global::MetaDslx.Core.MutableModelList<OperationBuilder> operations0;
	
		internal InterfaceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Interface(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	}
	
	internal class DatabaseId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Database.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Database); } }
		public override global::System.Type MutableType { get { return typeof(DatabaseBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Operation> operations0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Entity> entities0;
	
		internal DatabaseImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Operation> Operations
		{
		    get { return this.GetList<Operation>(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Entity> Entities
		{
		    get { return this.GetList<Entity>(global::MetaDslx.Soal.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	}
	
	internal class DatabaseBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DatabaseBuilder
	{
		private global::MetaDslx.Core.MutableModelList<OperationBuilder> operations0;
		private global::MetaDslx.Core.MutableModelList<EntityBuilder> entities0;
	
		internal DatabaseBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Database(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<OperationBuilder> Operations
		{
			get { return this.GetList<OperationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Interface.OperationsProperty, ref operations0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<EntityBuilder> Entities
		{
			get { return this.GetList<EntityBuilder>(global::MetaDslx.Soal.SoalDescriptor.Database.EntitiesProperty, ref entities0); }
		}
	}
	
	internal class OperationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Operation.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Operation); } }
		public override global::System.Type MutableType { get { return typeof(OperationBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface parent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isOneway0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType returnType0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Parameter> parameters0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Exception> exceptions0;
	
		internal OperationImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Interface Parent
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty, ref parent0); }
		}
	
		
		public bool IsOneway
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty, ref isOneway0); }
		}
	
		
		public SoalType ReturnType
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty, ref returnType0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Parameter> Parameters
		{
		    get { return this.GetList<Parameter>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Exception> Exceptions
		{
		    get { return this.GetList<Exception>(global::MetaDslx.Soal.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	}
	
	internal class OperationBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, OperationBuilder
	{
		private global::MetaDslx.Core.MutableModelList<ParameterBuilder> parameters0;
		private global::MetaDslx.Core.MutableModelList<ExceptionBuilder> exceptions0;
	
		internal OperationBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Operation(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public InterfaceBuilder Parent
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty, value); }
		}
		
		public Func<InterfaceBuilder> ParentLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Operation.ParentProperty, value); }
		}
	
		
		public bool IsOneway
		{
			get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty, value); }
		}
		
		public Func<bool> IsOnewayLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Operation.IsOnewayProperty); }
			set { this.SetLazyValue(SoalDescriptor.Operation.IsOnewayProperty, value); }
		}
	
		
		public SoalTypeBuilder ReturnType
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> ReturnTypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ReturnTypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Operation.ReturnTypeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ParameterBuilder> Parameters
		{
			get { return this.GetList<ParameterBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ParametersProperty, ref parameters0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ExceptionBuilder> Exceptions
		{
			get { return this.GetList<ExceptionBuilder>(global::MetaDslx.Soal.SoalDescriptor.Operation.ExceptionsProperty, ref exceptions0); }
		}
	}
	
	internal class ParameterId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Parameter.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Parameter); } }
		public override global::System.Type MutableType { get { return typeof(ParameterBuilder); } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new ParameterImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new ParameterBuilderImpl(this, model, creating);
		}
	}
	
	internal class ParameterImpl : global::MetaDslx.Core.ImmutableSymbolBase, Parameter
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SoalType type0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Operation operation0;
	
		internal ParameterImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Parameter; }
		}
	
		public new ParameterBuilder ToMutable()
		{
			return (ParameterBuilder)base.ToMutable();
		}
	
		public new ParameterBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (ParameterBuilder)base.ToMutable(model);
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
	
		
		public SoalType Type
		{
		    get { return this.GetReference<SoalType>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, ref type0); }
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Operation Operation
		{
		    get { return this.GetReference<Operation>(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty, ref operation0); }
		}
	}
	
	internal class ParameterBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ParameterBuilder
	{
	
		internal ParameterBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Parameter(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.Parameter; }
		}
	
		public new Parameter ToImmutable()
		{
			return (Parameter)base.ToImmutable();
		}
	
		public new Parameter ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (Parameter)base.ToImmutable(model);
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
	
		
		public SoalTypeBuilder Type
		{
			get { return this.GetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty, value); }
		}
		
		public Func<SoalTypeBuilder> TypeLazy
		{
			get { return this.GetLazyReference<SoalTypeBuilder>(global::MetaDslx.Soal.SoalDescriptor.TypedElement.TypeProperty); }
			set { this.SetLazyReference(SoalDescriptor.TypedElement.TypeProperty, value); }
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public OperationBuilder Operation
		{
			get { return this.GetReference<OperationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty); }
			set { this.SetReference<OperationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty, value); }
		}
		
		public Func<OperationBuilder> OperationLazy
		{
			get { return this.GetLazyReference<OperationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Parameter.OperationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Parameter.OperationProperty, value); }
		}
	}
	
	internal class ComponentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Component.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Component); } }
		public override global::System.Type MutableType { get { return typeof(ComponentBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties1;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Implementation implementation0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Language language0;
	
		internal ComponentImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.ImmutableModelList<Property> StructuredType.Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	}
	
	internal class ComponentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, ComponentBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties1;
	
		internal ComponentBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Component(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> StructuredTypeBuilder.Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	}
	
	internal class CompositeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Composite.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Composite); } }
		public override global::System.Type MutableType { get { return typeof(CompositeBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties1;
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.ImmutableModelList<Property> StructuredType.Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Soal.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Soal.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class CompositeBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, CompositeBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties1;
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> StructuredTypeBuilder.Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Soal.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class AssemblyId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Assembly.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Assembly); } }
		public override global::System.Type MutableType { get { return typeof(AssemblyBuilder); } }
	
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
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Namespace namespace0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Component baseComponent0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool isAbstract0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Service> services0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Reference> references0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private global::MetaDslx.Core.ImmutableModelList<Property> properties1;
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalTypeBuilder SoalType.ToMutable()
		{
			return this.ToMutable();
		}
	
		SoalTypeBuilder SoalType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		StructuredTypeBuilder StructuredType.ToMutable()
		{
			return this.ToMutable();
		}
	
		StructuredTypeBuilder StructuredType.ToMutable(global::MetaDslx.Core.MutableModel model)
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.ImmutableModelList<Property> StructuredType.Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public Component BaseComponent
		{
		    get { return this.GetReference<Component>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, ref baseComponent0); }
		}
	
		
		public bool IsAbstract
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, ref isAbstract0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Service> Services
		{
		    get { return this.GetList<Service>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Reference> References
		{
		    get { return this.GetList<Reference>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Property> Properties
		{
		    get { return this.GetList<Property>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public Implementation Implementation
		{
		    get { return this.GetReference<Implementation>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, ref implementation0); }
		}
	
		
		public Language Language
		{
		    get { return this.GetReference<Language>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, ref language0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Component> Components
		{
		    get { return this.GetList<Component>(global::MetaDslx.Soal.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Soal.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class AssemblyBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, AssemblyBuilder
	{
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties0;
		private global::MetaDslx.Core.MutableModelList<ServiceBuilder> services0;
		private global::MetaDslx.Core.MutableModelList<ReferenceBuilder> references0;
		private global::MetaDslx.Core.MutableModelList<PropertyBuilder> properties1;
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		SoalType SoalTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		SoalType SoalTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		StructuredType StructuredTypeBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		StructuredType StructuredTypeBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		global::MetaDslx.Core.MutableModelList<PropertyBuilder> StructuredTypeBuilder.Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.StructuredType.PropertiesProperty, ref properties0); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public ComponentBuilder BaseComponent
		{
			get { return this.GetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty, value); }
		}
		
		public Func<ComponentBuilder> BaseComponentLazy
		{
			get { return this.GetLazyReference<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.BaseComponentProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.BaseComponentProperty, value); }
		}
	
		
		public bool IsAbstract
		{
			get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty, value); }
		}
		
		public Func<bool> IsAbstractLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Soal.SoalDescriptor.Component.IsAbstractProperty); }
			set { this.SetLazyValue(SoalDescriptor.Component.IsAbstractProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ServiceBuilder> Services
		{
			get { return this.GetList<ServiceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ServicesProperty, ref services0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ReferenceBuilder> References
		{
			get { return this.GetList<ReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ReferencesProperty, ref references0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<PropertyBuilder> Properties
		{
			get { return this.GetList<PropertyBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.PropertiesProperty, ref properties1); }
		}
	
		
		public ImplementationBuilder Implementation
		{
			get { return this.GetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty, value); }
		}
		
		public Func<ImplementationBuilder> ImplementationLazy
		{
			get { return this.GetLazyReference<ImplementationBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.ImplementationProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.ImplementationProperty, value); }
		}
	
		
		public LanguageBuilder Language
		{
			get { return this.GetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty, value); }
		}
		
		public Func<LanguageBuilder> LanguageLazy
		{
			get { return this.GetLazyReference<LanguageBuilder>(global::MetaDslx.Soal.SoalDescriptor.Component.LanguageProperty); }
			set { this.SetLazyReference(SoalDescriptor.Component.LanguageProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ComponentBuilder> Components
		{
			get { return this.GetList<ComponentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Composite.ComponentsProperty, ref components0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Soal.SoalDescriptor.Composite.WiresProperty, ref wires0); }
		}
	}
	
	internal class WireId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Wire.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Wire); } }
		public override global::System.Type MutableType { get { return typeof(WireBuilder); } }
	
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
		private InterfaceReference source0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private InterfaceReference target0;
	
		internal WireImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public InterfaceReference Source
		{
		    get { return this.GetReference<InterfaceReference>(global::MetaDslx.Soal.SoalDescriptor.Wire.SourceProperty, ref source0); }
		}
	
		
		public InterfaceReference Target
		{
		    get { return this.GetReference<InterfaceReference>(global::MetaDslx.Soal.SoalDescriptor.Wire.TargetProperty, ref target0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public InterfaceReferenceBuilder Source
		{
			get { return this.GetReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.SourceProperty); }
			set { this.SetReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.SourceProperty, value); }
		}
		
		public Func<InterfaceReferenceBuilder> SourceLazy
		{
			get { return this.GetLazyReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.SourceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Wire.SourceProperty, value); }
		}
	
		
		public InterfaceReferenceBuilder Target
		{
			get { return this.GetReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.TargetProperty); }
			set { this.SetReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.TargetProperty, value); }
		}
		
		public Func<InterfaceReferenceBuilder> TargetLazy
		{
			get { return this.GetLazyReference<InterfaceReferenceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Wire.TargetProperty); }
			set { this.SetLazyReference(SoalDescriptor.Wire.TargetProperty, value); }
		}
	}
	
	internal class InterfaceReferenceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(InterfaceReference); } }
		public override global::System.Type MutableType { get { return typeof(InterfaceReferenceBuilder); } }
	
		public override global::MetaDslx.Core.ImmutableSymbolBase CreateImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return new InterfaceReferenceImpl(this, model);
		}
	
		public override global::MetaDslx.Core.MutableSymbolBase CreateMutable(global::MetaDslx.Core.MutableModel model, bool creating)
		{
			return new InterfaceReferenceBuilderImpl(this, model, creating);
		}
	}
	
	internal class InterfaceReferenceImpl : global::MetaDslx.Core.ImmutableSymbolBase, InterfaceReference
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string name0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string optionalName0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Interface interface0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Binding binding0;
	
		internal InterfaceReferenceImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.InterfaceReference; }
		}
	
		public new InterfaceReferenceBuilder ToMutable()
		{
			return (InterfaceReferenceBuilder)base.ToMutable();
		}
	
		public new InterfaceReferenceBuilder ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return (InterfaceReferenceBuilder)base.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, ref binding0); }
		}
	}
	
	internal class InterfaceReferenceBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, InterfaceReferenceBuilder
	{
	
		internal InterfaceReferenceBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.InterfaceReference(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
		{
			get { return SoalInstance.InterfaceReference; }
		}
	
		public new InterfaceReference ToImmutable()
		{
			return (InterfaceReference)base.ToImmutable();
		}
	
		public new InterfaceReference ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return (InterfaceReference)base.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
	}
	
	internal class ServiceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Service.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Service); } }
		public override global::System.Type MutableType { get { return typeof(ServiceBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		InterfaceReferenceBuilder InterfaceReference.ToMutable()
		{
			return this.ToMutable();
		}
	
		InterfaceReferenceBuilder InterfaceReference.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, ref binding0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		InterfaceReference InterfaceReferenceBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		InterfaceReference InterfaceReferenceBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
	}
	
	internal class ReferenceId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Reference.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Reference); } }
		public override global::System.Type MutableType { get { return typeof(ReferenceBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		InterfaceReferenceBuilder InterfaceReference.ToMutable()
		{
			return this.ToMutable();
		}
	
		InterfaceReferenceBuilder InterfaceReference.ToMutable(global::MetaDslx.Core.MutableModel model)
		{
			return this.ToMutable(model);
		}
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty, ref name0); }
		}
	
		
		public string OptionalName
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, ref optionalName0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, ref binding0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		InterfaceReference InterfaceReferenceBuilder.ToImmutable()
		{
			return this.ToImmutable();
		}
	
		InterfaceReference InterfaceReferenceBuilder.ToImmutable(global::MetaDslx.Core.ImmutableModel model)
		{
			return this.ToImmutable(model);
		}
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.NameProperty, value); }
		}
	
		
		public string OptionalName
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
		
		public Func<string> OptionalNameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.OptionalNameProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.OptionalNameProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.InterfaceReference.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.InterfaceReference.BindingProperty, value); }
		}
	}
	
	internal class ImplementationId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Implementation.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Implementation); } }
		public override global::System.Type MutableType { get { return typeof(ImplementationBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class LanguageId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Language.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Language); } }
		public override global::System.Type MutableType { get { return typeof(LanguageBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class DeploymentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Deployment.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Deployment); } }
		public override global::System.Type MutableType { get { return typeof(DeploymentBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Environment> Environments
		{
		    get { return this.GetList<Environment>(global::MetaDslx.Soal.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Wire> Wires
		{
		    get { return this.GetList<Wire>(global::MetaDslx.Soal.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	}
	
	internal class DeploymentBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, DeploymentBuilder
	{
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<EnvironmentBuilder> Environments
		{
			get { return this.GetList<EnvironmentBuilder>(global::MetaDslx.Soal.SoalDescriptor.Deployment.EnvironmentsProperty, ref environments0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<WireBuilder> Wires
		{
			get { return this.GetList<WireBuilder>(global::MetaDslx.Soal.SoalDescriptor.Deployment.WiresProperty, ref wires0); }
		}
	}
	
	internal class EnvironmentId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Environment.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Environment); } }
		public override global::System.Type MutableType { get { return typeof(EnvironmentBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Runtime Runtime
		{
		    get { return this.GetReference<Runtime>(global::MetaDslx.Soal.SoalDescriptor.Environment.RuntimeProperty, ref runtime0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Database> Databases
		{
		    get { return this.GetList<Database>(global::MetaDslx.Soal.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<Assembly> Assemblies
		{
		    get { return this.GetList<Assembly>(global::MetaDslx.Soal.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public RuntimeBuilder Runtime
		{
			get { return this.GetReference<RuntimeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Environment.RuntimeProperty); }
			set { this.SetReference<RuntimeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Environment.RuntimeProperty, value); }
		}
		
		public Func<RuntimeBuilder> RuntimeLazy
		{
			get { return this.GetLazyReference<RuntimeBuilder>(global::MetaDslx.Soal.SoalDescriptor.Environment.RuntimeProperty); }
			set { this.SetLazyReference(SoalDescriptor.Environment.RuntimeProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<DatabaseBuilder> Databases
		{
			get { return this.GetList<DatabaseBuilder>(global::MetaDslx.Soal.SoalDescriptor.Environment.DatabasesProperty, ref databases0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<AssemblyBuilder> Assemblies
		{
			get { return this.GetList<AssemblyBuilder>(global::MetaDslx.Soal.SoalDescriptor.Environment.AssembliesProperty, ref assemblies0); }
		}
	}
	
	internal class RuntimeId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Runtime.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Runtime); } }
		public override global::System.Type MutableType { get { return typeof(RuntimeBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class BindingId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Binding.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Binding); } }
		public override global::System.Type MutableType { get { return typeof(BindingBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public TransportBindingElement Transport
		{
		    get { return this.GetReference<TransportBindingElement>(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty, ref transport0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<EncodingBindingElement> Encodings
		{
		    get { return this.GetList<EncodingBindingElement>(global::MetaDslx.Soal.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Core.ImmutableModelList<ProtocolBindingElement> Protocols
		{
		    get { return this.GetList<ProtocolBindingElement>(global::MetaDslx.Soal.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	}
	
	internal class BindingBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, BindingBuilder
	{
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public TransportBindingElementBuilder Transport
		{
			get { return this.GetReference<TransportBindingElementBuilder>(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty); }
			set { this.SetReference<TransportBindingElementBuilder>(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty, value); }
		}
		
		public Func<TransportBindingElementBuilder> TransportLazy
		{
			get { return this.GetLazyReference<TransportBindingElementBuilder>(global::MetaDslx.Soal.SoalDescriptor.Binding.TransportProperty); }
			set { this.SetLazyReference(SoalDescriptor.Binding.TransportProperty, value); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<EncodingBindingElementBuilder> Encodings
		{
			get { return this.GetList<EncodingBindingElementBuilder>(global::MetaDslx.Soal.SoalDescriptor.Binding.EncodingsProperty, ref encodings0); }
		}
	
		
		public global::MetaDslx.Core.MutableModelList<ProtocolBindingElementBuilder> Protocols
		{
			get { return this.GetList<ProtocolBindingElementBuilder>(global::MetaDslx.Soal.SoalDescriptor.Binding.ProtocolsProperty, ref protocols0); }
		}
	}
	
	internal class EndpointId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.Endpoint.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(Endpoint); } }
		public override global::System.Type MutableType { get { return typeof(EndpointBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public Namespace Namespace
		{
		    get { return this.GetReference<Namespace>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, ref namespace0); }
		}
	
		
		public Interface Interface
		{
		    get { return this.GetReference<Interface>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty, ref interface0); }
		}
	
		
		public Binding Binding
		{
		    get { return this.GetReference<Binding>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty, ref binding0); }
		}
	
		
		public string Address
		{
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty, ref address0); }
		}
	}
	
	internal class EndpointBuilderImpl : global::MetaDslx.Core.MutableSymbolBase, EndpointBuilder
	{
	
		internal EndpointBuilderImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.MutableModel model, bool creating)
			: base(id, model, creating)
		{
		}
	
		protected override void MInit()
		{
			SoalImplementationProvider.Implementation.Endpoint(this);
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
	
		
		public string Name
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public NamespaceBuilder Namespace
		{
			get { return this.GetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
		
		public Func<NamespaceBuilder> NamespaceLazy
		{
			get { return this.GetLazyReference<NamespaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Declaration.NamespaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Declaration.NamespaceProperty, value); }
		}
	
		
		public InterfaceBuilder Interface
		{
			get { return this.GetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty); }
			set { this.SetReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty, value); }
		}
		
		public Func<InterfaceBuilder> InterfaceLazy
		{
			get { return this.GetLazyReference<InterfaceBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.InterfaceProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.InterfaceProperty, value); }
		}
	
		
		public BindingBuilder Binding
		{
			get { return this.GetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty); }
			set { this.SetReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty, value); }
		}
		
		public Func<BindingBuilder> BindingLazy
		{
			get { return this.GetLazyReference<BindingBuilder>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.BindingProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.BindingProperty, value); }
		}
	
		
		public string Address
		{
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty, value); }
		}
		
		public Func<string> AddressLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.Endpoint.AddressProperty); }
			set { this.SetLazyReference(SoalDescriptor.Endpoint.AddressProperty, value); }
		}
	}
	
	internal class BindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.BindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(BindingElement); } }
		public override global::System.Type MutableType { get { return typeof(BindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class TransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.TransportBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(TransportBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(TransportBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class EncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.EncodingBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(EncodingBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(EncodingBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class ProtocolBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.ProtocolBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(ProtocolBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(ProtocolBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class HttpTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.HttpTransportBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(HttpTransportBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(HttpTransportBindingElementBuilder); } }
	
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
	
		internal HttpTransportBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class RestTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.RestTransportBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(RestTransportBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(RestTransportBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WebSocketTransportBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.WebSocketTransportBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(WebSocketTransportBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(WebSocketTransportBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class SoapEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(SoapEncodingBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(SoapEncodingBindingElementBuilder); } }
	
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
		private SoapVersion version0;
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool mtomEnabled0;
	
		internal SoapEncodingBindingElementImpl(global::MetaDslx.Core.SymbolId id, global::MetaDslx.Core.ImmutableModel model)
			: base(id, model)
		{
		}
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
		}
	
		
		public SoapVersion Version
		{
		    get { return this.GetValue<SoapVersion>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty, ref version0); }
		}
	
		
		public bool MtomEnabled
		{
		    get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty, ref mtomEnabled0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	
		
		public SoapVersion Version
		{
			get { return this.GetValue<SoapVersion>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty); }
			set { this.SetValue<SoapVersion>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty, value); }
		}
		
		public Func<SoapVersion> VersionLazy
		{
			get { return this.GetLazyValue<SoapVersion>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.VersionProperty); }
			set { this.SetLazyValue(SoalDescriptor.SoapEncodingBindingElement.VersionProperty, value); }
		}
	
		
		public bool MtomEnabled
		{
			get { return this.GetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty); }
			set { this.SetValue<bool>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty, value); }
		}
		
		public Func<bool> MtomEnabledLazy
		{
			get { return this.GetLazyValue<bool>(global::MetaDslx.Soal.SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty); }
			set { this.SetLazyValue(SoalDescriptor.SoapEncodingBindingElement.MtomEnabledProperty, value); }
		}
	}
	
	internal class XmlEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.XmlEncodingBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(XmlEncodingBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(XmlEncodingBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class JsonEncodingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.JsonEncodingBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(JsonEncodingBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(JsonEncodingBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WsProtocolBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.WsProtocolBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(WsProtocolBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(WsProtocolBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}
	
	internal class WsAddressingBindingElementId : global::MetaDslx.Core.SymbolId
	{
		public override global::MetaDslx.Core.ModelSymbolInfo ModelSymbolInfo { get { return global::MetaDslx.Soal.SoalDescriptor.WsAddressingBindingElement.ModelSymbolInfo; } }
		public override global::System.Type ImmutableType { get { return typeof(WsAddressingBindingElement); } }
		public override global::System.Type MutableType { get { return typeof(WsAddressingBindingElementBuilder); } }
	
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
		    get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, ref name0); }
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
	
		public override global::MetaDslx.Core.MetaModel MMetaModel
		{
			get { return global::MetaDslx.Soal.SoalInstance.MetaModel; }
		}
	
		public override global::MetaDslx.Core.MetaClass MMetaClass
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
			get { return this.GetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty, value); }
		}
		
		public Func<string> NameLazy
		{
			get { return this.GetLazyReference<string>(global::MetaDslx.Soal.SoalDescriptor.NamedElement.NameProperty); }
			set { this.SetLazyReference(SoalDescriptor.NamedElement.NameProperty, value); }
		}
	}

	internal class SoalBuilderInstance
	{
		internal static SoalBuilderInstance instance = new SoalBuilderInstance();
	
		private bool creating;
		private bool created;
		internal global::MetaDslx.Core.MetaModelBuilder MetaModel;
		internal global::MetaDslx.Core.MutableModel Model;
	
		internal PrimitiveTypeBuilder Object = null;
		internal PrimitiveTypeBuilder String = null;
		internal PrimitiveTypeBuilder Int = null;
		internal PrimitiveTypeBuilder Long = null;
		internal PrimitiveTypeBuilder Float = null;
		internal PrimitiveTypeBuilder Double = null;
		internal PrimitiveTypeBuilder Byte = null;
		internal PrimitiveTypeBuilder Bool = null;
		internal PrimitiveTypeBuilder Void = null;
		internal PrimitiveTypeBuilder DateTime = null;
		internal PrimitiveTypeBuilder TimeSpan = null;
	
		private global::MetaDslx.Core.MetaNamespaceBuilder __tmp1;
		private global::MetaDslx.Core.MetaNamespaceBuilder __tmp2;
		private global::MetaDslx.Core.MetaModelBuilder __tmp3;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp4;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp5;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp6;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp7;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp8;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp9;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp10;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp11;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp12;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp13;
		private global::MetaDslx.Core.MetaConstantBuilder __tmp14;
		internal global::MetaDslx.Core.MetaClassBuilder NamedElement;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp15;
		internal global::MetaDslx.Core.MetaPropertyBuilder NamedElement_Name;
		internal global::MetaDslx.Core.MetaClassBuilder TypedElement;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp16;
		internal global::MetaDslx.Core.MetaPropertyBuilder TypedElement_Type;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp17;
		internal global::MetaDslx.Core.MetaClassBuilder SoalType;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp18;
		internal global::MetaDslx.Core.MetaClassBuilder Namespace;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp19;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp20;
		internal global::MetaDslx.Core.MetaPropertyBuilder Namespace_Declarations;
		internal global::MetaDslx.Core.MetaClassBuilder Declaration;
		internal global::MetaDslx.Core.MetaPropertyBuilder Declaration_Namespace;
		internal global::MetaDslx.Core.MetaClassBuilder ArrayType;
		internal global::MetaDslx.Core.MetaPropertyBuilder ArrayType_InnerType;
		internal global::MetaDslx.Core.MetaPropertyBuilder ArrayType_Namespace;
		internal global::MetaDslx.Core.MetaClassBuilder NullableType;
		internal global::MetaDslx.Core.MetaPropertyBuilder NullableType_InnerType;
		internal global::MetaDslx.Core.MetaPropertyBuilder NullableType_Namespace;
		internal global::MetaDslx.Core.MetaClassBuilder PrimitiveType;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp21;
		internal global::MetaDslx.Core.MetaClassBuilder Enum;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp22;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp23;
		internal global::MetaDslx.Core.MetaPropertyBuilder Enum_EnumLiterals;
		internal global::MetaDslx.Core.MetaClassBuilder EnumLiteral;
		internal global::MetaDslx.Core.MetaPropertyBuilder EnumLiteral_Enum;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp24;
		internal global::MetaDslx.Core.MetaClassBuilder StructuredType;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp25;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp26;
		internal global::MetaDslx.Core.MetaPropertyBuilder StructuredType_Properties;
		internal global::MetaDslx.Core.MetaClassBuilder Property;
		internal global::MetaDslx.Core.MetaPropertyBuilder Property_Parent;
		internal global::MetaDslx.Core.MetaClassBuilder Struct;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp27;
		internal global::MetaDslx.Core.MetaPropertyBuilder Struct_BaseType;
		internal global::MetaDslx.Core.MetaClassBuilder Exception;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp28;
		internal global::MetaDslx.Core.MetaPropertyBuilder Exception_BaseType;
		internal global::MetaDslx.Core.MetaClassBuilder Entity;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp29;
		internal global::MetaDslx.Core.MetaPropertyBuilder Entity_BaseType;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp30;
		internal global::MetaDslx.Core.MetaClassBuilder Interface;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp31;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp32;
		internal global::MetaDslx.Core.MetaPropertyBuilder Interface_Operations;
		internal global::MetaDslx.Core.MetaClassBuilder Database;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp33;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp34;
		internal global::MetaDslx.Core.MetaPropertyBuilder Database_Entities;
		internal global::MetaDslx.Core.MetaClassBuilder Operation;
		internal global::MetaDslx.Core.MetaPropertyBuilder Operation_Parent;
		internal global::MetaDslx.Core.MetaPropertyBuilder Operation_IsOneway;
		internal global::MetaDslx.Core.MetaPropertyBuilder Operation_ReturnType;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp35;
		internal global::MetaDslx.Core.MetaPropertyBuilder Operation_Parameters;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp36;
		internal global::MetaDslx.Core.MetaPropertyBuilder Operation_Exceptions;
		internal global::MetaDslx.Core.MetaClassBuilder Parameter;
		internal global::MetaDslx.Core.MetaPropertyBuilder Parameter_Operation;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp37;
		internal global::MetaDslx.Core.MetaClassBuilder Component;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp38;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_BaseComponent;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_IsAbstract;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp39;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp40;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_Services;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp41;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp42;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_References;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp43;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp44;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_Properties;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_Implementation;
		internal global::MetaDslx.Core.MetaPropertyBuilder Component_Language;
		internal global::MetaDslx.Core.MetaClassBuilder Composite;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp45;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp46;
		internal global::MetaDslx.Core.MetaPropertyBuilder Composite_Components;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp47;
		internal global::MetaDslx.Core.MetaPropertyBuilder Composite_Wires;
		internal global::MetaDslx.Core.MetaClassBuilder Assembly;
		internal global::MetaDslx.Core.MetaClassBuilder Wire;
		internal global::MetaDslx.Core.MetaPropertyBuilder Wire_Source;
		internal global::MetaDslx.Core.MetaPropertyBuilder Wire_Target;
		internal global::MetaDslx.Core.MetaClassBuilder InterfaceReference;
		private global::MetaDslx.Core.MetaAnnotationBuilder __tmp48;
		internal global::MetaDslx.Core.MetaPropertyBuilder InterfaceReference_Name;
		internal global::MetaDslx.Core.MetaPropertyBuilder InterfaceReference_OptionalName;
		internal global::MetaDslx.Core.MetaPropertyBuilder InterfaceReference_Interface;
		internal global::MetaDslx.Core.MetaPropertyBuilder InterfaceReference_Binding;
		internal global::MetaDslx.Core.MetaClassBuilder Service;
		internal global::MetaDslx.Core.MetaClassBuilder Reference;
		internal global::MetaDslx.Core.MetaClassBuilder Implementation;
		internal global::MetaDslx.Core.MetaClassBuilder Language;
		internal global::MetaDslx.Core.MetaClassBuilder Deployment;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp49;
		internal global::MetaDslx.Core.MetaPropertyBuilder Deployment_Environments;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp50;
		internal global::MetaDslx.Core.MetaPropertyBuilder Deployment_Wires;
		internal global::MetaDslx.Core.MetaClassBuilder Environment;
		internal global::MetaDslx.Core.MetaPropertyBuilder Environment_Runtime;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp51;
		internal global::MetaDslx.Core.MetaPropertyBuilder Environment_Databases;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp52;
		internal global::MetaDslx.Core.MetaPropertyBuilder Environment_Assemblies;
		internal global::MetaDslx.Core.MetaClassBuilder Runtime;
		internal global::MetaDslx.Core.MetaClassBuilder Binding;
		internal global::MetaDslx.Core.MetaPropertyBuilder Binding_Transport;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp53;
		internal global::MetaDslx.Core.MetaPropertyBuilder Binding_Encodings;
		private global::MetaDslx.Core.MetaCollectionTypeBuilder __tmp54;
		internal global::MetaDslx.Core.MetaPropertyBuilder Binding_Protocols;
		internal global::MetaDslx.Core.MetaClassBuilder Endpoint;
		internal global::MetaDslx.Core.MetaPropertyBuilder Endpoint_Interface;
		internal global::MetaDslx.Core.MetaPropertyBuilder Endpoint_Binding;
		internal global::MetaDslx.Core.MetaPropertyBuilder Endpoint_Address;
		internal global::MetaDslx.Core.MetaClassBuilder BindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder TransportBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder EncodingBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder ProtocolBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder HttpTransportBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder RestTransportBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder WebSocketTransportBindingElement;
		internal global::MetaDslx.Core.MetaEnumBuilder SoapVersion;
		private global::MetaDslx.Core.MetaEnumLiteralBuilder __tmp55;
		private global::MetaDslx.Core.MetaEnumLiteralBuilder __tmp56;
		internal global::MetaDslx.Core.MetaClassBuilder SoapEncodingBindingElement;
		internal global::MetaDslx.Core.MetaPropertyBuilder SoapEncodingBindingElement_Version;
		internal global::MetaDslx.Core.MetaPropertyBuilder SoapEncodingBindingElement_MtomEnabled;
		internal global::MetaDslx.Core.MetaClassBuilder XmlEncodingBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder JsonEncodingBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder WsProtocolBindingElement;
		internal global::MetaDslx.Core.MetaClassBuilder WsAddressingBindingElement;
	
		internal SoalBuilderInstance()
		{
			this.Model = new global::MetaDslx.Core.MutableModel();
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
			global::MetaDslx.Core.MetaFactory factory = new global::MetaDslx.Core.MetaFactory(this.Model, global::MetaDslx.Core.ModelFactoryFlags.DontMakeSymbolsCreated);
	
			__tmp1 = factory.MetaNamespace();
			__tmp2 = factory.MetaNamespace();
			__tmp3 = factory.MetaModel();
			MetaModel = __tmp3;
			__tmp4 = factory.MetaConstant();
			__tmp5 = factory.MetaConstant();
			__tmp6 = factory.MetaConstant();
			__tmp7 = factory.MetaConstant();
			__tmp8 = factory.MetaConstant();
			__tmp9 = factory.MetaConstant();
			__tmp10 = factory.MetaConstant();
			__tmp11 = factory.MetaConstant();
			__tmp12 = factory.MetaConstant();
			__tmp13 = factory.MetaConstant();
			__tmp14 = factory.MetaConstant();
			NamedElement = factory.MetaClass();
			__tmp15 = factory.MetaAnnotation();
			NamedElement_Name = factory.MetaProperty();
			TypedElement = factory.MetaClass();
			__tmp16 = factory.MetaAnnotation();
			TypedElement_Type = factory.MetaProperty();
			__tmp17 = factory.MetaAnnotation();
			SoalType = factory.MetaClass();
			__tmp18 = factory.MetaAnnotation();
			Namespace = factory.MetaClass();
			__tmp19 = factory.MetaAnnotation();
			__tmp20 = factory.MetaCollectionType();
			Namespace_Declarations = factory.MetaProperty();
			Declaration = factory.MetaClass();
			Declaration_Namespace = factory.MetaProperty();
			ArrayType = factory.MetaClass();
			ArrayType_InnerType = factory.MetaProperty();
			ArrayType_Namespace = factory.MetaProperty();
			NullableType = factory.MetaClass();
			NullableType_InnerType = factory.MetaProperty();
			NullableType_Namespace = factory.MetaProperty();
			PrimitiveType = factory.MetaClass();
			__tmp21 = factory.MetaAnnotation();
			Enum = factory.MetaClass();
			__tmp22 = factory.MetaAnnotation();
			__tmp23 = factory.MetaCollectionType();
			Enum_EnumLiterals = factory.MetaProperty();
			EnumLiteral = factory.MetaClass();
			EnumLiteral_Enum = factory.MetaProperty();
			__tmp24 = factory.MetaAnnotation();
			StructuredType = factory.MetaClass();
			__tmp25 = factory.MetaAnnotation();
			__tmp26 = factory.MetaCollectionType();
			StructuredType_Properties = factory.MetaProperty();
			Property = factory.MetaClass();
			Property_Parent = factory.MetaProperty();
			Struct = factory.MetaClass();
			__tmp27 = factory.MetaAnnotation();
			Struct_BaseType = factory.MetaProperty();
			Exception = factory.MetaClass();
			__tmp28 = factory.MetaAnnotation();
			Exception_BaseType = factory.MetaProperty();
			Entity = factory.MetaClass();
			__tmp29 = factory.MetaAnnotation();
			Entity_BaseType = factory.MetaProperty();
			__tmp30 = factory.MetaAnnotation();
			Interface = factory.MetaClass();
			__tmp31 = factory.MetaAnnotation();
			__tmp32 = factory.MetaCollectionType();
			Interface_Operations = factory.MetaProperty();
			Database = factory.MetaClass();
			__tmp33 = factory.MetaAnnotation();
			__tmp34 = factory.MetaCollectionType();
			Database_Entities = factory.MetaProperty();
			Operation = factory.MetaClass();
			Operation_Parent = factory.MetaProperty();
			Operation_IsOneway = factory.MetaProperty();
			Operation_ReturnType = factory.MetaProperty();
			__tmp35 = factory.MetaCollectionType();
			Operation_Parameters = factory.MetaProperty();
			__tmp36 = factory.MetaCollectionType();
			Operation_Exceptions = factory.MetaProperty();
			Parameter = factory.MetaClass();
			Parameter_Operation = factory.MetaProperty();
			__tmp37 = factory.MetaAnnotation();
			Component = factory.MetaClass();
			__tmp38 = factory.MetaAnnotation();
			Component_BaseComponent = factory.MetaProperty();
			Component_IsAbstract = factory.MetaProperty();
			__tmp39 = factory.MetaAnnotation();
			__tmp40 = factory.MetaCollectionType();
			Component_Services = factory.MetaProperty();
			__tmp41 = factory.MetaAnnotation();
			__tmp42 = factory.MetaCollectionType();
			Component_References = factory.MetaProperty();
			__tmp43 = factory.MetaAnnotation();
			__tmp44 = factory.MetaCollectionType();
			Component_Properties = factory.MetaProperty();
			Component_Implementation = factory.MetaProperty();
			Component_Language = factory.MetaProperty();
			Composite = factory.MetaClass();
			__tmp45 = factory.MetaAnnotation();
			__tmp46 = factory.MetaCollectionType();
			Composite_Components = factory.MetaProperty();
			__tmp47 = factory.MetaCollectionType();
			Composite_Wires = factory.MetaProperty();
			Assembly = factory.MetaClass();
			Wire = factory.MetaClass();
			Wire_Source = factory.MetaProperty();
			Wire_Target = factory.MetaProperty();
			InterfaceReference = factory.MetaClass();
			__tmp48 = factory.MetaAnnotation();
			InterfaceReference_Name = factory.MetaProperty();
			InterfaceReference_OptionalName = factory.MetaProperty();
			InterfaceReference_Interface = factory.MetaProperty();
			InterfaceReference_Binding = factory.MetaProperty();
			Service = factory.MetaClass();
			Reference = factory.MetaClass();
			Implementation = factory.MetaClass();
			Language = factory.MetaClass();
			Deployment = factory.MetaClass();
			__tmp49 = factory.MetaCollectionType();
			Deployment_Environments = factory.MetaProperty();
			__tmp50 = factory.MetaCollectionType();
			Deployment_Wires = factory.MetaProperty();
			Environment = factory.MetaClass();
			Environment_Runtime = factory.MetaProperty();
			__tmp51 = factory.MetaCollectionType();
			Environment_Databases = factory.MetaProperty();
			__tmp52 = factory.MetaCollectionType();
			Environment_Assemblies = factory.MetaProperty();
			Runtime = factory.MetaClass();
			Binding = factory.MetaClass();
			Binding_Transport = factory.MetaProperty();
			__tmp53 = factory.MetaCollectionType();
			Binding_Encodings = factory.MetaProperty();
			__tmp54 = factory.MetaCollectionType();
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
			RestTransportBindingElement = factory.MetaClass();
			WebSocketTransportBindingElement = factory.MetaClass();
			SoapVersion = factory.MetaEnum();
			__tmp55 = factory.MetaEnumLiteral();
			__tmp56 = factory.MetaEnumLiteral();
			SoapEncodingBindingElement = factory.MetaClass();
			SoapEncodingBindingElement_Version = factory.MetaProperty();
			SoapEncodingBindingElement_MtomEnabled = factory.MetaProperty();
			XmlEncodingBindingElement = factory.MetaClass();
			JsonEncodingBindingElement = factory.MetaClass();
			WsProtocolBindingElement = factory.MetaClass();
			WsAddressingBindingElement = factory.MetaClass();
	
			__tmp1.Name = "MetaDslx";
			__tmp1.Documentation = null;
			// __tmp1.Parent = null;
			// __tmp1.MetaModel = null;
			__tmp1.Namespaces.AddLazy(() => __tmp2);
			__tmp2.Name = "Soal";
			__tmp2.Documentation = null;
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
			__tmp2.Declarations.AddLazy(() => __tmp13);
			__tmp2.Declarations.AddLazy(() => __tmp14);
			__tmp2.Declarations.AddLazy(() => NamedElement);
			__tmp2.Declarations.AddLazy(() => TypedElement);
			__tmp2.Declarations.AddLazy(() => SoalType);
			__tmp2.Declarations.AddLazy(() => Namespace);
			__tmp2.Declarations.AddLazy(() => Declaration);
			__tmp2.Declarations.AddLazy(() => ArrayType);
			__tmp2.Declarations.AddLazy(() => NullableType);
			__tmp2.Declarations.AddLazy(() => PrimitiveType);
			__tmp2.Declarations.AddLazy(() => Enum);
			__tmp2.Declarations.AddLazy(() => EnumLiteral);
			__tmp2.Declarations.AddLazy(() => StructuredType);
			__tmp2.Declarations.AddLazy(() => Property);
			__tmp2.Declarations.AddLazy(() => Struct);
			__tmp2.Declarations.AddLazy(() => Exception);
			__tmp2.Declarations.AddLazy(() => Entity);
			__tmp2.Declarations.AddLazy(() => Interface);
			__tmp2.Declarations.AddLazy(() => Database);
			__tmp2.Declarations.AddLazy(() => Operation);
			__tmp2.Declarations.AddLazy(() => Parameter);
			__tmp2.Declarations.AddLazy(() => Component);
			__tmp2.Declarations.AddLazy(() => Composite);
			__tmp2.Declarations.AddLazy(() => Assembly);
			__tmp2.Declarations.AddLazy(() => Wire);
			__tmp2.Declarations.AddLazy(() => InterfaceReference);
			__tmp2.Declarations.AddLazy(() => Service);
			__tmp2.Declarations.AddLazy(() => Reference);
			__tmp2.Declarations.AddLazy(() => Implementation);
			__tmp2.Declarations.AddLazy(() => Language);
			__tmp2.Declarations.AddLazy(() => Deployment);
			__tmp2.Declarations.AddLazy(() => Environment);
			__tmp2.Declarations.AddLazy(() => Runtime);
			__tmp2.Declarations.AddLazy(() => Binding);
			__tmp2.Declarations.AddLazy(() => Endpoint);
			__tmp2.Declarations.AddLazy(() => BindingElement);
			__tmp2.Declarations.AddLazy(() => TransportBindingElement);
			__tmp2.Declarations.AddLazy(() => EncodingBindingElement);
			__tmp2.Declarations.AddLazy(() => ProtocolBindingElement);
			__tmp2.Declarations.AddLazy(() => HttpTransportBindingElement);
			__tmp2.Declarations.AddLazy(() => RestTransportBindingElement);
			__tmp2.Declarations.AddLazy(() => WebSocketTransportBindingElement);
			__tmp2.Declarations.AddLazy(() => SoapVersion);
			__tmp2.Declarations.AddLazy(() => SoapEncodingBindingElement);
			__tmp2.Declarations.AddLazy(() => XmlEncodingBindingElement);
			__tmp2.Declarations.AddLazy(() => JsonEncodingBindingElement);
			__tmp2.Declarations.AddLazy(() => WsProtocolBindingElement);
			__tmp2.Declarations.AddLazy(() => WsAddressingBindingElement);
			__tmp3.Name = "Soal";
			__tmp3.Documentation = null;
			__tmp3.Uri = "http://MetaDslx.Soal/1.0";
			__tmp3.NamespaceLazy = () => __tmp2;
			__tmp4.MetaModelLazy = () => __tmp3;
			__tmp4.NamespaceLazy = () => __tmp2;
			__tmp4.Documentation = null;
			__tmp4.Name = "Object";
			__tmp4.TypeLazy = () => PrimitiveType;
			__tmp5.MetaModelLazy = () => __tmp3;
			__tmp5.NamespaceLazy = () => __tmp2;
			__tmp5.Documentation = null;
			__tmp5.Name = "String";
			__tmp5.TypeLazy = () => PrimitiveType;
			__tmp6.MetaModelLazy = () => __tmp3;
			__tmp6.NamespaceLazy = () => __tmp2;
			__tmp6.Documentation = null;
			__tmp6.Name = "Int";
			__tmp6.TypeLazy = () => PrimitiveType;
			__tmp7.MetaModelLazy = () => __tmp3;
			__tmp7.NamespaceLazy = () => __tmp2;
			__tmp7.Documentation = null;
			__tmp7.Name = "Long";
			__tmp7.TypeLazy = () => PrimitiveType;
			__tmp8.MetaModelLazy = () => __tmp3;
			__tmp8.NamespaceLazy = () => __tmp2;
			__tmp8.Documentation = null;
			__tmp8.Name = "Float";
			__tmp8.TypeLazy = () => PrimitiveType;
			__tmp9.MetaModelLazy = () => __tmp3;
			__tmp9.NamespaceLazy = () => __tmp2;
			__tmp9.Documentation = null;
			__tmp9.Name = "Double";
			__tmp9.TypeLazy = () => PrimitiveType;
			__tmp10.MetaModelLazy = () => __tmp3;
			__tmp10.NamespaceLazy = () => __tmp2;
			__tmp10.Documentation = null;
			__tmp10.Name = "Byte";
			__tmp10.TypeLazy = () => PrimitiveType;
			__tmp11.MetaModelLazy = () => __tmp3;
			__tmp11.NamespaceLazy = () => __tmp2;
			__tmp11.Documentation = null;
			__tmp11.Name = "Bool";
			__tmp11.TypeLazy = () => PrimitiveType;
			__tmp12.MetaModelLazy = () => __tmp3;
			__tmp12.NamespaceLazy = () => __tmp2;
			__tmp12.Documentation = null;
			__tmp12.Name = "Void";
			__tmp12.TypeLazy = () => PrimitiveType;
			__tmp13.MetaModelLazy = () => __tmp3;
			__tmp13.NamespaceLazy = () => __tmp2;
			__tmp13.Documentation = null;
			__tmp13.Name = "DateTime";
			__tmp13.TypeLazy = () => PrimitiveType;
			__tmp14.MetaModelLazy = () => __tmp3;
			__tmp14.NamespaceLazy = () => __tmp2;
			__tmp14.Documentation = null;
			__tmp14.Name = "TimeSpan";
			__tmp14.TypeLazy = () => PrimitiveType;
			NamedElement.MetaModelLazy = () => __tmp3;
			NamedElement.NamespaceLazy = () => __tmp2;
			NamedElement.Documentation = null;
			NamedElement.Name = "NamedElement";
			NamedElement.IsAbstract = true;
			NamedElement.Properties.AddLazy(() => NamedElement_Name);
			// NamedElement.Constructor = null;
			__tmp15.Name = "Name";
			__tmp15.Documentation = null;
			NamedElement_Name.Annotations.AddLazy(() => __tmp15);
			NamedElement_Name.TypeLazy = () => global::MetaDslx.Core.MetaInstance.String.ToMutable();
			NamedElement_Name.Name = "Name";
			NamedElement_Name.Documentation = null;
			// NamedElement_Name.Kind = null;
			NamedElement_Name.ClassLazy = () => NamedElement;
			TypedElement.MetaModelLazy = () => __tmp3;
			TypedElement.NamespaceLazy = () => __tmp2;
			TypedElement.Documentation = null;
			TypedElement.Name = "TypedElement";
			TypedElement.IsAbstract = true;
			TypedElement.Properties.AddLazy(() => TypedElement_Type);
			// TypedElement.Constructor = null;
			__tmp16.Name = "Type";
			__tmp16.Documentation = null;
			TypedElement_Type.Annotations.AddLazy(() => __tmp16);
			TypedElement_Type.TypeLazy = () => SoalType;
			TypedElement_Type.Name = "Type";
			TypedElement_Type.Documentation = null;
			// TypedElement_Type.Kind = null;
			TypedElement_Type.ClassLazy = () => TypedElement;
			__tmp17.Name = "Type";
			__tmp17.Documentation = null;
			SoalType.MetaModelLazy = () => __tmp3;
			SoalType.NamespaceLazy = () => __tmp2;
			SoalType.Documentation = null;
			SoalType.Name = "SoalType";
			SoalType.Annotations.AddLazy(() => __tmp17);
			SoalType.IsAbstract = true;
			// SoalType.Constructor = null;
			__tmp18.Name = "Scope";
			__tmp18.Documentation = null;
			Namespace.MetaModelLazy = () => __tmp3;
			Namespace.NamespaceLazy = () => __tmp2;
			Namespace.Documentation = null;
			Namespace.Name = "Namespace";
			Namespace.Annotations.AddLazy(() => __tmp18);
			// Namespace.IsAbstract = null;
			Namespace.SuperClasses.AddLazy(() => Declaration);
			Namespace.Properties.AddLazy(() => Namespace_Declarations);
			// Namespace.Constructor = null;
			__tmp19.Name = "ScopeEntry";
			__tmp19.Documentation = null;
			__tmp20.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp20.InnerTypeLazy = () => Declaration;
			Namespace_Declarations.Annotations.AddLazy(() => __tmp19);
			Namespace_Declarations.TypeLazy = () => __tmp20;
			Namespace_Declarations.Name = "Declarations";
			Namespace_Declarations.Documentation = null;
			Namespace_Declarations.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Namespace_Declarations.ClassLazy = () => Namespace;
			Namespace_Declarations.OppositeProperties.AddLazy(() => Declaration_Namespace);
			Declaration.MetaModelLazy = () => __tmp3;
			Declaration.NamespaceLazy = () => __tmp2;
			Declaration.Documentation = null;
			Declaration.Name = "Declaration";
			Declaration.IsAbstract = true;
			Declaration.SuperClasses.AddLazy(() => NamedElement);
			Declaration.Properties.AddLazy(() => Declaration_Namespace);
			// Declaration.Constructor = null;
			Declaration_Namespace.TypeLazy = () => Namespace;
			Declaration_Namespace.Name = "Namespace";
			Declaration_Namespace.Documentation = null;
			// Declaration_Namespace.Kind = null;
			Declaration_Namespace.ClassLazy = () => Declaration;
			Declaration_Namespace.OppositeProperties.AddLazy(() => Namespace_Declarations);
			ArrayType.MetaModelLazy = () => __tmp3;
			ArrayType.NamespaceLazy = () => __tmp2;
			ArrayType.Documentation = null;
			ArrayType.Name = "ArrayType";
			// ArrayType.IsAbstract = null;
			ArrayType.SuperClasses.AddLazy(() => SoalType);
			ArrayType.Properties.AddLazy(() => ArrayType_InnerType);
			ArrayType.Properties.AddLazy(() => ArrayType_Namespace);
			// ArrayType.Constructor = null;
			ArrayType_InnerType.TypeLazy = () => SoalType;
			ArrayType_InnerType.Name = "InnerType";
			ArrayType_InnerType.Documentation = "ArrayType()\r\n{\r\nNamespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;\r\n}";
			// ArrayType_InnerType.Kind = null;
			ArrayType_InnerType.ClassLazy = () => ArrayType;
			ArrayType_Namespace.TypeLazy = () => Namespace;
			ArrayType_Namespace.Name = "Namespace";
			ArrayType_Namespace.Documentation = null;
			ArrayType_Namespace.Kind = global::MetaDslx.Core.MetaPropertyKind.Derived;
			ArrayType_Namespace.ClassLazy = () => ArrayType;
			NullableType.MetaModelLazy = () => __tmp3;
			NullableType.NamespaceLazy = () => __tmp2;
			NullableType.Documentation = null;
			NullableType.Name = "NullableType";
			// NullableType.IsAbstract = null;
			NullableType.SuperClasses.AddLazy(() => SoalType);
			NullableType.Properties.AddLazy(() => NullableType_InnerType);
			NullableType.Properties.AddLazy(() => NullableType_Namespace);
			// NullableType.Constructor = null;
			NullableType_InnerType.TypeLazy = () => SoalType;
			NullableType_InnerType.Name = "InnerType";
			NullableType_InnerType.Documentation = "NullableType()\r\n{\r\nNamespace = InnerType is Declaration ? ((Declaration)InnerType).Namespace : null;\r\n}";
			// NullableType_InnerType.Kind = null;
			NullableType_InnerType.ClassLazy = () => NullableType;
			NullableType_Namespace.TypeLazy = () => Namespace;
			NullableType_Namespace.Name = "Namespace";
			NullableType_Namespace.Documentation = null;
			NullableType_Namespace.Kind = global::MetaDslx.Core.MetaPropertyKind.Derived;
			NullableType_Namespace.ClassLazy = () => NullableType;
			PrimitiveType.MetaModelLazy = () => __tmp3;
			PrimitiveType.NamespaceLazy = () => __tmp2;
			PrimitiveType.Documentation = null;
			PrimitiveType.Name = "PrimitiveType";
			// PrimitiveType.IsAbstract = null;
			PrimitiveType.SuperClasses.AddLazy(() => SoalType);
			PrimitiveType.SuperClasses.AddLazy(() => NamedElement);
			// PrimitiveType.Constructor = null;
			__tmp21.Name = "Scope";
			__tmp21.Documentation = null;
			Enum.MetaModelLazy = () => __tmp3;
			Enum.NamespaceLazy = () => __tmp2;
			Enum.Documentation = null;
			Enum.Name = "Enum";
			Enum.Annotations.AddLazy(() => __tmp21);
			// Enum.IsAbstract = null;
			Enum.SuperClasses.AddLazy(() => SoalType);
			Enum.SuperClasses.AddLazy(() => Declaration);
			Enum.Properties.AddLazy(() => Enum_EnumLiterals);
			// Enum.Constructor = null;
			__tmp22.Name = "ScopeEntry";
			__tmp22.Documentation = null;
			__tmp23.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp23.InnerTypeLazy = () => EnumLiteral;
			Enum_EnumLiterals.Annotations.AddLazy(() => __tmp22);
			Enum_EnumLiterals.TypeLazy = () => __tmp23;
			Enum_EnumLiterals.Name = "EnumLiterals";
			Enum_EnumLiterals.Documentation = null;
			Enum_EnumLiterals.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Enum_EnumLiterals.ClassLazy = () => Enum;
			Enum_EnumLiterals.OppositeProperties.AddLazy(() => EnumLiteral_Enum);
			EnumLiteral.MetaModelLazy = () => __tmp3;
			EnumLiteral.NamespaceLazy = () => __tmp2;
			EnumLiteral.Documentation = null;
			EnumLiteral.Name = "EnumLiteral";
			// EnumLiteral.IsAbstract = null;
			EnumLiteral.SuperClasses.AddLazy(() => NamedElement);
			EnumLiteral.SuperClasses.AddLazy(() => TypedElement);
			EnumLiteral.Properties.AddLazy(() => EnumLiteral_Enum);
			// EnumLiteral.Constructor = null;
			EnumLiteral_Enum.TypeLazy = () => Enum;
			EnumLiteral_Enum.Name = "Enum";
			EnumLiteral_Enum.Documentation = "EnumLiteral()\r\n{\r\nType = Enum;\r\n}";
			// EnumLiteral_Enum.Kind = null;
			EnumLiteral_Enum.ClassLazy = () => EnumLiteral;
			EnumLiteral_Enum.OppositeProperties.AddLazy(() => Enum_EnumLiterals);
			__tmp24.Name = "Scope";
			__tmp24.Documentation = null;
			StructuredType.MetaModelLazy = () => __tmp3;
			StructuredType.NamespaceLazy = () => __tmp2;
			StructuredType.Documentation = null;
			StructuredType.Name = "StructuredType";
			StructuredType.Annotations.AddLazy(() => __tmp24);
			StructuredType.IsAbstract = true;
			StructuredType.SuperClasses.AddLazy(() => SoalType);
			StructuredType.SuperClasses.AddLazy(() => Declaration);
			StructuredType.Properties.AddLazy(() => StructuredType_Properties);
			// StructuredType.Constructor = null;
			__tmp25.Name = "ScopeEntry";
			__tmp25.Documentation = null;
			__tmp26.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp26.InnerTypeLazy = () => Property;
			StructuredType_Properties.Annotations.AddLazy(() => __tmp25);
			StructuredType_Properties.TypeLazy = () => __tmp26;
			StructuredType_Properties.Name = "Properties";
			StructuredType_Properties.Documentation = null;
			StructuredType_Properties.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			StructuredType_Properties.ClassLazy = () => StructuredType;
			StructuredType_Properties.OppositeProperties.AddLazy(() => Property_Parent);
			Property.MetaModelLazy = () => __tmp3;
			Property.NamespaceLazy = () => __tmp2;
			Property.Documentation = null;
			Property.Name = "Property";
			// Property.IsAbstract = null;
			Property.SuperClasses.AddLazy(() => NamedElement);
			Property.SuperClasses.AddLazy(() => TypedElement);
			Property.Properties.AddLazy(() => Property_Parent);
			// Property.Constructor = null;
			Property_Parent.TypeLazy = () => StructuredType;
			Property_Parent.Name = "Parent";
			Property_Parent.Documentation = null;
			// Property_Parent.Kind = null;
			Property_Parent.ClassLazy = () => Property;
			Property_Parent.OppositeProperties.AddLazy(() => StructuredType_Properties);
			Struct.MetaModelLazy = () => __tmp3;
			Struct.NamespaceLazy = () => __tmp2;
			Struct.Documentation = null;
			Struct.Name = "Struct";
			// Struct.IsAbstract = null;
			Struct.SuperClasses.AddLazy(() => StructuredType);
			Struct.Properties.AddLazy(() => Struct_BaseType);
			// Struct.Constructor = null;
			__tmp27.Name = "InheritedScope";
			__tmp27.Documentation = null;
			Struct_BaseType.Annotations.AddLazy(() => __tmp27);
			Struct_BaseType.TypeLazy = () => Struct;
			Struct_BaseType.Name = "BaseType";
			Struct_BaseType.Documentation = null;
			// Struct_BaseType.Kind = null;
			Struct_BaseType.ClassLazy = () => Struct;
			Exception.MetaModelLazy = () => __tmp3;
			Exception.NamespaceLazy = () => __tmp2;
			Exception.Documentation = null;
			Exception.Name = "Exception";
			// Exception.IsAbstract = null;
			Exception.SuperClasses.AddLazy(() => StructuredType);
			Exception.Properties.AddLazy(() => Exception_BaseType);
			// Exception.Constructor = null;
			__tmp28.Name = "InheritedScope";
			__tmp28.Documentation = null;
			Exception_BaseType.Annotations.AddLazy(() => __tmp28);
			Exception_BaseType.TypeLazy = () => Exception;
			Exception_BaseType.Name = "BaseType";
			Exception_BaseType.Documentation = null;
			// Exception_BaseType.Kind = null;
			Exception_BaseType.ClassLazy = () => Exception;
			Entity.MetaModelLazy = () => __tmp3;
			Entity.NamespaceLazy = () => __tmp2;
			Entity.Documentation = null;
			Entity.Name = "Entity";
			// Entity.IsAbstract = null;
			Entity.SuperClasses.AddLazy(() => StructuredType);
			Entity.Properties.AddLazy(() => Entity_BaseType);
			// Entity.Constructor = null;
			__tmp29.Name = "InheritedScope";
			__tmp29.Documentation = null;
			Entity_BaseType.Annotations.AddLazy(() => __tmp29);
			Entity_BaseType.TypeLazy = () => Entity;
			Entity_BaseType.Name = "BaseType";
			Entity_BaseType.Documentation = null;
			// Entity_BaseType.Kind = null;
			Entity_BaseType.ClassLazy = () => Entity;
			__tmp30.Name = "Scope";
			__tmp30.Documentation = null;
			Interface.MetaModelLazy = () => __tmp3;
			Interface.NamespaceLazy = () => __tmp2;
			Interface.Documentation = null;
			Interface.Name = "Interface";
			Interface.Annotations.AddLazy(() => __tmp30);
			// Interface.IsAbstract = null;
			Interface.SuperClasses.AddLazy(() => SoalType);
			Interface.SuperClasses.AddLazy(() => Declaration);
			Interface.Properties.AddLazy(() => Interface_Operations);
			// Interface.Constructor = null;
			__tmp31.Name = "ScopeEntry";
			__tmp31.Documentation = null;
			__tmp32.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp32.InnerTypeLazy = () => Operation;
			Interface_Operations.Annotations.AddLazy(() => __tmp31);
			Interface_Operations.TypeLazy = () => __tmp32;
			Interface_Operations.Name = "Operations";
			Interface_Operations.Documentation = null;
			Interface_Operations.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Interface_Operations.ClassLazy = () => Interface;
			Interface_Operations.OppositeProperties.AddLazy(() => Operation_Parent);
			Database.MetaModelLazy = () => __tmp3;
			Database.NamespaceLazy = () => __tmp2;
			Database.Documentation = null;
			Database.Name = "Database";
			// Database.IsAbstract = null;
			Database.SuperClasses.AddLazy(() => Interface);
			Database.Properties.AddLazy(() => Database_Entities);
			// Database.Constructor = null;
			__tmp33.Name = "ScopeEntry";
			__tmp33.Documentation = null;
			__tmp34.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp34.InnerTypeLazy = () => Entity;
			Database_Entities.Annotations.AddLazy(() => __tmp33);
			Database_Entities.TypeLazy = () => __tmp34;
			Database_Entities.Name = "Entities";
			Database_Entities.Documentation = null;
			// Database_Entities.Kind = null;
			Database_Entities.ClassLazy = () => Database;
			Operation.MetaModelLazy = () => __tmp3;
			Operation.NamespaceLazy = () => __tmp2;
			Operation.Documentation = null;
			Operation.Name = "Operation";
			// Operation.IsAbstract = null;
			Operation.SuperClasses.AddLazy(() => NamedElement);
			Operation.Properties.AddLazy(() => Operation_Parent);
			Operation.Properties.AddLazy(() => Operation_IsOneway);
			Operation.Properties.AddLazy(() => Operation_ReturnType);
			Operation.Properties.AddLazy(() => Operation_Parameters);
			Operation.Properties.AddLazy(() => Operation_Exceptions);
			// Operation.Constructor = null;
			Operation_Parent.TypeLazy = () => Interface;
			Operation_Parent.Name = "Parent";
			Operation_Parent.Documentation = null;
			// Operation_Parent.Kind = null;
			Operation_Parent.ClassLazy = () => Operation;
			Operation_Parent.OppositeProperties.AddLazy(() => Interface_Operations);
			Operation_IsOneway.TypeLazy = () => global::MetaDslx.Core.MetaInstance.Bool.ToMutable();
			Operation_IsOneway.Name = "IsOneway";
			Operation_IsOneway.Documentation = null;
			// Operation_IsOneway.Kind = null;
			Operation_IsOneway.ClassLazy = () => Operation;
			Operation_ReturnType.TypeLazy = () => SoalType;
			Operation_ReturnType.Name = "ReturnType";
			Operation_ReturnType.Documentation = null;
			// Operation_ReturnType.Kind = null;
			Operation_ReturnType.ClassLazy = () => Operation;
			__tmp35.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp35.InnerTypeLazy = () => Parameter;
			Operation_Parameters.TypeLazy = () => __tmp35;
			Operation_Parameters.Name = "Parameters";
			Operation_Parameters.Documentation = null;
			Operation_Parameters.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Operation_Parameters.ClassLazy = () => Operation;
			Operation_Parameters.OppositeProperties.AddLazy(() => Parameter_Operation);
			__tmp36.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp36.InnerTypeLazy = () => Exception;
			Operation_Exceptions.TypeLazy = () => __tmp36;
			Operation_Exceptions.Name = "Exceptions";
			Operation_Exceptions.Documentation = null;
			// Operation_Exceptions.Kind = null;
			Operation_Exceptions.ClassLazy = () => Operation;
			Parameter.MetaModelLazy = () => __tmp3;
			Parameter.NamespaceLazy = () => __tmp2;
			Parameter.Documentation = null;
			Parameter.Name = "Parameter";
			// Parameter.IsAbstract = null;
			Parameter.SuperClasses.AddLazy(() => NamedElement);
			Parameter.SuperClasses.AddLazy(() => TypedElement);
			Parameter.Properties.AddLazy(() => Parameter_Operation);
			// Parameter.Constructor = null;
			Parameter_Operation.TypeLazy = () => Operation;
			Parameter_Operation.Name = "Operation";
			Parameter_Operation.Documentation = null;
			// Parameter_Operation.Kind = null;
			Parameter_Operation.ClassLazy = () => Parameter;
			Parameter_Operation.OppositeProperties.AddLazy(() => Operation_Parameters);
			__tmp37.Name = "Scope";
			__tmp37.Documentation = null;
			Component.MetaModelLazy = () => __tmp3;
			Component.NamespaceLazy = () => __tmp2;
			Component.Documentation = null;
			Component.Name = "Component";
			Component.Annotations.AddLazy(() => __tmp37);
			// Component.IsAbstract = null;
			Component.SuperClasses.AddLazy(() => Declaration);
			Component.SuperClasses.AddLazy(() => StructuredType);
			Component.Properties.AddLazy(() => Component_BaseComponent);
			Component.Properties.AddLazy(() => Component_IsAbstract);
			Component.Properties.AddLazy(() => Component_Services);
			Component.Properties.AddLazy(() => Component_References);
			Component.Properties.AddLazy(() => Component_Properties);
			Component.Properties.AddLazy(() => Component_Implementation);
			Component.Properties.AddLazy(() => Component_Language);
			// Component.Constructor = null;
			__tmp38.Name = "InheritedScope";
			__tmp38.Documentation = null;
			Component_BaseComponent.Annotations.AddLazy(() => __tmp38);
			Component_BaseComponent.TypeLazy = () => Component;
			Component_BaseComponent.Name = "BaseComponent";
			Component_BaseComponent.Documentation = null;
			// Component_BaseComponent.Kind = null;
			Component_BaseComponent.ClassLazy = () => Component;
			Component_IsAbstract.TypeLazy = () => global::MetaDslx.Core.MetaInstance.Bool.ToMutable();
			Component_IsAbstract.Name = "IsAbstract";
			Component_IsAbstract.Documentation = null;
			// Component_IsAbstract.Kind = null;
			Component_IsAbstract.ClassLazy = () => Component;
			__tmp39.Name = "ScopeEntry";
			__tmp39.Documentation = null;
			__tmp40.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp40.InnerTypeLazy = () => Service;
			Component_Services.Annotations.AddLazy(() => __tmp39);
			Component_Services.TypeLazy = () => __tmp40;
			Component_Services.Name = "Services";
			Component_Services.Documentation = null;
			Component_Services.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Component_Services.ClassLazy = () => Component;
			__tmp41.Name = "ScopeEntry";
			__tmp41.Documentation = null;
			__tmp42.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp42.InnerTypeLazy = () => Reference;
			Component_References.Annotations.AddLazy(() => __tmp41);
			Component_References.TypeLazy = () => __tmp42;
			Component_References.Name = "References";
			Component_References.Documentation = null;
			Component_References.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Component_References.ClassLazy = () => Component;
			__tmp43.Name = "ScopeEntry";
			__tmp43.Documentation = null;
			__tmp44.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp44.InnerTypeLazy = () => Property;
			Component_Properties.Annotations.AddLazy(() => __tmp43);
			Component_Properties.TypeLazy = () => __tmp44;
			Component_Properties.Name = "Properties";
			Component_Properties.Documentation = null;
			Component_Properties.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Component_Properties.ClassLazy = () => Component;
			Component_Implementation.TypeLazy = () => Implementation;
			Component_Implementation.Name = "Implementation";
			Component_Implementation.Documentation = null;
			Component_Implementation.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Component_Implementation.ClassLazy = () => Component;
			Component_Language.TypeLazy = () => Language;
			Component_Language.Name = "Language";
			Component_Language.Documentation = null;
			Component_Language.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Component_Language.ClassLazy = () => Component;
			Composite.MetaModelLazy = () => __tmp3;
			Composite.NamespaceLazy = () => __tmp2;
			Composite.Documentation = null;
			Composite.Name = "Composite";
			// Composite.IsAbstract = null;
			Composite.SuperClasses.AddLazy(() => Component);
			Composite.Properties.AddLazy(() => Composite_Components);
			Composite.Properties.AddLazy(() => Composite_Wires);
			// Composite.Constructor = null;
			__tmp45.Name = "ScopeEntry";
			__tmp45.Documentation = null;
			__tmp46.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp46.InnerTypeLazy = () => Component;
			Composite_Components.Annotations.AddLazy(() => __tmp45);
			Composite_Components.TypeLazy = () => __tmp46;
			Composite_Components.Name = "Components";
			Composite_Components.Documentation = null;
			// Composite_Components.Kind = null;
			Composite_Components.ClassLazy = () => Composite;
			__tmp47.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp47.InnerTypeLazy = () => Wire;
			Composite_Wires.TypeLazy = () => __tmp47;
			Composite_Wires.Name = "Wires";
			Composite_Wires.Documentation = null;
			Composite_Wires.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Composite_Wires.ClassLazy = () => Composite;
			Assembly.MetaModelLazy = () => __tmp3;
			Assembly.NamespaceLazy = () => __tmp2;
			Assembly.Documentation = null;
			Assembly.Name = "Assembly";
			// Assembly.IsAbstract = null;
			Assembly.SuperClasses.AddLazy(() => Composite);
			// Assembly.Constructor = null;
			Wire.MetaModelLazy = () => __tmp3;
			Wire.NamespaceLazy = () => __tmp2;
			Wire.Documentation = null;
			Wire.Name = "Wire";
			// Wire.IsAbstract = null;
			Wire.Properties.AddLazy(() => Wire_Source);
			Wire.Properties.AddLazy(() => Wire_Target);
			// Wire.Constructor = null;
			Wire_Source.TypeLazy = () => InterfaceReference;
			Wire_Source.Name = "Source";
			Wire_Source.Documentation = null;
			// Wire_Source.Kind = null;
			Wire_Source.ClassLazy = () => Wire;
			Wire_Target.TypeLazy = () => InterfaceReference;
			Wire_Target.Name = "Target";
			Wire_Target.Documentation = null;
			// Wire_Target.Kind = null;
			Wire_Target.ClassLazy = () => Wire;
			InterfaceReference.MetaModelLazy = () => __tmp3;
			InterfaceReference.NamespaceLazy = () => __tmp2;
			InterfaceReference.Documentation = null;
			InterfaceReference.Name = "InterfaceReference";
			// InterfaceReference.IsAbstract = null;
			InterfaceReference.Properties.AddLazy(() => InterfaceReference_Name);
			InterfaceReference.Properties.AddLazy(() => InterfaceReference_OptionalName);
			InterfaceReference.Properties.AddLazy(() => InterfaceReference_Interface);
			InterfaceReference.Properties.AddLazy(() => InterfaceReference_Binding);
			// InterfaceReference.Constructor = null;
			__tmp48.Name = "Name";
			__tmp48.Documentation = null;
			InterfaceReference_Name.Annotations.AddLazy(() => __tmp48);
			InterfaceReference_Name.TypeLazy = () => global::MetaDslx.Core.MetaInstance.String.ToMutable();
			InterfaceReference_Name.Name = "Name";
			InterfaceReference_Name.Documentation = "InterfaceReference()\r\n{\r\n// this.Name = this.OptionalName != \"\" ? this.OptionalName : this.Interface.Name;\r\n}";
			InterfaceReference_Name.Kind = global::MetaDslx.Core.MetaPropertyKind.Derived;
			InterfaceReference_Name.ClassLazy = () => InterfaceReference;
			InterfaceReference_OptionalName.TypeLazy = () => global::MetaDslx.Core.MetaInstance.String.ToMutable();
			InterfaceReference_OptionalName.Name = "OptionalName";
			InterfaceReference_OptionalName.Documentation = null;
			// InterfaceReference_OptionalName.Kind = null;
			InterfaceReference_OptionalName.ClassLazy = () => InterfaceReference;
			InterfaceReference_Interface.TypeLazy = () => Interface;
			InterfaceReference_Interface.Name = "Interface";
			InterfaceReference_Interface.Documentation = null;
			// InterfaceReference_Interface.Kind = null;
			InterfaceReference_Interface.ClassLazy = () => InterfaceReference;
			InterfaceReference_Binding.TypeLazy = () => Binding;
			InterfaceReference_Binding.Name = "Binding";
			InterfaceReference_Binding.Documentation = null;
			// InterfaceReference_Binding.Kind = null;
			InterfaceReference_Binding.ClassLazy = () => InterfaceReference;
			Service.MetaModelLazy = () => __tmp3;
			Service.NamespaceLazy = () => __tmp2;
			Service.Documentation = null;
			Service.Name = "Service";
			// Service.IsAbstract = null;
			Service.SuperClasses.AddLazy(() => InterfaceReference);
			// Service.Constructor = null;
			Reference.MetaModelLazy = () => __tmp3;
			Reference.NamespaceLazy = () => __tmp2;
			Reference.Documentation = null;
			Reference.Name = "Reference";
			// Reference.IsAbstract = null;
			Reference.SuperClasses.AddLazy(() => InterfaceReference);
			// Reference.Constructor = null;
			Implementation.MetaModelLazy = () => __tmp3;
			Implementation.NamespaceLazy = () => __tmp2;
			Implementation.Documentation = null;
			Implementation.Name = "Implementation";
			// Implementation.IsAbstract = null;
			Implementation.SuperClasses.AddLazy(() => NamedElement);
			// Implementation.Constructor = null;
			Language.MetaModelLazy = () => __tmp3;
			Language.NamespaceLazy = () => __tmp2;
			Language.Documentation = null;
			Language.Name = "Language";
			// Language.IsAbstract = null;
			Language.SuperClasses.AddLazy(() => NamedElement);
			// Language.Constructor = null;
			Deployment.MetaModelLazy = () => __tmp3;
			Deployment.NamespaceLazy = () => __tmp2;
			Deployment.Documentation = null;
			Deployment.Name = "Deployment";
			// Deployment.IsAbstract = null;
			Deployment.SuperClasses.AddLazy(() => Declaration);
			Deployment.Properties.AddLazy(() => Deployment_Environments);
			Deployment.Properties.AddLazy(() => Deployment_Wires);
			// Deployment.Constructor = null;
			__tmp49.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp49.InnerTypeLazy = () => Environment;
			Deployment_Environments.TypeLazy = () => __tmp49;
			Deployment_Environments.Name = "Environments";
			Deployment_Environments.Documentation = null;
			Deployment_Environments.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Deployment_Environments.ClassLazy = () => Deployment;
			__tmp50.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp50.InnerTypeLazy = () => Wire;
			Deployment_Wires.TypeLazy = () => __tmp50;
			Deployment_Wires.Name = "Wires";
			Deployment_Wires.Documentation = null;
			Deployment_Wires.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Deployment_Wires.ClassLazy = () => Deployment;
			Environment.MetaModelLazy = () => __tmp3;
			Environment.NamespaceLazy = () => __tmp2;
			Environment.Documentation = null;
			Environment.Name = "Environment";
			// Environment.IsAbstract = null;
			Environment.SuperClasses.AddLazy(() => NamedElement);
			Environment.Properties.AddLazy(() => Environment_Runtime);
			Environment.Properties.AddLazy(() => Environment_Databases);
			Environment.Properties.AddLazy(() => Environment_Assemblies);
			// Environment.Constructor = null;
			Environment_Runtime.TypeLazy = () => Runtime;
			Environment_Runtime.Name = "Runtime";
			Environment_Runtime.Documentation = null;
			Environment_Runtime.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Environment_Runtime.ClassLazy = () => Environment;
			__tmp51.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp51.InnerTypeLazy = () => Database;
			Environment_Databases.TypeLazy = () => __tmp51;
			Environment_Databases.Name = "Databases";
			Environment_Databases.Documentation = null;
			// Environment_Databases.Kind = null;
			Environment_Databases.ClassLazy = () => Environment;
			__tmp52.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp52.InnerTypeLazy = () => Assembly;
			Environment_Assemblies.TypeLazy = () => __tmp52;
			Environment_Assemblies.Name = "Assemblies";
			Environment_Assemblies.Documentation = null;
			// Environment_Assemblies.Kind = null;
			Environment_Assemblies.ClassLazy = () => Environment;
			Runtime.MetaModelLazy = () => __tmp3;
			Runtime.NamespaceLazy = () => __tmp2;
			Runtime.Documentation = null;
			Runtime.Name = "Runtime";
			// Runtime.IsAbstract = null;
			Runtime.SuperClasses.AddLazy(() => NamedElement);
			// Runtime.Constructor = null;
			Binding.MetaModelLazy = () => __tmp3;
			Binding.NamespaceLazy = () => __tmp2;
			Binding.Documentation = null;
			Binding.Name = "Binding";
			// Binding.IsAbstract = null;
			Binding.SuperClasses.AddLazy(() => Declaration);
			Binding.Properties.AddLazy(() => Binding_Transport);
			Binding.Properties.AddLazy(() => Binding_Encodings);
			Binding.Properties.AddLazy(() => Binding_Protocols);
			// Binding.Constructor = null;
			Binding_Transport.TypeLazy = () => TransportBindingElement;
			Binding_Transport.Name = "Transport";
			Binding_Transport.Documentation = null;
			Binding_Transport.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Binding_Transport.ClassLazy = () => Binding;
			__tmp53.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp53.InnerTypeLazy = () => EncodingBindingElement;
			Binding_Encodings.TypeLazy = () => __tmp53;
			Binding_Encodings.Name = "Encodings";
			Binding_Encodings.Documentation = null;
			Binding_Encodings.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Binding_Encodings.ClassLazy = () => Binding;
			__tmp54.Kind = global::MetaDslx.Core.MetaCollectionKind.List;
			__tmp54.InnerTypeLazy = () => ProtocolBindingElement;
			Binding_Protocols.TypeLazy = () => __tmp54;
			Binding_Protocols.Name = "Protocols";
			Binding_Protocols.Documentation = null;
			Binding_Protocols.Kind = global::MetaDslx.Core.MetaPropertyKind.Containment;
			Binding_Protocols.ClassLazy = () => Binding;
			Endpoint.MetaModelLazy = () => __tmp3;
			Endpoint.NamespaceLazy = () => __tmp2;
			Endpoint.Documentation = null;
			Endpoint.Name = "Endpoint";
			// Endpoint.IsAbstract = null;
			Endpoint.SuperClasses.AddLazy(() => Declaration);
			Endpoint.Properties.AddLazy(() => Endpoint_Interface);
			Endpoint.Properties.AddLazy(() => Endpoint_Binding);
			Endpoint.Properties.AddLazy(() => Endpoint_Address);
			// Endpoint.Constructor = null;
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
			Endpoint_Address.TypeLazy = () => global::MetaDslx.Core.MetaInstance.String.ToMutable();
			Endpoint_Address.Name = "Address";
			Endpoint_Address.Documentation = null;
			// Endpoint_Address.Kind = null;
			Endpoint_Address.ClassLazy = () => Endpoint;
			BindingElement.MetaModelLazy = () => __tmp3;
			BindingElement.NamespaceLazy = () => __tmp2;
			BindingElement.Documentation = null;
			BindingElement.Name = "BindingElement";
			BindingElement.IsAbstract = true;
			BindingElement.SuperClasses.AddLazy(() => NamedElement);
			// BindingElement.Constructor = null;
			TransportBindingElement.MetaModelLazy = () => __tmp3;
			TransportBindingElement.NamespaceLazy = () => __tmp2;
			TransportBindingElement.Documentation = null;
			TransportBindingElement.Name = "TransportBindingElement";
			TransportBindingElement.IsAbstract = true;
			TransportBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// TransportBindingElement.Constructor = null;
			EncodingBindingElement.MetaModelLazy = () => __tmp3;
			EncodingBindingElement.NamespaceLazy = () => __tmp2;
			EncodingBindingElement.Documentation = null;
			EncodingBindingElement.Name = "EncodingBindingElement";
			EncodingBindingElement.IsAbstract = true;
			EncodingBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// EncodingBindingElement.Constructor = null;
			ProtocolBindingElement.MetaModelLazy = () => __tmp3;
			ProtocolBindingElement.NamespaceLazy = () => __tmp2;
			ProtocolBindingElement.Documentation = null;
			ProtocolBindingElement.Name = "ProtocolBindingElement";
			ProtocolBindingElement.IsAbstract = true;
			ProtocolBindingElement.SuperClasses.AddLazy(() => BindingElement);
			// ProtocolBindingElement.Constructor = null;
			HttpTransportBindingElement.MetaModelLazy = () => __tmp3;
			HttpTransportBindingElement.NamespaceLazy = () => __tmp2;
			HttpTransportBindingElement.Documentation = null;
			HttpTransportBindingElement.Name = "HttpTransportBindingElement";
			// HttpTransportBindingElement.IsAbstract = null;
			HttpTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			// HttpTransportBindingElement.Constructor = null;
			RestTransportBindingElement.MetaModelLazy = () => __tmp3;
			RestTransportBindingElement.NamespaceLazy = () => __tmp2;
			RestTransportBindingElement.Documentation = null;
			RestTransportBindingElement.Name = "RestTransportBindingElement";
			// RestTransportBindingElement.IsAbstract = null;
			RestTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			// RestTransportBindingElement.Constructor = null;
			WebSocketTransportBindingElement.MetaModelLazy = () => __tmp3;
			WebSocketTransportBindingElement.NamespaceLazy = () => __tmp2;
			WebSocketTransportBindingElement.Documentation = null;
			WebSocketTransportBindingElement.Name = "WebSocketTransportBindingElement";
			// WebSocketTransportBindingElement.IsAbstract = null;
			WebSocketTransportBindingElement.SuperClasses.AddLazy(() => TransportBindingElement);
			// WebSocketTransportBindingElement.Constructor = null;
			SoapVersion.MetaModelLazy = () => __tmp3;
			SoapVersion.NamespaceLazy = () => __tmp2;
			SoapVersion.Documentation = null;
			SoapVersion.Name = "SoapVersion";
			SoapVersion.EnumLiterals.AddLazy(() => __tmp55);
			SoapVersion.EnumLiterals.AddLazy(() => __tmp56);
			__tmp55.TypeLazy = () => SoapVersion;
			__tmp55.Name = "Soap11";
			__tmp55.Documentation = null;
			__tmp55.EnumLazy = () => SoapVersion;
			__tmp56.TypeLazy = () => SoapVersion;
			__tmp56.Name = "Soap12";
			__tmp56.Documentation = null;
			__tmp56.EnumLazy = () => SoapVersion;
			SoapEncodingBindingElement.MetaModelLazy = () => __tmp3;
			SoapEncodingBindingElement.NamespaceLazy = () => __tmp2;
			SoapEncodingBindingElement.Documentation = null;
			SoapEncodingBindingElement.Name = "SoapEncodingBindingElement";
			// SoapEncodingBindingElement.IsAbstract = null;
			SoapEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_Version);
			SoapEncodingBindingElement.Properties.AddLazy(() => SoapEncodingBindingElement_MtomEnabled);
			// SoapEncodingBindingElement.Constructor = null;
			SoapEncodingBindingElement_Version.TypeLazy = () => SoapVersion;
			SoapEncodingBindingElement_Version.Name = "Version";
			SoapEncodingBindingElement_Version.Documentation = null;
			// SoapEncodingBindingElement_Version.Kind = null;
			SoapEncodingBindingElement_Version.ClassLazy = () => SoapEncodingBindingElement;
			SoapEncodingBindingElement_MtomEnabled.TypeLazy = () => global::MetaDslx.Core.MetaInstance.Bool.ToMutable();
			SoapEncodingBindingElement_MtomEnabled.Name = "MtomEnabled";
			SoapEncodingBindingElement_MtomEnabled.Documentation = null;
			// SoapEncodingBindingElement_MtomEnabled.Kind = null;
			SoapEncodingBindingElement_MtomEnabled.ClassLazy = () => SoapEncodingBindingElement;
			XmlEncodingBindingElement.MetaModelLazy = () => __tmp3;
			XmlEncodingBindingElement.NamespaceLazy = () => __tmp2;
			XmlEncodingBindingElement.Documentation = null;
			XmlEncodingBindingElement.Name = "XmlEncodingBindingElement";
			// XmlEncodingBindingElement.IsAbstract = null;
			XmlEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			// XmlEncodingBindingElement.Constructor = null;
			JsonEncodingBindingElement.MetaModelLazy = () => __tmp3;
			JsonEncodingBindingElement.NamespaceLazy = () => __tmp2;
			JsonEncodingBindingElement.Documentation = null;
			JsonEncodingBindingElement.Name = "JsonEncodingBindingElement";
			// JsonEncodingBindingElement.IsAbstract = null;
			JsonEncodingBindingElement.SuperClasses.AddLazy(() => EncodingBindingElement);
			// JsonEncodingBindingElement.Constructor = null;
			WsProtocolBindingElement.MetaModelLazy = () => __tmp3;
			WsProtocolBindingElement.NamespaceLazy = () => __tmp2;
			WsProtocolBindingElement.Documentation = null;
			WsProtocolBindingElement.Name = "WsProtocolBindingElement";
			WsProtocolBindingElement.IsAbstract = true;
			WsProtocolBindingElement.SuperClasses.AddLazy(() => ProtocolBindingElement);
			// WsProtocolBindingElement.Constructor = null;
			WsAddressingBindingElement.MetaModelLazy = () => __tmp3;
			WsAddressingBindingElement.NamespaceLazy = () => __tmp2;
			WsAddressingBindingElement.Documentation = null;
			WsAddressingBindingElement.Name = "WsAddressingBindingElement";
			// WsAddressingBindingElement.IsAbstract = null;
			WsAddressingBindingElement.SuperClasses.AddLazy(() => WsProtocolBindingElement);
			// WsAddressingBindingElement.Constructor = null;
	
			foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)
			{
				symbol.MMakeCreated();
			}
		}
	}

	/// <summary>
	/// Base class for implementing the behavior of the model elements.
	/// This class has to be be overriden in global::MetaDslx.Soal.Internal.SoalImplementation to provide custom
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
			this.NamedElement(_this);
			this.Declaration(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Declaration()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Namespace</li>
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
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Namespace</li>
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
		/// Implements the constructor: PrimitiveType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>NamedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
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
			this.NamedElement(_this);
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
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: StructuredType()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>SoalType</li>
		///     <li>Declaration</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		/// </ul>
		public virtual void StructuredType(StructuredTypeBuilder _this)
		{
			this.CallStructuredTypeSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of StructuredType
		/// </summary>
		protected virtual void CallStructuredTypeSuperConstructors(StructuredTypeBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Property()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>TypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Struct()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>StructuredType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		///     <li>StructuredType</li>
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
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
			this.StructuredType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Exception()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>StructuredType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		///     <li>StructuredType</li>
		/// </ul>
		public virtual void Exception(ExceptionBuilder _this)
		{
			this.CallExceptionSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Exception
		/// </summary>
		protected virtual void CallExceptionSuperConstructors(ExceptionBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
			this.StructuredType(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Entity()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>StructuredType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>Declaration</li>
		///     <li>SoalType</li>
		///     <li>StructuredType</li>
		/// </ul>
		public virtual void Entity(EntityBuilder _this)
		{
			this.CallEntitySuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Entity
		/// </summary>
		protected virtual void CallEntitySuperConstructors(EntityBuilder _this)
		{
			this.NamedElement(_this);
			this.Declaration(_this);
			this.SoalType(_this);
			this.StructuredType(_this);
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
		/// </ul>
		/// All superclasses:
		/// <ul>
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
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Parameter()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>NamedElement</li>
		///     <li>TypedElement</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>TypedElement</li>
		///     <li>NamedElement</li>
		/// </ul>
		public virtual void Parameter(ParameterBuilder _this)
		{
			this.CallParameterSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of Parameter
		/// </summary>
		protected virtual void CallParameterSuperConstructors(ParameterBuilder _this)
		{
			this.TypedElement(_this);
			this.NamedElement(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Component()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>Declaration</li>
		///     <li>StructuredType</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>SoalType</li>
		///     <li>NamedElement</li>
		///     <li>StructuredType</li>
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
			this.SoalType(_this);
			this.NamedElement(_this);
			this.StructuredType(_this);
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
		///     <li>SoalType</li>
		///     <li>NamedElement</li>
		///     <li>StructuredType</li>
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
			this.SoalType(_this);
			this.NamedElement(_this);
			this.StructuredType(_this);
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
		///     <li>SoalType</li>
		///     <li>NamedElement</li>
		///     <li>StructuredType</li>
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
			this.SoalType(_this);
			this.NamedElement(_this);
			this.StructuredType(_this);
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
		/// Implements the constructor: InterfaceReference()
		/// </summary>
		/// Initializes the following derived properties:
		/// <ul>
		///     <li>Name</li>
		/// </ul>
		public virtual void InterfaceReference(InterfaceReferenceBuilder _this)
		{
			this.CallInterfaceReferenceSuperConstructors(_this);
		}
	
		/// <summary>
		/// Calls the super constructors of InterfaceReference
		/// </summary>
		protected virtual void CallInterfaceReferenceSuperConstructors(InterfaceReferenceBuilder _this)
		{
		}
	
	
		/// <summary>
		/// Implements the constructor: Service()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>InterfaceReference</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>InterfaceReference</li>
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
			this.InterfaceReference(_this);
		}
	
	
		/// <summary>
		/// Implements the constructor: Reference()
		/// </summary>
		/// Direct superclasses: 
		/// <ul>
		///     <li>InterfaceReference</li>
		/// </ul>
		/// All superclasses:
		/// <ul>
		///     <li>InterfaceReference</li>
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
			this.InterfaceReference(_this);
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
		// which is a subclass of global::MetaDslx.Soal.Internal.SoalImplementationBase:
		private static SoalImplementation implementation = new SoalImplementation();
	
		public static SoalImplementation Implementation
		{
			get { return implementation; }
		}
	}
}
