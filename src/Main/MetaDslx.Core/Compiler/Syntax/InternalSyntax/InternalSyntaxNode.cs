using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class InternalSyntaxNode : GreenNode
    {
        protected InternalSyntaxNode(int kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations, int fullWidth)
            : base(kind, diagnostics, annotations, fullWidth)
        {
            GreenStats.NoteGreen(this);
        }

        protected InternalSyntaxNode(ObjectReader reader)
            : base(reader)
        {
        }

        public override bool IsStructuredToken
        {
            get
            {
                return this.IsToken && this is IStructuredSyntax;
            }
        }

        public override bool IsStructuredTrivia
        {
            get
            {
                return this.IsTrivia && this is IStructuredSyntax;
            }
        }

        public override bool IsDirective
        {
            get
            {
                return this is IDirectiveTriviaSyntax;
            }
        }

        public override bool IsDocumentationCommentTrivia
        {
            get
            {
                return this is IDocumentationCommentTriviaSyntax;
            }
        }

        public abstract TResult Accept<TResult>(InternalSyntaxVisitor<TResult> visitor);

        public abstract void Accept(InternalSyntaxVisitor visitor);

        public virtual DirectiveStack ApplyDirectives(DirectiveStack stack)
        {
            return ApplyDirectives(this, stack);
        }

        public static DirectiveStack ApplyDirectives(GreenNode node, DirectiveStack stack)
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
            // If we have a list of trivia, then that node is not actually a GreenNode.
            // Just defer to our standard ApplyDirectives helper as it will do the appropriate
            // walking of this list to ApplyDirectives to the children.
            if (listOrNode.RawKind == (int)SyntaxKind.List)
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

        public virtual IList<IDirectiveTriviaSyntax> GetDirectives()
        {
            if ((this.flags & NodeFlags.ContainsDirectives) != 0)
            {
                var list = new List<IDirectiveTriviaSyntax>(32);
                GetDirectives(this, list);
                return list;
            }

            return SpecializedCollections.EmptyList<IDirectiveTriviaSyntax>();
        }

        private static void GetDirectives(GreenNode node, List<IDirectiveTriviaSyntax> directives)
        {
            if (node != null && node.ContainsDirectives)
            {
                var d = node as IDirectiveTriviaSyntax;
                if (d != null)
                {
                    directives.Add(d);
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

    }
}
