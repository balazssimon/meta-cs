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
    
using MetaDslx.Core;

    public class MetaModelParserAnnotator : MetaModelParserBaseVisitor<object>
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
        
        
        public MetaModelParserAnnotator()
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
                            ModelCompilerContext.RequireContext();
                            IModelCompiler compiler = ModelCompilerContext.Current;
                            string name = compiler.NameProvider.GetName(node);
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
            QualifiedNameAnnotation __tmp1 = new QualifiedNameAnnotation();
            treeAnnotList.Add(__tmp1);
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
            PropertyAnnotation __tmp2 = new PropertyAnnotation();
            __tmp2.Name = "Annotations";
            treeAnnotList.Add(__tmp2);
            SymbolAnnotation __tmp3 = new SymbolAnnotation();
            __tmp3.SymbolType = typeof(MetaAnnotation);
            treeAnnotList.Add(__tmp3);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp4 = new PropertyAnnotation();
                __tmp4.Name = "Name";
                elemAnnotList.Add(__tmp4);
                ValueAnnotation __tmp5 = new ValueAnnotation();
                elemAnnotList.Add(__tmp5);
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
            PropertyAnnotation __tmp6 = new PropertyAnnotation();
            __tmp6.Name = "Properties";
            treeAnnotList.Add(__tmp6);
            SymbolAnnotation __tmp7 = new SymbolAnnotation();
            __tmp7.SymbolType = typeof(MetaAnnotationProperty);
            treeAnnotList.Add(__tmp7);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp8 = new PropertyAnnotation();
                __tmp8.Name = "Name";
                elemAnnotList.Add(__tmp8);
                ValueAnnotation __tmp9 = new ValueAnnotation();
                elemAnnotList.Add(__tmp9);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp10 = new PropertyAnnotation();
                __tmp10.Name = "Value";
                elemAnnotList.Add(__tmp10);
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
            NameDefAnnotation __tmp11 = new NameDefAnnotation();
            __tmp11.SymbolType = typeof(MetaNamespace);
            __tmp11.NestingProperty = "Namespaces";
            __tmp11.Merge = true;
            treeAnnotList.Add(__tmp11);
            TriviaAnnotation __tmp12 = new TriviaAnnotation();
            __tmp12.Property = "Documentation";
            treeAnnotList.Add(__tmp12);
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
            PropertyAnnotation __tmp13 = new PropertyAnnotation();
            __tmp13.Name = "MetaModel";
            treeAnnotList.Add(__tmp13);
            NameDefAnnotation __tmp14 = new NameDefAnnotation();
            __tmp14.SymbolType = typeof(MetaModel);
            treeAnnotList.Add(__tmp14);
            TriviaAnnotation __tmp15 = new TriviaAnnotation();
            __tmp15.Property = "Documentation";
            treeAnnotList.Add(__tmp15);
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
            PropertyAnnotation __tmp16 = new PropertyAnnotation();
            treeAnnotList.Add(__tmp16);
            List<object> elemAnnotList = null;
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp17 = new ValueAnnotation();
                elemAnnotList.Add(__tmp17);
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
            PropertyAnnotation __tmp18 = new PropertyAnnotation();
            __tmp18.Name = "Declarations";
            treeAnnotList.Add(__tmp18);
            TypeDefAnnotation __tmp19 = new TypeDefAnnotation();
            __tmp19.SymbolType = typeof(MetaEnum);
            treeAnnotList.Add(__tmp19);
            TriviaAnnotation __tmp20 = new TriviaAnnotation();
            __tmp20.Property = "Documentation";
            treeAnnotList.Add(__tmp20);
            List<object> elemAnnotList = null;
            if (context.enumValues() != null)
            {
                object elem = context.enumValues();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp21 = new PropertyAnnotation();
                __tmp21.Name = "EnumLiterals";
                elemAnnotList.Add(__tmp21);
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
            NameDefAnnotation __tmp22 = new NameDefAnnotation();
            __tmp22.SymbolType = typeof(MetaEnumLiteral);
            treeAnnotList.Add(__tmp22);
            TriviaAnnotation __tmp23 = new TriviaAnnotation();
            __tmp23.Property = "Documentation";
            treeAnnotList.Add(__tmp23);
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
                PropertyAnnotation __tmp24 = new PropertyAnnotation();
                __tmp24.Name = "Operations";
                elemAnnotList.Add(__tmp24);
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
            PropertyAnnotation __tmp25 = new PropertyAnnotation();
            __tmp25.Name = "Declarations";
            treeAnnotList.Add(__tmp25);
            TypeDefAnnotation __tmp26 = new TypeDefAnnotation();
            __tmp26.SymbolType = typeof(MetaClass);
            treeAnnotList.Add(__tmp26);
            TriviaAnnotation __tmp27 = new TriviaAnnotation();
            __tmp27.Property = "Documentation";
            treeAnnotList.Add(__tmp27);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp28 = new PropertyAnnotation();
                __tmp28.Name = "IsAbstract";
                __tmp28.Value = true;
                elemAnnotList.Add(__tmp28);
            }
            if (context.classAncestors() != null)
            {
                object elem = context.classAncestors();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp29 = new PropertyAnnotation();
                __tmp29.Name = "SuperClasses";
                elemAnnotList.Add(__tmp29);
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
                TypeUseAnnotation __tmp30 = new TypeUseAnnotation();
                __tmp30.SymbolTypes.Add(typeof(MetaClass));
                __tmp30.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp30);
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
                PropertyAnnotation __tmp31 = new PropertyAnnotation();
                __tmp31.Name = "Properties";
                elemAnnotList.Add(__tmp31);
            }
            if (context.operationDeclaration() != null)
            {
                object elem = context.operationDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp32 = new PropertyAnnotation();
                __tmp32.Name = "Operations";
                elemAnnotList.Add(__tmp32);
            }
            if (context.constructorDeclaration() != null)
            {
                object elem = context.constructorDeclaration();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp33 = new PropertyAnnotation();
                __tmp33.Name = "Constructor";
                elemAnnotList.Add(__tmp33);
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
            NameDefAnnotation __tmp34 = new NameDefAnnotation();
            __tmp34.SymbolType = typeof(MetaProperty);
            treeAnnotList.Add(__tmp34);
            TriviaAnnotation __tmp35 = new TriviaAnnotation();
            __tmp35.Property = "Documentation";
            treeAnnotList.Add(__tmp35);
            List<object> elemAnnotList = null;
            if (context.fieldModifier() != null)
            {
                object elem = context.fieldModifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp36 = new PropertyAnnotation();
                __tmp36.Name = "Kind";
                elemAnnotList.Add(__tmp36);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp37 = new PropertyAnnotation();
                __tmp37.Name = "Type";
                elemAnnotList.Add(__tmp37);
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
                ValueAnnotation __tmp38 = new ValueAnnotation();
                __tmp38.Value = MetaPropertyKind.Containment;
                elemAnnotList.Add(__tmp38);
            }
            if (context.KReadonly() != null)
            {
                object elem = context.KReadonly();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp39 = new ValueAnnotation();
                __tmp39.Value = MetaPropertyKind.Readonly;
                elemAnnotList.Add(__tmp39);
            }
            if (context.KLazy() != null)
            {
                object elem = context.KLazy();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp40 = new ValueAnnotation();
                __tmp40.Value = MetaPropertyKind.Lazy;
                elemAnnotList.Add(__tmp40);
            }
            if (context.KDerived() != null)
            {
                object elem = context.KDerived();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp41 = new ValueAnnotation();
                __tmp41.Value = MetaPropertyKind.Derived;
                elemAnnotList.Add(__tmp41);
            }
            if (context.KSynthetized() != null)
            {
                object elem = context.KSynthetized();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp42 = new ValueAnnotation();
                __tmp42.Value = MetaPropertyKind.Synthetized;
                elemAnnotList.Add(__tmp42);
            }
            if (context.KInherited() != null)
            {
                object elem = context.KInherited();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp43 = new ValueAnnotation();
                __tmp43.Value = MetaPropertyKind.Inherited;
                elemAnnotList.Add(__tmp43);
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
                PropertyAnnotation __tmp44 = new PropertyAnnotation();
                __tmp44.Name = "RedefinedProperties";
                elemAnnotList.Add(__tmp44);
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
                PropertyAnnotation __tmp45 = new PropertyAnnotation();
                __tmp45.Name = "SubsettedProperties";
                elemAnnotList.Add(__tmp45);
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
                    NameUseAnnotation __tmp46 = new NameUseAnnotation();
                    __tmp46.SymbolTypes.Add(typeof(MetaProperty));
                    elemAnnotList.Add(__tmp46);
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
            PropertyAnnotation __tmp47 = new PropertyAnnotation();
            __tmp47.Name = "Declarations";
            treeAnnotList.Add(__tmp47);
            NameDefAnnotation __tmp48 = new NameDefAnnotation();
            __tmp48.SymbolType = typeof(MetaConstant);
            treeAnnotList.Add(__tmp48);
            TriviaAnnotation __tmp49 = new TriviaAnnotation();
            __tmp49.Property = "Documentation";
            treeAnnotList.Add(__tmp49);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp50 = new PropertyAnnotation();
                __tmp50.Name = "Type";
                elemAnnotList.Add(__tmp50);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp51 = new PropertyAnnotation();
                __tmp51.Name = "Value";
                elemAnnotList.Add(__tmp51);
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
            PropertyAnnotation __tmp52 = new PropertyAnnotation();
            __tmp52.Name = "Declarations";
            treeAnnotList.Add(__tmp52);
            NameDefAnnotation __tmp53 = new NameDefAnnotation();
            __tmp53.SymbolType = typeof(MetaGlobalFunction);
            __tmp53.Overload = true;
            treeAnnotList.Add(__tmp53);
            TriviaAnnotation __tmp54 = new TriviaAnnotation();
            __tmp54.Property = "Documentation";
            treeAnnotList.Add(__tmp54);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp55 = new PropertyAnnotation();
                __tmp55.Name = "ReturnType";
                elemAnnotList.Add(__tmp55);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp56 = new PropertyAnnotation();
                __tmp56.Name = "Parameters";
                elemAnnotList.Add(__tmp56);
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
            TypeUseAnnotation __tmp57 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp57);
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
            TypeUseAnnotation __tmp58 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp58);
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
            TypeUseAnnotation __tmp59 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp59);
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
            TypeUseAnnotation __tmp60 = new TypeUseAnnotation();
            treeAnnotList.Add(__tmp60);
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
            TypeUseAnnotation __tmp61 = new TypeUseAnnotation();
            __tmp61.SymbolTypes.Add(typeof(MetaClass));
            treeAnnotList.Add(__tmp61);
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
            NameAnnotation __tmp62 = new NameAnnotation();
            treeAnnotList.Add(__tmp62);
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
            NameAnnotation __tmp63 = new NameAnnotation();
            treeAnnotList.Add(__tmp63);
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
            NameAnnotation __tmp64 = new NameAnnotation();
            treeAnnotList.Add(__tmp64);
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
                PreDefSymbolAnnotation __tmp65 = new PreDefSymbolAnnotation();
                __tmp65.Value = MetaInstance.Any;
                elemAnnotList.Add(__tmp65);
            }
            if (context.KNone() != null)
            {
                object elem = context.KNone();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PreDefSymbolAnnotation __tmp66 = new PreDefSymbolAnnotation();
                __tmp66.Value = MetaInstance.None;
                elemAnnotList.Add(__tmp66);
            }
            if (context.KError() != null)
            {
                object elem = context.KError();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PreDefSymbolAnnotation __tmp67 = new PreDefSymbolAnnotation();
                __tmp67.Value = MetaInstance.Error;
                elemAnnotList.Add(__tmp67);
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
            TypeCtrAnnotation __tmp68 = new TypeCtrAnnotation();
            __tmp68.SymbolType = typeof(MetaNullableType);
            treeAnnotList.Add(__tmp68);
            List<object> elemAnnotList = null;
            if (context.primitiveType() != null)
            {
                object elem = context.primitiveType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp69 = new PropertyAnnotation();
                __tmp69.Name = "InnerType";
                elemAnnotList.Add(__tmp69);
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
            TypeCtrAnnotation __tmp70 = new TypeCtrAnnotation();
            __tmp70.SymbolType = typeof(MetaCollectionType);
            treeAnnotList.Add(__tmp70);
            List<object> elemAnnotList = null;
            if (context.collectionKind() != null)
            {
                object elem = context.collectionKind();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp71 = new PropertyAnnotation();
                __tmp71.Name = "Kind";
                elemAnnotList.Add(__tmp71);
            }
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp72 = new PropertyAnnotation();
                __tmp72.Name = "InnerType";
                elemAnnotList.Add(__tmp72);
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
                ValueAnnotation __tmp73 = new ValueAnnotation();
                __tmp73.Value = MetaCollectionKind.Set;
                elemAnnotList.Add(__tmp73);
            }
            if (context.KList() != null)
            {
                object elem = context.KList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp74 = new ValueAnnotation();
                __tmp74.Value = MetaCollectionKind.List;
                elemAnnotList.Add(__tmp74);
            }
            if (context.KMultiSet() != null)
            {
                object elem = context.KMultiSet();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp75 = new ValueAnnotation();
                __tmp75.Value = MetaCollectionKind.MultiSet;
                elemAnnotList.Add(__tmp75);
            }
            if (context.KMultiList() != null)
            {
                object elem = context.KMultiList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp76 = new ValueAnnotation();
                __tmp76.Value = MetaCollectionKind.MultiList;
                elemAnnotList.Add(__tmp76);
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
            NameDefAnnotation __tmp77 = new NameDefAnnotation();
            __tmp77.SymbolType = typeof(MetaOperation);
            treeAnnotList.Add(__tmp77);
            TriviaAnnotation __tmp78 = new TriviaAnnotation();
            __tmp78.Property = "Documentation";
            treeAnnotList.Add(__tmp78);
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp79 = new PropertyAnnotation();
                __tmp79.Name = "ReturnType";
                elemAnnotList.Add(__tmp79);
            }
            if (context.parameterList() != null)
            {
                object elem = context.parameterList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp80 = new PropertyAnnotation();
                __tmp80.Name = "Parameters";
                elemAnnotList.Add(__tmp80);
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
            NameDefAnnotation __tmp81 = new NameDefAnnotation();
            __tmp81.SymbolType = typeof(MetaParameter);
            treeAnnotList.Add(__tmp81);
            TriviaAnnotation __tmp82 = new TriviaAnnotation();
            __tmp82.Property = "Documentation";
            treeAnnotList.Add(__tmp82);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp83 = new PropertyAnnotation();
                __tmp83.Name = "Type";
                elemAnnotList.Add(__tmp83);
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
            NameDefAnnotation __tmp84 = new NameDefAnnotation();
            __tmp84.SymbolType = typeof(MetaConstructor);
            treeAnnotList.Add(__tmp84);
            TriviaAnnotation __tmp85 = new TriviaAnnotation();
            __tmp85.Property = "Documentation";
            treeAnnotList.Add(__tmp85);
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
                    PropertyAnnotation __tmp86 = new PropertyAnnotation();
                    __tmp86.Name = "Initializers";
                    elemAnnotList.Add(__tmp86);
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
            SymbolAnnotation __tmp87 = new SymbolAnnotation();
            __tmp87.SymbolType = typeof(MetaSynthetizedPropertyInitializer);
            treeAnnotList.Add(__tmp87);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp88 = new PropertyAnnotation();
                __tmp88.Name = "PropertyContext";
                elemAnnotList.Add(__tmp88);
                TypeUseAnnotation __tmp89 = new TypeUseAnnotation();
                __tmp89.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp89);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp90 = new PropertyAnnotation();
                __tmp90.Name = "PropertyName";
                elemAnnotList.Add(__tmp90);
                ValueAnnotation __tmp91 = new ValueAnnotation();
                elemAnnotList.Add(__tmp91);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
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
            SymbolAnnotation __tmp93 = new SymbolAnnotation();
            __tmp93.SymbolType = typeof(MetaInheritedPropertyInitializer);
            treeAnnotList.Add(__tmp93);
            List<object> elemAnnotList = null;
            if (context.@object != null)
            {
                object elem = context.@object;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp94 = new PropertyAnnotation();
                __tmp94.Name = "ObjectName";
                elemAnnotList.Add(__tmp94);
                ValueAnnotation __tmp95 = new ValueAnnotation();
                elemAnnotList.Add(__tmp95);
            }
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp96 = new PropertyAnnotation();
                __tmp96.Name = "PropertyContext";
                elemAnnotList.Add(__tmp96);
                TypeUseAnnotation __tmp97 = new TypeUseAnnotation();
                __tmp97.SymbolTypes.Add(typeof(MetaClass));
                elemAnnotList.Add(__tmp97);
            }
            if (context.property != null)
            {
                object elem = context.property;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp98 = new PropertyAnnotation();
                __tmp98.Name = "PropertyName";
                elemAnnotList.Add(__tmp98);
                ValueAnnotation __tmp99 = new ValueAnnotation();
                elemAnnotList.Add(__tmp99);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp100 = new PropertyAnnotation();
                __tmp100.Name = "Value";
                elemAnnotList.Add(__tmp100);
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
            SymbolAnnotation __tmp101 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp101);
            ExpressionAnnotation __tmp102 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp102);
            SymbolTypeAnnotation __tmp103 = new SymbolTypeAnnotation();
            __tmp103.SymbolType = typeof(MetaTypeCastExpression);
            treeAnnotList.Add(__tmp103);
            List<object> elemAnnotList = null;
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp104 = new PropertyAnnotation();
                __tmp104.Name = "TypeReference";
                elemAnnotList.Add(__tmp104);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp105 = new PropertyAnnotation();
                __tmp105.Name = "Expression";
                elemAnnotList.Add(__tmp105);
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
            SymbolAnnotation __tmp106 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp106);
            ExpressionAnnotation __tmp107 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp107);
            SymbolTypeAnnotation __tmp108 = new SymbolTypeAnnotation();
            __tmp108.SymbolType = typeof(MetaTypeOfExpression);
            treeAnnotList.Add(__tmp108);
            List<object> elemAnnotList = null;
            if (context.typeOfReference() != null)
            {
                object elem = context.typeOfReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp109 = new PropertyAnnotation();
                __tmp109.Name = "TypeReference";
                elemAnnotList.Add(__tmp109);
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
            SymbolAnnotation __tmp110 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp110);
            ExpressionAnnotation __tmp111 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp111);
            SymbolTypeAnnotation __tmp112 = new SymbolTypeAnnotation();
            __tmp112.SymbolType = typeof(MetaBracketExpression);
            treeAnnotList.Add(__tmp112);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp113 = new PropertyAnnotation();
                __tmp113.Name = "Expression";
                elemAnnotList.Add(__tmp113);
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
            SymbolAnnotation __tmp114 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp114);
            ExpressionAnnotation __tmp115 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp115);
            SymbolTypeAnnotation __tmp116 = new SymbolTypeAnnotation();
            __tmp116.SymbolType = typeof(MetaThisExpression);
            treeAnnotList.Add(__tmp116);
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
            SymbolAnnotation __tmp117 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp117);
            ExpressionAnnotation __tmp118 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp118);
            SymbolTypeAnnotation __tmp119 = new SymbolTypeAnnotation();
            __tmp119.SymbolType = typeof(MetaConstantExpression);
            treeAnnotList.Add(__tmp119);
            List<object> elemAnnotList = null;
            if (context.value != null)
            {
                object elem = context.value;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp120 = new PropertyAnnotation();
                __tmp120.Name = "Value";
                elemAnnotList.Add(__tmp120);
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
            SymbolAnnotation __tmp121 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp121);
            ExpressionAnnotation __tmp122 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp122);
            SymbolTypeAnnotation __tmp123 = new SymbolTypeAnnotation();
            __tmp123.SymbolType = typeof(MetaIdentifierExpression);
            treeAnnotList.Add(__tmp123);
            List<object> elemAnnotList = null;
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp124 = new ValueAnnotation();
                elemAnnotList.Add(__tmp124);
                PropertyAnnotation __tmp125 = new PropertyAnnotation();
                __tmp125.Name = "Name";
                elemAnnotList.Add(__tmp125);
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
            SymbolAnnotation __tmp126 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp126);
            ExpressionAnnotation __tmp127 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp127);
            SymbolTypeAnnotation __tmp128 = new SymbolTypeAnnotation();
            __tmp128.SymbolType = typeof(MetaIndexerExpression);
            treeAnnotList.Add(__tmp128);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp129 = new PropertyAnnotation();
                __tmp129.Name = "Expression";
                elemAnnotList.Add(__tmp129);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp130 = new PropertyAnnotation();
                __tmp130.Name = "Arguments";
                elemAnnotList.Add(__tmp130);
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
            SymbolAnnotation __tmp131 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp131);
            ExpressionAnnotation __tmp132 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp132);
            SymbolTypeAnnotation __tmp133 = new SymbolTypeAnnotation();
            __tmp133.SymbolType = typeof(MetaFunctionCallExpression);
            treeAnnotList.Add(__tmp133);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp134 = new PropertyAnnotation();
                __tmp134.Name = "Expression";
                elemAnnotList.Add(__tmp134);
            }
            if (context.expressionList() != null)
            {
                object elem = context.expressionList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp135 = new PropertyAnnotation();
                __tmp135.Name = "Arguments";
                elemAnnotList.Add(__tmp135);
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
            SymbolAnnotation __tmp136 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp136);
            ExpressionAnnotation __tmp137 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp137);
            SymbolTypeAnnotation __tmp138 = new SymbolTypeAnnotation();
            __tmp138.SymbolType = typeof(MetaMemberAccessExpression);
            treeAnnotList.Add(__tmp138);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp139 = new PropertyAnnotation();
                __tmp139.Name = "Expression";
                elemAnnotList.Add(__tmp139);
            }
            if (context.name != null)
            {
                object elem = context.name;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp140 = new ValueAnnotation();
                elemAnnotList.Add(__tmp140);
                PropertyAnnotation __tmp141 = new PropertyAnnotation();
                __tmp141.Name = "Name";
                elemAnnotList.Add(__tmp141);
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
            SymbolAnnotation __tmp142 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp142);
            ExpressionAnnotation __tmp143 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp143);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp144 = new PropertyAnnotation();
                __tmp144.Name = "Expression";
                elemAnnotList.Add(__tmp144);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp145 = new PropertyAnnotation();
                __tmp145.Name = "Kind";
                elemAnnotList.Add(__tmp145);
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
            SymbolAnnotation __tmp146 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp146);
            ExpressionAnnotation __tmp147 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp147);
            List<object> elemAnnotList = null;
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp148 = new PropertyAnnotation();
                __tmp148.Name = "Kind";
                elemAnnotList.Add(__tmp148);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp149 = new PropertyAnnotation();
                __tmp149.Name = "Expression";
                elemAnnotList.Add(__tmp149);
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
            SymbolAnnotation __tmp150 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp150);
            ExpressionAnnotation __tmp151 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp151);
            List<object> elemAnnotList = null;
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp152 = new PropertyAnnotation();
                __tmp152.Name = "Kind";
                elemAnnotList.Add(__tmp152);
            }
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp153 = new PropertyAnnotation();
                __tmp153.Name = "Expression";
                elemAnnotList.Add(__tmp153);
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
            SymbolAnnotation __tmp154 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp154);
            ExpressionAnnotation __tmp155 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp155);
            SymbolTypeAnnotation __tmp156 = new SymbolTypeAnnotation();
            __tmp156.SymbolType = typeof(MetaTypeAsExpression);
            treeAnnotList.Add(__tmp156);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp157 = new PropertyAnnotation();
                __tmp157.Name = "Expression";
                elemAnnotList.Add(__tmp157);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp158 = new PropertyAnnotation();
                __tmp158.Name = "TypeReference";
                elemAnnotList.Add(__tmp158);
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
            SymbolAnnotation __tmp159 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp159);
            ExpressionAnnotation __tmp160 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp160);
            SymbolTypeAnnotation __tmp161 = new SymbolTypeAnnotation();
            __tmp161.SymbolType = typeof(MetaTypeCheckExpression);
            treeAnnotList.Add(__tmp161);
            List<object> elemAnnotList = null;
            if (context.expression() != null)
            {
                object elem = context.expression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp162 = new PropertyAnnotation();
                __tmp162.Name = "Expression";
                elemAnnotList.Add(__tmp162);
            }
            if (context.typeReference() != null)
            {
                object elem = context.typeReference();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp163 = new PropertyAnnotation();
                __tmp163.Name = "TypeReference";
                elemAnnotList.Add(__tmp163);
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
            SymbolAnnotation __tmp164 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp164);
            ExpressionAnnotation __tmp165 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp165);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp166 = new PropertyAnnotation();
                __tmp166.Name = "Left";
                elemAnnotList.Add(__tmp166);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp167 = new PropertyAnnotation();
                __tmp167.Name = "Kind";
                elemAnnotList.Add(__tmp167);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp168 = new PropertyAnnotation();
                __tmp168.Name = "Right";
                elemAnnotList.Add(__tmp168);
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
            SymbolAnnotation __tmp169 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp169);
            ExpressionAnnotation __tmp170 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp170);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp171 = new PropertyAnnotation();
                __tmp171.Name = "Left";
                elemAnnotList.Add(__tmp171);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp172 = new PropertyAnnotation();
                __tmp172.Name = "Kind";
                elemAnnotList.Add(__tmp172);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp173 = new PropertyAnnotation();
                __tmp173.Name = "Right";
                elemAnnotList.Add(__tmp173);
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
            SymbolAnnotation __tmp174 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp174);
            ExpressionAnnotation __tmp175 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp175);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp176 = new PropertyAnnotation();
                __tmp176.Name = "Left";
                elemAnnotList.Add(__tmp176);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp177 = new PropertyAnnotation();
                __tmp177.Name = "Kind";
                elemAnnotList.Add(__tmp177);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp178 = new PropertyAnnotation();
                __tmp178.Name = "Right";
                elemAnnotList.Add(__tmp178);
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
            SymbolAnnotation __tmp179 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp179);
            ExpressionAnnotation __tmp180 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp180);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp181 = new PropertyAnnotation();
                __tmp181.Name = "Left";
                elemAnnotList.Add(__tmp181);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp182 = new PropertyAnnotation();
                __tmp182.Name = "Kind";
                elemAnnotList.Add(__tmp182);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp183 = new PropertyAnnotation();
                __tmp183.Name = "Right";
                elemAnnotList.Add(__tmp183);
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
            SymbolAnnotation __tmp184 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp184);
            ExpressionAnnotation __tmp185 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp185);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp186 = new PropertyAnnotation();
                __tmp186.Name = "Left";
                elemAnnotList.Add(__tmp186);
            }
            if (context.kind != null)
            {
                object elem = context.kind;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp187 = new PropertyAnnotation();
                __tmp187.Name = "Kind";
                elemAnnotList.Add(__tmp187);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp188 = new PropertyAnnotation();
                __tmp188.Name = "Right";
                elemAnnotList.Add(__tmp188);
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
            SymbolAnnotation __tmp189 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp189);
            ExpressionAnnotation __tmp190 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp190);
            SymbolTypeAnnotation __tmp191 = new SymbolTypeAnnotation();
            __tmp191.SymbolType = typeof(MetaAndExpression);
            treeAnnotList.Add(__tmp191);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp192 = new PropertyAnnotation();
                __tmp192.Name = "Left";
                elemAnnotList.Add(__tmp192);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp193 = new PropertyAnnotation();
                __tmp193.Name = "Right";
                elemAnnotList.Add(__tmp193);
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
            SymbolAnnotation __tmp194 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp194);
            ExpressionAnnotation __tmp195 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp195);
            SymbolTypeAnnotation __tmp196 = new SymbolTypeAnnotation();
            __tmp196.SymbolType = typeof(MetaExclusiveOrExpression);
            treeAnnotList.Add(__tmp196);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp197 = new PropertyAnnotation();
                __tmp197.Name = "Left";
                elemAnnotList.Add(__tmp197);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp198 = new PropertyAnnotation();
                __tmp198.Name = "Right";
                elemAnnotList.Add(__tmp198);
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
            SymbolAnnotation __tmp199 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp199);
            ExpressionAnnotation __tmp200 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp200);
            SymbolTypeAnnotation __tmp201 = new SymbolTypeAnnotation();
            __tmp201.SymbolType = typeof(MetaOrExpression);
            treeAnnotList.Add(__tmp201);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp202 = new PropertyAnnotation();
                __tmp202.Name = "Left";
                elemAnnotList.Add(__tmp202);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp203 = new PropertyAnnotation();
                __tmp203.Name = "Right";
                elemAnnotList.Add(__tmp203);
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
            SymbolAnnotation __tmp204 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp204);
            ExpressionAnnotation __tmp205 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp205);
            SymbolTypeAnnotation __tmp206 = new SymbolTypeAnnotation();
            __tmp206.SymbolType = typeof(MetaAndAlsoExpression);
            treeAnnotList.Add(__tmp206);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp207 = new PropertyAnnotation();
                __tmp207.Name = "Left";
                elemAnnotList.Add(__tmp207);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp208 = new PropertyAnnotation();
                __tmp208.Name = "Right";
                elemAnnotList.Add(__tmp208);
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
            SymbolAnnotation __tmp209 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp209);
            ExpressionAnnotation __tmp210 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp210);
            SymbolTypeAnnotation __tmp211 = new SymbolTypeAnnotation();
            __tmp211.SymbolType = typeof(MetaOrElseExpression);
            treeAnnotList.Add(__tmp211);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp212 = new PropertyAnnotation();
                __tmp212.Name = "Left";
                elemAnnotList.Add(__tmp212);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp213 = new PropertyAnnotation();
                __tmp213.Name = "Right";
                elemAnnotList.Add(__tmp213);
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
            SymbolAnnotation __tmp214 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp214);
            ExpressionAnnotation __tmp215 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp215);
            SymbolTypeAnnotation __tmp216 = new SymbolTypeAnnotation();
            __tmp216.SymbolType = typeof(MetaNullCoalescingExpression);
            treeAnnotList.Add(__tmp216);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp217 = new PropertyAnnotation();
                __tmp217.Name = "Left";
                elemAnnotList.Add(__tmp217);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp218 = new PropertyAnnotation();
                __tmp218.Name = "Right";
                elemAnnotList.Add(__tmp218);
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
            SymbolAnnotation __tmp219 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp219);
            ExpressionAnnotation __tmp220 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp220);
            SymbolTypeAnnotation __tmp221 = new SymbolTypeAnnotation();
            __tmp221.SymbolType = typeof(MetaConditionalExpression);
            treeAnnotList.Add(__tmp221);
            List<object> elemAnnotList = null;
            if (context.condition != null)
            {
                object elem = context.condition;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp222 = new PropertyAnnotation();
                __tmp222.Name = "Condition";
                elemAnnotList.Add(__tmp222);
            }
            if (context.then != null)
            {
                object elem = context.then;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp223 = new PropertyAnnotation();
                __tmp223.Name = "Then";
                elemAnnotList.Add(__tmp223);
            }
            if (context.@else != null)
            {
                object elem = context.@else;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp224 = new PropertyAnnotation();
                __tmp224.Name = "Else";
                elemAnnotList.Add(__tmp224);
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
            SymbolAnnotation __tmp225 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp225);
            ExpressionAnnotation __tmp226 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp226);
            List<object> elemAnnotList = null;
            if (context.left != null)
            {
                object elem = context.left;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp227 = new PropertyAnnotation();
                __tmp227.Name = "Left";
                elemAnnotList.Add(__tmp227);
            }
            if (context.@operator != null)
            {
                object elem = context.@operator;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp228 = new PropertyAnnotation();
                __tmp228.Name = "Operator";
                elemAnnotList.Add(__tmp228);
            }
            if (context.right != null)
            {
                object elem = context.right;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp229 = new PropertyAnnotation();
                __tmp229.Name = "Right";
                elemAnnotList.Add(__tmp229);
            }
            this.HandleSymbolType(context);
            return base.VisitAssignmentExpression(context);
        }
        
        public override object VisitLiteralExpression(MetaModelParser.LiteralExpressionContext context)
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
                SymbolAnnotation __tmp230 = new SymbolAnnotation();
                __tmp230.SymbolType = typeof(MetaNullExpression);
                elemAnnotList.Add(__tmp230);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp231 = new ValueAnnotation();
                elemAnnotList.Add(__tmp231);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp232 = new ValueAnnotation();
                elemAnnotList.Add(__tmp232);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp233 = new ValueAnnotation();
                elemAnnotList.Add(__tmp233);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp234 = new ValueAnnotation();
                elemAnnotList.Add(__tmp234);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp235 = new ValueAnnotation();
                elemAnnotList.Add(__tmp235);
            }
            this.HandleSymbolType(context);
            return base.VisitLiteralExpression(context);
        }
        
        public override object VisitNewObjectExpression(MetaModelParser.NewObjectExpressionContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp236 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp236);
            ExpressionAnnotation __tmp237 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp237);
            SymbolTypeAnnotation __tmp238 = new SymbolTypeAnnotation();
            __tmp238.SymbolType = typeof(MetaNewExpression);
            treeAnnotList.Add(__tmp238);
            List<object> elemAnnotList = null;
            if (context.classType() != null)
            {
                object elem = context.classType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp239 = new PropertyAnnotation();
                __tmp239.Name = "TypeReference";
                elemAnnotList.Add(__tmp239);
            }
            if (context.newPropertyInitList() != null)
            {
                object elem = context.newPropertyInitList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp240 = new PropertyAnnotation();
                __tmp240.Name = "NewPropertyInitList";
                elemAnnotList.Add(__tmp240);
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
            SymbolAnnotation __tmp241 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp241);
            ExpressionAnnotation __tmp242 = new ExpressionAnnotation();
            treeAnnotList.Add(__tmp242);
            SymbolTypeAnnotation __tmp243 = new SymbolTypeAnnotation();
            __tmp243.SymbolType = typeof(MetaNewCollectionExpression);
            treeAnnotList.Add(__tmp243);
            List<object> elemAnnotList = null;
            if (context.collectionType() != null)
            {
                object elem = context.collectionType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp244 = new PropertyAnnotation();
                __tmp244.Name = "TypeReference";
                elemAnnotList.Add(__tmp244);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp245 = new PropertyAnnotation();
                __tmp245.Name = "Values";
                elemAnnotList.Add(__tmp245);
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
            PropertyAnnotation __tmp246 = new PropertyAnnotation();
            __tmp246.Name = "PropertyInitializers";
            treeAnnotList.Add(__tmp246);
            SymbolAnnotation __tmp247 = new SymbolAnnotation();
            __tmp247.SymbolType = typeof(MetaNewPropertyInitializer);
            treeAnnotList.Add(__tmp247);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp248 = new PropertyAnnotation();
                __tmp248.Name = "PropertyName";
                elemAnnotList.Add(__tmp248);
                ValueAnnotation __tmp249 = new ValueAnnotation();
                elemAnnotList.Add(__tmp249);
            }
            if (context.expressionOrNewExpression() != null)
            {
                object elem = context.expressionOrNewExpression();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp250 = new PropertyAnnotation();
                __tmp250.Name = "Value";
                elemAnnotList.Add(__tmp250);
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
                SymbolTypeAnnotation __tmp251 = new SymbolTypeAnnotation();
                __tmp251.SymbolType = typeof(MetaPostIncrementAssignExpression);
                elemAnnotList.Add(__tmp251);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp252 = new SymbolTypeAnnotation();
                __tmp252.SymbolType = typeof(MetaPostDecrementAssignExpression);
                elemAnnotList.Add(__tmp252);
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
                SymbolTypeAnnotation __tmp253 = new SymbolTypeAnnotation();
                __tmp253.SymbolType = typeof(MetaPreIncrementAssignExpression);
                elemAnnotList.Add(__tmp253);
            }
            if (context.TMinusMinus() != null)
            {
                object elem = context.TMinusMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp254 = new SymbolTypeAnnotation();
                __tmp254.SymbolType = typeof(MetaPreDecrementAssignExpression);
                elemAnnotList.Add(__tmp254);
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
                SymbolTypeAnnotation __tmp255 = new SymbolTypeAnnotation();
                __tmp255.SymbolType = typeof(MetaUnaryPlusExpression);
                elemAnnotList.Add(__tmp255);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp256 = new SymbolTypeAnnotation();
                __tmp256.SymbolType = typeof(MetaNegateExpression);
                elemAnnotList.Add(__tmp256);
            }
            if (context.TTilde() != null)
            {
                object elem = context.TTilde();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp257 = new SymbolTypeAnnotation();
                __tmp257.SymbolType = typeof(MetaOnesComplementExpression);
                elemAnnotList.Add(__tmp257);
            }
            if (context.TExclamation() != null)
            {
                object elem = context.TExclamation();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp258 = new SymbolTypeAnnotation();
                __tmp258.SymbolType = typeof(MetaNotExpression);
                elemAnnotList.Add(__tmp258);
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
                SymbolTypeAnnotation __tmp259 = new SymbolTypeAnnotation();
                __tmp259.SymbolType = typeof(MetaMultiplyExpression);
                elemAnnotList.Add(__tmp259);
            }
            if (context.TSlash() != null)
            {
                object elem = context.TSlash();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp260 = new SymbolTypeAnnotation();
                __tmp260.SymbolType = typeof(MetaDivideExpression);
                elemAnnotList.Add(__tmp260);
            }
            if (context.TPercent() != null)
            {
                object elem = context.TPercent();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp261 = new SymbolTypeAnnotation();
                __tmp261.SymbolType = typeof(MetaModuloExpression);
                elemAnnotList.Add(__tmp261);
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
                SymbolTypeAnnotation __tmp262 = new SymbolTypeAnnotation();
                __tmp262.SymbolType = typeof(MetaAddExpression);
                elemAnnotList.Add(__tmp262);
            }
            if (context.TMinus() != null)
            {
                object elem = context.TMinus();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp263 = new SymbolTypeAnnotation();
                __tmp263.SymbolType = typeof(MetaSubtractExpression);
                elemAnnotList.Add(__tmp263);
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
                    SymbolTypeAnnotation __tmp264 = new SymbolTypeAnnotation();
                    __tmp264.SymbolType = typeof(MetaLeftShiftExpression);
                    elemAnnotList.Add(__tmp264);
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
                    SymbolTypeAnnotation __tmp265 = new SymbolTypeAnnotation();
                    __tmp265.SymbolType = typeof(MetaRightShiftExpression);
                    elemAnnotList.Add(__tmp265);
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
                SymbolTypeAnnotation __tmp266 = new SymbolTypeAnnotation();
                __tmp266.SymbolType = typeof(MetaLessThanExpression);
                elemAnnotList.Add(__tmp266);
            }
            if (context.TGreaterThan() != null)
            {
                object elem = context.TGreaterThan();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp267 = new SymbolTypeAnnotation();
                __tmp267.SymbolType = typeof(MetaGreaterThanExpression);
                elemAnnotList.Add(__tmp267);
            }
            if (context.TLessThanOrEqual() != null)
            {
                object elem = context.TLessThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp268 = new SymbolTypeAnnotation();
                __tmp268.SymbolType = typeof(MetaLessThanOrEqualExpression);
                elemAnnotList.Add(__tmp268);
            }
            if (context.TGreaterThanOrEqual() != null)
            {
                object elem = context.TGreaterThanOrEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp269 = new SymbolTypeAnnotation();
                __tmp269.SymbolType = typeof(MetaGreaterThanOrEqualExpression);
                elemAnnotList.Add(__tmp269);
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
                SymbolTypeAnnotation __tmp270 = new SymbolTypeAnnotation();
                __tmp270.SymbolType = typeof(MetaEqualExpression);
                elemAnnotList.Add(__tmp270);
            }
            if (context.TNotEqual() != null)
            {
                object elem = context.TNotEqual();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp271 = new SymbolTypeAnnotation();
                __tmp271.SymbolType = typeof(MetaNotEqualExpression);
                elemAnnotList.Add(__tmp271);
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
                SymbolTypeAnnotation __tmp272 = new SymbolTypeAnnotation();
                __tmp272.SymbolType = typeof(MetaAssignExpression);
                elemAnnotList.Add(__tmp272);
            }
            if (context.TAsteriskAssign() != null)
            {
                object elem = context.TAsteriskAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp273 = new SymbolTypeAnnotation();
                __tmp273.SymbolType = typeof(MetaMultiplyAssignExpression);
                elemAnnotList.Add(__tmp273);
            }
            if (context.TSlashAssign() != null)
            {
                object elem = context.TSlashAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp274 = new SymbolTypeAnnotation();
                __tmp274.SymbolType = typeof(MetaDivideAssignExpression);
                elemAnnotList.Add(__tmp274);
            }
            if (context.TPercentAssign() != null)
            {
                object elem = context.TPercentAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp275 = new SymbolTypeAnnotation();
                __tmp275.SymbolType = typeof(MetaModuloAssignExpression);
                elemAnnotList.Add(__tmp275);
            }
            if (context.TPlusAssign() != null)
            {
                object elem = context.TPlusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp276 = new SymbolTypeAnnotation();
                __tmp276.SymbolType = typeof(MetaAddAssignExpression);
                elemAnnotList.Add(__tmp276);
            }
            if (context.TMinusAssign() != null)
            {
                object elem = context.TMinusAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp277 = new SymbolTypeAnnotation();
                __tmp277.SymbolType = typeof(MetaSubtractAssignExpression);
                elemAnnotList.Add(__tmp277);
            }
            if (context.TLeftShiftAssign() != null)
            {
                object elem = context.TLeftShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp278 = new SymbolTypeAnnotation();
                __tmp278.SymbolType = typeof(MetaLeftShiftAssignExpression);
                elemAnnotList.Add(__tmp278);
            }
            if (context.TRightShiftAssign() != null)
            {
                object elem = context.TRightShiftAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp279 = new SymbolTypeAnnotation();
                __tmp279.SymbolType = typeof(MetaRightShiftAssignExpression);
                elemAnnotList.Add(__tmp279);
            }
            if (context.TAmpersandAssign() != null)
            {
                object elem = context.TAmpersandAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp280 = new SymbolTypeAnnotation();
                __tmp280.SymbolType = typeof(MetaAndAssignExpression);
                elemAnnotList.Add(__tmp280);
            }
            if (context.THatAssign() != null)
            {
                object elem = context.THatAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp281 = new SymbolTypeAnnotation();
                __tmp281.SymbolType = typeof(MetaExclusiveOrAssignExpression);
                elemAnnotList.Add(__tmp281);
            }
            if (context.TBarAssign() != null)
            {
                object elem = context.TBarAssign();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp282 = new SymbolTypeAnnotation();
                __tmp282.SymbolType = typeof(MetaOrAssignExpression);
                elemAnnotList.Add(__tmp282);
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
                NameUseAnnotation __tmp283 = new NameUseAnnotation();
                __tmp283.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp283);
            }
            if (context.target != null)
            {
                object elem = context.target;
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp284 = new NameUseAnnotation();
                __tmp284.SymbolTypes.Add(typeof(MetaProperty));
                elemAnnotList.Add(__tmp284);
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
            NameAnnotation __tmp285 = new NameAnnotation();
            treeAnnotList.Add(__tmp285);
            IdentifierAnnotation __tmp286 = new IdentifierAnnotation();
            treeAnnotList.Add(__tmp286);
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
                ValueAnnotation __tmp287 = new ValueAnnotation();
                elemAnnotList.Add(__tmp287);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp288 = new ValueAnnotation();
                elemAnnotList.Add(__tmp288);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp289 = new ValueAnnotation();
                elemAnnotList.Add(__tmp289);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp290 = new ValueAnnotation();
                elemAnnotList.Add(__tmp290);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp291 = new ValueAnnotation();
                elemAnnotList.Add(__tmp291);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp292 = new ValueAnnotation();
                elemAnnotList.Add(__tmp292);
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
        
        public virtual object VisitLiteralExpression(MetaModelParser.LiteralExpressionContext context)
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
    public abstract class MetaModelCompilerBase : MetaCompiler
    {
        public MetaModelCompilerBase(string source, string fileName)
            : base(source, fileName)
        {
        }
        
        protected override void DoCompile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new MetaModelLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new MetaModelParser(this.CommonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.main();
            MetaModelParserAnnotator annotator = new MetaModelParserAnnotator();
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
            MetaModelParserPropertyEvaluator propertyEvaluator = new MetaModelParserPropertyEvaluator(this);
            propertyEvaluator.Visit(this.ParseTree);
            
            this.Model.EvalLazyValues();
            foreach (var symbol in this.Data.GetSymbols())
            {
                if (symbol.MHasUninitializedValue())
                {
                    this.Diagnostics.AddError("The symbol '" + symbol + "' has uninitialized lazy values.", this.FileName, new TextSpan(), true);
                }
            }
        }
        
        public MetaModelParser.MainContext ParseTree { get; private set; }
        public MetaModelLexer Lexer { get; private set; }
        public MetaModelParser Parser { get; private set; }
    }
}
