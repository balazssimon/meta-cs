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

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax
{
	public class TestLangOneSyntaxKind : TestLangOneTokensSyntaxKind
	{
        public static new readonly TestLangOneSyntaxKind __FirstToken;
        public static new readonly TestLangOneSyntaxKind __LastToken;
        public static new readonly TestLangOneSyntaxKind __FirstFixedToken;
        public static new readonly TestLangOneSyntaxKind __LastFixedToken;
        public static readonly TestLangOneSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly TestLangOneSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Test = nameof(Test);
		public const string Test01 = nameof(Test01);
		public const string NamespaceDeclaration01 = nameof(NamespaceDeclaration01);
		public const string NamespaceBody01 = nameof(NamespaceBody01);
		public const string Declaration01 = nameof(Declaration01);
		public const string Vertex01 = nameof(Vertex01);
		public const string Arrow01 = nameof(Arrow01);
		public const string Test02 = nameof(Test02);
		public const string NamespaceDeclaration02 = nameof(NamespaceDeclaration02);
		public const string NamespaceBody02 = nameof(NamespaceBody02);
		public const string Declaration02 = nameof(Declaration02);
		public const string Vertex02 = nameof(Vertex02);
		public const string Arrow02 = nameof(Arrow02);
		public const string Source02 = nameof(Source02);
		public const string Target02 = nameof(Target02);
		public const string Test03 = nameof(Test03);
		public const string NamespaceDeclaration03 = nameof(NamespaceDeclaration03);
		public const string NamespaceBody03 = nameof(NamespaceBody03);
		public const string Declaration03 = nameof(Declaration03);
		public const string Vertex03 = nameof(Vertex03);
		public const string Arrow03 = nameof(Arrow03);
		public const string Source03 = nameof(Source03);
		public const string Target03 = nameof(Target03);
		public const string Test04 = nameof(Test04);
		public const string NamespaceDeclaration04 = nameof(NamespaceDeclaration04);
		public const string NamespaceBody04 = nameof(NamespaceBody04);
		public const string Declaration04 = nameof(Declaration04);
		public const string Vertex04 = nameof(Vertex04);
		public const string Arrow04 = nameof(Arrow04);
		public const string Test05 = nameof(Test05);
		public const string NamespaceDeclaration05 = nameof(NamespaceDeclaration05);
		public const string NamespaceBody05 = nameof(NamespaceBody05);
		public const string Declaration05 = nameof(Declaration05);
		public const string Vertex05 = nameof(Vertex05);
		public const string Arrow05 = nameof(Arrow05);
		public const string Test06 = nameof(Test06);
		public const string NamespaceDeclaration06 = nameof(NamespaceDeclaration06);
		public const string NamespaceBody06 = nameof(NamespaceBody06);
		public const string Declaration06 = nameof(Declaration06);
		public const string Vertex06 = nameof(Vertex06);
		public const string Arrow06 = nameof(Arrow06);
		public const string Test07 = nameof(Test07);
		public const string NamespaceDeclaration07 = nameof(NamespaceDeclaration07);
		public const string NamespaceBody07 = nameof(NamespaceBody07);
		public const string Declaration07 = nameof(Declaration07);
		public const string Vertex07 = nameof(Vertex07);
		public const string Arrow07 = nameof(Arrow07);
		public const string Source07 = nameof(Source07);
		public const string Target07 = nameof(Target07);
		public const string Test08 = nameof(Test08);
		public const string NamespaceDeclaration08 = nameof(NamespaceDeclaration08);
		public const string NamespaceBody08 = nameof(NamespaceBody08);
		public const string Declaration08 = nameof(Declaration08);
		public const string Vertex08 = nameof(Vertex08);
		public const string Arrow08 = nameof(Arrow08);
		public const string Source08 = nameof(Source08);
		public const string Target08 = nameof(Target08);
		public const string Test09 = nameof(Test09);
		public const string NamespaceDeclaration09 = nameof(NamespaceDeclaration09);
		public const string NamespaceBody09 = nameof(NamespaceBody09);
		public const string Declaration09 = nameof(Declaration09);
		public const string Vertex09 = nameof(Vertex09);
		public const string Arrow09 = nameof(Arrow09);
		public const string Test10 = nameof(Test10);
		public const string NamespaceDeclaration10 = nameof(NamespaceDeclaration10);
		public const string NamespaceBody10 = nameof(NamespaceBody10);
		public const string Declaration10 = nameof(Declaration10);
		public const string Vertex10 = nameof(Vertex10);
		public const string Arrow10 = nameof(Arrow10);
		public const string Test11 = nameof(Test11);
		public const string NamespaceDeclaration11 = nameof(NamespaceDeclaration11);
		public const string NamespaceBody11 = nameof(NamespaceBody11);
		public const string Declaration11 = nameof(Declaration11);
		public const string Vertex11 = nameof(Vertex11);
		public const string Arrow11 = nameof(Arrow11);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string Identifier = nameof(Identifier);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string StringLiteral = nameof(StringLiteral);

		protected TestLangOneSyntaxKind(string name)
            : base(name)
        {
        }

        protected TestLangOneSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLangOneSyntaxKind()
        {
            EnumObject.AutoInit<TestLangOneSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LCommentStart;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = LCommentStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = StringLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator TestLangOneSyntaxKind(string name)
        {
            return FromString<TestLangOneSyntaxKind>(name);
        }

        public static explicit operator TestLangOneSyntaxKind(int value)
        {
            return FromIntUnsafe<TestLangOneSyntaxKind>(value);
        }

	}
}

