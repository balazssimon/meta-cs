// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class InternalSyntaxNode : GreenNodeAdapter
    {
        protected InternalSyntaxNode(SyntaxKind kind)
            : base(kind)
        {
        }

        protected InternalSyntaxNode(SyntaxKind kind, int fullWidth)
            : base(kind, fullWidth)
        {
        }

        protected InternalSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics)
            : base(kind, diagnostics)
        {
        }

        protected InternalSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, int fullWidth)
            : base(kind, diagnostics, fullWidth)
        {
        }

        protected InternalSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base(kind, diagnostics, annotations)
        {
        }

        protected InternalSyntaxNode(SyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
        }

        protected InternalSyntaxNode(ObjectReader reader)
            : base(reader)
        {
        }

        public new Language Language => this.LanguageCore;

        public override int RawContextualKind
        {
            get
            {
                return this.RawKind;
            }
        }

        public override bool IsDirective
        {
            get
            {
                return this is IInternalDirectiveTriviaSyntax;
            }
        }

        public override bool IsSkippedTokensTrivia => this.GetKind() == SyntaxKind.SkippedTokensTrivia;
        public override bool IsDocumentationCommentTrivia => Language.SyntaxFacts.IsDocumentationCommentTrivia(this.GetKind());

        public override int GetSlotOffset(int index)
        {
            // This implementation should not support arbitrary
            // length lists since the implementation is O(n).
            System.Diagnostics.Debug.Assert(index < 11); // Max. slots 11 (TypeDeclarationSyntax)

            int offset = 0;
            for (int i = 0; i < index; i++)
            {
                var child = this.GetSlot(i);
                if (child != null)
                {
                    offset += child.FullWidth;
                }
            }

            return offset;
        }

        public InternalSyntaxToken GetFirstToken()
        {
            return (InternalSyntaxToken)this.GetFirstTerminal();
        }

        public InternalSyntaxToken GetLastToken()
        {
            return (InternalSyntaxToken)this.GetLastTerminal();
        }

        public InternalSyntaxToken GetLastNonmissingToken()
        {
            return (InternalSyntaxToken)this.GetLastNonmissingTerminal();
        }

        public virtual GreenNode GetLeadingTrivia()
        {
            return null;
        }

        public override GreenNode GetLeadingTriviaCore()
        {
            return this.GetLeadingTrivia();
        }

        public virtual GreenNode GetTrailingTrivia()
        {
            return null;
        }

        public override GreenNode GetTrailingTriviaCore()
        {
            return this.GetTrailingTrivia();
        }

        internal override GreenNode SetDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return this.WithDiagnostics(diagnostics);
        }

        public abstract InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics);

        internal override GreenNode SetAnnotations(SyntaxAnnotation[] annotations)
        {
            return this.WithAnnotations(annotations);
        }

        public abstract InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations);

        public abstract TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor);

        public abstract void Accept(InternalSyntaxVisitor visitor);

        internal virtual DirectiveStack ApplyDirectives(DirectiveStack stack)
        {
            return ApplyDirectives(this, stack);
        }

        internal static DirectiveStack ApplyDirectives(GreenNode node, DirectiveStack stack)
        {
            if (node.ContainsDirectives)
            {
                for (int i = 0, n = node.SlotCount; i < n; i++)
                {
                    var child = node.GetSlot(i);
                    if (child != null)
                    {
                        stack = ApplyDirectivesToListOrNode(child, stack);
                    }
                }
            }

            return stack;
        }

        internal static DirectiveStack ApplyDirectivesToListOrNode(GreenNode listOrNode, DirectiveStack stack)
        {
            // If we have a list of trivia, then that node is not actually a CSharpSyntaxNode.
            // Just defer to our standard ApplyDirectives helper as it will do the appropriate
            // walking of this list to ApplyDirectives to the children.
            if (listOrNode.RawKind == GreenNode.ListKind)
            {
                return ApplyDirectives(listOrNode, stack);
            }
            else
            {
                // Otherwise, we must have an actual piece of C# trivia.  Just apply the stack
                // to that node directly.
                return ((InternalSyntaxNode)listOrNode).ApplyDirectives(stack);
            }
        }

        internal virtual IList<Directive> GetDirectives()
        {
            if ((this.flags & NodeFlags.ContainsDirectives) != 0)
            {
                var list = new List<Directive>(32);
                GetDirectives(this, list);
                return list;
            }

            return SpecializedCollections.EmptyList<Directive>();
        }

        private static void GetDirectives(GreenNode node, List<Directive> directives)
        {
            if (node != null && node.ContainsDirectives)
            {
                var d = node as IInternalDirectiveTriviaSyntax;
                if (d != null)
                {
                    directives.Add(d.Directive);
                }
                else
                {
                    var t = node as InternalSyntaxToken;
                    if (t != null)
                    {
                        GetDirectives(t.GetLeadingTrivia(), directives);
                        GetDirectives(t.GetTrailingTrivia(), directives);
                    }
                    else
                    {
                        for (int i = 0, n = node.SlotCount; i < n; i++)
                        {
                            GetDirectives(node.GetSlot(i), directives);
                        }
                    }
                }
            }
        }

        public override SyntaxToken CreateSeparator<TNode>(SyntaxNode element)
        {
            return Language.SyntaxFactory.DefaultSeparator;
        }

        public override bool IsTriviaWithEndOfLine()
        {
            return Language.SyntaxFacts.IsTriviaWithEndOfLine(this);
        }

        // Use conditional weak table so we always return same identity for structured trivia
        private static readonly ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>> s_structuresTable
            = new ConditionalWeakTable<SyntaxNode, Dictionary<SyntaxTrivia, SyntaxNode>>();

        /// <summary>
        /// Gets the syntax node represented the structure of this trivia, if any. The HasStructure property can be used to 
        /// determine if this trivia has structure.
        /// </summary>
        /// <returns>
        /// A CSharpSyntaxNode derived from StructuredTriviaSyntax, with the structured view of this trivia node. 
        /// If this trivia node does not have structure, returns null.
        /// </returns>
        /// <remarks>
        /// Some types of trivia have structure that can be accessed as additional syntax nodes.
        /// These forms of trivia include: 
        ///   directives, where the structure describes the structure of the directive.
        ///   documentation comments, where the structure describes the XML structure of the comment.
        ///   skipped tokens, where the structure describes the tokens that were skipped by the parser.
        /// </remarks>
        public override SyntaxNode GetStructure(SyntaxTrivia trivia)
        {
            if (trivia.HasStructure)
            {
                var parent = trivia.Token.Parent;
                if (parent != null)
                {
                    SyntaxNode structure;
                    var structsInParent = s_structuresTable.GetOrCreateValue(parent);
                    lock (structsInParent)
                    {
                        if (!structsInParent.TryGetValue(trivia, out structure))
                        {
                            structure = Language.SyntaxFactory.CreateStructure(trivia);
                            structsInParent.Add(trivia, structure);
                        }
                    }

                    return structure;
                }
                else
                {
                    return Language.SyntaxFactory.CreateStructure(trivia);
                }
            }

            return null;
        }
    }
}
