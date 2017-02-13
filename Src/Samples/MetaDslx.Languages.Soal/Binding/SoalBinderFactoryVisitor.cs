using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalBinderFactoryVisitor : BinderFactoryVisitor, ISoalSyntaxVisitor<Binder>
    {
        public SoalBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }
		
		public Binder VisitMain(MainSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitNameDef(NameDefSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitQualifiedNameDef(QualifiedNameDefSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitIdentifierList(IdentifierListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitQualifiedNameList(QualifiedNameListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitAnnotationList(AnnotationListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitAnnotation(AnnotationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitAnnotationHead(AnnotationHeadSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitAnnotationBody(AnnotationBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitDeclaration(DeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitEnumBody(EnumBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEnumLiteral(EnumLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitStructDeclaration(StructDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitStructBody(StructBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitDatabaseBody(DatabaseBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitEntityReference(EntityReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitInterfaceBody(InterfaceBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitOperationHead(OperationHeadSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitParameterList(ParameterListSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitParameter(ParameterSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitOperationResult(OperationResultSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentBody(ComponentBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitComponentElements(ComponentElementsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitComponentElement(ComponentElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitComponentService(ComponentServiceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentReference(ComponentReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitComponentProperty(ComponentPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentImplementation(ComponentImplementationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitComponentLanguage(ComponentLanguageSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitCompositeBody(CompositeBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitCompositeElements(CompositeElementsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitCompositeElement(CompositeElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitCompositeComponent(CompositeComponentSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitCompositeWire(CompositeWireSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitWireSource(WireSourceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitWireTarget(WireTargetSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitDeploymentBody(DeploymentBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitDeploymentElements(DeploymentElementsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitDeploymentElement(DeploymentElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitBindingBody(BindingBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitBindingLayers(BindingLayersSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitTransportLayer(TransportLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEncodingLayer(EncodingLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitProtocolLayer(ProtocolLayerSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitEndpointBody(EndpointBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node, inBody: true);
		}
		
		public Binder VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEndpointProperty(EndpointPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitReturnType(ReturnTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitTypeReference(TypeReferenceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSimpleType(SimpleTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitNulledType(NulledTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitReferenceType(ReferenceTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitObjectType(ObjectTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitValueType(ValueTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitVoidType(VoidTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitOnewayType(OnewayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitNullableType(NullableTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitNonNullableType(NonNullableTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitArrayType(ArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.GetBinderForSymbol(node);
		}
		
		public Binder VisitConstantValue(ConstantValueSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitTypeofValue(TypeofValueSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitIdentifier(IdentifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitIdentifiers(IdentifiersSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitLiteral(LiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitNullLiteral(NullLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
		
		public Binder VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.Visit(node.Parent);
		    }
			return this.Visit(node.Parent);
		}
    }
}

