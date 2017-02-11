﻿using MetaDslx.Compiler.MetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public enum TypeKind
    {
        Field,
        Public
    }

    internal static class CompilerGeneratorUtils
    {
        public static string ToCamelCase(this string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            if (identifier.ToCharArray().All(c => char.IsUpper(c))) identifier = identifier.ToLower();
            string result = identifier[0].ToString().ToLower() + identifier.Substring(1);
            if (reservedNames.Contains(result)) result = "_" + result;
            return result;
        }

        public static string ToPascalCase(this string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            //else if (identifier.ToCharArray().All(c => char.IsUpper(c))) return identifier[0].ToString().ToUpper() + identifier.Substring(1).ToLower();
            else return identifier[0].ToString().ToUpper() + identifier.Substring(1);
        }

        public static List<int> Range(int n)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                result.Add(i);
            }
            return result;
        }

        public static Antlr4ParserRule MainRule(this Antlr4Grammar grammar)
        {
            return grammar.ParserRules.FirstOrDefault();
        }

        public static Antlr4LexerRule FirstLiteral(this Antlr4Grammar grammar)
        {
            return grammar.LexerRules.Where(rule => rule.FixedToken != null).FirstOrDefault();
        }

        public static Antlr4LexerRule LastLiteral(this Antlr4Grammar grammar)
        {
            return grammar.LexerRules.Where(rule => rule.FixedToken != null).LastOrDefault();
        }

        public static bool HasEof(this Antlr4ParserRule rule)
        {
            return rule.Alternatives.Count == 0 && rule.Elements.Any(e => e.Type == "EOF");
        }

        public static string GreenName(this Antlr4ParserRule rule)
        {
            return rule.Name.ToPascalCase() + "Green";
        }

        public static string RedName(this Antlr4ParserRule rule)
        {
            return rule.Name.ToPascalCase() + "Syntax";
        }

        public static string PlainName(this Antlr4ParserRule rule)
        {
            return rule.Name.ToPascalCase();
        }

        public static string PlainName(this Antlr4LexerRule rule)
        {
            return rule.Name.ToPascalCase();
        }

        public static bool HasOptionalElements(this Antlr4ParserRule rule)
        {
            return rule.Elements.Any(e => e.IsOptional || (e.IsToken && e.IsFixedToken && !e.IsList));
        }

        public static string GreenName(this Antlr4ParserRuleElement elem)
        {
            if (elem.Name == "EOF") return "Eof";
            else return elem.Name.ToPascalCase();
        }

        public static string RedName(this Antlr4ParserRuleElement elem)
        {
            if (elem.Name == "EOF") return "Eof";
            else return elem.Name.ToPascalCase();
        }

        public static string Antlr4Name(this Antlr4ParserRuleElement elem)
        {
            if (elem.Name != elem.Type) return elem.Name;
            else
            {
                if (elem.Type == "EOF") return "Eof()";
                return elem.Name + "()";
            }
        }

        public static int IndexOf(this Antlr4ParserRule rule, Antlr4ParserRuleElement elem)
        {
            return rule.AllElements.IndexOf(elem);
        }

        public static string PlainType(this Antlr4ParserRuleElement elem, bool simplified = true)
        {
            string typeName = elem.Type;
            if (!simplified && elem.IsSimplified) typeName = elem.OriginalType;
            if (elem.IsToken)
            {
                StringBuilder builder = new StringBuilder();
                string name = typeName;
                for (int i = 0; i < name.Length; i++)
                {
                    if (i == 0)
                    {
                        builder.Append(char.ToUpper(name[i]));
                    }
                    else if(name[i] == '_')
                    {
                        ++i;
                        if (i < name.Length) builder.Append(char.ToUpper(name[i]));
                    }
                    else
                    {
                        builder.Append(char.ToLower(name[i]));
                    }
                }
                return builder.ToString();
            }
            else
            {
                return typeName.ToPascalCase();
            }
        }
       
        public static string GreenType(this Antlr4ParserRuleElement elem, TypeKind kind, bool simplified = true)
        {
            if (!simplified && elem.IsSimplified)
            {
                return elem.OriginalType.ToPascalCase() + "Green";
            }
            /*if (kind == TypeKind.Public)
            {
                if (elem.IsBlock)
                {
                    if (elem.IsFixedTokenAltBlock) return "InternalSyntaxToken";
                    else return "InternalSyntaxNode";
                }
                else if (elem.IsList)
                {
                    if (elem.IsSeparated) return "InternalSeparatedNodeList<" + elem.Type.ToPascalCase() + "Green>";
                    else if (elem.IsToken) return "InternalSyntaxList<InternalSyntaxToken>";
                    else return "InternalNodeList<" + elem.Type.ToPascalCase() + "Green>";
                }
                else
                {
                    if (elem.IsToken) return "InternalSyntaxToken";
                    else return elem.Type.ToPascalCase() + "Green";
                }
            }
            else if (kind == TypeKind.Field)*/
            {
                if (elem.IsBlock)
                {
                    if (elem.IsFixedTokenAltBlock) return "InternalSyntaxToken";
                    else return "InternalSyntaxNode";
                }
                else if (elem.IsList)
                {
                    if (elem.IsToken) return "InternalSyntaxTokenList";
                    else if (elem.IsSeparated) return "InternalSeparatedSyntaxNodeList";
                    else return "InternalSyntaxNodeList";
                }
                else if (elem.IsToken) return "InternalSyntaxToken";
                else return elem.Type.ToPascalCase() + "Green";
            }
            throw new NotSupportedException("Invalid type kind.");
        }

        public static string GreenInnerType(this Antlr4ParserRuleElement elem)
        {
            if (elem.IsBlock)
            {
                if (elem.IsFixedTokenAltBlock) return "InternalSyntaxToken";
                else return "InternalSyntaxNode";
            }
            else if (elem.IsToken) return "InternalSyntaxToken";
            else if (elem.IsList) return elem.Type.ToPascalCase() + "Green";
            else return elem.Type.ToPascalCase() + "Green";
        }

        public static string RedFieldType(this Antlr4ParserRuleElement elem)
        {
            if (elem.IsBlock)
            {
                if (elem.IsFixedTokenAltBlock) return "SyntaxToken";
                else return "SyntaxNode";
            }
            else if (elem.IsList)
            {
                if (elem.IsSeparated) return "SeparatedSyntaxNodeList";
                else if (elem.IsToken) return "SyntaxTokenList";
                else return "SyntaxNodeList";
            }
            else if (elem.IsToken) return "SyntaxToken";
            else return elem.Type.ToPascalCase() + "Syntax";
        }

        public static string RedType(this Antlr4ParserRuleElement elem)
        {
            if (elem.IsBlock)
            {
                if (elem.IsFixedTokenAltBlock) return "SyntaxToken";
                else return "SyntaxNode";
            }
            else if (elem.IsList)
            {
                if (elem.IsSeparated) return "SeparatedSyntaxNodeList<" + elem.Type.ToPascalCase() + "Syntax>";
                else if (elem.IsToken) return "SyntaxTokenList";
                else return "SyntaxNodeList<" + elem.Type.ToPascalCase() + "Syntax>";
            }
            else if (elem.IsToken) return "SyntaxToken";
            else return elem.Type.ToPascalCase() + "Syntax";
        }

        public static string RedInnerType(this Antlr4ParserRuleElement elem)
        {
            if (elem.IsBlock)
            {
                if (elem.IsFixedTokenAltBlock) return "SyntaxToken";
                else return "SyntaxNode";
            }
            else if (elem.IsList) return elem.Type.ToPascalCase() + "Syntax";
            else if (elem.IsToken) return "SyntaxToken";
            else return elem.Type.ToPascalCase() + "Syntax";
        }

        public static string FieldName(this Antlr4ParserRuleElement elem)
        {
            string result = elem.Name.ToCamelCase();
            return result;
        }

        public static string SyntaxKind(this Antlr4ParserRuleElement elem)
        {
            string result = elem.Type;
            if (result == "EOF") return "Eof";
            return result;
        }

        public static bool IsEof(this Antlr4ParserRuleElement elem)
        {
            return elem.Type == "EOF";
        }

        public static string FixedTokenToCSharpString(this string literal)
        {
            return Antlr4RoslynCompiler.FixedTokenToCSharpString(literal);
        }

        public static bool IsDeclaration(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.NameDef) || annots.HasAnnotation(MetaCompilerAnnotationInfo.TypeDef);
        }

        public static bool IsSymbolBoundary(this MetaCompilerAnnotations annots)
        {
            return annots.Annotations.Any(a => MetaCompilerAnnotationInfo.SymbolBoundary.Contains(a.Name));
        }

        public static bool IsSymbolType(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.SymbolType);
        }

        public static bool IsRootScope(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.RootScope);
        }

        public static bool IsIdentifier(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.Identifier);
        }

        public static bool IsName(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.Name);
        }

        public static bool IsProperty(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.Property);
        }

        public static bool IsQualifiedName(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.QualifiedName);
        }

        public static bool IsNameCtr(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.NameCtr);
        }

        public static bool IsTypeCtr(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.TypeCtr);
        }

        public static bool IsNameUse(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.NameUse);
        }

        public static bool IsTypeUse(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.TypeUse);
        }

        public static bool IsConstant(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.Constant);
        }

        public static bool IsValue(this MetaCompilerAnnotations annots)
        {
            return annots.HasAnnotation(MetaCompilerAnnotationInfo.Value);
        }

        public static string GetNestingProperty(this MetaCompilerAnnotations annots)
        {
            foreach (var annot in annots.Annotations)
            {
                foreach (var prop in annot.Properties)
                {
                    if (prop.Name == "nestingProperty") return "\"" + prop.Value + "\"";
                }
            }
            return "null";
        }

        public static string GetSymbolType(this MetaCompilerAnnotations annots, string name)
        {
            foreach (var annot in annots.Annotations)
            {
                if (annot.Name == name)
                {
                    foreach (var prop in annot.Properties)
                    {
                        if (prop.Name == "symbolType") return "typeof(Symbols." + prop.Value + ")";
                    }
                }
            }
            return "null";
        }
        public static string GetSymbolType(this MetaCompilerAnnotations annots)
        {
            foreach (var annot in annots.Annotations)
            {
                foreach (var prop in annot.Properties)
                {
                    if (prop.Name == "symbolType") return "typeof(Symbols." + prop.Value + ")";
                }
            }
            return "null";
        }


        internal static readonly string[] reservedNames =
            {
                "abstract",
                "as",
                "base",
                "bool",
                "break",
                "byte",
                "case",
                "catch",
                "char",
                "checked",
                "class",
                "const",
                "continue",
                "decimal",
                "default",
                "delegate",
                "do",
                "double",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "float",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "int",
                "interface",
                "internal",
                "is",
                "lock",
                "long",
                "namespace",
                "new",
                "null",
                "object",
                "operator",
                "out",
                "override",
                "params",
                "private",
                "protected",
                "public",
                "readonly",
                "ref",
                "return",
                "sbyte",
                "sealed",
                "short",
                "sizeof",
                "stackalloc",
                "static",
                "string",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "uint",
                "ulong",
                "unchecked",
                "unsafe",
                "ushort",
                "using",
                "virtual",
                "void",
                "volatile",
                "while",
            };

    }
}
