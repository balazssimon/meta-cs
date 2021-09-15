// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;

namespace MetaDslx.Languages.Core.Binding
{
    public class CoreCompletionBinderFactoryVisitor : CompletionBinderFactoryVisitor, ICoreSyntaxVisitor
    {
		public static object UnassignedUse = new object();
		public static object FinishedUse = new object();
		public static object Use_Main_UsingNamespace = new object();
		public static object Use_Main_Statement = new object();
		public static object Use_UsingNamespace_Name = new object();
		public static object Use_UsingNamespace_Qualifier = new object();
		public static object Use_Statement_Expression = new object();
		public static object Use_BlockStatement_Statement = new object();
		public static object Use_ParenthesizedExpr_Expression = new object();
		public static object Use_TupleExpr_TupleArguments = new object();
		public static object Use_LiteralExpr_Literal = new object();
		public static object Use_IdentifierExpr_Identifier = new object();
		public static object Use_IdentifierExpr_GenericTypeArguments = new object();
		public static object Use_QualifierExpr_Expression = new object();
		public static object Use_QualifierExpr_DotOperator = new object();
		public static object Use_QualifierExpr_Identifier = new object();
		public static object Use_QualifierExpr_GenericTypeArguments = new object();
		public static object Use_IndexerExpr_Expression = new object();
		public static object Use_IndexerExpr_IndexerOperator = new object();
		public static object Use_IndexerExpr_ArgumentList = new object();
		public static object Use_InvocationExpr_Expression = new object();
		public static object Use_InvocationExpr_ArgumentList = new object();
		public static object Use_TypeofExpr_TypeReference = new object();
		public static object Use_NameofExpr_Expression = new object();
		public static object Use_SizeofExpr_TypeReference = new object();
		public static object Use_CheckedExpr_Expression = new object();
		public static object Use_UncheckedExpr_Expression = new object();
		public static object Use_NewExpr_TypeReference = new object();
		public static object Use_NewExpr_ArgumentList = new object();
		public static object Use_NewExpr_InitializerExpression = new object();
		public static object Use_PostfixUnaryExpr_Expression = new object();
		public static object Use_PostfixUnaryExpr_PostfixOperator = new object();
		public static object Use_NullForgivingExpr_Expression = new object();
		public static object Use_UnaryExpr_UnaryOperator = new object();
		public static object Use_UnaryExpr_Expression = new object();
		public static object Use_TypeCastExpr_TypeReference = new object();
		public static object Use_TypeCastExpr_Expression = new object();
		public static object Use_AwaitExpr_Expression = new object();
		public static object Use_RangeExpr_Left = new object();
		public static object Use_RangeExpr_TDotDot = new object();
		public static object Use_RangeExpr_Right = new object();
		public static object Use_MultExpr_Left = new object();
		public static object Use_MultExpr_MultiplicativeOperator = new object();
		public static object Use_MultExpr_Right = new object();
		public static object Use_AddExpr_Left = new object();
		public static object Use_AddExpr_AdditiveOperator = new object();
		public static object Use_AddExpr_Right = new object();
		public static object Use_ShiftExpr_Left = new object();
		public static object Use_ShiftExpr_ShiftOperator = new object();
		public static object Use_ShiftExpr_Right = new object();
		public static object Use_RelExpr_Left = new object();
		public static object Use_RelExpr_RelationalOperator = new object();
		public static object Use_RelExpr_Right = new object();
		public static object Use_TypeIsExpr_Expression = new object();
		public static object Use_TypeIsExpr_KNot = new object();
		public static object Use_TypeIsExpr_TypeReference = new object();
		public static object Use_TypeAsExpr_Expression = new object();
		public static object Use_TypeAsExpr_TypeReference = new object();
		public static object Use_EqExpr_Left = new object();
		public static object Use_EqExpr_EqualityOperator = new object();
		public static object Use_EqExpr_Right = new object();
		public static object Use_AndExpr_Left = new object();
		public static object Use_AndExpr_TAmpersand = new object();
		public static object Use_AndExpr_Right = new object();
		public static object Use_XorExpr_Left = new object();
		public static object Use_XorExpr_THat = new object();
		public static object Use_XorExpr_Right = new object();
		public static object Use_OrExpr_Left = new object();
		public static object Use_OrExpr_TBar = new object();
		public static object Use_OrExpr_Right = new object();
		public static object Use_AndAlsoExpr_Left = new object();
		public static object Use_AndAlsoExpr_TAndAlso = new object();
		public static object Use_AndAlsoExpr_Right = new object();
		public static object Use_OrElseExpr_Left = new object();
		public static object Use_OrElseExpr_TOrElse = new object();
		public static object Use_OrElseExpr_Right = new object();
		public static object Use_ThrowExpr_Expression = new object();
		public static object Use_CoalExpr_Value = new object();
		public static object Use_CoalExpr_WhenNull = new object();
		public static object Use_CondExpr_Condition = new object();
		public static object Use_CondExpr_WhenTrue = new object();
		public static object Use_CondExpr_WhenFalse = new object();
		public static object Use_AssignExpr_Target = new object();
		public static object Use_AssignExpr_Value = new object();
		public static object Use_CompAssignExpr_Target = new object();
		public static object Use_CompAssignExpr_CompoundAssignmentOperator = new object();
		public static object Use_CompAssignExpr_Value = new object();
		public static object Use_LambdaExpr_LambdaSignature = new object();
		public static object Use_LambdaExpr_LambdaBody = new object();
		public static object Use_TupleArguments_ArgumentExpression = new object();
		public static object Use_TupleArguments_ArgumentList = new object();
		public static object Use_ArgumentList_ArgumentExpression = new object();
		public static object Use_ArgumentExpression_Name = new object();
		public static object Use_ArgumentExpression_Expression = new object();
		public static object Use_InitializerExpression_FieldInitializerExpressions = new object();
		public static object Use_InitializerExpression_CollectionInitializerExpressions = new object();
		public static object Use_InitializerExpression_DictionaryInitializerExpressions = new object();
		public static object Use_FieldInitializerExpressions_FieldInitializerExpression = new object();
		public static object Use_FieldInitializerExpression_Identifier = new object();
		public static object Use_FieldInitializerExpression_Expression = new object();
		public static object Use_CollectionInitializerExpressions_Expression = new object();
		public static object Use_DictionaryInitializerExpressions_DictionaryInitializerExpression = new object();
		public static object Use_DictionaryInitializerExpression_Identifier = new object();
		public static object Use_DictionaryInitializerExpression_Expression = new object();
		public static object Use_LambdaSignature_ImplicitLambdaSignature = new object();
		public static object Use_LambdaSignature_ExplicitLambdaSignature = new object();
		public static object Use_ImplicitLambdaSignature_ImplicitParameter = new object();
		public static object Use_ImplicitLambdaSignature_ImplicitParameterList = new object();
		public static object Use_ImplicitParameterList_ImplicitParameter = new object();
		public static object Use_ImplicitParameter_Name = new object();
		public static object Use_ExplicitLambdaSignature_ExplicitParameterList = new object();
		public static object Use_ExplicitParameterList_ExplicitParameter = new object();
		public static object Use_ExplicitParameter_TypeReference = new object();
		public static object Use_ExplicitParameter_Name = new object();
		public static object Use_LambdaBody_Expression = new object();
		public static object Use_LambdaBody_BlockStatement = new object();
		public static object Use_DotOperator_DotOperator = new object();
		public static object Use_IndexerOperator_IndexerOperator = new object();
		public static object Use_PostfixOperator_PostfixOperator = new object();
		public static object Use_UnaryOperator_UnaryOperator = new object();
		public static object Use_MultiplicativeOperator_MultiplicativeOperator = new object();
		public static object Use_AdditiveOperator_AdditiveOperator = new object();
		public static object Use_ShiftOperator_LeftShiftOperator = new object();
		public static object Use_ShiftOperator_RightShiftOperator = new object();
		public static object Use_RelationalOperator_RelationalOperator = new object();
		public static object Use_EqualityOperator_EqualityOperator = new object();
		public static object Use_CompoundAssignmentOperator_CompoundAssignmentOperator = new object();
		public static object Use_ReturnType_TypeReference = new object();
		public static object Use_ReturnType_VoidType = new object();
		public static object Use_PrimitiveTypeRef_PrimitiveType = new object();
		public static object Use_GenericTypeRef_NamedType = new object();
		public static object Use_GenericTypeRef_GenericTypeArguments = new object();
		public static object Use_NamedTypeRef_Qualifier = new object();
		public static object Use_ArrayTypeRef_TypeReference = new object();
		public static object Use_NullableTypeRef_TypeReference = new object();
		public static object Use_NamedType_Qualifier = new object();
		public static object Use_GenericTypeArguments_GenericTypeArgument = new object();
		public static object Use_GenericTypeArgument_TypeReference = new object();
		public static object Use_PrimitiveType_PrimitiveType = new object();
		public static object Use_Name_Identifier = new object();
		public static object Use_QualifiedName_Qualifier = new object();
		public static object Use_Qualifier_Identifier = new object();
		public static object Use_Literal_NullLiteral = new object();
		public static object Use_Literal_BooleanLiteral = new object();
		public static object Use_Literal_IntegerLiteral = new object();
		public static object Use_Literal_DecimalLiteral = new object();
		public static object Use_Literal_ScientificLiteral = new object();
		public static object Use_Literal_StringLiteral = new object();

        private bool[] _visited = new bool[52];

        public CoreCompletionBinderFactoryVisitor(BinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new CoreBinderFactory BinderFactory => (CoreBinderFactory)base.BinderFactory;

		
		public void VisitMain(MainSyntax parent) // 0
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UsingNamespace.Node == null || parent.UsingNamespace.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.UsingNamespace.Node == null || !parent.UsingNamespace.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UsingNamespace.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMain(Use_Main_UsingNamespace, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.UsingNamespace)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.UsingNamespace.FullSpan.Length;
		    if (parent.Statement.Node == null || parent.Statement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Statement.Node == null || !parent.Statement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Statement.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMain(Use_Main_Statement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Statement)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Statement.FullSpan.Length;
		    position += parent.EndOfFileToken.FullSpan.Length;
		}
		
		public void VisitUsingNamespace(UsingNamespaceSyntax parent) // 1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KUsing.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KUsing);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KUsing, operation);
		        }
		    }
		    position += parent.KUsing.FullSpan.Length;
		    if (parent.Name == null || parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Name == null || !parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespace(Use_UsingNamespace_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForUsingNamespace(Use_UsingNamespace_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    if (parent.Name != null) position += parent.Name.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUsingNamespace(Use_UsingNamespace_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForUsingNamespace(Use_UsingNamespace_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitStatement(StatementSyntax parent) // 2
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForStatement(Use_Statement_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForStatement(Use_Statement_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TSemicolon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TSemicolon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TSemicolon, operation);
		        }
		    }
		    position += parent.TSemicolon.FullSpan.Length;
		}
		
		public void VisitBlockStatement(BlockStatementSyntax parent) // 3
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBrace, operation);
		        }
		    }
		    position += parent.TOpenBrace.FullSpan.Length;
		    if (parent.Statement.Node == null || parent.Statement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Statement.Node == null || !parent.Statement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Statement.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForBlockStatement(Use_BlockStatement_Statement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Statement)
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                VisitCore(item);
		            }
		        }
		    }
		    position += parent.Statement.FullSpan.Length;
		    if (parent.TCloseBrace.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBrace);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBrace, operation);
		        }
		    }
		    position += parent.TCloseBrace.FullSpan.Length;
		}
		
		public void VisitParenthesizedExpr(ParenthesizedExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForParenthesizedExpr(Use_ParenthesizedExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForParenthesizedExpr(Use_ParenthesizedExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitTupleExpr(TupleExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.TupleArguments.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TupleArguments.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TupleArguments);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTupleExpr(Use_TupleExpr_TupleArguments, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TupleArguments);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TupleArguments == null || parent.TupleArguments.IsMissing) AddResultsForTupleExpr(Use_TupleExpr_TupleArguments, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TupleArguments);
		        }
		    }
		    position += parent.TupleArguments.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitDiscardExpr(DiscardExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KDiscard.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KDiscard);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KDiscard, operation);
		        }
		    }
		    position += parent.KDiscard.FullSpan.Length;
		}
		
		public void VisitDefaultExpr(DefaultExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KDefault.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KDefault);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KDefault, operation);
		        }
		    }
		    position += parent.KDefault.FullSpan.Length;
		}
		
		public void VisitThisExpr(ThisExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KThis.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KThis);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KThis, operation);
		        }
		    }
		    position += parent.KThis.FullSpan.Length;
		}
		
		public void VisitBaseExpr(BaseExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KBase.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KBase);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KBase, operation);
		        }
		    }
		    position += parent.KBase.FullSpan.Length;
		}
		
		public void VisitLiteralExpr(LiteralExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Literal.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Literal.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Literal);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteralExpr(Use_LiteralExpr_Literal, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Literal);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Literal == null || parent.Literal.IsMissing) AddResultsForLiteralExpr(Use_LiteralExpr_Literal, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Literal);
		        }
		    }
		    position += parent.Literal.FullSpan.Length;
		}
		
		public void VisitIdentifierExpr(IdentifierExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIdentifierExpr(Use_IdentifierExpr_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForIdentifierExpr(Use_IdentifierExpr_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		    if (parent.GenericTypeArguments == null || parent.GenericTypeArguments.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.GenericTypeArguments == null || !parent.GenericTypeArguments.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.GenericTypeArguments);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIdentifierExpr(Use_IdentifierExpr_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.GenericTypeArguments);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.GenericTypeArguments == null || parent.GenericTypeArguments.IsMissing) AddResultsForIdentifierExpr(Use_IdentifierExpr_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.GenericTypeArguments);
		        }
		    }
		    if (parent.GenericTypeArguments != null) position += parent.GenericTypeArguments.FullSpan.Length;
		}
		
		public void VisitQualifierExpr(QualifierExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifierExpr(Use_QualifierExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForQualifierExpr(Use_QualifierExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.DotOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.DotOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DotOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifierExpr(Use_QualifierExpr_DotOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DotOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DotOperator == null || parent.DotOperator.IsMissing) AddResultsForQualifierExpr(Use_QualifierExpr_DotOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DotOperator);
		        }
		    }
		    position += parent.DotOperator.FullSpan.Length;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifierExpr(Use_QualifierExpr_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForQualifierExpr(Use_QualifierExpr_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		    if (parent.GenericTypeArguments == null || parent.GenericTypeArguments.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.GenericTypeArguments == null || !parent.GenericTypeArguments.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.GenericTypeArguments);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifierExpr(Use_QualifierExpr_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.GenericTypeArguments);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.GenericTypeArguments == null || parent.GenericTypeArguments.IsMissing) AddResultsForQualifierExpr(Use_QualifierExpr_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.GenericTypeArguments);
		        }
		    }
		    if (parent.GenericTypeArguments != null) position += parent.GenericTypeArguments.FullSpan.Length;
		}
		
		public void VisitIndexerExpr(IndexerExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIndexerExpr(Use_IndexerExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForIndexerExpr(Use_IndexerExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.IndexerOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.IndexerOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.IndexerOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIndexerExpr(Use_IndexerExpr_IndexerOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.IndexerOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.IndexerOperator == null || parent.IndexerOperator.IsMissing) AddResultsForIndexerExpr(Use_IndexerExpr_IndexerOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.IndexerOperator);
		        }
		    }
		    position += parent.IndexerOperator.FullSpan.Length;
		    if (parent.ArgumentList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ArgumentList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIndexerExpr(Use_IndexerExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ArgumentList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ArgumentList == null || parent.ArgumentList.IsMissing) AddResultsForIndexerExpr(Use_IndexerExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ArgumentList);
		        }
		    }
		    position += parent.ArgumentList.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitInvocationExpr(InvocationExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForInvocationExpr(Use_InvocationExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForInvocationExpr(Use_InvocationExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ArgumentList == null || parent.ArgumentList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ArgumentList == null || !parent.ArgumentList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForInvocationExpr(Use_InvocationExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ArgumentList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ArgumentList == null || parent.ArgumentList.IsMissing) AddResultsForInvocationExpr(Use_InvocationExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ArgumentList);
		        }
		    }
		    if (parent.ArgumentList != null) position += parent.ArgumentList.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitTypeofExpr(TypeofExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KTypeof.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KTypeof);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KTypeof, operation);
		        }
		    }
		    position += parent.KTypeof.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeofExpr(Use_TypeofExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForTypeofExpr(Use_TypeofExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitNameofExpr(NameofExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNameof.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNameof);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNameof, operation);
		        }
		    }
		    position += parent.KNameof.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNameofExpr(Use_NameofExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForNameofExpr(Use_NameofExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitSizeofExpr(SizeofExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KSizeof.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KSizeof);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KSizeof, operation);
		        }
		    }
		    position += parent.KSizeof.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForSizeofExpr(Use_SizeofExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForSizeofExpr(Use_SizeofExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitCheckedExpr(CheckedExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KChecked.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KChecked);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KChecked, operation);
		        }
		    }
		    position += parent.KChecked.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCheckedExpr(Use_CheckedExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForCheckedExpr(Use_CheckedExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitUncheckedExpr(UncheckedExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KUnchecked.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KUnchecked);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KUnchecked, operation);
		        }
		    }
		    position += parent.KUnchecked.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUncheckedExpr(Use_UncheckedExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForUncheckedExpr(Use_UncheckedExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitNewExpr(NewExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNew.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNew);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNew, operation);
		        }
		    }
		    position += parent.KNew.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNewExpr(Use_NewExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForNewExpr(Use_NewExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ArgumentList == null || parent.ArgumentList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ArgumentList == null || !parent.ArgumentList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNewExpr(Use_NewExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ArgumentList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ArgumentList == null || parent.ArgumentList.IsMissing) AddResultsForNewExpr(Use_NewExpr_ArgumentList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ArgumentList);
		        }
		    }
		    if (parent.ArgumentList != null) position += parent.ArgumentList.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		    if (parent.InitializerExpression == null || parent.InitializerExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.InitializerExpression == null || !parent.InitializerExpression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.InitializerExpression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNewExpr(Use_NewExpr_InitializerExpression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.InitializerExpression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.InitializerExpression == null || parent.InitializerExpression.IsMissing) AddResultsForNewExpr(Use_NewExpr_InitializerExpression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.InitializerExpression);
		        }
		    }
		    if (parent.InitializerExpression != null) position += parent.InitializerExpression.FullSpan.Length;
		}
		
		public void VisitPostfixUnaryExpr(PostfixUnaryExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPostfixUnaryExpr(Use_PostfixUnaryExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForPostfixUnaryExpr(Use_PostfixUnaryExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.PostfixOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PostfixOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PostfixOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPostfixUnaryExpr(Use_PostfixUnaryExpr_PostfixOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PostfixOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.PostfixOperator == null || parent.PostfixOperator.IsMissing) AddResultsForPostfixUnaryExpr(Use_PostfixUnaryExpr_PostfixOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.PostfixOperator);
		        }
		    }
		    position += parent.PostfixOperator.FullSpan.Length;
		}
		
		public void VisitNullForgivingExpr(NullForgivingExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNullForgivingExpr(Use_NullForgivingExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForNullForgivingExpr(Use_NullForgivingExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.TExclamation.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TExclamation);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TExclamation, operation);
		        }
		    }
		    position += parent.TExclamation.FullSpan.Length;
		}
		
		public void VisitUnaryExpr(UnaryExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UnaryOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.UnaryOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UnaryOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUnaryExpr(Use_UnaryExpr_UnaryOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.UnaryOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.UnaryOperator == null || parent.UnaryOperator.IsMissing) AddResultsForUnaryExpr(Use_UnaryExpr_UnaryOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.UnaryOperator);
		        }
		    }
		    position += parent.UnaryOperator.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUnaryExpr(Use_UnaryExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForUnaryExpr(Use_UnaryExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitTypeCastExpr(TypeCastExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeCastExpr(Use_TypeCastExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForTypeCastExpr(Use_TypeCastExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeCastExpr(Use_TypeCastExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForTypeCastExpr(Use_TypeCastExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitAwaitExpr(AwaitExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KAwait.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KAwait);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KAwait, operation);
		        }
		    }
		    position += parent.KAwait.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAwaitExpr(Use_AwaitExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForAwaitExpr(Use_AwaitExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitRangeExpr(RangeExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRangeExpr(Use_RangeExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForRangeExpr(Use_RangeExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.TDotDot.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TDotDot.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TDotDot);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRangeExpr(Use_RangeExpr_TDotDot, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TDotDot);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TDotDot.GetKind() == SyntaxKind.None || parent.TDotDot.IsMissing) AddResultsForRangeExpr(Use_RangeExpr_TDotDot, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.TDotDot, operation);
		        }
		    }
		    position += parent.TDotDot.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRangeExpr(Use_RangeExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForRangeExpr(Use_RangeExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitMultExpr(MultExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMultExpr(Use_MultExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForMultExpr(Use_MultExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.MultiplicativeOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.MultiplicativeOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MultiplicativeOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMultExpr(Use_MultExpr_MultiplicativeOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MultiplicativeOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.MultiplicativeOperator == null || parent.MultiplicativeOperator.IsMissing) AddResultsForMultExpr(Use_MultExpr_MultiplicativeOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.MultiplicativeOperator);
		        }
		    }
		    position += parent.MultiplicativeOperator.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMultExpr(Use_MultExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForMultExpr(Use_MultExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitAddExpr(AddExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAddExpr(Use_AddExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForAddExpr(Use_AddExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.AdditiveOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.AdditiveOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.AdditiveOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAddExpr(Use_AddExpr_AdditiveOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.AdditiveOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.AdditiveOperator == null || parent.AdditiveOperator.IsMissing) AddResultsForAddExpr(Use_AddExpr_AdditiveOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.AdditiveOperator);
		        }
		    }
		    position += parent.AdditiveOperator.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAddExpr(Use_AddExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForAddExpr(Use_AddExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitShiftExpr(ShiftExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForShiftExpr(Use_ShiftExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForShiftExpr(Use_ShiftExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.ShiftOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ShiftOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ShiftOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForShiftExpr(Use_ShiftExpr_ShiftOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ShiftOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ShiftOperator == null || parent.ShiftOperator.IsMissing) AddResultsForShiftExpr(Use_ShiftExpr_ShiftOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ShiftOperator);
		        }
		    }
		    position += parent.ShiftOperator.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForShiftExpr(Use_ShiftExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForShiftExpr(Use_ShiftExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitRelExpr(RelExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRelExpr(Use_RelExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForRelExpr(Use_RelExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.RelationalOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.RelationalOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RelationalOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRelExpr(Use_RelExpr_RelationalOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.RelationalOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.RelationalOperator == null || parent.RelationalOperator.IsMissing) AddResultsForRelExpr(Use_RelExpr_RelationalOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.RelationalOperator);
		        }
		    }
		    position += parent.RelationalOperator.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRelExpr(Use_RelExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForRelExpr(Use_RelExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitTypeIsExpr(TypeIsExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeIsExpr(Use_TypeIsExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForTypeIsExpr(Use_TypeIsExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.KIs.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KIs);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KIs, operation);
		        }
		    }
		    position += parent.KIs.FullSpan.Length;
		    if (parent.KNot.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.KNot.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.KNot);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeIsExpr(Use_TypeIsExpr_KNot, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.KNot);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.KNot.GetKind() == SyntaxKind.None || parent.KNot.IsMissing) AddResultsForTypeIsExpr(Use_TypeIsExpr_KNot, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.KNot, operation);
		        }
		    }
		    position += parent.KNot.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeIsExpr(Use_TypeIsExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForTypeIsExpr(Use_TypeIsExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		}
		
		public void VisitTypeAsExpr(TypeAsExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeAsExpr(Use_TypeAsExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForTypeAsExpr(Use_TypeAsExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		    if (parent.KAs.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KAs);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KAs, operation);
		        }
		    }
		    position += parent.KAs.FullSpan.Length;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTypeAsExpr(Use_TypeAsExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForTypeAsExpr(Use_TypeAsExpr_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		}
		
		public void VisitEqExpr(EqExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEqExpr(Use_EqExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForEqExpr(Use_EqExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.EqualityOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.EqualityOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EqualityOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEqExpr(Use_EqExpr_EqualityOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EqualityOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.EqualityOperator == null || parent.EqualityOperator.IsMissing) AddResultsForEqExpr(Use_EqExpr_EqualityOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.EqualityOperator);
		        }
		    }
		    position += parent.EqualityOperator.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEqExpr(Use_EqExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForEqExpr(Use_EqExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitAndExpr(AndExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndExpr(Use_AndExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForAndExpr(Use_AndExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.TAmpersand.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TAmpersand.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TAmpersand);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndExpr(Use_AndExpr_TAmpersand, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TAmpersand);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TAmpersand.GetKind() == SyntaxKind.None || parent.TAmpersand.IsMissing) AddResultsForAndExpr(Use_AndExpr_TAmpersand, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.TAmpersand, operation);
		        }
		    }
		    position += parent.TAmpersand.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndExpr(Use_AndExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForAndExpr(Use_AndExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitXorExpr(XorExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForXorExpr(Use_XorExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForXorExpr(Use_XorExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.THat.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.THat.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.THat);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForXorExpr(Use_XorExpr_THat, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.THat);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.THat.GetKind() == SyntaxKind.None || parent.THat.IsMissing) AddResultsForXorExpr(Use_XorExpr_THat, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.THat, operation);
		        }
		    }
		    position += parent.THat.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForXorExpr(Use_XorExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForXorExpr(Use_XorExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitOrExpr(OrExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrExpr(Use_OrExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForOrExpr(Use_OrExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.TBar.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TBar.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TBar);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrExpr(Use_OrExpr_TBar, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TBar);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TBar.GetKind() == SyntaxKind.None || parent.TBar.IsMissing) AddResultsForOrExpr(Use_OrExpr_TBar, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.TBar, operation);
		        }
		    }
		    position += parent.TBar.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrExpr(Use_OrExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForOrExpr(Use_OrExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitAndAlsoExpr(AndAlsoExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndAlsoExpr(Use_AndAlsoExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForAndAlsoExpr(Use_AndAlsoExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.TAndAlso.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TAndAlso.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TAndAlso);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndAlsoExpr(Use_AndAlsoExpr_TAndAlso, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TAndAlso);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TAndAlso.GetKind() == SyntaxKind.None || parent.TAndAlso.IsMissing) AddResultsForAndAlsoExpr(Use_AndAlsoExpr_TAndAlso, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.TAndAlso, operation);
		        }
		    }
		    position += parent.TAndAlso.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAndAlsoExpr(Use_AndAlsoExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForAndAlsoExpr(Use_AndAlsoExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitOrElseExpr(OrElseExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Left.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Left.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Left);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrElseExpr(Use_OrElseExpr_Left, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Left);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Left == null || parent.Left.IsMissing) AddResultsForOrElseExpr(Use_OrElseExpr_Left, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Left);
		        }
		    }
		    position += parent.Left.FullSpan.Length;
		    if (parent.TOrElse.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TOrElse.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TOrElse);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrElseExpr(Use_OrElseExpr_TOrElse, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TOrElse);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TOrElse.GetKind() == SyntaxKind.None || parent.TOrElse.IsMissing) AddResultsForOrElseExpr(Use_OrElseExpr_TOrElse, operation, Compilation.GetBinder(parent));
		            else AddBinder(parent.TOrElse, operation);
		        }
		    }
		    position += parent.TOrElse.FullSpan.Length;
		    if (parent.Right.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Right.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Right);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForOrElseExpr(Use_OrElseExpr_Right, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Right);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Right == null || parent.Right.IsMissing) AddResultsForOrElseExpr(Use_OrElseExpr_Right, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Right);
		        }
		    }
		    position += parent.Right.FullSpan.Length;
		}
		
		public void VisitThrowExpr(ThrowExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KThrow.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KThrow);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KThrow, operation);
		        }
		    }
		    position += parent.KThrow.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForThrowExpr(Use_ThrowExpr_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForThrowExpr(Use_ThrowExpr_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitCoalExpr(CoalExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Value.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Value.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Value);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCoalExpr(Use_CoalExpr_Value, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Value);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Value == null || parent.Value.IsMissing) AddResultsForCoalExpr(Use_CoalExpr_Value, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Value);
		        }
		    }
		    position += parent.Value.FullSpan.Length;
		    if (parent.TQuestionQuestion.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TQuestionQuestion);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TQuestionQuestion, operation);
		        }
		    }
		    position += parent.TQuestionQuestion.FullSpan.Length;
		    if (parent.WhenNull.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.WhenNull.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.WhenNull);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCoalExpr(Use_CoalExpr_WhenNull, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.WhenNull);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.WhenNull == null || parent.WhenNull.IsMissing) AddResultsForCoalExpr(Use_CoalExpr_WhenNull, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.WhenNull);
		        }
		    }
		    position += parent.WhenNull.FullSpan.Length;
		}
		
		public void VisitCondExpr(CondExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Condition.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Condition.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Condition);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCondExpr(Use_CondExpr_Condition, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Condition);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Condition == null || parent.Condition.IsMissing) AddResultsForCondExpr(Use_CondExpr_Condition, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Condition);
		        }
		    }
		    position += parent.Condition.FullSpan.Length;
		    if (parent.TQuestion.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TQuestion);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TQuestion, operation);
		        }
		    }
		    position += parent.TQuestion.FullSpan.Length;
		    if (parent.WhenTrue.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.WhenTrue.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.WhenTrue);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCondExpr(Use_CondExpr_WhenTrue, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.WhenTrue);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.WhenTrue == null || parent.WhenTrue.IsMissing) AddResultsForCondExpr(Use_CondExpr_WhenTrue, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.WhenTrue);
		        }
		    }
		    position += parent.WhenTrue.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.WhenFalse.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.WhenFalse.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.WhenFalse);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCondExpr(Use_CondExpr_WhenFalse, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.WhenFalse);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.WhenFalse == null || parent.WhenFalse.IsMissing) AddResultsForCondExpr(Use_CondExpr_WhenFalse, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.WhenFalse);
		        }
		    }
		    position += parent.WhenFalse.FullSpan.Length;
		}
		
		public void VisitAssignExpr(AssignExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Target.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Target.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Target);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssignExpr(Use_AssignExpr_Target, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Target);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Target == null || parent.Target.IsMissing) AddResultsForAssignExpr(Use_AssignExpr_Target, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Target);
		        }
		    }
		    position += parent.Target.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Value.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Value.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Value);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAssignExpr(Use_AssignExpr_Value, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Value);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Value == null || parent.Value.IsMissing) AddResultsForAssignExpr(Use_AssignExpr_Value, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Value);
		        }
		    }
		    position += parent.Value.FullSpan.Length;
		}
		
		public void VisitCompAssignExpr(CompAssignExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Target.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Target.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Target);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCompAssignExpr(Use_CompAssignExpr_Target, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Target);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Target == null || parent.Target.IsMissing) AddResultsForCompAssignExpr(Use_CompAssignExpr_Target, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Target);
		        }
		    }
		    position += parent.Target.FullSpan.Length;
		    if (parent.CompoundAssignmentOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.CompoundAssignmentOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CompoundAssignmentOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCompAssignExpr(Use_CompAssignExpr_CompoundAssignmentOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CompoundAssignmentOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.CompoundAssignmentOperator == null || parent.CompoundAssignmentOperator.IsMissing) AddResultsForCompAssignExpr(Use_CompAssignExpr_CompoundAssignmentOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.CompoundAssignmentOperator);
		        }
		    }
		    position += parent.CompoundAssignmentOperator.FullSpan.Length;
		    if (parent.Value.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Value.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Value);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCompAssignExpr(Use_CompAssignExpr_Value, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Value);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Value == null || parent.Value.IsMissing) AddResultsForCompAssignExpr(Use_CompAssignExpr_Value, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Value);
		        }
		    }
		    position += parent.Value.FullSpan.Length;
		}
		
		public void VisitLambdaExpr(LambdaExprSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.LambdaSignature.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.LambdaSignature.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LambdaSignature);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaExpr(Use_LambdaExpr_LambdaSignature, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LambdaSignature);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LambdaSignature == null || parent.LambdaSignature.IsMissing) AddResultsForLambdaExpr(Use_LambdaExpr_LambdaSignature, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LambdaSignature);
		        }
		    }
		    position += parent.LambdaSignature.FullSpan.Length;
		    if (parent.TArrow.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TArrow);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TArrow, operation);
		        }
		    }
		    position += parent.TArrow.FullSpan.Length;
		    if (parent.LambdaBody.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.LambdaBody.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LambdaBody);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaExpr(Use_LambdaExpr_LambdaBody, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LambdaBody);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LambdaBody == null || parent.LambdaBody.IsMissing) AddResultsForLambdaExpr(Use_LambdaExpr_LambdaBody, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LambdaBody);
		        }
		    }
		    position += parent.LambdaBody.FullSpan.Length;
		}
		
		public void VisitTupleArguments(TupleArgumentsSyntax parent) // 5
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ArgumentExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ArgumentExpression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentExpression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTupleArguments(Use_TupleArguments_ArgumentExpression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ArgumentExpression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ArgumentExpression == null || parent.ArgumentExpression.IsMissing) AddResultsForTupleArguments(Use_TupleArguments_ArgumentExpression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ArgumentExpression);
		        }
		    }
		    position += parent.ArgumentExpression.FullSpan.Length;
		    if (parent.TComma.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TComma);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TComma, operation);
		        }
		    }
		    position += parent.TComma.FullSpan.Length;
		    if (parent.ArgumentList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ArgumentList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForTupleArguments(Use_TupleArguments_ArgumentList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ArgumentList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ArgumentList == null || parent.ArgumentList.IsMissing) AddResultsForTupleArguments(Use_TupleArguments_ArgumentList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ArgumentList);
		        }
		    }
		    position += parent.ArgumentList.FullSpan.Length;
		}
		
		public void VisitArgumentList(ArgumentListSyntax parent) // 6
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ArgumentExpression.Node == null || parent.ArgumentExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ArgumentExpression.Node == null || !parent.ArgumentExpression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ArgumentExpression.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForArgumentList(Use_ArgumentList_ArgumentExpression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ArgumentExpression.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ArgumentExpression.FullSpan.Length;
		}
		
		public void VisitArgumentExpression(ArgumentExpressionSyntax parent) // 7
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Name == null || parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Name == null || !parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForArgumentExpression(Use_ArgumentExpression_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForArgumentExpression(Use_ArgumentExpression_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    if (parent.Name != null) position += parent.Name.FullSpan.Length;
		    if (parent.TColon.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TColon);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TColon, operation);
		        }
		    }
		    position += parent.TColon.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForArgumentExpression(Use_ArgumentExpression_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForArgumentExpression(Use_ArgumentExpression_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitInitializerExpression(InitializerExpressionSyntax parent) // 8
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FieldInitializerExpressions == null || parent.FieldInitializerExpressions.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldInitializerExpressions == null || !parent.FieldInitializerExpressions.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldInitializerExpressions);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForInitializerExpression(Use_InitializerExpression_FieldInitializerExpressions, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.FieldInitializerExpressions);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.FieldInitializerExpressions == null || parent.FieldInitializerExpressions.IsMissing) AddResultsForInitializerExpression(Use_InitializerExpression_FieldInitializerExpressions, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.FieldInitializerExpressions);
		        }
		    }
		    if (parent.FieldInitializerExpressions != null) position += parent.FieldInitializerExpressions.FullSpan.Length;
		    if (parent.CollectionInitializerExpressions == null || parent.CollectionInitializerExpressions.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.CollectionInitializerExpressions == null || !parent.CollectionInitializerExpressions.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CollectionInitializerExpressions);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForInitializerExpression(Use_InitializerExpression_CollectionInitializerExpressions, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CollectionInitializerExpressions);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.CollectionInitializerExpressions == null || parent.CollectionInitializerExpressions.IsMissing) AddResultsForInitializerExpression(Use_InitializerExpression_CollectionInitializerExpressions, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.CollectionInitializerExpressions);
		        }
		    }
		    if (parent.CollectionInitializerExpressions != null) position += parent.CollectionInitializerExpressions.FullSpan.Length;
		    if (parent.DictionaryInitializerExpressions == null || parent.DictionaryInitializerExpressions.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DictionaryInitializerExpressions == null || !parent.DictionaryInitializerExpressions.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DictionaryInitializerExpressions);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForInitializerExpression(Use_InitializerExpression_DictionaryInitializerExpressions, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DictionaryInitializerExpressions);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DictionaryInitializerExpressions == null || parent.DictionaryInitializerExpressions.IsMissing) AddResultsForInitializerExpression(Use_InitializerExpression_DictionaryInitializerExpressions, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DictionaryInitializerExpressions);
		        }
		    }
		    if (parent.DictionaryInitializerExpressions != null) position += parent.DictionaryInitializerExpressions.FullSpan.Length;
		}
		
		public void VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax parent) // 9
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.FieldInitializerExpression.Node == null || parent.FieldInitializerExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.FieldInitializerExpression.Node == null || !parent.FieldInitializerExpression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.FieldInitializerExpression.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldInitializerExpressions(Use_FieldInitializerExpressions_FieldInitializerExpression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.FieldInitializerExpression.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.FieldInitializerExpression.FullSpan.Length;
		}
		
		public void VisitFieldInitializerExpression(FieldInitializerExpressionSyntax parent) // 10
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldInitializerExpression(Use_FieldInitializerExpression_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForFieldInitializerExpression(Use_FieldInitializerExpression_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForFieldInitializerExpression(Use_FieldInitializerExpression_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForFieldInitializerExpression(Use_FieldInitializerExpression_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax parent) // 11
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression.Node == null || parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Expression.Node == null || !parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCollectionInitializerExpressions(Use_CollectionInitializerExpressions_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Expression.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax parent) // 12
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.DictionaryInitializerExpression.Node == null || parent.DictionaryInitializerExpression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DictionaryInitializerExpression.Node == null || !parent.DictionaryInitializerExpression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DictionaryInitializerExpression.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDictionaryInitializerExpressions(Use_DictionaryInitializerExpressions_DictionaryInitializerExpression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.DictionaryInitializerExpression.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.DictionaryInitializerExpression.FullSpan.Length;
		}
		
		public void VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax parent) // 13
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDictionaryInitializerExpression(Use_DictionaryInitializerExpression_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForDictionaryInitializerExpression(Use_DictionaryInitializerExpression_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		    if (parent.TAssign.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TAssign);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TAssign, operation);
		        }
		    }
		    position += parent.TAssign.FullSpan.Length;
		    if (parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDictionaryInitializerExpression(Use_DictionaryInitializerExpression_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForDictionaryInitializerExpression(Use_DictionaryInitializerExpression_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    position += parent.Expression.FullSpan.Length;
		}
		
		public void VisitLambdaSignature(LambdaSignatureSyntax parent) // 14
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ImplicitLambdaSignature == null || parent.ImplicitLambdaSignature.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ImplicitLambdaSignature == null || !parent.ImplicitLambdaSignature.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ImplicitLambdaSignature);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaSignature(Use_LambdaSignature_ImplicitLambdaSignature, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ImplicitLambdaSignature);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ImplicitLambdaSignature == null || parent.ImplicitLambdaSignature.IsMissing) AddResultsForLambdaSignature(Use_LambdaSignature_ImplicitLambdaSignature, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ImplicitLambdaSignature);
		        }
		    }
		    if (parent.ImplicitLambdaSignature != null) position += parent.ImplicitLambdaSignature.FullSpan.Length;
		    if (parent.ExplicitLambdaSignature == null || parent.ExplicitLambdaSignature.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ExplicitLambdaSignature == null || !parent.ExplicitLambdaSignature.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ExplicitLambdaSignature);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaSignature(Use_LambdaSignature_ExplicitLambdaSignature, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ExplicitLambdaSignature);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ExplicitLambdaSignature == null || parent.ExplicitLambdaSignature.IsMissing) AddResultsForLambdaSignature(Use_LambdaSignature_ExplicitLambdaSignature, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ExplicitLambdaSignature);
		        }
		    }
		    if (parent.ExplicitLambdaSignature != null) position += parent.ExplicitLambdaSignature.FullSpan.Length;
		}
		
		public void VisitImplicitLambdaSignature(ImplicitLambdaSignatureSyntax parent) // 15
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ImplicitParameter == null || parent.ImplicitParameter.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ImplicitParameter == null || !parent.ImplicitParameter.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ImplicitParameter);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForImplicitLambdaSignature(Use_ImplicitLambdaSignature_ImplicitParameter, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ImplicitParameter);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ImplicitParameter == null || parent.ImplicitParameter.IsMissing) AddResultsForImplicitLambdaSignature(Use_ImplicitLambdaSignature_ImplicitParameter, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ImplicitParameter);
		        }
		    }
		    if (parent.ImplicitParameter != null) position += parent.ImplicitParameter.FullSpan.Length;
		    if (parent.ImplicitParameterList == null || parent.ImplicitParameterList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ImplicitParameterList == null || !parent.ImplicitParameterList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ImplicitParameterList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForImplicitLambdaSignature(Use_ImplicitLambdaSignature_ImplicitParameterList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ImplicitParameterList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ImplicitParameterList == null || parent.ImplicitParameterList.IsMissing) AddResultsForImplicitLambdaSignature(Use_ImplicitLambdaSignature_ImplicitParameterList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ImplicitParameterList);
		        }
		    }
		    if (parent.ImplicitParameterList != null) position += parent.ImplicitParameterList.FullSpan.Length;
		}
		
		public void VisitImplicitParameterList(ImplicitParameterListSyntax parent) // 16
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ImplicitParameter.Node == null || parent.ImplicitParameter.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ImplicitParameter.Node == null || !parent.ImplicitParameter.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ImplicitParameter.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForImplicitParameterList(Use_ImplicitParameterList_ImplicitParameter, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ImplicitParameter.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ImplicitParameter.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitImplicitParameter(ImplicitParameterSyntax parent) // 17
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForImplicitParameter(Use_ImplicitParameter_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForImplicitParameter(Use_ImplicitParameter_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		}
		
		public void VisitExplicitLambdaSignature(ExplicitLambdaSignatureSyntax parent) // 18
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.ExplicitParameterList.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.ExplicitParameterList.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ExplicitParameterList);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForExplicitLambdaSignature(Use_ExplicitLambdaSignature_ExplicitParameterList, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ExplicitParameterList);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ExplicitParameterList == null || parent.ExplicitParameterList.IsMissing) AddResultsForExplicitLambdaSignature(Use_ExplicitLambdaSignature_ExplicitParameterList, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ExplicitParameterList);
		        }
		    }
		    position += parent.ExplicitParameterList.FullSpan.Length;
		}
		
		public void VisitExplicitParameterList(ExplicitParameterListSyntax parent) // 19
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TOpenParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenParen, operation);
		        }
		    }
		    position += parent.TOpenParen.FullSpan.Length;
		    if (parent.ExplicitParameter.Node == null || parent.ExplicitParameter.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ExplicitParameter.Node == null || !parent.ExplicitParameter.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ExplicitParameter.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForExplicitParameterList(Use_ExplicitParameterList_ExplicitParameter, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.ExplicitParameter.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.ExplicitParameter.FullSpan.Length;
		    if (parent.TCloseParen.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseParen);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseParen, operation);
		        }
		    }
		    position += parent.TCloseParen.FullSpan.Length;
		}
		
		public void VisitExplicitParameter(ExplicitParameterSyntax parent) // 20
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForExplicitParameter(Use_ExplicitParameter_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForExplicitParameter(Use_ExplicitParameter_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.Name.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Name.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Name);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForExplicitParameter(Use_ExplicitParameter_Name, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Name);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Name == null || parent.Name.IsMissing) AddResultsForExplicitParameter(Use_ExplicitParameter_Name, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Name);
		        }
		    }
		    position += parent.Name.FullSpan.Length;
		}
		
		public void VisitLambdaBody(LambdaBodySyntax parent) // 21
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Expression == null || parent.Expression.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Expression == null || !parent.Expression.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Expression);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaBody(Use_LambdaBody_Expression, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Expression);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Expression == null || parent.Expression.IsMissing) AddResultsForLambdaBody(Use_LambdaBody_Expression, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Expression);
		        }
		    }
		    if (parent.Expression != null) position += parent.Expression.FullSpan.Length;
		    if (parent.BlockStatement == null || parent.BlockStatement.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.BlockStatement == null || !parent.BlockStatement.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.BlockStatement);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLambdaBody(Use_LambdaBody_BlockStatement, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.BlockStatement);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.BlockStatement == null || parent.BlockStatement.IsMissing) AddResultsForLambdaBody(Use_LambdaBody_BlockStatement, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.BlockStatement);
		        }
		    }
		    if (parent.BlockStatement != null) position += parent.BlockStatement.FullSpan.Length;
		}
		
		public void VisitDotOperator(DotOperatorSyntax parent) // 22
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.DotOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.DotOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DotOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForDotOperator(Use_DotOperator_DotOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DotOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForDotOperator(Use_DotOperator_DotOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.DotOperator.FullSpan.Length;
		}
		
		public void VisitIndexerOperator(IndexerOperatorSyntax parent) // 23
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.IndexerOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.IndexerOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.IndexerOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForIndexerOperator(Use_IndexerOperator_IndexerOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.IndexerOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForIndexerOperator(Use_IndexerOperator_IndexerOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.IndexerOperator.FullSpan.Length;
		}
		
		public void VisitPostfixOperator(PostfixOperatorSyntax parent) // 24
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PostfixOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PostfixOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PostfixOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPostfixOperator(Use_PostfixOperator_PostfixOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PostfixOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForPostfixOperator(Use_PostfixOperator_PostfixOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.PostfixOperator.FullSpan.Length;
		}
		
		public void VisitUnaryOperator(UnaryOperatorSyntax parent) // 25
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.UnaryOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.UnaryOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.UnaryOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForUnaryOperator(Use_UnaryOperator_UnaryOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.UnaryOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForUnaryOperator(Use_UnaryOperator_UnaryOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.UnaryOperator.FullSpan.Length;
		}
		
		public void VisitMultiplicativeOperator(MultiplicativeOperatorSyntax parent) // 26
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.MultiplicativeOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.MultiplicativeOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.MultiplicativeOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForMultiplicativeOperator(Use_MultiplicativeOperator_MultiplicativeOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.MultiplicativeOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForMultiplicativeOperator(Use_MultiplicativeOperator_MultiplicativeOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.MultiplicativeOperator.FullSpan.Length;
		}
		
		public void VisitAdditiveOperator(AdditiveOperatorSyntax parent) // 27
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.AdditiveOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.AdditiveOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.AdditiveOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForAdditiveOperator(Use_AdditiveOperator_AdditiveOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.AdditiveOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForAdditiveOperator(Use_AdditiveOperator_AdditiveOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.AdditiveOperator.FullSpan.Length;
		}
		
		public void VisitShiftOperator(ShiftOperatorSyntax parent) // 28
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.LeftShiftOperator == null || parent.LeftShiftOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.LeftShiftOperator == null || !parent.LeftShiftOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.LeftShiftOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForShiftOperator(Use_ShiftOperator_LeftShiftOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.LeftShiftOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.LeftShiftOperator == null || parent.LeftShiftOperator.IsMissing) AddResultsForShiftOperator(Use_ShiftOperator_LeftShiftOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.LeftShiftOperator);
		        }
		    }
		    if (parent.LeftShiftOperator != null) position += parent.LeftShiftOperator.FullSpan.Length;
		    if (parent.RightShiftOperator == null || parent.RightShiftOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.RightShiftOperator == null || !parent.RightShiftOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RightShiftOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForShiftOperator(Use_ShiftOperator_RightShiftOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.RightShiftOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.RightShiftOperator == null || parent.RightShiftOperator.IsMissing) AddResultsForShiftOperator(Use_ShiftOperator_RightShiftOperator, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.RightShiftOperator);
		        }
		    }
		    if (parent.RightShiftOperator != null) position += parent.RightShiftOperator.FullSpan.Length;
		}
		
		public void VisitLeftShiftOperator(LeftShiftOperatorSyntax parent) // 29
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.First.FullSpan.Length;
		    position += parent.Second.FullSpan.Length;
		}
		
		public void VisitRightShiftOperator(RightShiftOperatorSyntax parent) // 30
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.First.FullSpan.Length;
		    position += parent.Second.FullSpan.Length;
		}
		
		public void VisitRelationalOperator(RelationalOperatorSyntax parent) // 31
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.RelationalOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.RelationalOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.RelationalOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForRelationalOperator(Use_RelationalOperator_RelationalOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.RelationalOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForRelationalOperator(Use_RelationalOperator_RelationalOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.RelationalOperator.FullSpan.Length;
		}
		
		public void VisitEqualityOperator(EqualityOperatorSyntax parent) // 32
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.EqualityOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.EqualityOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.EqualityOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForEqualityOperator(Use_EqualityOperator_EqualityOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.EqualityOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForEqualityOperator(Use_EqualityOperator_EqualityOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.EqualityOperator.FullSpan.Length;
		}
		
		public void VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax parent) // 33
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.CompoundAssignmentOperator.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.CompoundAssignmentOperator.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.CompoundAssignmentOperator);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForCompoundAssignmentOperator(Use_CompoundAssignmentOperator_CompoundAssignmentOperator, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.CompoundAssignmentOperator);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForCompoundAssignmentOperator(Use_CompoundAssignmentOperator_CompoundAssignmentOperator, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.CompoundAssignmentOperator.FullSpan.Length;
		}
		
		public void VisitReturnType(ReturnTypeSyntax parent) // 34
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference == null || parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.TypeReference == null || !parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForReturnType(Use_ReturnType_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForReturnType(Use_ReturnType_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    if (parent.TypeReference != null) position += parent.TypeReference.FullSpan.Length;
		    if (parent.VoidType == null || parent.VoidType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.VoidType == null || !parent.VoidType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.VoidType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForReturnType(Use_ReturnType_VoidType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.VoidType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.VoidType == null || parent.VoidType.IsMissing) AddResultsForReturnType(Use_ReturnType_VoidType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.VoidType);
		        }
		    }
		    if (parent.VoidType != null) position += parent.VoidType.FullSpan.Length;
		}
		
		public void VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PrimitiveType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PrimitiveType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PrimitiveType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPrimitiveTypeRef(Use_PrimitiveTypeRef_PrimitiveType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PrimitiveType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.PrimitiveType == null || parent.PrimitiveType.IsMissing) AddResultsForPrimitiveTypeRef(Use_PrimitiveTypeRef_PrimitiveType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.PrimitiveType);
		        }
		    }
		    position += parent.PrimitiveType.FullSpan.Length;
		}
		
		public void VisitGenericTypeRef(GenericTypeRefSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.NamedType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.NamedType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NamedType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGenericTypeRef(Use_GenericTypeRef_NamedType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NamedType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NamedType == null || parent.NamedType.IsMissing) AddResultsForGenericTypeRef(Use_GenericTypeRef_NamedType, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NamedType);
		        }
		    }
		    position += parent.NamedType.FullSpan.Length;
		    if (parent.GenericTypeArguments.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.GenericTypeArguments.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.GenericTypeArguments);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGenericTypeRef(Use_GenericTypeRef_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.GenericTypeArguments);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.GenericTypeArguments == null || parent.GenericTypeArguments.IsMissing) AddResultsForGenericTypeRef(Use_GenericTypeRef_GenericTypeArguments, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.GenericTypeArguments);
		        }
		    }
		    position += parent.GenericTypeArguments.FullSpan.Length;
		}
		
		public void VisitNamedTypeRef(NamedTypeRefSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamedTypeRef(Use_NamedTypeRef_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForNamedTypeRef(Use_NamedTypeRef_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitArrayTypeRef(ArrayTypeRefSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForArrayTypeRef(Use_ArrayTypeRef_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForArrayTypeRef(Use_ArrayTypeRef_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TOpenBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TOpenBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TOpenBracket, operation);
		        }
		    }
		    position += parent.TOpenBracket.FullSpan.Length;
		    if (parent.TCloseBracket.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TCloseBracket);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TCloseBracket, operation);
		        }
		    }
		    position += parent.TCloseBracket.FullSpan.Length;
		}
		
		public void VisitNullableTypeRef(NullableTypeRefSyntax parent) // -1
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNullableTypeRef(Use_NullableTypeRef_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForNullableTypeRef(Use_NullableTypeRef_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		    if (parent.TQuestion.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TQuestion);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TQuestion, operation);
		        }
		    }
		    position += parent.TQuestion.FullSpan.Length;
		}
		
		public void VisitNamedType(NamedTypeSyntax parent) // 36
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForNamedType(Use_NamedType_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForNamedType(Use_NamedType_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitGenericTypeArguments(GenericTypeArgumentsSyntax parent) // 37
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TLessThan.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TLessThan);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TLessThan, operation);
		        }
		    }
		    position += parent.TLessThan.FullSpan.Length;
		    if (parent.GenericTypeArgument.Node == null || parent.GenericTypeArgument.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.GenericTypeArgument.Node == null || !parent.GenericTypeArgument.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.GenericTypeArgument.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGenericTypeArguments(Use_GenericTypeArguments_GenericTypeArgument, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.GenericTypeArgument.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.GenericTypeArgument.FullSpan.Length;
		    if (parent.TGreaterThan.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.TGreaterThan);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.TGreaterThan, operation);
		        }
		    }
		    position += parent.TGreaterThan.FullSpan.Length;
		}
		
		public void VisitGenericTypeArgument(GenericTypeArgumentSyntax parent) // 38
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.TypeReference.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.TypeReference.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.TypeReference);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForGenericTypeArgument(Use_GenericTypeArgument_TypeReference, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.TypeReference);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.TypeReference == null || parent.TypeReference.IsMissing) AddResultsForGenericTypeArgument(Use_GenericTypeArgument_TypeReference, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.TypeReference);
		        }
		    }
		    position += parent.TypeReference.FullSpan.Length;
		}
		
		public void VisitPrimitiveType(PrimitiveTypeSyntax parent) // 39
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.PrimitiveType.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.PrimitiveType.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.PrimitiveType);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForPrimitiveType(Use_PrimitiveType_PrimitiveType, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.PrimitiveType);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddResultsForPrimitiveType(Use_PrimitiveType_PrimitiveType, operation, Compilation.GetBinder(parent));
		        }
		    }
		    position += parent.PrimitiveType.FullSpan.Length;
		}
		
		public void VisitVoidType(VoidTypeSyntax parent) // 40
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KVoid.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KVoid);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KVoid, operation);
		        }
		    }
		    position += parent.KVoid.FullSpan.Length;
		}
		
		public void VisitName(NameSyntax parent) // 41
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Identifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Identifier == null || parent.Identifier.IsMissing) AddResultsForName(Use_Name_Identifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Identifier);
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitQualifiedName(QualifiedNameSyntax parent) // 42
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Qualifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (!parent.Qualifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Qualifier);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.Qualifier);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.Qualifier == null || parent.Qualifier.IsMissing) AddResultsForQualifiedName(Use_QualifiedName_Qualifier, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.Qualifier);
		        }
		    }
		    position += parent.Qualifier.FullSpan.Length;
		}
		
		public void VisitQualifier(QualifierSyntax parent) // 43
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.Identifier.Node == null || parent.Identifier.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.Identifier.Node == null || !parent.Identifier.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.Identifier.Node);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForQualifier(Use_Qualifier_Identifier, operation, Compilation.GetBinder(parent));
		            }
		        }
		        foreach (var item in parent.Identifier.GetWithSeparators())
		        {
		            operation = GetOperation(position, item);
		            if (operation != CompletionSearchFlags.None)
		            {
		                if (item.IsToken) AddBinder(item, operation);
		                else VisitCore(item.AsNode());
		            }
		        }
		    }
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitIdentifier(IdentifierSyntax parent) // 44
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.Identifier.FullSpan.Length;
		}
		
		public void VisitLiteral(LiteralSyntax parent) // 45
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.NullLiteral == null || parent.NullLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.NullLiteral == null || !parent.NullLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.NullLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.NullLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.NullLiteral == null || parent.NullLiteral.IsMissing) AddResultsForLiteral(Use_Literal_NullLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.NullLiteral);
		        }
		    }
		    if (parent.NullLiteral != null) position += parent.NullLiteral.FullSpan.Length;
		    if (parent.BooleanLiteral == null || parent.BooleanLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.BooleanLiteral == null || !parent.BooleanLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.BooleanLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.BooleanLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.BooleanLiteral == null || parent.BooleanLiteral.IsMissing) AddResultsForLiteral(Use_Literal_BooleanLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.BooleanLiteral);
		        }
		    }
		    if (parent.BooleanLiteral != null) position += parent.BooleanLiteral.FullSpan.Length;
		    if (parent.IntegerLiteral == null || parent.IntegerLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.IntegerLiteral == null || !parent.IntegerLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.IntegerLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.IntegerLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.IntegerLiteral == null || parent.IntegerLiteral.IsMissing) AddResultsForLiteral(Use_Literal_IntegerLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.IntegerLiteral);
		        }
		    }
		    if (parent.IntegerLiteral != null) position += parent.IntegerLiteral.FullSpan.Length;
		    if (parent.DecimalLiteral == null || parent.DecimalLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.DecimalLiteral == null || !parent.DecimalLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.DecimalLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.DecimalLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.DecimalLiteral == null || parent.DecimalLiteral.IsMissing) AddResultsForLiteral(Use_Literal_DecimalLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.DecimalLiteral);
		        }
		    }
		    if (parent.DecimalLiteral != null) position += parent.DecimalLiteral.FullSpan.Length;
		    if (parent.ScientificLiteral == null || parent.ScientificLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.ScientificLiteral == null || !parent.ScientificLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.ScientificLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.ScientificLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.ScientificLiteral == null || parent.ScientificLiteral.IsMissing) AddResultsForLiteral(Use_Literal_ScientificLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.ScientificLiteral);
		        }
		    }
		    if (parent.ScientificLiteral != null) position += parent.ScientificLiteral.FullSpan.Length;
		    if (parent.StringLiteral == null || parent.StringLiteral.FullSpan.IntersectsWith(FullSpan))
		    {
		        if (parent.StringLiteral == null || !parent.StringLiteral.Span.Contains(Span))
		        {
		            operation = GetOperation(position, parent.StringLiteral);
		            if (operation != CompletionSearchFlags.None)
		            {
		                AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            }
		        }
		        operation = this.GetOperation(position, parent.StringLiteral);
		        if (operation != CompletionSearchFlags.None)
		        {
		            if (parent.StringLiteral == null || parent.StringLiteral.IsMissing) AddResultsForLiteral(Use_Literal_StringLiteral, operation, Compilation.GetBinder(parent));
		            else VisitCore(parent.StringLiteral);
		        }
		    }
		    if (parent.StringLiteral != null) position += parent.StringLiteral.FullSpan.Length;
		}
		
		public void VisitNullLiteral(NullLiteralSyntax parent) // 46
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    if (parent.KNull.FullSpan.IntersectsWith(FullSpan))
		    {
		        operation = this.GetOperation(position, parent.KNull);
		        if (operation != CompletionSearchFlags.None)
		        {
		            AddBinder(parent.KNull, operation);
		        }
		    }
		    position += parent.KNull.FullSpan.Length;
		}
		
		public void VisitBooleanLiteral(BooleanLiteralSyntax parent) // 47
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.BooleanLiteral.FullSpan.Length;
		}
		
		public void VisitIntegerLiteral(IntegerLiteralSyntax parent) // 48
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LInteger.FullSpan.Length;
		}
		
		public void VisitDecimalLiteral(DecimalLiteralSyntax parent) // 49
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LDecimal.FullSpan.Length;
		}
		
		public void VisitScientificLiteral(ScientificLiteralSyntax parent) // 50
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LScientific.FullSpan.Length;
		}
		
		public void VisitStringLiteral(StringLiteralSyntax parent) // 51
		{
		    if (!parent.FullSpan.IntersectsWith(FullSpan)) return;
		    var position = parent.FullSpan.Start;
		    var operation = CompletionSearchFlags.None;
		    position += parent.LRegularString.FullSpan.Length;
		}

        public void VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax node)
        {
        }

        
        public void AddResultsForMain(object use, CompletionSearchFlags operation, Binder parentBinder) // 0
        {
            if (_visited[0]) return;
            _visited[0] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Main_UsingNamespace)
            {
                var binder = ruleBinder;
                AddResultsForUsingNamespace(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Main_Statement)
            {
                var binder = ruleBinder;
                AddResultsForStatement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.Eof, operation);
                use = FinishedUse;
            }
            _visited[0] = false;
        }
        
        public void AddResultsForUsingNamespace(object use, CompletionSearchFlags operation, Binder parentBinder) // 1
        {
            if (_visited[1]) return;
            _visited[1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateImportBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KUsing, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UsingNamespace_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAssign, operation);
            }
            if (use == UnassignedUse || use == Use_UsingNamespace_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[1] = false;
        }
        
        public void AddResultsForStatement(object use, CompletionSearchFlags operation, Binder parentBinder) // 2
        {
            if (_visited[2]) return;
            _visited[2] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ExpressionStatement), forCompletion: true);
            if (use == UnassignedUse || use == Use_Statement_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Expression", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TSemicolon, operation);
                use = FinishedUse;
            }
            _visited[2] = false;
        }
        
        public void AddResultsForBlockStatement(object use, CompletionSearchFlags operation, Binder parentBinder) // 3
        {
            if (_visited[3]) return;
            _visited[3] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BlockStatement), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenBrace, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_BlockStatement_Statement)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Statements", forCompletion: true);
                AddResultsForStatement(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseBrace, operation);
                use = FinishedUse;
            }
            _visited[3] = false;
        }
        
        public void AddResultsForExpression(object use, CompletionSearchFlags operation, Binder parentBinder) // 4
        {
            if (_visited[4]) return;
            _visited[4] = true;
            object altUse;
            if (use == Use_ParenthesizedExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForParenthesizedExpr(altUse, operation, parentBinder);
            if (use == Use_TupleExpr_TupleArguments) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForTupleExpr(altUse, operation, parentBinder);
            AddResultsForDiscardExpr(altUse, operation, parentBinder);
            AddResultsForDefaultExpr(altUse, operation, parentBinder);
            AddResultsForThisExpr(altUse, operation, parentBinder);
            AddResultsForBaseExpr(altUse, operation, parentBinder);
            if (use == Use_LiteralExpr_Literal) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForLiteralExpr(altUse, operation, parentBinder);
            if (use == Use_IdentifierExpr_Identifier || use == Use_IdentifierExpr_GenericTypeArguments) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForIdentifierExpr(altUse, operation, parentBinder);
            if (use == Use_QualifierExpr_Expression || use == Use_QualifierExpr_DotOperator || use == Use_QualifierExpr_Identifier || use == Use_QualifierExpr_GenericTypeArguments) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForQualifierExpr(altUse, operation, parentBinder);
            if (use == Use_IndexerExpr_Expression || use == Use_IndexerExpr_IndexerOperator || use == Use_IndexerExpr_ArgumentList) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForIndexerExpr(altUse, operation, parentBinder);
            if (use == Use_InvocationExpr_Expression || use == Use_InvocationExpr_ArgumentList) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForInvocationExpr(altUse, operation, parentBinder);
            if (use == Use_TypeofExpr_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForTypeofExpr(altUse, operation, parentBinder);
            if (use == Use_NameofExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForNameofExpr(altUse, operation, parentBinder);
            if (use == Use_SizeofExpr_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForSizeofExpr(altUse, operation, parentBinder);
            if (use == Use_CheckedExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForCheckedExpr(altUse, operation, parentBinder);
            if (use == Use_UncheckedExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForUncheckedExpr(altUse, operation, parentBinder);
            if (use == Use_NewExpr_TypeReference || use == Use_NewExpr_ArgumentList || use == Use_NewExpr_InitializerExpression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForNewExpr(altUse, operation, parentBinder);
            if (use == Use_PostfixUnaryExpr_Expression || use == Use_PostfixUnaryExpr_PostfixOperator) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForPostfixUnaryExpr(altUse, operation, parentBinder);
            if (use == Use_NullForgivingExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForNullForgivingExpr(altUse, operation, parentBinder);
            if (use == Use_UnaryExpr_UnaryOperator || use == Use_UnaryExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForUnaryExpr(altUse, operation, parentBinder);
            if (use == Use_TypeCastExpr_TypeReference || use == Use_TypeCastExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForTypeCastExpr(altUse, operation, parentBinder);
            if (use == Use_AwaitExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForAwaitExpr(altUse, operation, parentBinder);
            if (use == Use_RangeExpr_Left || use == Use_RangeExpr_TDotDot || use == Use_RangeExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForRangeExpr(altUse, operation, parentBinder);
            if (use == Use_MultExpr_Left || use == Use_MultExpr_MultiplicativeOperator || use == Use_MultExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForMultExpr(altUse, operation, parentBinder);
            if (use == Use_AddExpr_Left || use == Use_AddExpr_AdditiveOperator || use == Use_AddExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForAddExpr(altUse, operation, parentBinder);
            if (use == Use_ShiftExpr_Left || use == Use_ShiftExpr_ShiftOperator || use == Use_ShiftExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForShiftExpr(altUse, operation, parentBinder);
            if (use == Use_RelExpr_Left || use == Use_RelExpr_RelationalOperator || use == Use_RelExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForRelExpr(altUse, operation, parentBinder);
            if (use == Use_TypeIsExpr_Expression || use == Use_TypeIsExpr_KNot || use == Use_TypeIsExpr_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForTypeIsExpr(altUse, operation, parentBinder);
            if (use == Use_TypeAsExpr_Expression || use == Use_TypeAsExpr_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForTypeAsExpr(altUse, operation, parentBinder);
            if (use == Use_EqExpr_Left || use == Use_EqExpr_EqualityOperator || use == Use_EqExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForEqExpr(altUse, operation, parentBinder);
            if (use == Use_AndExpr_Left || use == Use_AndExpr_TAmpersand || use == Use_AndExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForAndExpr(altUse, operation, parentBinder);
            if (use == Use_XorExpr_Left || use == Use_XorExpr_THat || use == Use_XorExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForXorExpr(altUse, operation, parentBinder);
            if (use == Use_OrExpr_Left || use == Use_OrExpr_TBar || use == Use_OrExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForOrExpr(altUse, operation, parentBinder);
            if (use == Use_AndAlsoExpr_Left || use == Use_AndAlsoExpr_TAndAlso || use == Use_AndAlsoExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForAndAlsoExpr(altUse, operation, parentBinder);
            if (use == Use_OrElseExpr_Left || use == Use_OrElseExpr_TOrElse || use == Use_OrElseExpr_Right) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForOrElseExpr(altUse, operation, parentBinder);
            if (use == Use_ThrowExpr_Expression) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForThrowExpr(altUse, operation, parentBinder);
            if (use == Use_CoalExpr_Value || use == Use_CoalExpr_WhenNull) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForCoalExpr(altUse, operation, parentBinder);
            if (use == Use_CondExpr_Condition || use == Use_CondExpr_WhenTrue || use == Use_CondExpr_WhenFalse) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForCondExpr(altUse, operation, parentBinder);
            if (use == Use_AssignExpr_Target || use == Use_AssignExpr_Value) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForAssignExpr(altUse, operation, parentBinder);
            if (use == Use_CompAssignExpr_Target || use == Use_CompAssignExpr_CompoundAssignmentOperator || use == Use_CompAssignExpr_Value) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForCompAssignExpr(altUse, operation, parentBinder);
            if (use == Use_LambdaExpr_LambdaSignature || use == Use_LambdaExpr_LambdaBody) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForLambdaExpr(altUse, operation, parentBinder);
            _visited[4] = false;
        }
        
        public void AddResultsForParenthesizedExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ParenthesizedExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ParenthesizedExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTupleExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(TupleExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TupleExpr_TupleArguments)
            {
                var binder = ruleBinder;
                AddResultsForTupleArguments(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForDiscardExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(DiscardExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KDiscard, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForDefaultExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(DefaultValueExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KDefault, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForThisExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(InstanceReferenceExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KThis, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForBaseExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(InstanceReferenceExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KBase, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForLiteralExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(LiteralExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_LiteralExpr_Literal)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForLiteral(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForIdentifierExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ReferenceExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_IdentifierExpr_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ReferencedSymbol", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(Declaration)), forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_IdentifierExpr_GenericTypeArguments)
            {
                var binder = ruleBinder;
                AddResultsForGenericTypeArguments(UnassignedUse, operation, binder);
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForQualifierExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ReferenceExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_QualifierExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Qualifier", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_QualifierExpr_DotOperator)
            {
                var binder = ruleBinder;
                AddResultsForDotOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_QualifierExpr_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ReferencedSymbol", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(Declaration)), forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_QualifierExpr_GenericTypeArguments)
            {
                var binder = ruleBinder;
                AddResultsForGenericTypeArguments(UnassignedUse, operation, binder);
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForIndexerExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(IndexerAccessExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_IndexerExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Receiver", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_IndexerExpr_IndexerOperator)
            {
                var binder = ruleBinder;
                AddResultsForIndexerOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_IndexerExpr_ArgumentList)
            {
                var binder = ruleBinder;
                AddResultsForArgumentList(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForInvocationExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(InvocationExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_InvocationExpr_Expression)
            {
                var binder = ruleBinder;
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_InvocationExpr_ArgumentList)
            {
                var binder = ruleBinder;
                AddResultsForArgumentList(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTypeofExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(TypeOfExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KTypeof, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeofExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "TypeOperand", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNameofExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(NameOfExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KNameof, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NameofExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Argument", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForSizeofExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(SizeOfExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KSizeof, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_SizeofExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "TypeOperand", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForCheckedExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KChecked, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CheckedExpr_Expression)
            {
                var binder = ruleBinder;
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForUncheckedExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KUnchecked, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UncheckedExpr_Expression)
            {
                var binder = ruleBinder;
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNewExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ObjectCreationExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KNew, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NewExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ObjectType", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NewExpr_ArgumentList)
            {
                var binder = ruleBinder;
                AddResultsForArgumentList(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_NewExpr_InitializerExpression)
            {
                var binder = ruleBinder;
                AddResultsForInitializerExpression(UnassignedUse, operation, binder);
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForPostfixUnaryExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(UnaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_PostfixUnaryExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_PostfixUnaryExpr_PostfixOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForPostfixOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNullForgivingExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(NullForgivingExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_NullForgivingExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TExclamation, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForUnaryExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(UnaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_UnaryExpr_UnaryOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForUnaryOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_UnaryExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTypeCastExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ConversionExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeCastExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "TargetType", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeCastExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForAwaitExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(AwaitExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KAwait, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AwaitExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operation", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForRangeExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_RangeExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_RangeExpr_TDotDot)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.Range, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TDotDot, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_RangeExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForMultExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_MultExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_MultExpr_MultiplicativeOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForMultiplicativeOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_MultExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForAddExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_AddExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AddExpr_AdditiveOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForAdditiveOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AddExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForShiftExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_ShiftExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ShiftExpr_ShiftOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForShiftOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ShiftExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForRelExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_RelExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_RelExpr_RelationalOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForRelationalOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_RelExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTypeIsExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(IsTypeExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_TypeIsExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ValueOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KIs, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeIsExpr_KNot)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "IsNegated", value: true, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KNot, operation);
            }
            if (use == UnassignedUse || use == Use_TypeIsExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "TypeOperand", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTypeAsExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ConversionExpression), forCompletion: true);
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "IsTryCast", value: true, forCompletion: true);
            if (use == UnassignedUse || use == Use_TypeAsExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Operand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KAs, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TypeAsExpr_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "TargetType", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForEqExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_EqExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_EqExpr_EqualityOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForEqualityOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_EqExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForAndExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_AndExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AndExpr_TAmpersand)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.BitwiseAnd, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAmpersand, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AndExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForXorExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_XorExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_XorExpr_THat)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.BitwiseXor, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.THat, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_XorExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForOrExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_OrExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OrExpr_TBar)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.BitwiseOr, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TBar, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OrExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForAndAlsoExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_AndAlsoExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AndAlsoExpr_TAndAlso)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.LogicalAnd, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAndAlso, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AndAlsoExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForOrElseExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(BinaryExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_OrElseExpr_Left)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "LeftOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OrElseExpr_TOrElse)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
            	binder = this.BinderFactory.CreateValueBinder(binder, null, value: BinaryOperatorKind.LogicalOr, forCompletion: true);
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOrElse, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_OrElseExpr_Right)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "RightOperand", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForThrowExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ThrowExpression), forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KThrow, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ThrowExpr_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Exception", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForCoalExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(CoalesceExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_CoalExpr_Value)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TQuestionQuestion, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CoalExpr_WhenNull)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "WhenNull", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForCondExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ConditionalExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_CondExpr_Condition)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Condition", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TQuestion, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CondExpr_WhenTrue)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "WhenTrue", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TColon, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CondExpr_WhenFalse)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "WhenFalse", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForAssignExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(AssignmentExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_AssignExpr_Target)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Target", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_AssignExpr_Value)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForCompAssignExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(CompoundAssignmentExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_CompAssignExpr_Target)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Target", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CompAssignExpr_CompoundAssignmentOperator)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "OperatorKind", forCompletion: true);
                AddResultsForCompoundAssignmentOperator(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_CompAssignExpr_Value)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForLambdaExpr(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(LambdaExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_LambdaExpr_LambdaSignature)
            {
                var binder = ruleBinder;
                AddResultsForLambdaSignature(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TArrow, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_LambdaExpr_LambdaBody)
            {
                var binder = ruleBinder;
                AddResultsForLambdaBody(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForTupleArguments(object use, CompletionSearchFlags operation, Binder parentBinder) // 5
        {
            if (_visited[5]) return;
            _visited[5] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Arguments", forCompletion: true);
            if (use == UnassignedUse || use == Use_TupleArguments_ArgumentExpression)
            {
                var binder = ruleBinder;
                AddResultsForArgumentExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TComma, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_TupleArguments_ArgumentList)
            {
                var binder = ruleBinder;
                AddResultsForArgumentList(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[5] = false;
        }
        
        public void AddResultsForArgumentList(object use, CompletionSearchFlags operation, Binder parentBinder) // 6
        {
            if (_visited[6]) return;
            _visited[6] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Arguments", forCompletion: true);
            if (use == UnassignedUse || use == Use_ArgumentList_ArgumentExpression)
            {
                var binder = ruleBinder;
                AddResultsForArgumentExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[6] = false;
        }
        
        public void AddResultsForArgumentExpression(object use, CompletionSearchFlags operation, Binder parentBinder) // 7
        {
            if (_visited[7]) return;
            _visited[7] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(Argument), forCompletion: true);
            if (use == UnassignedUse || use == Use_ArgumentExpression_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TColon, operation);
            }
            if (use == UnassignedUse || use == Use_ArgumentExpression_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[7] = false;
        }
        
        public void AddResultsForInitializerExpression(object use, CompletionSearchFlags operation, Binder parentBinder) // 8
        {
            if (_visited[8]) return;
            _visited[8] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_InitializerExpression_FieldInitializerExpressions)
            {
                var binder = ruleBinder;
                AddResultsForFieldInitializerExpressions(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_InitializerExpression_CollectionInitializerExpressions)
            {
                var binder = ruleBinder;
                AddResultsForCollectionInitializerExpressions(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_InitializerExpression_DictionaryInitializerExpressions)
            {
                var binder = ruleBinder;
                AddResultsForDictionaryInitializerExpressions(UnassignedUse, operation, binder);
            }
            _visited[8] = false;
        }
        
        public void AddResultsForFieldInitializerExpressions(object use, CompletionSearchFlags operation, Binder parentBinder) // 9
        {
            if (_visited[9]) return;
            _visited[9] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_FieldInitializerExpressions_FieldInitializerExpression)
            {
                var binder = ruleBinder;
                AddResultsForFieldInitializerExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[9] = false;
        }
        
        public void AddResultsForFieldInitializerExpression(object use, CompletionSearchFlags operation, Binder parentBinder) // 10
        {
            if (_visited[10]) return;
            _visited[10] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(AssignmentExpression), forCompletion: true);
            if (use == UnassignedUse || use == Use_FieldInitializerExpression_Identifier)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Target", forCompletion: true);
            	binder = this.BinderFactory.CreateUseBinder(binder, null, types: ImmutableArray.Create(typeof(FieldLikeMember)), forCompletion: true);
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_FieldInitializerExpression_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Value", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[10] = false;
        }
        
        public void AddResultsForCollectionInitializerExpressions(object use, CompletionSearchFlags operation, Binder parentBinder) // 11
        {
            if (_visited[11]) return;
            _visited[11] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_CollectionInitializerExpressions_Expression)
            {
                var binder = ruleBinder;
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[11] = false;
        }
        
        public void AddResultsForDictionaryInitializerExpressions(object use, CompletionSearchFlags operation, Binder parentBinder) // 12
        {
            if (_visited[12]) return;
            _visited[12] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_DictionaryInitializerExpressions_DictionaryInitializerExpression)
            {
                var binder = ruleBinder;
                AddResultsForDictionaryInitializerExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[12] = false;
        }
        
        public void AddResultsForDictionaryInitializerExpression(object use, CompletionSearchFlags operation, Binder parentBinder) // 13
        {
            if (_visited[13]) return;
            _visited[13] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_DictionaryInitializerExpression_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TAssign, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_DictionaryInitializerExpression_Expression)
            {
                var binder = ruleBinder;
                AddResultsForExpression(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[13] = false;
        }
        
        public void AddResultsForLambdaSignature(object use, CompletionSearchFlags operation, Binder parentBinder) // 14
        {
            if (_visited[14]) return;
            _visited[14] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_LambdaSignature_ImplicitLambdaSignature)
            {
                var binder = ruleBinder;
                AddResultsForImplicitLambdaSignature(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LambdaSignature_ExplicitLambdaSignature)
            {
                var binder = ruleBinder;
                AddResultsForExplicitLambdaSignature(UnassignedUse, operation, binder);
            }
            _visited[14] = false;
        }
        
        public void AddResultsForImplicitLambdaSignature(object use, CompletionSearchFlags operation, Binder parentBinder) // 15
        {
            if (_visited[15]) return;
            _visited[15] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ImplicitLambdaSignature_ImplicitParameter)
            {
                var binder = ruleBinder;
                AddResultsForImplicitParameter(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ImplicitLambdaSignature_ImplicitParameterList)
            {
                var binder = ruleBinder;
                AddResultsForImplicitParameterList(UnassignedUse, operation, binder);
            }
            _visited[15] = false;
        }
        
        public void AddResultsForImplicitParameterList(object use, CompletionSearchFlags operation, Binder parentBinder) // 16
        {
            if (_visited[16]) return;
            _visited[16] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Parameters", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ImplicitParameterList_ImplicitParameter)
            {
                var binder = ruleBinder;
                AddResultsForImplicitParameter(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[16] = false;
        }
        
        public void AddResultsForImplicitParameter(object use, CompletionSearchFlags operation, Binder parentBinder) // 17
        {
            if (_visited[17]) return;
            _visited[17] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Parameters", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(Parameter), forCompletion: true);
            if (use == UnassignedUse || use == Use_ImplicitParameter_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[17] = false;
        }
        
        public void AddResultsForExplicitLambdaSignature(object use, CompletionSearchFlags operation, Binder parentBinder) // 18
        {
            if (_visited[18]) return;
            _visited[18] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ExplicitLambdaSignature_ExplicitParameterList)
            {
                var binder = ruleBinder;
                AddResultsForExplicitParameterList(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[18] = false;
        }
        
        public void AddResultsForExplicitParameterList(object use, CompletionSearchFlags operation, Binder parentBinder) // 19
        {
            if (_visited[19]) return;
            _visited[19] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Parameters", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenParen, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ExplicitParameterList_ExplicitParameter)
            {
                var binder = ruleBinder;
                AddResultsForExplicitParameter(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseParen, operation);
                use = FinishedUse;
            }
            _visited[19] = false;
        }
        
        public void AddResultsForExplicitParameter(object use, CompletionSearchFlags operation, Binder parentBinder) // 20
        {
            if (_visited[20]) return;
            _visited[20] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Parameters", forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(Parameter), forCompletion: true);
            if (use == UnassignedUse || use == Use_ExplicitParameter_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Type", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_ExplicitParameter_Name)
            {
                var binder = ruleBinder;
                AddResultsForName(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[20] = false;
        }
        
        public void AddResultsForLambdaBody(object use, CompletionSearchFlags operation, Binder parentBinder) // 21
        {
            if (_visited[21]) return;
            _visited[21] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Body", forCompletion: true);
            if (use == UnassignedUse || use == Use_LambdaBody_Expression)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreateDefineBinder(binder, null, type: typeof(ExpressionStatement), forCompletion: true);
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "Expression", forCompletion: true);
                AddResultsForExpression(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_LambdaBody_BlockStatement)
            {
                var binder = ruleBinder;
                AddResultsForBlockStatement(UnassignedUse, operation, binder);
            }
            _visited[21] = false;
        }
        
        public void AddResultsForDotOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 22
        {
            if (_visited[22]) return;
            _visited[22] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_DotOperator_DotOperator)
            {
                var binder = ruleBinder;
            	var TDotBinder = binder;
            	AddBinder(TDotBinder, (CoreSyntaxKind)CoreSyntaxKind.TDot, operation);
            	var TQuestionDotBinder = binder;
            	TQuestionDotBinder = this.BinderFactory.CreatePropertyBinder(TQuestionDotBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TQuestionDot), name: "IsNullConditional", value: true, forCompletion: true);
            	AddBinder(TQuestionDotBinder, (CoreSyntaxKind)CoreSyntaxKind.TQuestionDot, operation);
                use = FinishedUse;
            }
            _visited[22] = false;
        }
        
        public void AddResultsForIndexerOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 23
        {
            if (_visited[23]) return;
            _visited[23] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_IndexerOperator_IndexerOperator)
            {
                var binder = ruleBinder;
            	var TOpenBracketBinder = binder;
            	AddBinder(TOpenBracketBinder, (CoreSyntaxKind)CoreSyntaxKind.TOpenBracket, operation);
            	var TQuestionOpenBracketBinder = binder;
            	TQuestionOpenBracketBinder = this.BinderFactory.CreatePropertyBinder(TQuestionOpenBracketBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TQuestionOpenBracket), name: "IsNullConditional", value: true, forCompletion: true);
            	AddBinder(TQuestionOpenBracketBinder, (CoreSyntaxKind)CoreSyntaxKind.TQuestionOpenBracket, operation);
                use = FinishedUse;
            }
            _visited[23] = false;
        }
        
        public void AddResultsForPostfixOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 24
        {
            if (_visited[24]) return;
            _visited[24] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_PostfixOperator_PostfixOperator)
            {
                var binder = ruleBinder;
            	var TPlusPlusBinder = binder;
            	TPlusPlusBinder = this.BinderFactory.CreateValueBinder(TPlusPlusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPlusPlus), value: UnaryOperatorKind.PostfixIncrement, forCompletion: true);
            	AddBinder(TPlusPlusBinder, (CoreSyntaxKind)CoreSyntaxKind.TPlusPlus, operation);
            	var TMinusMinusBinder = binder;
            	TMinusMinusBinder = this.BinderFactory.CreateValueBinder(TMinusMinusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TMinusMinus), value: UnaryOperatorKind.PostfixDecrement, forCompletion: true);
            	AddBinder(TMinusMinusBinder, (CoreSyntaxKind)CoreSyntaxKind.TMinusMinus, operation);
                use = FinishedUse;
            }
            _visited[24] = false;
        }
        
        public void AddResultsForUnaryOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 25
        {
            if (_visited[25]) return;
            _visited[25] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_UnaryOperator_UnaryOperator)
            {
                var binder = ruleBinder;
            	var TPlusBinder = binder;
            	TPlusBinder = this.BinderFactory.CreateValueBinder(TPlusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPlus), value: UnaryOperatorKind.UnaryPlus, forCompletion: true);
            	AddBinder(TPlusBinder, (CoreSyntaxKind)CoreSyntaxKind.TPlus, operation);
            	var TMinusBinder = binder;
            	TMinusBinder = this.BinderFactory.CreateValueBinder(TMinusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TMinus), value: UnaryOperatorKind.UnaryMinus, forCompletion: true);
            	AddBinder(TMinusBinder, (CoreSyntaxKind)CoreSyntaxKind.TMinus, operation);
            	var TExclamationBinder = binder;
            	TExclamationBinder = this.BinderFactory.CreateValueBinder(TExclamationBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TExclamation), value: UnaryOperatorKind.LogicalNegation, forCompletion: true);
            	AddBinder(TExclamationBinder, (CoreSyntaxKind)CoreSyntaxKind.TExclamation, operation);
            	var TTildeBinder = binder;
            	TTildeBinder = this.BinderFactory.CreateValueBinder(TTildeBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TTilde), value: UnaryOperatorKind.BitwiseComplement, forCompletion: true);
            	AddBinder(TTildeBinder, (CoreSyntaxKind)CoreSyntaxKind.TTilde, operation);
            	var TPlusPlusBinder = binder;
            	TPlusPlusBinder = this.BinderFactory.CreateValueBinder(TPlusPlusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPlusPlus), value: UnaryOperatorKind.PrefixIncrement, forCompletion: true);
            	AddBinder(TPlusPlusBinder, (CoreSyntaxKind)CoreSyntaxKind.TPlusPlus, operation);
            	var TMinusMinusBinder = binder;
            	TMinusMinusBinder = this.BinderFactory.CreateValueBinder(TMinusMinusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TMinusMinus), value: UnaryOperatorKind.PrefixDecrement, forCompletion: true);
            	AddBinder(TMinusMinusBinder, (CoreSyntaxKind)CoreSyntaxKind.TMinusMinus, operation);
            	var THatBinder = binder;
            	THatBinder = this.BinderFactory.CreateValueBinder(THatBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.THat), value: UnaryOperatorKind.IndexFromEnd, forCompletion: true);
            	AddBinder(THatBinder, (CoreSyntaxKind)CoreSyntaxKind.THat, operation);
                use = FinishedUse;
            }
            _visited[25] = false;
        }
        
        public void AddResultsForMultiplicativeOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 26
        {
            if (_visited[26]) return;
            _visited[26] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_MultiplicativeOperator_MultiplicativeOperator)
            {
                var binder = ruleBinder;
            	var TAsteriskBinder = binder;
            	TAsteriskBinder = this.BinderFactory.CreateValueBinder(TAsteriskBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TAsterisk), value: BinaryOperatorKind.Multiplication, forCompletion: true);
            	AddBinder(TAsteriskBinder, (CoreSyntaxKind)CoreSyntaxKind.TAsterisk, operation);
            	var TSlashBinder = binder;
            	TSlashBinder = this.BinderFactory.CreateValueBinder(TSlashBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TSlash), value: BinaryOperatorKind.Division, forCompletion: true);
            	AddBinder(TSlashBinder, (CoreSyntaxKind)CoreSyntaxKind.TSlash, operation);
            	var TPercentBinder = binder;
            	TPercentBinder = this.BinderFactory.CreateValueBinder(TPercentBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPercent), value: BinaryOperatorKind.Remainder, forCompletion: true);
            	AddBinder(TPercentBinder, (CoreSyntaxKind)CoreSyntaxKind.TPercent, operation);
                use = FinishedUse;
            }
            _visited[26] = false;
        }
        
        public void AddResultsForAdditiveOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 27
        {
            if (_visited[27]) return;
            _visited[27] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "OperatorKind", forCompletion: true);
            if (use == UnassignedUse || use == Use_AdditiveOperator_AdditiveOperator)
            {
                var binder = ruleBinder;
            	var TPlusBinder = binder;
            	TPlusBinder = this.BinderFactory.CreateValueBinder(TPlusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPlus), value: BinaryOperatorKind.Addition, forCompletion: true);
            	AddBinder(TPlusBinder, (CoreSyntaxKind)CoreSyntaxKind.TPlus, operation);
            	var TMinusBinder = binder;
            	TMinusBinder = this.BinderFactory.CreateValueBinder(TMinusBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TMinus), value: BinaryOperatorKind.Subtraction, forCompletion: true);
            	AddBinder(TMinusBinder, (CoreSyntaxKind)CoreSyntaxKind.TMinus, operation);
                use = FinishedUse;
            }
            _visited[27] = false;
        }
        
        public void AddResultsForShiftOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 28
        {
            if (_visited[28]) return;
            _visited[28] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ShiftOperator_LeftShiftOperator)
            {
                var binder = ruleBinder;
                AddResultsForLeftShiftOperator(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ShiftOperator_RightShiftOperator)
            {
                var binder = ruleBinder;
                AddResultsForRightShiftOperator(UnassignedUse, operation, binder);
            }
            _visited[28] = false;
        }
        
        public void AddResultsForLeftShiftOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 29
        {
            if (_visited[29]) return;
            _visited[29] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, value: BinaryOperatorKind.LeftShift, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            _visited[29] = false;
        }
        
        public void AddResultsForRightShiftOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 30
        {
            if (_visited[30]) return;
            _visited[30] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, value: BinaryOperatorKind.RightShift, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            _visited[30] = false;
        }
        
        public void AddResultsForRelationalOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 31
        {
            if (_visited[31]) return;
            _visited[31] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_RelationalOperator_RelationalOperator)
            {
                var binder = ruleBinder;
            	var TLessThanBinder = binder;
            	TLessThanBinder = this.BinderFactory.CreateValueBinder(TLessThanBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TLessThan), value: BinaryOperatorKind.LessThan, forCompletion: true);
            	AddBinder(TLessThanBinder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
            	var TGreaterThanBinder = binder;
            	TGreaterThanBinder = this.BinderFactory.CreateValueBinder(TGreaterThanBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TGreaterThan), value: BinaryOperatorKind.GreaterThan, forCompletion: true);
            	AddBinder(TGreaterThanBinder, (CoreSyntaxKind)CoreSyntaxKind.TGreaterThan, operation);
            	var TLessThanOrEqualBinder = binder;
            	TLessThanOrEqualBinder = this.BinderFactory.CreateValueBinder(TLessThanOrEqualBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TLessThanOrEqual), value: BinaryOperatorKind.LessThanOrEqual, forCompletion: true);
            	AddBinder(TLessThanOrEqualBinder, (CoreSyntaxKind)CoreSyntaxKind.TLessThanOrEqual, operation);
            	var TGreaterThanOrEqualBinder = binder;
            	TGreaterThanOrEqualBinder = this.BinderFactory.CreateValueBinder(TGreaterThanOrEqualBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TGreaterThanOrEqual), value: BinaryOperatorKind.GreaterThanOrEqual, forCompletion: true);
            	AddBinder(TGreaterThanOrEqualBinder, (CoreSyntaxKind)CoreSyntaxKind.TGreaterThanOrEqual, operation);
                use = FinishedUse;
            }
            _visited[31] = false;
        }
        
        public void AddResultsForEqualityOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 32
        {
            if (_visited[32]) return;
            _visited[32] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_EqualityOperator_EqualityOperator)
            {
                var binder = ruleBinder;
            	var TEqualBinder = binder;
            	TEqualBinder = this.BinderFactory.CreateValueBinder(TEqualBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TEqual), value: BinaryOperatorKind.Equal, forCompletion: true);
            	AddBinder(TEqualBinder, (CoreSyntaxKind)CoreSyntaxKind.TEqual, operation);
            	var TNotEqualBinder = binder;
            	TNotEqualBinder = this.BinderFactory.CreateValueBinder(TNotEqualBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TNotEqual), value: BinaryOperatorKind.NotEqual, forCompletion: true);
            	AddBinder(TNotEqualBinder, (CoreSyntaxKind)CoreSyntaxKind.TNotEqual, operation);
                use = FinishedUse;
            }
            _visited[32] = false;
        }
        
        public void AddResultsForCompoundAssignmentOperator(object use, CompletionSearchFlags operation, Binder parentBinder) // 33
        {
            if (_visited[33]) return;
            _visited[33] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_CompoundAssignmentOperator_CompoundAssignmentOperator)
            {
                var binder = ruleBinder;
            	var TPlusAssignBinder = binder;
            	TPlusAssignBinder = this.BinderFactory.CreateValueBinder(TPlusAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPlusAssign), value: BinaryOperatorKind.Addition, forCompletion: true);
            	AddBinder(TPlusAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TPlusAssign, operation);
            	var TMinusAssignBinder = binder;
            	TMinusAssignBinder = this.BinderFactory.CreateValueBinder(TMinusAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TMinusAssign), value: BinaryOperatorKind.Subtraction, forCompletion: true);
            	AddBinder(TMinusAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TMinusAssign, operation);
            	var TAsteriskAssignBinder = binder;
            	TAsteriskAssignBinder = this.BinderFactory.CreateValueBinder(TAsteriskAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TAsteriskAssign), value: BinaryOperatorKind.Multiplication, forCompletion: true);
            	AddBinder(TAsteriskAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TAsteriskAssign, operation);
            	var TSlashAssignBinder = binder;
            	TSlashAssignBinder = this.BinderFactory.CreateValueBinder(TSlashAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TSlashAssign), value: BinaryOperatorKind.Division, forCompletion: true);
            	AddBinder(TSlashAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TSlashAssign, operation);
            	var TPercentAssignBinder = binder;
            	TPercentAssignBinder = this.BinderFactory.CreateValueBinder(TPercentAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TPercentAssign), value: BinaryOperatorKind.Remainder, forCompletion: true);
            	AddBinder(TPercentAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TPercentAssign, operation);
            	var TAmpersandAssignBinder = binder;
            	TAmpersandAssignBinder = this.BinderFactory.CreateValueBinder(TAmpersandAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TAmpersandAssign), value: BinaryOperatorKind.LogicalAnd, forCompletion: true);
            	AddBinder(TAmpersandAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TAmpersandAssign, operation);
            	var THatAssignBinder = binder;
            	THatAssignBinder = this.BinderFactory.CreateValueBinder(THatAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.THatAssign), value: BinaryOperatorKind.LogicalXor, forCompletion: true);
            	AddBinder(THatAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.THatAssign, operation);
            	var TBarAssignBinder = binder;
            	TBarAssignBinder = this.BinderFactory.CreateValueBinder(TBarAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TBarAssign), value: BinaryOperatorKind.LogicalOr, forCompletion: true);
            	AddBinder(TBarAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TBarAssign, operation);
            	var TLeftShiftAssignBinder = binder;
            	TLeftShiftAssignBinder = this.BinderFactory.CreateValueBinder(TLeftShiftAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TLeftShiftAssign), value: BinaryOperatorKind.LeftShift, forCompletion: true);
            	AddBinder(TLeftShiftAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TLeftShiftAssign, operation);
            	var TRightShiftAssignBinder = binder;
            	TRightShiftAssignBinder = this.BinderFactory.CreateValueBinder(TRightShiftAssignBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.TRightShiftAssign), value: BinaryOperatorKind.RightShift, forCompletion: true);
            	AddBinder(TRightShiftAssignBinder, (CoreSyntaxKind)CoreSyntaxKind.TRightShiftAssign, operation);
                use = FinishedUse;
            }
            _visited[33] = false;
        }
        
        public void AddResultsForReturnType(object use, CompletionSearchFlags operation, Binder parentBinder) // 34
        {
            if (_visited[34]) return;
            _visited[34] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_ReturnType_TypeReference)
            {
                var binder = ruleBinder;
                AddResultsForTypeReference(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_ReturnType_VoidType)
            {
                var binder = ruleBinder;
                AddResultsForVoidType(UnassignedUse, operation, binder);
            }
            _visited[34] = false;
        }
        
        public void AddResultsForTypeReference(object use, CompletionSearchFlags operation, Binder parentBinder) // 35
        {
            if (_visited[35]) return;
            _visited[35] = true;
            object altUse;
            if (use == Use_PrimitiveTypeRef_PrimitiveType) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForPrimitiveTypeRef(altUse, operation, parentBinder);
            if (use == Use_GenericTypeRef_NamedType || use == Use_GenericTypeRef_GenericTypeArguments) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForGenericTypeRef(altUse, operation, parentBinder);
            if (use == Use_NamedTypeRef_Qualifier) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForNamedTypeRef(altUse, operation, parentBinder);
            if (use == Use_ArrayTypeRef_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForArrayTypeRef(altUse, operation, parentBinder);
            if (use == Use_NullableTypeRef_TypeReference) altUse = use;
            else altUse = UnassignedUse;
            AddResultsForNullableTypeRef(altUse, operation, parentBinder);
            _visited[35] = false;
        }
        
        public void AddResultsForPrimitiveTypeRef(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(DataType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_PrimitiveTypeRef_PrimitiveType)
            {
                var binder = ruleBinder;
                AddResultsForPrimitiveType(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForGenericTypeRef(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(DataType)), forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(GenericTypeReference), forCompletion: true);
            if (use == UnassignedUse || use == Use_GenericTypeRef_NamedType)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ReferencedType", forCompletion: true);
                AddResultsForNamedType(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_GenericTypeRef_GenericTypeArguments)
            {
                var binder = ruleBinder;
                AddResultsForGenericTypeArguments(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNamedTypeRef(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(DataType)), forCompletion: true);
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_NamedTypeRef_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForArrayTypeRef(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(DataType)), forCompletion: true);
            ruleBinder = this.BinderFactory.CreateDefineBinder(ruleBinder, null, type: typeof(ArrayType), forCompletion: true);
            if (use == UnassignedUse || use == Use_ArrayTypeRef_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "ElementType", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TOpenBracket, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TCloseBracket, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNullableTypeRef(object use, CompletionSearchFlags operation, Binder parentBinder) // -1
        {
            if (_visited[-1]) return;
            _visited[-1] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(DataType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_NullableTypeRef_TypeReference)
            {
                var binder = ruleBinder;
            	binder = this.BinderFactory.CreatePropertyBinder(binder, null, name: "InnerType", forCompletion: true);
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TQuestion, operation);
                use = FinishedUse;
            }
            _visited[-1] = false;
        }
        
        public void AddResultsForNamedType(object use, CompletionSearchFlags operation, Binder parentBinder) // 36
        {
            if (_visited[36]) return;
            _visited[36] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateUseBinder(ruleBinder, null, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)), forCompletion: true);
            if (use == UnassignedUse || use == Use_NamedType_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[36] = false;
        }
        
        public void AddResultsForGenericTypeArguments(object use, CompletionSearchFlags operation, Binder parentBinder) // 37
        {
            if (_visited[37]) return;
            _visited[37] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "TypeArguments", forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TLessThan, operation);
                use = FinishedUse;
            }
            if (use == UnassignedUse || use == Use_GenericTypeArguments_GenericTypeArgument)
            {
                var binder = ruleBinder;
                AddResultsForGenericTypeArgument(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.TGreaterThan, operation);
                use = FinishedUse;
            }
            _visited[37] = false;
        }
        
        public void AddResultsForGenericTypeArgument(object use, CompletionSearchFlags operation, Binder parentBinder) // 38
        {
            if (_visited[38]) return;
            _visited[38] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_GenericTypeArgument_TypeReference)
            {
                var binder = ruleBinder;
                AddResultsForTypeReference(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[38] = false;
        }
        
        public void AddResultsForPrimitiveType(object use, CompletionSearchFlags operation, Binder parentBinder) // 39
        {
            if (_visited[39]) return;
            _visited[39] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_PrimitiveType_PrimitiveType)
            {
                var binder = ruleBinder;
            	var KObjectBinder = binder;
            	KObjectBinder = this.BinderFactory.CreateValueBinder(KObjectBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KObject), value: CoreInstance.Object, forCompletion: true);
            	AddBinder(KObjectBinder, (CoreSyntaxKind)CoreSyntaxKind.KObject, operation);
            	var KBoolBinder = binder;
            	KBoolBinder = this.BinderFactory.CreateValueBinder(KBoolBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KBool), value: CoreInstance.Boolean, forCompletion: true);
            	AddBinder(KBoolBinder, (CoreSyntaxKind)CoreSyntaxKind.KBool, operation);
            	var KCharBinder = binder;
            	KCharBinder = this.BinderFactory.CreateValueBinder(KCharBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KChar), value: CoreInstance.Char, forCompletion: true);
            	AddBinder(KCharBinder, (CoreSyntaxKind)CoreSyntaxKind.KChar, operation);
            	var KSByteBinder = binder;
            	KSByteBinder = this.BinderFactory.CreateValueBinder(KSByteBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KSByte), value: CoreInstance.SByte, forCompletion: true);
            	AddBinder(KSByteBinder, (CoreSyntaxKind)CoreSyntaxKind.KSByte, operation);
            	var KByteBinder = binder;
            	KByteBinder = this.BinderFactory.CreateValueBinder(KByteBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KByte), value: CoreInstance.Byte, forCompletion: true);
            	AddBinder(KByteBinder, (CoreSyntaxKind)CoreSyntaxKind.KByte, operation);
            	var KShortBinder = binder;
            	KShortBinder = this.BinderFactory.CreateValueBinder(KShortBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KShort), value: CoreInstance.Int16, forCompletion: true);
            	AddBinder(KShortBinder, (CoreSyntaxKind)CoreSyntaxKind.KShort, operation);
            	var KUShortBinder = binder;
            	KUShortBinder = this.BinderFactory.CreateValueBinder(KUShortBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KUShort), value: CoreInstance.UInt16, forCompletion: true);
            	AddBinder(KUShortBinder, (CoreSyntaxKind)CoreSyntaxKind.KUShort, operation);
            	var KIntBinder = binder;
            	KIntBinder = this.BinderFactory.CreateValueBinder(KIntBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KInt), value: CoreInstance.Int32, forCompletion: true);
            	AddBinder(KIntBinder, (CoreSyntaxKind)CoreSyntaxKind.KInt, operation);
            	var KUIntBinder = binder;
            	KUIntBinder = this.BinderFactory.CreateValueBinder(KUIntBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KUInt), value: CoreInstance.UInt32, forCompletion: true);
            	AddBinder(KUIntBinder, (CoreSyntaxKind)CoreSyntaxKind.KUInt, operation);
            	var KLongBinder = binder;
            	KLongBinder = this.BinderFactory.CreateValueBinder(KLongBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KLong), value: CoreInstance.Int64, forCompletion: true);
            	AddBinder(KLongBinder, (CoreSyntaxKind)CoreSyntaxKind.KLong, operation);
            	var KULongBinder = binder;
            	KULongBinder = this.BinderFactory.CreateValueBinder(KULongBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KULong), value: CoreInstance.UInt64, forCompletion: true);
            	AddBinder(KULongBinder, (CoreSyntaxKind)CoreSyntaxKind.KULong, operation);
            	var KDecimalBinder = binder;
            	KDecimalBinder = this.BinderFactory.CreateValueBinder(KDecimalBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KDecimal), value: CoreInstance.Decimal, forCompletion: true);
            	AddBinder(KDecimalBinder, (CoreSyntaxKind)CoreSyntaxKind.KDecimal, operation);
            	var KFloatBinder = binder;
            	KFloatBinder = this.BinderFactory.CreateValueBinder(KFloatBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KFloat), value: CoreInstance.Single, forCompletion: true);
            	AddBinder(KFloatBinder, (CoreSyntaxKind)CoreSyntaxKind.KFloat, operation);
            	var KDoubleBinder = binder;
            	KDoubleBinder = this.BinderFactory.CreateValueBinder(KDoubleBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KDouble), value: CoreInstance.Double, forCompletion: true);
            	AddBinder(KDoubleBinder, (CoreSyntaxKind)CoreSyntaxKind.KDouble, operation);
            	var KStringBinder = binder;
            	KStringBinder = this.BinderFactory.CreateValueBinder(KStringBinder, this.SyntaxFactory.MissingToken((CoreSyntaxKind)CoreSyntaxKind.KString), value: CoreInstance.String, forCompletion: true);
            	AddBinder(KStringBinder, (CoreSyntaxKind)CoreSyntaxKind.KString, operation);
                use = FinishedUse;
            }
            _visited[39] = false;
        }
        
        public void AddResultsForVoidType(object use, CompletionSearchFlags operation, Binder parentBinder) // 40
        {
            if (_visited[40]) return;
            _visited[40] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, value: CoreInstance.Void, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KVoid, operation);
                use = FinishedUse;
            }
            _visited[40] = false;
        }
        
        public void AddResultsForName(object use, CompletionSearchFlags operation, Binder parentBinder) // 41
        {
            if (_visited[41]) return;
            _visited[41] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Name_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[41] = false;
        }
        
        public void AddResultsForQualifiedName(object use, CompletionSearchFlags operation, Binder parentBinder) // 42
        {
            if (_visited[42]) return;
            _visited[42] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateNameBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_QualifiedName_Qualifier)
            {
                var binder = ruleBinder;
                AddResultsForQualifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[42] = false;
        }
        
        public void AddResultsForQualifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 43
        {
            if (_visited[43]) return;
            _visited[43] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateQualifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse || use == Use_Qualifier_Identifier)
            {
                var binder = ruleBinder;
                AddResultsForIdentifier(UnassignedUse, operation, binder);
                use = FinishedUse;
            }
            _visited[43] = false;
        }
        
        public void AddResultsForIdentifier(object use, CompletionSearchFlags operation, Binder parentBinder) // 44
        {
            if (_visited[44]) return;
            _visited[44] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateIdentifierBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var IdentifierNormalBinder = binder;
            	AddBinder(IdentifierNormalBinder, (CoreSyntaxKind)CoreSyntaxKind.IdentifierNormal, operation);
            	var IdentifierVerbatimBinder = binder;
            	AddBinder(IdentifierVerbatimBinder, (CoreSyntaxKind)CoreSyntaxKind.IdentifierVerbatim, operation);
                use = FinishedUse;
            }
            _visited[44] = false;
        }
        
        public void AddResultsForLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 45
        {
            if (_visited[45]) return;
            _visited[45] = true;
            var ruleBinder = parentBinder;
            if (use == UnassignedUse || use == Use_Literal_NullLiteral)
            {
                var binder = ruleBinder;
                AddResultsForNullLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_BooleanLiteral)
            {
                var binder = ruleBinder;
                AddResultsForBooleanLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_IntegerLiteral)
            {
                var binder = ruleBinder;
                AddResultsForIntegerLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_DecimalLiteral)
            {
                var binder = ruleBinder;
                AddResultsForDecimalLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_ScientificLiteral)
            {
                var binder = ruleBinder;
                AddResultsForScientificLiteral(UnassignedUse, operation, binder);
            }
            if (use == UnassignedUse || use == Use_Literal_StringLiteral)
            {
                var binder = ruleBinder;
                AddResultsForStringLiteral(UnassignedUse, operation, binder);
            }
            _visited[45] = false;
        }
        
        public void AddResultsForNullLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 46
        {
            if (_visited[46]) return;
            _visited[46] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.KNull, operation);
                use = FinishedUse;
            }
            _visited[46] = false;
        }
        
        public void AddResultsForBooleanLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 47
        {
            if (_visited[47]) return;
            _visited[47] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Type", value: CoreInstance.Boolean, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	var KTrueBinder = binder;
            	AddBinder(KTrueBinder, (CoreSyntaxKind)CoreSyntaxKind.KTrue, operation);
            	var KFalseBinder = binder;
            	AddBinder(KFalseBinder, (CoreSyntaxKind)CoreSyntaxKind.KFalse, operation);
                use = FinishedUse;
            }
            _visited[47] = false;
        }
        
        public void AddResultsForIntegerLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 48
        {
            if (_visited[48]) return;
            _visited[48] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Type", value: CoreInstance.Int32, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.LInteger, operation);
                use = FinishedUse;
            }
            _visited[48] = false;
        }
        
        public void AddResultsForDecimalLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 49
        {
            if (_visited[49]) return;
            _visited[49] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Type", value: CoreInstance.Decimal, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.LDecimal, operation);
                use = FinishedUse;
            }
            _visited[49] = false;
        }
        
        public void AddResultsForScientificLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 50
        {
            if (_visited[50]) return;
            _visited[50] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Type", value: CoreInstance.Double, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.LScientific, operation);
                use = FinishedUse;
            }
            _visited[50] = false;
        }
        
        public void AddResultsForStringLiteral(object use, CompletionSearchFlags operation, Binder parentBinder) // 51
        {
            if (_visited[51]) return;
            _visited[51] = true;
            var ruleBinder = parentBinder;
            ruleBinder = this.BinderFactory.CreatePropertyBinder(ruleBinder, null, name: "Type", value: CoreInstance.String, forCompletion: true);
            ruleBinder = this.BinderFactory.CreateValueBinder(ruleBinder, null, forCompletion: true);
            if (use == UnassignedUse)
            {
                var binder = ruleBinder;
            	AddBinder(binder, (CoreSyntaxKind)CoreSyntaxKind.LRegularString, operation);
                use = FinishedUse;
            }
            _visited[51] = false;
        }
    }
}

