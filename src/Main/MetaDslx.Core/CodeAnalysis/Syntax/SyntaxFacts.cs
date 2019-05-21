using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
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

        private Type _syntaxKindType;

        public SyntaxFacts(Type syntaxKindType)
        {
            _syntaxKindType = syntaxKindType;
        }

        public Type SyntaxKindType => _syntaxKindType;

        public SyntaxKind ToLanguageSyntaxKind(SyntaxKind kind)
        {
            return (SyntaxKind)kind.CastUnsafe(_syntaxKindType);
        }
        public abstract bool IsToken(SyntaxKind kind);
        public abstract bool IsFixedToken(SyntaxKind kind);
        public abstract bool IsTrivia(SyntaxKind kind);
        public abstract bool IsReservedKeyword(SyntaxKind kind);
        public abstract bool IsContextualKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorContextualKeyword(SyntaxKind kind);
        public abstract bool IsPreprocessorDirective(SyntaxKind kind);
        public abstract bool IsIdentifier(SyntaxKind rawKind);
        public abstract bool IsGeneralCommentTrivia(SyntaxKind rawKind);
        public abstract bool IsDocumentationCommentTrivia(SyntaxKind rawKind);

        public virtual string GetKindText(SyntaxKind kind)
        {
            return kind.ToString();
        }

        public abstract string GetText(SyntaxKind kind);

        public virtual object GetValue(SyntaxKind kind)
        {
            string text = GetText(kind);
            if (text == "null") return null;
            if (text == "true") return true;
            if (text == "false") return false;
            if (int.TryParse(text, out int i)) return i;
            if (double.TryParse(text, out double d)) return d;
            return text;
        }

        public abstract SyntaxKind GetReservedKeywordKind(string text);
        public abstract SyntaxKind GetContextualKeywordKind(string text);
        public abstract SyntaxKind GetFixedTokenKind(string text);

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

        public virtual bool IsTriviaWithEndOfLine(SyntaxKind kind)
        {
            return false;
        }

        public virtual bool IsTriviaWithEndOfLine(GreenNode trivia)
        {
            if (trivia is InternalSyntaxTrivia internalSyntaxTrivia)
            {
                string text = internalSyntaxTrivia.Text;
                if (string.IsNullOrEmpty(text)) return false;
                if (text.EndsWith("\r") || text.EndsWith("\n")) return true;
            }
            return false;
        }

        public abstract bool IsInNamespaceOrTypeContext(SyntaxNode node);
        public abstract bool IsStatement(SyntaxNode syntax);
        public abstract bool IsExpression(SyntaxNode node);
    }
}
