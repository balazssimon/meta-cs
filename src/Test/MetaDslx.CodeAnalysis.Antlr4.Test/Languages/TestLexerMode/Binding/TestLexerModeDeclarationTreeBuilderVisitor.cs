// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Symbols;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Binding
{
	public class TestLexerModeDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ITestLexerModeSyntaxVisitor
	{
        protected TestLexerModeDeclarationTreeBuilderVisitor(TestLexerModeSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            TestLexerModeSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new TestLexerModeDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }

		public virtual void VisitSkippedTokensTrivia(TestLexerModeSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		}
		
		public virtual void VisitGeneratorDeclaration(GeneratorDeclarationSyntax node)
		{
		}
		
		public virtual void VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node)
		{
		}
		
		public virtual void VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node)
		{
		}
		
		public virtual void VisitConfigDeclaration(ConfigDeclarationSyntax node)
		{
		}
		
		public virtual void VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node)
		{
		}
		
		public virtual void VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node)
		{
		}
		
		public virtual void VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
		}
		
		public virtual void VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node)
		{
		}
		
		public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		}
		
		public virtual void VisitFunctionSignature(FunctionSignatureSyntax node)
		{
		}
		
		public virtual void VisitParamList(ParamListSyntax node)
		{
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
		}
		
		public virtual void VisitBody(BodySyntax node)
		{
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		}
		
		public virtual void VisitSingleStatement(SingleStatementSyntax node)
		{
		}
		
		public virtual void VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node)
		{
		}
		
		public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		}
		
		public virtual void VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node)
		{
		}
		
		public virtual void VisitVariableDeclarationItem(VariableDeclarationItemSyntax node)
		{
		}
		
		public virtual void VisitVoidStatement(VoidStatementSyntax node)
		{
		}
		
		public virtual void VisitReturnStatement(ReturnStatementSyntax node)
		{
		}
		
		public virtual void VisitExpressionStatement(ExpressionStatementSyntax node)
		{
		}
		
		public virtual void VisitIfStatement(IfStatementSyntax node)
		{
		}
		
		public virtual void VisitElseIfStatementBody(ElseIfStatementBodySyntax node)
		{
		}
		
		public virtual void VisitIfStatementElseBody(IfStatementElseBodySyntax node)
		{
		}
		
		public virtual void VisitIfStatementBegin(IfStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitElseIfStatement(ElseIfStatementSyntax node)
		{
		}
		
		public virtual void VisitIfStatementElse(IfStatementElseSyntax node)
		{
		}
		
		public virtual void VisitIfStatementEnd(IfStatementEndSyntax node)
		{
		}
		
		public virtual void VisitForStatement(ForStatementSyntax node)
		{
		}
		
		public virtual void VisitForStatementBegin(ForStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitForStatementEnd(ForStatementEndSyntax node)
		{
		}
		
		public virtual void VisitForInitStatement(ForInitStatementSyntax node)
		{
		}
		
		public virtual void VisitWhileStatement(WhileStatementSyntax node)
		{
		}
		
		public virtual void VisitWhileStatementBegin(WhileStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitWhileStatementEnd(WhileStatementEndSyntax node)
		{
		}
		
		public virtual void VisitWhileRunExpression(WhileRunExpressionSyntax node)
		{
		}
		
		public virtual void VisitRepeatStatement(RepeatStatementSyntax node)
		{
		}
		
		public virtual void VisitRepeatStatementBegin(RepeatStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitRepeatStatementEnd(RepeatStatementEndSyntax node)
		{
		}
		
		public virtual void VisitRepeatRunExpression(RepeatRunExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopStatement(LoopStatementSyntax node)
		{
		}
		
		public virtual void VisitLoopStatementBegin(LoopStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitLoopStatementEnd(LoopStatementEndSyntax node)
		{
		}
		
		public virtual void VisitLoopChain(LoopChainSyntax node)
		{
		}
		
		public virtual void VisitLoopChainItem(LoopChainItemSyntax node)
		{
		}
		
		public virtual void VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopWhereExpression(LoopWhereExpressionSyntax node)
		{
		}
		
		public virtual void VisitLoopRunExpression(LoopRunExpressionSyntax node)
		{
		}
		
		public virtual void VisitSeparatorStatement(SeparatorStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchStatement(SwitchStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchStatementBegin(SwitchStatementBeginSyntax node)
		{
		}
		
		public virtual void VisitSwitchStatementEnd(SwitchStatementEndSyntax node)
		{
		}
		
		public virtual void VisitSwitchBranchStatement(SwitchBranchStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node)
		{
		}
		
		public virtual void VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node)
		{
		}
		
		public virtual void VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node)
		{
		}
		
		public virtual void VisitTemplateDeclaration(TemplateDeclarationSyntax node)
		{
		}
		
		public virtual void VisitTemplateSignature(TemplateSignatureSyntax node)
		{
		}
		
		public virtual void VisitTemplateBody(TemplateBodySyntax node)
		{
		}
		
		public virtual void VisitTemplateContentLine(TemplateContentLineSyntax node)
		{
		}
		
		public virtual void VisitTemplateContent(TemplateContentSyntax node)
		{
		}
		
		public virtual void VisitTemplateOutput(TemplateOutputSyntax node)
		{
		}
		
		public virtual void VisitTemplateLineEnd(TemplateLineEndSyntax node)
		{
		}
		
		public virtual void VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node)
		{
		}
		
		public virtual void VisitTemplateStatement(TemplateStatementSyntax node)
		{
		}
		
		public virtual void VisitTypeArgumentList(TypeArgumentListSyntax node)
		{
		}
		
		public virtual void VisitPredefinedType(PredefinedTypeSyntax node)
		{
		}
		
		public virtual void VisitTypeReferenceList(TypeReferenceListSyntax node)
		{
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
		}
		
		public virtual void VisitArrayItemType(ArrayItemTypeSyntax node)
		{
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		}
		
		public virtual void VisitNullableItemType(NullableItemTypeSyntax node)
		{
		}
		
		public virtual void VisitGenericType(GenericTypeSyntax node)
		{
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		}
		
		public virtual void VisitExpressionList(ExpressionListSyntax node)
		{
		}
		
		public virtual void VisitVariableReference(VariableReferenceSyntax node)
		{
		}
		
		public virtual void VisitRankSpecifiers(RankSpecifiersSyntax node)
		{
		}
		
		public virtual void VisitRankSpecifier(RankSpecifierSyntax node)
		{
		}
		
		public virtual void VisitUnboundTypeName(UnboundTypeNameSyntax node)
		{
		}
		
		public virtual void VisitGenericDimensionItem(GenericDimensionItemSyntax node)
		{
		}
		
		public virtual void VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node)
		{
		}
		
		public virtual void VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node)
		{
		}
		
		public virtual void VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node)
		{
		}
		
		public virtual void VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node)
		{
		}
		
		public virtual void VisitExplicitParameter(ExplicitParameterSyntax node)
		{
		}
		
		public virtual void VisitImplicitParameter(ImplicitParameterSyntax node)
		{
		}
		
		public virtual void VisitThisExpression(ThisExpressionSyntax node)
		{
		}
		
		public virtual void VisitLiteralExpression(LiteralExpressionSyntax node)
		{
		}
		
		public virtual void VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node)
		{
		}
		
		public virtual void VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node)
		{
		}
		
		public virtual void VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node)
		{
		}
		
		public virtual void VisitDefaultValueExpression(DefaultValueExpressionSyntax node)
		{
		}
		
		public virtual void VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node)
		{
		}
		
		public virtual void VisitIdentifierExpression(IdentifierExpressionSyntax node)
		{
		}
		
		public virtual void VisitHasLoopExpression(HasLoopExpressionSyntax node)
		{
		}
		
		public virtual void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
		{
		}
		
		public virtual void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
		{
		}
		
		public virtual void VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		}
		
		public virtual void VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node)
		{
		}
		
		public virtual void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
		{
		}
		
		public virtual void VisitTypecastExpression(TypecastExpressionSyntax node)
		{
		}
		
		public virtual void VisitUnaryExpression(UnaryExpressionSyntax node)
		{
		}
		
		public virtual void VisitPostExpression(PostExpressionSyntax node)
		{
		}
		
		public virtual void VisitMultiplicationExpression(MultiplicationExpressionSyntax node)
		{
		}
		
		public virtual void VisitAdditionExpression(AdditionExpressionSyntax node)
		{
		}
		
		public virtual void VisitRelationalExpression(RelationalExpressionSyntax node)
		{
		}
		
		public virtual void VisitTypecheckExpression(TypecheckExpressionSyntax node)
		{
		}
		
		public virtual void VisitEqualityExpression(EqualityExpressionSyntax node)
		{
		}
		
		public virtual void VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node)
		{
		}
		
		public virtual void VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node)
		{
		}
		
		public virtual void VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node)
		{
		}
		
		public virtual void VisitLogicalAndExpression(LogicalAndExpressionSyntax node)
		{
		}
		
		public virtual void VisitLogicalXorExpression(LogicalXorExpressionSyntax node)
		{
		}
		
		public virtual void VisitLogicalOrExpression(LogicalOrExpressionSyntax node)
		{
		}
		
		public virtual void VisitConditionalExpression(ConditionalExpressionSyntax node)
		{
		}
		
		public virtual void VisitAssignmentExpression(AssignmentExpressionSyntax node)
		{
		}
		
		public virtual void VisitLambdaExpression(LambdaExpressionSyntax node)
		{
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public virtual void VisitNumberLiteral(NumberLiteralSyntax node)
		{
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public virtual void VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node)
		{
		}
		
		public virtual void VisitDateTimeOffsetLiteral(DateTimeOffsetLiteralSyntax node)
		{
		}
		
		public virtual void VisitDateTimeLiteral(DateTimeLiteralSyntax node)
		{
		}
		
		public virtual void VisitDateLiteral(DateLiteralSyntax node)
		{
		}
		
		public virtual void VisitTimeLiteral(TimeLiteralSyntax node)
		{
		}
		
		public virtual void VisitCharLiteral(CharLiteralSyntax node)
		{
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
		
		public virtual void VisitGuidLiteral(GuidLiteralSyntax node)
		{
		}
	}
}

