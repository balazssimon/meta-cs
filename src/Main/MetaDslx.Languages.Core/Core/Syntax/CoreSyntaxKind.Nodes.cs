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

namespace MetaDslx.Languages.Core.Syntax
{
	public class CoreSyntaxKind : CoreTokensSyntaxKind
	{
        public static new readonly CoreSyntaxKind __FirstToken;
        public static new readonly CoreSyntaxKind __LastToken;
        public static new readonly CoreSyntaxKind __FirstFixedToken;
        public static new readonly CoreSyntaxKind __LastFixedToken;
        public static readonly CoreSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly CoreSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string MainBlock = nameof(MainBlock);
		public const string UsingNamespace = nameof(UsingNamespace);
		public const string EmptyStmt = nameof(EmptyStmt);
		public const string BlockStmt = nameof(BlockStmt);
		public const string ExprStmt = nameof(ExprStmt);
		public const string ForeachStmt = nameof(ForeachStmt);
		public const string ForStmt = nameof(ForStmt);
		public const string IfStmt = nameof(IfStmt);
		public const string BreakStmt = nameof(BreakStmt);
		public const string ContinueStmt = nameof(ContinueStmt);
		public const string GotoStmt = nameof(GotoStmt);
		public const string LabeledStmt = nameof(LabeledStmt);
		public const string LockStmt = nameof(LockStmt);
		public const string ReturnStmt = nameof(ReturnStmt);
		public const string SwitchStmt = nameof(SwitchStmt);
		public const string TryStmt = nameof(TryStmt);
		public const string UsingStmt = nameof(UsingStmt);
		public const string WhileStmt = nameof(WhileStmt);
		public const string DoWhileStmt = nameof(DoWhileStmt);
		public const string BlockStatement = nameof(BlockStatement);
		public const string BareBlockStatement = nameof(BareBlockStatement);
		public const string SwitchCase = nameof(SwitchCase);
		public const string CaseClause = nameof(CaseClause);
		public const string SingleValueCaseClause = nameof(SingleValueCaseClause);
		public const string DefaultCaseClause = nameof(DefaultCaseClause);
		public const string CatchClause = nameof(CatchClause);
		public const string CatchFilter = nameof(CatchFilter);
		public const string FinallyClause = nameof(FinallyClause);
		public const string UsingHeader = nameof(UsingHeader);
		public const string ExpressionList = nameof(ExpressionList);
		public const string ParenthesizedExpr = nameof(ParenthesizedExpr);
		public const string TupleExpr = nameof(TupleExpr);
		public const string DiscardExpr = nameof(DiscardExpr);
		public const string DefaultExpr = nameof(DefaultExpr);
		public const string ThisExpr = nameof(ThisExpr);
		public const string BaseExpr = nameof(BaseExpr);
		public const string LiteralExpr = nameof(LiteralExpr);
		public const string IdentifierExpr = nameof(IdentifierExpr);
		public const string QualifierExpr = nameof(QualifierExpr);
		public const string IndexerExpr = nameof(IndexerExpr);
		public const string InvocationExpr = nameof(InvocationExpr);
		public const string TypeofExpr = nameof(TypeofExpr);
		public const string NameofExpr = nameof(NameofExpr);
		public const string SizeofExpr = nameof(SizeofExpr);
		public const string CheckedExpr = nameof(CheckedExpr);
		public const string UncheckedExpr = nameof(UncheckedExpr);
		public const string NewExpr = nameof(NewExpr);
		public const string PostfixUnaryExpr = nameof(PostfixUnaryExpr);
		public const string NullForgivingExpr = nameof(NullForgivingExpr);
		public const string UnaryExpr = nameof(UnaryExpr);
		public const string TypeCastExpr = nameof(TypeCastExpr);
		public const string AwaitExpr = nameof(AwaitExpr);
		public const string RangeExpr = nameof(RangeExpr);
		public const string MultExpr = nameof(MultExpr);
		public const string AddExpr = nameof(AddExpr);
		public const string ShiftExpr = nameof(ShiftExpr);
		public const string RelExpr = nameof(RelExpr);
		public const string TypeIsExpr = nameof(TypeIsExpr);
		public const string TypeAsExpr = nameof(TypeAsExpr);
		public const string EqExpr = nameof(EqExpr);
		public const string AndExpr = nameof(AndExpr);
		public const string XorExpr = nameof(XorExpr);
		public const string OrExpr = nameof(OrExpr);
		public const string AndAlsoExpr = nameof(AndAlsoExpr);
		public const string OrElseExpr = nameof(OrElseExpr);
		public const string ThrowExpr = nameof(ThrowExpr);
		public const string CoalExpr = nameof(CoalExpr);
		public const string CondExpr = nameof(CondExpr);
		public const string AssignExpr = nameof(AssignExpr);
		public const string CompAssignExpr = nameof(CompAssignExpr);
		public const string LambdaExpr = nameof(LambdaExpr);
		public const string VarDefExpr = nameof(VarDefExpr);
		public const string TupleArguments = nameof(TupleArguments);
		public const string ArgumentList = nameof(ArgumentList);
		public const string ArgumentExpression = nameof(ArgumentExpression);
		public const string InitializerExpression = nameof(InitializerExpression);
		public const string FieldInitializerExpressions = nameof(FieldInitializerExpressions);
		public const string FieldInitializerExpression = nameof(FieldInitializerExpression);
		public const string CollectionInitializerExpressions = nameof(CollectionInitializerExpressions);
		public const string DictionaryInitializerExpressions = nameof(DictionaryInitializerExpressions);
		public const string DictionaryInitializerExpression = nameof(DictionaryInitializerExpression);
		public const string LambdaSignature = nameof(LambdaSignature);
		public const string ImplicitLambdaSignature = nameof(ImplicitLambdaSignature);
		public const string ImplicitParameterList = nameof(ImplicitParameterList);
		public const string ImplicitParameter = nameof(ImplicitParameter);
		public const string ExplicitLambdaSignature = nameof(ExplicitLambdaSignature);
		public const string ExplicitParameterList = nameof(ExplicitParameterList);
		public const string ExplicitParameter = nameof(ExplicitParameter);
		public const string LambdaBody = nameof(LambdaBody);
		public const string VariableDefList = nameof(VariableDefList);
		public const string VariableDef = nameof(VariableDef);
		public const string DotOperator = nameof(DotOperator);
		public const string IndexerOperator = nameof(IndexerOperator);
		public const string PostfixOperator = nameof(PostfixOperator);
		public const string UnaryOperator = nameof(UnaryOperator);
		public const string MultiplicativeOperator = nameof(MultiplicativeOperator);
		public const string AdditiveOperator = nameof(AdditiveOperator);
		public const string ShiftOperator = nameof(ShiftOperator);
		public const string LeftShiftOperator = nameof(LeftShiftOperator);
		public const string RightShiftOperator = nameof(RightShiftOperator);
		public const string RelationalOperator = nameof(RelationalOperator);
		public const string EqualityOperator = nameof(EqualityOperator);
		public const string CompoundAssignmentOperator = nameof(CompoundAssignmentOperator);
		public const string ReturnType = nameof(ReturnType);
		public const string VariableType = nameof(VariableType);
		public const string PrimitiveTypeRef = nameof(PrimitiveTypeRef);
		public const string GenericTypeRef = nameof(GenericTypeRef);
		public const string NamedTypeRef = nameof(NamedTypeRef);
		public const string ArrayTypeRef = nameof(ArrayTypeRef);
		public const string NullableTypeRef = nameof(NullableTypeRef);
		public const string NamedType = nameof(NamedType);
		public const string GenericTypeArguments = nameof(GenericTypeArguments);
		public const string GenericTypeArgument = nameof(GenericTypeArgument);
		public const string PrimitiveType = nameof(PrimitiveType);
		public const string VoidType = nameof(VoidType);
		public const string VarType = nameof(VarType);
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

		protected CoreSyntaxKind(string name)
            : base(name)
        {
        }

        protected CoreSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static CoreSyntaxKind()
        {
            EnumObject.AutoInit<CoreSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LCommentStart;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = LCommentStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = StringLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator CoreSyntaxKind(string name)
        {
            return FromString<CoreSyntaxKind>(name);
        }

        public static explicit operator CoreSyntaxKind(int value)
        {
            return FromIntUnsafe<CoreSyntaxKind>(value);
        }

	}
}

