//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\balaz\AppData\Local\Temp\ju2oh3kv.rzt\CalculatorParser.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MetaDslx.Languages.Calculator.Syntax.InternalSyntax {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CalculatorParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
public interface ICalculatorParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] CalculatorParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.statementLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementLine([NotNull] CalculatorParser.StatementLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] CalculatorParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] CalculatorParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>valueExpression</c>
	/// labeled alternative in <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValueExpression([NotNull] CalculatorParser.ValueExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>printExpression</c>
	/// labeled alternative in <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintExpression([NotNull] CalculatorParser.PrintExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>mulOrDivExpression</c>
	/// labeled alternative in <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulOrDivExpression([NotNull] CalculatorParser.MulOrDivExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenExpression</c>
	/// labeled alternative in <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenExpression([NotNull] CalculatorParser.ParenExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addOrSubExpression</c>
	/// labeled alternative in <see cref="CalculatorParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddOrSubExpression([NotNull] CalculatorParser.AddOrSubExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgs([NotNull] CalculatorParser.ArgsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] CalculatorParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] CalculatorParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] CalculatorParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.integer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInteger([NotNull] CalculatorParser.IntegerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculatorParser.arg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArg([NotNull] CalculatorParser.ArgContext context);
}
} // namespace MetaDslx.Languages.Calculator.Syntax.InternalSyntax
