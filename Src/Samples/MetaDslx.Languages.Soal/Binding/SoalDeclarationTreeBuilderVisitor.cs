// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Languages.Soal.Syntax;

namespace MetaDslx.Languages.Soal.Binding
{
	public class SoalDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ISoalSyntaxVisitor
	{
        protected SoalDeclarationTreeBuilderVisitor(SoalSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            SoalSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new SoalDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), typeof(Symbols.Namespace));
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				foreach (var child in node.NamespaceDeclaration)
				{
					this.Visit(child);
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName();
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName();
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier();
			try
			{
				foreach (var child in node.Identifier)
				{
					this.Visit(child);
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
			foreach (var child in node.Identifier)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitQualifierList(QualifierListSyntax node)
		{
			foreach (var child in node.Qualifier)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitAnnotationList(AnnotationListSyntax node)
		{
			foreach (var child in node.Annotation)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			foreach (var child in node.ReturnAnnotation)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
			this.BeginProperty("Annotations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Annotation), node);
				try
				{
					this.Visit(node.AnnotationHead);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			this.BeginProperty("Annotations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Annotation), node);
				try
				{
					this.Visit(node.AnnotationHead);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			this.Visit(node.Name);
			this.Visit(node.AnnotationBody);
		}
		
		public virtual void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			this.Visit(node.AnnotationPropertyList);
		}
		
		public virtual void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			foreach (var child in node.AnnotationProperty)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.BeginDeclaration(typeof(Symbols.AnnotationProperty), node);
				try
				{
					this.Visit(node.Name);
					this.BeginProperty("Value");
					try
					{
						this.Visit(node.AnnotationPropertyValue);
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			this.Visit(node.ConstantValue);
			this.Visit(node.TypeofValue);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Namespace), node);
			try
			{
				this.RegisterNestingProperty("Declarations");
				this.RegisterCanMerge(true);
				this.Visit(node.AnnotationList);
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			foreach (var child in node.Declaration)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.Visit(node.EnumDeclaration);
				this.Visit(node.StructDeclaration);
				this.Visit(node.DatabaseDeclaration);
				this.Visit(node.InterfaceDeclaration);
				this.Visit(node.ComponentDeclaration);
				this.Visit(node.CompositeDeclaration);
				this.Visit(node.AssemblyDeclaration);
				this.Visit(node.BindingDeclaration);
				this.Visit(node.EndpointDeclaration);
				this.Visit(node.DeploymentDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Enum), node);
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.EnumBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.Visit(node.EnumLiterals);
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			foreach (var child in node.EnumLiteral)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.BeginProperty("EnumLiterals");
			try
			{
				this.BeginDeclaration(typeof(Symbols.EnumLiteral), node);
				try
				{
					this.Visit(node.AnnotationList);
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Struct), node);
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.StructBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitStructBody(StructBodySyntax node)
		{
			foreach (var child in node.PropertyDeclaration)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Property), node);
				try
				{
					this.Visit(node.AnnotationList);
					this.BeginProperty("Type");
					try
					{
						this.Visit(node.TypeReference);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Database), node);
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.DatabaseBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			foreach (var child in node.EntityReference)
			{
				this.Visit(child);
			}
			foreach (var child in node.OperationDeclaration)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.BeginProperty("Entities");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Interface), node);
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.Name);
				this.Visit(node.InterfaceBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			foreach (var child in node.OperationDeclaration)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginProperty("Operations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Operation), node);
				try
				{
					this.Visit(node.OperationHead);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitOperationHead(OperationHeadSyntax node)
		{
			this.Visit(node.AnnotationList);
			this.Visit(node.OperationResult);
			this.Visit(node.Name);
			this.Visit(node.ParameterList);
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			foreach (var child in node.Parameter)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.BeginProperty("Parameters");
			try
			{
				this.BeginDeclaration(typeof(Symbols.InputParameter), node);
				try
				{
					this.Visit(node.AnnotationList);
					this.BeginProperty("Type");
					try
					{
						this.Visit(node.TypeReference);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitOperationResult(OperationResultSyntax node)
		{
			this.BeginProperty("Result");
			try
			{
				this.BeginDeclaration(typeof(Symbols.OutputParameter), node);
				try
				{
					this.Visit(node.ReturnAnnotationList);
					this.Visit(node.OperationReturnType);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Component), node);
			try
			{
				if (node.KAbstract != null)
				{
					switch (((SoalSyntaxToken)node.KAbstract).Kind)
					{
						default:
							break;
					}
				}
				this.Visit(node.Name);
				this.Visit(node.ComponentBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitComponentBody(ComponentBodySyntax node)
		{
			this.Visit(node.ComponentElements);
		}
		
		public virtual void VisitComponentElements(ComponentElementsSyntax node)
		{
			foreach (var child in node.ComponentElement)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitComponentElement(ComponentElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
			this.Visit(node.ComponentLanguage);
		}
		
		public virtual void VisitComponentService(ComponentServiceSyntax node)
		{
			this.BeginProperty("Services");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Service), node);
				try
				{
					this.Visit(node.Name);
					this.Visit(node.ComponentServiceOrReferenceBody);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentReference(ComponentReferenceSyntax node)
		{
			this.BeginProperty("References");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Reference), node);
				try
				{
					this.Visit(node.Name);
					this.Visit(node.ComponentServiceOrReferenceBody);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			foreach (var child in node.ComponentServiceOrReferenceElement)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		}
		
		public virtual void VisitComponentProperty(ComponentPropertySyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Property), node);
				try
				{
					this.BeginProperty("Type");
					try
					{
						this.Visit(node.TypeReference);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			this.BeginProperty("Implementation");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Implementation), node);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			this.BeginProperty("Language");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Language), node);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Composite), node);
			try
			{
				this.Visit(node.Name);
				this.Visit(node.CompositeBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitCompositeBody(CompositeBodySyntax node)
		{
			this.Visit(node.CompositeElements);
		}
		
		public virtual void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Assembly), node);
			try
			{
				this.Visit(node.Name);
				this.Visit(node.CompositeBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitCompositeElements(CompositeElementsSyntax node)
		{
			foreach (var child in node.CompositeElement)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitCompositeElement(CompositeElementSyntax node)
		{
			this.Visit(node.ComponentService);
			this.Visit(node.ComponentReference);
			this.Visit(node.ComponentProperty);
			this.Visit(node.ComponentImplementation);
			this.Visit(node.ComponentLanguage);
			this.Visit(node.CompositeComponent);
			this.Visit(node.CompositeWire);
		}
		
		public virtual void VisitCompositeComponent(CompositeComponentSyntax node)
		{
			this.BeginProperty("Components");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCompositeWire(CompositeWireSyntax node)
		{
			this.BeginProperty("Wires");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Wire), node);
				try
				{
					this.Visit(node.WireSource);
					this.Visit(node.WireTarget);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitWireSource(WireSourceSyntax node)
		{
		}
		
		public virtual void VisitWireTarget(WireTargetSyntax node)
		{
		}
		
		public virtual void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Deployment), node);
			try
			{
				this.Visit(node.Name);
				this.Visit(node.DeploymentBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitDeploymentBody(DeploymentBodySyntax node)
		{
			this.Visit(node.DeploymentElements);
		}
		
		public virtual void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			foreach (var child in node.DeploymentElement)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			this.Visit(node.EnvironmentDeclaration);
			this.Visit(node.CompositeWire);
		}
		
		public virtual void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			this.BeginProperty("Environments");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Environment), node);
				try
				{
					this.Visit(node.Name);
					this.Visit(node.EnvironmentBody);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
			this.Visit(node.RuntimeDeclaration);
			foreach (var child in node.RuntimeReference)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			this.BeginProperty("Runtime");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Runtime), node);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			this.Visit(node.AssemblyReference);
			this.Visit(node.DatabaseReference);
		}
		
		public virtual void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.BeginProperty("Assemblies");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			this.BeginProperty("Databases");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Binding), node);
			try
			{
				this.Visit(node.Name);
				this.Visit(node.BindingBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitBindingBody(BindingBodySyntax node)
		{
			this.Visit(node.BindingLayers);
		}
		
		public virtual void VisitBindingLayers(BindingLayersSyntax node)
		{
			this.Visit(node.TransportLayer);
			foreach (var child in node.EncodingLayer)
			{
				this.Visit(child);
			}
			foreach (var child in node.ProtocolLayer)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitTransportLayer(TransportLayerSyntax node)
		{
			this.BeginProperty("Transport");
			try
			{
				this.Visit(node.HttpTransportLayer);
				this.Visit(node.RestTransportLayer);
				this.Visit(node.WebSocketTransportLayer);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.HttpTransportBindingElement), node);
			try
			{
				this.Visit(node.HttpTransportLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			foreach (var child in node.HttpTransportLayerProperties)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.RestTransportBindingElement), node);
			try
			{
				this.Visit(node.RestTransportLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.WebSocketTransportBindingElement), node);
			try
			{
				this.Visit(node.WebSocketTransportLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			this.Visit(node.HttpSslProperty);
			this.Visit(node.HttpClientAuthenticationProperty);
		}
		
		public virtual void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			this.BeginProperty("Ssl");
			try
			{
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			this.BeginProperty("ClientAuthentication");
			try
			{
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			this.BeginProperty("Encodings");
			try
			{
				this.Visit(node.SoapEncodingLayer);
				this.Visit(node.XmlEncodingLayer);
				this.Visit(node.JsonEncodingLayer);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.SoapEncodingBindingElement), node);
			try
			{
				this.Visit(node.SoapEncodingLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			foreach (var child in node.SoapEncodingProperties)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.XmlEncodingBindingElement), node);
			try
			{
				this.Visit(node.XmlEncodingLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.JsonEncodingBindingElement), node);
			try
			{
				this.Visit(node.JsonEncodingLayerBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			this.Visit(node.SoapVersionProperty);
			this.Visit(node.SoapMtomProperty);
			this.Visit(node.SoapStyleProperty);
		}
		
		public virtual void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			this.BeginProperty("Version");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			this.BeginProperty("Mtom");
			try
			{
				this.Visit(node.BooleanLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			this.BeginProperty("Style");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			this.BeginProperty("Protocols");
			try
			{
				this.Visit(node.ProtocolLayerKind);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			this.Visit(node.WsAddressing);
		}
		
		public virtual void VisitWsAddressing(WsAddressingSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.WsAddressingBindingElement), node);
			try
			{
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Endpoint), node);
			try
			{
				this.Visit(node.Name);
				this.Visit(node.EndpointBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEndpointBody(EndpointBodySyntax node)
		{
			this.Visit(node.EndpointProperties);
		}
		
		public virtual void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			foreach (var child in node.EndpointProperty)
			{
				this.Visit(child);
			}
		}
		
		public virtual void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			this.Visit(node.EndpointBindingProperty);
			this.Visit(node.EndpointAddressProperty);
		}
		
		public virtual void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		}
		
		public virtual void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			this.BeginProperty("Address");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
		}
		
		public virtual void VisitNulledType(NulledTypeSyntax node)
		{
		}
		
		public virtual void VisitReferenceType(ReferenceTypeSyntax node)
		{
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
		}
		
		public virtual void VisitValueType(ValueTypeSyntax node)
		{
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		}
		
		public virtual void VisitOnewayType(OnewayTypeSyntax node)
		{
		}
		
		public virtual void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.BeginProperty("Type");
			try
			{
				this.Visit(node.ReturnType);
				this.Visit(node.OnewayType);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		}
		
		public virtual void VisitNonNullableType(NonNullableTypeSyntax node)
		{
		}
		
		public virtual void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
			this.Visit(node.SimpleArrayType);
			this.Visit(node.NulledArrayType);
		}
		
		public virtual void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		}
		
		public virtual void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		}
		
		public virtual void VisitConstantValue(ConstantValueSyntax node)
		{
			this.Visit(node.Literal);
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitTypeofValue(TypeofValueSyntax node)
		{
			this.Visit(node.ReturnType);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitIdentifiers(IdentifiersSyntax node)
		{
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
			this.Visit(node.StringLiteral);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
		
		public virtual void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		}
	}
}

