using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Languages.Soal.Syntax;

namespace MetaDslx.Languages.Soal.Binder
{
	public class SoalDeclarationTreeBuilder : DeclarationTreeBuilder, ISoalSyntaxVisitor
	{
        protected SoalDeclarationTreeBuilder(SoalSyntaxTree syntaxTree, string scriptClassName, bool isSubmission, bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
            : base(syntaxTree, scriptClassName, isSubmission, visitIntoStructuredToken, visitIntoStructuredTrivia)
        {
        }

        public static RootSingleDeclaration ForTree(
            SoalSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new SoalDeclarationTreeBuilder(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), typeof(Symbols.Namespace));
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.VisitList(node.NamespaceDeclaration);
			this.VisitToken(node.Eof);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginQualifiedName();
			try
			{
				this.VisitList(node.Identifier);
			}
			finally
			{
				this.EndQualifiedName();
			}
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public virtual void VisitQualifiedNameList(QualifiedNameListSyntax node)
		{
			this.VisitList(node.QualifiedName);
		}
		
		public virtual void VisitAnnotationList(AnnotationListSyntax node)
		{
			this.VisitList(node.Annotation);
		}
		
		public virtual void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			this.VisitList(node.ReturnAnnotation);
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.TOpenBracket);
				this.Visit(node.AnnotationBody);
				this.VisitToken(node.TCloseBracket);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.TOpenBracket);
				this.VisitToken(node.KReturn);
				this.VisitToken(node.TColon);
				this.Visit(node.AnnotationBody);
				this.VisitToken(node.TCloseBracket);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			this.Visit(node.NameDef);
			this.Visit(node.AnnotationProperties);
		}
		
		public virtual void VisitAnnotationProperties(AnnotationPropertiesSyntax node)
		{
			this.VisitToken(node.TOpenParen);
			this.Visit(node.AnnotationPropertyList);
			this.VisitToken(node.TCloseParen);
		}
		
		public virtual void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			this.VisitList(node.AnnotationProperty);
		}
		
		public virtual void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.NameDef);
				this.VisitToken(node.TAssign);
				this.Visit(node.AnnotationPropertyValue);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			this.Visit(node.ConstantValue);
			this.Visit(node.TypeofValue);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Namespace));
			try
			{
				this.Visit(node.AnnotationList);
				this.VisitToken(node.KNamespace);
				this.Visit(node.QualifiedNameDef);
				this.VisitToken(node.TAssign);
				this.Visit(node.Identifier);
				this.VisitToken(node.TColon);
				this.Visit(node.StringLiteral);
				this.VisitToken(node.TOpenBrace);
				this.VisitList(node.Declaration);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
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
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Enum));
			try
			{
				this.Visit(node.AnnotationList);
				this.VisitToken(node.KEnum);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.EnumLiterals);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			this.VisitList(node.EnumLiteral);
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.EnumLiteral));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.NameDef);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Struct));
			try
			{
				this.Visit(node.AnnotationList);
				this.VisitToken(node.KStruct);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.VisitList(node.PropertyDeclaration);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Property));
			try
			{
				this.Visit(node.AnnotationList);
				this.BeginSymbol();
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndSymbol();
				}
				this.Visit(node.NameDef);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Database));
			try
			{
				this.Visit(node.AnnotationList);
				this.VisitToken(node.KDatabase);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenBrace);
				this.VisitList(node.EntityReference);
				this.VisitList(node.OperationDeclaration);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.VisitToken(node.KEntity);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Interface));
			try
			{
				this.Visit(node.AnnotationList);
				this.VisitToken(node.KInterface);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenBrace);
				this.VisitList(node.OperationDeclaration);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Operation));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.OperationResult);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenParen);
				this.Visit(node.ParameterList);
				this.VisitToken(node.TCloseParen);
				this.VisitToken(node.KThrows);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedNameList);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			this.VisitList(node.Parameter);
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.InputParameter));
			try
			{
				this.Visit(node.AnnotationList);
				this.BeginSymbol();
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndSymbol();
				}
				this.Visit(node.NameDef);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitOperationResult(OperationResultSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.ReturnAnnotationList);
				this.Visit(node.OperationReturnType);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Component));
			try
			{
				this.VisitToken(node.KAbstract);
				this.VisitToken(node.KComponent);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.ComponentElements);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitComponentElements(ComponentElementsSyntax node)
		{
			this.VisitList(node.ComponentElement);
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
			this.BeginDeclaration(typeof(Symbols.Service));
			try
			{
				this.VisitToken(node.KService);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.Visit(node.NameDef);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitComponentReference(ComponentReferenceSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Reference));
			try
			{
				this.VisitToken(node.KReference);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.Visit(node.NameDef);
				this.Visit(node.ComponentServiceOrReferenceBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.ComponentServiceOrReferenceElement);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.VisitToken(node.KBinding);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitComponentProperty(ComponentPropertySyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Property));
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndSymbol();
				}
				this.Visit(node.NameDef);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Implementation));
			try
			{
				this.VisitToken(node.KImplementation);
				this.Visit(node.NameDef);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Language));
			try
			{
				this.VisitToken(node.KLanguage);
				this.Visit(node.NameDef);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Composite));
			try
			{
				this.VisitToken(node.KComposite);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.CompositeElements);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Assembly));
			try
			{
				this.VisitToken(node.KAssembly);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.CompositeElements);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitCompositeElements(CompositeElementsSyntax node)
		{
			this.VisitList(node.CompositeElement);
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
			this.VisitToken(node.KComponent);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitCompositeWire(CompositeWireSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KWire);
				this.Visit(node.WireSource);
				this.VisitToken(node.KTo);
				this.Visit(node.WireTarget);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitWireSource(WireSourceSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitWireTarget(WireTargetSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Deployment));
			try
			{
				this.VisitToken(node.KDeployment);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.DeploymentElements);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
			this.VisitList(node.DeploymentElement);
		}
		
		public virtual void VisitDeploymentElement(DeploymentElementSyntax node)
		{
			this.Visit(node.EnvironmentDeclaration);
			this.Visit(node.CompositeWire);
		}
		
		public virtual void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Environment));
			try
			{
				this.VisitToken(node.KEnvironment);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.RuntimeDeclaration);
				this.VisitList(node.RuntimeReference);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Runtime));
			try
			{
				this.VisitToken(node.KRuntime);
				this.Visit(node.NameDef);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			this.Visit(node.AssemblyReference);
			this.Visit(node.DatabaseReference);
		}
		
		public virtual void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
			this.VisitToken(node.KAssembly);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
			this.VisitToken(node.KDatabase);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Binding));
			try
			{
				this.VisitToken(node.KBinding);
				this.Visit(node.NameDef);
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.BindingLayers);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitBindingLayers(BindingLayersSyntax node)
		{
			this.Visit(node.TransportLayer);
			this.VisitList(node.EncodingLayer);
			this.VisitList(node.ProtocolLayer);
		}
		
		public virtual void VisitTransportLayer(TransportLayerSyntax node)
		{
			this.Visit(node.HttpTransportLayer);
			this.Visit(node.RestTransportLayer);
			this.Visit(node.WebSocketTransportLayer);
		}
		
		public virtual void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KTransport);
				this.VisitToken(node.IHTTP);
				this.Visit(node.HttpTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.HttpTransportLayerProperties);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KTransport);
				this.VisitToken(node.IREST);
				this.Visit(node.RestTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KTransport);
				this.VisitToken(node.IWebSocket);
				this.Visit(node.WebSocketTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			this.Visit(node.HttpSslProperty);
			this.Visit(node.HttpClientAuthenticationProperty);
		}
		
		public virtual void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
			this.VisitToken(node.ISSL);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
			this.VisitToken(node.IClientAuthentication);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitEncodingLayer(EncodingLayerSyntax node)
		{
			this.Visit(node.SoapEncodingLayer);
			this.Visit(node.XmlEncodingLayer);
			this.Visit(node.JsonEncodingLayer);
		}
		
		public virtual void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KEncoding);
				this.VisitToken(node.ISOAP);
				this.Visit(node.SoapEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.SoapEncodingProperties);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KEncoding);
				this.VisitToken(node.IXML);
				this.Visit(node.XmlEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KEncoding);
				this.VisitToken(node.IJSON);
				this.Visit(node.JsonEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			this.Visit(node.SoapVersionProperty);
			this.Visit(node.SoapMtomProperty);
			this.Visit(node.SoapStyleProperty);
		}
		
		public virtual void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
			this.VisitToken(node.IVersion);
			this.VisitToken(node.TAssign);
			this.Visit(node.Identifier);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
			this.VisitToken(node.IMTOM);
			this.VisitToken(node.TAssign);
			this.Visit(node.BooleanLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
			this.VisitToken(node.IStyle);
			this.VisitToken(node.TAssign);
			this.Visit(node.Identifier);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.VisitToken(node.KProtocol);
				this.Visit(node.ProtocolLayerKind);
				this.VisitToken(node.TSemicolon);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
			if (node.Identifier != null) this.RegisterDeclarationType(typeof(Symbols.WsAddressingBindingElement));
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Endpoint));
			try
			{
				this.VisitToken(node.KEndpoint);
				this.Visit(node.NameDef);
				this.VisitToken(node.TColon);
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedName);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBrace);
				this.Visit(node.EndpointProperties);
				this.VisitToken(node.TCloseBrace);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.Children);
			}
		}
		
		public virtual void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			this.VisitList(node.EndpointProperty);
		}
		
		public virtual void VisitEndpointProperty(EndpointPropertySyntax node)
		{
			this.Visit(node.EndpointBindingProperty);
			this.Visit(node.EndpointAddressProperty);
		}
		
		public virtual void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
			this.VisitToken(node.KBinding);
			this.BeginSymbol();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
			this.VisitToken(node.KAddress);
			this.Visit(node.StringLiteral);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.Visit(node.TypeReference);
			this.Visit(node.VoidType);
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.Visit(node.NonNullableArrayType);
			this.Visit(node.ArrayType);
			this.Visit(node.SimpleType);
			this.Visit(node.NulledType);
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.Visit(node.ValueType);
			this.Visit(node.ObjectType);
			this.Visit(node.QualifiedName);
		}
		
		public virtual void VisitNulledType(NulledTypeSyntax node)
		{
			this.Visit(node.NullableType);
			this.Visit(node.NonNullableType);
		}
		
		public virtual void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.Visit(node.ObjectType);
			this.Visit(node.QualifiedName);
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			this.VisitToken(node.ObjectType);
		}
		
		public virtual void VisitValueType(ValueTypeSyntax node)
		{
			this.VisitToken(node.ValueType);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			this.VisitToken(node.KVoid);
		}
		
		public virtual void VisitOnewayType(OnewayTypeSyntax node)
		{
			this.VisitToken(node.KOneway);
		}
		
		public virtual void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.ReturnType);
			}
			finally
			{
				this.EndSymbol();
			}
			this.Visit(node.OnewayType);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.ValueType);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TQuestion);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.ReferenceType);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TExclamation);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.ArrayType);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TExclamation);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
			this.Visit(node.SimpleArrayType);
			this.Visit(node.NulledArrayType);
		}
		
		public virtual void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.SimpleType);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBracket);
				this.VisitToken(node.TCloseBracket);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.NulledType);
				}
				finally
				{
					this.EndSymbol();
				}
				this.VisitToken(node.TOpenBracket);
				this.VisitToken(node.TCloseBracket);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitConstantValue(ConstantValueSyntax node)
		{
			this.Visit(node.Literal);
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitTypeofValue(TypeofValueSyntax node)
		{
			this.VisitToken(node.KTypeof);
			this.VisitToken(node.TOpenParen);
			this.BeginSymbol();
			try
			{
				this.Visit(node.ReturnType);
			}
			finally
			{
				this.EndSymbol();
			}
			this.VisitToken(node.TCloseParen);
		}
		
		public virtual void VisitNameDef(NameDefSyntax node)
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
		
		public virtual void VisitQualifiedNameDef(QualifiedNameDefSyntax node)
		{
			this.BeginName();
			try
			{
				this.Visit(node.QualifiedName);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
			this.Visit(node.Identifiers);
			this.Visit(node.ContextualKeywords);
		}
		
		public virtual void VisitIdentifiers(IdentifiersSyntax node)
		{
			this.VisitToken(node.Identifiers);
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
			this.VisitToken(node.KNull);
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.VisitToken(node.BooleanLiteral);
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.VisitToken(node.LInteger);
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.VisitToken(node.LDecimal);
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.VisitToken(node.LScientific);
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.VisitToken(node.StringLiteral);
		}
		
		public virtual void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
			this.VisitToken(node.ContextualKeywords);
		}
	}
}

