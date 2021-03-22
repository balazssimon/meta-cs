using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public abstract SyntaxKind DefaultWhitespaceKind { get; }
        public abstract SyntaxKind DefaultEndOfLineKind { get; }
        public abstract SyntaxKind DefaultSeparatorKind { get; }
        public abstract SyntaxKind DefaultIdentifierKind { get; }
        public virtual SyntaxKind EndOfDirectiveTokenKind => SyntaxKind.None;
        public virtual SyntaxKind CompilationUnitKind => SyntaxKind.None;

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
            return ExtractValue(text);
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

        public virtual ImmutableArray<ExternAliasDirective> GetExternAliasDirectives(LanguageSyntaxNode declarationSyntax)
        {
            return ImmutableArray<ExternAliasDirective>.Empty;
        }

        public virtual ImmutableArray<UsingDirective> GetUsingDirectives(LanguageSyntaxNode declarationSyntax)
        {
            return ImmutableArray<UsingDirective>.Empty;
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
                    if (node.Parent.GetKind() == CompilationUnitKind)
                    {
                        return 0;
                    }

                    int parentDepth = GetDeclarationDepth(node.Parent);
                    return parentDepth;
                }
            }

            return 0;
        }

        public virtual bool IsGlobalAlias(SyntaxNodeOrToken nodeOrToken)
        {
            return ExtractName(nodeOrToken) == "global";
        }

        public virtual string ExtractName(SyntaxNodeOrToken nodeOrToken)
        {
            if (nodeOrToken.IsToken) return nodeOrToken.AsToken().ValueText;
            else return nodeOrToken.AsNode().ToString();
        }

        public virtual string ExtractErrorDisplayName(SyntaxNodeOrToken nodeOrToken)
        {
            return null;
        }

        public virtual ImmutableArray<string> ExtractQualifiedName(SyntaxNodeOrToken nodeOrToken)
        {
            string name = this.ExtractName(nodeOrToken);
            return ExtractQualifiedName(name);
        }

        public virtual ImmutableArray<string> ExtractQualifiedName(string qualifiedNameAsString)
        {
            if (string.IsNullOrWhiteSpace(qualifiedNameAsString)) return ImmutableArray<string>.Empty;
            else return qualifiedNameAsString.Split('.').ToImmutableArray();
        }

        public virtual string ExtractMetadataName(SyntaxNodeOrToken nodeOrToken)
        {
            if (nodeOrToken.IsToken) return nodeOrToken.AsToken().ValueText;
            else return nodeOrToken.AsNode().ToString();
        }

        public virtual object ExtractValue(SyntaxNodeOrToken nodeOrToken)
        {
            if (nodeOrToken.IsToken) return nodeOrToken.AsToken().Value;
            else return ExtractValue(nodeOrToken.AsNode().ToString());
        }

        public virtual object ExtractValue(string value)
        {
            if (value == "null") return null;
            if (value.Length >= 3 && value.StartsWith("@\'") && value.EndsWith("\'"))
            {
                return value.Substring(2, value.Length - 3).Replace("\'\'", "\'");
            }
            else if (value.Length >= 2 && value.StartsWith("\'") && value.EndsWith("\'"))
            {
                return StringUtilities.UnescapeCharLiteralValue(value.Substring(1, value.Length - 2));
            }
            else if (value.Length >= 3 && value.StartsWith("@\"") && value.EndsWith("\""))
            {
                return value.Substring(2, value.Length - 3).Replace("\"\"", "\"");
            }
            else if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return StringUtilities.UnescapeStringLiteralValue(value.Substring(1, value.Length - 2));
            }
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            long longValue;
            if (long.TryParse(value, out longValue))
            {
                return longValue;
            }
            float floatValue;
            if (float.TryParse(value, out floatValue))
            {
                return floatValue;
            }
            double doubleValue;
            if (double.TryParse(value, out doubleValue))
            {
                return doubleValue;
            }
            return value;
        }

        public virtual TypeKind ToTypeKind(ModelObjectDescriptor info)
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

        public virtual bool IsDynamicTypeDeclaration(SyntaxNodeOrToken syntax)
        {
            return ExtractName(syntax) == "global";
        }

        public virtual bool IsVarTypeDeclaration(SyntaxNodeOrToken syntax)
        {
            return ExtractName(syntax) == "var";
        }

        public virtual bool IsExternAliasDirective(SyntaxKind syntax)
        {
            return false;
        }

        public virtual bool IsUsingDirective(SyntaxNodeOrToken syntax)
        {
            return false;
        }

        public virtual bool IsInTypeOnlyContext(SyntaxNodeOrToken syntax)
        {
            return false;
        }

        public virtual bool IsInNamespaceOrTypeContext(SyntaxNodeOrToken syntax)
        {
            return false;
        }

        public virtual bool IsStatement(SyntaxNodeOrToken syntax)
        {
            return false;
        }

        public virtual bool IsExpression(SyntaxNodeOrToken syntax)
        {
            return false;
        }
    }
}
