using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
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
        private ScopeAnnotation namespaceDeclaration_Scope;
        private NameDefAnnotation namespaceDeclaration_QualifiedName_NameDef;
        private TypeDefAnnotation metamodelDeclaration_TypeDef;
        private NameDefAnnotation metamodelDeclaration_Identifier_NameDef;
        private TypeDefAnnotation enumDeclaration_TypeDef;
        private NameDefAnnotation enumDeclaration_Identifier_NameDef;
        private NameDefAnnotation enumValue_Identifier_NameDef;
        private TypeDefAnnotation classDeclaration_TypeDef;
        private NameDefAnnotation classDeclaration_Identifier_NameDef;
        private TypeUseAnnotation classAncestor_QualifiedName_TypeUse;
        private NameDefAnnotation fieldDeclaration_Identifier_NameDef;
        private NameDefAnnotation constDeclaration_Identifier_NameDef;
        private TypeUseAnnotation typeReference_TypeUse;
        private TypeConstructorAnnotation nullableType_TypeConstructor;
        private TypeConstructorAnnotation collectionType_TypeConstructor;
        private TypeUseAnnotation returnType_TypeUse;
        private ScopeAnnotation operationDeclaration_Scope;
        private TypeConstructorAnnotation operationDeclaration_TypeConstructor;
        private NameDefAnnotation operationDeclaration_Identifier_NameDef;
        private NameDefAnnotation parameter_Identifier_NameDef;
        private NameUseAnnotation associationDeclaration_Source_NameUse;
        private NameUseAnnotation associationDeclaration_Target_NameUse;
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
            this.namespaceDeclaration_Scope = new ScopeAnnotation();
            annotList.Add(this.namespaceDeclaration_Scope);
            this.namespaceDeclaration_QualifiedName_NameDef = new NameDefAnnotation();
            this.namespaceDeclaration_QualifiedName_NameDef.Kind = NameKind.Namespace;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.MetamodelDeclarationContext), annotList);
            this.metamodelDeclaration_TypeDef = new TypeDefAnnotation();
            annotList.Add(this.metamodelDeclaration_TypeDef);
            this.metamodelDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.metamodelDeclaration_Identifier_NameDef.Kind = NameKind.Metamodel;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.EnumDeclarationContext), annotList);
            this.enumDeclaration_TypeDef = new TypeDefAnnotation();
            annotList.Add(this.enumDeclaration_TypeDef);
            this.enumDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.enumDeclaration_Identifier_NameDef.Kind = NameKind.Enum;
            
            this.enumValue_Identifier_NameDef = new NameDefAnnotation();
            this.enumValue_Identifier_NameDef.Kind = NameKind.EnumValue;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ClassDeclarationContext), annotList);
            this.classDeclaration_TypeDef = new TypeDefAnnotation();
            annotList.Add(this.classDeclaration_TypeDef);
            this.classDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.classDeclaration_Identifier_NameDef.Kind = NameKind.Class;
            
            this.classAncestor_QualifiedName_TypeUse = new TypeUseAnnotation();
            this.classAncestor_QualifiedName_TypeUse.Kind = NameKind.Class;
            
            this.fieldDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.fieldDeclaration_Identifier_NameDef.Kind = NameKind.Property;
            
            this.constDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.constDeclaration_Identifier_NameDef.Kind = NameKind.Const;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.TypeReferenceContext), annotList);
            this.typeReference_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.typeReference_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.NullableTypeContext), annotList);
            this.nullableType_TypeConstructor = new TypeConstructorAnnotation();
            annotList.Add(this.nullableType_TypeConstructor);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.CollectionTypeContext), annotList);
            this.collectionType_TypeConstructor = new TypeConstructorAnnotation();
            annotList.Add(this.collectionType_TypeConstructor);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.ReturnTypeContext), annotList);
            this.returnType_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.returnType_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.OperationDeclarationContext), annotList);
            this.operationDeclaration_Scope = new ScopeAnnotation();
            annotList.Add(this.operationDeclaration_Scope);
            this.operationDeclaration_TypeConstructor = new TypeConstructorAnnotation();
            annotList.Add(this.operationDeclaration_TypeConstructor);
            this.operationDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.operationDeclaration_Identifier_NameDef.Kind = NameKind.Operation;
            
            this.parameter_Identifier_NameDef = new NameDefAnnotation();
            this.parameter_Identifier_NameDef.Kind = NameKind.Parameter;
            
            this.associationDeclaration_Source_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Source_NameUse.Kind = NameKind.Property;
            this.associationDeclaration_Target_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Target_NameUse.Kind = NameKind.Property;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaModelParser.IdentifierContext), annotList);
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
            MapAnnotation __tmp1 = new MapAnnotation();
            __tmp1.Type = "MetaNamespace";
            treeAnnotList.Add(__tmp1);
            treeAnnotList.Add(this.namespaceDeclaration_Scope);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.qualifiedName(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.qualifiedName(), elemAnnotList);
                }
                MapAnnotation __tmp2 = new MapAnnotation();
                __tmp2.Property = "Name";
                elemAnnotList.Add(__tmp2);
                elemAnnotList.Add(this.namespaceDeclaration_QualifiedName_NameDef);
            }
            if (context.stringLiteral() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.stringLiteral(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.stringLiteral(), elemAnnotList);
                }
                MapAnnotation __tmp3 = new MapAnnotation();
                __tmp3.Property = "Uri";
                elemAnnotList.Add(__tmp3);
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
            MapAnnotation __tmp4 = new MapAnnotation();
            __tmp4.Property = "Models";
            treeAnnotList.Add(__tmp4);
            MapAnnotation __tmp5 = new MapAnnotation();
            __tmp5.Type = "MetaModel";
            treeAnnotList.Add(__tmp5);
            treeAnnotList.Add(this.metamodelDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp6 = new MapAnnotation();
                __tmp6.Property = "Name";
                elemAnnotList.Add(__tmp6);
                elemAnnotList.Add(this.metamodelDeclaration_Identifier_NameDef);
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
            MapAnnotation __tmp7 = new MapAnnotation();
            __tmp7.Property = "Types";
            treeAnnotList.Add(__tmp7);
            MapAnnotation __tmp8 = new MapAnnotation();
            __tmp8.Type = "MetaEnum";
            treeAnnotList.Add(__tmp8);
            treeAnnotList.Add(this.enumDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp9 = new MapAnnotation();
                __tmp9.Property = "Name";
                elemAnnotList.Add(__tmp9);
                elemAnnotList.Add(this.enumDeclaration_Identifier_NameDef);
            }
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumValues(MetaModelParser.EnumValuesContext context)
        {
            return base.VisitEnumValues(context);
        }
        
        public override object VisitEnumValue(MetaModelParser.EnumValueContext context)
        {
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp10 = new MapAnnotation();
                __tmp10.Property = "EnumLiterals";
                elemAnnotList.Add(__tmp10);
                elemAnnotList.Add(this.enumValue_Identifier_NameDef);
            }
            return base.VisitEnumValue(context);
        }
        
        public override object VisitEnumMemberDeclaration(MetaModelParser.EnumMemberDeclarationContext context)
        {
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
            MapAnnotation __tmp11 = new MapAnnotation();
            __tmp11.Property = "Types";
            treeAnnotList.Add(__tmp11);
            MapAnnotation __tmp12 = new MapAnnotation();
            __tmp12.Type = "MetaClass";
            treeAnnotList.Add(__tmp12);
            treeAnnotList.Add(this.classDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.KAbstract(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.KAbstract(), elemAnnotList);
                }
                MapAnnotation __tmp13 = new MapAnnotation();
                __tmp13.Property = "IsAbstract";
                __tmp13.Value = true;
                elemAnnotList.Add(__tmp13);
            }
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp14 = new MapAnnotation();
                __tmp14.Property = "Name";
                elemAnnotList.Add(__tmp14);
                elemAnnotList.Add(this.classDeclaration_Identifier_NameDef);
            }
            return base.VisitClassDeclaration(context);
        }
        
        public override object VisitClassAncestors(MetaModelParser.ClassAncestorsContext context)
        {
            return base.VisitClassAncestors(context);
        }
        
        public override object VisitClassAncestor(MetaModelParser.ClassAncestorContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            MapAnnotation __tmp15 = new MapAnnotation();
            __tmp15.Property = "Ancestors";
            treeAnnotList.Add(__tmp15);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.qualifiedName(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.qualifiedName(), elemAnnotList);
                }
                elemAnnotList.Add(this.classAncestor_QualifiedName_TypeUse);
            }
            return base.VisitClassAncestor(context);
        }
        
        public override object VisitClassMemberDeclaration(MetaModelParser.ClassMemberDeclarationContext context)
        {
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
            MapAnnotation __tmp16 = new MapAnnotation();
            __tmp16.Property = "Properties";
            treeAnnotList.Add(__tmp16);
            MapAnnotation __tmp17 = new MapAnnotation();
            __tmp17.Type = "MetaProperty";
            treeAnnotList.Add(__tmp17);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.typeReference(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.typeReference(), elemAnnotList);
                }
                MapAnnotation __tmp18 = new MapAnnotation();
                __tmp18.Property = "Type";
                elemAnnotList.Add(__tmp18);
            }
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp19 = new MapAnnotation();
                __tmp19.Property = "Name";
                elemAnnotList.Add(__tmp19);
                elemAnnotList.Add(this.fieldDeclaration_Identifier_NameDef);
            }
            return base.VisitFieldDeclaration(context);
        }
        
        public override object VisitConstDeclaration(MetaModelParser.ConstDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                elemAnnotList.Add(this.constDeclaration_Identifier_NameDef);
            }
            return base.VisitConstDeclaration(context);
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
            return base.VisitSimpleType(context);
        }
        
        public override object VisitNullableType(MetaModelParser.NullableTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.nullableType_TypeConstructor);
            return base.VisitNullableType(context);
        }
        
        public override object VisitObjectType(MetaModelParser.ObjectTypeContext context)
        {
            return base.VisitObjectType(context);
        }
        
        public override object VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
        {
            return base.VisitPrimitiveType(context);
        }
        
        public override object VisitCollectionType(MetaModelParser.CollectionTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.collectionType_TypeConstructor);
            return base.VisitCollectionType(context);
        }
        
        public override object VisitVoidType(MetaModelParser.VoidTypeContext context)
        {
            return base.VisitVoidType(context);
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
        
        public override object VisitOperationDeclaration(MetaModelParser.OperationDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            MapAnnotation __tmp20 = new MapAnnotation();
            __tmp20.Property = "Operations";
            treeAnnotList.Add(__tmp20);
            MapAnnotation __tmp21 = new MapAnnotation();
            __tmp21.Type = "MetaOperation";
            treeAnnotList.Add(__tmp21);
            treeAnnotList.Add(this.operationDeclaration_Scope);
            treeAnnotList.Add(this.operationDeclaration_TypeConstructor);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.returnType(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.returnType(), elemAnnotList);
                }
                MapAnnotation __tmp22 = new MapAnnotation();
                __tmp22.Property = "ReturnType";
                elemAnnotList.Add(__tmp22);
            }
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp23 = new MapAnnotation();
                __tmp23.Property = "Name";
                elemAnnotList.Add(__tmp23);
                elemAnnotList.Add(this.operationDeclaration_Identifier_NameDef);
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
            MapAnnotation __tmp24 = new MapAnnotation();
            __tmp24.Property = "Parameters";
            treeAnnotList.Add(__tmp24);
            MapAnnotation __tmp25 = new MapAnnotation();
            __tmp25.Type = "MetaParameter";
            treeAnnotList.Add(__tmp25);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.typeReference(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.typeReference(), elemAnnotList);
                }
                MapAnnotation __tmp26 = new MapAnnotation();
                __tmp26.Property = "Type";
                elemAnnotList.Add(__tmp26);
            }
            if (context.identifier() != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.identifier(), elemAnnotList);
                }
                MapAnnotation __tmp27 = new MapAnnotation();
                __tmp27.Property = "Name";
                elemAnnotList.Add(__tmp27);
                elemAnnotList.Add(this.parameter_Identifier_NameDef);
            }
            return base.VisitParameter(context);
        }
        
        public override object VisitExpression(MetaModelParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }
        
        public override object VisitAssociationDeclaration(MetaModelParser.AssociationDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (context.source != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.source, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.source, elemAnnotList);
                }
                MapAnnotation __tmp28 = new MapAnnotation();
                __tmp28.Object = context.target;
                __tmp28.Property = "Opposites";
                elemAnnotList.Add(__tmp28);
                elemAnnotList.Add(this.associationDeclaration_Source_NameUse);
            }
            if (context.target != null)
            {
                if (!this.treeAnnotations.TryGetValue(context.target, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(context.target, elemAnnotList);
                }
                MapAnnotation __tmp29 = new MapAnnotation();
                __tmp29.Object = context.source;
                __tmp29.Property = "Opposites";
                elemAnnotList.Add(__tmp29);
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
        
        public override object VisitNumberLiteral(MetaModelParser.NumberLiteralContext context)
        {
            return base.VisitNumberLiteral(context);
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
        
        public override object VisitDateOrTimeLiteral(MetaModelParser.DateOrTimeLiteralContext context)
        {
            return base.VisitDateOrTimeLiteral(context);
        }
        
        public override object VisitDateTimeOffsetLiteral(MetaModelParser.DateTimeOffsetLiteralContext context)
        {
            return base.VisitDateTimeOffsetLiteral(context);
        }
        
        public override object VisitDateTimeLiteral(MetaModelParser.DateTimeLiteralContext context)
        {
            return base.VisitDateTimeLiteral(context);
        }
        
        public override object VisitDateLiteral(MetaModelParser.DateLiteralContext context)
        {
            return base.VisitDateLiteral(context);
        }
        
        public override object VisitTimeLiteral(MetaModelParser.TimeLiteralContext context)
        {
            return base.VisitTimeLiteral(context);
        }
        
        public override object VisitStringLiteral(MetaModelParser.StringLiteralContext context)
        {
            return base.VisitStringLiteral(context);
        }
        
        public override object VisitGuidLiteral(MetaModelParser.GuidLiteralContext context)
        {
            return base.VisitGuidLiteral(context);
        }
    }
}

