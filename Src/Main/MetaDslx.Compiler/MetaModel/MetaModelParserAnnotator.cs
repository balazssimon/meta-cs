using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    
using MetaDslx.Core;

    internal class MetaModelParserAnnotator : MetaModelParserBaseVisitor<object>
    {
        private MetaModelLexerAnnotator lexerAnnotator = new MetaModelLexerAnnotator();
        private List<object> grammarAnnotations = new List<object>();
        private Dictionary<Type, List<object>> ruleAnnotations = new Dictionary<Type, List<object>>();
        private Dictionary<object, List<object>> treeAnnotations = new Dictionary<object, List<object>>();
        
        public List<object> ParserAnnotations { get { return this.grammarAnnotations; } }
        public List<object> LexerAnnotations { get { return this.lexerAnnotator.LexerAnnotations; } }
        public Dictionary<int, List<object>> TokenAnnotations { get { return this.lexerAnnotator.TokenAnnotations; } }
        public Dictionary<int, List<object>> ModeAnnotations { get { return this.lexerAnnotator.ModeAnnotations; } }
        public Dictionary<Type, List<object>> RuleAnnotations { get { return this.ruleAnnotations; } }
        public Dictionary<object, List<object>> TreeAnnotations { get { return this.treeAnnotations; } }
        
        private QualifiedNameAnnotation qualifiedName_QualifiedName;
        private InheritScopeAnnotation classDeclaration_ClassAncestors_InheritScope;
        private NameAnnotation objectType_Name;
        private NameAnnotation primitiveType_Name;
        private NameAnnotation voidType_Name;
        private PreDefSymbolAnnotation invisibleType_KAny_PreDefSymbol;
        private PreDefSymbolAnnotation invisibleType_KNone_PreDefSymbol;
        private PreDefSymbolAnnotation invisibleType_KError_PreDefSymbol;
        private ExpressionAnnotation expression_Expression;
        private SymbolTypeAnnotation castExpression_SymbolType;
        private SymbolTypeAnnotation typeofExpression_SymbolType;
        private SymbolTypeAnnotation bracketExpression_SymbolType;
        private SymbolTypeAnnotation thisExpression_SymbolType;
        private SymbolTypeAnnotation constantExpression_SymbolType;
        private SymbolTypeAnnotation identifierExpression_SymbolType;
        private SymbolTypeAnnotation indexerExpression_SymbolType;
        private SymbolTypeAnnotation functionCallExpression_SymbolType;
        private SymbolTypeAnnotation memberAccessExpression_SymbolType;
        private SymbolTypeAnnotation typeConversionExpression_SymbolType;
        private SymbolTypeAnnotation typeCheckExpression_SymbolType;
        private SymbolTypeAnnotation bitwiseAndExpression_SymbolType;
        private SymbolTypeAnnotation bitwiseXorExpression_SymbolType;
        private SymbolTypeAnnotation bitwiseOrExpression_SymbolType;
        private SymbolTypeAnnotation logicalAndExpression_SymbolType;
        private SymbolTypeAnnotation logicalOrExpression_SymbolType;
        private SymbolTypeAnnotation nullCoalescingExpression_SymbolType;
        private SymbolTypeAnnotation conditionalExpression_SymbolType;
        private ExpressionAnnotation newExpression_Expression;
        private SymbolTypeAnnotation newObjectExpression_SymbolType;
        private SymbolTypeAnnotation newCollectionExpression_SymbolType;
        private SymbolTypeAnnotation postOperator_TPlusPlus_SymbolType;
        private SymbolTypeAnnotation postOperator_TMinusMinus_SymbolType;
        private SymbolTypeAnnotation preOperator_TPlusPlus_SymbolType;
        private SymbolTypeAnnotation preOperator_TMinusMinus_SymbolType;
        private SymbolTypeAnnotation unaryOperator_TPlus_SymbolType;
        private SymbolTypeAnnotation unaryOperator_TMinus_SymbolType;
        private SymbolTypeAnnotation unaryOperator_TTilde_SymbolType;
        private SymbolTypeAnnotation unaryOperator_TExclamation_SymbolType;
        private SymbolTypeAnnotation multiplicativeOperator_TAsterisk_SymbolType;
        private SymbolTypeAnnotation multiplicativeOperator_TSlash_SymbolType;
        private SymbolTypeAnnotation multiplicativeOperator_TPercent_SymbolType;
        private SymbolTypeAnnotation additiveOperator_TPlus_SymbolType;
        private SymbolTypeAnnotation additiveOperator_TMinus_SymbolType;
        private SymbolTypeAnnotation shiftOperator_TLessThan_SymbolType;
        private SymbolTypeAnnotation shiftOperator_TGreaterThan_SymbolType;
        private SymbolTypeAnnotation comparisonOperator_TLessThan_SymbolType;
        private SymbolTypeAnnotation comparisonOperator_TGreaterThan_SymbolType;
        private SymbolTypeAnnotation comparisonOperator_TLessThanOrEqual_SymbolType;
        private SymbolTypeAnnotation comparisonOperator_TGreaterThanOrEqual_SymbolType;
        private SymbolTypeAnnotation equalityOperator_TEqual_SymbolType;
        private SymbolTypeAnnotation equalityOperator_TNotEqual_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TAsteriskAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TSlashAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TPercentAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TPlusAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TMinusAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TLeftShiftAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TRightShiftAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TAmpersandAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_THatAssign_SymbolType;
        private SymbolTypeAnnotation assignmentOperator_TBarAssign_SymbolType;
        private NameAnnotation identifier_Name;
        private IdentifierAnnotation identifier_Identifier;
        
        public MetaModelParserAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.QualifiedNameContext), annotList);
            this.qualifiedName_QualifiedName = new QualifiedNameAnnotation();
            annotList.Add(this.qualifiedName_QualifiedName);
            
            this.classDeclaration_ClassAncestors_InheritScope = new InheritScopeAnnotation();
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ObjectTypeContext), annotList);
            this.objectType_Name = new NameAnnotation();
            annotList.Add(this.objectType_Name);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PrimitiveTypeContext), annotList);
            this.primitiveType_Name = new NameAnnotation();
            annotList.Add(this.primitiveType_Name);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.VoidTypeContext), annotList);
            this.voidType_Name = new NameAnnotation();
            annotList.Add(this.voidType_Name);
            
            this.invisibleType_KAny_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KAny_PreDefSymbol.Value = MetaDescriptor.Constants.Any;
            this.invisibleType_KNone_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KNone_PreDefSymbol.Value = MetaDescriptor.Constants.None;
            this.invisibleType_KError_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KError_PreDefSymbol.Value = MetaDescriptor.Constants.Error;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ExpressionContext), annotList);
            this.expression_Expression = new ExpressionAnnotation();
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.CastExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.castExpression_SymbolType = new SymbolTypeAnnotation();
            this.castExpression_SymbolType.SymbolType = typeof(MetaTypeCastExpression);
            annotList.Add(this.castExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeofExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeofExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeofExpression_SymbolType.SymbolType = typeof(MetaTypeOfExpression);
            annotList.Add(this.typeofExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BracketExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bracketExpression_SymbolType = new SymbolTypeAnnotation();
            this.bracketExpression_SymbolType.SymbolType = typeof(MetaBracketExpression);
            annotList.Add(this.bracketExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ThisExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.thisExpression_SymbolType = new SymbolTypeAnnotation();
            this.thisExpression_SymbolType.SymbolType = typeof(MetaThisExpression);
            annotList.Add(this.thisExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConstantExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.constantExpression_SymbolType = new SymbolTypeAnnotation();
            this.constantExpression_SymbolType.SymbolType = typeof(MetaConstantExpression);
            annotList.Add(this.constantExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.identifierExpression_SymbolType = new SymbolTypeAnnotation();
            this.identifierExpression_SymbolType.SymbolType = typeof(MetaIdentifierExpression);
            annotList.Add(this.identifierExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IndexerExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.indexerExpression_SymbolType = new SymbolTypeAnnotation();
            this.indexerExpression_SymbolType.SymbolType = typeof(MetaIndexerExpression);
            annotList.Add(this.indexerExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.FunctionCallExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.functionCallExpression_SymbolType = new SymbolTypeAnnotation();
            this.functionCallExpression_SymbolType.SymbolType = typeof(MetaFunctionCallExpression);
            annotList.Add(this.functionCallExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MemberAccessExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.memberAccessExpression_SymbolType = new SymbolTypeAnnotation();
            this.memberAccessExpression_SymbolType.SymbolType = typeof(MetaMemberAccessExpression);
            annotList.Add(this.memberAccessExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PostExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PreExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.UnaryExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeConversionExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeConversionExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeConversionExpression_SymbolType.SymbolType = typeof(MetaTypeAsExpression);
            annotList.Add(this.typeConversionExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeCheckExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeCheckExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeCheckExpression_SymbolType.SymbolType = typeof(MetaTypeCheckExpression);
            annotList.Add(this.typeCheckExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MultiplicativeExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AdditiveExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ShiftExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ComparisonExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EqualityExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseAndExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseAndExpression_SymbolType.SymbolType = typeof(MetaAndExpression);
            annotList.Add(this.bitwiseAndExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseXorExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseXorExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseXorExpression_SymbolType.SymbolType = typeof(MetaExclusiveOrExpression);
            annotList.Add(this.bitwiseXorExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseOrExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseOrExpression_SymbolType.SymbolType = typeof(MetaOrExpression);
            annotList.Add(this.bitwiseOrExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalAndExpression_SymbolType = new SymbolTypeAnnotation();
            this.logicalAndExpression_SymbolType.SymbolType = typeof(MetaAndAlsoExpression);
            annotList.Add(this.logicalAndExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalOrExpression_SymbolType = new SymbolTypeAnnotation();
            this.logicalOrExpression_SymbolType.SymbolType = typeof(MetaOrElseExpression);
            annotList.Add(this.logicalOrExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NullCoalescingExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.nullCoalescingExpression_SymbolType = new SymbolTypeAnnotation();
            this.nullCoalescingExpression_SymbolType.SymbolType = typeof(MetaNullCoalescingExpression);
            annotList.Add(this.nullCoalescingExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConditionalExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.conditionalExpression_SymbolType = new SymbolTypeAnnotation();
            this.conditionalExpression_SymbolType.SymbolType = typeof(MetaConditionalExpression);
            annotList.Add(this.conditionalExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AssignmentExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NewExpressionContext), annotList);
            this.newExpression_Expression = new ExpressionAnnotation();
            annotList.Add(this.newExpression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NewObjectExpressionContext), annotList);
            annotList.Add(this.newExpression_Expression);
            this.newObjectExpression_SymbolType = new SymbolTypeAnnotation();
            this.newObjectExpression_SymbolType.SymbolType = typeof(MetaNewExpression);
            annotList.Add(this.newObjectExpression_SymbolType);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NewCollectionExpressionContext), annotList);
            annotList.Add(this.newExpression_Expression);
            this.newCollectionExpression_SymbolType = new SymbolTypeAnnotation();
            this.newCollectionExpression_SymbolType.SymbolType = typeof(MetaNewCollectionExpression);
            annotList.Add(this.newCollectionExpression_SymbolType);
            
            this.postOperator_TPlusPlus_SymbolType = new SymbolTypeAnnotation();
            this.postOperator_TPlusPlus_SymbolType.SymbolType = typeof(MetaPostIncrementAssignExpression);
            this.postOperator_TMinusMinus_SymbolType = new SymbolTypeAnnotation();
            this.postOperator_TMinusMinus_SymbolType.SymbolType = typeof(MetaPostDecrementAssignExpression);
            
            this.preOperator_TPlusPlus_SymbolType = new SymbolTypeAnnotation();
            this.preOperator_TPlusPlus_SymbolType.SymbolType = typeof(MetaPreIncrementAssignExpression);
            this.preOperator_TMinusMinus_SymbolType = new SymbolTypeAnnotation();
            this.preOperator_TMinusMinus_SymbolType.SymbolType = typeof(MetaPreDecrementAssignExpression);
            
            this.unaryOperator_TPlus_SymbolType = new SymbolTypeAnnotation();
            this.unaryOperator_TPlus_SymbolType.SymbolType = typeof(MetaUnaryPlusExpression);
            this.unaryOperator_TMinus_SymbolType = new SymbolTypeAnnotation();
            this.unaryOperator_TMinus_SymbolType.SymbolType = typeof(MetaNegateExpression);
            this.unaryOperator_TTilde_SymbolType = new SymbolTypeAnnotation();
            this.unaryOperator_TTilde_SymbolType.SymbolType = typeof(MetaOnesComplementExpression);
            this.unaryOperator_TExclamation_SymbolType = new SymbolTypeAnnotation();
            this.unaryOperator_TExclamation_SymbolType.SymbolType = typeof(MetaNotExpression);
            
            this.multiplicativeOperator_TAsterisk_SymbolType = new SymbolTypeAnnotation();
            this.multiplicativeOperator_TAsterisk_SymbolType.SymbolType = typeof(MetaMultiplyExpression);
            this.multiplicativeOperator_TSlash_SymbolType = new SymbolTypeAnnotation();
            this.multiplicativeOperator_TSlash_SymbolType.SymbolType = typeof(MetaDivideExpression);
            this.multiplicativeOperator_TPercent_SymbolType = new SymbolTypeAnnotation();
            this.multiplicativeOperator_TPercent_SymbolType.SymbolType = typeof(MetaModuloExpression);
            
            this.additiveOperator_TPlus_SymbolType = new SymbolTypeAnnotation();
            this.additiveOperator_TPlus_SymbolType.SymbolType = typeof(MetaAddExpression);
            this.additiveOperator_TMinus_SymbolType = new SymbolTypeAnnotation();
            this.additiveOperator_TMinus_SymbolType.SymbolType = typeof(MetaSubtractExpression);
            
            this.shiftOperator_TLessThan_SymbolType = new SymbolTypeAnnotation();
            this.shiftOperator_TLessThan_SymbolType.SymbolType = typeof(MetaLeftShiftExpression);
            this.shiftOperator_TGreaterThan_SymbolType = new SymbolTypeAnnotation();
            this.shiftOperator_TGreaterThan_SymbolType.SymbolType = typeof(MetaRightShiftExpression);
            
            this.comparisonOperator_TLessThan_SymbolType = new SymbolTypeAnnotation();
            this.comparisonOperator_TLessThan_SymbolType.SymbolType = typeof(MetaLessThanExpression);
            this.comparisonOperator_TGreaterThan_SymbolType = new SymbolTypeAnnotation();
            this.comparisonOperator_TGreaterThan_SymbolType.SymbolType = typeof(MetaGreaterThanExpression);
            this.comparisonOperator_TLessThanOrEqual_SymbolType = new SymbolTypeAnnotation();
            this.comparisonOperator_TLessThanOrEqual_SymbolType.SymbolType = typeof(MetaLessThanOrEqualExpression);
            this.comparisonOperator_TGreaterThanOrEqual_SymbolType = new SymbolTypeAnnotation();
            this.comparisonOperator_TGreaterThanOrEqual_SymbolType.SymbolType = typeof(MetaGreaterThanOrEqualExpression);
            
            this.equalityOperator_TEqual_SymbolType = new SymbolTypeAnnotation();
            this.equalityOperator_TEqual_SymbolType.SymbolType = typeof(MetaEqualExpression);
            this.equalityOperator_TNotEqual_SymbolType = new SymbolTypeAnnotation();
            this.equalityOperator_TNotEqual_SymbolType.SymbolType = typeof(MetaNotEqualExpression);
            
            this.assignmentOperator_TAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TAssign_SymbolType.SymbolType = typeof(MetaAssignExpression);
            this.assignmentOperator_TAsteriskAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TAsteriskAssign_SymbolType.SymbolType = typeof(MetaMultiplyAssignExpression);
            this.assignmentOperator_TSlashAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TSlashAssign_SymbolType.SymbolType = typeof(MetaDivideAssignExpression);
            this.assignmentOperator_TPercentAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TPercentAssign_SymbolType.SymbolType = typeof(MetaModuloAssignExpression);
            this.assignmentOperator_TPlusAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TPlusAssign_SymbolType.SymbolType = typeof(MetaAddAssignExpression);
            this.assignmentOperator_TMinusAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TMinusAssign_SymbolType.SymbolType = typeof(MetaSubtractAssignExpression);
            this.assignmentOperator_TLeftShiftAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TLeftShiftAssign_SymbolType.SymbolType = typeof(MetaLeftShiftAssignExpression);
            this.assignmentOperator_TRightShiftAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TRightShiftAssign_SymbolType.SymbolType = typeof(MetaRightShiftAssignExpression);
            this.assignmentOperator_TAmpersandAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TAmpersandAssign_SymbolType.SymbolType = typeof(MetaAndAssignExpression);
            this.assignmentOperator_THatAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_THatAssign_SymbolType.SymbolType = typeof(MetaExclusiveOrAssignExpression);
            this.assignmentOperator_TBarAssign_SymbolType = new SymbolTypeAnnotation();
            this.assignmentOperator_TBarAssign_SymbolType.SymbolType = typeof(MetaOrAssignExpression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierContext), annotList);
            this.identifier_Name = new NameAnnotation();
            annotList.Add(this.identifier_Name);
            this.identifier_Identifier = new IdentifierAnnotation();
            annotList.Add(this.identifier_Identifier);
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
                        this.OverrideSymbolType(node, sta.SymbolType);
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
        
        public override object VisitMain(MetaModelParser.MainContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMain(context);
        }
        
        public override object VisitQualifiedName(MetaModelParser.QualifiedNameContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.qualifiedName_QualifiedName);
            this.HandleSymbolType(context);
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitIdentifierList(MetaModelParser.IdentifierListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitQualifiedNameList(MetaModelParser.QualifiedNameListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifiedNameList(context);
        }
        
        public override object VisitAnnotation(MetaModelParser.AnnotationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp1 = new PropertyAnnotation();
            __tmp1.Name = "Annotations";
            treeAnnotList.Add(__tmp1);
            SymbolAnnotation __tmp2 = new SymbolAnnotation();
            __tmp2.SymbolType = typeof(MetaAnnotation);
            treeAnnotList.Add(__tmp2);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp3 = new PropertyAnnotation();
                __tmp3.Name = "Name";
                elemAnnotList.Add(__tmp3);
                ValueAnnotation __tmp4 = new ValueAnnotation();
                elemAnnotList.Add(__tmp4);
            }
            this.HandleSymbolType(context);
            return base.VisitAnnotation(context);
        }
        
        public override object VisitAnnotationParams(MetaModelParser.AnnotationParamsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationParams(context);
        }
        
        public override object VisitAnnotationParamList(MetaModelParser.AnnotationParamListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationParamList(context);
        }
        
        public override object VisitAnnotationParam(MetaModelParser.AnnotationParamContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp5 = new PropertyAnnotation();
            __tmp5.Name = "Properties";
            treeAnnotList.Add(__tmp5);
            SymbolAnnotation __tmp6 = new SymbolAnnotation();
            __tmp6.SymbolType = typeof(MetaAnnotationProperty);
            treeAnnotList.Add(__tmp6);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp7 = new PropertyAnnotation();
                __tmp7.Name = "Name";
                elemAnnotList.Add(__tmp7);
                ValueAnnotation __tmp8 = new ValueAnnotation();
                elemAnnotList.Add(__tmp8);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp9 = new PropertyAnnotation();
                __tmp9.Name = "Value";
                elemAnnotList.Add(__tmp9);
            }
            this.HandleSymbolType(context);
            return base.VisitAnnotationParam(context);
        }
        
        public override object VisitNamespaceDeclaration(MetaModelParser.NamespaceDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp10 = new NameDefAnnotation();
            __tmp10.SymbolType = typeof(MetaNamespace);
            __tmp10.NestingProperty = "Namespaces";
            __tmp10.Merge = true;
            treeAnnotList.Add(__tmp10);
            this.HandleSymbolType(context);
            return base.VisitNamespaceDeclaration(context);
        }
        
        public override object VisitMetamodelDeclaration(MetaModelParser.MetamodelDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp11 = new PropertyAnnotation();
            __tmp11.Name = "MetaModel";
            treeAnnotList.Add(__tmp11);
            NameDefAnnotation __tmp12 = new NameDefAnnotation();
            __tmp12.SymbolType = typeof(MetaModel);
            treeAnnotList.Add(__tmp12);
            this.HandleSymbolType(context);
            return base.VisitMetamodelDeclaration(context);
        }
        
        public override object VisitMetamodelPropertyList(MetaModelParser.MetamodelPropertyListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitMetamodelPropertyList(context);
        }
        
        public override object VisitMetamodelProperty(MetaModelParser.MetamodelPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp13 = new PropertyAnnotation();
            treeAnnotList.Add(__tmp13);
            List<object> elemAnnotList = null;
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp14 = new ValueAnnotation();
                elemAnnotList.Add(__tmp14);
            }
            this.HandleSymbolType(context);
            return base.VisitMetamodelProperty(context);
        }
        
        public override object VisitDeclaration(MetaModelParser.DeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDeclaration(context);
        }
        
        public override object VisitEnumDeclaration(MetaModelParser.EnumDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp15 = new PropertyAnnotation();
            __tmp15.Name = "Declarations";
            treeAnnotList.Add(__tmp15);
            TypeDefAnnotation __tmp16 = new TypeDefAnnotation();
            __tmp16.SymbolType = typeof(MetaEnum);
            treeAnnotList.Add(__tmp16);
            List<object> elemAnnotList = null;
            if (context.enumValues() != null)
            {
                object elem = context.enumValues();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp17 = new PropertyAnnotation();
                __tmp17.Name = "EnumLiterals";
                elemAnnotList.Add(__tmp17);
            }
            this.HandleSymbolType(context);
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumValues(MetaModelParser.EnumValuesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEnumValues(context);
        }
        
        public override object VisitEnumValue(MetaModelParser.EnumValueContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp18 = new NameDefAnnotation();
            __tmp18.SymbolType = typeof(MetaEnumLiteral);
            treeAnnotList.Add(__tmp18);
            this.HandleSymbolType(context);
            return base.VisitEnumValue(context);
        }
        
        public override object VisitEnumMemberDeclaration(MetaModelParser.EnumMemberDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (context.operationDeclaration() != null)
            {
                object elem = context.operationDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp19 = new PropertyAnnotation();
                __tmp19.Name = "Operations";
                elemAnnotList.Add(__tmp19);
            }
            this.HandleSymbolType(context);
            return base.VisitEnumMemberDeclaration(context);
        }
        
        public override object VisitClassDeclaration(MetaModelParser.ClassDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp20 = new PropertyAnnotation();
            __tmp20.Name = "Declarations";
            treeAnnotList.Add(__tmp20);
            TypeDefAnnotation __tmp21 = new TypeDefAnnotation();
            __tmp21.SymbolType = typeof(MetaClass);
            treeAnnotList.Add(__tmp21);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp22 = new PropertyAnnotation();
                __tmp22.Name = "IsAbstract";
                __tmp22.Value = true;
                elemAnnotList.Add(__tmp22);
            }
            if (context.classAncestors() != null)
            {
                object elem = context.classAncestors();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp23 = new PropertyAnnotation();
                __tmp23.Name = "SuperClasses";
                elemAnnotList.Add(__tmp23);
                elemAnnotList.Add(this.classDeclaration_ClassAncestors_InheritScope);
            }
            this.HandleSymbolType(context);
            return base.VisitClassDeclaration(context);
        }
        
        public override object VisitClassAncestors(MetaModelParser.ClassAncestorsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitClassAncestors(context);
        }
        
        public override object VisitClassAncestor(MetaModelParser.ClassAncestorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp24 = new TypeUseAnnotation();
                __tmp24.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp24);
            }
            this.HandleSymbolType(context);
            return base.VisitClassAncestor(context);
        }
        
        public override object VisitClassMemberDeclaration(MetaModelParser.ClassMemberDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (context.fieldDeclaration() != null)
            {
                object elem = context.fieldDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp25 = new PropertyAnnotation();
                __tmp25.Name = "Properties";
                elemAnnotList.Add(__tmp25);
            }
            if (context.operationDeclaration() != null)
            {
                object elem = context.operationDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp26 = new PropertyAnnotation();
                __tmp26.Name = "Operations";
                elemAnnotList.Add(__tmp26);
            }
            if (context.constructorDeclaration() != null)
            {
                object elem = context.constructorDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp27 = new PropertyAnnotation();
                __tmp27.Name = "Constructor";
                elemAnnotList.Add(__tmp27);
            }
            this.HandleSymbolType(context);
            return base.VisitClassMemberDeclaration(context);
        }
        
        public override object VisitFieldDeclaration(MetaModelParser.FieldDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp28 = new NameDefAnnotation();
            __tmp28.SymbolType = typeof(MetaProperty);
            treeAnnotList.Add(__tmp28);
            List<object> elemAnnotList = null;
            if (context.fieldModifier() != null)
            {
                object elem = context.fieldModifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp29 = new PropertyAnnotation();
                __tmp29.Name = "Kind";
                elemAnnotList.Add(__tmp29);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp30 = new PropertyAnnotation();
                __tmp30.Name = "Type";
                elemAnnotList.Add(__tmp30);
            }
            this.HandleSymbolType(context);
            return base.VisitFieldDeclaration(context);
        }
        
        public override object VisitFieldModifier(MetaModelParser.FieldModifierContext context)
        {
            List<object> elemAnnotList = null;
            if (context.KContainment() != null)
            {
                object elem = context.KContainment();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp31 = new ValueAnnotation();
                __tmp31.Value = MetaPropertyKind.Containment;
                elemAnnotList.Add(__tmp31);
            }
            if (context.KReadonly() != null)
            {
                object elem = context.KReadonly();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp32 = new ValueAnnotation();
                __tmp32.Value = MetaPropertyKind.Readonly;
                elemAnnotList.Add(__tmp32);
            }
            if (context.KLazy() != null)
            {
                object elem = context.KLazy();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp33 = new ValueAnnotation();
                __tmp33.Value = MetaPropertyKind.Lazy;
                elemAnnotList.Add(__tmp33);
            }
            if (context.KDerived() != null)
            {
                object elem = context.KDerived();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp34 = new ValueAnnotation();
                __tmp34.Value = MetaPropertyKind.Derived;
                elemAnnotList.Add(__tmp34);
            }
            if (context.KSynthetized() != null)
            {
                object elem = context.KSynthetized();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp35 = new ValueAnnotation();
                __tmp35.Value = MetaPropertyKind.Synthetized;
                elemAnnotList.Add(__tmp35);
            }
            if (context.KInherited() != null)
            {
                object elem = context.KInherited();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp36 = new ValueAnnotation();
                __tmp36.Value = MetaPropertyKind.Inherited;
                elemAnnotList.Add(__tmp36);
            }
            this.HandleSymbolType(context);
            return base.VisitFieldModifier(context);
        }
        
        public override object VisitRedefinitions(MetaModelParser.RedefinitionsContext context)
        {
            List<object> elemAnnotList = null;
            if (context.nameUseList() != null)
            {
                object elem = context.nameUseList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp37 = new PropertyAnnotation();
                __tmp37.Name = "RedefinedProperties";
                elemAnnotList.Add(__tmp37);
            }
            this.HandleSymbolType(context);
            return base.VisitRedefinitions(context);
        }
        
        public override object VisitSubsettings(MetaModelParser.SubsettingsContext context)
        {
            List<object> elemAnnotList = null;
            if (context.nameUseList() != null)
            {
                object elem = context.nameUseList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp38 = new PropertyAnnotation();
                __tmp38.Name = "SubsettedProperties";
                elemAnnotList.Add(__tmp38);
            }
            this.HandleSymbolType(context);
            return base.VisitSubsettings(context);
        }
        
        public override object VisitNameUseList(MetaModelParser.NameUseListContext context)
        {
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                foreach(object elem in context.qualifiedName())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    NameUseAnnotation __tmp39 = new NameUseAnnotation();
                    __tmp39.SymbolTypes.Add(typeof(MetaProperty));
                    elemAnnotList.Add(__tmp39);
                }
            }
            this.HandleSymbolType(context);
            return base.VisitNameUseList(context);
        }
        
        public override object VisitConstDeclaration(MetaModelParser.ConstDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp40 = new PropertyAnnotation();
            __tmp40.Name = "Declarations";
            treeAnnotList.Add(__tmp40);
            NameDefAnnotation __tmp41 = new NameDefAnnotation();
            __tmp41.SymbolType = typeof(MetaConstant);
            treeAnnotList.Add(__tmp41);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp42 = new PropertyAnnotation();
                __tmp42.Name = "Type";
                elemAnnotList.Add(__tmp42);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp43 = new PropertyAnnotation();
                __tmp43.Name = "Value";
                elemAnnotList.Add(__tmp43);
            }
            this.HandleSymbolType(context);
            return base.VisitConstDeclaration(context);
        }
        
        public override object VisitFunctionDeclaration(MetaModelParser.FunctionDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp44 = new PropertyAnnotation();
            __tmp44.Name = "Declarations";
            treeAnnotList.Add(__tmp44);
            NameDefAnnotation __tmp45 = new NameDefAnnotation();
            __tmp45.SymbolType = typeof(MetaFunction);
            __tmp45.Overload = true;
            treeAnnotList.Add(__tmp45);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp46 = new PropertyAnnotation();
                __tmp46.Name = "ReturnType";
                elemAnnotList.Add(__tmp46);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp47 = new PropertyAnnotation();
                __tmp47.Name = "Parameters";
                elemAnnotList.Add(__tmp47);
            }
            this.HandleSymbolType(context);
            return base.VisitFunctionDeclaration(context);
        }
        
        public override object VisitReturnType(MetaModelParser.ReturnTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeUseAnnotation __tmp48 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp48);
            this.HandleSymbolType(context);
            return base.VisitReturnType(context);
        }
        
        public override object VisitTypeOfReference(MetaModelParser.TypeOfReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeUseAnnotation __tmp49 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp49);
            this.HandleSymbolType(context);
            return base.VisitTypeOfReference(context);
        }
        
        public override object VisitTypeReference(MetaModelParser.TypeReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeUseAnnotation __tmp50 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp50);
            this.HandleSymbolType(context);
            return base.VisitTypeReference(context);
        }
        
        public override object VisitSimpleType(MetaModelParser.SimpleTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeUseAnnotation __tmp51 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp51);
            this.HandleSymbolType(context);
            return base.VisitSimpleType(context);
        }
        
        public override object VisitClassType(MetaModelParser.ClassTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeUseAnnotation __tmp52 = new TypeUseAnnotation();
            __tmp52.SymbolTypes.Add(typeof(MetaClass));
            treeAnnotList.Add(__tmp52);
            this.HandleSymbolType(context);
            return base.VisitClassType(context);
        }
        
        public override object VisitObjectType(MetaModelParser.ObjectTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.objectType_Name);
            this.HandleSymbolType(context);
            return base.VisitObjectType(context);
        }
        
        public override object VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.primitiveType_Name);
            this.HandleSymbolType(context);
            return base.VisitPrimitiveType(context);
        }
        
        public override object VisitVoidType(MetaModelParser.VoidTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.voidType_Name);
            this.HandleSymbolType(context);
            return base.VisitVoidType(context);
        }
        
        public override object VisitInvisibleType(MetaModelParser.InvisibleTypeContext context)
        {
            List<object> elemAnnotList = null;
            if (context.KAny() != null)
            {
                object elem = context.KAny();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.invisibleType_KAny_PreDefSymbol);
            }
            if (context.KNone() != null)
            {
                object elem = context.KNone();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.invisibleType_KNone_PreDefSymbol);
            }
            if (context.KError() != null)
            {
                object elem = context.KError();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.invisibleType_KError_PreDefSymbol);
            }
            this.HandleSymbolType(context);
            return base.VisitInvisibleType(context);
        }
        
        public override object VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp53 = new TypeCtrAnnotation();
            __tmp53.SymbolType = typeof(MetaNullableType);
            treeAnnotList.Add(__tmp53);
            List<object> elemAnnotList = null;
            if (context.primitiveType() != null)
            {
                object elem = context.primitiveType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp54 = new PropertyAnnotation();
                __tmp54.Name = "InnerType";
                elemAnnotList.Add(__tmp54);
            }
            this.HandleSymbolType(context);
            return base.VisitNullableType(context);
        }
        
        public override object VisitCollectionType(MetaModelParser.CollectionTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp55 = new TypeCtrAnnotation();
            __tmp55.SymbolType = typeof(MetaCollectionType);
            treeAnnotList.Add(__tmp55);
            List<object> elemAnnotList = null;
            if (context.collectionKind() != null)
            {
                object elem = context.collectionKind();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp56 = new PropertyAnnotation();
                __tmp56.Name = "Kind";
                elemAnnotList.Add(__tmp56);
            }
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp57 = new PropertyAnnotation();
                __tmp57.Name = "InnerType";
                elemAnnotList.Add(__tmp57);
            }
            this.HandleSymbolType(context);
            return base.VisitCollectionType(context);
        }
        
        public override object VisitCollectionKind(MetaModelParser.CollectionKindContext context)
        {
            List<object> elemAnnotList = null;
            if (context.KSet() != null)
            {
                object elem = context.KSet();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp58 = new ValueAnnotation();
                __tmp58.Value = MetaCollectionKind.Set;
                elemAnnotList.Add(__tmp58);
            }
            if (context.KList() != null)
            {
                object elem = context.KList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp59 = new ValueAnnotation();
                __tmp59.Value = MetaCollectionKind.List;
                elemAnnotList.Add(__tmp59);
            }
            if (context.KMultiSet() != null)
            {
                object elem = context.KMultiSet();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp60 = new ValueAnnotation();
                __tmp60.Value = MetaCollectionKind.MultiSet;
                elemAnnotList.Add(__tmp60);
            }
            if (context.KMultiList() != null)
            {
                object elem = context.KMultiList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp61 = new ValueAnnotation();
                __tmp61.Value = MetaCollectionKind.MultiList;
                elemAnnotList.Add(__tmp61);
            }
            this.HandleSymbolType(context);
            return base.VisitCollectionKind(context);
        }
        
        public override object VisitOperationDeclaration(MetaModelParser.OperationDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp62 = new NameDefAnnotation();
            __tmp62.SymbolType = typeof(MetaOperation);
            treeAnnotList.Add(__tmp62);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp63 = new PropertyAnnotation();
                __tmp63.Name = "ReturnType";
                elemAnnotList.Add(__tmp63);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp64 = new PropertyAnnotation();
                __tmp64.Name = "Parameters";
                elemAnnotList.Add(__tmp64);
            }
            this.HandleSymbolType(context);
            return base.VisitOperationDeclaration(context);
        }
        
        public override object VisitParameterList(MetaModelParser.ParameterListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParameterList(context);
        }
        
        public override object VisitParameter(MetaModelParser.ParameterContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp65 = new NameDefAnnotation();
            __tmp65.SymbolType = typeof(MetaParameter);
            treeAnnotList.Add(__tmp65);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp66 = new PropertyAnnotation();
                __tmp66.Name = "Type";
                elemAnnotList.Add(__tmp66);
            }
            this.HandleSymbolType(context);
            return base.VisitParameter(context);
        }
        
        public override object VisitConstructorDeclaration(MetaModelParser.ConstructorDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp67 = new NameDefAnnotation();
            __tmp67.SymbolType = typeof(MetaConstructor);
            treeAnnotList.Add(__tmp67);
            List<object> elemAnnotList = null;
            if (context.initializerDeclaration() != null)
            {
                foreach(object elem in context.initializerDeclaration())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    PropertyAnnotation __tmp68 = new PropertyAnnotation();
                    __tmp68.Name = "Initializers";
                    elemAnnotList.Add(__tmp68);
                }
            }
            this.HandleSymbolType(context);
            return base.VisitConstructorDeclaration(context);
        }
        
        public override object VisitInitializerDeclaration(MetaModelParser.InitializerDeclarationContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitInitializerDeclaration(context);
        }
        
        public override object VisitSynthetizedPropertyInitializer(MetaModelParser.SynthetizedPropertyInitializerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp69 = new SymbolAnnotation();
            __tmp69.SymbolType = typeof(MetaSynthetizedPropertyInitializer);
            treeAnnotList.Add(__tmp69);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp70 = new PropertyAnnotation();
                __tmp70.Name = "PropertyContext";
                elemAnnotList.Add(__tmp70);
                TypeUseAnnotation __tmp71 = new TypeUseAnnotation();
                __tmp71.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp71);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp72 = new PropertyAnnotation();
                __tmp72.Name = "PropertyName";
                elemAnnotList.Add(__tmp72);
                ValueAnnotation __tmp73 = new ValueAnnotation();
                elemAnnotList.Add(__tmp73);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp74 = new PropertyAnnotation();
                __tmp74.Name = "Value";
                elemAnnotList.Add(__tmp74);
            }
            this.HandleSymbolType(context);
            return base.VisitSynthetizedPropertyInitializer(context);
        }
        
        public override object VisitInheritedPropertyInitializer(MetaModelParser.InheritedPropertyInitializerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp75 = new SymbolAnnotation();
            __tmp75.SymbolType = typeof(MetaInheritedPropertyInitializer);
            treeAnnotList.Add(__tmp75);
            List<object> elemAnnotList = null;
            if (context.@object != null)
            {
                object elem = context.@object;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp76 = new PropertyAnnotation();
                __tmp76.Name = "ObjectName";
                elemAnnotList.Add(__tmp76);
                ValueAnnotation __tmp77 = new ValueAnnotation();
                elemAnnotList.Add(__tmp77);
            }
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp78 = new PropertyAnnotation();
                __tmp78.Name = "PropertyContext";
                elemAnnotList.Add(__tmp78);
                TypeUseAnnotation __tmp79 = new TypeUseAnnotation();
                __tmp79.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp79);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp80 = new PropertyAnnotation();
                __tmp80.Name = "PropertyName";
                elemAnnotList.Add(__tmp80);
                ValueAnnotation __tmp81 = new ValueAnnotation();
                elemAnnotList.Add(__tmp81);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp82 = new PropertyAnnotation();
                __tmp82.Name = "Value";
                elemAnnotList.Add(__tmp82);
            }
            this.HandleSymbolType(context);
            return base.VisitInheritedPropertyInitializer(context);
        }
        
        public override object VisitExpressionList(MetaModelParser.ExpressionListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionList(context);
        }
        
        public override object VisitExpressionOrNewExpressionList(MetaModelParser.ExpressionOrNewExpressionListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionOrNewExpressionList(context);
        }
        
        public override object VisitExpressionOrNewExpression(MetaModelParser.ExpressionOrNewExpressionContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitExpressionOrNewExpression(context);
        }
        
        public override object VisitCastExpression(MetaModelParser.CastExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp83 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp83);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.castExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp84 = new PropertyAnnotation();
                __tmp84.Name = "TypeReference";
                elemAnnotList.Add(__tmp84);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp85 = new PropertyAnnotation();
                __tmp85.Name = "Expression";
                elemAnnotList.Add(__tmp85);
            }
            this.HandleSymbolType(context);
            return base.VisitCastExpression(context);
        }
        
        public override object VisitTypeofExpression(MetaModelParser.TypeofExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp86 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp86);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeofExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.typeOfReference() != null)
            {
                object elem = context.typeOfReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp87 = new PropertyAnnotation();
                __tmp87.Name = "TypeReference";
                elemAnnotList.Add(__tmp87);
            }
            this.HandleSymbolType(context);
            return base.VisitTypeofExpression(context);
        }
        
        public override object VisitBracketExpression(MetaModelParser.BracketExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp88 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp88);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bracketExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp89 = new PropertyAnnotation();
                __tmp89.Name = "Expression";
                elemAnnotList.Add(__tmp89);
            }
            this.HandleSymbolType(context);
            return base.VisitBracketExpression(context);
        }
        
        public override object VisitThisExpression(MetaModelParser.ThisExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp90 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp90);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.thisExpression_SymbolType);
            this.HandleSymbolType(context);
            return base.VisitThisExpression(context);
        }
        
        public override object VisitConstantExpression(MetaModelParser.ConstantExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp91 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp91);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.constantExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.value != null)
            {
                object elem = context.value;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp92 = new PropertyAnnotation();
                __tmp92.Name = "Value";
                elemAnnotList.Add(__tmp92);
            }
            this.HandleSymbolType(context);
            return base.VisitConstantExpression(context);
        }
        
        public override object VisitIdentifierExpression(MetaModelParser.IdentifierExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp93 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp93);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.identifierExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp94 = new ValueAnnotation();
                elemAnnotList.Add(__tmp94);
                PropertyAnnotation __tmp95 = new PropertyAnnotation();
                __tmp95.Name = "Name";
                elemAnnotList.Add(__tmp95);
            }
            this.HandleSymbolType(context);
            return base.VisitIdentifierExpression(context);
        }
        
        public override object VisitIndexerExpression(MetaModelParser.IndexerExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp96 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp96);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.indexerExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp97 = new PropertyAnnotation();
                __tmp97.Name = "Expression";
                elemAnnotList.Add(__tmp97);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp98 = new PropertyAnnotation();
                __tmp98.Name = "Arguments";
                elemAnnotList.Add(__tmp98);
            }
            this.HandleSymbolType(context);
            return base.VisitIndexerExpression(context);
        }
        
        public override object VisitFunctionCallExpression(MetaModelParser.FunctionCallExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp99 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp99);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.functionCallExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp100 = new PropertyAnnotation();
                __tmp100.Name = "Expression";
                elemAnnotList.Add(__tmp100);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp101 = new PropertyAnnotation();
                __tmp101.Name = "Arguments";
                elemAnnotList.Add(__tmp101);
            }
            this.HandleSymbolType(context);
            return base.VisitFunctionCallExpression(context);
        }
        
        public override object VisitMemberAccessExpression(MetaModelParser.MemberAccessExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp102 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp102);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.memberAccessExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp103 = new PropertyAnnotation();
                __tmp103.Name = "Expression";
                elemAnnotList.Add(__tmp103);
            }
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp104 = new ValueAnnotation();
                elemAnnotList.Add(__tmp104);
                PropertyAnnotation __tmp105 = new PropertyAnnotation();
                __tmp105.Name = "Name";
                elemAnnotList.Add(__tmp105);
            }
            this.HandleSymbolType(context);
            return base.VisitMemberAccessExpression(context);
        }
        
        public override object VisitPostExpression(MetaModelParser.PostExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp106 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp106);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp107 = new PropertyAnnotation();
                __tmp107.Name = "Expression";
                elemAnnotList.Add(__tmp107);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp108 = new PropertyAnnotation();
                __tmp108.Name = "Kind";
                elemAnnotList.Add(__tmp108);
            }
            this.HandleSymbolType(context);
            return base.VisitPostExpression(context);
        }
        
        public override object VisitPreExpression(MetaModelParser.PreExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp109 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp109);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp110 = new PropertyAnnotation();
                __tmp110.Name = "Kind";
                elemAnnotList.Add(__tmp110);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp111 = new PropertyAnnotation();
                __tmp111.Name = "Expression";
                elemAnnotList.Add(__tmp111);
            }
            this.HandleSymbolType(context);
            return base.VisitPreExpression(context);
        }
        
        public override object VisitUnaryExpression(MetaModelParser.UnaryExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp112 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp112);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp113 = new PropertyAnnotation();
                __tmp113.Name = "Kind";
                elemAnnotList.Add(__tmp113);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp114 = new PropertyAnnotation();
                __tmp114.Name = "Expression";
                elemAnnotList.Add(__tmp114);
            }
            this.HandleSymbolType(context);
            return base.VisitUnaryExpression(context);
        }
        
        public override object VisitTypeConversionExpression(MetaModelParser.TypeConversionExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp115 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp115);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeConversionExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp116 = new PropertyAnnotation();
                __tmp116.Name = "Expression";
                elemAnnotList.Add(__tmp116);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp117 = new PropertyAnnotation();
                __tmp117.Name = "TypeReference";
                elemAnnotList.Add(__tmp117);
            }
            this.HandleSymbolType(context);
            return base.VisitTypeConversionExpression(context);
        }
        
        public override object VisitTypeCheckExpression(MetaModelParser.TypeCheckExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp118 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp118);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeCheckExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp119 = new PropertyAnnotation();
                __tmp119.Name = "Expression";
                elemAnnotList.Add(__tmp119);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp120 = new PropertyAnnotation();
                __tmp120.Name = "TypeReference";
                elemAnnotList.Add(__tmp120);
            }
            this.HandleSymbolType(context);
            return base.VisitTypeCheckExpression(context);
        }
        
        public override object VisitMultiplicativeExpression(MetaModelParser.MultiplicativeExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp121 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp121);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp122 = new PropertyAnnotation();
                __tmp122.Name = "Left";
                elemAnnotList.Add(__tmp122);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp123 = new PropertyAnnotation();
                __tmp123.Name = "Kind";
                elemAnnotList.Add(__tmp123);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp124 = new PropertyAnnotation();
                __tmp124.Name = "Right";
                elemAnnotList.Add(__tmp124);
            }
            this.HandleSymbolType(context);
            return base.VisitMultiplicativeExpression(context);
        }
        
        public override object VisitAdditiveExpression(MetaModelParser.AdditiveExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp125 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp125);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp126 = new PropertyAnnotation();
                __tmp126.Name = "Left";
                elemAnnotList.Add(__tmp126);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp127 = new PropertyAnnotation();
                __tmp127.Name = "Kind";
                elemAnnotList.Add(__tmp127);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp128 = new PropertyAnnotation();
                __tmp128.Name = "Right";
                elemAnnotList.Add(__tmp128);
            }
            this.HandleSymbolType(context);
            return base.VisitAdditiveExpression(context);
        }
        
        public override object VisitShiftExpression(MetaModelParser.ShiftExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp129 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp129);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp130 = new PropertyAnnotation();
                __tmp130.Name = "Left";
                elemAnnotList.Add(__tmp130);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp131 = new PropertyAnnotation();
                __tmp131.Name = "Kind";
                elemAnnotList.Add(__tmp131);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp132 = new PropertyAnnotation();
                __tmp132.Name = "Right";
                elemAnnotList.Add(__tmp132);
            }
            this.HandleSymbolType(context);
            return base.VisitShiftExpression(context);
        }
        
        public override object VisitComparisonExpression(MetaModelParser.ComparisonExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp133 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp133);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp134 = new PropertyAnnotation();
                __tmp134.Name = "Left";
                elemAnnotList.Add(__tmp134);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp135 = new PropertyAnnotation();
                __tmp135.Name = "Kind";
                elemAnnotList.Add(__tmp135);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp136 = new PropertyAnnotation();
                __tmp136.Name = "Right";
                elemAnnotList.Add(__tmp136);
            }
            this.HandleSymbolType(context);
            return base.VisitComparisonExpression(context);
        }
        
        public override object VisitEqualityExpression(MetaModelParser.EqualityExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp137 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp137);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp138 = new PropertyAnnotation();
                __tmp138.Name = "Left";
                elemAnnotList.Add(__tmp138);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp139 = new PropertyAnnotation();
                __tmp139.Name = "Kind";
                elemAnnotList.Add(__tmp139);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp140 = new PropertyAnnotation();
                __tmp140.Name = "Right";
                elemAnnotList.Add(__tmp140);
            }
            this.HandleSymbolType(context);
            return base.VisitEqualityExpression(context);
        }
        
        public override object VisitBitwiseAndExpression(MetaModelParser.BitwiseAndExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp141 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp141);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseAndExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp142 = new PropertyAnnotation();
                __tmp142.Name = "Left";
                elemAnnotList.Add(__tmp142);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp143 = new PropertyAnnotation();
                __tmp143.Name = "Right";
                elemAnnotList.Add(__tmp143);
            }
            this.HandleSymbolType(context);
            return base.VisitBitwiseAndExpression(context);
        }
        
        public override object VisitBitwiseXorExpression(MetaModelParser.BitwiseXorExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp144 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp144);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseXorExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp145 = new PropertyAnnotation();
                __tmp145.Name = "Left";
                elemAnnotList.Add(__tmp145);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp146 = new PropertyAnnotation();
                __tmp146.Name = "Right";
                elemAnnotList.Add(__tmp146);
            }
            this.HandleSymbolType(context);
            return base.VisitBitwiseXorExpression(context);
        }
        
        public override object VisitBitwiseOrExpression(MetaModelParser.BitwiseOrExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp147 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp147);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseOrExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp148 = new PropertyAnnotation();
                __tmp148.Name = "Left";
                elemAnnotList.Add(__tmp148);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp149 = new PropertyAnnotation();
                __tmp149.Name = "Right";
                elemAnnotList.Add(__tmp149);
            }
            this.HandleSymbolType(context);
            return base.VisitBitwiseOrExpression(context);
        }
        
        public override object VisitLogicalAndExpression(MetaModelParser.LogicalAndExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp150 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp150);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.logicalAndExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp151 = new PropertyAnnotation();
                __tmp151.Name = "Left";
                elemAnnotList.Add(__tmp151);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp152 = new PropertyAnnotation();
                __tmp152.Name = "Right";
                elemAnnotList.Add(__tmp152);
            }
            this.HandleSymbolType(context);
            return base.VisitLogicalAndExpression(context);
        }
        
        public override object VisitLogicalOrExpression(MetaModelParser.LogicalOrExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp153 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp153);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.logicalOrExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp154 = new PropertyAnnotation();
                __tmp154.Name = "Left";
                elemAnnotList.Add(__tmp154);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp155 = new PropertyAnnotation();
                __tmp155.Name = "Right";
                elemAnnotList.Add(__tmp155);
            }
            this.HandleSymbolType(context);
            return base.VisitLogicalOrExpression(context);
        }
        
        public override object VisitNullCoalescingExpression(MetaModelParser.NullCoalescingExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp156 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp156);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.nullCoalescingExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp157 = new PropertyAnnotation();
                __tmp157.Name = "Left";
                elemAnnotList.Add(__tmp157);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp158 = new PropertyAnnotation();
                __tmp158.Name = "Right";
                elemAnnotList.Add(__tmp158);
            }
            this.HandleSymbolType(context);
            return base.VisitNullCoalescingExpression(context);
        }
        
        public override object VisitConditionalExpression(MetaModelParser.ConditionalExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp159 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp159);
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.conditionalExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.condition != null)
            {
                object elem = context.condition;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp160 = new PropertyAnnotation();
                __tmp160.Name = "Condition";
                elemAnnotList.Add(__tmp160);
            }
            if (context.then != null)
            {
                object elem = context.then;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp161 = new PropertyAnnotation();
                __tmp161.Name = "Then";
                elemAnnotList.Add(__tmp161);
            }
            if (context.@else != null)
            {
                object elem = context.@else;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp162 = new PropertyAnnotation();
                __tmp162.Name = "Else";
                elemAnnotList.Add(__tmp162);
            }
            this.HandleSymbolType(context);
            return base.VisitConditionalExpression(context);
        }
        
        public override object VisitAssignmentExpression(MetaModelParser.AssignmentExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp163 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp163);
            treeAnnotList.Add(this.expression_Expression);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp164 = new PropertyAnnotation();
                __tmp164.Name = "Left";
                elemAnnotList.Add(__tmp164);
            }
            if (context.@operator != null)
            {
                object elem = context.@operator;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp165 = new PropertyAnnotation();
                __tmp165.Name = "Operator";
                elemAnnotList.Add(__tmp165);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp166 = new PropertyAnnotation();
                __tmp166.Name = "Right";
                elemAnnotList.Add(__tmp166);
            }
            this.HandleSymbolType(context);
            return base.VisitAssignmentExpression(context);
        }
        
        public override object VisitNewObjectExpression(MetaModelParser.NewObjectExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp167 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp167);
            treeAnnotList.Add(this.newExpression_Expression);
            treeAnnotList.Add(this.newObjectExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.classType() != null)
            {
                object elem = context.classType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp168 = new PropertyAnnotation();
                __tmp168.Name = "TypeReference";
                elemAnnotList.Add(__tmp168);
            }
            if (context.newPropertyInitList() != null)
            {
                object elem = context.newPropertyInitList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp169 = new PropertyAnnotation();
                __tmp169.Name = "NewPropertyInitList";
                elemAnnotList.Add(__tmp169);
            }
            this.HandleSymbolType(context);
            return base.VisitNewObjectExpression(context);
        }
        
        public override object VisitNewCollectionExpression(MetaModelParser.NewCollectionExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp170 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp170);
            treeAnnotList.Add(this.newExpression_Expression);
            treeAnnotList.Add(this.newCollectionExpression_SymbolType);
            List<object> elemAnnotList = null;
            if (context.collectionType() != null)
            {
                object elem = context.collectionType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp171 = new PropertyAnnotation();
                __tmp171.Name = "TypeReference";
                elemAnnotList.Add(__tmp171);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp172 = new PropertyAnnotation();
                __tmp172.Name = "Values";
                elemAnnotList.Add(__tmp172);
            }
            this.HandleSymbolType(context);
            return base.VisitNewCollectionExpression(context);
        }
        
        public override object VisitNewPropertyInitList(MetaModelParser.NewPropertyInitListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNewPropertyInitList(context);
        }
        
        public override object VisitNewPropertyInit(MetaModelParser.NewPropertyInitContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp173 = new PropertyAnnotation();
            __tmp173.Name = "PropertyInitializers";
            treeAnnotList.Add(__tmp173);
            SymbolAnnotation __tmp174 = new SymbolAnnotation();
            __tmp174.SymbolType = typeof(MetaNewPropertyInitializer);
            treeAnnotList.Add(__tmp174);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp175 = new PropertyAnnotation();
                __tmp175.Name = "PropertyName";
                elemAnnotList.Add(__tmp175);
                ValueAnnotation __tmp176 = new ValueAnnotation();
                elemAnnotList.Add(__tmp176);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp177 = new PropertyAnnotation();
                __tmp177.Name = "Value";
                elemAnnotList.Add(__tmp177);
            }
            this.HandleSymbolType(context);
            return base.VisitNewPropertyInit(context);
        }
        
        public override object VisitPostOperator(MetaModelParser.PostOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TPlusPlus() != null)
            {
                object elem = context.TPlusPlus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.postOperator_TPlusPlus_SymbolType);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.postOperator_TMinusMinus_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitPostOperator(context);
        }
        
        public override object VisitPreOperator(MetaModelParser.PreOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TPlusPlus() != null)
            {
                object elem = context.TPlusPlus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.preOperator_TPlusPlus_SymbolType);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.preOperator_TMinusMinus_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitPreOperator(context);
        }
        
        public override object VisitUnaryOperator(MetaModelParser.UnaryOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TPlus() != null)
            {
                object elem = context.TPlus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.unaryOperator_TPlus_SymbolType);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.unaryOperator_TMinus_SymbolType);
            }
            if (context.TTilde() != null)
            {
                object elem = context.TTilde();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.unaryOperator_TTilde_SymbolType);
            }
            if (context.TExclamation() != null)
            {
                object elem = context.TExclamation();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.unaryOperator_TExclamation_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitUnaryOperator(context);
        }
        
        public override object VisitMultiplicativeOperator(MetaModelParser.MultiplicativeOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TAsterisk() != null)
            {
                object elem = context.TAsterisk();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.multiplicativeOperator_TAsterisk_SymbolType);
            }
            if (context.TSlash() != null)
            {
                object elem = context.TSlash();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.multiplicativeOperator_TSlash_SymbolType);
            }
            if (context.TPercent() != null)
            {
                object elem = context.TPercent();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.multiplicativeOperator_TPercent_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitMultiplicativeOperator(context);
        }
        
        public override object VisitAdditiveOperator(MetaModelParser.AdditiveOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TPlus() != null)
            {
                object elem = context.TPlus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.additiveOperator_TPlus_SymbolType);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.additiveOperator_TMinus_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitAdditiveOperator(context);
        }
        
        public override object VisitShiftOperator(MetaModelParser.ShiftOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TLessThan() != null)
            {
                foreach(object elem in context.TLessThan())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    elemAnnotList.Add(this.shiftOperator_TLessThan_SymbolType);
                }
            }
            if (context.TGreaterThan() != null)
            {
                foreach(object elem in context.TGreaterThan())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    elemAnnotList.Add(this.shiftOperator_TGreaterThan_SymbolType);
                }
            }
            this.HandleSymbolType(context);
            return base.VisitShiftOperator(context);
        }
        
        public override object VisitComparisonOperator(MetaModelParser.ComparisonOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TLessThan() != null)
            {
                object elem = context.TLessThan();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonOperator_TLessThan_SymbolType);
            }
            if (context.TGreaterThan() != null)
            {
                object elem = context.TGreaterThan();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonOperator_TGreaterThan_SymbolType);
            }
            if (context.TLessThanOrEqual() != null)
            {
                object elem = context.TLessThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonOperator_TLessThanOrEqual_SymbolType);
            }
            if (context.TGreaterThanOrEqual() != null)
            {
                object elem = context.TGreaterThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonOperator_TGreaterThanOrEqual_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitComparisonOperator(context);
        }
        
        public override object VisitEqualityOperator(MetaModelParser.EqualityOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TEqual() != null)
            {
                object elem = context.TEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.equalityOperator_TEqual_SymbolType);
            }
            if (context.TNotEqual() != null)
            {
                object elem = context.TNotEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.equalityOperator_TNotEqual_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitEqualityOperator(context);
        }
        
        public override object VisitAssignmentOperator(MetaModelParser.AssignmentOperatorContext context)
        {
            List<object> elemAnnotList = null;
            if (context.TAssign() != null)
            {
                object elem = context.TAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TAssign_SymbolType);
            }
            if (context.TAsteriskAssign() != null)
            {
                object elem = context.TAsteriskAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TAsteriskAssign_SymbolType);
            }
            if (context.TSlashAssign() != null)
            {
                object elem = context.TSlashAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TSlashAssign_SymbolType);
            }
            if (context.TPercentAssign() != null)
            {
                object elem = context.TPercentAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TPercentAssign_SymbolType);
            }
            if (context.TPlusAssign() != null)
            {
                object elem = context.TPlusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TPlusAssign_SymbolType);
            }
            if (context.TMinusAssign() != null)
            {
                object elem = context.TMinusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TMinusAssign_SymbolType);
            }
            if (context.TLeftShiftAssign() != null)
            {
                object elem = context.TLeftShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TLeftShiftAssign_SymbolType);
            }
            if (context.TRightShiftAssign() != null)
            {
                object elem = context.TRightShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TRightShiftAssign_SymbolType);
            }
            if (context.TAmpersandAssign() != null)
            {
                object elem = context.TAmpersandAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TAmpersandAssign_SymbolType);
            }
            if (context.THatAssign() != null)
            {
                object elem = context.THatAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_THatAssign_SymbolType);
            }
            if (context.TBarAssign() != null)
            {
                object elem = context.TBarAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentOperator_TBarAssign_SymbolType);
            }
            this.HandleSymbolType(context);
            return base.VisitAssignmentOperator(context);
        }
        
        public override object VisitAssociationDeclaration(MetaModelParser.AssociationDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (context.source != null)
            {
                object elem = context.source;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp178 = new NameUseAnnotation();
                __tmp178.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp178);
            }
            if (context.target != null)
            {
                object elem = context.target;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp179 = new NameUseAnnotation();
                __tmp179.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp179);
            }
            this.HandleSymbolType(context);
            return base.VisitAssociationDeclaration(context);
        }
        
        public override object VisitIdentifier(MetaModelParser.IdentifierContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.identifier_Name);
            treeAnnotList.Add(this.identifier_Identifier);
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitLiteral(MetaModelParser.LiteralContext context)
        {
            List<object> elemAnnotList = null;
            if (context.nullLiteral() != null)
            {
                object elem = context.nullLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolAnnotation __tmp180 = new SymbolAnnotation();
                __tmp180.SymbolType = typeof(MetaNullExpression);
                elemAnnotList.Add(__tmp180);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp181 = new ValueAnnotation();
                elemAnnotList.Add(__tmp181);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp182 = new ValueAnnotation();
                elemAnnotList.Add(__tmp182);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp183 = new ValueAnnotation();
                elemAnnotList.Add(__tmp183);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp184 = new ValueAnnotation();
                elemAnnotList.Add(__tmp184);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp185 = new ValueAnnotation();
                elemAnnotList.Add(__tmp185);
            }
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(MetaModelParser.NullLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(MetaModelParser.BooleanLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitIntegerLiteral(MetaModelParser.IntegerLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(MetaModelParser.DecimalLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(MetaModelParser.ScientificLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitStringLiteral(MetaModelParser.StringLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStringLiteral(context);
        }
    }
    
    public class MetaModelParserPropertyEvaluator : MetaCompilerPropertyEvaluator, IMetaModelParserVisitor<object>
    {
        public MetaModelParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitMain(MetaModelParser.MainContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedName(MetaModelParser.QualifiedNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierList(MetaModelParser.IdentifierListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedNameList(MetaModelParser.QualifiedNameListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotation(MetaModelParser.AnnotationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationParams(MetaModelParser.AnnotationParamsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationParamList(MetaModelParser.AnnotationParamListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationParam(MetaModelParser.AnnotationParamContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNamespaceDeclaration(MetaModelParser.NamespaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMetamodelDeclaration(MetaModelParser.MetamodelDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMetamodelPropertyList(MetaModelParser.MetamodelPropertyListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMetamodelProperty(MetaModelParser.MetamodelPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDeclaration(MetaModelParser.DeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumDeclaration(MetaModelParser.EnumDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumValues(MetaModelParser.EnumValuesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumValue(MetaModelParser.EnumValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumMemberDeclaration(MetaModelParser.EnumMemberDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitClassDeclaration(MetaModelParser.ClassDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitClassAncestors(MetaModelParser.ClassAncestorsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitClassAncestor(MetaModelParser.ClassAncestorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitClassMemberDeclaration(MetaModelParser.ClassMemberDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFieldDeclaration(MetaModelParser.FieldDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFieldModifier(MetaModelParser.FieldModifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRedefinitions(MetaModelParser.RedefinitionsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSubsettings(MetaModelParser.SubsettingsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNameUseList(MetaModelParser.NameUseListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConstDeclaration(MetaModelParser.ConstDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionDeclaration(MetaModelParser.FunctionDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnType(MetaModelParser.ReturnTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeOfReference(MetaModelParser.TypeOfReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeReference(MetaModelParser.TypeReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSimpleType(MetaModelParser.SimpleTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitClassType(MetaModelParser.ClassTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitObjectType(MetaModelParser.ObjectTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitVoidType(MetaModelParser.VoidTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitInvisibleType(MetaModelParser.InvisibleTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCollectionType(MetaModelParser.CollectionTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCollectionKind(MetaModelParser.CollectionKindContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationDeclaration(MetaModelParser.OperationDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParameterList(MetaModelParser.ParameterListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParameter(MetaModelParser.ParameterContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConstructorDeclaration(MetaModelParser.ConstructorDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitInitializerDeclaration(MetaModelParser.InitializerDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSynthetizedPropertyInitializer(MetaModelParser.SynthetizedPropertyInitializerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitInheritedPropertyInitializer(MetaModelParser.InheritedPropertyInitializerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionList(MetaModelParser.ExpressionListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionOrNewExpressionList(MetaModelParser.ExpressionOrNewExpressionListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitExpressionOrNewExpression(MetaModelParser.ExpressionOrNewExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCastExpression(MetaModelParser.CastExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofExpression(MetaModelParser.TypeofExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBracketExpression(MetaModelParser.BracketExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitThisExpression(MetaModelParser.ThisExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConstantExpression(MetaModelParser.ConstantExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierExpression(MetaModelParser.IdentifierExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIndexerExpression(MetaModelParser.IndexerExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitFunctionCallExpression(MetaModelParser.FunctionCallExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMemberAccessExpression(MetaModelParser.MemberAccessExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPostExpression(MetaModelParser.PostExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPreExpression(MetaModelParser.PreExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUnaryExpression(MetaModelParser.UnaryExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeConversionExpression(MetaModelParser.TypeConversionExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeCheckExpression(MetaModelParser.TypeCheckExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMultiplicativeExpression(MetaModelParser.MultiplicativeExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAdditiveExpression(MetaModelParser.AdditiveExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitShiftExpression(MetaModelParser.ShiftExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComparisonExpression(MetaModelParser.ComparisonExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEqualityExpression(MetaModelParser.EqualityExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseAndExpression(MetaModelParser.BitwiseAndExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseXorExpression(MetaModelParser.BitwiseXorExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseOrExpression(MetaModelParser.BitwiseOrExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalAndExpression(MetaModelParser.LogicalAndExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalOrExpression(MetaModelParser.LogicalOrExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullCoalescingExpression(MetaModelParser.NullCoalescingExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConditionalExpression(MetaModelParser.ConditionalExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssignmentExpression(MetaModelParser.AssignmentExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNewObjectExpression(MetaModelParser.NewObjectExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNewCollectionExpression(MetaModelParser.NewCollectionExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNewPropertyInitList(MetaModelParser.NewPropertyInitListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNewPropertyInit(MetaModelParser.NewPropertyInitContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPostOperator(MetaModelParser.PostOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPreOperator(MetaModelParser.PreOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitUnaryOperator(MetaModelParser.UnaryOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMultiplicativeOperator(MetaModelParser.MultiplicativeOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAdditiveOperator(MetaModelParser.AdditiveOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitShiftOperator(MetaModelParser.ShiftOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComparisonOperator(MetaModelParser.ComparisonOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEqualityOperator(MetaModelParser.EqualityOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssignmentOperator(MetaModelParser.AssignmentOperatorContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssociationDeclaration(MetaModelParser.AssociationDeclarationContext context)
        {
            this.SetValue(context.source, "OppositeProperties", new Lazy<object>(() => this.Symbol(context.target)));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(MetaModelParser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteral(MetaModelParser.LiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullLiteral(MetaModelParser.NullLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBooleanLiteral(MetaModelParser.BooleanLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIntegerLiteral(MetaModelParser.IntegerLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDecimalLiteral(MetaModelParser.DecimalLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitScientificLiteral(MetaModelParser.ScientificLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStringLiteral(MetaModelParser.StringLiteralContext context)
        {
            return this.VisitChildren(context);
        }
    }
}

