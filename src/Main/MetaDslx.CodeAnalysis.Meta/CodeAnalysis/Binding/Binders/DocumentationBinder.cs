using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Languages.Meta.Model;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.Metadata;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class DocumentationBinder : CustomBinder
    {
        public DocumentationBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var syntax = this.Syntax;
            if (syntax.IsNull) return null;
            var firstToken = syntax.IsToken ? syntax.AsToken() : syntax.AsNode().GetFirstToken();
            StringBuilder sb = new StringBuilder();
            foreach (var trivia in firstToken.LeadingTrivia)
            {
                var text = trivia.ToString();
                if (text.StartsWith("///")) sb.AppendLine(text.Substring(3));
                else if (text.StartsWith("/**") && text.EndsWith("*/")) sb.AppendLine(text.Substring(3, text.Length - 5));
            }
            this.SetDocumentation(sb.ToString());
            return null;
        }

        protected virtual void SetDocumentation(string documentationText)
        {
            var symbolDef = this.FindAncestorBinder<DefineBinder>();
            var mobj = (symbolDef?.DefinedSymbol as IModelSymbol)?.ModelObject as MetaDocumentedElementBuilder;
            if (mobj == null) return;
            mobj.Documentation = documentationText;
        }
    }
}
