// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Compiler.Syntax
{
	public class CompilerSyntaxKind : CompilerTokensSyntaxKind
	{
        public static new readonly CompilerSyntaxKind __FirstToken;
        public static new readonly CompilerSyntaxKind __LastToken;
        public static new readonly CompilerSyntaxKind __FirstFixedToken;
        public static new readonly CompilerSyntaxKind __LastFixedToken;
        public static readonly CompilerSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly CompilerSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Annotation = nameof(Annotation);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string NamespaceBody = nameof(NamespaceBody);
		public const string GrammarDeclaration = nameof(GrammarDeclaration);
		public const string UsingDeclaration = nameof(UsingDeclaration);
		public const string RuleDeclarations = nameof(RuleDeclarations);
		public const string RuleDeclaration = nameof(RuleDeclaration);
		public const string ParserRuleDeclaration = nameof(ParserRuleDeclaration);
		public const string ParserRuleAlt = nameof(ParserRuleAlt);
		public const string ParserRuleAltRef = nameof(ParserRuleAltRef);
		public const string ParserRuleSimple = nameof(ParserRuleSimple);
		public const string EofElement = nameof(EofElement);
		public const string ParserRuleNamedElement = nameof(ParserRuleNamedElement);
		public const string Assign = nameof(Assign);
		public const string Multiplicity = nameof(Multiplicity);
		public const string ParserNegatedElement = nameof(ParserNegatedElement);
		public const string ParserRuleElement = nameof(ParserRuleElement);
		public const string ParserRuleFixedElement = nameof(ParserRuleFixedElement);
		public const string ParserRuleWildcardElement = nameof(ParserRuleWildcardElement);
		public const string ParserRuleReference = nameof(ParserRuleReference);
		public const string ParserRuleBlockElement = nameof(ParserRuleBlockElement);
		public const string LexerRuleDeclaration = nameof(LexerRuleDeclaration);
		public const string LexerRuleAlternative = nameof(LexerRuleAlternative);
		public const string LexerRuleAlternativeElement = nameof(LexerRuleAlternativeElement);
		public const string LexerRuleElement = nameof(LexerRuleElement);
		public const string LexerRuleReferenceElement = nameof(LexerRuleReferenceElement);
		public const string LexerRuleWildcardElement = nameof(LexerRuleWildcardElement);
		public const string LexerRuleFixedStringElement = nameof(LexerRuleFixedStringElement);
		public const string LexerRuleFixedCharElement = nameof(LexerRuleFixedCharElement);
		public const string LexerRuleBlockElement = nameof(LexerRuleBlockElement);
		public const string LexerRuleRangeElement = nameof(LexerRuleRangeElement);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string Identifier = nameof(Identifier);
		public const string LexerRuleIdentifier = nameof(LexerRuleIdentifier);
		public const string ParserRuleIdentifier = nameof(ParserRuleIdentifier);
		public const string LexerRuleName = nameof(LexerRuleName);
		public const string ParserRuleName = nameof(ParserRuleName);
		public const string ElementName = nameof(ElementName);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string StringLiteral = nameof(StringLiteral);
		public const string CharLiteral = nameof(CharLiteral);

		protected CompilerSyntaxKind(string name)
            : base(name)
        {
        }

        protected CompilerSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static CompilerSyntaxKind()
        {
            EnumObject.AutoInit<CompilerSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LMultilineComment;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = TGreaterThan;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = CharLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator CompilerSyntaxKind(string name)
        {
            return FromString<CompilerSyntaxKind>(name);
        }

        public static explicit operator CompilerSyntaxKind(int value)
        {
            return FromIntUnsafe<CompilerSyntaxKind>(value);
        }

	}
}

