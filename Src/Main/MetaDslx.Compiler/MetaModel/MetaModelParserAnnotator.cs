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
        private TypeDefAnnotation metamodelDeclaration_TypeDef;
        private PropertyAnnotation metamodelDeclaration_Declaration_Property;
        private TypeDefAnnotation enumDeclaration_TypeDef;
        private PropertyAnnotation enumDeclaration_EnumValues_Property;
        private NameDefAnnotation enumValue_NameDef;
        private PropertyAnnotation enumMemberDeclaration_OperationDeclaration_Property;
        private TypeDefAnnotation classDeclaration_TypeDef;
        private PropertyAnnotation classDeclaration_KAbstract_Property;
        private PropertyAnnotation classDeclaration_ClassAncestors_Property;
        private TypeUseAnnotation classAncestor_QualifiedName_TypeUse;
        private PropertyAnnotation classMemberDeclaration_FieldDeclaration_Property;
        private PropertyAnnotation classMemberDeclaration_OperationDeclaration_Property;
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
        private TypeCtrAnnotation operationDeclaration_TypeCtr;
        private PropertyAnnotation operationDeclaration_ReturnType_Property;
        private PropertyAnnotation operationDeclaration_ParameterList_Property;
        private NameDefAnnotation parameter_NameDef;
        private PropertyAnnotation parameter_TypeReference_Property;
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
            this.metamodelDeclaration_TypeDef = new TypeDefAnnotation();
            this.metamodelDeclaration_TypeDef.SymbolType = typeof(MetaModel);
            annotList.Add(this.metamodelDeclaration_TypeDef);
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
            
            this.classAncestor_QualifiedName_TypeUse = new TypeUseAnnotation();
            this.classAncestor_QualifiedName_TypeUse.SymbolTypes.Add(typeof(MetaClass));
            
            this.classMemberDeclaration_FieldDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_FieldDeclaration_Property.Name = "Properties";
            this.classMemberDeclaration_OperationDeclaration_Property = new PropertyAnnotation();
            this.classMemberDeclaration_OperationDeclaration_Property.Name = "Operations";
            
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
            this.operationDeclaration_TypeCtr = new TypeCtrAnnotation();
            annotList.Add(this.operationDeclaration_TypeCtr);
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
            treeAnnotList.Add(this.metamodelDeclaration_TypeDef);
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
                ValueAnnotation __tmp6 = new ValueAnnotation();
                __tmp6.Value = MetaCollectionKind.Set;
                elemAnnotList.Add(__tmp6);
            }
            if (context.KList() != null)
            {
                object elem = context.KList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp7 = new ValueAnnotation();
                __tmp7.Value = MetaCollectionKind.List;
                elemAnnotList.Add(__tmp7);
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
            treeAnnotList.Add(this.operationDeclaration_TypeCtr);
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

