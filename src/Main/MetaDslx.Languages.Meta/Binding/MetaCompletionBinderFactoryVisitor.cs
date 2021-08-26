// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaCompletionBinderFactoryVisitor : CompletionBinderFactoryVisitor, IMetaSyntaxVisitor
    {

        public MetaCompletionBinderFactoryVisitor(BinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new MetaBinderFactory BinderFactory => (MetaBinderFactory)base.BinderFactory;

		
		public void VisitMain(MainSyntax parent) // 0
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.UsingNamespace)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.UsingNamespace);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.NamespaceDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NamespaceDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.NamespaceDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.EndOfFileToken, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EndOfFileToken, operation);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.UsingNamespace)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.UsingNamespace);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.NamespaceDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NamespaceDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.NamespaceDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.EndOfFileToken, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EndOfFileToken, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitName(NameSyntax parent) // 1
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax parent) // 2
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitQualifier(QualifierSyntax parent) // 3
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Identifier.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Identifier.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitAttribute(AttributeSyntax parent) // 4
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitUsingNamespace(UsingNamespaceSyntax parent) // 5
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KUsing, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KUsing, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KUsing, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KUsing, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent) // 6
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KNamespace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KNamespace, operation);
		        }
		        operation = this.GetOperation(ref position, parent.QualifiedName, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.QualifiedName, operation, (MetaSyntaxKind)MetaSyntaxKind.QualifiedName);
		        }
		        operation = this.GetOperation(ref position, parent.NamespaceBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NamespaceBody, operation, (MetaSyntaxKind)MetaSyntaxKind.NamespaceBody);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KNamespace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KNamespace, operation);
		        }
		        operation = this.GetOperation(ref position, parent.QualifiedName, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.QualifiedName, operation, (MetaSyntaxKind)MetaSyntaxKind.QualifiedName);
		        }
		        operation = this.GetOperation(ref position, parent.NamespaceBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NamespaceBody, operation, (MetaSyntaxKind)MetaSyntaxKind.NamespaceBody);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitNamespaceBody(NamespaceBodySyntax parent) // 7
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        foreach (var item in parent.UsingNamespace)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.UsingNamespace);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelDeclaration);
		        }
		        foreach (var item in parent.Declaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Declaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        foreach (var item in parent.UsingNamespace)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.UsingNamespace);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelDeclaration);
		        }
		        foreach (var item in parent.Declaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Declaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitMetamodelDeclaration(MetamodelDeclarationSyntax parent) // 8
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KMetamodel, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KMetamodel, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TOpenParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelPropertyList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelPropertyList, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelPropertyList);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KMetamodel, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KMetamodel, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TOpenParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelPropertyList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelPropertyList, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelPropertyList);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitMetamodelPropertyList(MetamodelPropertyListSyntax parent) // 9
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.MetamodelProperty.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelProperty);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.MetamodelProperty.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelProperty);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitMetamodelProperty(MetamodelPropertySyntax parent) // 10
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.MetamodelUriProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelUriProperty, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelUriProperty);
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelPrefixProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelPrefixProperty, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelPrefixProperty);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.MetamodelUriProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelUriProperty, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelUriProperty);
		        }
		        operation = this.GetOperation(ref position, parent.MetamodelPrefixProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.MetamodelPrefixProperty, operation, (MetaSyntaxKind)MetaSyntaxKind.MetamodelPrefixProperty);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitMetamodelUriProperty(MetamodelUriPropertySyntax parent) // 11
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.IUri, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IUri, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.IUri, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IUri, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax parent) // 12
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.IPrefix, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IPrefix, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.IPrefix, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IPrefix, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitDeclaration(DeclarationSyntax parent) // 13
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.EnumDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.ClassDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.AssociationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.AssociationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.AssociationDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.ConstDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ConstDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.ConstDeclaration);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.EnumDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.ClassDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.AssociationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.AssociationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.AssociationDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.ConstDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ConstDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.ConstDeclaration);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitEnumDeclaration(EnumDeclarationSyntax parent) // 14
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KEnum, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KEnum, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.EnumBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumBody, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumBody);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KEnum, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KEnum, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.EnumBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumBody, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumBody);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitEnumBody(EnumBodySyntax parent) // 15
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        operation = this.GetOperation(ref position, parent.EnumValues, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumValues, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumValues);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        foreach (var item in parent.EnumMemberDeclaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumMemberDeclaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        operation = this.GetOperation(ref position, parent.EnumValues, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.EnumValues, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumValues);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        foreach (var item in parent.EnumMemberDeclaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumMemberDeclaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitEnumValues(EnumValuesSyntax parent) // 16
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.EnumValue.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumValue);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.EnumValue.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.EnumValue);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitEnumValue(EnumValueSyntax parent) // 17
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax parent) // 18
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.OperationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationDeclaration);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.OperationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationDeclaration);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassDeclaration(ClassDeclarationSyntax parent) // 19
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.SymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.SymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.KAbstract, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KAbstract, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KClass, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KClass, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.ClassAncestors, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassAncestors, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassAncestors);
		        }
		        operation = this.GetOperation(ref position, parent.ClassBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassBody, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassBody);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.SymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.SymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.KAbstract, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KAbstract, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KClass, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KClass, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.ClassAncestors, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassAncestors, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassAncestors);
		        }
		        operation = this.GetOperation(ref position, parent.ClassBody, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassBody, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassBody);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitSymbolAttribute(SymbolAttributeSyntax parent) // 20
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.SymbolSymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SymbolSymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.SymbolSymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.ExpressionSymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ExpressionSymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.ExpressionSymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.StatementSymbolTypeAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StatementSymbolTypeAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.StatementSymbolTypeAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.TypeSymbolTypeAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeSymbolTypeAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeSymbolTypeAttribute);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.SymbolSymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SymbolSymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.SymbolSymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.ExpressionSymbolAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ExpressionSymbolAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.ExpressionSymbolAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.StatementSymbolTypeAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StatementSymbolTypeAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.StatementSymbolTypeAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.TypeSymbolTypeAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeSymbolTypeAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeSymbolTypeAttribute);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax parent) // 21
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KSymbol, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KSymbol, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KSymbol, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KSymbol, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax parent) // 22
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KExpression, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KExpression, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KExpression, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KExpression, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax parent) // 23
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KStatement, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KStatement, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KStatement, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KStatement, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax parent) // 24
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KType, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KType, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassBody(ClassBodySyntax parent) // 25
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        foreach (var item in parent.ClassMemberDeclaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassMemberDeclaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBrace, operation);
		        }
		        foreach (var item in parent.ClassMemberDeclaration)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassMemberDeclaration);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBrace, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBrace, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassAncestors(ClassAncestorsSyntax parent) // 26
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.ClassAncestor.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassAncestor);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.ClassAncestor.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassAncestor);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassAncestor(ClassAncestorSyntax parent) // 27
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax parent) // 28
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.FieldDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.OperationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationDeclaration);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.FieldDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldDeclaration);
		        }
		        operation = this.GetOperation(ref position, parent.OperationDeclaration, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationDeclaration, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationDeclaration);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitFieldDeclaration(FieldDeclarationSyntax parent) // 29
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.FieldSymbolPropertyAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldSymbolPropertyAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldSymbolPropertyAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.FieldContainment, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldContainment, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldContainment);
		        }
		        operation = this.GetOperation(ref position, parent.FieldModifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldModifier, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldModifier);
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.DefaultValue, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.DefaultValue, operation, (MetaSyntaxKind)MetaSyntaxKind.DefaultValue);
		        }
		        foreach (var item in parent.RedefinitionsOrSubsettings)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.RedefinitionsOrSubsettings);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.FieldSymbolPropertyAttribute, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldSymbolPropertyAttribute, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldSymbolPropertyAttribute);
		        }
		        operation = this.GetOperation(ref position, parent.FieldContainment, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldContainment, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldContainment);
		        }
		        operation = this.GetOperation(ref position, parent.FieldModifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldModifier, operation, (MetaSyntaxKind)MetaSyntaxKind.FieldModifier);
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.DefaultValue, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.DefaultValue, operation, (MetaSyntaxKind)MetaSyntaxKind.DefaultValue);
		        }
		        foreach (var item in parent.RedefinitionsOrSubsettings)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.RedefinitionsOrSubsettings);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax parent) // 30
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KProperty, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TOpenBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenBracket, operation);
		        }
		        operation = this.GetOperation(ref position, parent.KProperty, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KProperty, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TColon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TColon, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Identifier);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseBracket, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseBracket, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitFieldContainment(FieldContainmentSyntax parent) // 31
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KContainment, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KContainment, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KContainment, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KContainment, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitFieldModifier(FieldModifierSyntax parent) // 32
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.FieldModifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldModifier, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.FieldModifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.FieldModifier, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitDefaultValue(DefaultValueSyntax parent) // 33
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax parent) // 34
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Redefinitions, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Redefinitions, operation, (MetaSyntaxKind)MetaSyntaxKind.Redefinitions);
		        }
		        operation = this.GetOperation(ref position, parent.Subsettings, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Subsettings, operation, (MetaSyntaxKind)MetaSyntaxKind.Subsettings);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Redefinitions, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Redefinitions, operation, (MetaSyntaxKind)MetaSyntaxKind.Redefinitions);
		        }
		        operation = this.GetOperation(ref position, parent.Subsettings, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Subsettings, operation, (MetaSyntaxKind)MetaSyntaxKind.Subsettings);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitRedefinitions(RedefinitionsSyntax parent) // 35
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KRedefines, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KRedefines, operation);
		        }
		        operation = this.GetOperation(ref position, parent.NameUseList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NameUseList, operation, (MetaSyntaxKind)MetaSyntaxKind.NameUseList);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KRedefines, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KRedefines, operation);
		        }
		        operation = this.GetOperation(ref position, parent.NameUseList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NameUseList, operation, (MetaSyntaxKind)MetaSyntaxKind.NameUseList);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitSubsettings(SubsettingsSyntax parent) // 36
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KSubsets, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KSubsets, operation);
		        }
		        operation = this.GetOperation(ref position, parent.NameUseList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NameUseList, operation, (MetaSyntaxKind)MetaSyntaxKind.NameUseList);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KSubsets, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KSubsets, operation);
		        }
		        operation = this.GetOperation(ref position, parent.NameUseList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NameUseList, operation, (MetaSyntaxKind)MetaSyntaxKind.NameUseList);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitNameUseList(NameUseListSyntax parent) // 37
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Qualifier.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Qualifier.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitConstDeclaration(ConstDeclarationSyntax parent) // 38
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KConst, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KConst, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.ConstValue, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ConstValue, operation, (MetaSyntaxKind)MetaSyntaxKind.ConstValue);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KConst, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KConst, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.ConstValue, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ConstValue, operation, (MetaSyntaxKind)MetaSyntaxKind.ConstValue);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitConstValue(ConstValueSyntax parent) // 39
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TAssign, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TAssign, operation);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitReturnType(ReturnTypeSyntax parent) // 40
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.VoidType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.VoidType, operation, (MetaSyntaxKind)MetaSyntaxKind.VoidType);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.VoidType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.VoidType, operation, (MetaSyntaxKind)MetaSyntaxKind.VoidType);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitTypeOfReference(TypeOfReferenceSyntax parent) // 41
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitTypeReference(TypeReferenceSyntax parent) // 42
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.CollectionType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionType, operation, (MetaSyntaxKind)MetaSyntaxKind.CollectionType);
		        }
		        operation = this.GetOperation(ref position, parent.SimpleType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SimpleType, operation, (MetaSyntaxKind)MetaSyntaxKind.SimpleType);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.CollectionType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionType, operation, (MetaSyntaxKind)MetaSyntaxKind.CollectionType);
		        }
		        operation = this.GetOperation(ref position, parent.SimpleType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SimpleType, operation, (MetaSyntaxKind)MetaSyntaxKind.SimpleType);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitSimpleType(SimpleTypeSyntax parent) // 43
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation, (MetaSyntaxKind)MetaSyntaxKind.PrimitiveType);
		        }
		        operation = this.GetOperation(ref position, parent.ObjectType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ObjectType, operation, (MetaSyntaxKind)MetaSyntaxKind.ObjectType);
		        }
		        operation = this.GetOperation(ref position, parent.NullableType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NullableType, operation, (MetaSyntaxKind)MetaSyntaxKind.NullableType);
		        }
		        operation = this.GetOperation(ref position, parent.ClassType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassType, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassType);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation, (MetaSyntaxKind)MetaSyntaxKind.PrimitiveType);
		        }
		        operation = this.GetOperation(ref position, parent.ObjectType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ObjectType, operation, (MetaSyntaxKind)MetaSyntaxKind.ObjectType);
		        }
		        operation = this.GetOperation(ref position, parent.NullableType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NullableType, operation, (MetaSyntaxKind)MetaSyntaxKind.NullableType);
		        }
		        operation = this.GetOperation(ref position, parent.ClassType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ClassType, operation, (MetaSyntaxKind)MetaSyntaxKind.ClassType);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitClassType(ClassTypeSyntax parent) // 44
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Qualifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Qualifier, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitObjectType(ObjectTypeSyntax parent) // 45
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.ObjectType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ObjectType, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.ObjectType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ObjectType, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitPrimitiveType(PrimitiveTypeSyntax parent) // 46
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitVoidType(VoidTypeSyntax parent) // 47
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KVoid, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KVoid, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KVoid, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KVoid, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitNullableType(NullableTypeSyntax parent) // 48
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation, (MetaSyntaxKind)MetaSyntaxKind.PrimitiveType);
		        }
		        operation = this.GetOperation(ref position, parent.TQuestion, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TQuestion, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.PrimitiveType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.PrimitiveType, operation, (MetaSyntaxKind)MetaSyntaxKind.PrimitiveType);
		        }
		        operation = this.GetOperation(ref position, parent.TQuestion, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TQuestion, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitCollectionType(CollectionTypeSyntax parent) // 49
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.CollectionKind, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionKind, operation, (MetaSyntaxKind)MetaSyntaxKind.CollectionKind);
		        }
		        operation = this.GetOperation(ref position, parent.TLessThan, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TLessThan, operation);
		        }
		        operation = this.GetOperation(ref position, parent.SimpleType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SimpleType, operation, (MetaSyntaxKind)MetaSyntaxKind.SimpleType);
		        }
		        operation = this.GetOperation(ref position, parent.TGreaterThan, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TGreaterThan, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.CollectionKind, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionKind, operation, (MetaSyntaxKind)MetaSyntaxKind.CollectionKind);
		        }
		        operation = this.GetOperation(ref position, parent.TLessThan, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TLessThan, operation);
		        }
		        operation = this.GetOperation(ref position, parent.SimpleType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.SimpleType, operation, (MetaSyntaxKind)MetaSyntaxKind.SimpleType);
		        }
		        operation = this.GetOperation(ref position, parent.TGreaterThan, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TGreaterThan, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitCollectionKind(CollectionKindSyntax parent) // 50
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.CollectionKind, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionKind, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.CollectionKind, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.CollectionKind, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitOperationDeclaration(OperationDeclarationSyntax parent) // 51
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        foreach (var item in parent.OperationModifier)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifier);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.ReturnType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ReturnType, operation, (MetaSyntaxKind)MetaSyntaxKind.ReturnType);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TOpenParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.ParameterList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ParameterList, operation, (MetaSyntaxKind)MetaSyntaxKind.ParameterList);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        foreach (var item in parent.OperationModifier)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifier);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.ReturnType, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ReturnType, operation, (MetaSyntaxKind)MetaSyntaxKind.ReturnType);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        operation = this.GetOperation(ref position, parent.TOpenParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TOpenParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.ParameterList, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ParameterList, operation, (MetaSyntaxKind)MetaSyntaxKind.ParameterList);
		        }
		        operation = this.GetOperation(ref position, parent.TCloseParen, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TCloseParen, operation);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitOperationModifier(OperationModifierSyntax parent) // 52
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.OperationModifierBuilder, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationModifierBuilder, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifierBuilder);
		        }
		        operation = this.GetOperation(ref position, parent.OperationModifierReadonly, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationModifierReadonly, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifierReadonly);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.OperationModifierBuilder, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationModifierBuilder, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifierBuilder);
		        }
		        operation = this.GetOperation(ref position, parent.OperationModifierReadonly, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.OperationModifierReadonly, operation, (MetaSyntaxKind)MetaSyntaxKind.OperationModifierReadonly);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitOperationModifierBuilder(OperationModifierBuilderSyntax parent) // 53
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KBuilder, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KBuilder, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KBuilder, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KBuilder, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitOperationModifierReadonly(OperationModifierReadonlySyntax parent) // 54
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KReadonly, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KReadonly, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KReadonly, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KReadonly, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitParameterList(ParameterListSyntax parent) // 55
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Parameter.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Parameter);
		            }
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Parameter.GetWithSeparators())
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Parameter);
		            }
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitParameter(ParameterSyntax parent) // 56
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.TypeReference, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TypeReference, operation, (MetaSyntaxKind)MetaSyntaxKind.TypeReference);
		        }
		        operation = this.GetOperation(ref position, parent.Name, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Name, operation, (MetaSyntaxKind)MetaSyntaxKind.Name);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitAssociationDeclaration(AssociationDeclarationSyntax parent) // 57
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KAssociation, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KAssociation, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Source, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Source, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.KWith, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KWith, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Target, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Target, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		    }
		    else
		    {
		        foreach (var item in parent.Attribute)
		        {
		            operation = this.GetOperation(ref position, item, searchLeft, searchRight);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResults(parent, item, operation, (MetaSyntaxKind)MetaSyntaxKind.Attribute);
		            }
		        }
		        operation = this.GetOperation(ref position, parent.KAssociation, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KAssociation, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Source, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Source, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.KWith, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KWith, operation);
		        }
		        operation = this.GetOperation(ref position, parent.Target, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Target, operation, (MetaSyntaxKind)MetaSyntaxKind.Qualifier);
		        }
		        operation = this.GetOperation(ref position, parent.TSemicolon, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.TSemicolon, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitIdentifier(IdentifierSyntax parent) // 58
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.Identifier, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.Identifier, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitLiteral(LiteralSyntax parent) // 59
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.NullLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NullLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.NullLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.BooleanLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.BooleanLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.BooleanLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.IntegerLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IntegerLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.IntegerLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.DecimalLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.DecimalLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.DecimalLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.ScientificLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ScientificLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.ScientificLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.NullLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.NullLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.NullLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.BooleanLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.BooleanLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.BooleanLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.IntegerLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.IntegerLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.IntegerLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.DecimalLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.DecimalLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.DecimalLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.ScientificLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.ScientificLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.ScientificLiteral);
		        }
		        operation = this.GetOperation(ref position, parent.StringLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.StringLiteral, operation, (MetaSyntaxKind)MetaSyntaxKind.StringLiteral);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitNullLiteral(NullLiteralSyntax parent) // 60
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.KNull, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KNull, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.KNull, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.KNull, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax parent) // 61
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.BooleanLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.BooleanLiteral, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.BooleanLiteral, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.BooleanLiteral, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax parent) // 62
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.LInteger, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LInteger, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.LInteger, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LInteger, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax parent) // 63
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.LDecimal, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LDecimal, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.LDecimal, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LDecimal, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax parent) // 64
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.LScientific, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LScientific, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.LScientific, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LScientific, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}
		
		public void VisitStringLiteral(StringLiteralSyntax parent) // 65
		{
		    var searchLeft = LeftPosition == SearchSpan.Start && parent.FullSpan.Start <= SearchSpan.End;
		    var searchRight = RightPosition == SearchSpan.End && parent.FullSpan.End >= SearchSpan.Start;
		    if (!(searchLeft || searchRight)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (VisitChildren)
		    {
		        operation = this.GetOperation(ref position, parent.LRegularString, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LRegularString, operation);
		        }
		    }
		    else
		    {
		        operation = this.GetOperation(ref position, parent.LRegularString, searchLeft, searchRight);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResults(parent, parent.LRegularString, operation);
		        }
		        if (parent.FullSpan.Start < LeftPosition) LeftPosition = parent.FullSpan.Start;
		        if (parent.FullSpan.End > RightPosition) RightPosition = parent.FullSpan.End;
		        VisitParent(parent);
		    }
		}

        public void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
        {
        }
    }
}

