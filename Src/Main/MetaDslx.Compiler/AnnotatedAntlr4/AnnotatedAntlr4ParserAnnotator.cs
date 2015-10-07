using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Core;

namespace MetaDslx.Compiler
{
    public class AnnotatedAntlr4ParserAnnotator : AnnotatedAntlr4ParserBaseVisitor<object>
    {
        private AnnotatedAntlr4LexerAnnotator lexerAnnotator = new AnnotatedAntlr4LexerAnnotator();
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<Type, List<object>> ruleAnnotations = new Dictionary<Type, List<object>>();
        private Dictionary<object, List<object>> treeAnnotations = new Dictionary<object, List<object>>();
        
        public List<object> ParserAnnotations { get { return this.grammarAnnotations; } }
        public List<object> LexerAnnotations { get { return this.lexerAnnotator.LexerAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.lexerAnnotator.TokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.lexerAnnotator.ModeAnnotations; } }
        public Dictionary<Type, List<object>> RuleAnnotations { get { return this.ruleAnnotations; } }
        public Dictionary<object, List<object>> TreeAnnotations { get { return this.treeAnnotations; } }
        
        
        public AnnotatedAntlr4ParserAnnotator()
        {
            List<object> annotList = null;
        }
        
        public override object VisitTerminal(ITerminalNode node)
        {
            this.lexerAnnotator.VisitTerminal(node, treeAnnotations);
            this.HandleSymbolType(node);
            return null;
        }
        
        private void HandleSymbolType(IParseTree node)
        {
            List<object> treeAnnotList = null;
            if (this.treeAnnotations.TryGetValue(node, out treeAnnotList))
            {
                foreach (var treeAnnot in treeAnnotList)
                {
                    SymbolTypeAnnotation sta = treeAnnot as SymbolTypeAnnotation;
                    if (sta != null)
                    {
                        if (sta.HasName)
                        {
                            ModelContext ctx = ModelContext.Current;
                            if (ctx != null)
                            {
                                IModelCompiler compiler = ModelContext.Current.Compiler;
                                string name = compiler.NameProvider.GetName(node);
                                if (sta.Name == name)
                                {
                                    this.OverrideSymbolType(node, sta.SymbolType);
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("ModelContext is missing. Define a ModelContextScope.");
                            }
                        }
                        else
                        {
                            this.OverrideSymbolType(node, sta.SymbolType);
                        }
                    }
                }
                treeAnnotList.RemoveAll(a => a is SymbolTypeAnnotation);
            }
        }
        
        private void OverrideSymbolType(IParseTree node, Type symbolType)
        {
            if (node == null) return;
            if (symbolType == null) return;
            bool set = false;
            while(!set && node != null)
            {
                List<object> treeAnnotList = null;
                if (this.treeAnnotations.TryGetValue(node, out treeAnnotList))
                {
                    foreach (var treeAnnot in treeAnnotList)
                    {
                        SymbolTypedAnnotation sta = treeAnnot as SymbolTypedAnnotation;
                        if (sta != null)
                        {
                            set = true;
                            if (sta.SymbolType == null)
                            {
                                sta.SymbolType = symbolType;
                            }
                            else if (sta.OverrideSymbolType)
                            {
                                sta.SymbolType = symbolType;
                            }
                            else
                            {
                                throw new InvalidOperationException("Cannot change symbol type from '"+sta.SymbolType+"' to '"+symbolType+"'");
                            }
                        }
                    }
                }
                node = node.Parent;
            }
        }
        
        public override object VisitGrammarSpec(AnnotatedAntlr4Parser.GrammarSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGrammarSpec(context);
        }
        
        public override object VisitGrammarType(AnnotatedAntlr4Parser.GrammarTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGrammarType(context);
        }
        
        public override object VisitPrequelConstruct(AnnotatedAntlr4Parser.PrequelConstructContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPrequelConstruct(context);
        }
        
        public override object VisitOptionsSpec(AnnotatedAntlr4Parser.OptionsSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitOptionsSpec(context);
        }
        
        public override object VisitOption(AnnotatedAntlr4Parser.OptionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitOption(context);
        }
        
        public override object VisitOptionValue(AnnotatedAntlr4Parser.OptionValueContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitOptionValue(context);
        }
        
        public override object VisitDelegateGrammars(AnnotatedAntlr4Parser.DelegateGrammarsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDelegateGrammars(context);
        }
        
        public override object VisitDelegateGrammar(AnnotatedAntlr4Parser.DelegateGrammarContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDelegateGrammar(context);
        }
        
        public override object VisitTokensSpec(AnnotatedAntlr4Parser.TokensSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTokensSpec(context);
        }
        
        public override object VisitAnnotatedId(AnnotatedAntlr4Parser.AnnotatedIdContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotatedId(context);
        }
        
        public override object VisitAction(AnnotatedAntlr4Parser.ActionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAction(context);
        }
        
        public override object VisitActionScopeName(AnnotatedAntlr4Parser.ActionScopeNameContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitActionScopeName(context);
        }
        
        public override object VisitModeSpec(AnnotatedAntlr4Parser.ModeSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitModeSpec(context);
        }
        
        public override object VisitRules(AnnotatedAntlr4Parser.RulesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRules(context);
        }
        
        public override object VisitRuleSpec(AnnotatedAntlr4Parser.RuleSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleSpec(context);
        }
        
        public override object VisitParserRuleSpec(AnnotatedAntlr4Parser.ParserRuleSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParserRuleSpec(context);
        }
        
        public override object VisitExceptionGroup(AnnotatedAntlr4Parser.ExceptionGroupContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExceptionGroup(context);
        }
        
        public override object VisitExceptionHandler(AnnotatedAntlr4Parser.ExceptionHandlerContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExceptionHandler(context);
        }
        
        public override object VisitFinallyClause(AnnotatedAntlr4Parser.FinallyClauseContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitFinallyClause(context);
        }
        
        public override object VisitRulePrequel(AnnotatedAntlr4Parser.RulePrequelContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRulePrequel(context);
        }
        
        public override object VisitRuleReturns(AnnotatedAntlr4Parser.RuleReturnsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleReturns(context);
        }
        
        public override object VisitThrowsSpec(AnnotatedAntlr4Parser.ThrowsSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitThrowsSpec(context);
        }
        
        public override object VisitLocalsSpec(AnnotatedAntlr4Parser.LocalsSpecContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLocalsSpec(context);
        }
        
        public override object VisitRuleAction(AnnotatedAntlr4Parser.RuleActionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleAction(context);
        }
        
        public override object VisitRuleModifiers(AnnotatedAntlr4Parser.RuleModifiersContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleModifiers(context);
        }
        
        public override object VisitRuleModifier(AnnotatedAntlr4Parser.RuleModifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleModifier(context);
        }
        
        public override object VisitRuleBlock(AnnotatedAntlr4Parser.RuleBlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleBlock(context);
        }
        
        public override object VisitRuleAltList(AnnotatedAntlr4Parser.RuleAltListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleAltList(context);
        }
        
        public override object VisitLabeledAlt(AnnotatedAntlr4Parser.LabeledAltContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLabeledAlt(context);
        }
        
        public override object VisitPropertiesBlock(AnnotatedAntlr4Parser.PropertiesBlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPropertiesBlock(context);
        }
        
        public override object VisitLexerRule(AnnotatedAntlr4Parser.LexerRuleContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerRule(context);
        }
        
        public override object VisitLexerRuleBlock(AnnotatedAntlr4Parser.LexerRuleBlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerRuleBlock(context);
        }
        
        public override object VisitLexerAltList(AnnotatedAntlr4Parser.LexerAltListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerAltList(context);
        }
        
        public override object VisitLexerAlt(AnnotatedAntlr4Parser.LexerAltContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerAlt(context);
        }
        
        public override object VisitLexerElements(AnnotatedAntlr4Parser.LexerElementsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerElements(context);
        }
        
        public override object VisitLexerElement(AnnotatedAntlr4Parser.LexerElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerElement(context);
        }
        
        public override object VisitLabeledLexerElement(AnnotatedAntlr4Parser.LabeledLexerElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLabeledLexerElement(context);
        }
        
        public override object VisitLexerBlock(AnnotatedAntlr4Parser.LexerBlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerBlock(context);
        }
        
        public override object VisitLexerCommands(AnnotatedAntlr4Parser.LexerCommandsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerCommands(context);
        }
        
        public override object VisitLexerCommand(AnnotatedAntlr4Parser.LexerCommandContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerCommand(context);
        }
        
        public override object VisitLexerCommandName(AnnotatedAntlr4Parser.LexerCommandNameContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerCommandName(context);
        }
        
        public override object VisitLexerCommandExpr(AnnotatedAntlr4Parser.LexerCommandExprContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerCommandExpr(context);
        }
        
        public override object VisitAltList(AnnotatedAntlr4Parser.AltListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAltList(context);
        }
        
        public override object VisitAlternative(AnnotatedAntlr4Parser.AlternativeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAlternative(context);
        }
        
        public override object VisitElement(AnnotatedAntlr4Parser.ElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitElement(context);
        }
        
        public override object VisitLabeledElement(AnnotatedAntlr4Parser.LabeledElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLabeledElement(context);
        }
        
        public override object VisitEbnf(AnnotatedAntlr4Parser.EbnfContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEbnf(context);
        }
        
        public override object VisitBlockSuffix(AnnotatedAntlr4Parser.BlockSuffixContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBlockSuffix(context);
        }
        
        public override object VisitEbnfSuffix(AnnotatedAntlr4Parser.EbnfSuffixContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEbnfSuffix(context);
        }
        
        public override object VisitLexerAtom(AnnotatedAntlr4Parser.LexerAtomContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLexerAtom(context);
        }
        
        public override object VisitAtom(AnnotatedAntlr4Parser.AtomContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAtom(context);
        }
        
        public override object VisitNotSet(AnnotatedAntlr4Parser.NotSetContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNotSet(context);
        }
        
        public override object VisitBlockSet(AnnotatedAntlr4Parser.BlockSetContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBlockSet(context);
        }
        
        public override object VisitSetElement(AnnotatedAntlr4Parser.SetElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSetElement(context);
        }
        
        public override object VisitBlock(AnnotatedAntlr4Parser.BlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBlock(context);
        }
        
        public override object VisitRuleref(AnnotatedAntlr4Parser.RulerefContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuleref(context);
        }
        
        public override object VisitRange(AnnotatedAntlr4Parser.RangeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRange(context);
        }
        
        public override object VisitTerminal(AnnotatedAntlr4Parser.TerminalContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTerminal(context);
        }
        
        public override object VisitElementOptions(AnnotatedAntlr4Parser.ElementOptionsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitElementOptions(context);
        }
        
        public override object VisitElementOption(AnnotatedAntlr4Parser.ElementOptionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitElementOption(context);
        }
        
        public override object VisitId(AnnotatedAntlr4Parser.IdContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitId(context);
        }
        
        public override object VisitAnnotation(AnnotatedAntlr4Parser.AnnotationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotation(context);
        }
        
        public override object VisitAnnotationBody(AnnotatedAntlr4Parser.AnnotationBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationBody(context);
        }
        
        public override object VisitAnnotationAttributeList(AnnotatedAntlr4Parser.AnnotationAttributeListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationAttributeList(context);
        }
        
        public override object VisitAnnotationAttribute(AnnotatedAntlr4Parser.AnnotationAttributeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationAttribute(context);
        }
        
        public override object VisitExpressionList(AnnotatedAntlr4Parser.ExpressionListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionList(context);
        }
        
        public override object VisitQualifiedName(AnnotatedAntlr4Parser.QualifiedNameContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitExpression(AnnotatedAntlr4Parser.ExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpression(context);
        }
        
        public override object VisitLiteral(AnnotatedAntlr4Parser.LiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitIdentifier(AnnotatedAntlr4Parser.IdentifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitBoolLiteral(AnnotatedAntlr4Parser.BoolLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBoolLiteral(context);
        }
        
        public override object VisitNullLiteral(AnnotatedAntlr4Parser.NullLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
    }
    
    public class AnnotatedAntlr4ParserPropertyEvaluator : MetaCompilerPropertyEvaluator, IAnnotatedAntlr4ParserVisitor<object>
    {
        public AnnotatedAntlr4ParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitGrammarSpec(AnnotatedAntlr4Parser.GrammarSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitGrammarType(AnnotatedAntlr4Parser.GrammarTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPrequelConstruct(AnnotatedAntlr4Parser.PrequelConstructContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOptionsSpec(AnnotatedAntlr4Parser.OptionsSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOption(AnnotatedAntlr4Parser.OptionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOptionValue(AnnotatedAntlr4Parser.OptionValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDelegateGrammars(AnnotatedAntlr4Parser.DelegateGrammarsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDelegateGrammar(AnnotatedAntlr4Parser.DelegateGrammarContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTokensSpec(AnnotatedAntlr4Parser.TokensSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotatedId(AnnotatedAntlr4Parser.AnnotatedIdContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAction(AnnotatedAntlr4Parser.ActionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitActionScopeName(AnnotatedAntlr4Parser.ActionScopeNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitModeSpec(AnnotatedAntlr4Parser.ModeSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRules(AnnotatedAntlr4Parser.RulesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleSpec(AnnotatedAntlr4Parser.RuleSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParserRuleSpec(AnnotatedAntlr4Parser.ParserRuleSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExceptionGroup(AnnotatedAntlr4Parser.ExceptionGroupContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExceptionHandler(AnnotatedAntlr4Parser.ExceptionHandlerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFinallyClause(AnnotatedAntlr4Parser.FinallyClauseContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRulePrequel(AnnotatedAntlr4Parser.RulePrequelContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleReturns(AnnotatedAntlr4Parser.RuleReturnsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitThrowsSpec(AnnotatedAntlr4Parser.ThrowsSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLocalsSpec(AnnotatedAntlr4Parser.LocalsSpecContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleAction(AnnotatedAntlr4Parser.RuleActionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleModifiers(AnnotatedAntlr4Parser.RuleModifiersContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleModifier(AnnotatedAntlr4Parser.RuleModifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleBlock(AnnotatedAntlr4Parser.RuleBlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleAltList(AnnotatedAntlr4Parser.RuleAltListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLabeledAlt(AnnotatedAntlr4Parser.LabeledAltContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPropertiesBlock(AnnotatedAntlr4Parser.PropertiesBlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerRule(AnnotatedAntlr4Parser.LexerRuleContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerRuleBlock(AnnotatedAntlr4Parser.LexerRuleBlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerAltList(AnnotatedAntlr4Parser.LexerAltListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerAlt(AnnotatedAntlr4Parser.LexerAltContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerElements(AnnotatedAntlr4Parser.LexerElementsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerElement(AnnotatedAntlr4Parser.LexerElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLabeledLexerElement(AnnotatedAntlr4Parser.LabeledLexerElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerBlock(AnnotatedAntlr4Parser.LexerBlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerCommands(AnnotatedAntlr4Parser.LexerCommandsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerCommand(AnnotatedAntlr4Parser.LexerCommandContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerCommandName(AnnotatedAntlr4Parser.LexerCommandNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerCommandExpr(AnnotatedAntlr4Parser.LexerCommandExprContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAltList(AnnotatedAntlr4Parser.AltListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAlternative(AnnotatedAntlr4Parser.AlternativeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitElement(AnnotatedAntlr4Parser.ElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLabeledElement(AnnotatedAntlr4Parser.LabeledElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEbnf(AnnotatedAntlr4Parser.EbnfContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBlockSuffix(AnnotatedAntlr4Parser.BlockSuffixContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEbnfSuffix(AnnotatedAntlr4Parser.EbnfSuffixContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLexerAtom(AnnotatedAntlr4Parser.LexerAtomContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAtom(AnnotatedAntlr4Parser.AtomContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNotSet(AnnotatedAntlr4Parser.NotSetContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBlockSet(AnnotatedAntlr4Parser.BlockSetContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSetElement(AnnotatedAntlr4Parser.SetElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBlock(AnnotatedAntlr4Parser.BlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuleref(AnnotatedAntlr4Parser.RulerefContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRange(AnnotatedAntlr4Parser.RangeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTerminal(AnnotatedAntlr4Parser.TerminalContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitElementOptions(AnnotatedAntlr4Parser.ElementOptionsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitElementOption(AnnotatedAntlr4Parser.ElementOptionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitId(AnnotatedAntlr4Parser.IdContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotation(AnnotatedAntlr4Parser.AnnotationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationBody(AnnotatedAntlr4Parser.AnnotationBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationAttributeList(AnnotatedAntlr4Parser.AnnotationAttributeListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationAttribute(AnnotatedAntlr4Parser.AnnotationAttributeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionList(AnnotatedAntlr4Parser.ExpressionListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedName(AnnotatedAntlr4Parser.QualifiedNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpression(AnnotatedAntlr4Parser.ExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteral(AnnotatedAntlr4Parser.LiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(AnnotatedAntlr4Parser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBoolLiteral(AnnotatedAntlr4Parser.BoolLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullLiteral(AnnotatedAntlr4Parser.NullLiteralContext context)
        {
            return this.VisitChildren(context);
        }
    }
}
