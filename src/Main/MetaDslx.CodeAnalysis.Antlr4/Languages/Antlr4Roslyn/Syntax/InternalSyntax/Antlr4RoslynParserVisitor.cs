//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\Balazs\source\repos\meta-cs\src\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="Antlr4RoslynParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IAntlr4RoslynParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.grammarSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGrammarSpec([NotNull] Antlr4RoslynParser.GrammarSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.grammarType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGrammarType([NotNull] Antlr4RoslynParser.GrammarTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.prequelConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrequelConstruct([NotNull] Antlr4RoslynParser.PrequelConstructContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.optionsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOptionsSpec([NotNull] Antlr4RoslynParser.OptionsSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOption([NotNull] Antlr4RoslynParser.OptionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.optionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOptionValue([NotNull] Antlr4RoslynParser.OptionValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDelegateGrammars([NotNull] Antlr4RoslynParser.DelegateGrammarsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDelegateGrammar([NotNull] Antlr4RoslynParser.DelegateGrammarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.tokensSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTokensSpec([NotNull] Antlr4RoslynParser.TokensSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.channelsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChannelsSpec([NotNull] Antlr4RoslynParser.ChannelsSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.idList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdList([NotNull] Antlr4RoslynParser.IdListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotatedIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotatedIdentifier([NotNull] Antlr4RoslynParser.AnnotatedIdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAction([NotNull] Antlr4RoslynParser.ActionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.actionScopeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitActionScopeName([NotNull] Antlr4RoslynParser.ActionScopeNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitActionBlock([NotNull] Antlr4RoslynParser.ActionBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.argActionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgActionBlock([NotNull] Antlr4RoslynParser.ArgActionBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.modeSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModeSpec([NotNull] Antlr4RoslynParser.ModeSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRules([NotNull] Antlr4RoslynParser.RulesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleSpec([NotNull] Antlr4RoslynParser.RuleSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.parserRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParserRuleSpec([NotNull] Antlr4RoslynParser.ParserRuleSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.exceptionGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExceptionGroup([NotNull] Antlr4RoslynParser.ExceptionGroupContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.exceptionHandler"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExceptionHandler([NotNull] Antlr4RoslynParser.ExceptionHandlerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.finallyClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFinallyClause([NotNull] Antlr4RoslynParser.FinallyClauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.rulePrequel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRulePrequel([NotNull] Antlr4RoslynParser.RulePrequelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleReturns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleReturns([NotNull] Antlr4RoslynParser.RuleReturnsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.throwsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitThrowsSpec([NotNull] Antlr4RoslynParser.ThrowsSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.localsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocalsSpec([NotNull] Antlr4RoslynParser.LocalsSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleAction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleAction([NotNull] Antlr4RoslynParser.RuleActionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleModifiers([NotNull] Antlr4RoslynParser.RuleModifiersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleModifier([NotNull] Antlr4RoslynParser.RuleModifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleBlock([NotNull] Antlr4RoslynParser.RuleBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleAltList([NotNull] Antlr4RoslynParser.RuleAltListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.labeledAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabeledAlt([NotNull] Antlr4RoslynParser.LabeledAltContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerRuleSpec([NotNull] Antlr4RoslynParser.LexerRuleSpecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerRuleBlock([NotNull] Antlr4RoslynParser.LexerRuleBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerAltList([NotNull] Antlr4RoslynParser.LexerAltListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerAlt([NotNull] Antlr4RoslynParser.LexerAltContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerElements([NotNull] Antlr4RoslynParser.LexerElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerElement([NotNull] Antlr4RoslynParser.LexerElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.labeledLexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabeledLexerElement([NotNull] Antlr4RoslynParser.LabeledLexerElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerBlock([NotNull] Antlr4RoslynParser.LexerBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerCommands([NotNull] Antlr4RoslynParser.LexerCommandsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerCommand([NotNull] Antlr4RoslynParser.LexerCommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerCommandName([NotNull] Antlr4RoslynParser.LexerCommandNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerCommandExpr([NotNull] Antlr4RoslynParser.LexerCommandExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.altList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAltList([NotNull] Antlr4RoslynParser.AltListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.alternative"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAlternative([NotNull] Antlr4RoslynParser.AlternativeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElement([NotNull] Antlr4RoslynParser.ElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.labeledElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabeledElement([NotNull] Antlr4RoslynParser.LabeledElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ebnf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEbnf([NotNull] Antlr4RoslynParser.EbnfContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.blockSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockSuffix([NotNull] Antlr4RoslynParser.BlockSuffixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ebnfSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEbnfSuffix([NotNull] Antlr4RoslynParser.EbnfSuffixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAtom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLexerAtom([NotNull] Antlr4RoslynParser.LexerAtomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtom([NotNull] Antlr4RoslynParser.AtomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.notSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotSet([NotNull] Antlr4RoslynParser.NotSetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.blockSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockSet([NotNull] Antlr4RoslynParser.BlockSetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.setElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSetElement([NotNull] Antlr4RoslynParser.SetElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] Antlr4RoslynParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.ruleref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRuleref([NotNull] Antlr4RoslynParser.RulerefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.characterRange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCharacterRange([NotNull] Antlr4RoslynParser.CharacterRangeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.terminal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerminal([NotNull] Antlr4RoslynParser.TerminalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.elementOptions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementOptions([NotNull] Antlr4RoslynParser.ElementOptionsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.elementOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementOption([NotNull] Antlr4RoslynParser.ElementOptionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] Antlr4RoslynParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotation([NotNull] Antlr4RoslynParser.AnnotationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotationBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationBody([NotNull] Antlr4RoslynParser.AnnotationBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttributeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationAttributeList([NotNull] Antlr4RoslynParser.AnnotationAttributeListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationAttribute([NotNull] Antlr4RoslynParser.AnnotationAttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionList([NotNull] Antlr4RoslynParser.ExpressionListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifiedName([NotNull] Antlr4RoslynParser.QualifiedNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] Antlr4RoslynParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] Antlr4RoslynParser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.annotationIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAnnotationIdentifier([NotNull] Antlr4RoslynParser.AnnotationIdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.boolLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolLiteral([NotNull] Antlr4RoslynParser.BoolLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Antlr4RoslynParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullLiteral([NotNull] Antlr4RoslynParser.NullLiteralContext context);
}
} // namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
