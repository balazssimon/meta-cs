//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from AnnotatedAntlr4Parser.g4 by ANTLR 4.5

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace MetaDslx.Compiler {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="AnnotatedAntlr4Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5")]
[System.CLSCompliant(false)]
public interface IAnnotatedAntlr4ParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.grammarSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrammarSpec([NotNull] AnnotatedAntlr4Parser.GrammarSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.grammarSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrammarSpec([NotNull] AnnotatedAntlr4Parser.GrammarSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.grammarType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrammarType([NotNull] AnnotatedAntlr4Parser.GrammarTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.grammarType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrammarType([NotNull] AnnotatedAntlr4Parser.GrammarTypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.prequelConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrequelConstruct([NotNull] AnnotatedAntlr4Parser.PrequelConstructContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.prequelConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrequelConstruct([NotNull] AnnotatedAntlr4Parser.PrequelConstructContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.optionsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionsSpec([NotNull] AnnotatedAntlr4Parser.OptionsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.optionsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionsSpec([NotNull] AnnotatedAntlr4Parser.OptionsSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOption([NotNull] AnnotatedAntlr4Parser.OptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOption([NotNull] AnnotatedAntlr4Parser.OptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.optionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionValue([NotNull] AnnotatedAntlr4Parser.OptionValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.optionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionValue([NotNull] AnnotatedAntlr4Parser.OptionValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.delegateGrammars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDelegateGrammars([NotNull] AnnotatedAntlr4Parser.DelegateGrammarsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.delegateGrammars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDelegateGrammars([NotNull] AnnotatedAntlr4Parser.DelegateGrammarsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.delegateGrammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDelegateGrammar([NotNull] AnnotatedAntlr4Parser.DelegateGrammarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.delegateGrammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDelegateGrammar([NotNull] AnnotatedAntlr4Parser.DelegateGrammarContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.tokensSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTokensSpec([NotNull] AnnotatedAntlr4Parser.TokensSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.tokensSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTokensSpec([NotNull] AnnotatedAntlr4Parser.TokensSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAction([NotNull] AnnotatedAntlr4Parser.ActionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAction([NotNull] AnnotatedAntlr4Parser.ActionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.actionScopeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActionScopeName([NotNull] AnnotatedAntlr4Parser.ActionScopeNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.actionScopeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActionScopeName([NotNull] AnnotatedAntlr4Parser.ActionScopeNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.modeSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModeSpec([NotNull] AnnotatedAntlr4Parser.ModeSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.modeSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModeSpec([NotNull] AnnotatedAntlr4Parser.ModeSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRules([NotNull] AnnotatedAntlr4Parser.RulesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRules([NotNull] AnnotatedAntlr4Parser.RulesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleSpec([NotNull] AnnotatedAntlr4Parser.RuleSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleSpec([NotNull] AnnotatedAntlr4Parser.RuleSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.parserRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParserRuleSpec([NotNull] AnnotatedAntlr4Parser.ParserRuleSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.parserRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParserRuleSpec([NotNull] AnnotatedAntlr4Parser.ParserRuleSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.exceptionGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExceptionGroup([NotNull] AnnotatedAntlr4Parser.ExceptionGroupContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.exceptionGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExceptionGroup([NotNull] AnnotatedAntlr4Parser.ExceptionGroupContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.exceptionHandler"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExceptionHandler([NotNull] AnnotatedAntlr4Parser.ExceptionHandlerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.exceptionHandler"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExceptionHandler([NotNull] AnnotatedAntlr4Parser.ExceptionHandlerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.finallyClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFinallyClause([NotNull] AnnotatedAntlr4Parser.FinallyClauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.finallyClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFinallyClause([NotNull] AnnotatedAntlr4Parser.FinallyClauseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.rulePrequel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRulePrequel([NotNull] AnnotatedAntlr4Parser.RulePrequelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.rulePrequel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRulePrequel([NotNull] AnnotatedAntlr4Parser.RulePrequelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleReturns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleReturns([NotNull] AnnotatedAntlr4Parser.RuleReturnsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleReturns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleReturns([NotNull] AnnotatedAntlr4Parser.RuleReturnsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.throwsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterThrowsSpec([NotNull] AnnotatedAntlr4Parser.ThrowsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.throwsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitThrowsSpec([NotNull] AnnotatedAntlr4Parser.ThrowsSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.localsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLocalsSpec([NotNull] AnnotatedAntlr4Parser.LocalsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.localsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLocalsSpec([NotNull] AnnotatedAntlr4Parser.LocalsSpecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleAction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleAction([NotNull] AnnotatedAntlr4Parser.RuleActionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleAction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleAction([NotNull] AnnotatedAntlr4Parser.RuleActionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleModifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleModifiers([NotNull] AnnotatedAntlr4Parser.RuleModifiersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleModifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleModifiers([NotNull] AnnotatedAntlr4Parser.RuleModifiersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleModifier([NotNull] AnnotatedAntlr4Parser.RuleModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleModifier([NotNull] AnnotatedAntlr4Parser.RuleModifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleBlock([NotNull] AnnotatedAntlr4Parser.RuleBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleBlock([NotNull] AnnotatedAntlr4Parser.RuleBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleAltList([NotNull] AnnotatedAntlr4Parser.RuleAltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleAltList([NotNull] AnnotatedAntlr4Parser.RuleAltListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledAlt([NotNull] AnnotatedAntlr4Parser.LabeledAltContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledAlt([NotNull] AnnotatedAntlr4Parser.LabeledAltContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.propertiesBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertiesBlock([NotNull] AnnotatedAntlr4Parser.PropertiesBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.propertiesBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertiesBlock([NotNull] AnnotatedAntlr4Parser.PropertiesBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerRule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerRule([NotNull] AnnotatedAntlr4Parser.LexerRuleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerRule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerRule([NotNull] AnnotatedAntlr4Parser.LexerRuleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerRuleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerRuleBlock([NotNull] AnnotatedAntlr4Parser.LexerRuleBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerRuleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerRuleBlock([NotNull] AnnotatedAntlr4Parser.LexerRuleBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAltList([NotNull] AnnotatedAntlr4Parser.LexerAltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAltList([NotNull] AnnotatedAntlr4Parser.LexerAltListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAlt([NotNull] AnnotatedAntlr4Parser.LexerAltContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAlt([NotNull] AnnotatedAntlr4Parser.LexerAltContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerElements([NotNull] AnnotatedAntlr4Parser.LexerElementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerElements([NotNull] AnnotatedAntlr4Parser.LexerElementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerElement([NotNull] AnnotatedAntlr4Parser.LexerElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerElement([NotNull] AnnotatedAntlr4Parser.LexerElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledLexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledLexerElement([NotNull] AnnotatedAntlr4Parser.LabeledLexerElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledLexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledLexerElement([NotNull] AnnotatedAntlr4Parser.LabeledLexerElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerBlock([NotNull] AnnotatedAntlr4Parser.LexerBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerBlock([NotNull] AnnotatedAntlr4Parser.LexerBlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommands([NotNull] AnnotatedAntlr4Parser.LexerCommandsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommands([NotNull] AnnotatedAntlr4Parser.LexerCommandsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommand([NotNull] AnnotatedAntlr4Parser.LexerCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommand([NotNull] AnnotatedAntlr4Parser.LexerCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommandName([NotNull] AnnotatedAntlr4Parser.LexerCommandNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommandName([NotNull] AnnotatedAntlr4Parser.LexerCommandNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommandExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommandExpr([NotNull] AnnotatedAntlr4Parser.LexerCommandExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerCommandExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommandExpr([NotNull] AnnotatedAntlr4Parser.LexerCommandExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.altList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAltList([NotNull] AnnotatedAntlr4Parser.AltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.altList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAltList([NotNull] AnnotatedAntlr4Parser.AltListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.alternative"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAlternative([NotNull] AnnotatedAntlr4Parser.AlternativeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.alternative"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAlternative([NotNull] AnnotatedAntlr4Parser.AlternativeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElement([NotNull] AnnotatedAntlr4Parser.ElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElement([NotNull] AnnotatedAntlr4Parser.ElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledElement([NotNull] AnnotatedAntlr4Parser.LabeledElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.labeledElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledElement([NotNull] AnnotatedAntlr4Parser.LabeledElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ebnf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEbnf([NotNull] AnnotatedAntlr4Parser.EbnfContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ebnf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEbnf([NotNull] AnnotatedAntlr4Parser.EbnfContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.blockSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockSuffix([NotNull] AnnotatedAntlr4Parser.BlockSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.blockSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockSuffix([NotNull] AnnotatedAntlr4Parser.BlockSuffixContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ebnfSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEbnfSuffix([NotNull] AnnotatedAntlr4Parser.EbnfSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ebnfSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEbnfSuffix([NotNull] AnnotatedAntlr4Parser.EbnfSuffixContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAtom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAtom([NotNull] AnnotatedAntlr4Parser.LexerAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.lexerAtom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAtom([NotNull] AnnotatedAntlr4Parser.LexerAtomContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtom([NotNull] AnnotatedAntlr4Parser.AtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtom([NotNull] AnnotatedAntlr4Parser.AtomContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.notSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotSet([NotNull] AnnotatedAntlr4Parser.NotSetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.notSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotSet([NotNull] AnnotatedAntlr4Parser.NotSetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.blockSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockSet([NotNull] AnnotatedAntlr4Parser.BlockSetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.blockSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockSet([NotNull] AnnotatedAntlr4Parser.BlockSetContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.setElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSetElement([NotNull] AnnotatedAntlr4Parser.SetElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.setElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSetElement([NotNull] AnnotatedAntlr4Parser.SetElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] AnnotatedAntlr4Parser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] AnnotatedAntlr4Parser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleref([NotNull] AnnotatedAntlr4Parser.RulerefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.ruleref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleref([NotNull] AnnotatedAntlr4Parser.RulerefContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRange([NotNull] AnnotatedAntlr4Parser.RangeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRange([NotNull] AnnotatedAntlr4Parser.RangeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.terminal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerminal([NotNull] AnnotatedAntlr4Parser.TerminalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.terminal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerminal([NotNull] AnnotatedAntlr4Parser.TerminalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.elementOptions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementOptions([NotNull] AnnotatedAntlr4Parser.ElementOptionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.elementOptions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementOptions([NotNull] AnnotatedAntlr4Parser.ElementOptionsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.elementOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementOption([NotNull] AnnotatedAntlr4Parser.ElementOptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.elementOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementOption([NotNull] AnnotatedAntlr4Parser.ElementOptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterId([NotNull] AnnotatedAntlr4Parser.IdContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitId([NotNull] AnnotatedAntlr4Parser.IdContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotation([NotNull] AnnotatedAntlr4Parser.AnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotation([NotNull] AnnotatedAntlr4Parser.AnnotationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationBody([NotNull] AnnotatedAntlr4Parser.AnnotationBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationBody([NotNull] AnnotatedAntlr4Parser.AnnotationBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationAttributeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationAttributeList([NotNull] AnnotatedAntlr4Parser.AnnotationAttributeListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationAttributeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationAttributeList([NotNull] AnnotatedAntlr4Parser.AnnotationAttributeListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationAttribute([NotNull] AnnotatedAntlr4Parser.AnnotationAttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.annotationAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationAttribute([NotNull] AnnotatedAntlr4Parser.AnnotationAttributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionList([NotNull] AnnotatedAntlr4Parser.ExpressionListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionList([NotNull] AnnotatedAntlr4Parser.ExpressionListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] AnnotatedAntlr4Parser.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] AnnotatedAntlr4Parser.QualifiedNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] AnnotatedAntlr4Parser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] AnnotatedAntlr4Parser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] AnnotatedAntlr4Parser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] AnnotatedAntlr4Parser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] AnnotatedAntlr4Parser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] AnnotatedAntlr4Parser.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.boolean"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean([NotNull] AnnotatedAntlr4Parser.BooleanContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.boolean"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean([NotNull] AnnotatedAntlr4Parser.BooleanContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="AnnotatedAntlr4Parser.null"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNull([NotNull] AnnotatedAntlr4Parser.NullContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AnnotatedAntlr4Parser.null"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNull([NotNull] AnnotatedAntlr4Parser.NullContext context);
}
} // namespace MetaDslx.Compiler
