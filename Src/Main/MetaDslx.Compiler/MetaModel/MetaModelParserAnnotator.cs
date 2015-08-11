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
        private PropertyAnnotation annotation_Property;
        private PropertyAnnotation annotation_Identifier_Property;
        private PropertyAnnotation namespaceDeclaration_MetamodelDeclaration_Property;
        private PropertyAnnotation enumDeclaration_Property;
        private PropertyAnnotation enumDeclaration_EnumValues_Property;
        private PropertyAnnotation enumMemberDeclaration_OperationDeclaration_Property;
        private PropertyAnnotation classDeclaration_Property;
        private PropertyAnnotation classDeclaration_KAbstract_Property;
        private PropertyAnnotation classDeclaration_ClassAncestors_Property;
        private InheritScopeAnnotation classDeclaration_ClassAncestors_InheritScope;
        private PropertyAnnotation classMemberDeclaration_FieldDeclaration_Property;
        private PropertyAnnotation classMemberDeclaration_OperationDeclaration_Property;
        private PropertyAnnotation classMemberDeclaration_ConstructorDeclaration_Property;
        private PropertyAnnotation fieldDeclaration_FieldModifier_Property;
        private PropertyAnnotation fieldDeclaration_TypeReference_Property;
        private PropertyAnnotation redefinitions_NameUseList_Property;
        private PropertyAnnotation subsettings_NameUseList_Property;
        private PropertyAnnotation constDeclaration_Property;
        private PropertyAnnotation constDeclaration_TypeReference_Property;
        private PropertyAnnotation constDeclaration_ExpressionOrNewExpression_Property;
        private PropertyAnnotation functionDeclaration_Property;
        private PropertyAnnotation functionDeclaration_ReturnType_Property;
        private PropertyAnnotation functionDeclaration_ParameterList_Property;
        private NameAnnotation objectType_Name;
        private NameAnnotation primitiveType_Name;
        private NameAnnotation voidType_Name;
        private NameAnnotation invisibleType_Name;
        private PreDefSymbolAnnotation invisibleType_KAny_PreDefSymbol;
        private PreDefSymbolAnnotation invisibleType_KNone_PreDefSymbol;
        private PreDefSymbolAnnotation invisibleType_KError_PreDefSymbol;
        private PropertyAnnotation nullableType_PrimitiveType_Property;
        private PropertyAnnotation collectionType_CollectionKind_Property;
        private PropertyAnnotation collectionType_SimpleType_Property;
        private PropertyAnnotation operationDeclaration_ReturnType_Property;
        private PropertyAnnotation operationDeclaration_ParameterList_Property;
        private PropertyAnnotation parameter_TypeReference_Property;
        private PropertyAnnotation constructorDeclaration_InitializerDeclaration_Property;
        private PropertyAnnotation synthetizedPropertyInitializer_QualifiedName_Property;
        private PropertyAnnotation synthetizedPropertyInitializer_Property_Property;
        private PropertyAnnotation synthetizedPropertyInitializer_Expression_Property;
        private PropertyAnnotation inheritedPropertyInitializer_Object_Property;
        private PropertyAnnotation inheritedPropertyInitializer_QualifiedName_Property;
        private PropertyAnnotation inheritedPropertyInitializer_Property_Property;
        private PropertyAnnotation inheritedPropertyInitializer_Expression_Property;
        private ExpressionAnnotation expression_Expression;
        private SymbolTypeAnnotation castExpression_SymbolType;
        private PropertyAnnotation castExpression_TypeReference_Property;
        private PropertyAnnotation castExpression_Expression_Property;
        private SymbolTypeAnnotation typeofExpression_SymbolType;
        private PropertyAnnotation typeofExpression_TypeOfReference_Property;
        private SymbolTypeAnnotation bracketExpression_SymbolType;
        private PropertyAnnotation bracketExpression_Expression_Property;
        private SymbolTypeAnnotation thisExpression_SymbolType;
        private SymbolTypeAnnotation constantExpression_SymbolType;
        private PropertyAnnotation constantExpression_Value_Property;
        private SymbolTypeAnnotation identifierExpression_SymbolType;
        private PropertyAnnotation identifierExpression_Name_Property;
        private SymbolTypeAnnotation indexerExpression_SymbolType;
        private PropertyAnnotation indexerExpression_Expression_Property;
        private PropertyAnnotation indexerExpression_ExpressionList_Property;
        private SymbolTypeAnnotation functionCallExpression_SymbolType;
        private PropertyAnnotation functionCallExpression_Expression_Property;
        private PropertyAnnotation functionCallExpression_ExpressionList_Property;
        private SymbolTypeAnnotation memberAccessExpression_SymbolType;
        private PropertyAnnotation memberAccessExpression_Expression_Property;
        private PropertyAnnotation memberAccessExpression_Name_Property;
        private PropertyAnnotation postExpression_Expression_Property;
        private PropertyAnnotation postExpression_Kind_Property;
        private PropertyAnnotation preExpression_Kind_Property;
        private PropertyAnnotation preExpression_Expression_Property;
        private PropertyAnnotation unaryExpression_Kind_Property;
        private PropertyAnnotation unaryExpression_Expression_Property;
        private SymbolTypeAnnotation typeConversionExpression_SymbolType;
        private PropertyAnnotation typeConversionExpression_Expression_Property;
        private PropertyAnnotation typeConversionExpression_TypeReference_Property;
        private SymbolTypeAnnotation typeCheckExpression_SymbolType;
        private PropertyAnnotation typeCheckExpression_Expression_Property;
        private PropertyAnnotation typeCheckExpression_TypeReference_Property;
        private PropertyAnnotation multiplicativeExpression_Left_Property;
        private PropertyAnnotation multiplicativeExpression_Kind_Property;
        private PropertyAnnotation multiplicativeExpression_Right_Property;
        private PropertyAnnotation additiveExpression_Left_Property;
        private PropertyAnnotation additiveExpression_Kind_Property;
        private PropertyAnnotation additiveExpression_Right_Property;
        private PropertyAnnotation shiftExpression_Left_Property;
        private PropertyAnnotation shiftExpression_Kind_Property;
        private PropertyAnnotation shiftExpression_Right_Property;
        private PropertyAnnotation comparisonExpression_Left_Property;
        private PropertyAnnotation comparisonExpression_Kind_Property;
        private PropertyAnnotation comparisonExpression_Right_Property;
        private PropertyAnnotation equalityExpression_Left_Property;
        private PropertyAnnotation equalityExpression_Kind_Property;
        private PropertyAnnotation equalityExpression_Right_Property;
        private SymbolTypeAnnotation bitwiseAndExpression_SymbolType;
        private PropertyAnnotation bitwiseAndExpression_Left_Property;
        private PropertyAnnotation bitwiseAndExpression_Right_Property;
        private SymbolTypeAnnotation bitwiseXorExpression_SymbolType;
        private PropertyAnnotation bitwiseXorExpression_Left_Property;
        private PropertyAnnotation bitwiseXorExpression_Right_Property;
        private SymbolTypeAnnotation bitwiseOrExpression_SymbolType;
        private PropertyAnnotation bitwiseOrExpression_Left_Property;
        private PropertyAnnotation bitwiseOrExpression_Right_Property;
        private SymbolTypeAnnotation logicalAndExpression_SymbolType;
        private PropertyAnnotation logicalAndExpression_Left_Property;
        private PropertyAnnotation logicalAndExpression_Right_Property;
        private SymbolTypeAnnotation logicalOrExpression_SymbolType;
        private PropertyAnnotation logicalOrExpression_Left_Property;
        private PropertyAnnotation logicalOrExpression_Right_Property;
        private SymbolTypeAnnotation nullCoalescingExpression_SymbolType;
        private PropertyAnnotation nullCoalescingExpression_Left_Property;
        private PropertyAnnotation nullCoalescingExpression_Right_Property;
        private SymbolTypeAnnotation conditionalExpression_SymbolType;
        private PropertyAnnotation conditionalExpression_Condition_Property;
        private PropertyAnnotation conditionalExpression_Then_Property;
        private PropertyAnnotation conditionalExpression_Else_Property;
        private PropertyAnnotation assignmentExpression_Left_Property;
        private PropertyAnnotation assignmentExpression_Operator_Property;
        private PropertyAnnotation assignmentExpression_Right_Property;
        private ExpressionAnnotation newExpression_Expression;
        private SymbolTypeAnnotation newObjectExpression_SymbolType;
        private PropertyAnnotation newObjectExpression_ClassType_Property;
        private PropertyAnnotation newObjectExpression_NewPropertyInitList_Property;
        private SymbolTypeAnnotation newCollectionExpression_SymbolType;
        private PropertyAnnotation newCollectionExpression_CollectionType_Property;
        private PropertyAnnotation newCollectionExpression_ExpressionOrNewExpression_Property;
        private PropertyAnnotation newPropertyInit_Property;
        private PropertyAnnotation newPropertyInit_Identifier_Property;
        private PropertyAnnotation newPropertyInit_ExpressionOrNewExpression_Property;
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
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AnnotationContext), annotList);
            this.annotation_Property = new PropertyAnnotation();
            this.annotation_Property.Name = "Annotations";
            annotList.Add(this.annotation_Property);
            this.annotation_Identifier_Property = new PropertyAnnotation();
            this.annotation_Identifier_Property.Name = "Name";
            
            this.namespaceDeclaration_MetamodelDeclaration_Property = new PropertyAnnotation();
            this.namespaceDeclaration_MetamodelDeclaration_Property.Name = "Models";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EnumDeclarationContext), annotList);
            this.enumDeclaration_Property = new PropertyAnnotation();
            this.enumDeclaration_Property.Name = "Types";
            annotList.Add(this.enumDeclaration_Property);
            this.enumDeclaration_EnumValues_Property = new PropertyAnnotation();
            this.enumDeclaration_EnumValues_Property.Name = "EnumLiterals";
            
            this.enumMemberDeclaration_OperationDeclaration_Property = new PropertyAnnotation();
            this.enumMemberDeclaration_OperationDeclaration_Property.Name = "Operations";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ClassDeclarationContext), annotList);
            this.classDeclaration_Property = new PropertyAnnotation();
            this.classDeclaration_Property.Name = "Types";
            annotList.Add(this.classDeclaration_Property);
            this.classDeclaration_KAbstract_Property = new PropertyAnnotation();
            this.classDeclaration_KAbstract_Property.Name = "IsAbstract";
            this.classDeclaration_KAbstract_Property.Value = true;
            this.classDeclaration_ClassAncestors_Property = new PropertyAnnotation();
            this.classDeclaration_ClassAncestors_Property.Name = "SuperClasses";
            this.classDeclaration_ClassAncestors_InheritScope = new InheritScopeAnnotation();
            
            this.classMemberDeclaration_FieldDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_FieldDeclaration_Property.Name = "Properties";
            this.classMemberDeclaration_OperationDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_OperationDeclaration_Property.Name = "Operations";
            this.classMemberDeclaration_ConstructorDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_ConstructorDeclaration_Property.Name = "Constructor";
            
            this.fieldDeclaration_FieldModifier_Property = new PropertyAnnotation();
            this.fieldDeclaration_FieldModifier_Property.Name = "Kind";
            this.fieldDeclaration_TypeReference_Property = new PropertyAnnotation();
            this.fieldDeclaration_TypeReference_Property.Name = "Type";
            
            this.redefinitions_NameUseList_Property = new PropertyAnnotation();
            this.redefinitions_NameUseList_Property.Name = "RedefinedProperties";
            
            this.subsettings_NameUseList_Property = new PropertyAnnotation();
            this.subsettings_NameUseList_Property.Name = "SubsettedProperties";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConstDeclarationContext), annotList);
            this.constDeclaration_Property = new PropertyAnnotation();
            this.constDeclaration_Property.Name = "Constants";
            annotList.Add(this.constDeclaration_Property);
            this.constDeclaration_TypeReference_Property = new PropertyAnnotation();
            this.constDeclaration_TypeReference_Property.Name = "Type";
            this.constDeclaration_ExpressionOrNewExpression_Property = new PropertyAnnotation();
            this.constDeclaration_ExpressionOrNewExpression_Property.Name = "Value";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.FunctionDeclarationContext), annotList);
            this.functionDeclaration_Property = new PropertyAnnotation();
            this.functionDeclaration_Property.Name = "Functions";
            annotList.Add(this.functionDeclaration_Property);
            this.functionDeclaration_ReturnType_Property = new PropertyAnnotation();
            this.functionDeclaration_ReturnType_Property.Name = "ReturnType";
            this.functionDeclaration_ParameterList_Property = new PropertyAnnotation();
            this.functionDeclaration_ParameterList_Property.Name = "Parameters";
            
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
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.InvisibleTypeContext), annotList);
            this.invisibleType_Name = new NameAnnotation();
            annotList.Add(this.invisibleType_Name);
            this.invisibleType_KAny_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KAny_PreDefSymbol.Value = Meta.Constants.Any;
            this.invisibleType_KNone_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KNone_PreDefSymbol.Value = Meta.Constants.None;
            this.invisibleType_KError_PreDefSymbol = new PreDefSymbolAnnotation();
            this.invisibleType_KError_PreDefSymbol.Value = Meta.Constants.Error;
            
            this.nullableType_PrimitiveType_Property = new PropertyAnnotation();
            this.nullableType_PrimitiveType_Property.Name = "InnerType";
            
            this.collectionType_CollectionKind_Property = new PropertyAnnotation();
            this.collectionType_CollectionKind_Property.Name = "Kind";
            this.collectionType_SimpleType_Property = new PropertyAnnotation();
            this.collectionType_SimpleType_Property.Name = "InnerType";
            
            this.operationDeclaration_ReturnType_Property = new PropertyAnnotation();
            this.operationDeclaration_ReturnType_Property.Name = "ReturnType";
            this.operationDeclaration_ParameterList_Property = new PropertyAnnotation();
            this.operationDeclaration_ParameterList_Property.Name = "Parameters";
            
            this.parameter_TypeReference_Property = new PropertyAnnotation();
            this.parameter_TypeReference_Property.Name = "Type";
            
            this.constructorDeclaration_InitializerDeclaration_Property = new PropertyAnnotation();
            this.constructorDeclaration_InitializerDeclaration_Property.Name = "Initializers";
            
            this.synthetizedPropertyInitializer_QualifiedName_Property = new PropertyAnnotation();
            this.synthetizedPropertyInitializer_QualifiedName_Property.Name = "PropertyContext";
            this.synthetizedPropertyInitializer_Property_Property = new PropertyAnnotation();
            this.synthetizedPropertyInitializer_Property_Property.Name = "PropertyName";
            this.synthetizedPropertyInitializer_Expression_Property = new PropertyAnnotation();
            this.synthetizedPropertyInitializer_Expression_Property.Name = "Value";
            
            this.inheritedPropertyInitializer_Object_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_Object_Property.Name = "ObjectName";
            this.inheritedPropertyInitializer_QualifiedName_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_QualifiedName_Property.Name = "PropertyContext";
            this.inheritedPropertyInitializer_Property_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_Property_Property.Name = "PropertyName";
            this.inheritedPropertyInitializer_Expression_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_Expression_Property.Name = "Value";
            
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
            this.castExpression_TypeReference_Property = new PropertyAnnotation();
            this.castExpression_TypeReference_Property.Name = "TypeReference";
            this.castExpression_Expression_Property = new PropertyAnnotation();
            this.castExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeofExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeofExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeofExpression_SymbolType.SymbolType = typeof(MetaTypeOfExpression);
            annotList.Add(this.typeofExpression_SymbolType);
            this.typeofExpression_TypeOfReference_Property = new PropertyAnnotation();
            this.typeofExpression_TypeOfReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BracketExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bracketExpression_SymbolType = new SymbolTypeAnnotation();
            this.bracketExpression_SymbolType.SymbolType = typeof(MetaBracketExpression);
            annotList.Add(this.bracketExpression_SymbolType);
            this.bracketExpression_Expression_Property = new PropertyAnnotation();
            this.bracketExpression_Expression_Property.Name = "Expression";
            
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
            this.constantExpression_Value_Property = new PropertyAnnotation();
            this.constantExpression_Value_Property.Name = "Value";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.identifierExpression_SymbolType = new SymbolTypeAnnotation();
            this.identifierExpression_SymbolType.SymbolType = typeof(MetaIdentifierExpression);
            annotList.Add(this.identifierExpression_SymbolType);
            this.identifierExpression_Name_Property = new PropertyAnnotation();
            this.identifierExpression_Name_Property.Name = "Name";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IndexerExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.indexerExpression_SymbolType = new SymbolTypeAnnotation();
            this.indexerExpression_SymbolType.SymbolType = typeof(MetaIndexerExpression);
            annotList.Add(this.indexerExpression_SymbolType);
            this.indexerExpression_Expression_Property = new PropertyAnnotation();
            this.indexerExpression_Expression_Property.Name = "Expression";
            this.indexerExpression_ExpressionList_Property = new PropertyAnnotation();
            this.indexerExpression_ExpressionList_Property.Name = "Arguments";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.FunctionCallExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.functionCallExpression_SymbolType = new SymbolTypeAnnotation();
            this.functionCallExpression_SymbolType.SymbolType = typeof(MetaFunctionCallExpression);
            annotList.Add(this.functionCallExpression_SymbolType);
            this.functionCallExpression_Expression_Property = new PropertyAnnotation();
            this.functionCallExpression_Expression_Property.Name = "Expression";
            this.functionCallExpression_ExpressionList_Property = new PropertyAnnotation();
            this.functionCallExpression_ExpressionList_Property.Name = "Arguments";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MemberAccessExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.memberAccessExpression_SymbolType = new SymbolTypeAnnotation();
            this.memberAccessExpression_SymbolType.SymbolType = typeof(MetaMemberAccessExpression);
            annotList.Add(this.memberAccessExpression_SymbolType);
            this.memberAccessExpression_Expression_Property = new PropertyAnnotation();
            this.memberAccessExpression_Expression_Property.Name = "Expression";
            this.memberAccessExpression_Name_Property = new PropertyAnnotation();
            this.memberAccessExpression_Name_Property.Name = "Name";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PostExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.postExpression_Expression_Property = new PropertyAnnotation();
            this.postExpression_Expression_Property.Name = "Expression";
            this.postExpression_Kind_Property = new PropertyAnnotation();
            this.postExpression_Kind_Property.Name = "Kind";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PreExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.preExpression_Kind_Property = new PropertyAnnotation();
            this.preExpression_Kind_Property.Name = "Kind";
            this.preExpression_Expression_Property = new PropertyAnnotation();
            this.preExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.UnaryExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.unaryExpression_Kind_Property = new PropertyAnnotation();
            this.unaryExpression_Kind_Property.Name = "Kind";
            this.unaryExpression_Expression_Property = new PropertyAnnotation();
            this.unaryExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeConversionExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeConversionExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeConversionExpression_SymbolType.SymbolType = typeof(MetaTypeAsExpression);
            annotList.Add(this.typeConversionExpression_SymbolType);
            this.typeConversionExpression_Expression_Property = new PropertyAnnotation();
            this.typeConversionExpression_Expression_Property.Name = "Expression";
            this.typeConversionExpression_TypeReference_Property = new PropertyAnnotation();
            this.typeConversionExpression_TypeReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeCheckExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeCheckExpression_SymbolType = new SymbolTypeAnnotation();
            this.typeCheckExpression_SymbolType.SymbolType = typeof(MetaTypeCheckExpression);
            annotList.Add(this.typeCheckExpression_SymbolType);
            this.typeCheckExpression_Expression_Property = new PropertyAnnotation();
            this.typeCheckExpression_Expression_Property.Name = "Expression";
            this.typeCheckExpression_TypeReference_Property = new PropertyAnnotation();
            this.typeCheckExpression_TypeReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MultiplicativeExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.multiplicativeExpression_Left_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Left_Property.Name = "Left";
            this.multiplicativeExpression_Kind_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Kind_Property.Name = "Kind";
            this.multiplicativeExpression_Right_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AdditiveExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.additiveExpression_Left_Property = new PropertyAnnotation();
            this.additiveExpression_Left_Property.Name = "Left";
            this.additiveExpression_Kind_Property = new PropertyAnnotation();
            this.additiveExpression_Kind_Property.Name = "Kind";
            this.additiveExpression_Right_Property = new PropertyAnnotation();
            this.additiveExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ShiftExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.shiftExpression_Left_Property = new PropertyAnnotation();
            this.shiftExpression_Left_Property.Name = "Left";
            this.shiftExpression_Kind_Property = new PropertyAnnotation();
            this.shiftExpression_Kind_Property.Name = "Kind";
            this.shiftExpression_Right_Property = new PropertyAnnotation();
            this.shiftExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ComparisonExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.comparisonExpression_Left_Property = new PropertyAnnotation();
            this.comparisonExpression_Left_Property.Name = "Left";
            this.comparisonExpression_Kind_Property = new PropertyAnnotation();
            this.comparisonExpression_Kind_Property.Name = "Kind";
            this.comparisonExpression_Right_Property = new PropertyAnnotation();
            this.comparisonExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EqualityExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.equalityExpression_Left_Property = new PropertyAnnotation();
            this.equalityExpression_Left_Property.Name = "Left";
            this.equalityExpression_Kind_Property = new PropertyAnnotation();
            this.equalityExpression_Kind_Property.Name = "Kind";
            this.equalityExpression_Right_Property = new PropertyAnnotation();
            this.equalityExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseAndExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseAndExpression_SymbolType.SymbolType = typeof(MetaAndExpression);
            annotList.Add(this.bitwiseAndExpression_SymbolType);
            this.bitwiseAndExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseAndExpression_Left_Property.Name = "Left";
            this.bitwiseAndExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseAndExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseXorExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseXorExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseXorExpression_SymbolType.SymbolType = typeof(MetaExclusiveOrExpression);
            annotList.Add(this.bitwiseXorExpression_SymbolType);
            this.bitwiseXorExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseXorExpression_Left_Property.Name = "Left";
            this.bitwiseXorExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseXorExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseOrExpression_SymbolType = new SymbolTypeAnnotation();
            this.bitwiseOrExpression_SymbolType.SymbolType = typeof(MetaOrExpression);
            annotList.Add(this.bitwiseOrExpression_SymbolType);
            this.bitwiseOrExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseOrExpression_Left_Property.Name = "Left";
            this.bitwiseOrExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseOrExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalAndExpression_SymbolType = new SymbolTypeAnnotation();
            this.logicalAndExpression_SymbolType.SymbolType = typeof(MetaAndAlsoExpression);
            annotList.Add(this.logicalAndExpression_SymbolType);
            this.logicalAndExpression_Left_Property = new PropertyAnnotation();
            this.logicalAndExpression_Left_Property.Name = "Left";
            this.logicalAndExpression_Right_Property = new PropertyAnnotation();
            this.logicalAndExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalOrExpression_SymbolType = new SymbolTypeAnnotation();
            this.logicalOrExpression_SymbolType.SymbolType = typeof(MetaOrElseExpression);
            annotList.Add(this.logicalOrExpression_SymbolType);
            this.logicalOrExpression_Left_Property = new PropertyAnnotation();
            this.logicalOrExpression_Left_Property.Name = "Left";
            this.logicalOrExpression_Right_Property = new PropertyAnnotation();
            this.logicalOrExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NullCoalescingExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.nullCoalescingExpression_SymbolType = new SymbolTypeAnnotation();
            this.nullCoalescingExpression_SymbolType.SymbolType = typeof(MetaNullCoalescingExpression);
            annotList.Add(this.nullCoalescingExpression_SymbolType);
            this.nullCoalescingExpression_Left_Property = new PropertyAnnotation();
            this.nullCoalescingExpression_Left_Property.Name = "Left";
            this.nullCoalescingExpression_Right_Property = new PropertyAnnotation();
            this.nullCoalescingExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConditionalExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.conditionalExpression_SymbolType = new SymbolTypeAnnotation();
            this.conditionalExpression_SymbolType.SymbolType = typeof(MetaConditionalExpression);
            annotList.Add(this.conditionalExpression_SymbolType);
            this.conditionalExpression_Condition_Property = new PropertyAnnotation();
            this.conditionalExpression_Condition_Property.Name = "Condition";
            this.conditionalExpression_Then_Property = new PropertyAnnotation();
            this.conditionalExpression_Then_Property.Name = "Then";
            this.conditionalExpression_Else_Property = new PropertyAnnotation();
            this.conditionalExpression_Else_Property.Name = "Else";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AssignmentExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.assignmentExpression_Left_Property = new PropertyAnnotation();
            this.assignmentExpression_Left_Property.Name = "Left";
            this.assignmentExpression_Operator_Property = new PropertyAnnotation();
            this.assignmentExpression_Operator_Property.Name = "Operator";
            this.assignmentExpression_Right_Property = new PropertyAnnotation();
            this.assignmentExpression_Right_Property.Name = "Right";
            
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
            this.newObjectExpression_ClassType_Property = new PropertyAnnotation();
            this.newObjectExpression_ClassType_Property.Name = "TypeReference";
            this.newObjectExpression_NewPropertyInitList_Property = new PropertyAnnotation();
            this.newObjectExpression_NewPropertyInitList_Property.Name = "NewPropertyInitList";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NewCollectionExpressionContext), annotList);
            annotList.Add(this.newExpression_Expression);
            this.newCollectionExpression_SymbolType = new SymbolTypeAnnotation();
            this.newCollectionExpression_SymbolType.SymbolType = typeof(MetaNewCollectionExpression);
            annotList.Add(this.newCollectionExpression_SymbolType);
            this.newCollectionExpression_CollectionType_Property = new PropertyAnnotation();
            this.newCollectionExpression_CollectionType_Property.Name = "TypeReference";
            this.newCollectionExpression_ExpressionOrNewExpression_Property = new PropertyAnnotation();
            this.newCollectionExpression_ExpressionOrNewExpression_Property.Name = "Values";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NewPropertyInitContext), annotList);
            this.newPropertyInit_Property = new PropertyAnnotation();
            this.newPropertyInit_Property.Name = "PropertyInitializers";
            annotList.Add(this.newPropertyInit_Property);
            this.newPropertyInit_Identifier_Property = new PropertyAnnotation();
            this.newPropertyInit_Identifier_Property.Name = "PropertyName";
            this.newPropertyInit_ExpressionOrNewExpression_Property = new PropertyAnnotation();
            this.newPropertyInit_ExpressionOrNewExpression_Property.Name = "Value";
            
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
            treeAnnotList.Add(this.annotation_Property);
            SymbolAnnotation __tmp1 = new SymbolAnnotation();
            __tmp1.SymbolType = typeof(MetaAnnotation);
            treeAnnotList.Add(__tmp1);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.annotation_Identifier_Property);
                ValueAnnotation __tmp2 = new ValueAnnotation();
                elemAnnotList.Add(__tmp2);
            }
            this.HandleSymbolType(context);
            return base.VisitAnnotation(context);
        }
        
        public override object VisitNamespaceDeclaration(MetaModelParser.NamespaceDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp3 = new NameDefAnnotation();
            __tmp3.SymbolType = typeof(MetaNamespace);
            __tmp3.NestingProperty = "Namespaces";
            __tmp3.Merge = true;
            treeAnnotList.Add(__tmp3);
            List<object> elemAnnotList = null;
            if (context.metamodelDeclaration() != null)
            {
                foreach(object elem in context.metamodelDeclaration())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    elemAnnotList.Add(this.namespaceDeclaration_MetamodelDeclaration_Property);
                }
            }
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
            NameDefAnnotation __tmp4 = new NameDefAnnotation();
            __tmp4.SymbolType = typeof(MetaModel);
            treeAnnotList.Add(__tmp4);
            this.HandleSymbolType(context);
            return base.VisitMetamodelDeclaration(context);
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
            treeAnnotList.Add(this.enumDeclaration_Property);
            TypeDefAnnotation __tmp5 = new TypeDefAnnotation();
            __tmp5.SymbolType = typeof(MetaEnum);
            treeAnnotList.Add(__tmp5);
            List<object> elemAnnotList = null;
            if (context.enumValues() != null)
            {
                object elem = context.enumValues();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.enumDeclaration_EnumValues_Property);
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
            NameDefAnnotation __tmp6 = new NameDefAnnotation();
            __tmp6.SymbolType = typeof(MetaEnumLiteral);
            treeAnnotList.Add(__tmp6);
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
                elemAnnotList.Add(this.enumMemberDeclaration_OperationDeclaration_Property);
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
            treeAnnotList.Add(this.classDeclaration_Property);
            TypeDefAnnotation __tmp7 = new TypeDefAnnotation();
            __tmp7.SymbolType = typeof(MetaClass);
            treeAnnotList.Add(__tmp7);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.classDeclaration_KAbstract_Property);
            }
            if (context.classAncestors() != null)
            {
                object elem = context.classAncestors();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.classDeclaration_ClassAncestors_Property);
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
                TypeUseAnnotation __tmp8 = new TypeUseAnnotation();
                __tmp8.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp8);
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
                elemAnnotList.Add(this.classMemberDeclaration_FieldDeclaration_Property);
            }
            if (context.operationDeclaration() != null)
            {
                object elem = context.operationDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.classMemberDeclaration_OperationDeclaration_Property);
            }
            if (context.constructorDeclaration() != null)
            {
                object elem = context.constructorDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.classMemberDeclaration_ConstructorDeclaration_Property);
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
            NameDefAnnotation __tmp9 = new NameDefAnnotation();
            __tmp9.SymbolType = typeof(MetaProperty);
            treeAnnotList.Add(__tmp9);
            List<object> elemAnnotList = null;
            if (context.fieldModifier() != null)
            {
                object elem = context.fieldModifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.fieldDeclaration_FieldModifier_Property);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.fieldDeclaration_TypeReference_Property);
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
                ValueAnnotation __tmp10 = new ValueAnnotation();
                __tmp10.Value = MetaPropertyKind.Containment;
                elemAnnotList.Add(__tmp10);
            }
            if (context.KReadonly() != null)
            {
                object elem = context.KReadonly();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp11 = new ValueAnnotation();
                __tmp11.Value = MetaPropertyKind.Readonly;
                elemAnnotList.Add(__tmp11);
            }
            if (context.KLazy() != null)
            {
                object elem = context.KLazy();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp12 = new ValueAnnotation();
                __tmp12.Value = MetaPropertyKind.Lazy;
                elemAnnotList.Add(__tmp12);
            }
            if (context.KDerived() != null)
            {
                object elem = context.KDerived();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp13 = new ValueAnnotation();
                __tmp13.Value = MetaPropertyKind.Derived;
                elemAnnotList.Add(__tmp13);
            }
            if (context.KSynthetized() != null)
            {
                object elem = context.KSynthetized();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp14 = new ValueAnnotation();
                __tmp14.Value = MetaPropertyKind.Synthetized;
                elemAnnotList.Add(__tmp14);
            }
            if (context.KInherited() != null)
            {
                object elem = context.KInherited();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp15 = new ValueAnnotation();
                __tmp15.Value = MetaPropertyKind.Inherited;
                elemAnnotList.Add(__tmp15);
            }
            this.HandleSymbolType(context);
            return base.VisitFieldModifier(context);
        }
        
        public override object VisitRedefinitions(MetaModelParser.RedefinitionsContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ScopeAnnotation __tmp16 = new ScopeAnnotation();
            treeAnnotList.Add(__tmp16);
            List<object> elemAnnotList = null;
            if (context.nameUseList() != null)
            {
                object elem = context.nameUseList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.redefinitions_NameUseList_Property);
            }
            this.HandleSymbolType(context);
            return base.VisitRedefinitions(context);
        }
        
        public override object VisitSubsettings(MetaModelParser.SubsettingsContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ScopeAnnotation __tmp17 = new ScopeAnnotation();
            treeAnnotList.Add(__tmp17);
            List<object> elemAnnotList = null;
            if (context.nameUseList() != null)
            {
                object elem = context.nameUseList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.subsettings_NameUseList_Property);
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
                    NameUseAnnotation __tmp18 = new NameUseAnnotation();
                    __tmp18.SymbolTypes.Add(typeof(MetaProperty));
                    elemAnnotList.Add(__tmp18);
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
            treeAnnotList.Add(this.constDeclaration_Property);
            NameDefAnnotation __tmp19 = new NameDefAnnotation();
            __tmp19.SymbolType = typeof(MetaConstant);
            treeAnnotList.Add(__tmp19);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.constDeclaration_TypeReference_Property);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.constDeclaration_ExpressionOrNewExpression_Property);
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
            treeAnnotList.Add(this.functionDeclaration_Property);
            NameDefAnnotation __tmp20 = new NameDefAnnotation();
            __tmp20.SymbolType = typeof(MetaFunction);
            treeAnnotList.Add(__tmp20);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.functionDeclaration_ReturnType_Property);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.functionDeclaration_ParameterList_Property);
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
            TypeUseAnnotation __tmp21 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp21);
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
            TypeUseAnnotation __tmp22 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp22);
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
            TypeUseAnnotation __tmp23 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp23);
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
            TypeUseAnnotation __tmp24 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp24);
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
            TypeUseAnnotation __tmp25 = new TypeUseAnnotation();
            __tmp25.SymbolTypes.Add(typeof(MetaClass));
            treeAnnotList.Add(__tmp25);
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
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.invisibleType_Name);
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
            TypeCtrAnnotation __tmp26 = new TypeCtrAnnotation();
            __tmp26.SymbolType = typeof(MetaNullableType);
            treeAnnotList.Add(__tmp26);
            List<object> elemAnnotList = null;
            if (context.primitiveType() != null)
            {
                object elem = context.primitiveType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.nullableType_PrimitiveType_Property);
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
            TypeCtrAnnotation __tmp27 = new TypeCtrAnnotation();
            __tmp27.SymbolType = typeof(MetaCollectionType);
            treeAnnotList.Add(__tmp27);
            List<object> elemAnnotList = null;
            if (context.collectionKind() != null)
            {
                object elem = context.collectionKind();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.collectionType_CollectionKind_Property);
            }
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.collectionType_SimpleType_Property);
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
                ValueAnnotation __tmp28 = new ValueAnnotation();
                __tmp28.Value = MetaCollectionKind.Set;
                elemAnnotList.Add(__tmp28);
            }
            if (context.KList() != null)
            {
                object elem = context.KList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp29 = new ValueAnnotation();
                __tmp29.Value = MetaCollectionKind.List;
                elemAnnotList.Add(__tmp29);
            }
            if (context.KMultiSet() != null)
            {
                object elem = context.KMultiSet();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp30 = new ValueAnnotation();
                __tmp30.Value = MetaCollectionKind.MultiSet;
                elemAnnotList.Add(__tmp30);
            }
            if (context.KMultiList() != null)
            {
                object elem = context.KMultiList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp31 = new ValueAnnotation();
                __tmp31.Value = MetaCollectionKind.MultiList;
                elemAnnotList.Add(__tmp31);
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
            NameDefAnnotation __tmp32 = new NameDefAnnotation();
            __tmp32.SymbolType = typeof(MetaOperation);
            treeAnnotList.Add(__tmp32);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.operationDeclaration_ReturnType_Property);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.operationDeclaration_ParameterList_Property);
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
            NameDefAnnotation __tmp33 = new NameDefAnnotation();
            __tmp33.SymbolType = typeof(MetaParameter);
            treeAnnotList.Add(__tmp33);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.parameter_TypeReference_Property);
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
            NameDefAnnotation __tmp34 = new NameDefAnnotation();
            __tmp34.SymbolType = typeof(MetaConstructor);
            treeAnnotList.Add(__tmp34);
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
                    elemAnnotList.Add(this.constructorDeclaration_InitializerDeclaration_Property);
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
            SymbolAnnotation __tmp35 = new SymbolAnnotation();
            __tmp35.SymbolType = typeof(MetaSynthetizedPropertyInitializer);
            treeAnnotList.Add(__tmp35);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.synthetizedPropertyInitializer_QualifiedName_Property);
                TypeUseAnnotation __tmp36 = new TypeUseAnnotation();
                __tmp36.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp36);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.synthetizedPropertyInitializer_Property_Property);
                ValueAnnotation __tmp37 = new ValueAnnotation();
                elemAnnotList.Add(__tmp37);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.synthetizedPropertyInitializer_Expression_Property);
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
            SymbolAnnotation __tmp38 = new SymbolAnnotation();
            __tmp38.SymbolType = typeof(MetaInheritedPropertyInitializer);
            treeAnnotList.Add(__tmp38);
            List<object> elemAnnotList = null;
            if (context.@object != null)
            {
                object elem = context.@object;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.inheritedPropertyInitializer_Object_Property);
                ValueAnnotation __tmp39 = new ValueAnnotation();
                elemAnnotList.Add(__tmp39);
            }
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.inheritedPropertyInitializer_QualifiedName_Property);
                TypeUseAnnotation __tmp40 = new TypeUseAnnotation();
                __tmp40.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp40);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.inheritedPropertyInitializer_Property_Property);
                ValueAnnotation __tmp41 = new ValueAnnotation();
                elemAnnotList.Add(__tmp41);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.inheritedPropertyInitializer_Expression_Property);
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
            SymbolAnnotation __tmp42 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp42);
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
                elemAnnotList.Add(this.castExpression_TypeReference_Property);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.castExpression_Expression_Property);
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
            SymbolAnnotation __tmp43 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp43);
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
                elemAnnotList.Add(this.typeofExpression_TypeOfReference_Property);
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
            SymbolAnnotation __tmp44 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp44);
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
                elemAnnotList.Add(this.bracketExpression_Expression_Property);
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
            SymbolAnnotation __tmp45 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp45);
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
            SymbolAnnotation __tmp46 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp46);
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
                elemAnnotList.Add(this.constantExpression_Value_Property);
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
            SymbolAnnotation __tmp47 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp47);
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
                ValueAnnotation __tmp48 = new ValueAnnotation();
                elemAnnotList.Add(__tmp48);
                elemAnnotList.Add(this.identifierExpression_Name_Property);
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
            SymbolAnnotation __tmp49 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp49);
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
                elemAnnotList.Add(this.indexerExpression_Expression_Property);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.indexerExpression_ExpressionList_Property);
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
            SymbolAnnotation __tmp50 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp50);
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
                elemAnnotList.Add(this.functionCallExpression_Expression_Property);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.functionCallExpression_ExpressionList_Property);
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
            SymbolAnnotation __tmp51 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp51);
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
                elemAnnotList.Add(this.memberAccessExpression_Expression_Property);
            }
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp52 = new ValueAnnotation();
                elemAnnotList.Add(__tmp52);
                elemAnnotList.Add(this.memberAccessExpression_Name_Property);
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
            SymbolAnnotation __tmp53 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp53);
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
                elemAnnotList.Add(this.postExpression_Expression_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.postExpression_Kind_Property);
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
            SymbolAnnotation __tmp54 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp54);
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
                elemAnnotList.Add(this.preExpression_Kind_Property);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.preExpression_Expression_Property);
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
            SymbolAnnotation __tmp55 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp55);
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
                elemAnnotList.Add(this.unaryExpression_Kind_Property);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.unaryExpression_Expression_Property);
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
            SymbolAnnotation __tmp56 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp56);
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
                elemAnnotList.Add(this.typeConversionExpression_Expression_Property);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.typeConversionExpression_TypeReference_Property);
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
            SymbolAnnotation __tmp57 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp57);
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
                elemAnnotList.Add(this.typeCheckExpression_Expression_Property);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.typeCheckExpression_TypeReference_Property);
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
            SymbolAnnotation __tmp58 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp58);
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
                elemAnnotList.Add(this.multiplicativeExpression_Left_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.multiplicativeExpression_Kind_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.multiplicativeExpression_Right_Property);
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
            SymbolAnnotation __tmp59 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp59);
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
                elemAnnotList.Add(this.additiveExpression_Left_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.additiveExpression_Kind_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.additiveExpression_Right_Property);
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
            SymbolAnnotation __tmp60 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp60);
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
                elemAnnotList.Add(this.shiftExpression_Left_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.shiftExpression_Kind_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.shiftExpression_Right_Property);
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
            SymbolAnnotation __tmp61 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp61);
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
                elemAnnotList.Add(this.comparisonExpression_Left_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonExpression_Kind_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.comparisonExpression_Right_Property);
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
            SymbolAnnotation __tmp62 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp62);
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
                elemAnnotList.Add(this.equalityExpression_Left_Property);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.equalityExpression_Kind_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.equalityExpression_Right_Property);
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
            SymbolAnnotation __tmp63 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp63);
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
                elemAnnotList.Add(this.bitwiseAndExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.bitwiseAndExpression_Right_Property);
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
            SymbolAnnotation __tmp64 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp64);
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
                elemAnnotList.Add(this.bitwiseXorExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.bitwiseXorExpression_Right_Property);
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
            SymbolAnnotation __tmp65 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp65);
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
                elemAnnotList.Add(this.bitwiseOrExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.bitwiseOrExpression_Right_Property);
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
            SymbolAnnotation __tmp66 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp66);
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
                elemAnnotList.Add(this.logicalAndExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.logicalAndExpression_Right_Property);
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
            SymbolAnnotation __tmp67 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp67);
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
                elemAnnotList.Add(this.logicalOrExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.logicalOrExpression_Right_Property);
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
            SymbolAnnotation __tmp68 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp68);
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
                elemAnnotList.Add(this.nullCoalescingExpression_Left_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.nullCoalescingExpression_Right_Property);
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
            SymbolAnnotation __tmp69 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp69);
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
                elemAnnotList.Add(this.conditionalExpression_Condition_Property);
            }
            if (context.then != null)
            {
                object elem = context.then;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.conditionalExpression_Then_Property);
            }
            if (context.@else != null)
            {
                object elem = context.@else;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.conditionalExpression_Else_Property);
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
            SymbolAnnotation __tmp70 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp70);
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
                elemAnnotList.Add(this.assignmentExpression_Left_Property);
            }
            if (context.@operator != null)
            {
                object elem = context.@operator;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentExpression_Operator_Property);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.assignmentExpression_Right_Property);
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
            SymbolAnnotation __tmp71 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp71);
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
                elemAnnotList.Add(this.newObjectExpression_ClassType_Property);
            }
            if (context.newPropertyInitList() != null)
            {
                object elem = context.newPropertyInitList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.newObjectExpression_NewPropertyInitList_Property);
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
            SymbolAnnotation __tmp72 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp72);
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
                elemAnnotList.Add(this.newCollectionExpression_CollectionType_Property);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.newCollectionExpression_ExpressionOrNewExpression_Property);
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
            treeAnnotList.Add(this.newPropertyInit_Property);
            SymbolAnnotation __tmp73 = new SymbolAnnotation();
            __tmp73.SymbolType = typeof(MetaNewPropertyInitializer);
            treeAnnotList.Add(__tmp73);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.newPropertyInit_Identifier_Property);
                ValueAnnotation __tmp74 = new ValueAnnotation();
                elemAnnotList.Add(__tmp74);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.newPropertyInit_ExpressionOrNewExpression_Property);
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
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            ScopeAnnotation __tmp75 = new ScopeAnnotation();
            treeAnnotList.Add(__tmp75);
            List<object> elemAnnotList = null;
            if (context.source != null)
            {
                object elem = context.source;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp76 = new NameUseAnnotation();
                __tmp76.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp76);
            }
            if (context.target != null)
            {
                object elem = context.target;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp77 = new NameUseAnnotation();
                __tmp77.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp77);
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
                SymbolAnnotation __tmp78 = new SymbolAnnotation();
                __tmp78.SymbolType = typeof(MetaNullExpression);
                elemAnnotList.Add(__tmp78);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp79 = new ValueAnnotation();
                elemAnnotList.Add(__tmp79);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp80 = new ValueAnnotation();
                elemAnnotList.Add(__tmp80);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp81 = new ValueAnnotation();
                elemAnnotList.Add(__tmp81);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp82 = new ValueAnnotation();
                elemAnnotList.Add(__tmp82);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp83 = new ValueAnnotation();
                elemAnnotList.Add(__tmp83);
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
        
        public virtual object VisitNamespaceDeclaration(MetaModelParser.NamespaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitMetamodelDeclaration(MetaModelParser.MetamodelDeclarationContext context)
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

