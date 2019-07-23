// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
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
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.NamespaceDeclaration != null)
			{
				foreach (var child in node.NamespaceDeclaration)
				{
					this.Visit(child);
				}
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
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
			if (node.Identifier != null)
			{
				foreach (var child in node.Identifier)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitQualifierList(QualifierListSyntax node)
		{
			if (node.Qualifier != null)
			{
				foreach (var child in node.Qualifier)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitAnnotationList(AnnotationListSyntax node)
		{
			if (node.Annotation != null)
			{
				foreach (var child in node.Annotation)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
			if (node.ReturnAnnotation != null)
			{
				foreach (var child in node.ReturnAnnotation)
				{
					this.Visit(child);
				}
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
			if (node.AnnotationProperty != null)
			{
				foreach (var child in node.AnnotationProperty)
				{
					this.Visit(child);
				}
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
				this.Visit(node.NamespacePrefix);
				this.Visit(node.NamespaceUri);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
			this.BeginProperty("Prefix");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNamespaceUri(NamespaceUriSyntax node)
		{
			this.BeginProperty("Uri");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			if (node.Declaration != null)
			{
				foreach (var child in node.Declaration)
				{
					this.Visit(child);
				}
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
				this.BeginProperty("BaseType");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Enum), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.Visit(node.EnumLiterals);
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			if (node.EnumLiteral != null)
			{
				foreach (var child in node.EnumLiteral)
				{
					this.Visit(child);
				}
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
				this.BeginProperty("BaseType");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Struct), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitStructBody(StructBodySyntax node)
		{
			if (node.PropertyDeclaration != null)
			{
				foreach (var child in node.PropertyDeclaration)
				{
					this.Visit(child);
				}
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
			if (node.EntityReference != null)
			{
				foreach (var child in node.EntityReference)
				{
					this.Visit(child);
				}
			}
			if (node.OperationDeclaration != null)
			{
				foreach (var child in node.OperationDeclaration)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitEntityReference(EntityReferenceSyntax node)
		{
			this.BeginProperty("Entities");
			try
			{
				this.BeginNoDeclaration(typeof(Symbols.Struct), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
				}
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
			if (node.OperationDeclaration != null)
			{
				foreach (var child in node.OperationDeclaration)
				{
					this.Visit(child);
				}
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
			this.Visit(node.ThrowsList);
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			if (node.Parameter != null)
			{
				foreach (var child in node.Parameter)
				{
					this.Visit(child);
				}
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
					this.BeginProperty("Type");
					try
					{
						this.Visit(node.OperationReturnType);
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
		
		public virtual void VisitThrowsList(ThrowsListSyntax node)
		{
			this.BeginProperty("Exceptions");
			try
			{
				this.BeginNoDeclaration(typeof(Symbols.Struct), node.QualifierList);
				try
				{
					this.Visit(node.QualifierList);
				}
				finally
				{
					this.EndNoDeclaration();
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
				switch (node.KAbstract.GetKind().Switch())
				{
					default:
						break;
				}
				this.Visit(node.Name);
				this.BeginProperty("BaseComponent");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Component), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitComponentBody(ComponentBodySyntax node)
		{
			this.Visit(node.ComponentElements);
		}
		
		public virtual void VisitComponentElements(ComponentElementsSyntax node)
		{
			if (node.ComponentElement != null)
			{
				foreach (var child in node.ComponentElement)
				{
					this.Visit(child);
				}
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
					this.BeginProperty("Interface");
					try
					{
						this.BeginNoDeclaration(typeof(Symbols.Interface), node.Qualifier);
						try
						{
							this.Visit(node.Qualifier);
						}
						finally
						{
							this.EndNoDeclaration();
						}
					}
					finally
					{
						this.EndProperty();
					}
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
					this.BeginProperty("Interface");
					try
					{
						this.BeginNoDeclaration(typeof(Symbols.Interface), node.Qualifier);
						try
						{
							this.Visit(node.Qualifier);
						}
						finally
						{
							this.EndNoDeclaration();
						}
					}
					finally
					{
						this.EndProperty();
					}
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
			if (node.ComponentServiceOrReferenceElement != null)
			{
				foreach (var child in node.ComponentServiceOrReferenceElement)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
			this.BeginProperty("Binding");
			try
			{
				this.BeginNoDeclaration(typeof(Symbols.Binding), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
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
			this.BeginProperty("ProgrammingLanguage");
			try
			{
				this.BeginDeclaration(typeof(Symbols.ProgrammingLanguage), node);
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
				this.BeginProperty("BaseComponent");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Component), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.BeginProperty("BaseComponent");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Component), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitCompositeElements(CompositeElementsSyntax node)
		{
			if (node.CompositeElement != null)
			{
				foreach (var child in node.CompositeElement)
				{
					this.Visit(child);
				}
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
				this.BeginNoDeclaration(typeof(Symbols.Component), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
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
			this.BeginProperty("Source");
			try
			{
				this.BeginNoDeclaration(typeof(Symbols.Port), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
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
				this.BeginNoDeclaration(typeof(Symbols.Port), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
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
			if (node.DeploymentElement != null)
			{
				foreach (var child in node.DeploymentElement)
				{
					this.Visit(child);
				}
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
			if (node.RuntimeReference != null)
			{
				foreach (var child in node.RuntimeReference)
				{
					this.Visit(child);
				}
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
				this.BeginNoDeclaration(typeof(Symbols.Assembly), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
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
				this.BeginNoDeclaration(typeof(Symbols.Database), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
				}
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
			if (node.EncodingLayer != null)
			{
				foreach (var child in node.EncodingLayer)
				{
					this.Visit(child);
				}
			}
			if (node.ProtocolLayer != null)
			{
				foreach (var child in node.ProtocolLayer)
				{
					this.Visit(child);
				}
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
			if (node.HttpTransportLayerProperties != null)
			{
				foreach (var child in node.HttpTransportLayerProperties)
				{
					this.Visit(child);
				}
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
			if (node.SoapEncodingProperties != null)
			{
				foreach (var child in node.SoapEncodingProperties)
				{
					this.Visit(child);
				}
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
				this.BeginProperty("Interface");
				try
				{
					this.BeginNoDeclaration(typeof(Symbols.Interface), node.Qualifier);
					try
					{
						this.Visit(node.Qualifier);
					}
					finally
					{
						this.EndNoDeclaration();
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
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitEndpointBody(EndpointBodySyntax node)
		{
			this.Visit(node.EndpointProperties);
		}
		
		public virtual void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
			if (node.EndpointProperty != null)
			{
				foreach (var child in node.EndpointProperty)
				{
					this.Visit(child);
				}
			}
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
				this.BeginNoDeclaration(typeof(Symbols.Binding), node.Qualifier);
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndNoDeclaration();
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
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				this.Visit(node.VoidType);
				this.Visit(node.TypeReference);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				this.Visit(node.NonNullableArrayType);
				this.Visit(node.ArrayType);
				this.Visit(node.SimpleType);
				this.Visit(node.NulledType);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				this.Visit(node.ValueType);
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitNulledType(NulledTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				this.Visit(node.NullableType);
				this.Visit(node.NonNullableType);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitReferenceType(ReferenceTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				this.Visit(node.ObjectType);
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				if (node != null) this.RegisterIdentifier(node);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitValueType(ValueTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				if (node != null) this.RegisterIdentifier(node);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				if (node != null) this.RegisterIdentifier(node);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitOnewayType(OnewayTypeSyntax node)
		{
			this.BeginNoDeclaration(typeof(Symbols.SoalType), node);
			try
			{
				if (node != null) this.RegisterIdentifier(node);
			}
			finally
			{
				this.EndNoDeclaration();
			}
		}
		
		public virtual void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			this.Visit(node.OnewayType);
			this.Visit(node.VoidType);
			this.Visit(node.TypeReference);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.NullableType), node);
			try
			{
				this.BeginProperty("InnerType");
				try
				{
					this.Visit(node.ValueType);
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
		
		public virtual void VisitNonNullableType(NonNullableTypeSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.NonNullableType), node);
			try
			{
				this.BeginProperty("InnerType");
				try
				{
					this.Visit(node.ReferenceType);
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
		
		public virtual void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.NonNullableType), node);
			try
			{
				this.BeginProperty("InnerType");
				try
				{
					this.Visit(node.ArrayType);
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
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
			this.Visit(node.SimpleArrayType);
			this.Visit(node.NulledArrayType);
		}
		
		public virtual void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.ArrayType), node);
			try
			{
				this.BeginProperty("InnerType");
				try
				{
					this.Visit(node.SimpleType);
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
		
		public virtual void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.ArrayType), node);
			try
			{
				this.BeginProperty("InnerType");
				try
				{
					this.Visit(node.NulledType);
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

