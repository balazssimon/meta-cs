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

namespace MetaDslx.Languages.Soal
{
    public class SoalParserAnnotator : SoalParserBaseVisitor<object>
    {
        private SoalLexerAnnotator lexerAnnotator = new SoalLexerAnnotator();
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
        
        public SoalParserAnnotator(MetaDslx.Compiler.IModelCompiler compiler)
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
        
        public override object VisitMain(SoalParser.MainContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            RootScopeAnnotation __tmp1 = new RootScopeAnnotation();
            __tmp1.Value = node;
            treeAnnotList.Add(__tmp1);
            this.HandleSymbolType(context);
            return base.VisitMain(context);
        }
        
        public override object VisitQualifiedName(SoalParser.QualifiedNameContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            QualifiedNameAnnotation __tmp2 = new QualifiedNameAnnotation();
            treeAnnotList.Add(__tmp2);
            this.HandleSymbolType(context);
            return base.VisitQualifiedName(context);
        }
        
        public override object VisitIdentifierList(SoalParser.IdentifierListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifierList(context);
        }
        
        public override object VisitQualifiedNameList(SoalParser.QualifiedNameListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitQualifiedNameList(context);
        }
        
        public override object VisitAnnotationList(SoalParser.AnnotationListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationList(context);
        }
        
        public override object VisitReturnAnnotationList(SoalParser.ReturnAnnotationListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitReturnAnnotationList(context);
        }
        
        public override object VisitAnnotation(SoalParser.AnnotationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp3 = new PropertyAnnotation();
            __tmp3.Name = "Annotations";
            treeAnnotList.Add(__tmp3);
            SymbolAnnotation __tmp4 = new SymbolAnnotation();
            __tmp4.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp4);
            this.HandleSymbolType(context);
            return base.VisitAnnotation(context);
        }
        
        public override object VisitReturnAnnotation(SoalParser.ReturnAnnotationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp5 = new PropertyAnnotation();
            __tmp5.Name = "Annotations";
            treeAnnotList.Add(__tmp5);
            SymbolAnnotation __tmp6 = new SymbolAnnotation();
            __tmp6.SymbolType = typeof(Annotation);
            treeAnnotList.Add(__tmp6);
            this.HandleSymbolType(context);
            return base.VisitReturnAnnotation(context);
        }
        
        public override object VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
        {
            List<object> elemAnnotList = null;
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
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
            this.HandleSymbolType(context);
            return base.VisitAnnotationBody(context);
        }
        
        public override object VisitAnnotationProperties(SoalParser.AnnotationPropertiesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationProperties(context);
        }
        
        public override object VisitAnnotationPropertyList(SoalParser.AnnotationPropertyListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationPropertyList(context);
        }
        
        public override object VisitAnnotationProperty(SoalParser.AnnotationPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp9 = new PropertyAnnotation();
            __tmp9.Name = "Properties";
            treeAnnotList.Add(__tmp9);
            SymbolAnnotation __tmp10 = new SymbolAnnotation();
            __tmp10.SymbolType = typeof(AnnotationProperty);
            treeAnnotList.Add(__tmp10);
            List<object> elemAnnotList = null;
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp11 = new PropertyAnnotation();
                __tmp11.Name = "Name";
                elemAnnotList.Add(__tmp11);
                ValueAnnotation __tmp12 = new ValueAnnotation();
                elemAnnotList.Add(__tmp12);
            }
            if (context.annotationPropertyValue() != null)
            {
                object elem = context.annotationPropertyValue();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp13 = new PropertyAnnotation();
                __tmp13.Name = "Value";
                elemAnnotList.Add(__tmp13);
            }
            this.HandleSymbolType(context);
            return base.VisitAnnotationProperty(context);
        }
        
        public override object VisitAnnotationPropertyValue(SoalParser.AnnotationPropertyValueContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitAnnotationPropertyValue(context);
        }
        
        public override object VisitNamespaceDeclaration(SoalParser.NamespaceDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp14 = new NameDefAnnotation();
            __tmp14.SymbolType = typeof(Namespace);
            __tmp14.NestingProperty = "Declarations";
            __tmp14.Merge = true;
            treeAnnotList.Add(__tmp14);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp15 = new PropertyAnnotation();
                __tmp15.Name = "Prefix";
                elemAnnotList.Add(__tmp15);
                ValueAnnotation __tmp16 = new ValueAnnotation();
                elemAnnotList.Add(__tmp16);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp17 = new PropertyAnnotation();
                __tmp17.Name = "Uri";
                elemAnnotList.Add(__tmp17);
                ValueAnnotation __tmp18 = new ValueAnnotation();
                elemAnnotList.Add(__tmp18);
            }
            this.HandleSymbolType(context);
            return base.VisitNamespaceDeclaration(context);
        }
        
        public override object VisitDeclaration(SoalParser.DeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp19 = new PropertyAnnotation();
            __tmp19.Name = "Declarations";
            treeAnnotList.Add(__tmp19);
            this.HandleSymbolType(context);
            return base.VisitDeclaration(context);
        }
        
        public override object VisitEnumDeclaration(SoalParser.EnumDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp20 = new TypeDefAnnotation();
            __tmp20.SymbolType = typeof(Enum);
            treeAnnotList.Add(__tmp20);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp21 = new PropertyAnnotation();
                __tmp21.Name = "BaseType";
                elemAnnotList.Add(__tmp21);
                TypeUseAnnotation __tmp22 = new TypeUseAnnotation();
                __tmp22.SymbolTypes.Add(typeof(Enum));
                __tmp22.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp22);
            }
            this.HandleSymbolType(context);
            return base.VisitEnumDeclaration(context);
        }
        
        public override object VisitEnumLiterals(SoalParser.EnumLiteralsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEnumLiterals(context);
        }
        
        public override object VisitEnumLiteral(SoalParser.EnumLiteralContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp23 = new PropertyAnnotation();
            __tmp23.Name = "EnumLiterals";
            treeAnnotList.Add(__tmp23);
            NameDefAnnotation __tmp24 = new NameDefAnnotation();
            __tmp24.SymbolType = typeof(EnumLiteral);
            treeAnnotList.Add(__tmp24);
            this.HandleSymbolType(context);
            return base.VisitEnumLiteral(context);
        }
        
        public override object VisitStructDeclaration(SoalParser.StructDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp25 = new TypeDefAnnotation();
            __tmp25.SymbolType = typeof(Struct);
            treeAnnotList.Add(__tmp25);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp26 = new PropertyAnnotation();
                __tmp26.Name = "BaseType";
                elemAnnotList.Add(__tmp26);
                TypeUseAnnotation __tmp27 = new TypeUseAnnotation();
                __tmp27.SymbolTypes.Add(typeof(Struct));
                __tmp27.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp27);
            }
            this.HandleSymbolType(context);
            return base.VisitStructDeclaration(context);
        }
        
        public override object VisitPropertyDeclaration(SoalParser.PropertyDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp28 = new PropertyAnnotation();
            __tmp28.Name = "Properties";
            treeAnnotList.Add(__tmp28);
            NameDefAnnotation __tmp29 = new NameDefAnnotation();
            __tmp29.SymbolType = typeof(Property);
            treeAnnotList.Add(__tmp29);
            List<object> elemAnnotList = null;
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
                TypeUseAnnotation __tmp31 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp31);
            }
            this.HandleSymbolType(context);
            return base.VisitPropertyDeclaration(context);
        }
        
        public override object VisitDatabaseDeclaration(SoalParser.DatabaseDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp32 = new TypeDefAnnotation();
            __tmp32.SymbolType = typeof(Database);
            treeAnnotList.Add(__tmp32);
            this.HandleSymbolType(context);
            return base.VisitDatabaseDeclaration(context);
        }
        
        public override object VisitEntityReference(SoalParser.EntityReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp33 = new PropertyAnnotation();
            __tmp33.Name = "Entities";
            treeAnnotList.Add(__tmp33);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp34 = new TypeUseAnnotation();
                __tmp34.SymbolTypes.Add(typeof(Struct));
                elemAnnotList.Add(__tmp34);
            }
            this.HandleSymbolType(context);
            return base.VisitEntityReference(context);
        }
        
        public override object VisitInterfaceDeclaration(SoalParser.InterfaceDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp35 = new TypeDefAnnotation();
            __tmp35.SymbolType = typeof(Interface);
            treeAnnotList.Add(__tmp35);
            this.HandleSymbolType(context);
            return base.VisitInterfaceDeclaration(context);
        }
        
        public override object VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp36 = new PropertyAnnotation();
            __tmp36.Name = "Operations";
            treeAnnotList.Add(__tmp36);
            NameDefAnnotation __tmp37 = new NameDefAnnotation();
            __tmp37.SymbolType = typeof(Operation);
            treeAnnotList.Add(__tmp37);
            List<object> elemAnnotList = null;
            if (context.qualifiedNameList() != null)
            {
                object elem = context.qualifiedNameList();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp38 = new PropertyAnnotation();
                __tmp38.Name = "Exceptions";
                elemAnnotList.Add(__tmp38);
                TypeUseAnnotation __tmp39 = new TypeUseAnnotation();
                __tmp39.SymbolTypes.Add(typeof(Struct));
                elemAnnotList.Add(__tmp39);
            }
            this.HandleSymbolType(context);
            return base.VisitOperationDeclaration(context);
        }
        
        public override object VisitParameterList(SoalParser.ParameterListContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitParameterList(context);
        }
        
        public override object VisitParameter(SoalParser.ParameterContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp40 = new PropertyAnnotation();
            __tmp40.Name = "Parameters";
            treeAnnotList.Add(__tmp40);
            NameDefAnnotation __tmp41 = new NameDefAnnotation();
            __tmp41.SymbolType = typeof(InputParameter);
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
                TypeUseAnnotation __tmp43 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp43);
            }
            this.HandleSymbolType(context);
            return base.VisitParameter(context);
        }
        
        public override object VisitOperationResult(SoalParser.OperationResultContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp44 = new PropertyAnnotation();
            __tmp44.Name = "Result";
            treeAnnotList.Add(__tmp44);
            SymbolAnnotation __tmp45 = new SymbolAnnotation();
            __tmp45.SymbolType = typeof(OutputParameter);
            treeAnnotList.Add(__tmp45);
            this.HandleSymbolType(context);
            return base.VisitOperationResult(context);
        }
        
        public override object VisitComponentDeclaration(SoalParser.ComponentDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp46 = new TypeDefAnnotation();
            __tmp46.SymbolType = typeof(Component);
            treeAnnotList.Add(__tmp46);
            List<object> elemAnnotList = null;
            if (context.KAbstract() != null)
            {
                object elem = context.KAbstract();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp47 = new PropertyAnnotation();
                __tmp47.Name = "IsAbstract";
                __tmp47.Value = true;
                elemAnnotList.Add(__tmp47);
            }
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp48 = new PropertyAnnotation();
                __tmp48.Name = "BaseComponent";
                elemAnnotList.Add(__tmp48);
                TypeUseAnnotation __tmp49 = new TypeUseAnnotation();
                __tmp49.SymbolTypes.Add(typeof(Component));
                __tmp49.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp49);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentDeclaration(context);
        }
        
        public override object VisitComponentElements(SoalParser.ComponentElementsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitComponentElements(context);
        }
        
        public override object VisitComponentElement(SoalParser.ComponentElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitComponentElement(context);
        }
        
        public override object VisitComponentService(SoalParser.ComponentServiceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp50 = new PropertyAnnotation();
            __tmp50.Name = "Services";
            treeAnnotList.Add(__tmp50);
            NameDefAnnotation __tmp51 = new NameDefAnnotation();
            __tmp51.SymbolType = typeof(Service);
            treeAnnotList.Add(__tmp51);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp52 = new PropertyAnnotation();
                __tmp52.Name = "Interface";
                elemAnnotList.Add(__tmp52);
                TypeUseAnnotation __tmp53 = new TypeUseAnnotation();
                __tmp53.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp53);
            }
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp54 = new PropertyAnnotation();
                __tmp54.Name = "OptionalName";
                elemAnnotList.Add(__tmp54);
                ValueAnnotation __tmp55 = new ValueAnnotation();
                elemAnnotList.Add(__tmp55);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentService(context);
        }
        
        public override object VisitComponentReference(SoalParser.ComponentReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp56 = new PropertyAnnotation();
            __tmp56.Name = "References";
            treeAnnotList.Add(__tmp56);
            NameDefAnnotation __tmp57 = new NameDefAnnotation();
            __tmp57.SymbolType = typeof(Reference);
            treeAnnotList.Add(__tmp57);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp58 = new PropertyAnnotation();
                __tmp58.Name = "Interface";
                elemAnnotList.Add(__tmp58);
                TypeUseAnnotation __tmp59 = new TypeUseAnnotation();
                __tmp59.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp59);
            }
            if (context.nameDef() != null)
            {
                object elem = context.nameDef();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp60 = new PropertyAnnotation();
                __tmp60.Name = "OptionalName";
                elemAnnotList.Add(__tmp60);
                ValueAnnotation __tmp61 = new ValueAnnotation();
                elemAnnotList.Add(__tmp61);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentReference(context);
        }
        
        public override object VisitComponentServiceOrReferenceEmptyBody(SoalParser.ComponentServiceOrReferenceEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitComponentServiceOrReferenceEmptyBody(context);
        }
        
        public override object VisitComponentServiceOrReferenceNonEmptyBody(SoalParser.ComponentServiceOrReferenceNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitComponentServiceOrReferenceNonEmptyBody(context);
        }
        
        public override object VisitComponentServiceOrReferenceElement(SoalParser.ComponentServiceOrReferenceElementContext context)
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
                PropertyAnnotation __tmp62 = new PropertyAnnotation();
                __tmp62.Name = "Binding";
                elemAnnotList.Add(__tmp62);
                NameUseAnnotation __tmp63 = new NameUseAnnotation();
                __tmp63.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp63);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentServiceOrReferenceElement(context);
        }
        
        public override object VisitComponentProperty(SoalParser.ComponentPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp64 = new PropertyAnnotation();
            __tmp64.Name = "Properties";
            treeAnnotList.Add(__tmp64);
            NameDefAnnotation __tmp65 = new NameDefAnnotation();
            __tmp65.SymbolType = typeof(Property);
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
                TypeUseAnnotation __tmp66 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp66);
            }
            this.HandleSymbolType(context);
            return base.VisitComponentProperty(context);
        }
        
        public override object VisitComponentImplementation(SoalParser.ComponentImplementationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp67 = new PropertyAnnotation();
            __tmp67.Name = "Implementation";
            treeAnnotList.Add(__tmp67);
            NameDefAnnotation __tmp68 = new NameDefAnnotation();
            __tmp68.SymbolType = typeof(Implementation);
            treeAnnotList.Add(__tmp68);
            this.HandleSymbolType(context);
            return base.VisitComponentImplementation(context);
        }
        
        public override object VisitComponentLanguage(SoalParser.ComponentLanguageContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp69 = new PropertyAnnotation();
            __tmp69.Name = "Language";
            treeAnnotList.Add(__tmp69);
            NameDefAnnotation __tmp70 = new NameDefAnnotation();
            __tmp70.SymbolType = typeof(Language);
            treeAnnotList.Add(__tmp70);
            this.HandleSymbolType(context);
            return base.VisitComponentLanguage(context);
        }
        
        public override object VisitCompositeDeclaration(SoalParser.CompositeDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp71 = new TypeDefAnnotation();
            __tmp71.SymbolType = typeof(Composite);
            treeAnnotList.Add(__tmp71);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp72 = new PropertyAnnotation();
                __tmp72.Name = "BaseComponent";
                elemAnnotList.Add(__tmp72);
                TypeUseAnnotation __tmp73 = new TypeUseAnnotation();
                __tmp73.SymbolTypes.Add(typeof(Component));
                __tmp73.SymbolTypes.Add(typeof(Composite));
                __tmp73.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp73);
            }
            this.HandleSymbolType(context);
            return base.VisitCompositeDeclaration(context);
        }
        
        public override object VisitAssemblyDeclaration(SoalParser.AssemblyDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeDefAnnotation __tmp74 = new TypeDefAnnotation();
            __tmp74.SymbolType = typeof(Assembly);
            treeAnnotList.Add(__tmp74);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp75 = new PropertyAnnotation();
                __tmp75.Name = "BaseComponent";
                elemAnnotList.Add(__tmp75);
                TypeUseAnnotation __tmp76 = new TypeUseAnnotation();
                __tmp76.SymbolTypes.Add(typeof(Component));
                __tmp76.SymbolTypes.Add(typeof(Composite));
                __tmp76.Location = ResolutionLocation.Parent;
                elemAnnotList.Add(__tmp76);
            }
            this.HandleSymbolType(context);
            return base.VisitAssemblyDeclaration(context);
        }
        
        public override object VisitCompositeElements(SoalParser.CompositeElementsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitCompositeElements(context);
        }
        
        public override object VisitCompositeElement(SoalParser.CompositeElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitCompositeElement(context);
        }
        
        public override object VisitCompositeComponent(SoalParser.CompositeComponentContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp77 = new PropertyAnnotation();
            __tmp77.Name = "Components";
            treeAnnotList.Add(__tmp77);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                NameUseAnnotation __tmp78 = new NameUseAnnotation();
                __tmp78.SymbolTypes.Add(typeof(Component));
                elemAnnotList.Add(__tmp78);
            }
            this.HandleSymbolType(context);
            return base.VisitCompositeComponent(context);
        }
        
        public override object VisitCompositeWire(SoalParser.CompositeWireContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp79 = new PropertyAnnotation();
            __tmp79.Name = "Wires";
            treeAnnotList.Add(__tmp79);
            SymbolAnnotation __tmp80 = new SymbolAnnotation();
            __tmp80.SymbolType = typeof(Wire);
            treeAnnotList.Add(__tmp80);
            this.HandleSymbolType(context);
            return base.VisitCompositeWire(context);
        }
        
        public override object VisitWireSource(SoalParser.WireSourceContext context)
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
                PropertyAnnotation __tmp81 = new PropertyAnnotation();
                __tmp81.Name = "Source";
                elemAnnotList.Add(__tmp81);
                NameUseAnnotation __tmp82 = new NameUseAnnotation();
                __tmp82.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp82);
            }
            this.HandleSymbolType(context);
            return base.VisitWireSource(context);
        }
        
        public override object VisitWireTarget(SoalParser.WireTargetContext context)
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
                PropertyAnnotation __tmp83 = new PropertyAnnotation();
                __tmp83.Name = "Target";
                elemAnnotList.Add(__tmp83);
                NameUseAnnotation __tmp84 = new NameUseAnnotation();
                __tmp84.SymbolTypes.Add(typeof(Port));
                elemAnnotList.Add(__tmp84);
            }
            this.HandleSymbolType(context);
            return base.VisitWireTarget(context);
        }
        
        public override object VisitDeploymentDeclaration(SoalParser.DeploymentDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp85 = new NameDefAnnotation();
            __tmp85.SymbolType = typeof(Deployment);
            treeAnnotList.Add(__tmp85);
            this.HandleSymbolType(context);
            return base.VisitDeploymentDeclaration(context);
        }
        
        public override object VisitDeploymentElements(SoalParser.DeploymentElementsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDeploymentElements(context);
        }
        
        public override object VisitDeploymentElement(SoalParser.DeploymentElementContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDeploymentElement(context);
        }
        
        public override object VisitEnvironmentDeclaration(SoalParser.EnvironmentDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp86 = new PropertyAnnotation();
            __tmp86.Name = "Environments";
            treeAnnotList.Add(__tmp86);
            NameDefAnnotation __tmp87 = new NameDefAnnotation();
            __tmp87.SymbolType = typeof(Environment);
            treeAnnotList.Add(__tmp87);
            this.HandleSymbolType(context);
            return base.VisitEnvironmentDeclaration(context);
        }
        
        public override object VisitRuntimeDeclaration(SoalParser.RuntimeDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp88 = new PropertyAnnotation();
            __tmp88.Name = "Runtime";
            treeAnnotList.Add(__tmp88);
            NameDefAnnotation __tmp89 = new NameDefAnnotation();
            __tmp89.SymbolType = typeof(Runtime);
            treeAnnotList.Add(__tmp89);
            this.HandleSymbolType(context);
            return base.VisitRuntimeDeclaration(context);
        }
        
        public override object VisitRuntimeReference(SoalParser.RuntimeReferenceContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRuntimeReference(context);
        }
        
        public override object VisitAssemblyReference(SoalParser.AssemblyReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp90 = new PropertyAnnotation();
            __tmp90.Name = "Assemblies";
            treeAnnotList.Add(__tmp90);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp91 = new TypeUseAnnotation();
                __tmp91.SymbolTypes.Add(typeof(Assembly));
                elemAnnotList.Add(__tmp91);
            }
            this.HandleSymbolType(context);
            return base.VisitAssemblyReference(context);
        }
        
        public override object VisitDatabaseReference(SoalParser.DatabaseReferenceContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp92 = new PropertyAnnotation();
            __tmp92.Name = "Databases";
            treeAnnotList.Add(__tmp92);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp93 = new TypeUseAnnotation();
                __tmp93.SymbolTypes.Add(typeof(Database));
                elemAnnotList.Add(__tmp93);
            }
            this.HandleSymbolType(context);
            return base.VisitDatabaseReference(context);
        }
        
        public override object VisitBindingDeclaration(SoalParser.BindingDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp94 = new NameDefAnnotation();
            __tmp94.SymbolType = typeof(Binding);
            treeAnnotList.Add(__tmp94);
            this.HandleSymbolType(context);
            return base.VisitBindingDeclaration(context);
        }
        
        public override object VisitBindingLayers(SoalParser.BindingLayersContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBindingLayers(context);
        }
        
        public override object VisitTransportLayer(SoalParser.TransportLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp95 = new PropertyAnnotation();
            __tmp95.Name = "Transport";
            treeAnnotList.Add(__tmp95);
            this.HandleSymbolType(context);
            return base.VisitTransportLayer(context);
        }
        
        public override object VisitHttpTransportLayer(SoalParser.HttpTransportLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp96 = new SymbolAnnotation();
            __tmp96.SymbolType = typeof(HttpTransportBindingElement);
            treeAnnotList.Add(__tmp96);
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayer(context);
        }
        
        public override object VisitHttpTransportLayerEmptyBody(SoalParser.HttpTransportLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayerEmptyBody(context);
        }
        
        public override object VisitHttpTransportLayerNonEmptyBody(SoalParser.HttpTransportLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayerNonEmptyBody(context);
        }
        
        public override object VisitRestTransportLayer(SoalParser.RestTransportLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp97 = new SymbolAnnotation();
            __tmp97.SymbolType = typeof(RestTransportBindingElement);
            treeAnnotList.Add(__tmp97);
            this.HandleSymbolType(context);
            return base.VisitRestTransportLayer(context);
        }
        
        public override object VisitRestTransportLayerEmptyBody(SoalParser.RestTransportLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRestTransportLayerEmptyBody(context);
        }
        
        public override object VisitRestTransportLayerNonEmptyBody(SoalParser.RestTransportLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitRestTransportLayerNonEmptyBody(context);
        }
        
        public override object VisitWebSocketTransportLayer(SoalParser.WebSocketTransportLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp98 = new SymbolAnnotation();
            __tmp98.SymbolType = typeof(WebSocketTransportBindingElement);
            treeAnnotList.Add(__tmp98);
            this.HandleSymbolType(context);
            return base.VisitWebSocketTransportLayer(context);
        }
        
        public override object VisitWebSocketTransportLayerEmptyBody(SoalParser.WebSocketTransportLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitWebSocketTransportLayerEmptyBody(context);
        }
        
        public override object VisitWebSocketTransportLayerNonEmptyBody(SoalParser.WebSocketTransportLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitWebSocketTransportLayerNonEmptyBody(context);
        }
        
        public override object VisitHttpTransportLayerProperties(SoalParser.HttpTransportLayerPropertiesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitHttpTransportLayerProperties(context);
        }
        
        public override object VisitHttpSslProperty(SoalParser.HttpSslPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp99 = new PropertyAnnotation();
            __tmp99.Name = "Ssl";
            treeAnnotList.Add(__tmp99);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp100 = new ValueAnnotation();
                elemAnnotList.Add(__tmp100);
            }
            this.HandleSymbolType(context);
            return base.VisitHttpSslProperty(context);
        }
        
        public override object VisitHttpClientAuthenticationProperty(SoalParser.HttpClientAuthenticationPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp101 = new PropertyAnnotation();
            __tmp101.Name = "ClientAuthentication";
            treeAnnotList.Add(__tmp101);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp102 = new ValueAnnotation();
                elemAnnotList.Add(__tmp102);
            }
            this.HandleSymbolType(context);
            return base.VisitHttpClientAuthenticationProperty(context);
        }
        
        public override object VisitEncodingLayer(SoalParser.EncodingLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp103 = new PropertyAnnotation();
            __tmp103.Name = "Encodings";
            treeAnnotList.Add(__tmp103);
            this.HandleSymbolType(context);
            return base.VisitEncodingLayer(context);
        }
        
        public override object VisitSoapEncodingLayer(SoalParser.SoapEncodingLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp104 = new SymbolAnnotation();
            __tmp104.SymbolType = typeof(SoapEncodingBindingElement);
            treeAnnotList.Add(__tmp104);
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingLayer(context);
        }
        
        public override object VisitSoapEncodingLayerEmptyBody(SoalParser.SoapEncodingLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingLayerEmptyBody(context);
        }
        
        public override object VisitSoapEncodingLayerNonEmptyBody(SoalParser.SoapEncodingLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingLayerNonEmptyBody(context);
        }
        
        public override object VisitXmlEncodingLayer(SoalParser.XmlEncodingLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp105 = new SymbolAnnotation();
            __tmp105.SymbolType = typeof(XmlEncodingBindingElement);
            treeAnnotList.Add(__tmp105);
            this.HandleSymbolType(context);
            return base.VisitXmlEncodingLayer(context);
        }
        
        public override object VisitXmlEncodingLayerEmptyBody(SoalParser.XmlEncodingLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitXmlEncodingLayerEmptyBody(context);
        }
        
        public override object VisitXmlEncodingLayerNonEmptyBody(SoalParser.XmlEncodingLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitXmlEncodingLayerNonEmptyBody(context);
        }
        
        public override object VisitJsonEncodingLayer(SoalParser.JsonEncodingLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            SymbolAnnotation __tmp106 = new SymbolAnnotation();
            __tmp106.SymbolType = typeof(JsonEncodingBindingElement);
            treeAnnotList.Add(__tmp106);
            this.HandleSymbolType(context);
            return base.VisitJsonEncodingLayer(context);
        }
        
        public override object VisitJsonEncodingLayerEmptyBody(SoalParser.JsonEncodingLayerEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitJsonEncodingLayerEmptyBody(context);
        }
        
        public override object VisitJsonEncodingLayerNonEmptyBody(SoalParser.JsonEncodingLayerNonEmptyBodyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitJsonEncodingLayerNonEmptyBody(context);
        }
        
        public override object VisitSoapEncodingProperties(SoalParser.SoapEncodingPropertiesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSoapEncodingProperties(context);
        }
        
        public override object VisitSoapVersionProperty(SoalParser.SoapVersionPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp107 = new PropertyAnnotation();
            __tmp107.Name = "Version";
            treeAnnotList.Add(__tmp107);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp108 = new EnumValueAnnotation();
                __tmp108.EnumType = typeof(SoapVersion);
                elemAnnotList.Add(__tmp108);
            }
            this.HandleSymbolType(context);
            return base.VisitSoapVersionProperty(context);
        }
        
        public override object VisitSoapMtomProperty(SoalParser.SoapMtomPropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp109 = new PropertyAnnotation();
            __tmp109.Name = "Mtom";
            treeAnnotList.Add(__tmp109);
            List<object> elemAnnotList = null;
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp110 = new ValueAnnotation();
                elemAnnotList.Add(__tmp110);
            }
            this.HandleSymbolType(context);
            return base.VisitSoapMtomProperty(context);
        }
        
        public override object VisitSoapStyleProperty(SoalParser.SoapStylePropertyContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp111 = new PropertyAnnotation();
            __tmp111.Name = "Style";
            treeAnnotList.Add(__tmp111);
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                EnumValueAnnotation __tmp112 = new EnumValueAnnotation();
                __tmp112.EnumType = typeof(SoapEncodingStyle);
                elemAnnotList.Add(__tmp112);
            }
            this.HandleSymbolType(context);
            return base.VisitSoapStyleProperty(context);
        }
        
        public override object VisitProtocolLayer(SoalParser.ProtocolLayerContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            PropertyAnnotation __tmp113 = new PropertyAnnotation();
            __tmp113.Name = "Protocols";
            treeAnnotList.Add(__tmp113);
            SymbolAnnotation __tmp114 = new SymbolAnnotation();
            treeAnnotList.Add(__tmp114);
            this.HandleSymbolType(context);
            return base.VisitProtocolLayer(context);
        }
        
        public override object VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
        {
            List<object> elemAnnotList = null;
            if (context.identifier() != null)
            {
                object elem = context.identifier();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                SymbolTypeAnnotation __tmp115 = new SymbolTypeAnnotation();
                __tmp115.Name = "WsAddressing";
                __tmp115.SymbolType = typeof(WsAddressingBindingElement);
                elemAnnotList.Add(__tmp115);
            }
            this.HandleSymbolType(context);
            return base.VisitProtocolLayerKind(context);
        }
        
        public override object VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameDefAnnotation __tmp116 = new NameDefAnnotation();
            __tmp116.SymbolType = typeof(Endpoint);
            treeAnnotList.Add(__tmp116);
            List<object> elemAnnotList = null;
            if (context.qualifiedName() != null)
            {
                object elem = context.qualifiedName();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp117 = new PropertyAnnotation();
                __tmp117.Name = "Interface";
                elemAnnotList.Add(__tmp117);
                TypeUseAnnotation __tmp118 = new TypeUseAnnotation();
                __tmp118.SymbolTypes.Add(typeof(Interface));
                elemAnnotList.Add(__tmp118);
            }
            this.HandleSymbolType(context);
            return base.VisitEndpointDeclaration(context);
        }
        
        public override object VisitEndpointProperties(SoalParser.EndpointPropertiesContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEndpointProperties(context);
        }
        
        public override object VisitEndpointProperty(SoalParser.EndpointPropertyContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitEndpointProperty(context);
        }
        
        public override object VisitEndpointBindingProperty(SoalParser.EndpointBindingPropertyContext context)
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
                PropertyAnnotation __tmp119 = new PropertyAnnotation();
                __tmp119.Name = "Binding";
                elemAnnotList.Add(__tmp119);
                NameUseAnnotation __tmp120 = new NameUseAnnotation();
                __tmp120.SymbolTypes.Add(typeof(Binding));
                elemAnnotList.Add(__tmp120);
            }
            this.HandleSymbolType(context);
            return base.VisitEndpointBindingProperty(context);
        }
        
        public override object VisitEndpointAddressProperty(SoalParser.EndpointAddressPropertyContext context)
        {
            List<object> elemAnnotList = null;
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp121 = new PropertyAnnotation();
                __tmp121.Name = "Address";
                elemAnnotList.Add(__tmp121);
                ValueAnnotation __tmp122 = new ValueAnnotation();
                elemAnnotList.Add(__tmp122);
            }
            this.HandleSymbolType(context);
            return base.VisitEndpointAddressProperty(context);
        }
        
        public override object VisitReturnType(SoalParser.ReturnTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitReturnType(context);
        }
        
        public override object VisitTypeReference(SoalParser.TypeReferenceContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitTypeReference(context);
        }
        
        public override object VisitSimpleType(SoalParser.SimpleTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitSimpleType(context);
        }
        
        public override object VisitNulledType(SoalParser.NulledTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNulledType(context);
        }
        
        public override object VisitReferenceType(SoalParser.ReferenceTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitReferenceType(context);
        }
        
        public override object VisitObjectType(SoalParser.ObjectTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitObjectType(context);
        }
        
        public override object VisitValueType(SoalParser.ValueTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitValueType(context);
        }
        
        public override object VisitVoidType(SoalParser.VoidTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitVoidType(context);
        }
        
        public override object VisitOnewayType(SoalParser.OnewayTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitOnewayType(context);
        }
        
        public override object VisitOperationReturnType(SoalParser.OperationReturnTypeContext context)
        {
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp123 = new PropertyAnnotation();
                __tmp123.Name = "Type";
                elemAnnotList.Add(__tmp123);
                TypeUseAnnotation __tmp124 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp124);
            }
            if (context.onewayType() != null)
            {
                object elem = context.onewayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp125 = new PropertyAnnotation();
                __tmp125.Name = "Type";
                __tmp125.Value = SoalInstance.Void;
                elemAnnotList.Add(__tmp125);
                PropertyAnnotation __tmp126 = new PropertyAnnotation();
                __tmp126.Name = "IsOneway";
                __tmp126.Value = true;
                elemAnnotList.Add(__tmp126);
            }
            this.HandleSymbolType(context);
            return base.VisitOperationReturnType(context);
        }
        
        public override object VisitNullableType(SoalParser.NullableTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp127 = new TypeCtrAnnotation();
            __tmp127.SymbolType = typeof(NullableType);
            treeAnnotList.Add(__tmp127);
            List<object> elemAnnotList = null;
            if (context.valueType() != null)
            {
                object elem = context.valueType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp128 = new PropertyAnnotation();
                __tmp128.Name = "InnerType";
                elemAnnotList.Add(__tmp128);
                TypeUseAnnotation __tmp129 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp129);
            }
            this.HandleSymbolType(context);
            return base.VisitNullableType(context);
        }
        
        public override object VisitNonNullableType(SoalParser.NonNullableTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp130 = new TypeCtrAnnotation();
            __tmp130.SymbolType = typeof(NonNullableType);
            treeAnnotList.Add(__tmp130);
            List<object> elemAnnotList = null;
            if (context.referenceType() != null)
            {
                object elem = context.referenceType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp131 = new PropertyAnnotation();
                __tmp131.Name = "InnerType";
                elemAnnotList.Add(__tmp131);
                TypeUseAnnotation __tmp132 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp132);
            }
            this.HandleSymbolType(context);
            return base.VisitNonNullableType(context);
        }
        
        public override object VisitNonNullableArrayType(SoalParser.NonNullableArrayTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp133 = new TypeCtrAnnotation();
            __tmp133.SymbolType = typeof(NonNullableType);
            treeAnnotList.Add(__tmp133);
            List<object> elemAnnotList = null;
            if (context.arrayType() != null)
            {
                object elem = context.arrayType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp134 = new PropertyAnnotation();
                __tmp134.Name = "InnerType";
                elemAnnotList.Add(__tmp134);
                TypeUseAnnotation __tmp135 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp135);
            }
            this.HandleSymbolType(context);
            return base.VisitNonNullableArrayType(context);
        }
        
        public override object VisitArrayType(SoalParser.ArrayTypeContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitArrayType(context);
        }
        
        public override object VisitSimpleArrayType(SoalParser.SimpleArrayTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp136 = new TypeCtrAnnotation();
            __tmp136.SymbolType = typeof(ArrayType);
            treeAnnotList.Add(__tmp136);
            List<object> elemAnnotList = null;
            if (context.simpleType() != null)
            {
                object elem = context.simpleType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp137 = new PropertyAnnotation();
                __tmp137.Name = "InnerType";
                elemAnnotList.Add(__tmp137);
                TypeUseAnnotation __tmp138 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp138);
            }
            this.HandleSymbolType(context);
            return base.VisitSimpleArrayType(context);
        }
        
        public override object VisitNulledArrayType(SoalParser.NulledArrayTypeContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            TypeCtrAnnotation __tmp139 = new TypeCtrAnnotation();
            __tmp139.SymbolType = typeof(ArrayType);
            treeAnnotList.Add(__tmp139);
            List<object> elemAnnotList = null;
            if (context.nulledType() != null)
            {
                object elem = context.nulledType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                PropertyAnnotation __tmp140 = new PropertyAnnotation();
                __tmp140.Name = "InnerType";
                elemAnnotList.Add(__tmp140);
                TypeUseAnnotation __tmp141 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp141);
            }
            this.HandleSymbolType(context);
            return base.VisitNulledArrayType(context);
        }
        
        public override object VisitConstantValue(SoalParser.ConstantValueContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitConstantValue(context);
        }
        
        public override object VisitTypeofValue(SoalParser.TypeofValueContext context)
        {
            List<object> elemAnnotList = null;
            if (context.returnType() != null)
            {
                object elem = context.returnType();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                TypeUseAnnotation __tmp142 = new TypeUseAnnotation();
                elemAnnotList.Add(__tmp142);
            }
            this.HandleSymbolType(context);
            return base.VisitTypeofValue(context);
        }
        
        public override object VisitNameDef(SoalParser.NameDefContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameAnnotation __tmp143 = new NameAnnotation();
            treeAnnotList.Add(__tmp143);
            this.HandleSymbolType(context);
            return base.VisitNameDef(context);
        }
        
        public override object VisitQualifiedNameDef(SoalParser.QualifiedNameDefContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            NameAnnotation __tmp144 = new NameAnnotation();
            treeAnnotList.Add(__tmp144);
            this.HandleSymbolType(context);
            return base.VisitQualifiedNameDef(context);
        }
        
        public override object VisitIdentifier(SoalParser.IdentifierContext context)
        {
            List<object> treeAnnotList = null;
            if (!this.treeAnnotations.TryGetValue(context, out treeAnnotList))
            {
                treeAnnotList = new List<object>();
                this.treeAnnotations.Add(context, treeAnnotList);
            }
            IdentifierAnnotation __tmp145 = new IdentifierAnnotation();
            treeAnnotList.Add(__tmp145);
            this.HandleSymbolType(context);
            return base.VisitIdentifier(context);
        }
        
        public override object VisitIdentifiers(SoalParser.IdentifiersContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIdentifiers(context);
        }
        
        public override object VisitLiteral(SoalParser.LiteralContext context)
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
                ValueAnnotation __tmp146 = new ValueAnnotation();
                elemAnnotList.Add(__tmp146);
            }
            if (context.booleanLiteral() != null)
            {
                object elem = context.booleanLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp147 = new ValueAnnotation();
                elemAnnotList.Add(__tmp147);
            }
            if (context.integerLiteral() != null)
            {
                object elem = context.integerLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp148 = new ValueAnnotation();
                elemAnnotList.Add(__tmp148);
            }
            if (context.decimalLiteral() != null)
            {
                object elem = context.decimalLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp149 = new ValueAnnotation();
                elemAnnotList.Add(__tmp149);
            }
            if (context.scientificLiteral() != null)
            {
                object elem = context.scientificLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp150 = new ValueAnnotation();
                elemAnnotList.Add(__tmp150);
            }
            if (context.stringLiteral() != null)
            {
                object elem = context.stringLiteral();
                if (!this.treeAnnotations.TryGetValue(elem, out elemAnnotList))
                {
                    elemAnnotList = new List<object>();
                    this.treeAnnotations.Add(elem, elemAnnotList);
                }
                ValueAnnotation __tmp151 = new ValueAnnotation();
                elemAnnotList.Add(__tmp151);
            }
            this.HandleSymbolType(context);
            return base.VisitLiteral(context);
        }
        
        public override object VisitNullLiteral(SoalParser.NullLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitNullLiteral(context);
        }
        
        public override object VisitBooleanLiteral(SoalParser.BooleanLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitBooleanLiteral(context);
        }
        
        public override object VisitIntegerLiteral(SoalParser.IntegerLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitIntegerLiteral(context);
        }
        
        public override object VisitDecimalLiteral(SoalParser.DecimalLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitDecimalLiteral(context);
        }
        
        public override object VisitScientificLiteral(SoalParser.ScientificLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitScientificLiteral(context);
        }
        
        public override object VisitStringLiteral(SoalParser.StringLiteralContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitStringLiteral(context);
        }
        
        public override object VisitContextualKeywords(SoalParser.ContextualKeywordsContext context)
        {
            this.HandleSymbolType(context);
            return base.VisitContextualKeywords(context);
        }
    }
    
    public class SoalParserPropertyEvaluator : MetaCompilerPropertyEvaluator, ISoalParserVisitor<object>
    {
        public SoalParserPropertyEvaluator(MetaCompiler compiler)
            : base(compiler)
        {
        }
        
        public virtual object VisitMain(SoalParser.MainContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedName(SoalParser.QualifiedNameContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifierList(SoalParser.IdentifierListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedNameList(SoalParser.QualifiedNameListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationList(SoalParser.AnnotationListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnAnnotationList(SoalParser.ReturnAnnotationListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotation(SoalParser.AnnotationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnAnnotation(SoalParser.ReturnAnnotationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationProperties(SoalParser.AnnotationPropertiesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationPropertyList(SoalParser.AnnotationPropertyListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationProperty(SoalParser.AnnotationPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAnnotationPropertyValue(SoalParser.AnnotationPropertyValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNamespaceDeclaration(SoalParser.NamespaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDeclaration(SoalParser.DeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumDeclaration(SoalParser.EnumDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumLiterals(SoalParser.EnumLiteralsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnumLiteral(SoalParser.EnumLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStructDeclaration(SoalParser.StructDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitPropertyDeclaration(SoalParser.PropertyDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDatabaseDeclaration(SoalParser.DatabaseDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEntityReference(SoalParser.EntityReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitInterfaceDeclaration(SoalParser.InterfaceDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParameterList(SoalParser.ParameterListContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitParameter(SoalParser.ParameterContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationResult(SoalParser.OperationResultContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentDeclaration(SoalParser.ComponentDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentElements(SoalParser.ComponentElementsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentElement(SoalParser.ComponentElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentService(SoalParser.ComponentServiceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentReference(SoalParser.ComponentReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentServiceOrReferenceEmptyBody(SoalParser.ComponentServiceOrReferenceEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentServiceOrReferenceNonEmptyBody(SoalParser.ComponentServiceOrReferenceNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentServiceOrReferenceElement(SoalParser.ComponentServiceOrReferenceElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentProperty(SoalParser.ComponentPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentImplementation(SoalParser.ComponentImplementationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitComponentLanguage(SoalParser.ComponentLanguageContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCompositeDeclaration(SoalParser.CompositeDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssemblyDeclaration(SoalParser.AssemblyDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCompositeElements(SoalParser.CompositeElementsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCompositeElement(SoalParser.CompositeElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCompositeComponent(SoalParser.CompositeComponentContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitCompositeWire(SoalParser.CompositeWireContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitWireSource(SoalParser.WireSourceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitWireTarget(SoalParser.WireTargetContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDeploymentDeclaration(SoalParser.DeploymentDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDeploymentElements(SoalParser.DeploymentElementsContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDeploymentElement(SoalParser.DeploymentElementContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEnvironmentDeclaration(SoalParser.EnvironmentDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuntimeDeclaration(SoalParser.RuntimeDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRuntimeReference(SoalParser.RuntimeReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitAssemblyReference(SoalParser.AssemblyReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDatabaseReference(SoalParser.DatabaseReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBindingDeclaration(SoalParser.BindingDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBindingLayers(SoalParser.BindingLayersContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTransportLayer(SoalParser.TransportLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpTransportLayer(SoalParser.HttpTransportLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpTransportLayerEmptyBody(SoalParser.HttpTransportLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpTransportLayerNonEmptyBody(SoalParser.HttpTransportLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRestTransportLayer(SoalParser.RestTransportLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRestTransportLayerEmptyBody(SoalParser.RestTransportLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitRestTransportLayerNonEmptyBody(SoalParser.RestTransportLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitWebSocketTransportLayer(SoalParser.WebSocketTransportLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitWebSocketTransportLayerEmptyBody(SoalParser.WebSocketTransportLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitWebSocketTransportLayerNonEmptyBody(SoalParser.WebSocketTransportLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpTransportLayerProperties(SoalParser.HttpTransportLayerPropertiesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpSslProperty(SoalParser.HttpSslPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitHttpClientAuthenticationProperty(SoalParser.HttpClientAuthenticationPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEncodingLayer(SoalParser.EncodingLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapEncodingLayer(SoalParser.SoapEncodingLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapEncodingLayerEmptyBody(SoalParser.SoapEncodingLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapEncodingLayerNonEmptyBody(SoalParser.SoapEncodingLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitXmlEncodingLayer(SoalParser.XmlEncodingLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitXmlEncodingLayerEmptyBody(SoalParser.XmlEncodingLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitXmlEncodingLayerNonEmptyBody(SoalParser.XmlEncodingLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitJsonEncodingLayer(SoalParser.JsonEncodingLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitJsonEncodingLayerEmptyBody(SoalParser.JsonEncodingLayerEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitJsonEncodingLayerNonEmptyBody(SoalParser.JsonEncodingLayerNonEmptyBodyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapEncodingProperties(SoalParser.SoapEncodingPropertiesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapVersionProperty(SoalParser.SoapVersionPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapMtomProperty(SoalParser.SoapMtomPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSoapStyleProperty(SoalParser.SoapStylePropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitProtocolLayer(SoalParser.ProtocolLayerContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointProperties(SoalParser.EndpointPropertiesContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointProperty(SoalParser.EndpointPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointBindingProperty(SoalParser.EndpointBindingPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitEndpointAddressProperty(SoalParser.EndpointAddressPropertyContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReturnType(SoalParser.ReturnTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeReference(SoalParser.TypeReferenceContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSimpleType(SoalParser.SimpleTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNulledType(SoalParser.NulledTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitReferenceType(SoalParser.ReferenceTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitObjectType(SoalParser.ObjectTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitValueType(SoalParser.ValueTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitVoidType(SoalParser.VoidTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOnewayType(SoalParser.OnewayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitOperationReturnType(SoalParser.OperationReturnTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullableType(SoalParser.NullableTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNonNullableType(SoalParser.NonNullableTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNonNullableArrayType(SoalParser.NonNullableArrayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitArrayType(SoalParser.ArrayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitSimpleArrayType(SoalParser.SimpleArrayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNulledArrayType(SoalParser.NulledArrayTypeContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitConstantValue(SoalParser.ConstantValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitTypeofValue(SoalParser.TypeofValueContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNameDef(SoalParser.NameDefContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitQualifiedNameDef(SoalParser.QualifiedNameDefContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifier(SoalParser.IdentifierContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIdentifiers(SoalParser.IdentifiersContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitLiteral(SoalParser.LiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitNullLiteral(SoalParser.NullLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitBooleanLiteral(SoalParser.BooleanLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitIntegerLiteral(SoalParser.IntegerLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitDecimalLiteral(SoalParser.DecimalLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitScientificLiteral(SoalParser.ScientificLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitStringLiteral(SoalParser.StringLiteralContext context)
        {
            return this.VisitChildren(context);
        }
        
        public virtual object VisitContextualKeywords(SoalParser.ContextualKeywordsContext context)
        {
            return this.VisitChildren(context);
        }
    }
    public abstract class SoalCompilerBase : MetaCompiler
    {
        public SoalCompilerBase(string source, string fileName)
            : base(source, fileName)
        {
        }
        
        protected override void DoCompile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new SoalLexer(inputStream);
            this.Lexer.AddErrorListener(this);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new SoalParser(this.CommonTokenStream);
            this.Parser.AddErrorListener(this);
            this.ParseTree = this.Parser.main();
            if (!this.Diagnostics.HasErrors())
            {
                SoalParserAnnotator annotator = new SoalParserAnnotator(this);
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
                SoalParserPropertyEvaluator propertyEvaluator = new SoalParserPropertyEvaluator(this);
                propertyEvaluator.Visit(this.ParseTree);
                
                this.Model.EvaluateLazyValues();
            }
        }
        
        public SoalParser.MainContext ParseTree { get; private set; }
        public SoalLexer Lexer { get; private set; }
        public SoalParser Parser { get; private set; }
    }
}
*/