using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    public class MetaGeneratorParserAnnotator : MetaGeneratorParserBaseVisitor<object>
    {
        private MetaGeneratorLexerAnnotator lexerAnnotator = new MetaGeneratorLexerAnnotator();
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<Type, List<object>> ruleAnnotations = new Dictionary<Type, List<object>>();
        private Dictionary<object, List<object>> treeAnnotations = new Dictionary<object, List<object>>();
        
        public List<object> ParserAnnotations { get { return this.grammarAnnotations; } }
        public List<object> LexerAnnotations { get { return this.lexerAnnotator.LexerAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.lexerAnnotator.TokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.lexerAnnotator.ModeAnnotations; } }
        public Dictionary<Type, List<object>> RuleAnnotations { get { return this.ruleAnnotations; } }
        public Dictionary<object, List<object>> TreeAnnotations { get { return this.treeAnnotations; } }
        
        
        public MetaGeneratorParserAnnotator()
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
        
        public override object VisitMain(MetaGeneratorParser.MainContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMain(context);
        }
        
        public override object VisitNamespaceDeclaration(MetaGeneratorParser.NamespaceDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNamespaceDeclaration(context);
        }
        
        public override object VisitGeneratorDeclaration(MetaGeneratorParser.GeneratorDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGeneratorDeclaration(context);
        }
        
        public override object VisitUsingNamespaceDeclaration(MetaGeneratorParser.UsingNamespaceDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitUsingNamespaceDeclaration(context);
        }
        
        public override object VisitUsingGeneratorDeclaration(MetaGeneratorParser.UsingGeneratorDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitUsingGeneratorDeclaration(context);
        }
        
        public override object VisitConfigDeclaration(MetaGeneratorParser.ConfigDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitConfigDeclaration(context);
        }
        
        public override object VisitConfigPropertyDeclaration(MetaGeneratorParser.ConfigPropertyDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitConfigPropertyDeclaration(context);
        }
        
        public override object VisitConfigPropertyGroupDeclaration(MetaGeneratorParser.ConfigPropertyGroupDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitConfigPropertyGroupDeclaration(context);
        }
        
        public override object VisitMethodDeclaration(MetaGeneratorParser.MethodDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMethodDeclaration(context);
        }
        
        public override object VisitFunctionDeclaration(MetaGeneratorParser.FunctionDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitFunctionDeclaration(context);
        }
        
        public override object VisitFunctionSignature(MetaGeneratorParser.FunctionSignatureContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitFunctionSignature(context);
        }
        
        public override object VisitParamList(MetaGeneratorParser.ParamListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParamList(context);
        }
        
        public override object VisitParameter(MetaGeneratorParser.ParameterContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParameter(context);
        }
        
        public override object VisitBody(MetaGeneratorParser.BodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBody(context);
        }
        
        public override object VisitStatement(MetaGeneratorParser.StatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStatement(context);
        }
        
        public override object VisitVariableDeclarationStatement(MetaGeneratorParser.VariableDeclarationStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitVariableDeclarationStatement(context);
        }
        
        public override object VisitReturnStatement(MetaGeneratorParser.ReturnStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitReturnStatement(context);
        }
        
        public override object VisitExpressionStatement(MetaGeneratorParser.ExpressionStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionStatement(context);
        }
        
        public override object VisitIfStatement(MetaGeneratorParser.IfStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIfStatement(context);
        }
        
        public override object VisitIfStatementBegin(MetaGeneratorParser.IfStatementBeginContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIfStatementBegin(context);
        }
        
        public override object VisitElseIfStatement(MetaGeneratorParser.ElseIfStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitElseIfStatement(context);
        }
        
        public override object VisitIfStatementElse(MetaGeneratorParser.IfStatementElseContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIfStatementElse(context);
        }
        
        public override object VisitIfStatementEnd(MetaGeneratorParser.IfStatementEndContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIfStatementEnd(context);
        }
        
        public override object VisitLoopStatement(MetaGeneratorParser.LoopStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopStatement(context);
        }
        
        public override object VisitLoopStatementBegin(MetaGeneratorParser.LoopStatementBeginContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopStatementBegin(context);
        }
        
        public override object VisitLoopStatementEnd(MetaGeneratorParser.LoopStatementEndContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopStatementEnd(context);
        }
        
        public override object VisitLoopChain(MetaGeneratorParser.LoopChainContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChain(context);
        }
        
        public override object VisitLoopChainItem(MetaGeneratorParser.LoopChainItemContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChainItem(context);
        }
        
        public override object VisitLoopChainTypeofExpression(MetaGeneratorParser.LoopChainTypeofExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChainTypeofExpression(context);
        }
        
        public override object VisitLoopChainIdentifierExpression(MetaGeneratorParser.LoopChainIdentifierExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChainIdentifierExpression(context);
        }
        
        public override object VisitLoopChainMemberAccessExpression(MetaGeneratorParser.LoopChainMemberAccessExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChainMemberAccessExpression(context);
        }
        
        public override object VisitLoopChainMethodCallExpression(MetaGeneratorParser.LoopChainMethodCallExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopChainMethodCallExpression(context);
        }
        
        public override object VisitLoopWhereExpression(MetaGeneratorParser.LoopWhereExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopWhereExpression(context);
        }
        
        public override object VisitLoopRunExpression(MetaGeneratorParser.LoopRunExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopRunExpression(context);
        }
        
        public override object VisitLoopRunList(MetaGeneratorParser.LoopRunListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopRunList(context);
        }
        
        public override object VisitLoopRun(MetaGeneratorParser.LoopRunContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLoopRun(context);
        }
        
        public override object VisitSwitchStatement(MetaGeneratorParser.SwitchStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchStatement(context);
        }
        
        public override object VisitSwitchStatementBegin(MetaGeneratorParser.SwitchStatementBeginContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchStatementBegin(context);
        }
        
        public override object VisitSwitchStatementEnd(MetaGeneratorParser.SwitchStatementEndContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchStatementEnd(context);
        }
        
        public override object VisitSwitchBranchStatement(MetaGeneratorParser.SwitchBranchStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchBranchStatement(context);
        }
        
        public override object VisitSwitchBranchHeadStatement(MetaGeneratorParser.SwitchBranchHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchBranchHeadStatement(context);
        }
        
        public override object VisitSwitchCaseOrTypeIsHeadStatement(MetaGeneratorParser.SwitchCaseOrTypeIsHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchCaseOrTypeIsHeadStatement(context);
        }
        
        public override object VisitSwitchCaseHeadStatement(MetaGeneratorParser.SwitchCaseHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchCaseHeadStatement(context);
        }
        
        public override object VisitSwitchTypeIsHeadStatement(MetaGeneratorParser.SwitchTypeIsHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchTypeIsHeadStatement(context);
        }
        
        public override object VisitSwitchTypeAsHeadStatement(MetaGeneratorParser.SwitchTypeAsHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchTypeAsHeadStatement(context);
        }
        
        public override object VisitSwitchDefaultStatement(MetaGeneratorParser.SwitchDefaultStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchDefaultStatement(context);
        }
        
        public override object VisitSwitchDefaultHeadStatement(MetaGeneratorParser.SwitchDefaultHeadStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSwitchDefaultHeadStatement(context);
        }
        
        public override object VisitTemplateDeclaration(MetaGeneratorParser.TemplateDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateDeclaration(context);
        }
        
        public override object VisitTemplateSignature(MetaGeneratorParser.TemplateSignatureContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateSignature(context);
        }
        
        public override object VisitTemplateBody(MetaGeneratorParser.TemplateBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateBody(context);
        }
        
        public override object VisitTemplateContentLine(MetaGeneratorParser.TemplateContentLineContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateContentLine(context);
        }
        
        public override object VisitTemplateOutput(MetaGeneratorParser.TemplateOutputContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateOutput(context);
        }
        
        public override object VisitTemplateLineEnd(MetaGeneratorParser.TemplateLineEndContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateLineEnd(context);
        }
        
        public override object VisitTemplateStatementStartEnd(MetaGeneratorParser.TemplateStatementStartEndContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateStatementStartEnd(context);
        }
        
        public override object VisitTemplateStatement(MetaGeneratorParser.TemplateStatementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTemplateStatement(context);
        }
        
        public override object VisitTypeArgumentList(MetaGeneratorParser.TypeArgumentListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeArgumentList(context);
        }
        
        public override object VisitPredefinedType(MetaGeneratorParser.PredefinedTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPredefinedType(context);
        }
        
        public override object VisitTypeReferenceList(MetaGeneratorParser.TypeReferenceListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeReferenceList(context);
        }
        
        public override object VisitTypeReference(MetaGeneratorParser.TypeReferenceContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeReference(context);
        }
        
        public override object VisitArrayType(MetaGeneratorParser.ArrayTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitArrayType(context);
        }
        
        public override object VisitNullableType(MetaGeneratorParser.NullableTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullableType(context);
        }
        
        public override object VisitGenericType(MetaGeneratorParser.GenericTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGenericType(context);
        }
        
        public override object VisitSimpleType(MetaGeneratorParser.SimpleTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSimpleType(context);
        }
        
        public override object VisitVoidType(MetaGeneratorParser.VoidTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitVoidType(context);
        }
        
        public override object VisitReturnType(MetaGeneratorParser.ReturnTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitReturnType(context);
        }
        
        public override object VisitExpressionList(MetaGeneratorParser.ExpressionListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionList(context);
        }
        
        public override object VisitVariableReference(MetaGeneratorParser.VariableReferenceContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitVariableReference(context);
        }
        
        public override object VisitRankSpecifiers(MetaGeneratorParser.RankSpecifiersContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRankSpecifiers(context);
        }
        
        public override object VisitRankSpecifier(MetaGeneratorParser.RankSpecifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRankSpecifier(context);
        }
        
        public override object VisitUnboundTypeName(MetaGeneratorParser.UnboundTypeNameContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitUnboundTypeName(context);
        }
        
        public override object VisitGenericDimensionSpecifier(MetaGeneratorParser.GenericDimensionSpecifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGenericDimensionSpecifier(context);
        }
        
        public override object VisitExplicitAnonymousFunctionSignature(MetaGeneratorParser.ExplicitAnonymousFunctionSignatureContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExplicitAnonymousFunctionSignature(context);
        }
        
        public override object VisitImplicitAnonymousFunctionSignature(MetaGeneratorParser.ImplicitAnonymousFunctionSignatureContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitImplicitAnonymousFunctionSignature(context);
        }
        
        public override object VisitSingleParamAnonymousFunctionSignature(MetaGeneratorParser.SingleParamAnonymousFunctionSignatureContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSingleParamAnonymousFunctionSignature(context);
        }
        
        public override object VisitExplicitParameter(MetaGeneratorParser.ExplicitParameterContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExplicitParameter(context);
        }
        
        public override object VisitImplicitParameter(MetaGeneratorParser.ImplicitParameterContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitImplicitParameter(context);
        }
        
        public override object VisitThisExpression(MetaGeneratorParser.ThisExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitThisExpression(context);
        }
        
        public override object VisitLiteralExpression(MetaGeneratorParser.LiteralExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLiteralExpression(context);
        }
        
        public override object VisitTypeofVoidExpression(MetaGeneratorParser.TypeofVoidExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeofVoidExpression(context);
        }
        
        public override object VisitTypeofUnboundTypeExpression(MetaGeneratorParser.TypeofUnboundTypeExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeofUnboundTypeExpression(context);
        }
        
        public override object VisitTypeofTypeExpression(MetaGeneratorParser.TypeofTypeExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeofTypeExpression(context);
        }
        
        public override object VisitDefaultValueExpression(MetaGeneratorParser.DefaultValueExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDefaultValueExpression(context);
        }
        
        public override object VisitNewObjectOrCollectionWithConstructorExpression(MetaGeneratorParser.NewObjectOrCollectionWithConstructorExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNewObjectOrCollectionWithConstructorExpression(context);
        }
        
        public override object VisitIdentifierExpression(MetaGeneratorParser.IdentifierExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifierExpression(context);
        }
        
        public override object VisitHasLoopExpression(MetaGeneratorParser.HasLoopExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitHasLoopExpression(context);
        }
        
        public override object VisitParenthesizedExpression(MetaGeneratorParser.ParenthesizedExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParenthesizedExpression(context);
        }
        
        public override object VisitElementAccessExpression(MetaGeneratorParser.ElementAccessExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitElementAccessExpression(context);
        }
        
        public override object VisitFunctionCallExpression(MetaGeneratorParser.FunctionCallExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitFunctionCallExpression(context);
        }
        
        public override object VisitPredefinedTypeMemberAccessExpression(MetaGeneratorParser.PredefinedTypeMemberAccessExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPredefinedTypeMemberAccessExpression(context);
        }
        
        public override object VisitMemberAccessExpression(MetaGeneratorParser.MemberAccessExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMemberAccessExpression(context);
        }
        
        public override object VisitTypecastExpression(MetaGeneratorParser.TypecastExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypecastExpression(context);
        }
        
        public override object VisitUnaryExpression(MetaGeneratorParser.UnaryExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitUnaryExpression(context);
        }
        
        public override object VisitPostExpression(MetaGeneratorParser.PostExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitPostExpression(context);
        }
        
        public override object VisitMultiplicationExpression(MetaGeneratorParser.MultiplicationExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMultiplicationExpression(context);
        }
        
        public override object VisitAdditionExpression(MetaGeneratorParser.AdditionExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAdditionExpression(context);
        }
        
        public override object VisitRelationalExpression(MetaGeneratorParser.RelationalExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRelationalExpression(context);
        }
        
        public override object VisitTypecheckExpression(MetaGeneratorParser.TypecheckExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypecheckExpression(context);
        }
        
        public override object VisitEqualityExpression(MetaGeneratorParser.EqualityExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEqualityExpression(context);
        }
        
        public override object VisitBitwiseAndExpression(MetaGeneratorParser.BitwiseAndExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBitwiseAndExpression(context);
        }
        
        public override object VisitBitwiseXorExpression(MetaGeneratorParser.BitwiseXorExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBitwiseXorExpression(context);
        }
        
        public override object VisitBitwiseOrExpression(MetaGeneratorParser.BitwiseOrExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBitwiseOrExpression(context);
        }
        
        public override object VisitLogicalAndExpression(MetaGeneratorParser.LogicalAndExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLogicalAndExpression(context);
        }
        
        public override object VisitLogicalXorExpression(MetaGeneratorParser.LogicalXorExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLogicalXorExpression(context);
        }
        
        public override object VisitLogicalOrExpression(MetaGeneratorParser.LogicalOrExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLogicalOrExpression(context);
        }
        
        public override object VisitConditionalExpression(MetaGeneratorParser.ConditionalExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitConditionalExpression(context);
        }
        
        public override object VisitAssignmentExpression(MetaGeneratorParser.AssignmentExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAssignmentExpression(context);
        }
        
        public override object VisitLambdaExpression(MetaGeneratorParser.LambdaExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLambdaExpression(context);
        }
        
        public override object VisitQualifiedName(MetaGeneratorParser.QualifiedNameContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitIdentifierList(MetaGeneratorParser.IdentifierListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitIdentifier(MetaGeneratorParser.IdentifierContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitLiteral(MetaGeneratorParser.LiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(MetaGeneratorParser.NullLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(MetaGeneratorParser.BooleanLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitNumberLiteral(MetaGeneratorParser.NumberLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNumberLiteral(context);
        }
        
        public override object VisitIntegerLiteral(MetaGeneratorParser.IntegerLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(MetaGeneratorParser.DecimalLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(MetaGeneratorParser.ScientificLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitDateOrTimeLiteral(MetaGeneratorParser.DateOrTimeLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDateOrTimeLiteral(context);
        }
        
        public override object VisitDateTimeOffsetLiteral(MetaGeneratorParser.DateTimeOffsetLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDateTimeOffsetLiteral(context);
        }
        
        public override object VisitDateTimeLiteral(MetaGeneratorParser.DateTimeLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDateTimeLiteral(context);
        }
        
        public override object VisitDateLiteral(MetaGeneratorParser.DateLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDateLiteral(context);
        }
        
        public override object VisitTimeLiteral(MetaGeneratorParser.TimeLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTimeLiteral(context);
        }
        
        public override object VisitCharLiteral(MetaGeneratorParser.CharLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitCharLiteral(context);
        }
        
        public override object VisitStringLiteral(MetaGeneratorParser.StringLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStringLiteral(context);
        }
        
        public override object VisitGuidLiteral(MetaGeneratorParser.GuidLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitGuidLiteral(context);
        }
    }
    
    public class MetaGeneratorParserPropertyEvaluator : MetaCompilerPropertyEvaluator, IMetaGeneratorParserVisitor<object>
    {
        public MetaGeneratorParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitMain(MetaGeneratorParser.MainContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNamespaceDeclaration(MetaGeneratorParser.NamespaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitGeneratorDeclaration(MetaGeneratorParser.GeneratorDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUsingNamespaceDeclaration(MetaGeneratorParser.UsingNamespaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUsingGeneratorDeclaration(MetaGeneratorParser.UsingGeneratorDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConfigDeclaration(MetaGeneratorParser.ConfigDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConfigPropertyDeclaration(MetaGeneratorParser.ConfigPropertyDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConfigPropertyGroupDeclaration(MetaGeneratorParser.ConfigPropertyGroupDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMethodDeclaration(MetaGeneratorParser.MethodDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionDeclaration(MetaGeneratorParser.FunctionDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionSignature(MetaGeneratorParser.FunctionSignatureContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParamList(MetaGeneratorParser.ParamListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParameter(MetaGeneratorParser.ParameterContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBody(MetaGeneratorParser.BodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStatement(MetaGeneratorParser.StatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitVariableDeclarationStatement(MetaGeneratorParser.VariableDeclarationStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnStatement(MetaGeneratorParser.ReturnStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionStatement(MetaGeneratorParser.ExpressionStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIfStatement(MetaGeneratorParser.IfStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIfStatementBegin(MetaGeneratorParser.IfStatementBeginContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitElseIfStatement(MetaGeneratorParser.ElseIfStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIfStatementElse(MetaGeneratorParser.IfStatementElseContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIfStatementEnd(MetaGeneratorParser.IfStatementEndContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopStatement(MetaGeneratorParser.LoopStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopStatementBegin(MetaGeneratorParser.LoopStatementBeginContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopStatementEnd(MetaGeneratorParser.LoopStatementEndContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChain(MetaGeneratorParser.LoopChainContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChainItem(MetaGeneratorParser.LoopChainItemContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChainTypeofExpression(MetaGeneratorParser.LoopChainTypeofExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChainIdentifierExpression(MetaGeneratorParser.LoopChainIdentifierExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChainMemberAccessExpression(MetaGeneratorParser.LoopChainMemberAccessExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopChainMethodCallExpression(MetaGeneratorParser.LoopChainMethodCallExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopWhereExpression(MetaGeneratorParser.LoopWhereExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopRunExpression(MetaGeneratorParser.LoopRunExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopRunList(MetaGeneratorParser.LoopRunListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLoopRun(MetaGeneratorParser.LoopRunContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchStatement(MetaGeneratorParser.SwitchStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchStatementBegin(MetaGeneratorParser.SwitchStatementBeginContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchStatementEnd(MetaGeneratorParser.SwitchStatementEndContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchBranchStatement(MetaGeneratorParser.SwitchBranchStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchBranchHeadStatement(MetaGeneratorParser.SwitchBranchHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchCaseOrTypeIsHeadStatement(MetaGeneratorParser.SwitchCaseOrTypeIsHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchCaseHeadStatement(MetaGeneratorParser.SwitchCaseHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchTypeIsHeadStatement(MetaGeneratorParser.SwitchTypeIsHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchTypeAsHeadStatement(MetaGeneratorParser.SwitchTypeAsHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchDefaultStatement(MetaGeneratorParser.SwitchDefaultStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSwitchDefaultHeadStatement(MetaGeneratorParser.SwitchDefaultHeadStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateDeclaration(MetaGeneratorParser.TemplateDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateSignature(MetaGeneratorParser.TemplateSignatureContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateBody(MetaGeneratorParser.TemplateBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateContentLine(MetaGeneratorParser.TemplateContentLineContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateOutput(MetaGeneratorParser.TemplateOutputContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateLineEnd(MetaGeneratorParser.TemplateLineEndContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateStatementStartEnd(MetaGeneratorParser.TemplateStatementStartEndContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTemplateStatement(MetaGeneratorParser.TemplateStatementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeArgumentList(MetaGeneratorParser.TypeArgumentListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPredefinedType(MetaGeneratorParser.PredefinedTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeReferenceList(MetaGeneratorParser.TypeReferenceListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeReference(MetaGeneratorParser.TypeReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitArrayType(MetaGeneratorParser.ArrayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullableType(MetaGeneratorParser.NullableTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitGenericType(MetaGeneratorParser.GenericTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSimpleType(MetaGeneratorParser.SimpleTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitVoidType(MetaGeneratorParser.VoidTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnType(MetaGeneratorParser.ReturnTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionList(MetaGeneratorParser.ExpressionListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitVariableReference(MetaGeneratorParser.VariableReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRankSpecifiers(MetaGeneratorParser.RankSpecifiersContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRankSpecifier(MetaGeneratorParser.RankSpecifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUnboundTypeName(MetaGeneratorParser.UnboundTypeNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitGenericDimensionSpecifier(MetaGeneratorParser.GenericDimensionSpecifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExplicitAnonymousFunctionSignature(MetaGeneratorParser.ExplicitAnonymousFunctionSignatureContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitImplicitAnonymousFunctionSignature(MetaGeneratorParser.ImplicitAnonymousFunctionSignatureContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSingleParamAnonymousFunctionSignature(MetaGeneratorParser.SingleParamAnonymousFunctionSignatureContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExplicitParameter(MetaGeneratorParser.ExplicitParameterContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitImplicitParameter(MetaGeneratorParser.ImplicitParameterContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitThisExpression(MetaGeneratorParser.ThisExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteralExpression(MetaGeneratorParser.LiteralExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofVoidExpression(MetaGeneratorParser.TypeofVoidExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofUnboundTypeExpression(MetaGeneratorParser.TypeofUnboundTypeExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofTypeExpression(MetaGeneratorParser.TypeofTypeExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDefaultValueExpression(MetaGeneratorParser.DefaultValueExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNewObjectOrCollectionWithConstructorExpression(MetaGeneratorParser.NewObjectOrCollectionWithConstructorExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierExpression(MetaGeneratorParser.IdentifierExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHasLoopExpression(MetaGeneratorParser.HasLoopExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParenthesizedExpression(MetaGeneratorParser.ParenthesizedExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitElementAccessExpression(MetaGeneratorParser.ElementAccessExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionCallExpression(MetaGeneratorParser.FunctionCallExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPredefinedTypeMemberAccessExpression(MetaGeneratorParser.PredefinedTypeMemberAccessExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMemberAccessExpression(MetaGeneratorParser.MemberAccessExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypecastExpression(MetaGeneratorParser.TypecastExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUnaryExpression(MetaGeneratorParser.UnaryExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPostExpression(MetaGeneratorParser.PostExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMultiplicationExpression(MetaGeneratorParser.MultiplicationExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAdditionExpression(MetaGeneratorParser.AdditionExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRelationalExpression(MetaGeneratorParser.RelationalExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypecheckExpression(MetaGeneratorParser.TypecheckExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEqualityExpression(MetaGeneratorParser.EqualityExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseAndExpression(MetaGeneratorParser.BitwiseAndExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseXorExpression(MetaGeneratorParser.BitwiseXorExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseOrExpression(MetaGeneratorParser.BitwiseOrExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalAndExpression(MetaGeneratorParser.LogicalAndExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalXorExpression(MetaGeneratorParser.LogicalXorExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalOrExpression(MetaGeneratorParser.LogicalOrExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConditionalExpression(MetaGeneratorParser.ConditionalExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssignmentExpression(MetaGeneratorParser.AssignmentExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLambdaExpression(MetaGeneratorParser.LambdaExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedName(MetaGeneratorParser.QualifiedNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierList(MetaGeneratorParser.IdentifierListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(MetaGeneratorParser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteral(MetaGeneratorParser.LiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullLiteral(MetaGeneratorParser.NullLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBooleanLiteral(MetaGeneratorParser.BooleanLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNumberLiteral(MetaGeneratorParser.NumberLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIntegerLiteral(MetaGeneratorParser.IntegerLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDecimalLiteral(MetaGeneratorParser.DecimalLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitScientificLiteral(MetaGeneratorParser.ScientificLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDateOrTimeLiteral(MetaGeneratorParser.DateOrTimeLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDateTimeOffsetLiteral(MetaGeneratorParser.DateTimeOffsetLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDateTimeLiteral(MetaGeneratorParser.DateTimeLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDateLiteral(MetaGeneratorParser.DateLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTimeLiteral(MetaGeneratorParser.TimeLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCharLiteral(MetaGeneratorParser.CharLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStringLiteral(MetaGeneratorParser.StringLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitGuidLiteral(MetaGeneratorParser.GuidLiteralContext context)
        {
            return this.VisitChildren(context);
        }
    }
}

