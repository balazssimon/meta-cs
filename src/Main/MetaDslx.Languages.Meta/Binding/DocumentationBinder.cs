using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.Metadata;

namespace MetaDslx.Languages.Meta.Binding
{
    public class DocumentationBinder : CustomBinder
    {
        public DocumentationBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var syntax = (MetaSyntaxNode)this.Syntax;
            var symbolDef = this.FindAncestorBinder<SymbolDefBinder>();
            var mobj = (MetaDocumentedElementBuilder)(symbolDef?.DefinedSymbol as IModelSymbol)?.ModelObject;
            if (syntax == null || mobj == null) return null;
            switch (syntax.Kind.Switch())
            {
                case MetaSyntaxKind.MetamodelDeclaration:
                    var mm = (MetamodelDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, mm.GetFirstToken(), mm.Attribute);
                    break;
                case MetaSyntaxKind.EnumDeclaration:
                    var enm = (EnumDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, enm.GetFirstToken(), enm.Attribute);
                    break;
                case MetaSyntaxKind.EnumValue:
                    var enml = (EnumValueSyntax)syntax;
                    this.SetDocumentation(mobj, enml.GetFirstToken(), enml.Attribute);
                    break;
                case MetaSyntaxKind.ClassDeclaration:
                    var cls = (ClassDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, cls.GetFirstToken(), cls.Attribute);
                    break;
                case MetaSyntaxKind.FieldDeclaration:
                    var fld = (FieldDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, fld.GetFirstToken(), fld.Attribute);
                    break;
                case MetaSyntaxKind.OperationDeclaration:
                    var op = (OperationDeclarationSyntax)syntax;
                    this.SetDocumentation(mobj, op.GetFirstToken(), op.Attribute);
                    break;
                default:
                    break;
            }
            return null;
        }

        private void SetDocumentation(MetaDocumentedElementBuilder mobj, SyntaxToken token, SyntaxList<AttributeSyntax> attributes)
        {
            if (token == null || token.GetKind() == MetaSyntaxKind.None || token.FullSpan.Length == 0)
            {
                Debug.Assert(false);
                return;
            }
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
