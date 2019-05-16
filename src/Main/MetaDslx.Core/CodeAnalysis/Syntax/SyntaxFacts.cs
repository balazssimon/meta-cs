using MetaDslx.Modeling;
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

        public abstract bool IsToken(SyntaxKind kind);
        public abstract bool IsFixedToken(SyntaxKind kind);
        public abstract bool IsTrivia(SyntaxKind kind);
        public abstract bool IsReservedKeyword(SyntaxKind kind);
        public abstract bool IsContextualKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorContextualKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorDirective(SyntaxKind kind);
        public abstract bool IsName(SyntaxKind kind);
        public abstract bool IsPredefinedType(SyntaxKind kind);
        public abstract bool IsType(SyntaxKind kind);
        public abstract bool IsTypeDeclaration(SyntaxKind kind);
        public abstract bool IsGlobalMemberDeclaration(SyntaxKind kind);
        public abstract bool IsNamespaceMemberDeclaration(SyntaxKind kind);
        public abstract bool IsIdentifier(SyntaxKind rawKind);
        public abstract bool IsGeneralCommentTrivia(SyntaxKind rawKind);
        public abstract bool IsDocumentationCommentTrivia(SyntaxKind rawKind);
        public abstract bool IsTriviaWithEndOfLine(SyntaxKind rawKind);

        public abstract string GetKindText(int rawKind);
        public abstract string GetText(int rawKind);
        public abstract object GetValue(int rawKind);
        public abstract int GetKeywordKind(string text);
        public abstract int GetContextualKeywordKind(string text);
        public abstract int GetPreprocessorKeywordKind(string text);

        public abstract IEnumerable<SyntaxKind> GetReservedKeywordKinds();
        public abstract IEnumerable<SyntaxKind> GetContextualKeywordKinds();

        public bool IsCommentTrivia(SyntaxKind rawKind)
        {
            return IsGeneralCommentTrivia(rawKind) || IsDocumentationCommentTrivia(rawKind);
        }

        public bool IsKeyword(SyntaxKind kind)
        {
            return IsReservedKeyword(kind) || IsContextualKeyword(kind);
        }

        public IEnumerable<SyntaxKind> GetKeywordKinds()
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
            if (IsPreprocessorDirective(trivia.GetKind()))
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
                    if (node.Parent.GetKind() == SyntaxKind.CompilationUnit)
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
        public virtual string ExtractMetadataName(LanguageSyntaxNode node)
        {
            return null;
        }
        public virtual string ExtractMetadataName(SyntaxToken token)
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
        public virtual TypeKind ToTypeKind(ModelSymbolInfo info)
        {
            return TypeKind.Class;
        }

        public virtual bool IsWeakChild(SyntaxNode node)
        {
            return false;
        }

        public abstract bool IsInNamespaceOrTypeContext(SyntaxNode node);
        public abstract bool IsStatement(SyntaxNode syntax);
        public abstract bool IsExpression(SyntaxNode node);
    }
}
