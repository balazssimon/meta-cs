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
        private NameDefAnnotation namespaceDeclaration_NameDef;
        private PropertyAnnotation namespaceDeclaration_MetamodelDeclaration_Property;
        private NameDefAnnotation metamodelDeclaration_NameDef;
        private PropertyAnnotation metamodelDeclaration_Declaration_Property;
        private TypeDefAnnotation enumDeclaration_TypeDef;
        private PropertyAnnotation enumDeclaration_EnumValues_Property;
        private NameDefAnnotation enumValue_NameDef;
        private PropertyAnnotation enumMemberDeclaration_OperationDeclaration_Property;
        private TypeDefAnnotation classDeclaration_TypeDef;
        private PropertyAnnotation classDeclaration_KAbstract_Property;
        private PropertyAnnotation classDeclaration_ClassAncestors_Property;
        private InheritScopeAnnotation classDeclaration_ClassAncestors_InheritScope;
        private TypeUseAnnotation classAncestor_QualifiedName_TypeUse;
        private PropertyAnnotation classMemberDeclaration_FieldDeclaration_Property;
        private PropertyAnnotation classMemberDeclaration_OperationDeclaration_Property;
        private PropertyAnnotation classMemberDeclaration_ConstructorDeclaration_Property;
        private NameDefAnnotation fieldDeclaration_NameDef;
        private PropertyAnnotation fieldDeclaration_FieldModifier_Property;
        private PropertyAnnotation fieldDeclaration_TypeReference_Property;
        private ScopeAnnotation redefinitions_Scope;
        private PropertyAnnotation redefinitions_NameUseList_Property;
        private ScopeAnnotation subsettings_Scope;
        private PropertyAnnotation subsettings_NameUseList_Property;
        private NameUseAnnotation nameUseList_QualifiedName_NameUse;
        private TypeUseAnnotation returnType_TypeUse;
        private TypeUseAnnotation typeReference_TypeUse;
        private TypeUseAnnotation simpleType_TypeUse;
        private NameAnnotation objectType_Name;
        private PreDefSymbolAnnotation objectType_KObject_PreDefSymbol;
        private PreDefSymbolAnnotation objectType_KString_PreDefSymbol;
        private NameAnnotation primitiveType_Name;
        private PreDefSymbolAnnotation primitiveType_KInt_PreDefSymbol;
        private PreDefSymbolAnnotation primitiveType_KLong_PreDefSymbol;
        private PreDefSymbolAnnotation primitiveType_KFloat_PreDefSymbol;
        private PreDefSymbolAnnotation primitiveType_KDouble_PreDefSymbol;
        private PreDefSymbolAnnotation primitiveType_KByte_PreDefSymbol;
        private PreDefSymbolAnnotation primitiveType_KBool_PreDefSymbol;
        private NameAnnotation voidType_Name;
        private PreDefSymbolAnnotation voidType_KVoid_PreDefSymbol;
        private TypeCtrAnnotation nullableType_TypeCtr;
        private PropertyAnnotation nullableType_PrimitiveType_Property;
        private TypeCtrAnnotation collectionType_TypeCtr;
        private PropertyAnnotation collectionType_CollectionKind_Property;
        private PropertyAnnotation collectionType_SimpleType_Property;
        private NameDefAnnotation operationDeclaration_NameDef;
        private PropertyAnnotation operationDeclaration_ReturnType_Property;
        private PropertyAnnotation operationDeclaration_ParameterList_Property;
        private NameDefAnnotation parameter_NameDef;
        private PropertyAnnotation parameter_TypeReference_Property;
        private NameDefAnnotation constructorDeclaration_NameDef;
        private PropertyAnnotation constructorDeclaration_InitializerDeclaration_Property;
        private SymbolAnnotation synthetizedPropertyInitializer_Symbol;
        private PropertyAnnotation synthetizedPropertyInitializer_Property_Property;
        private NameUseAnnotation synthetizedPropertyInitializer_Property_NameUse;
        private PropertyAnnotation synthetizedPropertyInitializer_Expression_Property;
        private SymbolAnnotation inheritedPropertyInitializer_Symbol;
        private PropertyAnnotation inheritedPropertyInitializer_Object_Property;
        private NameUseAnnotation inheritedPropertyInitializer_Object_NameUse;
        private PropertyAnnotation inheritedPropertyInitializer_Expression_Property;
        private ExpressionAnnotation expression_Expression;
        private SymbolAnnotation castExpression_Symbol;
        private PropertyAnnotation castExpression_TypeReference_Property;
        private PropertyAnnotation castExpression_Expression_Property;
        private SymbolAnnotation typeofExpression_Symbol;
        private PropertyAnnotation typeofExpression_TypeReference_Property;
        private SymbolAnnotation bracketExpression_Symbol;
        private PropertyAnnotation bracketExpression_Expression_Property;
        private SymbolAnnotation thisExpression_Symbol;
        private SymbolAnnotation constantExpression_Symbol;
        private PropertyAnnotation constantExpression_Value_Property;
        private SymbolAnnotation identifierExpression_Symbol;
        private PropertyAnnotation identifierExpression_Name_Property;
        private SymbolAnnotation indexerExpression_Symbol;
        private PropertyAnnotation indexerExpression_Expression_Property;
        private PropertyAnnotation indexerExpression_ArgumentList_Property;
        private SymbolAnnotation functionCallExpression_Symbol;
        private PropertyAnnotation functionCallExpression_Expression_Property;
        private PropertyAnnotation functionCallExpression_ArgumentList_Property;
        private SymbolAnnotation memberAccessExpression_Symbol;
        private PropertyAnnotation memberAccessExpression_Expression_Property;
        private PropertyAnnotation memberAccessExpression_Name_Property;
        private SymbolAnnotation postExpression_Symbol;
        private PropertyAnnotation postExpression_Expression_Property;
        private PropertyAnnotation postExpression_Kind_Property;
        private SymbolAnnotation preExpression_Symbol;
        private PropertyAnnotation preExpression_Kind_Property;
        private PropertyAnnotation preExpression_Expression_Property;
        private SymbolAnnotation unaryExpression_Symbol;
        private PropertyAnnotation unaryExpression_Kind_Property;
        private PropertyAnnotation unaryExpression_Expression_Property;
        private SymbolAnnotation typeConversionExpression_Symbol;
        private PropertyAnnotation typeConversionExpression_Expression_Property;
        private PropertyAnnotation typeConversionExpression_TypeReference_Property;
        private SymbolAnnotation typeCheckExpression_Symbol;
        private PropertyAnnotation typeCheckExpression_Expression_Property;
        private PropertyAnnotation typeCheckExpression_TypeReference_Property;
        private SymbolAnnotation multiplicativeExpression_Symbol;
        private PropertyAnnotation multiplicativeExpression_Left_Property;
        private PropertyAnnotation multiplicativeExpression_Kind_Property;
        private PropertyAnnotation multiplicativeExpression_Right_Property;
        private SymbolAnnotation additiveExpression_Symbol;
        private PropertyAnnotation additiveExpression_Left_Property;
        private PropertyAnnotation additiveExpression_Kind_Property;
        private PropertyAnnotation additiveExpression_Right_Property;
        private SymbolAnnotation shiftExpression_Symbol;
        private PropertyAnnotation shiftExpression_Left_Property;
        private PropertyAnnotation shiftExpression_Kind_Property;
        private PropertyAnnotation shiftExpression_Right_Property;
        private SymbolAnnotation comparisonExpression_Symbol;
        private PropertyAnnotation comparisonExpression_Left_Property;
        private PropertyAnnotation comparisonExpression_Kind_Property;
        private PropertyAnnotation comparisonExpression_Right_Property;
        private SymbolAnnotation equalityExpression_Symbol;
        private PropertyAnnotation equalityExpression_Left_Property;
        private PropertyAnnotation equalityExpression_Kind_Property;
        private PropertyAnnotation equalityExpression_Right_Property;
        private SymbolAnnotation bitwiseAndExpression_Symbol;
        private PropertyAnnotation bitwiseAndExpression_Left_Property;
        private PropertyAnnotation bitwiseAndExpression_Right_Property;
        private SymbolAnnotation bitwiseXorExpression_Symbol;
        private PropertyAnnotation bitwiseXorExpression_Left_Property;
        private PropertyAnnotation bitwiseXorExpression_Right_Property;
        private SymbolAnnotation bitwiseOrExpression_Symbol;
        private PropertyAnnotation bitwiseOrExpression_Left_Property;
        private PropertyAnnotation bitwiseOrExpression_Right_Property;
        private SymbolAnnotation logicalAndExpression_Symbol;
        private PropertyAnnotation logicalAndExpression_Left_Property;
        private PropertyAnnotation logicalAndExpression_Right_Property;
        private SymbolAnnotation logicalOrExpression_Symbol;
        private PropertyAnnotation logicalOrExpression_Left_Property;
        private PropertyAnnotation logicalOrExpression_Right_Property;
        private SymbolAnnotation nullCoalescingExpression_Symbol;
        private PropertyAnnotation nullCoalescingExpression_Left_Property;
        private PropertyAnnotation nullCoalescingExpression_Right_Property;
        private SymbolAnnotation conditionalExpression_Symbol;
        private PropertyAnnotation conditionalExpression_Condition_Property;
        private PropertyAnnotation conditionalExpression_Then_Property;
        private PropertyAnnotation conditionalExpression_Else_Property;
        private SymbolAnnotation assignmentExpression_Symbol;
        private PropertyAnnotation assignmentExpression_Left_Property;
        private PropertyAnnotation assignmentExpression_Operator_Property;
        private PropertyAnnotation assignmentExpression_Right_Property;
        private ScopeAnnotation associationDeclaration_Scope;
        private NameUseAnnotation associationDeclaration_Source_NameUse;
        private NameUseAnnotation associationDeclaration_Target_NameUse;
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
            this.ruleAnnotations.Add(typeof(MetaModelParser.NamespaceDeclarationContext), annotList);
            this.namespaceDeclaration_NameDef = new NameDefAnnotation();
            this.namespaceDeclaration_NameDef.SymbolType = typeof(MetaNamespace);
            this.namespaceDeclaration_NameDef.NestingProperty = "Namespaces";
            this.namespaceDeclaration_NameDef.Scope = true;
            this.namespaceDeclaration_NameDef.Merge = true;
            annotList.Add(this.namespaceDeclaration_NameDef);
            this.namespaceDeclaration_MetamodelDeclaration_Property = new PropertyAnnotation();
            this.namespaceDeclaration_MetamodelDeclaration_Property.Name = "Models";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MetamodelDeclarationContext), annotList);
            this.metamodelDeclaration_NameDef = new NameDefAnnotation();
            this.metamodelDeclaration_NameDef.SymbolType = typeof(MetaModel);
            annotList.Add(this.metamodelDeclaration_NameDef);
            this.metamodelDeclaration_Declaration_Property = new PropertyAnnotation();
            this.metamodelDeclaration_Declaration_Property.Name = "Types";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EnumDeclarationContext), annotList);
            this.enumDeclaration_TypeDef = new TypeDefAnnotation();
            this.enumDeclaration_TypeDef.SymbolType = typeof(MetaEnum);
            annotList.Add(this.enumDeclaration_TypeDef);
            this.enumDeclaration_EnumValues_Property = new PropertyAnnotation();
            this.enumDeclaration_EnumValues_Property.Name = "EnumLiterals";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EnumValueContext), annotList);
            this.enumValue_NameDef = new NameDefAnnotation();
            this.enumValue_NameDef.SymbolType = typeof(MetaEnumLiteral);
            annotList.Add(this.enumValue_NameDef);
            
            this.enumMemberDeclaration_OperationDeclaration_Property = new PropertyAnnotation();
            this.enumMemberDeclaration_OperationDeclaration_Property.Name = "Operations";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ClassDeclarationContext), annotList);
            this.classDeclaration_TypeDef = new TypeDefAnnotation();
            this.classDeclaration_TypeDef.SymbolType = typeof(MetaClass);
            annotList.Add(this.classDeclaration_TypeDef);
            this.classDeclaration_KAbstract_Property = new PropertyAnnotation();
            this.classDeclaration_KAbstract_Property.Name = "IsAbstract";
            this.classDeclaration_KAbstract_Property.Value = true;
            this.classDeclaration_ClassAncestors_Property = new PropertyAnnotation();
            this.classDeclaration_ClassAncestors_Property.Name = "SuperClasses";
            this.classDeclaration_ClassAncestors_InheritScope = new InheritScopeAnnotation();
            
            this.classAncestor_QualifiedName_TypeUse = new TypeUseAnnotation();
            this.classAncestor_QualifiedName_TypeUse.SymbolTypes.Add(typeof(MetaClass));
            
            this.classMemberDeclaration_FieldDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_FieldDeclaration_Property.Name = "Properties";
            this.classMemberDeclaration_OperationDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_OperationDeclaration_Property.Name = "Operations";
            this.classMemberDeclaration_ConstructorDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_ConstructorDeclaration_Property.Name = "Constructor";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.FieldDeclarationContext), annotList);
            this.fieldDeclaration_NameDef = new NameDefAnnotation();
            this.fieldDeclaration_NameDef.SymbolType = typeof(MetaProperty);
            annotList.Add(this.fieldDeclaration_NameDef);
            this.fieldDeclaration_FieldModifier_Property = new PropertyAnnotation();
            this.fieldDeclaration_FieldModifier_Property.Name = "Kind";
            this.fieldDeclaration_TypeReference_Property = new PropertyAnnotation();
            this.fieldDeclaration_TypeReference_Property.Name = "Type";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.RedefinitionsContext), annotList);
            this.redefinitions_Scope = new ScopeAnnotation();
            annotList.Add(this.redefinitions_Scope);
            this.redefinitions_NameUseList_Property = new PropertyAnnotation();
            this.redefinitions_NameUseList_Property.Name = "RedefinedProperties";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.SubsettingsContext), annotList);
            this.subsettings_Scope = new ScopeAnnotation();
            annotList.Add(this.subsettings_Scope);
            this.subsettings_NameUseList_Property = new PropertyAnnotation();
            this.subsettings_NameUseList_Property.Name = "SubsettedProperties";
            
            this.nameUseList_QualifiedName_NameUse = new NameUseAnnotation();
            this.nameUseList_QualifiedName_NameUse.SymbolTypes.Add(typeof(MetaProperty));
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ReturnTypeContext), annotList);
            this.returnType_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.returnType_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeReferenceContext), annotList);
            this.typeReference_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.typeReference_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.SimpleTypeContext), annotList);
            this.simpleType_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.simpleType_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ObjectTypeContext), annotList);
            this.objectType_Name = new NameAnnotation();
            annotList.Add(this.objectType_Name);
            this.objectType_KObject_PreDefSymbol = new PreDefSymbolAnnotation();
            this.objectType_KObject_PreDefSymbol.Value = MetaBuiltInType.Object;
            this.objectType_KString_PreDefSymbol = new PreDefSymbolAnnotation();
            this.objectType_KString_PreDefSymbol.Value = MetaBuiltInType.String;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PrimitiveTypeContext), annotList);
            this.primitiveType_Name = new NameAnnotation();
            annotList.Add(this.primitiveType_Name);
            this.primitiveType_KInt_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KInt_PreDefSymbol.Value = MetaBuiltInType.Int;
            this.primitiveType_KLong_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KLong_PreDefSymbol.Value = MetaBuiltInType.Long;
            this.primitiveType_KFloat_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KFloat_PreDefSymbol.Value = MetaBuiltInType.Float;
            this.primitiveType_KDouble_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KDouble_PreDefSymbol.Value = MetaBuiltInType.Double;
            this.primitiveType_KByte_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KByte_PreDefSymbol.Value = MetaBuiltInType.Byte;
            this.primitiveType_KBool_PreDefSymbol = new PreDefSymbolAnnotation();
            this.primitiveType_KBool_PreDefSymbol.Value = MetaBuiltInType.Bool;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.VoidTypeContext), annotList);
            this.voidType_Name = new NameAnnotation();
            annotList.Add(this.voidType_Name);
            this.voidType_KVoid_PreDefSymbol = new PreDefSymbolAnnotation();
            this.voidType_KVoid_PreDefSymbol.Value = MetaBuiltInType.Void;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NullableTypeContext), annotList);
            this.nullableType_TypeCtr = new TypeCtrAnnotation();
            this.nullableType_TypeCtr.SymbolType = typeof(MetaNullableType);
            annotList.Add(this.nullableType_TypeCtr);
            this.nullableType_PrimitiveType_Property = new PropertyAnnotation();
            this.nullableType_PrimitiveType_Property.Name = "InnerType";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.CollectionTypeContext), annotList);
            this.collectionType_TypeCtr = new TypeCtrAnnotation();
            this.collectionType_TypeCtr.SymbolType = typeof(MetaCollectionType);
            annotList.Add(this.collectionType_TypeCtr);
            this.collectionType_CollectionKind_Property = new PropertyAnnotation();
            this.collectionType_CollectionKind_Property.Name = "Kind";
            this.collectionType_SimpleType_Property = new PropertyAnnotation();
            this.collectionType_SimpleType_Property.Name = "InnerType";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.OperationDeclarationContext), annotList);
            this.operationDeclaration_NameDef = new NameDefAnnotation();
            this.operationDeclaration_NameDef.SymbolType = typeof(MetaOperation);
            annotList.Add(this.operationDeclaration_NameDef);
            this.operationDeclaration_ReturnType_Property = new PropertyAnnotation();
            this.operationDeclaration_ReturnType_Property.Name = "ReturnType";
            this.operationDeclaration_ParameterList_Property = new PropertyAnnotation();
            this.operationDeclaration_ParameterList_Property.Name = "Parameters";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ParameterContext), annotList);
            this.parameter_NameDef = new NameDefAnnotation();
            this.parameter_NameDef.SymbolType = typeof(MetaParameter);
            annotList.Add(this.parameter_NameDef);
            this.parameter_TypeReference_Property = new PropertyAnnotation();
            this.parameter_TypeReference_Property.Name = "Type";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConstructorDeclarationContext), annotList);
            this.constructorDeclaration_NameDef = new NameDefAnnotation();
            this.constructorDeclaration_NameDef.SymbolType = typeof(MetaConstructor);
            annotList.Add(this.constructorDeclaration_NameDef);
            this.constructorDeclaration_InitializerDeclaration_Property = new PropertyAnnotation();
            this.constructorDeclaration_InitializerDeclaration_Property.Name = "Initializers";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.SynthetizedPropertyInitializerContext), annotList);
            this.synthetizedPropertyInitializer_Symbol = new SymbolAnnotation();
            this.synthetizedPropertyInitializer_Symbol.SymbolType = typeof(MetaSynthetizedPropertyInitializer);
            annotList.Add(this.synthetizedPropertyInitializer_Symbol);
            this.synthetizedPropertyInitializer_Property_Property = new PropertyAnnotation();
            this.synthetizedPropertyInitializer_Property_Property.Name = "Property";
            this.synthetizedPropertyInitializer_Property_NameUse = new NameUseAnnotation();
            this.synthetizedPropertyInitializer_Property_NameUse.SymbolTypes.Add(typeof(MetaProperty));
            this.synthetizedPropertyInitializer_Expression_Property = new PropertyAnnotation();
            this.synthetizedPropertyInitializer_Expression_Property.Name = "Value";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.InheritedPropertyInitializerContext), annotList);
            this.inheritedPropertyInitializer_Symbol = new SymbolAnnotation();
            this.inheritedPropertyInitializer_Symbol.SymbolType = typeof(MetaInheritedPropertyInitializer);
            annotList.Add(this.inheritedPropertyInitializer_Symbol);
            this.inheritedPropertyInitializer_Object_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_Object_Property.Name = "Object";
            this.inheritedPropertyInitializer_Object_NameUse = new NameUseAnnotation();
            this.inheritedPropertyInitializer_Object_NameUse.SymbolTypes.Add(typeof(MetaProperty));
            this.inheritedPropertyInitializer_Expression_Property = new PropertyAnnotation();
            this.inheritedPropertyInitializer_Expression_Property.Name = "Value";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ExpressionContext), annotList);
            this.expression_Expression = new ExpressionAnnotation();
            annotList.Add(this.expression_Expression);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.CastExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.castExpression_Symbol = new SymbolAnnotation();
            this.castExpression_Symbol.SymbolType = typeof(MetaTypeConversionExpression);
            annotList.Add(this.castExpression_Symbol);
            this.castExpression_TypeReference_Property = new PropertyAnnotation();
            this.castExpression_TypeReference_Property.Name = "TypeReference";
            this.castExpression_Expression_Property = new PropertyAnnotation();
            this.castExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeofExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeofExpression_Symbol = new SymbolAnnotation();
            this.typeofExpression_Symbol.SymbolType = typeof(MetaTypeOfExpression);
            annotList.Add(this.typeofExpression_Symbol);
            this.typeofExpression_TypeReference_Property = new PropertyAnnotation();
            this.typeofExpression_TypeReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BracketExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bracketExpression_Symbol = new SymbolAnnotation();
            this.bracketExpression_Symbol.SymbolType = typeof(MetaUnaryExpression);
            annotList.Add(this.bracketExpression_Symbol);
            this.bracketExpression_Expression_Property = new PropertyAnnotation();
            this.bracketExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ThisExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.thisExpression_Symbol = new SymbolAnnotation();
            this.thisExpression_Symbol.SymbolType = typeof(MetaThisExpression);
            annotList.Add(this.thisExpression_Symbol);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConstantExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.constantExpression_Symbol = new SymbolAnnotation();
            this.constantExpression_Symbol.SymbolType = typeof(MetaConstantExpression);
            annotList.Add(this.constantExpression_Symbol);
            this.constantExpression_Value_Property = new PropertyAnnotation();
            this.constantExpression_Value_Property.Name = "Value";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.identifierExpression_Symbol = new SymbolAnnotation();
            this.identifierExpression_Symbol.SymbolType = typeof(MetaIdentifierExpression);
            annotList.Add(this.identifierExpression_Symbol);
            this.identifierExpression_Name_Property = new PropertyAnnotation();
            this.identifierExpression_Name_Property.Name = "Name";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IndexerExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.indexerExpression_Symbol = new SymbolAnnotation();
            this.indexerExpression_Symbol.SymbolType = typeof(MetaIndexerExpression);
            annotList.Add(this.indexerExpression_Symbol);
            this.indexerExpression_Expression_Property = new PropertyAnnotation();
            this.indexerExpression_Expression_Property.Name = "Expression";
            this.indexerExpression_ArgumentList_Property = new PropertyAnnotation();
            this.indexerExpression_ArgumentList_Property.Name = "Arguments";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.FunctionCallExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.functionCallExpression_Symbol = new SymbolAnnotation();
            this.functionCallExpression_Symbol.SymbolType = typeof(MetaFunctionCallExpression);
            annotList.Add(this.functionCallExpression_Symbol);
            this.functionCallExpression_Expression_Property = new PropertyAnnotation();
            this.functionCallExpression_Expression_Property.Name = "Expression";
            this.functionCallExpression_ArgumentList_Property = new PropertyAnnotation();
            this.functionCallExpression_ArgumentList_Property.Name = "Arguments";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MemberAccessExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.memberAccessExpression_Symbol = new SymbolAnnotation();
            this.memberAccessExpression_Symbol.SymbolType = typeof(MetaMemberAccessExpression);
            annotList.Add(this.memberAccessExpression_Symbol);
            this.memberAccessExpression_Expression_Property = new PropertyAnnotation();
            this.memberAccessExpression_Expression_Property.Name = "Expression";
            this.memberAccessExpression_Name_Property = new PropertyAnnotation();
            this.memberAccessExpression_Name_Property.Name = "Name";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PostExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.postExpression_Symbol = new SymbolAnnotation();
            this.postExpression_Symbol.SymbolType = typeof(MetaUnaryExpression);
            annotList.Add(this.postExpression_Symbol);
            this.postExpression_Expression_Property = new PropertyAnnotation();
            this.postExpression_Expression_Property.Name = "Expression";
            this.postExpression_Kind_Property = new PropertyAnnotation();
            this.postExpression_Kind_Property.Name = "Kind";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.PreExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.preExpression_Symbol = new SymbolAnnotation();
            this.preExpression_Symbol.SymbolType = typeof(MetaUnaryExpression);
            annotList.Add(this.preExpression_Symbol);
            this.preExpression_Kind_Property = new PropertyAnnotation();
            this.preExpression_Kind_Property.Name = "Kind";
            this.preExpression_Expression_Property = new PropertyAnnotation();
            this.preExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.UnaryExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.unaryExpression_Symbol = new SymbolAnnotation();
            this.unaryExpression_Symbol.SymbolType = typeof(MetaUnaryExpression);
            annotList.Add(this.unaryExpression_Symbol);
            this.unaryExpression_Kind_Property = new PropertyAnnotation();
            this.unaryExpression_Kind_Property.Name = "Kind";
            this.unaryExpression_Expression_Property = new PropertyAnnotation();
            this.unaryExpression_Expression_Property.Name = "Expression";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeConversionExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeConversionExpression_Symbol = new SymbolAnnotation();
            this.typeConversionExpression_Symbol.SymbolType = typeof(MetaTypeConversionExpression);
            annotList.Add(this.typeConversionExpression_Symbol);
            this.typeConversionExpression_Expression_Property = new PropertyAnnotation();
            this.typeConversionExpression_Expression_Property.Name = "Expression";
            this.typeConversionExpression_TypeReference_Property = new PropertyAnnotation();
            this.typeConversionExpression_TypeReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeCheckExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.typeCheckExpression_Symbol = new SymbolAnnotation();
            this.typeCheckExpression_Symbol.SymbolType = typeof(MetaTypeCheckExpression);
            annotList.Add(this.typeCheckExpression_Symbol);
            this.typeCheckExpression_Expression_Property = new PropertyAnnotation();
            this.typeCheckExpression_Expression_Property.Name = "Expression";
            this.typeCheckExpression_TypeReference_Property = new PropertyAnnotation();
            this.typeCheckExpression_TypeReference_Property.Name = "TypeReference";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MultiplicativeExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.multiplicativeExpression_Symbol = new SymbolAnnotation();
            this.multiplicativeExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.multiplicativeExpression_Symbol);
            this.multiplicativeExpression_Left_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Left_Property.Name = "Left";
            this.multiplicativeExpression_Kind_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Kind_Property.Name = "Kind";
            this.multiplicativeExpression_Right_Property = new PropertyAnnotation();
            this.multiplicativeExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AdditiveExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.additiveExpression_Symbol = new SymbolAnnotation();
            this.additiveExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.additiveExpression_Symbol);
            this.additiveExpression_Left_Property = new PropertyAnnotation();
            this.additiveExpression_Left_Property.Name = "Left";
            this.additiveExpression_Kind_Property = new PropertyAnnotation();
            this.additiveExpression_Kind_Property.Name = "Kind";
            this.additiveExpression_Right_Property = new PropertyAnnotation();
            this.additiveExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ShiftExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.shiftExpression_Symbol = new SymbolAnnotation();
            this.shiftExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.shiftExpression_Symbol);
            this.shiftExpression_Left_Property = new PropertyAnnotation();
            this.shiftExpression_Left_Property.Name = "Left";
            this.shiftExpression_Kind_Property = new PropertyAnnotation();
            this.shiftExpression_Kind_Property.Name = "Kind";
            this.shiftExpression_Right_Property = new PropertyAnnotation();
            this.shiftExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ComparisonExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.comparisonExpression_Symbol = new SymbolAnnotation();
            this.comparisonExpression_Symbol.SymbolType = typeof(MetaBinaryComparisonExpression);
            annotList.Add(this.comparisonExpression_Symbol);
            this.comparisonExpression_Left_Property = new PropertyAnnotation();
            this.comparisonExpression_Left_Property.Name = "Left";
            this.comparisonExpression_Kind_Property = new PropertyAnnotation();
            this.comparisonExpression_Kind_Property.Name = "Kind";
            this.comparisonExpression_Right_Property = new PropertyAnnotation();
            this.comparisonExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EqualityExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.equalityExpression_Symbol = new SymbolAnnotation();
            this.equalityExpression_Symbol.SymbolType = typeof(MetaBinaryComparisonExpression);
            annotList.Add(this.equalityExpression_Symbol);
            this.equalityExpression_Left_Property = new PropertyAnnotation();
            this.equalityExpression_Left_Property.Name = "Left";
            this.equalityExpression_Kind_Property = new PropertyAnnotation();
            this.equalityExpression_Kind_Property.Name = "Kind";
            this.equalityExpression_Right_Property = new PropertyAnnotation();
            this.equalityExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseAndExpression_Symbol = new SymbolAnnotation();
            this.bitwiseAndExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.bitwiseAndExpression_Symbol);
            this.bitwiseAndExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseAndExpression_Left_Property.Name = "Left";
            this.bitwiseAndExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseAndExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseXorExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseXorExpression_Symbol = new SymbolAnnotation();
            this.bitwiseXorExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.bitwiseXorExpression_Symbol);
            this.bitwiseXorExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseXorExpression_Left_Property.Name = "Left";
            this.bitwiseXorExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseXorExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.BitwiseOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.bitwiseOrExpression_Symbol = new SymbolAnnotation();
            this.bitwiseOrExpression_Symbol.SymbolType = typeof(MetaBinaryArithmeticExpression);
            annotList.Add(this.bitwiseOrExpression_Symbol);
            this.bitwiseOrExpression_Left_Property = new PropertyAnnotation();
            this.bitwiseOrExpression_Left_Property.Name = "Left";
            this.bitwiseOrExpression_Right_Property = new PropertyAnnotation();
            this.bitwiseOrExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalAndExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalAndExpression_Symbol = new SymbolAnnotation();
            this.logicalAndExpression_Symbol.SymbolType = typeof(MetaBinaryLogicalExpression);
            annotList.Add(this.logicalAndExpression_Symbol);
            this.logicalAndExpression_Left_Property = new PropertyAnnotation();
            this.logicalAndExpression_Left_Property.Name = "Left";
            this.logicalAndExpression_Right_Property = new PropertyAnnotation();
            this.logicalAndExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.LogicalOrExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.logicalOrExpression_Symbol = new SymbolAnnotation();
            this.logicalOrExpression_Symbol.SymbolType = typeof(MetaBinaryLogicalExpression);
            annotList.Add(this.logicalOrExpression_Symbol);
            this.logicalOrExpression_Left_Property = new PropertyAnnotation();
            this.logicalOrExpression_Left_Property.Name = "Left";
            this.logicalOrExpression_Right_Property = new PropertyAnnotation();
            this.logicalOrExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NullCoalescingExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.nullCoalescingExpression_Symbol = new SymbolAnnotation();
            this.nullCoalescingExpression_Symbol.SymbolType = typeof(MetaNullCoalescingExpression);
            annotList.Add(this.nullCoalescingExpression_Symbol);
            this.nullCoalescingExpression_Left_Property = new PropertyAnnotation();
            this.nullCoalescingExpression_Left_Property.Name = "Left";
            this.nullCoalescingExpression_Right_Property = new PropertyAnnotation();
            this.nullCoalescingExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ConditionalExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.conditionalExpression_Symbol = new SymbolAnnotation();
            this.conditionalExpression_Symbol.SymbolType = typeof(MetaConditionalExpression);
            annotList.Add(this.conditionalExpression_Symbol);
            this.conditionalExpression_Condition_Property = new PropertyAnnotation();
            this.conditionalExpression_Condition_Property.Name = "Condition";
            this.conditionalExpression_Then_Property = new PropertyAnnotation();
            this.conditionalExpression_Then_Property.Name = "Then";
            this.conditionalExpression_Else_Property = new PropertyAnnotation();
            this.conditionalExpression_Else_Property.Name = "Else";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AssignmentExpressionContext), annotList);
            annotList.Add(this.expression_Expression);
            this.assignmentExpression_Symbol = new SymbolAnnotation();
            this.assignmentExpression_Symbol.SymbolType = typeof(MetaAssignmentExpression);
            annotList.Add(this.assignmentExpression_Symbol);
            this.assignmentExpression_Left_Property = new PropertyAnnotation();
            this.assignmentExpression_Left_Property.Name = "Left";
            this.assignmentExpression_Operator_Property = new PropertyAnnotation();
            this.assignmentExpression_Operator_Property.Name = "Operator";
            this.assignmentExpression_Right_Property = new PropertyAnnotation();
            this.assignmentExpression_Right_Property.Name = "Right";
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.AssociationDeclarationContext), annotList);
            this.associationDeclaration_Scope = new ScopeAnnotation();
            annotList.Add(this.associationDeclaration_Scope);
            this.associationDeclaration_Source_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Source_NameUse.SymbolTypes.Add(typeof(MetaProperty));
            this.associationDeclaration_Target_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Target_NameUse.SymbolTypes.Add(typeof(MetaProperty));
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierContext), annotList);
            this.identifier_Name = new NameAnnotation();
            annotList.Add(this.identifier_Name);
            this.identifier_Identifier = new IdentifierAnnotation();
            annotList.Add(this.identifier_Identifier);
        }
        
        public override object VisitTerminal(ITerminalNode node)
        {
            return this.lexerAnnotator.VisitTerminal(node, treeAnnotations);
        }
        
        public override object VisitMain(MetaModelParser.MainContext context)
        {
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
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitIdentifierList(MetaModelParser.IdentifierListContext context)
        {
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitQualifiedNameList(MetaModelParser.QualifiedNameListContext context)
        {
            return base.VisitQualifiedNameList(context);
        }
        
        public override object VisitAnnotation(MetaModelParser.AnnotationContext context)
        {
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
            treeAnnotList.Add(this.namespaceDeclaration_NameDef);
            List<object> elemAnnotList = null;
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp1 = new ValueAnnotation();
                elemAnnotList.Add(__tmp1);
            }
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
            treeAnnotList.Add(this.metamodelDeclaration_NameDef);
            List<object> elemAnnotList = null;
            if (context.declaration() != null)
            {
                foreach(object elem in context.declaration())
                {
                    if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                    {
                        elemAnnotList = new List<object>();
                        this.treeAnnotations.Add(elem, elemAnnotList);
                    }
                    elemAnnotList.Add(this.metamodelDeclaration_Declaration_Property);
                }
            }
            return base.VisitMetamodelDeclaration(context);
        }
        
        public override object VisitDeclaration(MetaModelParser.DeclarationContext context)
        {
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
            treeAnnotList.Add(this.enumDeclaration_TypeDef);
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
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumValues(MetaModelParser.EnumValuesContext context)
        {
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
            treeAnnotList.Add(this.enumValue_NameDef);
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
            treeAnnotList.Add(this.classDeclaration_TypeDef);
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
            return base.VisitClassDeclaration(context);
        }
        
        public override object VisitClassAncestors(MetaModelParser.ClassAncestorsContext context)
        {
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
                elemAnnotList.Add(this.classAncestor_QualifiedName_TypeUse);
            }
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
            treeAnnotList.Add(this.fieldDeclaration_NameDef);
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
                ValueAnnotation __tmp2 = new ValueAnnotation();
                __tmp2.Value = MetaPropertyKind.Containment;
                elemAnnotList.Add(__tmp2);
            }
            if (context.KReadonly() != null)
            {
                object elem = context.KReadonly();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp3 = new ValueAnnotation();
                __tmp3.Value = MetaPropertyKind.Readonly;
                elemAnnotList.Add(__tmp3);
            }
            if (context.KLazy() != null)
            {
                object elem = context.KLazy();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp4 = new ValueAnnotation();
                __tmp4.Value = MetaPropertyKind.Lazy;
                elemAnnotList.Add(__tmp4);
            }
            if (context.KDerived() != null)
            {
                object elem = context.KDerived();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp5 = new ValueAnnotation();
                __tmp5.Value = MetaPropertyKind.Derived;
                elemAnnotList.Add(__tmp5);
            }
            if (context.KSynthetized() != null)
            {
                object elem = context.KSynthetized();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp6 = new ValueAnnotation();
                __tmp6.Value = MetaPropertyKind.Synthetized;
                elemAnnotList.Add(__tmp6);
            }
            if (context.KInherited() != null)
            {
                object elem = context.KInherited();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp7 = new ValueAnnotation();
                __tmp7.Value = MetaPropertyKind.Inherited;
                elemAnnotList.Add(__tmp7);
            }
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
            treeAnnotList.Add(this.redefinitions_Scope);
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
            treeAnnotList.Add(this.subsettings_Scope);
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
                    elemAnnotList.Add(this.nameUseList_QualifiedName_NameUse);
                }
            }
            return base.VisitNameUseList(context);
        }
        
        public override object VisitConstDeclaration(MetaModelParser.ConstDeclarationContext context)
        {
            return base.VisitConstDeclaration(context);
        }
        
        public override object VisitReturnType(MetaModelParser.ReturnTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.returnType_TypeUse);
            return base.VisitReturnType(context);
        }
        
        public override object VisitTypeReference(MetaModelParser.TypeReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.typeReference_TypeUse);
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
            treeAnnotList.Add(this.simpleType_TypeUse);
            return base.VisitSimpleType(context);
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
            List<object> elemAnnotList = null;
            if (context.KObject() != null)
            {
                object elem = context.KObject();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.objectType_KObject_PreDefSymbol);
            }
            if (context.KString() != null)
            {
                object elem = context.KString();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.objectType_KString_PreDefSymbol);
            }
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
            List<object> elemAnnotList = null;
            if (context.KInt() != null)
            {
                object elem = context.KInt();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KInt_PreDefSymbol);
            }
            if (context.KLong() != null)
            {
                object elem = context.KLong();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KLong_PreDefSymbol);
            }
            if (context.KFloat() != null)
            {
                object elem = context.KFloat();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KFloat_PreDefSymbol);
            }
            if (context.KDouble() != null)
            {
                object elem = context.KDouble();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KDouble_PreDefSymbol);
            }
            if (context.KByte() != null)
            {
                object elem = context.KByte();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KByte_PreDefSymbol);
            }
            if (context.KBool() != null)
            {
                object elem = context.KBool();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.primitiveType_KBool_PreDefSymbol);
            }
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
            List<object> elemAnnotList = null;
            if (context.KVoid() != null)
            {
                object elem = context.KVoid();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.voidType_KVoid_PreDefSymbol);
            }
            return base.VisitVoidType(context);
        }
        
        public override object VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.nullableType_TypeCtr);
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
            treeAnnotList.Add(this.collectionType_TypeCtr);
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
                ValueAnnotation __tmp8 = new ValueAnnotation();
                __tmp8.Value = MetaCollectionKind.Set;
                elemAnnotList.Add(__tmp8);
            }
            if (context.KList() != null)
            {
                object elem = context.KList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp9 = new ValueAnnotation();
                __tmp9.Value = MetaCollectionKind.List;
                elemAnnotList.Add(__tmp9);
            }
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
            treeAnnotList.Add(this.operationDeclaration_NameDef);
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
            return base.VisitOperationDeclaration(context);
        }
        
        public override object VisitParameterList(MetaModelParser.ParameterListContext context)
        {
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
            treeAnnotList.Add(this.parameter_NameDef);
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
            treeAnnotList.Add(this.constructorDeclaration_NameDef);
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
            return base.VisitConstructorDeclaration(context);
        }
        
        public override object VisitInitializerDeclaration(MetaModelParser.InitializerDeclarationContext context)
        {
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
            treeAnnotList.Add(this.synthetizedPropertyInitializer_Symbol);
            List<object> elemAnnotList = null;
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.synthetizedPropertyInitializer_Property_Property);
                elemAnnotList.Add(this.synthetizedPropertyInitializer_Property_NameUse);
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
            treeAnnotList.Add(this.inheritedPropertyInitializer_Symbol);
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
                elemAnnotList.Add(this.inheritedPropertyInitializer_Object_NameUse);
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
            return base.VisitInheritedPropertyInitializer(context);
        }
        
        public override object VisitArgumentList(MetaModelParser.ArgumentListContext context)
        {
            return base.VisitArgumentList(context);
        }
        
        public override object VisitCastExpression(MetaModelParser.CastExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.castExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeofExpression_Symbol);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.typeofExpression_TypeReference_Property);
            }
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bracketExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.thisExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.constantExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.identifierExpression_Symbol);
            List<object> elemAnnotList = null;
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp10 = new ValueAnnotation();
                elemAnnotList.Add(__tmp10);
                elemAnnotList.Add(this.identifierExpression_Name_Property);
            }
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.indexerExpression_Symbol);
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
            if (context.argumentList() != null)
            {
                object elem = context.argumentList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.indexerExpression_ArgumentList_Property);
            }
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.functionCallExpression_Symbol);
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
            if (context.argumentList() != null)
            {
                object elem = context.argumentList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.functionCallExpression_ArgumentList_Property);
            }
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.memberAccessExpression_Symbol);
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
                ValueAnnotation __tmp11 = new ValueAnnotation();
                elemAnnotList.Add(__tmp11);
                elemAnnotList.Add(this.memberAccessExpression_Name_Property);
            }
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.postExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.preExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.unaryExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeConversionExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.typeCheckExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.multiplicativeExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.additiveExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.shiftExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.comparisonExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.equalityExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseAndExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseXorExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.bitwiseOrExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.logicalAndExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.logicalOrExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.nullCoalescingExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.conditionalExpression_Symbol);
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
            treeAnnotList.Add(this.expression_Expression);
            treeAnnotList.Add(this.assignmentExpression_Symbol);
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
            return base.VisitAssignmentExpression(context);
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
                ValueAnnotation __tmp12 = new ValueAnnotation();
                __tmp12.Value = MetaExpressionKind.PostIncrementAssign;
                elemAnnotList.Add(__tmp12);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp13 = new ValueAnnotation();
                __tmp13.Value = MetaExpressionKind.PostDecrementAssign;
                elemAnnotList.Add(__tmp13);
            }
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
                ValueAnnotation __tmp14 = new ValueAnnotation();
                __tmp14.Value = MetaExpressionKind.PreIncrementAssign;
                elemAnnotList.Add(__tmp14);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp15 = new ValueAnnotation();
                __tmp15.Value = MetaExpressionKind.PreDecrementAssign;
                elemAnnotList.Add(__tmp15);
            }
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
                ValueAnnotation __tmp16 = new ValueAnnotation();
                __tmp16.Value = MetaExpressionKind.UnaryPlus;
                elemAnnotList.Add(__tmp16);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp17 = new ValueAnnotation();
                __tmp17.Value = MetaExpressionKind.Negate;
                elemAnnotList.Add(__tmp17);
            }
            if (context.TTilde() != null)
            {
                object elem = context.TTilde();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp18 = new ValueAnnotation();
                __tmp18.Value = MetaExpressionKind.OnesComplement;
                elemAnnotList.Add(__tmp18);
            }
            if (context.TExclamation() != null)
            {
                object elem = context.TExclamation();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp19 = new ValueAnnotation();
                __tmp19.Value = MetaExpressionKind.Not;
                elemAnnotList.Add(__tmp19);
            }
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
                ValueAnnotation __tmp20 = new ValueAnnotation();
                __tmp20.Value = MetaExpressionKind.Multiply;
                elemAnnotList.Add(__tmp20);
            }
            if (context.TSlash() != null)
            {
                object elem = context.TSlash();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp21 = new ValueAnnotation();
                __tmp21.Value = MetaExpressionKind.Divide;
                elemAnnotList.Add(__tmp21);
            }
            if (context.TPercent() != null)
            {
                object elem = context.TPercent();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp22 = new ValueAnnotation();
                __tmp22.Value = MetaExpressionKind.Modulo;
                elemAnnotList.Add(__tmp22);
            }
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
                ValueAnnotation __tmp23 = new ValueAnnotation();
                __tmp23.Value = MetaExpressionKind.Add;
                elemAnnotList.Add(__tmp23);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp24 = new ValueAnnotation();
                __tmp24.Value = MetaExpressionKind.Subtract;
                elemAnnotList.Add(__tmp24);
            }
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
                    ValueAnnotation __tmp25 = new ValueAnnotation();
                    __tmp25.Value = MetaExpressionKind.LeftShift;
                    elemAnnotList.Add(__tmp25);
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
                    ValueAnnotation __tmp26 = new ValueAnnotation();
                    __tmp26.Value = MetaExpressionKind.RightShift;
                    elemAnnotList.Add(__tmp26);
                }
            }
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
                ValueAnnotation __tmp27 = new ValueAnnotation();
                __tmp27.Value = MetaExpressionKind.LessThan;
                elemAnnotList.Add(__tmp27);
            }
            if (context.TGreaterThan() != null)
            {
                object elem = context.TGreaterThan();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp28 = new ValueAnnotation();
                __tmp28.Value = MetaExpressionKind.GreaterThan;
                elemAnnotList.Add(__tmp28);
            }
            if (context.TLessThanOrEqual() != null)
            {
                object elem = context.TLessThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp29 = new ValueAnnotation();
                __tmp29.Value = MetaExpressionKind.LessThanOrEqual;
                elemAnnotList.Add(__tmp29);
            }
            if (context.TGreaterThanOrEqual() != null)
            {
                object elem = context.TGreaterThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp30 = new ValueAnnotation();
                __tmp30.Value = MetaExpressionKind.GreaterThanOrEqual;
                elemAnnotList.Add(__tmp30);
            }
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
                ValueAnnotation __tmp31 = new ValueAnnotation();
                __tmp31.Value = MetaExpressionKind.Equal;
                elemAnnotList.Add(__tmp31);
            }
            if (context.TNotEqual() != null)
            {
                object elem = context.TNotEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp32 = new ValueAnnotation();
                __tmp32.Value = MetaExpressionKind.NotEqual;
                elemAnnotList.Add(__tmp32);
            }
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
                ValueAnnotation __tmp33 = new ValueAnnotation();
                __tmp33.Value = MetaExpressionKind.Assign;
                elemAnnotList.Add(__tmp33);
            }
            if (context.TAsteriskAssign() != null)
            {
                object elem = context.TAsteriskAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp34 = new ValueAnnotation();
                __tmp34.Value = MetaExpressionKind.MultiplyAssign;
                elemAnnotList.Add(__tmp34);
            }
            if (context.TSlashAssign() != null)
            {
                object elem = context.TSlashAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp35 = new ValueAnnotation();
                __tmp35.Value = MetaExpressionKind.DivideAssign;
                elemAnnotList.Add(__tmp35);
            }
            if (context.TPercentAssign() != null)
            {
                object elem = context.TPercentAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp36 = new ValueAnnotation();
                __tmp36.Value = MetaExpressionKind.ModuloAssign;
                elemAnnotList.Add(__tmp36);
            }
            if (context.TPlusAssign() != null)
            {
                object elem = context.TPlusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp37 = new ValueAnnotation();
                __tmp37.Value = MetaExpressionKind.AddAssign;
                elemAnnotList.Add(__tmp37);
            }
            if (context.TMinusAssign() != null)
            {
                object elem = context.TMinusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp38 = new ValueAnnotation();
                __tmp38.Value = MetaExpressionKind.SubtractAssign;
                elemAnnotList.Add(__tmp38);
            }
            if (context.TLeftShiftAssign() != null)
            {
                object elem = context.TLeftShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp39 = new ValueAnnotation();
                __tmp39.Value = MetaExpressionKind.LeftShiftAssign;
                elemAnnotList.Add(__tmp39);
            }
            if (context.TRightShiftAssign() != null)
            {
                object elem = context.TRightShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp40 = new ValueAnnotation();
                __tmp40.Value = MetaExpressionKind.RightShiftAssign;
                elemAnnotList.Add(__tmp40);
            }
            if (context.TAmpersandAssign() != null)
            {
                object elem = context.TAmpersandAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp41 = new ValueAnnotation();
                __tmp41.Value = MetaExpressionKind.AndAssign;
                elemAnnotList.Add(__tmp41);
            }
            if (context.THatAssign() != null)
            {
                object elem = context.THatAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp42 = new ValueAnnotation();
                __tmp42.Value = MetaExpressionKind.ExclusiveOrAssign;
                elemAnnotList.Add(__tmp42);
            }
            if (context.TBarAssign() != null)
            {
                object elem = context.TBarAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp43 = new ValueAnnotation();
                __tmp43.Value = MetaExpressionKind.OrAssign;
                elemAnnotList.Add(__tmp43);
            }
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
            treeAnnotList.Add(this.associationDeclaration_Scope);
            List<object> elemAnnotList = null;
            if (context.source != null)
            {
                object elem = context.source;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.associationDeclaration_Source_NameUse);
            }
            if (context.target != null)
            {
                object elem = context.target;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                elemAnnotList.Add(this.associationDeclaration_Target_NameUse);
            }
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
            return base.VisitIdentifier(context);
        }
        
        public override object VisitLiteral(MetaModelParser.LiteralContext context)
        {
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(MetaModelParser.NullLiteralContext context)
        {
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(MetaModelParser.BooleanLiteralContext context)
        {
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitIntegerLiteral(MetaModelParser.IntegerLiteralContext context)
        {
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(MetaModelParser.DecimalLiteralContext context)
        {
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(MetaModelParser.ScientificLiteralContext context)
        {
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitStringLiteral(MetaModelParser.StringLiteralContext context)
        {
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
        
        public virtual object VisitReturnType(MetaModelParser.ReturnTypeContext context)
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
        
        public virtual object VisitArgumentList(MetaModelParser.ArgumentListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCastExpression(MetaModelParser.CastExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.TypeCast));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofExpression(MetaModelParser.TypeofExpressionContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBracketExpression(MetaModelParser.BracketExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.Bracket));
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
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.TypeAs));
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
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.And));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseXorExpression(MetaModelParser.BitwiseXorExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.ExclusiveOr));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBitwiseOrExpression(MetaModelParser.BitwiseOrExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.Or));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalAndExpression(MetaModelParser.LogicalAndExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.AndAlso));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLogicalOrExpression(MetaModelParser.LogicalOrExpressionContext context)
        {
            this.SetValue(context, "Kind", new Lazy<object>(() => MetaExpressionKind.OrElse));
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
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.Any));
            this.SetValue(context, "Value", new Lazy<object>(() => null));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBooleanLiteral(MetaModelParser.BooleanLiteralContext context)
        {
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.Bool));
            this.SetValue(context, "Value", new Lazy<object>(() => this.Valueof(this.Symbol(context))));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIntegerLiteral(MetaModelParser.IntegerLiteralContext context)
        {
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.Int));
            this.SetValue(context, "Value", new Lazy<object>(() => this.Valueof(this.Symbol(context))));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDecimalLiteral(MetaModelParser.DecimalLiteralContext context)
        {
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.Double));
            this.SetValue(context, "Value", new Lazy<object>(() => this.Valueof(this.Symbol(context))));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitScientificLiteral(MetaModelParser.ScientificLiteralContext context)
        {
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.Double));
            this.SetValue(context, "Value", new Lazy<object>(() => this.Valueof(this.Symbol(context))));
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStringLiteral(MetaModelParser.StringLiteralContext context)
        {
            this.SetValue(context, "Type", new Lazy<object>(() => MetaBuiltInType.String));
            this.SetValue(context, "Value", new Lazy<object>(() => this.Valueof(this.Symbol(context))));
            return this.VisitChildren(context);
        }
    }
}

