﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\Balazs\source\repos\meta-cs\src\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\Antlr4RoslynParser.g4 by ANTLR 4.6.6

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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="Antlr4RoslynParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IAntlr4RoslynParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.grammarSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrammarSpec([NotNull] Antlr4RoslynParser.GrammarSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.grammarSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrammarSpec([NotNull] Antlr4RoslynParser.GrammarSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.grammarType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrammarType([NotNull] Antlr4RoslynParser.GrammarTypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.grammarType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrammarType([NotNull] Antlr4RoslynParser.GrammarTypeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.prequelConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrequelConstruct([NotNull] Antlr4RoslynParser.PrequelConstructContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.prequelConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrequelConstruct([NotNull] Antlr4RoslynParser.PrequelConstructContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.optionsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionsSpec([NotNull] Antlr4RoslynParser.OptionsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.optionsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionsSpec([NotNull] Antlr4RoslynParser.OptionsSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOption([NotNull] Antlr4RoslynParser.OptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.option"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOption([NotNull] Antlr4RoslynParser.OptionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.optionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionValue([NotNull] Antlr4RoslynParser.OptionValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.optionValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionValue([NotNull] Antlr4RoslynParser.OptionValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDelegateGrammars([NotNull] Antlr4RoslynParser.DelegateGrammarsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammars"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDelegateGrammars([NotNull] Antlr4RoslynParser.DelegateGrammarsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDelegateGrammar([NotNull] Antlr4RoslynParser.DelegateGrammarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.delegateGrammar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDelegateGrammar([NotNull] Antlr4RoslynParser.DelegateGrammarContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.tokensSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTokensSpec([NotNull] Antlr4RoslynParser.TokensSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.tokensSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTokensSpec([NotNull] Antlr4RoslynParser.TokensSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.channelsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChannelsSpec([NotNull] Antlr4RoslynParser.ChannelsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.channelsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChannelsSpec([NotNull] Antlr4RoslynParser.ChannelsSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.idList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdList([NotNull] Antlr4RoslynParser.IdListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.idList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdList([NotNull] Antlr4RoslynParser.IdListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotatedIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotatedIdentifier([NotNull] Antlr4RoslynParser.AnnotatedIdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotatedIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotatedIdentifier([NotNull] Antlr4RoslynParser.AnnotatedIdentifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAction([NotNull] Antlr4RoslynParser.ActionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.action"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAction([NotNull] Antlr4RoslynParser.ActionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.actionScopeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActionScopeName([NotNull] Antlr4RoslynParser.ActionScopeNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.actionScopeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActionScopeName([NotNull] Antlr4RoslynParser.ActionScopeNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActionBlock([NotNull] Antlr4RoslynParser.ActionBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.actionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActionBlock([NotNull] Antlr4RoslynParser.ActionBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.argActionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArgActionBlock([NotNull] Antlr4RoslynParser.ArgActionBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.argActionBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArgActionBlock([NotNull] Antlr4RoslynParser.ArgActionBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.modeSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModeSpec([NotNull] Antlr4RoslynParser.ModeSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.modeSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModeSpec([NotNull] Antlr4RoslynParser.ModeSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRules([NotNull] Antlr4RoslynParser.RulesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.rules"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRules([NotNull] Antlr4RoslynParser.RulesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleSpec([NotNull] Antlr4RoslynParser.RuleSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleSpec([NotNull] Antlr4RoslynParser.RuleSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.parserRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParserRuleSpec([NotNull] Antlr4RoslynParser.ParserRuleSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.parserRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParserRuleSpec([NotNull] Antlr4RoslynParser.ParserRuleSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.exceptionGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExceptionGroup([NotNull] Antlr4RoslynParser.ExceptionGroupContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.exceptionGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExceptionGroup([NotNull] Antlr4RoslynParser.ExceptionGroupContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.exceptionHandler"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExceptionHandler([NotNull] Antlr4RoslynParser.ExceptionHandlerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.exceptionHandler"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExceptionHandler([NotNull] Antlr4RoslynParser.ExceptionHandlerContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.finallyClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFinallyClause([NotNull] Antlr4RoslynParser.FinallyClauseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.finallyClause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFinallyClause([NotNull] Antlr4RoslynParser.FinallyClauseContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.rulePrequel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRulePrequel([NotNull] Antlr4RoslynParser.RulePrequelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.rulePrequel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRulePrequel([NotNull] Antlr4RoslynParser.RulePrequelContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleReturns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleReturns([NotNull] Antlr4RoslynParser.RuleReturnsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleReturns"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleReturns([NotNull] Antlr4RoslynParser.RuleReturnsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.throwsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterThrowsSpec([NotNull] Antlr4RoslynParser.ThrowsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.throwsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitThrowsSpec([NotNull] Antlr4RoslynParser.ThrowsSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.localsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLocalsSpec([NotNull] Antlr4RoslynParser.LocalsSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.localsSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLocalsSpec([NotNull] Antlr4RoslynParser.LocalsSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleAction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleAction([NotNull] Antlr4RoslynParser.RuleActionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleAction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleAction([NotNull] Antlr4RoslynParser.RuleActionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleModifiers([NotNull] Antlr4RoslynParser.RuleModifiersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifiers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleModifiers([NotNull] Antlr4RoslynParser.RuleModifiersContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleModifier([NotNull] Antlr4RoslynParser.RuleModifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleModifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleModifier([NotNull] Antlr4RoslynParser.RuleModifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleBlock([NotNull] Antlr4RoslynParser.RuleBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleBlock([NotNull] Antlr4RoslynParser.RuleBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleAltList([NotNull] Antlr4RoslynParser.RuleAltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleAltList([NotNull] Antlr4RoslynParser.RuleAltListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.labeledAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledAlt([NotNull] Antlr4RoslynParser.LabeledAltContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.labeledAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledAlt([NotNull] Antlr4RoslynParser.LabeledAltContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerRuleSpec([NotNull] Antlr4RoslynParser.LexerRuleSpecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleSpec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerRuleSpec([NotNull] Antlr4RoslynParser.LexerRuleSpecContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerRuleBlock([NotNull] Antlr4RoslynParser.LexerRuleBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerRuleBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerRuleBlock([NotNull] Antlr4RoslynParser.LexerRuleBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAltList([NotNull] Antlr4RoslynParser.LexerAltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAltList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAltList([NotNull] Antlr4RoslynParser.LexerAltListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAlt([NotNull] Antlr4RoslynParser.LexerAltContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAlt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAlt([NotNull] Antlr4RoslynParser.LexerAltContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerElements([NotNull] Antlr4RoslynParser.LexerElementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerElements([NotNull] Antlr4RoslynParser.LexerElementsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerElement([NotNull] Antlr4RoslynParser.LexerElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerElement([NotNull] Antlr4RoslynParser.LexerElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.labeledLexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledLexerElement([NotNull] Antlr4RoslynParser.LabeledLexerElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.labeledLexerElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledLexerElement([NotNull] Antlr4RoslynParser.LabeledLexerElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerBlock([NotNull] Antlr4RoslynParser.LexerBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerBlock([NotNull] Antlr4RoslynParser.LexerBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommands([NotNull] Antlr4RoslynParser.LexerCommandsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommands([NotNull] Antlr4RoslynParser.LexerCommandsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommand([NotNull] Antlr4RoslynParser.LexerCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommand([NotNull] Antlr4RoslynParser.LexerCommandContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommandName([NotNull] Antlr4RoslynParser.LexerCommandNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommandName([NotNull] Antlr4RoslynParser.LexerCommandNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerCommandExpr([NotNull] Antlr4RoslynParser.LexerCommandExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerCommandExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerCommandExpr([NotNull] Antlr4RoslynParser.LexerCommandExprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.altList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAltList([NotNull] Antlr4RoslynParser.AltListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.altList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAltList([NotNull] Antlr4RoslynParser.AltListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.alternative"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAlternative([NotNull] Antlr4RoslynParser.AlternativeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.alternative"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAlternative([NotNull] Antlr4RoslynParser.AlternativeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElement([NotNull] Antlr4RoslynParser.ElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElement([NotNull] Antlr4RoslynParser.ElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.labeledElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabeledElement([NotNull] Antlr4RoslynParser.LabeledElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.labeledElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabeledElement([NotNull] Antlr4RoslynParser.LabeledElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ebnf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEbnf([NotNull] Antlr4RoslynParser.EbnfContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ebnf"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEbnf([NotNull] Antlr4RoslynParser.EbnfContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.blockSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockSuffix([NotNull] Antlr4RoslynParser.BlockSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.blockSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockSuffix([NotNull] Antlr4RoslynParser.BlockSuffixContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ebnfSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEbnfSuffix([NotNull] Antlr4RoslynParser.EbnfSuffixContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ebnfSuffix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEbnfSuffix([NotNull] Antlr4RoslynParser.EbnfSuffixContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.lexerAtom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLexerAtom([NotNull] Antlr4RoslynParser.LexerAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.lexerAtom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLexerAtom([NotNull] Antlr4RoslynParser.LexerAtomContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtom([NotNull] Antlr4RoslynParser.AtomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtom([NotNull] Antlr4RoslynParser.AtomContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.notSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotSet([NotNull] Antlr4RoslynParser.NotSetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.notSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotSet([NotNull] Antlr4RoslynParser.NotSetContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.blockSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlockSet([NotNull] Antlr4RoslynParser.BlockSetContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.blockSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlockSet([NotNull] Antlr4RoslynParser.BlockSetContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.setElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSetElement([NotNull] Antlr4RoslynParser.SetElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.setElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSetElement([NotNull] Antlr4RoslynParser.SetElementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] Antlr4RoslynParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] Antlr4RoslynParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.ruleref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRuleref([NotNull] Antlr4RoslynParser.RulerefContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.ruleref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRuleref([NotNull] Antlr4RoslynParser.RulerefContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.characterRange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCharacterRange([NotNull] Antlr4RoslynParser.CharacterRangeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.characterRange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCharacterRange([NotNull] Antlr4RoslynParser.CharacterRangeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.terminal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerminal([NotNull] Antlr4RoslynParser.TerminalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.terminal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerminal([NotNull] Antlr4RoslynParser.TerminalContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.elementOptions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementOptions([NotNull] Antlr4RoslynParser.ElementOptionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.elementOptions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementOptions([NotNull] Antlr4RoslynParser.ElementOptionsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.elementOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementOption([NotNull] Antlr4RoslynParser.ElementOptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.elementOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementOption([NotNull] Antlr4RoslynParser.ElementOptionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] Antlr4RoslynParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] Antlr4RoslynParser.IdentifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotation([NotNull] Antlr4RoslynParser.AnnotationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotation([NotNull] Antlr4RoslynParser.AnnotationContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotationBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationBody([NotNull] Antlr4RoslynParser.AnnotationBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotationBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationBody([NotNull] Antlr4RoslynParser.AnnotationBodyContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttributeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationAttributeList([NotNull] Antlr4RoslynParser.AnnotationAttributeListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttributeList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationAttributeList([NotNull] Antlr4RoslynParser.AnnotationAttributeListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationAttribute([NotNull] Antlr4RoslynParser.AnnotationAttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotationAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationAttribute([NotNull] Antlr4RoslynParser.AnnotationAttributeContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionList([NotNull] Antlr4RoslynParser.ExpressionListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.expressionList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionList([NotNull] Antlr4RoslynParser.ExpressionListContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] Antlr4RoslynParser.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] Antlr4RoslynParser.QualifiedNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] Antlr4RoslynParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] Antlr4RoslynParser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] Antlr4RoslynParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] Antlr4RoslynParser.LiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.annotationIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAnnotationIdentifier([NotNull] Antlr4RoslynParser.AnnotationIdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.annotationIdentifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAnnotationIdentifier([NotNull] Antlr4RoslynParser.AnnotationIdentifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.boolLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolLiteral([NotNull] Antlr4RoslynParser.BoolLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.boolLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolLiteral([NotNull] Antlr4RoslynParser.BoolLiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Antlr4RoslynParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNullLiteral([NotNull] Antlr4RoslynParser.NullLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Antlr4RoslynParser.nullLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNullLiteral([NotNull] Antlr4RoslynParser.NullLiteralContext context);
}
} // namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
