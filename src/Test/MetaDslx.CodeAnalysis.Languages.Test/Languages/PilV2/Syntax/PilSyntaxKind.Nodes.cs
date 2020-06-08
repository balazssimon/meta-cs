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

namespace PilV2.Syntax
{
	public class PilSyntaxKind : PilTokensSyntaxKind
	{
        public static new readonly PilSyntaxKind __FirstToken;
        public static new readonly PilSyntaxKind __LastToken;
        public static new readonly PilSyntaxKind __FirstFixedToken;
        public static new readonly PilSyntaxKind __LastFixedToken;
        public static readonly PilSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly PilSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Declaration = nameof(Declaration);
		public const string TypeDefDeclaration = nameof(TypeDefDeclaration);
		public const string ExternalParameterDeclaration = nameof(ExternalParameterDeclaration);
		public const string EnumDeclaration = nameof(EnumDeclaration);
		public const string EnumLiterals = nameof(EnumLiterals);
		public const string EnumLiteral = nameof(EnumLiteral);
		public const string ObjectDeclaration = nameof(ObjectDeclaration);
		public const string ObjectHeader = nameof(ObjectHeader);
		public const string Ports = nameof(Ports);
		public const string Port = nameof(Port);
		public const string ObjectExternalParameters = nameof(ObjectExternalParameters);
		public const string ObjectFields = nameof(ObjectFields);
		public const string ObjectFunctions = nameof(ObjectFunctions);
		public const string FunctionDeclaration = nameof(FunctionDeclaration);
		public const string FunctionHeader = nameof(FunctionHeader);
		public const string FunctionParams = nameof(FunctionParams);
		public const string Param = nameof(Param);
		public const string QueryDeclaration = nameof(QueryDeclaration);
		public const string QueryHeader = nameof(QueryHeader);
		public const string QueryRequestParams = nameof(QueryRequestParams);
		public const string QueryAcceptParams = nameof(QueryAcceptParams);
		public const string QueryRefuseParams = nameof(QueryRefuseParams);
		public const string QueryCancelParams = nameof(QueryCancelParams);
		public const string QueryExternalParameters = nameof(QueryExternalParameters);
		public const string QueryField = nameof(QueryField);
		public const string QueryFunction = nameof(QueryFunction);
		public const string QueryObject = nameof(QueryObject);
		public const string QueryObjectField = nameof(QueryObjectField);
		public const string QueryObjectFunction = nameof(QueryObjectFunction);
		public const string QueryObjectEvent = nameof(QueryObjectEvent);
		public const string Input = nameof(Input);
		public const string InputPortList = nameof(InputPortList);
		public const string InputPort = nameof(InputPort);
		public const string Trigger = nameof(Trigger);
		public const string TriggerVarList = nameof(TriggerVarList);
		public const string TriggerVar = nameof(TriggerVar);
		public const string Statements = nameof(Statements);
		public const string Statement = nameof(Statement);
		public const string ForkStatement = nameof(ForkStatement);
		public const string CaseBranch = nameof(CaseBranch);
		public const string ElseBranch = nameof(ElseBranch);
		public const string IfStatement = nameof(IfStatement);
		public const string IfBranch = nameof(IfBranch);
		public const string ElseIfBranch = nameof(ElseIfBranch);
		public const string RequestStatement = nameof(RequestStatement);
		public const string CallRequest = nameof(CallRequest);
		public const string RequestArguments = nameof(RequestArguments);
		public const string ResponseStatement = nameof(ResponseStatement);
		public const string CancelStatement = nameof(CancelStatement);
		public const string Assertion = nameof(Assertion);
		public const string ResponseStatementKind = nameof(ResponseStatementKind);
		public const string CancelStatementKind = nameof(CancelStatementKind);
		public const string ForkRequestStatement = nameof(ForkRequestStatement);
		public const string ForkRequestVariable = nameof(ForkRequestVariable);
		public const string ForkRequestIdentifier = nameof(ForkRequestIdentifier);
		public const string AcceptBranch = nameof(AcceptBranch);
		public const string RefuseBranch = nameof(RefuseBranch);
		public const string CancelBranch = nameof(CancelBranch);
		public const string VariableDeclarationStatement = nameof(VariableDeclarationStatement);
		public const string VariableDeclaration = nameof(VariableDeclaration);
		public const string AssignmentStatement = nameof(AssignmentStatement);
		public const string LeftSide = nameof(LeftSide);
		public const string ExpressionList = nameof(ExpressionList);
		public const string Expression = nameof(Expression);
		public const string MulDivExpression = nameof(MulDivExpression);
		public const string PlusMinusExpression = nameof(PlusMinusExpression);
		public const string NegateExpression = nameof(NegateExpression);
		public const string SimpleArithmeticExpression = nameof(SimpleArithmeticExpression);
		public const string OpMulDiv = nameof(OpMulDiv);
		public const string OpAddSub = nameof(OpAddSub);
		public const string ParenArithmeticExpression = nameof(ParenArithmeticExpression);
		public const string TerminalArithmeticExpression = nameof(TerminalArithmeticExpression);
		public const string OpMinus = nameof(OpMinus);
		public const string AndExpression = nameof(AndExpression);
		public const string OrExpression = nameof(OrExpression);
		public const string NotExpression = nameof(NotExpression);
		public const string SimpleConditionalExpression = nameof(SimpleConditionalExpression);
		public const string AndAlsoOp = nameof(AndAlsoOp);
		public const string OrElseOp = nameof(OrElseOp);
		public const string OpExcl = nameof(OpExcl);
		public const string ParenConditionalExpression = nameof(ParenConditionalExpression);
		public const string ElementOfConditionalExpression = nameof(ElementOfConditionalExpression);
		public const string ComparisonConditionalExpression = nameof(ComparisonConditionalExpression);
		public const string TerminalComparisonExpression = nameof(TerminalComparisonExpression);
		public const string ComparisonExpression = nameof(ComparisonExpression);
		public const string ComparisonOperator = nameof(ComparisonOperator);
		public const string ElementOfExpression = nameof(ElementOfExpression);
		public const string ElementOfValueList = nameof(ElementOfValueList);
		public const string ElementOfValue = nameof(ElementOfValue);
		public const string TerminalExpression = nameof(TerminalExpression);
		public const string FunctionCallExpression = nameof(FunctionCallExpression);
		public const string VariableReference = nameof(VariableReference);
		public const string VariableReferenceIdentifier = nameof(VariableReferenceIdentifier);
		public const string Comment = nameof(Comment);
		public const string Literal = nameof(Literal);
		public const string TypeReference = nameof(TypeReference);
		public const string BuiltInType = nameof(BuiltInType);
		public const string QualifierList = nameof(QualifierList);
		public const string Qualifier = nameof(Qualifier);
		public const string Name = nameof(Name);
		public const string IdentifierList = nameof(IdentifierList);
		public const string Identifier = nameof(Identifier);
		public const string ResultIdentifier = nameof(ResultIdentifier);

		protected PilSyntaxKind(string name)
            : base(name)
        {
        }

        protected PilSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static PilSyntaxKind()
        {
            EnumObject.AutoInit<PilSyntaxKind>();
            __FirstToken = KTypeDef;
            __LastToken = LMultiLineComment;
            __FirstFixedToken = KTypeDef;
            __LastFixedToken = TBarAssign;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = ResultIdentifier;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator PilSyntaxKind(string name)
        {
            return FromString<PilSyntaxKind>(name);
        }

        public static explicit operator PilSyntaxKind(int value)
        {
            return FromIntUnsafe<PilSyntaxKind>(value);
        }

	}
}

