using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
/*
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219

namespace MetaDslx.Languages.Calculator.Syntax.InternalSyntax
{
    public class CalculatorParserAnnotator : CalculatorParserBaseVisitor<object>
    {
        private CalculatorLexerAnnotator lexerAnnotator = new CalculatorLexerAnnotator();
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<Type, List<object>> ruleAnnotations = new Dictionary<Type, List<object>>();
        private Dictionary<object, List<object>> treeAnnotations = new Dictionary<object, List<object>>();
        
        public List<object> ParserAnnotations { get { return this.grammarAnnotations; } }
        public List<object> LexerAnnotations { get { return this.lexerAnnotator.LexerAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.lexerAnnotator.TokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.lexerAnnotator.ModeAnnotations; } }
        public Dictionary<Type, List<object>> RuleAnnotations { get { return this.ruleAnnotations; } }
        public Dictionary<object, List<object>> TreeAnnotations { get { return this.treeAnnotations; } }
        
        
        private MetaDslx.Compiler.IModelCompiler compiler;
        
        public CalculatorParserAnnotator(MetaDslx.Compiler.IModelCompiler compiler)
        {
            this.compiler = compiler;
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
                            string name = this.compiler.NameProvider.GetName(node);
                            if (sta.Name == name)
                            {
                                this.OverrideSymbolType(node, sta.SymbolType);
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
                        SymbolBasedAnnotation sta = treeAnnot as SymbolBasedAnnotation;
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
        
        public override object VisitMain(CalculatorParser.MainContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMain(context);
        }
        
        public override object VisitStatementLine(CalculatorParser.StatementLineContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStatementLine(context);
        }
        
        public override object VisitStatement(CalculatorParser.StatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStatement(context);
        }
        
        public override object VisitAssignment(CalculatorParser.AssignmentContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAssignment(context);
        }
        
        public override object VisitParenExpression(CalculatorParser.ParenExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParenExpression(context);
        }
        
        public override object VisitMulOrDivExpression(CalculatorParser.MulOrDivExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMulOrDivExpression(context);
        }
        
        public override object VisitAddOrSubExpression(CalculatorParser.AddOrSubExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAddOrSubExpression(context);
        }
        
        public override object VisitPrintExpression(CalculatorParser.PrintExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPrintExpression(context);
        }
        
        public override object VisitValueExpression(CalculatorParser.ValueExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitValueExpression(context);
        }
        
        public override object VisitArgs(CalculatorParser.ArgsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitArgs(context);
        }
        
        public override object VisitValue(CalculatorParser.ValueContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitValue(context);
        }
        
        public override object VisitIdentifier(CalculatorParser.IdentifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitString(CalculatorParser.StringContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitString(context);
        }
        
        public override object VisitInteger(CalculatorParser.IntegerContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitInteger(context);
        }
        
        public override object VisitArg(CalculatorParser.ArgContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitArg(context);
        }
    }
    
    public class CalculatorParserPropertyEvaluator : MetaCompilerPropertyEvaluator, ICalculatorParserVisitor<object>
    {
        public CalculatorParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitMain(CalculatorParser.MainContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStatementLine(CalculatorParser.StatementLineContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStatement(CalculatorParser.StatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssignment(CalculatorParser.AssignmentContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParenExpression(CalculatorParser.ParenExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMulOrDivExpression(CalculatorParser.MulOrDivExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAddOrSubExpression(CalculatorParser.AddOrSubExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPrintExpression(CalculatorParser.PrintExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitValueExpression(CalculatorParser.ValueExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitArgs(CalculatorParser.ArgsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitValue(CalculatorParser.ValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(CalculatorParser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitString(CalculatorParser.StringContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitInteger(CalculatorParser.IntegerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitArg(CalculatorParser.ArgContext context)
        {
            return this.VisitChildren(context);
        }
    }
    public class CalculatorCompiler : MetaCompiler
    {
        public CalculatorCompiler(string source, string fileName)
            : base(source, fileName)
        {
        }
        
        protected override void DoCompile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new CalculatorLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new CalculatorParser(this.CommonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.main();
            if (!this.Diagnostics.HasErrors())
            {
                CalculatorParserAnnotator annotator = new CalculatorParserAnnotator(this);
                annotator.Visit(this.ParseTree);
                this.LexerAnnotations = annotator.LexerAnnotations;
                this.ParserAnnotations = annotator.ParserAnnotations;
                this.ModeAnnotations = annotator.ModeAnnotations;
                this.TokenAnnotations = annotator.TokenAnnotations;
                this.RuleAnnotations = annotator.RuleAnnotations;
                this.TreeAnnotations = annotator.TreeAnnotations;
                MetaCompilerDefinitionPhase definitionPhase = new MetaCompilerDefinitionPhase(this);
                definitionPhase.VisitNode(this.ParseTree);
                MetaCompilerMergePhase mergePhase = new MetaCompilerMergePhase(this);
                mergePhase.VisitNode(this.ParseTree);
                MetaCompilerReferencePhase referencePhase = new MetaCompilerReferencePhase(this);
                referencePhase.VisitNode(this.ParseTree);
                CalculatorParserPropertyEvaluator propertyEvaluator = new CalculatorParserPropertyEvaluator(this);
                propertyEvaluator.Visit(this.ParseTree);
                
                this.Model.EvaluateLazyValues();
            }
        }
        
        public CalculatorParser.MainContext ParseTree { get; private set; }
        public CalculatorLexer Lexer { get; private set; }
        public CalculatorParser Parser { get; private set; }
    }
}
*/