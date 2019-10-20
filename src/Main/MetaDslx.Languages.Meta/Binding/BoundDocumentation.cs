using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class BoundDocumentation : CustomBoundNode
    {
        public BoundDocumentation(MetaBoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            
        }

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            var syntax = (MetaSyntaxNode)this.Syntax;
            var symbolDef = this.GetBinder<SymbolDefBinder>();
            var mobj = (MetaDocumentedElementBuilder)symbolDef?.LastDeclaredSymbol?.ModelObject;
            if (mobj == null) return;
            switch (syntax.Kind.Switch())
            {
                case MetaSyntaxKind.MetamodelDeclaration:
                    var mm = (MetamodelDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, mm.KMetamodel, mm.Attribute);
                    break;
                case MetaSyntaxKind.EnumDeclaration:
                    var enm = (EnumDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, enm.KEnum, enm.Attribute);
                    break;
                case MetaSyntaxKind.EnumValue:
                    var enml = (EnumValueSyntax)syntax;
                    this.SetDocumentation(mobj, enml.Name.GetFirstToken(), enml.Attribute);
                    break;
                case MetaSyntaxKind.ClassDeclaration:
                    var cls = (ClassDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, cls.KAbstract.Span.Length > 0 ? cls.KAbstract : cls.KClass, cls.Attribute);
                    break;
                case MetaSyntaxKind.FieldDeclaration:
                    var fld = (FieldDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, fld.FieldModifier.Span.Length > 0 ? fld.FieldModifier.GetFirstToken() : fld.TypeReference.GetFirstToken(), fld.Attribute);
                    break;
                case MetaSyntaxKind.OperationDeclaration:
                    var op = (OperationDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, op.OperationModifier.Span.Length > 0 ? op.OperationModifier.First().GetFirstToken() : op.ReturnType.GetFirstToken(), op.Attribute);
                    break;
                default:
                    break;
            }
        }

        private void SetDocumentation(MetaDocumentedElementBuilder mobj, SyntaxToken token, SyntaxList<AttributeSyntax> attributes)
        {
            Debug.Assert(token.GetKind() != MetaSyntaxKind.None);
            StringBuilder sb = new StringBuilder();
            foreach (var attribute in attributes)
            {
                foreach (var trivia in attribute.GetLeadingTrivia())
                {
                    var text = trivia.ToString();
                    if (text.StartsWith("///")) sb.AppendLine(text.Substring(3));
                    else if (text.StartsWith("/**") && text.EndsWith("*/")) sb.AppendLine(text.Substring(3, text.Length - 5));
                }
            }
            foreach (var trivia in token.LeadingTrivia)
            {
                var text = trivia.ToString();
                if (text.StartsWith("///")) sb.AppendLine(text.Substring(3));
                else if (text.StartsWith("/**") && text.EndsWith("*/")) sb.AppendLine(text.Substring(3, text.Length - 5));
            }
            mobj.Documentation = sb.ToString();
        }
    }
}
