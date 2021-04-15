using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Languages.Meta.Model;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class DocumentationBinder : ValueBinder
    {
        public DocumentationBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

        protected override object ComputeValue()
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
            var documentation = sb.ToString();
            return string.IsNullOrWhiteSpace(documentation) ? null : documentation;
        }
    }
}
