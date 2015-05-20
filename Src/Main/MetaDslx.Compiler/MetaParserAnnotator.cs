using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MetaDslx.Compiler
{
    internal class MetaParserAnnotator : MetaParserBaseVisitor<object>
    {
        private MetaLexerAnnotator lexerAnnotator = new MetaLexerAnnotator();
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
        private NameDefAnnotation enumValues_IdentifierList_NameDef;
        private TypeDefAnnotation classDeclaration_TypeDef;
        private NameDefAnnotation classDeclaration_Identifier_NameDef;
        private TypeUseAnnotation classAncestor_QualifiedName_TypeUse;
        private NameDefAnnotation fieldDeclaration_Identifier_NameDef;
        private NameDefAnnotation constDeclaration_Identifier_NameDef;
        private TypeUseAnnotation typeReference_TypeUse;
        private TypeUseAnnotation returnType_TypeUse;
        private ScopeAnnotation operationDeclaration_Scope;
        private NameDefAnnotation operationDeclaration_Identifier_NameDef;
        private NameDefAnnotation parameter_Identifier_NameDef;
        private NameUseAnnotation associationDeclaration_Source_NameUse;
        private NameUseAnnotation associationDeclaration_Target_NameUse;
        private IdentifierAnnotation identifier_Identifier;
        
        public MetaParserAnnotator()
        {
            List<object> annotList = null;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.QualifiedNameContext), annotList);
            this.qualifiedName_QualifiedName = new QualifiedNameAnnotation();
            annotList.Add(this.qualifiedName_QualifiedName);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.NamespaceDeclarationContext), annotList);
            this.namespaceDeclaration_Scope = new ScopeAnnotation();
            annotList.Add(this.namespaceDeclaration_Scope);
            this.namespaceDeclaration_QualifiedName_NameDef = new NameDefAnnotation();
            this.namespaceDeclaration_QualifiedName_NameDef.Kind = NameKind.Namespace;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.MetamodelDeclarationContext), annotList);
            this.metamodelDeclaration_TypeDef = new TypeDefAnnotation();
            annotList.Add(this.metamodelDeclaration_TypeDef);
            this.metamodelDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.metamodelDeclaration_Identifier_NameDef.Kind = NameKind.Metamodel;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.EnumDeclarationContext), annotList);
            this.enumDeclaration_TypeDef = new TypeDefAnnotation();
            annotList.Add(this.enumDeclaration_TypeDef);
            this.enumDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.enumDeclaration_Identifier_NameDef.Kind = NameKind.Enum;
            
            this.enumValues_IdentifierList_NameDef = new NameDefAnnotation();
            this.enumValues_IdentifierList_NameDef.Kind = NameKind.EnumValue;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.ClassDeclarationContext), annotList);
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
            this.ruleAnnotations.Add(typeof(MetaParser.TypeReferenceContext), annotList);
            this.typeReference_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.typeReference_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.ReturnTypeContext), annotList);
            this.returnType_TypeUse = new TypeUseAnnotation();
            annotList.Add(this.returnType_TypeUse);
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.OperationDeclarationContext), annotList);
            this.operationDeclaration_Scope = new ScopeAnnotation();
            annotList.Add(this.operationDeclaration_Scope);
            this.operationDeclaration_Identifier_NameDef = new NameDefAnnotation();
            this.operationDeclaration_Identifier_NameDef.Kind = NameKind.Operation;
            
            this.parameter_Identifier_NameDef = new NameDefAnnotation();
            this.parameter_Identifier_NameDef.Kind = NameKind.Parameter;
            
            this.associationDeclaration_Source_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Source_NameUse.Kind = NameKind.Property;
            this.associationDeclaration_Target_NameUse = new NameUseAnnotation();
            this.associationDeclaration_Target_NameUse.Kind = NameKind.Property;
            
            annotList = new List<object>();
            this.ruleAnnotations.Add(typeof(MetaParser.IdentifierContext), annotList);
            this.identifier_Identifier = new IdentifierAnnotation();
            annotList.Add(this.identifier_Identifier);
        }
        
        public override object VisitTerminal(ITerminalNode node)
        {
            return this.lexerAnnotator.VisitTerminal(node, treeAnnotations);
        }
        
        public override object VisitMain(MetaParser.MainContext context)
        {
            return base.VisitMain(context);
        }
        
        public override object VisitQualifiedName(MetaParser.QualifiedNameContext context)
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
        
        public override object VisitIdentifierList(MetaParser.IdentifierListContext context)
        {
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitQualifiedNameList(MetaParser.QualifiedNameListContext context)
        {
            return base.VisitQualifiedNameList(context);
        }
        
        public override object VisitNamespaceDeclaration(MetaParser.NamespaceDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.namespaceDeclaration_Scope);
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.qualifiedName(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.qualifiedName(), elemAnnotList);
            }
            elemAnnotList.Add(this.namespaceDeclaration_QualifiedName_NameDef);
            return base.VisitNamespaceDeclaration(context);
        }
        
        public override object VisitMetamodelDeclaration(MetaParser.MetamodelDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.metamodelDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.metamodelDeclaration_Identifier_NameDef);
            return base.VisitMetamodelDeclaration(context);
        }
        
        public override object VisitDeclaration(MetaParser.DeclarationContext context)
        {
            return base.VisitDeclaration(context);
        }
        
        public override object VisitEnumDeclaration(MetaParser.EnumDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.enumDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.enumDeclaration_Identifier_NameDef);
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumValues(MetaParser.EnumValuesContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifierList(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifierList(), elemAnnotList);
            }
            elemAnnotList.Add(this.enumValues_IdentifierList_NameDef);
            return base.VisitEnumValues(context);
        }
        
        public override object VisitEnumMemberDeclaration(MetaParser.EnumMemberDeclarationContext context)
        {
            return base.VisitEnumMemberDeclaration(context);
        }
        
        public override object VisitClassDeclaration(MetaParser.ClassDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.classDeclaration_TypeDef);
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.classDeclaration_Identifier_NameDef);
            return base.VisitClassDeclaration(context);
        }
        
        public override object VisitClassAncestors(MetaParser.ClassAncestorsContext context)
        {
            return base.VisitClassAncestors(context);
        }
        
        public override object VisitClassAncestor(MetaParser.ClassAncestorContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.qualifiedName(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.qualifiedName(), elemAnnotList);
            }
            elemAnnotList.Add(this.classAncestor_QualifiedName_TypeUse);
            return base.VisitClassAncestor(context);
        }
        
        public override object VisitClassMemberDeclaration(MetaParser.ClassMemberDeclarationContext context)
        {
            return base.VisitClassMemberDeclaration(context);
        }
        
        public override object VisitFieldDeclaration(MetaParser.FieldDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.fieldDeclaration_Identifier_NameDef);
            return base.VisitFieldDeclaration(context);
        }
        
        public override object VisitConstDeclaration(MetaParser.ConstDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.constDeclaration_Identifier_NameDef);
            return base.VisitConstDeclaration(context);
        }
        
        public override object VisitTypeReference(MetaParser.TypeReferenceContext context)
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
        
        public override object VisitSimpleType(MetaParser.SimpleTypeContext context)
        {
            return base.VisitSimpleType(context);
        }
        
        public override object VisitNullableType(MetaParser.NullableTypeContext context)
        {
            return base.VisitNullableType(context);
        }
        
        public override object VisitObjectType(MetaParser.ObjectTypeContext context)
        {
            return base.VisitObjectType(context);
        }
        
        public override object VisitPrimitiveType(MetaParser.PrimitiveTypeContext context)
        {
            return base.VisitPrimitiveType(context);
        }
        
        public override object VisitCollectionType(MetaParser.CollectionTypeContext context)
        {
            return base.VisitCollectionType(context);
        }
        
        public override object VisitVoidType(MetaParser.VoidTypeContext context)
        {
            return base.VisitVoidType(context);
        }
        
        public override object VisitReturnType(MetaParser.ReturnTypeContext context)
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
        
        public override object VisitOperationDeclaration(MetaParser.OperationDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            treeAnnotList.Add(this.operationDeclaration_Scope);
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.operationDeclaration_Identifier_NameDef);
            return base.VisitOperationDeclaration(context);
        }
        
        public override object VisitParameterList(MetaParser.ParameterListContext context)
        {
            return base.VisitParameterList(context);
        }
        
        public override object VisitParameter(MetaParser.ParameterContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.identifier(), out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.identifier(), elemAnnotList);
            }
            elemAnnotList.Add(this.parameter_Identifier_NameDef);
            return base.VisitParameter(context);
        }
        
        public override object VisitExpression(MetaParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }
        
        public override object VisitAssociationDeclaration(MetaParser.AssociationDeclarationContext context)
        {
            List<object> elemAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context.source, out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.source, elemAnnotList);
            }
            elemAnnotList.Add(this.associationDeclaration_Source_NameUse);
            if (!this.treeAnnotations.TryGetValue(context.target, out elemAnnotList))
            {
                elemAnnotList = new List<object>();
                this.treeAnnotations.Add(context.target, elemAnnotList);
            }
            elemAnnotList.Add(this.associationDeclaration_Target_NameUse);
            return base.VisitAssociationDeclaration(context);
        }
        
        public override object VisitIdentifier(MetaParser.IdentifierContext context)
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
        
        public override object VisitLiteral(MetaParser.LiteralContext context)
        {
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(MetaParser.NullLiteralContext context)
        {
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(MetaParser.BooleanLiteralContext context)
        {
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitNumberLiteral(MetaParser.NumberLiteralContext context)
        {
            return base.VisitNumberLiteral(context);
        }
        
        public override object VisitIntegerLiteral(MetaParser.IntegerLiteralContext context)
        {
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(MetaParser.DecimalLiteralContext context)
        {
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(MetaParser.ScientificLiteralContext context)
        {
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitDateOrTimeLiteral(MetaParser.DateOrTimeLiteralContext context)
        {
            return base.VisitDateOrTimeLiteral(context);
        }
        
        public override object VisitDateTimeOffsetLiteral(MetaParser.DateTimeOffsetLiteralContext context)
        {
            return base.VisitDateTimeOffsetLiteral(context);
        }
        
        public override object VisitDateTimeLiteral(MetaParser.DateTimeLiteralContext context)
        {
            return base.VisitDateTimeLiteral(context);
        }
        
        public override object VisitDateLiteral(MetaParser.DateLiteralContext context)
        {
            return base.VisitDateLiteral(context);
        }
        
        public override object VisitTimeLiteral(MetaParser.TimeLiteralContext context)
        {
            return base.VisitTimeLiteral(context);
        }
        
        public override object VisitStringLiteral(MetaParser.StringLiteralContext context)
        {
            return base.VisitStringLiteral(context);
        }
        
        public override object VisitGuidLiteral(MetaParser.GuidLiteralContext context)
        {
            return base.VisitGuidLiteral(context);
        }
    }
}

