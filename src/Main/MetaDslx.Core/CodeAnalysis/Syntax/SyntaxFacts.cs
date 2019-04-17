using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public abstract class SyntaxFacts
    {
        // Maximum size of tokens/trivia that we cache and use in quick scanner.
        // From what I see in our own codebase, tokens longer then 40-50 chars are 
        // not very common. 
        // So it seems reasonable to limit the sizes to some round number like 42.
        public virtual int MaxCachedTokenSize => 42;

        public abstract bool IsToken(int rawKind);
        public abstract bool IsFixedToken(int rawKind);
        public abstract bool IsTrivia(int kind);
        public abstract bool IsReservedKeyword(int kind);
        public abstract bool IsContextualKeyword(int kind);
        public abstract bool IsPreprocessorKeyword(int kind);
        public abstract bool IsPreprocessorContextualKeyword(int kind);
        public abstract bool IsPreprocessorDirective(int kind);
        public abstract bool IsName(int kind);
        public abstract bool IsPredefinedType(int kind);
        public abstract bool IsType(int kind);
        public abstract bool IsTypeDeclaration(int kind);
        public abstract bool IsGlobalMemberDeclaration(int kind);
        public abstract bool IsNamespaceMemberDeclaration(int kind);
        public abstract bool IsIdentifier(int rawKind);
        public abstract bool IsGeneralCommentTrivia(int rawKind);
        public abstract bool IsDocumentationCommentTrivia(int rawKind);
        public abstract bool IsTriviaWithEndOfLine(int rawKind);

        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract object GetValue(int rawKind);
        public abstract int GetKeywordKind(string text);
        public abstract int GetContextualKeywordKind(string text);
        public abstract int GetPreprocessorKeywordKind(string text);

        public abstract IEnumerable<int> GetReservedKeywordKinds();
        public abstract IEnumerable<int> GetContextualKeywordKinds();

        public bool IsCommentTrivia(int rawKind)
        {
            return IsGeneralCommentTrivia(rawKind) || IsDocumentationCommentTrivia(rawKind);
        }

        public bool IsKeyword(int kind)
        {
            return IsReservedKeyword(kind) || IsContextualKeyword(kind);
        }

        public IEnumerable<int> GetKeywordKinds()
        {
            foreach (var reserved in GetReservedKeywordKinds())
            {
                yield return reserved;
            }

            foreach (var contextual in GetContextualKeywordKinds())
            {
                yield return contextual;
            }
        }

        public virtual int GetDeclarationDepth(SyntaxToken token)
        {
            return GetDeclarationDepth(token.Parent);
        }

        public virtual int GetDeclarationDepth(SyntaxTrivia trivia)
        {
            if (IsPreprocessorDirective(trivia.RawKind))
            {
                return 0;
            }

            return GetDeclarationDepth((SyntaxToken)trivia.Token);
        }

        public virtual int GetDeclarationDepth(SyntaxNode node)
        {
            if (node != null)
            {
                if (node.IsStructuredTrivia)
                {
                    var tr = ((IStructuredTriviaSyntax)node).ParentTrivia;
                    return GetDeclarationDepth(tr);
                }
                else if (node.Parent != null)
                {
                    if (node.Parent.RawKind == SyntaxKind.CompilationUnit)
                    {
                        return 0;
                    }

                    int parentDepth = GetDeclarationDepth(node.Parent);
                    return parentDepth;
                }
            }

            return 0;
        }

        public virtual string ExtractName(LanguageSyntaxNode node)
        {
            return null;
        }
        public virtual string ExtractName(SyntaxToken token)
        {
            return token.Text;
        }
        public virtual object ExtractValue(LanguageSyntaxNode node)
        {
            return null;
        }
        public virtual object ExtractValue(SyntaxToken token)
        {
            return token.Value;
        }

    public virtual bool IsWeakChild(SyntaxNode node)
        {
            return false;
        }
    }
}
