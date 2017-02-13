using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Languages.Soal.Syntax;

namespace MetaDslx.Languages.Soal.Binding
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
			this.BeginProperty("Declarations");
			try
			{
				this.VisitList(node.NamespaceDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
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
			this.BeginProperty("Annotations");
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.AnnotationHead);
				}
				finally
				{
					this.EndSymbol();
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
				this.BeginSymbol();
				try
				{
					this.Visit(node.AnnotationHead);
				}
				finally
				{
					this.EndSymbol();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
			this.BeginProperty("Name");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
			this.Visit(node.AnnotationBody);
		}
		
		public virtual void VisitAnnotationBody(AnnotationBodySyntax node)
		{
			this.Visit(node.AnnotationPropertyList);
		}
		
		public virtual void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
			this.VisitList(node.AnnotationProperty);
		}
		
		public virtual void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.BeginSymbol();
				try
				{
					this.BeginProperty("Name");
					try
					{
						this.Visit(node.Identifier);
					}
					finally
					{
						this.EndProperty();
					}
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
					this.EndSymbol();
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
			this.BeginDeclaration(typeof(Symbols.Namespace));
			try
			{
				this.RegisterNestingProperty("Declarations");
				this.RegisterCanMerge(true);
				this.Visit(node.AnnotationList);
				this.Visit(node.QualifiedNameDef);
				this.BeginProperty("Prefix");
				try
				{
					this.Visit(node.Identifier);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty("Uri");
				try
				{
					this.Visit(node.StringLiteral);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.VisitList(node.Declaration);
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
			this.BeginDeclaration(typeof(Symbols.Enum));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.NameDef);
				this.BeginProperty("BaseType");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.EnumBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.Visit(node.EnumLiterals);
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			this.VisitList(node.EnumLiteral);
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.BeginProperty("EnumLiterals");
			try
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
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Struct));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.NameDef);
				this.BeginProperty("BaseType");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.StructBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitStructBody(StructBodySyntax node)
		{
			this.VisitList(node.PropertyDeclaration);
		}
		
		public virtual void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
			this.BeginProperty("Properties");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Property));
				try
				{
					this.Visit(node.AnnotationList);
					this.BeginProperty("Type");
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
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.NameDef);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Database));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.NameDef);
				this.Visit(node.DatabaseBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitDatabaseBody(DatabaseBodySyntax node)
		{
			this.VisitList(node.EntityReference);
			this.VisitList(node.OperationDeclaration);
		}
		
		public virtual void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.BeginProperty("Entities");
			try
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Interface));
			try
			{
				this.Visit(node.AnnotationList);
				this.Visit(node.NameDef);
				this.Visit(node.InterfaceBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitInterfaceBody(InterfaceBodySyntax node)
		{
			this.VisitList(node.OperationDeclaration);
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginProperty("Operations");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Operation));
				try
				{
					this.Visit(node.OperationHead);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			this.Visit(node.NameDef);
			this.Visit(node.ParameterList);
			this.BeginProperty("Exceptions");
			try
			{
				this.BeginSymbol();
				try
				{
					this.Visit(node.QualifiedNameList);
				}
				finally
				{
					this.EndSymbol();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			this.VisitList(node.Parameter);
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.BeginProperty("Parameters");
			try
			{
				this.BeginDeclaration(typeof(Symbols.InputParameter));
				try
				{
					this.Visit(node.AnnotationList);
					this.BeginProperty("Type");
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
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.NameDef);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Component));
			try
			{
				this.BeginProperty("IsAbstract");
				try
				{
					this.VisitToken(node.KAbstract);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.NameDef);
				this.BeginProperty("BaseComponent");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.ComponentBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitComponentBody(ComponentBodySyntax node)
		{
			this.Visit(node.ComponentElements);
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
			this.BeginProperty("Services");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Service));
				try
				{
					this.BeginProperty("Interface");
					try
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
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.NameDef);
					this.Visit(node.ComponentServiceOrReferenceBody);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
				this.BeginDeclaration(typeof(Symbols.Reference));
				try
				{
					this.BeginProperty("Interface");
					try
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
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.NameDef);
					this.Visit(node.ComponentServiceOrReferenceBody);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			this.VisitList(node.ComponentServiceOrReferenceElement);
		}
		
		public virtual void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.BeginProperty("Binding");
			try
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComponentProperty(ComponentPropertySyntax node)
		{
			this.BeginProperty("Properties");
			try
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
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
				this.BeginDeclaration(typeof(Symbols.Implementation));
				try
				{
					this.Visit(node.NameDef);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
				this.BeginDeclaration(typeof(Symbols.Language));
				try
				{
					this.Visit(node.NameDef);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Composite));
			try
			{
				this.Visit(node.NameDef);
				this.BeginProperty("BaseComponent");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.CompositeBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitCompositeBody(CompositeBodySyntax node)
		{
			this.Visit(node.CompositeElements);
		}
		
		public virtual void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Assembly));
			try
			{
				this.Visit(node.NameDef);
				this.BeginProperty("BaseComponent");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.CompositeBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			this.BeginProperty("Components");
			try
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
				this.BeginSymbol();
				try
				{
					this.Visit(node.WireSource);
					this.Visit(node.WireTarget);
				}
				finally
				{
					this.EndSymbol();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitWireSource(WireSourceSyntax node)
		{
			this.BeginProperty("Source");
			try
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitWireTarget(WireTargetSyntax node)
		{
			this.BeginProperty("Target");
			try
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Deployment));
			try
			{
				this.Visit(node.NameDef);
				this.Visit(node.DeploymentBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitDeploymentBody(DeploymentBodySyntax node)
		{
			this.Visit(node.DeploymentElements);
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
			this.BeginProperty("Environments");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Environment));
				try
				{
					this.Visit(node.NameDef);
					this.Visit(node.EnvironmentBody);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			this.VisitList(node.RuntimeReference);
		}
		
		public virtual void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
			this.BeginProperty("Runtime");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Runtime));
				try
				{
					this.Visit(node.NameDef);
				}
				finally
				{
					DeclarationInfo decl = this.EndDeclaration();
					this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Binding));
			try
			{
				this.Visit(node.NameDef);
				this.Visit(node.BindingBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitBindingBody(BindingBodySyntax node)
		{
			this.Visit(node.BindingLayers);
		}
		
		public virtual void VisitBindingLayers(BindingLayersSyntax node)
		{
			this.Visit(node.TransportLayer);
			this.VisitList(node.EncodingLayer);
			this.VisitList(node.ProtocolLayer);
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
			this.BeginSymbol();
			try
			{
				this.Visit(node.HttpTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
			this.VisitList(node.HttpTransportLayerProperties);
		}
		
		public virtual void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.RestTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
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
			this.BeginSymbol();
			try
			{
				this.Visit(node.WebSocketTransportLayerBody);
			}
			finally
			{
				this.EndSymbol();
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
			this.BeginSymbol();
			try
			{
				this.Visit(node.SoapEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
			}
		}
		
		public virtual void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		}
		
		public virtual void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
			this.VisitList(node.SoapEncodingProperties);
		}
		
		public virtual void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.Visit(node.XmlEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
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
			this.BeginSymbol();
			try
			{
				this.Visit(node.JsonEncodingLayerBody);
			}
			finally
			{
				this.EndSymbol();
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
				this.BeginSymbol();
				try
				{
					this.Visit(node.ProtocolLayerKind);
				}
				finally
				{
					this.EndSymbol();
				}
			}
			finally
			{
				this.EndProperty();
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
				this.Visit(node.NameDef);
				this.BeginProperty("Interface");
				try
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
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.EndpointBody);
			}
			finally
			{
				DeclarationInfo decl = this.EndDeclaration();
				this.CreateDeclaration(node, decl.Kind, decl.Names, decl.CanMerge, decl.ParentPropertyToAddTo, decl.Children);
			}
		}
		
		public virtual void VisitEndpointBody(EndpointBodySyntax node)
		{
			this.Visit(node.EndpointProperties);
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
			this.BeginProperty("Binding");
			try
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
			finally
			{
				this.EndProperty();
			}
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
			this.Visit(node.TypeReference);
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
			this.Visit(node.QualifiedName);
		}
		
		public virtual void VisitNulledType(NulledTypeSyntax node)
		{
			this.Visit(node.NullableType);
			this.Visit(node.NonNullableType);
		}
		
		public virtual void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.Visit(node.QualifiedName);
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
				this.BeginSymbol();
				try
				{
					this.Visit(node.ReturnType);
				}
				finally
				{
					this.EndSymbol();
				}
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty("Type");
			try
			{
				this.Visit(node.OnewayType);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginSymbol();
			try
			{
				this.BeginProperty("InnerType");
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
				}
				finally
				{
					this.EndProperty();
				}
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
				this.BeginProperty("InnerType");
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
				}
				finally
				{
					this.EndProperty();
				}
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
				this.BeginProperty("InnerType");
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
				}
				finally
				{
					this.EndProperty();
				}
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
				this.BeginProperty("InnerType");
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
				}
				finally
				{
					this.EndProperty();
				}
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
				this.BeginProperty("InnerType");
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
				}
				finally
				{
					this.EndProperty();
				}
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
			this.BeginSymbol();
			try
			{
				this.Visit(node.ReturnType);
			}
			finally
			{
				this.EndSymbol();
			}
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

