using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

// The variable '...' is assigned but its value is never used
#pragma warning disable 0219

namespace MetaDslx.Compiler
{
    public class AnnotatedAntlr4PropertiesParserAnnotator : AnnotatedAntlr4PropertiesParserBaseVisitor<object>
    {
        private AnnotatedAntlr4PropertiesLexerAnnotator lexerAnnotator = new AnnotatedAntlr4PropertiesLexerAnnotator();
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
        
        public AnnotatedAntlr4PropertiesParserAnnotator(MetaDslx.Compiler.IModelCompiler compiler)
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
        
        public override object VisitPropertiesBlock(AnnotatedAntlr4PropertiesParser.PropertiesBlockContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPropertiesBlock(context);
        }
        
        public override object VisitPropertyAssignment(AnnotatedAntlr4PropertiesParser.PropertyAssignmentContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPropertyAssignment(context);
        }
        
        public override object VisitQualifiedProperty(AnnotatedAntlr4PropertiesParser.QualifiedPropertyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifiedProperty(context);
        }
        
        public override object VisitPropertySelector(AnnotatedAntlr4PropertiesParser.PropertySelectorContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPropertySelector(context);
        }
        
        public override object VisitExpressionList(AnnotatedAntlr4PropertiesParser.ExpressionListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionList(context);
        }
        
        public override object VisitExpression(AnnotatedAntlr4PropertiesParser.ExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpression(context);
        }
        
        public override object VisitFunctionCall(AnnotatedAntlr4PropertiesParser.FunctionCallContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitFunctionCall(context);
        }
        
        public override object VisitLiteral(AnnotatedAntlr4PropertiesParser.LiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitIdentifier(AnnotatedAntlr4PropertiesParser.IdentifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitBooleanLiteral(AnnotatedAntlr4PropertiesParser.BooleanLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitNullLiteral(AnnotatedAntlr4PropertiesParser.NullLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
    }
    
    public class AnnotatedAntlr4PropertiesParserPropertyEvaluator : MetaCompilerPropertyEvaluator, IAnnotatedAntlr4PropertiesParserVisitor<object>
    {
        public AnnotatedAntlr4PropertiesParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitPropertiesBlock(AnnotatedAntlr4PropertiesParser.PropertiesBlockContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPropertyAssignment(AnnotatedAntlr4PropertiesParser.PropertyAssignmentContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedProperty(AnnotatedAntlr4PropertiesParser.QualifiedPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPropertySelector(AnnotatedAntlr4PropertiesParser.PropertySelectorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionList(AnnotatedAntlr4PropertiesParser.ExpressionListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpression(AnnotatedAntlr4PropertiesParser.ExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionCall(AnnotatedAntlr4PropertiesParser.FunctionCallContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteral(AnnotatedAntlr4PropertiesParser.LiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(AnnotatedAntlr4PropertiesParser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBooleanLiteral(AnnotatedAntlr4PropertiesParser.BooleanLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullLiteral(AnnotatedAntlr4PropertiesParser.NullLiteralContext context)
        {
            return this.VisitChildren(context);
        }
    }
}
