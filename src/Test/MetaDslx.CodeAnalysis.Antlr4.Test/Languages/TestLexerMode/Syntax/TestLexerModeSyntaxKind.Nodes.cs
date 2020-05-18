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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax
{
	public class TestLexerModeSyntaxKind : TestLexerModeTokensSyntaxKind
	{
        public static new readonly TestLexerModeSyntaxKind __FirstToken;
        public static new readonly TestLexerModeSyntaxKind __LastToken;
        public static new readonly TestLexerModeSyntaxKind __FirstFixedToken;
        public static new readonly TestLexerModeSyntaxKind __LastFixedToken;
        public static readonly TestLexerModeSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly TestLexerModeSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string GeneratorDeclaration = nameof(GeneratorDeclaration);
		public const string UsingNamespaceDeclaration = nameof(UsingNamespaceDeclaration);
		public const string UsingGeneratorDeclaration = nameof(UsingGeneratorDeclaration);
		public const string ConfigDeclaration = nameof(ConfigDeclaration);
		public const string ConfigPropertyDeclaration = nameof(ConfigPropertyDeclaration);
		public const string ConfigPropertyGroupDeclaration = nameof(ConfigPropertyGroupDeclaration);
		public const string MethodDeclaration = nameof(MethodDeclaration);
		public const string ExternFunctionDeclaration = nameof(ExternFunctionDeclaration);
		public const string FunctionDeclaration = nameof(FunctionDeclaration);
		public const string FunctionSignature = nameof(FunctionSignature);
		public const string ParamList = nameof(ParamList);
		public const string Parameter = nameof(Parameter);
		public const string Body = nameof(Body);
		public const string Statement = nameof(Statement);
		public const string SingleStatement = nameof(SingleStatement);
		public const string SingleStatementSemicolon = nameof(SingleStatementSemicolon);
		public const string VariableDeclarationStatement = nameof(VariableDeclarationStatement);
		public const string VariableDeclarationExpression = nameof(VariableDeclarationExpression);
		public const string VariableDeclarationItem = nameof(VariableDeclarationItem);
		public const string VoidStatement = nameof(VoidStatement);
		public const string ReturnStatement = nameof(ReturnStatement);
		public const string ExpressionStatement = nameof(ExpressionStatement);
		public const string IfStatement = nameof(IfStatement);
		public const string ElseIfStatementBody = nameof(ElseIfStatementBody);
		public const string IfStatementElseBody = nameof(IfStatementElseBody);
		public const string IfStatementBegin = nameof(IfStatementBegin);
		public const string ElseIfStatement = nameof(ElseIfStatement);
		public const string IfStatementElse = nameof(IfStatementElse);
		public const string IfStatementEnd = nameof(IfStatementEnd);
		public const string ForStatement = nameof(ForStatement);
		public const string ForStatementBegin = nameof(ForStatementBegin);
		public const string ForStatementEnd = nameof(ForStatementEnd);
		public const string ForInitStatement = nameof(ForInitStatement);
		public const string WhileStatement = nameof(WhileStatement);
		public const string WhileStatementBegin = nameof(WhileStatementBegin);
		public const string WhileStatementEnd = nameof(WhileStatementEnd);
		public const string WhileRunExpression = nameof(WhileRunExpression);
		public const string RepeatStatement = nameof(RepeatStatement);
		public const string RepeatStatementBegin = nameof(RepeatStatementBegin);
		public const string RepeatStatementEnd = nameof(RepeatStatementEnd);
		public const string RepeatRunExpression = nameof(RepeatRunExpression);
		public const string LoopStatement = nameof(LoopStatement);
		public const string LoopStatementBegin = nameof(LoopStatementBegin);
		public const string LoopStatementEnd = nameof(LoopStatementEnd);
		public const string LoopChain = nameof(LoopChain);
		public const string LoopChainItem = nameof(LoopChainItem);
		public const string LoopChainTypeofExpression = nameof(LoopChainTypeofExpression);
		public const string LoopChainIdentifierExpression = nameof(LoopChainIdentifierExpression);
		public const string LoopChainMemberAccessExpression = nameof(LoopChainMemberAccessExpression);
		public const string LoopChainMethodCallExpression = nameof(LoopChainMethodCallExpression);
		public const string LoopWhereExpression = nameof(LoopWhereExpression);
		public const string LoopRunExpression = nameof(LoopRunExpression);
		public const string SeparatorStatement = nameof(SeparatorStatement);
		public const string SwitchStatement = nameof(SwitchStatement);
		public const string SwitchStatementBegin = nameof(SwitchStatementBegin);
		public const string SwitchStatementEnd = nameof(SwitchStatementEnd);
		public const string SwitchBranchStatement = nameof(SwitchBranchStatement);
		public const string SwitchBranchHeadStatement = nameof(SwitchBranchHeadStatement);
		public const string SwitchCaseOrTypeIsHeadStatements = nameof(SwitchCaseOrTypeIsHeadStatements);
		public const string SwitchCaseOrTypeIsHeadStatement = nameof(SwitchCaseOrTypeIsHeadStatement);
		public const string SwitchCaseHeadStatement = nameof(SwitchCaseHeadStatement);
		public const string SwitchTypeIsHeadStatement = nameof(SwitchTypeIsHeadStatement);
		public const string SwitchTypeAsHeadStatement = nameof(SwitchTypeAsHeadStatement);
		public const string SwitchDefaultStatement = nameof(SwitchDefaultStatement);
		public const string SwitchDefaultHeadStatement = nameof(SwitchDefaultHeadStatement);
		public const string TemplateDeclaration = nameof(TemplateDeclaration);
		public const string TemplateSignature = nameof(TemplateSignature);
		public const string TemplateBody = nameof(TemplateBody);
		public const string TemplateContentLine = nameof(TemplateContentLine);
		public const string TemplateContent = nameof(TemplateContent);
		public const string TemplateOutput = nameof(TemplateOutput);
		public const string TemplateLineEnd = nameof(TemplateLineEnd);
		public const string TemplateStatementStartEnd = nameof(TemplateStatementStartEnd);
		public const string TemplateStatement = nameof(TemplateStatement);
		public const string TypeArgumentList = nameof(TypeArgumentList);
		public const string PredefinedType = nameof(PredefinedType);
		public const string TypeReferenceList = nameof(TypeReferenceList);
		public const string TypeReference = nameof(TypeReference);
		public const string ArrayType = nameof(ArrayType);
		public const string ArrayItemType = nameof(ArrayItemType);
		public const string NullableType = nameof(NullableType);
		public const string NullableItemType = nameof(NullableItemType);
		public const string GenericType = nameof(GenericType);
		public const string SimpleType = nameof(SimpleType);
		public const string VoidType = nameof(VoidType);
		public const string ReturnType = nameof(ReturnType);
		public const string ExpressionList = nameof(ExpressionList);
		public const string VariableReference = nameof(VariableReference);
		public const string RankSpecifiers = nameof(RankSpecifiers);
		public const string RankSpecifier = nameof(RankSpecifier);
		public const string UnboundTypeName = nameof(UnboundTypeName);
		public const string GenericDimensionItem = nameof(GenericDimensionItem);
		public const string GenericDimensionSpecifier = nameof(GenericDimensionSpecifier);
		public const string ExplicitAnonymousFunctionSignature = nameof(ExplicitAnonymousFunctionSignature);
		public const string ImplicitAnonymousFunctionSignature = nameof(ImplicitAnonymousFunctionSignature);
		public const string SingleParamAnonymousFunctionSignature = nameof(SingleParamAnonymousFunctionSignature);
		public const string ExplicitParameter = nameof(ExplicitParameter);
		public const string ImplicitParameter = nameof(ImplicitParameter);
		public const string ThisExpression = nameof(ThisExpression);
		public const string LiteralExpression = nameof(LiteralExpression);
		public const string TypeofVoidExpression = nameof(TypeofVoidExpression);
		public const string TypeofUnboundTypeExpression = nameof(TypeofUnboundTypeExpression);
		public const string TypeofTypeExpression = nameof(TypeofTypeExpression);
		public const string DefaultValueExpression = nameof(DefaultValueExpression);
		public const string NewObjectOrCollectionWithConstructorExpression = nameof(NewObjectOrCollectionWithConstructorExpression);
		public const string IdentifierExpression = nameof(IdentifierExpression);
		public const string HasLoopExpression = nameof(HasLoopExpression);
		public const string ParenthesizedExpression = nameof(ParenthesizedExpression);
		public const string ElementAccessExpression = nameof(ElementAccessExpression);
		public const string FunctionCallExpression = nameof(FunctionCallExpression);
		public const string PredefinedTypeMemberAccessExpression = nameof(PredefinedTypeMemberAccessExpression);
		public const string MemberAccessExpression = nameof(MemberAccessExpression);
		public const string TypecastExpression = nameof(TypecastExpression);
		public const string UnaryExpression = nameof(UnaryExpression);
		public const string PostExpression = nameof(PostExpression);
		public const string MultiplicationExpression = nameof(MultiplicationExpression);
		public const string AdditionExpression = nameof(AdditionExpression);
		public const string RelationalExpression = nameof(RelationalExpression);
		public const string TypecheckExpression = nameof(TypecheckExpression);
		public const string EqualityExpression = nameof(EqualityExpression);
		public const string BitwiseAndExpression = nameof(BitwiseAndExpression);
		public const string BitwiseXorExpression = nameof(BitwiseXorExpression);
		public const string BitwiseOrExpression = nameof(BitwiseOrExpression);
		public const string LogicalAndExpression = nameof(LogicalAndExpression);
		public const string LogicalXorExpression = nameof(LogicalXorExpression);
		public const string LogicalOrExpression = nameof(LogicalOrExpression);
		public const string ConditionalExpression = nameof(ConditionalExpression);
		public const string AssignmentExpression = nameof(AssignmentExpression);
		public const string LambdaExpression = nameof(LambdaExpression);
		public const string QualifiedName = nameof(QualifiedName);
		public const string IdentifierList = nameof(IdentifierList);
		public const string Identifier = nameof(Identifier);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string NumberLiteral = nameof(NumberLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string DateOrTimeLiteral = nameof(DateOrTimeLiteral);
		public const string DateTimeOffsetLiteral = nameof(DateTimeOffsetLiteral);
		public const string DateTimeLiteral = nameof(DateTimeLiteral);
		public const string DateLiteral = nameof(DateLiteral);
		public const string TimeLiteral = nameof(TimeLiteral);
		public const string CharLiteral = nameof(CharLiteral);
		public const string StringLiteral = nameof(StringLiteral);
		public const string GuidLiteral = nameof(GuidLiteral);

		protected TestLexerModeSyntaxKind(string name)
            : base(name)
        {
        }

        protected TestLexerModeSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLexerModeSyntaxKind()
        {
            EnumObject.AutoInit<TestLexerModeSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = COMMENT_START;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = DoubleQuoteVerbatimStringLiteralStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = GuidLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator TestLexerModeSyntaxKind(string name)
        {
            return FromString<TestLexerModeSyntaxKind>(name);
        }

        public static explicit operator TestLexerModeSyntaxKind(int value)
        {
            return FromIntUnsafe<TestLexerModeSyntaxKind>(value);
        }

	}
}

