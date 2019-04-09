// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxFactory
    {
        public InternalSyntaxFactory()
        {
            string CrLf = "\r\n";
            CarriageReturnLineFeed = EndOfLine(CrLf);
            LineFeed = EndOfLine("\n");
            CarriageReturn = EndOfLine("\r");
            Space = Whitespace(" ");
            Tab = Whitespace("\t");

            ElasticCarriageReturnLineFeed = EndOfLine(CrLf, elastic: true);
            ElasticLineFeed = EndOfLine("\n", elastic: true);
            ElasticCarriageReturn = EndOfLine("\r", elastic: true);
            ElasticSpace = Whitespace(" ", elastic: true);
            ElasticTab = Whitespace("\t", elastic: true);

            ElasticZeroSpace = Whitespace(string.Empty, elastic: true);
        }

        public Language Language
        {
            get { return this.LanguageCore; }
        }

        protected abstract Language LanguageCore { get; }

        public InternalSyntaxTrivia CarriageReturnLineFeed { get; }
        public InternalSyntaxTrivia LineFeed { get; }
        public InternalSyntaxTrivia CarriageReturn { get; }
        public InternalSyntaxTrivia Space { get; }
        public InternalSyntaxTrivia Tab { get; }
        public InternalSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
        public InternalSyntaxTrivia ElasticLineFeed { get; }
        public InternalSyntaxTrivia ElasticCarriageReturn { get; }
        public InternalSyntaxTrivia ElasticSpace { get; }
        public InternalSyntaxTrivia ElasticTab { get; }
        public InternalSyntaxTrivia ElasticZeroSpace { get; }

        protected InternalSyntaxTrivia GetWellKnownTrivia(string text, bool elastic = false)
        {
            switch (text)
            {
                case " ":
                    return elastic ? this.ElasticSpace : this.Space;
                case "\t":
                    return elastic ? this.ElasticTab : this.Tab;
                case "\r":
                    return elastic ? this.ElasticCarriageReturn : this.CarriageReturn;
                case "\n":
                    return elastic ? this.ElasticLineFeed : this.LineFeed;
                case "\r\n":
                    return elastic ? this.ElasticCarriageReturnLineFeed : this.CarriageReturnLineFeed;
                default:
                    return null;
            }
        }

        public InternalSyntaxTrivia EndOfLine(string text, bool elastic = false)
        {
            InternalSyntaxTrivia trivia = null;

            // use predefined trivia
            switch (text)
            {
                case "\r":
                    trivia = elastic ? this.ElasticCarriageReturn : this.CarriageReturn;
                    break;
                case "\n":
                    trivia = elastic ? this.ElasticLineFeed : this.LineFeed;
                    break;
                case "\r\n":
                    trivia = elastic ? this.ElasticCarriageReturnLineFeed : this.CarriageReturnLineFeed;
                    break;
            }

            // note: predefined trivia might not yet be defined during initialization
            if (trivia != null)
            {
                return trivia;
            }

            trivia = this.Trivia(this.Language.SyntaxFacts.DefaultEndOfLineSyntaxKind, text);
            if (!elastic)
            {
                return trivia;
            }

            return (InternalSyntaxTrivia)trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public InternalSyntaxTrivia Whitespace(string text, bool elastic = false)
        {
            var trivia = this.Trivia(this.Language.SyntaxFacts.DefaultWhitespaceSyntaxKind, text);
            if (!elastic)
            {
                return trivia;
            }

            return (InternalSyntaxTrivia)trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public abstract InternalSyntaxToken Token(int kind);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing);
        public abstract InternalSyntaxToken MissingToken(int kind);
        public abstract InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxTrivia Trivia(int kind, string text);

        public abstract string ExtractValueText(int kind, string text);
        public abstract object ExtractValue(int kind, string text);
        /// <summary>
        /// Gets the syntax node represented the structure of this token, if any. The HasStructure property can be used to 
        /// determine if this trivia has structure.
        /// </summary>
        /// <returns>
        /// A GreenNode with the structured view of this token node. 
        /// If this token node does not have structure, returns null.
        /// </returns>
        public virtual SyntaxNode CreateStructure(MetaDslx.Compiler.SyntaxToken token)
        {
            return null;
        }

        /// <summary>
        /// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
        /// determine if this trivia has structure.
        /// </summary>
        /// <returns>
        /// A GreenNode with the structured view of this trivia node. 
        /// If this trivia node does not have structure, returns null.
        /// </returns>
        /// <remarks>
        /// Some types of trivia have structure that can be accessed as additional syntax nodes.
        /// These forms of trivia include: 
        ///   directives, where the structure describes the structure of the directive.
        ///   documentation comments, where the structure describes the XML structure of the comment.
        ///   skipped tokens, where the structure describes the tokens that were skipped by the parser.
        /// </remarks>        
        public virtual SyntaxNode CreateStructure(MetaDslx.Compiler.SyntaxTrivia trivia)
        {
            return null;
        }
    }
}
